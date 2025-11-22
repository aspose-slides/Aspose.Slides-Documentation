---
title: Multithreading dans Aspose.Slides
type: docs
weight: 310
url: /fr/nodejs-java/multithreading/
keywords:
- PowerPoint
- présentation
- multithreading
- travail parallèle
- convertir les diapositives
- diapositives en images
- JavaScript
- Aspose.Slides pour Node.js via Java
---

## **Introduction**

Bien que le travail parallèle avec les présentations soit possible (en dehors de l'analyse/le chargement/le clonage) et que tout se passe bien (la plupart du temps), il existe une petite possibilité d'obtenir des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous recommandons vivement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) dans un environnement multithread, car cela pourrait entraîner des erreurs ou des échecs imprévisibles qui ne sont pas facilement détectés.

Il n'est **pas** sûr de charger, enregistrer et/ou cloner une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) dans plusieurs threads. De telles opérations ne sont **pas** prises en charge. Si vous devez effectuer ces tâches, vous devez paralléliser les opérations en utilisant plusieurs processus monothreadés — et chacun de ces processus doit utiliser sa propre instance de présentation.

## **Convertir les diapositives de présentation en images en parallèle**

Supposons que nous voulions convertir toutes les diapositives d'une présentation PowerPoint en images PNG en parallèle. Puisqu'il n'est pas sûr d'utiliser une seule instance `Presentation` dans plusieurs threads, nous divisons les diapositives de la présentation en présentations séparées et convertissons les diapositives en images en parallèle, chaque présentation étant utilisée dans un thread distinct. L'exemple de code suivant montre comment procéder.
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
        // Extraire la diapositive i dans une présentation séparée.
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

    // Attendre que toutes les tâches soient terminées.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```


## **FAQ**

**Dois-je appeler la configuration de licence dans chaque thread ?**

Non. Il suffit de le faire une fois par processus/domaine d'application avant le démarrage des threads. Si la [license setup](/slides/fr/nodejs-java/licensing/) peut être appelée simultanément (par exemple, lors d'une initialisation paresseuse), synchronisez cet appel car la méthode de configuration de licence elle‑même n'est pas thread‑safe.

**Puis‑je transmettre des objets `Presentation` ou `Slide` entre les threads ?**

La transmission d'objets de présentation « vivants » entre les threads n'est pas recommandée : utilisez des instances indépendantes par thread ou pré‑créez des présentations/containers de diapositives distincts pour chaque thread. Cette approche suit la recommandation générale de ne pas partager une seule instance de présentation entre les threads.

**Est‑il sûr de paralléliser l'exportation vers différents formats (PDF, HTML, images) à condition que chaque thread dispose de sa propre instance `Presentation` ?**

Oui. Avec des instances indépendantes et des chemins de sortie séparés, ces tâches se parallélisent généralement correctement ; évitez tout objet de présentation partagé et tout flux d'E/S partagé.

**Que dois‑je faire avec les paramètres de police globaux (dossiers, substitutions) en multithreading ?**

Initialisez tous les paramètres de police globaux avant de démarrer les threads et ne les modifiez pas durant le travail parallèle. Cela élimine les conditions de course lors de l'accès aux ressources de police partagées.