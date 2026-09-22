---
title: Menentukan Format Presentasi Asli dalam Java
linktitle: Format Sumber
type: docs
weight: 35
url: /id/java/detect-presentation-source-format/
keywords:
- format sumber
- deteksi format presentasi
- PowerPoint
- OpenDocument
- presentasi
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Baca format asli dari presentasi yang dimuat dalam Java dengan Aspose.Slides for Java, bandingkan API deteksi, dan tangani file, stream, serta format legacy."
---
## **Ikhtisar**

Setelah memuat presentasi, panggil metode [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getSourceFormat--) untuk menentukan format aslinya. Metode ini juga tersedia melalui [IPresentation.getSourceFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentation/#getSourceFormat--). Gunakan metode ini ketika pemrosesan selanjutnya bergantung pada format dari mana instance saat ini dimuat.

Format sumber berbeda dari [SaveFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/) yang dipilih untuk file keluaran. Menyimpan ke format lain tidak mengubah format sumber dari instance yang ada.

## **Baca Format Sumber dari File**

Contoh ini memerlukan file `sample.pptx` yang sudah ada. Ia memuat file dan memilih kebijakan pemrosesan aplikasi menggunakan [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getSourceFormat--), bukan nama file. Ubah jalur input untuk mencoba format lain. Contoh ini mencetak kebijakan yang dipilih; ganti pesan dengan logika aplikasi Anda.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Kenali Nilai yang Didukung**

Kelas [SourceFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/sourceformat/) mendefinisikan konstanta integer yang membedakan format presentasi berikut. Ekstensi di bawah ini bersifat konvensional, bukan rekonstruksi nama file asli.

| Nilai SourceFormat | Ekstensi | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | Presentasi PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Presentasi Office Open XML |
| `Pptm` | `.pptm` | Presentasi Office Open XML dengan makro |
| `Pps` | `.pps` | Slide show PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Slide show Office Open XML |
| `Ppsm` | `.ppsm` | Slide show Office Open XML dengan makro |
| `Pot` | `.pot` | Template PowerPoint 97–2003 |
| `Potx` | `.potx` | Template Office Open XML |
| `Potm` | `.potm` | Template Office Open XML dengan makro |
| `Odp` | `.odp` | Presentasi OpenDocument |
| `Otp` | `.otp` | Template presentasi OpenDocument |
| `Fodp` | `.fodp` | Presentasi Flat XML ODF |
| `Xml` | `.xml` | Presentasi PowerPoint XML |

## **Baca Format Sumber dari Stream**

Contoh ini memerlukan file `sample.pps` yang sudah ada. Membaca byte‑nya ke dalam stream memori mensimulasikan input yang diterima tanpa nama file, seperti nilai basis data atau array byte yang diunggah. Konstruktor [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) menerima hanya stream tersebut.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS, dan POT menggunakan format biner yang sama. Saat memuat melalui jalur file, ekstensi dapat membantu membedakan slide show atau template. Tanpa nama file, konten legacy PPS dan POT dapat dilaporkan sebagai `SourceFormat.Ppt`; contoh PPS di atas mencetak nilai integer `SourceFormat.Ppt`.

Jika aplikasi Anda harus mempertahankan perbedaan tersebut, simpan nama file asli atau metadata subtipe secara terpisah. Ekstensi merupakan petunjuk yang berguna untuk subtipe legacy ini, tetapi tidak boleh menjadi satu‑satunya dasar untuk mengidentifikasi konten presentasi apa pun.

## **Bandingkan Deteksi Sebelum dan Setelah Memuat**

Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) dan [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) ketika Anda perlu memeriksa file sebelum memuat model objek presentasi lengkapnya. Gunakan [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getSourceFormat--) ketika instance sudah ada.

