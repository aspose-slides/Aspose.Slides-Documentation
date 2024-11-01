---
title: Convertir Presentación a Tiff con Notas
type: docs
weight: 50
url: /es/net/convert-presentation-to-tiff-with-notes/
---

TIFF es uno de varios formatos de imagen ampliamente utilizados que Aspose.Slides para .NET admite para convertir una presentación con notas a imágenes. También puedes generar miniaturas de diapositivas en la vista de Diapositiva de Notas. A continuación se muestran dos fragmentos de código que muestran cómo generar imágenes TIFF de una presentación en vista de Diapositiva de Notas.

El método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) expuesto por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) se puede usar para convertir toda la presentación en la vista de Diapositiva de Notas a TIFF. También puedes generar una miniatura de diapositiva en la vista de Diapositiva de Notas para diapositivas individuales.
## **Ejemplo**

``` 

  //Instanciar un objeto Presentation que representa un archivo de presentación

 Presentation pres = new Presentation("Conversion.pptx");

 //Guardar la presentación en TIFF con notas

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Descargar Ejemplo en Ejecución**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Tiff conversion with note/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Descargar Código de Ejemplo**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Para más detalles, visita [Convertir Presentación con Notas](/slides/es/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/).

{{% /alert %}}