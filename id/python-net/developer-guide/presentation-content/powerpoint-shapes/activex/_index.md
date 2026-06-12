---
title: Kelola Kontrol ActiveX dalam Presentasi dengan Python
linktitle: ActiveX
type: docs
weight: 80
url: /id/python-net/activex/
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
description: "Pelajari cara Aspose.Slides untuk Python via .NET memanfaatkan ActiveX untuk mengotomatiskan dan meningkatkan presentasi PowerPoint, memberikan kontrol kuat kepada pengembang atas slide."
---
## **Pendahuluan**

Kontrol ActiveX digunakan dalam presentasi. Aspose.Slides untuk Python via .NET memungkinkan Anda mengelola kontrol ActiveX, tetapi mengelolanya sedikit lebih rumit dan berbeda dari bentuk presentasi biasa. Mulai Aspose.Slides untuk Python via .NET 6.9.0, komponen ini mendukung pengelolaan kontrol ActiveX. Saat ini, Anda dapat mengakses kontrol ActiveX yang sudah ditambahkan dalam presentasi Anda dan memodifikasi atau menghapusnya dengan menggunakan berbagai propertinya. Ingat, kontrol ActiveX bukan bentuk dan bukan bagian dari IShapeCollection presentasi melainkan IControlCollection terpisah. Artikel ini menunjukkan cara bekerja dengan mereka.

## **Modifikasi Kontrol ActiveX**
Untuk mengelola kontrol ActiveX sederhana seperti kotak teks dan tombol perintah sederhana pada slide:

1. Buat instance dari kelas Presentation dan muat presentasi yang berisi kontrol ActiveX.
2. Dapatkan referensi slide berdasarkan indeksnya.
3. Akses kontrol ActiveX pada slide dengan mengakses IControlCollection.
4. Akses kontrol ActiveX TextBox1 menggunakan objek ControlEx.
5. Ubah berbagai properti kontrol ActiveX TextBox1 termasuk teks, font, tinggi font, dan posisi bingkai.
6. Akses kontrol akses kedua yang disebut CommandButton1.
7. Ubah keterangan tombol, font, dan posisinya.
8. Geser posisi bingkai kontrol ActiveX.
9. Tulis presentasi yang telah dimodifikasi ke file PPTX.

Potongan kode di bawah ini memperbarui kontrol ActiveX pada slide presentasi seperti yang ditunjukkan di bawah.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Mengakses presentasi dengan kontrol ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Mengakses slide pertama dalam presentasi
    slide = presentation.slides[0]

    # mengubah teks TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # mengubah gambar pengganti. PowerPoint akan mengganti gambar ini selama aktivasi ActiveX, jadi kadang-kadang boleh membiarkan gambar tidak berubah.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # mengubah keterangan tombol
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # mengubah pengganti
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # Memindahkan bingkai ActiveX 100 poin ke bawah
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # Simpan presentasi dengan Kontrol ActiveX yang Diedit
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Sekarang menghapus kontrol
    slide.controls.clear()

    # Menyimpan presentasi dengan kontrol ActiveX yang dibersihkan
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Menambahkan Kontrol Media Player ActiveX**
Untuk menambahkan kontrol Media Player ActiveX, silakan lakukan langkah-langkah berikut:

1. Buat instance dari kelas Presentation dan muat contoh presentasi yang berisi kontrol Media Player ActiveX.
2. Buat instance dari kelas Presentation target dan hasilkan instance presentasi kosong.
3. Klon slide yang memiliki kontrol Media Player ActiveX dalam presentasi templat ke Presentation target.
4. Akses slide yang diklon di Presentation target.
5. Akses kontrol ActiveX pada slide dengan mengakses IControlCollection.
6. Akses kontrol Media Player ActiveX dan atur jalur video dengan menggunakan propertinya.
7. Simpan presentasi ke file PPTX.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Membuat instance presentasi kosong
    with slides.Presentation() as newPresentation:

        # Menghapus slide default
        newPresentation.slides.remove_at(0)

        # Menggandakan slide dengan Kontrol Media Player ActiveX
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Mengakses kontrol Media Player ActiveX dan mengatur jalur video
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Simpan Presentasi
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah Aspose.Slides mempertahankan kontrol ActiveX saat membaca dan menyimpan kembali jika kontrol tersebut tidak dapat dijalankan di runtime Python?**

Ya. Aspose.Slides memperlakukan mereka sebagai bagian dari presentasi dan dapat membaca/memodifikasi properti serta bingkai mereka; mengeksekusi kontrol itu sendiri tidak diperlukan untuk mempertahankannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE dalam sebuah presentasi?**

Kontrol ActiveX adalah kontrol terkelola interaktif (tombol, kotak teks, pemutar media), sedangkan [OLE](/slides/id/python-net/manage-ole/) merujuk pada objek aplikasi yang disematkan (misalnya, lembar kerja Excel). Mereka disimpan dan diproses secara berbeda serta memiliki model properti yang berbeda.

**Apakah peristiwa ActiveX dan makro VBA berfungsi jika file telah dimodifikasi oleh Aspose.Slides?**

Aspose.Slides mempertahankan markup dan metadata yang ada; namun, peristiwa dan makro hanya berjalan di dalam PowerPoint pada Windows ketika keamanan mengizinkannya. Perpustakaan ini tidak mengeksekusi VBA.