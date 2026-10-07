---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /tr/jasperreports/
keywords:
- belgeler
- JasperReports
- JasperReports Server
- rapor dışa aktarım
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for JasperReports'ı kurun, ilk raporu PowerPoint'e dışa aktarın ve dışa aktarım, JasperReports Server entegrasyonu ve destek kılavuzlarını bulun."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports, JasperReports Library ve JasperReports Server'a PowerPoint dışa aktarıcıları ekler, böylece Java uygulamaları ve rapor sunucuları doldurulmuş raporları Microsoft PowerPoint olmadan sunum olarak kaydedebilir.

Doldurulmuş bir raporu PPT ve PPTX formatına, rapor sayfası başına bir slayt olacak şekilde, ayrıca PDF ve HTML formatına dışa aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlayın</b></p>
<hr>
<p>BAŞLANGIÇ</p>
<ul>
<li><a href="/slides/tr/jasperreports/installing-aspose-slides-for-jasperreports/">Kurulum</a></li>
<li><a href="/slides/tr/jasperreports/product-overview/">Ürün genel bakışı</a></li>
<li><a href="/slides/tr/jasperreports/system-requirements/">Sistem gereksinimleri</a></li>
<li><a href="/slides/tr/jasperreports/getting-started/">Başlangıç kılavuzu</a></li>
</ul>
<p>DEĞERLENDİR</p>
<ul>
<li><a href="/slides/tr/jasperreports/supported-file-formats/">Desteklenen dosya biçimleri</a></li>
<li><a href="/slides/tr/jasperreports/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/jasperreports/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides ile Oluşturun</b></p>
<hr>
<p>DIŞA AKTARMA</p>
<ul>
<li><a href="/slides/tr/jasperreports/ppt-pptx-pdf-and-html-export/">PPT, PPTX, PDF ve HTML'ye dışa aktar</a></li>
<li><a href="/slides/tr/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Yazı tiplerini eşle</a></li>
<li><a href="/slides/tr/jasperreports/integration-with-jasperserver/">JasperReports Server entegrasyonu</a></li>
</ul>
<p>ÖRNEKLER</p>
<ul>
<li><a href="/slides/tr/jasperreports/demos-setup/">Demo projeler</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referans &amp; Destek</b></p>
<hr>
<p>REFERANS</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Sürüm notları</a></li>
<li><a href="https://products.aspose.com/slides/jasperreports/">Ürün sayfası</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">İndirme</a></li>
</ul>
<p>DESTEK</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ücretli destek yardım masası</a></li>
</ul>
</div>
</div>

------

## **İlk dışa aktarımınız**

Bu adımlar, tek satırlık bir raporu derler, doldurur ve Maven Central'dan JasperReports 6.16.0 ile PPTX olarak dışa aktarır. JDK 11 veya üzeri ve Apache Maven gerekir.

1. ZIP dosyasını [indirme sayfası](https://releases.aspose.com/slides/jasperreport/) üzerinden indirin ve açın. *lib* klasörü, JasperReports sürüm aralıklarına göre bir alt klasör içerir ve her biri o aralık için jar dosyasını tutar. JasperReports 6.16.0 için *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* dosyasını boş bir proje klasörüne kopyalayın.

2. Jar, Maven deposundan değil ZIP içinde geldiği için yerel Maven deponuza kurmanız gerekir. Proje klasöründe şu komutu çalıştırın:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. *pom.xml* dosyasını proje klasörüne kaydedin. Bu, JasperReports 6.16.0 ve kurduğunuz jar dosyasını ekler ve çalıştırılacak sınıfı belirler. JasperReports 6.16.0, Maven Central'da bulunmayan yamanmış bir iText sürümü bildirir, bu nedenle dosyada bu olarak dışarıda bırakılır; Aspose dışa aktarıcıları buna ihtiyaç duymaz.

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-jasper-export</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloExport</exec.mainClass>
    </properties>

    <dependencies>
        <dependency>
            <groupId>net.sf.jasperreports</groupId>
            <artifactId>jasperreports</artifactId>
            <version>6.16.0</version>
            <exclusions>
                <exclusion>
                    <groupId>com.lowagie</groupId>
                    <artifactId>itext</artifactId>
                </exclusion>
            </exclusions>
        </dependency>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides-jasperreports</artifactId>
            <version>26.6</version>
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

4. Bu rapor tasarımını proje klasöründe *hello.jrxml* olarak kaydedin. Başlık bandında bir satır metin basar:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<jasperReport xmlns="http://jasperreports.sourceforge.net/jasperreports"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xsi:schemaLocation="http://jasperreports.sourceforge.net/jasperreports http://jasperreports.sourceforge.net/xsd/jasperreport.xsd"
        name="Hello" pageWidth="595" pageHeight="842" columnWidth="555"
        leftMargin="20" rightMargin="20" topMargin="20" bottomMargin="20">
    <title>
        <band height="50">
            <staticText>
                <reportElement x="0" y="0" width="555" height="40"/>
                <textElement>
                    <font size="24"/>
                </textElement>
                <text><![CDATA[Hello from JasperReports!]]></text>
            </staticText>
        </band>
    </title>
</jasperReport>
```

5. Bu kodu *src/main/java/HelloExport.java* olarak kaydedin. Tasarımı derler, bir boş kayıtla doldurur ve sonucu `ASPptxExporter` ile dışa aktarır:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class HelloExport {
    public static void main(String[] args) throws Exception {
        // Rapor tasarımını derleyin ve bir boş kayıtla doldurun.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Doldurulmuş raporu PPTX olarak dışa aktarın.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Proje klasöründe şu komutu çalıştırın:

```bash
mvn compile exec:java
```

Program, proje klasöründe *hello.pptx* dosyasını kaydeder; raporun metnini içeren bir slayt oluşturur. Derleyici, kodun eski bir API kullandığını bildirir: dışa aktarıcılar girdilerini ve çıktısını `JRExporterParameter` aracılığıyla alır ve yeni `setExporterInput` ve `setExporterOutput` yapılandırmalarını kabul etmez. Linux'ta fontconfig ve en az bir yazı tipi kurulmuş olmalıdır, aksi takdirde rapor doldurma başarısız olur. Lisans olmadan, her slayt ortasında bir değerlendirme filigranı taşır — bkz. [Lisanslama](/slides/tr/jasperreports/licensing/). PPT, PDF veya HTML olarak dışa aktarmak için [PPT, PPTX, PDF ve HTML Dışa Aktarımı](/slides/tr/jasperreports/ppt-pptx-pdf-and-html-export/) sayfasına bakın.