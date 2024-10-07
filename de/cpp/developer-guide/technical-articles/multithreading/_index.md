---
title: Multithreading in Aspose.Slides
type: docs
weight: 200
url: /cpp/multithreading/
keywords:
- PowerPoint
- Präsentation
- Multithreading
- paralleles Arbeiten
- Folien konvertieren
- Folien zu Bildern
- C++
- Aspose.Slides für C++
---

## **Einleitung**

Während paralleles Arbeiten mit Präsentationen möglich ist (neben dem Parsen/Laden/Klonen) und in den meisten Fällen gut funktioniert, besteht eine kleine Chance, dass Sie falsche Ergebnisse erhalten, wenn Sie die Bibliothek in mehreren Threads verwenden.

Wir empfehlen dringend, eine einzelne [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Instanz in einer Multithreading-Umgebung **nicht** zu verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht zu erkennen sind.

Es ist **nicht** sicher, eine Instanz einer [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Solche Operationen werden **nicht** unterstützt. Wenn Sie solche Aufgaben ausführen müssen, müssen Sie die Operationen mit mehreren einaramigen Prozessen parallelisieren – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden.

## **Präsentationsfolien parallel in Bilder umwandeln**

Nehmen wir an, wir möchten alle Folien aus einer PowerPoint-Präsentation parallel in PNG-Bilder umwandeln. Da es unsicher ist, eine einzelne `Presentation` Instanz in mehreren Threads zu verwenden, teilen wir die Präsentationsfolien in separate Präsentationen auf und konvertieren die Folien parallel in Bilder, wobei wir jede Präsentation in einem separaten Thread verwenden. Das folgende Codebeispiel zeigt, wie dies geht.

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

    // Konvertiere die Folie in ein Bild in einer separaten Aufgabe.
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

// Warten Sie, bis alle Aufgaben abgeschlossen sind.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```