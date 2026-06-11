---
title: Grupppresentationformer med Python
linktitle: Formgrupp
type: docs
weight: 40
url: /sv/python-net/group/
keywords:
- gruppform
- formgrupp
- lägg till grupp
- alternativ text
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig att gruppera och avgruppera former i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python—snabb, steg-för-steg-guide med gratis kod."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med gruppformer i Aspose.Slides. Den visar hur du lägger till en gruppform på en bild, placerar former i den och sparar den uppdaterade presentationen. Den demonstrerar också hur du får åtkomst till former som lagras i en grupp och läser deras `alternative_text`‑värden. Dessutom täcker artikeln kort relaterade funktioner för gruppformer såsom nästlade grupper, z‑ordning och låsalternativ.

## **Lägg till gruppformer**

Aspose.Slides stödjer arbete med gruppformer på en bild. Denna funktion låter dig skapa rikare presentationer genom att behandla flera former som ett enda objekt. Du kan lägga till nya gruppformer, komma åt befintliga, fylla dem med underformer och läsa eller ändra någon av deras egenskaper. För att lägga till en gruppform på en bild:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till en bild efter index.
3. Lägg till en [GroupShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshape/) på bilden.
4. Lägg till former i den nya gruppformen.
5. Spara den ändrade presentationen som en PPTX‑fil.

Exemplet nedan visar hur du lägger till en gruppform på en bild.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen.
with slides.Presentation() as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en gruppform på bilden.
    group_shape = slide.shapes.add_group_shape()

    # Lägg till former i gruppformen.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Skriv PPTX-filen till disk.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till Alt‑text‑egenskapen**

Detta avsnitt förklarar hur du läser Alt‑text för former som finns i en gruppform på en bild med Aspose.Slides. För att få åtkomst till Alt‑text för formerna:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för att representera en PPTX‑fil.
2. Hämta en referens till bilden efter dess index.
3. Få åtkomst till bildens samling av former.
4. Få åtkomst till [GroupShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshape/).
5. Läs Alt‑text‑egenskapen.

Exemplet nedan hämtar Alt‑text för former som finns i gruppformer.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att öppna PPTX-filen.
with slides.Presentation("group_shape.pptx") as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Åtkomst till gruppformen.
            for child_shape in shape.shapes:
                # Åtkomst till Alt Text-egenskapen.
                print(child_shape.alternative_text)
```

## **FAQ**

**Stöds nästlad gruppering (en grupp inuti en grupp)?**

Ja. [GroupShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshape/) har en [parent_group](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshape/parent_group/)‑egenskap som tydligt indikerar stöd för hierarki (en grupp kan vara ett underobjekt till en annan grupp).

**Hur styr jag gruppens z‑ordning i förhållande till andra objekt på bilden?**

Använd [GroupShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshape/)s [z_order_position](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshape/z_order_position/)‑egenskap för att undersöka dess position i visningsstacken.

**Kan jag förhindra att flytta/redigera/avgruppa?**

Ja. Gruppens låsavsnitt exponeras via [group_shape_lock](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshape/group_shape_lock/), vilket låter dig begränsa operationer på objektet.