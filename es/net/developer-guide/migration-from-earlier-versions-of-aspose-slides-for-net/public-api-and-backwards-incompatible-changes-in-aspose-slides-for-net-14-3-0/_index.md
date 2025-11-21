---
title: API pública y cambios incompatibles con versiones anteriores en Aspose.Slides para .NET 14.3.0
linktitle: Aspose.Slides para .NET 14.3.0
type: docs
weight: 50
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios de ruptura en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

## **API pública y cambios incompatibles con versiones anteriores**
### **Enumeración Aspose.Slides.ShapeThumbnailBounds y métodos Aspose.Slides.IShape.GetThumbnail() añadidos**
Los métodos GetThumbnail() y GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) se utilizan para crear una miniatura de forma independiente. La enumeración ShapeThumbnailBounds define los posibles tipos de límites de miniatura de forma.
### **Propiedad UniqueId añadida a Aspose.Slides.IShape**
La propiedad Aspose.Slides.IShape.UniqueId obtiene un identificador de forma único en el ámbito de la presentación. Estos identificadores únicos se almacenan en etiquetas personalizadas de la forma.
### **Firma del método SetGroupingItem modificada en IChartCategoryLevelsManager**
La firma del método IChartCategoryLevelsManager

``` csharp
 void SetGroupingItem(int level, IChartDataCell value);
```

está ahora obsoleta y se reemplaza por la firma

``` csharp
 void SetGroupingItem(int level, object value);
```

Ahora llamadas como

``` csharp
 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));
```

deben cambiarse a llamadas como

``` csharp
 .SetGroupingItem(1, "Group 1");
```

Pase un valor como "Group 1" a SetGroupingItem, pero no un valor del tipo IChartDataCell. La construcción de IChartDataCell con una hoja de cálculo, fila y columna definidas para los niveles de categoría debe cumplir algunos requisitos y se ha encapsulado en el método SetGroupingItem(int, object).
### **Propiedad SlideId añadida a la interfaz Aspose.Slides.IBaseSlide**
La propiedad SlideId obtiene un identificador de diapositiva único.
### **Propiedad SoundName añadida a ISlideShowTransition**
Cadena de lectura y escritura. Especifica un nombre legible por humanos para el sonido de la transición. La propiedad Sound debe asignarse para obtener o establecer el nombre del sonido. Este nombre aparece en la interfaz de usuario de PowerPoint al configurar manualmente el sonido de la transición. Puede lanzar PptxException cuando la propiedad Sound no está asignada.
### **Tipo de la propiedad ChartSeriesGroup.Type modificado**
La propiedad ChartSeriesGroup.Type se ha cambiado de la enumeración ChartType a la nueva enumeración CombinableSeriesTypesGroup. La enumeración CombinableSeriesTypesGroup representa los grupos de tipos de series combinables.
### **Se agregó soporte para generar miniaturas de forma individuales**
Aspose.Slides.ShapeThumbnailBounds

Nuevos miembros en Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)