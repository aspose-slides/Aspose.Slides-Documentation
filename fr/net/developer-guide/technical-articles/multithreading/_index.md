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
- convertir les diapositives
- diapositives en images
- C#
- .NET
- Aspose.Slides pour .NET
---

## **Introduction**

Bien que le travail parallèle avec les presentations soit possible (en dehors du parsing/loading/cloning) et que tout se passe bien (la plupart du temps), il existe une petite chance d'obtenir des résultats incorrects lorsque vous utilisez la bibliotheque dans plusieurs threads.

Nous recommandons fortement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) dans un environnement multithreading, car cela pourrait entraîner des erreurs ou des echecs imprevisibles qui ne sont pas facilement detects.

Il n'est **pas** sûr de charger, d'enregistrer et/ou de cloner une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) dans plusieurs threads. De telles operations ne sont **pas** prises en charge. Si vous devez effectuer ces taches, vous devez paralleliser les operations en utilisant plusieurs processus monothread et chaque processus doit utiliser sa propre instance de presentation.

## **Convertir les diapositives de la presentation en images en parallel**

Supposons que nous voulions convertir toutes les diapositives d'une presentation PowerPoint en images PNG en parallel. Comme il n'est pas sûr d'utiliser une seule instance `Presentation` dans plusieurs threads, nous separeons les diapositives de la presentation en presentations distinctes et convertissons les diapositives en images en parallel, chaque presentation etant utilisee dans un thread separe. L'exemple de code suivant montre comment proceder.
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


## **FAQ**

**Dois-je appeler la configuration de licence dans chaque thread?**

Non. Il suffit de le faire une fois par processus/domaine d'application avant le demarrage des threads. Si la [license setup](/slides/fr/net/licensing/) peut etre invoquee simultanee (par exemple, lors d'une initialisation paresseuse), synchronisez cet appel car la methode de configuration de licence elle-meme n'est pas sure pour le multithreading.

**Puis-je passer des objets `Presentation` ou `Slide` entre les threads?**

Passer des objets de presentation "actifs" entre les threads n'est pas recommande: utilisez des instances independantes par thread ou precreez des presentations/containers de diapositives separes pour chaque thread. Cette approche suit la recommandation generale de ne pas partager une seule instance de presentation entre les threads.

**Est-il sûr de paralleliser l'exportation vers différents formats (PDF, HTML, images) a condition que chaque thread dispose de sa propre instance `Presentation`?**

Oui. Avec des instances independantes et des chemins de sortie distincts, ces taches se paralelisent generalement correctement; evitez tout objet de presentation partage ainsi que les flux d'E/S partages.

**Que faut-il faire avec les paramètres de police globaux (dossiers, substitutions) en multithreading?**

Initialisez tous les parametres de police globaux avant de demarrer les threads et ne les modifiez pas pendant le travail parallel. Cela elimine les conditions de concurrence lors de l'acces aux ressources de police partagees.