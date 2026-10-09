---
title: Persyaratan Sistem
type: docs
weight: 60
url: /id/java/system-requirements/
keywords:
- persyaratan sistem
- platform yang didukung
- versi Java
- JDK
- JRE
- fontconfig
- font
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Periksa apa yang diperlukan Aspose.Slides for Java sebelum Anda menginstalnya: versi Java dan sistem operasi yang didukung, serta pustaka font dan font yang dibutuhkan oleh Linux."
---
## **Pendahuluan**

Aspose.Slides for Java adalah pustaka mandiri: tidak memerlukan Microsoft PowerPoint atau Microsoft Office. Ini adalah file JAR tunggal, dipublikasikan di repositori Maven Aspose. File JAR berisi hanya kelas Java dan sumber daya, tanpa perpustakaan native, dan tidak menyatakan ketergantungan pada pustaka lain. File yang sama oleh karena itu dapat berjalan pada setiap sistem operasi dan prosesor yang memiliki runtime Java yang didukung.

Artikel ini mencantumkan versi Java dan sistem operasi yang didukung serta pustaka font dan font yang dibutuhkan Linux, dan diakhiri dengan program singkat yang memeriksa pengaturan Anda. Untuk menambahkan pustaka ke proyek, lihat [Instalasi](/slides/id/java/installation/).

## **Versi Java yang Didukung**

Aspose.Slides for Java berjalan pada Java 8 atau lebih baru, dengan JDK atau JRE. Ini mencakup rilis dukungan jangka panjang Java 8, 11, 17, 21, dan 25, serta rilis selanjutnya seperti Java 26 dan Java 27. Runtime Java dapat berasal dari vendor manapun, misalnya Eclipse Temurin, Amazon Corretto, Oracle, atau paket OpenJDK dari distribusi Linux.

Aspose.Slides tidak memerlukan opsi JVM, seperti `--add-opens`, pada versi apapun ini. Pada Java 11, JVM mencetak peringatan yang dimulai dengan "WARNING: An illegal reflective access operation has occurred"; peringatan tersebut tidak memengaruhi hasil.

{{% alert color="warning" title="Warning" %}}
Java 6 dan Java 7 sudah tidak didukung lagi. Aspose.Slides for Java 26.9 masih dapat dijalankan pada mereka tetapi mencetak peringatan depresiasi. Mulai versi 26.10, Java 8 menjadi minimum, dan Java 6 serta Java 7 tidak lagi didukung.
{{% /alert %}}

