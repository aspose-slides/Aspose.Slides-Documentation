---
title: Gestionar advertencias de presentación en .NET
type: docs
weight: 120
url: /es/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback de advertencia
- política de advertencias
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
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo recopilar, clasificar y actuar sobre las advertencias al cargar, renderizar, convertir y guardar presentaciones con Aspose.Slides para .NET."
---
## **Descripción general**

Aspose.Slides puede informar problemas recuperables mientras carga, renderiza, convierte o guarda una presentación. Los ejemplos incluyen registros de origen dañados, contenido que no puede preservarse, sustitución de fuentes y limitaciones de un formato de destino. Un callback de advertencia permite a una aplicación registrar estas condiciones y decidir si la operación actual puede continuar.

Implemente la [IWarningCallback](https://reference.aspose.com/slides/es/net/aspose.slides.warnings/iwarningcallback/) y examine las propiedades [WarningType](https://reference.aspose.com/slides/es/net/aspose.slides.warnings/iwarninginfo/warningtype/) y [Description](https://reference.aspose.com/slides/es/net/aspose.slides.warnings/iwarninginfo/description/) suministradas a través de [IWarningInfo](https://reference.aspose.com/slides/es/net/aspose.slides.warnings/iwarninginfo/). Devuelva [ReturnAction.Continue](https://reference.aspose.com/slides/es/net/aspose.slides.warnings/returnaction/) para aceptar la advertencia o `ReturnAction.Abort` para detener la operación.

Utilice [LoadOptions.WarningCallback](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/warningcallback/) para las advertencias generadas al abrir una presentación. Las clases de opciones de renderizado y exportación heredan de [SaveOptions.WarningCallback](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveoptions/warningcallback/), que recibe advertencias del renderizado de diapositivas, la conversión y el guardado. Dado que la propia advertencia no identifica la operación de la aplicación, asocie cada instancia de callback con una fase de la operación cuando construya un informe combinado.

## **Advertencias y excepciones**

Una advertencia describe una condición de la que Aspose.Slides puede recuperarse si el callback devuelve `ReturnAction.Continue`. Una excepción indica que la operación solicitada no puede completarse normalmente; las excepciones no se convierten en advertencias y no pueden ser gestionadas mediante una política de advertencias.

Devolver `ReturnAction.Abort` solicita al despachador de advertencias que termine la operación actual lanzando una excepción. La excepción pública depende de la operación y del formato de la presentación. Por ejemplo, al cargar puede aparecer una [PptxReadException](https://reference.aspose.com/slides/es/net/aspose.slides/pptxreadexception/) o [PptReadException](https://reference.aspose.com/slides/es/net/aspose.slides/pptreadexception/), mientras que al guardar o exportar puede aparecer una [PptxException](https://reference.aspose.com/slides/es/net/aspose.slides/pptxexception/). Maneje la excepción en el límite de la operación y utilice el informe de advertencias para determinar si la política de la aplicación causó la terminación en lugar de depender de un subtipo o mensaje de excepción. El callback registra la advertencia antes de devolver `ReturnAction.Abort`, asegurando que el motivo siga disponible para la aplicación.

## **Categorías de advertencias**

La enumeración [WarningType](https://reference.aspose.com/slides/es/net/aspose.slides.warnings/warningtype/) proporciona las siguientes categorías:

| Tipo de advertencia | Significado | Política típica |
| --- | --- | --- |
| `SourceFileCorruption` | La presentación de origen contiene corrupción que puede hacer que un documento guardado en su formato original sea inutilizable. | Abort. |
| `DataLoss` | Texto, gráficos, imágenes u otros datos pueden estar ausentes después de cargar o guardar. | Abort. |
| `MajorFormattingLoss` | La presentación puede perder un formato importante. | Abort en modo de validación estricta; de lo contrario registrar y continuar. |
| `MinorFormattingLoss` | Puede producirse una diferencia de formato limitada. | Registrar para diagnóstico y continuar. |
| `CompatibilityIssue` | El resultado puede no abrirse o comportarse correctamente en algunas aplicaciones o versiones anteriores. | Registrar y continuar a menos que la compatibilidad sea obligatoria. |
| `UnexpectedContent` | El origen contiene contenido no compatible o no reconocido cuyo efecto aún puede ser desconocido. | Registrar y continuar, o tratar como error en una política estricta. |

La categoría debe guiar la decisión de la política. Almacene `Description` para diagnóstico, pero no dependa de su redacción para la lógica de la aplicación porque el texto del mensaje puede variar entre escenarios de advertencia y versiones del producto.

## **Recopilar y clasificar advertencias**

El siguiente ejemplo utiliza un informe a nivel de aplicación para toda la cadena de procesamiento. Una instancia de callback distinta etiqueta las advertencias de carga, renderizado, conversión a PDF y guardado en PPTX. La política aborta ante corrupción de origen o pérdida de datos, opcionalmente aborta ante pérdida importante de formato y continúa para el resto de advertencias.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Establezca `abortOnMajorFormattingLoss` a `false` cuando las diferencias importantes de formato sean aceptables. Los problemas de compatibilidad, la pérdida menor de formato y el contenido inesperado siguen retenidos en el informe aun cuando la operación continúe. Amplíe `WarningPolicy.GetAction` si la aplicación debe rechazar alguna de esas categorías.

## **Escenarios comunes de advertencias**

Las advertencias pueden aparecer en distintas fases de un flujo de trabajo:

- **Firmas digitales:** Una presentación firmada puede generar una advertencia durante la carga indicando que su firma se perderá durante el procesamiento. Aspose.Slides informa esta condición `DataLoss` a través de [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/es/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Un callback en la fase de carga permite a la aplicación rechazar el archivo o aceptar explícitamente la pérdida informada.
- **Sustitución de fuentes:** Una fuente no disponible puede ser reemplazada mientras se renderiza o exporta una diapositiva. Las advertencias de sustitución de fuentes se informan como `DataLoss`, por lo que la política estricta anterior aborta incluso si la aplicación consideraría aceptable un reemplazo visual particular. Para observar este comportamiento, utilice una presentación de entrada que contenga texto con una fuente no disponible en tiempo de ejecución. La descripción de la advertencia identifica la sustitución; configure las fuentes necesarias o las [font substitution rules](/slides/es/net/font-substitution/) antes de reintentar.
- **Contenido no compatible o inesperado:** El cargador puede encontrarse con registros o características de la presentación que no reconoce. Tales advertencias pueden usar `UnexpectedContent`, o una categoría más severa cuando se sabe que los datos o el formato se ven afectados.
- **Compatibilidad de formato:** Guardar en otro formato de presentación puede omitir características o producir un resultado que se comporte de manera diferente en algunas aplicaciones. Por ejemplo, guardar una presentación con más de ocho guías de dibujo horizontales o verticales en un PPT heredado reporta un `CompatibilityIssue`. El callback en la fase de guardado puede registrar la pérdida y continuar, o rechazarla si es necesario preservar todas las guías.
- **Comportamiento de carga:** Las opciones de carga y los comportamientos heredados también pueden generar advertencias. Por ejemplo, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/es/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identifica el uso de un comportamiento de bloqueo de presentación obsoleto como un `CompatibilityIssue`.

Las advertencias dependen del documento de origen, del formato de destino, de la operación y de la versión de Aspose.Slides. No asuma que cada archivo genere una advertencia o que un escenario siempre se corresponda con una única categoría.

## **Manejo seguro de operaciones abortadas**

Cuando un callback devuelve `ReturnAction.Abort`, no utilice un objeto que no se haya cargado y no asuma que una salida de renderizado o guardado esté completa. La operación puede terminar después de crear un archivo de salida pero antes de finalizarlo.

Guarde los resultados validados en una ruta independiente, por ejemplo `validated-output.pptx`. Reemplace una presentación existente solo después de que la operación finalice con éxito, el informe de advertencias cumpla la política de la aplicación y la salida pueda abrirse y verificarse. Esto evita sobrescribir un archivo de origen válido con un resultado parcial o rechazado.

Un informe de advertencias vacío no garantiza que cada característica del origen haya sido preservada. Aplique cualquier comprobación adicional de contenido y visual requerida por la aplicación. Vea también [Open Presentations](/slides/es/net/open-presentation/) y [Save Presentations](/slides/es/net/save-presentation/).

## **Preguntas frecuentes**

**¿Puede un callback de advertencia gestionar todos los errores de Aspose.Slides?**

No. Gestiona condiciones recuperables reportadas como advertencias. Las excepciones que ocurren independientemente del callback deben ser manejadas por la aplicación alrededor de la llamada de carga, renderizado, conversión o guardado.

**¿Garantiza devolver `ReturnAction.Continue` una salida idéntica?**

No. Solo permite que el procesamiento continúe. La condición informada aún puede provocar diferencias de datos, formato o compatibilidad, por lo que es necesario revisar los tipos y descripciones de las advertencias recopiladas.

**¿Cómo puede una aplicación identificar la operación que produjo una advertencia?**

Cree una instancia de callback para cada operación y almacene una fase definida por la aplicación junto con `WarningType` y `Description`, como se muestra en el ejemplo.