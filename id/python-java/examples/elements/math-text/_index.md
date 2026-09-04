---
title: Teks Matematika
type: docs
weight: 160
url: /id/python-java/examples/elements/math-text/
keywords:
- contoh kode
- teks matematika
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Jelajahi contoh teks matematika Aspose.Slides for Python via Java: buat dan format persamaan, pecahan, matriks, serta simbol dalam presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara bekerja dengan bentuk teks matematika dan memformat persamaan menggunakan **Aspose.Slides for Python via Java**.

Instal paket seperti dijelaskan di [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan.

## **Tambah Teks Matematika**

Buat bentuk matematika yang berisi pecahan dan rumus Pythagoras.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan bentuk matematika ke slide.
    math_shape = slide.getShapes().addMathShape(0, 0, 720, 150)

    # Akses paragraf matematika.
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()

    # Tambahkan pecahan sederhana: x / y.
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # Tambahkan persamaan: c² = a² + b².
    math_block = MathematicalText("c").setSuperscript("2").join("=").join(MathematicalText("a").setSuperscript("2")).join("+").join(MathematicalText("b").setSuperscript("2"))
    math_paragraph.add(math_block)
finally:
    presentation.dispose()
```

## **Akses Teks Matematika**

Temukan bentuk yang berisi paragraf matematika pada slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathBlock, MathematicalText, MathPortion, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan bentuk matematika yang dapat ditemukan di bawah.
    created_math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    created_paragraph = created_math_shape.getTextFrame().getParagraphs().get_Item(0)
    created_portion = created_paragraph.getPortions().get_Item(0)
    created_math_paragraph = created_portion.getMathParagraph()
    created_fraction = MathematicalText("x").divide("y")
    created_math_paragraph.add(MathBlock(created_fraction))

    # Temukan bentuk pertama yang berisi paragraf matematika.
    math_shape = None
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                has_math = False
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        if isinstance(portion, MathPortion):
                            has_math = True
                            break
                    if has_math:
                        break
                if has_math:
                    math_shape = shape
                    break

    if math_shape is not None:
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        text_portion = paragraph.getPortions().get_Item(0)
        math_paragraph = text_portion.getMathParagraph()

        # Contoh: buat pecahan (tidak ditambahkan di sini).
        fraction = MathematicalText("x").divide("y")

        # Gunakan math_paragraph atau fraction sesuai kebutuhan.
finally:
    presentation.dispose()
```

## **Hapus Teks Matematika**

Hapus bentuk matematika dari slide.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)

    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # Hapus bentuk matematika.
    slide.getShapes().remove(math_shape)
finally:
    presentation.dispose()
```

## **Format Teks Matematika**

Setel properti font untuk bagian matematika.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    text_portion.getPortionFormat().setFontHeight(20)
finally:
    presentation.dispose()
```