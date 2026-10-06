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
- yazı tipleri
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
description: "Aspose.Slides for Java'i kurmadan önce neye ihtiyacı olduğunu kontrol edin: desteklenen Java sürümleri ve işletim sistemleri ile Linux'un gerektirdiği yazı tipi kitaplığı ve yazı tipleri."
---
## **Giriş**

Aspose.Slides for Java, bağımsız bir kütüphanedir: Microsoft PowerPoint veya Microsoft Office gerektirmez. Aspose'un Maven deposunda yayımlanan tek bir JAR dosyasıdır. JAR dosyası yalnızca Java sınıfları ve kaynakları içerir, yerel kütüphane içermez ve başka kütüphanelere bağımlılık beyan etmez. Bu aynı dosya, desteklenen bir Java çalışma zamanı bulunan her işletim sistemi ve işlemci üzerinde çalışır.

Bu makale, desteklenen Java sürümlerini ve işletim sistemlerini, Linux'un ihtiyaç duyduğu yazı tipi kitaplığını ve yazı tiplerini listeler ve kurulumunuzu kontrol eden kısa bir programla sona erer. Kütüphaneyi bir projeye eklemek için [Kurulum](/slides/tr/java/installation/) bölümüne bakın.

## **Desteklenen Java Sürümleri**

Aspose.Slides for Java, JDK veya JRE ile Java 8 veya daha yenisi üzerinde çalışır. Bu, uzun vadeli destek sürümleri Java 8, 11, 17, 21 ve 25 ile birlikte Java 26 ve Java 27 gibi sonraki sürümleri kapsar. Java çalışma zamanı, örneğin Eclipse Temurin, Amazon Corretto, Oracle veya bir Linux dağıtımının OpenJDK paketleri gibi herhangi bir sağlayıcıdan gelebilir.

Aspose.Slides, bu sürümlerin hiçbirinde `--add-opens` gibi JVM seçeneklerine ihtiyaç duymaz. Java 11'de JVM, “WARNING: An illegal reflective access operation has occurred” ile başlayan bir uyarı verir; bu uyarı sonucu etkilemez.

{{% alert color="warning" title="Warning" %}}
Java 6 ve Java 7 kullanımdan kaldırılmıştır. Aspose.Slides for Java 26.9 hâlâ bu sürümlerde çalışır ancak bir kullanımdan kaldırma uyarısı verir. 26.10 sürümünden itibaren minimum Java 8’dir ve Java 6 ve Java 7 artık desteklenmez.
{{% /alert %}}

Maven projesi ve [Kurulum](/slides/tr/java/installation/) içindeki komutlar JDK 11 veya daha yenisini gerektirir. Java 8 ile programınızı aşağıdaki **Kurulumunuzu Kontrol Edin** bölümünde gösterildiği gibi derleyip çalıştırabilirsiniz.

## **Desteklenen İşletim Sistemleri**

JAR dosyasında yerel kod bulunmadığından, Aspose.Slides for Java, Java çalışma zamanının desteklediği herhangi bir işlemci mimarisinde (x64, ARM64 vb.) Windows, Linux ve macOS üzerinde çalışır. Windows'ta yalnızca Java çalışma zamanı gereklidir. Linux'ta Java'nın yazı tipi desteği, [Linux](#linux) bölümünde açıklanan yazı tipi kitaplığı ve yazı tiplerine de ihtiyaç duyar.

## **Linux**

