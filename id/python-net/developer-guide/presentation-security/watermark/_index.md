---
title: Menambahkan Watermark ke Presentasi dengan Python
linktitle: Watermark
type: docs
weight: 40
url: /id/python-net/watermark/
keywords:
- watermark
- watermark teks
- watermark gambar
- menambahkan watermark
- mengubah watermark
- menghapus watermark
- menghapus watermark
- menambahkan watermark ke PPT
- menambahkan watermark ke PPTX
- menambahkan watermark ke ODP
- menghapus watermark dari PPT
- menghapus watermark dari PPTX
- menghapus watermark dari ODP
- menghapus watermark dari PPT
- menghapus watermark dari PPTX
- menghapus watermark dari ODP
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengelola watermark teks dan gambar dalam presentasi PowerPoint dan OpenDocument menggunakan Python untuk menandai draft, informasi rahasia, hak cipta, dan lainnya."
---
## **Introduction**

**Watermark** dalam sebuah presentasi adalah stempel teks atau gambar yang digunakan pada satu slide atau pada semua slide presentasi. Biasanya, watermark digunakan untuk menunjukkan bahwa presentasi tersebut masih draft (misalnya watermark “Draft”), berisi informasi rahasia (misalnya watermark “Confidential”), menandakan perusahaan yang bersangkutan (misalnya watermark “Company Name”), mengidentifikasi penulis presentasi, dll. Watermark membantu mencegah pelanggaran hak cipta dengan menunjukkan bahwa presentasi tidak boleh disalin. Watermark digunakan dalam format presentasi PowerPoint maupun OpenOffice. Pada Aspose.Slides, Anda dapat menambahkan watermark ke format file PowerPoint PPT, PPTX, dan OpenOffice ODP.

