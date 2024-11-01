---
title: Conversion de format PPT à PPTX dans Aspose.Slides
type: docs
weight: 10
url: /fr/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---

**Aspose.Slides** pour .NET facilite désormais aux développeurs l'accès au PPT en utilisant une instance de la classe Presentation et en le convertissant au format PPTX respectif. Actuellement, il prend en charge la conversion partielle de PPT à PPTX. Pour plus de détails sur les fonctionnalités prises en charge et non prises en charge dans la conversion de PPT à PPTX, veuillez consulter ce lien de documentation.

**Aspose.Slides** pour .NET propose la classe Presentation qui représente un fichier de présentation PPTX. La classe Presentation peut également accéder au PPT via Presentation lorsque l'objet est instancié.

``` csharp

 //Instancier un objet Presentation qui représente un fichier PPTX

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Sauvegarder la présentation PPTX au format PPTX

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Télécharger le code exemple**
- [Codeplex](http://goo.gl/LklO0x)
- [Github](https://github.com/asposemarketplace/Aspose_for_OpenXML/releases/download/6/Conversion.PPT.to.PPTX.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)