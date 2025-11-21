---
title: Multithreading dans Aspose.Slides pour .NET
linktitle: Multithreading
type: docs
weight: 310
url: /fr/net/multithreading/
keywords:
- multithreading
- plusieurs threads
- travail parallèle
- conversion de diapositives
- diapositives en images
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Le multithreading d'Aspose.Slides pour .NET optimise le traitement de PowerPoint et d'OpenDocument. Découvrez les meilleures pratiques pour des flux de travail de présentation efficaces."
---

## **Introduction**

Bien que le travail parallèle avec des présentations soit possible (en dehors de l’analyse/le chargement/le clonage) et que tout se passe généralement bien, il existe une petite probabilité d’obtenir des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous vous recommandons fortement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) dans un environnement multithread, car cela pourrait entraîner des erreurs ou des échecs imprévisibles difficiles à détecter.

Il n’est **pas** sûr de charger, enregistrer et/ou cloner une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) dans plusieurs threads. De telles opérations ne sont **pas** prises en charge. Si vous devez effectuer ces tâches, vous devez paralléliser les opérations en utilisant plusieurs processus monothreads, chaque processus devant disposer de sa propre instance de présentation.

## **Convertir les diapositives d’une présentation en images en parallèle**

Supposons que nous voulions convertir toutes les diapositives d’une présentation PowerPoint en images PNG en parallèle. Comme il n’est pas sûr d’utiliser une seule instance `Presentation` dans plusieurs threads, nous divisons les diapositives de la présentation en présentations distinctes et convertissons les diapositives en images en parallèle, chaque présentation étant utilisée dans un thread séparé. L’exemple de code suivant montre comment procéder.
```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Extraire la diapositive i dans une présentation distincte.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Convertir la diapositive en image dans une tâche distincte.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```


## **FAQ**

**Dois‑je appeler la configuration de licence dans chaque thread ?**

Non. Il suffit de le faire une fois par processus/domaine d’application avant le démarrage des threads. Si [license setup](/slides/fr/net/licensing/) peut être invoqué simultanément (par exemple, lors d’une initialisation paresseuse), synchronisez cet appel car la méthode de configuration de licence elle‑même n’est pas sûre pour les threads.

**Puis‑je transmettre des objets `Presentation` ou `Slide` entre les threads ?**

Il n’est pas recommandé de transmettre des objets de présentation « vivants » entre les threads : utilisez des instances indépendantes par thread ou pré‑créez des présentations/conteneurs de diapositives séparés pour chaque thread. Cette approche suit la recommandation générale de ne pas partager une seule instance de présentation entre les threads.

**Est‑il sûr de paralléliser l’exportation vers différents formats (PDF, HTML, images) à condition que chaque thread ait sa propre instance `Presentation` ?**

Oui. Avec des instances indépendantes et des chemins de sortie séparés, ces tâches se parallélisent généralement correctement ; évitez tout objet de présentation partagé et les flux d’E/S communs.

**Que faire des paramètres de police globaux (dossiers, substitutions) en multithreading ?**

Initialisez tous les paramètres de police globaux avant de démarrer les threads et ne les modifiez pas pendant le travail parallèle. Cela supprime les conflits d’accès aux ressources de police partagées.