---
title: Gestionar párrafos de texto de PowerPoint en Android
linktitle: Gestionar párrafo
type: docs
weight: 40
url: /es/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
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
- Android
- Java
- Aspose.Slides
description: "Aprenda a crear y formatear párrafos, porciones, viñetas, listas numeradas, sangrías, contenido HTML y imágenes de párrafos con Aspose.Slides para Android mediante Java."
---
## **Visión general**

Aspose.Slides for Android via Java representa el texto como una jerarquía de marcos de texto, párrafos y porciones:

* [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) representa el contenedor de texto en una forma y proporciona acceso a su colección de párrafos.
* [IParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/) representa un párrafo en un marco de texto y proporciona acceso a sus porciones y al formato a nivel de párrafo.
* [IPortion](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iportion/) representa una ejecución de texto dentro de un párrafo. Cada porción puede tener su propio texto y formato a nivel de carácter.

Por lo tanto, un párrafo puede contener texto con diferentes fuentes, colores, tamaños y otros formatos mediante el uso de varias porciones.

## **Crear y formatear párrafos**

### **Crear párrafos con múltiples porciones**

Los siguientes pasos crean un marco de texto con tres párrafos, cada uno con tres porciones:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Acceda a la diapositiva pertinente mediante su índice.
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) rectangular a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) de la forma.
5. Utilice el párrafo predeterminado y añada dos objetos [IParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/) más al marco de texto.
6. Añada suficientes objetos [IPortion](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iportion/) para que cada párrafo contenga tres porciones. El párrafo predeterminado ya contiene una porción vacía.
7. Establezca el texto de cada porción.
8. Aplique formato a nivel de carácter mediante [IPortion.getPortionFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Guarde la presentación modificada.

Este ejemplo de Android vía Java implementa los pasos:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Los viñetas y la numeración hacen que los elementos relacionados sean más fáciles de examinar. En Aspose.Slides, la configuración de la lista se define a través de [IBulletFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/).

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Acceda a la diapositiva pertinente mediante su índice.
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) de la forma.
5. Elimine el párrafo predeterminado del marco de texto.
6. Cree un [Paragraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraph/) para una viñeta de símbolo.
7. Establezca [IBulletFormat.setType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setType-int-) a [BulletType.Symbol](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/bullettype/) y especifique el carácter de la viñeta.
8. Establezca el texto del párrafo, la sangría, el color de la viñeta y la altura de la viñeta.
9. Añada el párrafo al marco de texto.
10. Cree un segundo párrafo y establezca [IBulletFormat.setType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setType-int-) a [BulletType.Numbered](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/bullettype/).
11. Configure el estilo de viñeta numerada y añada el párrafo al marco de texto.
12. Guarde la presentación.

Este ejemplo de Android vía Java crea una viñeta de símbolo y una viñeta numerada:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Usar viñetas con imágenes**

Las viñetas con imágenes le permiten usar una imagen personalizada en lugar de un símbolo o número.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Acceda a la diapositiva pertinente mediante su índice.
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) y acceda a su [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/).
4. Elimine el párrafo predeterminado del marco de texto.
5. Cargue la imagen de la viñeta y añádala a la colección de imágenes de la presentación como un [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/).
6. Cree un [Paragraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraph/) y establezca su texto.
7. Establezca [IBulletFormat.setType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setType-int-) a [BulletType.Picture](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/bullettype/).
8. Asigne la imagen mediante [IBulletFormat.getPicture](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#getPicture--) y establezca la altura de la viñeta.
9. Añada el párrafo al marco de texto.
10. Guarde la presentación modificada.

Este ejemplo de Android vía Java crea una viñeta con imagen:

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

Establezca [IParagraphFormat.setDepth](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) para colocar los párrafos en diferentes niveles de una lista. El nivel superior tiene una profundidad de `0`.

1. Cree una [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) y acceda a una diapositiva.
2. Añada una [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) y elimine el párrafo predeterminado de su marco de texto.
3. Cree cuatro párrafos y configure sus símbolos de viñeta.
4. Establezca sus valores [IParagraphFormat.setDepth](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) a `0`, `1`, `2` y `3`.
5. Añada los párrafos al marco de texto y guarde la presentación.

Este ejemplo de Android vía Java crea una lista con viñetas de cuatro niveles:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Iniciar los elementos numerados de la lista en valores personalizados**

Utilice [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) para establecer el número inicial que se muestra para un párrafo numerado.

1. Cree una [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) y añada una [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) a una diapositiva.
2. Elimine el párrafo predeterminado del marco de texto de la forma.
3. Cree tres párrafos numerados.
4. Establezca [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) a `2`, `3` y `7` para los respectivos párrafos.
5. Añada los párrafos al marco de texto y guarde la presentación.

Este ejemplo de Android vía Java asigna un número de inicio personalizado a cada párrafo:

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

## **Controlar el diseño y las propiedades finales del párrafo**

### **Establecer una sangría de primera línea**

Utilice [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para controlar la sangría de la primera línea de un párrafo. Este método desplaza solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que el resto de líneas permanecen alineadas al cuerpo del párrafo.

Utilice [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) cuando necesite mover todo el párrafo. Utilice [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) cuando necesite mover solo la primera línea.

El ejemplo a continuación crea varios párrafos y aplica diferentes valores [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para demostrar cómo la sangría de primera línea afecta al diseño del párrafo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) rectangular a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) de la forma y elimine el párrafo predeterminado.
5. Cree varios párrafos y establezca diferentes valores [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para ellos.
6. Añada los párrafos al marco de texto.
7. Guarde la presentación modificada.

Este código muestra cómo establecer una sangría de párrafo:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![La sangría de primera línea de los párrafos](first_line_indent.png)

### **Establecer una sangría francesa**

Una sangría francesa es un diseño de párrafo en el que la primera línea comienza a la izquierda del resto de líneas. En Aspose.Slides, crea este efecto con [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Pase un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) define la posición izquierda del cuerpo del párrafo, y [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) define la posición de la primera línea respecto a ese margen. Para crear una sangría francesa, pase un valor positivo a `setMarginLeft` y un valor negativo a `setIndent`.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas ajustadas deben alinearse bajo el cuerpo del párrafo en lugar de bajo el primer carácter de la primera línea.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) rectangular a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) de la forma y elimine el párrafo predeterminado.
5. Cree párrafos y pase un valor positivo a [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) para cada párrafo.
6. Pase un valor negativo a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) para crear el efecto de sangría francesa.
7. Añada los párrafos al marco de texto.
8. Guarde la presentación modificada.

