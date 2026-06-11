---
title: Multitrådning i Aspose.Slides för Java
linktitle: Multitrådning
type: docs
weight: 310
url: /sv/java/multithreading/
keywords:
- multitrådning
- flera trådar
- parallellt arbete
- konvertera bilder
- bilder till bildfiler
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Multitrådning i Aspose.Slides för Java förbättrar hanteringen av PowerPoint och OpenDocument. Upptäck bästa praxis för effektiva presentationsarbetsflöden."
---
## **Introduktion**

Även om parallellt arbete med presentationer är möjligt (förutom parsning/laddning/kloning) och allt går bra (ofta), finns det en liten risk att du kan få felaktiga resultat när du använder biblioteket i flera trådar.

Vi rekommenderar starkt att du **inte** använder en enda [Presentation]‑instans i en multitrådad miljö eftersom det kan leda till oförutsägbara fel eller misslyckanden som inte är lätt att upptäcka. 

Det är **inte** säkert att ladda, spara och/eller klona en instans av en [Presentation]‑klass i flera trådar. Sådana operationer **stöds inte**. Om du behöver utföra sådana uppgifter måste du parallellisera operationerna med flera enklatrådade processer – och varje process ska använda sin egen presentationsinstans. 

## **Konvertera presentationsbilder till bilder parallellt**

Låt oss säga att vi vill konvertera alla bilder i en PowerPoint‑presentation till PNG‑bilder parallellt. Eftersom det är osäkert att använda en enda `Presentation`‑instans i flera trådar delar vi presentationsbilderna i separata presentationer och konverterar bilderna till bilder parallellt, där varje presentation används i en separat tråd. Följande kodexempel visar hur man gör detta.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extrahera bild i till en separat presentation.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Konvertera bilden till en bild i en separat uppgift.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Vänta på att alla uppgifter ska slutföras.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **Vanliga frågor**

**Behöver jag anropa licensinställning i varje tråd?**

Nej. Det räcker att göra det en gång per process/applikationsdomän innan trådarna startar. Om [licensinställning](/slides/sv/java/licensing/) kan anropas samtidigt (till exempel under fördröjd initiering), synkronisera det anropet eftersom licensinställningsmetoden i sig inte är trådsäker.

**Kan jag skicka `Presentation`‑ eller `Slide`‑objekt mellan trådar?**

Att skicka "levande" presentationsobjekt mellan trådar rekommenderas inte: använd oberoende instanser per tråd eller för‑skapa separata presentationer/slide‑behållare för varje tråd. Detta tillvägagångssätt följer den allmänna rekommendationen att inte dela en enda presentationsinstans över trådar.

**Är det säkert att parallellisera export till olika format (PDF, HTML, bilder) förutsatt att varje tråd har sin egen `Presentation`‑instans?**

Ja. Med oberoende instanser och separata utdatavägar parallelliseras sådana uppgifter normalt korrekt; undvik delade presentationsobjekt och delade I/O‑strömmar.

**Vad bör jag göra med globala fontinställningar (mappar, ersättningar) i multitrådning?**

Initiera alla globala [fontinställningar](/slides/sv/java/powerpoint-fonts/) innan trådarna startas och ändra dem inte under parallellt arbete. Detta eliminerar tävlingar vid åtkomst till delade fontresurser.