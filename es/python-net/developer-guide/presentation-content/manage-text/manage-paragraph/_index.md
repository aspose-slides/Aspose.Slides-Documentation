---
title: Administrar Párrafos de PowerPoint en Python
type: docs
weight: 40
url: /python-net/manage-paragraph/
keywords: "Agregar párrafo de PowerPoint, Administrar párrafos, Sangría de párrafo, Propiedades de párrafo, Texto HTML, Exportar texto de párrafo, Presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Crear y gestionar párrafos, texto, sangría y propiedades en presentaciones de PowerPoint en Python"
---

Aspose.Slides proporciona todas las interfaces y clases que necesita para trabajar con textos, párrafos y porciones de PowerPoint en Python.

* Aspose.Slides proporciona la interfaz [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) para permitirle agregar objetos que representan un párrafo. Un objeto `ITextFame` puede tener uno o múltiples párrafos (cada párrafo se crea a través de un retorno de carro).
* Aspose.Slides proporciona la interfaz [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) para permitirle agregar objetos que representan porciones. Un objeto `IParagraph` puede tener una o múltiples porciones (colección de objetos iPortions).
* Aspose.Slides proporciona la interfaz [IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) para permitirle agregar objetos que representan textos y sus propiedades de formato.

Un objeto `IParagraph` es capaz de manejar textos con diferentes propiedades de formato a través de sus objetos subyacentes `IPortion`.

## **Agregar Múltiples Párrafos que Contienen Múltiples Porciones**

