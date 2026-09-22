---
title: Menentukan Format Presentasi Asli di Node.js
linktitle: Format Sumber
type: docs
weight: 35
url: /id/nodejs-java/detect-presentation-source-format/
keywords:
- format sumber
- deteksi format presentasi
- PowerPoint
- OpenDocument
- presentasi
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Baca format asli dari presentasi yang dimuat di Node.js dengan Aspose.Slides untuk Node.js via Java, bandingkan API deteksi, dan tangani file, stream, serta format warisan."
---
## **Gambaran Umum**

Setelah memuat sebuah presentasi, panggil metode [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSourceFormat) untuk menentukan format aslinya. Gunakan metode ini ketika pemrosesan selanjutnya tergantung pada format dari mana instance saat ini dimuat.

Format sumber berbeda dari [SaveFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/) yang dipilih untuk file output. Menyimpan ke format lain tidak mengubah format sumber dari instance yang ada.

## **Baca Format Sumber dari File**

Contoh ini memerlukan file `sample.pptx` yang sudah ada. Ia memuat file tersebut dan memilih kebijakan pemrosesan aplikasi menggunakan [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSourceFormat), bukan berdasarkan nama file. Ubah jalur input untuk mencoba format lain. Contoh ini mencetak kebijakan yang dipilih; ganti pesan-pesan tersebut dengan logika aplikasi Anda.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Mengenali Nilai-Nilai yang Didukung**

Kelas [SourceFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sourceformat/) mendefinisikan konstanta bilangan bulat yang membedakan format presentasi berikut. Ekstensi di bawah ini adalah ekstensi konvensional, bukan rekonstruksi nama file asli.

| Nilai SourceFormat | Ekstensi | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | presentasi PowerPoint 97–2003 |
| `Pptx` | `.pptx` | presentasi Office Open XML |
| `Pptm` | `.pptm` | presentasi Office Open XML dengan makro |
| `Pps` | `.pps` | pertunjukan slide PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | pertunjukan slide Office Open XML |
| `Ppsm` | `.ppsm` | pertunjukan slide Office Open XML dengan makro |
| `Pot` | `.pot` | templat PowerPoint 97–2003 |
| `Potx` | `.potx` | templat Office Open XML |
| `Potm` | `.potm` | templat Office Open XML dengan makro |
| `Odp` | `.odp` | presentasi OpenDocument |
| `Otp` | `.otp` | templat presentasi OpenDocument |
| `Fodp` | `.fodp` | presentasi Flat XML ODF |
| `Xml` | `.xml` | presentasi PowerPoint XML |

## **Baca Format Sumber dari Stream**

Contoh ini memerlukan file `sample.pps` yang sudah ada. Membaca byte-nya ke dalam stream memori mensimulasikan input yang diterima tanpa nama file, seperti nilai basis data atau array byte yang diunggah. Konstruktor [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) menerima hanya stream tersebut.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS, dan POT menggunakan format biner yang sama. Saat memuat melalui jalur file, ekstensi dapat membantu membedakan pertunjukan slide atau templat. Tanpa nama file, konten PPS dan POT lama dapat dilaporkan sebagai `SourceFormat.Ppt`; contoh PPS di atas mencetak nilai bilangan bulat dari `SourceFormat.Ppt`.

Jika aplikasi Anda harus mempertahankan perbedaan tersebut, simpan nama file asli atau metadata subtipe secara terpisah. Ekstensi merupakan petunjuk yang berguna untuk subtipe lama ini, tetapi tidak boleh menjadi satu‑satunya dasar untuk mengidentifikasi konten presentasi apa pun.

## **Bandingkan Deteksi Sebelum dan Sesudah Memuat**

Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) dan [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) ketika Anda perlu memeriksa file sebelum memuat model objek presentasi lengkapnya. Gunakan [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSourceFormat) ketika instance sudah ada.

