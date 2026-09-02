---
title: Gestionar etiquetas de sensibilidad en presentaciones de PowerPoint con JavaScript
linktitle: Etiquetas de sensibilidad
type: docs
weight: 50
url: /es/nodejs-java/sensitivity-labels/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lea, añada, actualice, elimine y migre etiquetas de sensibilidad de Microsoft Purview en presentaciones PPTX de PowerPoint con Aspose.Slides para Node.js mediante Java."
---
## **Visión general**

Microsoft Purview sensitivity labels ayudan a las organizaciones a clasificar y gobernar documentos. Durante el procesamiento automatizado de presentaciones, una aplicación puede necesitar conservar una etiqueta existente, aplicar una etiqueta seleccionada por una política, actualizar su estado o migrar los metadatos de etiqueta escritos por un flujo de trabajo anterior de Microsoft Information Protection (MIP).

Aspose.Slides for Node.js via Java expone los metadatos modernos de etiquetas de sensibilidad a través de [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Este método devuelve una [SensitivityLabelCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcollection/) que puede inspeccionarse y modificarse antes de guardar la presentación como PPTX.

{{% alert color="primary" title="Note" %}}
Los identificadores de etiquetas de sensibilidad e información de política se definen en su configuración de Microsoft Purview. Valide la disponibilidad de etiquetas y los requisitos de política en su entorno antes de añadir o migrar metadatos. Los valores de [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) describen los marcados de contenido asociados a una etiqueta; por sí mismos no añaden texto o formas visibles a las diapositivas.
{{% /alert %}}

## **Comprender las propiedades de la etiqueta de sensibilidad**

Cada [SensitivityLabel](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/) contiene los siguientes metadatos:

| Métodos | Propósito |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#getId) y [SensitivityLabel.setId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Obtiene o establece el identificador de la etiqueta de sensibilidad en la política de Purview. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) y [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Obtiene o establece el sitio asociado a la política de la etiqueta. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) y [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Obtiene o establece si la etiqueta está habilitada. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) y [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Obtiene o establece si la etiqueta ha sido eliminada. Establezca el valor a `true` cuando el estado de eliminación deba conservarse en los metadatos. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) y [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Obtiene o establece si la etiqueta se aplicó automáticamente o mediante una decisión del usuario. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Obtiene los tipos de marcados de contenido asociados a la etiqueta. |

La clase [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) define cómo se asignó una etiqueta:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta predeterminada o aplicada automáticamente.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta aplicada mediante una decisión del usuario, incluidas las etiquetas aplicadas manualmente, recomendadas y obligatorias.

La clase [SensitivityLabelContentType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) define el marcado asociado a una etiqueta:

| Valor | Significado |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | La etiqueta se aplicó por defecto o automáticamente. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | El marcado de contenido de encabezado está asociado a la etiqueta. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | El marcado de contenido de pie de página está asociado a la etiqueta. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | El marcado de contenido de marca de agua está asociado a la etiqueta. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | La protección de cifrado está asociada a la etiqueta. |

Pueden asociarse varios tipos de marcado a una misma etiqueta.

## **Enumerar etiquetas de sensibilidad existentes**

Lea la colección moderna de etiquetas mediante [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) y recorra sus elementos. El siguiente ejemplo muestra cada propiedad y marcado de contenido almacenados para cada etiqueta:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Añadir una etiqueta de sensibilidad con marcado de contenido**

Utilice [SensitivityLabelCollection.add](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) con el identificador de la etiqueta, el identificador del sitio, el estado habilitado y el método de asignación. Después de que el método devuelva la nueva [SensitivityLabel](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/), añada los valores de marcado requeridos a través de la lista devuelta por [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

El siguiente ejemplo añade una etiqueta seleccionada manualmente asociada a marcados de pie de página y marca de agua, y luego guarda el resultado como PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Actualizar una etiqueta de sensibilidad**

Los valores de [SensitivityLabel](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/) son de lectura/escritura, salvo que la lista devuelta por [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) se modifique mediante sus operaciones de lista. Tras localizar la etiqueta requerida, puede actualizar su identificador, identificador del sitio, estado habilitado, método de asignación, estado de eliminación y tipos de marcado de contenido. Guarde la presentación para que los cambios persistan.

El siguiente ejemplo actualiza el estado habilitado y el método de asignación de la primera etiqueta:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Marcar una etiqueta de sensibilidad como eliminada**

Para conservar el hecho de que una etiqueta fue eliminada, encuentre la etiqueta y llame a [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) con `true`. Esto mantiene la entrada de la etiqueta mientras registra su estado eliminado. Si por el contrario necesita eliminar una entrada de la colección moderna, utilice [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); use [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) para borrar todas las entradas.

El siguiente ejemplo marca una etiqueta específica como eliminada y guarda la presentación actualizada:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Leer y migrar etiquetas de sensibilidad heredadas de MIP**

Los flujos de trabajo basados en MIP más antiguos pueden almacenar metadatos de etiquetas de sensibilidad en propiedades de documento personalizadas en lugar de la colección moderna de etiquetas. Lea esos metadatos con [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). El método analiza las propiedades personalizadas heredadas y devuelve una matriz de objetos [SensitivityLabel](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/).

Para migrar los metadatos, añada cada etiqueta devuelta a la moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcollection/) mediante [SensitivityLabelCollection.add](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). Como añadir un identificador de etiqueta duplicado genera una excepción, el ejemplo comprueba la colección de destino antes de copiar cada etiqueta. Puede agregar validaciones adicionales para confirmar que cada etiqueta heredada sigue existiendo en la política actual de Purview.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La migración copia los objetos de etiqueta analizados a la colección moderna. No es necesario borrar todas las propiedades de documento personalizadas, por lo que los metadatos de documento no relacionados permanecen intactos. Utilice [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/) para escribir los metadatos modernos de etiquetas en un archivo PPTX.

## **Preguntas frecuentes**

**¿Añadir un tipo de marcado de contenido crea un encabezado, pie de página o marca de agua visible en las diapositivas?**  
No. Los valores añadidos a través de la lista devuelta por [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) describen los marcados asociados a la etiqueta de sensibilidad. No crean texto ni formas visibles en la presentación. Añada el contenido de diapositiva correspondiente por separado si su flujo de trabajo debe renderizar esos marcados.

**¿Cuál es la diferencia entre marcar una etiqueta como eliminada y eliminarla de la colección?**  
Llamar a [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) con `true` mantiene la entrada de la etiqueta y registra su estado eliminado. Llamar a [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) elimina la entrada de la colección moderna. Elija la operación que coincida con los requisitos de retención de metadatos de su organización.

**¿Puede una presentación contener tanto metadatos heredados de MIP como etiquetas de sensibilidad modernas?**  
Sí. Las etiquetas heredadas pueden permanecer en propiedades de documento personalizadas mientras que las etiquetas modernas están disponibles a través de [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Utilice [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) para leer los metadatos heredados y migrar solo las etiquetas válidas que no estén ya presentes en la colección moderna.

**¿Qué ocurre cuando se añade una etiqueta con el mismo identificador más de una vez?**  
[SensitivityLabelCollection.add](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) genera una excepción cuando la colección ya contiene una etiqueta con el mismo identificador. Compruebe los valores existentes devueltos por [SensitivityLabel.getId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sensitivitylabel/#getId) antes de añadir o migrar etiquetas.

**¿Qué formato de salida se debe usar para conservar las etiquetas de sensibilidad actualizadas?**  
Guarde la presentación como PPTX llamando a [Presentation.save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/saveformat/), como se muestra en los ejemplos anteriores.