---
title: API Pública y Cambios Incompatibles hacia Atrás en Aspose.Slides para Java 15.5.0
type: docs
weight: 130
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases agregadas](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/), métodos, propiedades, y así sucesivamente, cualquier nueva restricción y otros [cambios](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) introducidos con el API de Aspose.Slides para Java 15.5.0.

{{% /alert %}} 
## **Cambios en la API Pública**
### **Se ha agregado la clase CommonSlideViewProperties y la interfaz ICommonSlideViewProperties**
La clase com.aspose.slides.CommonSlideViewProperties (y su interfaz com.aspose.slides.ICommonSlideViewProperties) representa propiedades comunes de vista de diapositivas (actualmente opciones de escala de vista).
### **Se han agregado los métodos IAxis.getLabelOffset(), setLabelOffset(int)**
Los métodos IAxis.getLabelOffset(), setLabelOffset(int) permiten obtener y especificar la distancia de las etiquetas desde el eje. Se aplican al eje de categoría o de fecha.
### **Se han agregado los métodos IChartTextBlockFormat.getAutofitType(), setAutofitType(byte)**
Se han agregado los métodos getAutofitType(), setAutofitType(/**TextAutofitType**/byte) a la interfaz com.aspose.slides.IChartTextBlockFormat.
El cambio de este valor puede tener una cierta influencia solo en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2013; en PowerPoint 2007 no hay efecto en el renderizado).
### **Se han agregado los métodos IChartTextBlockFormat.getWrapText(), setWrapText(byte)**
Se han agregado los métodos getWrapText(), setWrapText(/**NullableBool**/byte) a la interfaz com.aspose.slides.IChartTextBlockFormat.
El cambio de este valor puede tener una cierta influencia solo en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2007/2013).
### **Se han agregado métodos para gestionar márgenes a IChartTextBlockFormat**
Se han agregado los métodos getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() y setMarginBottom(double) a la interfaz com.aspose.slides.IChartTextBlockFormat.
El cambio de estos valores puede tener una cierta influencia solo en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2013; en PowerPoint 2007 no hay efecto en el renderizado).
### **Se ha agregado el método ViewProperties.getNotesViewProperties()**
Se ha agregado la propiedad com.aspose.slides.ViewProperties.getNotesViewProperties(). Obtiene las propiedades comunes de vista asociadas con el modo de vista de notas.
### **Se ha agregado el método ViewProperties.getSlideViewProperties()**
Se ha agregado el método com.aspose.slides.ViewProperties.getSlideViewProperties(). Obtiene las propiedades comunes de vista asociadas con el modo de vista de diapositivas.