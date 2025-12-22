---
title: Multithreading in Aspose.Slides für Android via Java
linktitle: Multithreading
type: docs
weight: 310
url: /de/androidjava/multithreading/
keywords:
- Multithreading
- Mehrere Threads
- parallele Arbeit
- Folien konvertieren
- Folien zu Bildern
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides für Android via Java Multithreading verbessert die Verarbeitung von PowerPoint und OpenDocument. Entdecken Sie bewährte Vorgehensweisen für effiziente Präsentations-Workflows."
---

## **Einleitung**

Während parallele Arbeit mit Präsentationen möglich ist (außerhalb von Parsen/Laden/Klonen) und meist alles gut funktioniert, besteht eine geringe Wahrscheinlichkeit, dass bei Verwendung der Bibliothek in mehreren Threads falsche Ergebnisse erzielt werden.

Wir empfehlen dringend, dass Sie in einer Mehrthread‑Umgebung keine einzelne [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Instanz verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht zu erkennen sind.

Es ist nicht sicher, eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Derartige Vorgänge werden nicht unterstützt. Wenn Sie solche Aufgaben ausführen müssen, müssen Sie die Vorgänge parallel über mehrere einstufige Prozesse ausführen – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden.

## **Präsentationsfolien parallel in Bilder konvertieren**

Angenommen, wir möchten alle Folien einer PowerPoint‑Präsentation parallel in PNG‑Bilder konvertieren. Da die Verwendung einer einzelnen `Presentation`‑Instanz in mehreren Threads unsicher ist, teilen wir die Präsentationsfolien in separate Präsentationen auf und konvertieren die Folien parallel in Bilder, wobei jede Präsentation in einem eigenen Thread verwendet wird. Das folgende Codebeispiel zeigt, wie das funktioniert.
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
	// Folie i in eine separate Präsentation extrahieren.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Folie in einer separaten Aufgabe in ein Bild konvertieren.
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

// Auf alle Aufgaben warten, bis sie abgeschlossen sind.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```


## **FAQ**

**Muss ich die Lizenzkonfiguration in jedem Thread aufrufen?**

Nein. Es reicht, sie einmal pro Prozess/App‑Domain aufzurufen, bevor die Threads starten. Falls [Lizenzsetup](/slides/de/androidjava/licensing/) möglicherweise gleichzeitig aufgerufen wird (z. B. bei Lazy‑Initialisierung), synchronisieren Sie diesen Aufruf, da die Lizenzsetup‑Methode selbst nicht thread‑sicher ist.

**Kann ich `Presentation`‑ oder `Slide`‑Objekte zwischen Threads übergeben?**

Das Übergeben von „lebenden“ Präsentationsobjekten zwischen Threads wird nicht empfohlen: Verwenden Sie unabhängige Instanzen pro Thread oder erzeugen Sie im Voraus separate Präsentationen/Slide‑Container für jeden Thread. Dieser Ansatz folgt der allgemeinen Empfehlung, keine einzelne Präsentationsinstanz über Threads hinweg zu teilen.

**Ist es sicher, den Export in verschiedene Formate (PDF, HTML, Bilder) parallel auszuführen, vorausgesetzt, jeder Thread hat seine eigene `Presentation`‑Instanz?**

Ja. Bei unabhängigen Instanzen und separaten Ausgabepfaden lassen sich solche Aufgaben in der Regel korrekt parallelisieren; vermeiden Sie gemeinsam genutzte Präsentationsobjekte und geteilte I/O‑Ströme.

**Was soll ich mit globalen Schrifteinstellungen (Ordner, Ersetzungen) im Multithreading tun?**

Initialisieren Sie alle globalen [Schrifteinstellungen](/slides/de/androidjava/powerpoint-fonts/) vor dem Start der Threads und ändern Sie sie während der parallelen Verarbeitung nicht. Dadurch entfallen Rennbedingungen beim Zugriff auf gemeinsam genutzte Schriftressourcen.