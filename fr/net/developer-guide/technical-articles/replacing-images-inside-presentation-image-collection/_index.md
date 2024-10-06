---  
title: Remplacement des Images dans la Collection d'Images de Présentation  
type: docs  
weight: 110  
url: /net/replacing-images-inside-presentation-image-collection/  
---  

{{% alert color="primary" %}}  

Aspose.Slides pour .NET permet de remplacer les images ajoutées dans les formes de diapositives. Cet article explique comment remplacer l'image ajoutée dans la collection d'images de présentation en utilisant différentes approches.  

{{% /alert %}}  
## **Remplacer une Image dans la Collection d'Images de Présentation**  
Aspose.Slides pour .NET fournit des méthodes d'API simples pour remplacer les images dans la collection d'images de présentation. Veuillez suivre les étapes ci-dessous :  

1. Chargez le fichier de présentation avec une image à l'intérieur en utilisant la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
1. Chargez une image depuis un fichier dans un tableau d'octets.  
1. Remplacez l'image cible par la nouvelle image dans le tableau d'octets.  
1. Dans la deuxième approche, chargez l'image dans un objet Image et remplacez l'image cible par l'image chargée.  
1. Dans la troisième approche, remplacez l'image par une image déjà ajoutée dans la collection d'images de présentation.  
1. Écrivez la présentation modifiée sous forme de fichier PPTX.  

```c#  
//Instancier la présentation  
using Presentation presentation = new Presentation("presentation.pptx");  

//la première façon  
byte[] data = File.ReadAllBytes("image0.jpeg");  
IPPImage oldImage = presentation.Images[0];  
oldImage.ReplaceImage(data);  

//la deuxième façon  
using IImage newImage = Images.FromFile("image1.png");  
oldImage = presentation.Images[1];  
oldImage.ReplaceImage(newImage);  

//la troisième façon  
oldImage = presentation.Images[2];  
oldImage.ReplaceImage(presentation.Images[3]);  

//Sauvegarder la présentation  
presentation.Save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);  
```  