---
title: Abrir una presentación en VSTO y Aspose.Slides
type: docs
weight: 120
url: /net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
A continuación se muestra el fragmento de código para abrir una presentación:

``` csharp

  string FileName = "Abrir Presentación.pptx";

 Application.Presentations.Open(FileName);

``` 
## **Aspose.Slides**
Aspose.Slides para .NET proporciona la clase **Presentation** que se utiliza para abrir una presentación existente. Ofrece algunos constructores sobrecargados y podemos hacer uso de uno de los constructores adecuados de la clase **Presentation** para crear su objeto basado en una presentación existente. En el ejemplo dado a continuación, hemos pasado el nombre del archivo de presentación (que se abrirá) al constructor de la clase Presentation. Después de que el archivo se abre, obtenemos el número total de diapositivas presentes en la presentación para imprimir en la pantalla.

``` csharp

  string FileName = "Abrir Presentación.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Descargar código en ejecución**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Descargar código de muestra**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Opening a Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)