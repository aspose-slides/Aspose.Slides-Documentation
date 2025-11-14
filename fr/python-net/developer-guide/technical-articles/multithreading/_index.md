---
title: Multithreading dans Aspose.Slides
type: docs
weight: 200
url: /fr/python-net/multithreading/
keywords:
- PowerPoint
- présentation
- multithreading
- travail parallèle
- convertir les diapositives
- diapositives en images
- Python
- Aspose.Slides pour Python
---

## **Introduction**

Bien que le travail parallèle avec des présentations soit possible (en dehors de l'analyse/le chargement/le clonage) et que tout se passe bien (la plupart du temps), il y a une petite chance que vous obteniez des résultats incorrects lorsque vous utilisez la bibliothèque dans plusieurs threads.

Nous vous recommandons fortement de **ne pas** utiliser une seule instance de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dans un environnement multi-thread car cela peut entraîner des erreurs ou des échecs imprévisibles qui ne sont pas facilement détectés.

Il est **non** sûr de charger, sauvegarder et/ou cloner une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dans plusieurs threads. De telles opérations **ne sont pas** supportées. Si vous devez effectuer de telles tâches, vous devez paralléliser les opérations en utilisant plusieurs processus à thread unique—et chacun de ces processus doit utiliser sa propre instance de présentation.

## **Convertir les diapositives de présentation en images en parallèle**

Supposons que nous voulons convertir toutes les diapositives d'une présentation PowerPoint en images PNG en parallèle. Étant donné qu'il n'est pas sûr d'utiliser une seule instance de `Presentation` dans plusieurs threads, nous divisons les diapositives de la présentation en présentations séparées et convertissons les diapositives en images en parallèle, en utilisant chaque présentation dans un thread séparé. L'exemple de code suivant montre comment procéder.

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

        # Convertir la diapositive en une image.
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