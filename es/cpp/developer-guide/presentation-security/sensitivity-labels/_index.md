---
title: Gestionar etiquetas de sensibilidad en presentaciones de PowerPoint en C++
linktitle: Etiquetas de sensibilidad
type: docs
weight: 50
url: /es/cpp/sensitivity-labels/
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
- C++
- Aspose.Slides
description: "Leer, añadir, actualizar, eliminar y migrar etiquetas de sensibilidad de Microsoft Purview en presentaciones PPTX de PowerPoint con Aspose.Slides para C++."
---
## **Visión general**

Microsoft Purview sensitivity labels help organizations classify and govern documents. During automated presentation processing, an application may need to preserve an existing label, apply a label selected by a policy, update its state, or migrate label metadata written by an older Microsoft Information Protection (MIP) workflow.

Aspose.Slides expone los metadatos modernos de etiquetas de sensibilidad a través de [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Este método devuelve una [ISensitivityLabelCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabelcollection/) que puede inspeccionarse y modificarse antes de que la presentación se guarde como PPTX.

{{% alert color="primary" title="Note" %}}
Los identificadores de etiquetas de sensibilidad y la información de políticas están definidas por la configuración de Microsoft Purview. Valide la disponibilidad de etiquetas y los requisitos de la política en su entorno antes de añadir o migrar metadatos. Los valores de [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) describen las marcas de contenido asociadas a una etiqueta; no añaden por sí mismos texto visible ni formas a las diapositivas.
{{% /alert %}}

## **Comprender las propiedades de la etiqueta de sensibilidad**

Cada [ISensitivityLabel](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/) contiene los siguientes metadatos:

| Accessors | Propósito |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/set_id/) | Identifica la etiqueta de sensibilidad en la política de Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Identifica el sitio asociado a la política de la etiqueta. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Indica si la etiqueta está habilitada. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Indica que la etiqueta ha sido eliminada. Establezca el valor a `true` cuando el estado de eliminación deba conservarse en los metadatos. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Especifica si la etiqueta se aplicó automáticamente o mediante una decisión del usuario. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Enumera los tipos de marcas de contenido asociados a la etiqueta. |

La enumeración [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/es/cpp/aspose.slides/sensitivitylabelassignmenttype/) describe cómo se asignó una etiqueta:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/es/cpp/aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta predeterminada o aplicada automáticamente.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/es/cpp/aspose.slides/sensitivitylabelassignmenttype/) representa una etiqueta aplicada mediante una decisión del usuario, incluyendo etiquetas aplicadas manualmente, recomendadas y obligatorias.

La enumeración [SensitivityLabelContentType](https://reference.aspose.com/slides/es/cpp/aspose.slides/sensitivitylabelcontenttype/) identifica la marca asociada a una etiqueta:

| Valor | Significado |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/es/cpp/aspose.slides/sensitivitylabelcontenttype/) | La etiqueta fue aplicada por defecto o automáticamente. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/es/cpp/aspose.slides/sensitivitylabelcontenttype/) | La marca de contenido de encabezado está asociada a la etiqueta. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/es/cpp/aspose.slides/sensitivitylabelcontenttype/) | La marca de contenido de pie de página está asociada a la etiqueta. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/es/cpp/aspose.slides/sensitivitylabelcontenttype/) | La marca de contenido de marca de agua está asociada a la etiqueta. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/es/cpp/aspose.slides/sensitivitylabelcontenttype/) | La protección de cifrado está asociada a la etiqueta. |

Se pueden asociar varios tipos de marcas a una etiqueta.

## **Enumerar las etiquetas de sensibilidad existentes**

Lea la colección moderna de etiquetas desde [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) y enumerela. El siguiente ejemplo muestra cada propiedad y marca de contenido almacenada para cada etiqueta:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **Añadir una etiqueta de sensibilidad con marca de contenido**

