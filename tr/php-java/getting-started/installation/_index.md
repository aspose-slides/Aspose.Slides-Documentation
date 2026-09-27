---
title: Kurulum
type: docs
weight: 70
url: /tr/php-java/installation/
keywords:
- Aspose.Slides kurulum
- Aspose.Slides indirme
- Aspose.Slides kullanma
- Aspose.Slides kurulumu
- Windows
- Linux
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Linux ve Windows'ta PHP için Java aracılığıyla Aspose.Slides'i kurun: PHP, Java, Apache Tomcat ve PHP/Java Bridge'i ayarlayın, paketi Composer ile ekleyin ve kısa bir betikle kurulumu doğrulayın."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java iki süreçte çalışır. PHP betiğiniz, her çağrıyı PHP/Java Bridge üzerinden Aspose.Slides'e gönderen PHP sınıflarını kullanır; Aspose.Slides, Apache Tomcat içinde Java üzerinde çalışır. Bu makale, her iki tarafı nasıl yapılandıracağınızı, paketi Composer ile nasıl kuracağınızı ve kurulumu doğrulamak için kısa bir betik nasıl çalıştıracağınızı açıklar.

## **Ön Koşullar**

- **PHP 7.0'dan 8.3'e kadar**, `php.ini` içinde `allow_url_include = On` ayarıyla. Betikleriniz, köprünün istemci kütüphanesi olan `Java.inc` dosyasını Tomcat üzerinden HTTP ile yükler. PHP 8.4 ve sonraki sürümlerde, PHP'nin `xml` uzantısı yüklendiğinde `Java.inc` "end() expects exactly 1 argument" hatasıyla durur ve Windows PHP derlemeleri her zaman bunu yükler.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 veya daha yeni sürüm.** Bir JRE yeterlidir.
- **Apache Tomcat 9.** PHP/Java Bridge `javax.servlet` API'si üzerine inşa edilmiştir; Tomcat 10 ve sonrası bu API'yi sağlamaz, bu yüzden köprü orada başlatılamaz.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, en son sürümü. Web uygulaması `JavaBridge.war`, Tomcat içinde çalışır.

Bu makale, Tomcat ve PHP betiklerinizi aynı bilgisayarda çalıştırır. Aspose.Slides dosyaları Tomcat içinde açar ve kaydeder, bu yüzden betiklerinizin ona gönderdiği her yolun Tomcat içinde geçerli olması gerekir.

## **Linux'ta Kurulum**

Bu komutlar, Ubuntu 24.04'te tüm dosyaları ev klasörünüze kurar. Diğer dağıtımlarda aynı paketleri dağıtımın paket yöneticisiyle kurun.

1. PHP, Composer, Java ve indirme araçlarını kurun, ardından PHP komut satırı için `allow_url_include` ayarını açın:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

1. Apache Tomcat 9 ve PHP/Java Bridge'i indirin, köprünün `JavaBridge.war` dosyasını Tomcat'in `webapps` klasörüne koyun ve Tomcat'i başlatın. Tomcat, başlaması sırasında WAR dosyasını `webapps/JavaBridge` içine açar:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

1. Bir proje klasörü oluşturun ve Aspose.Slides for PHP via Java'i [Packagist](https://packagist.org/packages/aspose/slides) üzerinden kurun:

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

1. Tomcat'i durdurun, paketten Aspose.Slides JAR dosyasını köprünün `WEB-INF/lib` klasörüne kopyalayın, köprünün `Java.inc` dosyasını paketten gelen PHP 8 sürümüyle değiştirin ve Tomcat'i tekrar başlatın:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/tr/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/tr/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   PHP 7 için `Java.inc` değişimini atlayın. Tomcat'in başlatılması birkaç saniye sürer ve betikleriniz Aspose.Slides kullanırken Tomcat'in çalışıyor olması gerekir.

## **Windows'ta Kurulum**

