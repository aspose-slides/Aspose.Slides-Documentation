---
title: Interupsi Operasi Presentasi yang Memakan Waktu Lama di Node.js
linktitle: Interupsi Operasi Presentasi
type: docs
weight: 120
url: /id/nodejs-java/support-for-interruptable-library/
keywords:
- operasi yang dapat diinterupsi
- token interupsi
- token pembatalan
- batas waktu konversi
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Batalkan operasi presentasi yang memakan waktu lama di Aspose.Slides untuk Node.js via Java, atur batas waktu konversi, dan lacak slide yang diekspor sebelum pembatalan."
---
## **Gambaran Umum**

Aspose.Slides untuk Node.js via Java mendukung pembatalan saat memuat, menyimpan, atau merender sebuah presentasi. Anda juga dapat memeriksa token yang sama dalam loop ekspor Anda sendiri untuk berhenti sebelum slide berikutnya dan mengembalikan nomor slide yang telah disimpan.

## **Interupsi Operasi Presentasi**

Buat sebuah [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), dapatkan tokennya dengan [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken), dan serahkan ke [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Gunakan opsi ini saat membangun [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Memanggil [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) pada sumber meminta pembatalan operasi saat ini. Aspose.Slides berhenti ketika ia selanjutnya memeriksa token.

### **Atur Batas Waktu Konversi**

Contoh berikut memberikan waktu 20 detik untuk membuka `sample.pptx` dan menyimpannya sebagai `sample.pdf`. Baik konstruktor maupun proses penyimpanan berjalan secara asynchronous melalui jembatan Java sehingga timer Node.js dapat aktif selama operasi mana pun. Contoh memeriksa token setelah memuat dan lagi setelah menyimpan, karena panggilan perpustakaan dapat kembali setelah permintaan pembatalan. Ia melepaskan presentasi ketika operasi selesai dan menghapus timer jika konversi selesai lebih awal. Jika pembatalan terjadi selama penyimpanan, file output mungkin sudah ada dan mungkin tidak lengkap.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

Untuk mengonversi ke format PowerPoint lama dengan batas 10 detik, berikan `"sample.ppt"`, `slides.SaveFormat.Ppt`, dan `10000` sebagai tiga argumen terakhir.

## **Berhenti Sebelum Memproses Slide Berikutnya**

Gunakan [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) sebelum setiap ekspor ketika pemanggil dapat menggunakan hasil parsial. Overload [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) untuk slide yang dipilih menerima sebuah Java `int[]` berisi nomor slide yang dimulai dari 1. Catat setiap nomor hanya setelah PDF‑nya berhasil disimpan.

Jalankan contoh dengan presentasi bernama `sample.pptx` yang berisi minimal dua slide. Untuk mendemonstrasikan pembatalan antar ekspor, contoh meminta pembatalan segera setelah menyimpan slide pertama.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

Contoh menulis `slide-1.pdf` dan mencetak `Starting slide 1` diikuti oleh `Completed: [1]`. Loop memperhatikan pembatalan sebelum memulai slide 2. Jika penyimpanan sendiri terinterupsi, daftar yang dikembalikan hanya berisi ekspor yang berhasil sebelumnya.

Untuk memungkinkan pemanggil menangani pembatalan sebagai kesalahan, gantilah pemeriksaan dan `break`‑nya di bagian atas loop dengan [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), dipanggil sebagai `token.throwIfInterruptionRequested()`. Gunakan pemeriksaan lemparan yang sama setelah penyimpanan dan hapus `try`/`catch` di sekitarnya. Dengan input yang sama, PDF pertama tetap ditulis, dan iterasi kedua melempar sebelum fungsi dapat mengembalikan daftar.

## **FAQ**

**Kapan saya harus meminta pembatalan?**

Minta pembatalan ketika batas waktu berakhir atau aplikasi tidak lagi membutuhkan hasilnya. Memuat, menyimpan, dan merender semuanya dapat menggunakan token yang diberikan kepada presentasi saat konstruksi.

**Apa perbedaan antara sumber dan token?**

Sumber memungkinkan aplikasi meminta pembatalan. Token memungkinkan Aspose.Slides dan kode Anda memeriksa permintaan tersebut.

**Apakah timer Node.js dapat menginterupsi penyimpanan sinkron?**

Penyimpanan sinkron memblokir JavaScript pada thread pemanggil. Gunakan panggilan jembatan Java asynchronous yang ditunjukkan dalam contoh batas waktu agar timer dapat meminta pembatalan saat penyimpanan sedang berjalan.

**Apakah pembatalan berlaku segera?**

Pembatalan bersifat kooperatif. Operasi yang sedang berjalan berhenti ketika ia memperhatikan permintaan. Operasi yang sudah selesai tetap mempertahankan hasilnya.

**Apakah beberapa operasi dapat berbagi satu sumber?**

Ya. Memanggil `interrupt()` meminta pembatalan untuk setiap operasi yang menggunakan token dari sumber tersebut. Gunakan sumber terpisah untuk setiap operasi yang ingin Anda batalkan secara independen.