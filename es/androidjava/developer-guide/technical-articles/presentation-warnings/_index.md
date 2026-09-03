---
title: Gestionar advertencias de presentaciones en Android
type: docs
weight: 90
url: /es/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Android
- Java
- Aspose.Slides
description: "Aprende a recopilar, clasificar y actuar sobre las advertencias al cargar, renderizar, convertir y guardar presentaciones con Aspose.Slides para Android mediante Java."
---
## **Visión general**

Aspose.Slides puede informar problemas recuperables mientras carga, renderiza, convierte o guarda una presentación. Los ejemplos incluyen registros de origen dañados, contenido que no puede preservarse, sustitución de fuentes y limitaciones de un formato de destino. Un callback de advertencia permite que una aplicación registre estas condiciones y decida si la operación actual puede continuar.

Implemente la [IWarningCallback](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iwarningcallback/) y examine los valores de [getWarningType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) y [getDescription](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) suministrados a través de [IWarningInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iwarninginfo/). Devuelva [ReturnAction.Continue](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/returnaction/#Continue) para aceptar la advertencia o [ReturnAction.Abort](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/returnaction/#Abort) para detener la operación.

Utilice [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) para las advertencias generadas al abrir una presentación. Las clases de opciones de renderizado y exportación heredan [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), que recibe advertencias del renderizado de diapositivas, la conversión y el guardado. Como la propia advertencia no identifica la operación de la aplicación, asocie cada instancia de callback con una etapa de operación cuando construya un informe combinado.

## **Advertencias y excepciones**

Una advertencia describe una condición de la que Aspose.Slides puede recuperarse si el callback devuelve `ReturnAction.Continue`. Una excepción indica que la operación solicitada no puede completarse normalmente; las excepciones no se convierten en advertencias y no pueden gestionarse mediante una política de advertencias.

Devolver `ReturnAction.Abort` pide al despachador de advertencias que termine la operación actual lanzando una excepción. La excepción pública depende de la operación y del formato de la presentación. Por ejemplo, la carga puede generar una [PptxReadException](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxreadexception/) o una [PptReadException](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptreadexception/), mientras que al guardar o exportar puede aparecer una [PptxException](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxexception/). Maneje la excepción en el límite de la operación y utilice el informe de advertencias para determinar si la política de la aplicación provocó la terminación en lugar de basarse en un subtipo de excepción o en el mensaje. El callback registra la advertencia antes de devolver `ReturnAction.Abort`, garantizando que la razón permanezca disponible para la aplicación.

## **Categorías de advertencias**

La clase [WarningType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/warningtype/) proporciona constantes enteras para las siguientes categorías:

| Tipo de advertencia | Significado | Política típica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | La presentación de origen contiene corrupción que puede hacer que un documento guardado en su formato original sea inutilizable. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/warningtype/#DataLoss) | Texto, gráficos, imágenes u otros datos pueden estar ausentes después de la carga o el guardado. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | La presentación puede perder un formato importante. | Abort en modo de validación estricta; de lo contrario registrar y continuar. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Puede producirse una diferencia de formato limitada. | Registrar para diagnóstico y continuar. |
| [CompatibilityIssue](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | El resultado puede no abrirse o comportarse correctamente en algunas aplicaciones o versiones antiguas. | Registrar y continuar a menos que la compatibilidad sea obligatoria. |
| [UnexpectedContent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | El origen contiene contenido no compatible o no reconocido cuyo efecto aún puede ser desconocido. | Registrar y continuar, o tratar como error en una política estricta. |

La categoría debe guiar la decisión de la política. Guarde el valor devuelto por [getDescription](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) para diagnóstico, pero no dependa de su redacción para la lógica de la aplicación, ya que el texto del mensaje puede variar entre escenarios de advertencia y versiones del producto.

## **Recopilar y clasificar advertencias**

El siguiente ejemplo utiliza un informe a nivel de aplicación para toda la canalización de procesamiento. Una instancia de callback separada etiqueta las advertencias provenientes de la carga, el renderizado, la conversión a PDF y el guardado en PPTX. La política aborta ante corrupción de origen o pérdida de datos, aborta opcionalmente ante una pérdida mayor de formato y continúa con el resto de advertencias.

Coloque `input.pptx` en un directorio de aplicación con permiso de escritura y pase ese directorio a `PresentationWarningExample.run`. El ejemplo guarda sus resultados en el mismo directorio. Ejecute el procesamiento de la presentación en un sub‑hilo para que la interfaz de usuario de Android permanezca receptiva.

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

Pasar `false` a `abortOnMajorFormattingLoss` al crear `WarningPolicy` si las diferencias mayores de formato son aceptables. Los problemas de compatibilidad, la pérdida menor de formato y el contenido inesperado siguen retenidos en el informe aunque la operación continúe. Amplíe `WarningPolicy.getAction` si la aplicación debe rechazar cualquiera de esas categorías.

## **Escenarios comunes de advertencias**

Las advertencias pueden aparecer en distintas etapas de un flujo de trabajo:

- **Firmas digitales:** Una presentación firmada puede generar una advertencia durante la carga indicando que su firma se perderá durante el procesamiento. Aspose.Slides informa esta condición `DataLoss` a través de [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Un callback en la fase de carga permite a la aplicación rechazar el archivo o aceptar explícitamente la pérdida reportada.
- **Sustitución de fuentes:** Una fuente no disponible puede ser reemplazada mientras se renderiza o exporta una diapositiva. Las advertencias de sustitución de fuentes se informan como `DataLoss`, por lo que la política estricta anterior aborta incluso si la aplicación consideraría aceptable un reemplazo visual concreto. Para observar este comportamiento, use una presentación de entrada que contenga texto en una fuente no disponible en tiempo de ejecución. La descripción de la advertencia identifica la sustitución; configure las fuentes necesarias o las [reglas de sustitución de fuentes](/slides/es/androidjava/font-substitution/) antes de reintentar.
- **Contenido no compatible o inesperado:** Un cargador puede encontrar registros o características de la presentación que no reconoce. Tales advertencias pueden usar `UnexpectedContent`, o una categoría más severa cuando se sabe que datos o formato se ven afectados.
- **Compatibilidad de formato:** Guardar en otro formato de presentación puede omitir características o producir un resultado que se comporte de forma distinta en algunas aplicaciones. Por ejemplo, guardar una presentación con más de ocho guías de dibujo horizontales o verticales en PPT heredado informa un `CompatibilityIssue`. El callback en la fase de guardado puede registrar la pérdida y continuar, o rechazarla si es necesario preservar todas las guías.
- **Comportamiento de carga:** Las opciones de carga y los comportamientos heredados también pueden generar advertencias. Por ejemplo, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifica el uso de un comportamiento de bloqueo de presentación obsoleto como un `CompatibilityIssue`.

Las advertencias dependen del documento de origen, del formato de destino, de la operación y de la versión de Aspose.Slides. No asuma que cada archivo genere una advertencia o que un escenario siempre se corresponda con una única categoría.

## **Manejar de forma segura operaciones abortadas**

Cuando un callback devuelve `ReturnAction.Abort`, no utilice un objeto que no se haya cargado y no asuma que la salida de renderizado o guardado está completa. La operación puede terminar después de crear un archivo de salida pero antes de finalizarlo.

Guarde los resultados validados en una ruta distinta, por ejemplo `validated-output.pptx`. Reemplace una presentación existente solo después de que la operación finalice correctamente, el informe de advertencias cumpla la política de la aplicación y la salida pueda abrirse y verificarse. Así se evita sobrescribir un archivo fuente válido con un resultado parcial o rechazado.

Un informe de advertencias vacío no garantiza que se haya preservado cada característica del origen. Aplique cualquier comprobación adicional de contenido y visual requerida por la aplicación. Consulte también [Open Presentations](/slides/es/androidjava/open-presentation/) y [Save Presentations](/slides/es/androidjava/save-presentation/).

## **Preguntas frecuentes**

**¿Puede un callback de advertencia manejar cualquier error de Aspose.Slides?**

No. Gestiona condiciones recuperables informadas como advertencias. Las excepciones que ocurran independientemente del callback deben ser manejadas por la aplicación alrededor de la llamada de carga, renderizado, conversión o guardado.

**¿Devolver `ReturnAction.Continue` garantiza una salida idéntica?**

No. Sólo permite que el procesamiento continúe. La condición reportada aún puede causar diferencias de datos, formato o compatibilidad, por lo que se deben revisar los tipos y descripciones de advertencias recopiladas.

**¿Cómo puede una aplicación identificar la operación que generó una advertencia?**

Cree una instancia de callback para cada operación y almacene una etapa definida por la aplicación junto con los valores devueltos por [getWarningType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) y [getDescription](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), como se muestra en el ejemplo.