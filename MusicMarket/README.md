Dotnet Core, Entity Framework, PostgreSQL, BootStrap gibi teknolojiler kullanılarak geliştirilen, Sakarya Üniversitesi Bilgisayar Mühendisliği Web Programlama dersi ödevi çerçevesinde yapılan şirket satış yazılımıdır.

#Hazılayanlar

B201210056 Kemal Aydın
B201210038 Beyza Erkan

#İçindekiler
    Kurulum
    Lisans
    Dosya Yapısı

#Kurulum

Projeyi İndirme

Projeyi lokalinize "MusicMarket" adıyla çekmek için:

git clone https://github.com/beyzaerkan/MusicMarket.git

MusicMarket Projenin içine girmek için:

cd MusicMarket
.sln dosyası sayesinde proje Visual Studio destekleyen ortamlarda çalıştırılabilir. Linux üzerindeyseniz cd WebApplication2 komutu ile ana koda girmeniz ve ondan sonra aşağıdaki işlemleri yapmanız gerekmektedir.
PostgreSQL üzerinde webdb adında bir veritabanı oluşturun ve ardından WebApplication2/appsettings.json dosyasındaki ConnectionStrings key'i içindeki DefaultConnection key'inin değerinde bulunan User ID kısmına PostgreSQL kullanıcı isminizi ve Password kısmına şifrenizi yazınız.

Veritabanı migrasyonu

Entity Framework'un kurulu olduğunu varsayarak tabloları oluşturmak için

# Terminalden çalıştırmak için
    dotnet ef database update
# Package Manager'dan çalıştırmak için
    Update-Database
    Ayağa kaldırma