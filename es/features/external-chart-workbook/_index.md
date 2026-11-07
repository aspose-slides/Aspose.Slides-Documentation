---
title: Enlazar gráficos a libros de trabajo externos
description: Enlazar datos del gráfico a un libro de trabajo externo y actualizarlo.
type: docs
url: /es/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Visión general**

Apunte un gráfico a un libro de Excel externo en lugar de mantener todos sus datos de origen incrustados en la presentación. Puede establecer la ruta del libro y elegir si actualizar el gráfico a partir de ese archivo. El gráfico guardado también puede contener datos de visualización en caché.

## **Ejemplo de uso**

Este ejemplo en C# utiliza Aspose.Slides for .NET. Cree un libro de ventas válido con North = 55 y South = 40 y guárdelo como sales.xlsx junto a la salida. Restablezca el valor North del gráfico a 20, luego enlace el gráfico a la ruta absoluta del libro y actualícelo: North vuelve a ser 55. El rango explícito cubre la cabecera y dos filas de datos. Mantenga sales.xlsx disponible al reabrir o actualizar el gráfico enlazado; la presentación no incrusta este archivo externo. No se necesita ningún archivo de entrada. Se guardan *external-chart-workbook.pptx* y *external-chart-workbook.png*. Instale la biblioteca usando la [guía de instalación](/slides/es/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **Preguntas frecuentes**

### **¿Puedo leer todos los valores en caché cuando falta el archivo enlazado?**

Aspose.Slides for .NET 26.11 puede [leer los valores del gráfico almacenados directamente](/slides/es/net/chart-workbook/#read-cached-chart-values-without-a-workbook) sin abrir el libro enlazado. Esto incluye valores habituales, valores X/Y, tamaños de burbuja y valores de categoría cuando esas cachés existen. Los datos en caché pueden estar ausentes o obsoletos; no constituyen un libro completo. Actualizar desde el origen sigue requiriendo un libro compatible disponible. Para otros SDK y versiones, consulte la guía de gráficos correspondiente.

### **¿Qué ocurre si se mueve el libro externo?**

Actualice la ruta del libro externo del gráfico a su nueva ubicación y haga que ese archivo esté disponible donde sea que se procese la presentación. No confíe en los datos en caché para operaciones de acceso completo a los datos cuando falten.

### **¿Puedo elegir si refrescar los datos del gráfico en caché al enlazar?**

Sí. Elija si actualizar los datos del gráfico al establecer el enlace. Refrescar requiere un libro compatible disponible; omitir el refresco registra el enlace sin leer nuevos valores de ese archivo.

## **Guías**

- [Administrar libros de gráficos en presentaciones en .NET](/slides/es/net/chart-workbook/)

Funcionalidad relacionada: [Rellenar gráficos editables con datos](/slides/es/features/chart-data-binding/).