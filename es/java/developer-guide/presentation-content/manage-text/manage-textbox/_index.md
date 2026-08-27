---
title: Gestionar cuadros de texto en presentaciones usando Java
linktitle: Gestionar cuadro de texto
type: docs
weight: 20
url: /es/java/manage-textbox/
keywords:
- cuadro de texto
- marco de texto
- añadir texto
- actualizar texto
- crear cuadro de texto
- comprobar cuadro de texto
- añadir columna de texto
- añadir hipervínculo
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aspose.Slides para Java facilita la creación, edición y clonación de cuadros de texto en archivos PowerPoint y OpenDocument, mejorando la automatización de sus presentaciones."
---
## **Introducción**

Los textos en las diapositivas suelen estar en cuadros de texto o en formas. Por lo tanto, para añadir texto a una diapositiva, hay que agregar un cuadro de texto y luego colocar algo de texto dentro del cuadro. Aspose.Slides para Java proporciona la interfaz [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/IAutoShape) que permite añadir una forma que contenga texto.

{{% alert title="Información" color="info" %}}
Aspose.Slides también ofrece la interfaz [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/IShape) que permite añadir formas a las diapositivas. Sin embargo, no todas las formas añadidas a través de la interfaz `IShape` pueden contener texto. Pero las formas añadidas mediante la interfaz [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/IAutoShape) pueden contener texto. 
{{% /alert %}}

