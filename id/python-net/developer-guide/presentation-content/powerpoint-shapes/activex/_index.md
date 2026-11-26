---
title: "Kelola Kontrol ActiveX dalam Presentasi dengan Python"
linktitle: "ActiveX"
type: docs
weight: 80
url: /id/python-net/activex/
keywords:
- ActiveX
- kontrol ActiveX
- kelola ActiveX
- tambahkan ActiveX
- modifikasi ActiveX
- pemutar media
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Edit kotak teks dan tombol ActiveX, perbarui preview kontrol, dan gunakan kembali kontrol Windows Media Player dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via .NET."
---
## **Pendahuluan**

Kontrol ActiveX memberikan elemen interaktif pada slide PowerPoint seperti kotak teks, tombol perintah, dan pemutar media. Aspose.Slides untuk Python via .NET menampilkan kontrol slide melalui [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). Gunakan koleksi ini untuk mengedit kontrol, memindahkannya pada slide, atau menghapusnya.

## **Daftar Kontrol ActiveX dan Properti yang Disimpan**

Untuk memeriksa templat yang tidak dikenal, buka untuk dibaca dan iterasikan melalui kontrol pada setiap slide. Contoh melaporkan nomor slide, nama kontrol, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), dan setiap pasangan kunci-nilai dalam [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). Ia membaca presentasi tanpa mengaktifkan kontrol, memanggil event atau makro, mengubah nilai, atau menyimpan file.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

Output yang dipilih dari `ActiveX.pptm` menunjukkan sebuah kotak teks dan sebuah tombol perintah.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Koleksi properti kosong muncul sebagai `[]`. Untuk kontrol yang menggunakan penyimpanan biner, `properties` dapat mengembalikan `None`, yang ditampilkan sebagai `Properties unavailable`. Jika Anda hanya membutuhkan nama, gunakan [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) setelah memeriksa apakah bernilai `None`. Laporan mencantumkan properti yang tersedia dari presentasi. Sebuah kontrol dapat mendukung properti tambahan pada waktu berjalan.

## **Ubah Kontrol ActiveX**

Contoh mengharapkan presentasi yang mendukung makro dengan kotak teks bernama `TextBox1` dan tombol perintah bernama `CommandButton1` pada slide pertama. Ia menggunakan [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) untuk mengubah nilai kotak teks dan judul tombol. Setiap kontrol juga memiliki pratinjau statis yang dapat ditampilkan PowerPoint sebelum aktivasi. Sediakan PNG untuk setiap kontrol yang menunjukkan teks dan tampilan yang diperbarui. Contoh menetapkan gambar ini melalui [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

Contoh memindahkan setiap kontrol pada slide pertama ke bawah sebesar 100 poin dengan mengubah [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). Ia menyimpan presentasi yang diedit dalam format PPTM, lalu menggunakan [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) untuk menyimpan salinan kedua dengan semua kontrol ActiveX dihapus dari slide tersebut.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **Tambahkan Kontrol Media Player ActiveX**

Untuk menggunakan kembali kontrol Windows Media Player yang telah dikonfigurasi, mulai dengan templat yang slide pertamanya berisi pemutar bernama `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) menyalin seluruh slide ke presentasi baru. Contoh mengatur `URL` pemutar dalam [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) dan menyimpan slide yang dikloning sebagai satu-satunya slide dalam keluaran. Video tetap eksternal, jadi pilih jalur yang dapat diakses pemutar selama pemutaran.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah Aspose.Slides dapat mempertahankan kontrol ActiveX tanpa menjalankannya?**

Ya. Aspose.Slides dapat membaca dan menyimpan kontrol, termasuk properti dan posisinya, tanpa mengaktifkannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE?**

Kontrol ActiveX memungkinkan pengguna berinteraksi dengan slide, misalnya dengan memasukkan teks atau mengklik tombol. Sebuah [OLE object](/slides/id/python-net/manage-ole/) memungkinkan slide berisi atau menautkan ke konten yang dikelola oleh aplikasi lain, seperti lembar kerja Excel.

**Apakah peristiwa ActiveX masih akan memicu makro VBA setelah saya menyimpan presentasi dengan Aspose.Slides?**

Simpan presentasi dalam format yang mendukung makro seperti PPTM untuk mempertahankan proyek VBA-nya. PowerPoint untuk Windows dapat menjalankan penangan peristiwa yang ada ketika pengaturan keamanannya mengizinkan baik kontrol ActiveX maupun makro.