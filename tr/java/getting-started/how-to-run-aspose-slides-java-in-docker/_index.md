---
title: Docker'da Aspose.Slides for Java Çalıştırma
linktitle: Docker
type: docs
weight: 150
url: /tr/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker konteyneri
- çok aşamalı yapı
- konteyner imajı
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- yazı tipleri
- PDF dönüşümü
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Docker'da bir Aspose.Slides for Java uygulaması oluşturun ve çalıştırın: resmi Maven ve Eclipse Temurin görüntülerinde çok aşamalı bir Dockerfile, Aspose.Slides'ın ihtiyaç duyduğu Linux kütüphaneleri ve yazı tipleri ve oluşturulan dosyaları makinenize nasıl kopyalayacağınız."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Java'ı bir Docker konteynerinde nasıl çalıştıracağınızı gösterir. Metin kutulu bir sunum oluşturan ve PDF'ye dönüştüren küçük bir Maven projesi oluşturur, resmi Maven ve Eclipse Temurin görüntüleri üzerinde çok aşamalı bir Dockerfile ile paketlersiniz, çalıştırırsınız ve oluşturulan dosyaları makinenize kopyalarsınız. Makale ayrıca Aspose.Slides'ın Linux görüntüsünde Java dışında neye ihtiyacı olduğunu açıklar ve Alpine Linux ile dağıtım paketlerinden Java kuran görüntüler için varyantlarla sona erer.

