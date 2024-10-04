---
title: API Público y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para PHP a través de Java 15.5.0
type: docs
weight: 130
url: /es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/), métodos, propiedades, etc., cualquier nueva restricción y otros [cambios](/slides/es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) introducidos con el API de Aspose.Slides para PHP a través de Java 15.5.0.

{{% /alert %}} 
## **Cambios en la API Pública**
### **Se han añadido la clase CommonSlideViewProperties y la interfaz ICommonSlideViewProperties**
La clase com.aspose.slides.CommonSlideViewProperties (y su interfaz com.aspose.slides.ICommonSlideViewProperties) representa propiedades comunes de vista de diapositiva (actualmente opciones de escala de vista).
### **Se han añadido los métodos IAxis.getLabelOffset(), setLabelOffset(int)**
Los métodos IAxis.getLabelOffset(), setLabelOffset(int) permiten obtener y especificar la distancia de las etiquetas desde el eje. Aplicado a ejes de categoría o fecha.
### **Se han añadido los métodos IChartTextBlockFormat.getAutofitType(), setAutofitType(byte)**
Se han añadido los métodos getAutofitType(), setAutofitType(/**TextAutofitType**/byte) a la interfaz com.aspose.slides.IChartTextBlockFormat.
Cambiar este valor puede tener cierta influencia solo en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2013; en PowerPoint 2007 no hay efecto para la representación).
### **Se han añadido los métodos IChartTextBlockFormat.getWrapText(), setWrapText(byte)**
Se han añadido los métodos getWrapText(), setWrapText(/**NullableBool**/byte) a la interfaz com.aspose.slides.IChartTextBlockFormat.
Cambiar este valor puede tener cierta influencia solo en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2007/2013).
### **Se han añadido métodos para gestionar márgenes a IChartTextBlockFormat**
Se han añadido los métodos getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() y setMarginBottom(double) a la interfaz com.aspose.slides.IChartTextBlockFormat.
Cambiar estos valores puede tener cierta influencia solo en estas partes del gráfico: DataLabel y DataLabelFormat (soporte completo en PowerPoint 2013; en PowerPoint 2007 no hay efecto para la representación).
### **Se ha añadido el método ViewProperties.getNotesViewProperties()**
Se ha añadido la propiedad com.aspose.slides.ViewProperties.getNotesViewProperties(). Obtiene propiedades de vista comunes asociadas con el modo de vista de notas.
### **Se ha añadido el método ViewProperties.getSlideViewProperties()**
Se ha añadido el método com.aspose.slides.ViewProperties.getSlideViewProperties(). Obtiene propiedades de vista comunes asociadas con el modo de vista de diapositivas.