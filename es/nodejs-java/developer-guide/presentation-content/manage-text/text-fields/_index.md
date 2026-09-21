---
title: Gestionar campos de texto en presentaciones de PowerPoint en JavaScript
linktitle: Campos de texto
type: docs
weight: 52
url: /es/nodejs-java/text-fields/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Crear, inspeccionar, modificar y eliminar campos de texto en presentaciones de PowerPoint con Aspose.Slides para Node.js vía Java. Conservar el formato y verificar los archivos PPTX y PPT guardados."
---
## **Visión general**

Un párrafo de texto se compone de porciones. Una [Portion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/) ordinaria contiene texto literal; una porción de campo también tiene un [Field](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/field/) cuyo tipo identifica un valor actualizado automáticamente, como el número de diapositiva o la fecha. Dos porciones pueden mostrar los mismos caracteres mientras que solo una contiene un campo.

Utilice [Portion.getField](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/#getField) para distinguirlas: devuelve `null` para texto ordinario. [Portion.addField](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/#addField) convierte una porción existente en un campo. Mantenga una etiqueta y su valor dinámico en porciones separadas para que al convertir el valor no se reemplace también la etiqueta.

Esta guía cubre los campos dentro del texto, su formato y su guardado en PPTX y PPT. Para marcos de texto y párrafos, consulte [Administrar texto](/slides/es/nodejs-java/manage-text/).

## **Crear un campo de número de diapositiva**

El siguiente ejemplo completo crea un cuadro de texto que contiene una etiqueta literal `Slide ` seguida de un número actualizado automáticamente. Establece el tamaño, el grosor y el color del número antes de añadir el campo, luego reabre la presentación guardada y verifica el tipo de campo, el texto y el formato. No se requiere ningún archivo de entrada.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

La nueva presentación comienza con el número de diapositiva 1, por lo que el texto es `Slide 1`, y ambas comprobaciones imprimen `true`. El número sigue siendo un campo después de volver a abrirla; no es un literal `1`. Los índices en la verificación se refieren a la forma y a las porciones creadas por este ejemplo.

## **Elegir un tipo de campo**

[FieldType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fieldtype/) ofrece los siguientes métodos para obtener valores predefinidos. Pase el valor correspondiente a [addField](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/#addField).

| Método | Propósito |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | El número de diapositiva actual. |
| [getDateTime](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Fecha/hora en el formato predeterminado de la aplicación de renderizado. |
| [getDateTime1](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Formatos de fecha predefinidos o combinaciones de fecha/hora. |
| [getDateTime10](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Formatos de hora predefinidos, con opciones para segundos y reloj de 12 horas. |
| [getHeader](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fieldtype/#getHeader) | Un campo de cabecera; vea las limitaciones de marcador de posición y formato más abajo. |
| [getFooter](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fieldtype/#getFooter) | Un campo de pie de página. |

Por ejemplo, [getDateTime3](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fieldtype/#getDateTime3) representa un día, el nombre completo del mes y el año en inglés. Estos son formatos de campo predefinidos, no cadenas arbitrarias de formato de fecha. El idioma establecido con [setLanguageId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) y la aplicación que procesa la presentación pueden afectar el resultado mostrado.

## **Crear un campo a partir de una cadena interna**

La sobrecarga de cadena de [addField](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/#addField) acepta un identificador interno de campo. Úsela cuando se deba preservar un identificador proporcionado por otra aplicación que no tiene un valor predefinido. También puede crear un [FieldType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fieldtype/) a partir del identificador. [FieldType.getInternalString](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fieldtype/#getInternalString) expone ese identificador para su inspección.

Este ejemplo almacena un campo específico de la aplicación `custom-report-id` con el texto de reserva `Report-042`. El identificador no registra un cálculo: Aspose.Slides no genera IDs de informe para un tipo desconocido. La aplicación que interpreta este identificador debe proporcionar su significado y actualizar su valor.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Después de este ciclo PPTX, el tipo es `custom-report-id` y el texto es `Report-042`. Pasar una cadena como `yyyy-MM-dd` nombraría un tipo de campo; no configuraría un formato de fecha personalizado. Para una fecha fija en un formato arbitrario, utilice texto ordinario.

## **Inspeccionar, modificar y eliminar campos de fecha/hora**

Cambie un campo existente mediante [Field.setType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/field/#setType). Verifique que el campo exista antes de acceder a su tipo. Para detener las actualizaciones automáticas, llame a [Portion.removeField](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/#removeField). Esto mantiene la porción y su texto actual mientras elimina la asociación del campo. Si necesita un valor fijo específico, asigne ese texto después de eliminar el campo.

Para la configuración de la API asociada al procesamiento de campos de fecha/hora, vea [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). El ejemplo a continuación utiliza una fecha de aprobación explícita al convertir un campo a texto ordinario.

Descargue [sample.pptx](sample.pptx) y colóquelo en el directorio de trabajo. Contiene dos formas de texto con nombre, `UpdatedAt` y `ApprovedDate`, cada una con un campo de fecha/hora, además de etiquetas de texto ordinario. El siguiente ejemplo recorre las formas de texto de nivel superior en diapositivas normales. Cambia los campos de fecha/hora a un formato de fecha larga y los pone en cursiva, conservando el resto de su formato. Solo los campos en `ApprovedDate` se convierten en texto fijo.

La fecha de aprobación es el 5 de abril de 2030; los índices de mes en JavaScript empiezan en cero, por lo que abril es `3`. Se utiliza UTC tanto para la construcción como para el formato para mantener la fecha independiente de la zona horaria local.

La muestra reconoce los identificadores internos incorporados `datetime` y `datetime1` a `datetime13`. Los grupos, tablas, notas, diseños y patrones requieren recorrer sus propios contenedores de texto y están fuera del alcance de este ejemplo.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Después de volver a abrir, `UpdatedAt` tiene el tipo `datetime3` y sigue siendo dinámico. `ApprovedDate` no tiene campo y contiene `05 April 2030`. Ambas porciones de fecha están en cursiva, y su tamaño de fuente original, configuración de negrita y color permanecen intactos. Las etiquetas de texto ordinario no se modifican. La verificación lee la primera porción de las dos formas conocidas en la muestra suministrada.

## **Conservar el formato del texto**

Trabaje con la porción existente al añadir un campo, cambiar su tipo o eliminarlo. Estas operaciones conservan el formato de esa porción. Utilice [Portion.getPortionFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/#getPortionFormat) para cambiar solo las propiedades necesarias, como hacen los ejemplos para el color o la cursiva.

Evite reconstruir todo un marco de texto solo para actualizar un campo: hacerlo puede perder los límites originales de las porciones y su formato individual. Además, distinga entre el formato establecido explícitamente y el heredado del párrafo, diseño o tema. Consulte [Formato de texto](/slides/es/nodejs-java/text-formatting/) para opciones de formato más amplias.

## **Campos y marcadores de posición de encabezado/pie de página**

Un campo es parte de una porción de texto. Un marcador de posición es una forma con un rol de presentación, como un pie de página o número de diapositiva. Añadir un campo a un cuadro de texto ordinario no convierte esa forma en un marcador de posición.

Los gestores de encabezado/pie de página controlan el texto y la visibilidad de los marcadores de posición en diapositivas, diseños y patrones, incluida la propagación a diapositivas dependientes. Un campo numérico en un cuadro de texto personalizado puede ser útil incluso cuando no se utiliza el marcador de posición de número de diapositiva. Por el contrario, cambiar la visibilidad del marcador de posición no elimina un campo de un cuadro de texto no relacionado.

Los tipos predefinidos de encabezado y pie de página no crean los marcadores de posición correspondientes ni suministran su contenido. En particular, una diapositiva estándar de PowerPoint no tiene marcador de posición de encabezado; los encabezados pertenecen a páginas de notas y folletos. No asuma que un campo de encabezado o pie de página en una forma arbitraria obtendrá automáticamente el texto configurado mediante un gestor de marcadores de posición. Para ese flujo de trabajo, consulte [Encabezados y pies de página de la presentación](/slides/es/nodejs-java/presentation-header-and-footer/).

## **Limitaciones de PPTX y PPT**

Verifique tanto el tipo de campo como el texto resultante después de guardar y volver a abrir. Preservar un identificador no prueba que una aplicación pueda calcular o mostrar su valor.

| Formato | Comportamiento del campo y limitaciones |
|---|---|
| PPTX | Almacena los identificadores internos de campo junto con el texto del campo. En las comprobaciones de ida y vuelta, los tipos predefinidos y el identificador personalizado usado arriba sobrevivieron a guardar y volver a abrir. El tipo personalizado desconocido conservó su texto de reserva; no adquirió lógica de cálculo automática. Otra aplicación puede tratar los identificadores no compatibles de forma diferente. |
| PPT | Utiliza representaciones de campo heredadas y tiene una compatibilidad más limitada. En las comprobaciones de ida y vuelta, los campos de número de diapositiva y los de fecha/hora predefinidos sobrevivieron a guardar y volver a abrir. Un campo personalizado en un cuadro de texto de diapositiva ordinario se reabrió con su identificador pero con `*` como texto; un campo de encabezado en el mismo contexto también produjo `*`. No confíe en que los campos personalizados o contextos de campo no compatibles conserven su texto visible. |

Para una salida portátil y fija, convierta los campos no compatibles a texto ordinario y asigne explícitamente el valor deseado antes de guardar. Esto preserva el texto elegido pero detiene intencionalmente las actualizaciones automáticas. Pruebe también la aplicación de destino cuando su propio recálculo de campos forme parte de su flujo de trabajo.

## **Preguntas frecuentes**

**¿Cómo puedo saber si un número o fecha mostrados son un campo?**

Inspeccione [Portion.getField](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/#getField). Un valor distinto de `null` identifica un campo; el texto mostrado por sí solo no lo indica.

**¿Eliminar un campo elimina su texto o formato?**

No. [removeField](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/portion/#removeField) convierte la porción existente en texto ordinario. Asigne un valor explícito después si necesita una fecha congelada o un texto de reserva concreto.

**¿Puede una cadena interna definir un nuevo formato de fecha o fórmula?**

No. Identifica un tipo de campo. Un identificador desconocido no proporciona un evaluador ni un patrón de formato de fecha. Utilice un tipo predefinido compatible o formatee el valor usted mismo como texto ordinario.

**¿Por qué comprobar una presentación de nuevo después de guardarla?**

Los identificadores de campos, el texto calculado y el formato son aspectos distintos que deben verificarse. La conversión de formatos puede cambiar el resultado visible aun cuando el identificador del campo siga presente.