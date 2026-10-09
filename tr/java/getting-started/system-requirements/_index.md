---
title: Sistem Gereksinimleri
type: docs
weight: 60
url: /tr/java/system-requirements/
keywords:
- sistem gereksinimleri
- desteklenen platformlar
- Java sürümleri
- JDK
- JRE
- fontconfig
- fontlar
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'ı kurmadan önce neye ihtiyaç duyduğunu kontrol edin: desteklenen Java sürümleri ve işletim sistemleri, ayrıca Linux'un gerektirdiği font kütüphanesi ve fontlar."
---
## **Giriş**

Aspose.Slides for Java, bağımsız bir kütüphanedir: Microsoft PowerPoint veya Microsoft Office gerektirmez. Aspose'un Maven deposunda yayımlanan tek bir JAR dosyasıdır. JAR dosyası yalnızca Java sınıfları ve kaynakları içerir, yerel kütüphaneler içermez ve başka kütüphanelere bağımlılık bildirmaz. Bu aynı dosya, desteklenen bir Java çalışma zamanı bulunan her işletim sistemi ve işlemci üzerinde çalışır.

Bu makale, desteklenen Java sürümlerini ve işletim sistemlerini, Linux'un ihtiyaç duyduğu font kütüphanesini ve fontları listeler ve ardından ayarlarınızı kontrol eden kısa bir programla sona erer. Kütüphaneyi bir projeye eklemek için [Kurulum](/slides/tr/java/installation/) bölümüne bakın.

## **Desteklenen Java Sürümleri**

Aspose.Slides for Java, Java 8 veya daha yeni bir sürümde, JDK veya JRE ile çalışır. Bu, uzun vadeli destek sürümleri Java 8, 11, 17, 21 ve 25 ve Java 26 ve Java 27 gibi sonraki sürümleri içerir. Java çalışma zamanı, örneğin Eclipse Temurin, Amazon Corretto, Oracle veya bir Linux dağıtımının OpenJDK paketleri gibi herhangi bir satıcıdan gelebilir.

Aspose.Slides, bu sürümlerin hiçbirinde `--add-opens` gibi JVM seçeneklerine ihtiyaç duymaz. Java 11'de, JVM "WARNING: An illegal reflective access operation has occurred" ile başlayan bir uyarı verir; bu uyarı sonuca etki etmez.

{{% alert color="warning" title="Warning" %}}
Java 6 ve Java 7 kullanımdan kaldırılmıştır. Aspose.Slides for Java 26.9 hâlâ bu sürümlerde çalışır ancak bir kullanımdan kaldırma uyarısı verir. 26.10 sürümünden itibaren minimum Java 8'dir ve Java 6 ve Java 7 artık desteklenmez.
{{% /alert %}}

