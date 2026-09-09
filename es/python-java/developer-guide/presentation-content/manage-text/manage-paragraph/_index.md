---
title: Administrar párrafos de texto de PowerPoint en Python mediante Java
linktitle: Administrar párrafo
type: docs
weight: 40
url: /es/python-java/manage-paragraph/
aliases:
  - /python-java/parrafo/
  - /python-java/fragmento/
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
- Python
- Java
- Aspose.Slides
description: "Aprenda a crear y formatear párrafos, fragmentos, viñetas, listas numeradas, sangrías, contenido HTML y imágenes de párrafos con Aspose.Slides para Python mediante Java."
---
## **Descripción general**

Aspose.Slides for Python via Java representa el texto como una jerarquía de marcos de texto, párrafos y fragmentos:

* [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) representa el contenedor de texto en una forma y proporciona acceso a su colección de párrafos.
* [Paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) representa un párrafo en un marco de texto y proporciona acceso a sus fragmentos y al formato a nivel de párrafo.
* [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/) representa una ejecución de texto dentro de un párrafo. Cada fragmento puede tener su propio texto y formato a nivel de carácter.

Un párrafo, por lo tanto, puede contener texto con diferentes fuentes, colores, tamaños y otros formatos mediante el uso de varios fragmentos.

## **Crear y formatear párrafos**

### **Crear párrafos con múltiples fragmentos**

