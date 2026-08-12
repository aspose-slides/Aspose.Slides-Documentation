---
title: Gestionar etiquetas de sensibilidad en presentaciones de PowerPoint en Python
linktitle: Etiquetas de sensibilidad
type: docs
weight: 50
url: /es/python-net/sensitivity-labels/
keywords:
- etiqueta de sensibilidad
- Microsoft Purview
- Protección de Información de Microsoft
- metadatos MIP
- marcado de contenido
- protección de la información
- gobernanza de documentos
- PowerPoint
- PPTX
- seguridad de presentaciones
- Python
- Aspose.Slides
description: "Leer, agregar, actualizar, eliminar y migrar etiquetas de sensibilidad de Microsoft Purview en presentaciones PPTX de PowerPoint con Aspose.Slides para Python vía .NET."
---
## **Descripción general**

Microsoft Purview sensitivity labels ayudan a las organizaciones a clasificar y gobernar documentos. Durante el procesamiento automatizado de presentaciones, una aplicación puede necesitar conservar una etiqueta existente, aplicar una etiqueta seleccionada por una política, actualizar su estado o migrar los metadatos de la etiqueta escritos por un flujo de trabajo más antiguo de Microsoft Information Protection (MIP).

Aspose.Slides for Python via .NET expone los metadatos modernos de etiquetas de sensibilidad a través de [Presentation.sensitivity_labels](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/sensitivity_labels/). Esta propiedad devuelve una [SensitivityLabelCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcollection/) que puede inspeccionarse y modificarse antes de guardar la presentación como PPTX.

{{% alert color="primary" title="Nota" %}}
Los identificadores de etiquetas de sensibilidad y la información de la política están definidos por la configuración de Microsoft Purview. Valide la disponibilidad de la etiqueta y los requisitos de la política en su entorno antes de agregar o migrar metadatos. Los valores de [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/content_mark_types/) describen las marcas de contenido asociadas a una etiqueta; no añaden por sí mismos texto o formas visibles a las diapositivas.
{{% /alert %}}

## **Comprender las propiedades de las etiquetas de sensibilidad**

Cada [SensitivityLabel](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/) contiene los siguientes metadatos:

| Propiedad | Propósito |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/id/) | Identifica la etiqueta de sensibilidad en la política de Purview. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/site_id/) | Identifica el sitio asociado a la política de la etiqueta. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Indica si la etiqueta está habilitada. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/is_removed/) | Indica que la etiqueta ha sido eliminada. Establezca esta propiedad a `True` cuando el estado de eliminación deba conservarse en los metadatos. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Especifica si la etiqueta se aplicó automáticamente o mediante una decisión del usuario. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Enumera los tipos de marcas de contenido asociados a la etiqueta. |

El enumerado [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelassignmenttype/) describe cómo se asignó una etiqueta:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta predeterminada o aplicada automáticamente.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta aplicada mediante una decisión del usuario, incluyendo etiquetas aplicadas manualmente, recomendadas y obligatorias.

El enumerado [SensitivityLabelContentType](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcontenttype/) identifica la marca asociada a una etiqueta:

| Valor | Significado |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcontenttype/) | La etiqueta se aplicó por defecto o automáticamente. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcontenttype/) | Se asocia una marca de contenido de encabezado con la etiqueta. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcontenttype/) | Se asocia una marca de contenido de pie de página con la etiqueta. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcontenttype/) | Se asocia una marca de contenido de marca de agua con la etiqueta. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcontenttype/) | Se asocia una protección de cifrado con la etiqueta. |

Pueden asociarse varios tipos de marcas a una única etiqueta.

## **Enumerar las etiquetas de sensibilidad existentes**

Lea la colección moderna de etiquetas desde [Presentation.sensitivity_labels](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/sensitivity_labels/) y recórrela. El siguiente ejemplo enumera cada propiedad y marca de contenido almacenada para cada etiqueta:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **Agregar una etiqueta de sensibilidad con marca de contenido**