Maven projesi ve [Kurulum](/slides/tr/java/installation/) içindeki komutlar JDK 11 veya daha yenisini gerektirir. Java 8 ile, programınızı [Kurulumunuzu Kontrol Edin](#check-your-setup) bölümünde gösterildiği gibi derleyip çalıştırın.

## **Desteklenen İşletim Sistemleri**

JAR dosyası yerel kod içermediğinden, Aspose.Slides for Java Windows, Linux ve macOS üzerinde, Java çalışma zamanının desteklediği herhangi bir işlemci mimarisinde, örneğin x64 ve ARM64, çalışır. Windows'ta tek gereksinim Java çalışma zamanıdır. Linux'ta, Java'nın font desteği ayrıca [Linux](#linux) bölümünde açıklanan font kütüphanesini ve fontları da gerektirir.

## **Linux**

Aspose.Slides for Java, metni Java çalışma zamanının font desteğiyle yerleştirir ve çizer. Linux'ta bu destek, fontconfig kütüphanesini ve en az bir kurulu fontu gerektirir. Linux dağıtımlarının resmi konteyner imajları genellikle bu bileşenlere sahip değildir. Bunlar olmadan, [Sunum Oluşturma](/slides/tr/java/create-presentation/) içindeki ilk örnek, sunumu kaydederken başarısız olur, boş bir dosya bırakır ve şu hatayı raporlar:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Resmi `eclipse-temurin` konteyner imajları Ubuntu ve Alpine Linux için zaten fontconfig ve DejaVu fontlarını içerir, bu nedenle hiçbir şey yüklemenize gerek yoktur. Diğer sistemlerde, aşağıdaki paketleri kurun. Debian, Ubuntu ve Red Hat komutları `sudo` kullanır; bir Dockerfile içinde, `sudo` olmadan bir `RUN` talimatı içinde çalıştırın. DejaVu fontları, Aspose.Slides'ın çalışması için yeterlidir; sunumlarınızın kullandığı fontlar [Fontlar](#fonts) bölümünde ele alınmıştır.

### **Debian ve Ubuntu**

Debian veya Ubuntu paketlerinden varsayılan `apt-get` ayarlarıyla Java'yı kurarsanız, [Kurulum](/slides/tr/java/installation/#linux) bölümündeki komut gibi, Java paketleri aynı zamanda fontconfig kütüphanesini, DejaVu fontlarını ve bu Java paketlerinin ihtiyaç duyduğu HarfBuzz kütüphanesini de kurar ve başka bir şeye gerek kalmaz.

Eclipse Temurin arşivi gibi başka bir kaynaktan bir Java çalışma zamanı kullanıyorsanız, fontconfig ve DejaVu fontlarını kurun:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Bir Dockerfile genellikle `--no-install-recommends` seçeneğiyle `openjdk-21-jdk-headless` veya `default-jdk-headless` gibi Debian veya Ubuntu Java paketlerini kurar; bu seçenek üçünü de atlar. Yukarıdaki komutla fontconfig ve DejaVu fontlarını kurun ve ayrıca HarfBuzz'u da kurun:

```bash
sudo apt-get install -y libharfbuzz0b
```

HarfBuzz olmadan, bu Java paketleri `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` mesajını verir ve kaydetme, `libharfbuzz.so.0` açılamıyor hatasını bildiren bir `UnsatisfiedLinkError` ile başarısız olur.

### **Red Hat Enterprise Linux**

Red Hat Enterprise Linux'un `java-<version>-openjdk-headless` paketleri fontconfig kütüphanesini kurmaz. Bunu DejaVu fontlarıyla birlikte kurun:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Tam `java-<version>-openjdk` paketleri fontconfig ve fontları bağımlılık olarak kurar ve Amazon Linux 2023'ün Amazon Corretto paketleri de, örneğin `java-21-amazon-corretto-headless`, aynı şekilde kurar.

### **Alpine Linux**

Alpine Linux tabanlı bir Dockerfile'da, fontconfig ve DejaVu fontlarını kurun:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Mevcut Alpine sürümlerinde, `ttf-dejavu` `font-dejavu` paketini kurar. Java'yı `openjdk<version>-jre` veya `openjdk<version>-jdk` paketiyle kurun, örneğin `openjdk25-jdk`. Alpine Linux'un `openjdk<version>-jre-headless` paketleri Java'nın font kütüphanesini içermez, bu yüzden fontlar yüklü olsa bile program `UnsatisfiedLinkError: no fontmanager in system library path` hatasıyla başarısız olur.

### **Fontlar**

Metnin doğru font ve metriklerle renderlanabilmesi için, sunumlarınızın kullandığı fontlar veya uygun ikameler sistemde yüklü olmalı ya da uygulamanız tarafından yüklenmelidir. [Fontları Dağıt](/slides/tr/java/deploy-fonts/), [Font İkamesi](/slides/tr/java/font-substitution/) ve [Özel Fontlar](/slides/tr/java/custom-font/) bölümlerine bakın.

## **Kurulumunuzu Kontrol Edin**

Kütüphanenin ve gereksinimlerinin mevcut olduğunu kontrol etmek için, bir sunumu kaydedip bir slaytı görüntüye dönüştüren bir program çalıştırın. Kaydetme ve renderleme, yukarıdaki Linux gereksinimlerinin sağladığı Java çalışma zamanı font desteğini kullanır.

Aşağıdaki kodu, Aspose.Slides JAR dosyasını içeren klasöre *CheckSetup.java* olarak kaydedin. JAR dosyasını indirmek için [Maven olmadan JAR Dosyasını Kullan](/slides/tr/java/installation/#use-the-jar-file-without-maven) bölümüne bakın.

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // İlk slayta metin içeren bir dikdörtgen ekleyin ve sunumu kaydedin.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Slaytı nokta başına bir piksel olarak render edin ve görüntüyü kaydedin.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

JDK 11 veya daha yeni bir sürümle, aşağıdaki komutla aynı klasörde programı çalıştırın. JAR dosyanızın adı farklıysa, komutlardaki adı değiştirin.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Java 8 ile veya yalnızca JRE olan bir sistemde, programı bir JDK'dan `javac` ile derleyip ardından derlenmiş sınıfı çalıştırın. Linux ve macOS'ta çalıştırın:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

Windows'ta aynı `javac` komutunu çalıştırın ve ardından sınıf yolunu ayırıcı olarak noktalı virgül kullanarak sınıfı çalıştırın. Tırnakları koruyun, böylece PowerShell noktalı virgülü komutun sonu olarak kabul etmez: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

Program, ilk slayta metin içeren bir dikdörtgen ekler ve sunumu *hello.pptx* olarak [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemiyle kaydeder. Ardından slaytı [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) ile render eder ve sonucu *hello.png* olarak [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) yöntemiyle [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/) formatında kaydeder. 1 ölçek faktörü her nokta başına bir piksel render eder, bu yüzden varsayılan 720 × 540 nokta slayt 720 × 540 piksel görsele dönüşür ve metin dikdörtgen içinde görünür. Lisans olmadan, iki dosya da bir değerlendirme filigranı taşır; detaylar için [Lisanslama](/slides/tr/java/licensing/) bölümüne bakın. Bir gereksinim eksikse, program [Linux](#linux) bölümünde açıklanan hatalardan biriyle durur.

## **Geliştirme Araçları**

Aspose.Slides kullanan uygulamaları, desteklenen bir Java sürümünün herhangi bir JDK'sı ile oluşturabilirsiniz. [Kurulum](/slides/tr/java/installation/) bölümünde açıklandığı gibi Aspose'un Maven deposu ile Apache Maven kullanın veya bir Maven deposu kullanabilen başka bir derleme aracını kullanın. JAR dosyasını IDE'nizin veya derleme aracınızın sınıf yoluna kendiniz de ekleyebilirsiniz.

## **SSS**

**Dönüştürmeler ve renderleme için Microsoft PowerPoint yüklü olması gerekir mi?**

Hayır, PowerPoint gerekli değildir. Aspose.Slides, sunumları [oluşturma](/slides/tr/java/create-presentation/), düzenleme, [dönüştürme](/slides/tr/java/convert-presentation/) ve [renderleme](/slides/tr/java/convert-powerpoint-to-png/) için bağımsız bir motorudur.

**Aspose.Slides for Java, Linux sunucusunda bir görüntü birimi veya masaüstü ortamına ihtiyaç duyar mı?**

Hayır. Aspose.Slides, bir X sunucusuna veya ekrana ihtiyaç duymaz, bu yüzden sunucularda ve konteynerlerde çalışır. Linux'ta yalnızca [Linux](#linux) bölümünde açıklanan font kütüphanesi ve fontlara ihtiyaç duyar.

**Doğru renderleme için hangi fontlar gerekir?**

Sunumda kullanılan fontlar veya uygun [ikamelere](/slides/tr/java/font-substitution/) sahip olmak gerekir. Linux ve macOS'ta, tutarlı renderleme için sunumlarınızın ihtiyaç duyduğu font paketlerini kurun.

**Neden özel bir font Linux'ta yedek veya eksik metin olarak renderlanıyor?**

Font dosyasındaki ad tablosu kayıtları tutarsız veya bozuk ise, Linux font eşleştirme yığını (FreeType/fontconfig) geçersiz bir kaydı seçebilir ve fontun çözülememesine yol açar. Düzeltilmiş ad tablosu kayıtlarına sahip bir font sürümü kullanmak veya tutarlı bir yedek kurmak sorunu çözer.