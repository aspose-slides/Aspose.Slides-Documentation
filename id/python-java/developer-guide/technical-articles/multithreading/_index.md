---
title: Multithreading dalam Aspose.Slides untuk Python via Java
linktitle: Multithreading
type: docs
weight: 310
url: /id/python-java/multithreading/
keywords:
- multithreading
- banyak thread
- pekerjaan paralel
- mengonversi slide
- slide ke gambar
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Multithreading Aspose.Slides untuk Python via Java meningkatkan pemrosesan PowerPoint dan OpenDocument. Temukan praktik terbaik untuk alur kerja presentasi yang efisien."
---
## **Pendahuluan**

Meskipun kerja paralel dengan presentasi dimungkinkan (kecuali untuk parsing, pemuatan, dan kloning) dan biasanya bekerja dengan baik, ada kemungkinan kecil hasil yang tidak tepat ketika Anda menggunakan perpustakaan ini dalam beberapa thread.

Kami sangat menyarankan agar Anda **tidak** menggunakan satu instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dalam lingkungan multithread karena dapat menghasilkan kesalahan atau kegagalan yang tidak dapat diprediksi dan tidak mudah terdeteksi.

Tidak **aman** untuk memuat, menyimpan, dan/atau mengkloning sebuah instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dalam beberapa thread. Operasi semacam itu **tidak** didukung. Jika Anda perlu melakukan tugas tersebut, Anda harus memparalelkan operasi menggunakan beberapa proses satu thread—dan tiap proses tersebut harus menggunakan instance presentasi masing‑masing.

## **Mengonversi Slide Presentasi ke Gambar Secara Paralel**

Misalkan kita ingin mengonversi semua slide dari presentasi PowerPoint ke gambar PNG secara paralel. Karena tidak aman menggunakan satu instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dalam beberapa thread, kita membagi slide presentasi menjadi presentasi terpisah dan mengonversi slide ke gambar secara paralel, dengan menggunakan setiap presentasi di thread terpisah. Contoh kode berikut menunjukkan cara melakukannya.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Ekstrak slide ke presentasi terpisah.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Konversi slide ke gambar dalam tugas terpisah.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Tunggu semua tugas selesai.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya perlu memanggil pengaturan lisensi di setiap thread?**

Tidak. Cukup melakukannya sekali per proses sebelum thread dimulai. Jika [license setup](/slides/id/python-java/licensing/) dapat dipanggil secara bersamaan (misalnya selama inisialisasi malas), sinkronkan pemanggilan itu karena metode pengaturan lisensi itu sendiri tidak thread‑safe.

**Apakah saya dapat meneruskan objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) atau [Slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/) antar thread?**

Meneruskan objek presentasi yang “aktif” antar thread tidak disarankan: gunakan instance terpisah per thread atau buat presentasi atau kontainer slide terpisah untuk setiap thread sebelumnya. Pendekatan ini mengikuti rekomendasi umum untuk tidak membagikan satu instance presentasi antar thread.

**Apakah aman memparalelkan ekspor ke format berbeda (PDF, HTML, gambar) asalkan setiap thread memiliki instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) masing‑masing?**

Ya. Dengan instance independen dan jalur output terpisah, tugas semacam itu biasanya dapat diparalelkan dengan benar; hindari objek presentasi yang dibagi dan aliran I/O yang dibagi.

**Apa yang harus saya lakukan dengan pengaturan font global (folder, substitusi) dalam multithreading?**

Inisialisasi semua [pengaturan font](/slides/id/python-java/powerpoint-fonts/) global sebelum memulai thread dan jangan mengubahnya selama pekerjaan paralel. Ini menghilangkan kondisi balapan saat mengakses sumber daya font yang dibagi.