Estos pasos le mostrarán cómo agregar un marco de texto que contenga 3 párrafos y cada párrafo contenga 3 porciones:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue una forma rectangular [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) a la diapositiva.
4. Obtenga el ITextFrame asociado con el [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).
5. Cree dos objetos [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) y agréguelo a la colección `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/).
6. Cree tres objetos [IPortion](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) para cada nuevo `IParagraph` (dos objetos Portion para el párrafo predeterminado) y agregue cada objeto `IPortion` a la colección IPortion de cada `IParagraph`.
7. Establezca algún texto para cada porción.
8. Aplique sus características de formato preferidas a cada porción utilizando las propiedades de formato expuestas por el objeto `IPortion`.
9. Guarde la presentación modificada.

Este código Python es una implementación de los pasos para agregar párrafos que contienen porciones: 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar una clase Presentation que representa un archivo PPTX
with slides.Presentation() as pres:
    # Accediendo a la primera diapositiva
    slide = pres.slides[0]

    # Agregando una forma AutoShape de tipo Rectángulo
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Accediendo al TextFrame de la forma AutoShape
    tf = ashp.text_frame

    # Creando Párrafos y Porciones con diferentes formatos de texto
    para0 = tf.paragraphs[0]
    port01 = slides.Portion()
    port02 = slides.Portion()
    para0.portions.add(port01)
    para0.portions.add(port02)

    para1 = slides.Paragraph()
    tf.paragraphs.add(para1)
    port10 = slides.Portion()
    port11 = slides.Portion()
    port12 = slides.Portion()
    para1.portions.add(port10)
    para1.portions.add(port11)
    para1.portions.add(port12)

    para2 = slides.Paragraph()
    tf.paragraphs.add(para2)
    port20 = slides.Portion()
    port21 = slides.Portion()
    port22 = slides.Portion()
    para2.portions.add(port20)
    para2.portions.add(port21)
    para2.portions.add(port22)

    for i in range(3):
        for j in range(3):
            tf.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                tf.paragraphs[i].portions[j].portion_format.font_bold = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                tf.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                tf.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                tf.paragraphs[i].portions[j].portion_format.font_italic = 1
                tf.paragraphs[i].portions[j].portion_format.font_height = 18

    # Escribir PPTX en disco
    pres.save("multiParaPort_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gestionar Viñetas de Párrafo**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos con viñetas siempre son más fáciles de leer y entender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) del autoshape. 
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
7. Establezca el `Type` de viñeta para el párrafo a `Symbol` y establezca el carácter de la viñeta.
8. Establezca el `Text` del párrafo.
9. Establezca la `Indent` del párrafo para la viñeta.
10. Establezca un color para la viñeta.
11. Establezca una altura para la viñeta.
12. Agregue el nuevo párrafo a la colección de párrafos del `TextFrame`.
13. Agregue el segundo párrafo y repita el proceso indicado en los pasos 7 a 13.
14. Guarde la presentación.

Este código Python le muestra cómo agregar una viñeta a un párrafo: 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Creando una instancia de presentación
with slides.Presentation() as pres:
    # Accediendo a la primera diapositiva
    slide = pres.slides[0]

    # Agregando y accediendo a AutoShape
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accediendo al marco de texto de la forma AutoShape creada
    txtFrm = aShp.text_frame

    # Eliminando el párrafo predeterminado existente
    txtFrm.paragraphs.remove_at(0)

    # Creando un párrafo
    para = slides.Paragraph()

    # Estableciendo el estilo de la viñeta del párrafo y el símbolo
    para.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para.paragraph_format.bullet.char = chr(8226)

    # Estableciendo el texto del párrafo
    para.text = "Bienvenido a Aspose.Slides"

    # Estableciendo la sangría de la viñeta
    para.paragraph_format.indent = 25

    # Estableciendo el color de la viñeta
    para.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para.paragraph_format.bullet.color.color = draw.Color.black
    para.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Estableciendo la altura de la viñeta
    para.paragraph_format.bullet.height = 100

    # Agregando el párrafo al marco de texto
    txtFrm.paragraphs.add(para)

    # Creando el segundo párrafo
    para2 = slides.Paragraph()

    # Estableciendo el tipo y estilo de viñeta del párrafo
    para2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    para2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Agregando el texto del párrafo
    para2.text = "Esta es una viñeta numerada"

    # Estableciendo la sangría de la viñeta
    para2.paragraph_format.indent = 25

    para2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    para2.paragraph_format.bullet.color.color = draw.Color.black
    para2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Estableciendo la altura de la viñeta
    para2.paragraph_format.bullet.height = 100

    # Agregando el párrafo al marco de texto
    txtFrm.paragraphs.add(para2)


    # Escribiendo la presentación como un archivo PPTX
    pres.save("bullet_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Gestionar Viñetas de Imagen**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Los párrafos de imagen son fáciles de leer y entender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) del autoshape. 
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo utilizando la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
7. Cargue la imagen en [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/).
8. Establezca el tipo de viñeta en [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) y establezca la imagen.
9. Establezca el `Text` del párrafo.
10. Establezca la `Indent` del párrafo para la viñeta.
11. Establezca un color para la viñeta.
12. Establezca una altura para la viñeta.
13. Agregue el nuevo párrafo a la colección de párrafos del `TextFrame`.
14. Agregue el segundo párrafo y repita el proceso basado en los pasos anteriores.
15. Guarde la presentación modificada.

Este código Python le muestra cómo agregar y gestionar viñetas de imagen: 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Accediendo a la primera diapositiva
    slide = presentation.slides[0]

    # Instanciar la imagen para las viñetas
    image = draw.Bitmap(path + "bullets.png")
    ippxImage = presentation.images.add_image(image)

    # Agregando y accediendo a AutoShape
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accediendo al marco de texto de la forma AutoShape creada
    textFrame = autoShape.text_frame

    # Eliminando el párrafo predeterminado existente
    textFrame.paragraphs.remove_at(0)

    # Creando un nuevo párrafo
    paragraph = slides.Paragraph()
    paragraph.text = "Bienvenido a Aspose.Slides"

    # Estableciendo el estilo de la viñeta del párrafo y la imagen
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = ippxImage

    # Estableciendo la altura de la viñeta
    paragraph.paragraph_format.bullet.height = 100

    # Agregando el párrafo al marco de texto
    textFrame.paragraphs.add(paragraph)

    # Escribiendo la presentación como un archivo PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", slides.export.SaveFormat.PPTX)
    # Escribiendo la presentación como un archivo PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", slides.export.SaveFormat.PPT)
```


## **Gestionar Viñetas de Múltiples Niveles**

Las listas con viñetas le ayudan a organizar y presentar información de manera rápida y eficiente. Las viñetas de múltiples niveles son fáciles de leer y entender.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) en la nueva diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) del autoshape. 
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y establezca la profundidad en 0.
7. Cree la segunda instancia de párrafo a través de la clase `Paragraph` y establezca la profundidad en 1.
8. Cree la tercera instancia de párrafo a través de la clase `Paragraph` y establezca la profundidad en 2.
9. Cree la cuarta instancia de párrafo a través de la clase `Paragraph` y establezca la profundidad en 3.
10. Agregue los nuevos párrafos a la colección de párrafos del `TextFrame`.
11. Guarde la presentación modificada.

