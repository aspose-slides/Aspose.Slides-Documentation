---
title: Animera PowerPoint-text i Java
linktitle: Animerad text
type: docs
weight: 60
url: /sv/java/animated-text/
keywords:
- animerad text
- textanimation
- animerat stycke
- styckeanimation
- animationseffekt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Skapa dynamisk animerad text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Java, med lättföljda, optimerade Java-kodexempel."
---
## **Översikt**

Denna artikel förklarar hur du arbetar med animerad text i Aspose.Slides genom att tillämpa animationseffekter på enskilda stycken och hämta de effekter som redan har tilldelats stycken i ett textram. Den fokuserar på API‑metoderna som används för att lägga till styckenivåanimation och inspektera befintliga styckeanimationseffekter i en presentation.

## **Lägg till animationseffekter på stycken**

Vi har lagt till metoden [**addEffect()**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) i klasserna [**Sequence**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Sequence) och [**ISequence**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISequence). Denna metod gör det möjligt att lägga till animationseffekter på ett enskilt stycke. Följande kodexempel visar hur du lägger till en animationseffekt på ett enskilt stycke:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // välj stycke för att lägga till en effekt
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // lägg till Fly-animeringseffekt till det valda stycket
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Hämta animationseffekter för stycken**

Du kanske vill ta reda på vilka animationseffekter som har lagts till ett stycke – till exempel kan du i ett scenario vilja hämta animationseffekterna i ett stycke eftersom du planerar att tillämpa dessa effekter på ett annat stycke eller en annan form.  

Aspose.Slides for Java låter dig hämta alla animationseffekter som har tillämpats på stycken som finns i ett textram (form). Följande kodexempel visar hur du hämtar animationseffekterna i ett stycke:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **Vanliga frågor**

**Hur skiljer sig textanimationer från bildövergångar, och kan de kombineras?**

Textanimationer styr objekts beteende över tid på en bild, medan [övergångar](/slides/sv/java/slide-transition/) styr hur bilder förändras. De är oberoende och kan användas tillsammans; uppspelningsordningen styrs av animationstidslinjen och övergångsinställningarna.

**Bevaras textanimationer vid export till PDF eller bilder?**

Nej. PDF och rasterbilder är statiska, så du ser ett enda bildläge utan rörelse. För att behålla rörelsen, använd export till [video](/slides/sv/java/convert-powerpoint-to-video/) eller [HTML](/slides/sv/java/export-to-html5/).

**Fungerar textanimationer i layouter och bildmästaren?**

Effekter som tillämpas på layout-/mästarobjekt ärvs av bilder, men deras timing och interaktion med bildnivåanimationer beror på den slutgiltiga sekvensen på bilden.