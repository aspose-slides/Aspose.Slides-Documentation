---
title: Teks Matematika
type: docs
weight: 160
url: /id/python-net/examples/elements/math-text/
keywords:
- teks matematika
- tambah teks matematika
- akses teks matematika
- hapus teks matematika
- format teks matematika
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Bekerja dengan teks matematika di Python menggunakan Aspose.Slides: membuat dan mengedit persamaan, pecahan, radikal, skrip, pemformatan, dan merender hasil untuk PPT dan PPTX."
---
Menunjukkan cara bekerja dengan bentuk teks matematika dan memformat persamaan menggunakan **Aspose.Slides for Python via .NET**.

## **Tambah Teks Matematika**

Buat bentuk matematika yang berisi pecahan dan rumus Pythagoras.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tambahkan bentuk Math ke slide.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Akses paragraf matematika.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Tambahkan pecahan sederhana: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Tambahkan persamaan: c² = a² + b².
        math_block = (
            slides.mathtext.MathematicalText("c")
            .set_superscript("2")
            .join("=")
            .join(slides.mathtext.MathematicalText("a").set_superscript("2"))
            .join("+")
            .join(slides.mathtext.MathematicalText("b").set_superscript("2"))
        )
        math_paragraph.add(math_block)

        presentation.save("math_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Teks Matematika**

Temukan bentuk yang berisi paragraf matematika di slide.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Temukan bentuk pertama yang berisi paragraf matematika.
        math_shape = next(
            (
                shape for shape in slide.shapes
                if isinstance(shape, slides.AutoShape)
                and shape.text_frame is not None
                and any(
                    any(isinstance(portion, slides.mathtext.MathPortion) for portion in paragraph.portions)
                    for paragraph in shape.text_frame.paragraphs
                )
            ),
            None
        )
```

## **Hapus Teks Matematika**

Hapus bentuk matematika dari slide.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bentuk pertama adalah bentuk dengan teks matematika.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Format Teks Matematika**

Atur properti font untuk bagian matematika.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan bentuk pertama adalah bentuk dengan teks matematika.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```