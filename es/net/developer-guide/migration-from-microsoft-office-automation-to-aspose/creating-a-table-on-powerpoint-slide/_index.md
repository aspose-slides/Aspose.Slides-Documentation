---
title: Creando una Tabla en una Diapositiva de PowerPoint
type: docs
weight: 50
url: /es/net/creating-a-table-on-powerpoint-slide/
---

{{% alert color="primary" %}} 

Las tablas se utilizan ampliamente para mostrar datos en las diapositivas de presentación. Este artículo muestra cómo crear una tabla de 15 x 15 con un tamaño de fuente de 10 programáticamente usando primero [VSTO 2008](/slides/es/net/creating-a-table-on-powerpoint-slide/) y luego [Aspose.Slides para .NET](/slides/es/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **Creando Tablas**
#### **Ejemplo de VSTO 2008**
Los siguientes pasos añaden una tabla a una diapositiva de Microsoft PowerPoint utilizando VSTO:

1. Crear una presentación.
1. Añadir una diapositiva en blanco a la presentación.
1. Añadir una tabla de 15 x 15 a la diapositiva.
1. Añadir texto a cada celda de la tabla con un tamaño de fuente de 10.
1. Guardar la presentación en el disco.

```c#
//Crear una presentación
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Añadir una diapositiva en blanco
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Añadir una tabla de 15 x 15
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
        //Añadir algo de texto
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Establecer el tamaño de fuente del texto como 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Guardar la presentación en el disco
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Ejemplo de Aspose.Slides para .NET**
Los siguientes pasos añaden una tabla a una diapositiva de Microsoft PowerPoint utilizando Aspose.Slides:

1. Crear una presentación.
1. Añadir una tabla de 15 x 15 a la primera diapositiva.
1. Añadir texto a cada celda de la tabla con un tamaño de fuente de 10.
1. Escribir la presentación en el disco.

```c#
Presentation pres = new Presentation();

//Acceder a la primera diapositiva
ISlide sld = pres.Slides[0];

//Definir columnas con anchos y filas con alturas
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Añadir una tabla
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Establecer formato de borde para cada celda
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Obtener el marco de texto de cada celda
		ITextFrame tf = cell.TextFrame;
		//Añadir algo de texto
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Establecer tamaño de fuente de 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Escribir la presentación en el disco
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```