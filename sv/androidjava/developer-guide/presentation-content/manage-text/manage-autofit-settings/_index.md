---
title: Förbättra dina presentationer med AutoFit på Android
linktitle: Autofit‑inställningar
type: docs
weight: 30
url: /sv/androidjava/manage-autofit-settings/
keywords:
- textruta
- autofit
- inaktivera autofit
- anpassa text
- minska text
- radbryt text
- ändra formstorlek
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera AutoFit‑inställningar i Aspose.Slides för Android via Java för att optimera textvisning i dina PowerPoint‑ och OpenDocument‑presentationer och förbättra innehållsläsbarheten."
---
## **Introduktion**

Som standard, när du lägger till en textruta, använder Microsoft PowerPoint inställningen **Resize shape to fix text** för textrutan — den ändrar automatiskt storleken på textrutan för att säkerställa att dess text alltid får plats i den. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* När texten i textrutan blir längre eller större förstorar PowerPoint automatiskt textrutan — ökar dess höjd — för att den ska kunna rymma mer text. 
* När texten i textrutan blir kortare eller mindre minskar PowerPoint automatiskt textrutan — minskar dess höjd — för att ta bort överflödig plats. 

I PowerPoint är det dessa fyra viktiga parametrar eller alternativ som styr autofit‑beteendet för en textruta: 

* **Inaktivera Autofit**
* **Minska text vid överspill**
* **Ändra formens storlek för att passa text**
* **Radbryt text i formen.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides för Android via Java tillhandahåller liknande alternativ—vissa egenskaper i klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrameFormat) — som låter dig styra autofit‑beteendet för textrutor i presentationer.

## **Ändra formens storlek för att passa text**

Om du vill att texten i en ruta alltid ska få plats i den efter att texten ändrats, måste du använda alternativet **Resize shape to fix text**. För att ange denna inställning, sätt egenskapen [AutofitType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrameFormat)) till `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Denna Java‑kod visar hur du anger att en text alltid ska få plats i sin ruta i en PowerPoint‑presentation:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Om texten blir längre eller större kommer textrutan automatiskt att ändra storlek (öka i höjd) för att säkerställa att all text får plats i den. Om texten blir kortare sker motsatsen. 

## **Inaktivera Autofit**

Om du vill att en textruta eller form ska behålla sina mått oavsett vilka förändringar som görs i den text den innehåller, måste du använda alternativet **Do not Autofit**. För att ange denna inställning, sätt egenskapen [AutofitType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrameFormat)) till `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Denna Java‑kod visar hur du anger att en textruta alltid ska behålla sina mått i en PowerPoint‑presentation:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

När texten blir för lång för sin ruta flödar den över. 

## **Minska text vid överspill**

Om en text blir för lång för sin ruta, kan du med alternativet **Shrink text on overflow** ange att textens storlek och avstånd ska minskas för att få den att passa i rutan. För att ange denna inställning, sätt egenskapen [AutofitType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrameFormat)) till `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Denna Java‑kod visar hur du anger att en text ska minskas vid överspill i en PowerPoint‑presentation:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
När alternativet **Shrink text on overflow** används tillämpas inställningen endast när texten blir för lång för sin ruta. 
{{% /alert %}}

## **Radbryt text**

Om du vill att texten i en form ska radbrytas inom formen när texten går utanför formens kant (endast bredd), måste du använda parametern **Wrap text in shape**. För att ange denna inställning, sätt egenskapen [WrapText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/TextFrameFormat)) till `true`.

Denna Java‑kod visar hur du använder inställningen Wrap Text i en PowerPoint‑presentation:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Om du sätter egenskapen `WrapText` till `False` för en form, kommer texten inuti formen att fortsätta utanför formens kanter i en enda rad när texten blir längre än formens bredd. 
{{% /alert %}}

## **FAQ**

**Påverkar textramens interna marginaler AutoFit?**

Ja. Padding (inre marginaler) minskar det användbara området för text, så AutoFit aktiveras tidigare — teckensnittet minskar eller formen ändras i storlek snabbare. Kontrollera och justera marginalerna innan du finjusterar AutoFit.

**Hur samverkar AutoFit med manuella och mjuka radbrytningar?**

Tvingade radbrytningar förblir, och AutoFit anpassar teckenstorlek och avstånd runt dem. Att ta bort onödiga radbrytningar minskar ofta hur aggressivt AutoFit måste minska texten.

**Påverkar ändring av temateckensnitt eller aktivering av teckensnittsbyte AutoFit‑resultaten?**

Ja. Att byta till ett teckensnitt med andra glyf‑mått ändrar textens bredd/höjd, vilket kan förändra den slutliga teckenstorleken och radbrytningen. Efter någon teckensnittsförändring eller -substitution, kontrollera bilderna igen.