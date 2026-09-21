---
title: Gestionar campos de texto en presentaciones de PowerPoint en Python mediante Java
linktitle: Campos de texto
type: docs
weight: 52
url: /es/python-java/text-fields/
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
- Java
- Aspose.Slides
description: "Crear, inspeccionar, modificar y eliminar campos de texto en presentaciones de PowerPoint con Aspose.Slides para Python mediante Java. Conservar el formato y verificar los archivos PPTX y PPT guardados."
---
## **Visión general**

Un párrafo de texto consta de porciones. Una [Porción](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/) ordinaria contiene texto literal; una porción de campo también tiene un [Campo](https://reference.aspose.com/slides/es/python-java/aspose.slides/field/) cuyo tipo identifica un valor actualizado automáticamente, como el número de diapositiva o la fecha. Dos porciones pueden mostrar los mismos caracteres mientras solo una contiene un campo.

Utilice [Portion.getField](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#getField) para distinguirlas: es `None` para texto ordinario. [Portion.addField](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#addField) convierte una porción existente en un campo. Mantenga una etiqueta y su valor dinámico en porciones separadas para que la conversión del valor no sustituya también la etiqueta.

Esta guía cubre los campos dentro del texto, su formato y su guardado en PPTX y PPT. Para marcos de texto y párrafos, consulte [Manage Text](/slides/es/python-java/manage-text/).

## **Crear un campo de número de diapositiva**

El siguiente ejemplo completo crea un cuadro de texto que contiene una etiqueta literal `Slide ` seguida de un número actualizado automáticamente. Establece el tamaño, el grosor y el color del número antes de añadir el campo, luego vuelve a abrir la presentación guardada y comprueba el tipo de campo, el texto y el formato. No se requiere archivo de entrada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

La nueva presentación comienza con el número de diapositiva 1, por lo que el texto es `Slide 1`, y ambas comprobaciones imprimen `True`. El número sigue siendo un campo después de volver a abrir; no es un literal `1`. Los índices en la verificación se refieren a la forma y a las porciones creadas por este ejemplo.

## **Elegir un tipo de campo**

[FieldType](https://reference.aspose.com/slides/es/python-java/aspose.slides/fieldtype/) proporciona los siguientes métodos para obtener valores predefinidos. Pase el valor apropiado a [addField](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#addField).

| Método | Propósito |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/es/python-java/aspose.slides/fieldtype/#getSlideNumber) | El número de diapositiva actual. |
| [getDateTime](https://reference.aspose.com/slides/es/python-java/aspose.slides/fieldtype/#getDateTime) | Fecha/hora en el formato predeterminado de la aplicación de renderizado. |
| [getDateTime1](https://reference.aspose.com/slides/es/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/es/python-java/aspose.slides/fieldtype/#getDateTime9) | Formatos de fecha predefinidos o combinaciones de fecha/hora. |
| [getDateTime10](https://reference.aspose.com/slides/es/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/es/python-java/aspose.slides/fieldtype/#getDateTime13) | Formatos de hora predefinidos, con opciones para segundos y reloj de 12 horas. |
| [getHeader](https://reference.aspose.com/slides/es/python-java/aspose.slides/fieldtype/#getHeader) | Un campo de encabezado; vea las limitaciones de marcador de posición y formato más abajo. |
| [getFooter](https://reference.aspose.com/slides/es/python-java/aspose.slides/fieldtype/#getFooter) | Un campo de pie de página. |

Por ejemplo, [getDateTime3](https://reference.aspose.com/slides/es/python-java/aspose.slides/fieldtype/#getDateTime3) representa día, nombre completo del mes y año en inglés. Estos son formatos de campo predefinidos, no cadenas de formato de fecha arbitrarias de Python. El idioma establecido con [setLanguageId](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setLanguageId) y la aplicación que procesa la presentación pueden afectar el resultado mostrado.

## **Crear un campo a partir de una cadena interna**

La sobrecarga de cadena de [addField](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#addField) acepta un identificador interno de campo. Úsela cuando necesite conservar un identificador suministrado por otra aplicación que no tenga un valor predefinido. También puede crear un [FieldType](https://reference.aspose.com/slides/es/python-java/aspose.slides/fieldtype/#FieldType) a partir del identificador. [FieldType.getInternalString](https://reference.aspose.com/slides/es/python-java/aspose.slides/fieldtype/#getInternalString) expone ese identificador para su inspección.

Este ejemplo almacena un campo específico de la aplicación `custom-report-id` con el texto de reserva `Report-042`. El identificador no registra un cálculo: Aspose.Slides no genera IDs de informe para un tipo desconocido. La aplicación que comprende este identificador debe proporcionar su significado y actualizar su valor.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Tras este viaje de ida y vuelta en PPTX, el tipo es `custom-report-id` y el texto es `Report-042`. Pasar una cadena como `yyyy-MM-dd` nombraría un tipo de campo; no configuraría un formato de fecha personalizado. Para una fecha fija en un formato arbitrario, utilice texto ordinario.

## **Inspeccionar, modificar y eliminar campos de fecha/hora**

Cambie un campo existente mediante [Field.setType](https://reference.aspose.com/slides/es/python-java/aspose.slides/field/#setType). Compruebe que el campo exista antes de acceder a su tipo. Para detener las actualizaciones automáticas, llame a [Portion.removeField](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#removeField). Esto mantiene la porción y su texto actual mientras elimina la asociación del campo. Si necesita un valor fijo específico, asigne ese texto después de eliminar el campo.

Para la configuración de API asociada al procesamiento de campos de fecha/hora, vea [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#setCurrentDateTime). El ejemplo siguiente usa una fecha de aprobación explícita al convertir un campo a texto ordinario.

Descargue [sample.pptx](sample.pptx) y colóquelo en el directorio de trabajo. Contiene dos formas de texto con nombre, `UpdatedAt` y `ApprovedDate`, cada una con un campo de fecha/hora, además de etiquetas de texto ordinario. El siguiente ejemplo recorre las formas de texto de nivel superior en diapositivas normales. Cambia los campos de fecha/hora a un formato de fecha larga y los pone en cursiva, preservando el resto de su formato. Solo los campos en `ApprovedDate` se convierten en texto fijo.

El ejemplo reconoce los identificadores internos incorporados `datetime` y `datetime1` a `datetime13`. Los grupos, tablas, notas, diseños y maestros requieren recorrer sus propios contenedores de texto y están fuera del alcance de este ejemplo.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Utilizar nombres de meses en inglés independientemente de la configuración regional del sistema.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Después de volver a abrir, `UpdatedAt` tiene el tipo `datetime3` y sigue siendo dinámico. `ApprovedDate` no tiene campo y contiene `05 April 2030`. Ambas porciones de fecha están en cursiva, y su tamaño de fuente original, configuración de negrita y color permanecen intactos. Las etiquetas de texto ordinario no se modifican. La verificación lee la primera porción de las dos formas conocidas en la muestra proporcionada.

## **Preservar el formato de texto**

Trabaje con la porción existente al añadir un campo, cambiar su tipo o eliminarlo. Estas operaciones conservan el formato de esa porción. Utilice [Portion.getPortionFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#getPortionFormat) para cambiar solo las propiedades necesarias, como hacen los ejemplos para el color o la cursiva.

Evite reconstruir todo un marco de texto solo para actualizar un campo: hacerlo puede perder los límites originales de las porciones y su formato individual. Distinga también entre el formato establecido explícitamente y el heredado del párrafo, diseño o tema. Consulte [Text Formatting](/slides/es/python-java/text-formatting/) para opciones de formato más amplias.

## **Campos y marcadores de posición de encabezado/pie de página**

Un campo es parte de una porción de texto. Un marcador de posición es una forma con un rol de presentación, como un pie de página o número de diapositiva. Añadir un campo a un cuadro de texto ordinario no convierte esa forma en un marcador de posición.

Los gestores de encabezado/pie de página controlan el texto y la visibilidad de los marcadores de posición en diapositivas, diseños y maestros, incluida la propagación a diapositivas dependientes. Un campo de número en un cuadro de texto personalizado puede ser útil aunque no utilice el marcador de posición de número de diapositiva. Por el contrario, cambiar la visibilidad del marcador de posición no elimina un campo de un cuadro de texto no relacionado.

Los tipos predefinidos de encabezado y pie de página no crean los marcadores de posición correspondientes ni suministran su contenido. En particular, una diapositiva PowerPoint normal no tiene marcador de posición de encabezado; los encabezados pertenecen a páginas de notas y documentos. No asuma que un campo de encabezado o pie de página en una forma arbitraria obtendrá automáticamente el texto configurado mediante un gestor de marcadores de posición. Para ese flujo de trabajo, vea [Presentation Headers and Footers](/slides/es/python-java/presentation-header-and-footer/).

## **Limitaciones de PPTX y PPT**

Compruebe tanto el tipo de campo como el texto resultante después de guardar y volver a abrir. Preservar un identificador no prueba que una aplicación pueda calcular o mostrar su valor.

| Formato | Comportamiento y limitaciones del campo |
|---|---|
| PPTX | Almacena identificadores internos de campo junto con el texto del campo. En las comprobaciones de ida y vuelta, los tipos predefinidos y el identificador personalizado usado arriba sobrevivieron al guardado y la reapertura. El tipo personalizado desconocido conservó su texto de reserva; no adquirió lógica de cálculo automática. Otra aplicación puede tratar los identificadores no soportados de forma diferente. |
| PPT | Utiliza representaciones de campo heredadas y tiene una compatibilidad más limitada. En las comprobaciones de ida y vuelta, los campos de número de diapositiva y de fecha/hora predefinidos sobrevivieron al guardado y la reapertura. Un campo personalizado en un cuadro de texto de diapositiva ordinaria se volvió a abrir con su identificador pero con `*` como texto; un campo de encabezado en el mismo contexto también produjo `*`. No confíe en que los campos personalizados o contextos de campo no admitidos conserven su texto visible. |

Para una salida fija y portable, convierta los campos no admitidos a texto ordinario y asigne explícitamente el valor que desea antes de guardar. Esto conserva el texto elegido pero detiene intencionalmente las actualizaciones automáticas. Pruebe también la aplicación de destino cuando su propio recálculo de campos forme parte de su flujo de trabajo.

## **FAQ**

**¿Cómo puedo saber si un número o fecha mostrada es un campo?**

Inspeccione [Portion.getField](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#getField). Un valor distinto de `None` identifica un campo; el texto mostrado por sí solo no lo indica.

**¿Eliminar un campo elimina su texto o formato?**

No. [removeField](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#removeField) convierte la porción existente en texto ordinario. Asigne un valor explícito después si necesita una fecha fija o un valor de reserva particular.

**¿Puede una cadena interna definir un nuevo formato de fecha o una fórmula?**

No. Identifica un tipo de campo. Un identificador desconocido no proporciona un evaluador ni un patrón de formato de fecha de Python. Utilice un tipo predefinido admitido o formatee el valor usted mismo como texto ordinario.

**¿Por qué volver a comprobar una presentación después de guardarla?**

Los identificadores de campo, el texto calculado y el formato son cosas distintas que hay que verificar. La conversión de formato puede cambiar el resultado visible aun cuando el identificador de campo siga presente.