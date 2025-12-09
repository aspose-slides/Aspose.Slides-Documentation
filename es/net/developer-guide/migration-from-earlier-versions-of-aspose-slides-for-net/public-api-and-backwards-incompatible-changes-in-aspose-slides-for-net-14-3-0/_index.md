---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 14.3.0
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
description: "Revise las actualizaciones de la API pública y los cambios disruptivos en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---

## **API pública y cambios incompatibles hacia atrás**
### **Enumeración Aspose.Slides.ShapeThumbnailBounds y métodos Aspose.Slides.IShape.GetThumbnail() añadidos**
Los métodos GetThumbnail() y GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) se utilizan para crear una miniatura de forma independiente. La enumeración ShapeThumbnailBounds define los posibles tipos de límites de miniatura de forma.
### **Propiedad UniqueId añadida a Aspose.Slides.IShape**
La propiedad Aspose.Slides.IShape.UniqueId obtiene un identificador de forma único dentro del alcance de una presentación. Estos identificadores únicos se almacenan en etiquetas personalizadas de la forma.
### **Firma del método SetGroupingItem cambiada en IChartCategoryLevelsManager**
Signature of the IChartCategoryLevelsManager method

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

is obsolete now and replaced with the signature

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Now calls like

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

must be changed to calls like

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

Pasar un valor como "Group 1" a SetGroupingItem pero no un valor del tipo IChartDataCell. Construir IChartDataCell con una hoja de cálculo definida, fila y columna para los niveles de categoría debe cumplir ciertos requisitos y ha sido encapsulado en el método SetGroupingItem(int, object).
### **Propiedad SlideId añadida a la interfaz Aspose.Slides.IBaseSlide**
La propiedad SlideId obtiene un identificador de diapositiva único.
### **Propiedad SoundName añadida a ISlideShowTransition**
Cadena de lectura y escritura. Especifica un nombre legible por humanos para el sonido de la transición. La propiedad Sound debe asignarse para obtener o establecer el nombre del sonido. Este nombre aparece en la interfaz de usuario de PowerPoint al configurar manualmente el sonido de la transición. Puede lanzar PptxException cuando la propiedad Sound no está asignada.
### **Tipo de la propiedad ChartSeriesGroup.Type cambiado**
La propiedad ChartSeriesGroup.Type se ha cambiado de la enumeración ChartType a la nueva enumeración CombinableSeriesTypesGroup. El enum CombinableSeriesTypesGroup representa los grupos de tipos de series combinables.
### **Soporte para generar miniaturas de formas individuales añadido**
Aspose.Slides.ShapeThumbnailBounds

Nuevos miembros en Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)