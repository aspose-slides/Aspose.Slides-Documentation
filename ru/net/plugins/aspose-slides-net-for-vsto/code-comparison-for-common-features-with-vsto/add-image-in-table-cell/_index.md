---
title: Добавить изображение в ячейку таблицы
type: docs
weight: 10
url: /ru/net/add-image-in-table-cell/
---

## **VSTO**
Ниже приведён код для добавления изображения в ячейку таблицы:

``` csharp

    //Open Prsentation class that contains the table

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

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
Aspose.Slides for .NET предоставляет самый простой API для создания таблиц самым лёгким способом. Чтобы добавить изображение в ячейку таблицы при создании новой таблицы, выполните следующие действия:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его индекс
- Определите массив столбцов с указанием ширины
- Определите массив строк с указанием высоты
- Добавьте таблицу на слайд, используя метод AddTable, доступный у объекта IShapes
- Создайте объект Bitmap для хранения файла изображения
- Добавьте изображение Bitmap в объект IPPImage
- Установите формат заливки ячейки таблицы как изображение
- Добавьте изображение в первую ячейку таблицы
- Сохраните изменённую презентацию в файл PPTX

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Get First Slide

  ISlide sld = MyPresentation.Slides[0];

  //Creating a Bitmap Image object to hold the image file

  using IImage image = Images.FromFile(ImageFile);

  //Create an IPPImage object using the bitmap object

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Add image to first table cell

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Save PPTX to Disk

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Скачать работающий код**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)