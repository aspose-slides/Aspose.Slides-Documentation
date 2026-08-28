---
title: Administrar párrafos de texto de PowerPoint en JavaScript
linktitle: Administrar párrafo
type: docs
weight: 40
url: /es/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- añadir texto
- añadir párrafo
- gestionar texto
- gestionar párrafo
- gestionar viñeta
- sangría de párrafo
- sangría colgante
- viñeta de párrafo
- lista numerada
- lista con viñetas
- propiedades de párrafo
- importar HTML
- texto a HTML
- párrafo a HTML
- párrafo a imagen
- texto a imagen
- exportar párrafo
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a crear y formatear párrafos, porciones, viñetas, listas numeradas, sangrías, contenido HTML y imágenes de párrafos con Aspose.Slides para Node.js mediante Java."
---
## **Visión general**

Aspose.Slides for Node.js via Java representa el texto como una jerarquía de marcos de texto, párrafos y porciones:

* [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) representa el contenedor de texto en una forma y proporciona acceso a su colección de párrafos.
* [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/) representa un párrafo en un marco de texto y proporciona acceso a sus porciones y al formato a nivel de párrafo.
* [Portion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/) representa una secuencia de texto dentro de un párrafo. Cada porción puede tener su propio texto y formato a nivel de carácter.

Por lo tanto, un párrafo puede contener texto con diferentes fuentes, colores, tamaños y otros formatos mediante el uso de varias porciones.

## **Crear y formatear párrafos**

### **Crear párrafos con varias porciones**

Los siguientes pasos crean un marco de texto con tres párrafos, cada uno con tres porciones:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la diapositiva correspondiente mediante su índice.
3. Agregue una [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) de la forma.
5. Utilice el párrafo predeterminado y añada dos objetos [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/) más al marco de texto.
6. Agregue suficientes objetos [Portion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/) para que cada párrafo contenga tres porciones. El párrafo predeterminado ya contiene una porción vacía.
7. Establezca el texto de cada porción.
8. Aplique el formato a nivel de carácter mediante [Portion.getPortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/getportionformat/).
9. Guarde la presentación modificada.

Este ejemplo de JavaScript implementa los pasos:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Crear listas con viñetas y numeradas**

### **Crear una lista con viñetas o numerada**

Las viñetas y la numeración facilitan la exploración de elementos relacionados. En Aspose.Slides, la configuración de listas se define mediante [BulletFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bulletformat/).

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la diapositiva correspondiente mediante su índice.
3. Agregue una [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva seleccionada.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) de la forma.
5. Elimine el párrafo predeterminado del marco de texto.
6. Cree un [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/) para una viñeta de símbolo.
7. Establezca [BulletFormat.setType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bulletformat/settype/) en [BulletType.Symbol](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bullettype/) y especifique el carácter de la viñeta.
8. Defina el texto del párrafo, la sangría, el color de la viñeta y la altura de la viñeta.
9. Añada el párrafo al marco de texto.
10. Cree un segundo párrafo y establezca [BulletFormat.setType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bulletformat/settype/) en [BulletType.Numbered](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bullettype/).
11. Configure el estilo de la viñeta numerada y añada el párrafo al marco de texto.
12. Guarde la presentación.

Este ejemplo de JavaScript crea una viñeta de símbolo y una viñeta numerada:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Usar viñetas con imágenes**

Las viñetas con imágenes le permiten usar una imagen personalizada en lugar de un símbolo o número.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la diapositiva correspondiente mediante su índice.
3. Agregue una [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) y acceda a su [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/).
4. Elimine el párrafo predeterminado del marco de texto.
5. Cargue la imagen de la viñeta y agréguela a la colección de imágenes de la presentación como una [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/).
6. Cree un [Paragraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/) y establezca su texto.
7. Establezca [BulletFormat.setType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bulletformat/settype/) en [BulletType.Picture](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bullettype/).
8. Asigne la imagen mediante [BulletFormat.getPicture](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bulletformat/getpicture/) y establezca la altura de la viñeta.
9. Añada el párrafo al marco de texto.
10. Guarde la presentación modificada.

