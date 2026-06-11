---
title: Bädda in typsnitt i presentationer med Python
linktitle: Inbäddning av typsnitt
type: docs
weight: 40
url: /sv/python-net/embedded-font/
keywords:
- lägga till typsnitt
- bädda in typsnitt
- inbäddning av typsnitt
- hämta inbäddat typsnitt
- lägga till inbäddat typsnitt
- ta bort inbäddat typsnitt
- komprimera inbäddat typsnitt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Bädda in TrueType-typsnitt i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET, vilket säkerställer exakt rendering på alla plattformar."
---
## **Introduktion**

**Inbäddning av typsnitt i PowerPoint** säkerställer att din presentation behåller sitt avsedda utseende på olika system. Oavsett om du använder unika typsnitt för kreativitet eller standardtypsnitt, förhindrar inbäddning av typsnitt text- och layoutstörningar.

Om du använde ett tredjeparts- eller icke‑standardtypsnitt eftersom du var kreativ i ditt arbete, har du ännu fler skäl att bädda in ditt typsnitt. Annars (utan inbäddade typsnitt) kan texter eller siffror på dina bildspel, layouten, stilen osv. förändras eller förvandlas till förvirrande rektanglar.

Använd klasserna [FontsManager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontdata/) och [Compress](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/) för att hantera inbäddade typsnitt.

## **Hämta och ta bort inbäddade typsnitt**

Hämta eller ta bort inbäddade typsnitt från en presentation enkelt med metoderna [get_embedded_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) och [remove_embedded_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Den här Python‑koden visar hur du hämtar och tar bort inbäddade typsnitt från en presentation:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instansiera Presentation-klassen som representerar en presentationsfil.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Rendera bilden som innehåller en textruta som använder det inbäddade 'FunSized'-typsnittet.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Hämta alla inbäddade typsnitt.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Hitta 'Calibri'-typsnittet.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Ta bort 'Calibri'-typsnittet.
    fonts_manager.remove_embedded_font(font_data)

    # Rendera bilden; 'Calibri'-typsnittet kommer att ersättas med ett befintligt.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Spara presentationen utan det inbäddade 'Calibri'-typsnittet till disk.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Lägg till inbäddade typsnitt**

Genom att använda enumet [EmbedFontCharacters](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/embedfontcharacters/) och två överlagringar av metoden [add_embedded_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsmanager/add_embedded_font/) kan du välja din föredragna (inbäddnings)regel för att bädda in typsnitten i en presentation. Den här Python‑koden visar hur du bäddar in och lägger till typsnitt i en presentation:

```python
import aspose.slides as slides

# Läs in en presentation.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Spara presentationen till disk.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Komprimera inbäddade typsnitt**

Optimera filstorleken genom att komprimera inbäddade typsnitt med [compress_embedded_fonts](https://reference.aspose.com/slides/sv/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Exempelkod för komprimering:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Hur kan jag se att ett specifikt typsnitt i presentationen fortfarande kommer att ersättas under rendering trots inbäddning?**

Kontrollera [substitution information](/slides/sv/python-net/font-substitution/) i typsnittshanteraren och [fallback/substitution rules](/slides/sv/python-net/fallback-font/): om typsnittet är otillgängligt eller begränsat kommer en reserv att användas.

**Är det värt att bädda in ”system”-typsnitt som Arial/Calibri?**

Vanligtvis nej—de är nästan alltid tillgängliga. Men för full portabilitet i ”smala” miljöer (Docker, en Linux‑server utan förinstallerade typsnitt) kan inbäddning av systemtypsnitt eliminera risken för oväntade ersättningar.