---
title: Administrar etiquetas de sensibilidad en presentaciones de PowerPoint en Python
linktitle: Etiquetas de sensibilidad
type: docs
weight: 50
url: /es/python-java/sensitivity-labels/
keywords:
- etiqueta de sensibilidad
- Microsoft Purview
- Microsoft Information Protection
- metadatos MIP
- marcado de contenido
- protección de la información
- gobernanza de documentos
- PowerPoint
- PPTX
- seguridad de presentaciones
- Python
- Aspose.Slides
description: "Leer, añadir, actualizar, eliminar y migrar etiquetas de sensibilidad de Microsoft Purview en presentaciones PPTX de PowerPoint con Aspose.Slides para Python a través de Java."
---
## **Visión general**

Las etiquetas de sensibilidad de Microsoft Purview ayudan a las organizaciones a clasificar y gobernar documentos. Durante el procesamiento automatizado de presentaciones, una aplicación puede necesitar conservar una etiqueta existente, aplicar una etiqueta seleccionada por una política, actualizar su estado o migrar los metadatos de etiqueta escritos por un flujo de trabajo anterior de Microsoft Information Protection (MIP).

Aspose.Slides expone los metadatos de etiquetas de sensibilidad modernas a través de [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSensitivityLabels). Este método devuelve una [SensitivityLabelCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcollection/) que puede inspeccionarse y modificarse antes de guardar la presentación como PPTX.

{{% alert color="info" title="Nota" %}}

Los identificadores de etiquetas y la información de política están definidos por la configuración de Microsoft Purview. Valide la disponibilidad de etiquetas y los requisitos de política en su entorno antes de añadir o migrar metadatos. Los valores de [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) describen los marcados de contenido asociados a una etiqueta; por sí mismos no añaden texto visible ni formas a las diapositivas.

{{% /alert %}}

## **Comprender las propiedades de la etiqueta de sensibilidad**

Cada [SensitivityLabel](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/) contiene los siguientes metadatos:

