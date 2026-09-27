---
title: Kurulum
type: docs
weight: 70
url: /tr/java/installation/
keywords:
- Aspose.Slides yükleme
- Aspose.Slides indirme
- Aspose.Slides kullanma
- Aspose.Slides kurulumu
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose'un Maven deposundan ya da JAR dosyası olarak Aspose.Slides for Java'ı kurun, Linux önkoşullarını ayarlayın ve ilk programla kurulumu kontrol edin."
---
## **Genel Bakış**

Bu makale, bir projeye Aspose.Slides for Java eklemenin nasıl yapılacağını açıklar. Aspose.Slides for Java, Aspose'un kendi Maven deposunda yayımlanır, Maven Central'da değildir; bu nedenle bir Maven projesi bu depoyu bildirmelidir. Ayrıca JAR dosyasını indirip sınıf yoluna manuel olarak ekleyebilirsiniz. Her iki yol da kütüphanenin çalıştığını doğrulayan kısa bir programla sonuçlanır.

Aspose.Slides for Java, Microsoft PowerPoint gerektirmez. Gerekli sunum dosyalarını programlı olarak oluşturur. Ancak oluşturulan sunumları görüntülemek için Microsoft PowerPoint veya başka bir sunum görüntüleyiciye ihtiyaç duyabilirsiniz.

## **Önkoşullar**

- Bir Java Development Kit (JDK). Bu makaledeki proje ve komutlar JDK 11 veya daha yenisini gerektirir. JDK 11'de, kurulum kontrol programı “WARNING: An illegal reflective access operation has occurred” ile başlayan bir uyarı verir; bu sonuçları etkilemez ve göz ardı edilebilir.
- [Apache Maven](https://maven.apache.org/install.html), Maven yolunu kullanıyorsanız.
- Linux'ta, fontconfig kütüphanesi ve en az bir yüklü font. Bkz. [Linux](#linux).

## **Maven Deposu'ndan Kurulum**

Aspose, Java kütüphanelerini kendi [Maven deposunda](https://releases.aspose.com/java/repo/com/aspose/) barındırır. Bir Maven projesinde [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) kullanmak için *pom.xml* dosyanıza iki giriş ekleyin.

1. **Aspose Maven deposunu bildiriniz.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Aspose.Slides for Java bağımlılığını ekleyiniz.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

`jdk16` sınıflandırıcısı gereklidir: kütüphanenin Java SE derlemesini seçer. `26.9` yerine [depolarda](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) listelenen en yeni sürümü koyun. Depo, her JAR dosyasının yanında bir SHA-1 kontrol toplamı dosyası yayınlar; Maven indirme sırasında bunu doğrular.

### **Kurulumu Kontrol Et**

Yeni bir proje ile kurulumu kontrol etmek için:

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
               <version>26.9</version>
               <classifier>jdk16</classifier>
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

   Depo ve bağımlılığın yanı sıra bu *pom.xml*, derleme için Java sürümünü ayarlar, `mvn exec:java` komutunun çalıştıracağı sınıfı belirtir ve derleyici eklentisini sabitleyerek bazı Maven kurulumlarının varsayılan olarak yoksaydığı `maven.compiler.release` ayarını etkinleştirir.

2. İlk örneği [Create Presentations](/slides/tr/java/create-presentation/) adresinden alın ve *src/main/java/HelloSlides.java* olarak kaydedin.

3. Proje klasöründe çalıştırın:

   ```bash
   mvn compile exec:java
   ```

Maven, Aspose.Slides for Java'ı indirir, programı derler ve çalıştırır. Program, proje klasöründe *new_presentation.pptx* dosyasını kaydeder.

## **Maven Olmadan JAR Dosyasını Kullanma**

1. Depodaki [sürüm klasöründen](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) *aspose-slides-26.9-jdk16.jar* dosyasını indirin. Başka bir sürüm için, [depo](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) içindeki ilgili klasöre gidin ve *-jdk16.jar* ile biten dosyayı indirin.
2. İlk örneği aynı klasörde *HelloSlides.java* olarak kaydedin.
3. O klasörde çalıştırın:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

JDK tek kaynak dosyasını derler ve çalıştırır; program klasörde *new_presentation.pptx* dosyasını kaydeder. Kendi uygulamanızda, JAR dosyasını derleme aracınızın veya IDE'nizin sınıf yoluna ekleyin.

## **Linux**

Aspose.Slides for Java, Linux'ta fontconfig kütüphanesini ve en az bir yüklü fontu gerektiren Java font desteğini kullanır. Bu bileşenler olmadan, “Fontconfig head is null, check your fonts or fonts configuration” hatasıyla sunum kaydedilemez. Minimal sunucu ve konteyner görüntüleri her ikisini de eksik bırakabilir; örneğin resmi Ubuntu konteyner görüntüsü hiçbirine sahip değildir.

Debian ve Ubuntu'da aşağıdaki komut bir JDK, Maven, fontconfig ve DejaVu fontlarını kurar:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Sunumlarınızda kullanılan fontlar veya uygun ikameler de metnin doğru görüntülenmesi için kurulmalıdır.

## **FAQ**

### Aspose.Slides'ın doğru bir şekilde entegre edildiğini nasıl doğrularım?

Projenizi derleyin, boş bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) nesnesi oluşturun ve yeni bir adla kaydedin. Dosya istisna fırlatmadan oluşturulursa, kütüphane başarıyla entegre edilmiştir.

### Büyük sunumlar işlenirken bellek tüketimini nasıl sınırlayabilirim?

JVM bellek limitlerini yalnızca ihtiyaç duyulan seviyeye yükseltin ve her [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) örneğinde bir `finally` bloğu içinde [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) metodunu çağırarak önbelleği hemen serbest bırakın. Bu, bellek yetersizliği hatalarını önler ve toplu işlemler sırasında genel bellek kullanımını öngörülebilir tutar.

### Gereksiz dışa aktarma formatlarını dışarı çıkararak final JAR boyutunu küçültebilir miyim?

Mevcut Aspose.Slides sürümleri tek bir monolitik kütüphane olarak dağıtılır; bu yüzden derleme zamanında PDF veya SVG gibi belirli dışa aktarıcıları devre dışı bırakamazsınız.