Makinenizde yalnızca Docker gerekir. JDK ve Maven, oluşturma görüntüsünün bir parçasıdır, bu yüzden onları kurmanıza gerek yoktur. Docker kurmak için, [Docker'ı Edinin](https://docs.docker.com/get-started/get-docker/) sayfasına bakın.

## **Temel Görüntüleri Seçin**

Bu makaledeki Dockerfile, Docker Hub'dan iki resmi görüntü kullanır:

- [maven](https://hub.docker.com/_/maven) `3.9-eclipse-temurin-21` etiketiyle uygulamayı derler. Apache Maven 3.9 ve Eclipse Temurin JDK 21 içerir.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) `21-jre` etiketiyle çalıştırır. JDK ve Maven olmadan Ubuntu üzerinde Eclipse Temurin Java 21 çalışma zamanı içerir.

Aspose.Slides for Java, Java'nın yazı tipi desteğiyle metin çizer; Linux'ta bunun için fontconfig ve FreeType kütüphaneleri ve en az bir yüklü yazı tipi gerekir. Eclipse Temurin görüntüleri zaten fontconfig, FreeType ve DejaVu yazı tiplerini içerdiğinden, bu makaledeki Dockerfile hiçbir paket kurmaz. Yazı tipi olmayan bir görüntüde sunumu kaydetmek "Fontconfig head is null, check your fonts or fonts configuration" hatasıyla durur. Başka bir temel görüntüde inşa ederseniz, [Başka Bir Temel Görüntü Kullan](#use-another-base-image) bölümüne bakın.

## **Projeyi Oluşturun**

*hello-slides-docker* adlı bir klasör oluşturun ve aşağıdaki dosyaları ekleyin.

* pom.xml Aspose'un Maven deposunu ve Aspose.Slides for Java bağımlılığını tanımlar; bu, [Kurulum](/slides/tr/java/installation/) bölümünde açıklandığı gibi yapılır. Aspose.Slides for Java Maven Central'da yayımlanmadığı için depo kaydı gereklidir. `finalName` öğesi uygulama JAR dosyasını *hello-slides.jar* olarak adlandırır ve [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) Maven paketi oluşturduğunda uygulamanın bağımlılıklarını *target/lib* dizinine kopyalar. Aspose.Slides sürümünü, [depo](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) sayfasında listelenen en yeni sürümle ayarlayın.

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
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
        <finalName>hello-slides</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

*src/main/java/HelloSlides.java* bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) oluşturur, ilk slaytına metin içeren bir dikdörtgen ekler ve sunumu iki kez kaydeder: bir kez PPTX, bir kez PDF olarak. Her iki dosya da çalışma dizininin altındaki *output* klasörüne konur. Program daha sonra Aspose.Slides'ın sunumu işlerken değiştirdiği yazı tiplerini, [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) kullanarak listeler; böylece konteynerin sunumun kullandığı yazı tiplerine sahip olup olmadığını görebilirsiniz.

```java
import com.aspose.slides.*;
import java.io.File;

public class HelloSlides {
    public static void main(String[] args) {
        File outputFolder = new File("output");
        outputFolder.mkdirs();

        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello from a Docker container!");

            String pptxPath = new File(outputFolder, "hello.pptx").getPath();
            String pdfPath = new File(outputFolder, "hello.pdf").getPath();
            presentation.save(pptxPath, SaveFormat.Pptx);
            presentation.save(pdfPath, SaveFormat.Pdf);

            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                System.out.println("Font substitution: " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
            }

            System.out.println("Saved " + pptxPath + " and " + pdfPath);
        } finally {
            presentation.dispose();
        }
    }
}
```

*.dockerignore* dosyası, yerel bir derlemenin *target* klasörünü ve önceki çalıştırmaların çıktılarını Docker derleme bağlamından hariç tutar; böylece görüntü yalnızca kaynak dosyalardan oluşturulur.

```text
target/
output/
```

## **Dockerfile'ı Yazın**

*hello-slides-docker* klasörüne *Dockerfile* adlı bir dosya ekleyin:

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Dosyanın iki aşaması vardır:

- **Derleme aşaması** Maven görüntüsünden başlar. İlk olarak *pom.xml* dosyasını kopyalar ve `mvn dependency:go-offline` çalıştırır; bu, Aspose.Slides for Java ve Maven eklentilerini indirir, böylece *pom.xml* değişmediği sürece Docker bu katmanı yeniden kullanır. Ardından kaynak kodunu kopyalar ve `mvn package` çalıştırır; bu, programı *target/hello-slides.jar* dosyasına derler ve Aspose.Slides JAR dosyasını *target/lib* içine kopyalar. `-B` seçeneği Maven'i etkileşimsiz (batch) modda çalıştırır.
- **Çalışma zamanı aşaması** daha küçük bir Java çalışma zamanı görüntüsünden başlar ve yalnızca uygulama JAR dosyasını ve *lib* klasörünü kopyalar. *output* klasörünü oluşturur, onu Ubuntu tabanlı görüntünün tanımladığı kök olmayan `ubuntu` kullanıcısına verir ve uygulamayı bu kullanıcı olarak çalıştırır. `hello-slides.jar:lib/*` sınıf yolu, uygulamayı ve *lib* içindeki her JAR dosyasını içerir; `*` karakterini Java kendisi genişletir.

Proje Java 11 için derlenmiştir (`maven.compiler.release` özelliği); bu yüzden çalışma zamanı aşaması daha yeni bir Java sürümüyle kullanılabilir. Örneğin, uygulamayı Java 25 üzerinde çalıştırmak için çalışma zamanı aşamasının görüntüsünü `eclipse-temurin:25-jre` olarak değiştirin.

## **Konteyneri Oluşturun ve Çalıştırın**

*hello-slides-docker* klasöründe bir terminal açın. Görüntüyü oluşturun, ardından bir konteyner çalıştırın:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

İlk oluşturma temel görüntüleri, Maven eklentilerini ve Aspose.Slides for Java'ı indirir; bu yüzden birkaç dakika sürer; sonraki oluşturmalarda bunlar yeniden kullanılır. Konteyner uygulamayı çalıştırır ve durur. Aşağıdaki çıktıyı verir:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

İlk satır, metnin yeni bir sunumun varsayılan yazı tipi olan Calibri'yi kullandığını ve Calibri'nin görüntüde yüklü olmadığını gösterir; bu yüzden Aspose.Slides metni DejaVu Sans ile çizer. PDF'deki metin gerçek, seçilebilir bir metindir ve o yazı tipinde gösterilir. Lisans olmadığında Aspose.Slides, kaydettiği her slayta bir değerlendirme filigranı ekler; bkz. [Lisanslama](/slides/tr/java/licensing/).

## **Çıktıyı Makinenize Kopyalayın**

Dosyalar, durdurulmuş konteynerin */app/output* klasöründedir. Bunları makinenizdeki bir *output* klasörüne kopyalayın, ardından konteyneri silin:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Bu iki komut Bash, PowerShell ve Windows Komut İstemi'nde aynı şekilde çalışır.

Linux'ta, bir klasörü konteyner içine bağlayarak uygulamanın dosyaları doğrudan oraya yazmasını sağlayabilirsiniz:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user` seçeneği, uygulamayı kendi kullanıcı ve grup kimliklerinizle çalıştırır; böylece oluşturduğunuz klasöre yazabilir ve dosyalar size ait olur. `--rm` seçeneği konteyner durduğunda onu kaldırır.

## **Alpine Linux'ta Çalıştırın**

Eclipse Temurin, daha küçük bir Alpine Linux tabanlı görüntü olarak da mevcuttur. Bu görüntü de fontconfig, FreeType ve DejaVu yazı tiplerini içerir; bu yüzden uygulamanın burada ekstra paketlere ihtiyacı yoktur. Kullanmak için, *Dockerfile* içindeki çalışma zamanı aşamasını (ikinci `FROM` satırından itibaren) aşağıdaki ile değiştirin:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Alpine görüntüsünde `ubuntu` kullanıcısı bulunmadığından, bu aşama `adduser` ile `app` adlı bir kullanıcı oluşturur ve uygulamayı bu kullanıcı olarak çalıştırır. Yukarıdaki aynı komutlarla oluşturun, çalıştırın ve çıktıyı kopyalayın. Uygulama aynı iki satırı yazdırır.

## **Başka Bir Temel Görüntü Kullanın**

Görüntünüz Linux dağıtımının paketlerinden Java kuruyorsa, Java'nın yazı tipi kütüphanelerini ve bir yazı tipini birlikte kurun. Debian ve Ubuntu'da `openjdk-21-jre-headless` paketi yalnızca tavsiye edilen paketler olarak fontconfig, FreeType ve HarfBuzz listesini içerir; bu yüzden `apt-get install --no-install-recommends` bunları dışarı bırakır ve uygulama `libfontmanager.so` için bir `UnsatisfiedLinkError` ile durur. Bu çalışma zamanı aşaması, Debian 13'te Java 21, gerekli kütüphaneler ve DejaVu yazı tiplerini kurar ve `app` adlı bir kök olmayan kullanıcı oluşturur:

```dockerfile
FROM debian:trixie
RUN apt-get update \
    && apt-get install -y --no-install-recommends openjdk-21-jre-headless libfontconfig1 libfreetype6 libharfbuzz0b fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN useradd --create-home app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Aynı aşama `FROM ubuntu:26.04` ile Ubuntu 26.04'te de çalışır.

## **SSS**

**Sunumu kaydederken "Fontconfig head is null, check your fonts or fonts configuration" hatası alıyorum. Ne eksik?**

Bir yazı tipi. Java'nın yazı tipi desteği görüntüde yüklü bir yazı tipi bulamadı. Örneğin Debian ve Ubuntu'da `fonts-dejavu-core` paketini kurun; bkz. [Başka Bir Temel Görüntü Kullan](#use-another-base-image). [Yazı Tipi Dağıtımı](/slides/tr/java/deploy-fonts/) diğer yazı tipi paketlerini listeler.

**Uygulama `libfontmanager.so` için UnsatisfiedLinkError ile duruyor. Ne eksik?**

Java'nın yazı tipi desteğinin yerel kütüphanesi; mesaj, yüklenemeyen dosyayı (`libharfbuzz.so.0` gibi) gösterir. Bu, Java dağıtım paketlerinden kurulduğunda tavsiye edilen paketler yüklenmediğinde olur. [Başka Bir Temel Görüntü Kullan](#use-another-base-image) bölümünde listelenen kütüphaneleri kurun.

**PDF'deki metin PowerPoint'teki metinden farklı bir yazı tipinde neden?**

Sunumun kullandığı yazı tipleri görüntüde yüklü değildir; bu yüzden Aspose.Slides metni bir yedek yazı tipiyle çizer. Uygulamanın çıktısı, her değiştirilen yazı tipini adlandırır. [Yazı Tipi Dağıtımı](/slides/tr/java/deploy-fonts/) yazı tiplerini görüntüye nasıl kuracağınızı veya uygulama klasöründen nasıl yükleyeceğinizi açıklar.

**Uygulama konteynerde ne kadar bellek kullanabilir?**

Varsayılan olarak Java, heap'ini konteynerdeki mevcut belleğin dörtte birine sınırlar; örneğin `docker run -m 1g` ile konteyneri başlatırsanız yaklaşık 250 MB olur. Büyük sunumları işlemek için `MaxRAMPercentage` seçeneğiyle payı artırabilirsiniz; örneğin `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java, uygulama çıktısından önce bir "Picked up JAVA_TOOL_OPTIONS" satırı yazdırır.

**Makinemde JDK veya Maven olmadan çalıştırabilir miyim?**

Hayır. Derleme aşaması, uygulamayı Maven görüntüsü içinde derler. JDK ve Maven yalnızca uygulamayı Docker dışındaki bir ortamda derlemek ve çalıştırmak isterseniz gereklidir; bkz. [Kurulum](/slides/tr/java/installation/).