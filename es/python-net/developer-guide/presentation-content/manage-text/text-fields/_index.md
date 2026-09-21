---
title: Gestionar campos de texto en presentaciones PowerPoint con Python
linktitle: Campos de texto
type: docs
weight: 52
url: /es/python-net/text-fields/
keywords:
- campo de texto
- texto automático
- número de diapositiva
- fecha y hora
- encabezado
- pie de página
- porción de texto
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Crear, inspeccionar, modificar y eliminar campos de texto en presentaciones de PowerPoint con Aspose.Slides para Python mediante .NET. Conservar el formato y verificar los archivos PPTX y PPT guardados."
---
## **Visión general**

Un párrafo de texto está formado por porciones. Una [Portion](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/) ordinaria contiene texto literal; una porción de campo también tiene un [Field](https://reference.aspose.com/slides/es/python-net/aspose.slides/field/) cuyo tipo identifica un valor actualizado automáticamente, como el número de diapositiva o la fecha. Dos porciones pueden mostrar los mismos caracteres mientras que sólo una contiene un campo.

Utilice [Portion.field](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/field/) para distinguirlas: es `None` para texto ordinario. [Portion.add_field](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/add_field/) convierte una porción existente en un campo. Mantenga una etiqueta y su valor dinámico en porciones separadas para que la conversión del valor no reemplace también la etiqueta.

Esta guía cubre los campos dentro del texto, su formato y la forma de guardarlos en PPTX y PPT. Para marcos de texto y párrafos, consulte [Manage Text](/slides/es/python-net/manage-text/).

## **Crear un campo de número de diapositiva**

El siguiente ejemplo completo crea un cuadro de texto que contiene una etiqueta literal `Slide ` seguida de un número actualizado automáticamente. Establece el tamaño, el grosor y el color del número antes de añadir el campo, luego reabre la presentación guardada y comprueba el tipo de campo, el texto y el formato. No se requiere ningún archivo de entrada.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

La nueva presentación comienza con el número de diapositiva 1, por lo que el texto es `Slide 1`, y ambas comprobaciones imprimen `True`. El número sigue siendo un campo después de reabrir; no es un `1` literal. Los índices en la verificación se refieren a la forma y las porciones creadas por este ejemplo.

## **Elegir un tipo de campo**

[FieldType](https://reference.aspose.com/slides/es/python-net/aspose.slides/fieldtype/) proporciona los siguientes valores predefinidos. Pase el valor apropiado a [add_field](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/add_field/).

| Valor | Propósito |
|---|---|
| [slide_number](https://reference.aspose.com/slides/es/python-net/aspose.slides/fieldtype/slide_number/) | El número actual de diapositiva. |
| [date_time](https://reference.aspose.com/slides/es/python-net/aspose.slides/fieldtype/date_time/) | Fecha/hora en el formato predeterminado de la aplicación de renderizado. |
| [date_time1](https://reference.aspose.com/slides/es/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/es/python-net/aspose.slides/fieldtype/date_time9/) | Formatos de fecha predefinidos o combinados de fecha/hora. |
| [date_time10](https://reference.aspose.com/slides/es/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/es/python-net/aspose.slides/fieldtype/date_time13/) | Formatos de hora predefinidos, con opciones para segundos y reloj de 12 horas. |
| [header](https://reference.aspose.com/slides/es/python-net/aspose.slides/fieldtype/header/) | Un campo de encabezado; vea las limitaciones de marcador de posición y formato más abajo. |
| [footer](https://reference.aspose.com/slides/es/python-net/aspose.slides/fieldtype/footer/) | Un campo de pie de página. |

Por ejemplo, [date_time3](https://reference.aspose.com/slides/es/python-net/aspose.slides/fieldtype/date_time3/) representa un día, el nombre completo del mes y el año en inglés. Estos son formatos de campo predefinidos, no cadenas arbitrarias de formato de fecha de Python. El [language_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/language_id/) de la porción y la aplicación que procesa la presentación pueden afectar el resultado mostrado.

## **Crear un campo a partir de una cadena interna**

La sobrecarga de cadena de [add_field](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/add_field/) acepta un identificador de campo interno. Úsela cuando se preserve un identificador suministrado por otra aplicación que no tiene un valor predefinido. También puede crear un [FieldType](https://reference.aspose.com/slides/es/python-net/aspose.slides/fieldtype/__init__/) a partir del identificador. [FieldType.internal_string](https://reference.aspose.com/slides/es/python-net/aspose.slides/fieldtype/internal_string/) expone ese identificador para inspección.

Este ejemplo almacena un campo `custom-report-id` específico de la aplicación con el texto de respaldo `Report-042`. El identificador no registra un cálculo: Aspose.Slides no genera IDs de informe para un tipo desconocido. La aplicación que interpreta este identificador debe proporcionar su significado y actualizar su valor.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

Tras este viaje de ida y vuelta en PPTX, el tipo es `custom-report-id` y el texto es `Report-042`. Pasar una cadena como `%Y-%m-%d` nombraría un tipo de campo; no configuraría un formato de fecha personalizado. Para una fecha fija en un formato arbitrario, utilice texto ordinario.

## **Inspeccionar, modificar y eliminar campos de fecha/hora**

Lea y modifique un campo existente a través de [Field.type](https://reference.aspose.com/slides/es/python-net/aspose.slides/field/type/). Verifique que el campo exista antes de acceder a su tipo. Para detener las actualizaciones automáticas, llame a [Portion.remove_field](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/remove_field/). Esto conserva la porción y su texto actual mientras elimina la asociación del campo. Si necesita un valor fijo específico, asigne ese texto después de eliminar el campo.

Para la configuración de la API asociada al procesamiento de campos de fecha/hora, vea [Presentation.current_date_time](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/current_date_time/). El ejemplo a continuación utiliza una fecha de aprobación explícita al convertir un campo a texto ordinario. Una tupla de nombres de mes en inglés mantiene la fecha fija independiente de la configuración regional del sistema.

Descargue [sample.pptx](sample.pptx) y colóquelo en el directorio de trabajo. Contiene dos formas de texto con nombre, `UpdatedAt` y `ApprovedDate`, cada una con un campo de fecha/hora, además de etiquetas de texto ordinario. El siguiente ejemplo recorre las formas de texto de nivel superior en diapositivas normales. Cambia los campos de fecha/hora a un formato de fecha larga y los pone en cursiva, manteniendo su otro formato. Sólo los campos en `ApprovedDate` se convierten en texto fijo.

El ejemplo reconoce los identificadores internos incorporados `datetime` y `datetime1` hasta `datetime13`. Los grupos, tablas, notas, diseños y patrones requieren recorrer sus propios contenedores de texto y están fuera del alcance de este ejemplo.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

Tras reabrir, `UpdatedAt` tiene el tipo `datetime3` y sigue siendo dinámico. `ApprovedDate` no tiene campo y contiene `05 April 2030`. Ambas porciones de fecha están en cursiva, y su tamaño de fuente original, configuración de negrita y color permanecen intactos. Las etiquetas de texto ordinario no cambian. La verificación lee la primera porción de las dos formas conocidas en el ejemplo proporcionado.

## **Conservar el formato del texto**

Trabaje con la porción existente al añadir un campo, cambiar su tipo o eliminarlo. Estas operaciones conservan el formato de esa porción. Utilice [Portion.portion_format](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/portion_format/) para cambiar sólo las propiedades necesarias, como hacen los ejemplos para color o cursiva.

Evite reconstruir un marco de texto completo solo para actualizar un campo: hacerlo puede perder los límites originales de las porciones y su formato individual. También distinga el formato establecido explícitamente del heredado del párrafo, diseño o tema. Consulte [Text Formatting](/slides/es/python-net/text-formatting/) para opciones de formato más amplias.

## **Campos y marcadores de posición de encabezado/pie de página**

Un campo forma parte de una porción de texto. Un marcador de posición es una forma con un rol en la presentación, como un pie de página o número de diapositiva. Añadir un campo a un cuadro de texto ordinario no convierte esa forma en un marcador de posición.

Los administradores de encabezado/pie de página controlan el texto y la visibilidad de los marcadores de posición en diapositivas, diseños y patrones, incluida la propagación a diapositivas dependientes. Un campo numérico en un cuadro de texto personalizado puede ser útil incluso cuando no se usa el marcador de posición de número de diapositiva. Por el contrario, cambiar la visibilidad del marcador de posición no elimina un campo de un cuadro de texto no relacionado.

Los tipos predefinidos de encabezado y pie de página no crean los marcadores de posición correspondientes ni proporcionan su contenido. En particular, una diapositiva normal de PowerPoint no tiene marcador de posición de encabezado; los encabezados pertenecen a las páginas de notas y a los folletos. No asuma que un campo de encabezado o pie de página en una forma arbitraria obtendrá automáticamente el texto configurado mediante un administrador de marcadores de posición. Para ese flujo de trabajo, consulte [Presentation Headers and Footers](/slides/es/python-net/presentation-header-and-footer/).

## **Limitaciones de PPTX y PPT**

Compruebe tanto el tipo de campo como el texto resultante después de guardar y reabrir. Conservar un identificador no demuestra que una aplicación pueda calcular o mostrar su valor.

| Formato | Comportamiento del campo y limitaciones |
|---|---|
| PPTX | Almacena los identificadores internos de campo junto al texto del campo. En las comprobaciones de ida y vuelta, los tipos predefinidos y el identificador personalizado usado arriba sobrevivieron a guardarse y reabrirse. El tipo personalizado desconocido conservó su texto de respaldo; no obtuvo lógica de cálculo automática. Otra aplicación puede tratar los identificadores no soportados de forma diferente. |
| PPT | Utiliza representaciones de campo heredadas y tiene una compatibilidad más limitada. En las comprobaciones de ida y vuelta, los campos de número de diapositiva y los campos predefinidos de fecha/hora sobrevivieron al guardado y reabriendo. Un campo personalizado en un cuadro de texto de diapositiva ordinario se reabrió con su identificador pero con `*` como texto; un campo de encabezado en el mismo contexto también produjo `*`. No confíe en que los campos personalizados o contextos de campos no compatibles mantengan su texto visible. |

Para una salida portátil y fija, convierta los campos no compatibles a texto ordinario y asigne explícitamente el valor que desee antes de guardar. Esto conserva el texto elegido pero detiene intencionalmente las actualizaciones automáticas. Pruebe también la aplicación de destino cuando su propio recálculo de campos forme parte de su flujo de trabajo.

## **Preguntas frecuentes**

**¿Cómo puedo saber si un número o fecha mostrado es un campo?**

Inspeccione [Portion.field](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/field/). Un valor diferente de `None` identifica un campo; el texto mostrado por sí solo no puede indicarlo.

**¿Eliminar un campo elimina su texto o formato?**

No. [remove_field](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/remove_field/) convierte la porción existente en texto ordinario. Asigne un valor explícito después si necesita una fecha fija concreta o un valor de respaldo.

**¿Puede una cadena interna definir un nuevo formato de fecha o fórmula?**

No. Identifica un tipo de campo. Un identificador desconocido no proporciona un evaluador ni un patrón de formato de fecha de Python. Utilice un tipo predefinido soportado o formatee el valor usted mismo como texto ordinario.

**¿Por qué volver a comprobar una presentación después de guardarla?**

Los identificadores de campo, el texto calculado y el formato son elementos separados que deben verificarse. La conversión de formato puede cambiar el resultado visible incluso cuando el identificador de campo sigue presente.