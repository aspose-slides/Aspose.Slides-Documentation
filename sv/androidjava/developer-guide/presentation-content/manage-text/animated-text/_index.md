---
title: Animera PowerPoint-text på Android
linktitle: Animerad text
type: docs
weight: 60
url: /sv/androidjava/animated-text/
keywords:
- animerad text
- textanimation
- animerat stycke
- styckeanimation
- animeringseffekt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Skapa dynamisk animerad text i PowerPoint- och OpenDocument-presentationer med hjälp av Aspose.Slides för Android, med lättföljda, optimerade Java-kodexempel."
---
## **Översikt**

Den här artikeln beskriver hur du arbetar med animerad text i Aspose.Slides genom att applicera animeringseffekter på enskilda stycken och hämta de effekter som redan har tilldelats stycken i en textram. Den fokuserar på API‑metoderna som används för att lägga till animering på styckennivå och inspektera befintliga animeringseffekter för stycken i en presentation.

## **Lägg till animeringseffekter på stycken**

Vi har lagt till metoden [**addEffect()**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) i klasserna [**Sequence**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Sequence) och [**ISequence**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISequence). Denna metod låter dig lägga till animeringseffekter på ett enskilt stycke. Följande exempel visar hur du lägger till en animeringseffekt på ett enskilt stycke:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // välj stycke för att lägga till effekt
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

## **Hämta animeringseffekter för stycken**

Du kan behöva ta reda på vilka animeringseffekter som har lagts till ett stycke – till exempel i ett scenario där du vill hämta animeringseffekterna i ett stycke för att sedan applicera dem på ett annat stycke eller en annan form.

Aspose.Slides for Android via Java gör det möjligt att hämta alla animeringseffekter som har applicerats på stycken i en textram (form). Följande exempel visar hur du hämtar animeringseffekterna i ett stycke:

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

Textanimationer styr objektets beteende över tid på en bild, medan [transitions](/slides/sv/androidjava/slide-transition/) styr hur bilder byts. De är oberoende och kan användas tillsammans; uppspelningsordningen styrs av animeringstidslinjen och övergångsinställningarna.

**Behålls textanimationer vid export till PDF eller bilder?**

Nej. PDF och rasterbilder är statiska, så du ser ett enda tillstånd av bilden utan rörelse. För att behålla rörelsen, använd export till [video](/slides/sv/androidjava/convert-powerpoint-to-video/) eller [HTML](/slides/sv/androidjava/export-to-html5/).

**Fungerar textanimationer i layouter och bildmaster?**

Effekter som appliceras på layout-/masterobjekt ärvs av bilder, men deras timing och samspel med bildnivåanimationer beror på den slutliga sekvensen på bilden.