---
title: Gestionar etiquetas de sensibilidad en presentaciones de PowerPoint con PHP
linktitle: Etiquetas de sensibilidad
type: docs
weight: 50
url: /es/php-java/sensitivity-labels/
keywords:
- etiqueta de sensibilidad
- Microsoft Purview
- Microsoft Information Protection
- metadatos MIP
- marcado de contenido
- protección de la información
- gobernanza documental
- PowerPoint
- PPTX
- seguridad de la presentación
- PHP
- Aspose.Slides
description: "Leer, añadir, actualizar, eliminar y migrar etiquetas de sensibilidad de Microsoft Purview en presentaciones PPTX de PowerPoint en PHP."
---
## **Visión general**

Microsoft Purview sensitivity labels ayudan a las organizaciones a clasificar y gestionar documentos. Durante el procesamiento automatizado de presentaciones, una aplicación puede necesitar preservar una etiqueta existente, aplicar una etiqueta seleccionada por una política, actualizar su estado o migrar los metadatos de la etiqueta escritos por un flujo de trabajo anterior de Microsoft Information Protection (MIP).

Aspose.Slides for PHP a través de Java expone los metadatos modernos de etiquetas de sensibilidad mediante [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSensitivityLabels). Este método devuelve una [SensitivityLabelCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcollection/) que puede inspeccionarse y modificarse antes de que la presentación se guarde como PPTX.

{{% alert color="primary" title="Note" %}}
Los identificadores de etiquetas de sensibilidad y la información de la política están definidos por la configuración de Microsoft Purview. Valide la disponibilidad de etiquetas y los requisitos de la política en su entorno antes de añadir o migrar metadatos. Los valores de [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) describen las marcas de contenido asociadas a una etiqueta; por sí solos no añaden texto visible ni formas a las diapositivas.
{{% /alert %}}

## **Comprender las propiedades de las etiquetas de sensibilidad**

Cada [SensitivityLabel](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/) contiene los siguientes metadatos:

| Métodos | Propósito |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#getId) y [SensitivityLabel::setId](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#setId) | Obtener o establecer el identificador de la etiqueta de sensibilidad en la política de Purview. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#getSiteId) y [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Obtener o establecer el sitio asociado a la política de la etiqueta. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#isEnabled) y [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Obtener o establecer si la etiqueta está habilitada. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#isRemoved) y [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Obtener o establecer si la etiqueta ha sido eliminada. Establezca el valor a `true` cuando el estado de eliminación deba conservarse en los metadatos. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) y [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Obtener o establecer si la etiqueta se aplicó automáticamente o mediante una decisión del usuario. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Obtener los tipos de marcas de contenido asociados a la etiqueta. |

La clase [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelassignmenttype/) define cómo se asignó una etiqueta:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta predeterminada o aplicada automáticamente.  
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta aplicada mediante la decisión del usuario, incluyendo etiquetas aplicadas manualmente, recomendadas y obligatorias.

La clase [SensitivityLabelContentType](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcontenttype/) define la marca asociada a una etiqueta:

| Valor | Significado |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcontenttype/) | La etiqueta se aplicó por defecto o automáticamente. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcontenttype/) | La marca de contenido de encabezado está asociada a la etiqueta. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcontenttype/) | La marca de contenido de pie de página está asociada a la etiqueta. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcontenttype/) | La marca de contenido de marca de agua está asociada a la etiqueta. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcontenttype/) | La protección mediante cifrado está asociada a la etiqueta. |

Se pueden asociar varios tipos de marcas a una sola etiqueta.

## **Enumerar las etiquetas de sensibilidad existentes**

Lea la colección de etiquetas modernas mediante [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSensitivityLabels) y enumérela. El siguiente ejemplo muestra cada propiedad y marca de contenido almacenada para cada etiqueta:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Agregar una etiqueta de sensibilidad con marca de contenido**

