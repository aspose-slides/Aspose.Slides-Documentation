---
title: Gestionar etiquetas de sensibilidad en presentaciones de PowerPoint en Android
linktitle: Etiquetas de sensibilidad
type: docs
weight: 50
url: /es/androidjava/sensitivity-labels/
keywords:
- etiqueta de sensibilidad
- Microsoft Purview
- Microsoft Information Protection
- metadatos MIP
- marca de contenido
- protección de la información
- gobierno de documentos
- PowerPoint
- PPTX
- seguridad de presentaciones
- Android
- Java
- Aspose.Slides
description: "Leer, agregar, actualizar, eliminar y migrar etiquetas de sensibilidad de Microsoft Purview en presentaciones PPTX de PowerPoint con Aspose.Slides para Android mediante Java."
---
## **Visión general**

Microsoft Purview sensitivity labels help organizations classify and govern documents. During automated presentation processing, an application may need to preserve an existing label, apply a label selected by a policy, update its state, or migrate label metadata written by an older Microsoft Information Protection (MIP) workflow.

Aspose.Slides for Android via Java exposes modern sensitivity label metadata through [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). This method returns an [ISensitivityLabelCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabelcollection/) that can be inspected and modified before the presentation is saved as PPTX.

{{% alert color="info" title="Note" %}}
Sensitivity label identifiers and policy information are defined by your Microsoft Purview configuration. Validate label availability and policy requirements in your environment before adding or migrating metadata. The [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) values describe the content markings associated with a label; they do not by themselves add visible text or shapes to slides.
{{% /alert %}}

## **Comprender las propiedades de la etiqueta de sensibilidad**

Each [ISensitivityLabel](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/) contains the following metadata:

| Métodos | Propósito |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#getId--) and [ISensitivityLabel.setId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Obtiene o establece el identificador de la etiqueta de sensibilidad en la política de Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) and [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Obtiene o establece el sitio asociado a la política de la etiqueta. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) and [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Obtiene o establece si la etiqueta está habilitada. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) and [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Obtiene o establece si la etiqueta ha sido eliminada. Establezca el valor a `true` cuando el estado de eliminación debe conservarse en los metadatos. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) and [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Obtiene o establece si la etiqueta se aplicó automáticamente o mediante una decisión del usuario. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Obtiene los tipos de marcas de contenido asociados a la etiqueta. |

The [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) class defines how a label was assigned:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) represents a default or automatically applied label.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) represents a label applied through a user decision, including manually applied, recommended, and mandatory labels.

The [SensitivityLabelContentType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) class defines the marking associated with a label:

| Valor | Significado |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | La etiqueta se aplicó por defecto o automáticamente. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Se asocia una marca de contenido de encabezado a la etiqueta. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Se asocia una marca de contenido de pie de página a la etiqueta. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Se asocia una marca de contenido de marca de agua a la etiqueta. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Se asocia protección de cifrado a la etiqueta. |

Multiple marking types can be associated with one label.

## **Enumerar etiquetas de sensibilidad existentes**

Read the modern label collection from [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) and enumerate it. The following example lists every property and content marking stored for each label:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Agregar una etiqueta de sensibilidad con marca de contenido**

Use [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) with the label identifier, site identifier, enabled state, and assignment method. After the method returns the new [ISensitivityLabel](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/), add the required marking values through the list returned by [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

The following example adds a manually selected label associated with footer and watermark markings, and then saves the result as PPTX:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Actualizar una etiqueta de sensibilidad**

The [ISensitivityLabel](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/) values are read/write, except that the list returned by [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) is modified through its list operations. After locating the required label, you can update its identifier, site identifier, enabled state, assignment method, removal state, and content marking types. Save the presentation to persist the changes.

The following example updates the enabled state and assignment method of the first label:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Marcar una etiqueta de sensibilidad como eliminada**

To preserve the fact that a label was removed, find the label and call [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) with `true`. This retains the label entry while recording its removed state. If you instead need to delete an entry from the modern collection, use [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); use [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) to delete every entry.

The following example marks a specific label as removed and saves the updated presentation:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Leer y migrar etiquetas de sensibilidad MIP heredadas**

Older MIP-based workflows can store sensitivity label metadata in custom document properties instead of the modern label collection. Read that metadata with [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). The method parses the legacy custom properties and returns an array of [ISensitivityLabel](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/) objects.

To migrate the metadata, add each returned label to the modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabelcollection/) through [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Because adding a duplicate label identifier raises an exception, the example checks the destination collection before copying each label. You can add further validation to confirm that each legacy label still exists in the current Purview policy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The migration copies the parsed label objects into the modern collection. It does not require clearing all custom document properties, so unrelated document metadata remains intact. Use [IPresentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) with [SaveFormat.Pptx](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/) to write the modern label metadata to a PPTX file.

## **Preguntas frecuentes**

**¿Agregar un tipo de marca de contenido crea un encabezado, pie de página o marca de agua visible en las diapositivas?**

No. Values added through the list returned by [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) describe the markings associated with the sensitivity label. They do not create visible text or shapes in the presentation. Add the corresponding slide content separately if your workflow must render those markings.

**¿Cuál es la diferencia entre marcar una etiqueta como eliminada y borrarla de la colección?**

Calling [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) with `true` keeps the label entry and records its removed state. Calling [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) deletes the entry from the modern collection. Choose the operation that matches your organization's metadata retention requirements.

**¿Puede una presentación contener tanto metadatos MIP heredados como etiquetas de sensibilidad modernas?**

Yes. Legacy labels can remain in custom document properties while modern labels are available through [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Use [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) to read the legacy metadata and migrate only the valid labels that are not already present in the modern collection.

**¿Qué ocurre cuando se añade más de una vez una etiqueta con el mismo identificador?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) raises an exception when the collection already contains a label with the same identifier. Check existing values returned by [ISensitivityLabel.getId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isensitivitylabel/#getId--) before adding or migrating labels.

**¿Qué formato de salida se debe usar para conservar las etiquetas de sensibilidad actualizadas?**

Save the presentation as PPTX by calling [IPresentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) with [SaveFormat.Pptx](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/saveformat/), as shown in the examples above.