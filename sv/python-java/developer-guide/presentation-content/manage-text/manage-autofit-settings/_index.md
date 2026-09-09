---
title: Förbättra dina presentationer med AutoFit i Python
linktitle: Autofit-inställningar
type: docs
weight: 30
url: /sv/python-java/manage-autofit-settings/
keywords:
- textruta
- autofit
- ingen autofit
- passa text
- krymp text
- radbryt text
- ändra storlek på form
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar AutoFit-inställningar i Aspose.Slides för Python via Java för att optimera textvisning i dina PowerPoint- och OpenDocument-presentationer och förbättra innehålls läsbarhet."
---
## **Introduktion**

Som standard, när du lägger till en textruta, använder Microsoft PowerPoint inställningen **Resize shape to fit text** för textrutan – den ändrar automatiskt storleken på textrutan så att dess text alltid får plats i den.

![Textruta i PowerPoint](textbox-in-powerpoint.png)

* När texten i textrutan blir längre eller större, förstorar PowerPoint automatiskt textrutan – ökar dess höjd – för att den ska kunna rymma mer text.
* När texten i textrutan blir kortare eller mindre, minskar PowerPoint automatiskt textrutan – minskar dess höjd – för att ta bort överflödig plats.

I PowerPoint är detta de 4 viktiga parametrarna eller alternativen som styr autofit‑beteendet för en textruta:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-alternativ i PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java tillhandahåller liknande alternativ—några egenskaper under klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/)—som låter dig styra autofit‑beteendet för textrutor i presentationer.

## **Ändra storlek på en form för att passa text**

Om du vill att texten i en ruta alltid ska få plats i den efter att texten ändrats, måste du använda alternativet **Resize shape to fit text**. För att ange denna inställning, använd metoden [setAutofitType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setAutofitType) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/)) med [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textautofittype/#Shape).

![alltid-passar-inställning i PowerPoint](alwaysfit-setting-powerpoint.png)

Denna Python‑kod visar hur du anger att text alltid ska få plats i sin ruta i en PowerPoint‑presentation:

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

Om texten blir längre eller större, kommer textrutan automatiskt att ändra storlek (öka i höjd) för att säkerställa att all text får plats. Om texten blir kortare sker motsatsen.

## **Do Not Autofit**

Om du vill att en textruta eller form ska behålla sina dimensioner oavsett ändringar i den text den innehåller, måste du använda alternativet **Do not Autofit**. För att ange denna inställning, använd metoden [setAutofitType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setAutofitType) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/)) med [None](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textautofittype/#None).

![ingen-autofit-inställning i PowerPoint](donotautofit-setting-powerpoint.png)

Denna Python‑kod visar hur du anger att en textruta alltid ska behålla sina dimensioner i en PowerPoint‑presentation:

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
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

När texten blir för lång för sin ruta, spill över. 

## **Shrink Text on Overflow**

Om text blir för lång för sin ruta kan du använda alternativet **Shrink text on overflow** för att ange att textens storlek och avstånd måste minskas så att den får plats i rutan. För att ange denna inställning, använd metoden [setAutofitType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setAutofitType) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/)) med [Normal](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textautofittype/#Normal).

![krymp-text-vid-överspill-inställning i PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Denna Python‑kod visar hur du anger att text måste krympas vid överspill i en PowerPoint‑presentation:

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

{{% alert title="Obs" color="info" %}}
När alternativet **Shrink text on overflow** används, tillämpas inställningen bara när texten blir för lång för sin ruta. 
{{% /alert %}}

## **Wrap Text**

Om du vill att texten i en form radbryts inom den formen när texten går utanför formens kant (endast bredd) måste du använda parametern **Wrap text in shape**. För att ange denna inställning använder du metoden [setWrapText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setWrapText) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/)) med [NullableBool.True_](https://reference.aspose.com/slides/sv/python-java/aspose.slides/nullablebool/#True).

Denna Python‑kod visar hur du använder Wrap Text‑inställningen i en PowerPoint‑presentation:

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
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Varning" color="warning" %}} 
Om du använder metoden [setWrapText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setWrapText) med [NullableBool.False](https://reference.aspose.com/slides/sv/python-java/aspose.slides/nullablebool/#False) för en form, så kommer texten inuti formen, när den blir längre än formens bredd, att sträcka sig utanför formens kanter på en enda rad. 
{{% /alert %}}

## **FAQ**

**Påverkar textramens interna marginaler AutoFit?**

Ja. Padding (interna marginaler) minskar det användbara området för text, så AutoFit aktiveras tidigare – teckensnittet krymps eller formen ändras i storlek snabbare. Kontrollera och justera marginalerna innan du finjusterar AutoFit.

**Hur interagerar AutoFit med manuella och mjuka radbrytningar?**

Tvingade radbrytningar behålls, och AutoFit anpassar teckenstorlek och avstånd runt dem. Att ta bort onödiga radbrytningar minskar ofta hur aggressivt AutoFit måste krympa texten.

**Påverkar ändring av temats teckensnitt eller aktivering av teckensnittssubstitution AutoFit‑resultaten?**

Ja. Att ersätta ett teckensnitt med ett som har andra glykformetrar ändrar textens bredd/höjd, vilket kan förändra den slutliga teckenstorleken och radbrytningen. Efter någon teckensnittändring eller -substitution bör du kontrollera bilderna igen.