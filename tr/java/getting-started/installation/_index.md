---
title: Kurulum
type: docs
weight: 70
url: /tr/java/installation/
keywords:
- Aspose.Slides kur
- Aspose.Slides indir
- Aspose.Slides kullan
- Aspose.Slides kurulumu
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'ı Aspose'un Maven deposundan veya bir JAR dosyası olarak kurun, Linux önkoşullarını ayarlayın ve ilk programla kurulumu kontrol edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Java'ı bir projeye nasıl ekleyeceğinizi açıklar. Aspose.Slides for Java, Aspose'un kendi Maven deposunda yayınlanır, Maven Central'da değildir, bu nedenle bir Maven projesi o depoyu bildirmelidir. Ayrıca JAR dosyasını indirip sınıf yoluna kendiniz ekleyebilirsiniz. Her iki yol da kütüphanenin çalıştığını doğrulayan kısa bir programla sona erer.

Aspose.Slides for Java, Microsoft PowerPoint gerektirmez. Gerekli sunum dosyalarını programlı olarak oluşturur. Ancak oluşturulan sunumları görüntülemek için Microsoft PowerPoint veya başka bir sunum görüntüleyici gerekebilir.

## **Önkoşullar**

- Bir Java Development Kit (JDK). Bu makaledeki proje ve komutlar JDK 11 veya daha yeni bir sürüm gerektirir. JDK 11'de, kurulumu kontrol eden program "WARNING: An illegal reflective access operation has occurred" ile başlayan bir uyarı verir; bu sonuçları etkilemez ve göz ardı edilebilir.
- [Apache Maven](https://maven.apache.org/install.html), Maven yolunu kullanıyorsanız.
- Linux'ta, fontconfig kütüphanesi ve en az bir yüklü font gerekir. Bkz. [Linux](#linux).

## **Maven Deposundan Kurulum**

Aspose, Java kütüphanelerini kendi [Maven deposunda](https://releases.aspose.com/java/repo/com/aspose/) barındırır. Bir Maven projesinde [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) kullanmak için *pom.xml* dosyanıza iki giriş ekleyin.

1. **Aspose Maven deposunu bildir.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Aspose.Slides for Java bağımlılığını ekle.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

`jdk8` sınıflandırıcısı gereklidir: kütüphanenin Java SE sürümünü seçer. `26.10` yerine, [deposunda](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) listelenen en yeni sürümü koyun. Depo, her JAR'ın yanında bir SHA-1 kontrol toplamı dosyası yayınlar; Maven, kütüphaneyi indirirken bu dosyayı kontrol eder.

### **Kurulumu Kontrol Et**

Yeni bir projeyle kurulumu kontrol etmek için:

1. Proje için bir klasör oluşturun ve bu *pom.xml* dosyasını içine kaydedin:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.10</version>
               <classifier>jdk8</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   Depo ve bağımlılığın yanı sıra, bu *pom.xml* derleme için Java sürümünü ayarlar, `mvn exec:java` komutunun çalıştıracağı sınıfı adlandırır ve derleyici eklentisini sabitler; çünkü bazı Maven kurulumlarının varsayılan olarak kullandığı eski eklenti `maven.compiler.release` ayarını göz ardı eder.

2. İlk örneği [Sunumlar Oluştur](/slides/tr/java/create-presentation/) içinde *src/main/java/HelloSlides.java* olarak kaydedin.

3. Proje klasöründe çalıştırın:

   ```bash
   mvn compile exec:java
   ```

Maven, Aspose.Slides for Java'ı indirir, programı derler ve çalıştırır. Program, *new_presentation.pptx* dosyasını proje klasörüne kaydeder.

## **Maven Olmadan JAR Dosyasını Kullan**

1. Depodaki [versiyon klasöründen](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) *aspose-slides-26.10-jdk8.jar* dosyasını indirin. Başka bir sürüm için, [depo](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) içinde ilgili klasörü açın ve *-jdk8.jar* ile biten dosyayı indirin.

2. İlk örneği [Sunumlar Oluştur](/slides/tr/java/create-presentation/) içinde *HelloSlides.java* olarak JAR dosyasıyla aynı klasöre kaydedin.

3. O klasörde çalıştırın:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

JDK, tek kaynak dosyasını derleyip çalıştırır ve program *new_presentation.pptx* dosyasını klasöre kaydeder. Kendi uygulamanızda, JAR dosyasını derleme aracınızın ya da IDE'nizin sınıf yoluna ekleyin.

## **Linux**

Aspose.Slides for Java, Java'nın font desteğini kullanır; Linux'ta bunun için fontconfig kütüphanesi ve en az bir yüklü font gerekir. Bunlar olmadan, sunum kaydedilirken "Fontconfig head is null, check your fonts or fonts configuration" hatası alınır. Minimal sunucu ve konteyner imajları her ikisini de eksik bulundurabilir; örneğin resmi Ubuntu konteyner imajı hiçbirine sahip değildir.

Debian ve Ubuntu üzerinde, bu komut bir JDK, Maven, fontconfig ve DejaVu fontlarını kurar:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Sunumlarınızda kullanılan fontların veya uygun alternatiflerin de metnin doğru görüntülenmesi için kurulmuş olması gerekir.

## **SSS**

### Aspose.Slides'ın doğru entegre edildiğini nasıl doğrulayabilirim?

Projenizi derleyin, boş bir [Sunum](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) nesnesi oluşturun ve yeni bir adla kaydedin. Dosya istisna fırlatmadan oluşturulursa, kütüphane başarılı bir şekilde entegre edilmiştir.

### Büyük sunumları işlerken bellek tüketimini nasıl sınırlayabilirim?

JVM bellek sınırlarını sadece ihtiyaç duyulan kadar yükseltin ve her bir [Sunum](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) örneğinde `finally` bloğu içinde [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) metodunu çağırarak önbelleği hızlıca serbest bırakın. Bu, bellek yetersizliği hatalarını önler ve toplu işlemler sırasında toplam bellek kullanımının öngörülebilir kalmasını sağlar.

### İstenmeyen dışa aktarma formatlarını dışarı çıkararak son JAR boyutunu küçültebilir miyim?

Mevcut Aspose.Slides sürümleri tek bir monolitik kütüphane olarak dağıtılır, bu nedenle derleme zamanında PDF veya SVG gibi belirli dışa aktarıcıları devre dışı bırakamazsınız.