---
title: Solución práctica para el redimensionado de gráficos en PPTX
type: docs
weight: 60
url: /es/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionado de gráficos
- gráfico de Excel
- objeto OLE
- incrustar gráfico
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Soluciona el redimensionado inesperado de gráficos en PPTX al usar objetos OLE de Excel incrustados con Aspose.Slides para .NET. Establece dimensiones fijas del gráfico para mantener consistentes los tamaños del gráfico y del marco OLE."
---
## **Antecedentes**

Los gráficos de Excel incrustados como objetos OLE en presentaciones de PowerPoint mediante componentes Aspose pueden cambiar de tamaño después de su primera activación. Esto puede provocar una diferencia notable en la apariencia del gráfico antes y después de la activación. Este artículo explica por qué ocurre el cambio de tamaño y muestra cómo evitarlo haciendo coincidir las dimensiones fijas del gráfico con el marco OLE.

En [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos cómo crear un gráfico de Excel con Aspose.Cells para .NET y cómo incrustarlo en una presentación de PowerPoint usando Aspose.Slides para .NET. Para abordar el [problema de vista previa del objeto](/slides/es/net/object-preview-issue-when-adding-oleobjectframe/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación resultante, al hacer doble clic en el marco del objeto OLE que muestra la imagen del gráfico, se activa el gráfico de Excel. Los usuarios pueden editar el libro de Excel incrustado y luego regresar a la diapositiva haciendo clic fuera del libro activado. El tamaño del marco del objeto OLE cambia cuando el usuario vuelve a la diapositiva, y el factor de redimensionado varía según los tamaños originales tanto del marco OLE como del libro de Excel incrustado.

## **Causa del cambio de tamaño**

El libro de Excel incrustado tiene sus propias dimensiones de ventana, que Excel intenta conservar cuando el objeto se activa por primera vez. El marco OLE en la diapositiva tiene dimensiones definidas de forma independiente. Cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño del objeto para mantener sus proporciones como parte del proceso de incrustación. Las diferencias entre la ventana del libro y el marco OLE pueden, por lo tanto, provocar el redimensionado del objeto.

## **Solución**

Haz coincidir el tamaño del gráfico con el marco OLE en la diapositiva y mantén las dimensiones del gráfico independientes de la ventana del libro. Esta solución funciona con una presentación nueva o con una plantilla existente.

El ejemplo requiere Aspose.Cells para .NET y Aspose.Slides para .NET. Crea un gráfico de columnas sencillo en una hoja de gráfico activa y incrusta el libro en formato XLS. No se asigna ninguna imagen de vista previa del gráfico; el gráfico se vuelve visible cuando el objeto OLE se activa en PowerPoint.

El ejemplo crea una nueva presentación con un marco OLE de 9,5 × 4 pulgadas situado a 0,5 pulgadas del borde izquierdo y a 1 pulgada de la parte superior. Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada). Para una presentación existente, consulta [Usar una plantilla](#use-a-template).

## **Establecer un tamaño de gráfico fijo**

Establece [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) a false para que las dimensiones del gráfico sean independientes de la ventana del libro. Define las dimensiones del [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) mediante [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) y [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), convirtiendo puntos a píxeles usando 96 píxeles por pulgada: un marco de 684 × 288 puntos corresponde a un gráfico de 912 × 384 píxeles. Establece [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) al valor Custom de [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). El ejemplo incrusta el libro con [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) y guarda una presentación con un marco OLE de 9,5 × 4 pulgadas.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada).
var width = 684f; // 9,5 pulgadas.
var height = 288f; // 4 pulgadas.

chart.SizeWithWindow = false;
// Convertir puntos a píxeles del gráfico usando 96 píxeles por pulgada.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Usar una plantilla**

La lógica de dimensionado es la misma para una presentación existente. Para adaptar el ejemplo:

1. Carga la presentación plantilla en lugar de crear una presentación vacía.  
1. Verifica que la primera diapositiva contenga al menos tres formas y utiliza la forma en el índice 2 como marcador de posición.  
1. Obtén el ancho y alto del marco a partir de esa forma en lugar de usar los valores fijos 684 y 288. Mantén los cálculos de dimensionado sin cambios.  
1. Añade el marco OLE en la posición del marcador de posición en lugar de usar las coordenadas fijas 36 y 72.  
1. Elimina el marcador de posición antes de guardar la presentación.

## **Preguntas frecuentes**

**¿Por qué mi gráfico de Excel incrustado cambia de tamaño después de activarlo en PowerPoint?**

Esto ocurre porque Excel intenta restaurar el tamaño original de la ventana al activarse por primera vez, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la proporción, lo que puede provocar el redimensionado.

**¿Cómo puedo mantener consistentes los tamaños del gráfico y del marco OLE?**

Establece dimensiones fijas del gráfico que coincidan con el marco OLE y usa un tamaño de impresión de gráfico personalizado antes de incrustar el libro. El ejemplo anterior muestra la configuración necesaria y las conversiones de unidades.

**¿Es suficiente hacer coincidir el tamaño de la ventana del libro?**

Hacer coincidir solo el tamaño de la ventana del libro no evita de forma fiable que el marco OLE cambie de tamaño después de la activación. Utiliza dimensiones fijas del gráfico como se muestra en el ejemplo.

**¿Esta solución funciona tanto con presentaciones basadas en plantillas como con presentaciones nuevas?**

Sí. Para una plantilla, usa las dimensiones y posición del marcador de posición. Para una presentación nueva, especifica directamente las dimensiones y la posición del marco.

**¿Puedo usar este ejemplo con gráficos creados en otros programas de hojas de cálculo?**

El ejemplo utiliza un libro de Excel creado con Aspose.Cells. No muestra el comportamiento de activación para otros programas de hojas de cálculo.

## **Secciones relacionadas**

- [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Actualizar objetos OLE automáticamente usando un complemento de PowerPoint](/slides/es/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)