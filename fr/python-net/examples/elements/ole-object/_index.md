---
title: ObjetOLE
type: docs
weight: 210
url: /fr/python-net/examples/elements/ole-object/
keywords:
- objet OLE
- ajouter objet OLE
- accéder objet OLE
- supprimer objet OLE
- mettre à jour objet OLE
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Travaillez avec des objets OLE en Python à l'aide d'Aspose.Slides: insérez ou mettez à jour des fichiers incorporés, définissez des icônes ou des liens, extrayez le contenu, contrôlez le comportement pour PPT, PPTX et ODP."
---
Démontre comment incorporer un fichier en tant qu'objet OLE et mettre à jour ses données à l'aide de **Aspose.Slides for Python via .NET**.

## **Ajouter un objet OLE**

Incorporez un fichier PDF dans la présentation.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Charger les données PDF à incorporer.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Ajouter un cadre d'objet OLE à la diapositive.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à un objet OLE**

Récupérez le premier cadre d'objet OLE sur une diapositive.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Obtenir le premier cadre d'objet OLE sur la diapositive.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Supprimer un objet OLE**

Supprimez un objet OLE incorporé de la diapositive.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Supposant que la première forme est un objet OleObjectFrame.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Mettre à jour les données d'un objet OLE**

Remplacez les données incorporées dans un objet OLE existant.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # En supposant que la première forme est un objet OleObjectFrame.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Mettre à jour l'objet OLE avec les nouvelles données incorporées.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```