1. Windows için [PHP 8.3'ü](https://www.php.net/downloads.php?os=windows) kurun ve klasörünü `PATH` ortam değişkenine ekleyin. `php.ini-production` dosyasını aynı klasörde `php.ini` olarak kopyalayın. `php.ini` içinde `allow_url_include = On` ayarlayın ve `extension_dir = "ext"`, `extension=openssl` ve `extension=zip` satırlarının yorumunu kaldırın. Composer, paketleri indirmek için `openssl` ve paketleri açmak için (7‑Zip kurulu değilse veya `PATH`'de bir `unzip` komutu yoksa) `zip` uzantısına ihtiyaç duyar.
2. Composer'ı kurun: **[Composer](https://getcomposer.org/download/)**.
3. Java'yı kurun ve `JAVA_HOME` ortam değişkenini Java klasörüne ayarlayın. Tomcat, bu değişken olmadan başlatılamaz.
4. Komut İstemi'nde Apache Tomcat 9 ve PHP/Java Bridge'i indirin, köprünün `JavaBridge.war` dosyasını Tomcat'in `webapps` klasörüne koyun ve Tomcat'i başlatın. Tomcat'in betikleri, `CATALINA_HOME` değişkeni aracılığıyla Tomcat'i bulur; bu nedenle sonraki adımlar için aynı Komut İstemi penceresini kullanmaya devam edin. Tomcat, başlaması sırasında WAR dosyasını `webapps\JavaBridge` içine açar:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

1. Bir proje klasörü oluşturun ve Aspose.Slides for PHP via Java'i [Packagist](https://packagist.org/packages/aspose/slides) üzerinden kurun:

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

1. Tomcat'i durdurun, paketten Aspose.Slides JAR dosyasını köprünün `WEB-INF\lib` klasörüne kopyalayın, köprünün `Java.inc` dosyasını paketten gelen PHP 8 sürümüyle değiştirin ve Tomcat'i tekrar başlatın:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   PHP 7 için `Java.inc` değişimini atlayın. Tomcat'in başlatılması birkaç saniye sürer ve betikleriniz Aspose.Slides kullanırken Tomcat'in çalışıyor olması gerekir.

## **Kurulumu Doğrulama**

*hello.php* adlı bu betiği proje klasörüne kaydedin. Betik bir sunum oluşturur, içinde bir metin kutusu olur ve betiğin yanına kaydeder:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/tr/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Proje klasöründen çalıştırın:

```bash
   php hello.php
```

Betik *hello.pptx* dosyasını yazar; bir slayt ve içinde metin kutusu bulunur. Lisans olmadan, slayt bir deneme filigranı da içerir; bakınız **[Lisanslama](/slides/tr/php-java/licensing/)**.

Betik `aspose.slides.php` dosyasını doğrudan içerir: Composer'ın otomatik yükleyicisi bu sınıfları yükleyemez, çünkü hepsi tek bir dosyada tanımlıdır. Ayrıca `save` metoduna mutlak bir yol gönderir, çünkü Aspose.Slides Tomcat içinde çalışır ve göreli yolu Tomcat'in çalışma klasörüne göre çözer, betiğinizin klasörüne göre değil.

## **SSS**

**Aspose.Slides'in doğru şekilde entegre edildiğini nasıl doğrulayabilirim?**

[Kurulumu Doğrulama](#verify-the-installation) bölümündeki betiği çalıştırın. Hatasız bir şekilde *hello.pptx* oluşturuyorsa, PHP, PHP/Java Bridge ve Aspose.Slides birlikte çalışıyor demektir.

**Betiğim neden "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'" hatasıyla duruyor?**

PHP, `Java.inc` dosyasını Tomcat'ten yükleyemedi. Hata mesajının öncesinde `http://` sarmalayıcısının devre dışı olduğu belirtiliyorsa, PHP komut satırının kullandığı `php.ini` dosyasında `allow_url_include = On` olarak ayarlayın; hangi dosyanın yüklendiğini `php --ini` gösterir. Eğer "Connection refused" mesajı alıyorsanız, Tomcat henüz çalışmıyor demektir: Tomcat'i başlatın veya başlatılmasını birkaç saniye bekleyin.

**Büyük sunumları işlerken bellek tüketimini nasıl sınırlayabilirim?**

JVM bellek limitlerini sadece ihtiyaç duyulan kadar yükseltin ve her [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneğini bir `finally` bloğunda kapatarak önbelleği hemen serbest bırakın. Bu, bellek yetersizliği hatalarını önler ve toplu işlemler sırasında toplam bellek kullanımının öngörülebilir kalmasını sağlar.

**İstenmeyen dışa aktarım formatlarını dışarı çıkararak son JAR boyutunu küçültebilir miyim?**

Mevcut Aspose.Slides sürümleri tek bir monolitik kütüphane olarak dağıtılır; bu yüzden derleme zamanında PDF ya da SVG gibi belirli dışa aktarıcıları devre dışı bırakamazsınız.