---
title: Manage Sensitivity Labels in PowerPoint Presentations in Python
linktitle: Sensitivity Labels
type: docs
weight: 50
url: /python-net/sensitivity-labels/
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
- Python
- Aspose.Slides
description: "Read, add, update, remove, and migrate Microsoft Purview sensitivity labels in PowerPoint PPTX presentations with Aspose.Slides for Python via .NET."
---

## **Overview**

Microsoft Purview sensitivity labels help organizations classify and govern documents. During automated presentation processing, an application may need to preserve an existing label, apply a label selected by a policy, update its state, or migrate label metadata written by an older Microsoft Information Protection (MIP) workflow.

Aspose.Slides for Python via .NET exposes modern sensitivity label metadata through [Presentation.sensitivity_labels](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/sensitivity_labels/). This property returns a [SensitivityLabelCollection](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcollection/) that can be inspected and modified before the presentation is saved as PPTX.

{{% alert color="info" title="Note" %}}

Sensitivity label identifiers and policy information are defined by your Microsoft Purview configuration. Validate label availability and policy requirements in your environment before adding or migrating metadata. The [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/content_mark_types/) values describe the content markings associated with a label; they do not by themselves add visible text or shapes to slides.

{{% /alert %}}

## **Understand Sensitivity Label Properties**

Each [SensitivityLabel](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/) contains the following metadata:

| Property | Purpose |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/id/) | Identifies the sensitivity label in the Purview policy. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/site_id/) | Identifies the site associated with the label policy. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Indicates whether the label is enabled. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/is_removed/) | Indicates that the label has been removed. Set this property to `True` when the removal state must be retained in the metadata. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Specifies whether the label was applied automatically or through a user decision. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Lists the content marking types associated with the label. |

The [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelassignmenttype/) enumeration describes how a label was assigned:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelassignmenttype/) represents a default or automatically applied label.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelassignmenttype/) represents a label applied through a user decision, including manually applied, recommended, and mandatory labels.

The [SensitivityLabelContentType](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcontenttype/) enumeration identifies the marking associated with a label:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcontenttype/) | The label was applied by default or automatically. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcontenttype/) | Header content marking is associated with the label. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcontenttype/) | Footer content marking is associated with the label. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcontenttype/) | Watermark content marking is associated with the label. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcontenttype/) | Encryption protection is associated with the label. |

Multiple marking types can be associated with one label.

## **List Existing Sensitivity Labels**

Read the modern label collection from [Presentation.sensitivity_labels](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/sensitivity_labels/) and enumerate it. The following example lists every property and content marking stored for each label:

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

## **Add a Sensitivity Label with Content Marking**

Use [SensitivityLabelCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcollection/add/) with the label identifier, site identifier, enabled state, and assignment method. Pass the site identifier as a Python `uuid.UUID` object. After the method returns the new [SensitivityLabel](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/), append the required marking values to [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

The following example adds a manually selected label associated with footer and watermark markings, and then saves the result as PPTX:

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

## **Update a Sensitivity Label**

The [SensitivityLabel](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/) properties are read/write, except that the list returned by [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/content_mark_types/) is modified through its list operations. After locating the required label, you can update its identifier, site identifier, enabled state, assignment method, removal state, and content marking types. Save the presentation to persist the changes.

The following example updates the enabled state and assignment method of the first label:

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

## **Mark a Sensitivity Label as Removed**

To preserve the fact that a label was removed, find the label and set [SensitivityLabel.is_removed](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/is_removed/) to `True`. This retains the label entry while recording its removed state. If you instead need to delete an entry from the modern collection, use [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); use [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcollection/clear/) to delete every entry.

The following example marks a specific label as removed and saves the updated presentation:

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

## **Read and Migrate Legacy MIP Sensitivity Labels**

Older MIP-based workflows can store sensitivity label metadata in custom document properties instead of the modern label collection. Read that metadata with [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). The method parses the legacy custom properties and returns [SensitivityLabel](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/) objects.

To migrate the metadata, add each returned label to the modern [SensitivityLabelCollection](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcollection/) through [SensitivityLabelCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcollection/add/). Because adding a duplicate label identifier raises an exception, the example checks the destination collection before copying each label. You can add further validation to confirm that each legacy label still exists in the current Purview policy.

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

The migration copies the parsed label objects into the modern collection. It does not require clearing all custom document properties, so unrelated document metadata remains intact. Use [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) with [SaveFormat.PPTX](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveformat/) to write the modern label metadata to a PPTX file.

## **FAQ**

**Does adding a content marking type create a visible header, footer, or watermark on slides?**

No. Values added through [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/content_mark_types/) describe the markings associated with the sensitivity label. They do not create visible text or shapes in the presentation. Add the corresponding slide content separately if your workflow must render those markings.

**What is the difference between marking a label as removed and deleting it from the collection?**

Setting [SensitivityLabel.is_removed](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/is_removed/) to `True` keeps the label entry and records its removed state. Calling [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) deletes the entry from the modern collection. Choose the operation that matches your organization's metadata retention requirements.

**Can a presentation contain both legacy MIP metadata and modern sensitivity labels?**

Yes. Legacy labels can remain in custom document properties while modern labels are available through [Presentation.sensitivity_labels](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/sensitivity_labels/). Use [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) to read the legacy metadata and migrate only the valid labels that are not already present in the modern collection.

**What happens when a label with the same identifier is added more than once?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabelcollection/add/) raises an exception when the collection already contains a label with the same identifier. Check existing [SensitivityLabel.id](https://reference.aspose.com/slides/python-net/aspose.slides/sensitivitylabel/id/) values before adding or migrating labels.

**Which output format should be used to preserve updated sensitivity labels?**

Save the presentation as PPTX by calling [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) with [SaveFormat.PPTX](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveformat/), as shown in the examples above.
