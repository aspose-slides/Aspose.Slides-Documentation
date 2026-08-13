---
title: Añadir marcas de agua a presentaciones en Android
linktitle: Marca de agua
type: docs
weight: 40
url: /es/androidjava/watermark/
keywords:
- marca de agua
- marca de agua de texto
- marca de agua de imagen
- añadir marca de agua
- cambiar marca de agua
- eliminar marca de agua
- borrar marca de agua
- añadir marca de agua a PPT
- añadir marca de agua a PPTX
- añadir marca de agua a ODP
- eliminar marca de agua de PPT
- eliminar marca de agua de PPTX
- eliminar marca de agua de ODP
- borrar marca de agua de PPT
- borrar marca de agua de PPTX
- borrar marca de agua de ODP
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Gestiona marcas de agua de texto e imagen en presentaciones PowerPoint y OpenDocument en Android con Java para indicar un borrador, información confidencial y más."
---
## **Introducción**

**Una marca de agua** en una presentación es un sello de texto o imagen utilizado en una diapositiva o en todas las diapositivas de la presentación. Normalmente, una marca de agua se usa para indicar que la presentación es un borrador (p. ej., una marca de agua "Borrador"), que contiene información confidencial (p. ej., una marca de agua "Confidencial"), para especificar a qué empresa pertenece (p. ej., una marca de agua "Nombre de la empresa"), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir infracciones de derechos de autor al indicar que la presentación no debe copiarse. Las marcas de agua se utilizan tanto en formatos de presentación PowerPoint como OpenOffice. En Aspose.Slides, puedes añadir una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/es/android-java/), existen varias formas de crear marcas de agua en documentos PowerPoint u OpenOffice y modificar su diseño y comportamiento. El aspecto común es que, para añadir marcas de agua de texto, debes usar la interfaz [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/), y para añadir marcas de agua de imagen, usar la clase [PictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pictureframe/) o rellenar una forma de marca de agua con una imagen. `PictureFrame` implementa la interfaz [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/), lo que permite usar todas las configuraciones flexibles del objeto forma. Dado que `ITextFrame` no es una forma y sus ajustes son limitados, se envuelve en un objeto [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/).

Hay dos formas de aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. El Slide Master se usa para aplicar una marca de agua a todas las diapositivas: la marca de agua se añade al Slide Master, se diseña completamente allí y se aplica a todas las diapositivas sin afectar el permiso para modificar la marca de agua en diapositivas individuales.

Una marca de agua suele considerarse no editable por otros usuarios. Para evitar que la marca de agua (o más concretamente la forma que la contiene) se edite, Aspose.Slides proporciona funcionalidad de bloqueo de formas. Una forma concreta puede bloquearse en una diapositiva normal o en un Slide Master. Cuando la forma de la marca de agua está bloqueada en el Slide Master, estará bloqueada en todas las diapositivas de la presentación.

Puedes establecer un nombre para la marca de agua de modo que, en el futuro, si deseas eliminarla, puedas encontrarla en las formas de la diapositiva por nombre.

Puedes diseñar la marca de agua de cualquier manera; sin embargo, suelen existir características comunes en las marcas de agua, como alineación centrada, rotación, posición al frente, etc. Veremos cómo usar estas características en los ejemplos siguientes.

## **Marca de Agua de Texto**

### **Añadir una Marca de Agua de Texto a una Diapositiva**

Para añadir una marca de agua de texto en PPT, PPTX o ODP, puedes primero añadir una forma a la diapositiva y luego agregar un marco de texto a esa forma. El marco de texto está representado por la interfaz [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/). Este tipo no hereda de [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/), que posee un amplio conjunto de propiedades para posicionar la marca de agua de forma flexible. Por ello, el objeto [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) se envuelve en un objeto [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/). Para añadir texto de marca de agua a la forma, utiliza el método [addTextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) como se muestra a continuación.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Ver también" %}} 
- [Cómo usar la clase TextFrame](/slides/es/androidjava/text-formatting/)
{{% /alert %}}

### **Añadir una Marca de Agua de Texto a una Presentación**

