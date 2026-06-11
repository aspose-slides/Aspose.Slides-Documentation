---
title: Animera PowerPoint-text i JavaScript
linktitle: Animerad Text
type: docs
weight: 60
url: /sv/nodejs-java/animated-text/
keywords:
- animerad text
- textanimation
- animerat stycke
- styckeanimation
- animationseffekt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa dynamisk animerad text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js, med lättföljda, optimerade kodexempel."
---
## **Översikt**

Denna artikel förklarar hur du arbetar med animerad text i Aspose.Slides genom att tillämpa animationseffekter på enskilda stycken och hämta de effekter som redan har tilldelats stycken i en textram. Den fokuserar på API‑metoderna som används för att lägga till animation på styckenivå och inspektera befintliga animationseffekter i en presentation.

## **Lägga till animationseffekter till stycken**

Vi har lagt till metoden [**addEffect()**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) i klasserna [**Sequence**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Sequence) och [**Sequence**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Sequence). Denna metod låter dig lägga till animationseffekter på ett enskilt stycke. Följande exempel visar hur du lägger till en animationseffekt på ett enskilt stycke:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // välj stycke för att lägga till effekt
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // lägg till Fly-animeringseffekt på valt stycke
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Hämta animationseffekter i stycken**

Du kan behöva ta reda på vilka animationseffekter som har lagts till i ett stycke – till exempel i ett scenario där du vill hämta animationseffekterna i ett stycke för att tillämpa dem på ett annat stycke eller en annan form.

Aspose.Slides för Node.js via Java låter dig hämta alla animationseffekter som har applicerats på stycken i en textram (form). Följande exempel visar hur du får fram animationseffekterna i ett stycke:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**Hur skiljer sig textanimationer från bildövergångar, och kan de kombineras?**

Textanimationer styr objektets beteende över tid på en bild, medan [övergångar](/slides/sv/nodejs-java/slide-transition/) styr hur bilder byts. De är oberoende och kan användas tillsammans; uppspelningsordningen styrs av animationstidslinjen och övergångsinställningarna.

**Behålls textanimationer vid export till PDF eller bilder?**

Nej. PDF‑ och rasterbilder är statiska, så du ser bara ett enda bildtillstånd utan rörelse. För att behålla rörelse, använd [video](/slides/sv/nodejs-java/convert-powerpoint-to-video/) eller [HTML](/slides/sv/nodejs-java/export-to-html5/) export.

**Fungerar textanimationer i layout‑ och bild‑master?**

Effekter som appliceras på layout‑/master‑objekt ärvs av bilder, men deras timing och interaktion med bild‑nivåanimationer beror på den slutgiltiga sekvensen på bilden.