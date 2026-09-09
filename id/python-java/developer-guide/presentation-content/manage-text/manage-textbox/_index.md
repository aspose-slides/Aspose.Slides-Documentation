---
title: Kelola Kotak Teks dalam Presentasi Menggunakan Python via Java
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/python-java/manage-textbox/
keywords:
- kotak teks
- frame teks
- tambahkan teks
- perbarui teks
- buat kotak teks
- periksa kotak teks
- tambahkan kolom teks
- tambahkan tautan
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat, identifikasi, format, dan perbarui kotak teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via Java."
---
## **Pendahuluan**

In Aspose.Slides untuk Python via Java, teks slide disimpan dalam frame teks yang merupakan bagian dari shapes. Kelas [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) mewakili shape paling umum yang memuat teks dan menampilkan teksnya melalui metode [AutoShape.getTextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}

Setiap auto shape mewarisi dari [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/), tetapi tidak semua shape adalah auto shape atau mendukung frame teks. Saat memproses presentasi yang ada, periksa bahwa sebuah shape merupakan instance dari [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) sebelum mengakses teksnya.

{{% /alert %}}

## **Buat Kotak Teks di Slide**

Untuk membuat kotak teks, tambahkan auto shape ke slide, tambahkan teks ke frame teksnya, dan simpan presentasi. Contoh berikut membuat kotak teks persegi panjang:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Koordinat dan dimensi yang diberikan ke [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addAutoShape) diukur dalam poin. [AutoShape.addTextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/#addTextFrame) menginisialisasi frame teks dengan teks yang diberikan.

## **Periksa Bentuk Kotak Teks**

Gunakan metode [AutoShape.isTextBox](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/#isTextBox) untuk menentukan apakah sebuah auto shape dianggap sebagai kotak teks. Ini berguna ketika sebuah presentasi berisi baik auto shape yang memuat teks maupun yang hanya grafis.

![A text box and a shape](istextbox.png)

Contoh berikut memeriksa setiap auto shape dalam sebuah presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Auto shape yang baru ditambahkan tidak dianggap sebagai kotak teks sampai ia berisi teks yang tidak kosong. Anda dapat menyediakan teks tersebut melalui [AutoShape.addTextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/#addTextFrame) atau [TextFrame.setText](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#setText). Menambahkan atau menetapkan string kosong menyebabkan [AutoShape.isTextBox](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/#isTextBox) mengembalikan `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

Pemanggilan dua pertama mencetak `True`; dua terakhir mencetak `False`.

## **Temukan Shape yang Memiliki Text Frame**

Kode pemrosesan teks generik dapat menerima sebuah [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) tanpa mengetahui objek presentasi mana yang memilikinya. Gunakan metode read‑only [TextFrame.getParentShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getParentShape) untuk menavigasi kembali ke Shape pemiliknya.

Untuk sebuah text frame yang dimiliki oleh auto shape atau shape lain yang memuat teks, [TextFrame.getParentShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getParentShape) mengembalikan pemiliknya dan [TextFrame.getParentCell](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getParentCell) mengembalikan `None`. Periksa nilai yang dikembalikan sebelum mengaksesnya. Untuk mengidentifikasi baik pemilik shape maupun sel tabel, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/python-java/search-and-replace-text/).

## **Tambahkan Kolom ke Kotak Teks**

Metode [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setColumnCount) membagi frame teks menjadi kolom, sementara [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setColumnSpacing) mengatur jarak antar kolom dalam poin. Kedua pengaturan tersebut merupakan bagian dari [TextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/) dan dapat diubah melalui frame teks dari kotak teks yang ada. Teks mengalir kembali antar kolom di dalam shape yang sama; tidak berlanjut ke shape lain.

Contoh berikut membuat kotak teks tiga kolom dengan jarak 10 poin antar kolom, menyimpan presentasi, dan membaca pengaturan yang disimpan kembali dari file output:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Ekstrak Teks dari Setiap Kolom**

Gunakan [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#splitTextByColumns) untuk mengambil teks yang diberikan ke setiap kolom visual dalam sebuah text frame yang ada. Metode ini mengembalikan satu string untuk setiap kolom, dalam urutan baca berbasis kolom. Text frame satu kolom menghasilkan array dengan satu elemen, dan kolom kosong direpresentasikan dengan string kosong. String tersebut hanya berisi teks biasa; format tingkat bagian tidak dipertahankan.

Ini berguna ketika Anda perlu:

- Mengekstrak teks sambil mempertahankan urutan baca berbasis kolom.
- Mengindeks atau membandingkan konten slide multi‑kolom.
- Mengekspor setiap kolom ke file terpisah, field basis data, atau tujuan lain.
- Memeriksa bagaimana teks didistribusikan kembali setelah mengubah jumlah kolom dengan [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setColumnCount), jarak dengan [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setColumnSpacing), font, atau ukuran text‑frame.

Metode ini melaporkan teks yang didistribusikan dalam TextFrame saat ini; tidak secara otomatis mengalirkan teks antar shape atau kotak teks terpisah. Distribusi kolom dapat bergantung pada font yang tersedia dan pengaturan tata letak teks lainnya, jadi pastikan font yang diperlukan tersedia ketika hasil yang konsisten penting.

Contoh berikut memuat sebuah presentasi, menemukan auto shape multi‑kolom pertama dengan text frame, membaca jumlah kolom yang dikonfigurasikan, dan menulis teks dari setiap kolom ke file terpisah. Shape yang tidak menyediakan text frame akan dilewati.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Perbarui Teks**

Untuk memperbarui teks di seluruh presentasi, iterasikan slide dan shape, pilih auto shape, kemudian edit bagian teksnya. Bekerja pada tingkat bagian memungkinkan Anda mengubah teks serta format karakternya.

Contoh berikut menggantikan setiap kemunculan `years` dengan `months` dalam teks auto‑shape dan membuat setiap bagian yang terpengaruh menjadi tebal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Traversing ini memperbarui teks hanya dalam auto shape. Teks yang disimpan dalam tabel, diagram, SmartArt, atau shape yang digabungkan memerlukan traversal koleksi masing‑masing objek tersebut.

## **Tambahkan Kotak Teks dengan Tautan**

Tautan dapat ditetapkan ke bagian teks tertentu, sehingga hanya teks tersebut yang berfungsi sebagai tautan yang dapat diklik. Gunakan [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) untuk mengaitkan bagian tersebut dengan URL eksternal.

Contoh berikut membuat teks bertautan dan menyimpannya ke dalam presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks pada slide master atau layout?**

Sebuah [placeholder](/slides/id/python-java/manage-placeholder/) dapat mewarisi posisi dan formatnya dari sebuah [master slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/) atau [layout slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/). Kotak teks biasa adalah shape independen pada slide tempat ia dibuat dan tidak memperoleh perilaku placeholder ketika layout berubah.

**Bagaimana saya dapat mengganti teks tanpa mengubah teks di chart, tabel, atau SmartArt?**

Batasi traversal hanya pada shape yang merupakan instance dari [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/), seperti yang ditunjukkan dalam contoh Perbarui Teks. Chart, tabel, dan SmartArt menyimpan teks dalam model objek mereka masing‑masing, sehingga tidak dimodifikasi oleh loop tersebut.