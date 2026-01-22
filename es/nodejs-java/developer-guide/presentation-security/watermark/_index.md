---
title: Añadir marcas de agua a presentaciones en JavaScript
linktitle: Marca de agua
type: docs
weight: 40
url: /es/nodejs-java/watermark/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestiona marcas de agua de texto e imagen en presentaciones PowerPoint y OpenDocument en Node.js para indicar un borrador, información confidencial, derechos de autor y más."
---

## **Acerca de la marca de agua**

**Una marca de agua** en una presentación es un sello de texto o imagen utilizado en una diapositiva o en todas las diapositivas de la presentación. Normalmente, se usa para indicar que la presentación es un borrador (p. ej., una marca de agua “Borrador”), que contiene información confidencial (p. ej., una marca de agua “Confidencial”), para especificar a qué empresa pertenece (p. ej., una marca de agua “Nombre de la empresa”), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir violaciones de derechos de autor al indicar que la presentación no debe copiarse. Las marcas de agua se utilizan tanto en formatos de presentación PowerPoint como OpenOffice. En Aspose.Slides, puede añadir una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/), existen varias formas de crear marcas de agua en documentos PowerPoint u OpenOffice y de modificar su diseño y comportamiento. El aspecto común es que, para añadir marcas de agua de texto, debe usar el tipo [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/), y, para añadir marcas de agua de imagen, utilice la clase [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) o rellene una forma de marca de agua con una imagen. `PictureFrame` implementa el tipo [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), lo que le permite usar todas las configuraciones flexibles del objeto forma. Dado que `TextFrame` no es una forma y sus configuraciones son limitadas, se envuelve en un objeto [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

Hay dos maneras de aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. El maestro de diapositivas se utiliza para aplicar una marca de agua a todas las diapositivas: la marca de agua se añade al maestro de diapositivas, se diseña completamente allí y se aplica a todas las diapositivas sin afectar la posibilidad de modificar la marca de agua en diapositivas individuales.

Una marca de agua suele considerarse no editable por otros usuarios. Para evitar que la marca de agua (o, más concretamente, la forma padre de la marca de agua) sea editada, Aspose.Slides proporciona funcionalidad de bloqueo de forma. Una forma específica puede bloquearse en una diapositiva normal o en un maestro de diapositivas. Cuando la forma de la marca de agua está bloqueada en el maestro de diapositivas, estará bloqueada en todas las diapositivas de la presentación.

Puede asignar un nombre a la marca de agua para que, en el futuro, si desea eliminarla, pueda encontrarla entre las formas de la diapositiva por nombre.

Puede diseñar la marca de agua de cualquier manera; sin embargo, suelen existir características comunes en las marcas de agua, como alineación centrada, rotación, posición al frente, etc. Trataremos de cómo usar estas características en los ejemplos a continuación.

## **Marca de agua de texto**

### **Añadir marca de agua de texto a una diapositiva**

Para añadir una marca de agua de texto en PPT, PPTX o ODP, primero puede añadir una forma a la diapositiva y, a continuación, añadir un marco de texto a esa forma. El marco de texto está representado por el tipo [**TextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame). Este tipo no hereda de [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape), que tiene un amplio conjunto de propiedades para posicionar la marca de agua de forma flexible. Por ello, el objeto [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) se envuelve en un objeto [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape). Para añadir texto de marca de agua a la forma, utilice el método [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) con el texto de la marca de agua como argumento:
```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```


{{% alert color="primary" title="Ver también" %}} 
- Cómo usar [TextFrame](/slides/es/nodejs-java/text-formatting/).
{{% /alert %}}

### **Añadir marca de agua de texto a la presentación**

Si desea añadir una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), añádala al [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide). El resto de la lógica es idéntico al de añadir una marca de agua a una sola diapositiva: cree un objeto [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) y, a continuación, añada la marca de agua mediante el método [**addTextFrame**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-):
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

