---
title: Tabla
type: docs
weight: 120
url: /es/python-net/examples/elements/table/
keywords:
- tabla
- añadir tabla
- acceder a la tabla
- eliminar tabla
- combinar celdas
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Crear y dar formato a tablas en Python con Aspose.Slides: insertar datos, combinar celdas, diseñar bordes, alinear contenido e importar/exportar para PPT, PPTX y ODP."
---
Ejemplos para agregar tablas, acceder a ellas, eliminarlas y combinar celdas usando **Aspose.Slides for Python via .NET**.

## **Añadir una tabla**

Crear una tabla simple con dos filas y dos columnas.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Definir anchos de columna y alturas de fila.
        widths = [80, 80]
        heights = [30, 30]

        # Añadir una forma de tabla a la diapositiva.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a una tabla**

Obtener la primera forma de tabla en la diapositiva.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Acceder a la primera tabla en la diapositiva.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Eliminar una tabla**

Eliminar una tabla de una diapositiva.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es una tabla.
        table = slide.shapes[0]

        # Eliminar la tabla de la diapositiva.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Combinar celdas de tabla**

Combinar celdas adyacentes de una tabla en una sola celda.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es una tabla.
        table = slide.shapes[0]

        # Combinar celdas.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```