Aspose.Slides for Java, metni Java çalışma zamanının yazı tipi desteğiyle yerleştirir ve çizer. Linux'ta bu destek, fontconfig kitaplığı ve en az bir yüklü yazı tipine ihtiyaç duyar. Resmi Linux dağıtımı konteyner görüntüleri genellikle hiçbiri yoktur. Bu eksik olduğunda, [Sunum Oluşturma](/slides/tr/java/create-presentation/) bölümündeki ilk örnek sunumu kaydederken başarısız olur, boş bir dosya bırakır ve aşağıdaki hatayı rapor eder:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Resmi `eclipse-temurin` konteyner görüntüleri (Ubuntu ve Alpine Linux için) zaten fontconfig ve DejaVu yazı tiplerini içerir; bu yüzden ek bir kurulum gerekmez. Diğer sistemlerde aşağıdaki paketleri kurun. Debian, Ubuntu ve Red Hat komutları `sudo` kullanır; bir Dockerfile içinde `sudo` olmadan bir `RUN` talimatı içinde çalıştırın. DejaVu yazı tipleri, Aspose.Slides'in çalışması için yeterlidir; sunumlarınızın kullandığı yazı tipleri ise [Yazı Tipleri](#fonts) bölümünde ele alınır.

### **Debian ve Ubuntu**

[Kurulum](/slides/tr/java/installation/#linux) bölümündeki komutla, varsayılan `apt-get` ayarlarıyla Debian veya Ubuntu paketlerinden Java kurarsanız, Java paketleri aynı zamanda fontconfig kitaplığını, DejaVu yazı tiplerini ve bu Java paketlerinin gerektirdiği HarfBuzz kitaplığını da kurar; başka bir şey gerekmez.

Başka bir kaynaktan (örneğin bir Eclipse Temurin arşivi) Java çalışma zamanı kullanıyorsanız, fontconfig ve DejaVu yazı tiplerini şu şekilde kurun:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Bir Dockerfile genellikle `openjdk-21-jdk-headless` veya `default-jdk-headless` gibi Debian/Ubuntu Java paketlerini `--no-install-recommends` seçeneğiyle kurar; bu seçenek üç paketi de atlar. Yukarıdaki komutla fontconfig ve DejaVu yazı tiplerini kurun ve ayrıca HarfBuzz’u da ekleyin:

```bash
sudo apt-get install -y libharfbuzz0b
```

HarfBuzz kurulmazsa, bu Java paketleri `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` mesajını verir ve kaydetme, `libharfbuzz.so.0` açılamadığına dair bir `UnsatisfiedLinkError` ile başarısız olur.

### **Red Hat Enterprise Linux**

Red Hat Enterprise Linux’taki `java-<version>-openjdk-headless` paketleri fontconfig kitaplığını kurmaz. Fontconfig’u DejaVu yazı tipleriyle birlikte şu komutla kurun:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Tam `java-<version>-openjdk` paketleri bağımlılık olarak fontconfig ve yazı tiplerini kurar; Amazon Corretto paketleri (ör. `java-21-amazon-corretto-headless`) da aynı şekilde davranır.

### **Alpine Linux**

Alpine Linux tabanlı bir Dockerfile’da fontconfig ve DejaVu yazı tiplerini şu komutla kurun:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Güncel Alpine sürümlerinde `ttf-dejavu`, `font-dejavu` paketini kurar. Java’yı `openjdk<version>-jre` veya `openjdk<version>-jdk` paketiyle (ör. `openjdk25-jdk`) kurun. Alpine Linux’taki `openjdk<version>-jre-headless` paketleri Java’nın yazı tipi kitaplığını içermez; bu paketlerle program, `UnsatisfiedLinkError: no fontmanager in system library path` hatası verir, yazı tipleri kurulu olsa bile.

### **Yazı Tipleri**

Metnin doğru yazı tipleri ve ölçümleriyle render edilmesi için, sunumlarınızın kullandığı yazı tipleri veya uygun ikameleri sistemde yüklü olmalı ya da uygulamanız tarafından yüklenmelidir. Ayrıntılar için [Yazı Tiplerini Dağıtma](/slides/tr/java/deploy-fonts/), [Yazı Tipi Değiştirme](/slides/tr/java/font-substitution/) ve [Özel Yazı Tipleri](/slides/tr/java/custom-font/) bölümlerine bakın.

## **Kurulumunuzu Kontrol Edin**

Kütüphane ve gereksinimlerin doğru kurulduğunu doğrulamak için bir sunumu kaydedip bir slaytı görüntüye dönüştüren bir program çalıştırın. Kaydetme ve render işlemleri, Linux gereksinimlerinde açıklanan Java çalışma zamanı yazı tipi desteğini kullanır.

Aşağıdaki kodu *CheckSetup.java* olarak, Aspose.Slides JAR dosyasının bulunduğu klasöre kaydedin. JAR dosyasını indirmek için [Maven Olmadan JAR Dosyasını Kullanma](/slides/tr/java/installation/#use-the-jar-file-without-maven) bölümüne bakın.

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

            // Slaytı nokta başına bir piksel olacak şekilde render edin ve görüntüyü kaydedin.
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

JDK 11 veya üzeri ile, aynı klasörde aşağıdaki komutla programı çalıştırın. JAR dosyanızın adı farklıysa, komutlarda adı değiştirin.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Java 8 ile veya sadece JRE bulunan bir sistemde, bir JDK’dan `javac` ile programı derleyip derlenmiş sınıfı çalıştırın. Linux ve macOS’da şu komutu kullanın:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

Windows’da aynı `javac` komutunu çalıştırın ve ardından sınıfı, sınıf yolu ayırıcı olarak noktalı virgül (`;`) kullanarak çalıştırın. PowerShell’in noktalı virgülü komut sonu olarak görmemesi için tırnakları koruyun: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

Program, ilk slayta bir metin içeren dikdörtgen ekler ve sunumu *hello.pptx* olarak [save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemiyle kaydeder. Ardından slaytı [getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#getImage-float-float-) ile render eder ve sonucu *hello.png* olarak [IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ve [ImageFormat.Png](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imageformat/) formatı ile kaydeder. 1 ölçek faktörü, nokta başına bir piksel render eder; böylece varsayılan 720 × 540 nokta slayt, 720 × 540 piksel bir görüntüye dönüşür ve metin dikdörtgen içinde görünür. Lisans olmadan her iki dosya da bir değerlendirme filigranı taşır; ayrıntılar için [Lisanslama](/slides/tr/java/licensing/) bölümüne bakın. Bir gereksinim eksikse, program [Linux](#linux) bölümünde açıklanan hatalardan biriyle durur.

## **Geliştirme Araçları**

Desteklenen bir Java sürümünün herhangi bir JDK’sı ile Aspose.Slides kullanan uygulamalar oluşturabilirsiniz. [Kurulum](/slides/tr/java/installation/) bölümünde açıklandığı gibi Aspose’un Maven deposu ile Apache Maven kullanın veya bir Maven deposunu kullanabilen herhangi bir yapı aracını tercih edin. JAR dosyasını IDE’nizin veya yapı aracınızın sınıf yoluna kendiniz de ekleyebilirsiniz.

## **SSS**

**Dönüştürme ve render işlemleri için Microsoft PowerPoint yüklü olması gerekir mi?**

Hayır, PowerPoint gerekmez. Aspose.Slides, [sunum oluşturma](/slides/tr/java/create-presentation/), düzenleme, [dönüştürme](/slides/tr/java/convert-presentation/) ve [render](/slides/tr/java/convert-powerpoint-to-png/) için bağımsız bir motor sağlar.

**Aspose.Slides for Java bir Linux sunucusunda ekran veya masaüstü ortamı ister mi?**

Hayır. Aspose.Slides bir X sunucusuna veya ekrana ihtiyaç duymaz; bu yüzden sunucularda ve konteynerlerde çalışabilir. Linux’ta yalnızca [Linux](#linux) bölümünde açıklanan yazı tipi kitaplığını ve yazı tiplerini gerekir.

**Doğru render için hangi yazı tipleri gerekir?**

Sunumda kullanılan yazı tipleri veya uygun [ikame](/slides/tr/java/font-substitution/) yazı tipleri mevcut olmalıdır. Linux ve macOS’ta, tutarlı render elde etmek için sunumlarınızın ihtiyaç duyduğu yazı tipi paketlerini kurun.

**Özel bir yazı tipi Linux’ta yedek veya eksik metin olarak neden görüntülenir?**

Yazı tipi dosyasının ad‑tablosu girdileri tutarsız veya bozuksa, Linux yazı tipi eşleştirme yığını (FreeType/fontconfig) geçersiz bir kaydı seçebilir ve yazı tipinin çözülemediği ortaya çıkar. Düzeltülmüş ad‑tablosu kayıtlarına sahip bir sürüm kullanmak veya tutarlı bir yedek kurmak sorunu çözer.