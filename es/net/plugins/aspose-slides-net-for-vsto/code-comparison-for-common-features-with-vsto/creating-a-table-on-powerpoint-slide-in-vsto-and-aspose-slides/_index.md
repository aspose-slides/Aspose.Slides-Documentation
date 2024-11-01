---
title: Creando una tabla en una diapositiva de PowerPoint en VSTO y Aspose.Slides
type: docs
weight: 90
url: /es/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---

Los siguientes pasos añaden una tabla a una diapositiva de Microsoft PowerPoint usando VSTO:

- Crear una presentación.
- Se añade una diapositiva vacía a la presentación.
- Añadir una tabla de 15 x 15 a la diapositiva.
- Añadir texto a cada celda de la tabla con un tamaño de fuente de 10.
- Guardar la presentación en el disco.
## **VSTO**
``` csharp

 //Crear una presentación

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Agregar una diapositiva en blanco

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Agregar una tabla de 15 x 15

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//Recorrer todas las filas

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//Recorrer todas las celdas en la fila

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//Obtener el marco de texto de cada celda

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//Agregar algo de texto

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//Establecer el tamaño de fuente del texto como 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//Guardar la presentación en el disco

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

Los siguientes pasos añaden una tabla a una diapositiva de Microsoft PowerPoint usando Aspose.Slides:

- Crear una presentación.
- Añadir una tabla de 15 x 15 en la primera diapositiva.
- Añadir texto a cada celda de la tabla con un tamaño de fuente de 10.
- Escribir la presentación en el disco.
## **Aspose.Slides**
``` csharp

 //Crear una presentación

Presentation pres = new Presentation();

//Acceder a la primera diapositiva

Slide sld = pres.GetSlideByPosition(1);

//Agregar una tabla

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//Recorrer filas

for (int i = 0; i < tbl.RowsNumber; i++)

	//Recorrer celdas

	for (int j = 0; j < tbl.ColumnsNumber; j++)

	{

		//Obtener el marco de texto de cada celda

		TextFrame tf = tbl.GetCell(j, i).TextFrame;

		//Agregar algo de texto

		tf.Text = "T" + i.ToString() + j.ToString();

		//Establecer tamaño de fuente en 10

		tf.Paragraphs[0].Portions[0].FontHeight = 10;

		tf.Paragraphs[0].HasBullet = false;

	}

//Escribir la presentación en el disco

pres.Write("tblSLD.ppt");

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772951)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip)