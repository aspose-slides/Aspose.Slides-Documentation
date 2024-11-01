---
title: Trabajando con el Tamaño y el Diseño de la Presentación
type: docs
weight: 90
url: /es/net/working-with-size-and-layout-of-presentation/
---

**SlideSize.Type** y **SlideSize.Size** son las propiedades de la clase presentación que se pueden establecer o obtener como se muestra a continuación en el ejemplo.
## **Ejemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Trabajando Con Tamaño y Diseño.pptx";

//Instanciar un objeto Presentation que representa un archivo de presentación 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Establecer el tamaño de la diapositiva de las presentaciones generadas al de la fuente

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Guardar la presentación en disco

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Descargar Ejemplo en Ejecución**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Working With Size and Layout/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

Para más detalles, visita [Trabajando Con el Tamaño y el Diseño de Diapositiva](/slides/es/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}