Este código muestra cómo establecer una sangría francesa para un párrafo:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Establecer propiedades de ejecución del final del párrafo**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) controla el formato del signo de final de párrafo. El siguiente ejemplo asigna un tamaño de fuente y una fuente latina al signo final del segundo párrafo:

1. Cargue una [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) y acceda a una diapositiva.
2. Añada una [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) y elimine su párrafo predeterminado.
3. Cree dos párrafos y añada porciones de texto a ellos.
4. Cree un [PortionFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/portionformat/) para el signo final del segundo párrafo.
5. Establezca [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) y [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Asigne el formato con [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) y guarde la presentación.

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

## **Importar y exportar contenido de párrafos**

### **Importar texto HTML en párrafos**

Utilice [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) para convertir el marcado HTML en párrafos y porciones en un marco de texto.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Acceda a una diapositiva y añada una [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/).
3. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/) de la forma y elimine su párrafo predeterminado.
4. Lea el archivo HTML fuente.
5. Pase la cadena HTML a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Guarde la presentación modificada.

Este ejemplo de Android vía Java importa HTML en un marco de texto:

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

Utilice [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) para exportar un rango seleccionado de párrafos como HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) y cargue la presentación deseada.
2. Acceda a la diapositiva y encuentre la [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) que contiene el texto.
3. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/).
4. Llame a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) con el índice del párrafo inicial y el número de párrafos a exportar.
5. Escriba la cadena HTML devuelta en un archivo.

Este ejemplo de Android vía Java exporta todos los párrafos de la primera forma de texto:

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

[IParagraph.getImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/#getImage--) renderiza directamente un párrafo individual y devuelve un [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/). Guarde el resultado en un archivo o flujo con [IImage.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). No necesita renderizar la forma contenedora ni recortar manualmente un bitmap.

[IParagraph.getImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/#getImage--) puede devolver `null` si el párrafo no se encuentra en su colección padre, no tiene límites de renderizado válidos o no se puede renderizar. Verifique el resultado antes de guardarlo y libere la imagen devuelta después de su uso.

#### **Renderizar un párrafo a la escala predeterminada**

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

El siguiente ejemplo renderiza el segundo párrafo en una forma de texto regular a la escala predeterminada y guarda la imagen devuelta en formato PNG. El bloque `finally` asegura que la imagen se libere correctamente.

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

Utilice la sobrecarga [IParagraph.getImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) que acepta los parámetros `float scaleX` y `float scaleY` para establecer los factores de escala horizontal y vertical. El siguiente ejemplo crea una tabla, renderiza el párrafo en su primera celda al doble de su ancho y altura predeterminados, y guarda el resultado como una imagen PNG.

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

Un factor de escala de `1` mantiene ese eje en su tamaño de píxel predeterminado. Por ejemplo, `2` para ambos factores produce una imagen cuyo ancho y alto son aproximadamente el doble de las dimensiones predeterminadas, lo que resulta en cuatro veces más píxeles. Los factores mayores generalmente producen texto más nítido para ampliación o salida de alta resolución, pero también aumentan el uso de memoria y el tamaño del archivo. Los factores por debajo de `1` generan imágenes más pequeñas con menos detalle. Use factores iguales para conservar la relación de aspecto del párrafo; factores horizontales y verticales diferentes estiran la salida de forma independiente.

Renderizar una forma completa con [IShape.getImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getImage--) sigue siendo útil cuando la salida debe incluir el relleno, borde u otro contexto visual de la forma. Para una imagen solo del párrafo, use [IParagraph.getImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **Preguntas frecuentes**

**¿Puedo desactivar por completo el ajuste de línea dentro de un marco de texto?**

Sí. Establezca [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) para desactivar el ajuste, de modo que las líneas no se dividan en los bordes del marco de texto.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo específico?**

Utilice [IParagraph.getRect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/#getRect--) para obtener el rectángulo delimitador del párrafo. [IPortion.getRect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iportion/#getRect--) proporciona los límites de una porción individual.

**¿Dónde se controla la alineación del párrafo (izquierda, derecha, centrado o justificado)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) es una configuración a nivel de párrafo y se aplica a todo el párrafo independientemente del formato de las porciones individuales.

**¿Puedo establecer el idioma de corrección para una parte de un párrafo?**

Sí. Establezca [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) para porciones individuales, de modo que un párrafo pueda contener texto en varios idiomas.