Este código Python le muestra cómo agregar y gestionar viñetas de múltiples niveles: 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Creando una instancia de presentación
with slides.Presentation() as pres:
    # Accediendo a la primera diapositiva
    slide = pres.slides[0]
    
    # Agregando y accediendo a AutoShape
    aShp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accediendo al marco de texto de la forma AutoShape creada
    text = aShp.add_text_frame("")
    
    # Limpiando el párrafo predeterminado
    text.paragraphs.clear()

    # Agregando el primer párrafo
    para1 = slides.Paragraph()
    para1.text = "Contenido"
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Estableciendo el nivel de la viñeta
    para1.paragraph_format.depth = 0

    # Agregando el segundo párrafo
    para2 = slides.Paragraph()
    para2.text = "Segundo Nivel"
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = '-'
    para2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Estableciendo el nivel de la viñeta
    para2.paragraph_format.depth = 1

    # Agregando el tercer párrafo
    para3 = slides.Paragraph()
    para3.text = "Tercer Nivel"
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Estableciendo el nivel de la viñeta
    para3.paragraph_format.depth = 2

    # Agregando el cuarto párrafo
    para4 = slides.Paragraph()
    para4.text = "Cuarto Nivel"
    para4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para4.paragraph_format.bullet.char = '-'
    para4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    para4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Estableciendo el nivel de la viñeta
    para4.paragraph_format.depth = 3

    # Agregando los párrafos a la colección
    text.paragraphs.add(para1)
    text.paragraphs.add(para2)
    text.paragraphs.add(para3)
    text.paragraphs.add(para4)

    # Escribiendo la presentación como un archivo PPTX
    pres.save("MultilevelBullet.pptx", slides.export.SaveFormat.PPTX)
```


## **Gestionar Párrafo con Lista Numerada Personalizada**

La interfaz [IBulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformat/#ibulletformat/) proporciona la propiedad `NumberedBulletStartWith` y otras que le permiten gestionar párrafos con numeración o formato personalizado. 

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la diapositiva que contiene el párrafo.
3. Agregue un [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) a la diapositiva.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) del autoshape. 
5. Elimine el párrafo predeterminado en el `TextFrame`.
6. Cree la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) y establezca `NumberedBulletStartWith` en 2.
7. Cree la segunda instancia de párrafo a través de la clase `Paragraph` y establezca `NumberedBulletStartWith` en 3.
8. Cree la tercera instancia de párrafo a través de la clase `Paragraph` y establezca `NumberedBulletStartWith` en 7.
9. Agregue los nuevos párrafos a la colección de párrafos del `TextFrame`.
10. Guarde la presentación modificada.

Este código Python le muestra cómo agregar y gestionar párrafos con numeración o formato personalizado: 

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Accediendo al marco de texto de la forma AutoShape creada
    textFrame = shape.text_frame

    # Eliminando el párrafo predeterminado existente
    textFrame.paragraphs.remove_at(0)

    # Primer lista
    paragraph1 = slides.Paragraph()
    paragraph1.text = "viñeta 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.text = "viñeta 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    textFrame.paragraphs.add(paragraph2)


    paragraph5 = slides.Paragraph()
    paragraph5.text = "viñeta 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    textFrame.paragraphs.add(paragraph5)

    presentation.save("SetCustomBulletsNumber-slides.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer Sangría de Párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceda a la referencia de la diapositiva relevante a través de su índice.
1. Agregue una forma rectangular [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) a la diapositiva.
1. Agregue un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) con tres párrafos a la forma rectangular autoshape.
1. Oculte las líneas del rectángulo.
1. Establezca la sangría para cada [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) a través de su propiedad BulletOffset.
1. Escriba la presentación modificada como un archivo PPT.

Este código Python le muestra cómo establecer una sangría de párrafo: 

```python
import aspose.slides as slides

# Instanciar la clase Presentation
with slides.Presentation() as pres:

    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar una forma rectangular
    rect = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # Agregar un marco de texto a la forma rectangular
    tf = rect.add_text_frame("Esta es la primera línea \rEsta es la segunda línea \rEsta es la tercera línea")

    # Ajustar el texto para que se ajuste a la forma
    tf.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Ocultar las líneas del rectángulo
    rect.line_format.fill_format.fill_type = slides.FillType.SOLID

    # Obtener el primer párrafo en el marco de texto y establecer su sangría
    para1 = tf.paragraphs[0]
    # Estableciendo el estilo de la viñeta del párrafo y el símbolo
    para1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para1.paragraph_format.bullet.char = chr(8226)
    para1.paragraph_format.alignment = slides.TextAlignment.LEFT

    para1.paragraph_format.depth = 2
    para1.paragraph_format.indent = 30

    # Obtener el segundo párrafo en el marco de texto y establecer su sangría
    para2 = tf.paragraphs[1]
    para2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para2.paragraph_format.bullet.char = chr(8226)
    para2.paragraph_format.alignment = slides.TextAlignment.LEFT
    para2.paragraph_format.depth = 2
    para2.paragraph_format.indent = 40

    # Obtener el tercer párrafo en el marco de texto y establecer su sangría
    para3 = tf.paragraphs[2]
    para3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    para3.paragraph_format.bullet.char = chr(8226)
    para3.paragraph_format.alignment = slides.TextAlignment.LEFT
    para3.paragraph_format.depth = 2
    para3.paragraph_format.indent = 50

    # Escribir la presentación en disco
    pres.save("InOutDent_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Sangría Colgante para Párrafo**

Este código Python le muestra cómo establecer la sangría colgante para un párrafo:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    auto_shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    para1 = slides.Paragraph()
    para1.text = "Ejemplo"
    para2 = slides.Paragraph()
    para2.text = "Establecer Sangría Colgante para Párrafo"
    para3 = slides.Paragraph()
    para3.text = "Este código C# muestra cómo establecer la sangría colgante para un párrafo: "

    para2.paragraph_format.margin_left = 10
    para3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(para1)
    paragraphs.add(para2)
    paragraphs.add(para3)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestionar Propiedades del Final del Párrafo para Párrafo**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva que contiene el párrafo a través de su posición.
1. Agregue una forma rectangular [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) a la diapositiva.
1. Agregue un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) con dos párrafos a la forma rectangular.
1. Establezca la `FontHeight` y el tipo de fuente para los párrafos.
1. Establezca las propiedades de Fin para los párrafos.
1. Escriba la presentación modificada como un archivo PPTX.

