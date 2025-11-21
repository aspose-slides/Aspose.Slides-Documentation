---
title: Создание таблиц с использованием VSTO и Aspose.Slides для .NET
linktitle: Создание таблиц
type: docs
weight: 50
url: /ru/net/creating-a-table-on-powerpoint-slide/
keywords:
- создать таблицу
- миграция
- VSTO
- автоматизация Office
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Перейдите с автоматизации Microsoft Office на Aspose.Slides для .NET и создавайте таблицы в слайдах PowerPoint (PPT, PPTX) на C# с гибким форматированием."
---

{{% alert color="primary" %}} 
Таблицы широко используются для отображения данных на слайдах презентаций. В этой статье показывается, как программно создать таблицу 15 x 15 с размером шрифта 10, сначала с помощью [VSTO 2008](/slides/ru/net/creating-a-table-on-powerpoint-slide/), а затем с помощью [Aspose.Slides for .NET](/slides/ru/net/creating-a-table-on-powerpoint-slide/).
{{% /alert %}} 
## **Создание таблиц**
#### **Пример VSTO 2008**
Следующие шаги добавляют таблицу на слайд Microsoft PowerPoint с использованием VSTO:

1. Создать презентацию.
1. Добавить пустой слайд в презентацию.
1. Добавить таблицу 15 x 15 на слайд.
1. Добавить текст в каждую ячейку таблицы с размером шрифта 10.
1. Сохранить презентацию на диск.
```c#
//Создать презентацию
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Добавить пустой слайд
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Добавить таблицу 15 x 15
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Перебрать все строки
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Перебрать все ячейки в строке
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Получить текстовый фрейм каждой ячейки
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Добавить текст
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Установить размер шрифта текста 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Сохранить презентацию на диск
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Пример Aspose.Slides for .NET**
Следующие шаги добавляют таблицу на слайд Microsoft PowerPoint с использованием Aspose.Slides:

1. Создать презентацию.
1. Добавить таблицу 15 x 15 на первый слайд.
1. Добавить текст в каждую ячейку таблицы с размером шрифта 10.
1. Записать презентацию на диск.
```c#
Presentation pres = new Presentation();

//Access first slide
ISlide sld = pres.Slides[0];

//Define columns with widths and rows with heights
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Add a table
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Set border format for each cell
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Get text frame of each cell
		ITextFrame tf = cell.TextFrame;
		//Add some text
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Set font size of 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Write the presentation to the disk
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```
