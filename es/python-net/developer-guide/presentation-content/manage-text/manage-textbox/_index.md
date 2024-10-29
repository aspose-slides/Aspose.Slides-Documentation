---
title: Gestionar TextBox
type: docs
weight: 20
url: /es/python-net/manage-textbox/
keywords: "Textbox, Marco de texto, Añadir textbox, Textbox con hiperenlace, Python, Aspose.Slides para Python a través de .NET"
description: "Añadir un textbox o marco de texto a presentaciones de PowerPoint en Python o .NET"
---

Los textos en las diapositivas generalmente existen en cuadros de texto o formas. Por lo tanto, para agregar un texto a una diapositiva, debes añadir un cuadro de texto y luego poner algo de texto dentro del textbox. Aspose.Slides para Python a través de .NET proporciona la interfaz [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) que te permite agregar una forma que contenga algo de texto.

{{% alert title="Info" color="info" %}}

Aspose.Slides también proporciona la interfaz [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) que te permite agregar formas a las diapositivas. Sin embargo, no todas las formas añadidas a través de la interfaz `IShape` pueden contener texto. Pero las formas añadidas a través de la interfaz [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) pueden contener texto. 

{{% /alert %}}

{{% alert title="Nota" color="warning" %}} 

Por lo tanto, cuando trabajes con una forma a la que deseas agregar texto, puede que quieras verificar y confirmar que se haya convertido a través de la interfaz `IAutoShape`. Solo entonces podrás trabajar con [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/), que es una propiedad de `IAutoShape`. Consulta la sección [Actualizar Texto](https://docs.aspose.com/slides/python-net/manage-textbox/#update-text) en esta página. 

{{% /alert %}}

## **Crear Cuadro de Texto en la Diapositiva**

Para crear un textbox en una diapositiva, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Obtén una referencia para la primera diapositiva en la presentación recién creada. 
3. Agrega un objeto [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) con [ShapeType](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) establecido como `RECTANGLE` en una posición especificada en la diapositiva y obtén la referencia para el objeto `IAutoShape` recién añadido. 
4. Agrega una propiedad `text_frame` al objeto `IAutoShape` que contendrá un texto. En el ejemplo a continuación, añadimos este texto: *Aspose TextBox*
5. Finalmente, escribe el archivo PPTX a través del objeto `Presentation`. 

Este código en Python—una implementación de los pasos anteriores—te muestra cómo agregar texto a una diapositiva:

```py
import aspose.slides as slides

# Instancia PresentationEx
with slides.Presentation() as pres:

    # Obtiene la primera diapositiva en la presentación
    sld = pres.slides[0]

    # Añade una AutoShape con tipo establecido como Rectángulo
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Añade TextFrame al Rectángulo
    ashp.add_text_frame(" ")

    # Accede al marco de texto
    txtFrame = ashp.text_frame

    # Crea el objeto Paragraph para el marco de texto
    para = txtFrame.paragraphs[0]

    # Crea un objeto Portion para el párrafo
    portion = para.portions[0]

    # Establece el Texto
    portion.text = "Aspose TextBox"

    # Guarda la presentación en disco
    pres.save("TextBox_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Verificar Forma de Cuadro de Texto**

Aspose.Slides proporciona la propiedad `is_text_box` (de la clase [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)) que te permite examinar formas y encontrar cuadros de texto.

![Cuadro de texto y forma](istextbox.png)

Este código en Python te muestra cómo verificar si una forma fue creada como un cuadro de texto: xxx

```python
from aspose.slides import Presentation, AutoShape

with Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if (type(shape) is AutoShape):
                print("la forma es un cuadro de texto" if shape.is_text_box else "la forma no es un cuadro de texto")
```

## **Añadir Columna en Cuadro de Texto**

Aspose.Slides proporciona las propiedades [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) y [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) y la clase [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) que te permiten añadir columnas a los cuadros de texto. Puedes especificar el número de columnas en un cuadro de texto y establecer la cantidad de espaciado en puntos entre las columnas. 

Este código en Python demuestra la operación descrita: 

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obtiene la primera diapositiva en la presentación
    slide = presentation.slides[0]

    # Añade una AutoShape con tipo establecido como Rectángulo
    aShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

    # Añade un TextFrame al Rectángulo
    aShape.add_text_frame("Todas estas columnas están limitadas a estar dentro de un único contenedor de texto -- " +
    "puedes añadir o eliminar texto y el nuevo o restante texto se ajusta automáticamente " +
    "para fluir dentro del contenedor. No puedes tener texto fluyendo de un contenedor " +
    "a otro, ya que las opciones de columnas de PowerPoint para texto son limitadas.")

    # Obtiene el formato de texto de TextFrame
    format = aShape.text_frame.text_frame_format

    # Especifica el número de columnas en TextFrame
    format.column_count = 3

    # Especifica el espaciado entre columnas
    format.column_spacing = 10

    # Guarda la presentación
    presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir Columna en Marco de Texto**
Aspose.Slides para Python a través de .NET proporciona la propiedad [ColumnCount](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) (de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/)) que te permite añadir columnas en marcos de texto. A través de esta propiedad, puedes especificar tu número preferido de columnas en un marco de texto. 

Este código en Python te muestra cómo añadir una columna dentro de un marco de texto:

```py
import aspose.slides as slides

outPptxFileName = "ColumnsTest.pptx"
with slides.Presentation() as pres:
    shape1 = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)
    format = shape1.text_frame.text_frame_format

    format.column_count = 2
    shape1.text_frame.text = """Todas estas columnas están forzadas a permanecer dentro de un único contenedor de texto -- 
        puedes añadir o eliminar texto - y el nuevo o restante texto se ajusta automáticamente 
        para permanecer dentro del contenedor. No puedes tener texto desbordándose de un contenedor 
        a otro, ya que las opciones de columnas de PowerPoint para texto son limitadas!"""
    
    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_spacing = 20
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_count = 3
    format.column_spacing = 15
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)
```

## **Actualizar Texto**

Aspose.Slides te permite cambiar o actualizar el texto contenido en un cuadro de texto o todos los textos contenidos en una presentación. 

Este código en Python demuestra una operación donde todos los textos en una presentación son actualizados o cambiados:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Guarda la presentación modificada
    pres.save("text-changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Añadir Cuadro de Texto con Hiperenlace** 

Puedes insertar un enlace dentro de un cuadro de texto. Cuando se hace clic en el cuadro de texto, los usuarios son dirigidos a abrir el enlace. 

Para añadir un cuadro de texto que contenga un enlace, sigue estos pasos:

1. Crea una instancia de la clase `Presentation`. 
2. Obtén una referencia para la primera diapositiva en la presentación recién creada. 
3. Añade un objeto `AutoShape` con `ShapeType` establecido como `RECTANGLE` en una posición especificada en la diapositiva y obtén la referencia del objeto AutoShape recién añadido.
4. Añade un `text_frame` al objeto `AutoShape` que contenga *Aspose TextBox* como su texto predeterminado. 
5. Instancia la clase `hyperlink_manager`. 
6. Asigna el objeto `hyperlink_manager` a la propiedad [HyperlinkClick](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) asociada con tu porción preferida del `TextFrame`. 
7. Finalmente, escribe el archivo PPTX a través del objeto `Presentation`. 

Este código en Python—una implementación de los pasos anteriores—te muestra cómo añadir un cuadro de texto con un hiperenlace a una diapositiva:

```py
import aspose.slides as slides

# Instancia una clase Presentation que representa un PPTX
with slides.Presentation() as pptxPresentation:
    # Obtiene la primera diapositiva en la presentación
    slide = pptxPresentation.slides[0]

    # Añade un objeto AutoShape con tipo establecido como Rectángulo
    pptxShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    # Accede a la propiedad ITextFrame asociada con el AutoShape
    pptxShape.add_text_frame("")

    textFrame = pptxShape.text_frame

    # Añade algo de texto al marco
    textFrame.paragraphs[0].portions[0].text = "Aspose.Slides"

    # Establece el hiperenlace para el texto de la porción
    hm = textFrame.paragraphs[0].portions[0].portion_format.hyperlink_manager
    hm.set_external_hyperlink_click("http://www.aspose.com")
    # Guarda la presentación PPTX
    pptxPresentation.save("hLinkPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```