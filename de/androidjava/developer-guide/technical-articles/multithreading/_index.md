---
title: Multithreading in Aspose.Slides
type: docs
weight: 310
url: /androidjava/multithreading/
keywords:
- PowerPoint
- Präsentation
- Multithreading
- paralleles Arbeiten
- Folien konvertieren
- Folien in Bilder
- Android
- Java
- Aspose.Slides für Android über Java
---

## **Einführung**

Während paralleles Arbeiten mit Präsentationen möglich ist (neben dem Parsen/Laden/Klonen) und meistens alles gut verläuft, besteht eine geringe Chance, dass Sie bei der Verwendung der Bibliothek in mehreren Threads falsche Ergebnisse erhalten könnten.

Wir empfehlen dringend, dass Sie **nicht** eine einzelne [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Instanz in einer Multithreading-Umgebung verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht erkannt werden können.

Es ist **nicht** sicher, eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Solche Operationen werden **nicht** unterstützt. Wenn Sie solche Aufgaben durchführen müssen, müssen Sie die Operationen mit mehreren einkernigen Prozessen parallelisieren – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden.

## **Präsentationsfolien parallel in Bilder konvertieren**

Angen wir, wir möchten alle Folien aus einer PowerPoint-Präsentation parallel in PNG-Bilder konvertieren. Da es unsicher ist, eine einzelne `Presentation` Instanz in mehreren Threads zu verwenden, teilen wir die Präsentationsfolien in separate Präsentationen auf und konvertieren die Folien parallel in Bilder, wobei jede Präsentation in einem separaten Thread verwendet wird. Das folgende Codebeispiel zeigt, wie dies geht.

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
	// Extrahiere Folie i in eine separate Präsentation.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Konvertiere die Folie in ein Bild im separaten Task.
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

// Warte, bis alle Aufgaben abgeschlossen sind.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```