---
title: Marca de agua
type: docs
weight: 40
url: /androidjava/watermark/
keywords:
- marca de agua
- agregar marca de agua
- marca de agua de texto
- marca de agua de imagen
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides para Android a través de Java
description: "Agregar marcas de agua de texto e imagen a presentaciones de PowerPoint en Java"
---

## **Acerca de las Marcas de Agua**

**Una marca de agua** en una presentación es un sello de texto o imagen que se utiliza en una diapositiva o en todas las diapositivas de la presentación. Por lo general, una marca de agua se utiliza para indicar que la presentación es un borrador (por ejemplo, una marca de agua "Borrador"), que contiene información confidencial (por ejemplo, una marca de agua "Confidencial"), para especificar a qué empresa pertenece (por ejemplo, una marca de agua "Nombre de la Empresa"), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir violaciones de derechos de autor al indicar que la presentación no debe ser copiada. Las marcas de agua se utilizan en los formatos de presentación de PowerPoint y OpenOffice. En Aspose.Slides, puedes agregar una marca de agua a los formatos de archivo PPT, PPTX y ODP de PowerPoint y OpenOffice.

En [**Aspose.Slides**](https://products.aspose.com/slides/android-java/), hay varias formas en que puedes crear marcas de agua en documentos de PowerPoint u OpenOffice y modificar su diseño y comportamiento. El aspecto común es que, para agregar marcas de agua de texto, debes usar la interfaz [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/), y para agregar marcas de agua de imagen, usa la clase [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) o llena una forma de marca de agua con una imagen. `PictureFrame` implementa la interfaz [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), lo que te permite usar todas las configuraciones flexibles del objeto de forma. Dado que `ITextFrame` no es una forma y sus configuraciones son limitadas, está envuelto en un objeto [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/).

Hay dos formas en las que se puede aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. El Maestro de Diapositivas se utiliza para aplicar una marca de agua a todas las diapositivas de la presentación: la marca de agua se agrega al Maestro de Diapositivas, se diseña completamente allí y se aplica a todas las diapositivas sin afectar la posibilidad de modificar la marca de agua en diapositivas individuales.

Una marca de agua generalmente se considera no editable por otros usuarios. Para evitar que la marca de agua (o más bien la forma principal de la marca de agua) sea editada, Aspose.Slides proporciona funcionalidad de bloqueo de formas. Una forma específica puede ser bloqueada en una diapositiva normal o en un Maestro de Diapositivas. Cuando la forma de marca de agua está bloqueada en el Maestro de Diapositivas, estará bloqueada en todas las diapositivas de la presentación.

Puedes establecer un nombre para la marca de agua de modo que en el futuro, si deseas eliminarla, puedas encontrarla en las formas de la diapositiva por su nombre.

Puedes diseñar la marca de agua de cualquier forma; sin embargo, generalmente hay características comunes en las marcas de agua, como alineación centrada, rotación, posición frontal, etc. Consideraremos cómo utilizar estas en los ejemplos a continuación.

## **Marca de Agua de Texto**

### **Agregar una Marca de Agua de Texto a una Diapositiva**

Para agregar una marca de agua de texto en PPT, PPTX o ODP, primero puedes agregar una forma a la diapositiva, luego agregar un marco de texto a esta forma. El marco de texto está representado por la interfaz [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/). Este tipo no se hereda de [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), que tiene un amplio conjunto de propiedades para posicionar la marca de agua de manera flexible. Por lo tanto, el objeto [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) está envuelto en un objeto [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). Para agregar texto de marca de agua a la forma, usa el método [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) como se muestra a continuación.

```java
String watermarkText = "CONFIDENCIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo Usar la Clase TextFrame](/slides/androidjava/text-formatting/)
{{% /alert %}}

### **Agregar una Marca de Agua de Texto a una Presentación**

Si deseas agregar una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), agrégala al [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/). El resto de la lógica es la misma que al agregar una marca de agua a una sola diapositiva: crea un objeto [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) y luego agrégale la marca de agua usando el método [addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENCIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo Usar el Maestro de Diapositivas](/slides/androidjava/slide-master/)
{{% /alert %}}

### **Establecer la Transparencia de la Forma de Marca de Agua**

Por defecto, la forma rectangular está estilizada con colores de relleno y línea. Las siguientes líneas de código hacen que la forma sea transparente.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Establecer la Fuente para una Marca de Agua de Texto**

Puedes cambiar la fuente de la marca de agua de texto como se muestra a continuación.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Establecer el Color del Texto de la Marca de Agua**

Para establecer el color del texto de la marca de agua, usa este código:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Centrar una Marca de Agua de Texto**

Es posible centrar la marca de agua en una diapositiva, y para eso, puedes hacer lo siguiente:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

La imagen de abajo muestra el resultado final.

![La marca de agua de texto](text_watermark.png)

## **Marca de Agua de Imagen**

### **Agregar una Marca de Agua de Imagen a una Presentación**

Para agregar una marca de agua de imagen a una diapositiva de presentación, puedes hacer lo siguiente:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

## **Bloquear una Marca de Agua para Edición**

Si es necesario evitar que una marca de agua sea editada, usa el método [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) en la forma. Con esta propiedad, puedes proteger la forma de ser seleccionada, redimensionada, reposicionada, agrupada con otros elementos, bloquear su texto de edición y mucho más:

```java
// Bloquear la forma de marca de agua de modificaciones
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

## **Traer una Marca de Agua al Frente**

En Aspose.Slides, el orden Z de las formas se puede establecer a través del método [IShapeCollection.reorder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Para hacer esto, necesitas llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De esta manera, es posible llevar una forma al frente o enviarla al fondo de la diapositiva. Esta característica es especialmente útil si necesitas colocar una marca de agua frente a la presentación:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

## **Establecer la Rotación de la Marca de Agua**

Aquí hay un ejemplo de código sobre cómo ajustar la rotación de la marca de agua para que esté posicionada en diagonal a través de la diapositiva:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

## **Establecer un Nombre para una Marca de Agua**

Aspose.Slides te permite establecer el nombre de una forma. Al usar el nombre de la forma, puedes acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de marca de agua, asígnale el método [IAutoShape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("marca de agua");
```

## **Eliminar una Marca de Agua**

Para eliminar la forma de marca de agua, usa el método [IAutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getName--) para encontrarla en las formas de la diapositiva. Luego, pasa la forma de marca de agua al método [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) :

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("marca de agua".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Un Ejemplo en Vivo**

Puedes querer revisar las herramientas en línea **Aspose.Slides free** [Agregar Marca de Agua](https://products.aspose.app/slides/watermark) y [Eliminar Marca de Agua](https://products.aspose.app/slides/watermark/remove-watermark).

![Herramientas en línea para agregar y eliminar marcas de agua](online_tools.png)