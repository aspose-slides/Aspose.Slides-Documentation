---
title: Gestionar Fuentes - PowerPoint Java API
linktitle: Gestionar Fuentes
type: docs
weight: 10
url: /es/java/manage-fonts/
description: Las presentaciones generalmente contienen tanto texto como imágenes. Este artículo muestra cómo utilizar la API de PowerPoint Java para configurar las propiedades de fuente de los párrafos de texto en las diapositivas.
---

## **Gestionar Propiedades Relacionadas con Fuentes**
{{% alert color="primary" %}} 

Las presentaciones generalmente contienen tanto texto como imágenes. El texto se puede formatear de diversas maneras, ya sea para resaltar secciones y palabras específicas o para conformarse con estilos corporativos. El formateo del texto ayuda a los usuarios a variar la apariencia y la sensación del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides para Java para configurar las propiedades de fuente de los párrafos de texto en las diapositivas.

{{% /alert %}} 

Para gestionar las propiedades de la fuente de un párrafo utilizando Aspose.Slides para Java:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtén la referencia de una diapositiva utilizando su índice.
1. Accede a las formas [Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Placeholder) en la diapositiva y realízales un typecast a [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Obtén el [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph) del [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) expuesto por [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Justifica el párrafo.
1. Accede al [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) de texto de un [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph).
1. Define la fuente utilizando [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FontData) y establece la **Fuente** del texto [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) en consecuencia.
   1. Establece la fuente en negrita.
   1. Establece la fuente en cursiva.
1. Establece el color de la fuente utilizando el [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FillFormat) expuesto por el objeto [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. Guarda la presentación modificada en un archivo PPTX.

La implementación de los pasos anteriores se presenta a continuación. Toma una presentación simple y formatea las fuentes en una de las diapositivas. Las capturas de pantalla que siguen muestran el archivo de entrada y cómo los fragmentos de código lo modifican. El código cambia la fuente, el color y el estilo de la fuente.

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
	// Accediendo a una diapositiva usando su posición en la diapositiva
	ISlide slide = pres.getSlides().get_Item(0);

	// Accediendo al primer y segundo placeholder en la diapositiva y realizándole un typecast a AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Accediendo al primer Paragraph
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Justificar el párrafo
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Accediendo al primer portion
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definir nuevas fuentes
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Asignar nuevas fuentes al portion
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Establecer la fuente en Negrita
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Establecer la fuente en Cursiva
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

## **Establecer Propiedades de Fuente de Texto**
{{% alert color="primary" %}} 

Como se mencionó en **Gestionando Propiedades Relacionadas con Fuentes**, un [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) se utiliza para contener texto con un estilo de formateo similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides para Java para crear un cuadro de texto con algo de texto y luego definir una fuente particular, y varias otras propiedades de la categoría de fuentes.

{{% /alert %}} 

Para crear un cuadro de texto y establecer propiedades de fuente del texto en él:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtén la referencia de una diapositiva utilizando su índice.
1. Agrega un [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape) del tipo **Rectángulo** a la diapositiva.
1. Elimina el estilo de relleno asociado con el [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Accede al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) del [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Agrega algo de texto al [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame).
1. Accede al objeto [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) asociado con el [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame).
1. Define la fuente que se utilizará para el [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. Establece otras propiedades de la fuente como negrita, cursiva, subrayado, color y altura utilizando las propiedades relevantes expuestas por el objeto [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. Escribe la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se presenta a continuación.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Texto con algunas propiedades de fuente establecidas por Aspose.Slides para Java**|

```java
// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
	// Obtener la primera diapositiva
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Agregar un AutoShape de tipo Rectángulo
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Eliminar cualquier estilo de relleno asociado con el AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Acceder al TextFrame asociado con el AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Acceder al Portion asociado con el TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Establecer la Fuente para el Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Establecer la propiedad Negrita de la Fuente
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Establecer la propiedad Cursiva de la Fuente
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Establecer la propiedad Subrayado de la Fuente
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Establecer la Altura de la Fuente
	port.getPortionFormat().setFontHeight(25);
	
	// Establecer el color de la Fuente
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Guardar la presentación en disco
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```