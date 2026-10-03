---
title: Jalankan Aspose.Slides for Java di Docker
linktitle: Docker
type: docs
weight: 150
url: /id/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Kontainer Docker
- Build multi-tahap
- Image kontainer
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- font
- Konversi PDF
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Bangun dan jalankan aplikasi Aspose.Slides for Java dalam Docker: Dockerfile multi-tahap pada gambar resmi Maven dan Eclipse Temurin, pustaka Linux dan font yang diperlukan Aspose.Slides, serta cara menyalin file yang dihasilkan ke mesin Anda."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara menjalankan Aspose.Slides for Java dalam kontainer Docker. Anda membuat proyek Maven kecil yang membuat sebuah presentasi dengan kotak teks dan mengonversinya ke PDF, mengemasnya dengan Dockerfile multi‑tahap pada gambar resmi Maven dan Eclipse Temurin, menjalankannya, dan menyalin file yang dihasilkan ke mesin Anda. Artikel ini juga menjelaskan apa yang dibutuhkan Aspose.Slides dalam gambar Linux selain Java, dan diakhiri dengan varian untuk Alpine Linux serta untuk gambar yang menginstal Java dari paket distribusi.

Anda hanya memerlukan Docker di mesin Anda. JDK dan Maven merupakan bagian dari gambar build, sehingga Anda tidak perlu menginstalnya. Untuk menginstal Docker, lihat [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Pilih Gambar Dasar**

Dockerfile dalam artikel ini menggunakan dua gambar resmi dari Docker Hub:

- [maven](https://hub.docker.com/_/maven) dengan tag `3.9-eclipse-temurin-21` membangun aplikasi. Gambar ini berisi Apache Maven 3.9 dan Eclipse Temurin JDK 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) dengan tag `21-jre` menjalankannya. Gambar ini berisi runtime Java 21 Eclipse Temurin di Ubuntu, tanpa JDK dan Maven.

Aspose.Slides for Java menggambar teks dengan dukungan font Java, yang di Linux memerlukan pustaka fontconfig dan FreeType serta setidaknya satu font yang terpasang. Gambar Eclipse Temurin sudah menyertakan fontconfig, FreeType, dan font DejaVu, sehingga Dockerfile dalam artikel ini tidak menginstal paket apa pun. Pada gambar tanpa font, penyimpanan presentasi akan berhenti dengan error "Fontconfig head is null, check your fonts or fonts configuration". Jika Anda membangun pada gambar dasar lain, lihat [Use Another Base Image](#use-another-base-image).

## **Buat Proyek**

Buat folder bernama *hello-slides-docker* dan tambahkan file‑file berikut ke dalamnya.

*pom.xml* mendeklarasikan repositori Maven Aspose dan dependensi Aspose.Slides for Java, seperti yang dijelaskan di [Installation](/slides/id/java/installation/); Aspose.Slides for Java tidak dipublikasikan di Maven Central, sehingga entri repositori diperlukan. Elemen `finalName` memberi nama file JAR aplikasi *hello-slides.jar*, dan [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) menyalin dependensi aplikasi ke *target/lib* saat Maven mempaknya. Tentukan versi Aspose.Slides ke versi terbaru yang tercantum di [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

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

*src/main/java/HelloSlides.java* membuat sebuah [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/), menambahkan persegi panjang dengan teks ke slide pertama, dan menyimpan presentasi dua kali dengan metode [save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-): sebagai PPTX dan sebagai PDF. Kedua file disimpan ke folder *output* di bawah direktori kerja. Program kemudian mencantumkan font yang diganti oleh Aspose.Slides ketika merender presentasi, menggunakan [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), sehingga Anda dapat melihat apakah kontainer memiliki font yang digunakan oleh presentasi.

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

*.dockerignore* menjaga folder *target* dari build lokal, serta output dari run sebelumnya, agar tidak masuk ke konteks build Docker, sehingga gambar dibangun hanya dari file sumber.

```text
target/
output/
```

## **Tulis Dockerfile**

Tambahkan file bernama *Dockerfile* ke folder *hello-slides-docker*:

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

File ini memiliki dua tahap:

- **Tahap build** dimulai dari gambar Maven. Ia menyalin *pom.xml* terlebih dahulu dan menjalankan `mvn dependency:go-offline`, yang mengunduh Aspose.Slides for Java dan plugin Maven, sehingga Docker dapat menggunakan kembali lapisan itu selama *pom.xml* tidak berubah. Kemudian menyalin kode sumber dan menjalankan `mvn package`, yang mengompilasi program ke *target/hello-slides.jar* dan menyalin file JAR Aspose.Slides ke *target/lib*. Opsi `-B` menjalankan Maven dalam mode non‑interaktif (batch).

- **Tahap runtime** dimulai dari gambar runtime Java yang lebih kecil dan menyalin hanya file JAR aplikasi serta folder *lib*. Ia membuat folder *output*, memberikannya ke `ubuntu`, pengguna non‑root yang didefinisikan oleh gambar berbasis Ubuntu, dan menjalankan aplikasi sebagai pengguna tersebut. Classpath `hello-slides.jar:lib/*` berisi aplikasi dan setiap file JAR di *lib*; Java memperluas `*` sendiri.

Proyek ini dikompilasi untuk Java 11 (properti `maven.compiler.release`), sehingga tahap runtime dapat menggunakan versi Java yang lebih baru. Misalnya, untuk menjalankan aplikasi pada Java 25, ubah gambar tahap runtime menjadi `eclipse-temurin:25-jre`.

## **Bangun dan Jalankan Kontainer**

Buka terminal di folder *hello-slides-docker*. Bangun gambar, lalu jalankan sebuah kontainer darinya:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Build pertama mengunduh gambar dasar, plugin Maven, dan Aspose.Slides for Java, sehingga memerlukan beberapa menit; build berikutnya akan menggunakan kembali lapisan tersebut. Kontainer menjalankan aplikasi dan berhenti. Ia mencetak:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Baris pertama menunjukkan bahwa teks menggunakan Calibri, font default presentasi baru, dan bahwa Calibri tidak terpasang di gambar, sehingga Aspose.Slides menggambar teks dengan DejaVu Sans. Teks dalam PDF berupa teks nyata yang dapat dipilih dengan font itu. Tanpa lisensi, Aspose.Slides juga menambahkan watermark evaluasi pada setiap slide yang disimpan; lihat [Licensing](/slides/id/java/licensing/).

## **Salin Output ke Mesin Anda**

File berada di folder */app/output* dalam kontainer yang telah dihentikan. Salin mereka ke folder *output* di mesin Anda, lalu hapus kontainer:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Kedua perintah ini berfungsi sama di Bash, PowerShell, dan Windows Command Prompt.

Di Linux, Anda dapat memasang (mount) folder mesin Anda ke dalam kontainer, sehingga aplikasi menulis file langsung ke sana:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Opsi `--user` menjalankan aplikasi dengan ID pengguna dan grup Anda, sehingga ia dapat menulis ke folder yang Anda buat dan file‑file tersebut menjadi milik Anda. `--rm` menghapus kontainer ketika selesai.

## **Jalankan di Alpine Linux**

Eclipse Temurin juga tersedia sebagai gambar berbasis Alpine Linux, yang lebih kecil. Gambar tersebut berisi fontconfig, FreeType, dan font DejaVu, sehingga aplikasi tidak memerlukan paket tambahan di sana juga. Untuk menggunakannya, ganti tahap runtime dalam *Dockerfile* (semua mulai baris `FROM` kedua) dengan:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Gambar Alpine tidak memiliki pengguna `ubuntu`, sehingga tahap ini membuat pengguna bernama `app` dengan `adduser` dan menjalankan aplikasi sebagai pengguna tersebut. Bangun, jalankan, dan salin output dengan perintah yang sama seperti di atas. Aplikasi mencetak dua baris yang sama.

## **Gunakan Gambar Dasar Lain**

Jika gambar Anda menginstal Java dari paket distribusi Linux, instal pustaka font Java dan satu font bersamaan. Pada Debian dan Ubuntu, paket `openjdk-21-jre-headless` mencantumkan fontconfig, FreeType, dan HarfBuzz hanya sebagai paket yang direkomendasikan, sehingga `apt-get install --no-install-recommends` tidak menginstalnya, dan aplikasi berhenti dengan `UnsatisfiedLinkError` untuk `libfontmanager.so`. Tahap runtime ini menginstal Java 21, pustaka‑pustakanya, dan font DejaVu pada Debian 13, serta membuat pengguna non‑root bernama `app`:

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

Tahap yang sama juga berfungsi pada Ubuntu 26.04 dengan `FROM ubuntu:26.04`.

## **FAQ**

**Menyimpan presentasi berhenti dengan "Fontconfig head is null, check your fonts or fonts configuration". Apa yang kurang?**

Sebuah font. Dukungan font Java tidak menemukan font yang terpasang di dalam gambar. Instal paket font, misalnya `fonts-dejavu-core` pada Debian dan Ubuntu, seperti yang dijelaskan di [Use Another Base Image](#use-another-base-image). [Deploy Fonts](/slides/id/java/deploy-fonts/) mencantumkan paket‑paket font lainnya.

**Aplikasi berhenti dengan UnsatisfiedLinkError untuk libfontmanager.so. Apa yang kurang?**

Pustaka native untuk dukungan font Java; pesan tersebut menyebutkan file yang tidak dapat dimuat, misalnya `libharfbuzz.so.0`. Hal ini terjadi ketika Java diinstal dari paket distribusi tanpa paket yang direkomendasikan. Instal pustaka yang tercantum di [Use Another Base Image](#use-another-base-image).

**Mengapa teks dalam PDF menggunakan font yang berbeda dari di PowerPoint?**

Font yang digunakan oleh presentasi tidak terpasang di dalam gambar, sehingga Aspose.Slides menggambar teks dengan font pengganti. Output aplikasi menampilkan setiap font yang diganti. [Deploy Fonts](/slides/id/java/deploy-fonts/) menjelaskan cara menginstal font di gambar atau memuatnya dari folder aplikasi.

**Berapa banyak memori yang dapat digunakan aplikasi di dalam kontainer?**

Secara default, Java membatasi heap ke seperempat memori yang tersedia untuk kontainer, misalnya sekitar 250 MB ketika Anda menjalankan kontainer dengan `docker run -m 1g`. Untuk memproses presentasi besar, naikkan proporsi tersebut dengan opsi `MaxRAMPercentage`, misalnya `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java kemudian mencetak baris "Picked up JAVA_TOOL_OPTIONS" sebelum output aplikasi.

**Apakah saya memerlukan JDK atau Maven di mesin saya?**

Tidak. Tahap build mengompilasi aplikasi di dalam gambar Maven. Anda hanya memerlukan JDK dan Maven bila ingin membangun dan menjalankan aplikasi di luar Docker; lihat [Installation](/slides/id/java/installation/).