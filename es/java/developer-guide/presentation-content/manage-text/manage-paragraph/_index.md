---
title: Administrar párrafos de texto de PowerPoint en Java
linktitle: Administrar párrafo
type: docs
weight: 40
url: /es/java/manage-paragraph/
aliases:
  - /java/parrafo/
  - /java/porcion/
keywords:
- añadir texto
- añadir párrafo
- gestionar texto
- gestionar párrafo
- gestionar viñeta
- sangría de párrafo
- sangría francesa
- viñeta de párrafo
- lista numerada
- lista con viñetas
- propiedades del párrafo
- importar HTML
- texto a HTML
- párrafo a HTML
- párrafo a imagen
- texto a imagen
- exportar párrafo
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a crear y dar formato a párrafos, porciones, viñetas, listas numeradas, sangrías, contenido HTML y imágenes de párrafos con Aspose.Slides for Java."
---
## **Descripción general**

Aspose.Slides for Java representa el texto como una jerarquía de marcos de texto, párrafos y porciones:

* [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) representa el contenedor de texto en una forma y proporciona acceso a su colección de párrafos.
* [IParagraph](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/) representa un párrafo en un marco de texto y proporciona acceso a sus porciones y al formato a nivel de párrafo.
* [IPortion](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/) representa una ejecución de texto dentro de un párrafo. Cada porción puede tener su propio texto y formato a nivel de carácter.

Por lo tanto, un párrafo puede contener texto con distintas fuentes, colores, tamaños y otros formatos mediante el uso de varias porciones.

## **Crear y dar formato a párrafos**

### **Crear párrafos con varias porciones**

