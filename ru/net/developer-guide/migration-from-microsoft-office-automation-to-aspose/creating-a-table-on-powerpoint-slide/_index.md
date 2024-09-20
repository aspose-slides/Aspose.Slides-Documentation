---
title: Создание таблицы на слайде PowerPoint
type: docs
weight: 50
url: /net/создание-таблицы-на-слайде-powerpoint/
---

{{% alert color="primary" %}} 

Таблицы широко используются для отображения данных на слайдах презентаций. В этой статье показано, как программно создать таблицу 15 x 15 с размером шрифта 10, используя сначала [VSTO 2008](/slides/net/creating-a-table-on-powerpoint-slide/), а затем [Aspose.Slides для .NET](/slides/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Создание таблиц**
#### **Пример VSTO 2008**
Следующие шаги добавляют таблицу на слайд Microsoft PowerPoint с использованием VSTO:

1. Создайте презентацию.
1. Добавьте пустой слайд в презентацию.
1. Добавьте таблицу 15 x 15 на слайд.
1. Добавьте текст в каждую ячейку таблицы с размером шрифта 10.
1. Сохраните презентацию на диск.

```c#
//Создание презентации
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Добавление пустого слайда
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Добавление таблицы 15 x 15
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//Цикл по всем строкам
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Цикл по всем ячейкам в строке
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Получение текстового фрейма каждой ячейки
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Добавление текста
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Установка размера шрифта текста как 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Сохранение презентации на диск
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Пример Aspose.Slides для .NET**
Следующие шаги добавляют таблицу на слайд Microsoft PowerPoint с использованием Aspose.Slides:

1. Создайте презентацию.
1. Добавьте таблицу 15 x 15 на первый слайд.
1. Добавьте текст в каждую ячейку таблицы с размером шрифта 10.
1. Запишите презентацию на диск.

```c#
Presentation pres = new Presentation();

//Получение первого слайда
ISlide sld = pres.Slides[0];

//Определение столбцов с ширинами и строк с высотами
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Добавление таблицы
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Установка формата границы для каждой ячейки
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Получение текстового фрейма каждой ячейки
		ITextFrame tf = cell.TextFrame;
		//Добавление текста
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Установка размера шрифта 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Запись презентации на диск
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```