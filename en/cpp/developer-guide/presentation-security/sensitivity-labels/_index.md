---
title: Manage Sensitivity Labels in PowerPoint Presentations in C++
linktitle: Sensitivity Labels
type: docs
weight: 50
url: /cpp/sensitivity-labels/
keywords:
- sensitivity label
- Microsoft Purview
- Microsoft Information Protection
- MIP metadata
- content marking
- information protection
- document governance
- PowerPoint
- PPTX
- presentation security
- C++
- Aspose.Slides
description: "Read, add, update, remove, and migrate Microsoft Purview sensitivity labels in PowerPoint PPTX presentations with Aspose.Slides for C++."
---

## **Overview**

Microsoft Purview sensitivity labels help organizations classify and govern documents. During automated presentation processing, an application may need to preserve an existing label, apply a label selected by a policy, update its state, or migrate label metadata written by an older Microsoft Information Protection (MIP) workflow.

Aspose.Slides exposes modern sensitivity label metadata through [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). This method returns an [ISensitivityLabelCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabelcollection/) that can be inspected and modified before the presentation is saved as PPTX.

{{% alert color="info" title="Note" %}}

Sensitivity label identifiers and policy information are defined by your Microsoft Purview configuration. Validate label availability and policy requirements in your environment before adding or migrating metadata. The [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) values describe the content markings associated with a label; they do not by themselves add visible text or shapes to slides.

{{% /alert %}}

## **Understand Sensitivity Label Properties**

Each [ISensitivityLabel](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/) contains the following metadata:

| Accessors | Purpose |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/set_id/) | Identify the sensitivity label in the Purview policy. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Identify the site associated with the label policy. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Indicate whether the label is enabled. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Indicate that the label has been removed. Set the value to `true` when the removal state must be retained in the metadata. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Specify whether the label was applied automatically or through a user decision. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | List the content marking types associated with the label. |

The [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/cpp/aspose.slides/sensitivitylabelassignmenttype/) enumeration describes how a label was assigned:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/cpp/aspose.slides/sensitivitylabelassignmenttype/) represents a default or automatically applied label.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/cpp/aspose.slides/sensitivitylabelassignmenttype/) represents a label applied through a user decision, including manually applied, recommended, and mandatory labels.

The [SensitivityLabelContentType](https://reference.aspose.com/slides/cpp/aspose.slides/sensitivitylabelcontenttype/) enumeration identifies the marking associated with a label:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/cpp/aspose.slides/sensitivitylabelcontenttype/) | The label was applied by default or automatically. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/cpp/aspose.slides/sensitivitylabelcontenttype/) | Header content marking is associated with the label. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/cpp/aspose.slides/sensitivitylabelcontenttype/) | Footer content marking is associated with the label. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/cpp/aspose.slides/sensitivitylabelcontenttype/) | Watermark content marking is associated with the label. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/cpp/aspose.slides/sensitivitylabelcontenttype/) | Encryption protection is associated with the label. |

Multiple marking types can be associated with one label.

## **List Existing Sensitivity Labels**

Read the modern label collection from [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) and enumerate it. The following example lists every property and content marking stored for each label:

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

## **Add a Sensitivity Label with Content Marking**

Use [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabelcollection/add/) with the label identifier, site identifier, enabled state, and assignment method. After the method returns the new [ISensitivityLabel](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/), add the required marking values through [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

The following example adds a manually selected label associated with footer and watermark markings, and then saves the result as PPTX:

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

## **Update a Sensitivity Label**

The [ISensitivityLabel](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/) values are read/write through their getter and setter methods, except that the collection returned by [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) is modified through its list operations. After locating the required label, you can update its identifier, site identifier, enabled state, assignment method, removal state, and content marking types. Save the presentation to persist the changes.

The following example updates the enabled state and assignment method of the first label:

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

## **Mark a Sensitivity Label as Removed**

To preserve the fact that a label was removed, find the label and call [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/set_isremoved/) with `true`. This retains the label entry while recording its removed state. If you instead need to delete an entry from the modern collection, use [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabelcollection/removeat/); use [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabelcollection/clear/) to delete every entry.

The following example marks a specific label as removed and saves the updated presentation:

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

## **Read and Migrate Legacy MIP Sensitivity Labels**

Older MIP-based workflows can store sensitivity label metadata in custom document properties instead of the modern label collection. Read that metadata with [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). The method parses the legacy custom properties and returns an array of [ISensitivityLabel](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/) objects.

To migrate the metadata, add each returned label to the modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabelcollection/) through [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabelcollection/add/). Because adding a duplicate label identifier raises an exception, the example checks the destination collection before copying each label. You can add further validation to confirm that each legacy label still exists in the current Purview policy.

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

The migration copies the parsed label objects into the modern collection. It does not require clearing all custom document properties, so unrelated document metadata remains intact. Use [IPresentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/) with [SaveFormat::Pptx](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveformat/) to write the modern label metadata to a PPTX file.

## **FAQ**

**Does adding a content marking type create a visible header, footer, or watermark on slides?**

No. Values added through [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) describe the markings associated with the sensitivity label. They do not create visible text or shapes in the presentation. Add the corresponding slide content separately if your workflow must render those markings.

**What is the difference between marking a label as removed and deleting it from the collection?**

Calling [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/set_isremoved/) with `true` keeps the label entry and records its removed state. Calling [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabelcollection/removeat/) deletes the entry from the modern collection. Choose the operation that matches your organization's metadata retention requirements.

**Can a presentation contain both legacy MIP metadata and modern sensitivity labels?**

Yes. Legacy labels can remain in custom document properties while modern labels are available through [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Use [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) to read the legacy metadata and migrate only the valid labels that are not already present in the modern collection.

**What happens when a label with the same identifier is added more than once?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabelcollection/add/) throws an argument exception when the collection already contains a label with the same identifier. Check existing [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/cpp/aspose.slides/isensitivitylabel/get_id/) values before adding or migrating labels.

**Which output format should be used to preserve updated sensitivity labels?**

Save the presentation as PPTX by calling [IPresentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/) with [SaveFormat::Pptx](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveformat/), as shown in the examples above.
