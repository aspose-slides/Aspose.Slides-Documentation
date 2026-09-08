---
title: Verbeter uw presentaties met AutoFit in Python
linktitle: Autofit-instellingen
type: docs
weight: 30
url: /nl/python-java/manage-autofit-settings/
keywords:
- tekstvak
- autofit
- niet automatisch aanpassen
- tekst laten passen
- tekst verkleinen
- tekst omslaan
- vormgrootte aanpassen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u AutoFit-instellingen beheert in Aspose.Slides voor Python via Java om de weergave van tekst in uw PowerPoint- en OpenDocument-presentaties te optimaliseren en de leesbaarheid van de inhoud te verbeteren."
---
## **Inleiding**

Standaard, wanneer je een tekstvak toevoegt, gebruikt Microsoft PowerPoint de instelling **Resize shape to fix text** voor het tekstvak – het past de grootte van het tekstvak automatisch aan om te zorgen dat de tekst er altijd in past. 

![tekstvak-in-powerpoint](textbox-in-powerpoint.png)

* Wanneer de tekst in het tekstvak langer of groter wordt, vergroot PowerPoint het tekstvak automatisch – het verhoogt de hoogte – zodat het meer tekst kan bevatten. 
* Wanneer de tekst in het tekstvak korter of kleiner wordt, verkleint PowerPoint het tekstvak automatisch – het verlaagt de hoogte – om overbodige ruimte te verwijderen. 

In PowerPoint zijn dit de vier belangrijke parameters of opties die het autofit‑gedrag van een tekstvak bepalen: 

* **Niet automatisch aanpassen**
* **Tekst verkleinen bij overflow**
* **Vormgrootte aanpassen aan tekst**
* **Tekst laten omslaan in vorm.**

![autofit-opties-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java biedt soortgelijke opties – enkele eigenschappen onder de [TextFrameFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/)‑klasse – die je in staat stellen het autofit‑gedrag van tekstvakken in presentaties te regelen. 

## **Vormgrootte aanpassen aan tekst**

Als je wilt dat de tekst in een vak altijd in dat vak past nadat de tekst is aangepast, moet je de optie **Resize shape to fix text** gebruiken. Om deze instelling te specificeren, gebruik je de [setAutofitType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setAutofitType)‑methode (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/)‑klasse) met [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textautofittype/#Shape). 

![altijd-passend-instelling-powerpoint](alwaysfit-setting-powerpoint.png)

Deze Python‑code toont hoe je opgeeft dat een tekst altijd in zijn vak moet passen in een PowerPoint‑presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Als de tekst langer of groter wordt, wordt het tekstvak automatisch vergroot (hoogte wordt verhoogd) zodat alle tekst erin past. Wordt de tekst korter, gebeurt het tegenovergestelde. 

## **Niet automatisch aanpassen**

Als je wilt dat een tekstvak of vorm zijn afmetingen behoudt, ongeacht de wijzigingen in de tekst die het bevat, moet je de optie **Do not Autofit** gebruiken. Om deze instelling te specificeren, gebruik je de [setAutofitType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setAutofitType)‑methode (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/)‑klasse) met [None](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textautofittype/#None). 

![niet-autofit-instelling-powerpoint](donotautofit-setting-powerpoint.png)

Deze Python‑code toont hoe je opgeeft dat een tekstvak altijd zijn afmetingen moet behouden in een PowerPoint‑presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wanneer de tekst te lang wordt voor het vak, stroomt deze over. 

## **Tekst verkleinen bij overflow**

Als een tekst te lang wordt voor het vak, kun je via de optie **Shrink text on overflow** opgeven dat de grootte en de afstand van de tekst moeten worden verkleind zodat deze in het vak past. Om deze instelling te specificeren, gebruik je de [setAutofitType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setAutofitType)‑methode (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/)‑klasse) met [Normal](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textautofittype/#Normal). 

![tekstverkleinen-overflow-instelling-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Deze Python‑code toont hoe je opgeeft dat een tekst moet worden verkleind bij overflow in een PowerPoint‑presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
Wanneer de optie **Shrink text on overflow** wordt gebruikt, wordt de instelling alleen toegepast wanneer de tekst te lang wordt voor het vak. 
{{% /alert %}}

## **Tekst laten omslaan**

Als je wilt dat de tekst in een vorm wordt omslagen binnen die vorm wanneer de tekst de rand van de vorm (alleen de breedte) overschrijdt, moet je de parameter **Wrap text in shape** gebruiken. Om deze instelling te specificeren, moet je de [setWrapText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setWrapText)‑methode (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/)‑klasse) gebruiken met [NullableBool.True](https://reference.aspose.com/slides/nl/python-java/aspose.slides/nullablebool/#True). 

Deze Python‑code toont hoe je de instelling Tekst laten omslaan gebruikt in een PowerPoint‑presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
Als je de [setWrapText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setWrapText)‑methode gebruikt met [NullableBool.False](https://reference.aspose.com/slides/nl/python-java/aspose.slides/nullablebool/#False) voor een vorm, dan wordt de tekst die langer wordt dan de breedte van de vorm in één regel buiten de vormranden voortgezet. 
{{% /alert %}}

## **FAQ**

**Hebben de interne marges van het tekstkader invloed op AutoFit?**

Ja. Padding (interne marges) verkleint het bruikbare tekstgebied, waardoor AutoFit eerder ingrijpt – door het lettertype te verkleinen of de vorm eerder te herschalen. Controleer en pas de marges aan voordat je AutoFit afstemt.

**Hoe werkt AutoFit samen met handmatige en zachte regelafbrekingen?**

Geforceerde afbrekingen blijven behouden, en AutoFit past de lettergrootte en interlinie eromheen aan. Het verwijderen van overbodige afbrekingen vermindert vaak hoe agressief AutoFit de tekst moet verkleinen.

**Heeft het wijzigen van het themalekertype of het activeren van lettertype‑vervanging invloed op de AutoFit‑resultaten?**

Ja. Het vervangen door een lettertype met andere glyf‑metrieken verandert de breedte/hoogte van de tekst, wat de uiteindelijke lettergrootte en regelomslag kan beïnvloeden. Na elke wijziging of substitutie van een lettertype, moet je de dia's opnieuw controleren.