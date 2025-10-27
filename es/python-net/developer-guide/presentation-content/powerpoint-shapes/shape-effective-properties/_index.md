---
title: Obtener propiedades efectivas de forma de presentaciones con Python
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/python-net/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- conjunto de luces
- forma biselada
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para Python mediante .NET calcula y aplica propiedades efectivas de forma para una renderización precisa de PowerPoint y OpenDocument."
---

## **Resumen**

En este tema, aprenderá los conceptos de propiedades **efectivas** y **locales**. Cuando los valores se establecen directamente en los siguientes niveles:

1. En las propiedades de la porción de texto en la diapositiva.  
2. En el estilo de texto de la forma prototipo en la diapositiva de diseño o maestra (si el marco de texto tiene uno).  
3. En la configuración global de texto de la presentación.

esos valores se denominan valores **locales**. En cualquier nivel, los valores **locales** pueden definirse u omitirse. Cuando la aplicación necesita determinar cómo debe aparecer la porción de texto, utiliza los valores **efectivos**. Puede obtener los valores efectivos llamando al método `get_effective` del formato local.

El siguiente ejemplo muestra cómo obtener los valores efectivos para un formato de marco de texto y un formato de porción de texto.

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **Obtener propiedades efectivas de la cámara**

Aspose.Slides para Python mediante .NET le permite recuperar las propiedades efectivas de la cámara. La clase [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) representa un objeto inmutable que contiene estas propiedades. Una instancia de [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), que proporciona los valores efectivos para la clase [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

El siguiente ejemplo muestra cómo obtener las propiedades efectivas de la cámara:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Propiedades efectivas de la cámara =")
	print("Tipo:", str(three_d_effective_data.camera.camera_type))
	print("Ángulo de visión:", str(three_d_effective_data.camera.field_of_view_angle))
	print("Zoom:", str(three_d_effective_data.camera.zoom))
```

## **Obtener propiedades efectivas del conjunto de luces**

Aspose.Slides para Python mediante .NET le permite recuperar las propiedades efectivas de un conjunto de luces. La clase [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) representa un objeto inmutable que contiene estas propiedades. Una instancia de [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), que proporciona los valores efectivos para la clase [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

El siguiente ejemplo muestra cómo obtener las propiedades efectivas del conjunto de luces:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Propiedades efectivas del conjunto de luces =")
	print("Tipo:", str(three_d_effective_data.light_rig.light_type))
	print("Dirección:", str(three_d_effective_data.light_rig.direction))
```

## **Obtener propiedades efectivas del bisel de forma**

Aspose.Slides para Python mediante .NET le permite recuperar las propiedades efectivas del bisel de una forma. La clase [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) representa un objeto inmutable que contiene las propiedades de relieve (bisel) de una forma. Una instancia de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) se expone a través de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), que proporciona los valores efectivos para la clase [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

El siguiente ejemplo muestra cómo obtener las propiedades efectivas del bisel de una forma:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Propiedades efectivas del relieve de la cara superior de la forma =")
	print("Tipo:", str(three_d_effective_data.bevel_top.bevel_type))
	print("Anchura:", str(three_d_effective_data.bevel_top.width))
	print("Altura:", str(three_d_effective_data.bevel_top.height))
```

## **Obtener propiedades efectivas del marco de texto**

Con Aspose.Slides para Python mediante .NET, puede recuperar las propiedades efectivas de un marco de texto. La clase [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) contiene las propiedades efectivas de formato del marco de texto.

El siguiente ejemplo muestra cómo obtener las propiedades efectivas de formato del marco de texto:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
	shape = presentation.slides[0].shapes[0]

	text_frame_format_effective_data = shape.text_frame.text_frame_format.get_effective()

	print("Tipo de anclaje:", str(text_frame_format_effective_data.anchoring_type))
	print("Tipo de ajuste automático:", str(text_frame_format_effective_data.autofit_type))
	print("Tipo de texto vertical:", str(text_frame_format_effective_data.text_vertical_type))
	print("Márgenes")
	print("   Izquierda:", str(text_frame_format_effective_data.margin_left))
	print("   Superior:", str(text_frame_format_effective_data.margin_top))
	print("   Derecha:", str(text_frame_format_effective_data.margin_right))
	print("   Inferior:", str(text_frame_format_effective_data.margin_bottom))
```

## **Obtener propiedades efectivas del estilo de texto**

Con Aspose.Slides para Python mediante .NET, puede recuperar las propiedades efectivas de un estilo de texto. La clase [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) contiene las propiedades efectivas del estilo de texto.

El siguiente ejemplo muestra cómo obtener las propiedades efectivas del estilo de texto:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    effective_text_style = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effective_text_style.get_level(i)
        print(f"= Formato de párrafo efectivo para el nivel de estilo #{str(i)} =")

        print("Profundidad:", str(effectiveStyleLevel.depth))
        print("Sangría:", str(effectiveStyleLevel.indent))
        print("Alineación:", str(effectiveStyleLevel.alignment))
        print("Alineación de fuente:", str(effectiveStyleLevel.font_alignment))
```

## **Obtener altura de fuente efectiva**

Con Aspose.Slides para Python mediante .NET, puede recuperar la altura de fuente efectiva. El ejemplo a continuación demuestra cómo cambia la altura de fuente efectiva de una porción de texto al establecer valores locales de altura de fuente en diferentes niveles de la estructura de la presentación.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)

    shape.add_text_frame("")
    paragraph = shape.text_frame.paragraphs[0]

    portion0 = slides.Portion("Sample text with first portion")
    portion1 = slides.Portion(" and second portion.")

    paragraph.portions.add(portion0)
    paragraph.portions.add(portion1)

    print("Altura de fuente efectiva justo después de la creación:")
    print("Porción #0:", portion0.portion_format.get_effective().font_height)
    print("Porción #1:", portion1.portion_format.get_effective().font_height)

    presentation.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Altura de fuente efectiva después de establecer la altura de fuente predeterminada de toda la presentación:")
    print("Porción #0:", portion0.portion_format.get_effective().font_height)
    print("Porción #1:", portion1.portion_format.get_effective().font_height)

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Altura de fuente efectiva después de establecer la altura de fuente predeterminada del párrafo:")
    print("Porción #0:", portion0.portion_format.get_effective().font_height)
    print("Porción #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[0].portion_format.font_height = 55

    print("Altura de fuente efectiva después de establecer la altura de fuente de la porción #0:")
    print("Porción #0:", portion0.portion_format.get_effective().font_height)
    print("Porción #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[1].portion_format.font_height = 18

    print("Altura de fuente efectiva después de establecer la altura de fuente de la porción #1:")
    print("Porción #0:", portion0.portion_format.get_effective().font_height)
    print("Porción #1:", portion1.portion_format.get_effective().font_height)

    presentation.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```

## **Obtener formato de relleno efectivo de tabla**

Con Aspose.Slides para Python mediante .NET, puede recuperar el formato de relleno efectivo para diferentes partes lógicas de una tabla. La clase [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) contiene las propiedades efectivas de formato de relleno. Tenga en cuenta que el formato de celda siempre tiene mayor prioridad que el formato de fila, una fila tiene mayor prioridad que una columna, y una columna tiene mayor prioridad que toda la tabla.

Por lo tanto, las propiedades de [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) se usan en última instancia para dibujar la tabla. El siguiente ejemplo muestra cómo obtener el formato de relleno efectivo para los distintos niveles de la tabla:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	table = presentation.slides[0].shapes[0]

	table_format_effective = table.table_format.get_effective()
	row_format_effective = table.rows[0].row_format.get_effective()
	column_format_effective = table.columns[0].column_format.get_effective()
	cell_format_effective = table[0, 0].cell_format.get_effective()

	table_fill_format_effective = table_format_effective.fill_format
	row_fill_format_effective = row_format_effective.fill_format
	column_fill_format_effective = column_format_effective.fill_format
	cell_fill_format_effective = cell_format_effective.fill_format
```

## **Preguntas frecuentes**

**¿Cómo puedo saber si obtuve una “instantánea” en lugar de un “objeto en vivo”, y cuándo debo volver a leer las propiedades efectivas?**  

Los objetos EffectiveData son instantáneas inmutables de los valores calculados en el momento de la llamada. Si cambia la configuración local o heredada de la forma, recupere los datos efectivos nuevamente para obtener los valores actualizados.

**¿Cambiar la diapositiva de diseño/maestra afecta a las propiedades efectivas ya obtenidas?**  

Sí, pero solo después de volver a leerlas. Un objeto EffectiveData ya obtenido no se actualiza por sí mismo; solicítelo nuevamente tras cambiar el diseño o la maestra.

**¿Puedo modificar valores a través de EffectiveData?**  

No. EffectiveData es de solo lectura. Realice los cambios en los objetos de formato local (forma/texto/3D, etc.) y luego obtenga nuevamente los valores efectivos.

**¿Qué ocurre si una propiedad no está definida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**  

El valor efectivo se determina mediante el mecanismo predeterminado (valores por defecto de PowerPoint/Aspose.Slides). Ese valor resuelto pasa a formar parte de la instantánea EffectiveData.

**A partir de un valor de fuente efectivo, ¿puedo saber qué nivel proporcionó el tamaño o la tipografía?**  

No directamente. EffectiveData devuelve el valor final. Para encontrar el origen, verifique los valores locales en la porción/párrafo/marco de texto y los estilos de texto en el diseño/maestra/presentación para ver dónde aparece la primera definición explícita.

**¿Por qué a veces los valores de EffectiveData parecen idénticos a los locales?**  

Porque el valor local resultó ser el final (no se necesitó herencia de nivel superior). En esos casos, el valor efectivo coincide con el local.

**¿Cuándo debo usar propiedades efectivas y cuándo trabajar solo con las locales?**  

Use EffectiveData cuando necesite el resultado “tal como se renderiza” después de aplicar toda la herencia (p. ej., para alinear colores, sangrías o tamaños). Si necesita cambiar el formato en un nivel específico, modifique las propiedades locales y, si es necesario, vuelva a leer EffectiveData para verificar el resultado.