---
title: "Gestionar advertencias de presentación en C++"
type: docs
weight: 70
url: /es/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- devolución de llamada de advertencia
- política de advertencias
- pérdida de datos
- corrupción del origen
- problema de compatibilidad
- sustitución de fuentes
- firma digital
- carga de presentación
- renderizado de presentación
- conversión de presentación
- guardado de presentación
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Aprenda cómo recopilar, clasificar y actuar sobre las advertencias al cargar, renderizar, convertir y guardar presentaciones con Aspose.Slides para C++."
---
## **Descripción general**

Aspose.Slides puede informar problemas recuperables mientras carga, renderiza, convierte o guarda una presentación. Los ejemplos incluyen registros de origen dañados, contenido que no puede preservarse, sustitución de fuentes y limitaciones del formato de destino. Una devolución de llamada de advertencia permite a una aplicación registrar estas condiciones y decidir si la operación actual puede continuar.

Implemente la interfaz [IWarningCallback](https://reference.aspose.com/slides/es/cpp/aspose.slides.warnings/iwarningcallback/) y examine los métodos [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/es/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) y [IWarningInfo::get_Description](https://reference.aspose.com/slides/es/cpp/aspose.slides.warnings/iwarninginfo/get_description/) proporcionados a través de [IWarningInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides.warnings/iwarninginfo/). Devuelva [ReturnAction::Continue](https://reference.aspose.com/slides/es/cpp/aspose.slides.warnings/returnaction/) para aceptar la advertencia o `ReturnAction::Abort` para detener la operación.

Utilice [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_warningcallback/) para las advertencias generadas al abrir una presentación. Las clases de opciones de renderizado y exportación heredan [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveoptions/set_warningcallback/), que recibe advertencias del renderizado de diapositivas, la conversión y el guardado. Dado que la propia advertencia no identifica la operación de la aplicación, asocie cada instancia de devolución de llamada con una etapa de operación al crear un informe combinado.

## **Advertencias y excepciones**

Una advertencia describe una condición de la que Aspose.Slides puede recuperarse si la devolución de llamada devuelve `ReturnAction::Continue`. Una excepción indica que la operación solicitada no puede completarse normalmente; las excepciones no se convierten en advertencias y no pueden ser manejadas por una política de advertencias.

Devolver `ReturnAction::Abort` solicita al despachador de advertencias que termine la operación actual lanzando una excepción. La excepción pública depende de la operación y del formato de la presentación. Por ejemplo, la carga puede generar una [PptxReadException](https://reference.aspose.com/slides/es/cpp/aspose.slides/pptxreadexception/) o una [PptReadException](https://reference.aspose.com/slides/es/cpp/aspose.slides/pptreadexception/), mientras que al guardar o exportar puede generarse una [PptxException](https://reference.aspose.com/slides/es/cpp/aspose.slides/pptxexception/). Maneje la excepción en el límite de la operación y utilice el informe de advertencias para determinar si la política de la aplicación provocó la terminación, en lugar de depender de un subtipo o mensaje de excepción. La devolución de llamada registra la advertencia antes de devolver `ReturnAction::Abort`, garantizando que la razón permanezca disponible para la aplicación.

## **Categorías de advertencia**

La enumeración [WarningType](https://reference.aspose.com/slides/es/cpp/aspose.slides.warnings/warningtype/) proporciona las siguientes categorías:

| Tipo de advertencia | Significado | Política típica |
| --- | --- | --- |
| `SourceFileCorruption` | La presentación de origen contiene corrupción que puede hacer que un documento guardado en su formato original sea inutilizable. | Abort |
| `DataLoss` | Texto, gráficos, imágenes u otros datos pueden estar ausentes después de la carga o el guardado. | Abort |
| `MajorFormattingLoss` | La presentación puede perder formato importante. | Abortar en modo de validación estricta; de lo contrario registrar y continuar |
| `MinorFormattingLoss` | Puede producirse una diferencia limitada de formato. | Registrar para diagnóstico y continuar |
| `CompatibilityIssue` | El resultado puede no abrirse o comportarse correctamente en algunas aplicaciones o versiones antiguas. | Registrar y continuar a menos que la compatibilidad sea obligatoria |
| `UnexpectedContent` | El origen contiene contenido no compatible o no reconocido cuyo efecto aún puede ser desconocido. | Registrar y continuar, o tratar como error en una política estricta |

La categoría debe guiar la decisión de política. Guarde la descripción de la advertencia para diagnóstico, pero no dependa de su redacción para la lógica de la aplicación, ya que el texto del mensaje puede variar entre escenarios de advertencia y versiones del producto.

## **Recopilar y clasificar advertencias**

El siguiente ejemplo utiliza un informe a nivel de aplicación para toda la cadena de procesamiento. Una instancia de devolución de llamada separada etiqueta las advertencias de carga, renderizado, conversión a PDF y guardado de PPTX. La política aborta ante corrupción de origen o pérdida de datos, opcionalmente aborta ante pérdida importante de formato y continúa para otras advertencias.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

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
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Establezca `abortOnMajorFormattingLoss` a `false` cuando las diferencias importantes de formato sean aceptables. Los problemas de compatibilidad, la pérdida menor de formato y el contenido inesperado siguen presentes en el informe incluso cuando la operación continúa. Amplíe `WarningPolicy::GetAction` si la aplicación debe rechazar cualquiera de esas categorías.

## **Escenarios comunes de advertencias**

Las advertencias pueden aparecer en diferentes etapas de un flujo de trabajo:

- **Firmas digitales:** Una presentación firmada puede generar una advertencia durante la carga indicando que su firma se perderá durante el procesamiento. Aspose.Slides informa esta condición `DataLoss` a través de [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). Una devolución de llamada en la fase de carga permite a la aplicación rechazar el archivo o aceptar explícitamente la pérdida informada.
- **Sustitución de fuentes:** Una fuente no disponible puede ser reemplazada mientras se renderiza o exporta una diapositiva. Las advertencias de sustitución de fuentes se informan como `DataLoss`, por lo que la política estricta anterior aborta incluso si la aplicación consideraría aceptable visualmente un reemplazo concreto. Para observar este comportamiento, use una presentación de entrada que contenga texto con una fuente no disponible en tiempo de ejecución. La descripción de la advertencia identifica la sustitución; configure las fuentes necesarias o [reglas de sustitución de fuentes](/slides/es/cpp/font-substitution/) antes de reintentar.
- **Contenido no compatible o inesperado:** Un cargador puede encontrar registros o características de la presentación que no reconoce. Tales advertencias pueden usar `UnexpectedContent`, o una categoría más severa cuando se sabe que los datos o el formato se ven afectados.
- **Compatibilidad de formato:** Guardar en otro formato de presentación puede omitir características o producir un resultado que se comporte de forma diferente en algunas aplicaciones. Por ejemplo, guardar una presentación con más de ocho guías de dibujo horizontales o verticales en un PPT heredado genera un `CompatibilityIssue`. La devolución de llamada en la fase de guardado puede registrar la pérdida y continuar, o rechazarla si se requiere preservar todas las guías.
- **Comportamiento de carga:** Las opciones de carga y los comportamientos heredados también pueden generar advertencias. Por ejemplo, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identifica el uso de un comportamiento obsoleto de bloqueo de presentación como un `CompatibilityIssue`.

Las advertencias dependen del documento de origen, el formato de destino, la operación y la versión de Aspose.Slides. No asuma que cada archivo genera una advertencia o que un escenario siempre se corresponda con una única categoría.

## **Gestionar de forma segura operaciones abortadas**

Cuando una devolución de llamada devuelve `ReturnAction::Abort`, no utilice un objeto que no se haya cargado y no asuma que una salida de renderizado o guardado esté completa. La operación puede terminar después de crear un archivo de salida pero antes de finalizarlo.

Guarde los resultados validados en una ruta separada, como `validated-output.pptx`. Reemplace una presentación existente solo después de que la operación finalice con éxito, el informe de advertencias cumpla la política de la aplicación y la salida pueda abrirse y verificarse. Esto evita sobrescribir un archivo de origen válido con un resultado parcial o rechazado.

Un informe de advertencias vacío no garantiza que se haya conservado cada característica del origen. Aplique cualquier comprobación de contenido y visual adicional requerida por la aplicación. Consulte también [Abrir presentaciones](/slides/es/cpp/open-presentation/) y [Guardar presentaciones](/slides/es/cpp/save-presentation/).

## **Preguntas frecuentes**

**¿Puede una devolución de llamada de advertencia manejar todos los errores de Aspose.Slides?**

No. Maneja condiciones recuperables reportadas como advertencias. Las excepciones que ocurren independientemente de la devolución de llamada deben ser gestionadas por la aplicación alrededor de la llamada de carga, renderizado, conversión o guardado.

**¿Devuelve `ReturnAction::Continue` garantiza una salida idéntica?**

No. Solo permite que el procesamiento continúe. La condición reportada aún puede causar diferencias en datos, formato o compatibilidad, por lo que debe revisar los tipos y descripciones de advertencias recogidas.

**¿Cómo puede una aplicación identificar la operación que generó una advertencia?**

Cree una instancia de devolución de llamada para cada operación y almacene una etapa definida por la aplicación junto con el tipo y la descripción de la advertencia, como se muestra en el ejemplo.