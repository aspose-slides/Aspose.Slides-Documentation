---
title: Formateo de Texto
type: docs
weight: 50
url: /java/text-formatting/
keywords:
- resaltar texto
- expresión regular
- alinear párrafos de texto
- transparencia del texto
- propiedades de la fuente del párrafo
- familia de fuentes
- rotación del texto
- rotación de ángulo personalizado
- marco de texto
- interlineado
- propiedad autofit
- ancla del marco de texto
- tabulación de texto
- estilo de texto predeterminado
- Java
- Aspose.Slides para Java
description: "Gestionar y manipular propiedades del texto y del marco de texto en Java"
---

## **Resaltar Texto**
El método [highlightText](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) se ha añadido a la interfaz [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) y a la clase [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

Permite resaltar una parte del texto con un color de fondo usando una muestra de texto, similar a la herramienta de Color de Resaltado de Texto en PowerPoint 2019.

El siguiente fragmento de código muestra cómo utilizar esta función:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // resaltando todas las palabras 'importante'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// resaltando todas las ocurrencias separadas de 'the'
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Aspose proporciona un sencillo [servicio de edición de PowerPoint en línea gratuito](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Resaltar Texto usando Expresión Regular**

El método [highlightRegex](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) se ha añadido a la interfaz [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) y a la clase [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame).

Permite resaltar una parte del texto con un color de fondo usando regex, similar a la herramienta de Color de Resaltado de Texto en PowerPoint 2019.

El siguiente fragmento de código muestra cómo utilizar esta función:

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

## **Establecer Color de Fondo del Texto**

Aspose.Slides te permite especificar tu color preferido para el fondo de un texto.

Este código Java muestra cómo establecer el color de fondo para todo el texto:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();

    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Negro");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Rojo ");

    Portion portion3 = new Portion("Negro");
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

Este código Java muestra cómo establecer el color de fondo solo para una porción de un texto:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    
    Paragraph para = new Paragraph();

    Portion portion1 = new Portion("Negro");
    portion1.getPortionFormat().setFontBold(NullableBool.True);

    Portion portion2 = new Portion(" Rojo ");

    Portion portion3 = new Portion("Negro");
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
            .filter(p -> p.getText().contains("Rojo"))
            .findFirst();

    if(redPortion.isPresent())
        redPortion.get().getPortionFormat().getHighlightColor().setColor(Color.RED);

    presentation.save("text-red.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Alinear Párrafos de Texto**

El formateo de texto es uno de los elementos clave al crear cualquier tipo de documentos o presentaciones. Sabemos que Aspose.Slides para Java admite la adición de texto a las diapositivas, pero en este tema, veremos cómo podemos controlar la alineación de los párrafos de texto en una diapositiva. Siga los pasos a continuación para alinear los párrafos de texto utilizando Aspose.Slides para Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva utilizando su índice.
3. Acceda a las formas de marcador de posición presentes en la diapositiva y conviértalas en [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
4. Obtenga el párrafo (que necesita ser alineado) del [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#getTextFrame--) expuesto por [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. Alinee el párrafo. Un párrafo puede alinearse a la derecha, a la izquierda, al centro y justificar.
6. Escriba la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se presenta a continuación.

```java
// Instanciar un objeto Presentation que representa un archivo PPTX
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Accediendo al primer y segundo marcador de posición en la diapositiva y convirtiéndolos en AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Cambiando el texto en ambos marcadores de posición
    tf1.setText("Alineación al centro por Aspose");
    tf2.setText("Alineación al centro por Aspose");

    // Obteniendo el primer párrafo de los marcadores de posición
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Alineando el párrafo de texto al centro
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    // Escribiendo la presentación como un archivo PPTX
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Transparencia para el Texto**
Este artículo demuestra cómo establecer la propiedad de transparencia a cualquier forma de texto utilizando Aspose.Slides para Java. Para establecer la transparencia en el texto, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva.
3. Establezca el color de sombra.
4. Escriba la presentación como un archivo PPTX.

La implementación de los pasos anteriores se presenta a continuación.

```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - la transparencia es: "+ (shadowColor.getAlpha() / 255f) * 100);

    // establecer transparencia al cero por ciento
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Espaciado de Caracteres para el Texto**

Aspose.Slides te permite establecer el espacio entre letras en un cuadro de texto. De esta manera, puedes ajustar la densidad visual de una línea o bloque de texto expandiendo o condensando el espaciado entre caracteres.

Este código Java muestra cómo expandir el espaciado para una línea de texto y condensar el espaciado para otra línea:

```java
Presentation presentation = new Presentation("in.pptx");

IAutoShape textBox1 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
IAutoShape textBox2 = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(1);

textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20); // expandir
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2); // condensar

presentation.save("out.pptx", SaveFormat.Pptx);
```

## **Gestionar Propiedades de Fuente de los Párrafos**

Las presentaciones suelen contener tanto texto como imágenes. El texto puede formatearse de diversas maneras, ya sea para resaltar secciones y palabras específicas, o para conformarse con estilos corporativos. El formateo de texto ayuda a los usuarios a variar la apariencia del contenido de la presentación. Este artículo muestra cómo usar Aspose.Slides para Java para configurar las propiedades de fuente de los párrafos de texto en las diapositivas. Para gestionar las propiedades de fuente de un párrafo utilizando Aspose.Slides para Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Acceda a las formas de marcador de posición en la diapositiva y conviértalas en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Obtenga el [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) de la [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) expuesta por [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Justifique el párrafo.
1. Acceda a la porción de texto de un párrafo.
1. Defina la fuente utilizando FontData y establezca la fuente de la porción de texto en consecuencia.
   1. Establezca la fuente en negrita.
   1. Establezca la fuente en cursiva.
1. Establezca el color de fuente utilizando el [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#getFillFormat--) expuesto por el objeto [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
1. Escriba la presentación modificada en un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

La implementación de los pasos anteriores se presenta a continuación. Toma una presentación sin adornos y formatea las fuentes en una de las diapositivas.

```java
// Instanciar un objeto Presentación que representa un archivo PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Accediendo a una diapositiva utilizando su posición en la diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Accediendo al primer y segundo marcador de posición en la diapositiva y convirtiéndolos en AutoShape
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

    // Establecer la fuente en Negrita
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Establecer la fuente en Cursiva
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // Establecer el color de la fuente
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Escribir el PPTX en el disco
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestionar Familia de Fuentes del Texto**
Una porción se utiliza para contener texto con un estilo de formato similar en un párrafo. Este artículo muestra cómo usar Aspose.Slides para Java para crear un cuadro de texto con algún texto y luego definir una fuente particular y varias otras propiedades de la categoría de familia de fuentes. Para crear un cuadro de texto y establecer propiedades de fuente del texto en él:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva utilizando su índice.
3. Agregue un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) del tipo [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) a la diapositiva.
4. Elimine el estilo de relleno asociado con el [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. Acceda al TextFrame del AutoShape.
6. Agregue algo de texto al TextFrame.
7. Acceda al objeto Portion asociado con el [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
8. Defina la fuente que se utilizará para la [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/IPortion).
9. Establezca otras propiedades de la fuente como negrita, cursiva, subrayado, color y altura utilizando las propiedades relevantes expuestas por el objeto Portion.
10. Escriba la presentación modificada como un archivo PPTX.

La implementación de los pasos anteriores se presenta a continuación.

```java
// Instanciar Presentación
Presentation pres = new Presentation();
try {

    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agregar un AutoShape de tipo Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Eliminar cualquier estilo de relleno asociado con el AutoShape
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Acceder al TextFrame asociado con el AutoShape
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Cuadro de Texto Aspose");

    // Acceder a la Porción asociada con el TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Establecer la Fuente para la Porción
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

    // Escribir el PPTX en disco 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Tamaño de Fuente para el Texto**

Aspose.Slides te permite elegir tu tamaño de fuente preferido para el texto existente en un párrafo y otros textos que se puedan agregar al párrafo más tarde.

Este código Java muestra cómo establecer el tamaño de la fuente para los textos contenidos en un párrafo:

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

## **Establecer Rotación del Texto**

Aspose.Slides para Java permite a los desarrolladores rotar el texto. El texto puede aparecer como [Horizontal](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) o [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Para rotar el texto de cualquier TextFrame, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Acceda a la primera diapositiva.
3. Agregue cualquier forma a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Rote el texto](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Guarde el archivo en disco.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregar un AutoShape de tipo Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Agregar TextFrame al rectángulo
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Accediendo al marco de texto
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Crear el objeto Párrafo para el marco de texto
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Crear objeto Porción para el párrafo
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Una rápida y marrón zorro salta sobre el perro perezoso. Una rápida y marrón zorro salta sobre el perro perezoso.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Guardar la Presentación
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Ángulo de Rotación Personalizado para TextFrame**
Aspose.Slides para Java ahora permite establecer ángulos de rotación personalizados para el textframe. En este tema, veremos con un ejemplo cómo establecer la propiedad RotationAngle en Aspose.Slides. Los nuevos métodos [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) y [getRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) se han añadido a las interfaces [IChartTextBlockFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) y [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat), que permiten establecer el ángulo de rotación personalizado para el textframe. Para establecer el RotationAngle, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Agregue un gráfico en la diapositiva.
3. [Establezca la propiedad RotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Escriba la presentación como un archivo PPTX.

En el ejemplo dado a continuación, establecemos la propiedad RotationAngle.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregar un AutoShape de tipo Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Agregar TextFrame al rectángulo
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accediendo al marco de texto
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Crear el objeto Párrafo para el marco de texto
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Crear objeto Porción para el párrafo
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Ejemplo de rotación de texto.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Guardar la Presentación
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Espaciado de Línea del Párrafo**
Aspose.Slides proporciona propiedades bajo [`ParagraphFormat`](https://reference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` y `SpaceWithin`—que te permiten gestionar el espaciado de línea para un párrafo. Las tres propiedades se usan de la siguiente manera:

* Para especificar el espaciado de línea para un párrafo en porcentaje, use un valor positivo. 
* Para especificar el espaciado de línea para un párrafo en puntos, use un valor negativo.

Por ejemplo, puedes aplicar un espaciado de línea de 16pt para un párrafo configurando la propiedad `SpaceBefore` a -16.

Así es como especificas el espaciado de línea para un párrafo específico:

1. Carga una presentación que contenga un AutoShape con algo de texto en él.
2. Obtén la referencia de una diapositiva a través de su índice.
3. Accede al TextFrame.
4. Accede al Párrafo.
5. Establece las propiedades del Párrafo.
6. Guarda la presentación.

Este código Java muestra cómo especificar el espaciado de línea para un párrafo:

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Obtener la referencia de una diapositiva por su índice
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Acceder al TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Acceder al Párrafo
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Establecer propiedades del Párrafo
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Guardar la Presentación
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer la Propiedad AutofitType para TextFrame**
En este tema, exploraremos las diferentes propiedades de formateo del marco de texto. Este artículo cubre cómo establecer la propiedad AutofitType del marco de texto, anclar texto y rotar el texto en presentaciones. Aspose.Slides para Java permite a los desarrolladores establecer la propiedad AutofitType de cualquier marco de texto. AutofitType podría establecerse en [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) o [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape). Si se establece en [Normal](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal), la forma permanecerá igual, mientras que el texto se ajustará sin causar que la forma cambie; si AutofitType se establece en [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape), entonces la forma se modificará de tal manera que solo el texto requerido esté contenido en ella. Para establecer la propiedad AutofitType de un marco de texto, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Acceda a la primera diapositiva.
3. Agregue cualquier forma a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Establezca el AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) del TextFrame.
6. Guarde el archivo en disco.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Acceder a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregar un AutoShape de tipo Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // Agregar TextFrame al Rectángulo
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accediendo al marco de texto
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Crear el objeto Párrafo para el marco de texto
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Crear objeto Porción para el párrafo
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Una rápida y marrón zorro salta sobre el perro perezoso. Una rápida y marrón zorro salta sobre el perro perezoso.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Guardar Presentación
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Ancla del TextFrame**
Aspose.Slides para Java permite a los desarrolladores establecer el ancla de cualquier TextFrame. TextAnchorType especifica dónde se coloca ese texto en la forma. El AnclaType podría establecerse en [Top](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) o [Distributed](https://reference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed). Para establecer el ancla de cualquier TextFrame, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Acceda a la primera diapositiva.
3. Agregue cualquier forma a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
5. [Establezca TextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) del TextFrame.
6. Guarde el archivo en disco.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregar un AutoShape de tipo Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Agregar TextFrame al Rectángulo
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Accediendo al marco de texto
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Crear el objeto Párrafo para el marco de texto
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Crear objeto Porción para el párrafo
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Una rápida y marrón zorro salta sobre el perro perezoso. Una rápida y marrón zorro salta sobre el perro perezoso.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Guardar Presentación
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tabs y EffectiveTabs en Presentación**
Todas las tabulaciones de texto se dan en píxeles.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figura: 2 Tabulaciones Explícitas y 2 Tabulaciones Predeterminadas**|
- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- La colección EffectiveTabs incluye todas las tabulaciones (de la colección Tabs y las tabulaciones predeterminadas).
- La propiedad EffectiveTabs.ExplicitTabCount (2 en nuestro caso) es igual a Tabs.Count.
- La propiedad EffectiveTabs.DefaultTabSize (294) muestra la distancia entre las pestañas predeterminadas (3 y 4 en nuestro ejemplo).
- EffectiveTabs.GetTabByIndex(index) con índice = 0 devolverá la primera pestaña explícita (Posición = 731), índice = 1 - segunda pestaña (Posición = 1241). Si intentas obtener la siguiente pestaña con el índice = 2, devolverá la primera pestaña predeterminada (Posición = 1470) y etc.
- EffectiveTabs.GetTabAfterPosition(pos) se utiliza para obtener la siguiente tabulación después de algún texto. Por ejemplo, tienes el texto: "¡Hola Mundo!". Para renderizar tal texto, debes saber dónde comenzar a dibujar "¡mundo!". Primero, deberías calcular la longitud de "Hola" en píxeles y llamar a GetTabAfterPosition con este valor. Obtendrás la siguiente posición de tabulación para dibujar "¡mundo!".

## **Establecer Estilo de Texto Predeterminado**

Si necesitas aplicar el mismo formato de texto predeterminado a todos los elementos de texto de una presentación a la vez, entonces puedes usar el método `getDefaultTextStyle` de la interfaz [IPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/) y establecer el formato preferido. El siguiente ejemplo de código muestra cómo establecer la fuente en negrita predeterminada (14 pt) para el texto en todas las diapositivas de una nueva presentación.

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