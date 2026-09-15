---
title: Multithreading dans Aspose.Slides pour Python via Java
linktitle: Multithreading
type: docs
weight: 310
url: /fr/python-java/multithreading/
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
- Java
- Aspose.Slides
description: "Le multithreading d'Aspose.Slides pour Python via Java améliore le traitement de PowerPoint et d'OpenDocument. Découvrez les meilleures pratiques pour des flux de travail de présentation efficaces."
---
## **Introduction**

Bien que le travail parallèle avec les présentations soit possible (sauf pour l'analyse, le chargement et le clonage) et fonctionne généralement bien, il existe une petite chance d'obtenir des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous vous recommandons vivement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) dans un environnement multithread, car cela pourrait entraîner des erreurs ou des échecs imprévisibles qui ne sont pas facilement détectés.

Il n'est **pas** sûr de charger, enregistrer et/ou cloner une instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) dans plusieurs threads. De telles opérations ne sont **pas** prises en charge. Si vous devez effectuer ces tâches, vous devez paralléliser les opérations en utilisant plusieurs processus à thread unique — et chaque processus doit utiliser sa propre instance de présentation.

## **Convertir les diapositives de présentation en images en parallèle**

Supposons que nous voulions convertir toutes les diapositives d'une présentation PowerPoint en images PNG en parallèle. Comme il n'est pas sûr d'utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) dans plusieurs threads, nous divisons les diapositives de la présentation en présentations séparées et convertissons les diapositives en images en parallèle, en utilisant chaque présentation dans un thread distinct. L'exemple de code suivant montre comment procéder.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Extraire la diapositive dans une présentation distincte.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Convertir la diapositive en image dans une tâche distincte.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Attendre que toutes les tâches soient terminées.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **FAQ**

**Dois‑je appeler l'initialisation de licence dans chaque thread ?**

Non. Il suffit de le faire une fois par processus avant le démarrage des threads. Si [license setup](/slides/fr/python-java/licensing/) peut être invoqué concurrentiellement (par exemple, lors d'une initialisation paresseuse), synchronisez cet appel car la méthode d'initialisation de licence elle‑elle n'est pas thread‑safe.

**Puis‑je passer des objets [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) ou [Slide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/) entre des threads ?**

Passer des objets de présentation « en cours d'utilisation » entre des threads n'est pas recommandé : utilisez des instances indépendantes par thread ou créez des présentations ou des conteneurs de diapositives séparés pour chaque thread à l'avance. Cette approche suit la recommandation générale de ne pas partager une seule instance de présentation entre les threads.

**Est‑il sûr de paralléliser l'exportation vers différents formats (PDF, HTML, images) à condition que chaque thread possède sa propre instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) ?**

Oui. Avec des instances indépendantes et des chemins de sortie distincts, ces tâches se parallélisent généralement correctement ; évitez tout objet de présentation partagé ainsi que les flux d'E/S partagés.

**Que dois‑je faire avec les paramètres de police globaux (dossiers, substitutions) en multithreading ?**

Initialisez tous les [font settings](/slides/fr/python-java/powerpoint-fonts/) globaux avant de démarrer les threads et ne les modifiez pas pendant le travail parallèle. Cela élimine les conditions de concurrence lors de l'accès aux ressources de police partagées.