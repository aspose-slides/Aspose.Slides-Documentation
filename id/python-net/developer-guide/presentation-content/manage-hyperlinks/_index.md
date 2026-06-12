---
title: Kelola Hyperlink dalam Presentasi dengan Python
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/python-net/manage-hyperlinks/
keywords:
- menambahkan URL
- menambahkan hyperlink
- membuat hyperlink
- memformat hyperlink
- menghapus hyperlink
- memperbarui hyperlink
- hyperlink teks
- hyperlink slide
- hyperlink bentuk
- hyperlink gambar
- hyperlink video
- hyperlink dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- Python
description: "Kelola hyperlink dengan mudah dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET—tingkatkan interaktivitas dan alur kerja dalam hitungan menit."
---
## **Introduction**

Hyperlink adalah referensi ke sumber eksternal, objek atau item data, atau lokasi spesifik dalam sebuah file. Jenis hyperlink umum dalam presentasi PowerPoint meliputi:

* Tautan ke situs web yang disematkan dalam teks, bentuk, atau media
* Tautan ke slide

Aspose.Slides for Python via .NET memungkinkan berbagai operasi terkait hyperlink dalam presentasi.

## **Add URL Hyperlinks**

Bagian ini menjelaskan cara menambahkan hyperlink URL ke elemen slide saat bekerja dengan Aspose.Slides. Ini mencakup penetapan alamat tautan ke teks, bentuk, dan gambar untuk memastikan navigasi yang mulus selama presentasi.

### **Add URL Hyperlinks to Text**

Contoh kode berikut menunjukkan cara menambahkan hyperlink situs web ke teks:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Add URL Hyperlinks to Shapes or Frames**

Contoh kode berikut menunjukkan cara menambahkan hyperlink situs web ke sebuah bentuk:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Add URL Hyperlinks to Media**

Aspose.Slides memungkinkan Anda menambahkan hyperlink ke file gambar, audio, dan video.

Contoh kode berikut menunjukkan cara menambahkan hyperlink ke **gambar**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tambahkan gambar ke presentasi.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Buat sebuah frame gambar pada slide 1 menggunakan gambar yang ditambahkan sebelumnya.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Contoh kode berikut menunjukkan cara menambahkan hyperlink ke **file audio**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Contoh kode berikut menunjukkan cara menambahkan hyperlink ke **video**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Anda mungkin ingin melihat [Manage OLE in Presentations Using Python](/slides/id/python-net/manage-ole/).
{{% /alert %}}

## **Use Hyperlinks to Create a Table of Contents**

Karena hyperlink memungkinkan Anda merujuk ke objek atau lokasi, Anda dapat menggunakannya untuk membuat daftar isi.

Contoh kode di bawah ini menunjukkan cara membuat daftar isi dengan hyperlink:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Format Hyperlinks**

Bagian ini menunjukkan cara memformat tampilan hyperlink di Aspose.Slides. Anda akan belajar mengontrol warna dan opsi gaya lainnya untuk menjaga konsistensi format hyperlink di teks, bentuk, dan gambar.

### **Hyperlink Color**

Dengan menggunakan properti [color_source](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/color_source/) dari kelas [Hyperlink](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/), Anda dapat mengatur warna hyperlink dan membaca informasi warnanya. Fitur ini diperkenalkan di PowerPoint 2019, sehingga perubahan yang dibuat melalui properti ini tidak berlaku untuk versi PowerPoint sebelumnya.

Contoh berikut menunjukkan cara menambahkan hyperlink dengan warna berbeda ke slide yang sama:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Removе Hyperlinks from Presentations**

Bagian ini menjelaskan cara menghapus hyperlink dari presentasi saat bekerja dengan Aspose.Slides. Anda akan belajar cara menghapus target tautan dari teks, bentuk, dan gambar sambil mempertahankan konten dan format asli.

### **Removе Hyperlinks from Text**

Contoh kode berikut menunjukkan cara menghapus hyperlink dari teks pada slide presentasi:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Remove Hyperlinks from Shapes or Frames**

Contoh kode berikut menunjukkan cara menghapus hyperlink dari bentuk pada slide presentasi: 

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Mutable Hyperlinks**

Kelas [Hyperlink](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/) bersifat mutable. Dengan menggunakan kelas ini, Anda dapat mengubah nilai properti berikut:

- [target_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

Cuplikan kode berikut menunjukkan cara menambahkan hyperlink ke slide dan kemudian mengedit tooltip-nya:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Supported Properties in IHyperlinkQueries**

Anda dapat mengakses [HyperlinkQueries](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/) dari presentasi, slide, atau teks yang berisi hyperlink.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/hyperlink_queries/)

Kelas [HyperlinkQueries](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/) mendukung metode berikut: 

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Anda mungkin ingin melihat editor [PowerPoint](https://products.aspose.app/slides/id/editor) sederhana dan gratis secara online dari Aspose.
{{% /alert %}}

## **FAQ**

**Bagaimana saya dapat membuat navigasi internal tidak hanya ke sebuah slide, tetapi ke "section" atau slide pertama dari sebuah section?**

Section di PowerPoint adalah pengelompokan slide; navigasi secara teknis menargetkan slide tertentu. Untuk "menavigasi ke section", Anda biasanya menautkan ke slide pertamanya.

**Apakah saya dapat menempelkan hyperlink pada elemen master slide sehingga berfungsi di semua slide?**

Ya. Elemen master slide dan layout mendukung hyperlink. Tautan semacam itu muncul di slide turunan dan dapat diklik selama presentasi.

**Apakah hyperlink akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Pada [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/python-net/convert-powerpoint-to-html/), ya—tautan biasanya dipertahankan. Saat mengekspor ke [gambar](/slides/id/python-net/convert-powerpoint-to-png/) dan [video](/slides/id/python-net/convert-powerpoint-to-video/), kemampuan mengklik tidak akan terbawa karena sifat format tersebut (frame raster/video tidak mendukung hyperlink).