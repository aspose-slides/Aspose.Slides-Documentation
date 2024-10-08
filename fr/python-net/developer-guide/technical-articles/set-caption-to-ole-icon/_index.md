---
title: Définir le titre de l'icône OLE
type: docs
weight: 160
url: /fr/python-net/set-caption-to-ole-icon/
---

Une nouvelle propriété **SubstitutePictureTitle** a été ajoutée à l'interface **IOleObjectFrame** et à la classe **OleObjectFrame**. Elle permet d'obtenir, de définir ou de changer le titre d'une icône OLE. L'extrait de code ci-dessous montre un exemple de création d'un objet Excel et de définition de son titre.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter un objet OLE à la diapositive
    with open("oleSourceFile.xlsx", "rb") as ole_stream:
        data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.read(), "xlsx")

    ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

    # Ajouter une image à la collection d'images de la présentation
    with slides.Images.from_file("oleIconFile.ico") as image:
        pp_image = presentation.images.add_image(image)

    # Définir l'image comme une icône pour l'objet OLE
    ole_frame.is_object_icon = True
    ole_frame.substitute_picture_format.picture.image = pp_image

    # Définir un titre pour l'icône OLE
    ole_frame.substitute_picture_title = "Exemple de titre"
```