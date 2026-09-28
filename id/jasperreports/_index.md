---
title: Aspose.Slides untuk JasperReports
second_title: Aspose.Slides untuk JasperReports
type: docs
weight: 70
url: /id/jasperreports/
keywords:
- dokumentasi
- JasperReports
- JasperReports Server
- ekspor laporan
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Mulai di sini: instal Aspose.Slides untuk JasperReports, ekspor laporan pertama ke PowerPoint, dan temukan panduan untuk ekspor, integrasi JasperReports Server, dan dukungan."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports menambahkan eksportir PowerPoint ke JasperReports Library dan JasperReports Server, sehingga aplikasi Java dan server laporan dapat menyimpan laporan yang terisi sebagai presentasi tanpa Microsoft PowerPoint.

Ini mengekspor laporan yang terisi ke PPT dan PPTX, satu slide per halaman laporan, serta ke PDF dan HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Mulai</b></p>
<hr>
<p>MEMULAI</p>
<ul>
<li><a href="/slides/id/jasperreports/installing-aspose-slides-for-jasperreports/">Instalasi</a></li>
<li><a href="/slides/id/jasperreports/product-overview/">Gambaran produk</a></li>
<li><a href="/slides/id/jasperreports/system-requirements/">Persyaratan sistem</a></li>
<li><a href="/slides/id/jasperreports/getting-started/">Panduan memulai</a></li>
</ul>
<p>EVALUASI</p>
<ul>
<li><a href="/slides/id/jasperreports/supported-file-formats/">Format file yang didukung</a></li>
<li><a href="/slides/id/jasperreports/evaluate-aspose-slides/">Batasan percobaan</a></li>
<li><a href="/slides/id/jasperreports/licensing/">Lisensi</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Buat dengan Slides</b></p>
<hr>
<p>EKSPOR</p>
<ul>
<li><a href="/slides/id/jasperreports/ppt-pptx-pdf-and-html-export/">Ekspor ke PPT, PPTX, PDF, dan HTML</a></li>
<li><a href="/slides/id/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Pemetaan font</a></li>
<li><a href="/slides/id/jasperreports/integration-with-jasperserver/">Integrasi JasperReports Server</a></li>
</ul>
<p>CONTOH</p>
<ul>
<li><a href="/slides/id/jasperreports/demos-setup/">Proyek demo</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referensi &amp; Dukungan</b></p>
<hr>
<p>REFERENSI</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Catatan rilis</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">Unduh</a></li>
</ul>
<p>DUKUNGAN</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum dukungan gratis</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk dukungan berbayar</a></li>
</ul>
</div>
</div>

------

## **Ekspor pertama Anda**

Langkah-langkah ini mengkompilasi laporan satu baris, mengisinya, dan mengekspornya ke PPTX dengan JasperReports 6.16.0 dari Maven Central. Anda memerlukan JDK 11 atau lebih baru dan Apache Maven.

1. Unduh ZIP dari [halaman unduhan](https://releases.aspose.com/slides/jasperreport/) dan ekstrak. Folder *lib*‑nya memiliki satu subfolder per rentang versi JasperReports, dan masing‑masing berisi jar untuk rentang tersebut. Untuk JasperReports 6.16.0, salin *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* ke folder proyek yang kosong.

2. Jar tersebut terdapat dalam ZIP bukan dari repositori Maven, jadi instal ke repositori Maven lokal Anda. Jalankan perintah berikut di folder proyek:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Simpan *pom.xml* ini di folder proyek. File ini menambahkan JasperReports 6.16.0 dan jar yang Anda instal, serta menentukan kelas yang akan dijalankan. JasperReports 6.16.0 mendeklarasikan build iText yang dipatch yang tidak ada di Maven Central, sehingga file ini mengecualikannya; eksportir Aspose tidak memerlukannya.

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

4. Simpan desain laporan ini sebagai *hello.jrxml* di folder proyek. Ia mencetak satu baris teks di band judul:

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

5. Simpan kode ini sebagai *src/main/java/HelloExport.java*. Kode ini mengkompilasi desain, mengisinya dengan satu record kosong, dan mengekspor hasilnya dengan `ASPptxExporter`:

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
        // Kompilasi desain laporan dan isi dengan satu record kosong.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Ekspor laporan yang terisi ke PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Jalankan perintah ini di folder proyek:

```bash
mvn compile exec:java
```

Program ini menyimpan *hello.pptx* di folder proyek, dengan satu slide yang memuat teks laporan. Kompilator mencatat bahwa kode ini menggunakan API yang sudah tidak dipakai lagi: eksportir mengambil masukan dan keluaran melalui `JRExporterParameter`, dan mereka tidak menerima konfigurasi `setExporterInput` dan `setExporterOutput` yang lebih baru. Pada Linux, fontconfig dan setidaknya satu font harus diinstal, atau proses pengisian laporan akan gagal. Tanpa lisensi, setiap slide menampilkan watermark evaluasi di tengahnya — lihat [Lisensi](/slides/id/jasperreports/licensing/). Untuk mengekspor ke PPT, PDF, atau HTML, lihat [Ekspor PPT, PPTX, PDF dan HTML](/slides/id/jasperreports/ppt-pptx-pdf-and-html-export/).