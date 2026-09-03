---
title: Gestionar advertencias de presentaciones en Node.js
type: docs
weight: 90
url: /es/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/obtener-callbacks-de-advertencia-para-sustitucion-de-fuentes-en-aspose-slides/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Aprenda cómo recopilar, clasificar y actuar sobre las advertencias al cargar, renderizar, convertir y guardar presentaciones con Aspose.Slides para Node.js a través de Java."
---
## **Visión general**

Aspose.Slides puede informar problemas recuperables mientras carga, renderiza, convierte o guarda una presentación. Los ejemplos incluyen registros de origen dañados, contenido que no puede preservarse, sustitución de fuentes y limitaciones del formato de destino. Un callback de advertencia permite a una aplicación registrar estas condiciones y decidir si la operación actual puede continuar.

Utilice `java.newProxy` para implementar la interfaz Java [IWarningCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarningcallback/) en JavaScript y examine los valores [getWarningType](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getWarningType--) y [getDescription](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getDescription--) proporcionados a través de [IWarningInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/). Devuelva [ReturnAction.Continue](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/returnaction/#Continue) para aceptar la advertencia o [ReturnAction.Abort](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/returnaction/#Abort) para detener la operación.

Utilice [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) para las advertencias generadas al abrir una presentación. Las clases de opciones de renderizado y exportación heredan [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), que recibe advertencias del renderizado de diapositivas, la conversión y el guardado. Como la propia advertencia no identifica la operación de la aplicación, asocie cada instancia de callback con una fase de operación al crear un informe combinado.

## **Advertencias y excepciones**

Una advertencia describe una condición de la que Aspose.Slides puede recuperarse si el callback devuelve `ReturnAction.Continue`. Una excepción significa que la operación solicitada no puede completarse normalmente; las excepciones no se convierten en advertencias y no pueden ser gestionadas mediante una política de advertencias.

Devolver `ReturnAction.Abort` solicita al despachador de advertencias que termine la operación actual lanzando una excepción. La excepción pública depende de la operación y del formato de la presentación. Por ejemplo, la carga puede generar una [PptxReadException](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxreadexception/) o una [PptReadException](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptreadexception/), mientras que al guardar o exportar puede generarse una [PptxException](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxexception/). Capture el error del puente Java en el límite de la operación y utilice el informe de advertencias para determinar si la política de la aplicación provocó la terminación en lugar de depender de un subtipo de excepción o mensaje. El callback registra la advertencia antes de devolver `ReturnAction.Abort`, garantizando que la razón permanezca disponible para la aplicación.

## **Categorías de advertencia**

La clase [WarningType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/warningtype/) proporciona constantes enteras para las siguientes categorías:

| Tipo de advertencia | Significado | Política típica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | La presentación de origen contiene corrupción que puede hacer que un documento guardado en su formato original sea inutilizable. | Abort |
| [DataLoss](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/warningtype/#DataLoss) | Puede que falten texto, gráficos, imágenes u otros datos después de cargar o guardar. | Abort |
| [MajorFormattingLoss](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | La presentación puede perder un formato importante. | Abortar en modo de validación estricta; de lo contrario registrar y continuar |
| [MinorFormattingLoss](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Puede producirse una diferencia de formato limitada. | Registrar para diagnóstico y continuar |
| [CompatibilityIssue](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | El resultado puede no abrirse o comportarse correctamente en algunas aplicaciones o versiones anteriores. | Registrar y continuar a menos que la compatibilidad sea obligatoria |
| [UnexpectedContent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | La fuente contiene contenido no soportado o no reconocido cuyo efecto aún puede ser desconocido. | Registrar y continuar, o tratar como error en una política estricta |

La categoría debe guiar la decisión de política. Guarde el valor devuelto por [getDescription](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getDescription--) para diagnóstico, pero no dependa de su redacción para la lógica de la aplicación, ya que el texto del mensaje puede variar entre escenarios de advertencia y versiones del producto.

## **Recopilar y clasificar advertencias**

El siguiente ejemplo de JavaScript utiliza un informe a nivel de aplicación para todo el pipeline de procesamiento. Una instancia de callback separada etiqueta las advertencias de carga, renderizado, conversión a PDF y guardado en PPTX. La política aborta ante corrupción de origen o pérdida de datos, opcionalmente aborta ante pérdida importante de formato y continúa con otras advertencias.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Pase `false` a `abortOnMajorFormattingLoss` al construir `WarningPolicy` si las diferencias importantes de formato son aceptables. Los problemas de compatibilidad, la pérdida menor de formato y el contenido inesperado siguen estando presentes en el informe incluso cuando la operación continúa. Amplíe `WarningPolicy.getAction` si la aplicación debe rechazar alguna de esas categorías.

## **Escenarios comunes de advertencia**

Las advertencias pueden aparecer en distintas etapas de un flujo de trabajo:

- **Firmas digitales:** Una presentación firmada puede generar una advertencia durante la carga indicando que su firma se perderá durante el procesamiento. Aspose.Slides informa esta condición `DataLoss` a través de [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationsignedwarninginfo/). Un callback en la fase de carga permite a la aplicación rechazar el archivo o aceptar explícitamente la pérdida informada.
- **Sustitución de fuentes:** Una fuente no disponible puede ser sustituida mientras se renderiza o exporta una diapositiva. Las advertencias de sustitución de fuentes se informan como `DataLoss`, por lo que la política estricta anterior aborta incluso si la aplicación consideraría aceptable visualmente una sustitución concreta. Para observar este comportamiento, use una presentación de entrada que contenga texto con una fuente no disponible en tiempo de ejecución. La descripción de la advertencia identifica la sustitución; configure las fuentes requeridas o [reglas de sustitución de fuentes](/slides/es/nodejs-java/font-substitution/) antes de volver a intentarlo.
- **Contenido no compatible o inesperado:** Un cargador puede encontrar registros o funcionalidades de la presentación que no reconoce. Tales advertencias pueden usar `UnexpectedContent`, o una categoría más severa cuando se sabe que los datos o el formato se ven afectados.
- **Compatibilidad de formato:** Guardar en otro formato de presentación puede omitir funcionalidades o producir un resultado que se comporte de manera diferente en algunas aplicaciones. Por ejemplo, guardar una presentación con más de ocho guías de dibujo horizontales o verticales en PPT heredado genera una `CompatibilityIssue`. El callback en la fase de guardado puede registrar la pérdida y continuar, o rechazarla si es necesario preservar todas las guías.
- **Comportamiento de carga:** Las opciones de carga y los comportamientos heredados también pueden generar advertencias. Por ejemplo, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifica el uso de un comportamiento de bloqueo de presentación obsoleto como una `CompatibilityIssue`.

Las advertencias dependen del documento de origen, el formato de destino, la operación y la versión de Aspose.Slides. No asuma que cada archivo produce una advertencia o que un escenario siempre se corresponda con una única categoría.

## **Gestionar operaciones abortadas de forma segura**

Cuando un callback devuelve `ReturnAction.Abort`, no utilice un objeto que no se haya cargado y no asuma que una salida de renderizado o guardado está completa. La operación puede terminar después de crear un archivo de salida pero antes de finalizarlo.

Guarde los resultados validados en una ruta separada como `validated-output.pptx`. Reemplace una presentación existente solo después de que la operación finalice con éxito, el informe de advertencias cumpla la política de la aplicación y la salida pueda abrirse y verificarse. Esto evita sobrescribir un archivo de origen válido con un resultado parcial o rechazado.

Un informe de advertencias vacío no es garantía de que cada característica de origen haya sido preservada. Aplique cualquier comprobación adicional de contenido y visual requerida por la aplicación. Vea también [Abrir presentaciones](/slides/es/nodejs-java/open-presentation/) y [Guardar presentaciones](/slides/es/nodejs-java/save-presentation/).

## **Preguntas frecuentes**

**¿Puede un callback de advertencia gestionar todos los errores de Aspose.Slides?**

No. Gestiona condiciones recuperables reportadas como advertencias. Las excepciones que ocurren independientemente del callback deben ser gestionadas por la aplicación alrededor de la llamada de carga, renderizado, conversión o guardado.

**¿El devolver `ReturnAction.Continue` garantiza una salida idéntica?**

No. Sólo permite que el procesamiento continúe. La condición reportada aún puede causar diferencias en datos, formato o compatibilidad, por lo que se deben revisar los tipos y descripciones de advertencia recopilados.

**¿Cómo puede una aplicación identificar la operación que produjo una advertencia?**

Cree una instancia de callback para cada operación y almacene una etapa definida por la aplicación junto con los valores devueltos por [getWarningType](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getWarningType--) y [getDescription](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getDescription--), como se muestra en el ejemplo.