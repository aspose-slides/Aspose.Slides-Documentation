---
title: Agregar Formas a la Presentación
type: docs
weight: 30
url: /net/adding-shapes-to-presentation/
---

## **VSTO**
A continuación se muestra el fragmento de código para agregar una forma de línea:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de una diapositiva utilizando su índice
- Agregue una AutoShape de tipo Línea utilizando el método AddAutoShape expuesto por el objeto Shapes
- Guarde la presentación modificada como un archivo PPTX

En el ejemplo que se muestra a continuación, hemos agregado una línea a la primera diapositiva de la presentación.

``` csharp

   //Instanciar la clase Presentation que representa el PPTX

  Presentation pres = new Presentation();

  //Obtener la primera diapositiva

  ISlide slide = pres.Slides[0];

  //Agregar una autoshape de tipo línea

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Descargar Código en Ejecución**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Adding Shape to Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)