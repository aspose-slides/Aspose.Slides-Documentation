---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /tr/java/
keywords:
- dokümantasyon
- sunum işleme
- sunum dönüştürme
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for Java'yı kurun, ilk sunumunuzu oluşturun ve ortak görevler, dağıtım ve API referansı için kılavuzları bulun."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java, Microsoft PowerPoint olmadan Java uygulamalarında PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için bir sınıf kitaplığıdır.

Makro‑destekli ve şablon çeşitleri dahil olmak üzere PPT, PPTX, PPS, POT ve ODP dosyalarını yükler ve kaydeder, ayrıca PDF, XPS, HTML, SVG, TIFF, Markdown ve görüntüler olarak dışa aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlayın</b></p>
<hr>
<p>BAŞLAMA</p>
<ul>
<li><a href="/slides/tr/java/installation/">Kurulum</a></li>
<li><a href="/slides/tr/java/create-presentation/">İlk sunumunuzu oluşturun</a></li>
<li><a href="/slides/tr/java/system-requirements/">Sistem gereksinimleri</a></li>
<li><a href="/slides/tr/java/getting-started/">Başlangıç kılavuzu</a></li>
</ul>
<p>DEĞERLENDİR</p>
<ul>
<li><a href="/slides/tr/java/supported-file-formats/">Desteklenen dosya formatları</a></li>
<li><a href="/slides/tr/java/features-overview/">Özellikler özeti</a></li>
<li><a href="/slides/tr/java/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/java/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides ile Oluşturun</b></p>
<hr>
<p>ORTAK GÖREVLER</p>
<ul>
<li><a href="/slides/tr/java/open-presentation/">Bir sunumu aç</a></li>
<li><a href="/slides/tr/java/save-presentation/">Bir sunumu kaydet</a></li>
<li><a href="/slides/tr/java/convert-powerpoint-to-pdf/">PDF'ye dönüştür</a></li>
<li><a href="/slides/tr/java/convert-slide/">Slaytları resim olarak oluştur</a></li>
<li><a href="/slides/tr/java/manage-text/">Metin ve şekilleri düzenle</a></li>
</ul>
<p>SLIDES İŞ AKIŞLARI</p>
<ul>
<li><a href="/slides/tr/java/powerpoint-charts/">Grafikler</a></li>
<li><a href="/slides/tr/java/powerpoint-animation/">Animasyonlar</a></li>
<li><a href="/slides/tr/java/manage-media-files/">Ses ve video</a></li>
<li><a href="/slides/tr/java/presentation-design/">Slayt tasarımı</a></li>
<li><a href="/slides/tr/java/merge-presentation/">Sunumları birleştir</a></li>
</ul>
<p>ÖRNEKLER</p>
<ul>
<li><a href="/slides/tr/java/examples/">Slayt öğesine göre örnekler</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">GitHub'daki örnekler</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Yayınla &amp; Destek</b></p>
<hr>
<p>YAYINLA</p>
<ul>
<li><a href="/slides/tr/java/system-requirements/#linux">Linux ön koşulları</a></li>
<li><a href="/slides/tr/java/how-to-run-aspose-slides-in-docker/">Docker'da çalıştır</a></li>
<li><a href="/slides/tr/java/deploy-fonts/">Yazı tipleri</a></li>
<li><a href="/slides/tr/java/security/">Güvenlik</a></li>
</ul>
<p>REFERANS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/tr/java/">API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/tr/java/release-notes/">Sürüm notları</a></li>
<li><a href="/slides/tr/java/known-issues/">Bilinen sorunlar</a></li>
<li><a href="/slides/tr/java/api-limitations/">Çıktı meta verisi sınırlamaları</a></li>
<li><a href="https://releases.aspose.com/slides/tr/java/">İndir</a></li>
</ul>
<p>DESTEK</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/tr/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ücretli destek hizmeti</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **İlk sunumunuz**

Aspose.Slides for Java, Maven Central yerine Aspose'un kendi Maven deposunda yayımlanır. Bir Maven projesi için bir klasör oluşturun ve bu *pom.xml* dosyasını içine kaydedin. Depoyu tanımlar, kütüphaneyi ekler ve çalıştırılacak sınıfı belirtir:

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

Bu kodu *src/main/java/HelloSlides.java* olarak kaydedin:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Bir sunum oluşturun. Zaten bir boş slayt içerir.
        Presentation presentation = new Presentation();
        try {
            // İlk slaytı alın.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Bir bulut şekli ekleyin ve içine metin yerleştirin.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Sunumu PPTX dosyası olarak kaydedin.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Ardından, JDK 11 veya daha yenisi ve Apache Maven yüklüyken, proje klasöründe şu komutu çalıştırın:

```bash
mvn compile exec:java
```

Program, proje klasöründe bir bulut şekli ve metin içeren bir slayt ile *new_presentation.pptx* dosyasını kaydeder. Linux'ta fontconfig ve en az bir yazı tipi yüklü olmalıdır; bkz. [Installation](/slides/tr/java/installation/#linux). Lisans olmadan, kaydedilen dosya bir değerlendirme filigranı içerir — bkz. [Licensing](/slides/tr/java/licensing/). Sunum oluşturma ve doldurma hakkında daha fazla bilgi için [Create Presentations](/slides/tr/java/create-presentation/) bölümüne bakın.