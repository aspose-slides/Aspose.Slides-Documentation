---
title: Multithreading dans Aspose.Slides pour Python
linktitle: Multithreading
type: docs
weight: 200
url: /fr/python-net/multithreading/
keywords:
- multithread
- plusieurs threads
- travail parallèle
- convertir des diapositives
- diapositives en images
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Aspose.Slides pour Python via le multithreading .NET améliore le traitement PowerPoint et OpenDocument. Découvrez les meilleures pratiques pour des flux de travail de présentation efficaces."
---

## **Introduction**

Bien que le travail parallèle avec les présentations soit possible (en plus de l’analyse/le chargement/le clonage) et que tout se passe bien (la plupart du temps), il existe une petite probabilité d’obtenir des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous vous recommandons vivement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dans un environnement multithread, car cela pourrait entraîner des erreurs ou des pannes imprévisibles difficilement détectables. 

Il n’est **pas** sûr de charger, enregistrer et/ou cloner une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dans plusieurs threads. De telles opérations ne sont **pas** prises en charge. Si vous devez réaliser ces tâches, vous devez paralléliser les opérations en utilisant plusieurs processus monothreads — et chaque processus doit utiliser sa propre instance de présentation. 

## **Convertir les diapositives de présentation en images en parallèle**

Supposons que nous voulions convertir toutes les diapositives d’une présentation PowerPoint en images PNG en parallèle. Comme il n’est pas sûr d’utiliser une seule instance `Presentation` dans plusieurs threads, nous divisons les diapositives de la présentation en présentations séparées et convertissons les diapositives en images en parallèle, chaque présentation étant utilisée dans un thread distinct. L’exemple de code suivant montre comment procéder.
```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Extraire la diapositive i dans une présentation distincte.
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

# Attendre que toutes les tâches soient terminées.
for task in conversion_tasks:
    task.result()

del presentation
```


## **FAQ**

**Do I need to call license setup in every thread?**

Non. Il suffit de le faire une fois par processus/domaine d’application avant le démarrage des threads. Si la [configuration de licence](/slides/fr/python-net/licensing/) peut être invoquée simultanément (par exemple, lors d’une initialisation paresseuse), synchronisez cet appel car la méthode de configuration de licence elle‑même n’est pas thread‑safe.

**Can I pass `Presentation` or `Slide` objects between threads?**

Il n’est pas recommandé de transmettre des objets de présentation « vivants » entre les threads : utilisez des instances indépendantes par thread ou créez à l’avance des présentations/conteneurs de diapositives séparés pour chaque thread. Cette approche suit la recommandation générale de ne pas partager une même instance de présentation entre les threads.

**Is it safe to parallelize export to different formats (PDF, HTML, images) provided each thread has its own `Presentation` instance?**

Oui. Avec des instances indépendantes et des chemins de sortie séparés, ces tâches se parallélisent généralement correctement ; évitez tout partage d’objets de présentation et de flux d’E/S.

**What should I do with global font settings (folders, substitutions) in multithreading?**

Initialisez tous les paramètres de police globaux avant de démarrer les threads et ne les modifiez pas pendant le travail parallèle. Cela élimine les courses d’accès aux ressources de police partagées.