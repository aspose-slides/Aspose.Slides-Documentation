---
title: Marca de agua
type: docs
weight: 40
url: /es/nodejs-java/watermark/
keywords: "marca de agua en presentación"
description: "Utiliza marcas de agua en PowerPoint con Aspose.Slides. Añade una marca de agua en una presentación ppt o elimina la marca de agua. Inserta una marca de agua de imagen o una marca de agua de texto."
---

## **Acerca de la Marca de Agua**

**Una marca de agua** en una presentación es un sello de texto o imagen que se usa en una diapositiva o en todas las diapositivas de la presentación. Normalmente, una marca de agua se utiliza para indicar que la presentación es un borrador (p. ej., una marca de agua “Borrador”), que contiene información confidencial (p. ej., una marca de agua “Confidencial”), para especificar a qué empresa pertenece (p. ej., una marca de agua “Nombre de la Empresa”), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir violaciones de derechos de autor al indicar que la presentación no debe copiarse. Las marcas de agua se usan tanto en formatos de presentación PowerPoint como OpenOffice. En Aspose.Slides, puedes agregar una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/), existen varias formas de crear marcas de agua en documentos PowerPoint o OpenOffice y modificar su diseño y comportamiento. El aspecto común es que, para agregar marcas de agua de texto, debes usar el tipo [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), y para agregar marcas de agua de imagen, usar la clase [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) o rellenar una forma de marca de agua con una imagen. `PictureFrame` implementa el tipo [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), lo que te permite usar todas las configuraciones flexibles del objeto forma. Dado que `TextFrame` no es una forma y sus configuraciones son limitadas, está envuelto en un objeto [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

Hay dos formas de aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. El Master de Diapositivas se usa para aplicar una marca de agua a todas las diapositivas: la marca de agua se agrega al Master de Diapositivas, se diseña completamente allí y se aplica a todas las diapositivas sin afectar la posibilidad de modificar la marca de agua en diapositivas individuales.

Una marca de agua generalmente se considera no disponible para la edición por otros usuarios. Para evitar que la marca de agua (o más bien la forma padre de la marca de agua) sea editada, Aspose.Slides proporciona funcionalidad de bloqueo de formas. Una forma específica puede bloquearse en una diapositiva normal o en un Master de Diapositivas. Cuando la forma de la marca de agua está bloqueada en el Master de Diapositivas, estará bloqueada en todas las diapositivas de la presentación.

Puedes establecer un nombre para la marca de agua de modo que, en el futuro, si deseas eliminarla, puedas encontrarla en las formas de la diapositiva por su nombre.

Puedes diseñar la marca de agua de cualquier manera; sin embargo, suelen existir características comunes en las marcas de agua, como alineación centrada, rotación, posición frontal, etc. Consideraremos cómo usar estas características en los ejemplos a continuación.

## **Marca de Agua de Texto**

### **Agregar Marca de Agua de Texto a la Diapositiva**
Para agregar una marca de agua de texto en PPT, PPTX o ODP, puedes primero agregar una forma a la diapositiva y luego agregar un marco de texto a esa forma. El marco de texto está representado por el tipo [**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame). Este tipo no hereda de [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape), que posee un amplio conjunto de propiedades para posicionar la marca de agua de forma flexible. Por lo tanto, el objeto [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) está envuelto en un objeto [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape). Para agregar texto de marca de agua a la forma, usa el método [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) pasando el texto de la marca de agua:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/es/nodejs-java/slide-master/)[TextFrame](/slides/es/nodejs-java/adding-and-formatting-text/)
{{% /alert %}}

### **Agregar Marca de Agua de Texto a la Presentación**

Si deseas agregar una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), agrégala al [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide). El resto de la lógica es igual que al agregar una marca de agua a una sola diapositiva: crea un objeto [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) y luego agrega la marca de agua usando el método [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-):
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/es/nodejs-java/slide-master/)[Slide Master](/slides/es/nodejs-java/slide-master/)
{{% /alert %}}

