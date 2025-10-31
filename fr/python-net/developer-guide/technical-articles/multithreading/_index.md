---
title: Multithreading dans Aspose.Slides pour Python
linktitle: Multithreading
type: docs
weight: 200
url: /fr/python-net/multithreading/
keywords:
- multithreading
- plusieurs threads
- travail parallèle
- convertir les diapositives
- diapositives en images
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Le multithreading Aspose.Slides for Python via .NET améliore le traitement des fichiers PowerPoint et OpenDocument. Découvrez les meilleures pratiques pour des flux de travail de présentations efficaces."
---

## **Introduction**

Bien que le travail parallèle avec les présentations soit possible (en plus de l'analyse/chargement/clonage) et que tout se passe bien (la plupart du temps), il existe une petite chance d'obtenir des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous recommandons fortement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dans un environnement multi‑thread car cela peut entraîner des erreurs ou des échecs imprévisibles difficilement détectables. 

Il n'est **pas** sûr de charger, enregistrer et/ou cloner une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dans plusieurs threads. De telles opérations ne sont **pas** prises en charge. Si vous devez effectuer ces tâches, vous devez paralléliser les opérations en utilisant plusieurs processus monothread – chaque processus doit alors utiliser sa propre instance de présentation. 

## **Convertir les diapositives d’une présentation en images en parallèle**

Disons que nous voulons convertir toutes les diapositives d’une présentation PowerPoint en images PNG en parallèle. Comme il n'est pas sûr d'utiliser une seule instance `Presentation` dans plusieurs threads, nous séparons les diapositives de la présentation en présentations distinctes et convertissons les diapositives en images en parallèle, chaque présentation étant utilisée dans un thread séparé. L'exemple de code suivant montre comment faire.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Extraire la diapositive i dans une présentation séparée.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Convertir la diapositive en image.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Wait for all tasks to complete.
for task in conversion_tasks:
    task.result()

del presentation
```

## **FAQ**

**Dois-je appeler la configuration de licence dans chaque thread ?**

Non. Il suffit de le faire une fois par processus/domaine d'application avant le démarrage des threads. Si [license setup](/slides/fr/python-net/licensing/) peut être invoqué simultanément (par exemple, lors d'une initialisation paresseuse), synchronisez cet appel car la méthode de configuration de licence elle‑-même n'est pas sûre en environnement multithread.

**Puis-je passer des objets `Presentation` ou `Slide` entre les threads ?**

Passer des objets de présentation « vivants » entre les threads n'est pas recommandé : utilisez des instances indépendantes par thread ou pré‑créez des présentations/conteneurs de diapositives distincts pour chaque thread. Cette approche suit la recommandation générale de ne pas partager une seule instance de présentation entre les threads.

**Est‑il sûr de paralléliser l'exportation vers différents formats (PDF, HTML, images) à condition que chaque thread dispose de sa propre instance de `Presentation` ?**

Oui. Avec des instances indépendantes et des chemins de sortie séparés, ces tâches se parallélisent généralement correctement ; évitez tout partage d'objets de présentation et de flux d'E/S.

**Que faire des paramètres de police globaux (dossiers, substitutions) en multithreading ?**

Initialisez tous les paramètres de police globaux avant de démarrer les threads et ne les modifiez pas pendant le travail parallèle. Cela élimine les conditions de concurrence lors de l'accès aux ressources de police partagées.