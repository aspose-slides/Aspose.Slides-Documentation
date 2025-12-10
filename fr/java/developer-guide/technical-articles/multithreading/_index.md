---
title: Multithreading dans Aspose.Slides pour Java
linktitle: Multithreading
type: docs
weight: 310
url: /fr/java/multithreading/
keywords:
- multithreading
- threads multiples
- travail parallèle
- convertir les diapositives
- diapositives en images
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Le multithreading d'Aspose.Slides pour Java améliore le traitement de PowerPoint et OpenDocument. Découvrez les meilleures pratiques pour des flux de travail de présentation efficaces."
---

## **Introduction**

Bien que le travail parallèle avec des présentations soit possible (en dehors de l'analyse/le chargement/le clonage) et que tout se passe bien (la plupart du temps), il existe une petite chance d'obtenir des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous vous recommandons fortement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) dans un environnement multi-thread car cela pourrait entraîner des erreurs ou des échecs imprévisibles qui ne sont pas facilement détectés.

Il n'est **pas** sûr de charger, enregistrer et/ou cloner une instance d'une classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) dans plusieurs threads. De telles opérations ne sont **pas** prises en charge. Si vous devez effectuer ces tâches, vous devez paralléliser les opérations en utilisant plusieurs processus mono-thread - et chacun de ces processus doit utiliser sa propre instance de présentation.

## **Convertir les diapositives de présentation en images en parallèle**

Supposons que nous voulions convertir toutes les diapositives d'une présentation PowerPoint en images PNG en parallèle. Comme il n'est pas sûr d'utiliser une seule instance `Presentation` dans plusieurs threads, nous divisons les diapositives de la présentation en présentations distinctes et convertissons les diapositives en images en parallèle, chaque présentation étant utilisée dans un thread séparé. L'exemple de code suivant montre comment procéder.
```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extraire la diapositive i dans une présentation distincte.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Convertir la diapositive en image dans une tâche distincte.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
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
    }));
}

// Attendre que toutes les tâches soient terminées.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```


## **FAQ**

**Dois-je appeler la configuration de licence dans chaque thread ?**

Non. Il suffit de le faire une fois par processus/domaine d'application avant le démarrage des threads. Si la [configuration de licence](/slides/fr/java/licensing/) peut être invoquée simultanément (par exemple, lors d'une initialisation paresseuse), synchronisez cet appel car la méthode de configuration de licence elle‑même n'est pas sûre pour le multithreading.

**Puis-je passer des objets `Presentation` ou `Slide` entre les threads ?**

Passer des objets de présentation « actifs » entre les threads n'est pas recommandé : utilisez des instances indépendantes par thread ou pré‑créez des présentations/containers de diapositives séparés pour chaque thread. Cette approche suit la recommandation générale de ne pas partager une seule instance de présentation entre les threads.

**Est‑il sûr de paralléliser l'exportation vers différents formats (PDF, HTML, images) à condition que chaque thread possède sa propre instance `Presentation` ?**

Oui. Avec des instances indépendantes et des chemins de sortie séparés, ces tâches se parallélisent généralement correctement ; évitez tout objet de présentation partagé ainsi que les flux d'E/S partagés.

**Que dois‑je faire avec les paramètres globaux de police (dossiers, substitutions) en multithreading ?**

Initialisez tous les [paramètres de police](/slides/fr/java/powerpoint-fonts/) globaux avant de démarrer les threads et ne les modifiez pas pendant le travail parallèle. Cela élimine les conflits lors de l'accès aux ressources de police partagées.