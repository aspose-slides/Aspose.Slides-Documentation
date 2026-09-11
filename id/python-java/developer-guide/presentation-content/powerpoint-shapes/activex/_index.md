---
title: Kelola Kontrol ActiveX dalam Presentasi Menggunakan Python
linktitle: ActiveX
type: docs
weight: 80
url: /id/python-java/activex/
keywords:
- ActiveX
- kontrol ActiveX
- mengelola ActiveX
- menambahkan ActiveX
- memodifikasi ActiveX
- pemutar media
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari bagaimana Aspose.Slides for Python via Java menggunakan ActiveX untuk mengotomatiskan dan meningkatkan presentasi PowerPoint, memberikan pengembang kontrol yang kuat atas slide."
---
## **Pendahuluan**

Kontrol ActiveX digunakan dalam presentasi. Aspose.Slides for Python via Java memungkinkan Anda menambahkan dan mengelola kontrol ActiveX, tetapi kontrol ini sedikit lebih sulit dikelola dibandingkan dengan bentuk bawaan presentasi. Aspose.Slides mendukung penambahan kontrol ActiveX Media Player. Perhatikan bahwa kontrol ActiveX bukanlah shape; mereka tidak termasuk dalam presentasi's [ShapeCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/). Mereka merupakan bagian dari [ControlCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/controlcollection/) terpisah. Pada topik ini, kami akan menunjukkan cara bekerja dengan mereka.

## **Menambahkan Kontrol ActiveX Media Player ke Slide**

Untuk menambahkan kontrol Media Player ActiveX, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan hasilkan sebuah presentasi kosong.
1. Akses slide target dalam [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Tambahkan kontrol Media Player ActiveX menggunakan metode [addControl](https://reference.aspose.com/slides/id/python-java/aspose.slides/controlcollection/#addControl) yang disediakan oleh [ControlCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/controlcollection/).
1. Akses kontrol Media Player ActiveX dan tetapkan jalur video dengan menggunakan propertinya.
1. Simpan presentasi sebagai file PPTX.

Contoh kode ini, berdasarkan langkah-langkah di atas, menunjukkan cara menambahkan kontrol ActiveX Media Player ke slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Buat presentasi kosong.
presentation = Presentation()
try:
    # Tambahkan kontrol ActiveX Media Player.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Tetapkan jalur video.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Simpan presentasi.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Memodifikasi Kontrol ActiveX**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java menyediakan komponen untuk mengelola kontrol ActiveX. Anda dapat mengakses kontrol ActiveX yang sudah ditambahkan dalam presentasi Anda dan memodifikasi atau menghapusnya melalui propertinya.

{{% /alert %}}

Untuk mengelola kontrol ActiveX sederhana seperti kotak teks dan tombol perintah sederhana pada slide, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang berisi kontrol ActiveX.
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Akses kontrol ActiveX dalam slide dengan mengakses [ControlCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/controlcollection/).
1. Akses kontrol ActiveX TextBox1 menggunakan objek [Control](https://reference.aspose.com/slides/id/python-java/aspose.slides/control/).
1. Ubah properti kontrol ActiveX TextBox1 yang mencakup teks, font, tinggi font, dan posisi frame.
1. Akses kontrol ActiveX kedua yang disebut CommandButton1.
1. Ubah caption tombol, font, dan posisinya.
1. Geser posisi frame kontrol ActiveX.
1. Tuliskan presentasi yang telah dimodifikasi ke file PPTM.

Contoh kode ini, berdasarkan langkah-langkah di atas, menunjukkan cara mengelola kontrol ActiveX sederhana:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# Muat presentasi dengan kontrol ActiveX.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Akses slide pertama.
        slide = presentation.getSlides().get_Item(0)

        # Ubah teks kotak teks.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Ubah gambar pengganti. PowerPoint menggantinya selama aktivasi ActiveX,
            # sehingga terkadang dapat dibiarkan tidak berubah.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Ubah caption tombol.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Ubah gambar pengganti.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Pindahkan kontrol ke bawah sebanyak 100 poin.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Hapus kontrol.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah Aspose.Slides mempertahankan kontrol ActiveX saat membaca dan menyimpan kembali jika kontrol tersebut tidak dapat dijalankan di runtime Python?**

Ya. Aspose.Slides memperlakukan mereka sebagai bagian dari presentasi dan dapat membaca/mengubah properti serta frame mereka; mengeksekusi kontrol itu sendiri tidak diperlukan untuk mempertahankannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE dalam presentasi?**

Kontrol ActiveX adalah kontrol interaktif yang dikelola (tombol, kotak teks, pemutar media), sedangkan [OLE](/slides/id/python-java/manage-ole/) merujuk pada objek aplikasi tersemat (misalnya, lembar kerja Excel). Mereka disimpan dan diproses secara berbeda serta memiliki model properti yang berbeda.

**Apakah event ActiveX dan makro VBA berfungsi jika file telah dimodifikasi oleh Aspose.Slides?**

Aspose.Slides mempertahankan markup dan metadata yang ada; namun, event dan makro hanya berjalan di dalam PowerPoint pada Windows ketika keamanan mengizinkannya. Perpustakaan ini tidak mengeksekusi VBA.