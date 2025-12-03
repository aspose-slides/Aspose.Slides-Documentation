---
title: Formatear texto de PowerPoint en Java
linktitle: Formateo de texto
type: docs
weight: 50
url: /es/java/text-formatting/
keywords:
- resaltar texto
- expresión regular
- alinear párrafo
- estilo de texto
- fondo de texto
- transparencia de texto
- espaciado de caracteres
- propiedades de fuente
- familia de fuentes
- rotación de texto
- ángulo de rotación
- marco de texto
- interlineado
- propiedad autofit
- ancla del marco de texto
- tabulación de texto
- idioma predeterminado
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Formatea y da estilo al texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Java. Personaliza fuentes, colores, alineación y más."
---

## **Resaltar texto**
El método [highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) ha sido añadido a la interfaz [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) y a la clase [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

Permite resaltar una parte del texto con color de fondo usando una muestra de texto, similar a la herramienta Color de resaltado de texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta función:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // resaltando todas las palabras 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// resaltando todas las ocurrencias separadas de 'the'
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

Aspose ofrece un sencillo, [servicio gratuito de edición de PowerPoint en línea](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Resaltar texto usando expresión regular**
El método [highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) ha sido añadido a la interfaz [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) y a la clase [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

Permite resaltar una parte del texto con color de fondo usando una expresión regular, similar a la herramienta Color de resaltado de texto en PowerPoint 2019.

El fragmento de código a continuación muestra cómo usar esta función:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // resaltando todas las palabras con 10 símbolos o más
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer color de fondo del texto**
Aspose.Slides le permite especificar el color preferido para el fondo de un texto.

Este código Java muestra cómo establecer el color de fondo para un texto completo:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
    portion3.getPortionFormat().setFontBold(NullableBool.True);

    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);

    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    StreamSupport.stream(autoShape.getTextFrame().getParagraphs().spliterator(), false)
            .map(p -> p.getPortions())
            .forEach(c -> c.forEach(ic -> ic.getPortionFormat().getHighlightColor().setColor(Color.BLUE)));

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


Este código Java muestra cómo establecer el color de fondo para solo una parte de un texto:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Black");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Red ");

    Portion portion3 = new Portion("Black");
    portion3.getPortionFormat().setFontBold(NullableBool.True);
    
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    
    pres.save("text.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

Presentation presentation = new Presentation("text.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    Optional<IPortion> redPortion = StreamSupport.stream(autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false)
            .filter(p -> p.getText().contains("Red"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Alinear párrafos de texto**
El formato de texto es uno de los elementos clave al crear cualquier tipo de documento o presentación. Sabemos que Aspose.Slides for Java admite la inserción de texto en diapositivas, pero en este tema veremos cómo controlar la alineación de los párrafos de texto en una diapositiva. Siga los pasos a continuación para alinear los párrafos de texto usando Aspose.Slides for Java:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtener la referencia de una diapositiva usando su índice.
3. Acceder a las formas de marcador de posición presentes en la diapositiva y convertirlas a un [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
4. Obtener el párrafo (que debe alinearse) del [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#getTextFrame--) expuesto por el [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. Alinear el párrafo. Un párrafo puede alinearse a la derecha, izquierda, centro o justificado.
6. Guardar la presentación modificada como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```java
// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Accediendo al primer y segundo placeholder en la diapositiva y convirtiéndolo a AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Cambiar el texto en ambos placeholders
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // Obtener el primer párrafo de los placeholders
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Alinear el párrafo de texto al centro
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // Escribir la presentación como un archivo PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer transparencia para el texto**
Este artículo demuestra cómo establecer la propiedad de transparencia a cualquier forma de texto usando Aspose.Slides for Java. Para establecer la transparencia al texto, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtener la referencia de una diapositiva.
3. Establecer el color de la sombra
4. Guardar la presentación como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparency is: "+ (shadowColor.getAlpha() / 255f) * 100);

    // establecer la transparencia a cero por ciento
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer espaciado de caracteres para el texto**
Aspose.Slides permite establecer el espacio entre letras en un cuadro de texto. De esta manera, puede ajustar la densidad visual de una línea o bloque de texto ampliando o condensando el espaciado entre caracteres.

Este código Java muestra cómo ampliar el espaciado para una línea de texto y condensar el espaciado para otra línea:
```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // expandir
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // condensar

presentation.save("out.pptx", SaveFormat.Pptx);
```


## **Administrar propiedades de fuente del párrafo**
Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas o para cumplir con estilos corporativos. El formato de texto ayuda a los usuarios a variar la apariencia del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides for Java para configurar las propiedades de fuente de los párrafos de texto en las diapositivas. Para administrar las propiedades de fuente de un párrafo usando Aspose.Slides for Java:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva usando su índice.
1. Acceder a las formas de marcador de posición en la diapositiva y convertirlas a [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Obtener el [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) del [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) expuesto por el [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Justificar el párrafo.
1. Acceder al Portion de texto del párrafo.
1. Definir la fuente usando FontData y establecer la fuente del Portion de texto en consecuencia.
   1. Establecer la fuente en negrita.
   1. Establecer la fuente en cursiva.
1. Establecer el color de la fuente usando el [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#getFillFormat--) expuesto por el objeto [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
1. Guardar la presentación modificada en un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

La implementación de los pasos anteriores se muestra a continuación. Toma una presentación sin adornos y formatea las fuentes en una de las diapositivas.
```java
// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Accediendo a una diapositiva usando su posición
    ISlide slide = pres.getSlides().get_Item(0);

    // Accediendo al primer y segundo marcador de posición en la diapositiva y convirtiéndolo a AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Accediendo al primer párrafo
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Accediendo a la primera porción
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // Definir nuevas fuentes
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Asignar nuevas fuentes a la porción
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // Establecer fuente en negrita
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Establecer fuente en cursiva
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // Establecer color de fuente
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    //Escribir el PPTX en disco
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Administrar familia de fuentes del texto**
Un Portion se utiliza para contener texto con estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides for Java para crear un cuadro de texto con algo de texto y luego definir una fuente específica, así como diversas propiedades de la familia de fuentes. Para crear un cuadro de texto y establecer propiedades de fuente del texto en él:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtener la referencia de una diapositiva usando su índice.
3. Añadir un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) del tipo [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) a la diapositiva.
4. Eliminar el estilo de relleno asociado al [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. Acceder al TextFrame del AutoShape.
6. Añadir texto al TextFrame.
7. Acceder al objeto Portion asociado al [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
8. Definir la fuente que se usará para el [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
9. Establecer otras propiedades de fuente como negrita, cursiva, subrayado, color y tamaño usando las propiedades relevantes expuestas por el objeto Portion.
10. Guardar la presentación modificada como archivo PPTX.

La implementación de los pasos anteriores se muestra a continuación.
```java
// Instanciar una Presentation
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

    // Establecer la propiedad Bold de la fuente
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Establecer la propiedad Italic de la fuente
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Establecer la propiedad Underline de la fuente
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // Establecer la altura de la fuente
    port.getPortionFormat().setFontHeight(25);

    // Establecer el color de la fuente
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Escribir el PPTX en disco 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer tamaño de fuente para el texto**
Aspose.Slides permite elegir el tamaño de fuente preferido para el texto existente en un párrafo y para otros textos que puedan añadirse al párrafo posteriormente.

Este código Java muestra cómo establecer el tamaño de fuente para los textos contenidos en un párrafo:
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Obtiene la primera forma, por ejemplo.
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape )
    {
        IAutoShape autoShape = (AutoShape) shape;
        // Obtiene el primer párrafo, por ejemplo.
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

        // Establece el tamaño de fuente predeterminado a 20 pt para todas las porciones de texto en el párrafo. 
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);

        // Establece el tamaño de fuente a 20 pt para las porciones de texto actuales en el párrafo. 
        for(IPortion portion : paragraph.getPortions())
        {
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Establecer rotación del texto**
Aspose.Slides for Java permite a los desarrolladores rotar el texto. El texto puede configurarse para aparecer como [Horizontal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) o [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Para rotar el texto de cualquier TextFrame, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Acceder a la primera diapositiva.
3. Añadir cualquier forma a la diapositiva.
4. Acceder al [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Rotar el texto](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Guardar el archivo en disco.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregar un AutoShape de tipo Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Agregar un TextFrame al rectángulo
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Acceder al marco de texto
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Crear el objeto Paragraph para el TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Crear el objeto Portion para el párrafo
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Guardar la presentación
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer ángulo de rotación personalizado para TextFrame**
Aspose.Slides for Java ahora admite establecer un ángulo de rotación personalizado para TextFrame. En este tema, veremos con un ejemplo cómo establecer la propiedad RotationAngle en Aspose.Slides. Los nuevos métodos [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) y [getRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) se han añadido a las interfaces [IChartTextBlockFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) y [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat), y permiten establecer el ángulo de rotación personalizado para TextFrame. Para establecer RotationAngle, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Añadir un gráfico a la diapositiva.
3. [Establecer la propiedad RotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Guardar la presentación como archivo PPTX.

En el ejemplo a continuación, establecemos la propiedad RotationAngle.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadir un AutoShape de tipo Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Añadir TextFrame al rectángulo
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accediendo al marco de texto
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Crear el objeto Paragraph para el TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Crear el objeto Portion para el párrafo
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Guardar la presentación
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Interlineado del párrafo**
Aspose.Slides proporciona propiedades bajo [`ParagraphFormat`](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` y `SpaceWithin`—que permiten gestionar el interlineado de un párrafo. Las tres propiedades se usan de la siguiente manera:

* Para especificar el interlineado de un párrafo en porcentaje, use un valor positivo. 
* Para especificar el interlineado de un párrafo en puntos, use un valor negativo.

Por ejemplo, puede aplicar un interlineado de 16 pt a un párrafo estableciendo la propiedad `SpaceBefore` a -16.

Así es como especifica el interlineado para un párrafo específico:

1. Cargar una presentación que contenga un AutoShape con texto.
2. Obtener la referencia de una diapositiva mediante su índice.
3. Acceder al TextFrame.
4. Acceder al Paragraph.
5. Establecer las propiedades del Paragraph.
6. Guardar la presentación.

Este código Java muestra cómo especificar el interlineado para un párrafo:
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Obtener la referencia de una diapositiva por su índice
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Acceder al TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Acceder al párrafo
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Establecer propiedades del párrafo
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Guardar la presentación
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer la propiedad AutofitType para TextFrame**
En este tema exploraremos las diferentes propiedades de formato de un cuadro de texto. Este artículo cubre cómo establecer la propiedad AutofitType de un cuadro de texto, el ancla del texto y la rotación del texto en una presentación. Aspose.Slides for Java permite a los desarrolladores establecer la propiedad AutofitType de cualquier cuadro de texto. AutofitType puede establecerse en [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) o [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape). Si se establece en [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal), la forma permanecerá igual mientras el texto se ajusta sin modificar la forma; si AutofitType se establece en [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape), la forma se modificará de modo que solo contenga el texto necesario. Para establecer la propiedad AutofitType de un cuadro de texto, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation ](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Acceder a la primera diapositiva.
3. Añadir cualquier forma a la diapositiva.
4. Acceder al [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Establecer el AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) del TextFrame.
6. Guardar el archivo en disco.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Acceder a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadir un AutoShape de tipo Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // Añadir TextFrame al rectángulo
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accediendo al marco de texto
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Crear el objeto Paragraph para el marco de texto
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Crear el objeto Portion para el párrafo
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Guardar la presentación
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer ancla de TextFrame**
Aspose.Slides for Java permite a los desarrolladores anclar cualquier TextFrame. TextAnchorType especifica dónde se coloca el texto dentro de la forma. AnchorType puede establecerse en [Top](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) o [Distributed](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed). Para establecer el ancla de cualquier TextFrame, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Acceder a la primera diapositiva.
3. Añadir cualquier forma a la diapositiva.
4. Acceder al [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Establecer TextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) del TextFrame.
6. Guardar el archivo en disco.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadir un AutoShape de tipo Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Añadir TextFrame al rectángulo
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Accediendo al marco de texto
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Crear el objeto Paragraph para el marco de texto
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Crear el objeto Portion para el párrafo
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Guardar la presentación
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Tabulaciones y EffectiveTabs en la presentación**
Todas las tabulaciones de texto se expresan en píxeles.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|
- EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- La colección EffectiveTabs incluye todas las tabulaciones (de la colección Tabs y las tabulaciones predeterminadas).
- EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) muestra la distancia entre las tabulaciones predeterminadas (3 y 4 en nuestro ejemplo).
- EffectiveTabs.GetTabByIndex(index) con index = 0 devolverá la primera tabulación explícita (Position = 731), index = 1 la segunda tabulación (Position = 1241). Si intenta obtener la siguiente tabulación con index = 2 devolverá la primera tabulación predeterminada (Position = 1470) y así sucesivamente.
- EffectiveTabs.GetTabAfterPosition(pos) se usa para obtener la tabulación siguiente después de algún texto. Por ejemplo, tiene el texto: "Hello World!". Para renderizar dicho texto debe saber dónde comenzar a dibujar "world!". Primero, calcule la longitud de "Hello" en píxeles y llame a GetTabAfterPosition con este valor. Obtendrá la posición de la siguiente tabulación para dibujar "world!".

## **Establecer estilo de texto predeterminado**
Si necesita aplicar el mismo formato de texto predeterminado a todos los elementos de texto de una presentación a la vez, puede usar el método `getDefaultTextStyle` de la interfaz [IPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/) y establecer el formato preferido. El siguiente ejemplo de código muestra cómo establecer la fuente en negrita predeterminada (14 pt) para el texto en todas las diapositivas de una nueva presentación.
```java
Presentation presentation = new Presentation();
try {
    // Obtener el formato de párrafo de nivel superior.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("DefaultTextStyle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Extraer texto con el efecto mayúsculas**
En PowerPoint, aplicar el efecto de fuente **All Caps** hace que el texto aparezca en mayúsculas en la diapositiva incluso cuando originalmente se escribió en minúsculas. Cuando recupera dicha porción de texto con Aspose.Slides, la biblioteca devuelve el texto exactamente como se ingresó. Para manejar esto, verifique [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/)—si indica `All`, simplemente convierta la cadena devuelta a mayúsculas para que la salida coincida con lo que los usuarios ven en la diapositiva.

Supongamos que tenemos el siguiente cuadro de texto en la primera diapositiva del archivo sample2.pptx.

![The All Caps effect](all_caps_effect.png)

El siguiente ejemplo de código muestra cómo extraer el texto con el efecto **All Caps** aplicado:
```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    IPortion textPortion = paragraph.getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```


Salida:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **Preguntas frecuentes**

**¿Cómo modificar texto en una tabla en una diapositiva?**

Para modificar texto en una tabla en una diapositiva, necesita usar la interfaz [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Puede iterar todas las celdas de la tabla y cambiar el texto en cada celda accediendo a sus propiedades `TextFrame` y `ParagraphFormat` dentro de cada celda.

**¿Cómo aplicar color degradado al texto en una diapositiva de PowerPoint?**

Para aplicar color degradado al texto, use el método `getFillFormat` en [BasePortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/). Establezca `FilFormat` a `Gradient`, donde podrá definir los colores de inicio y fin del degradado, junto con otras propiedades como dirección y transparencia para crear el efecto degradado en el texto.