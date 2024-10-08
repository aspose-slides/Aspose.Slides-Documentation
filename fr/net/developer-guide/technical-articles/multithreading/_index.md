---
title: Multithreading dans Aspose.Slides
type: docs
weight: 310
url: /fr/net/multithreading/
keywords:
- PowerPoint
- présentation
- multithreading
- travail parallèle
- convertir des diapositives
- diapositives en images
- C#
- .NET
- Aspose.Slides pour .NET
---

## **Introduction**

Bien que le travail parallèle avec des présentations soit possible (en plus de l'analyse/le chargement/le clonage) et que tout se passe bien (la plupart du temps), il y a une petite chance que vous obteniez des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous vous recommandons fortement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) dans un environnement multi-threading car cela pourrait entraîner des erreurs ou des échecs imprévisibles qui ne sont pas facilement détectés.

Il **n'est pas** sûr de charger, d'enregistrer et/ou de cloner une instance d'une classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) dans plusieurs threads. De telles opérations **ne sont pas** supportées. Si vous devez effectuer de telles tâches, vous devez paralléliser les opérations en utilisant plusieurs processus à thread unique—et chacun de ces processus doit utiliser sa propre instance de présentation.

## **Convertir les diapositives de présentation en images en parallèle**

Disons que nous voulons convertir toutes les diapositives d'une présentation PowerPoint en images PNG en parallèle. Comme il est dangereux d'utiliser une seule instance de `Presentation` dans plusieurs threads, nous divisons les diapositives de présentation en présentations séparées et convertissons les diapositives en images en parallèle, en utilisant chaque présentation dans un thread séparé. L'exemple de code suivant montre comment procéder.

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
    // Extraire la diapositive i dans une présentation séparée.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Convertir la diapositive en image dans une tâche séparée.
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