Los siguientes pasos crean un marco de texto con tres párrafos, cada uno con tres fragmentos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Acceda a la diapositiva correspondiente mediante su índice.
3. Añada una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) de la forma.
5. Utilice el párrafo predeterminado y añada dos objetos [Paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) más al marco de texto.
6. Añada suficientes objetos [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/) para que cada párrafo contenga tres fragmentos. El párrafo predeterminado ya contiene un fragmento vacío.
7. Establezca el texto de cada fragmento.
8. Aplique formato a nivel de carácter mediante [Portion.getPortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#getPortionFormat).
9. Guarde la presentación modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Crear listas con viñetas y numeración**

### **Crear una lista con viñetas o numerada**

Las viñetas y la numeración facilitan la revisión de elementos relacionados. En Aspose.Slides, la configuración de la lista se define mediante [BulletFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/bulletformat/).

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Acceda a la diapositiva correspondiente mediante su índice.
3. Añada una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) a la diapositiva seleccionada.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) de la forma.
5. Elimine el párrafo predeterminado del marco de texto.
6. Cree un [Paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) para una viñeta de símbolo.
7. Establezca [BulletFormat.setType](https://reference.aspose.com/slides/es/python-java/aspose.slides/bulletformat/#setType) a [BulletType.Symbol](https://reference.aspose.com/slides/es/python-java/aspose.slides/bullettype/#Symbol) y especifique el carácter de la viñeta.
8. Defina el texto del párrafo, la sangría, el color de la viñeta y la altura de la viñeta.
9. Añada el párrafo al marco de texto.
10. Cree un segundo párrafo y establezca [BulletFormat.setType](https://reference.aspose.com/slides/es/python-java/aspose.slides/bulletformat/#setType) a [BulletType.Numbered](https://reference.aspose.com/slides/es/python-java/aspose.slides/bullettype/#Numbered).
11. Configure el estilo de la viñeta numerada y añada el párrafo al marco de texto.
12. Guarde la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Usar viñetas de imagen**

Las viñetas de imagen le permiten utilizar una imagen personalizada en lugar de un símbolo o número.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Acceda a la diapositiva correspondiente mediante su índice.
3. Añada una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) y acceda a su [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/).
4. Elimine el párrafo predeterminado del marco de texto.
5. Cargue la imagen de la viñeta y agréguela a la colección de imágenes de la presentación como un [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/).
6. Cree un [Paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) y establezca su texto.
7. Establezca [BulletFormat.setType](https://reference.aspose.com/slides/es/python-java/aspose.slides/bulletformat/#setType) a [BulletType.Picture](https://reference.aspose.com/slides/es/python-java/aspose.slides/bullettype/#Picture).
8. Asigne la imagen mediante [BulletFormat.getPicture](https://reference.aspose.com/slides/es/python-java/aspose.slides/bulletformat/#getPicture) y defina la altura de la viñeta.
9. Añada el párrafo al marco de texto.
10. Guarde la presentación modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **Crear una lista multinivel**

Establezca [ParagraphFormat.setDepth](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setDepth) para situar los párrafos en diferentes niveles de una lista. El nivel superior tiene una profundidad de `0`.

1. Cree una [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y acceda a una diapositiva.
2. Añada una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) y elimine el párrafo predeterminado de su marco de texto.
3. Cree cuatro párrafos y configure sus símbolos de viñeta.
4. Establezca sus valores de [ParagraphFormat.setDepth](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setDepth) a `0`, `1`, `2` y `3`.
5. Añada los párrafos al marco de texto y guarde la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Iniciar los ítems numerados con valores personalizados**

Utilice [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/es/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) para definir el número inicial que se muestra en un párrafo numerado.

1. Cree una [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y añada una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) a una diapositiva.
2. Elimine el párrafo predeterminado del marco de texto de la forma.
3. Cree tres párrafos numerados.
4. Establezca [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/es/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) a `2`, `3` y `7` para los párrafos correspondientes.
5. Añada los párrafos al marco de texto y guarde la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlar la disposición y propiedades de final de párrafo**

### **Establecer una sangría de primera línea**

Utilice [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setIndent) para controlar la sangría de la primera línea de un párrafo. Este método desplaza solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo desplaza la primera línea a la derecha, mientras que las líneas restantes permanecen alineadas con el cuerpo del párrafo.

Utilice [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setMarginLeft) cuando necesite mover todo el párrafo. Utilice [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setIndent) cuando solo necesite mover la primera línea.

El ejemplo siguiente crea varios párrafos y aplica diferentes valores de [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setIndent) para demostrar cómo la sangría de primera línea afecta la disposición del párrafo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) de la forma y elimine el párrafo predeterminado.
5. Cree varios párrafos y establezca diferentes valores de [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setIndent) para ellos.
6. Añada los párrafos al marco de texto.
7. Guarde la presentación modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![La sangría de la primera línea de los párrafos](first_line_indent.png)

### **Establecer una sangría francesa**

Una sangría francesa es una disposición en la que la primera línea comienza a la izquierda del resto de líneas. En Aspose.Slides, crea este efecto con [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setIndent). Pase un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setMarginLeft) define la posición izquierda del cuerpo del párrafo, y [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setIndent) define la posición de la primera línea respecto a ese margen. Para crear una sangría francesa, pase un valor positivo a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setMarginLeft) y un valor negativo a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setIndent).

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas envueltas deben alinearse bajo el cuerpo del párrafo y no bajo el primer carácter de la primera línea.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) rectangular a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) de la forma y elimine el párrafo predeterminado.
5. Cree párrafos y pase un valor positivo a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setMarginLeft) para cada párrafo.
6. Pase un valor negativo a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setIndent) para crear el efecto de sangría francesa.
7. Añada los párrafos al marco de texto.
8. Guarde la presentación modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![La sangría francesa de los párrafos](hanging_indent.png)

### **Establecer propiedades de ejecución al final del párrafo**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) controla el formato del signo de fin de párrafo. El siguiente ejemplo asigna un tamaño de fuente y una fuente latina al signo de fin del segundo párrafo:

1. Cargue una [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y acceda a una diapositiva.
2. Añada una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) y elimine su párrafo predeterminado.
3. Cree dos párrafos y añada fragmentos de texto a cada uno.
4. Cree un [PortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portionformat/) para el signo de fin del segundo párrafo.
5. Establezca [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setFontHeight) y [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setLatinFont).
6. Asigne el formato con [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) y guarde la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Importar y exportar contenido de párrafo**