Si deseas añadir una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), añádela al [MasterSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/masterslide/). El resto de la lógica es igual que al añadir una marca de agua a una sola diapositiva: crea un objeto [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) y luego añade la marca de agua usando el método [addTextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Ver también" %}} 
- [Cómo usar el Slide Master](/slides/es/androidjava/slide-master/)
{{% /alert %}}

### **Establecer la Transparencia de la Forma de la Marca de Agua**

Por defecto, la forma rectangular tiene colores de relleno y de línea. Las siguientes líneas de código hacen la forma transparente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Establecer la Fuente para una Marca de Agua de Texto**

Puedes cambiar la fuente de la marca de agua de texto como se muestra a continuación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Establecer el Color del Texto de la Marca de Agua**

Para establecer el color del texto de la marca de agua, usa este código:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Centrar una Marca de Agua de Texto**

Es posible centrar la marca de agua en una diapositiva; para ello, puedes hacer lo siguiente:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

La imagen siguiente muestra el resultado final.

![Marca de agua de texto](text_watermark.png)

## **Marca de Agua de Imagen**

### **Añadir una Marca de Agua de Imagen a una Presentación**

Para añadir una marca de agua de imagen a una diapositiva de la presentación, puedes hacer lo siguiente:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Bloquear una Marca de Agua para que No se Edite**

Si es necesario impedir que una marca de agua se edite, usa el método [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) sobre la forma. Con esta propiedad, puedes proteger la forma contra la selección, el cambio de tamaño, el reposicionamiento, la agrupación con otros elementos, bloquear su texto para que no se edite y mucho más:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Bloquear la forma de la marca de agua para que no se modifique
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Traer una Marca de Agua al Frente**

En Aspose.Slides, el orden Z de las formas puede establecerse mediante el método [IShapeCollection.reorder](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Para ello, debes llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De esta forma, es posible traer una forma al frente o enviarla al fondo de la diapositiva. Esta función es especialmente útil si necesitas colocar una marca de agua delante de la presentación:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Establecer la Rotación de la Marca de Agua**

A continuación se muestra un ejemplo de código sobre cómo ajustar la rotación de la marca de agua para que quede diagonalmente posicionada en la diapositiva:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Establecer un Nombre para una Marca de Agua**

Aspose.Slides permite establecer el nombre de una forma. Mediante el nombre de la forma, puedes acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de la marca de agua, asígnalo al método [IAutoShape.setName](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Eliminar una Marca de Agua**

Para eliminar la forma de la marca de agua, usa el método [IAutoShape.getName](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getName--) para encontrarla entre las formas de la diapositiva. Luego, pasa la forma de la marca de agua al método [IShapeCollection.remove](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Preguntas Frecuentes**

### ¿Qué es una marca de agua y por qué debería usarla?

Una marca de agua es una superposición de texto o imagen aplicada a las diapositivas que ayuda a proteger la propiedad intelectual, mejorar el reconocimiento de marca o impedir el uso no autorizado de las presentaciones.

### ¿Puedo añadir una marca de agua a todas las diapositivas de una presentación?

Sí, Aspose.Slides permite añadir programáticamente una marca de agua a cada diapositiva de una presentación. Puedes iterar sobre todas las diapositivas y aplicar la configuración de la marca de agua individualmente.

### ¿Cómo puedo ajustar la transparencia de la marca de agua?

Puedes ajustar la transparencia de la marca de agua modificando la configuración de relleno ([getFillFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#getFillFormat--)) de la forma. Esto asegura que la marca de agua sea sutil y no distraiga del contenido de la diapositiva.

### ¿Qué formatos de imagen son compatibles con las marcas de agua?

Aspose.Slides es compatible con varios formatos de imagen como PNG, JPEG, GIF, BMP, SVG y otros.

### ¿Puedo personalizar la fuente y el estilo de una marca de agua de texto?

Sí, puedes elegir cualquier fuente, tamaño y estilo para que coincidan con el diseño de tu presentación y mantengan la coherencia de la marca.

### ¿Cómo cambio la posición o la orientación de una marca de agua?

Puedes ajustar la posición y la orientación de la marca de agua programáticamente modificando las coordenadas, el tamaño y las propiedades de rotación de la forma.