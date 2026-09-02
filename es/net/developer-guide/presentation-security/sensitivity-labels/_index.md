---
title: Gestionar etiquetas de sensibilidad en presentaciones de PowerPoint en .NET
linktitle: Etiquetas de sensibilidad
type: docs
weight: 50
url: /es/net/sensitivity-labels/
keywords:
- etiqueta de sensibilidad
- Microsoft Purview
- Microsoft Information Protection
- metadatos MIP
- marcaje de contenido
- protección de la información
- gobernanza documental
- PowerPoint
- PPTX
- seguridad de presentaciones
- .NET
- C#
- Aspose.Slides
description: "Lea, añada, actualice, elimine y migre etiquetas de sensibilidad de Microsoft Purview en presentaciones PPTX de PowerPoint con Aspose.Slides para .NET."
---
## **Visión general**

Las etiquetas de sensibilidad de Microsoft Purview ayudan a las organizaciones a clasificar y gobernar documentos. Durante el procesamiento automatizado de presentaciones, una aplicación puede necesitar conservar una etiqueta existente, aplicar una etiqueta seleccionada por una política, actualizar su estado o migrar los metadatos de etiqueta creados por un flujo de trabajo anterior de Microsoft Information Protection (MIP).

Aspose.Slides expone los metadatos modernos de etiquetas de sensibilidad a través de [Presentation.SensitivityLabels](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/sensitivitylabels/). Esta propiedad devuelve una [ISensitivityLabelCollection](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabelcollection/) que puede inspeccionarse y modificarse antes de guardar la presentación como PPTX.

{{% alert color="primary" title="Nota" %}}

Los identificadores de etiquetas de sensibilidad y la información de la política están definidos por la configuración de Microsoft Purview. Valide la disponibilidad de la etiqueta y los requisitos de la política en su entorno antes de añadir o migrar metadatos. Los valores de [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/contentmarktypes/) describen las marcas de contenido asociadas a una etiqueta; por sí mismos no añaden texto visible ni formas a las diapositivas.

{{% /alert %}}

## **Comprender las propiedades de la etiqueta de sensibilidad**

Cada [ISensitivityLabel](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/) contiene los siguientes metadatos:

| Property | Purpose |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/id/) | Identifica la etiqueta de sensibilidad en la política de Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/siteid/) | Identifica el sitio asociado a la política de la etiqueta. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/isenabled/) | Indica si la etiqueta está habilitada. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/isremoved/) | Indica que la etiqueta ha sido eliminada. Establezca esta propiedad a `true` cuando el estado de eliminación deba mantenerse en los metadatos. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Especifica si la etiqueta se aplicó automáticamente o mediante una decisión del usuario. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Enumera los tipos de marcas de contenido asociados a la etiqueta. |

La enumeración [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/es/net/aspose.slides/sensitivitylabelassignmenttype/) describe cómo se asignó una etiqueta:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/es/net/aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta predeterminada o aplicada automáticamente.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/es/net/aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta aplicada mediante una decisión del usuario, incluidas las etiquetas aplicadas manualmente, recomendadas y obligatorias.

