---
title: Удаление строки или столбца в таблице в VSTO и Aspose.Slides
type: docs
weight: 130
url: /ru/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
Ниже приведён код для удаления строк или столбцов из таблицы с использованием VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          shp.Table.Rows[1].Delete();

      }

   }

``` 
## **Aspose.Slides**
Aspose.Slides for .NET предоставляет самый простой API для создания таблиц самым лёгким способом. Чтобы создать таблицу на слайде и выполнить базовые операции с таблицей, выполните следующие шаги:

- Создать экземпляр класса Presentation
- Получить ссылку на слайд, используя его индекс
- Определить массив столбцов с шириной
- Определить массив строк с высотой
- Добавить таблицу на слайд с помощью метода AddTable, доступного через объект IShapes
- Удалить строку таблицы
- Удалить столбец таблицы
- Сохранить изменённую презентацию в файл PPTX

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Get First Slide

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)