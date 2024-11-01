---
title: Удаление строки или столбца в таблице в VSTO и Aspose.Slides
type: docs
weight: 130
url: /ru/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
Ниже представлен код для удаления строк или столбцов из таблицы с использованием VSTO Presentation:

``` csharp

    string FileName = "Удаление строки или столбца в таблице.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Получить первый слайд

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
Aspose.Slides для .NET предоставил самый простой API для создания таблиц самым простым способом. Чтобы создать таблицу на слайде и выполнить некоторые основные операции с таблицей, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите ссылку на слайд, используя его индекс
- Определите массив столбцов с шириной
- Определите массив строк с высотой
- Добавьте таблицу на слайд, используя метод AddTable, предоставленный объектом IShapes
- Удалите строку таблицы
- Удалите столбец таблицы
- Запишите измененную презентацию в файл PPTX

``` csharp

   string FileName = "Удаление строки или столбца в таблице.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Получить первый слайд

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Скачать работающий код**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Скачать примеры кода**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Removing Row Or Column in Table/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)