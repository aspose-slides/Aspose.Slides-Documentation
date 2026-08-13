---
title: Administrar fuentes en presentaciones en Android
linktitle: Administrar fuentes
type: docs
weight: 10
url: /es/androidjava/manage-fonts/
keywords:
- administrar fuentes
- propiedades de fuente
- párrafo
- formato de texto
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Controla las fuentes en Java con Aspose.Slides para Android: incrusta, sustituye y carga fuentes personalizadas para que las presentaciones PPT, PPTX y ODP sean claras, seguras para la marca y consistentes."
---
## **Visión general**

Aspose.Slides le permite gestionar las propiedades de la fuente en el texto de una presentación directamente desde su código. Puede acceder al texto de las diapositivas a través de formas, marcos de texto, párrafos y porciones, y luego aplicar formato al texto seleccionado.

Este artículo explica cómo configurar propiedades relacionadas con la fuente para texto existente en una presentación, incluidos la familia tipográfica, los estilos negrita e itálica, la alineación de párrafo y el color de la fuente. También muestra cómo crear un cuadro de texto, añadir texto a él y establecer propiedades tipográficas como familia, negrita, itálica, subrayado, tamaño y color antes de guardar el resultado como archivo PPTX.

## **Gestionar propiedades de fuente**
{{% alert color="info" %}} 

Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas o para cumplir con estilos corporativos. El formato del texto ayuda a los usuarios a variar el aspecto del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides para Android mediante Java para configurar las propiedades tipográficas de los párrafos de texto en las diapositivas.

{{% /alert %}} 

Para gestionar las propiedades de fuente de un párrafo con Aspose.Slides para Android mediante Java:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation).
1. Obtener la referencia de una diapositiva usando su índice.
1. Acceder a las formas [MarcadorDe posición](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/placeholder/) en la diapositiva y convertirlas a [AutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/autoshape/).
1. Obtener el [Párrafo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraph/) del [MarcoDeTexto](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textframe/) expuesto por [AutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/autoshape/).
1. Justificar el párrafo.
1. Acceder al [Texto](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraph/) de una [Porción](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/portion/).
1. Definir la fuente mediante [FontData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontdata/) y establecer la **Fuente** de la [Porción](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/portion/) correspondiente.
   1. Establecer la fuente en negrita.
   1. Establecer la fuente en itálica.
1. Establecer el color de la fuente mediante [FillFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fillformat/) expuesto por el objeto [Porción](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/portion/).
1. Guardar la presentación modificada en un archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación. Toma una presentación sin adornos y formatea las fuentes en una de las diapositivas. Las capturas de pantalla que siguen muestran el archivo de entrada y cómo los fragmentos de código lo modifican. El código cambia la fuente, el color y el estilo tipográfico.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: El texto en el archivo de entrada**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: El mismo texto con formato actualizado**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Acceder a una diapositiva usando su posición
	ISlide slide = pres.getSlides().get_Item(0);

	// Acceder al primer y segundo marcador de posición en la diapositiva y convertirlo a AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Acceder al primer párrafo
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Justificar el párrafo
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Acceder a la primera porción
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definir fuentes nuevas
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Asignar fuentes nuevas a la porción
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Establecer la fuente en negrita
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Establecer la fuente en cursiva
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Establecer el color de la fuente
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Guardar el PPTX en disco
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Establecer propiedades de fuente del texto**
{{% alert color="info" %}} 

Como se mencionó en **Gestionar propiedades de fuente**, una [Porción](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/portion/) se utiliza para contener texto con un estilo de formato similar dentro de un párrafo. Este artículo muestra cómo usar Aspose.Slides para Android mediante Java para crear un cuadro de texto con algún contenido y luego definir una fuente concreta, así como varias propiedades adicionales de la categoría de familia tipográfica.

{{% /alert %}} 

Para crear un cuadro de texto y establecer propiedades tipográficas del texto que contiene:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation).
1. Obtener la referencia de una diapositiva usando su índice.
1. Añadir a la diapositiva una [AutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/autoshape/) del tipo **Rectángulo**.
1. Eliminar el estilo de relleno asociado a la [AutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/autoshape/).
1. Acceder al [MarcoDeTexto](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textframe/) de la [AutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/autoshape/).
1. Añadir texto al [MarcoDeTexto](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textframe/).
1. Acceder al objeto [Porción](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/portion/) asociado al [MarcoDeTexto](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textframe/).
1. Definir la fuente que se usará para la [Porción](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/portion/).
1. Establecer otras propiedades tipográficas como negrita, itálica, subrayado, color y altura mediante las propiedades correspondientes del objeto [Porción](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/portion/).
1. Guardar la presentación modificada como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Texto con algunas propiedades de fuente establecidas por Aspose.Slides para Android mediante Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
	// Obtener la primera diapositiva
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Añadir un AutoShape de tipo Rectángulo
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Eliminar cualquier estilo de relleno asociado al AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Acceder al TextFrame asociado al AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Acceder a la Porción asociada al TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Establecer la fuente para la Porción
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Establecer la propiedad Negrita de la fuente
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Establecer la propiedad Cursiva de la fuente
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Establecer la propiedad Subrayado de la fuente
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Establecer la altura de la fuente
	port.getPortionFormat().setFontHeight(25);
	
	// Establecer el color de la fuente
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Guardar la presentación en disco
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```