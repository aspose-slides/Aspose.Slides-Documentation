---
title: Remplacement d'images dans la collection d'images de présentation
type: docs
weight: 80
url: /java/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides pour Java permet de remplacer des images dans les formes de diapositive. Cet article explique comment remplacer une image ajoutée à la collection d'images de présentation en utilisant différentes approches.

{{% /alert %}} 
## **Remplacement d'image dans la collection d'images de présentation**
Aspose.Slides pour Java fournit des méthodes API simples pour remplacer les images dans la collection d'images de présentation. Veuillez suivre les étapes ci-dessous :

1. Chargez le fichier de présentation contenant l'image en utilisant la classe Presentation.
1. Chargez une image depuis un fichier dans un tableau d'octets.
1. Remplacez l'image cible par la nouvelle image dans le tableau d'octets.
1. Dans la deuxième approche, chargez l'image dans un objet Image et remplacez l'image cible par l'image chargée.
1. Dans la troisième approche, remplacez l'image par une image déjà ajoutée dans la collection d'images de présentation.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

```java
//Instancier la présentation
Presentation presentation = new Presentation("presentation.pptx");

//la première méthode
byte[] data = Files.readAllBytes(Paths.get("image0.jpeg"));
IPPImage oldImage = presentation.getImages().get_Item(0);
oldImage.replaceImage(data);

//la deuxième méthode
IImage newImage = Images.fromFile("image1.png");
oldImage = presentation.getImages().get_Item(1);
oldImage.replaceImage(newImage);
newImage.dispose();

//la troisième méthode
oldImage = presentation.getImages().get_Item(2);
oldImage.replaceImage(presentation.getImages().get_Item(3));

//Enregistrer la présentation
presentation.save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
presentation.dispose();
```