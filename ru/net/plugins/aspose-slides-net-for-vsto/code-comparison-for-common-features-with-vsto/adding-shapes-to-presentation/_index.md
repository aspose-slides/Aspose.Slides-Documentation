---
title: Добавление фигур в презентацию
type: docs
weight: 30
url: /ru/net/adding-shapes-to-presentation/
---

## **VSTO**
Ниже приведен фрагмент кода для добавления линии:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Чтобы добавить простую прямую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его индекс
- Добавьте автофигуру типа линия с помощью метода AddAutoShape, предоставленного объектом Shapes
- Запишите измененную презентацию в файл PPTX

В примере ниже мы добавили линию на первый слайд презентации.

``` csharp

   //Создайте экземпляр класса Presentation, представляющего PPTX

  Presentation pres = new Presentation();

  //Получите первый слайд

  ISlide slide = pres.Slides[0];

  //Добавьте автофигуру типа линия

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Скачать работающий код**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Скачать образец кода**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Adding Shape to Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)