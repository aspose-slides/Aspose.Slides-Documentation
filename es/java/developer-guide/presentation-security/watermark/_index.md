---
title: Marca de agua
type: docs
weight: 40
url: /es/java/watermark/
keywords: "marca de agua en presentación"
description: "Usa marca de agua en PowerPoint con Aspose.Slides. Añade marca de agua en presentación ppt o elimina marca de agua. Inserta imagen de marca de agua o texto de marca de agua."
---

## **Acerca de Marca de Agua**
La **marca de agua** en una presentación es un sello de texto o imagen, utilizado en una diapositiva o en todas las diapositivas de la presentación. Normalmente, la marca de agua se utiliza para indicar que la presentación es un borrador (por ejemplo, marca de agua "Borrador"); que contiene información confidencial (por ejemplo, marca de agua "Confidencial"); especificar a qué empresa pertenece (por ejemplo, marca de agua "Nombre de la empresa"); identificar al autor de la presentación, etc. La marca de agua ayuda a prevenir la violación de derechos de autor de la presentación, indicando que la presentación no debe ser copiada. Las marcas de agua se utilizan en ambos formatos de presentación, PowerPoint y OpenOffice. En Aspose.Slides puedes añadir marcas de agua a los formatos de archivo PPT, PPTX y ODP de PowerPoint.

En [**Aspose.Slides**](https://products.aspose.com/slides/java/) hay varias formas en las que puedes crear una marca de agua en PowerPoint o OpenOffice, envolverla en diferentes formas, cambiar el diseño y el comportamiento, etc. Lo común es que para añadir marcas de agua de texto, debes usar la clase [**TextFrame**](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) y para añadir la marca de agua de imagen - [**PictureFrame**](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame/). [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame/) implementa la interfaz [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) y puede usar todo el poder de la configuración flexible del objeto de forma. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) no es una forma y su configuración es limitada. Por lo tanto, se aconseja envolver el [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) en un objeto [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).

Hay dos formas en que se puede aplicar una marca de agua: a una sola diapositiva y a todas las diapositivas de la presentación. El Patrón de Diapositiva se usa para aplicar la marca de agua a todas las diapositivas de la presentación: la marca de agua se añade al Patrón de Diapositiva, se diseña completamente allí y se aplica a todas las diapositivas sin modificar el permiso para modificar la marca de agua en las diapositivas.

La marca de agua generalmente se considera no disponible para la edición por otros usuarios. Para prevenir la edición de la marca de agua (o más bien de la forma padre de la marca de agua), Aspose.Slides proporciona la funcionalidad de bloqueo de forma. Una forma determinada puede ser bloqueada en una diapositiva normal o en un Patrón de Diapositiva. Al bloquear la forma de la marca de agua en un Patrón de Diapositiva, estará bloqueada en todas las diapositivas de la presentación.

Puedes establecer el nombre de la marca de agua, por lo que en el futuro, si deseas eliminar la marca de agua, podrás encontrarla en las formas de las diapositivas por su nombre.

Puedes diseñar la marca de agua de cualquier manera, sin embargo, normalmente hay características comunes dentro de las marcas de agua, como: alineación central, rotación, posición frontal, etc. Consideraremos cómo utilizarlas en los ejemplos a continuación.
## **Marca de Agua de Texto**
### **Añadir Marca de Agua de Texto a la Diapositiva**
Para añadir una marca de agua de texto en PPT, PPTX o ODP, primero puedes añadir una forma en la diapositiva y luego añadir un marco de texto dentro de esta forma. El marco de texto es representado por el tipo [**TextFrame**](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame). Este tipo no se hereda de [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape), que tiene un amplio conjunto de propiedades para establecer la marca de agua de manera flexible. Por lo tanto, se aconseja envolver el objeto [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) en un objeto [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape). Para añadir la marca de agua en la forma, utiliza el método [**addTextFrame**](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) con el texto de la marca de agua pasado a él:

```java
// Abrir presentación
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 0, 0, 0, 0);

    ITextFrame watermarkTextFrame = watermarkShape.addTextFrame("Marca de agua");
    
} finally {
    if (presentation != null) presentation.dispose();
}
```



{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/es/java/slide-master/)[TextFrame](/slides/es/java/adding-and-formatting-text/)
{{% /alert %}}

### **Añadir Marca de Agua de Texto a la Presentación**
Si deseas añadir una marca de agua a la presentación (es decir, todas las diapositivas a la vez), añádela al [**MasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/MasterSlide). Toda la lógica es la misma que al añadir la marca de agua a una sola diapositiva: crea un objeto [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) y luego añade la marca de agua en él con el método [**addTextFrame**](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-):

```java
// Abrir presentación
Presentation pres = new Presentation();
try {
    IMasterSlide master = pres.getMasters().get_Item(0);

    IAutoShape watermarkShape = master.getShapes().addAutoShape(ShapeType.Triangle, 0, 0, 0, 0);

    ITextFrame watermarkTextFrame = watermarkShape.addTextFrame("Marca de agua");

} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/es/java/slide-master/)[Patrón de Diapositiva](/slides/es/java/slide-master/)
{{% /alert %}}

### **Establecer Fuente de la Marca de Agua de Texto**
Puedes cambiar la fuente de la marca de agua de texto:

```java
IPortion watermarkPortion = watermarkTextFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);

