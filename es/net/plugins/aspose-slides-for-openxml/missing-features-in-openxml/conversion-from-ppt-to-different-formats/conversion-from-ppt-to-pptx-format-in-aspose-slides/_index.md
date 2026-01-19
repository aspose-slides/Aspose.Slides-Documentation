---
title: Conversión de PPT a formato PPTX en Aspose.Slides
type: docs
weight: 10
url: /es/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---

**Aspose.Slides** para .NET ahora permite a los desarrolladores acceder al PPT mediante una instancia de la clase Presentation y convertirlo al formato PPTX correspondiente. Actualmente, admite la conversión parcial de PPT a PPTX. Para obtener más detalles sobre qué características son compatibles e incompatibles en la conversión de PPT a PPTX, diríjase a este enlace de documentación.

**Aspose.Slides** para .NET ofrece la clase Presentation que representa un archivo de presentación PPTX. La clase Presentation ahora también puede acceder a PPT a través de Presentation cuando se instancia el objeto.

``` csharp
 //Instanciar un objeto Presentation que representa un archivo PPTX
PresentationEx pres = new PresentationEx("Conversion.ppt");

//Guardar la presentación PPTX en formato PPTX
pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);
``` 
## **Descargar código de ejemplo**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)