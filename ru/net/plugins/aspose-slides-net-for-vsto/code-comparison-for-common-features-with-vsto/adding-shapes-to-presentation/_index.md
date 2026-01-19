---
title: Добавление фигур в презентацию
type: docs
weight: 30
url: /ru/net/adding-shapes-to-presentation/
---

## **VSTO**
Ниже приведён фрагмент кода для добавления линии:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие действия:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его индекс
- Добавьте AutoShape типа Line с помощью метода AddAutoShape, предоставляемого объектом Shapes
- Сохраните изменённую презентацию в файл PPTX

В приведённом ниже примере мы добавили линию на первый слайд презентации.

``` csharp

   //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide slide = pres.Slides[0];

  //Add an autoshape of type line

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)