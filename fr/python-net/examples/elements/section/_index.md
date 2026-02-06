---
title: Section
type: docs
weight: 90
url: /fr/python-net/examples/elements/section/
keywords:
- section
- section de diapositive
- ajouter une section
- accéder à une section
- supprimer une section
- renommer une section
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Gérez les sections de diapositives en Python avec Aspose.Slides : créez, renommez, réorganisez facilement, déplacez les diapositives entre les sections et contrôlez la visibilité pour PPT, PPTX et ODP."
---
Exemples de gestion des sections de présentation — ajouter, accéder, supprimer et renommer les sections de manière programmatique à l'aide de **Aspose.Slides for Python via .NET**.

## **Ajouter une section**

Créez une section qui commence à une diapositive spécifique.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Ajouter une nouvelle section et spécifier la diapositive qui marque le début de la section.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à une section**

Récupérez une section à partir d'une présentation.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Accéder à une section par indice.
        section = presentation.sections[0]
```

## **Supprimer une section**

Supprimez une section précédemment ajoutée.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Supprimer la section.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Renommer une section**

Changez le nom d'une section existante.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Renommer la section.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```