Utilice [SensitivityLabelCollection.add](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcollection/add/) con el identificador de la etiqueta, el identificador del sitio, el estado habilitado y el método de asignación. Pase el identificador del sitio como un objeto Python `uuid.UUID`. Después de que el método devuelva la nueva [SensitivityLabel](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/), añada los valores de marca requeridos a [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

El siguiente ejemplo agrega una etiqueta seleccionada manualmente asociada a marcas de pie de página y marca de agua, y luego guarda el resultado como PPTX:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Actualizar una etiqueta de sensibilidad**

Las propiedades de [SensitivityLabel](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/) son de lectura/escritura, excepto que la lista devuelta por [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/content_mark_types/) se modifica mediante sus operaciones de lista. Después de localizar la etiqueta requerida, puede actualizar su identificador, identificador del sitio, estado habilitado, método de asignación, estado de eliminación y tipos de marcas de contenido. Guarde la presentación para que los cambios persistan.

El siguiente ejemplo actualiza el estado habilitado y el método de asignación de la primera etiqueta:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Marcar una etiqueta de sensibilidad como eliminada**

Para conservar el hecho de que una etiqueta fue eliminada, encuentre la etiqueta y establezca [SensitivityLabel.is_removed](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/is_removed/) a `True`. Esto mantiene la entrada de la etiqueta mientras registra su estado eliminado. Si necesita eliminar una entrada de la colección moderna, utilice [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); use [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcollection/clear/) para borrar todas las entradas.

El siguiente ejemplo marca una etiqueta específica como eliminada y guarda la presentación actualizada:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Leer y migrar etiquetas de sensibilidad heredadas de MIP**

Los flujos de trabajo basados en MIP más antiguos pueden almacenar metadatos de etiquetas de sensibilidad en propiedades de documento personalizadas en lugar de la colección moderna de etiquetas. Lea esos metadatos con [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). El método analiza las propiedades personalizadas heredadas y devuelve objetos [SensitivityLabel](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/).

Para migrar los metadatos, añada cada etiqueta devuelta a la moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcollection/) mediante [SensitivityLabelCollection.add](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcollection/add/). Como agregar un identificador de etiqueta duplicado genera una excepción, el ejemplo verifica la colección de destino antes de copiar cada etiqueta. Puede añadir validaciones adicionales para confirmar que cada etiqueta heredada sigue existiendo en la política actual de Purview.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

La migración copia los objetos de etiqueta analizados a la colección moderna. No es necesario limpiar todas las propiedades de documento personalizadas, por lo que los metadatos de documento no relacionados permanecen intactos. Utilice [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/) con [SaveFormat.PPTX](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/saveformat/) para escribir los metadatos modernos de etiquetas en un archivo PPTX.

## **Preguntas frecuentes**

**¿Agregar un tipo de marca de contenido crea un encabezado, pie de página o marca de agua visible en las diapositivas?**

No. Los valores añadidos a través de [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/content_mark_types/) describen las marcas asociadas a la etiqueta de sensibilidad. No generan texto o formas visibles en la presentación. Añada el contenido de diapositiva correspondiente por separado si su flujo de trabajo debe representar esas marcas.

**¿Cuál es la diferencia entre marcar una etiqueta como eliminada y eliminarla de la colección?**

Establecer [SensitivityLabel.is_removed](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/is_removed/) a `True` mantiene la entrada de la etiqueta y registra su estado eliminado. Llamar a [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) elimina la entrada de la colección moderna. Elija la operación que se ajuste a los requisitos de retención de metadatos de su organización.

**¿Puede una presentación contener tanto metadatos heredados de MIP como etiquetas de sensibilidad modernas?**

Sí. Las etiquetas heredadas pueden permanecer en propiedades de documento personalizadas mientras que las etiquetas modernas están disponibles a través de [Presentation.sensitivity_labels](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/sensitivity_labels/). Utilice [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) para leer los metadatos heredados y migrar solo las etiquetas válidas que no estén ya presentes en la colección moderna.

**¿Qué ocurre cuando se agrega una etiqueta con el mismo identificador más de una vez?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabelcollection/add/) genera una excepción cuando la colección ya contiene una etiqueta con el mismo identificador. Verifique los valores de [SensitivityLabel.id](https://reference.aspose.com/slides/es/python-net/aspose.slides/sensitivitylabel/id/) existentes antes de agregar o migrar etiquetas.

**¿Qué formato de salida se debe usar para conservar las etiquetas de sensibilidad actualizadas?**

Guarde la presentación como PPTX llamando a [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/) con [SaveFormat.PPTX](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/saveformat/), como se muestra en los ejemplos anteriores.