---
title: Verbeter uw presentaties met AutoFit in Python
linktitle: Autofit-instellingen
type: docs
weight: 30
url: /nl/python-net/manage-autofit-settings/
keywords:
- tekstvak
- autofit
- niet autofitten
- tekst passend maken
- tekst verkleinen
- tekst afbreken
- vorm aanpassen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u de AutoFit-instellingen in Aspose.Slides voor Python via .NET kunt beheren om de weergave van tekst in uw PowerPoint- en OpenDocument-presentaties te optimaliseren en de leesbaarheid van de inhoud te verbeteren."
---
## **Inleiding**

Standaard, wanneer je een tekstvak toevoegt, gebruikt Microsoft PowerPoint de **Resize shape to fix text**‑instelling voor het tekstvak—het past automatisch de grootte van het tekstvak aan zodat de tekst er altijd in past. 

![tekstvak-in-powerpoint](textbox-in-powerpoint.png)

* Wanneer de tekst in het tekstvak langer of groter wordt, vergroot PowerPoint automatisch het tekstvak—verhoogt de hoogte—om meer tekst te kunnen bevatten. 
* Wanneer de tekst in het tekstvak korter of kleiner wordt, verkleint PowerPoint automatisch het tekstvak—verlaagt de hoogte—om overbodige ruimte te verwijderen. 

In PowerPoint zijn dit de 4 belangrijke parameters of opties die het autofit‑gedrag voor een tekstvak regelen: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-opties-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET biedt vergelijkbare opties—enkele eigenschappen onder de klasse [TextFrameFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/)—die je in staat stellen het autofit‑gedrag voor tekstvakken in presentaties te beheren. 

## **Vorm aanpassen aan tekst**

Als je wilt dat de tekst in een vak altijd in dat vak past na wijzigingen, moet je de **Resize shape to fix text**‑optie gebruiken. Om deze instelling op te geven, stel je de eigenschap [autofit_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/) van de klasse [TextFrameFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/) in op `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Deze Python‑code laat zien hoe je aangeeft dat een tekst altijd in zijn vak moet passen in een PowerPoint‑presentatie:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Als de tekst langer of groter wordt, wordt het tekstvak automatisch aangepast (verhoogt in hoogte) zodat alle tekst erin past. Wordt de tekst korter, gebeurt het tegenovergestelde. 

## **Niet autofitten**

Als je wilt dat een tekstvak of vorm zijn afmetingen behoudt, ongeacht de wijzigingen in de tekst, moet je de **Do not Autofit**‑optie gebruiken. Om deze instelling op te geven, stel je de eigenschap [autofit_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/) van de klasse [TextFrameFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/) in op `NONE`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Deze Python‑code laat zien hoe je aangeeft dat een tekstvak altijd zijn afmetingen moet behouden in een PowerPoint‑presentatie:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Wanneer de tekst te lang wordt voor het vak, stroomt deze eruit. 

## **Tekst verkleinen bij overflow**

Als een tekst te lang wordt voor zijn vak, kun je via de **Shrink text on overflow**‑optie aangeven dat de grootte en de spatiëring van de tekst moeten worden verkleind zodat deze in het vak past. Om deze instelling op te geven, stel je de eigenschap [autofit_type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/) van de klasse [TextFrameFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/) in op `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Deze Python‑code laat zien hoe je aangeeft dat een tekst moet worden verkleind bij overflow in een PowerPoint‑presentatie:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Wanneer de optie **Shrink text on overflow** wordt gebruikt, wordt de instelling alleen toegepast wanneer de tekst langer wordt dan het vak. 
{{% /alert %}}

## **Wrap Text**

Als je wilt dat de tekst in een vorm wordt afgebroken binnen die vorm wanneer de tekst breder wordt dan de grens van de vorm (alleen breedte), moet je de **Wrap text in shape**‑parameter gebruiken. Om deze instelling op te geven, moet je de eigenschap [wrap_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/) van de klasse [TextFrameFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/) instellen op `NullableBool.TRUE`. 

Deze Python‑code laat zien hoe je de Wrap Text‑instelling gebruikt in een PowerPoint‑presentatie:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Opmerking" color="warning" %}} 
Als je de eigenschap `wrap_text` instelt op `NullableBool.FALSE` voor een vorm, wordt de tekst die langer wordt dan de breedte van de vorm buiten de vormgrenzen voortgezet op één regel. 
{{% /alert %}}

## **FAQ**

**Beïnvloeden de interne marges van het tekstframe AutoFit?**

Ja. Padding (interne marges) verkleint het bruikbare gebied voor tekst, waardoor AutoFit eerder wordt geactiveerd—de lettergrootte wordt verkleind of de vorm wordt eerder aangepast. Controleer en pas marges aan vóór je AutoFit afstemt.

**Hoe werkt AutoFit samen met handmatige en zachte regeleinden?**

Geforceerde regeleinden blijven behouden, en AutoFit past lettergrootte en spatiëring hieromtrent aan. Het verwijderen van onnodige regeleinden vermindert vaak hoe agressief AutoFit de tekst moet verkleinen.

**Heeft het wijzigen van het themalettertype of het activeren van lettertype‑substitutie invloed op de AutoFit‑resultaten?**

Ja. Het substitueren naar een lettertype met andere glyph‑metingen verandert de breedte/hoogte van de tekst, wat de uiteindelijke lettergrootte en regelafbreking kan wijzigen. Na elke wijziging of substitutie van het lettertype, controleer je de dia's opnieuw.