# Music Market
Enstrüman satışı yapılan, kullanıcıların siteye kayıt olup giriş yapabildiği, müşteri ise ürün listeleyebildiği sepete ürün atabildiği; admin ise ürünler ekleme, silme ve güncelleme işlemlerini yapabildiği bir e-ticaret web uygulamasıdır. 

# Hazırlayanlar
B201210056 Kemal Aydın
B201210038 Beyza Erkan

# Kullanılan Teknolojiler
    - Asp.Net Core 6 MVC
    - PostgreSQL
    - Entity Framework Core ORM
    - Bootstrap Tema
    - HTML5, CSS3, Javascript

# Kurulum
## Projeyi İndirme

Projeyi lokalinize "MusicMarket" adıyla çekmek için:

```bash
git clone https://github.com/beyzaerkan/MusicMarket.git`
```

MusicMarket Projenin içine girmek için:
```bash
cd MusicMarket
```

.sln dosyası sayesinde proje Visual Studio destekleyen ortamlarda çalıştırılabilir. Linux üzerindeyseniz `cd MusicMarket` komutu ile ana koda girmeniz ve daha sonra aşağıdaki işlemleri yapmanız gerekmektedir.

PostgreSQL üzerinde `musicmarket` adında bir veritabanı oluşturun ve ardından MusicMarket/appsettings.json dosyasındaki `ConnectionStrings` key'i içindeki `DefaultConnection` key'inin değerinde bulunan User ID kısmına PostgreSQL kullanıcı isminizi ve Password kısmına şifrenizi yazınız.

## Veritabanı migrasyonu
#### Terminalden çalıştırmak için
    dotnet ef database update

Entity Framework'un kurulu olduğunu varsayarak tabloları oluşturmak için
#### Package Manager'dan çalıştırmak için
    Update-Database
    
## Katkıda Bulunanlar

<a href = "https://github.com/beyzaerkan/MusicMarket/graphs/contributors">
  <img src = "https://contrib.rocks/image?repo=beyzaerkan/MusicMarket"/>
</a>