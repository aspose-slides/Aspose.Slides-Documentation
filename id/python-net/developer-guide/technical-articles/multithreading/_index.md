---
title: Multithreading di Aspose.Slides untuk Python
linktitle: Multithreading
type: docs
weight: 200
url: /id/python-net/multithreading/
keywords:
- multithreading
- beberapa thread
- pekerjaan paralel
- mengonversi slide
- slide ke gambar
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Aspose.Slides untuk Python melalui multithreading .NET meningkatkan pemrosesan PowerPoint dan OpenDocument. Temukan praktik terbaik untuk alur kerja presentasi yang efisien."
---
## **Pendahuluan**

Meskipun pekerjaan paralel dengan presentasi dimungkinkan (selain parsing/memuat/kloning) dan semuanya berjalan baik (kebanyakan waktu), ada kemungkinan kecil Anda mendapatkan hasil yang tidak tepat saat menggunakan pustaka ini dalam banyak thread.

Kami sangat menyarankan agar Anda **tidak** menggunakan satu instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dalam lingkungan multithreading karena dapat menghasilkan kesalahan atau kegagalan yang tidak dapat diprediksi dan sulit dideteksi. 

Tidak **aman** untuk memuat, menyimpan, dan/atau mengkloning sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dalam banyak thread. Operasi semacam itu **tidak** didukung. Jika Anda perlu melakukan tugas tersebut, Anda harus memparalelkan operasi dengan beberapa proses single-threaded—dan setiap proses tersebut harus menggunakan instance presentasinya sendiri. 

## **Mengonversi Slide Presentasi ke Gambar secara Paralel**

Misalkan kita ingin mengonversi semua slide dari presentasi PowerPoint ke gambar PNG secara paralel. Karena tidak aman menggunakan satu instance `Presentation` dalam banyak thread, kita membagi slide presentasi menjadi presentasi terpisah dan mengonversi slide ke gambar secara paralel, dengan menggunakan setiap presentasi dalam thread terpisah. Contoh kode berikut menunjukkan cara melakukannya.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Ekstrak slide i ke dalam presentasi terpisah.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Konversi slide menjadi gambar.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Tunggu semua tugas selesai.
for task in conversion_tasks:
    task.result()

del presentation
```

## **FAQ**

**Apakah saya perlu memanggil pengaturan lisensi di setiap thread?**

Tidak. Cukup melakukannya sekali per proses/domain aplikasi sebelum thread dimulai. Jika [license setup](/slides/id/python-net/licensing/) mungkin dipanggil secara bersamaan (misalnya, selama inisialisasi malas), sinkronkan pemanggilan tersebut karena metode pengaturan lisensi itu sendiri tidak thread‑safe. 

**Apakah saya bisa melewatkan objek `Presentation` atau `Slide` antar thread?**

Melewatkan objek presentasi yang “live” antar thread tidak disarankan: gunakan instance independen per thread atau buat terlebih dahulu presentasi/kontainer slide terpisah untuk setiap thread. Pendekatan ini mengikuti rekomendasi umum untuk tidak membagikan satu instance presentasi di antara thread. 

**Apakah aman memparalelkan ekspor ke format berbeda (PDF, HTML, gambar) dengan asumsi setiap thread memiliki instance `Presentation`‑nya sendiri?**

Ya. Dengan instance independen dan jalur output terpisah, tugas semacam itu biasanya dapat diparalelkan dengan benar; hindari objek presentasi yang dibagikan serta aliran I/O yang dibagikan. 

**Apa yang harus saya lakukan dengan pengaturan font global (folder, substitusi) dalam multithreading?**

Inisialisasi semua pengaturan font global sebelum memulai thread dan jangan mengubahnya selama pekerjaan paralel. Hal ini menghilangkan kondisi balapan saat mengakses sumber daya font yang dibagikan.