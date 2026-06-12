---
title: Inbedden van lettertypen in presentaties met Python
linktitle: Lettertype inbedden
type: docs
weight: 40
url: /nl/python-net/embedded-font/
keywords:
- lettertype toevoegen
- lettertype inbedden
- inbedden van lettertype
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Inbedde TrueType-lettertypen in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python via .NET, waardoor nauwkeurige weergave op alle platforms wordt gegarandeerd."
---
## **Introductie**

**Lettertypen inbedden in PowerPoint** zorgt ervoor dat uw presentatie zijn beoogde uiterlijk behoudt op verschillende systemen. Of u nu unieke lettertypen gebruikt voor creativiteit of standaard lettertypen, het inbedden van lettertypen voorkomt verstoringen van tekst en lay‑out.

Als u een lettertype van een derde partij of een niet‑standaard lettertype hebt gebruikt omdat u creatief was met uw werk, dan heeft u nog meer redenen om uw lettertype in te bedden. Anders (zonder ingesloten lettertypen) kunnen de teksten of cijfers op uw dia’s, de lay‑out, de opmaak, enzovoort, veranderen of veranderen in verwarrende rechthoeken. 

Gebruik de [FontsManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontdata/) en [Compress](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/) klassen om ingesloten lettertypen te beheren.

## **Haal ingesloten lettertypen op en verwijder ze**

Haalt of verwijdert ingesloten lettertypen uit een presentatie moeiteloos met de [get_embedded_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) en [remove_embedded_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/remove_embedded_font/) methoden.

Deze Python‑code laat zien hoe u ingesloten lettertypen uit een presentatie kunt ophalen en verwijderen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Render de dia met een tekstkader dat het ingesloten lettertype 'FunSized' gebruikt.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Haal alle ingesloten lettertypen op.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Zoek het lettertype 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Verwijder het lettertype 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # Render de dia; het lettertype 'Calibri' wordt vervangen door een bestaand lettertype.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Sla de presentatie zonder het ingesloten lettertype 'Calibri' op naar schijf.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Voeg ingesloten lettertypen toe**

Met behulp van de [EmbedFontCharacters](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/embedfontcharacters/) enum en twee overloads van de [add_embedded_font](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/add_embedded_font/) methode kunt u uw voorkeur (inbedregel) selecteren om lettertypen in een presentatie in te bedden. Deze Python‑code laat zien hoe u lettertypen kunt inbedden en toevoegen aan een presentatie:

```python
import aspose.slides as slides

# Laad een presentatie.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Sla de presentatie op naar schijf.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Ingesloten lettertypen comprimeren**

Optimaliseer de bestandsgrootte door ingesloten lettertypen te comprimeren met [compress_embedded_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Voorbeeldcode voor compressie:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Hoe kan ik zien of een specifiek lettertype in de presentatie nog steeds wordt vervangen tijdens het renderen, ondanks het inbedden?**

Controleer de [substitution information](/slides/nl/python-net/font-substitution/) in de font manager en de [fallback/substitution rules](/slides/nl/python-net/fallback-font/): als het lettertype niet beschikbaar of beperkt is, wordt er een fallback gebruikt.

**Is het de moeite waard om “systeem”lettertypen zoals Arial/Calibri in te bedden?**

Meestal niet—ze zijn bijna altijd beschikbaar. Maar voor volledige draagbaarheid in “dunne” omgevingen (Docker, een Linux‑server zonder vooraf geïnstalleerde lettertypen) kan het inbedden van systeemlettertypen het risico op onverwachte vervangingen wegnemen.