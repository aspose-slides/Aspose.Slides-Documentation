---
title: Administrar cuadros de texto en presentaciones en Android
linktitle: Administrar cuadro de texto
type: docs
weight: 20
url: /es/androidjava/manage-textbox/
keywords:
- cuadro de texto
- marco de texto
- añadir texto
- actualizar texto
- crear cuadro de texto
- verificar cuadro de texto
- añadir columna de texto
- añadir hipervínculo
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides para Android mediante Java facilita crear, editar y clonar cuadros de texto en archivos PowerPoint y OpenDocument, mejorando la automatización de sus presentaciones."
---

Los textos en las diapositivas normalmente se encuentran en cuadros de texto o formas. Por lo tanto, para añadir un texto a una diapositiva, debe agregar un cuadro de texto y luego colocar algún texto dentro del cuadro. Aspose.Slides para Android mediante Java proporciona la interfaz [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) que permite añadir una forma que contiene texto.

{{% alert title="Info" color="info" %}}

Aspose.Slides también ofrece la interfaz [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) que permite agregar formas a las diapositivas. Sin embargo, no todas las formas añadidas mediante la interfaz `IShape` pueden contener texto. Pero las formas añadidas mediante la interfaz [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) pueden contener texto.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Por lo tanto, al trabajar con una forma a la que desea añadir texto, es conveniente comprobar y confirmar que se ha convertido mediante la interfaz `IAutoShape`. Sólo entonces podrá trabajar con [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame), que es una propiedad de `IAutoShape`. Consulte la sección [Update Text](https://docs.aspose.com/slides/androidjava/manage-textbox/#update-text) en esta página.

{{% /alert %}}

## **Crear un cuadro de texto en una diapositiva**

Para crear un cuadro de texto en una diapositiva, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenga una referencia a la primera diapositiva de la presentación recién creada. 
3. Añada un objeto [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) con `ShapeType` establecido en `Rectangle` en una posición especificada de la diapositiva y obtenga la referencia al objeto `IAutoShape` recién añadido.
4. Añada una propiedad `TextFrame` al objeto `IAutoShape` que contendrá un texto. En el ejemplo a continuación, añadimos este texto: *Aspose TextBox*
5. Finalmente, escriba el archivo PPTX mediante el objeto `Presentation`. 

Este código Java—una implementación de los pasos anteriores—le muestra cómo añadir texto a una diapositiva:
```java
// Instancia Presentation
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva de la presentación
    ISlide sld = pres.getSlides().get_Item(0);

    // Añade un AutoShape con tipo establecido como Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Añade TextFrame al Rectangle
    ashp.addTextFrame(" ");

    // Accede al marco de texto
    ITextFrame txtFrame = ashp.getTextFrame();

    // Crea el objeto Paragraph para el marco de texto
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Crea un objeto Portion para el párrafo
    IPortion portion = para.getPortions().get_Item(0);

    // Establece el texto
    portion.setText("Aspose TextBox");

    // Guarda la presentación en disco
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Comprobar una forma de cuadro de texto**

Aspose.Slides proporciona el método [isTextBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#isTextBox--) de la interfaz [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), que permite examinar las formas e identificar los cuadros de texto.

![Text box and shape](istextbox.png)

Este código Java le muestra cómo comprobar si una forma se creó como cuadro de texto: 
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```


Observe que si simplemente añade una autoshape usando el método `addAutoShape` de la interfaz [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/), el método `isTextBox` de la autoshape devolverá `false`. Sin embargo, después de añadir texto a la autoshape usando el método `addTextFrame` o el método `setText`, la propiedad `isTextBox` devolverá `true`.
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() devuelve false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() devuelve true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() devuelve false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() devuelve true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() devuelve false
shape3.addTextFrame("");
// shape3.isTextBox() devuelve false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() devuelve false
shape4.getTextFrame().setText("");
// shape4.isTextBox() devuelve false
```


## **Añadir columnas a un cuadro de texto**

Aspose.Slides ofrece las propiedades [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) y [ColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat) y la clase [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) que permiten añadir columnas a los cuadros de texto. Puede especificar el número de columnas en un cuadro de texto y establecer el espaciado en puntos entre columnas.

Este código en Java demuestra la operación descrita: 
```java
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Añade un AutoShape con el tipo establecido como Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Añade TextFrame al Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Obtiene el formato de texto del TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Especifica el número de columnas en el TextFrame
    format.setColumnCount(3);

    // Especifica el espaciado entre columnas
    format.setColumnSpacing(10);

    // Guarda la presentación
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Añadir columnas a un marco de texto**
Aspose.Slides para Android mediante Java proporciona la propiedad [ColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormat)) que permite añadir columnas en marcos de texto. Mediante esta propiedad, puede especificar el número de columnas deseado en un marco de texto.

Este código Java le muestra cómo añadir una columna dentro de un marco de texto:
```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Actualizar texto**

Aspose.Slides permite cambiar o actualizar el texto contenido en un cuadro de texto o todos los textos contenidos en una presentación. 

Este código Java muestra una operación en la que se actualizan o cambian todos los textos de una presentación:
```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Comprueba si la forma admite un marco de texto (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Itera a través de los párrafos en el marco de texto
                {
                    for (IPortion portion : paragraph.getPortions()) //Itera a través de cada porción en el párrafo
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Cambia el texto
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Cambia el formato
                    }
                }
            }
        }
    }

    //Guarda la presentación modificada
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Añadir un cuadro de texto con hipervínculo** 

Puede insertar un enlace dentro de un cuadro de texto. Cuando se hace clic en el cuadro de texto, los usuarios son dirigidos a abrir el enlace. 

Para añadir un cuadro de texto que contenga un enlace, siga estos pasos:

1. Cree una instancia de la clase `Presentation`. 
2. Obtenga una referencia a la primera diapositiva de la presentación recién creada. 
3. Añada un objeto `AutoShape` con `ShapeType` establecido en `Rectangle` en una posición especificada de la diapositiva y obtenga una referencia al objeto AutoShape recién añadido.
4. Añada un `TextFrame` al objeto `AutoShape` que contenga *Aspose TextBox* como texto predeterminado. 
5. Instancie la clase `IHyperlinkManager`. 
6. Asigne el objeto `IHyperlinkManager` a la propiedad [HyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) asociada a la porción deseada del `TextFrame`.
7. Finalmente, escriba el archivo PPTX mediante el objeto `Presentation`. 

Este código Java—una implementación de los pasos anteriores—le muestra cómo añadir un cuadro de texto con hipervínculo a una diapositiva:
```java
// Instancia una clase Presentation que representa un PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Añade un objeto AutoShape con el tipo establecido como Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Convierte la forma a AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Accede a la propiedad ITextFrame asociada con el AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Añade texto al marco
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Establece el hipervínculo para el texto de la porción
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Guarda la presentación PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Cuál es la diferencia entre un cuadro de texto y un marcador de posición de texto al trabajar con diapositivas maestras?**

Un [placeholder](/slides/es/androidjava/manage-placeholder/) hereda estilo/posición de la [master](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/) y puede sobrescribirse en [layouts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/), mientras que un cuadro de texto normal es un objeto independiente en una diapositiva específica y no cambia al cambiar de layout.

**¿Cómo puedo realizar un reemplazo masivo de texto en toda la presentación sin tocar el texto dentro de gráficos, tablas y SmartArt?**

Limite su iteración a autoformas que tengan marcos de texto y excluya los objetos incrustados ([charts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)) recorriendo sus colecciones por separado o omitiendo esos tipos de objetos.