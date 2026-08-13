---
title: Agregar marcas de agua a presentaciones en Java
linktitle: Marca de agua
type: docs
weight: 40
url: /es/java/watermark/
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
- Java
- Aspose.Slides
description: "Administre marcas de agua de texto y de imagen en presentaciones PowerPoint y OpenDocument con Java para indicar un borrador, información confidencial, derechos de autor y más."
---
## **Introducción**

**Una marca de agua** en una presentación es un sello de texto o imagen utilizado en una diapositiva o en todas las diapositivas de la presentación. Normalmente, una marca de agua se usa para indicar que la presentación es un borrador (p. ej., una marca de agua «Draft»), que contiene información confidencial (p. ej., una marca de agua «Confidential»), para especificar a qué empresa pertenece (p. ej., una marca de agua «Company Name»), para identificar al autor de la presentación, etc. Una marca de agua ayuda a evitar infracciones de derechos de autor al indicar que la presentación no debe copiarse. Las marcas de agua se usan tanto en los formatos de presentación PowerPoint como OpenOffice. En Aspose.Slides, puede añadir una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/es/java/), existen varias formas de crear marcas de agua en documentos PowerPoint u OpenOffice y de modificar su diseño y comportamiento. El aspecto común es que, para añadir marcas de agua de texto, debe usar la interfaz [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/), y para añadir marcas de agua de imagen, utilice la clase [PictureFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/pictureframe/) o rellene una forma de marca de agua con una imagen. `PictureFrame` implementa la interfaz [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/), lo que le permite usar todas las configuraciones flexibles del objeto forma. Como `ITextFrame` no es una forma y sus configuraciones son limitadas, se envuelve en un objeto [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/) .

Existen dos formas de aplicar una marca de agua: a una única diapositiva o a todas las diapositivas de la presentación. El patrón de diapositivas (Slide Master) se utiliza para aplicar una marca de agua a todas las diapositivas — la marca de agua se añade al Slide Master, se diseña completamente allí y se aplica a todas las diapositivas sin afectar la posibilidad de modificar la marca de agua en diapositivas individuales.

Normalmente, se considera que una marca de agua no está disponible para su edición por otros usuarios. Para evitar que la marca de agua (o, más concretamente, la forma padre de la marca de agua) sea editada, Aspose.Slides ofrece funcionalidad de bloqueo de formas. Una forma concreta puede bloquearse en una diapositiva normal o en un Slide Master. Cuando la forma de la marca de agua está bloqueada en el Slide Master, se bloqueará en todas las diapositivas de la presentación.

Puede establecer un nombre para la marca de agua de modo que, en el futuro, si desea eliminarla, pueda encontrarla entre las formas de la diapositiva por nombre.

Puede diseñar la marca de agua de cualquier manera; sin embargo, suelen existir características comunes en las marcas de agua, como alineación centrada, rotación, posición al frente, etc. Consideraremos cómo usar estas en los ejemplos siguientes.

## **Marca de agua de texto**

### **Añadir una marca de agua de texto a una diapositiva**

Para añadir una marca de agua de texto en PPT, PPTX u ODP, puede primero agregar una forma a la diapositiva y luego añadir un marco de texto a esa forma. El marco de texto está representado por la interfaz [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/). Este tipo no hereda de [IShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/), que posee un amplio conjunto de propiedades para posicionar la marca de agua de forma flexible. Por lo tanto, el objeto [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) se envuelve en un objeto [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/). Para agregar el texto de la marca de agua a la forma, utilice el método [addTextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) como se muestra a continuación.

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
- [Cómo usar la clase TextFrame](/slides/es/java/text-formatting/)
{{% /alert %}}

### **Añadir una marca de agua de texto a una presentación**

