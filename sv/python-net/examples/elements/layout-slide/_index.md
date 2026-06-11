---
title: Layoutbild
type: docs
weight: 20
url: /sv/python-net/examples/elements/layout-slide/
keywords:
- layoutbild
- lägg till layoutbild
- åtkomst till layoutbild
- ta bort layoutbild
- oanvänd layoutbild
- klona layoutbild
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Använd Python för att hantera layoutbilder med Aspose.Slides: skapa, tillämpa, klona, byta namn på och anpassa platshållare och teman i presentationer för PPT, PPTX och ODP."
---
Det här artikeln visar hur man arbetar med **Layout Slides** i Aspose.Slides för Python via .NET. Ett layout‑bild definierar designen och formateringen som ärvs av vanliga bilder. Du kan lägga till, komma åt, klona och ta bort layout‑bilder, samt rensa bort oanvända för att minska presentationens storlek.

## **Lägg till en layout‑bild**

Du kan skapa en anpassad layout‑bild för att definiera återanvändbar formatering.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Skapa en layoutbild med den angivna typen och namnet.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tips 1:** Layout‑bilder fungerar som mallar för individuella bilder. Du kan definiera gemensamma element en gång och återanvända dem i många bilder.

> 💡 **Tips 2:** När du lägger till former eller text i en layout‑bild kommer alla bilder som bygger på den layouten automatiskt att visa detta delade innehåll.  
> Skärmbilden nedan visar två bilder, som vardera ärver en textruta från samma layout‑bild.

![Bilder som ärver layout‑innehåll](layout-slide-result.png)

## **Komma åt en layout‑bild**

Layout‑bilder kan nås via index eller via layout‑typ (t.ex. `Blank`, `Title`, `SectionHeader` osv.).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Åtkomst via index.
        first_layout_slide = presentation.layout_slides[0]

        # Åtkomst via layouttyp.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Ta bort en layout‑bild**

Du kan ta bort en specifik layout‑bild om den inte längre behövs.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Hämta en layoutbild efter typ och ta bort den.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort oanvända layout‑bilder**

För att minska presentationens storlek kan du vilja ta bort layout‑bilder som inte används av några vanliga bilder.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Tar automatiskt bort alla layoutbilder som inte refereras av någon bild.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona en layout‑bild**

Du kan duplicera en layout‑bild med metoden `AddClone`.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Hämta en befintlig layoutbild efter typ.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Klona layoutbilden till slutet av samlingen av layoutbilder.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Sammanfattning:** Layout‑bilder är kraftfulla verktyg för att hantera enhetlig formatering över bilder. Aspose.Slides ger full kontroll över att skapa, hantera och optimera layout‑bilder.