### **Importar texto HTML en párrafos**

Utilice [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphcollection/#addFromHtml) para convertir marcado HTML en párrafos y fragmentos dentro de un marco de texto.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Acceda a una diapositiva y añada una [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/).
3. Acceda al [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) de la forma y elimine el párrafo predeterminado.
4. Lea el archivo HTML fuente.
5. Pase la cadena HTML a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. Guarde la presentación modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **Exportar texto de párrafo a HTML**

Utilice [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphcollection/#exportToHtml) para exportar un rango seleccionado de párrafos como HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargue la presentación deseada.
2. Acceda a la diapositiva y encuentre la [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) que contiene el texto.
3. Acceda al [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) de la forma.
4. Llame a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphcollection/#exportToHtml) indicando el índice del párrafo inicial y la cantidad de párrafos a exportar.
5. Escriba la cadena HTML devuelta en un archivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **Renderizar un párrafo como imagen**

[Paragraph.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) renderiza directamente un párrafo individual y devuelve un objeto de imagen. Guarde el resultado en un archivo o flujo con su método `save`. No es necesario renderizar la forma contenedora ni recortar manualmente un mapa de bits.

[Paragraph.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) puede devolver `None` si el párrafo no se encuentra en su colección padre, no tiene límites de renderizado válidos o no puede renderizarse. Compruebe el resultado antes de guardarlo y libere la imagen devuelta después de usarla.

#### **Renderizar un párrafo a escala predeterminada**

Supongamos que tenemos un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

El siguiente ejemplo renderiza el segundo párrafo en una forma de texto normal a escala predeterminada y guarda la imagen devuelta en formato PNG. El bloque `finally` garantiza que la imagen se libere correctamente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

El resultado:

![La imagen del párrafo](paragraph_to_image_output.png)

#### **Renderizar un párrafo en una celda de tabla con escalado**

Utilice la sobrecarga de [Paragraph.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) que acepta los parámetros `scale_x` y `scale_y` para establecer los factores de escala horizontal y vertical. El siguiente ejemplo crea una tabla, renderiza el párrafo en su primera celda al doble de su ancho y alto predeterminados, y guarda el resultado como una imagen PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

Un factor de escala de `1` mantiene ese eje en su tamaño de píxel predeterminado. Por ejemplo, `2` para ambos factores produce una imagen cuyo ancho y alto son aproximadamente el doble de las dimensiones predeterminadas, lo que genera cuatro veces más píxeles. Factores mayores suelen producir texto más nítido para ampliaciones o salidas de alta resolución, aunque también incrementan el uso de memoria y el tamaño del archivo. Factores menores que `1` generan imágenes más pequeñas con menos detalle. Use factores iguales para mantener la relación de aspecto del párrafo; factores diferentes en horizontal y vertical estiran la salida de forma independiente.

Renderizar una forma completa con [Shape.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) sigue siendo útil cuando la salida debe incluir el relleno, el borde u otro contexto visual de la forma. Para una imagen únicamente del párrafo, use [Paragraph.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/).

## **FAQ**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Establezca [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframeformat/#setWrapText) para desactivar el ajuste, de modo que las líneas no se rompan en los bordes del marco de texto.

**¿Cómo puedo obtener los límites exactos en diapositiva de un párrafo específico?**

Utilice [Paragraph.getRect](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/#getRect) para obtener el rectángulo delimitador del párrafo. [Portion.getRect](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#getRect) proporciona los límites de un fragmento individual.

**¿Dónde se controla la alineación del párrafo (izquierda, derecha, centrado o justificado)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraphformat/#setAlignment) es una configuración a nivel de párrafo y se aplica a todo el párrafo independientemente del formato de los fragmentos individuales.

**¿Puedo establecer el idioma de revisión para una parte de un párrafo?**

Sí. Establezca [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setLanguageId) para fragmentos individuales, de modo que un párrafo pueda contener texto en varios idiomas.