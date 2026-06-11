---
title: Förbättra dina presentationer med AutoFit i Java
linktitle: Autofit-inställningar
type: docs
weight: 30
url: /sv/java/manage-autofit-settings/
keywords:
- textruta
- autofit
- ingen autofit
- passa text
- krymp text
- radbryt text
- ändra formstorlek
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar AutoFit-inställningar i Aspose.Slides för Java för att optimera textvisning i dina PowerPoint- och OpenDocument-presentationer och förbättra innehållsläsbarheten."
---
## **Introduktion**

Som standard när du lägger till en textruta använder Microsoft PowerPoint inställningen **Resize shape to fix text** för textrutan – den ändrar automatiskt storleken på textrutan för att säkerställa att dess text alltid får plats i den. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* När texten i textrutan blir längre eller större förstorar PowerPoint automatiskt textrutan – ökar dess höjd – för att den ska kunna rymma mer text. 
* När texten i textrutan blir kortare eller mindre minskar PowerPoint automatiskt textrutan – minskar dess höjd – för att ta bort överflödig plats. 

I PowerPoint är detta de 4 viktiga parametrarna eller alternativen som styr autofit‑beteendet för en textruta: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java erbjuder liknande alternativ – några egenskaper under klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TextFrameFormat) – som låter dig styra autofit‑beteendet för textrutor i presentationer. 

## **Ändra storlek på en form för att passa text**

Om du vill att texten i en ruta alltid ska få plats i den efter att förändringar gjorts i texten måste du använda alternativet **Resize shape to fix text**. För att ange den här inställningen, sätt egenskapen [AutofitType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TextFrameFormat)) till `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Den här Java‑koden visar hur du anger att en text alltid måste få plats i sin ruta i en PowerPoint‑presentation:

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

Om texten blir längre eller större kommer textrutan automatiskt att ändra storlek (öka i höjd) för att säkerställa att all text får plats. Om texten blir kortare sker det motsatta. 

## **Do Not Autofit**

Om du vill att en textruta eller form ska behålla sina dimensioner oavsett vilka förändringar som görs i dess text måste du använda alternativet **Do not Autofit**. För att ange den här inställningen, sätt egenskapen [AutofitType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TextFrameFormat)) till `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Den här Java‑koden visar hur du anger att en textruta alltid ska behålla sina dimensioner i en PowerPoint‑presentation:

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

När texten blir för lång för sin ruta spillras den ut. 

## **Shrink Text on Overflow**

Om en text blir för lång för sin ruta kan du via alternativet **Shrink text on overflow** ange att textens storlek och avstånd ska minskas så att den får plats i rutan. För att ange den här inställningen, sätt egenskapen [AutofitType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TextFrameFormat)) till `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Den här Java‑koden visar hur du anger att en text ska krympas vid överflöde i en PowerPoint‑presentation:

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

## **Wrap Text**

Om du vill att texten i en form ska radbrytas inom den när texten går utanför formens kant (endast bredd) måste du använda parametern **Wrap text in shape**. För att ange den här inställningen ska du sätta egenskapen [WrapText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TextFrameFormat#getWrapText--) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/TextFrameFormat)) till `true`. 

Den här Java‑koden visar hur du använder Wrap Text‑inställningen i en PowerPoint‑presentation:

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
Om du sätter egenskapen `WrapText` till `False` för en form, när texten i formen blir längre än formens bredd, sträcker sig texten utanför formens kanter på en enda rad. 
{{% /alert %}}

## **FAQ**

**Påverkar textrutans interna marginaler AutoFit?**

Ja. Padding (interna marginaler) minskar det användbara området för text, så AutoFit träder i kraft tidigare – texten blir mindre eller formen ändras i storlek snabbare. Kontrollera och justera marginalerna innan du fininställer AutoFit.

**Hur interagerar AutoFit med manuella och mjuka radbrytningar?**

Tvingade radbrytningar kvarstår, och AutoFit anpassar teckenstorlek och avstånd runt dem. Att ta bort onödiga brytningar minskar ofta hur aggressivt AutoFit behöver krympa texten.

**Påverkar ändring av temats teckensnitt eller aktivering av teckensnittsbyte resultaten för AutoFit?**

Ja. Att byta till ett teckensnitt med olika glyf‑mått förändrar textens bredd/höjd, vilket kan ändra den slutliga teckenstorleken och radbrytningarna. Efter någon teckensnittändring eller byte, kontrollera bilderna igen.