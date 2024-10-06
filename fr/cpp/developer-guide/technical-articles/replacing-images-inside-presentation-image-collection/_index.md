---
title: Remplacement des Images dans la Collection d'Images de la Présentation
type: docs
weight: 90
url: /cpp/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides pour C++ vous permet de remplacer les images ajoutées dans les formes de diapositive. Dans cet article, vous apprendrez comment remplacer l'image ajoutée dans la collection d'images de présentation par différentes approches.

{{% /alert %}} 
## **Remplacer l'Image dans une Collection d'Images de Présentation**
Aspose.Slides pour C++ fournit une méthode API simple qui vous permet de remplacer l'image dans une collection d'images de présentation de cette manière :

1. Chargez le fichier de présentation avec une image à l'intérieur en utilisant la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Chargez une image à partir d'un fichier dans un tableau d'octets.
1. Utilisez l'une de ces approches :
   - Première approche : Remplacez l'image cible par la nouvelle image dans le tableau d'octets.
   - Deuxième approche : Chargez l'image dans un objet [Image](https://reference.aspose.com/slides/cpp/class/system.drawing.image) et remplacez l'image cible par l'image chargée.
   - Troisième approche : Remplacez l'image par l'image déjà ajoutée dans la collection d'images de présentation.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code exemple vous montre comment remplacer l'image dans une collection d'images de présentation :

``` cpp
// Instancier la présentation
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"presentation.pptx");

// La première approche
ArrayPtr<uint8_t> data = ReadAllBytes(u"image0.jpeg");
SharedPtr<IPPImage> oldImage = presentation->get_Images()->idx_get(0);
oldImage->ReplaceImage(data);

// La deuxième approche
SharedPtr<IImage> newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Images()->idx_get(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// La troisième approche
oldImage = presentation->get_Images()->idx_get(2);
oldImage->ReplaceImage(presentation->get_Images()->idx_get(3));

// Enregistrer la présentation
presentation->Save(u"c:\\Presentations\\TestSmart.pptx", SaveFormat::Pptx);
```