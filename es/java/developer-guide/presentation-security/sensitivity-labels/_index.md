---
title: Gestionar etiquetas de sensibilidad en presentaciones de PowerPoint en Java
linktitle: Etiquetas de sensibilidad
type: docs
weight: 50
url: /es/java/sensitivity-labels/
keywords:
  - etiqueta de sensibilidad
  - Microsoft Purview
  - Microsoft Information Protection
  - metadatos MIP
  - marcaje de contenido
  - protección de la información
  - gobernanza de documentos
  - PowerPoint
  - PPTX
  - seguridad de presentaciones
  - Java
  - Aspose.Slides
description: "Leer, añadir, actualizar, eliminar y migrar etiquetas de sensibilidad de Microsoft Purview en presentaciones PPTX de PowerPoint con Aspose.Slides para Java."
---
## **Resumen**

Las etiquetas de sensibilidad de Microsoft Purview ayudan a las organizaciones a clasificar y gobernar documentos. Durante el procesamiento automatizado de presentaciones, una aplicación puede necesitar conservar una etiqueta existente, aplicar una etiqueta seleccionada por una política, actualizar su estado o migrar los metadatos de etiqueta escritos por un flujo de trabajo anterior de Microsoft Information Protection (MIP).

Aspose.Slides expone los metadatos modernos de etiquetas de sensibilidad a través de [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Este método devuelve una [ISensitivityLabelCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabelcollection/) que puede inspeccionarse y modificarse antes de guardar la presentación como PPTX.

{{% alert color="info" title="Nota" %}}

Los identificadores de etiquetas de sensibilidad y la información de políticas están definidos por la configuración de su Microsoft Purview. Verifique la disponibilidad de etiquetas y los requisitos de política en su entorno antes de añadir o migrar metadatos. Los valores de [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) describen las marcas de contenido asociadas a una etiqueta; por sí mismos no añaden texto visible ni formas a las diapositivas.

{{% /alert %}}

## **Comprender las propiedades de la etiqueta de sensibilidad**

Cada [ISensitivityLabel](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/) contiene los siguientes metadatos:

| Métodos | Propósito |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#getId--) y [ISensitivityLabel.setId](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Obtiene o establece el identificador de la etiqueta de sensibilidad en la política de Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#getSiteId--) y [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Obtiene o establece el sitio asociado a la política de la etiqueta. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#isEnabled--) y [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Obtiene o establece si la etiqueta está habilitada. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#isRemoved--) y [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Obtiene o establece si la etiqueta ha sido eliminada. Establezca el valor a `true` cuando el estado de eliminación deba conservarse en los metadatos. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) y [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Obtiene o establece si la etiqueta se aplicó automáticamente o mediante una decisión del usuario. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Obtiene los tipos de marcas de contenido asociados a la etiqueta. |

La clase [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/es/java/com.aspose.slides/sensitivitylabelassignmenttype/) define cómo se asignó una etiqueta:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/es/java/com.aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta predeterminada o aplicada automáticamente.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/es/java/com.aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta aplicada mediante una decisión del usuario, incluidas las etiquetas aplicadas manualmente, recomendadas y obligatorias.

La clase [SensitivityLabelContentType](https://reference.aspose.com/slides/es/java/com.aspose.slides/sensitivitylabelcontenttype/) define la marca asociada a una etiqueta:

| Valor | Significado |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/es/java/com.aspose.slides/sensitivitylabelcontenttype/) | La etiqueta se aplicó de forma predeterminada o automática. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/es/java/com.aspose.slides/sensitivitylabelcontenttype/) | Se asocia una marca de contenido de encabezado a la etiqueta. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/es/java/com.aspose.slides/sensitivitylabelcontenttype/) | Se asocia una marca de contenido de pie de página a la etiqueta. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/es/java/com.aspose.slides/sensitivitylabelcontenttype/) | Se asocia una marca de contenido de marca de agua a la etiqueta. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/es/java/com.aspose.slides/sensitivitylabelcontenttype/) | Se asocia una protección de cifrado a la etiqueta. |

Se pueden asociar varios tipos de marcas a una misma etiqueta.

## **Enumerar etiquetas de sensibilidad existentes**

Lea la colección de etiquetas modernas desde [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) y recórrela. El siguiente ejemplo enumera todas las propiedades y marcas de contenido almacenadas para cada etiqueta:

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