Este ejemplo de JavaScript crea una viñeta con imagen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Crear una lista multinivel**

Establezca [ParagraphFormat.setDepth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setdepth/) para colocar los párrafos en diferentes niveles de una lista. El nivel superior tiene una profundidad de `0`.

1. Cree una [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) y acceda a una diapositiva.
2. Agregue una [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) y elimine el párrafo predeterminado de su marco de texto.
3. Cree cuatro párrafos y configure sus símbolos de viñeta.
4. Establezca sus valores de [ParagraphFormat.setDepth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setdepth/) en `0`, `1`, `2` y `3`.
5. Añada los párrafos al marco de texto y guarde la presentación.

Este ejemplo de JavaScript crea una lista con viñetas de cuatro niveles:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Iniciar los elementos numerados de la lista con valores personalizados**

Use [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) para establecer el número inicial que se muestra en un párrafo numerado.

1. Cree una [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) y agregue una [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a una diapositiva.
2. Elimine el párrafo predeterminado del marco de texto de la forma.
3. Cree tres párrafos numerados.
4. Establezca [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) en `2`, `3` y `7` para los párrafos correspondientes.
5. Añada los párrafos al marco de texto y guarde la presentación.

Este ejemplo de JavaScript asigna un número de inicio personalizado a cada párrafo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar la disposición y propiedades finales del párrafo**

### **Establecer una sangría de primera línea**

Use [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/) para controlar la sangría de la primera línea de un párrafo. Este método mueve solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que el resto de las líneas permanece alineado con el cuerpo del párrafo.

Use [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) cuando necesite mover todo el párrafo. Use [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/) cuando necesite mover solo la primera línea.

El ejemplo a continuación crea varios párrafos y aplica diferentes valores de [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/) para demostrar cómo la sangría de primera línea afecta la disposición del párrafo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Agregue una [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) de la forma y elimine el párrafo predeterminado.
5. Cree varios párrafos y establezca distintos valores de [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/) para ellos.
6. Añada los párrafos al marco de texto.
7. Guarde la presentación modificada.

Este código muestra cómo establecer la sangría de un párrafo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La sangría de primera línea de los párrafos](first_line_indent.png)

### **Establecer una sangría colgante**

