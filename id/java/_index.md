---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /id/java/
keywords:
- dokumentasi
- pemrosesan presentasi
- konversi presentasi
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Mulailah di sini: instal Aspose.Slides for Java, buat presentasi pertama, dan temukan panduan untuk tugas umum, penyebaran, serta referensi API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java adalah pustaka kelas untuk membuat, membaca, mengedit, dan mengonversi presentasi PowerPoint dan OpenDocument dalam aplikasi Java, tanpa Microsoft PowerPoint.

Pustaka ini memuat dan menyimpan PPT, PPTX, PPS, POT, dan ODP, termasuk varian yang mendukung makro dan templat, serta mengekspor ke PDF, XPS, HTML, SVG, TIFF, Markdown, dan gambar.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Mulai</b></p>
<hr>
<p>MEMULAI</p>
<ul>
<li><a href="/slides/id/java/installation/">Instalasi</a></li>
<li><a href="/slides/id/java/create-presentation/">Buat presentasi pertama Anda</a></li>
<li><a href="/slides/id/java/system-requirements/">Persyaratan sistem</a></li>
<li><a href="/slides/id/java/getting-started/">Panduan memulai</a></li>
</ul>
<p>EVALUASI</p>
<ul>
<li><a href="/slides/id/java/supported-file-formats/">Format file yang didukung</a></li>
<li><a href="/slides/id/java/features-overview/">Gambaran fitur</a></li>
<li><a href="/slides/id/java/evaluate-aspose-slides/">Batasan percobaan</a></li>
<li><a href="/slides/id/java/licensing/">Lisensi</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Membangun dengan Slides</b></p>
<hr>
<p>TUGAS UMUM</p>
<ul>
<li><a href="/slides/id/java/open-presentation/">Buka presentasi</a></li>
<li><a href="/slides/id/java/save-presentation/">Simpan presentasi</a></li>
<li><a href="/slides/id/java/convert-powerpoint-to-pdf/">Konversi ke PDF</a></li>
<li><a href="/slides/id/java/convert-slide/">Render slide sebagai gambar</a></li>
<li><a href="/slides/id/java/manage-text/">Edit teks dan bentuk</a></li>
</ul>
<p>ALUR KERJA SLIDES</p>
<ul>
<li><a href="/slides/id/java/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/id/java/powerpoint-animation/">Animasi</a></li>
<li><a href="/slides/id/java/manage-media-files/">Audio dan video</a></li>
<li><a href="/slides/id/java/presentation-design/">Desain slide</a></li>
<li><a href="/slides/id/java/merge-presentation/">Gabungkan presentasi</a></li>
</ul>
<p>CONTOH</p>
<ul>
<li><a href="/slides/id/java/examples/">Contoh berdasarkan elemen slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Contoh di GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Deploy &amp; Dukungan</b></p>
<hr>
<p>PENYEBARAN</p>
<ul>
<li><a href="/slides/id/java/system-requirements/#linux">Prasyarat Linux</a></li>
<li><a href="/slides/id/java/how-to-run-aspose-slides-in-docker/">Jalankan di Docker</a></li>
<li><a href="/slides/id/java/deploy-fonts/">Font</a></li>
<li><a href="/slides/id/java/security/">Keamanan</a></li>
</ul>
<p>REFERENSI</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">Referensi API</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">Catatan rilis</a></li>
<li><a href="/slides/id/java/known-issues/">Masalah yang diketahui</a></li>
<li><a href="/slides/id/java/api-limitations/">Batasan metadata output</a></li>
<li><a href="https://products.aspose.com/slides/java/">Halaman produk</a></li>
<li><a href="https://releases.aspose.com/slides/java/">Unduh</a></li>
</ul>
<p>DUKUNGAN</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum dukungan gratis</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk dukungan berbayar</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Presentasi pertama Anda**

Aspose.Slides for Java dipublikasikan di repositori Maven milik Aspose sendiri, bukan di Maven Central. Buat folder untuk proyek Maven dan simpan *pom.xml* ini di dalamnya. File ini mendeklarasikan repositori, menambahkan pustaka, dan menentukan kelas yang akan dijalankan:

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

Simpan kode ini sebagai *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Buat presentasi. Sudah berisi satu slide kosong.
        Presentation presentation = new Presentation();
        try {
            // Ambil slide pertama.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Tambahkan bentuk awan dan masukkan teks ke dalamnya.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Simpan presentasi sebagai file PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Selanjutnya, dengan JDK 11 atau lebih baru dan Apache Maven terinstal, jalankan perintah ini di folder proyek:

```bash
mvn compile exec:java
```

Program ini menyimpan *new_presentation.pptx* di folder proyek, dengan satu slide yang berisi bentuk awan dengan teks. Pada Linux, fontconfig dan setidaknya satu font harus diinstal; lihat [Instalasi](/slides/id/java/installation/#linux). Tanpa lisensi, file yang disimpan akan memiliki watermark evaluasi — lihat [Lisensi](/slides/id/java/licensing/). Untuk cara lain dalam membuat dan mengisi presentasi, lihat [Buat Presentasi](/slides/id/java/create-presentation/).