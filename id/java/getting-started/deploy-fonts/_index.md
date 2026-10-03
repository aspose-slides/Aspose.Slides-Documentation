---
title: Pasang Font untuk Aspose.Slides untuk Java di Linux dan dalam Docker
linktitle: Pasang Font
type: docs
weight: 155
url: /id/java/deploy-fonts/
keywords:
- pasang font
- instal font
- font di Docker
- font di Linux
- font yang hilang
- substitusi font
- font inti Microsoft
- ttf-mscorefonts-installer
- font khusus
- font bawaan
- peladen
- kontainer
- konversi PDF
- presentasi
- Java
- Aspose.Slides
description: "Pasang font untuk Aspose.Slides untuk Java pada server Linux dan dalam kontainer Docker: periksa font mana yang digantikan, instal paket font pada Debian, Ubuntu, dan Alpine, tambahkan file font Anda sendiri, dan atur font bawaan."
---
## **Ikhtisar**

Aspose.Slides menggambar teks dengan font yang tersedia padanya saat merender presentasi, misalnya ketika mengonversi slide ke PDF atau ke gambar. Desktop Windows biasanya memiliki font yang digunakan oleh presentasi. Server dan kontainer Linux biasanya memiliki sedikit font, sehingga Aspose.Slides menggambar teks dengan font pengganti. Font pengganti memiliki bentuk dan lebar huruf yang berbeda, sehingga baris dapat terbungkus secara berbeda dan teks dapat melampaui bentuknya, serta karakter yang tidak dimiliki oleh pengganti tidak digambar dengan benar. Jika tidak ada font yang dipasang sama sekali, dukungan font Java tidak dapat dimulai, dan Aspose.Slides berhenti dengan error.

Artikel ini menunjukkan cara memeriksa font apa yang digantikan oleh Aspose.Slides, cara memasang font di Debian, Ubuntu, dan Alpine Linux, cara menambahkan file font Anda sendiri, dan cara mengatur font yang digunakan ketika sebuah font tidak ada. Contoh dijalankan dalam Docker pada image resmi Eclipse Temurin, seperti di [Jalankan Aspose.Slides untuk Java di Docker](/slides/id/java/how-to-run-aspose-slides-in-docker/). Perintah paket adalah instruksi Dockerfile; pada server Linux, jalankan perintah yang sama sebagai root.

Untuk API font itu sendiri, seperti menyematkan font dalam sebuah presentasi serta aturan fallback dan penggantian, lihat [Font PowerPoint](/slides/id/java/powerpoint-fonts/).

## **Periksa Font Mana yang Digantikan**

Proyek Maven berikut melaporkan font yang digantikan oleh Aspose.Slides di lingkungan saat ini. Buat folder bernama *font-check* dan tambahkan file di bawah ini ke dalamnya.

