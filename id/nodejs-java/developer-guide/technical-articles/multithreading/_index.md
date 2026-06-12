---
title: Multithreading di Aspose.Slides untuk Node.js via Java
linktitle: Multithreading
type: docs
weight: 310
url: /id/nodejs-java/multithreading/
keywords:
- multithreading
- beberapa utas
- pekerjaan paralel
- mengonversi slide
- slide ke gambar
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Multithreading Aspose.Slides untuk Node.js via Java meningkatkan proses PowerPoint dan OpenDocument. Temukan praktik terbaik untuk alur kerja presentasi yang efisien."
---
## **Pendahuluan**

Meskipun pekerjaan paralel dengan presentasi dimungkinkan (selain parsing/memuat/menyalin) dan semuanya berjalan baik (kebanyakan waktu), ada kemungkinan kecil Anda mendapatkan hasil yang tidak tepat ketika menggunakan perpustakaan ini di beberapa utas.

Kami sangat menyarankan agar Anda **tidak** menggunakan satu instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) dalam lingkungan multi‑threading karena dapat menghasilkan kesalahan atau kegagalan yang tidak dapat diprediksi dan sulit dideteksi.

Tidak **aman** untuk memuat, menyimpan, dan/atau menyalin sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) di beberapa utas. Operasi semacam itu **tidak** didukung. Jika Anda perlu melakukan tugas tersebut, Anda harus memparalelkan operasi menggunakan beberapa proses satu‑utasan—dan setiap proses tersebut harus menggunakan instance presentasinya masing‑masing.

## **Mengonversi Slide Presentasi ke Gambar Secara Paralel**

Misalkan kita ingin mengonversi semua slide dari sebuah presentasi PowerPoint ke gambar PNG secara paralel. Karena tidak aman menggunakan satu instance `Presentation` di banyak utas, kami membagi slide presentasi menjadi beberapa presentasi terpisah dan mengonversi slide tersebut ke gambar secara paralel, dengan setiap presentasi dijalankan di utas terpisah. Contoh kode berikut memperlihatkan cara melakukannya.

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Ekstrak slide i ke presentasi terpisah.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Tunggu semua tugas selesai.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **FAQ**

**Apakah saya perlu memanggil pengaturan lisensi di setiap utas?**

Tidak. Cukup lakukan sekali per proses/domain aplikasi sebelum utas dimulai. Jika [license setup](/slides/id/nodejs-java/licensing/) mungkin dipanggil secara bersamaan (misalnya, saat inisialisasi malas), sinkronkan pemanggilan itu karena metode pengaturan lisensi itu sendiri tidak thread‑safe.

**Bisakah saya memindahkan objek `Presentation` atau `Slide` antar utas?**

Memindahkan objek presentasi “aktif” antar utas tidak disarankan: gunakan instance independen per utas atau buat sebelumnya presentasi/kontainer slide terpisah untuk setiap utas. Pendekatan ini mengikuti rekomendasi umum untuk tidak berbagi satu instance presentasi di antara utas.

**Apakah aman memparalelkan ekspor ke format berbeda (PDF, HTML, gambar) asalkan setiap utas memiliki instance `Presentation`‑nya sendiri?**

Ya. Dengan instance independen dan jalur output terpisah, tugas semacam itu biasanya dapat diparalelkan dengan benar; hindari berbagi objek presentasi dan aliran I/O bersama.

**Apa yang harus saya lakukan dengan pengaturan font global (folder, substitusi) dalam multithreading?**

Inisialisasi semua pengaturan font global sebelum memulai utas dan jangan ubah selama pekerjaan paralel. Hal ini menghilangkan kondisi balapan saat mengakses sumber daya font bersama.