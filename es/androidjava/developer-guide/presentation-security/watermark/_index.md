---
title: Marca de Agua
type: docs
weight: 40
url: /es/androidjava/watermark/
keywords: "marca de agua en presentación"
description: "Usa marca de agua en PowerPoint con Aspose.Slides. Agrega marca de agua en presentación ppt o elimina la marca de agua. Inserta imagen de marca de agua o texto de marca de agua."
---

## **Acerca de la Marca de Agua**
La **marca de agua** en una presentación es un sello de texto o imagen, utilizado en una diapositiva o en todas las diapositivas de la presentación. Usualmente, la marca de agua se utiliza para indicar que la presentación es un borrador (por ejemplo, la marca de agua "Borrador"); que contiene información confidencial (por ejemplo, la marca de agua "Confidencial"); especificar a qué empresa pertenece (por ejemplo, la marca de agua "Nombre de la empresa"); identificar al autor de la presentación, etc. La marca de agua ayuda a prevenir violaciones de derechos de autor en las presentaciones, indicando que esta no debe ser copiada. Las marcas de agua se utilizan tanto en formatos de presentación de PowerPoint como de OpenOffice. En Aspose.Slides puedes agregar marcas de agua a formatos de archivo de PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) hay varias formas de crear una marca de agua en PowerPoint o OpenOffice, de adaptarla en diferentes formas, de cambiar el diseño y comportamiento, etc. La cuestión común es que para agregar marcas de agua de texto debes usar la clase [**TextFrame**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) y para agregar marcas de agua de imagen - [**PictureFrame**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame/). [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame/) implementa la interfaz [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) y puede utilizar todo el poder de las configuraciones flexibles del objeto de forma. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) no es una forma y sus configuraciones son limitadas. Por lo tanto, se aconseja envolver el objeto [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) en un objeto [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).

Hay dos formas en que se puede aplicar la marca de agua: a una sola diapositiva y a todas las diapositivas de la presentación. El Master de Diapositivas se utiliza para aplicar la marca de agua a todas las diapositivas de la presentación; la marca de agua se agrega en el Master de Diapositivas, se diseña completamente allí y se aplica a todas las diapositivas sin modificar el permiso para modificar la marca de agua en las diapositivas.

La marca de agua generalmente se considera no disponible para la edición por otros usuarios. Para evitar la edición de la marca de agua (o más bien de la forma padre de la marca de agua), Aspose.Slides proporciona funcionalidad de bloqueo de formas. Una cierta forma puede ser bloqueada en una diapositiva normal o en un Master de Diapositivas. Al bloquear la forma de marca de agua en un Master de Diapositivas, se bloqueará en todas las diapositivas de la presentación.

Puedes establecer el nombre de la marca de agua, así que en el futuro, si deseas eliminar la marca de agua, puedes encontrarla en las formas de las diapositivas por su nombre.

Puedes diseñar la marca de agua de cualquier manera; sin embargo, generalmente hay características comunes dentro de las marcas de agua, como: alineación central, rotación, posición al frente, etc. Consideraremos cómo utilizarlas en los ejemplos a continuación.
## **Marca de Agua de Texto**
### **Agregar Marca de Agua de Texto a Diapositiva**
Para agregar una marca de agua de texto en PPT, PPTX o ODP, primero puedes agregar una forma a la diapositiva, luego agregar un marco de texto a esta forma. El marco de texto se representa con el tipo [**TextFrame**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame). Este tipo no se hereda de [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape), que tiene un conjunto amplio de propiedades para colocar la marca de agua de manera flexible. Por lo tanto, se aconseja envolver el objeto [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) en un objeto [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape). Para agregar la marca de agua dentro de la forma, usa el método [**addTextFrame**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) con el texto de la marca de agua pasado a él:

```java
// Abrir presentación
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 0, 0, 0, 0);

    ITextFrame watermarkTextFrame = watermarkShape.addTextFrame("Marca de Agua");
    
} finally {
    if (presentation != null) presentation.dispose();
}
```