Los pasos siguientes crean un marco de texto con tres párrafos, cada uno con tres porciones:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
2. Acceder a la diapositiva correspondiente mediante su índice.
3. Añadir una forma rectangular [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) a la diapositiva.
4. Acceder al [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) de la forma.
5. Utilizar el párrafo predeterminado y añadir dos objetos [IParagraph](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/) más al marco de texto.
6. Añadir suficientes objetos [IPortion](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/) para que cada párrafo contenga tres porciones. El párrafo predeterminado ya contiene una porción vacía.
7. Establecer el texto de cada porción.
8. Aplicar formato a nivel de carácter mediante [IPortion.getPortionFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/#getPortionFormat--).
9. Guardar la presentación modificada.

Este ejemplo en Java implementa los pasos:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Crear listas con viñetas y numeradas**

### **Crear una lista con viñetas o numerada**

Las viñetas y la numeración facilitan la lectura de los elementos relacionados. En Aspose.Slides, la configuración de la lista se define mediante [IBulletFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/).

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
2. Acceder a la diapositiva correspondiente mediante su índice.
3. Añadir una [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceder al [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) de la forma.
5. Eliminar el párrafo predeterminado del marco de texto.
6. Crear un [Paragraph](https://reference.aspose.com/slides/es/java/com.aspose.slides/paragraph/) para una viñeta de símbolo.
7. Establecer [IBulletFormat.setType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#setType-int-) a [BulletType.Symbol](https://reference.aspose.com/slides/es/java/com.aspose.slides/bullettype/) y especificar el carácter de la viñeta.
8. Definir el texto del párrafo, la sangría, el color de la viñeta y la altura de la viñeta.
9. Añadir el párrafo al marco de texto.
10. Crear un segundo párrafo y establecer [IBulletFormat.setType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#setType-int-) a [BulletType.Numbered](https://reference.aspose.com/slides/es/java/com.aspose.slides/bullettype/).
11. Configurar el estilo de viñeta numerada y añadir el párrafo al marco de texto.
12. Guardar la presentación.

Este ejemplo en Java crea una viñeta de símbolo y una viñeta numerada:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Usar viñetas con imagen**

Las viñetas con imagen permiten usar una imagen personalizada en lugar de un símbolo o número.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
2. Acceder a la diapositiva correspondiente mediante su índice.
3. Añadir una [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) y acceder a su [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/).
4. Eliminar el párrafo predeterminado del marco de texto.
5. Cargar la imagen de la viñeta y añadirla a la colección de imágenes de la presentación como [IPPImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/ippimage/).
6. Crear un [Paragraph](https://reference.aspose.com/slides/es/java/com.aspose.slides/paragraph/) y establecer su texto.
7. Establecer [IBulletFormat.setType](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#setType-int-) a [BulletType.Picture](https://reference.aspose.com/slides/es/java/com.aspose.slides/bullettype/).
8. Asignar la imagen mediante [IBulletFormat.getPicture](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#getPicture--) y establecer la altura de la viñeta.
9. Añadir el párrafo al marco de texto.
10. Guardar la presentación modificada.

Este ejemplo en Java crea una viñeta con imagen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Crear una lista multinivel**

Establecer [IParagraphFormat.setDepth](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setDepth-short-) para colocar los párrafos en diferentes niveles de una lista. El nivel superior tiene una profundidad de `0`.

1. Crear una [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) y acceder a una diapositiva.
2. Añadir una [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) y limpiar el párrafo predeterminado de su marco de texto.
3. Crear cuatro párrafos y configurar sus símbolos de viñeta.
4. Establecer sus valores [IParagraphFormat.setDepth](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setDepth-short-) a `0`, `1`, `2` y `3`.
5. Añadir los párrafos al marco de texto y guardar la presentación.

Este ejemplo en Java crea una lista con viñetas de cuatro niveles:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Iniciar los elementos numerados de la lista con valores personalizados**

Usar [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) para establecer el número inicial que se muestra en un párrafo numerado.

1. Crear una [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) y añadir una [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) a una diapositiva.
2. Limpiar el párrafo predeterminado del marco de texto de la forma.
3. Crear tres párrafos numerados.
4. Establecer [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) a `2`, `3` y `7` para los respectivos párrafos.
5. Añadir los párrafos al marco de texto y guardar la presentación.

Este ejemplo en Java asigna un número de inicio personalizado a cada párrafo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar el diseño del párrafo y sus propiedades finales**

### **Establecer una sangría de primera línea**

Usar [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setIndent-float-) para controlar la sangría de la primera línea de un párrafo. Este método desplaza solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que las líneas restantes permanecen alineadas con el cuerpo del párrafo.

Usar [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) cuando sea necesario mover todo el párrafo. Usar [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setIndent-float-) cuando solo se quiera mover la primera línea.

El ejemplo a continuación crea varios párrafos y aplica diferentes valores de [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setIndent-float-) para demostrar cómo la sangría de primera línea afecta al diseño del párrafo.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
2. Acceder a la diapositiva objetivo.
3. Añadir una forma rectangular [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) a la diapositiva.
4. Acceder al [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) de la forma y eliminar el párrafo predeterminado.
5. Crear varios párrafos y establecer diferentes valores de [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setIndent-float-) para ellos.
6. Añadir los párrafos al marco de texto.
7. Guardar la presentación modificada.

Este código muestra cómo establecer una sangría de párrafo:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La sangría de la primera línea de los párrafos](first_line_indent.png)

### **Establecer una sangría francesa**

Una sangría francesa es un diseño de párrafo en el que la primera línea comienza a la izquierda de las líneas restantes. En Aspose.Slides, se crea este efecto con [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Pase un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) define la posición izquierda del cuerpo del párrafo, y [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setIndent-float-) define la posición de la primera línea respecto a ese margen. Para crear una sangría francesa, pase un valor positivo a `setMarginLeft` y un valor negativo a `setIndent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas envueltas deben alinearse bajo el cuerpo del párrafo y no bajo el primer carácter de la primera línea.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
2. Acceder a la diapositiva objetivo.
3. Añadir una forma rectangular [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) a la diapositiva.
4. Acceder al [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) de la forma y eliminar el párrafo predeterminado.
5. Crear párrafos y pasar un valor positivo a [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) para cada párrafo.
6. Pasar un valor negativo a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setIndent-float-) para crear el efecto de sangría francesa.
7. Añadir los párrafos al marco de texto.
8. Guardar la presentación modificada.

Este código muestra cómo establecer una sangría francesa para un párrafo:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La sangría francesa de los párrafos](hanging_indent.png)

### **Establecer propiedades de ejecución del párrafo final**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) controla el formato del signo de fin de párrafo. El siguiente ejemplo asigna un tamaño de fuente y una fuente latina al signo de fin del segundo párrafo:

1. Cargar una [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) y acceder a una diapositiva.
2. Añadir una [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) y eliminar su párrafo predeterminado.
3. Crear dos párrafos y añadirles porciones de texto.
4. Crear un [PortionFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/portionformat/) para el signo de fin del segundo párrafo.
5. Establecer [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) y [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Asignar el formato con [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) y guardar la presentación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contar líneas renderizadas**

Usar [IParagraph.getLinesCount](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/#getLinesCount--) para contar las líneas ocupadas por un párrafo después del diseño del texto, incluido el ajuste automático. Esto es útil al comprobar la longitud y el diseño del texto en plantillas de presentaciones.

Un párrafo es un elemento de [ITextFrame.getParagraphs](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#getParagraphs--), y puede ocupar varias líneas renderizadas. Un salto de línea explícito dentro de un párrafo fuerza una nueva línea sin crear otro párrafo. El ajuste automático crea líneas según el ancho disponible sin insertar saltos de línea explícitos en el texto. Por lo tanto, contar párrafos o caracteres de salto de línea no brinda el recuento de líneas renderizadas.

El siguiente ejemplo crea una forma de texto, cuenta sus líneas, estrecha la forma y luego sustituye el texto por una cadena más corta. El ajuste de texto está activado y el autofit desactivado, de modo que el ancho de la forma controla el ajuste sin reducir automáticamente el texto ni redimensionar la forma. Las dimensiones de la forma están en puntos. Finalmente, el ejemplo añade otro párrafo y suma los recuentos de líneas en todo el marco de texto.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Con este texto y estas dimensiones, estrechar la forma aumenta el número de líneas, mientras que sustituir el texto por la cadena corta lo reduce. Los recuentos exactos pueden variar según la disponibilidad de fuentes y sustituciones, el tamaño de fuente, los márgenes, la sangría, el ajuste y la configuración de autofit. Utilice las fuentes y la configuración de diseño previstas para el entorno de destino al comprobar una plantilla.

El recuento de líneas por sí solo no determina si el texto se desborda de su contenedor. También influyen la altura disponible, la altura de línea, el espaciado de párrafo y de línea, y el comportamiento de autofit; incluso una sola línea puede exceder el ancho disponible cuando el ajuste está desactivado.

## **Importar y exportar contenido de párrafos**

### **Importar texto HTML en párrafos**

Usar [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/es/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) para convertir marcado HTML en párrafos y porciones dentro de un marco de texto.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/).
2. Acceder a una diapositiva y añadir una [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/).
3. Acceder al [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) de la forma y limpiar su párrafo predeterminado.
4. Leer el archivo HTML fuente.
5. Pasar la cadena HTML a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/es/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Guardar la presentación modificada.

Este ejemplo en Java importa HTML en un marco de texto:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Exportar texto de párrafo a HTML**

Usar [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/es/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) para exportar un rango seleccionado de párrafos como HTML.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) y cargar la presentación deseada.
2. Acceder a la diapositiva y localizar la [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) que contiene el texto.
3. Acceder al [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) de la forma.
4. Llamar a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/es/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) con el índice del párrafo inicial y el número de párrafos a exportar.
5. Escribir la cadena HTML devuelta en un archivo.

Este ejemplo en Java exporta todos los párrafos del primer cuadro de texto:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Renderizar un párrafo como imagen**

[IParagraph.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/#getImage--) renderiza directamente un párrafo individual y devuelve un [IImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/). Guarde el resultado en un archivo o flujo con [IImage.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/iimage/#save-java.lang.String-int-). No es necesario renderizar la forma contenedora ni recortar manualmente un mapa de bits.

[IParagraph.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/#getImage--) puede devolver `null` si el párrafo no se encuentra en su colección principal, no tiene límites de renderizado válidos o no puede renderizarse. Verifique el resultado antes de guardarlo y libere la imagen devuelta después de su uso.

#### **Renderizar un párrafo a escala predeterminada**

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una sola diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

El siguiente ejemplo renderiza el segundo párrafo en una forma de texto normal a escala predeterminada y guarda la imagen resultante en formato PNG. El bloque `finally` asegura que la imagen se libere correctamente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

El resultado:

![La imagen del párrafo](paragraph_to_image_output.png)

#### **Renderizar un párrafo en una celda de tabla con escalado**

Utilizar la sobrecarga de [IParagraph.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/#getImage-float-float-) que acepta los parámetros `float scaleX` y `float scaleY` para establecer los factores de escala horizontal y vertical. El siguiente ejemplo crea una tabla, renderiza el párrafo en su primera celda al doble de su ancho y altura predeterminados, y guarda el resultado como una imagen PNG.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Un factor de escala de `1` mantiene ese eje en su tamaño de píxel predeterminado. Por ejemplo, `2` para ambos factores produce una imagen cuya anchura y altura son aproximadamente el doble de las dimensiones predeterminadas, lo que genera cuatro veces más píxeles. Los factores mayores suelen producir texto más nítido para ampliación o salida de alta resolución, pero también aumentan el uso de memoria y el tamaño del archivo. Los factores inferiores a `1` generan imágenes más pequeñas con menos detalle. Use factores iguales para conservar la proporción del párrafo; los factores diferentes en horizontal y vertical estiran la salida de forma independiente.

Renderizar una forma completa con [IShape.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getImage--) sigue siendo útil cuando la salida debe incluir el relleno, el borde u otro contexto visual de la forma. Para una imagen que contenga solo el párrafo, use [IParagraph.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/#getImage--).

## **Preguntas frecuentes**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Establezca [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) para desactivar el ajuste, de modo que las líneas no se dividan en los bordes del marco de texto.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Utilice [IParagraph.getRect](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraph/#getRect--) para obtener el rectángulo delimitador del párrafo. [IPortion.getRect](https://reference.aspose.com/slides/es/java/com.aspose.slides/iportion/#getRect--) proporciona los límites de una porción individual.

**¿Dónde se controla la alineación de párrafo (izquierda, derecha, centrado o justificado)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/es/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) es una configuración a nivel de párrafo y se aplica a todo el párrafo, independientemente del formato de cada porción.

**¿Puedo establecer el idioma de corrección para una parte del párrafo?**

Sí. Establezca [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) para porciones individuales, de modo que un párrafo pueda contener texto en varios idiomas.