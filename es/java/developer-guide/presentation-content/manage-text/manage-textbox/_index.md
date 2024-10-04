---
title: Administrar TextBox
type: docs
weight: 20
url: /es/java/manage-textbox/
description: Crea un cuadro de texto en diapositivas de PowerPoint utilizando Java. Agrega columna en el cuadro de texto o marco de texto en diapositivas de PowerPoint utilizando Java. Agrega un cuadro de texto con un hipervínculo en diapositivas de PowerPoint utilizando Java.
---


Los textos en las diapositivas suelen existir en cuadros de texto o formas. Por lo tanto, para agregar un texto a una diapositiva, debes agregar un cuadro de texto y luego poner algún texto dentro del cuadro de texto. Aspose.Slides para Java proporciona la interfaz [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) que te permite agregar una forma que contenga algún texto.

{{% alert title="Info" color="info" %}}

Aspose.Slides también proporciona la interfaz [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) que te permite agregar formas a las diapositivas. Sin embargo, no todas las formas agregadas a través de la interfaz `IShape` pueden contener texto. Pero las formas añadidas a través de la interfaz [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) pueden contener texto. 

{{% /alert %}}

{{% alert title="Nota" color="warning" %}} 

Por lo tanto, al tratar con una forma a la que deseas agregar texto, puede que desees verificar y confirmar que se haya convertido a través de la interfaz `IAutoShape`. Solo entonces podrás trabajar con [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), que es una propiedad de `IAutoShape`. Consulta la sección [Actualizar Texto](https://docs.aspose.com/slides/java/manage-textbox/#update-text) en esta página. 

{{% /alert %}}

## **Crear Cuadro de Texto en Diapositiva**

Para crear un cuadro de texto en una diapositiva, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Obtén una referencia para la primera diapositiva en la presentación recién creada. 
3. Agrega un objeto [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) con el [ShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setShapeType-int-) establecido como `Rectangle` en una posición específica de la diapositiva y obten la referencia del objeto `IAutoShape` recién agregado. 
4. Agrega una propiedad `TextFrame` al objeto `IAutoShape` que contendrá un texto. En el ejemplo a continuación, añadimos este texto: *Aspose TextBox*
5. Finalmente, escribe el archivo PPTX a través del objeto `Presentation`. 

Este código Java—una implementación de los pasos anteriores—te muestra cómo agregar texto a una diapositiva:

```java
// Instancia Presentation
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva en la presentación
    ISlide sld = pres.getSlides().get_Item(0);

    // Agrega un AutoShape con tipo establecido como Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Agrega TextFrame al Rectangle
    ashp.addTextFrame(" ");

    // Accede al marco de texto
    ITextFrame txtFrame = ashp.getTextFrame();

    // Crea el objeto Paragraph para el marco de texto
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Crea un objeto Portion para el párrafo
    IPortion portion = para.getPortions().get_Item(0);

    // Establece el Texto
    portion.setText("Aspose TextBox");

    // Guarda la presentación en el disco
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Verificar Forma de Cuadro de Texto**

Aspose.Slides proporciona la propiedad [isTextBox()](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#isTextBox--) (de la clase [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/)) que te permite examinar las formas y encontrar cuadros de texto.

![Cuadro de texto y forma](istextbox.png)

Este código Java te muestra cómo verificar si una forma fue creada como un cuadro de texto: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ForEach.shape(pres, (shape, slide, index) ->
    {
        if (shape instanceof AutoShape)
        {
            AutoShape autoShape = (AutoShape)shape;
            System.out.println(autoShape.isTextBox() ? "la forma es un cuadro de texto" : "la forma no es un cuadro de texto");
        }
    });
} finally {
    if (pres != null) pres.dispose();
}
```

## **Agregar Columna en Cuadro de Texto**

Aspose.Slides proporciona las propiedades [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) y [ColumnSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) y la clase [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) que te permiten agregar columnas a los cuadros de texto. Puedes especificar el número de columnas en un cuadro de texto y establecer la cantidad de espaciado en puntos entre las columnas. 

Este código en Java demuestra la operación descrita: 

```java
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva en la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Agrega un AutoShape con tipo establecido como Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Agrega TextFrame al Rectangle
    aShape.addTextFrame("Todas estas columnas están limitadas a estar dentro de un solo contenedor de texto -- " +
            "puedes agregar o eliminar texto y el nuevo o resto de texto se ajusta automáticamente " +
            "para fluir dentro del contenedor. No puedes hacer que el texto fluya de un contenedor " +
            "a otro, ya que te hemos dicho que las opciones de columna de PowerPoint para texto son limitadas!");

    // Obtiene el formato de texto del TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Especifica el número de columnas en TextFrame
    format.setColumnCount(3);

    // Especifica el espaciado entre columnas
    format.setColumnSpacing(10);

    // Guarda la presentación
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Agregar Columna en Marco de Texto**
Aspose.Slides para Java proporciona la propiedad [ColumnCount](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat)) que te permite agregar columnas en marcos de texto. A través de esta propiedad, puedes especificar tu número preferido de columnas en un marco de texto. 

Este código Java te muestra cómo agregar una columna dentro de un marco de texto:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("Todas estas columnas están forzadas a permanecer dentro de un solo contenedor de texto -- " +
            "puedes agregar o eliminar texto - y el nuevo o resto de texto se ajusta automáticamente " +
            "para permanecer dentro del contenedor. No puedes hacer que el texto se derrame de un contenedor " +
            "a otro, ya que las opciones de columna para texto en PowerPoint son limitadas!");
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

## **Actualizar Texto**

Aspose.Slides te permite cambiar o actualizar el texto contenido en un cuadro de texto o todos los textos contenidos en una presentación. 

Este código Java demuestra una operación donde todos los textos en una presentación se actualizan o cambian:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Verifica si la forma soporta el marco de texto (IAutoShape). 
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

## **Agregar Cuadro de Texto con Hipervínculo** 

Puedes insertar un enlace dentro de un cuadro de texto. Cuando se hace clic en el cuadro de texto, los usuarios son dirigidos a abrir el enlace. 

 Para agregar un cuadro de texto que contenga un enlace, sigue estos pasos:

1. Crea una instancia de la clase `Presentation`. 
2. Obtén una referencia para la primera diapositiva en la presentación recién creada. 
3. Agrega un objeto `AutoShape` con `ShapeType` establecido como `Rectangle` en una posición específica de la diapositiva y obten una referencia del objeto AutoShape recién agregado.
4. Agrega un `TextFrame` al objeto `AutoShape` que contenga *Aspose TextBox* como su texto predeterminado. 
5. Instancia la clase `IHyperlinkManager`. 
6. Asigna el objeto `IHyperlinkManager` a la propiedad [HyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getHyperlinkClick--) asociada con la porción preferida de tu `TextFrame`. 
7. Finalmente, escribe el archivo PPTX a través del objeto `Presentation`. 

Este código Java—una implementación de los pasos anteriores—te muestra cómo agregar un cuadro de texto con un hipervínculo a una diapositiva:

```java
// Instancia una clase Presentation que representa un PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva en la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Agrega un objeto AutoShape con tipo establecido como Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Convierte la forma a AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Accede a la propiedad ITextFrame asociada con el AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Agrega algún texto al marco
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Establece el Hipervínculo para el texto de la porción
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Guarda la Presentación PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```