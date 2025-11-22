---
title: Multithreading in Aspose.Slides
type: docs
weight: 310
url: /de/nodejs-java/multithreading/
keywords:
- PowerPoint
- Präsentation
- Multithreading
- parallele Arbeit
- Folien konvertieren
- Folien zu Bildern
- JavaScript
- Aspose.Slides für Node.js über Java
---

## **Einleitung**

Während parallele Arbeiten mit Präsentationen möglich sind (außerhalb von Parsen/Laden/Klonen) und meistens alles gut funktioniert, besteht eine geringe Wahrscheinlichkeit, dass Sie bei Verwendung der Bibliothek in mehreren Threads falsche Ergebnisse erhalten.

Wir empfehlen dringend, **nicht** eine einzelne [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Instanz in einer Multithreading-Umgebung zu verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht zu erkennen sind.

Es ist **nicht** sicher, eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Solche Vorgänge werden **nicht** unterstützt. Wenn Sie solche Aufgaben ausführen müssen, sollten Sie die Vorgänge parallel mit mehreren ein‑Thread‑Prozessen durchführen – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden.

## **Präsentationsfolien parallel in Bilder konvertieren**

Angenommen, wir möchten alle Folien einer PowerPoint‑Präsentation parallel in PNG‑Bilder konvertieren. Da es unsicher ist, eine einzelne `Presentation`‑Instanz in mehreren Threads zu verwenden, teilen wir die Folien in separate Präsentationen auf und konvertieren die Folien parallel in Bilder, wobei jede Präsentation in einem eigenen Thread verwendet wird. Das folgende Code‑Beispiel zeigt, wie das funktioniert.
```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Extrahiere Folie i in eine separate Präsentation.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Warte, bis alle Aufgaben abgeschlossen sind.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```


## **FAQ**

**Muss ich die Lizenzkonfiguration in jedem Thread aufrufen?**

Nein. Es reicht, dies einmal pro Prozess/Anwendungsdomäne vor dem Start der Threads auszuführen. Wenn die [license setup](/slides/de/nodejs-java/licensing/)-Methode gleichzeitig aufgerufen werden könnte (z. B. während der lazy‑Initialisierung), synchronisieren Sie diesen Aufruf, da die Lizenzkonfigurations‑Methode selbst nicht thread‑sicher ist.

**Kann ich `Presentation`‑ oder `Slide`‑Objekte zwischen Threads übergeben?**

Das Übergeben von „Live‑“Präsentationsobjekten zwischen Threads wird nicht empfohlen: Verwenden Sie unabhängige Instanzen pro Thread oder erzeugen Sie im Voraus separate Präsentationen/Slide‑Container für jeden Thread. Dieser Ansatz entspricht der allgemeinen Empfehlung, keine einzelne Präsentationsinstanz über Threads hinweg zu teilen.

**Ist es sicher, den Export in verschiedene Formate (PDF, HTML, Bilder) zu parallelisieren, sofern jeder Thread seine eigene `Presentation`‑Instanz hat?**

Ja. Mit unabhängigen Instanzen und separaten Ausgabepfaden lassen sich solche Vorgänge in der Regel korrekt parallelisieren; vermeiden Sie gemeinsam genutzte Präsentationsobjekte und geteilte I/O‑Streams.

**Was sollte ich mit globalen Schriftarteinstellungen (Ordner, Ersetzungen) im Multithreading tun?**

Initialisieren Sie alle globalen Schriftarteinstellungen, bevor Sie die Threads starten, und ändern Sie sie während der parallelen Arbeit nicht. Dadurch werden Wettbewerbsbedingungen beim Zugriff auf gemeinsam genutzte Schriftressourcen vermieden.