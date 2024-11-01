---
title: Добавить изображение в ячейку таблицы
type: docs
weight: 10
url: /ru/net/add-image-in-table-cell/
---

## **VSTO**
Ниже приведен код для добавления изображения в ячейку таблицы:

``` csharp

    //Открываем класс презентации, который содержит таблицу

   string FileName = "Добавление изображения в ячейку таблицы.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Получаем первый слайд

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell= shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }


``` 
## **Aspose.Slides**
Aspose.Slides для .NET предоставляет самый простой API для создания таблиц наиболее удобным образом. Чтобы добавить изображение в ячейку таблицы при создании новой таблицы, пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его индекс
- Определите массив столбцов с шириной
- Определите массив строк с высотой
- Добавьте таблицу на слайд с помощью метода AddTable, предоставленного объектом IShapes
- Создайте объект Bitmap для хранения файла изображения
- Добавьте изображение Bitmap в объект IPPImage
- Установите формат заполнения ячейки таблицы как изображение
- Добавьте изображение в первую ячейку таблицы
- Сохраните измененную презентацию в файл PPTX

``` csharp

   string FileName = "Добавление изображения в ячейку таблицы.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Получаем первый слайд

  ISlide sld = MyPresentation.Slides[0];

  //Создаем объект Bitmap Image для хранения файла изображения

  System.Drawing.Bitmap image = new Bitmap(ImageFile);

  //Создаем объект IPPImage, используя объект bitmap

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Добавляем изображение в первую ячейку таблицы

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Сохраняем PPTX на диск

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Скачать рабочий код**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Скачать пример кода**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Adding image in table cell/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)