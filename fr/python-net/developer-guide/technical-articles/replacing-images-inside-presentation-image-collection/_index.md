---
title: Remplacer des Images dans la Collection d'Images de Présentation
type: docs
weight: 110
url: /fr/python-net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides pour Python via .NET permet de remplacer les images ajoutées dans les formes de diapositive. Cet article explique comment remplacer l'image ajoutée dans la collection d'images de présentation en utilisant différentes approches.

{{% /alert %}} 
## **Remplacer une Image dans la Collection d'Images de Présentation**
Aspose.Slides pour Python via .NET fournit des méthodes API simples pour remplacer les images dans la collection d'images de présentation. Veuillez suivre les étapes ci-dessous :

1. Chargez le fichier de présentation contenant l'image en utilisant la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Chargez une image depuis un fichier dans un tableau d'octets.
1. Remplacez l'image cible par la nouvelle image dans le tableau d'octets.
1. Dans la deuxième approche, chargez l'image dans un objet Image et remplacez l'image cible par l'image chargée.
1. Dans la troisième approche, remplacez l'image par une image déjà ajoutée dans la collection d'images de présentation.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()

#Instancier la présentation
with slides.Presentation("pres.pptx") as presentation:

    #la première manière
    data = read_all_bytes("image_0.jpeg")
    oldImage = presentation.images[0]
    oldImage.replace_image(data)

    #la deuxième manière
    newImage = slides.Images.from_file("image_1.jpeg")
    oldImage = presentation.images[1]
    oldImage.replace_image(newImage)

    #la troisième manière
    oldImage = presentation.images[2]
    oldImage.replace_image(presentation.images[3])

    #Sauvegarder la présentation
    presentation.save("replace_image-out.pptx", slides.export.SaveFormat.PPTX)
```