Contoh ini memerlukan `sample.pptx` dan mencetak nilai bilangan bulat dari `LoadFormat.Pptx` dan `SourceFormat.Pptx`, masing‑masing. Dalam produksi, pilih API yang sesuai dengan tahap pemrosesan Anda; presentasi yang sudah dimuat tidak memerlukan inspeksi kedua hanya untuk memperoleh format sumbernya.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Hasilnya menggunakan konstanta dari kelas yang berbeda: [LoadFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadformat/) dan [SourceFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sourceformat/). Jangan membandingkan nilai numeriknya atau mengasumsikan bahwa setiap format memiliki hasil deteksi yang identik. PowerPoint XML dapat dilaporkan sebagai `LoadFormat.Unknown` sebelum pemuatan dan `SourceFormat.Xml` setelah pemuatan.

## **Pisahkan Format Sumber dan Output**

Contoh ini memerlukan `sample.pptx` dan menulis `converted.odp`. Ia mencetak nilai bilangan bulat `SourceFormat.Pptx` baik sebelum maupun setelah menyimpan instance asli. Hanya instance baru yang dimuat dari output ODP yang melaporkan `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Presentasi yang dibuat dari awal dengan `new Presentation()` melaporkan `SourceFormat.Pptx`. Ia tidak memiliki file input: ini adalah nilai default untuk instance yang baru dibuat, bukan bukti bahwa file PPTX telah dimuat. Lacak apakah aplikasi Anda membuat atau memuat instance secara terpisah jika perbedaan itu penting.

## **Pemetaan Format Sumber ke Ekstensi**

Contoh berikut memerlukan `sample.pptx`. Ia memetakan setiap nilai [SourceFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sourceformat/) yang saat ini didukung ke ekstensi konvensional, tanpa menguraikan nama file input. Penanganan cadangan menghindari penetapan ekstensi secara diam‑diam ke nilai yang tidak dikenali.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Pemetaan ini tidak mengonversi file atau memulihkan subtipe PPS/POT lama yang hilang selama pemuatan stream. Untuk penyimpanan sebenarnya, pilih [SaveFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/) secara eksplisit, atau gunakan konversi yang ditunjukkan dalam [Save Presentations in Their Original Format](/slides/id/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Verifikasi Format dengan Menyimpan dan Membuka Kembali**

Contoh mandiri ini membuat sebuah presentasi dan menulis tiga file di direktori kerja, menimpa file dengan nama yang sama. Ia membuka kembali setiap output baik melalui jalur maupun melalui stream memori. Untuk PPTX dan ODP, kedua jalur melaporkan format yang disimpan. Untuk PPS, pemuatan melalui jalur melaporkan `Pps`, sementara pemuatan byte yang sama tanpa nama file melaporkan `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Tabel berikut merangkum identifikasi format sumber untuk presentasi dengan ekstensi yang cocok. Nama-nama menunjukkan konstanta; contoh JavaScript mencetak nilai bilangan bulatnya:

| Format Tersimpan | SourceFormat dari jalur file | SourceFormat dari stream tanpa nama |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Konten PPS/POT diidentifikasi sebagai `Ppt` untuk stream tanpa nama. Tabel tersebut menggambarkan identifikasi format, bukan preservasi setiap fitur presentasi selama konversi.

## **FAQ**

**Apakah menyimpan ke ODP mengubah format sumber presentasi yang dimuat dari PPTX?**

Tidak. Instance yang ada tetap melaporkan `Pptx`. Instance yang dimuat dari file ODP yang disimpan melaporkan `Odp`.

**Apakah sebuah stream selalu dapat membedakan presentasi lama, pertunjukan slide, dan templat?**

Tidak. PPT, PPS, dan POT berbagi format biner. Simpan nama file atau metadata subtipe secara terpisah ketika perbedaan tersebut diperlukan.

**API mana yang harus saya gunakan jika presentasi sudah dimuat?**

Baca [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSourceFormat). Gunakan [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) untuk inspeksi sebelum pemuatan.