{{% alert title="Nota" color="warning" %}} 
Por consiguiente, cuando se trate una forma a la que se desea añadir texto, es conveniente comprobar y confirmar que se ha convertido mediante la interfaz `IAutoShape`. Sólo entonces podrá trabajar con [TextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/TextFrame), que es una propiedad de `IAutoShape`. Consulte la sección [Update Text](https://docs.aspose.com/slides/es/java/manage-textbox/#update-text) de esta página. 
{{% /alert %}}

## **Crear un cuadro de texto en una diapositiva**

Para crear un cuadro de texto en una diapositiva, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/Presentation). 
2. Obtenga una referencia a la primera diapositiva de la presentación recién creada. 
3. Añada un objeto [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/IAutoShape) con la propiedad [ShapeType](https://reference.aspose.com/slides/es/java/com.aspose.slides/IGeometryShape#setShapeType-int-) establecida en `Rectangle` en una posición especificada de la diapositiva y obtenga la referencia al objeto `IAutoShape` recién añadido. 
4. Agregue una propiedad `TextFrame` al objeto `IAutoShape` que contendrá el texto. En el ejemplo siguiente, añadimos este texto: *Aspose TextBox* 
5. Finalmente, guarde el archivo PPTX mediante el objeto `Presentation`. 

Este código Java —una implementación de los pasos anteriores— muestra cómo añadir texto a una diapositiva:

```java
import com.aspose.slides.*;

// Instancia la presentación
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva de la presentación
    ISlide sld = pres.getSlides().get_Item(0);

    // Añade un AutoShape con el tipo establecido como Rectángulo
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Añade un TextFrame al rectángulo
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

## **Comprobar si una forma es un cuadro de texto**

Aspose.Slides proporciona el método [isTextBox](https://reference.aspose.com/slides/es/java/com.aspose.slides/autoshape/#isTextBox--) de la interfaz [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) que permite examinar formas e identificar cuadros de texto.

![Cuadro de texto y forma](istextbox.png)

Este código Java muestra cómo comprobar si una forma se creó como cuadro de texto: 

```java
import com.aspose.slides.*;

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

Observe que si simplemente añade una forma automática mediante el método `addAutoShape` de la interfaz [IShapeCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/), el método `isTextBox` de la forma automática devolverá `false`. Sin embargo, después de añadir texto a la forma automática mediante el método `addTextFrame` o el método `setText`, la propiedad `isTextBox` devolverá `true`.

```java
import com.aspose.slides.*;

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

## **Encontrar la forma que posee un marco de texto**

En código genérico de procesamiento de texto, puede recibir un objeto [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) sin saber ya qué objeto de presentación lo contiene. Utilice el método [ITextFrame.getParentShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#getParentShape--) para volver a la [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/) propietaria.

Para un marco de texto que pertenece a una [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) u otra forma que contenga texto, [ITextFrame.getParentShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#getParentShape--) devuelve el propietario y [ITextFrame.getParentCell](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#getParentCell--) devuelve `null`. Ambos métodos proporcionan navegación de solo lectura, por lo que llamarlos no cambia la propiedad. Siempre compruebe que el valor devuelto no sea `null` antes de acceder a la forma.

Para un ejemplo completo que identifica los propietarios de formas y celdas de tabla, incluidas las formas asociadas a nodos de SmartArt, consulte [Search and Replace Text](/slides/es/java/search-and-replace-text/).

## **Añadir columnas a un cuadro de texto**

Aspose.Slides ofrece las propiedades [ColumnCount](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) y [ColumnSpacing](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITextFrameFormat) y la clase [TextFrameFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/TextFrameFormat)) que permiten añadir columnas a los cuadros de texto. Usted puede especificar el número de columnas en un cuadro de texto y definir el espaciado en puntos entre columnas. 

Este código Java demuestra la operación descrita: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Añade un AutoShape con el tipo establecido como Rectángulo
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Añade un TextFrame al rectángulo
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

Aspose.Slides para Java proporciona la propiedad [ColumnCount](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ITextFrameFormat)) que permite añadir columnas en marcos de texto. Mediante esta propiedad, puede especificar el número de columnas deseado en un marco de texto. 

Este código Java muestra cómo añadir una columna dentro de un marco de texto:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Actualizar texto**

Aspose.Slides le permite cambiar o actualizar el texto contenido en un cuadro de texto o todos los textos contenidos en una presentación. 

Este código Java muestra una operación en la que se actualizan o modifican todos los textos de una presentación:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Comprueba si la forma admite un marco de texto (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Recorre los párrafos del marco de texto
                {
                    for (IPortion portion : paragraph.getPortions()) //Recorre cada porción del párrafo
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Modifica el texto
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Modifica el formato
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
3. Añada un objeto `AutoShape` con la propiedad `ShapeType` establecida en `Rectangle` en una posición especificada de la diapositiva y obtenga una referencia al objeto `AutoShape` recién añadido. 
4. Añada un `TextFrame` al objeto `AutoShape` que contenga *Aspose TextBox* como texto predeterminado. 
5. Instancie la clase `IHyperlinkManager`. 
6. Asigne el objeto `IHyperlinkManager` a la propiedad [HyperlinkClick](https://reference.aspose.com/slides/es/java/com.aspose.slides/Shape#getHyperlinkClick--) asociada con la porción deseada del `TextFrame`. 
7. Finalmente, guarde el archivo PPTX mediante el objeto `Presentation`. 

Este código Java —una implementación de los pasos anteriores— muestra cómo añadir un cuadro de texto con hipervínculo a una diapositiva:

```java
import com.aspose.slides.*;

// Instancia una clase Presentation que representa un PPTX
Presentation pres = new Presentation();
try {
    // Obtiene la primera diapositiva de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Añade un objeto AutoShape con el tipo establecido como Rectángulo
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Convierte la forma a AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Accede a la propiedad ITextFrame asociada al AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Añade algo de texto al marco
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

Un [placeholder](/slides/es/java/manage-placeholder/) hereda estilo/posición de la [master](https://reference.aspose.com/slides/es/java/com.aspose.slides/masterslide/) y puede ser sobrescrito en los [layouts](https://reference.aspose.com/slides/es/java/com.aspose.slides/layoutslide/), mientras que un cuadro de texto normal es un objeto independiente en una diapositiva específica y no cambia al cambiar de layout.

**¿Cómo puedo realizar una sustitución masiva de texto en toda la presentación sin afectar el texto dentro de gráficos, tablas y SmartArt?**

Limite su iteración a las auto‑shapes que tengan marcos de texto y excluya los objetos incrustados ([charts](https://reference.aspose.com/slides/es/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/es/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/es/java/com.aspose.slides/smartart/)) recorriendo sus colecciones por separado o ignorando esos tipos de objetos.