Utilice [SensitivityLabelCollection::add](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcollection/#add) con el identificador de la etiqueta, el identificador del sitio, el estado habilitado y el método de asignación. Después de que el método devuelva la nueva [SensitivityLabel](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/), añada los valores de marca requeridos mediante la lista devuelta por [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

El siguiente ejemplo agrega una etiqueta seleccionada manualmente asociada a marcas de pie de página y marca de agua, y luego guarda el resultado como PPTX:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Actualizar una etiqueta de sensibilidad**

Los valores de [SensitivityLabel](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/) son de lectura/escritura, excepto que la lista devuelta por [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) se modifica mediante sus operaciones de lista. Después de localizar la etiqueta requerida, puede actualizar su identificador, identificador del sitio, estado habilitado, método de asignación, estado de eliminación y tipos de marcas de contenido. Guarde la presentación para conservar los cambios.

El siguiente ejemplo actualiza el estado habilitado y el método de asignación de la primera etiqueta:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Marcar una etiqueta de sensibilidad como eliminada**

Para conservar el hecho de que una etiqueta fue eliminada, encuentre la etiqueta y llame a [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#setRemoved) con `true`. Esto mantiene la entrada de la etiqueta mientras registra su estado eliminado. Si en su lugar necesita eliminar una entrada de la colección moderna, use [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); use [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcollection/#clear) para eliminar todas las entradas.

El siguiente ejemplo marca una etiqueta específica como eliminada y guarda la presentación actualizada:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Leer y migrar etiquetas de sensibilidad legadas de MIP**

Los flujos de trabajo basados en MIP más antiguos pueden almacenar los metadatos de etiquetas de sensibilidad en propiedades de documento personalizadas en lugar de la colección de etiquetas moderna. Lea esos metadatos con [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getSensitivityLabels). El método analiza las propiedades personalizadas heredadas y devuelve una matriz Java de objetos [SensitivityLabel](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/).

Para migrar los metadatos, añada cada etiqueta devuelta a la [SensitivityLabelCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcollection/) moderna mediante [SensitivityLabelCollection::add](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcollection/#add). Dado que añadir un identificador de etiqueta duplicado genera una excepción, el ejemplo verifica la colección de destino antes de copiar cada etiqueta. Puede añadir validación adicional para confirmar que cada etiqueta heredada todavía exista en la política actual de Purview.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La migración copia los objetos de etiqueta analizados a la colección moderna. No es necesario borrar todas las propiedades de documento personalizadas, por lo que los metadatos del documento no relacionados permanecen intactos. Use [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save) con [SaveFormat::Pptx](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/) para escribir los metadatos modernos de etiquetas a un archivo PPTX.

## **Preguntas frecuentes**

**¿Añadir un tipo de marca de contenido crea un encabezado, pie de página o marca de agua visible en las diapositivas?**

No. Los valores añadidos a través de la lista devuelta por [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) describen las marcas asociadas a la etiqueta de sensibilidad. No crean texto visible ni formas en la presentación. Añada el contenido de diapositiva correspondiente por separado si su flujo de trabajo debe renderizar esas marcas.

**¿Cuál es la diferencia entre marcar una etiqueta como eliminada y borrarla de la colección?**

Llamar a [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#setRemoved) con `true` mantiene la entrada de la etiqueta y registra su estado eliminado. Llamar a [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) elimina la entrada de la colección moderna. Elija la operación que coincida con los requisitos de retención de metadatos de su organización.

**¿Puede una presentación contener tanto metadatos heredados de MIP como etiquetas de sensibilidad modernas?**

Sí. Las etiquetas heredadas pueden permanecer en propiedades de documento personalizadas mientras que las etiquetas modernas están disponibles mediante [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSensitivityLabels). Use [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#getSensitivityLabels) para leer los metadatos heredados y migrar solo las etiquetas válidas que no estén ya presentes en la colección moderna.

**¿Qué ocurre cuando se añade una etiqueta con el mismo identificador más de una vez?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabelcollection/#add) genera una excepción cuando la colección ya contiene una etiqueta con el mismo identificador. Verifique los valores existentes devueltos por [SensitivityLabel::getId](https://reference.aspose.com/slides/es/php-java/aspose.slides/sensitivitylabel/#getId) antes de añadir o migrar etiquetas.

**¿Qué formato de salida debe usarse para conservar las etiquetas de sensibilidad actualizadas?**

Guarde la presentación como PPTX llamando a [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save) con [SaveFormat::Pptx](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/), como se muestra en los ejemplos anteriores.