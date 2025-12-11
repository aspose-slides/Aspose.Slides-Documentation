---
title: Multithreading dans Aspose.Slides pour C++
linktitle: Multithreading
type: docs
weight: 200
url: /fr/cpp/multithreading/
keywords:
- multithreading
- threads multiples
- travail parallèle
- conversion de diapositives
- diapositives en images
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Le multithreading d'Aspose.Slides pour C++ améliore le traitement de PowerPoint et d'OpenDocument. Découvrez les meilleures pratiques pour des flux de travail de présentation efficaces."
---

## **Introduction**

Bien que le travail parallèle avec les présentations soit possible (en dehors de l'analyse/le chargement/le clonage) et que tout se passe bien (la plupart du temps), il existe une petite chance d'obtenir des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous vous recommandons fortement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) dans un environnement multithread, car cela pourrait entraîner des erreurs ou des pannes imprévisibles qui ne sont pas facilement détectées.

Il n'est **pas** sûr de charger, enregistrer et/ou cloner une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) dans plusieurs threads. De telles opérations ne sont **pas** prises en charge.  Si vous devez effectuer ces tâches, vous devez paralléliser les opérations en utilisant plusieurs processus monothread—et chacun de ces processus doit utiliser sa propre instance de présentation.

## **Convertir les diapositives d'une présentation en images en parallèle**

Supposons que nous voulions convertir toutes les diapositives d'une présentation PowerPoint en images PNG en parallèle. Comme il n'est pas sûr d'utiliser une seule instance `Presentation` dans plusieurs threads, nous divisons les diapositives de la présentation en présentations séparées et convertissons les diapositives en images en parallèle, chaque présentation étant utilisée dans un thread distinct. L'exemple de code suivant montre comment procéder.
```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extraire la diapositive i dans une présentation distincte.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Convertir la diapositive en image dans une tâche distincte.
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


## **FAQ**

**Dois‑je appeler la configuration de licence dans chaque thread ?**

Non. Il suffit de le faire une fois par processus/domaine d'application avant le démarrage des threads. Si la [license setup](/slides/fr/cpp/licensing/) peut être invoquée simultanément (par exemple, lors d'une initialisation différée), synchronisez cet appel car la méthode de configuration de licence n'est pas sûre pour le multithreading.

**Puis‑je passer des objets `Presentation` ou `Slide` entre les threads ?**

Passer des objets de présentation « vivants » entre les threads n'est pas recommandé : utilisez des instances indépendantes par thread ou pré‑créez des présentations/containers de diapositives distincts pour chaque thread. Cette approche suit la recommandation générale de ne pas partager une seule instance de présentation entre les threads.

**Est‑il sûr de paralléliser l'exportation vers différents formats (PDF, HTML, images) à condition que chaque thread dispose de sa propre instance `Presentation` ?**

Oui. Avec des instances indépendantes et des chemins de sortie distincts, ces tâches se parallélisent généralement correctement ; évitez tout objet de présentation partagé et tout flux d'E/S partagé.

**Que dois‑je faire avec les paramètres de police globaux (dossiers, substitutions) en multithreading ?**

Initialisez tous les paramètres de police globaux avant de démarrer les threads et ne les modifiez pas pendant le travail parallèle. Cela élimine les conditions de concurrence lors de l'accès aux ressources de police partagées.