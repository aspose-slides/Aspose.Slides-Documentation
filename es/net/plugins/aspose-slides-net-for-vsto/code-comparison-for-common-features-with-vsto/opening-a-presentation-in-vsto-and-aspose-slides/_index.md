---
title: Abrir una presentación en VSTO y Aspose.Slides
type: docs
weight: 120
url: /es/net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
A continuación se muestra el fragmento de código para abrir una presentación:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides para .NET proporciona la clase **Presentation** que se utiliza para abrir una presentación existente. Ofrece varios constructores sobrecargados y podemos usar uno de los constructores adecuados de la clase **Presentation** para crear su objeto a partir de una presentación existente. En el ejemplo que se muestra a continuación, hemos pasado el nombre del archivo de la presentación (que se va a abrir) al constructor de la clase Presentation. Después de abrir el archivo, obtenemos el número total de diapositivas presentes en la presentación para imprimirlo en pantalla.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)