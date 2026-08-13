---
title: Cambios en la API pública y incompatibles retroactivos en Aspose.Slides for Java 15.5.0
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides for Java para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}}
Esta página enumera todas las [añadidas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) clases, métodos, propiedades, etc., cualquier nueva restricción y otros [cambios](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) introducidos con la API de Aspose.Slides for Java 15.5.0.
{{% /alert %}}
## **Cambios de la API pública**
### **Se ha añadido la clase CommonSlideViewProperties y la interfaz ICommonSlideViewProperties**
La clase com.aspose.slides.CommonSlideViewProperties (y su interfaz com.aspose.slides.ICommonSlideViewProperties) representa propiedades comunes de la vista de diapositiva (actualmente opciones de escala de vista).
### **Se han añadido los métodos IAxis.getLabelOffset() y setLabelOffset(int)**
Los métodos IAxis.getLabelOffset() y setLabelOffset(int) permiten obtener y especificar la distancia de las etiquetas respecto al eje. Se aplican a ejes de categoría o de fecha.
### **Se han añadido los métodos IChartTextBlockFormat.getAutofitType() y setAutofitType(byte)**
Se han añadido los métodos getAutofitType() y setAutofitType(/**TextAutofitType**/byte) a la interfaz com.aspose.slides.IChartTextBlockFormat.
Cambiar este valor puede producir una influencia concreta solo en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2013; en PowerPoint 2007 no hay efecto en el renderizado).
### **Se han añadido los métodos IChartTextBlockFormat.getWrapText() y setWrapText(byte)**
Se han añadido los métodos getWrapText() y setWrapText(/**NullableBool**/byte) a la interfaz com.aspose.slides.IChartTextBlockFormat.
Cambiar este valor puede producir una influencia concreta solo en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2007/2013).
### **Se han añadido a IChartTextBlockFormat los métodos para gestionar los márgenes**
Se han añadido los métodos getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() y setMarginBottom(double) a la interfaz com.aspose.slides.IChartTextBlockFormat.
Cambiar estos valores puede producir una influencia concreta solo en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2013; en PowerPoint 2007 no hay efecto en el renderizado).
### **Se ha añadido el método ViewProperties.getNotesViewProperties()**
Se ha añadido la propiedad com.aspose.slides.ViewProperties.getNotesViewProperties(). Obtiene las propiedades comunes de vista asociadas al modo de vista de notas.
### **Se ha añadido el método ViewProperties.getSlideViewProperties()**
Se ha añadido el método com.aspose.slides.ViewProperties.getSlideViewProperties(). Obtiene las propiedades comunes de vista asociadas al modo de vista de diapositiva.