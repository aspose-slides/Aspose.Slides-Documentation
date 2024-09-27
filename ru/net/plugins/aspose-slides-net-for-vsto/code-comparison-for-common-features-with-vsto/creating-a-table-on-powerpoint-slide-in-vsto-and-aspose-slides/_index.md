---  
title: Создание таблицы на слайде PowerPoint в VSTO и Aspose.Slides  
type: docs  
weight: 90  
url: /ru/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/  
---  

Следующие шаги добавляют таблицу на слайд Microsoft PowerPoint с использованием VSTO:

- Создайте презентацию.
- Добавьте пустой слайд в презентацию.
- Добавьте таблицу 15 x 15 на слайд.
- Добавьте текст в каждую ячейку таблицы размером шрифта 10.
- Сохраните презентацию на диск.  
## **VSTO**  
``` csharp  

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

//Цикл по всем строкам  

foreach (PowerPoint.Row row in tbl.Rows)  

{  

	i = i + 1;  

	j = -1;  

	//Цикл по всем ячейкам в строке  

	foreach (PowerPoint.Cell cell in row.Cells)  

	{  

		j = j + 1;  

		//Получить текстовое поле каждой ячейки  

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;  

		//Добавить текст  

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();  

		//Установить размер шрифта текста равным 10  

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;  

	}  

}  

//Сохранить презентацию на диск  

pres.SaveAs("tblVSTO.ppt",  

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,  

	  Microsoft.Office.Core.MsoTriState.msoFalse);  

```  

Следующие шаги добавляют таблицу на слайд Microsoft PowerPoint с использованием Aspose.Slides:

- Создайте презентацию.
- Добавьте таблицу 15 x 15 на первый слайд.
- Добавьте текст в каждую ячейку таблицы размером шрифта 10.
- Запишите презентацию на диск.  
## **Aspose.Slides**  
``` csharp  

//Создать презентацию  

Presentation pres = new Presentation();  

//Доступ к первому слайду  

Slide sld = pres.GetSlideByPosition(1);  

//Добавить таблицу  

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);  

//Цикл по строкам  

for (int i = 0; i < tbl.RowsNumber; i++)  

	//Цикл по ячейкам  

	for (int j = 0; j < tbl.ColumnsNumber; j++)  

	{  

		//Получить текстовое поле каждой ячейки  

		TextFrame tf = tbl.GetCell(j, i).TextFrame;  

		//Добавить текст  

		tf.Text = "T" + i.ToString() + j.ToString();  

		//Установить размер шрифта 10  

		tf.Paragraphs[0].Portions[0].FontHeight = 10;  

		tf.Paragraphs[0].HasBullet = false;  

	}  

//Записать презентацию на диск  

pres.Write("tblSLD.ppt");  

```  
## **Скачать пример кода**  
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772951)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)  
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip/download)  
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip)  