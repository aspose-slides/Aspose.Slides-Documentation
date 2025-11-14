---
title: Administrar Tabla
type: docs
weight: 10
url: /es/python-net/manage-table/
keywords: "Tabla, crear tabla, acceder a tabla, relación de aspecto de tabla, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Crear y administrar tablas en presentaciones de PowerPoint en Python"

---

Una tabla en PowerPoint es una forma eficiente de mostrar y presentar información. La información en una cuadrícula de celdas (dispuestas en filas y columnas) es clara y fácil de entender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/), la clase [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/), la interfaz [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) y otros tipos para permitirte crear, actualizar y gestionar tablas en todo tipo de presentaciones.

## **Crear Tabla desde Cero**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Define un arreglo de `columnWidth`.
4. Define un arreglo de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) a la diapositiva a través del método `add_table(x, y, column_widths, row_heights)`.
6. Itera a través de cada [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combina las dos primeras celdas de la primera fila de la tabla.
8. Accede al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de un [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/).
9. Agrega texto al [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
10. Guarda la presentación modificada.

Este código Python te muestra cómo crear una tabla en una presentación:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancia una clase Presentation que representa un archivo PPTX
with slides.Presentation() as pres:
    # Accede a la primera diapositiva
    sld = pres.slides[0]

    # Define columnas con anchos y filas con alturas
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # Agrega una forma de tabla a la diapositiva
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Establece el formato del borde para cada celda
    for row in range(len(tbl.rows)):
        for cell in range(len(tbl.rows[row])):
            tbl.rows[row][cell].cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_top.width = 5

            tbl.rows[row][cell].cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            tbl.rows[row][cell].cell_format.border_bottom.width =5

            tbl.rows[row][cell].cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            tbl.rows[row][cell].cell_format.border_left.width = 5

            tbl.rows[row][cell].cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_right.width = 5
        

    # Combina las celdas 1 y 2 de la fila 1
    tbl.merge_cells(tbl.rows[0][0], tbl.rows[1][1], False)

    # Agrega texto a la celda combinada
    tbl.rows[0][0].text_frame.text = "Celdas Combinadas"

    # Guarda la presentación en el disco
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numeración en Tabla Estándar**

En una tabla estándar, la numeración de celdas es sencilla y comienza desde cero. La primera celda en una tabla se indexa como 0,0 (columna 0, fila 0).

Por ejemplo, las celdas en una tabla con 4 columnas y 4 filas están numeradas de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código Python te muestra cómo especificar la numeración para celdas en una tabla:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancia una clase Presentation que representa un archivo PPTX
with slides.Presentation() as pres:
    # Accede a la primera diapositiva
    sld = pres.slides[0]

    # Define columnas con anchos y filas con alturas
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Agrega una forma de tabla a la diapositiva
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Establece el formato del borde para cada celda
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # Guarda la presentación en el disco
    pres.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a Tabla Existente**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

2. Obtén una referencia a la diapositiva que contiene la tabla a través de su índice.

3. Crea un objeto [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) y configúralo como nulo.

4. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) hasta que se encuentre la tabla.

   Si sospechas que la diapositiva con la que estás tratando contiene una sola tabla, puedes simplemente verificar todas las formas que contiene. Cuando una forma se identifica como una tabla, puedes castear su tipo como un objeto [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Pero si la diapositiva que estás tratando contiene varias tablas, será mejor buscar la tabla que necesitas a través de su `alternative_text`.

5. Utiliza el objeto [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) para trabajar con la tabla. En el ejemplo a continuación, hemos agregado una nueva fila a la tabla.

6. Guarda la presentación modificada.

Este código Python te muestra cómo acceder y trabajar con una tabla existente:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancia una clase Presentation que representa un archivo PPTX
with slides.Presentation(path + "UpdateExistingTable.pptx") as pres:
    # Accede a la primera diapositiva
    sld = pres.slides[0]

    # Inicializa null TableEx
    tbl = None

    # Itera a través de las formas y establece una referencia a la tabla encontrada
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # Establece el texto para la primera columna de la segunda fila
    tbl.rows[0][1].text_frame.text = "Nuevo"

    # Guarda la presentación modificada en el disco
    pres.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Alinéar Texto en Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega un objeto [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) a la diapositiva.
4. Accede a un objeto [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) de la tabla.
5. Accede al [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).
6. Alínea el texto verticalmente.
7. Guarda la presentación modificada.

Este código Python te muestra cómo alinear el texto en una tabla:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crea una instancia de la clase Presentation
with slides.Presentation() as presentation:
    # Obtiene la primera diapositiva 
    slide = presentation.slides[0]

    # Define columnas con anchos y filas con alturas
    dblCols =  [120, 120, 120, 120] 
    dblRows =  [100, 100, 100, 100] 

    # Agrega la forma de tabla a la diapositiva
    tbl = slide.shapes.add_table(100, 50, dblCols, dblRows)
    tbl.rows[1][0].text_frame.text = "10"
    tbl.rows[2][0].text_frame.text = "20"
    tbl.rows[3][0].text_frame.text = "30"

    # Accede al marco de texto
    txtFrame = tbl.rows[0][0].text_frame

    # Crea el objeto Párrafo para el marco de texto
    paragraph = txtFrame.paragraphs[0]

    # Crea el objeto Porción para el párrafo
    portion = paragraph.portions[0]
    portion.text = "texto aquí"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Alínea el texto verticalmente
    cell = tbl.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Guarda la presentación en disco
    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Formato de Texto a Nivel de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Accede a un objeto [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) de la diapositiva.
4. Establece la `font_height` para el texto. 
5. Establece la `alignment` y `margin_right`. 
6. Establece el `text_vertical_type`.
7. Guarda la presentación modificada. 

Este código Python te muestra cómo aplicar tus opciones de formato preferidas al texto en una tabla:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crea una instancia de la clase Presentation
with slides.Presentation() as presentation:
    someTable = presentation.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Establece la altura de fuente de las celdas de la tabla
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.set_text_format(portionFormat)

    # Establece la alineación del texto de las celdas de la tabla y el margen derecho en una sola llamada
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.set_text_format(paragraphFormat)

    # Establece el tipo de texto vertical de las celdas de la tabla
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.set_text_format(textFrameFormat)


    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtener Propiedades de Estilo de Tabla**

Aspose.Slides te permite recuperar las propiedades de estilo para una tabla para que puedas usar esos detalles para otra tabla o en otro lugar. Este código Python te muestra cómo obtener las propiedades de estilo de un estilo predeterminado de tabla:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Bloquear Relación de Aspecto de Tabla**

La relación de aspecto de una forma geométrica es la proporción de sus tamaños en diferentes dimensiones. Aspose.Slides proporciona la propiedad `aspect_ratio_locked` para permitirte bloquear la configuración de relación de aspecto para tablas y otras formas.

Este código Python te muestra cómo bloquear la relación de aspecto para una tabla:

```c#
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])
    print("Bloquear relación de aspecto establecido: {0}".format(table.shape_lock.aspect_ratio_locked))

    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked

    print("Bloquear relación de aspecto establecido: {0}".format(table.shape_lock.aspect_ratio_locked))

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```