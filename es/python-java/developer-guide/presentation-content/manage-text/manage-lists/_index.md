---
title: Administrar listas con viñetas y numeradas en presentaciones con Python vía Java
linktitle: Gestionar listas
type: docs
weight: 60
url: /es/python-java/manage-lists/
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
- Python
- Java
- Aspose.Slides
description: "Aprenda a crear y dar formato a listas con viñetas, viñetas con imagen, listas multinivel y listas numeradas en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Python vía Java."
---
## **Visión general**

Aspose.Slides for Python via Java le permite crear y formatear listas con viñetas y numeradas en presentaciones PowerPoint y OpenDocument. Un elemento de lista es un párrafo cuyas configuraciones de viñeta se controlan a través de su formato de párrafo.

Utilice el [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) método para acceder a la configuración de listas a nivel de párrafo. El punto de entrada principal es [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet), que devuelve un objeto [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/). Con este objeto, puede establecer el tipo de viñeta, símbolo, imagen, color, tamaño, estilo de numeración y número inicial.

Este artículo muestra cómo:

- crear una lista con viñetas usando un símbolo personalizado
- crear una viñeta con imagen
- crear una lista multinivel estableciendo la profundidad del párrafo
- crear una lista numerada
- inspeccionar y cambiar el formato de la lista en una presentación existente
- leer los marcadores y números reales de la lista junto al texto del párrafo

## **Crear una lista con viñetas**

Para crear una lista con viñetas, añada objetos [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) a un [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) y establezca [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) a [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol). Luego puede usar [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getColor) y [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) para controlar la apariencia de la viñeta.

El siguiente código Python muestra cómo crear una lista con viñetas en una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Los símbolos de viñetas](symbol_bullets.png)

## **Crear una lista numerada**

Utilice listas numeradas cuando el orden de los elementos sea importante. Establezca [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) a [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered). También puede elegir un formato de numeración con [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) o usar [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) cuando la lista debe comenzar con un valor distinto de 1.

El siguiente código Python muestra cómo crear una lista numerada en una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Las viñetas numeradas](numbered_bullets.png)

## **Crear una viñeta con imagen**

Aspose.Slides le permite reemplazar un símbolo de viñeta regular con una imagen. Las viñetas con imagen funcionan mejor con imágenes simples que siguen siendo legibles en un tamaño pequeño, como iconos o archivos PNG transparentes pequeños.

{{% alert color="info" title="Note" %}}
Si planea reemplazar un símbolo de viñeta regular con una imagen, elija un gráfico sencillo con fondo transparente. Estas imágenes funcionan bien como símbolos de viñeta personalizados.
{{% /alert %}}

Para crear una viñeta con imagen, añada una imagen a [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) y asigne el objeto de imagen devuelto a [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture). Establezca [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) a [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture) antes de asignar la imagen.

Supongamos que tenemos una imagen llamada "image.png":

![Una imagen para las viñetas](picture_for_bullets.png)

El siguiente código Python muestra cómo crear viñetas con imagen en una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Las viñetas con imagen](picture_bullets.png)

## **Crear una lista multinivel**

Utilice [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) para colocar los elementos de la lista en diferentes niveles. El nivel 0 es el nivel superior, el nivel 1 está anidado debajo de él, y así sucesivamente.

El siguiente código Python muestra cómo crear una lista con viñetas multinivel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![La lista multinivel](multilevel_list.png)

## **Cambiar una lista existente**

Para cambiar el formato de una lista en una presentación existente, acceda al párrafo objetivo y actualice sus configuraciones [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet). Las mismas propiedades usadas para crear listas pueden utilizarse para inspeccionar o modificar listas cargadas desde un archivo PPT, PPTX o ODP.

El siguiente código Python cambia el primer párrafo en un marco de texto para usar un estilo de lista numerada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Leer los valores reales de viñetas**

Al extraer el contenido de una presentación, mantenga los marcadores de lista junto al texto del párrafo. Llame a [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective) y acceda a `getBullet` para obtener el formato efectivo de la viñeta. Verifique su `getType` antes de leer `getActualBulletValue`.

Para listas numeradas, distinga estos tres valores:

- `getNumberedBulletStyle` determina el formato, como números arábigos seguidos de un punto o letras minúsculas seguidas de un punto.
- `getNumberedBulletStartWith` especifica el número inicial para un grupo de párrafos numerados.
- `getActualBulletValue` devuelve el marcador formateado para un párrafo concreto. Por ejemplo, el segundo elemento de una lista que comienza en 5 devuelve `6.`.

