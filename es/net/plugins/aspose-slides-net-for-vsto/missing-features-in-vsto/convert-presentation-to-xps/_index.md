---
title: Convertir Presentación a XPS
type: docs
weight: 60
url: /es/net/convert-presentation-to-xps/
---

El formato **XPS** también se utiliza ampliamente para el intercambio de datos. Aspose.Slides para .NET tiene en cuenta su importancia y proporciona soporte integrado para convertir una presentación en un documento XPS.

El método **Save** expuesto por la clase Presentation se puede usar para convertir toda la presentación en un documento **XPS**. Además, la clase **XpsOptions** expone la propiedad **SaveMetafileAsPng** que se puede establecer en verdadero o falso según los requisitos.
## **Ejemplo**

``` 

//Instanciar un objeto Presentation que representa un archivo de presentación

Presentation pres = new Presentation("Conversion.ppt");

//Guardar la presentación en un documento TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Descargar Ejemplo en Funcionamiento**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to XPS/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Descargar Código de Ejemplo**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Para más detalles, visita [Conversión a XPS](/slides/es/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/).

{{% /alert %}}