---
title: Multithreading di Aspose.Slides untuk Java
linktitle: Multithreading
type: docs
weight: 310
url: /id/java/multithreading/
keywords:
- multithreading
- beberapa thread
- pekerjaan paralel
- mengonversi slide
- slide ke gambar
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Multithreading Aspose.Slides untuk Java meningkatkan pemrosesan PowerPoint dan OpenDocument. Temukan praktik terbaik untuk alur kerja presentasi yang efisien."
---
## **Pendahuluan**

Sementara pekerjaan paralel dengan presentasi memungkinkan (selain parsing/muat/kloning) dan semuanya berjalan baik (kebanyakan waktu), ada kemungkinan kecil Anda mendapatkan hasil yang tidak tepat saat menggunakan perpustakaan ini di beberapa thread.

Kami sangat menyarankan agar Anda **tidak** menggunakan satu instance [Presentasi](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) dalam lingkungan multi‑threading karena dapat menyebabkan kesalahan atau kegagalan yang tidak dapat diprediksi dan sulit dideteksi. 

Tidak **aman** untuk memuat, menyimpan, dan/atau mengkloning sebuah instance kelas [Presentasi](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) dalam banyak thread. Operasi semacam itu **tidak** didukung. Jika Anda perlu melakukan tugas tersebut, Anda harus memparalelkan operasi menggunakan beberapa proses satu‑thread—dan masing‑masing proses tersebut harus menggunakan instance presentasi masing‑masing. 

## **Mengonversi Slide Presentasi menjadi Gambar secara Paralel**

Misalkan kita ingin mengonversi semua slide dari sebuah presentasi PowerPoint menjadi gambar PNG secara paralel. Karena tidak aman menggunakan satu instance `Presentation` pada banyak thread, kita membagi slide presentasi menjadi presentasi terpisah dan mengonversi slide menjadi gambar secara paralel, dengan menggunakan tiap presentasi pada thread terpisah. Contoh kode berikut menunjukkan cara melakukannya.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Ekstrak slide i ke dalam presentasi terpisah.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Konversi slide menjadi gambar dalam tugas terpisah.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Tunggu semua tugas selesai.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **FAQ**

**Apakah saya perlu memanggil penyiapan lisensi di setiap thread?**

Tidak. Cukup lakukan sekali per proses/domain aplikasi sebelum thread dimulai. Jika [penyiapan lisensi](/slides/id/java/licensing/) dapat dipanggil secara bersamaan (misalnya, selama inisialisasi malas), sinkronkan pemanggilan tersebut karena metode penyiapan lisensi itu sendiri tidak aman untuk thread.

**Apakah saya dapat melewatkan objek `Presentation` atau `Slide` antar thread?**

Melewatkan objek presentasi "aktif" antar thread tidak disarankan: gunakan instance independen per thread atau buat terlebih dahulu presentasi/kontainer slide terpisah untuk setiap thread. Pendekatan ini mengikuti rekomendasi umum untuk tidak berbagi satu instance presentasi di antara thread.

**Apakah aman memparalelkan ekspor ke format berbeda (PDF, HTML, gambar) dengan asumsi setiap thread memiliki instance `Presentation` masing‑masing?**

Ya. Dengan instance independen dan jalur output terpisah, tugas semacam itu biasanya dapat diparalelkan dengan benar; hindari objek presentasi yang dibagikan dan aliran I/O yang bersama.

**Apa yang harus saya lakukan dengan pengaturan font global (folder, substitusi) dalam multithreading?**

Inisialisasi semua [pengaturan font](/slides/id/java/powerpoint-fonts/) global sebelum memulai thread dan jangan ubah selama pekerjaan paralel. Ini menghilangkan kondisi balapan saat mengakses sumber daya font yang dibagikan.