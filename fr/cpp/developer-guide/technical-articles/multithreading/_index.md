---
title: Multithreading dans Aspose.Slides
type: docs
weight: 200
url: /cpp/multithreading/
keywords:
- PowerPoint
- présentation
- multithreading
- travail parallèle
- convertir des diapositives
- diapositives en images
- C++
- Aspose.Slides pour C++
---

## **Introduction**

Bien que le travail parallèle avec des présentations soit possible (en dehors de l'analyse/le chargement/le clonage) et que tout se déroule bien (la plupart du temps), il existe une petite chance que vous obteniez des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous recommandons fortement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) dans un environnement multithread, car cela pourrait entraîner des erreurs ou des défaillances imprévisibles qui ne sont pas facilement détectées.

Il **n'est pas** sûr de charger, enregistrer et/ou cloner une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) dans plusieurs threads. De telles opérations **ne sont pas** supportées. Si vous devez effectuer de telles tâches, vous devez paralléliser les opérations en utilisant plusieurs processus à thread unique, et chacun de ces processus doit utiliser sa propre instance de présentation.

## **Convertir les diapositives de présentation en images en parallèle**

Disons que nous voulons convertir toutes les diapositives d'une présentation PowerPoint en images PNG en parallèle. Puisqu'il est dangereux d'utiliser une seule instance de `Presentation` dans plusieurs threads, nous divisons les diapositives de la présentation en présentations séparées et convertissons les diapositives en images en parallèle, en utilisant chaque présentation dans un thread séparé. L'exemple de code suivant montre comment faire cela.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extraire la diapositive i dans une présentation séparée.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Convertir la diapositive en image dans une tâche séparée.
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

// Attendre que toutes les tâches soient terminées.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```