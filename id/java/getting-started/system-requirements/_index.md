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
description: "Periksa apa yang dibutuhkan Aspose.Slides for Java sebelum Anda menginstalnya: versi Java dan sistem operasi yang didukung, serta pustaka font dan font yang diperlukan Linux."
---
## **Pendahuluan**

Aspose.Slides for Java adalah pustaka mandiri: ia tidak memerlukan Microsoft PowerPoint atau Microsoft Office. Ini berupa satu file JAR, dipublikasikan di repositori Maven Aspose. File JAR hanya berisi kelas dan sumber daya Java, tanpa pustaka native, dan tidak menyatakan ketergantungan pada pustaka lain. Karena itu, file yang sama dapat dijalankan di setiap sistem operasi dan prosesor yang memiliki runtime Java yang didukung.

Artikel ini mencantumkan versi Java dan sistem operasi yang didukung serta pustaka font dan font yang dibutuhkan Linux, dan diakhiri dengan program singkat yang memeriksa pengaturan Anda. Untuk menambahkan pustaka ke proyek, lihat [Instalasi](/slides/id/java/installation/).

## **Versi Java yang Didukung**

Aspose.Slides for Java berjalan pada Java 8 atau yang lebih baru, dengan JDK atau JRE. Ini mencakup rilis dukungan jangka panjang Java 8, 11, 17, 21, dan 25, serta rilis selanjutnya seperti Java 26 dan Java 27. Runtime Java dapat berasal dari vendor apa pun, misalnya Eclipse Temurin, Amazon Corretto, Oracle, atau paket OpenJDK dari distribusi Linux.

Aspose.Slides tidak memerlukan opsi JVM, seperti `--add-opens`, pada versi apa pun tersebut. Pada Java 11, JVM mencetak peringatan yang dimulai dengan "WARNING: An illegal reflective access operation has occurred"; peringatan tersebut tidak memengaruhi hasil.

{{% alert color="warning" title="Warning" %}}
Java 6 dan Java 7 sudah tidak lagi didukung. Aspose.Slides for Java 26.9 masih dapat berjalan di atasnya namun mencetak peringatan depresiasi. Mulai versi 26.10, Java 8 menjadi minimum, dan Java 6 serta Java 7 tidak lagi didukung.
{{% /alert %}}

