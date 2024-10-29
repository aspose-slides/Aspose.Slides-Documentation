---
title: API Público y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para Java 15.5.0
type: docs
weight: 130
url: /es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/), métodos, propiedades y demás, cualquier nueva restricción y otros [cambios](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) introducidos con el API de Aspose.Slides para Java 15.5.0.

{{% /alert %}} 
## **Cambios en el API Público**
### **La clase CommonSlideViewProperties y la interfaz ICommonSlideViewProperties han sido añadidas**
La clase com.aspose.slides.CommonSlideViewProperties (y su interfaz com.aspose.slides.ICommonSlideViewProperties) representa propiedades comunes de la vista de diapositivas (actualmente opciones de escala de vista).
### **Los métodos IAxis.getLabelOffset(), setLabelOffset(int) han sido añadidos**
Los métodos IAxis.getLabelOffset(), setLabelOffset(int) permiten obtener y especificar la distancia de las etiquetas desde el eje. Aplicados al eje de categoría o de fecha.
### **Los métodos IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) han sido añadidos**
Los métodos getAutofitType(), setAutofitType(/**TextAutofitType**/byte) han sido añadidos a la interfaz com.aspose.slides.IChartTextBlockFormat.
Cambio de este valor puede producir una cierta influencia solo para estas partes del gráfico: DataLabel y DataLabelFormat (pleno soporte en PowerPoint 2013; en PowerPoint 2007 no hay efecto para el renderizado).
### **Se han añadido los métodos IChartTextBlockFormat.getWrapText(), setWrapText(byte)**
Se han añadido los métodos getWrapText(), setWrapText(/**NullableBool**/byte) a la interfaz com.aspose.slides.IChartTextBlockFormat.
Cambio de este valor puede producir una cierta influencia solo para estas partes del gráfico: DataLabel y DataLabelFormat (pleno soporte en PowerPoint 2007/2013).
### **Se han añadido los métodos para gestionar márgenes a IChartTextBlockFormat**
Se han añadido los métodos getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() y setMarginBottom(double) a la interfaz com.aspose.slides.IChartTextBlockFormat.
Cambio de estos valores puede producir una cierta influencia solo para estas partes del gráfico: DataLabel y DataLabelFormat (pleno soporte en PowerPoint 2013; en PowerPoint 2007 no hay efecto para el renderizado).
### **Se ha añadido el método ViewProperties.getNotesViewProperties()**
Se ha añadido la propiedad com.aspose.slides.ViewProperties.getNotesViewProperties(). Obtiene propiedades de vista comunes asociadas con el modo de vista de notas.
### **Se ha añadido el método ViewProperties.getSlideViewProperties()**
Se ha añadido el método com.aspose.slides.ViewProperties.getSlideViewProperties(). Obtiene propiedades de vista comunes asociadas con el modo de vista de diapositivas.