Contoh ini memerlukan `sample.pptx` dan mencetak nilai integer `LoadFormat.Pptx` serta `SourceFormat.Pptx`. Dalam produksi, pilih API yang sesuai dengan tahap pemrosesan Anda; presentasi yang sudah dimuat tidak memerlukan inspeksi kedua semata‑mata untuk memperoleh format sumbernya.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Hasilnya menggunakan konstanta dari kelas yang berbeda: [LoadFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadformat/) dan [SourceFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/sourceformat/). Jangan membandingkan nilai numeriknya atau mengasumsikan setiap format memiliki hasil deteksi yang identik. PowerPoint XML dapat dilaporkan sebagai `LoadFormat.Unknown` sebelum pemuatan dan `SourceFormat.Xml` setelah pemuatan.

## **Pisahkan Format Sumber dan Output**

Contoh ini memerlukan `sample.pptx` dan menulis `converted.odp`. Ia mencetak nilai integer `SourceFormat.Pptx` baik sebelum maupun setelah menyimpan instance asli. Hanya instance baru yang dimuat dari output ODP yang melaporkan `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Presentasi yang dibuat dari awal dengan `new Presentation()` melaporkan `SourceFormat.Pptx`. Karena tidak ada file input: ini adalah nilai default untuk instance yang baru dibuat, bukan bukti bahwa file PPTX telah dimuat. Lacak apakah aplikasi Anda membuat atau memuat instance secara terpisah jika perbedaan itu penting.

## **Pemetaan Format Sumber ke Ekstensi**

Contoh berikut memerlukan `sample.pptx`. Ia memetakan setiap nilai [SourceFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/sourceformat/) yang saat ini didukung ke ekstensi konvensional, tanpa mengurai nama file input. Mekanisme fallback menghindari penetapan ekstensi secara diam‑diam pada nilai yang tidak dikenali.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Pemetaan ini tidak mengubah file atau memulihkan subtipe legacy PPS/POT yang hilang selama pemuatan stream. Untuk penyimpanan sesungguhnya, pilih [SaveFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/) secara eksplisit, atau gunakan konversi yang ditunjukkan dalam [Save Presentations in Their Original Format](/slides/id/java/save-presentation/#save-presentations-in-their-original-format).

## **Verifikasi Format dengan Menyimpan dan Membuka Kembali**

Contoh mandiri ini membuat presentasi dan menulis tiga file di direktori kerja, menimpa file dengan nama yang sama. Ia membuka kembali setiap output baik melalui jalur maupun melalui stream memori. Untuk PPTX dan ODP, kedua jalur melaporkan format yang disimpan. Untuk PPS, pemuatan via jalur melaporkan `Pps`, sementara pemuatan byte yang sama tanpa nama file melaporkan `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Tabel berikut merangkum identifikasi format sumber untuk presentasi dengan ekstensi yang cocok. Nama menunjukkan konstanta; contoh Java mencetak nilai integernya:

| Format yang Disimpan | SourceFormat dari jalur file | SourceFormat dari stream tanpa nama |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` masing‑masing | Sama dengan jalur file |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` masing‑masing | Sama dengan jalur file |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` masing‑masing | Sama dengan jalur file |
| ODP, OTP | `Odp`, `Otp` masing‑masing | Sama dengan jalur file |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Konten PPS/POT diidentifikasi sebagai `Ppt` untuk stream tanpa nama. Tabel ini menjelaskan identifikasi format, bukan preservasi setiap fitur presentasi selama konversi.

## **Tanya Jawab**

**Apakah menyimpan ke ODP mengubah format sumber presentasi yang dimuat dari PPTX?**

Tidak. Instance yang ada tetap melaporkan `Pptx`. Instance yang dimuat dari file ODP yang disimpan melaporkan `Odp`.

**Apakah stream selalu dapat membedakan presentasi legacy, slide show, dan template?**

Tidak. PPT, PPS, dan POT berbagi format biner. Simpan nama file atau metadata subtipe secara terpisah ketika perbedaan tersebut dibutuhkan.

**API mana yang harus saya gunakan jika presentasi sudah dimuat?**

Baca [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getSourceFormat--). Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) untuk inspeksi sebelum pemuatan.