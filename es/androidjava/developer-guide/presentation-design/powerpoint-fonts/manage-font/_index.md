---
title: Administrar Fuentes - PowerPoint Java API
linktitle: Administrar Fuentes
type: docs
weight: 10
url: /androidjava/manage-fonts/
description: Las presentaciones suelen contener tanto texto como imágenes. Este artículo muestra cómo utilizar la API de PowerPoint Java para configurar las propiedades de fuente de los párrafos de texto en las diapositivas.
---

## **Administrar Propiedades Relacionadas con la Fuente**
{{% alert color="primary" %}} 

Las presentaciones suelen contener tanto texto como imágenes. El texto se puede formatear de diversas maneras, ya sea para resaltar secciones y palabras específicas o para ajustarse a estilos corporativos. El formato de texto ayuda a los usuarios a variar la apariencia y la sensación del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides para Android a través de Java para configurar las propiedades de fuente de los párrafos de texto en las diapositivas.

{{% /alert %}} 

Para gestionar las propiedades de fuente de un párrafo utilizando Aspose.Slides para Android a través de Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenga una referencia de la diapositiva utilizando su índice.
1. Acceda a las formas [Placeholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Placeholder) en la diapositiva y conviértalas a [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. Obtenga el [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Paragraph) del [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) expuesto por [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. Justifique el párrafo.
1. Acceda a la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) de texto de un [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Paragraph).
1. Defina la fuente utilizando [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/FontData) y establezca la **Fuente** del texto [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) en consecuencia.
   1. Establezca la fuente en negrita.
   1. Establezca la fuente en cursiva.
1. Establezca el color de la fuente utilizando el [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/FillFormat) expuesto por el objeto [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion).
1. Guarde la presentación modificada en un archivo PPTX.

A continuación se presenta la implementación de los pasos anteriores. Toma una presentación sin adornos y formatea las fuentes en una de las diapositivas. Las capturas de pantalla que siguen muestran el archivo de entrada y cómo los fragmentos de código lo cambian. El código cambia la fuente, el color y el estilo de fuente.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figura: El texto en el archivo de entrada**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figura: El mismo texto con formato actualizado**|

```java
// Instancia un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Accediendo a una diapositiva utilizando su posición en la diapositiva
	ISlide slide = pres.getSlides().get_Item(0);

	// Accediendo al primer y segundo placeholder en la diapositiva y convirtiéndolo como AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Accediendo al primer Paragraph
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Justifique el párrafo
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Accediendo a la primera portion
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Definir nuevas fuentes
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Asignar nuevas fuentes a la portion
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

## **Establecer Propiedades de Fuente de Texto**
{{% alert color="primary" %}} 

Como se mencionó en **Administrar Propiedades Relacionadas con la Fuente**, una [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) se utiliza para contener texto con un estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides para Android a través de Java para crear un cuadro de texto con algo de texto y luego definir una fuente particular, y varias otras propiedades de la categoría de familia de fuentes.

{{% /alert %}} 

Para crear un cuadro de texto y establecer propiedades de fuente del texto en él:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue un [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape) del tipo **Rectángulo** a la diapositiva.
1. Elimine el estilo de relleno asociado con el [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. Acceda a la [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) del [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/AutoShape).
1. Agregue algo de texto a la [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame).
1. Acceda al objeto [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) asociado con la [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame).
1. Defina la fuente que se utilizará para la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion).
1. Establezca otras propiedades de la fuente como negrita, cursiva, subrayado, color y altura utilizando las propiedades relevantes expuestas por el objeto [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion).
1. Escriba la presentación modificada como un archivo PPTX.

A continuación se presenta la implementación de los pasos anteriores.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figura: Texto con algunas propiedades de fuente establecidas por Aspose.Slides para Android a través de Java**|

```java
// Instancia un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation();
try {
	// Obtiene la primera diapositiva
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Agrega un AutoShape de tipo Rectángulo
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Elimina cualquier estilo de relleno asociado con el AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Accede a la TextFrame asociada con el AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Accede a la Portion asociada con la TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Establece la Fuente para la Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Establece la propiedad Negrita de la Fuente
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Establece la propiedad Cursiva de la Fuente
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Establece la propiedad Subrayado de la Fuente
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Establece la Altura de la Fuente
	port.getPortionFormat().setFontHeight(25);
	
	// Establece el color de la Fuente
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Guarda la presentación en disco
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```