{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/es/androidjava/slide-master/)[TextFrame](/slides/es/androidjava/adding-and-formatting-text/)
{{% /alert %}}

### **Agregar Marca de Agua de Texto a la Presentación**
Si deseas agregar una marca de agua en la presentación (es decir, en todas las diapositivas a la vez), agrégala en [**MasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterSlide).
Toda la otra lógica es la misma que al agregar marca de agua a una sola diapositiva: crea un objeto [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) y luego agrega la marca de agua en él con el método [**addTextFrame**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-):

```java
// Abrir presentación
Presentation pres = new Presentation();
try {
    IMasterSlide master = pres.getMasters().get_Item(0);

    IAutoShape watermarkShape = master.getShapes().addAutoShape(ShapeType.Triangle, 0, 0, 0, 0);

    ITextFrame watermarkTextFrame = watermarkShape.addTextFrame("Marca de Agua");

} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/es/androidjava/slide-master/)[Master de Diapositivas](/slides/es/androidjava/slide-master/)
{{% /alert %}}

### **Establecer Fuente de la Marca de Agua de Texto**
Puedes cambiar la fuente de la marca de agua de texto:

```java
IPortion watermarkPortion = watermarkTextFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);

watermarkPortion.getPortionFormat().setFontBold(NullableBool.True);

watermarkPortion.getPortionFormat().setFontHeight(52);
```


### **Establecer Transparencia de la Marca de Agua de Texto**
Para establecer la transparencia de la marca de agua de texto, utiliza este código:

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
### **Agregar Marca de Agua de Imagen a la Presentación**
Para agregar una marca de agua de imagen en todas las diapositivas de la presentación, puedes hacer lo siguiente:

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




## **Bloquear Marca de Agua de Edición**
Si es necesario prevenir la edición de la marca de agua, utiliza el método [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape#getShapeLock--) en la forma que la envuelve. Con este método puedes proteger la forma de selección, redimensionar, cambiar de posición, agrupar con otros elementos, bloquear su texto de edición y muchas otras:

```java
// Bloquear formas de modificación

watermarkShape.getShapeLock().setSelectLocked(true);

watermarkShape.getShapeLock().setSizeLocked(true);

watermarkShape.getShapeLock().setTextLocked(true);

watermarkShape.getShapeLock().setPositionLocked(true);

watermarkShape.getShapeLock().setGroupingLocked(true);
```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo bloquear formas de edición](/slides/es/androidjava/presentation-locking/)
{{% /alert %}}

## **Traer Marca de Agua al Frente**
En Aspose.Slides, el orden Z de las formas se puede establecer a través del método [**SlideCollection.reorder**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#reorder-int-com.aspose.slides.ISlide...-). Para eso, necesitas llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De este modo, es posible colocar la forma al frente o atrás de la diapositiva. Esta característica es especialmente útil si necesitas colocar la marca de agua al frente de la presentación:

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
Aspose.Slides permite establecer el nombre de la forma. Por el nombre de la forma puedes acceder a ella en el futuro para modificar o eliminar. Para establecer el nombre de la forma padre de la marca de agua: colócalo en el método [**AutoShape.getName**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getName--):



```java
watermarkShape.setName("marca de agua");
```


## **Eliminar Marca de Agua**
Para eliminar la forma de marca de agua y sus controles hijos de la diapositiva, utiliza el método [AutoShape.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getName--) para encontrarla en las formas de la diapositiva. Luego pasa la forma de marca de agua al método [**ShapeCollection.remove**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeCollection#remove-com.aspose.slides.IShape-) :

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
Puede que desees probar las herramientas en línea **gratis** **[Agregar Marca de Agua](https://products.aspose.app/slides/watermark)** y **[Eliminar Marca de Agua](https://products.aspose.app/slides/watermark/remove-watermark)** de **Aspose.Slides**.

![todo:image_alt_text](slides-watermark.png)