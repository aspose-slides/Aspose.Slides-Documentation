---
title: API Público y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para .NET 14.3.0
type: docs
weight: 50
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
---

## **API Público y Cambios Incompatibles con Versiones Anteriores**
### **Se Agregaron la Enumeración Aspose.Slides.ShapeThumbnailBounds y los Métodos Aspose.Slides.IShape.GetThumbnail()**
Los métodos GetThumbnail() y GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) se utilizan para crear un thumbnail de forma separado. La enumeración ShapeThumbnailBounds define los posibles tipos de límites de thumbnail de forma.
### **Se Agregó la Propiedad UniqueId a Aspose.Slides.IShape**
La propiedad Aspose.Slides.IShape.UniqueId obtiene un identificador único de forma en el ámbito de la presentación. Estos identificadores únicos se almacenan en etiquetas personalizadas de la forma.
### **La Firma del Método SetGroupingItem Cambió en IChartCategoryLevelsManager**
La firma del método IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

está obsoleta ahora y ha sido reemplazada por la firma

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Ahora llamadas como

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Grupo 1"));

``` 

deben cambiarse a llamadas como

``` csharp

 .SetGroupingItem(1, "Grupo 1");

``` 

Pase un valor como "Grupo 1" a SetGroupingItem pero no un valor de tipo IChartDataCell. La construcción de IChartDataCell con una hoja de trabajo definida, fila y columna para niveles de categoría debe satisfacer algunos requisitos y ha sido encapsulada en el método SetGroupingItem(int, object).
### **Se Agregó la Propiedad SlideId a la Interfaz Aspose.Slides.IBaseSlide**
La propiedad SlideId obtiene un identificador único de diapositiva.
### **Se Agregó la Propiedad SoundName a ISlideShowTransition**
Cadena de lectura y escritura. Especifica un nombre legible para humanos para el sonido de la transición. La propiedad Sound debe ser asignada para obtener o establecer el nombre del sonido. Este nombre aparece en la interfaz de usuario de PowerPoint al configurar manualmente el sonido de la transición. Puede lanzar PptxException cuando la propiedad Sound no está asignada.
### **Tipo de la Propiedad ChartSeriesGroup.Type Cambió**
La propiedad ChartSeriesGroup.Type ha sido cambiada de la enumeración ChartType a la nueva enumeración CombinableSeriesTypesGroup. La enumeración CombinableSeriesTypesGroup representa los grupos de tipos de series combinables.
### **Se Agregó Soporte para Generar Thumbnails de Forma Individual**
Aspose.Slides.ShapeThumbnailBounds

Nuevos miembros en Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)