*pom.xml* adalah yang dari [Jalankan Aspose.Slides untuk Java di Docker](/slides/id/java/how-to-run-aspose-slides-in-docker/#create-the-project), dengan ID artefak dan nama file JAR diubah menjadi *font-check*:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>font-check</artifactId>
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
        <finalName>font-check</finalName>
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

*src/main/java/FontCheck.java* menambahkan satu kotak teks per nama font ke sebuah slide dan menetapkan font dengan metode [setLatinFont](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) . Nama font berasal dari baris perintah; tanpa argumen, program memeriksa Calibri, Arial, dan Times New Roman. Program mencetak folder tempat Aspose.Slides mencari font ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsloader/#getFontFolders--)), merender slide ke *output/fonts.pdf*, dan mencetak substitusi yang dilaporkan oleh [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). Dua langkah opsional di awal, memuat folder *fonts* dan membaca variabel `DEFAULT_FONT`, dijelaskan nanti dalam artikel ini.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class FontCheck {
    public static void main(String[] args) {
        // Font yang akan diperiksa: argumen baris perintah, atau tiga font Office yang umum.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Muat file font dari folder fonts di direktori kerja, jika ada.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Gunakan font yang disebutkan dalam variabel lingkungan DEFAULT_FONT, jika sudah diatur, untuk teks yang fontnya hilang.
        LoadOptions loadOptions = new LoadOptions();
        String defaultFont = System.getenv("DEFAULT_FONT");
        if (defaultFont != null && !defaultFont.isEmpty()) {
            loadOptions.setDefaultRegularFont(defaultFont);
        }

        Set<String> fontFolders = new LinkedHashSet<>(Arrays.asList(FontsLoader.getFontFolders()));
        System.out.println("Font folders: " + String.join(", ", fontFolders));

        Presentation presentation = new Presentation(loadOptions);
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            for (int i = 0; i < fontNames.length; i++) {
                IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
                shape.getTextFrame().setText("This text is set in " + fontNames[i] + ".");
                shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData(fontNames[i]));
            }

            File outputFolder = new File("output");
            outputFolder.mkdirs();
            presentation.save(new File(outputFolder, "fonts.pdf").getPath(), SaveFormat.Pdf);

            List<FontSubstitutionInfo> substitutions = new ArrayList<>();
            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                substitutions.add(substitution);
            }

            if (substitutions.isEmpty()) {
                System.out.println("No font substitutions.");
            } else {
                System.out.println("Font substitutions:");
                for (FontSubstitutionInfo substitution : substitutions) {
                    System.out.println("  " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
                }
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

`getFontFolders` dapat mengembalikan sebuah folder lebih dari satu kali, sehingga program mengumpulkan folder dalam sebuah set sebelum mencetaknya.

*.dockerignore* menjaga hasil build lokal keluar dari konteks build:

```text
target/
output/
```

*Dockerfile* membangun program dengan image Maven dan menjalankannya pada image runtime Java Eclipse Temurin, yang sudah berisi fontconfig dan font DejaVu. [Jalankan Aspose.Slides untuk Java di Docker](/slides/id/java/how-to-run-aspose-slides-in-docker/) menjelaskan setiap instruksi.

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

Bangun image dan jalankan pemeriksaan:

```bash
docker build -t font-check .
docker run --rm font-check
```

Gambar hanya memiliki font DejaVu, sehingga ketiga font diganti dengan DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Untuk memeriksa font presentasi Anda sendiri, berikan nama mereka sebagai argumen, misalnya `docker run --rm font-check "Segoe UI" Consolas`. Untuk menyalin *output/fonts.pdf* keluar dari kontainer, gunakan perintah dalam [Salin Output ke Mesin Anda](/slides/id/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Pasang Font di Debian dan Ubuntu**

### **Microsoft Core Fonts**

Paket `ttf-mscorefonts-installer` mengunduh dan memasang Microsoft core fonts untuk web, di antaranya Arial, Times New Roman, Courier New, Verdana, Georgia, dan Trebuchet MS. Font-font ini dilisensikan di bawah perjanjian lisensi akhir pengguna Microsoft (EULA), dan paket memasangnya hanya setelah EULA diterima. Build Docker tidak dapat menjawab prompt, sehingga installer menolak EULA dan tidak memasang font apa pun, sementara `apt-get install` tetap melaporkan sukses. Terima EULA dengan `debconf-set-selections` **sebelum** paket dipasang. Menerimanya pada instruksi berikutnya tidak membantu: paket sudah terpasang, dan apt tidak menjalankan installer lagi.

Tambahkan instruksi ini ke stage runtime *Dockerfile*, tepat setelah baris `FROM`-nya, sehingga dijalankan sebagai root, sebelum instruksi `USER`:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Bangun image dan jalankan pemeriksaan lagi dengan dua perintah yang sama. Arial dan Times New Roman kini terpasang:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, font bawaan presentasi yang dibuat oleh Aspose.Slides, bukan salah satu core fonts, sehingga tetap diganti. Lihat [Atur Font Bawaan untuk Font yang Hilang](#set-a-default-font-for-missing-fonts).

Gambar Eclipse Temurin berbasis Ubuntu mengaktifkan `multiverse`, komponen Ubuntu yang berisi paket tersebut. Pada Debian, paket berada di komponen `contrib`, yang tidak diaktifkan pada image Debian. Dalam stage runtime berbasis Debian, seperti pada [Gunakan Image Dasar Lain](/slides/id/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), aktifkan `contrib` pada instruksi yang sama:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Paket Font Lainnya**

Debian dan Ubuntu juga menyediakan paket font dengan lisensi bebas, misalnya:

| Package | Fonts |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, dan Mono, dengan metrik yang sama seperti Arial, Times New Roman, dan Courier New |
| `fonts-crosextra-carlito` | Carlito, dengan metrik yang sama seperti Calibri |
| `fonts-crosextra-caladea` | Caladea, dengan metrik yang sama seperti Cambria |

Pasang mereka dengan `apt-get install` dalam instruksi `RUN` pada stage runtime, dengan cara yang sama seperti Microsoft core fonts. Aspose.Slides untuk Java tidak menerapkan alias font dari konfigurasi font Linux: dengan `fonts-liberation` terpasang, teks dalam Arial masih digambar dengan font pengganti umum, bukan dengan Liberation Sans. Untuk menggunakan font yang kompatibel secara metrik sebagai pengganti yang hilang, atur sebagai [font bawaan](#set-a-default-font-for-missing-fonts) atau tambahkan [aturan substitusi font](/slides/id/java/font-substitution/).

## **Tambahkan File Font Anda Sendiri**

Font yang tidak dipaketkan oleh distribusi, seperti font organisasi Anda atau font lain yang Anda miliki lisensi untuk digunakan di server, dapat ditambahkan sebagai file font. Letakkan file font, misalnya file *.ttf*, di dalam folder bernama *fonts* di dalam folder *font-check*. Contoh di bawah menggunakan file Carlito, sebuah font dengan metrik yang sama seperti Calibri, yang dapat Anda unduh dari [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Pasang Font di Folder Font Sistem**

Aspose.Slides membaca font di folder yang dicetak pada baris `Font folders`. Untuk memasang font Anda bagi setiap aplikasi dalam image, salin mereka ke */usr/local/share/fonts*, folder untuk font yang dipasang secara lokal. Tambahkan instruksi ini ke stage runtime *Dockerfile*, setelah instruksi `RUN` yang memasang Microsoft core fonts:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Bangun kembali image, lalu periksa Calibri dan Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito tidak lagi digantikan:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Muat Font dari Folder Aplikasi**

Alih-alih memasang font di folder sistem, Anda dapat mengirimkan mereka bersama aplikasi dan memuatnya dengan [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). Font tersebut kemudian tersedia hanya untuk Aspose.Slides, dan mereka dideploy bersama aplikasi. *FontCheck* melakukan ini: ketika direktori kerja, */app* di dalam kontainer, berisi folder *fonts*, program melewatkan folder itu ke `loadExternalFonts` sebelum membuat presentasi. [Custom Font](/slides/id/java/custom-font/) menjelaskan cara lain menyediakan font, seperti memuatnya dari memori.

Di *Dockerfile*, hapus instruksi `COPY fonts/ /usr/local/share/fonts/` dan tambahkan yang ini setelah instruksi yang menyalin folder *lib*:

```dockerfile
COPY fonts/ ./fonts/
```

Bangun kembali image dan jalankan pemeriksaan dengan dua perintah yang sama. Folder aplikasi kini muncul di antara folder font, dan Carlito masih tidak digantikan:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` menambahkan font ke yang terpasang, tetapi dukungan font Java masih membutuhkan setidaknya satu font yang terpasang. Pada image tanpa satupun, `loadExternalFonts` berhenti dengan error "Fontconfig head is null, check your fonts or fonts configuration".

## **Atur Font Bawaan untuk Font yang Hilang**

Ketika sebuah font tidak ada, Aspose.Slides menggunakan font pengganti yang dipilihnya sendiri. Untuk memilihnya sendiri, berikan nama font ke metode [setDefaultRegularFont](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) dari [LoadOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/), dan berikan opsi ke konstruktor [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/). *FontCheck* membaca nama font dari variabel lingkungan `DEFAULT_FONT`. Dengan Carlito dimuat, gunakan itu untuk font yang hilang:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri sekarang digambar dengan Carlito, yang karakternya memiliki lebar yang sama dengan Calibri, sehingga teks mempertahankan pemenggalan barisnya:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

Font bawaan menggantikan setiap font yang hilang. Untuk memetakan font individual, misalnya Arial ke Liberation Sans dan Calibri ke Carlito, gunakan [aturan substitusi font](/slides/id/java/font-substitution/). Aturan mengubah output yang dirender, tetapi `getSubstitutions` tidak mencerminkannya, jadi periksa font dalam file output sebagai gantinya. Untuk teks Asia, panggil juga [setDefaultAsianFont](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-); lihat [Font Bawaan](/slides/id/java/default-font/).

## **Pasang Font di Alpine Linux**

Image Eclipse Temurin berbasis Alpine juga berisi font DejaVu; [Jalankan di Alpine Linux](/slides/id/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) menjelaskan stage runtime-nya. Untuk memasang Microsoft core fonts di dalamnya juga, ganti stage runtime Dockerfile *font-check* dengan yang berikut:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
RUN apk add --no-cache msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

`update-ms-fonts` mengunduh dan memasang font Microsoft core yang sama seperti paket Debian dan Ubuntu, dan EULA-nya berlaku dengan cara yang sama. `fc-cache` memperbarui cache font fontconfig. Bangun image dan jalankan pemeriksaan dengan dua perintah dari [Periksa Font Mana yang Digantikan](#check-which-fonts-are-substituted). Ini mencetak:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Langkah lain pada halaman ini bekerja sama pada Alpine: salin folder *fonts* ke */usr/local/share/fonts* atau ke folder aplikasi, dan atur `DEFAULT_FONT` untuk memilih font bawaan. Image Alpine tidak memiliki folder */usr/local/share/fonts*, sehingga folder itu muncul pada baris `Font folders` hanya setelah instruksi `COPY` membuatnya.

## **FAQ**

**Mengapa sebuah presentasi terlihat berbeda ketika dikonversi di server?**

Server tidak memiliki font yang digunakan oleh presentasi, sehingga Aspose.Slides menggambar teks dengan font pengganti yang hurufnya memiliki lebar berbeda. Jalankan *FontCheck* dengan nama font presentasi untuk melihat font mana yang digantikan, lalu pasang font tersebut atau muat dari folder aplikasi.

**Build memasang ttf-mscorefonts-installer, tetapi Arial masih digantikan. Mengapa?**

EULA tidak diterima sebelum paket dipasang, sehingga installer melewatkan font. Letakkan perintah `debconf-set-selections` sebelum `apt-get install` dalam instruksi yang memasang paket, seperti yang ditunjukkan pada [Microsoft Core Fonts](#microsoft-core-fonts), dan bangun kembali image.

**Apakah komputer yang membuka PDF membutuhkan font?**

Tidak. Dalam contoh ini, PDF berisi font yang digunakan untuk menggambar teks, sehingga tampil sama di komputer mana pun. Font hanya diperlukan di tempat Aspose.Slides merender presentasi.