## **Añadir una etiqueta de sensibilidad con marca de contenido**

 utilice [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) con el identificador de la etiqueta, el identificador del sitio, el estado habilitado y el método de asignación. Después de que el método devuelva la nueva [ISensitivityLabel](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/), añada los valores de marca requeridos a través de la lista devuelta por [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

El siguiente ejemplo añade una etiqueta seleccionada manualmente asociada a marcas de pie de página y marca de agua, y luego guarda el resultado como PPTX:

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

Los valores de [ISensitivityLabel](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/) son de lectura/escritura, salvo que la lista devuelta por [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) se modifica mediante sus operaciones de lista. Después de localizar la etiqueta requerida, puede actualizar su identificador, identificador del sitio, estado habilitado, método de asignación, estado de eliminación y tipos de marcas de contenido. Guarde la presentación para persistir los cambios.

El siguiente ejemplo actualiza el estado habilitado y el método de asignación de la primera etiqueta:

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

Para conservar el hecho de que una etiqueta fue eliminada, encuentre la etiqueta y llame a [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) con `true`. Esto mantiene la entrada de la etiqueta mientras se registra su estado eliminado. Si, en cambio, necesita borrar una entrada de la colección moderna, utilice [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); use [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabelcollection/#clear--) para eliminar todas las entradas.

El siguiente ejemplo marca una etiqueta específica como eliminada y guarda la presentación actualizada:

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

## **Leer y migrar etiquetas de sensibilidad heredadas de MIP**

Los flujos de trabajo basados en MIP más antiguos pueden almacenar metadatos de etiquetas de sensibilidad en propiedades personalizadas del documento en lugar de la colección moderna de etiquetas. Lea esos metadatos con [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/es/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). El método analiza las propiedades personalizadas heredadas y devuelve una matriz de objetos [ISensitivityLabel](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/).

Para migrar los metadatos, añada cada etiqueta devuelta a la moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabelcollection/) mediante [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Como añadir un identificador de etiqueta duplicado genera una excepción, el ejemplo verifica la colección de destino antes de copiar cada etiqueta. Puede añadir validaciones adicionales para confirmar que cada etiqueta heredada sigue existiendo en la política actual de Purview.

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

La migración copia los objetos de etiqueta analizados a la colección moderna. No requiere limpiar todas las propiedades personalizadas del documento, por lo que los metadatos no relacionados permanecen intactos. Utilice [IPresentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveformat/) para escribir los metadatos modernos de etiquetas en un archivo PPTX.

## **FAQ**

**¿Añadir un tipo de marca de contenido crea un encabezado, pie de página o marca de agua visible en las diapositivas?**

No. Los valores añadidos a través de la lista devuelta por [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) describen las marcas asociadas a la etiqueta de sensibilidad. No crean texto o formas visibles en la presentación. Añada el contenido de diapositiva correspondiente por separado si su flujo de trabajo necesita representar esas marcas.

**¿Cuál es la diferencia entre marcar una etiqueta como eliminada y borrarla de la colección?**

Llamar a [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) con `true` mantiene la entrada de la etiqueta y registra su estado eliminado. Llamar a [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) elimina la entrada de la colección moderna. Elija la operación que coincida con los requisitos de retención de metadatos de su organización.

**¿Puede una presentación contener tanto metadatos heredados de MIP como etiquetas de sensibilidad modernas?**

Sí. Las etiquetas heredadas pueden permanecer en las propiedades personalizadas del documento mientras que las etiquetas modernas están disponibles a través de [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Use [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/es/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) para leer los metadatos heredados y migrar solo las etiquetas válidas que aún no estén presentes en la colección moderna.

**¿Qué ocurre cuando se añade una etiqueta con el mismo identificador más de una vez?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) genera una excepción cuando la colección ya contiene una etiqueta con el mismo identificador. Compruebe los valores existentes devueltos por [ISensitivityLabel.getId](https://reference.aspose.com/slides/es/java/com.aspose.slides/isensitivitylabel/#getId--) antes de añadir o migrar etiquetas.

**¿Qué formato de salida debe usarse para conservar las etiquetas de sensibilidad actualizadas?**

Guarde la presentación como PPTX llamando a [IPresentation.save](https://reference.aspose.com/slides/es/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveformat/), como se muestra en los ejemplos anteriores.