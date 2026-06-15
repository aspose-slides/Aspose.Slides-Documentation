---
title: Kurulum
type: docs
weight: 70
url: /tr/php-java/installation/
keywords:
- Aspose.Slides'ı kur
- Aspose.Slides'ı indir
- Aspose.Slides'ı kullan
- Aspose.Slides kurulumu
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'ı hızlıca kurun. Adım adım kılavuz, sistem gereksinimleri ve kod örnekleri — bugün PowerPoint sunumlarıyla çalışmaya başlayın!"
---
## **Genel Bakış**

Bu makale, Aspose.Slides for PHP via Java nasıl kurulup yapılandırılacağını açıklar. Gerekli ortam kurulumunu, kütüphanenin Packagist üzerinden indirilmesini, Apache Tomcat'in PHP/Java Bridge ile yapılandırılmasını ve kurulumu doğrulamak için bir örnek çalıştırılmasını kapsar.

## **Ortamı Yapılandırma**

1. PHP 7'yi kurun, PHP yolunu sistem `PATH` değişkenine ekleyin ve `php.ini` dosyasında `allow_url_include` ayarını `On` olarak belirleyin.  
2. JRE 8'i kurun. `JAVA_HOME` ortam değişkenini kurulu JRE'nin yoluna ayarlayın.  
3. Apache Tomcat 8.0'ı kurun.

## **Aspose.Slides for PHP via Java'ı İndirme** 

`packagist` Aspose.Slides for PHP via Java'ı indirmek için en kolay yoldur.

Aspose.Slides'ı Packagist kullanarak kurmak için şu komutu çalıştırın: 
```bash
   composer require aspose/slides
   ```

## **Apache Tomcat'ı Yapılandırma**

1. PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) dosyasını http://php-java-bridge.sourceforge.net/pjb/download.php adresinden indirin ve `JavaBridge.war` dosyasını tomcat `webapps` klasörüne çıkarın.  
2. Apache Tomcat hizmetini başlatın.  
3. [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/tr/php-java) dosyasını indirin ve `aspose.slides` klasörüne çıkarın. `jar/aspose-slides-x.x-php.jar` dosyasını `webapps\JavaBridge\WEB-INF\lib` klasörüne kopyalayın. **PHP 8** kullanıyorsanız, PHP-Java Bridge'ten gelen orijinal `Java.inc` dosyasını `Java.inc.php8.zip` içindeki `Java.inc` ile değiştirin.  
4. Apache Tomcat hizmetini yeniden başlatın.  
5. Örneği çalıştırmak için `aspose.slides` klasöründeki `example.php` dosyasını şu komutla çalıştırın:  
```bash
   php example.php
   ```

## **SSS**

**Aspose.Slides'ın doğru şekilde entegre edildiğini nasıl doğrulayabilirim?**

Projenizi derleyin, boş bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği oluşturun ve yeni bir adla kaydedin. Dosya istisna fırlatmadan oluşturulursa, kütüphane başarılı bir şekilde entegre edilmiştir.

**Büyük sunumları işlerken bellek tüketimini nasıl sınırlayabilirim?**

JVM bellek limitlerini yalnızca ihtiyaç duyulan seviyeye yükseltin ve her bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneğini `finally` bloğunda kapatarak önbelleği hemen serbest bırakın. Bu, bellek yetersizliği hatalarını önler ve toplu işlemler sırasında toplam bellek kullanımının öngörülebilir olmasını sağlar.

**İstenmeyen dışa aktarım formatlarını dışarı çıkararak JAR boyutunu küçültebilir miyim?**

Mevcut Aspose.Slides sürümleri tek bir monolitik kütüphane olarak sunulduğu için, derleme zamanında PDF veya SVG gibi belirli dışa aktarıcıları devre dışı bırakamazsınız.