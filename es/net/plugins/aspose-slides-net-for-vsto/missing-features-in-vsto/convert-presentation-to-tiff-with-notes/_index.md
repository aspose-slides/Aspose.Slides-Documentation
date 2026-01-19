---
title: Convertir presentación a Tiff con notas
type: docs
weight: 50
url: /es/net/convert-presentation-to-tiff-with-notes/
---

TIFF es uno de varios formatos de imagen ampliamente utilizados que Aspose.Slides para .NET admite para convertir una presentación con notas a imágenes. También puedes generar miniaturas de diapositivas en la vista de diapositiva de notas. A continuación se muestran dos fragmentos de código que demuestran cómo generar imágenes TIFF de una presentación en la vista de diapositiva de notas.

El método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) expuesto por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) puede usarse para convertir toda la presentación en la vista de diapositiva de notas a TIFF. También puedes generar una miniatura de diapositiva en la vista de diapositiva de notas para diapositivas individuales.
## **Example**

``` 

  //Instantiate a Presentation object that represents a presentation file

 Presentation pres = new Presentation("Conversion.pptx");

 //Saving the presentation to TIFF notes

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Download Running Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Para más detalles, visita [Convertir presentaciones de PowerPoint a TIFF con notas en .NET](/slides/es/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}