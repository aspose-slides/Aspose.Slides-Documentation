---
title: Multithreading in Aspose.Slides für C++
linktitle: Multithreading
type: docs
weight: 200
url: /de/cpp/multithreading/
keywords:
- Multithreading
- mehrere Threads
- parallele Arbeit
- Folien konvertieren
- Folien zu Bildern
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Aspose.Slides für C++ Multithreading beschleunigt die Verarbeitung von PowerPoint- und OpenDocument-Dateien. Entdecken Sie bewährte Methoden für effiziente Präsentations‑Workflows."
---

## **Einführung**

Während parallele Arbeit mit Präsentationen möglich ist (außer Parsing/Laden/Klonen) und meistens alles gut funktioniert, besteht eine geringe Wahrscheinlichkeit, dass Sie falsche Ergebnisse erhalten, wenn Sie die Bibliothek in mehreren Threads verwenden.

Wir empfehlen dringend, dass Sie **nicht** eine einzelne [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Instanz in einer Multi‑Threading‑Umgebung verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht zu erkennen sind. 

Es ist **nicht** sicher, eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Solche Vorgänge werden **nicht** unterstützt. Wenn Sie solche Aufgaben ausführen müssen, müssen Sie die Vorgänge mithilfe mehrerer Single‑Thread‑Prozesse parallelisieren – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden. 

## **Präsentationsfolien parallel in Bilder konvertieren**

Angenommen, wir möchten alle Folien einer PowerPoint‑Präsentation parallel in PNG‑Bilder konvertieren. Da die Verwendung einer einzelnen `Presentation` Instanz in mehreren Threads unsicher ist, teilen wir die Präsentationsfolien in separate Präsentationen auf und konvertieren die Folien parallel in Bilder, wobei jede Präsentation in einem eigenen Thread verwendet wird. Das folgende Codebeispiel zeigt, wie das geht.
```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extrahiere Folie i in eine separate Präsentation.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Konvertiere die Folie in ein Bild in einem separaten Task.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Warte, bis alle Tasks abgeschlossen sind.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```


## **FAQ**

**Muss ich die Lizenzkonfiguration in jedem Thread aufrufen?**

Nein. Es reicht aus, sie einmal pro Prozess/App‑Domain vor dem Start der Threads aufzurufen. Wenn [license setup](/slides/de/cpp/licensing/) gleichzeitig aufgerufen werden könnte (z. B. bei lazy‑Initialisierung), synchronisieren Sie diesen Aufruf, da die Lizenzsetup‑Methode selbst nicht thread‑sicher ist.

**Kann ich `Presentation`‑ oder `Slide`‑Objekte zwischen Threads übergeben?**

Das Übergeben von „Live“-Präsentationsobjekten zwischen Threads wird nicht empfohlen: Verwenden Sie unabhängige Instanzen pro Thread oder erstellen Sie separate Präsentationen/Slide‑Container für jeden Thread im Voraus. Dieser Ansatz folgt der allgemeinen Empfehlung, keine einzelne Präsentationsinstanz über Threads hinweg zu teilen.

**Ist es sicher, den Export in verschiedene Formate (PDF, HTML, Bilder) zu parallelisieren, vorausgesetzt, jeder Thread hat seine eigene `Presentation` Instanz?**

Ja. Bei unabhängigen Instanzen und separaten Ausgabepfaden lassen sich solche Aufgaben in der Regel korrekt parallelisieren; vermeiden Sie geteilte Präsentationsobjekte und geteilte I/O‑Streams.

**Was soll ich mit globalen Schriftarteinstellungen (Ordner, Ersatzschriften) im Multithreading tun?**

Initialisieren Sie alle globalen Schriftarteinstellungen, bevor Sie die Threads starten, und ändern Sie sie während der parallelen Verarbeitung nicht. Dadurch werden Rennen beim Zugriff auf geteilte Schriftressourcen vermieden.