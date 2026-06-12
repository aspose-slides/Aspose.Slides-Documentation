---
title: Multithreading di Aspose.Slides untuk C++
linktitle: Multithreading
type: docs
weight: 200
url: /id/cpp/multithreading/
keywords:
- multithreading
- beberapa thread
- pekerjaan paralel
- mengonversi slide
- slide ke gambar
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Multithreading Aspose.Slides untuk C++ meningkatkan pemrosesan PowerPoint dan OpenDocument. Temukan praktik terbaik untuk alur kerja presentasi yang efisien."
---
## **Pendahuluan**

Sementara pekerjaan paralel dengan presentasi dimungkinkan (selain parsing/muat/kloning) dan semuanya berjalan baik (kebanyakan waktu), ada sedikit kemungkinan Anda mendapatkan hasil yang tidak tepat ketika menggunakan perpustakaan dalam beberapa thread.

Kami sangat menyarankan agar Anda **tidak** menggunakan satu instance [Presentasi](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dalam lingkungan multi‑threading karena dapat menghasilkan kesalahan atau kegagalan yang tidak dapat diprediksi dan tidak mudah terdeteksi. 

Tidak aman untuk memuat, menyimpan, dan/atau mengkloning sebuah instance kelas [Presentasi](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation) dalam beberapa thread. Operasi semacam itu **tidak** didukung. Jika Anda perlu melakukan tugas tersebut, Anda harus memparalelkan operasi menggunakan beberapa proses satu‑thread—dan masing‑masing proses tersebut harus menggunakan instance presentasi mereka sendiri. 

## **Mengonversi Slide Presentasi menjadi Gambar secara Paralel**

Misalkan kita ingin mengonversi semua slide dari sebuah presentasi PowerPoint menjadi gambar PNG secara paralel. Karena tidak aman menggunakan satu instance `Presentation` dalam banyak thread, kita membagi slide presentasi menjadi presentasi terpisah dan mengonversi slide menjadi gambar secara paralel, menggunakan setiap presentasi dalam thread terpisah. Contoh kode berikut menunjukkan cara melakukannya.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Ekstrak slide i ke dalam presentasi terpisah.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Konversi slide menjadi gambar dalam tugas terpisah.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Tunggu semua tugas selesai.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **Tanya Jawab**

**Apakah saya perlu memanggil penyiapan lisensi di setiap thread?**

Tidak. Cukup lakukan sekali per proses/domain aplikasi sebelum thread dimulai. Jika [penyiapan lisensi](/slides/id/cpp/licensing/) mungkin dipanggil secara bersamaan (misalnya, selama inisialisasi malas), sinkronkan pemanggilan itu karena metode penyiapan lisensi sendiri tidak thread‑safe.

**Bisakah saya melewatkan objek `Presentation` atau `Slide` antar thread?**

Melewatkan objek presentasi “hidup” antar thread tidak disarankan: gunakan instance independen per thread atau buat sebelumnya presentasi/kontainer slide terpisah untuk setiap thread. Pendekatan ini mengikuti rekomendasi umum agar tidak berbagi satu instance presentasi antar thread.

**Apakah aman memparalelkan ekspor ke format berbeda (PDF, HTML, gambar) asalkan setiap thread memiliki instance `Presentation`‑nya sendiri?**

Ya. Dengan instance independen dan jalur keluaran terpisah, tugas semacam itu biasanya dapat diparalelkan dengan benar; hindari objek presentasi yang dibagi dan aliran I/O yang dibagi.

**Apa yang harus saya lakukan dengan pengaturan font global (folder, substitusi) dalam multithreading?**

Inisialisasi semua pengaturan font global sebelum memulai thread dan jangan ubah selama pekerjaan paralel. Ini menghilangkan kondisi balapan saat mengakses sumber daya font yang dibagi.