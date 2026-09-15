---
title: Manejar advertencias de presentación en Python mediante Java
type: docs
weight: 90
url: /es/python-java/presentation-warnings/
aliases:
- /python-java/obtener-callbacks-de-advertencia-para-sustitucion-de-fuentes-en-aspose-slides/
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
- Python
- Java
- Aspose.Slides
description: "Aprenda a recopilar, clasificar y actuar sobre advertencias al cargar, renderizar, convertir y guardar presentaciones con Aspose.Slides para Python mediante Java."
---
## **Resumen**

Aspose.Slides puede informar problemas recuperables mientras carga, renderiza, convierte o guarda una presentación. Los ejemplos incluyen registros de origen dañados, contenido que no se puede preservar, sustitución de fuentes y limitaciones de un formato de destino. Una devolución de llamada de advertencia permite a una aplicación registrar estas condiciones y decidir si la operación actual puede continuar.

Implemente la interfaz `IWarningCallback` mediante `jpype.JProxy` y examine los valores `getWarningType` y `getDescription` suministrados a través de `IWarningInfo`. Devuelva [ReturnAction.Continue](https://reference.aspose.com/slides/es/python-java/aspose.slides/returnaction/#Continue) para aceptar la advertencia o [ReturnAction.Abort](https://reference.aspose.com/slides/es/python-java/aspose.slides/returnaction/#Abort) para detener la operación.

Utilice [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setWarningCallback) para advertencias generadas al abrir una presentación. Las clases de opciones de renderizado y exportación heredan [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveoptions/#setWarningCallback), que recibe advertencias del renderizado de diapositivas, la conversión y el guardado. Dado que la propia advertencia no identifica la operación de la aplicación, asocie cada instancia de callback con una fase de operación al crear un informe combinado.

## **Advertencias y Excepciones**

Una advertencia describe una condición de la que Aspose.Slides puede recuperarse si el callback devuelve `ReturnAction.Continue`. Una excepción significa que la operación solicitada no puede completarse normalmente; las excepciones no se convierten en advertencias y no pueden ser gestionadas por una política de advertencias.

Devolver `ReturnAction.Abort` solicita al despachador de advertencias que termine la operación actual lanzando una excepción. La excepción pública depende de la operación y del formato de la presentación. Por ejemplo, la carga puede generar una [PptxReadException](https://reference.aspose.com/slides/es/python-java/aspose.slides/pptxreadexception/) o [PptReadException](https://reference.aspose.com/slides/es/python-java/aspose.slides/pptreadexception/), mientras que al guardar o exportar puede aparecer una [PptxException](https://reference.aspose.com/slides/es/python-java/aspose.slides/pptxexception/). Maneje la excepción en el punto límite de la operación y utilice el informe de advertencias para determinar si la política de la aplicación provocó la terminación en lugar de depender de un subtipo o mensaje de excepción. El callback registra la advertencia antes de devolver `ReturnAction.Abort`, garantizando que la razón permanezca disponible para la aplicación.

## **Categorías de advertencia**

La clase [WarningType](https://reference.aspose.com/slides/es/python-java/aspose.slides/warningtype/) proporciona constantes enteras para las siguientes categorías:

| Tipo de advertencia | Significado | Política típica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/es/python-java/aspose.slides/warningtype/#SourceFileCorruption) | La presentación de origen contiene corrupción que puede hacer que un documento guardado en su formato original sea inutilizable. | Abort |
| [DataLoss](https://reference.aspose.com/slides/es/python-java/aspose.slides/warningtype/#DataLoss) | Pueden faltar texto, gráficos, imágenes u otros datos después de cargar o guardar. | Abort |
| [MajorFormattingLoss](https://reference.aspose.com/slides/es/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | La presentación puede perder formato importante. | Abortar en modo de validación estricto; de lo contrario registrar y continuar |
| [MinorFormattingLoss](https://reference.aspose.com/slides/es/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Puede producirse una diferencia de formato limitada. | Registrar para diagnóstico y continuar |
| [CompatibilityIssue](https://reference.aspose.com/slides/es/python-java/aspose.slides/warningtype/#CompatibilityIssue) | El resultado puede no abrirse o comportarse correctamente en algunas aplicaciones o versiones antiguas. | Registrar y continuar a menos que la compatibilidad sea obligatoria |
| [UnexpectedContent](https://reference.aspose.com/slides/es/python-java/aspose.slides/warningtype/#UnexpectedContent) | La fuente contiene contenido no compatible o no reconocido cuyo efecto aún puede ser desconocido. | Registrar y continuar, o tratar como error en una política estricta |

La categoría debe guiar la decisión de política. Almacene el valor devuelto por `getDescription` para diagnóstico, pero no dependa de su redacción para la lógica de la aplicación, ya que el texto del mensaje puede variar entre escenarios de advertencia y versiones del producto.

## **Recopilar y clasificar advertencias**

El siguiente ejemplo usa un informe a nivel de aplicación para todo el pipeline de procesamiento. Una instancia de callback separada etiqueta las advertencias de carga, renderizado, conversión a PDF y guardado en PPTX. La política aborta ante corrupción de origen o pérdida de datos, opcionalmente aborta ante pérdida mayor de formato y continúa para el resto de advertencias.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Pase `False` para `abort_on_major_formatting_loss` al crear `WarningPolicy` si las diferencias mayores de formato son aceptables. Los problemas de compatibilidad, la pérdida menor de formato y el contenido inesperado siguen retenidos en el informe incluso cuando la operación continúa. Amplíe `WarningPolicy.get_action` si la aplicación debe rechazar alguna de esas categorías.

## **Escenarios comunes de advertencia**

Las advertencias pueden aparecer en diferentes etapas de un flujo de trabajo:

- **Firmas digitales:** Una presentación firmada puede generar una advertencia durante la carga indicando que su firma se perderá durante el procesamiento. Aspose.Slides informa esta condición `DataLoss` a través de `IPresentationSignedWarningInfo`. Un callback en la fase de carga permite a la aplicación rechazar el archivo o aceptar explícitamente la pérdida reportada.
- **Sustitución de fuentes:** Una fuente no disponible puede ser reemplazada mientras se renderiza o exporta una diapositiva. Las advertencias de sustitución de fuentes se informan como `DataLoss`, por lo que la política estricta anterior aborta incluso si la aplicación consideraría aceptable visualmente un reemplazo concreto. Para observar este comportamiento, use una presentación de entrada que contenga texto en una fuente no disponible para el entorno de ejecución. La descripción de la advertencia identifica la sustitución; configure las fuentes necesarias o [font substitution rules](/slides/es/python-java/font-substitution/) antes de reintentar.
- **Contenido no compatible o inesperado:** Un cargador puede encontrarse con registros o características de la presentación que no reconoce. Tales advertencias pueden usar `UnexpectedContent`, o una categoría más severa cuando se sabe que los datos o el formato están afectados.
- **Compatibilidad de formato:** Guardar en otro formato de presentación puede omitir características o producir un resultado que se comporte de forma distinta en algunas aplicaciones. Por ejemplo, guardar una presentación con más de ocho guías de dibujo horizontales o verticales en un PPT heredado genera un `CompatibilityIssue`. El callback en la fase de guardado puede registrar la pérdida y continuar, o rechazarla si es necesario preservar todas las guías.
- **Comportamiento de carga:** Las opciones de carga y los comportamientos heredados también pueden generar advertencias. Por ejemplo, `IObsoletePresLockingBehaviorWarningInfo` identifica el uso de un comportamiento de bloqueo de presentación obsoleto como un `CompatibilityIssue`.

Las advertencias dependen del documento de origen, del formato de destino, de la operación y de la versión de Aspose.Slides. No asuma que cada archivo genera una advertencia o que un escenario siempre se asocie a una única categoría.

## **Manejar operaciones abortadas de forma segura**

Cuando un callback devuelve `ReturnAction.Abort`, no use un objeto que no se haya cargado y no asuma que la salida de renderizado o guardado está completa. La operación puede terminar después de crear un archivo de salida pero antes de finalizarlo.

Guarde los resultados validados en una ruta separada, como `validated-output.pptx`. Reemplace una presentación existente solo después de que la operación finalice con éxito, el informe de advertencias cumpla la política de la aplicación y la salida pueda abrirse y verificarse. Así se evita sobrescribir un archivo de origen válido con un resultado parcial o rechazado.

Un informe de advertencias vacío no garantiza que se haya conservado cada característica del origen. Aplique las comprobaciones de contenido y visuales adicionales requeridas por la aplicación. Consulte también [Open Presentations](/slides/es/python-java/open-presentation/) y [Save Presentations](/slides/es/python-java/save-presentation/).

## **Preguntas frecuentes**

**¿Puede una devolución de llamada de advertencia manejar todos los errores de Aspose.Slides?**

No. Gestiona condiciones recuperables reportadas como advertencias. Las excepciones que ocurren independientemente del callback deben ser manejadas por la aplicación alrededor de la llamada de carga, renderizado, conversión o guardado.

**¿El devolver `ReturnAction.Continue` garantiza una salida idéntica?**

No. Solo permite que el procesamiento continúe. La condición reportada puede seguir provocando diferencias en datos, formato o compatibilidad, por lo que es necesario revisar los tipos y descripciones de advertencia recopilados.

**¿Cómo puede una aplicación identificar la operación que produjo una advertencia?**

Cree una instancia de callback para cada operación y almacene una fase definida por la aplicación junto con los valores devueltos por `getWarningType` y `getDescription`, como se muestra en el ejemplo.