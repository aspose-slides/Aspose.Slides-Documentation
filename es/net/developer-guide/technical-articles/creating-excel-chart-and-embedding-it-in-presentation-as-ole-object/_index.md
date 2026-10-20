---
title: Crear gráficos de Excel e incrustarlos en presentaciones como objetos OLE
type: docs
weight: 50
url: /es/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- gráfico de Excel
- incrustar gráfico
- objeto OLE
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Crear un gráfico de Excel con Aspose.Cells para .NET e incrustar el libro de trabajo en una presentación de PowerPoint con Aspose.Slides, incluyendo una vista previa del gráfico."
---
## **Visión general**

Este artículo muestra cómo crear un gráfico de columnas de Excel con Aspose.Cells para .NET e incrustar su libro de trabajo en una presentación de PowerPoint con Aspose.Slides para .NET. El libro de trabajo incrustado contiene tanto los datos de origen como el gráfico. Una vista previa PNG independiente muestra el gráfico en la diapositiva antes de que se active el objeto OLE.

El resultado es un objeto de Excel incrustado, no un gráfico nativo de PowerPoint. Editar el libro de trabajo a través de OLE requiere una aplicación de escritorio que admita la activación OLE y una instalación de Excel compatible.

## **Requisitos previos**

Agregue referencias a Aspose.Cells para .NET y Aspose.Slides para .NET en su proyecto C#. El ejemplo utiliza sentencias de nivel superior y requiere C# 9 o posterior. Microsoft Office no es necesario para generar la presentación con estas bibliotecas.

No se requieren archivos de entrada: el ejemplo crea los datos y el gráfico en memoria, y luego escribe `OutputChart.pptx` en el directorio de trabajo actual. Aplique licencias para ambos productos al ejecutarse fuera del modo de evaluación.

## **Cómo funciona la incrustación**

1. Crear un libro de trabajo con una hoja de datos y una hoja de gráfico.  
2. Activar la hoja de gráfico para que el libro de trabajo se abra en el gráfico.  
3. Establecer el rango de visualización OLE del libro de trabajo y renderizar el gráfico a PNG.  
4. Guardar el libro de trabajo como XLSX en memoria e incrustar esos bytes en una diapositiva.  
5. Asignar el PNG como vista previa del objeto OLE y guardar la presentación como PPTX.

El rango de visualización del libro de trabajo y el marco en la diapositiva tienen roles diferentes. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) utiliza índices de fila y columna de inicio/final basados en cero. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) en su lugar toma la fila superior, columna izquierda, fila inferior y columna derecha. El ejemplo usa el índice de fila 55 y el índice de columna 25 como límites inferiores derechos; esos valores son decisiones de diseño, no el número de filas o columnas de datos.

El marco de la diapositiva utiliza puntos. El ejemplo lo ajusta dentro de la diapositiva y lo centra mientras preserva la relación de aspecto del PNG, en lugar de estirar la vista previa para rellenar la diapositiva.

## **Crear e incrustar el gráfico**

El siguiente ejemplo completo rellena `DataSheet` con cuatro filas y cinco columnas de valores. Cada fila se convierte en una serie del gráfico. `ChartSheet` se selecciona como la hoja activa antes de guardar el libro de trabajo.

El libro de trabajo se guarda explícitamente como XLSX, coincidiendo con la extensión `xlsx` que se pasa a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). El PNG se carga directamente desde su flujo sin una conversión intermedia a bitmap. Asignarlo mediante [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) reemplaza el marcador de posición OLE predeterminado.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Renderizar la vista previa del gráfico y serializar el libro de trabajo editable por separado.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Ajustar la vista previa dentro de la diapositiva sin cambiar su relación de aspecto.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Resultado esperado**

`OutputChart.pptx` contiene una diapositiva con un libro de Excel incrustado y una vista previa del gráfico. El libro de trabajo contiene los datos originales y un gráfico de columnas con cuatro series. La vista previa está centrada en la diapositiva y conserva sus proporciones.

![Gráfico de columnas de Excel mostrado como vista previa de un libro de trabajo incrustado](excel-chart-ole-preview.png)

En un entorno de escritorio compatible de PowerPoint con Excel disponible, haga doble clic en el objeto para activar y editar el libro de trabajo incrustado. La activación y edición dependen del soporte OLE y la configuración de seguridad de la aplicación host.

## **Preguntas frecuentes**

**¿Por qué se necesita una imagen de vista previa?**

El libro de trabajo incrustado y su vista previa de diapositiva son contenidos separados. Proporcione una imagen del gráfico para que la diapositiva muestre el gráfico en lugar del marcador de posición predeterminado "EMBEDDED OLE OBJECT". Consulte [Problema de vista previa del objeto al agregar OleObjectFrame](/slides/es/net/object-preview-issue-when-adding-oleobjectframe/).

**¿Se actualiza automáticamente la vista previa cuando modifico el libro de trabajo en el código?**

Considere la vista previa como una instantánea. Al actualizar los datos del libro de trabajo mediante programación, regenere la imagen del gráfico y reemplace la vista previa así como los datos del libro de trabajo incrustado.

**¿Puedo usar XLS en lugar de XLSX?**

Sí. Guarde el libro de trabajo en formato XLS y use `xls` como extensión de los datos incrustados. La extensión debe coincidir con el formato real del libro de trabajo; cambiar solo la extensión no convierte los datos.

**¿Por qué podría el objeto cambiar de tamaño después de la activación?**

La aplicación host puede actualizar la presentación del objeto OLE cuando activa el libro de trabajo. Tanto el rango de visualización OLE del libro de trabajo como las dimensiones del marco de la diapositiva son importantes. Consulte [Solución funcional para el cambio de tamaño del gráfico en PPTX](/slides/es/net/working-solution-for-chart-resizing-in-pptx/).

## **Secciones relacionadas**

- [Solución funcional para el cambio de tamaño del gráfico en PPTX](/slides/es/net/working-solution-for-chart-resizing-in-pptx/)
- [Problema de vista previa del objeto al agregar OleObjectFrame](/slides/es/net/object-preview-issue-when-adding-oleobjectframe/)
- [Actualizar objetos OLE automáticamente usando un complemento de PowerPoint](/slides/es/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)