Di [**Aspose.Slides**](https://products.aspose.com/slides/id/python-net/), ada berbagai cara untuk membuat watermark di dokumen PowerPoint atau OpenOffice dan memodifikasi desain serta perilakunya. Kesamaan umumnya adalah untuk menambahkan watermark teks, Anda harus menggunakan kelas [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/), dan untuk menambahkan watermark gambar, gunakan kelas [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) atau mengisi bentuk watermark dengan gambar. `PictureFrame` mengimplementasikan kelas [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/), memungkinkan Anda menggunakan semua pengaturan fleksibel dari objek shape. Karena `TextFrame` bukan shape dan pengaturannya terbatas, ia dibungkus ke dalam objek [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/).

Ada dua cara penerapan watermark: pada satu slide atau pada semua slide presentasi. Slide Master digunakan untuk menerapkan watermark ke semua slide presentasi — watermark ditambahkan ke Slide Master, didesain sepenuhnya di sana, dan diterapkan ke semua slide tanpa mempengaruhi izin mengedit watermark pada slide individual.

Watermark biasanya dianggap tidak dapat diedit oleh pengguna lain. Untuk mencegah watermark (atau lebih tepatnya shape induk watermark) agar tidak diedit, Aspose.Slides menyediakan fungsi penguncian shape. Sebuah shape tertentu dapat dikunci pada slide biasa atau pada Slide Master. Ketika shape watermark dikunci pada Slide Master, ia akan terkunci pada semua slide presentasi.

Anda dapat menetapkan nama untuk watermark sehingga di masa depan, jika ingin menghapusnya, Anda dapat menemukannya di shape slide berdasarkan nama.

Anda dapat mendesain watermark dengan cara apa pun; namun biasanya terdapat fitur umum pada watermark, seperti penyelarasan tengah, rotasi, posisi di depan, dll. Kami akan membahas cara menggunakan hal tersebut dalam contoh di bawah.

## **Text Watermark**

### **Add a Text Watermark to a Slide**

Untuk menambahkan watermark teks pada PPT, PPTX, atau ODP, pertama-tama tambahkan sebuah shape ke slide, lalu tambahkan sebuah text frame ke shape tersebut. Text frame direpresentasikan oleh kelas [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/). Tipe ini tidak diwarisi dari [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/), yang memiliki banyak properti untuk memposisikan watermark secara fleksibel. Oleh karena itu, objek [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) dibungkus dalam objek [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/). Untuk menambahkan teks watermark ke shape, gunakan metode [add_text_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/add_text_frame/#str) seperti contoh di bawah.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/id/python-net/text-formatting/)
{{% /alert %}}

### **Add a Text Watermark to a Presentation**

Jika Anda ingin menambahkan watermark teks ke seluruh presentasi (yaitu semua slide sekaligus), tambahkan ke [MasterSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslide/). Logika selanjutnya sama seperti menambahkan watermark ke satu slide — buat objek [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) kemudian tambahkan watermark ke dalamnya menggunakan metode [add_text_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/id/python-net/slide-master/)
{{% /alert %}}

### **Set Watermark Shape Transparency**

Secara default, shape persegi panjang memiliki warna isian dan garis. Baris kode berikut menjadikan shape tersebut transparan.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Set the Font for a Text Watermark**

Anda dapat mengubah font watermark teks seperti berikut.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Set the Watermark Text Color**

Untuk mengatur warna teks watermark, gunakan kode berikut:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Center a Text Watermark**

Anda dapat memusatkan watermark pada slide dengan melakukan hal berikut:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

Gambar di bawah menunjukkan hasil akhirnya.

![The text watermark](text_watermark.png)

## **Image Watermark**

### **Add an Image Watermark to a Presentation**

Untuk menambahkan watermark gambar ke slide presentasi, Anda dapat melakukan hal berikut:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Lock a Watermark from Editing**

Jika perlu mencegah watermark diedit, gunakan properti [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/auto_shape_lock/) pada shape. Dengan properti ini, Anda dapat melindungi shape dari pemilihan, pengubahan ukuran, pemindahan posisi, pengelompokan dengan elemen lain, mengunci teksnya dari pengeditan, dan masih banyak lagi:

```py
# Kunci shape watermark agar tidak dapat diubah
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Bring a Watermark to Front**

Di Aspose.Slides, urutan Z shape dapat diatur melalui metode [ShapeCollection.reorder](https://reference.aspose.com/slides/id/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Untuk melakukannya, panggil metode ini dari daftar slide presentasi dan berikan referensi shape serta nomor urutnya ke metode tersebut. Dengan cara ini, shape dapat dibawa ke depan atau dikirim ke belakang slide. Fitur ini sangat berguna jika Anda perlu menempatkan watermark di depan presentasi:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Set Watermark Rotation**

Berikut contoh kode cara mengatur rotasi watermark sehingga posisinya diagonal melintasi slide:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Set a Name for a Watermark**

Aspose.Slides memungkinkan Anda memberikan nama pada sebuah shape. Dengan menggunakan nama shape, Anda dapat mengaksesnya di masa depan untuk memodifikasi atau menghapusnya. Untuk menetapkan nama pada shape watermark, tetapkan ke properti [AutoShape.name](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **Remove a Watermark**

Untuk menghapus shape watermark, gunakan metode [AutoShape.name](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/name/) untuk menemukannya di shape slide. Kemudian, berikan shape watermark tersebut ke metode [ShapeCollection.remove](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **A Live Example**

Anda mungkin ingin mencoba **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/id/watermark) dan [Remove Watermark](https://products.aspose.app/slides/id/watermark/remove-watermark) secara online.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**What is a watermark and why should I use it?**

Watermark adalah overlay teks atau gambar yang diterapkan pada slide untuk membantu melindungi hak kekayaan intelektual, meningkatkan pengenalan merek, atau mencegah penggunaan tidak sah dari presentasi.

**Can I add a watermark to all slides in a presentation?**

Ya, Aspose.Slides memungkinkan Anda menambahkan watermark ke setiap slide dalam sebuah presentasi. Anda dapat melakukan iterasi pada semua slide dan menerapkan pengaturan watermark secara individual.

**How can I adjust the transparency of the watermark?**

Anda dapat menyesuaikan transparansi watermark dengan mengubah pengaturan isian ([FillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/fillformat/)) dari shape. Ini memastikan watermark tetap halus dan tidak mengganggu konten slide.

**What image formats are supported for watermarks?**

Aspose.Slides mendukung berbagai format gambar seperti PNG, JPEG, GIF, BMP, SVG, dan lainnya.

**Can I customize the font and style of a text watermark?**

Ya, Anda dapat memilih font, ukuran, dan gaya apa pun untuk menyesuaikan desain presentasi Anda dan menjaga konsistensi merek.

**How do I change the position or orientation of a watermark?**

Anda dapat menyesuaikan posisi dan orientasi watermark dengan mengubah koordinat, ukuran, dan properti rotasi [shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/).