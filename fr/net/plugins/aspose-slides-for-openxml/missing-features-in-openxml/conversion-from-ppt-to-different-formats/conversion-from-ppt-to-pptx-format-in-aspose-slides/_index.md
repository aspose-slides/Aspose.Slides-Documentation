---
title: Conversion du format PPT en PPTX dans Aspose.Slides
type: docs
weight: 10
url: /fr/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---

**Aspose.Slides** pour .NET permet désormais aux développeurs d'accéder au PPT à l'aide d'une instance de la classe Presentation et de le convertir au format PPTX correspondant. Actuellement, il prend en charge la conversion partielle du PPT en PPTX. Pour plus de détails sur les fonctionnalités prises en charge et non prises en charge dans la conversion PPT vers PPTX, veuillez consulter ce lien de documentation.

**Aspose.Slides** pour .NET propose la classe Presentation qui représente un fichier de présentation PPTX. La classe Presentation peut désormais également accéder aux PPT via Presentation lorsqu'un objet est instancié.

``` csharp

 //Instantiate a Presentation object that represents a PPTX file

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Saving the PPTX presentation to PPTX format

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Télécharger le code d'exemple**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)