Una sangría colgante es una disposición en la que la primera línea comienza a la izquierda del resto de líneas. En Aspose.Slides, crea este efecto con [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/). Pase un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) define la posición izquierda del cuerpo del párrafo, y [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/) define la posición de la primera línea respecto a ese margen. Para crear una sangría colgante, pase un valor positivo a `setMarginLeft` y un valor negativo a `setIndent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas envueltas deben alinearse bajo el cuerpo del párrafo y no bajo el primer carácter de la primera línea.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Agregue una [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) de la forma y elimine el párrafo predeterminado.
5. Cree párrafos y pase un valor positivo a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) para cada párrafo.
6. Pase un valor negativo a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setindent/) para crear el efecto de sangría colgante.
7. Añada los párrafos al marco de texto.
8. Guarde la presentación modificada.

Este código muestra cómo establecer una sangría colgante para un párrafo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La sangría colgante de los párrafos](hanging_indent.png)

### **Establecer propiedades de ejecución del párrafo final**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) controla el formato del signo de fin de párrafo. El siguiente ejemplo asigna un tamaño de fuente y una fuente latina al signo de fin del segundo párrafo:

1. Cree o cargue una [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) y acceda a una diapositiva.
2. Agregue una [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) y elimine su párrafo predeterminado.
3. Cree dos párrafos y añada porciones de texto a cada uno.
4. Cree un [PortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portionformat/) para el signo de fin del segundo párrafo.
5. Establezca [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) y [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Asigne el formato con [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) y guarde la presentación.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importar y exportar contenido de párrafos**

### **Importar texto HTML en párrafos**

Use [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) para convertir marcado HTML en párrafos y porciones dentro de un marco de texto.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a una diapositiva y agregue una [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/).
3. Acceda al [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) de la forma y elimine el párrafo predeterminado.
4. Defina o lea la cadena HTML de origen.
5. Pase la cadena HTML a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Guarde la presentación modificada.

Este ejemplo de JavaScript importa HTML en un marco de texto:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Exportar texto de párrafo a HTML**

Use [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) para exportar un rango seleccionado de párrafos como HTML.

1. Cree o cargue una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la diapositiva y ubique la [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) que contiene el texto.
3. Acceda al [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) de la forma.
4. Llame a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) indicando el índice del párrafo inicial y la cantidad de párrafos a exportar.
5. Escriba la cadena HTML devuelta en un archivo.

Este ejemplo independiente de JavaScript crea una forma de texto y exporta todos sus párrafos:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Renderizar un párrafo como imagen**

[Paragraph.getImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/#getImage) renderiza directamente un párrafo individual y devuelve un [IImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/). Guarde el resultado en un archivo con [IImage.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/iimage/#save). No necesita renderizar la forma contenedora ni recortar un mapa de bits manualmente.

[Paragraph.getImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/#getImage) puede devolver `null` si el párrafo no se encuentra en su colección padre, no tiene límites de renderizado válidos o no puede renderizarse. Verifique el resultado antes de guardarlo y libere la imagen devuelta después de usarla.

#### **Renderizar un párrafo a la escala predeterminada**

El siguiente cuadro de texto contiene tres párrafos:

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

El siguiente ejemplo renderiza el segundo párrafo en una forma de texto normal a la escala predeterminada y guarda la imagen resultante en formato PNG. El bloque `finally` garantiza que la imagen se libere correctamente.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

El resultado:

![La imagen del párrafo](paragraph_to_image_output.png)

#### **Renderizar un párrafo en una celda de tabla con escala**

Utilice la sobrecarga de [Paragraph.getImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/#getImage) que acepta los parámetros `scaleX` y `scaleY` para establecer los factores de escala horizontal y vertical. El siguiente ejemplo crea una tabla, renderiza el párrafo en su primera celda a doble ancho y altura respecto a la escala predeterminada, y guarda el resultado como una imagen PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Un factor de escala de `1` mantiene ese eje en su tamaño de píxel predeterminado. Por ejemplo, `2` para ambos factores produce una imagen cuyo ancho y alto son aproximadamente el doble de las dimensiones predeterminadas, lo que resulta en cuatro veces más píxeles. Los factores mayores generalmente producen texto más nítido para ampliaciones o salidas de alta resolución, pero también aumentan el uso de memoria y el tamaño del archivo. Los factores por debajo de `1` generan imágenes más pequeñas con menos detalle. Use factores iguales para conservar la proporción del párrafo; los factores horizontales y verticales diferentes estiran la salida de forma independiente.

Renderizar una forma completa con [Shape.getImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getImage) sigue siendo útil cuando la salida debe incluir el relleno, el borde u otro contexto visual de la forma. Para una imagen únicamente del párrafo, use [Paragraph.getImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/#getImage).

## **Preguntas frecuentes**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Establezca [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframeformat/setwraptext/) para desactivar el ajuste y que las líneas no se rompan en los bordes del marco de texto.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Use [Paragraph.getRect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraph/getrect/) para recuperar el rectángulo delimitador del párrafo. [Portion.getRect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/#getRect) proporciona los límites de una porción individual.

**¿Dónde se controla la alineación del párrafo (izquierda, derecha, centrado o justificado)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/paragraphformat/setalignment/) es una configuración a nivel de párrafo y se aplica a todo el párrafo independientemente del formato de las porciones individuales.

**¿Puedo establecer el idioma de revisión para una parte de un párrafo?**

Sí. Establezca [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) para porciones individuales, de modo que un párrafo pueda contener texto en varios idiomas.