### **Establecer la transparencia de la forma de marca de agua**

Por defecto, la forma rectangular se estiliza con colores de relleno y de línea. Las siguientes líneas de código hacen que la forma sea transparente.
```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```


### **Establecer la fuente de una marca de agua de texto**

Puede cambiar la fuente de la marca de agua de texto como se muestra a continuación.
```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```


### **Establecer el color del texto de la marca de agua**

Para establecer el color del texto de la marca de agua, utilice este código:
```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```


### **Centrar la marca de agua de texto**

Es posible centrar la marca de agua en una diapositiva; para ello, puede hacer lo siguiente:
```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```


La imagen siguiente muestra el resultado final.

![The text watermark](text_watermark.png)

## **Marca de agua de imagen**

### **Añadir una marca de agua de imagen a una presentación**

Para añadir una marca de agua de imagen a todas las diapositivas de la presentación, puede hacer lo siguiente:
```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```


### **Bloquear una marca de agua para que no se edite**

Si es necesario evitar que una marca de agua se edite, utilice el método [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getShapeLock--) sobre la forma. Con esta propiedad, puede proteger la forma contra la selección, el redimensionado, el reposicionamiento, la agrupación con otros elementos, bloquear su texto contra la edición y mucho más:
```javascript
// Bloquear la forma de la marca de agua para que no se modifique
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```


### **Traer una marca de agua al frente**

En Aspose.Slides, el orden Z de las formas puede establecerse mediante el método [**SlideCollection.reorder**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). Para ello, debe llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De este modo, es posible llevar una forma al frente o enviarla al fondo de la diapositiva. Esta característica es especialmente útil si necesita colocar una marca de agua delante de la presentación:
```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```


### **Establecer la rotación de la marca de agua**

A continuación se muestra un ejemplo de código que ajusta la rotación de la marca de agua para que quede posicionada diagonalmente sobre la diapositiva:
```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```


### **Asignar un nombre a una marca de agua**

Aspose.Slides le permite asignar un nombre a una forma. Mediante el nombre de la forma, puede acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de la marca de agua, asígnelo mediante el método [**AutoShape.getName**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--):
```javascript
watermarkShape.setName("watermark");
```


### **Eliminar una marca de agua**

Para eliminar la forma de la marca de agua, utilice el método [AutoShape.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getName--) para encontrarla entre las formas de la diapositiva. Luego, pase la forma de la marca de agua al método [**ShapeCollection.remove**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):
```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```


## **FAQ**

**¿Qué es una marca de agua y por qué debería usarla?**

Una marca de agua es una superposición de texto o imagen aplicada a las diapositivas que ayuda a proteger la propiedad intelectual, mejorar el reconocimiento de la marca o prevenir el uso no autorizado de presentaciones.

**¿Puedo añadir una marca de agua a todas las diapositivas de una presentación?**

Sí, Aspose.Slides permite añadir una marca de agua a cada diapositiva de una presentación. Puede iterar sobre todas las diapositivas y aplicar la configuración de la marca de agua individualmente.

**¿Cómo puedo ajustar la transparencia de la marca de agua?**

Puede ajustar la transparencia de la marca de agua modificando la [configuración de relleno](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) de la forma. Así garantiza que la marca de agua sea sutil y no distraiga del contenido de la diapositiva.

**¿Qué formatos de imagen son compatibles con las marcas de agua?**

Aspose.Slides es compatible con varios formatos de imagen como PNG, JPEG, GIF, BMP, SVG y más.

**¿Puedo personalizar la fuente y el estilo de una marca de agua de texto?**

Sí, puede elegir cualquier fuente, tamaño y estilo para que coincidan con el diseño de su presentación y mantengan la coherencia de la marca.

**¿Cómo cambio la posición o la orientación de una marca de agua?**

Puede ajustar la posición y orientación de la marca de agua modificando las coordenadas, el tamaño y las propiedades de rotación de la forma.