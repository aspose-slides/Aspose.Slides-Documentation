---
title: Conversión de formato PPT a PPTX en Aspose.Slides
type: docs
weight: 10
url: /es/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---

**Aspose.Slides** para .NET ahora facilita a los desarrolladores el acceso al PPT utilizando una instancia de la clase Presentation y convirtiéndola al formato PPTX respectivo. Actualmente, admite la conversión parcial de PPT a PPTX. Para más detalles sobre qué funciones son compatibles y cuáles no en la conversión de PPT a PPTX, por favor procede a este enlace de documentación.

**Aspose.Slides** para .NET ofrece la clase Presentation que representa un archivo de presentación PPTX. La clase Presentation también puede acceder a PPT a través de Presentation cuando el objeto es instanciado.

``` csharp

 //Instantiate a Presentation object that represents a PPTX file

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Saving the PPTX presentation to PPTX format

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Descargar código de muestra**
- [Codeplex](http://goo.gl/LklO0x)
- [Github](https://github.com/asposemarketplace/Aspose_for_OpenXML/releases/download/6/Conversion.PPT.to.PPTX.Aspose.Slides.zip)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)