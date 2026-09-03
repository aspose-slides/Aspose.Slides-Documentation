---
title: Gestionar advertencias de presentaciones en Java
type: docs
weight: 90
url: /es/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Java
- Aspose.Slides
description: "Aprenda a recopilar, clasificar y actuar sobre las advertencias al cargar, renderizar, convertir y guardar presentaciones con Aspose.Slides para Java."
---
## **Visión general**

Aspose.Slides puede informar de problemas recuperables mientras carga, renderiza, convierte o guarda una presentación. Los ejemplos incluyen registros de origen dañados, contenido que no se puede conservar, sustitución de fuentes y limitaciones del formato de destino. Un callback de advertencia permite a una aplicación registrar estas condiciones y decidir si la operación actual puede continuar.

Implemente la [IWarningCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarningcallback/) interface y examine los valores devueltos por [getWarningType](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getWarningType--) y [getDescription](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getDescription--) a través de [IWarningInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/). Devuelva [ReturnAction.Continue](https://reference.aspose.com/slides/es/java/com.aspose.slides/returnaction/#Continue) para aceptar la advertencia o [ReturnAction.Abort](https://reference.aspose.com/slides/es/java/com.aspose.slides/returnaction/#Abort) para detener la operación.

Utilice [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) para las advertencias que se generan al abrir una presentación. Las clases de opciones de renderizado y exportación heredan [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), que recibe advertencias del renderizado de diapositivas, la conversión y el guardado. Dado que la propia advertencia no identifica la operación de la aplicación, asocie cada instancia de callback con una etapa de operación cuando construya un informe combinado.

## **Advertencias y excepciones**

Una advertencia describe una condición de la que Aspose.Slides puede recuperarse si el callback devuelve `ReturnAction.Continue`. Una excepción indica que la operación solicitada no puede completarse normalmente; las excepciones no se convierten en advertencias y no pueden ser gestionadas por una política de advertencias.

Devolver `ReturnAction.Abort` solicita al despachador de advertencias que termine la operación actual lanzando una excepción. La excepción pública depende de la operación y del formato de la presentación. Por ejemplo, al cargar puede aparecer una [PptxReadException](https://reference.aspose.com/slides/es/java/com.aspose.slides/pptxreadexception/) o [PptReadException](https://reference.aspose.com/slides/es/java/com.aspose.slides/pptreadexception/), mientras que al guardar o exportar puede aparecer una [PptxException](https://reference.aspose.com/slides/es/java/com.aspose.slides/pptxexception/). Maneje la excepción en el límite de la operación y use el informe de advertencias para determinar si la política de la aplicación provocó la terminación en lugar de basarse en un subtipo de excepción o mensaje. El callback registra la advertencia antes de devolver `ReturnAction.Abort`, asegurando que la razón siga estando disponible para la aplicación.

## **Categorías de advertencia**

La clase [WarningType](https://reference.aspose.com/slides/es/java/com.aspose.slides/warningtype/) proporciona constantes enteras para las siguientes categorías:

| Tipo de advertencia | Significado | Política típica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/es/java/com.aspose.slides/warningtype/#SourceFileCorruption) | La presentación de origen contiene corrupción que puede hacer que un documento guardado en su formato original sea inutilizable. | Abort |
| [DataLoss](https://reference.aspose.com/slides/es/java/com.aspose.slides/warningtype/#DataLoss) | El texto, los gráficos, las imágenes u otros datos pueden estar ausentes después de cargar o guardar. | Abort |
| [MajorFormattingLoss](https://reference.aspose.com/slides/es/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | La presentación puede perder un formato importante. | Abort en modo de validación estricta; de lo contrario, registrar y continuar |
| [MinorFormattingLoss](https://reference.aspose.com/slides/es/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Puede ocurrir una diferencia de formato limitada. | Registrar para diagnóstico y continuar |
| [CompatibilityIssue](https://reference.aspose.com/slides/es/java/com.aspose.slides/warningtype/#CompatibilityIssue) | El resultado puede no abrirse o comportarse correctamente en algunas aplicaciones o versiones antiguas. | Registrar y continuar a menos que la compatibilidad sea obligatoria |
| [UnexpectedContent](https://reference.aspose.com/slides/es/java/com.aspose.slides/warningtype/#UnexpectedContent) | El origen contiene contenido no soportado o no reconocido cuyo efecto aún puede ser desconocido. | Registrar y continuar, o tratar como error en una política estricta |

La categoría debe guiar la decisión de la política. Guarde el valor devuelto por [getDescription](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getDescription--) para diagnóstico, pero no dependa de su redacción para la lógica de la aplicación porque el texto del mensaje puede variar entre escenarios de advertencia y versiones del producto.

## **Recopilar y clasificar advertencias**

El siguiente ejemplo usa un informe a nivel de aplicación para toda la canalización de procesamiento. Una instancia de callback separada etiqueta las advertencias de carga, renderizado, conversión a PDF y guardado de PPTX. La política aborta ante corrupción de origen o pérdida de datos, aborta opcionalmente ante pérdida mayor de formato y continúa para otras advertencias.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

Pase `false` a `abortOnMajorFormattingLoss` al crear `WarningPolicy` si las diferencias mayores de formato son aceptables. Los problemas de compatibilidad, la pérdida menor de formato y el contenido inesperado siguen presentes en el informe aunque la operación continúe. Amplíe `WarningPolicy.getAction` si la aplicación debe rechazar cualquiera de esas categorías.

## **Escenarios comunes de advertencia**

Las advertencias pueden aparecer en diferentes etapas de un flujo de trabajo:

- **Firmas digitales:** Una presentación firmada puede generar una advertencia durante la carga indicando que su firma se perderá durante el procesamiento. Aspose.Slides informa de esta condición `DataLoss` a través de [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentationsignedwarninginfo/). Un callback en la etapa de carga permite a la aplicación rechazar el archivo o aceptar explícitamente la pérdida informada.
- **Sustitución de fuentes:** Una fuente no disponible puede ser reemplazada mientras se renderiza o exporta una diapositiva. Las advertencias de sustitución de fuentes se informan como `DataLoss`, por lo que la política estricta anterior aborta incluso si la aplicación consideraría aceptable visualmente un reemplazo concreto. Para observar este comportamiento, use una presentación de entrada que contenga texto con una fuente no disponible en tiempo de ejecución. La descripción de la advertencia identifica la sustitución; configure las fuentes necesarias o [font substitution rules](/slides/es/java/font-substitution/) antes de reintentar.
- **Contenido no soportado o inesperado:** Un cargador puede encontrar registros o funciones de la presentación que no reconoce. Tales advertencias pueden usar `UnexpectedContent`, o una categoría más severa cuando se sabe que los datos o el formato se ven afectados.
- **Compatibilidad de formato:** Guardar a otro formato de presentación puede omitir funciones o producir un resultado que se comporte de forma diferente en algunas aplicaciones. Por ejemplo, guardar una presentación con más de ocho guías de dibujo horizontales o verticales en un PPT heredado reporta un `CompatibilityIssue`. El callback en la etapa de guardado puede registrar la pérdida y continuar, o rechazarla si es necesario conservar todas las guías.
- **Comportamiento de carga:** Las opciones de carga y comportamientos heredados también pueden generar advertencias. Por ejemplo, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/es/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifica el uso de un comportamiento obsoleto de bloqueo de presentación como un `CompatibilityIssue`.

Las advertencias dependen del documento de origen, del formato de destino, de la operación y de la versión de Aspose.Slides. No asuma que cada archivo genera una advertencia o que un escenario siempre se corresponda con una única categoría.

## **Gestionar de forma segura operaciones abortadas**

Cuando un callback devuelve `ReturnAction.Abort`, no utilice un objeto que no se haya cargado y no asuma que una salida de renderizado o guardado está completa. La operación puede terminar después de crear un archivo de salida pero antes de finalizarlo.

Guarde los resultados validados en una ruta distinta, como `validated-output.pptx`. Reemplace una presentación existente solo después de que la operación finalice con éxito, el informe de advertencias cumpla la política de la aplicación y la salida pueda abrirse y verificarse. Esto evita sobrescribir un archivo de origen válido con un resultado parcial o rechazado.

Un informe de advertencias vacío no garantiza que se haya conservado cada característica del origen. Aplique cualquier comprobación de contenido y visual adicional requerida por la aplicación. Véase también [Open Presentations](/slides/es/java/open-presentation/) y [Save Presentations](/slides/es/java/save-presentation/).

## **Preguntas frecuentes**

**¿Puede un callback de advertencia manejar todos los errores de Aspose.Slides?**

No. Gestiona condiciones recuperables que se informan como advertencias. Las excepciones que ocurren independientemente del callback deben ser gestionadas por la aplicación alrededor de la llamada de carga, renderizado, conversión o guardado.

**¿El hecho de devolver `ReturnAction.Continue` garantiza una salida idéntica?**

No. Solo permite que el procesamiento continúe. La condición informada aún puede causar diferencias en datos, formato o compatibilidad, por lo que se deben revisar los tipos y descripciones de las advertencias recopiladas.

**¿Cómo puede una aplicación identificar la operación que produjo una advertencia?**

Cree una instancia de callback para cada operación y almacene una etapa definida por la aplicación junto con los valores devueltos por [getWarningType](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getWarningType--) y [getDescription](https://reference.aspose.com/slides/es/java/com.aspose.slides/iwarninginfo/#getDescription--), como se muestra en el ejemplo.