Este código Python le muestra cómo establecer las propiedades de Fin para los párrafos en PowerPoint: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
	shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	para1 = slides.Paragraph()
	para1.portions.add(slides.Portion("Texto de ejemplo"))

	para2 = slides.Paragraph()
	para2.portions.add(slides.Portion("Texto de ejemplo 2"))
	endParagraphPortionFormat = slides.PortionFormat()
	endParagraphPortionFormat.font_height = 48
	endParagraphPortionFormat.latin_font = slides.FontData("Times New Roman")
	para2.end_paragraph_portion_format = endParagraphPortionFormat

	shape.text_frame.paragraphs.add(para1)
	shape.text_frame.paragraphs.add(para2)

	pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```


## **Importar Texto HTML en Párrafos**

Aspose.Slides proporciona un soporte mejorado para importar texto HTML en párrafos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Agregue un [autoshape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) a la diapositiva.
4. Agregue y acceda al `autoshape` [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/).
5. Elimine el párrafo predeterminado en el `ITextFrame`.
6. Lea el archivo HTML fuente en un TextReader.
7. Cree la primera instancia de párrafo a través de la clase [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) .
8. Agregue el contenido del archivo HTML en el TextReader leído a la [ParagraphCollection](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/) del marco de texto.
9. Guarde la presentación modificada.

Este código Python es una implementación de los pasos para importar textos HTML en párrafos: 

```python
import aspose.slides as slides

# Crear una instancia de presentación vacía
with slides.Presentation() as pres:
    # Accediendo a la primera diapositiva predeterminada de la presentación
    slide = pres.slides[0]

    # Agregando el AutoShape para acomodar el contenido HTML
    ashape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, pres.slide_size.size.width - 20, pres.slide_size.size.height - 10)

    ashape.fill_format.fill_type = slides.FillType.NO_FILL

    # Agregando un marco de texto a la forma
    ashape.add_text_frame("")

    # Limpiando todos los párrafos en el marco de texto agregado
    ashape.text_frame.paragraphs.clear()

    # Cargando el archivo HTML usando el lector de flujo
    with open(path + "file.html", "rt") as tr:
        # Agregando texto del flujo HTML en el marco de texto
        ashape.text_frame.paragraphs.add_from_html(tr.read())

    # Guardar la presentación
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Exportar Texto de Párrafos a HTML**

Aspose.Slides proporciona un soporte mejorado para exportar textos (contenidos en párrafos) a HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargue la presentación deseada.
2. Acceda a la referencia de la diapositiva relevante a través de su índice.
3. Acceda a la forma que contiene el texto que se exportará a HTML.
4. Acceda al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forma.
5. Cree una instancia de `StreamWriter` y agregue el nuevo archivo HTML.
6. Proporcione un índice inicial a StreamWriter y exporte los párrafos que prefiera.

Este código Python le muestra cómo exportar los textos de los párrafos de PowerPoint a HTML:

```python
import aspose.slides as slides

# Cargar el archivo de presentación
with slides.Presentation(path + "ExportingHTMLText.pptx") as pres:
    # Accediendo a la primera diapositiva predeterminada de la presentación
    slide = pres.slides[0]

    # Índice deseado
    index = 0

    # Accediendo a la forma agregada
    ashape = slide.shapes[index]

    with open("output_out.html", "w") as sw:
        # Escribiendo los datos de los párrafos en HTML proporcionando el índice de inicio del párrafo, el total de párrafos a copiar
        sw.write(ashape.text_frame.paragraphs.export_to_html(0, ashape.text_frame.paragraphs.count, None))
```