Si desea agregar una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), agrégela al [MasterSlide](https://reference.aspose.com/slides/es/java/com.aspose.slides/masterslide/). El resto de la lógica es igual que al añadir una marca de agua a una sola diapositiva: cree un objeto [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) y luego añada la marca de agua a él usando el método [addTextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

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
- [Cómo usar el Slide Master](/slides/es/java/slide-master/)
{{% /alert %}}

### **Establecer la transparencia de la forma de la marca de agua**

De forma predeterminada, la forma de rectángulo tiene estilos de color de relleno y de línea. Las siguientes líneas de código hacen que la forma sea transparente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Establecer la fuente para una marca de agua de texto**

Puede cambiar la fuente de la marca de agua de texto como se muestra a continuación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Establecer el color del texto de la marca de agua**

Para establecer el color del texto de la marca de agua, use el siguiente código:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Centra una marca de agua de texto**

Es posible centrar la marca de agua en una diapositiva y, para ello, puede hacer lo siguiente:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

![La marca de agua de texto](text_watermark.png)

## **Marca de agua de imagen**

### **Añadir una marca de agua de imagen a una presentación**

Para añadir una marca de agua de imagen a una diapositiva de la presentación, puede hacer lo siguiente:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Bloquear una marca de agua para que no se edite**

Si es necesario impedir que una marca de agua sea editada, utilice el método [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) sobre la forma. Con esta propiedad, puede proteger la forma contra la selección, el cambio de tamaño, el reposicionamiento, el agrupamiento con otros elementos, bloquear su texto contra la edición y mucho más:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Bloquear la forma de la marca de agua para que no se modifique
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Traer una marca de agua al frente**

En Aspose.Slides, el orden Z de las formas puede establecerse mediante el método [IShapeCollection.reorder](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Para ello, debe llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De este modo, es posible traer una forma al frente o enviarla al fondo de la diapositiva. Esta característica es especialmente útil si necesita colocar una marca de agua delante de la presentación:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Establecer la rotación de la marca de agua**

Aquí tienes un ejemplo de código de cómo ajustar la rotación de la marca de agua para que quede posicionada diagonalmente a través de la diapositiva:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Establecer un nombre para una marca de agua**

Aspose.Slides le permite establecer el nombre de una forma. Mediante el nombre de la forma, puede acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de la marca de agua, asígnele el método [IAutoShape.setName](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Eliminar una marca de agua**

Para eliminar la forma de la marca de agua, utilice el método [IAutoShape.getName](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getName--) para encontrarla entre las formas de la diapositiva. Luego, pase la forma de la marca de agua al método [IShapeCollection.remove](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **Preguntas frecuentes**

### ¿Qué es una marca de agua y por qué debería usarla?

Una marca de agua es una superposición de texto o imagen aplicada a las diapositivas que ayuda a proteger la propiedad intelectual, mejorar el reconocimiento de la marca o impedir el uso no autorizado de presentaciones.

### ¿Puedo añadir una marca de agua a todas las diapositivas de una presentación?

Sí, Aspose.Slides permite añadir programáticamente una marca de agua a cada diapositiva de una presentación. Puede iterar por todas las diapositivas y aplicar la configuración de la marca de agua individualmente.

### ¿Cómo puedo ajustar la transparencia de la marca de agua?

Puede ajustar la transparencia de la marca de agua modificando la configuración de relleno ([getFillFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#getFillFormat--)) de la forma. Esto garantiza que la marca de agua sea sutil y no distraiga del contenido de la diapositiva.

### ¿Qué formatos de imagen son compatibles con las marcas de agua?

Aspose.Slides es compatible con varios formatos de imagen, como PNG, JPEG, GIF, BMP, SVG, entre otros.

### ¿Puedo personalizar la fuente y el estilo de una marca de agua de texto?

Sí, puede elegir cualquier fuente, tamaño y estilo para que coincidan con el diseño de su presentación y mantengan la consistencia de la marca.

### ¿Cómo cambio la posición o la orientación de una marca de agua?

Puede ajustar la posición y la orientación de la marca de agua programáticamente modificando las coordenadas, el tamaño y las propiedades de rotación de la forma.