---
title: Agregar formas a la presentación
type: docs
weight: 30
url: /es/net/adding-shapes-to-presentation/
---

## **VSTO**
A continuación se muestra el fragmento de código para añadir una forma de línea:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Para añadir una línea simple y lisa a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Crear una instancia de la clase Presentation
- Obtener la referencia de una diapositiva usando su Índice
- Añadir un AutoShape de tipo Línea mediante el método AddAutoShape expuesto por el objeto Shapes
- Guardar la presentación modificada como un archivo PPTX

En el ejemplo que sigue, hemos añadido una línea a la primera diapositiva de la presentación.

``` csharp

   //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide slide = pres.Slides[0];

  //Add an autoshape of type line

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Descargar código en ejecución**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Descargar código de muestra**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)