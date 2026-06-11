---
title: Bläck
type: docs
weight: 180
url: /sv/python-net/examples/elements/ink/
keywords:
- bläck
- åtkomst till bläck
- ta bort bläck
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Hantera digitalt bläck på bilder i Python med Aspose.Slides: lägg till pennstreck, redigera banor, ange färg och bredd samt exportera resultatet för PowerPoint och OpenDocument."
---
Tillhandahåller exempel på hur man får åtkomst till befintliga bläckformer och tar bort dem med **Aspose.Slides for Python via .NET**.

> ❗ **Obs!** Bläckformer representerar användarinmatning från specialiserade enheter. Aspose.Slides kan inte skapa nya bläckstift programmässigt, men du kan läsa och ändra befintligt bläck.

## **Åtkomst till bläck**

Hämta den första bläckformen från en bild.

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

## **Ta bort bläck**

Ta bort en bläckform från bilden.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Förutsatt att den första formen är ett Ink-objekt.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```