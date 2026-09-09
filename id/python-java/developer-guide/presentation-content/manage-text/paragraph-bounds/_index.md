---
title: Dapatkan Batas Paragraf dari Presentasi di Python via Java
linktitle: Batas Paragraf
type: docs
weight: 43
url: /id/python-java/paragraph-bounds/
keywords:
- batas paragraf
- koordinat paragraf
- ukuran paragraf
- bingkai teks
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf di Aspose.Slides untuk Python via Java untuk mengoptimalkan posisi teks dalam presentasi PowerPoint."
---
## **Overview**

Artikel ini menjelaskan cara memperoleh batas, ukuran, dan koordinat paragraf di Aspose.Slides. Artikel ini menunjukkan cara mengambil persegi panjang paragraf dari sebuah TextFrame dengan menggunakan Paragraph.getRect, cara mendapatkan koordinat paragraf di dalam kotak teks sel tabel, serta menyoroti detail penting seperti satuan pengukuran, pengaruh pembungkusan teks terhadap batas, konversi piksel, dan nilai format paragraf yang efektif.

## **Dapatkan Koordinat Persegi Panjang dari Sebuah Paragraf**

Gunakan Paragraph.getRect untuk mendapatkan persegi panjang pembatas sebuah paragraf.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **Dapatkan Ukuran Paragraf di Dalam Kotak Teks Sel Tabel**

Untuk mendapatkan ukuran dan koordinat sebuah Paragraph di dalam kotak teks sel tabel, gunakan Paragraph.getRect. Persegi panjang yang dikembalikan bersifat relatif terhadap kotak teks sel tabel, sehingga tambahkan posisi tabel dan offset sel ketika Anda memerlukan koordinat pada tingkat slide.

Contoh berikut mendapatkan batas paragraf di dalam sel tabel dan menggambar persegi panjang pada slide untuk memvisualisasikan batas tersebut:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Dalam satuan apa koordinat paragraf diukur?**

Koordinat tersebut diukur dalam poin, di mana 1 inci sama dengan 72 poin. Ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkusan kata memengaruhi batas paragraf?**

Ya. Jika TextFrameFormat.setWrapText diaktifkan untuk TextFrame, teks akan dipotong agar sesuai dengan lebar area, yang mengubah batas aktual paragraf.

**Dapatkah koordinat paragraf dipetakan secara andal ke piksel dalam gambar yang diekspor?**

Ya. Konversikan poin ke piksel menggunakan rumus berikut: piksel = poin × (DPI / 72). Hasilnya bergantung pada DPI yang dipilih untuk rendering atau ekspor.

**Bagaimana cara saya mendapatkan parameter format paragraf "efektif", dengan memperhitungkan pewarisan gaya?**

Gunakan [struktur data format paragraf efektif](/slides/id/python-java/shape-effective-properties/); ia mengembalikan nilai akhir yang terintegrasi untuk indentasi, spasi, pembungkusan, RTL, dan lainnya.