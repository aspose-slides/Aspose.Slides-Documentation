---
title: Hantera SmartArt-grafik i presentationer med Python
linktitle: SmartArt-grafik
type: docs
weight: 20
url: /sv/python-net/manage-smartart-shape/
keywords:
- SmartArt-objekt
- SmartArt-grafik
- SmartArt-stil
- SmartArt-färg
- skapa SmartArt
- lägga till SmartArt
- redigera SmartArt
- ändra SmartArt
- åtkomst till SmartArt
- SmartArt layouttyp
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Automatisera skapande, redigering och formatering av PowerPoint SmartArt i Python via .NET med Aspose.Slides, med korta kodexempel och prestandafokuserad vägledning."
---
## **Översikt**

Aspose.Slides låter dig skapa och hantera SmartArt-grafik i PowerPoint-presentationer programmässigt. Den här artikeln förklarar hur du lägger till en SmartArt-form på en bild, får åtkomst till befintliga SmartArt-former, hittar SmartArt med en specifik layouttyp och uppdaterar dess visuella utseende genom att ändra SmartArt-stilen eller färgstilen.

Exemplen visar hur du arbetar med SmartArt-former via bildens formsamling, kontrollerar om en form är SmartArt och sedan modifierar eller inspekterar dess egenskaper.

## **Skapa SmartArt-former**

Aspose.Slides for Python via .NET låter dig lägga till anpassade SmartArt-former på bilder från grunden. API:et gör detta enkelt. Så här lägger du till en SmartArt-form på en bild:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta målbilden med dess index.
1. Lägg till en SmartArt-form och ange dess layouttyp.
1. Spara den modifierade presentationen som en PPTX-fil.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Instansiera Presentation-klassen.
with slides.Presentation() as presentation:
    # Åtkomst till prezentationsbilden.
    slide = presentation.slides[0]
    # Lägg till en SmartArt-form.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Spara presentationen till disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Få åtkomst till SmartArt-former på bilder**

Följande kod visar hur du får åtkomst till SmartArt-former på en bild. Exemplet itererar genom varje form på bilden och kontrollerar om den är ett [SmartArt](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/)-objekt.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Läs in en presentationsfil.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterera genom varje form på den första bilden.
    for shape in presentation.slides[0].shapes:
        # Kontrollera om formen är en SmartArt-form.
        if isinstance(shape, smartart.SmartArt):
            # Skriv ut formens namn.
            print("Shape name:", shape.name)
```

## **Få åtkomst till SmartArt-former med en specificerad layouttyp**

Följande exempel visar hur du får åtkomst till en SmartArt-form med en specificerad layouttyp. Observera att du inte kan ändra en SmartArts layouttyp—den är skrivskyddad och anges när formen skapas.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-instans och läs in presentationen som innehåller SmartArt-formen.
1. Hämta en referens till den första bilden med index.
1. Iterera över varje form på den första bilden.
1. Kontrollera om formen är ett [SmartArt](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/)-objekt.
1. Om SmartArt-formens layouttyp matchar den du behöver, utför de nödvändiga åtgärderna.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterera genom varje form på den första bilden.
    for shape in presentation.slides[0].shapes:
        # Kontrollera om formen är en SmartArt-form.
        if isinstance(shape, smartart.SmartArt):
            # Kontrollera SmartArt layouttyp.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **Ändra SmartArt-formens stil**

Följande exempel visar hur du hittar SmartArt-former och ändrar deras stil:

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och läs in filen som innehåller SmartArt-form(en).
1. Hämta en referens till den första bilden med index.
1. Iterera över varje form på den första bilden.
1. Hitta SmartArt-formen med den specificerade stilen.
1. Tilldela den nya stilen till SmartArt-formen.
1. Spara presentationen.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterera genom varje form på den första bilden.
    for shape in presentation.slides[0].shapes:
        # Kontrollera om formen är en SmartArt-form.
        if isinstance(shape, smartart.SmartArt):
            # Kontrollera SmartArt-stilen.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Ändra SmartArt-stilen.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Spara presentationen.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ändra färgstilen för SmartArt-former**

Detta exempel visar hur du ändrar färgstilen för en SmartArt-form. Exempelkoden hittar en SmartArt-form med en specificerad färgstil och uppdaterar den.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och läs in presentationen som innehåller SmartArt-form(en).
1. Hämta en referens till den första bilden med index.
1. Iterera över varje form på den första bilden.
1. Kontrollera om formen är ett [SmartArt](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/)-objekt.
1. Lokalisera SmartArt-formen med den specificerade färgstilen.
1. Ange den nya färgstilen för den SmartArt-formen.
1. Spara presentationen.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iterera genom varje form på den första bilden.
    for shape in presentation.slides[0].shapes:
        # Kontrollera om formen är en SmartArt-form.
        if isinstance(shape, smartart.SmartArt):
            # Kontrollera färgtypen.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Ändra färgtypen.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Spara presentationen.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Kan jag animera SmartArt som ett enda objekt?**

Ja. SmartArt är en form, så du kan applicera [standardanimationer](/slides/sv/python-net/powerpoint-animation/) via animations‑API‑et (ingång, utgång, betoning, rörelsebanor) precis som för andra former.

**Hur kan jag hitta en specifik SmartArt på en bild om jag inte känner till dess interna ID?**

Ange och använd alternativ text (AltText) och sök efter formen med det värdet—detta är ett rekommenderat sätt att hitta målformen.

**Kan jag gruppera SmartArt med andra former?**

Ja. Du kan gruppera SmartArt med andra former (bilder, tabeller osv.) och sedan [manipulera gruppen](/slides/sv/python-net/group/).

**Hur får jag en bild av en specifik SmartArt (t.ex. för en förhandsgranskning eller rapport)?**

Exportera en miniatyrbild/bild av formen; biblioteket kan [rendera enskilda former](/slides/sv/python-net/create-shape-thumbnails/) till rasterfiler (PNG/JPG/TIFF).

**Kommer SmartArt-utseendet att bevaras när hela presentationen konverteras till PDF?**

Ja. Renderingsmotorn siktar på hög trohet för [PDF‑export](/slides/sv/python-net/convert-powerpoint-to-pdf/), med en rad kvalitets- och kompatibilitetsalternativ.