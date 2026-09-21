---
title: Administrar campos de texto en presentaciones de PowerPoint en PHP
linktitle: Campos de texto
type: docs
weight: 52
url: /es/php-java/text-fields/
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
- PHP
- Aspose.Slides
description: "Crear, inspeccionar, modificar y eliminar campos de texto en presentaciones de PowerPoint con Aspose.Slides para PHP vía Java. Conservar el formato y verificar los archivos PPTX y PPT guardados."
---
## **Visión general**

Un párrafo de texto está formado por porciones. Una [Portion](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/) ordinaria contiene texto literal; una porción de campo también tiene un [Field](https://reference.aspose.com/slides/es/php-java/aspose.slides/field/) cuyo tipo identifica un valor actualizado automáticamente, como el número de diapositiva o la fecha. Dos porciones pueden mostrar los mismos caracteres mientras que sólo una contiene un campo.

Utilice [Portion::getField](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/#getField) para distinguirlas: es `null` para texto ordinario. [Portion::addField](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/#addField) convierte una porción existente en un campo. Mantenga una etiqueta y su valor dinámico en porciones separadas de modo que convertir el valor no reemplace también la etiqueta.

Esta guía cubre los campos dentro del texto, su formato y su guardado en PPTX y PPT. Para marcos de texto y párrafos, vea [Gestionar texto](/slides/es/php-java/manage-text/).

## **Crear un campo de número de diapositiva**

El siguiente ejemplo completo crea un cuadro de texto que contiene una etiqueta literal `Slide ` seguida de un número actualizado automáticamente. Establece el tamaño, el grosor y el color del número antes de añadir el campo, luego vuelve a abrir la presentación guardada y verifica el tipo de campo, el texto y el formato. No se requiere ningún archivo de entrada.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

La nueva presentación comienza con el número de diapositiva 1, por lo que el texto es `Slide 1`, y ambas comprobaciones imprimen `true`. El número sigue siendo un campo después de volver a abrir; no es un `1` literal. Los índices en la verificación se refieren a la forma y a las porciones creadas por este ejemplo.

## **Elegir un tipo de campo**

[FieldType](https://reference.aspose.com/slides/es/php-java/aspose.slides/fieldtype/) proporciona los siguientes métodos para obtener valores predefinidos. Pase el valor apropiado a [addField](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/#addField).

| Método | Propósito |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/es/php-java/aspose.slides/fieldtype/#getSlideNumber) | El número de diapositiva actual. |
| [getDateTime](https://reference.aspose.com/slides/es/php-java/aspose.slides/fieldtype/#getDateTime) | Fecha/hora en el formato predeterminado de la aplicación de renderizado. |
| [getDateTime1](https://reference.aspose.com/slides/es/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/es/php-java/aspose.slides/fieldtype/#getDateTime9) | Formatos de fecha predefinidos o combinaciones de fecha/hora. |
| [getDateTime10](https://reference.aspose.com/slides/es/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/es/php-java/aspose.slides/fieldtype/#getDateTime13) | Formatos de hora predefinidos, con opciones para segundos y reloj de 12 horas. |
| [getHeader](https://reference.aspose.com/slides/es/php-java/aspose.slides/fieldtype/#getHeader) | Un campo de encabezado; vea las limitaciones de marcadores de posición y formato a continuación. |
| [getFooter](https://reference.aspose.com/slides/es/php-java/aspose.slides/fieldtype/#getFooter) | Un campo de pie de página. |

Por ejemplo, [getDateTime3](https://reference.aspose.com/slides/es/php-java/aspose.slides/fieldtype/#getDateTime3) representa un día, el nombre completo del mes y el año en inglés. Estos son formatos de campo predefinidos, no cadenas de formato de fecha PHP arbitrarias. El idioma establecido con [setLanguageId](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setLanguageId) y la aplicación que procesa la presentación pueden afectar el resultado mostrado.

## **Crear un campo a partir de una cadena interna**

La sobrecarga de cadena de [addField](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/#addField) acepta un identificador de campo interno. Úsela cuando conserve un identificador proporcionado por otra aplicación que no tiene un valor predefinido. También puede construir un [FieldType](https://reference.aspose.com/slides/es/php-java/aspose.slides/fieldtype/#FieldType) a partir del identificador. [FieldType::getInternalString](https://reference.aspose.com/slides/es/php-java/aspose.slides/fieldtype/#getInternalString) expone ese identificador para inspección.

Este ejemplo almacena un campo `custom-report-id` específico de la aplicación con el texto alternativo `Report-042`. El identificador no registra un cálculo: Aspose.Slides no genera IDs de informe para un tipo desconocido. La aplicación que comprende este identificador debe proporcionar su significado y actualizar su valor.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Después de este viaje de ida y vuelta con PPTX, el tipo es `custom-report-id` y el texto es `Report-042`. Pasar una cadena como `Y-m-d` nombraría un tipo de campo; no configuraría un formato de fecha personalizado. Para una fecha fija en un formato arbitrario, utilice texto ordinario.

## **Inspeccionar, modificar y eliminar campos de fecha/hora**

Modifique un campo existente mediante [Field::setType](https://reference.aspose.com/slides/es/php-java/aspose.slides/field/#setType). Verifique que el campo exista antes de acceder a su tipo. Para detener actualizaciones automáticas, llame a [Portion::removeField](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/#removeField). Esto mantiene la porción y su texto actual mientras se elimina la asociación del campo. Si necesita un valor fijo concreto, asigne ese texto después de eliminar el campo.

Para la configuración de la API asociada al procesamiento de campos de fecha/hora, vea [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#setCurrentDateTime). El ejemplo a continuación utiliza una fecha de aprobación explícita al convertir un campo a texto ordinario.

Descargue [sample.pptx](sample.pptx) y colóquelo en el directorio de trabajo de JavaBridge, o pase su ruta absoluta al constructor de la presentación. Contiene dos formas de texto con nombre, `UpdatedAt` y `ApprovedDate`, cada una con un campo de fecha/hora, más etiquetas de texto ordinario. El siguiente ejemplo recorre las formas de texto de nivel superior en diapositivas normales. Cambia los campos de fecha/hora a un formato de fecha larga y los pone en cursiva, preservando su otro formato. Sólo los campos en `ApprovedDate` se convierten en texto fijo.

El ejemplo reconoce los identificadores internos incorporados `datetime` y `datetime1` hasta `datetime13`. Los grupos, tablas, notas, diseños y patrones requieren recorrer sus propios contenedores de texto y están fuera del alcance de este ejemplo.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Tras volver a abrir, `UpdatedAt` tiene el tipo `datetime3` y sigue siendo dinámico. `ApprovedDate` no tiene campo y contiene `05 April 2030`. Ambas porciones de fecha están en cursiva, y su tamaño de fuente original, negrita y color permanecen intactos. Las etiquetas de texto ordinario no se modifican. La verificación lee la primera porción de las dos formas conocidas en el ejemplo suministrado.

## **Conservar el formato del texto**

Trabaje con la porción existente al añadir un campo, cambiar su tipo o eliminarlo. Estas operaciones conservan el formato de esa porción. Utilice [Portion::getPortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/#getPortionFormat) para cambiar sólo las propiedades necesarias, como hacen los ejemplos para el color o la cursiva.

Evite reconstruir todo un marco de texto sólo para actualizar un campo: hacerlo puede perder los límites originales de las porciones y su formato individual. Además, distinga el formato establecido explícitamente del heredado del párrafo, diseño o tema. Vea [Text Formatting](/slides/es/php-java/text-formatting/) para opciones de formato más amplias.

## **Campos y marcadores de posición de encabezado/pie de página**

Un campo forma parte de una porción de texto. Un marcador de posición es una forma con un rol en la presentación, como un pie de página o número de diapositiva. Añadir un campo a un cuadro de texto ordinario no convierte esa forma en un marcador de posición.

Los gestores de encabezado/pie de página controlan el texto y la visibilidad de los marcadores de posición en diapositivas, diseños y patrones, incluida la propagación a diapositivas dependientes. Un campo numérico en un cuadro de texto personalizado puede ser útil incluso cuando no se usa el marcador de posición de número de diapositiva. Por el contrario, cambiar la visibilidad del marcador de posición no elimina un campo de un cuadro de texto no relacionado.

Los tipos predefinidos de encabezado y pie de página no crean los marcadores de posición correspondientes ni proporcionan su contenido. En particular, una diapositiva PowerPoint normal no tiene marcador de posición de encabezado; los encabezados pertenecen a las páginas de notas y a los folletos. No asuma que un campo de encabezado o pie de página en una forma arbitraria obtendrá automáticamente el texto configurado mediante un gestor de marcadores de posición. Para ese flujo de trabajo, vea [Presentation Headers and Footers](/slides/es/php-java/presentation-header-and-footer/).

## **Limitaciones de PPTX y PPT**

Verifique tanto el tipo de campo como el texto resultante después de guardar y volver a abrir. Conservar un identificador no prueba que una aplicación pueda calcular o mostrar su valor.

| Formato | Comportamiento del campo y limitaciones |
|---|---|
| PPTX | Almacena los identificadores internos de campos junto con el texto del campo. En las verificaciones de ida y vuelta, los tipos predefinidos y el identificador personalizado usado arriba sobrevivieron al guardado y la reapertura. El tipo personalizado desconocido conservó su texto alternativo; no adquirió lógica de cálculo automática. Otra aplicación puede tratar los identificadores no compatibles de forma diferente. |
| PPT | Utiliza representaciones de campo heredadas y tiene una compatibilidad más limitada. En las verificaciones de ida y vuelta, los campos de número de diapositiva y los campos de fecha/hora predefinidos sobrevivieron al guardar y volver a abrir. Un campo personalizado en un cuadro de texto de diapositiva ordinario se reapróximo con su identificador pero con `*` como texto; un campo de encabezado en el mismo contexto también produjo `*`. No confíe en que los campos personalizados o contextos de campo no compatibles conserven su texto visible. |

Para una salida portable y fija, convierta los campos no compatibles a texto ordinario y asigne explícitamente el valor que desea antes de guardar. Esto conserva el texto elegido pero detiene intencionalmente las actualizaciones automáticas. Pruebe también la aplicación de destino cuando su propio recálculo de campos forme parte de su flujo de trabajo.

## **Preguntas frecuentes**

**¿Cómo puedo saber si un número o fecha mostrados son un campo?**

Inspeccione [Portion::getField](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/#getField). Un valor distinto de null identifica un campo; el texto mostrado por sí solo no lo indica.

**¿Eliminar un campo elimina su texto o formato?**

No. [removeField](https://reference.aspose.com/slides/es/php-java/aspose.slides/portion/#removeField) convierte la porción existente en texto ordinario. Asigne un valor explícito después si necesita una fecha fija concreta o un valor alternativo.

**¿Puede una cadena interna definir un nuevo formato de fecha o fórmula?**

No. Identifica un tipo de campo. Un identificador desconocido no proporciona un evaluador ni un patrón de formato de fecha PHP. Utilice un tipo predefinido compatible o formatee un valor usted mismo como texto ordinario.

**¿Por qué comprobar una presentación nuevamente después de guardarla?**

Los identificadores de campo, el texto calculado y el formato son aspectos distintos a verificar. La conversión de formato puede cambiar el resultado visible aun cuando el identificador del campo siga presente.