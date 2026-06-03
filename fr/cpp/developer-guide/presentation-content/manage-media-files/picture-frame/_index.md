---
title: Gérer les cadres d'image dans les présentations avec C++
linktitle: Cadre d'image
type: docs
weight: 10
url: /fr/cpp/picture-frame/
keywords:
- cadre d'image
- ajouter un cadre d'image
- créer un cadre d'image
- ajouter une image
- créer une image
- extraire une image
- image matricielle
- image vectorielle
- rogner une image
- zone rognée
- propriété StretchOff
- mise en forme du cadre d'image
- propriétés du cadre d'image
- mise à l'échelle relative
- effet d'image
- ratio d'aspect
- transparence d'image
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Ajoutez des cadres d'image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour C++. Simplifiez votre flux de travail et améliorez la conception des diapositives."
---
## **Introduction**

Un cadre d'image est une forme qui contient une image — c'est comme une image dans un cadre.  

Vous pouvez ajouter une image à une diapositive via un cadre d'image. Ainsi, vous pouvez formater l'image en formatant le cadre d'image.

{{% alert  title="Astuce" color="primary" %}} 
Aspose propose des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt)—qui permettent de créer rapidement des présentations à partir d'images. 
{{% /alert %}} 

## **Créer un cadre d'image**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).  
2. Obtenez la référence d'une diapositive via son index.  
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_p_p_image) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_image_collection) associée à l'objet présentation qui sera utilisé pour remplir la forme.  
4. Spécifiez la largeur et la hauteur de l'image.  
5. Créez un [PictureFrame](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.picture_frame) basé sur la largeur et la hauteur de l'image via la méthode `AddPictureFrame` exposée par l'objet forme associé à la diapositive référencée.  
6. Ajoutez un cadre d'image (contenant l'image) à la diapositive.