Conserve [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDepth) en cada párrafo para mantener su nivel de anidamiento. El marcador real no codifica la jerarquía completa: un elemento anidado puede devolver `c.` en lugar de una etiqueta combinada como `6.c.`.

El siguiente ejemplo autocontenido crea listas, las guarda en una presentación y vuelve a cargar la presentación para informar del texto, la profundidad, el tipo de viñeta y el valor real de cada párrafo. El pequeño marcador de imagen azul se crea a partir de SVG en línea.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import BulletType, FillType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, SvgImage
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Crear un marcador de imagen sin un archivo de imagen externo.
    svg = SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.getImages().addImage(svg)

    def add_paragraph(text, depth, bullet_type, start, style):
        paragraph = Paragraph()
        paragraph.setText(text)

        paragraph_format = paragraph.getParagraphFormat()
        paragraph_format.setDepth(depth)
        paragraph_format.setMarginLeft(30 + depth * 40)
        paragraph_format.setIndent(-28)
        paragraph_format.setSpaceAfter(8)
        paragraph_format.getDefaultPortionFormat().setFontHeight(22)
        paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        paragraph_format.getBullet().setType(bullet_type)
        paragraph_format.getBullet().setBulletHardColor(NullableBool.True_)
        paragraph_format.getBullet().getColor().setColor(Color.BLACK)
        if bullet_type == BulletType.Numbered:
            paragraph_format.getBullet().setNumberedBulletStyle(style)
            paragraph_format.getBullet().setNumberedBulletStartWith(start)
        elif bullet_type == BulletType.Symbol:
            paragraph_format.getBullet().setChar('\u2022')
        elif bullet_type == BulletType.Picture:
            paragraph_format.getBullet().getPicture().setImage(bullet_image)

        text_frame.getParagraphs().add(paragraph)

    add_paragraph("First item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Second item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod)
    add_paragraph("Back to top level", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Symbol marker", 0, BulletType.Symbol, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("No bullet", 0, BulletType.None_, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Picture marker", 0, BulletType.Picture, 1, NumberedBulletStyle.BulletArabicPeriod)
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

loaded_presentation = Presentation("actual_bullet_values.pptx")
try:
    loaded_shape = loaded_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    type_names = {
        BulletType.Numbered: "Numbered",
        BulletType.Symbol: "Symbol",
        BulletType.None_: "None",
        BulletType.Picture: "Picture",
    }
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.getTextFrame().getParagraphs():
        bullet = paragraph.getParagraphFormat().getEffective().getBullet()
        bullet_type = bullet.getType()
        if bullet_type in (BulletType.Numbered, BulletType.Symbol):
            marker = bullet.getActualBulletValue()
        elif bullet_type == BulletType.None_:
            marker = f"{bullet.getActualBulletValue()} (no bullet)"
        elif bullet_type == BulletType.Picture:
            marker = f"{bullet.getActualBulletValue()} (image required)"
        else:
            marker = "unsupported bullet type"
        type_name = type_names.get(bullet_type, "Unknown")
        print(f"{paragraph.getText()} | {paragraph.getParagraphFormat().getDepth()} | {type_name} | {marker}")
finally:
    loaded_presentation.dispose()
```

Las listas de origen se muestran a continuación.

![Listas que comienzan en 5, elementos anidados con letras y números romanos, un marcador de símbolo, un párrafo sin viñeta y un marcador de imagen azul](actual_bullet_values.png)

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
No bullet | 0 | None | None (no bullet)
Picture marker | 0 | Picture | None (image required)
```

Para [BulletType.None_ and BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/), `getActualBulletValue` devuelve `None` (Java `null`), no una cadena vacía. Maneje estos tipos por separado: el primero no tiene marcador, mientras que el segundo requiere extraer la imagen de la viñeta por separado. Una viñeta con imagen no puede reproducirse únicamente extrayendo un marcador de texto.

## **Preguntas frecuentes**

**¿Se pueden exportar listas con viñetas y numeradas a PDF o imágenes?**

Sí. Aspose.Slides conserva el formato de la lista cuando el formato de destino admite la disposición de texto correspondiente y las características de viñetas.

**¿Puedo editar listas en presentaciones existentes?**

Sí. Cargue la presentación, acceda al párrafo objetivo, inspeccione o actualice sus configuraciones [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) y guarde la presentación.

**¿Pueden las listas contener texto no latino?**

Sí. El texto de los elementos de la lista puede contener caracteres Unicode, por lo que puede crear listas en presentaciones multilingües. Asegúrese de que las fuentes usadas en la presentación admitan los caracteres que necesita.