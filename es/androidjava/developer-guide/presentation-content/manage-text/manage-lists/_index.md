---
title: Administrar listas con viñetas y numeradas en presentaciones en Android
linktitle: Gestionar listas
type: docs
weight: 60
url: /es/androidjava/manage-lists/
keywords:
- viñeta
- lista con viñetas
- lista numerada
- viñeta de símbolo
- viñeta con imagen
- viñeta personalizada
- lista multinivel
- crear viñeta
- añadir viñeta
- añadir lista
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo crear y formatear listas con viñetas, con imagen, multinivel y numeradas en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Android mediante Java."
---
## **Visión general**

Aspose.Slides para Android a través de Java le permite crear y formatear listas con viñetas y numeradas en presentaciones de PowerPoint y OpenDocument. Un elemento de lista es un párrafo cuyas configuraciones de viñeta se controlan mediante su formato de párrafo.

Use el método [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) para acceder a la configuración de listas a nivel de párrafo. El punto de entrada principal es [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), que devuelve un objeto [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/). Con este objeto, puede establecer el tipo de viñeta, el símbolo, la imagen, el color, el tamaño, el estilo de numeración y el número inicial.

Este artículo muestra cómo:

- crear una lista con viñetas con un símbolo personalizado
- crear una viñeta con imagen
- crear una lista multinivel estableciendo la profundidad del párrafo
- crear una lista numerada
- examinar y cambiar el formato de la lista en una presentación existente
- leer los marcadores y números reales de la lista junto al texto del párrafo

## **Crear una lista con viñetas**

Para crear una lista con viñetas, añada párrafos a un [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) y establezca [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) a [BulletType.Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/). Luego puede establecer [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getColor--) y [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) para controlar la apariencia de la viñeta.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    int bulletColor = Color.rgb(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las viñetas de símbolo](symbol_bullets.png)

## **Crear una lista numerada**

Use listas numeradas cuando el orden de los elementos sea importante. Establezca [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) a [BulletType.Numbered](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/). También puede elegir un formato de numeración con [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) o establecer [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) cuando la lista deba comenzar con un valor distinto de 1.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las viñetas numeradas](numbered_bullets.png)

## **Crear una viñeta con imagen**

Aspose.Slides permite reemplazar un símbolo de viñeta regular por una imagen. Las viñetas con imagen funcionan mejor con imágenes simples que siguen siendo legibles a un tamaño pequeño, como íconos o archivos PNG transparentes pequeños.

{{% alert color="info" title="Note" %}}
Idealmente, si planea reemplazar el símbolo de viñeta regular por una imagen, es mejor elegir un gráfico sencillo con fondo transparente. Estas imágenes funcionan bien como símbolos de viñeta personalizados.

Tenga en cuenta que la imagen se reducirá a un tamaño muy pequeño. Por esa razón, recomendamos encarecidamente seleccionar una imagen que siga siendo nítida y visualmente eficaz cuando se utilice como viñeta en una lista.
{{% /alert %}}

Para crear una viñeta con imagen, añada una imagen a [Presentation.getImages](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages--) y asigne el objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) devuelto a [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--). Establezca [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) a [BulletType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/) antes de asignar la imagen.

Supongamos que tenemos un "image.png":

![Una imagen para las viñetas](picture_for_bullets.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las viñetas con imagen](picture_bullets.png)

## **Crear una lista multinivel**

Utilice [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) para colocar los elementos de la lista en diferentes niveles. El nivel 0 es el nivel superior, el nivel 1 está anidado debajo de él, y así sucesivamente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La lista multinivel](multilevel_list.png)

## **Cambiar una lista existente**

Para cambiar el formato de la lista en una presentación existente, acceda al párrafo objetivo y actualice sus configuraciones [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--). Los mismos métodos usados para crear listas pueden usarse para examinar o modificar listas cargadas desde un archivo PPT, PPTX o ODP.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Leer valores reales de viñetas**

Al extraer contenido de una presentación, mantenga los marcadores de lista junto al texto del párrafo. Llame a [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) y acceda a [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) para obtener el formato de viñeta efectivo. Compruebe su [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getType--) antes de leer [getActualBulletValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--).

