---
title: Multitrådning i Aspose.Slides för Android via Java
linktitle: Multitrådning
type: docs
weight: 310
url: /sv/androidjava/multithreading/
keywords:
- multitrådning
- flera trådar
- parallellt arbete
- konvertera bilder
- bilder till bildfiler
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides för Android via Java multitrådning förbättrar bearbetning av PowerPoint och OpenDocument. Upptäck bästa praxis för effektiva presentationsarbetsflöden."
---
## **Introduktion**

Även om parallellt arbete med presentationer är möjligt (förutom parsning/lastning/kloning) och allt går bra (vanligtvis), finns en liten möjlighet att du får felaktiga resultat när du använder biblioteket i flera trådar.

Vi rekommenderar starkt att du **inte** använder ett enda [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-objekt i en multitrådad miljö eftersom det kan leda till oförutsägbara fel eller misslyckanden som är svåra att upptäcka.

Det är **inte** säkert att läsa in, spara och/eller klona en instans av en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-klass i flera trådar. Sådana operationer **stöds inte**. Om du behöver utföra sådana uppgifter måste du parallellisera operationerna med flera enklatrådade processer – och varje process bör använda sin egen presentationsinstans.

## **Konvertera presentationsbilder till bilder parallellt**

Låt oss säga att vi vill konvertera alla bilder i en PowerPoint-presentation till PNG‑bilder parallellt. Eftersom det är osäkert att använda en enda `Presentation`‑instans i flera trådar delar vi upp presentationsbilderna i separata presentationer och konverterar bilderna till bilder parallellt, där varje presentation används i en egen tråd. Följande kodexempel visar hur man gör detta.

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Extrahera slide i till en separat presentation.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Konvertera slide till en bild i en separat uppgift.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
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
		}
	}));
}

// Vänta på att alla uppgifter ska slutföras.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **Vanliga frågor**

**Behöver jag anropa licensinställning i varje tråd?**

Nej. Det räcker att göra det en gång per process/applikationsdomän innan trådarna startar. Om [licensinställning](/slides/sv/androidjava/licensing/) kan anropas samtidigt (till exempel under fördröjd initiering), synkronisera det anropet eftersom licensinställningsmetoden i sig inte är trådsäker.

**Kan jag skicka `Presentation`‑ eller `Slide`‑objekt mellan trådar?**

Det rekommenderas inte att skicka “levande” presentationsobjekt mellan trådar: använd oberoende instanser per tråd eller förhands skapa separata presentationer/slid‑behållare för varje tråd. Detta tillvägagångssätt följer den generella rekommendationen att inte dela en enda presentationsinstans mellan trådar.

**Är det säkert att parallellisera export till olika format (PDF, HTML, bilder) förutsatt att varje tråd har sin egen `Presentation`‑instans?**

Ja. Med oberoende instanser och separata utdatavägar parallelliseras sådana uppgifter vanligtvis korrekt; undvik delade presentationsobjekt och delade I/O‑strömmar.

**Vad ska jag göra med globala teckensnittsinställningar (mappar, ersättningar) i multitrådad miljö?**

Initiera alla globala [font settings](/slides/sv/androidjava/powerpoint-fonts/) innan trådarna startas och ändra dem inte under parallellt arbete. Detta eliminerar konkurrenssituationer när delade teckensnitt resurser nås.