La enumeración [SensitivityLabelContentType](https://reference.aspose.com/slides/es/net/aspose.slides/sensitivitylabelcontenttype/) identifica la marca asociada a una etiqueta:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/es/net/aspose.slides/sensitivitylabelcontenttype/) | La etiqueta se aplicó por defecto o automáticamente. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/es/net/aspose.slides/sensitivitylabelcontenttype/) | La marca de contenido del encabezado está asociada a la etiqueta. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/es/net/aspose.slides/sensitivitylabelcontenttype/) | La marca de contenido del pie de página está asociada a la etiqueta. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/es/net/aspose.slides/sensitivitylabelcontenttype/) | La marca de contenido de marca de agua está asociada a la etiqueta. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/es/net/aspose.slides/sensitivitylabelcontenttype/) | La protección de cifrado está asociada a la etiqueta. |

Se pueden asociar varios tipos de marcas a una única etiqueta.

## **Enumerar etiquetas de sensibilidad existentes**

Lea la colección de etiquetas modernas desde [Presentation.SensitivityLabels](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/sensitivitylabels/) y recórrela. El siguiente ejemplo enumera cada propiedad y marca de contenido almacenada para cada etiqueta:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Añadir una etiqueta de sensibilidad con marca de contenido**

Utilice [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabelcollection/add/) con el identificador de la etiqueta, el identificador del sitio, el estado habilitado y el método de asignación. Tras la llamada, obtendrá la nueva [ISensitivityLabel](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/); añada los valores de marca requeridos a través de [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/contentmarktypes/).

El siguiente ejemplo añade una etiqueta seleccionada manualmente asociada a marcas de pie de página y marca de agua, y luego guarda el resultado como PPTX:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Actualizar una etiqueta de sensibilidad**

Las propiedades de [ISensitivityLabel](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/) son de lectura/escritura, salvo que la colección devuelta por [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/contentmarktypes/) se modifica mediante sus operaciones de lista. Tras localizar la etiqueta requerida, puede actualizar su identificador, identificador del sitio, estado habilitado, método de asignación, estado de eliminación y tipos de marcas de contenido. Guarde la presentación para que los cambios persistan.

El siguiente ejemplo actualiza el estado habilitado y el método de asignación de la primera etiqueta:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Marcar una etiqueta de sensibilidad como eliminada**

Para conservar el hecho de que una etiqueta fue eliminada, encuentre la etiqueta y establezca [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/isremoved/) a `true`. Esto mantiene la entrada de la etiqueta mientras registra su estado eliminado. Si necesita eliminar una entrada de la colección moderna, utilice [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabelcollection/removeat/); use [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabelcollection/clear/) para borrar todas las entradas.

El siguiente ejemplo marca una etiqueta específica como eliminada y guarda la presentación actualizada:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Leer y migrar etiquetas de sensibilidad heredadas de MIP**

Los flujos de trabajo basados en versiones anteriores de MIP pueden almacenar los metadatos de etiquetas de sensibilidad en propiedades de documento personalizadas en lugar de la colección de etiquetas moderna. Lea esos metadatos con [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/getsensitivitylabels/). El método analiza las propiedades personalizadas heredadas y devuelve una matriz de objetos [ISensitivityLabel](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/).

Para migrar los metadatos, añada cada etiqueta devuelta a la colección moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabelcollection/) mediante [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabelcollection/add/). Como añadir un identificador de etiqueta duplicado genera una excepción, el ejemplo verifica la colección de destino antes de copiar cada etiqueta. Puede añadir validaciones adicionales para confirmar que cada etiqueta heredada sigue existiendo en la política actual de Purview.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

La migración copia los objetos de etiqueta analizados a la colección moderna. No es necesario limpiar todas las propiedades de documento personalizadas, de modo que los metadatos de documento no relacionados permanecen intactos. Utilice [IPresentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/save/) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/) para escribir los metadatos de etiquetas modernos en un archivo PPTX.

## **Preguntas frecuentes**

**¿Añadir un tipo de marca de contenido crea un encabezado, pie de página o marca de agua visible en las diapositivas?**

No. Los valores añadidos mediante [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/contentmarktypes/) describen las marcas asociadas a la etiqueta de sensibilidad. No crean texto visible ni formas en la presentación. Añada el contenido correspondiente a la diapositiva por separado si su flujo de trabajo debe mostrarlas.

**¿Cuál es la diferencia entre marcar una etiqueta como eliminada y borrarla de la colección?**

Establecer [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/isremoved/) a `true` conserva la entrada de la etiqueta y registra su estado eliminado. Llamar a [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabelcollection/removeat/) elimina la entrada de la colección moderna. Elija la operación que se ajuste a los requisitos de retención de metadatos de su organización.

**¿Puede una presentación contener tanto metadatos heredados de MIP como etiquetas de sensibilidad modernas?**

Sí. Las etiquetas heredadas pueden permanecer en propiedades de documento personalizadas mientras que las etiquetas modernas están disponibles a través de [Presentation.SensitivityLabels](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/sensitivitylabels/). Utilice [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/getsensitivitylabels/) para leer los metadatos heredados y migrar solo las etiquetas válidas que no estén ya presentes en la colección moderna.

**¿Qué ocurre cuando se añade una etiqueta con el mismo identificador más de una vez?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabelcollection/add/) lanza una `ArgumentException` cuando la colección ya contiene una etiqueta con el mismo identificador. Verifique los valores de [ISensitivityLabel.Id](https://reference.aspose.com/slides/es/net/aspose.slides/isensitivitylabel/id/) existentes antes de añadir o migrar etiquetas.

**¿Qué formato de salida se debe usar para conservar las etiquetas de sensibilidad actualizadas?**

Guarde la presentación como PPTX llamando a [IPresentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/save/) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/), tal como se muestra en los ejemplos anteriores.