Utilice [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabelcollection/add/) con el identificador de la etiqueta, el identificador del sitio, el estado habilitado y el método de asignación. Después de que el método devuelva la nueva [ISensitivityLabel](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/), añada los valores de marcas requeridos mediante [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

El siguiente ejemplo añade una etiqueta seleccionada manualmente asociada a marcas de pie de página y de marca de agua, y luego guarda el resultado como PPTX:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Actualizar una etiqueta de sensibilidad**

Los valores de [ISensitivityLabel](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/) se pueden leer/escribir mediante sus métodos getter y setter, excepto que la colección devuelta por [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) se modifica mediante sus operaciones de lista. Después de localizar la etiqueta requerida, puede actualizar su identificador, identificador del sitio, estado habilitado, método de asignación, estado de eliminación y tipos de marcas de contenido. Guarde la presentación para que los cambios se persistan.

El siguiente ejemplo actualiza el estado habilitado y el método de asignación de la primera etiqueta:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Marcar una etiqueta de sensibilidad como eliminada**

Para conservar el hecho de que una etiqueta fue eliminada, encuentre la etiqueta y llame a [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/set_isremoved/) con `true`. Esto mantiene la entrada de la etiqueta mientras registra su estado eliminado. Si en su lugar necesita borrar una entrada de la colección moderna, utilice [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabelcollection/removeat/); use [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabelcollection/clear/) para eliminar todas las entradas.

El siguiente ejemplo marca una etiqueta específica como eliminada y guarda la presentación actualizada:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Leer y migrar etiquetas de sensibilidad MIP heredadas**

Los flujos de trabajo basados en MIP más antiguos pueden almacenar los metadatos de etiquetas de sensibilidad en propiedades personalizadas del documento en lugar de la colección moderna de etiquetas. Lea esos metadatos con [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). El método analiza las propiedades personalizadas heredadas y devuelve una matriz de objetos [ISensitivityLabel](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/).

Para migrar los metadatos, añada cada etiqueta devuelta a la colección moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabelcollection/) mediante [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabelcollection/add/). Como añadir un identificador de etiqueta duplicado genera una excepción, el ejemplo verifica la colección de destino antes de copiar cada etiqueta. Puede añadir más validaciones para confirmar que cada etiqueta heredada sigue existiendo en la política actual de Purview.

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La migración copia los objetos de etiqueta analizados a la colección moderna. No requiere borrar todas las propiedades personalizadas del documento, por lo que los metadatos no relacionados del documento permanecen intactos. Utilice [IPresentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/save/) con [SaveFormat::Pptx](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveformat/) para escribir los metadatos modernos de etiquetas a un archivo PPTX.

## **Preguntas frecuentes**

**¿Agregar un tipo de marca de contenido crea un encabezado, pie de página o marca de agua visible en las diapositivas?**

No. Los valores añadidos a través de [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) describen las marcas asociadas a la etiqueta de sensibilidad. No crean texto visible ni formas en la presentación. Añada el contenido de diapositiva correspondiente por separado si su flujo de trabajo debe renderizar esas marcas.

**¿Cuál es la diferencia entre marcar una etiqueta como eliminada y borrarla de la colección?**

Llamar a [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/set_isremoved/) con `true` mantiene la entrada de la etiqueta y registra su estado eliminado. Llamar a [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabelcollection/removeat/) elimina la entrada de la colección moderna. Elija la operación que coincida con los requisitos de retención de metadatos de su organización.

**¿Puede una presentación contener tanto metadatos MIP heredados como etiquetas de sensibilidad modernas?**

Sí. Las etiquetas heredadas pueden permanecer en propiedades personalizadas del documento mientras que las etiquetas modernas están disponibles a través de [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Utilice [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) para leer los metadatos heredados y migrar solo las etiquetas válidas que no estén ya presentes en la colección moderna.

**¿Qué ocurre cuando se añade una etiqueta con el mismo identificador más de una vez?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabelcollection/add/) lanza una excepción de argumento cuando la colección ya contiene una etiqueta con el mismo identificador. Verifique los valores existentes de [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/es/cpp/aspose.slides/isensitivitylabel/get_id/) antes de añadir o migrar etiquetas.

**¿Qué formato de salida se debe usar para conservar las etiquetas de sensibilidad actualizadas?**

Guarde la presentación como PPTX llamando a [IPresentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/save/) con [SaveFormat::Pptx](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveformat/), como se muestra en los ejemplos anteriores.