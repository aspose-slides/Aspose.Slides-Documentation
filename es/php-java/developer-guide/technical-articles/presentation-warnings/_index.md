---
title: Manejar advertencias de presentación en PHP
type: docs
weight: 90
url: /es/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback de advertencia
- política de advertencia
- pérdida de datos
- corrupción de origen
- problema de compatibilidad
- sustitución de fuentes
- firma digital
- carga de presentación
- renderizado de presentación
- conversión de presentación
- guardado de presentación
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Aprenda cómo recopilar, clasificar y actuar sobre las advertencias al cargar, renderizar, convertir y guardar presentaciones con Aspose.Slides para PHP mediante Java."
---
## **Visión general**

Aspose.Slides puede informar problemas recuperables mientras carga, renderiza, convierte o guarda una presentación. Los ejemplos incluyen registros de origen dañados, contenido que no puede preservarse, sustitución de fuentes y limitaciones del formato de destino. Un callback de advertencia permite a una aplicación registrar estas condiciones y decidir si la operación actual puede continuar.

Cree una clase PHP con un método público `warning` y expóngala a través de PHP Java Bridge como la interfaz Java [IWarningCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarningcallback/) usando `java_closure`. Examine los valores devueltos por [getWarningType](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getWarningType--) y [getDescription](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getDescription--) a través de [IWarningInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/). Devuelva [ReturnAction::Continue](https://reference.aspose.com/slides/es/php-java/aspose.slides/returnaction/#Continue) para aceptar la advertencia o [ReturnAction::Abort](https://reference.aspose.com/slides/es/php-java/aspose.slides/returnaction/#Abort) para detener la operación.

Utilice [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setWarningCallback) para las advertencias generadas al abrir una presentación. Las clases de opciones de renderizado y exportación heredan [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveoptions/#setWarningCallback), que recibe advertencias del renderizado de diapositivas, la conversión y el guardado. Como la propia advertencia no identifica la operación de la aplicación, asocie cada instancia de callback con una etapa de operación al crear un informe combinado.

## **Advertencias y excepciones**

Las excepciones Java se exponen a PHP mediante PHP Java Bridge; captúrelas en el límite de la operación, como se muestra en el ejemplo siguiente. Los enlaces a la interfaz Java en este artículo describen el contrato del callback utilizado por el puente.

Una advertencia describe una condición de la que Aspose.Slides puede recuperarse si el callback devuelve `ReturnAction::Continue`. Una excepción indica que la operación solicitada no puede completarse normalmente; las excepciones no se convierten en advertencias y no pueden gestionarse mediante una política de advertencias.

Devolver `ReturnAction::Abort` solicita al despachador de advertencias que finalice la operación actual lanzando una excepción. La excepción pública depende de la operación y del formato de la presentación. Por ejemplo, al cargar pueden aparecer [PptxReadException](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxreadexception/) o [PptReadException](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptreadexception/), mientras que al guardar o exportar puede aparecer [PptxException](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxexception/). Maneje la excepción en el límite de la operación y utilice el informe de advertencias para determinar si la política de la aplicación provocó la terminación, en lugar de basarse en un subtipo o mensaje de excepción. El callback registra la advertencia antes de devolver `ReturnAction::Abort`, garantizando que la razón permanezca disponible para la aplicación.

## **Categorías de advertencia**

La clase [WarningType](https://reference.aspose.com/slides/es/php-java/aspose.slides/warningtype/) proporciona constantes enteras para las siguientes categorías:

| Warning type | Meaning | Typical policy |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/es/php-java/aspose.slides/warningtype/#SourceFileCorruption) | La presentación de origen contiene corrupción que puede volver inutilizable un documento guardado en su formato original. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/es/php-java/aspose.slides/warningtype/#DataLoss) | Texto, gráficos, imágenes u otros datos pueden faltar después de cargar o guardar. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/es/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | La presentación puede perder un formato importante. | Abort en modo de validación estricta; de lo contrario registrar y continuar. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/es/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Puede producirse una diferencia de formato limitada. | Registrar para diagnóstico y continuar. |
| [CompatibilityIssue](https://reference.aspose.com/slides/es/php-java/aspose.slides/warningtype/#CompatibilityIssue) | El resultado puede no abrirse o comportarse correctamente en algunas aplicaciones o versiones antiguas. | Registrar y continuar a menos que la compatibilidad sea obligatoria. |
| [UnexpectedContent](https://reference.aspose.com/slides/es/php-java/aspose.slides/warningtype/#UnexpectedContent) | La fuente contiene contenido no compatible o no reconocido cuyo efecto aún puede ser desconocido. | Registrar y continuar, o tratar como error bajo una política estricta. |

La categoría debe guiar la decisión de la política. Almacene el valor devuelto por [getDescription](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getDescription--) para diagnóstico, pero no dependa de su redacción para la lógica de la aplicación, ya que el texto del mensaje puede variar entre escenarios de advertencia y versiones del producto.

## **Recopilar y clasificar advertencias**

El ejemplo siguiente usa un informe a nivel de aplicación para toda la tubería de procesamiento. Una instancia de callback separada etiqueta las advertencias de carga, renderizado, conversión a PDF y guardado en PPTX. La política aborta ante corrupción de origen o pérdida de datos, opcionalmente aborta ante pérdida importante de formato y continúa para el resto de advertencias. El callback convierte los valores de advertencia a tipos nativos de PHP con `java_values` antes de registrarlos y compararlos.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

Passe `false` a `abortOnMajorFormattingLoss` al crear `WarningPolicy` si las diferencias importantes de formato son aceptables. Los problemas de compatibilidad, la pérdida menor de formato y el contenido inesperado siguen retenidos en el informe aunque la operación continúe. Amplíe `WarningPolicy::getAction` si la aplicación debe rechazar alguna de esas categorías.

## **Escenarios comunes de advertencia**

Las advertencias pueden aparecer en distintas etapas de un flujo de trabajo:

- **Firmas digitales:** Una presentación firmada puede generar una advertencia al cargarse indicando que su firma se perderá durante el procesamiento. Aspose.Slides informa esta condición `DataLoss` mediante [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationsignedwarninginfo/). Un callback en la fase de carga permite a la aplicación rechazar el archivo o aceptar explícitamente la pérdida informada.
- **Sustitución de fuentes:** Una fuente no disponible puede ser reemplazada mientras se renderiza o exporta una diapositiva. Las advertencias de sustitución de fuentes se reportan como `DataLoss`, por lo que la política estricta anterior aborta incluso si la sustitución sería visualmente aceptable para la aplicación. Para observar este comportamiento, utilice una presentación de entrada que contenga texto en una fuente no disponible en tiempo de ejecución. La descripción de la advertencia identifica la sustitución; configure las fuentes requeridas o las [reglas de sustitución de fuentes](/slides/es/php-java/font-substitution/) antes de reintentar.
- **Contenido no compatible o inesperado:** Un cargador puede encontrar registros o características de la presentación que no reconoce. Tales advertencias pueden usar `UnexpectedContent` o una categoría más grave cuando se sabe que los datos o el formato se ven afectados.
- **Compatibilidad de formato:** Guardar en otro formato de presentación puede omitir características o producir un resultado que se comporte de forma distinta en algunas aplicaciones. Por ejemplo, guardar una presentación con más de ocho guías de dibujo horizontales o verticales en un PPT heredado informa un `CompatibilityIssue`. El callback en la fase de guardado puede registrar la pérdida y continuar, o rechazarla si es necesario preservar todas las guías.
- **Comportamiento de carga:** Las opciones de carga y los comportamientos heredados también pueden generar advertencias. Por ejemplo, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifica el uso de un comportamiento obsoleto de bloqueo de presentación como un `CompatibilityIssue`.

Las advertencias dependen del documento de origen, del formato de destino, de la operación y de la versión de Aspose.Slides. No asuma que cada archivo produce una advertencia o que un escenario siempre se asigna a una sola categoría.

## **Manejar operaciones abortadas de forma segura**

Cuando un callback devuelve `ReturnAction::Abort`, no utilice un objeto que haya fallado al cargar y no asuma que una salida de renderizado o guardado está completa. La operación puede terminar después de crear un archivo de salida pero antes de finalizarlo.

Guarde los resultados validados en una ruta separada, por ejemplo `validated-output.pptx`. Reemplace una presentación existente sólo después de que la operación finalice con éxito, el informe de advertencias cumpla la política de la aplicación y el archivo de salida pueda abrirse y verificarse. Así se evita sobrescribir un archivo de origen válido con un resultado parcial o rechazado.

Un informe de advertencias vacío no garantiza que cada característica de origen se haya preservado. Aplique cualquier comprobación adicional de contenido y visual requerida por la aplicación. Consulte también [Open Presentations](/slides/es/php-java/open-presentation/) y [Save Presentations](/slides/es/php-java/save-presentation/).

## **Preguntas frecuentes**

**¿Puede un callback de advertencia manejar todos los errores de Aspose.Slides?**

No. Gestiona únicamente condiciones recuperables informadas como advertencias. Las excepciones que se produzcan independientemente del callback deben ser manejadas por la aplicación alrededor de la llamada de carga, renderizado, conversión o guardado.

**¿Garantiza devolver `ReturnAction::Continue` una salida idéntica?**

No. Sólo permite que el procesamiento continúe. La condición informada puede seguir provocando diferencias en datos, formato o compatibilidad, por lo que es necesario revisar los tipos y descripciones de advertencia recopilados.

**¿Cómo puede una aplicación identificar la operación que produjo una advertencia?**

Cree una instancia de callback para cada operación y almacene una etapa definida por la aplicación junto con los valores devueltos por [getWarningType](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getWarningType--) y [getDescription](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getDescription--), como se muestra en el ejemplo.