---
title: "Kelola Kontrol ActiveX dalam Presentasi Menggunakan Python"
linktitle: "ActiveX"
type: docs
weight: 80
url: /id/python-java/activex/
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
description: "Edit kotak teks dan tombol ActiveX, perbarui pratinjau kontrol, dan gunakan kembali kontrol Windows Media Player dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via Java."
---
## **Introduction**

ActiveX controls memberikan elemen interaktif pada slide PowerPoint seperti kotak teks, tombol perintah, dan pemutar media. Aspose.Slides untuk Python via Java mengekspor kontrol slide melalui [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Gunakan koleksi ini untuk mengedit kontrol, memindahkannya pada slide, atau menghapusnya.

## **List ActiveX Controls and Their Stored Properties**

Untuk memeriksa templat yang tidak dikenal, buka untuk dibaca dan iterasi melalui kontrol pada tiap slide. Contoh melaporkan nomor slide, nama kontrol, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId), dan setiap pasangan kunci-nilai dalam [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). Ia membaca presentasi tanpa mengaktifkan kontrol, memanggil event atau makro, mengubah nilai, atau menyimpan file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

Output terpilih dari `ActiveX.pptm` menunjukkan kotak teks dan tombol perintah.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Koleksi properti kosong muncul sebagai `[]`. Untuk kontrol yang menggunakan penyimpanan biner, [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) dapat mengembalikan `None`, yang ditampilkan sebagai `Properties unavailable`. Jika Anda hanya memerlukan nama-nama, gunakan [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) setelah memeriksa bahwa koleksi tersedia. Laporan mencantumkan properti yang tersedia dari presentasi. Sebuah kontrol mungkin mendukung properti tambahan pada runtime.

## **Modify ActiveX Controls**

Contoh mengharapkan presentasi yang mendukung makro dengan kotak teks bernama `TextBox1` dan tombol perintah bernama `CommandButton1` pada slide pertama. Ia menggunakan [koleksi properti kontrol](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) untuk mengubah nilai kotak teks dan caption tombol. Setiap kontrol juga memiliki pratinjau statis yang dapat ditampilkan PowerPoint sebelum aktivasi. Sediakan file PNG untuk setiap kontrol yang menunjukkan teks dan tampilan yang telah diperbarui. Contoh menetapkan gambar ini melalui [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

Contoh memindahkan setiap kontrol pada slide pertama ke bawah sebesar 100 poin dengan mengatur frame-nya menggunakan [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). Ia menyimpan presentasi yang telah diedit dalam format PPTM, kemudian menggunakan [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) untuk menyimpan salinan kedua dengan semua kontrol ActiveX dihapus dari slide tersebut.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **Add an ActiveX Media Player Control**

Untuk menggunakan kembali kontrol Windows Media Player yang sudah dikonfigurasi, mulailah dengan templat yang slide pertamanya berisi pemutar bernama `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) menyalin seluruh slide ke dalam presentasi baru. Contoh mengatur `URL` pemutar dalam [koleksi properti](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) dan menyimpan slide yang di‑kloning sebagai satu‑satunya slide dalam output. Video tetap eksternal, sehingga pilih jalur yang dapat diakses pemutar selama pemutaran.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **FAQ**

**Apakah Aspose.Slides dapat mempertahankan kontrol ActiveX tanpa menjalankannya?**

Ya. Aspose.Slides dapat membaca dan menyimpan kontrol, termasuk properti dan posisinya, tanpa mengaktifkannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE?**

Kontrol ActiveX memungkinkan pengguna berinteraksi dengan slide, misalnya dengan memasukkan teks atau mengklik tombol. Sebuah [OLE object](/slides/id/python-java/manage-ole/) memungkinkan slide berisi atau menautkan ke konten yang dikelola oleh **aplikasi** lain, seperti lembar kerja **Excel**.

**Apakah peristiwa ActiveX masih akan memicu makro VBA setelah saya menyimpan presentasi dengan Aspose.Slides?**

Simpan presentasi dalam format yang mendukung makro seperti PPTM untuk mempertahankan proyek VBA-nya. PowerPoint untuk Windows dapat menjalankan penangan peristiwa yang ada bila pengaturan keamanannya memperbolehkan baik kontrol ActiveX maupun makro.