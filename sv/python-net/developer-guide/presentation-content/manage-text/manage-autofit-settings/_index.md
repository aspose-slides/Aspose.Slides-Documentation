---
title: Förbättra dina presentationer med AutoFit i Python
linktitle: Autofit-inställningar
type: docs
weight: 30
url: /sv/python-net/manage-autofit-settings/
keywords:
- textruta
- autofit
- inaktivera autofit
- anpassa text
- krympa text
- radbryt text
- ändra formstorlek
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du hanterar AutoFit-inställningar i Aspose.Slides för Python via .NET för att optimera textvisning i dina PowerPoint- och OpenDocument-presentationer och förbättra innehållsläsbarheten."
---
## **Introduktion**

Som standard, när du lägger till en textruta, använder Microsoft PowerPoint inställningen **Resize shape to fix text** för textrutan — den ändrar automatiskt storleken på textrutan för att säkerställa att dess text alltid får plats i den. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* När texten i textrutan blir längre eller större, förstorar PowerPoint automatiskt textrutan — ökar dess höjd — för att den ska kunna rymda mer text. 
* När texten i textrutan blir kortare eller mindre, minskar PowerPoint automatiskt textrutan — minskar dess höjd — för att rensa överflödig plats. 

I PowerPoint är detta de 4 viktiga parametrarna eller alternativen som styr autofit‑beteendet för en textruta: 

* **Inaktivera Autofit**
* **Minska texten vid överflöde**
* **Ändra formens storlek för att passa text**
* **Radbryt text i form.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET tillhandahåller liknande alternativ — några egenskaper i klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/) — som låter dig kontrollera autofit‑beteendet för textrutor i presentationer. 

## **Ändra formens storlek för att passa text**

Om du vill att texten i en ruta alltid skall passa i den efter att ändringar gjorts i texten, måste du använda alternativet **Resize shape to fix text**. För att ange denna inställning, sätt egenskapen [autofit_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/) i klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/) till `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Den här Python‑koden visar hur du anger att en text alltid måste få plats i sin ruta i en PowerPoint‑presentation:

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

Om texten blir längre eller större, kommer textrutan automatiskt att ändras i storlek (höjden ökas) så att all text får plats. Om texten blir kortare sker motsatsen. 

## **Inaktivera Autofit**

Om du vill att en textruta eller form behåller sina dimensioner oavsett vilka ändringar som görs i texten den innehåller, måste du använda alternativet **Do not Autofit**. För att ange denna inställning, sätt egenskapen [autofit_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/) i klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/) till `NONE`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Den här Python‑koden visar hur du anger att en textruta alltid ska behålla sina dimensioner i en PowerPoint‑presentation:

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

När texten blir för lång för sin ruta, rinner den över. 

## **Minska texten vid överflöde**

Om en text blir för lång för sin ruta, kan du via alternativet **Shrink text on overflow** ange att textens storlek och avstånd ska minskas så att den får plats. För att ange denna inställning, sätt egenskapen [autofit_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/) i klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/) till `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Den här Python‑koden visar hur du anger att en text ska krympas vid överflöde i en PowerPoint‑presentation:

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
När alternativet **Shrink text on overflow** används, tillämpas inställningen endast när texten blir för lång för sin ruta. 
{{% /alert %}}

## **Radbryt text**

Om du vill att texten i en form radbryts inom den formen när texten går utanför formens kant (endast bredd), måste du använda parametern **Wrap text in shape**. För att ange denna inställning, måste du sätta egenskapen [wrap_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/) i klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/) till `NullableBool.TRUE`. 

Den här Python‑koden visar hur du använder Wrap Text‑inställningen i en PowerPoint‑presentation:

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

{{% alert title="Note" color="warning" %}} 
Om du sätter egenskapen `wrap_text` till `NullableBool.FALSE` för en form, när texten i formen blir längre än formens bredd, kommer texten att sträcka sig utanför formens kanter på en enda rad. 
{{% /alert %}}

## **FAQ**

**Påverkar textramens interna marginaler AutoFit?**

Ja. Padding (interna marginaler) minskar det användbara området för text, så AutoFit aktiveras tidigare — fonten krymper eller formen storlek ändras tidigare. Kontrollera och justera marginalerna innan du finjusterar AutoFit.

**Hur samverkar AutoFit med manuella och mjuka radbrytningar?**

Tvingade radbrytningar förblir, och AutoFit anpassar teckenstorlek och avstånd runt dem. Att ta bort onödiga radbrytningar minskar ofta hur aggressivt AutoFit måste krympa texten.

**Påverkar ändring av temats teckensnitt eller aktivering av teckensnittssubstitution AutoFit‑resultaten?**

Ja. Att ersätta ett teckensnitt med ett som har olika glyf‑mått förändrar textens bredd/höjd, vilket kan ändra den slutliga teckenstorleken och radbrytningen. Efter varje teckensnittbyte eller -substitution bör du kontrollera bilderna igen.