| Métodos | Propósito |
| --- | --- |
| [getId](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#getId) y [setId](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#setId) | Obtiene o establece el identificador de la etiqueta de sensibilidad en la política de Purview. |
| [getSiteId](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#getSiteId) y [setSiteId](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Obtiene o establece el sitio asociado a la política de la etiqueta. |
| [isEnabled](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#isEnabled) y [setEnabled](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Obtiene o establece si la etiqueta está habilitada. |
| [isRemoved](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#isRemoved) y [setRemoved](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Obtiene o establece si la etiqueta ha sido eliminada. Establezca el valor a `True` cuando el estado de eliminación deba conservarse en los metadatos. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) y [setAssignmentMethodType](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Obtiene o establece si la etiqueta se aplicó automáticamente o mediante una decisión del usuario. |
| [getContentMarkTypes](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Obtiene los tipos de marcados de contenido asociados a la etiqueta. |

La clase [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelassignmenttype/) define cómo se asignó una etiqueta:

- [Standard](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta predeterminada o aplicada automáticamente.
- [Privileged](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta aplicada mediante una decisión del usuario, incluidas las etiquetas aplicadas manualmente, recomendadas y obligatorias.

La clase [SensitivityLabelContentType](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcontenttype/) define el marcado asociado a una etiqueta:

| Valor | Significado |
| --- | --- |
| [None](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcontenttype/) | La etiqueta se aplicó por defecto o automáticamente. |
| [Header](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcontenttype/) | El marcado de contenido de encabezado está asociado a la etiqueta. |
| [Footer](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcontenttype/) | El marcado de contenido de pie de página está asociado a la etiqueta. |
| [Watermark](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcontenttype/) | El marcado de contenido de marca de agua está asociado a la etiqueta. |
| [Encryption](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcontenttype/) | La protección de cifrado está asociada a la etiqueta. |

Se pueden asociar varios tipos de marcado a una misma etiqueta.

## **Enumerar etiquetas de sensibilidad existentes**

Lea la colección de etiquetas modernas mediante [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSensitivityLabels) y recorra sus elementos. El siguiente ejemplo enumera cada propiedad y marcado de contenido almacenado para cada etiqueta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Agregar una etiqueta de sensibilidad con marcado de contenido**

Utilice [SensitivityLabelCollection.add](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcollection/#add) con el identificador de la etiqueta, el identificador del sitio, el estado habilitado y el método de asignación. Tras la llamada, obtendrá la nueva [SensitivityLabel](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/); añada los valores de marcado requeridos mediante la lista devuelta por [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

El siguiente ejemplo agrega una etiqueta seleccionada manualmente asociada a marcados de pie de página y marca de agua, y luego guarda el resultado como PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Actualizar una etiqueta de sensibilidad**

Los valores de [SensitivityLabel](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/) son de lectura/escritura, excepto la lista devuelta por [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), que se modifica mediante sus operaciones de lista. Tras localizar la etiqueta requerida, puede actualizar su identificador, identificador del sitio, estado habilitado, método de asignación, estado de eliminación y tipos de marcado de contenido. Guarde la presentación para que los cambios persistan.

El siguiente ejemplo actualiza el estado habilitado y el método de asignación de la primera etiqueta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Marcar una etiqueta de sensibilidad como eliminada**

Para conservar el hecho de que una etiqueta fue eliminada, encuentre la etiqueta y llame a [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#setRemoved) con `True`. Esto mantiene la entrada de la etiqueta mientras registra su estado eliminado. Si, por el contrario, necesita borrar una entrada de la colección moderna, utilice [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); use [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcollection/#clear) para eliminar todas las entradas.

El siguiente ejemplo marca una etiqueta específica como eliminada y guarda la presentación actualizada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Leer y migrar etiquetas de sensibilidad heredadas de MIP**

Los flujos de trabajo basados en MIP más antiguos pueden almacenar los metadatos de etiquetas de sensibilidad en propiedades personalizadas del documento en lugar de la colección moderna de etiquetas. Lea esos metadatos con [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getSensitivityLabels). El método analiza las propiedades personalizadas heredadas y devuelve una matriz de objetos [SensitivityLabel](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/).

Para migrar los metadatos, añada cada etiqueta devuelta a la moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcollection/) mediante [SensitivityLabelCollection.add](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcollection/#add). Como añadir un identificador de etiqueta duplicado genera una excepción, el ejemplo comprueba la colección de destino antes de copiar cada etiqueta. Puede añadir más validaciones para confirmar que cada etiqueta heredada sigue existiendo en la política actual de Purview.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La migración copia los objetos de etiqueta analizados a la colección moderna. No es necesario limpiar todas las propiedades personalizadas del documento, por lo que los metadatos no relacionados permanecen intactos. Use [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/) para escribir los metadatos de etiquetas modernas en un archivo PPTX.

## **Preguntas frecuentes**

**¿Agregar un tipo de marcado de contenido crea un encabezado, pie de página o marca de agua visible en las diapositivas?**

No. Los valores añadidos a través de la lista devuelta por [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) describen los marcados asociados a la etiqueta de sensibilidad. No crean texto visible ni formas en la presentación. Añada el contenido de diapositiva correspondiente por separado si su flujo de trabajo debe representar esos marcados.

**¿Cuál es la diferencia entre marcar una etiqueta como eliminada y eliminarla de la colección?**

Llamar a [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#setRemoved) con `True` conserva la entrada de la etiqueta y registra su estado eliminado. Llamar a [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) elimina la entrada de la colección moderna. Elija la operación que coincida con los requisitos de retención de metadatos de su organización.

**¿Puede una presentación contener tanto metadatos heredados de MIP como etiquetas de sensibilidad modernas?**

Sí. Las etiquetas heredadas pueden permanecer en propiedades personalizadas del documento mientras que las etiquetas modernas están disponibles a través de [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSensitivityLabels). Use [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#getSensitivityLabels) para leer los metadatos heredados y migrar solo las etiquetas válidas que no estén ya presentes en la colección moderna.

**¿Qué ocurre cuando se añade una etiqueta con el mismo identificador más de una vez?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabelcollection/#add) genera una excepción cuando la colección ya contiene una etiqueta con el mismo identificador. Verifique los valores existentes devueltos por [SensitivityLabel.getId](https://reference.aspose.com/slides/es/python-java/aspose.slides/sensitivitylabel/#getId) antes de añadir o migrar etiquetas.

**¿Qué formato de salida se debe usar para conservar las etiquetas de sensibilidad actualizadas?**

Guarde la presentación como PPTX llamando a [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/), como se muestra en los ejemplos anteriores.