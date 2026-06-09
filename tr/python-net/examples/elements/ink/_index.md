---
title: Mürekkep
type: docs
weight: 180
url: /tr/python-net/examples/elements/ink/
keywords:
- mürekkep
- mürekkebe erişim
- mürekkebi kaldır
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python’da slaytlardaki dijital mürekkebi yönetin: kalem darbeleri ekleyin, yolları düzenleyin, renk ve kalınlığı ayarlayın ve sonuçları PowerPoint ve OpenDocument için dışa aktarın."
---
Mevcut mürekkep şekillerine erişme ve bunları **Aspose.Slides for Python via .NET** kullanarak kaldırma örnekleri sağlar.

> ❗ **Not:** Mürekkep şekilleri, özel cihazlardan gelen kullanıcı girdisini temsil eder. Aspose.Slides programlı olarak yeni mürekkep darbeleri oluşturamaz, ancak mevcut mürekkebi okuyabilir ve değiştirebilirsiniz.

## **Mürekkebe Erişim**

Bir slayttan ilk mürekkep şekli alın.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Mürekkebi Kaldır**

Slayttan bir mürekkep şekli silin.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # İlk şeklin bir Ink nesnesi olduğunu varsayarak.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```