### **Establecer Transparencia de la Forma de la Marca de Agua**

De forma predeterminada, la forma rectangular tiene colores de relleno y línea. Las siguientes líneas de código hacen que la forma sea transparente.
```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```


### **Establecer la Fuente para una Marca de Agua de Texto**

Puedes cambiar la fuente de la marca de agua de texto como se muestra a continuación.
```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```


### **Establecer el Color del Texto de la Marca de Agua**

Para establecer el color del texto de la marca de agua, usa este código:
```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```


### **Centrar Marca de Agua de Texto**
Es posible centrar la marca de agua en una diapositiva y, para ello, puedes hacer lo siguiente:
```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


La imagen a continuación muestra el resultado final.

![La marca de agua de texto](text_watermark.png)

## **Marca de Agua de Imagen**

### **Agregar una Marca de Agua de Imagen a una Presentación**

Para agregar una marca de agua de imagen a todas las diapositivas de la presentación, puedes hacer lo siguiente:
```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```


### **Bloquear una Marca de Agua contra la Edición**

Si es necesario evitar que una marca de agua sea editada, usa el método [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--) en la forma. Con esta propiedad, puedes proteger la forma contra la selección, el cambio de tamaño, el reposicionamiento, la agrupación con otros elementos, bloquear su texto contra la edición y mucho más:
```javascript
// Bloquear la forma de la marca de agua para evitar su modificación
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo Bloquear Formas contra la Edición](/slides/es/nodejs-java/presentation-locking/)
{{% /alert %}}

### **Traer una Marca de Agua al Frente**

En Aspose.Slides, el orden Z de las formas puede establecerse mediante el método [**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). Para ello, debes llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden. De esta manera, es posible llevar una forma al frente o enviarla al fondo de la diapositiva. Esta característica es especialmente útil si necesitas colocar una marca de agua delante de la presentación:
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **Establecer Rotación de la Marca de Agua**

A continuación se muestra un ejemplo de código de cómo ajustar la rotación de la marca de agua para que quede posicionada diagonalmente a través de la diapositiva:
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **Establecer un Nombre para una Marca de Agua**

Aspose.Slides permite establecer el nombre de una forma. Al usar el nombre de la forma, puedes acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de la marca de agua, asígnalo al método [**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--):
```javascript
watermarkShape.setName("watermark");
```


### **Eliminar una Marca de Agua**

Para eliminar la forma de la marca de agua, usa el método [AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) para encontrarla en las formas de la diapositiva. Luego, pasa la forma de la marca de agua al método [**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):
```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **Preguntas frecuentes**

**¿Qué es una marca de agua y por qué debería usarla?**

Una marca de agua es una superposición de texto o imagen aplicada a las diapositivas que ayuda a proteger la propiedad intelectual, mejorar el reconocimiento de la marca o evitar el uso no autorizado de presentaciones.

**¿Puedo agregar una marca de agua a todas las diapositivas de una presentación?**

Sí, Aspose.Slides permite agregar una marca de agua a cada diapositiva de una presentación. Puedes iterar todas las diapositivas y aplicar la configuración de la marca de agua individualmente.

**¿Cómo puedo ajustar la transparencia de la marca de agua?**

Puedes ajustar la transparencia de la marca de agua modificando la [configuración de relleno](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) de la forma. Esto garantiza que la marca de agua sea sutil y no distraiga del contenido de la diapositiva.

**¿Qué formatos de imagen son compatibles con las marcas de agua?**

Aspose.Slides admite varios formatos de imagen como PNG, JPEG, GIF, BMP, SVG y más.

**¿Puedo personalizar la fuente y el estilo de una marca de agua de texto?**

Sí, puedes elegir cualquier fuente, tamaño y estilo para que coincidan con el diseño de tu presentación y mantengan la coherencia de la marca.

**¿Cómo cambio la posición o la orientación de una marca de agua?**

Puedes ajustar la posición y la orientación de la marca de agua modificando las coordenadas, el tamaño y las propiedades de rotación de la forma.