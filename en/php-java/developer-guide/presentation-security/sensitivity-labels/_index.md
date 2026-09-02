---
title: Manage Sensitivity Labels in PowerPoint Presentations in PHP
linktitle: Sensitivity Labels
type: docs
weight: 50
url: /php-java/sensitivity-labels/
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
- PHP
- Aspose.Slides
description: "Read, add, update, remove, and migrate Microsoft Purview sensitivity labels in PowerPoint PPTX presentations in PHP."
---

## **Overview**

Microsoft Purview sensitivity labels help organizations classify and govern documents. During automated presentation processing, an application may need to preserve an existing label, apply a label selected by a policy, update its state, or migrate label metadata written by an older Microsoft Information Protection (MIP) workflow.

Aspose.Slides for PHP via Java exposes modern sensitivity label metadata through [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSensitivityLabels). This method returns a [SensitivityLabelCollection](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcollection/) that can be inspected and modified before the presentation is saved as PPTX.

{{% alert color="info" title="Note" %}}

Sensitivity label identifiers and policy information are defined by your Microsoft Purview configuration. Validate label availability and policy requirements in your environment before adding or migrating metadata. The [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) values describe the content markings associated with a label; they do not by themselves add visible text or shapes to slides.

{{% /alert %}}

## **Understand Sensitivity Label Properties**

Each [SensitivityLabel](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/) contains the following metadata:

| Methods | Purpose |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#getId) and [SensitivityLabel::setId](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#setId) | Get or set the sensitivity label identifier in the Purview policy. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#getSiteId) and [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Get or set the site associated with the label policy. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#isEnabled) and [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Get or set whether the label is enabled. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#isRemoved) and [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Get or set whether the label has been removed. Set the value to `true` when the removal state must be retained in the metadata. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Get or set whether the label was applied automatically or through a user decision. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Get the content marking types associated with the label. |

The [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelassignmenttype/) class defines how a label was assigned:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelassignmenttype/) represents a default or automatically applied label.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelassignmenttype/) represents a label applied through a user decision, including manually applied, recommended, and mandatory labels.

The [SensitivityLabelContentType](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcontenttype/) class defines the marking associated with a label:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcontenttype/) | The label was applied by default or automatically. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcontenttype/) | Header content marking is associated with the label. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcontenttype/) | Footer content marking is associated with the label. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcontenttype/) | Watermark content marking is associated with the label. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcontenttype/) | Encryption protection is associated with the label. |

Multiple marking types can be associated with one label.

## **List Existing Sensitivity Labels**

Read the modern label collection from [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSensitivityLabels) and enumerate it. The following example lists every property and content marking stored for each label:

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

## **Add a Sensitivity Label with Content Marking**

Use [SensitivityLabelCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcollection/#add) with the label identifier, site identifier, enabled state, and assignment method. After the method returns the new [SensitivityLabel](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/), add the required marking values through the list returned by [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

The following example adds a manually selected label associated with footer and watermark markings, and then saves the result as PPTX:

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

## **Update a Sensitivity Label**

The [SensitivityLabel](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/) values are read/write, except that the list returned by [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) is modified through its list operations. After locating the required label, you can update its identifier, site identifier, enabled state, assignment method, removal state, and content marking types. Save the presentation to persist the changes.

The following example updates the enabled state and assignment method of the first label:

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

## **Mark a Sensitivity Label as Removed**

To preserve the fact that a label was removed, find the label and call [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#setRemoved) with `true`. This retains the label entry while recording its removed state. If you instead need to delete an entry from the modern collection, use [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); use [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcollection/#clear) to delete every entry.

The following example marks a specific label as removed and saves the updated presentation:

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

## **Read and Migrate Legacy MIP Sensitivity Labels**

Older MIP-based workflows can store sensitivity label metadata in custom document properties instead of the modern label collection. Read that metadata with [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getSensitivityLabels). The method parses the legacy custom properties and returns a Java array of [SensitivityLabel](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/) objects.

To migrate the metadata, add each returned label to the modern [SensitivityLabelCollection](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcollection/) through [SensitivityLabelCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcollection/#add). Because adding a duplicate label identifier raises an exception, the example checks the destination collection before copying each label. You can add further validation to confirm that each legacy label still exists in the current Purview policy.

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

The migration copies the parsed label objects into the modern collection. It does not require clearing all custom document properties, so unrelated document metadata remains intact. Use [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) with [SaveFormat::Pptx](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) to write the modern label metadata to a PPTX file.

## **FAQ**

**Does adding a content marking type create a visible header, footer, or watermark on slides?**

No. Values added through the list returned by [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) describe the markings associated with the sensitivity label. They do not create visible text or shapes in the presentation. Add the corresponding slide content separately if your workflow must render those markings.

**What is the difference between marking a label as removed and deleting it from the collection?**

Calling [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#setRemoved) with `true` keeps the label entry and records its removed state. Calling [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) deletes the entry from the modern collection. Choose the operation that matches your organization's metadata retention requirements.

**Can a presentation contain both legacy MIP metadata and modern sensitivity labels?**

Yes. Legacy labels can remain in custom document properties while modern labels are available through [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSensitivityLabels). Use [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getSensitivityLabels) to read the legacy metadata and migrate only the valid labels that are not already present in the modern collection.

**What happens when a label with the same identifier is added more than once?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabelcollection/#add) raises an exception when the collection already contains a label with the same identifier. Check existing values returned by [SensitivityLabel::getId](https://reference.aspose.com/slides/php-java/aspose.slides/sensitivitylabel/#getId) before adding or migrating labels.

**Which output format should be used to preserve updated sensitivity labels?**

Save the presentation as PPTX by calling [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) with [SaveFormat::Pptx](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/), as shown in the examples above.
