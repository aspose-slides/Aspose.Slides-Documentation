---
title: En-tête et pied de page
type: docs
weight: 220
url: /fr/python-net/examples/elements/header-footer/
keywords:
- en-tête et pied de page
- ajouter en-tête et pied de page
- mettre à jour en-tête et pied de page
- définir la date et l'heure
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Contrôlez les en-têtes et pieds de page en Python avec Aspose.Slides : ajoutez ou modifiez la date/heure, les numéros de diapositive et le texte du pied de page, affichez ou masquez les espaces réservés dans les formats PPT, PPTX et ODP."
---
Montre comment ajouter des pieds de page et mettre à jour les espaces réservés de date et d'heure en utilisant **Aspose.Slides for Python via .NET**.

## **Ajouter un pied de page**

Ajoutez du texte dans la zone de pied de page d'une diapositive et rendez-le visible.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Mettre à jour la date et l'heure**

Modifiez l'espace réservé de date et d'heure sur une diapositive.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```