---
title: Manage Sensitivity Labels in PowerPoint Presentations in .NET
linktitle: Sensitivity Labels
type: docs
weight: 50
url: /net/sensitivity-labels/
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
- .NET
- C#
- Aspose.Slides
description: "Read, add, update, remove, and migrate Microsoft Purview sensitivity labels in PowerPoint PPTX presentations with Aspose.Slides for .NET."
---

## **Overview**

Microsoft Purview sensitivity labels help organizations classify and govern documents. During automated presentation processing, an application may need to preserve an existing label, apply a label selected by a policy, update its state, or migrate label metadata written by an older Microsoft Information Protection (MIP) workflow.

Aspose.Slides exposes modern sensitivity label metadata through [Presentation.SensitivityLabels](https://reference.aspose.com/slides/net/aspose.slides/presentation/sensitivitylabels/). This property returns an [ISensitivityLabelCollection](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabelcollection/) that can be inspected and modified before the presentation is saved as PPTX.

{{% alert color="info" title="Note" %}}

Sensitivity label identifiers and policy information are defined by your Microsoft Purview configuration. Validate label availability and policy requirements in your environment before adding or migrating metadata. The [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/contentmarktypes/) values describe the content markings associated with a label; they do not by themselves add visible text or shapes to slides.

{{% /alert %}}

## **Understand Sensitivity Label Properties**

Each [ISensitivityLabel](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/) contains the following metadata:

| Property | Purpose |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/id/) | Identifies the sensitivity label in the Purview policy. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/siteid/) | Identifies the site associated with the label policy. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/isenabled/) | Indicates whether the label is enabled. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/isremoved/) | Indicates that the label has been removed. Set this property to `true` when the removal state must be retained in the metadata. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Specifies whether the label was applied automatically or through a user decision. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Lists the content marking types associated with the label. |

The [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/net/aspose.slides/sensitivitylabelassignmenttype/) enumeration describes how a label was assigned:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/net/aspose.slides/sensitivitylabelassignmenttype/) represents a default or automatically applied label.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/net/aspose.slides/sensitivitylabelassignmenttype/) represents a label applied through a user decision, including manually applied, recommended, and mandatory labels.

The [SensitivityLabelContentType](https://reference.aspose.com/slides/net/aspose.slides/sensitivitylabelcontenttype/) enumeration identifies the marking associated with a label:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/net/aspose.slides/sensitivitylabelcontenttype/) | The label was applied by default or automatically. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/net/aspose.slides/sensitivitylabelcontenttype/) | Header content marking is associated with the label. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/net/aspose.slides/sensitivitylabelcontenttype/) | Footer content marking is associated with the label. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/net/aspose.slides/sensitivitylabelcontenttype/) | Watermark content marking is associated with the label. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/net/aspose.slides/sensitivitylabelcontenttype/) | Encryption protection is associated with the label. |

Multiple marking types can be associated with one label.

## **List Existing Sensitivity Labels**

Read the modern label collection from [Presentation.SensitivityLabels](https://reference.aspose.com/slides/net/aspose.slides/presentation/sensitivitylabels/) and enumerate it. The following example lists every property and content marking stored for each label:

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

## **Add a Sensitivity Label with Content Marking**

Use [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabelcollection/add/) with the label identifier, site identifier, enabled state, and assignment method. After the method returns the new [ISensitivityLabel](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/), add the required marking values through [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/contentmarktypes/).

The following example adds a manually selected label associated with footer and watermark markings, and then saves the result as PPTX:

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

## **Update a Sensitivity Label**

The [ISensitivityLabel](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/) properties are read/write, except that the collection returned by [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/contentmarktypes/) is modified through its list operations. After locating the required label, you can update its identifier, site identifier, enabled state, assignment method, removal state, and content marking types. Save the presentation to persist the changes.

The following example updates the enabled state and assignment method of the first label:

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

## **Mark a Sensitivity Label as Removed**

To preserve the fact that a label was removed, find the label and set [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/isremoved/) to `true`. This retains the label entry while recording its removed state. If you instead need to delete an entry from the modern collection, use [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabelcollection/removeat/); use [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabelcollection/clear/) to delete every entry.

The following example marks a specific label as removed and saves the updated presentation:

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

## **Read and Migrate Legacy MIP Sensitivity Labels**

Older MIP-based workflows can store sensitivity label metadata in custom document properties instead of the modern label collection. Read that metadata with [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getsensitivitylabels/). The method parses the legacy custom properties and returns an array of [ISensitivityLabel](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/) objects.

To migrate the metadata, add each returned label to the modern [ISensitivityLabelCollection](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabelcollection/) through [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabelcollection/add/). Because adding a duplicate label identifier raises an exception, the example checks the destination collection before copying each label. You can add further validation to confirm that each legacy label still exists in the current Purview policy.

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

The migration copies the parsed label objects into the modern collection. It does not require clearing all custom document properties, so unrelated document metadata remains intact. Use [IPresentation.Save](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/) with [SaveFormat.Pptx](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) to write the modern label metadata to a PPTX file.

## **FAQ**

**Does adding a content marking type create a visible header, footer, or watermark on slides?**

No. Values added through [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/contentmarktypes/) describe the markings associated with the sensitivity label. They do not create visible text or shapes in the presentation. Add the corresponding slide content separately if your workflow must render those markings.

**What is the difference between marking a label as removed and deleting it from the collection?**

Setting [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/isremoved/) to `true` keeps the label entry and records its removed state. Calling [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabelcollection/removeat/) deletes the entry from the modern collection. Choose the operation that matches your organization's metadata retention requirements.

**Can a presentation contain both legacy MIP metadata and modern sensitivity labels?**

Yes. Legacy labels can remain in custom document properties while modern labels are available through [Presentation.SensitivityLabels](https://reference.aspose.com/slides/net/aspose.slides/presentation/sensitivitylabels/). Use [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getsensitivitylabels/) to read the legacy metadata and migrate only the valid labels that are not already present in the modern collection.

**What happens when a label with the same identifier is added more than once?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabelcollection/add/) throws an `ArgumentException` when the collection already contains a label with the same identifier. Check existing [ISensitivityLabel.Id](https://reference.aspose.com/slides/net/aspose.slides/isensitivitylabel/id/) values before adding or migrating labels.

**Which output format should be used to preserve updated sensitivity labels?**

Save the presentation as PPTX by calling [IPresentation.Save](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/) with [SaveFormat.Pptx](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/), as shown in the examples above.