Para listas numeradas, distinga estos tres valores:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) determina el formato, como números arábigos seguidos de un punto o letras minúsculas seguidas de un punto.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) especifica el número inicial para un grupo de párrafos numerados.
- [getActualBulletValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) devuelve el marcador formateado para un párrafo concreto. Por ejemplo, el segundo elemento de una lista que comienza en 5 devuelve `6.`.

Conserve [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDepth--) con cada párrafo para mantener su nivel de anidación. El marcador real no codifica toda la jerarquía: un elemento anidado puede devolver `c.` en lugar de una etiqueta combinada como `6.c.`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Crear un marcador de imagen sin un archivo de imagen externo.
    SvgImage svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    IPPImage bulletImage = presentation.getImages().addImage(svg);

    class ListBuilder {
        void addParagraph(String text, short depth, byte type, short start, byte style) {
            Paragraph paragraph = new Paragraph();
            paragraph.setText(text);

            IParagraphFormat format = paragraph.getParagraphFormat();
            format.setDepth(depth);
            format.setMarginLeft(30 + depth * 40);
            format.setIndent(-28);
            format.setSpaceAfter(8);
            format.getDefaultPortionFormat().setFontHeight(22);
            format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
            format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
            format.getBullet().setType(type);
            format.getBullet().setBulletHardColor(NullableBool.True);
            format.getBullet().getColor().setColor(Color.BLACK);
            if (type == BulletType.Numbered) {
                format.getBullet().setNumberedBulletStyle(style);
                format.getBullet().setNumberedBulletStartWith(start);
            } else if (type == BulletType.Symbol) {
                format.getBullet().setChar('\u2022');
            } else if (type == BulletType.Picture) {
                format.getBullet().getPicture().setImage(bulletImage);
            }

            textFrame.getParagraphs().add(paragraph);
        }
    }

    ListBuilder list = new ListBuilder();
    list.addParagraph("First item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Second item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Next nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Deep item", (short) 2, BulletType.Numbered, (short) 4, NumberedBulletStyle.BulletRomanLCPeriod);
    list.addParagraph("Back to top level", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Symbol marker", (short) 0, BulletType.Symbol, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("No bullet", (short) 0, BulletType.None, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Picture marker", (short) 0, BulletType.Picture, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    IAutoShape loadedShape = (IAutoShape) loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Text | Depth | Type | Actual value");
    for (IParagraph paragraph : loadedShape.getTextFrame().getParagraphs()) {
        IBulletFormatEffectiveData bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        String marker;
        switch (bullet.getType()) {
            case BulletType.Numbered:
            case BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        String typeName = BulletType.getName(BulletType.class, bullet.getType());
        System.out.println(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

Los listados de origen se muestran a continuación.

![Listas que comienzan en 5, elementos anidados de letra y número romano, un marcador de símbolo, un párrafo sin viñeta y un marcador de imagen azul](actual_bullet_values.png)

El informe coincide con los marcadores mostrados en PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Para [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/), [getActualBulletValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) devuelve `null`, no una cadena vacía. Maneje estos tipos por separado: el primero no tiene marcador, mientras que el segundo requiere extraer la imagen de la viñeta por separado. No es posible reproducir una viñeta con imagen únicamente extrayendo un marcador de texto.

## **Preguntas frecuentes**

**¿Se pueden exportar las listas con viñetas y numeradas a PDF o imágenes?**

Sí. Aspose.Slides conserva el formato de la lista cuando el formato de destino admite el diseño de texto y las características de viñetas correspondientes.

**¿Puedo editar listas en presentaciones existentes?**

Sí. Cargue la presentación, acceda al párrafo objetivo, examine o actualice sus configuraciones [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) y guarde la presentación.

**¿Las listas pueden contener texto no latino?**

Sí. El texto de los elementos de la lista puede contener caracteres Unicode, por lo que puede crear listas en presentaciones multilingües. Asegúrese de que las fuentes usadas en la presentación soporten los caracteres que necesita.