Proyek Maven dan perintah di [Instalasi](/slides/id/java/installation/) memerlukan JDK 11 atau lebih baru. Dengan Java 8, kompilasi dan jalankan program Anda seperti yang ditunjukkan di [Periksa Pengaturan Anda](#check-your-setup).

## **Sistem Operasi yang Didukung**

Karena file JAR tidak berisi kode native, Aspose.Slides for Java berjalan pada Windows, Linux, dan macOS, pada arsitektur prosesor apa pun yang didukung runtime Java, seperti x64 dan ARM64. Runtime Java adalah satu-satunya persyaratan pada Windows. Pada Linux, dukungan font Java juga membutuhkan pustaka font dan font yang dijelaskan di [Linux](#linux).

## **Linux**

Aspose.Slides for Java menyusun dan menggambar teks dengan dukungan font dari runtime Java. Pada Linux, dukungan tersebut memerlukan pustaka fontconfig dan setidaknya satu font yang terpasang. Gambar resmi kontainer dari distribusi Linux seringkali tidak memiliki keduanya. Tanpa itu, contoh pertama di [Buat Presentasi](/slides/id/java/create-presentation/) gagal saat menyimpan presentasi, meninggalkan file kosong, dan melaporkan kesalahan ini:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Gambar kontainer resmi `eclipse-temurin`, untuk Ubuntu dan Alpine Linux, sudah berisi fontconfig dan font DejaVu, jadi tidak perlu menginstal apa pun pada mereka. Pada sistem lain, instal paket-paket di bawah ini. Perintah Debian, Ubuntu, dan Red Hat menggunakan `sudo`; dalam Dockerfile, jalankan mereka dalam instruksi `RUN` tanpa `sudo`. Font DejaVu sudah cukup untuk menjalankan Aspose.Slides; font yang digunakan presentasi Anda dibahas di [Font](#fonts).

### **Debian dan Ubuntu**

Jika Anda memasang Java dari paket Debian atau Ubuntu dengan pengaturan `apt-get` default, seperti perintah di [Instalasi](/slides/id/java/installation/#linux) melakukan, paket Java juga memasang pustaka fontconfig, font DejaVu, dan pustaka HarfBuzz yang dibutuhkan paket Java tersebut, dan tidak ada hal lain yang diperlukan.

Dengan runtime Java dari sumber lain, seperti arsip Eclipse Temurin, instal fontconfig dan font DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Seringkali Dockerfile menginstal paket Java Debian atau Ubuntu, seperti `openjdk-21-jdk-headless` atau `default-jdk-headless`, dengan opsi `--no-install-recommends`, yang melewatkan ketiganya. Instal fontconfig dan font DejaVu dengan perintah di atas, dan instal HarfBuzz juga:

```bash
sudo apt-get install -y libharfbuzz0b
```

Tanpa HarfBuzz, paket Java ini mencetak `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, dan penyimpanan gagal dengan `UnsatisfiedLinkError` yang melaporkan bahwa `libharfbuzz.so.0` tidak dapat dibuka.

### **Red Hat Enterprise Linux**

Paket `java-<version>-openjdk-headless` dari Red Hat Enterprise Linux tidak menginstal pustaka fontconfig. Instal bersama dengan font DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Paket lengkap `java-<version>-openjdk` menginstal fontconfig dan font sebagai dependensi, begitu juga paket Amazon Corretto dari Amazon Linux 2023, seperti `java-21-amazon-corretto-headless`.

### **Alpine Linux**

Dalam Dockerfile berbasis Alpine Linux, instal fontconfig dan font DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Pada rilis Alpine saat ini, `ttf-dejavu` menginstal paket `font-dejavu`. Instal Java dengan paket `openjdk<version>-jre` atau `openjdk<version>-jdk`, seperti `openjdk25-jdk`. Paket `openjdk<version>-jre-headless` dari Alpine Linux tidak menyertakan pustaka font Java, sehingga dengan paket tersebut program gagal dengan `UnsatisfiedLinkError: no fontmanager in system library path`, meskipun font telah diinstal.

### **Font**

Agar teks ditampilkan dengan font dan metrik yang benar, font yang digunakan dalam presentasi Anda, atau pengganti yang cocok, harus diinstal pada sistem atau dimuat oleh aplikasi Anda. Lihat [Pasang Font](/slides/id/java/deploy-fonts/), [Substitusi Font](/slides/id/java/font-substitution/), dan [Font Kustom](/slides/id/java/custom-font/).

## **Periksa Pengaturan Anda**

Untuk memeriksa bahwa pustaka dan persyaratannya sudah ada, jalankan program yang menyimpan presentasi dan merender slide menjadi gambar. Penyimpanan dan rendering menggunakan dukungan font dari runtime Java, seperti yang disediakan oleh persyaratan Linux di atas.

Simpan kode di bawah ini sebagai *CheckSetup.java* di folder yang berisi file JAR Aspose.Slides. Untuk mengunduh file JAR, lihat [Gunakan File JAR tanpa Maven](/slides/id/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Tambahkan persegi panjang dengan teks ke slide pertama dan simpan presentasi.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Render slide dengan satu piksel per poin dan simpan gambar.
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

Dengan JDK 11 atau lebih baru, jalankan program di folder tersebut dengan perintah di bawah ini. Jika file JAR Anda memiliki nama berbeda, ubah nama dalam perintah.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Dengan Java 8, atau pada sistem yang hanya memiliki JRE, kompilasi program dengan `javac` dari JDK lalu jalankan kelas yang telah dikompilasi. Pada Linux dan macOS, jalankan:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

Di Windows, jalankan perintah `javac` yang sama, lalu jalankan kelas dengan titik koma sebagai pemisah class path. Pertahankan tanda kutip, agar PowerShell tidak menganggap titik koma sebagai akhir perintah: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

Program menambahkan persegi panjang dengan teks ke slide pertama dan menyimpan presentasi sebagai *hello.pptx* dengan metode [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Kemudian program merender slide dengan [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) dan menyimpan hasilnya sebagai *hello.png* dengan [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) dalam format [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/). Faktor skala 1 merender satu piksel per poin, sehingga slide default 720 × 540 poin menjadi gambar 720 × 540 piksel, dengan teks terlihat di dalam persegi panjang. Tanpa lisensi, kedua file juga membawa watermark evaluasi; lihat [Lisensi](/slides/id/java/licensing/). Jika ada persyaratan yang hilang, program berhenti dengan salah satu error yang dijelaskan di [Linux](#linux).

## **Alat Pengembangan**

Anda dapat membangun aplikasi yang menggunakan Aspose.Slides dengan JDK apapun dari versi Java yang didukung. Gunakan Apache Maven dengan repositori Maven Aspose, seperti dijelaskan di [Instalasi](/slides/id/java/installation/), atau alat build lain yang dapat menggunakan repositori Maven. Anda juga dapat menambahkan file JAR ke class path IDE atau alat build Anda sendiri.

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint untuk konversi dan rendering?**

Tidak, PowerPoint tidak diperlukan. Aspose.Slides adalah mesin mandiri untuk [membuat](/slides/id/java/create-presentation/), memodifikasi, [mengonversi](/slides/id/java/convert-presentation/), dan [merender](/slides/id/java/convert-powerpoint-to-png/) presentasi.

**Apakah Aspose.Slides for Java memerlukan tampilan atau lingkungan desktop pada server Linux?**

Tidak. Aspose.Slides tidak memerlukan server X atau tampilan, sehingga dapat berjalan pada server dan di dalam kontainer. Pada Linux, hanya diperlukan pustaka font dan font yang dijelaskan di [Linux](#linux).

**Font apa yang dibutuhkan untuk rendering yang tepat?**

Font yang digunakan dalam presentasi, atau [substitusi](/slides/id/java/font-substitution/) yang sesuai, harus tersedia. Pada Linux dan macOS, instal paket font yang dibutuhkan presentasi Anda untuk mendapatkan rendering yang konsisten.

**Mengapa font kustom dirender sebagai fallback atau teks yang hilang di Linux?**

Jika file font memiliki entri tabel nama yang tidak konsisten atau rusak, stack pencocokan font Linux (FreeType/fontconfig) dapat memilih catatan yang tidak valid, menyebabkan font tidak terpecahkan. Menggunakan versi font dengan catatan tabel nama yang diperbaiki atau menginstal pengganti yang konsisten menyelesaikan masalah.