---
title: Gestionar fuentes en presentaciones en Android
linktitle: Gestionar fuentes
type: docs
weight: 10
url: /es/androidjava/manage-fonts/
keywords:
- gestionar fuentes
- propiedades de fuente
- párrafo
- formato de texto
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Controla fuentes en Java con Aspose.Slides para Android: incrusta, sustituye y carga fuentes personalizadas para mantener las presentaciones PPT, PPTX y ODP claras, seguras para la marca y coherentes."
---

## **Administrar propiedades relacionadas con la fuente**
{{% alert color="primary" %}} 

Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas o para ajustarse a los estilos corporativos. El formato de texto ayuda a los usuarios a variar el aspecto y la sensación del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides for Android via Java para configurar las propiedades de fuente de los párrafos de texto en diapositivas.

{{% /alert %}} 

Para gestionar las propiedades de fuente de un párrafo usando Aspose.Slides for Android via Java:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtener la referencia de una diapositiva usando su índice.
1. Acceder a las formas [Placeholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) en la diapositiva y convertirlas a [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. Obtener el [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) del [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) expuesto por [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. Justificar el párrafo.
1. Acceder al [Portion] de texto de un [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
1. Definir la fuente usando [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) y establecer la **Font** del [Portion] de texto en consecuencia.
   1. Establecer la fuente en negrita.
   1. Establecer la fuente en cursiva.
1. Establecer el color de la fuente usando el [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) expuesto por el objeto [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/).
1. Guardar la presentación modificada en un archivo PPTX.

Se muestra a continuación la implementación de los pasos anteriores. Toma una presentación sin adornos y formatea las fuentes en una de las diapositivas. Las capturas de pantalla que siguen muestran el archivo de entrada y cómo los fragmentos de código lo modifican. El código cambia la fuente, el color y el estilo de la fuente.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: El texto en el archivo de entrada**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: El mismo texto con formato actualizado**|
```java
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

	// Definir nuevas fuentes
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Asignar nuevas fuentes a la porción
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
{{% alert color="primary" %}} 

Como se menciona en **Administrar propiedades relacionadas con la fuente**, un [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) se usa para contener texto con un estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides for Android via Java para crear un cuadro de texto con algún texto y luego definir una fuente concreta, así como varias otras propiedades de la categoría de familia tipográfica.

{{% /alert %}} 

Para crear un cuadro de texto y establecer las propiedades de fuente del texto en él:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtener la referencia de una diapositiva usando su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) de tipo **Rectangle** a la diapositiva.
1. Eliminar el estilo de relleno asociado al [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. Acceder al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) del [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/).
1. Añadir texto al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).
1. Acceder al objeto [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) asociado al [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/).
1. Definir la fuente a usar para el [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/).
1. Establecer otras propiedades de la fuente como negrita, cursiva, subrayado, color y altura usando las propiedades correspondientes expuestas por el objeto [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/).
1. Escribir la presentación modificada como un archivo PPTX.

A continuación se muestra la implementación de los pasos anteriores.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Texto con algunas propiedades de fuente establecidas por Aspose.Slides for Android via Java**|
```java
// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
	// Obtener la primera diapositiva
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Añadir un AutoShape de tipo Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Eliminar cualquier estilo de relleno asociado al AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Acceder al TextFrame asociado al AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Acceder a la Portion asociada al TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Establecer la fuente para la Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Establecer la propiedad negrita de la fuente
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Establecer la propiedad cursiva de la fuente
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Establecer la propiedad subrayado de la fuente
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
