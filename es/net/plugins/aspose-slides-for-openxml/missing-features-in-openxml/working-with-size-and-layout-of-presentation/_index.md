---
title: Trabajar con el tamaño y el diseño de la presentación
type: docs
weight: 90
url: /es/net/working-with-size-and-layout-of-presentation/
---

**SlideSize.Type** and **SlideSize.Size** son las propiedades de la clase Presentation que pueden establecerse u obtenerse como se muestra a continuación en el ejemplo.
## **Ejemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Instantiate a Presentation object that represents a presentation file 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Set the slide size of generated presentations to that of source

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Save Presentation to disk

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Descargar código de ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Descargar ejemplo en ejecución**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 

Para más detalles, visite [Cambiar el tamaño de diapositiva de la presentación en .NET](/slides/es/net/slide-size/).

{{% /alert %}}