Proyek Maven dan perintah dalam [Instalasi](/slides/id/java/installation/) memerlukan JDK 11 atau yang lebih baru. Dengan Java 8, kompilasi dan jalankan program Anda seperti yang ditunjukkan pada [Periksa Pengaturan Anda](#check-your-setup).

## **Sistem Operasi yang Didukung**

Karena file JAR tidak berisi kode native, Aspose.Slides for Java dapat dijalankan pada Windows, Linux, dan macOS, pada arsitektur prosesor apa pun yang didukung runtime Java, seperti x64 dan ARM64. Runtime Java adalah satu‑satunya persyaratan pada Windows. Pada Linux, dukungan font Java juga memerlukan pustaka font dan font yang dijelaskan di [Linux](#linux).

## **Linux**

Aspose.Slides for Java menata dan menggambar teks dengan dukungan font runtime Java. Pada Linux, dukungan tersebut memerlukan pustaka fontconfig dan setidaknya satu font yang terpasang. Gambar resmi kontainer distribusi Linux sering tidak menyediakannya. Tanpa keduanya, contoh pertama pada [Buat Presentasi](/slides/id/java/create-presentation/) gagal saat menyimpan presentasi, menghasilkan file kosong, dan melaporkan kesalahan berikut:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Kontainer resmi `eclipse-temurin`, baik untuk Ubuntu maupun Alpine Linux, sudah menyertakan fontconfig dan font DejaVu, sehingga tidak perlu menginstal apa pun di sana. Pada sistem lain, instal paket-paket di bawah ini. Perintah Debian, Ubuntu, dan Red Hat menggunakan `sudo`; dalam Dockerfile, jalankan tanpa `sudo` pada instruksi `RUN`. Font DejaVu sudah cukup untuk menjalankan Aspose.Slides; font yang digunakan presentasi Anda dibahas pada [Font](#fonts).

### **Debian dan Ubuntu**

Jika Anda menginstal Java dari paket Debian atau Ubuntu dengan pengaturan default `apt-get`, seperti perintah pada [Instalasi](/slides/id/java/installation/#linux), paket Java juga akan menginstal pustaka fontconfig, font DejaVu, dan pustaka HarfBuzz yang dibutuhkan paket Java tersebut, dan tidak ada hal lain yang diperlukan.

Dengan runtime Java dari sumber lain, misalnya arsip Eclipse Temurin, instal fontconfig dan font DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile yang sering menginstal paket Java Debian atau Ubuntu, seperti `openjdk-21-jdk-headless` atau `default-jdk-headless`, dengan opsi `--no-install-recommends`, akan melewati ketiganya. Instal fontconfig dan font DejaVu dengan perintah di atas, serta instal HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Tanpa HarfBuzz, paket Java ini mencetak `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, dan penyimpanan gagal dengan `UnsatisfiedLinkError` yang melaporkan bahwa `libharfbuzz.so.0` tidak dapat dibuka.

### **Red Hat Enterprise Linux**

Paket `java-<version>-openjdk-headless` pada Red Hat Enterprise Linux tidak menginstal pustaka fontconfig. Instal bersama font DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Paket lengkap `java-<version>-openjdk` menginstal fontconfig dan font sebagai ketergantungan, begitu pula paket Amazon Corretto pada Amazon Linux 2023, seperti `java-21-amazon-corretto-headless`.

### **Alpine Linux**

Dalam Dockerfile berbasis Alpine Linux, instal fontconfig dan font DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Pada rilis Alpine saat ini, `ttf-dejavu` menginstal paket `font-dejavu`. Instal Java dengan paket `openjdk<version>-jre` atau `openjdk<version>-jdk`, misalnya `openjdk25-jdk`. Paket `openjdk<version>-jre-headless` pada Alpine Linux tidak menyertakan pustaka font Java, sehingga program akan gagal dengan `UnsatisfiedLinkError: no fontmanager in system library path`, meskipun font telah diinstal.

### **Font**

Agar teks ditampilkan dengan font dan metrik yang tepat, font yang dipakai presentasi Anda, atau pengganti yang cocok, harus diinstal pada sistem atau dimuat oleh aplikasi Anda. Lihat [Sebarkan Font](/slides/id/java/deploy-fonts/), [Penggantian Font](/slides/id/java/font-substitution/), dan [Font Kustom](/slides/id/java/custom-font/).

## **Periksa Pengaturan Anda**

Untuk memverifikasi bahwa pustaka dan semua persyaratannya sudah tersedia, jalankan program yang menyimpan presentasi dan merender satu slide ke gambar. Penyimpanan dan perenderan menggunakan dukungan font runtime Java, sebagaimana yang disediakan oleh persyaratan Linux di atas.

Simpan kode di bawah ini sebagai *CheckSetup.java* di folder yang berisi file JAR Aspose.Slides. Untuk mengunduh file JAR, lihat [Gunakan File JAR Tanpa Maven](/slides/id/java/installation/#use-the-jar-file-without-maven).

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

Dengan JDK 11 atau yang lebih baru, jalankan program di folder tersebut dengan perintah di bawah ini. Jika nama file JAR Anda berbeda, ubah nama pada perintah.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Dengan Java 8, atau pada sistem yang hanya memiliki JRE, kompilasi program dengan `javac` dari JDK kemudian jalankan kelas yang sudah dikompilasi. Pada Linux dan macOS, jalankan:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

Pada Windows, jalankan perintah `javac` yang sama, lalu jalankan kelas dengan titik koma sebagai pemisah class path. Pertahankan tanda kutip agar PowerShell tidak menganggap titik koma sebagai akhir perintah: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

Program menambahkan sebuah persegi panjang berisi teks pada slide pertama dan menyimpan presentasi sebagai *hello.pptx* dengan metode [save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Kemudian ia merender slide dengan [getImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#getImage-float-float-) dan menyimpan hasilnya sebagai *hello.png* menggunakan [IImage.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/#save-java.lang.String-int-) dalam format [ImageFormat.Png](https://reference.aspose.com/slides/id/java/com.aspose.slides/imageformat/). Faktor skala 1 menghasilkan satu piksel per poin, sehingga slide standar 720 × 540 poin menjadi gambar 720 × 540 piksel, dengan teks terlihat di dalam persegi panjang. Tanpa lisensi, kedua file juga akan menampilkan watermark evaluasi; lihat [Lisensi](/slides/id/java/licensing/). Jika ada persyaratan yang belum terpenuhi, program akan berhenti dengan salah satu kesalahan yang dijelaskan pada [Linux](#linux).

## **Alat Pengembangan**

Anda dapat membangun aplikasi yang menggunakan Aspose.Slides dengan JDK versi Java yang didukung apa pun. Gunakan Apache Maven dengan repositori Maven Aspose, seperti yang dijelaskan pada [Instalasi](/slides/id/java/installation/), atau alat pembangunan lain yang dapat menggunakan repositori Maven. Anda juga dapat menambahkan file JAR ke classpath IDE atau alat pembangunan Anda secara manual.

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint untuk konversi dan perenderan?**

Tidak, PowerPoint tidak diperlukan. Aspose.Slides adalah mesin mandiri untuk [membuat](/slides/id/java/create-presentation/), memodifikasi, [mengonversi](/slides/id/java/convert-presentation/), dan [merender](/slides/id/java/convert-powerpoint-to-png/) presentasi.

**Apakah Aspose.Slides for Java memerlukan tampilan atau lingkungan desktop pada server Linux?**

Tidak. Aspose.Slides tidak memerlukan server X atau tampilan, sehingga dapat berjalan di server dan kontainer. Pada Linux, ia hanya memerlukan pustaka font dan font yang dijelaskan pada [Linux](#linux).

**Font apa yang dibutuhkan untuk perenderan yang tepat?**

Font yang digunakan dalam presentasi, atau [pengganti](/slides/id/java/font-substitution/) yang cocok, harus tersedia. Pada Linux dan macOS, instal paket font yang dibutuhkan presentasi Anda untuk mendapatkan perenderan yang konsisten.

**Mengapa font kustom dirender sebagai fallback atau teks yang hilang di Linux?**

Jika file font memiliki entri tabel nama yang tidak konsisten atau rusak, stack pencocokan font Linux (FreeType/fontconfig) mungkin memilih rekaman yang tidak valid, sehingga font tidak dapat dikenali. Menggunakan versi font dengan tabel nama yang diperbaiki atau memasang pengganti yang konsisten menyelesaikan masalah.