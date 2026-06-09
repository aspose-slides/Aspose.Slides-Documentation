---
title: MatematikMetni
type: docs
weight: 160
url: /tr/python-net/examples/elements/math-text/
keywords:
- matematik metni
- matematik metni ekle
- matematik metnine eriş
- matematik metni kaldır
- matematik metni biçimlendir
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python’da matematik metniyle çalışın: denklemler, kesirler, kök ifadeler, üst/alt karakterler, biçimlendirme oluşturun ve düzenleyin ve sonuçları PPT ve PPTX için işleyin."
---
Matematik metin şekilleriyle çalışmayı ve denklemleri biçimlendirmeyi **Aspose.Slides for Python via .NET** kullanarak gösterir.

## **Matematik Metni Ekle**

Bir kesir ve Pisagor formülünü içeren bir matematik şekli oluşturun.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Slayta bir Matematik şekli ekle.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Matematik paragrafına eriş.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Basit bir kesir ekle: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Denklem ekle: c² = a² + b².
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

## **Matematik Metnine Eriş**

Slaytta bir matematik paragrafı içeren bir şekli bulun.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk math paragrafı içeren şekli bul.
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

## **Matematik Metnini Kaldır**

Slayttan bir matematik şekli silin.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin matematik metni içeren bir şekil olduğunu varsayıyoruz.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Matematik Metnini Biçimlendir**

Bir matematik bölümünün yazı tipi özelliklerini ayarlayın.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin matematik metni içeren bir şekil olduğunu varsayıyoruz.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```