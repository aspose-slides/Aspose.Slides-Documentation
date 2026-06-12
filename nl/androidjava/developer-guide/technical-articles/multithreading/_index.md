---
title: Multithreading in Aspose.Slides voor Android via Java
linktitle: Multithreading
type: docs
weight: 310
url: /nl/androidjava/multithreading/
keywords:
- multithreading
- meerdere threads
- parallel werk
- dia's converteren
- dia's naar afbeeldingen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides voor Android via Java multithreading versnelt de verwerking van PowerPoint- en OpenDocument-bestanden. Ontdek best practices voor efficiënte presentatiewerkstromen."
---
## **Inleiding**

Hoewel parallel werken met presentaties mogelijk is (naast parsen/laden/kloont) en meestal alles goed gaat, is er een kleine kans dat je onjuiste resultaten krijgt wanneer je de bibliotheek in meerdere threads gebruikt.

We raden ten zeerste aan om **niet** één enkele [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) instantie te gebruiken in een multithread-omgeving, omdat dit kan leiden tot onvoorspelbare fouten of storingen die moeilijk te detecteren zijn.

Het is **niet** veilig om een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse te laden, op te slaan en/of te klonen in meerdere threads. Dergelijke bewerkingen worden **niet** ondersteund. Als je zulke taken moet uitvoeren, moet je de bewerkingen paralleliseren met meerdere eentalige processen — en elk van deze processen dient zijn eigen presentati​e‑instantie te gebruiken.

## **Dia's van presentaties in parallel naar afbeeldingen converteren**

Stel dat we alle dia's van een PowerPoint‑presentatie in parallel naar PNG‑afbeeldingen willen converteren. Omdat het onveilig is om één enkele `Presentation`‑instantie in meerdere threads te gebruiken, splitsen we de dia's op in afzonderlijke presentaties en converteren we de dia's parallel naar afbeeldingen, waarbij elke presentatie in een eigen thread wordt gebruikt. Het volgende code‑voorbeeld laat zien hoe dit te doen.

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
	// Extraheer dia i in een aparte presentatie.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Converteer de dia naar een afbeelding in een aparte taak.
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

// Wacht tot alle taken voltooid zijn.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **Veelgestelde vragen**

**Moet ik licentie‑initialisatie in elke thread aanroepen?**

Nee. Het is voldoende om dit één keer per proces/app‑domein uit te voeren voordat de threads starten. Als [license setup](/slides/nl/androidjava/licensing/) gelijktijdig kan worden aangeroepen (bijvoorbeeld tijdens lazy‑initialisatie), synchroniseer die aanroep omdat de licentie‑initialisatiemethode zelf niet thread‑safe is.

**Kan ik `Presentation`- of `Slide`-objecten tussen threads doorgeven?**

Het doorgeven van "live" presentat​ie‑objecten tussen threads wordt niet aanbevolen: gebruik onafhankelijke instanties per thread of maak vooraf aparte presentaties/dia‑containers voor elke thread. Deze werkwijze volgt de algemene aanbeveling om geen enkele presentat​e‑instantie tussen threads te delen.

**Is het veilig om export in parallel te uitvoeren naar verschillende formaten (PDF, HTML, afbeeldingen) mits elke thread zijn eigen `Presentation`‑instantie heeft?**

Ja. Met onafhankelijke instanties en gescheiden uitvoer‑paden kunnen dergelijke taken doorgaans correct parallel worden uitgevoerd; vermijd gedeelde presentat​ie‑objecten en gedeelde I/O‑streams.

**Wat moet ik doen met de globale lettertype‑instellingen (mappen, substituties) bij multithreading?**

Initialiseer alle globale [font settings](/slides/nl/androidjava/powerpoint-fonts/) voordat je de threads start en wijzig ze niet tijdens parallel werk. Dit voorkomt race‑condities bij het benaderen van gedeelde lettertype‑bronnen.