watermarkPortion.getPortionFormat().setFontBold(NullableBool.True);

watermarkPortion.getPortionFormat().setFontHeight(52);
```


### **Establecer Transparencia de la Marca de Agua de Texto**
Para establecer la transparencia de la marca de agua de texto usa este código:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IPortion watermarkPortion = watermarkTextFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);

watermarkPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);

watermarkPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```


### **Centrar Marca de Agua de Texto**
Es posible centrar la marca de agua en una diapositiva y para ello puedes hacer lo siguiente:



```java
Point2D.Float center = new Point2D.Float((float)  pres.getSlideSize().getSize().getWidth() / 2, (float) pres.getSlideSize().getSize().getHeight() / 2);

float width = 300;

float height = 300;

float x = (float) center.getX() - width / 2;

float y = (float) center.getY() - height / 2;


//...


IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Triangle, x, y, width, height);
```


## **Marca de Agua de Imagen**
### **Añadir Marca de Agua de Imagen a la Presentación**
Para añadir una marca de agua de imagen a todas las diapositivas de la presentación, puedes hacer lo siguiente:

```java
IPPImage picture;
IImage image = Images.fromFile("watermark.png");
try {
    picture = pres.getImages().addImage(image);
} finally {
    if (image != null) image.dispose();
}
// ...


watermarkShape.getFillFormat().setFillType(FillType.Picture);

watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```




## **Bloquear Marca de Agua para Edición**
Si es necesario prevenir la edición de la marca de agua, utiliza el método [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape#getShapeLock--) en la forma que la envuelve. Con este método puedes proteger la forma de la selección, redimensionar, cambiar la posición, agrupar con otros elementos, bloquear su texto para la edición y muchos otros:

```java
// Bloquear formas de modificar

watermarkShape.getShapeLock().setSelectLocked(true);

watermarkShape.getShapeLock().setSizeLocked(true);

watermarkShape.getShapeLock().setTextLocked(true);

watermarkShape.getShapeLock().setPositionLocked(true);

watermarkShape.getShapeLock().setGroupingLocked(true);
```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo bloquear formas de edición](/slides/es/java/presentation-locking/)
{{% /alert %}}

## **Traer Marca de Agua al Frente**
En Aspose.Slides, el orden Z de las formas se puede establecer a través del método [**SlideCollection.reorder**](https://reference.aspose.com/slides/java/com.aspose.slides/SlideCollection#reorder-int-com.aspose.slides.ISlide...-). Para ello, necesitas llamar a este método de la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De esta manera es posible poner la forma al frente o atrás de la diapositiva. Esta función es especialmente útil si necesitas colocar la marca de agua al frente de la presentación:

```java
slide.getShapes().reorder(slide.getShapes().size() - 1, watermarkShape);
```


## **Establecer Rotación de la Marca de Agua**
Aquí hay un ejemplo de cómo establecer la rotación de la marca de agua (y su forma padre):

```java
float h = (float) pres.getSlideSize().getSize().getHeight();

float w = (float) pres.getSlideSize().getSize().getWidth();

watermarkShape.setX((w - watermarkShape.getWidth()) / 2);

watermarkShape.setY((h - watermarkShape.getHeight()) / 2);

watermarkShape.setRotation(calculateRotation(h, w));
```

```java
private int calculateRotation(float height, float width)
{
    double pageHeight = height;
    
    double pageWidth = width;
    
    double rotation = Math.atan((pageHeight / pageWidth)) * 180 / Math.PI;
    
    return (int) rotation;
}
```


## **Establecer Nombre a la Marca de Agua**
Aspose.Slides permite establecer el nombre de la forma. Por nombre de forma puedes acceder a ella en el futuro para modificar o eliminar. Para establecer el nombre de la forma padre de la marca de agua, establecelo en el método [**AutoShape.getName**](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getName--):



```java
watermarkShape.setName("marca de agua");
```


## **Eliminar Marca de Agua**
Para eliminar la forma de marca de agua y sus controles hijos de la diapositiva, utiliza el método [AutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getName--) para encontrarla en las formas de la diapositiva. Luego pasa la forma de marca de agua al método [**ShapeCollection.remove**](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeCollection#remove-com.aspose.slides.IShape-) :

```java
for (int i = 0; i < slide.getShapes().size(); i++)
{
    AutoShape shape = (AutoShape)slide.getShapes().get_Item(i);

    if ("marca de agua".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **Ejemplo en Vivo**
Es posible que desees comprobar las herramientas en línea **gratuitas** de **Aspose.Slides** para [**Añadir Marca de Agua**](https://products.aspose.app/slides/watermark) y [**Eliminar Marca de Agua**](https://products.aspose.app/slides/watermark/remove-watermark).

![todo:image_alt_text](slides-watermark.png)