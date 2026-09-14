---
title: จัดการป้ายความอ่อนไหวในงานนำเสนอ PowerPoint ด้วย Python
linktitle: ป้ายความอ่อนไหว
type: docs
weight: 50
url: /th/python-java/sensitivity-labels/
keywords:
- ป้ายความอ่อนไหว
- Microsoft Purview
- Microsoft Information Protection
- เมตาดาต้า MIP
- การทำเครื่องหมายเนื้อหา
- การปกป้องข้อมูล
- การกำกับดูแลเอกสาร
- PowerPoint
- PPTX
- ความปลอดภัยของงานนำเสนอ
- Python
- Aspose.Slides
description: "อ่าน, เพิ่ม, ปรับปรุง, ลบ, และย้ายป้ายความอ่อนไหวของ Microsoft Purview ในงานนำเสนอ PowerPoint PPTX ด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **Overview**

Microsoft Purview sensitivity labels help organizations classify and govern documents. During automated presentation processing, an application may need to preserve an existing label, apply a label selected by a policy, update its state, or migrate label metadata written by an older Microsoft Information Protection (MIP) workflow.

Aspose.Slides exposes modern sensitivity label metadata through [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSensitivityLabels). This method returns an [SensitivityLabelCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcollection/) that can be inspected and modified before the presentation is saved as PPTX.

{{% alert color="info" title="Note" %}}
Sensitivity label identifiers and policy information are defined by your Microsoft Purview configuration. Validate label availability and policy requirements in your environment before adding or migrating metadata. The [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) values describe the content markings associated with a label; they do not by themselves add visible text or shapes to slides.
{{% /alert %}}

## **ทำความเข้าใจคุณสมบัติป้ายความอ่อนไหว**

Each [SensitivityLabel](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/) contains the following metadata:

| เมธอด | วัตถุประสงค์ |
| --- | --- |
| [getId](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#getId) and [setId](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#setId) | รับหรือกำหนดตัวระบุป้ายความอ่อนไหวในนโยบาย Purview |
| [getSiteId](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#getSiteId) and [setSiteId](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#setSiteId) | รับหรือกำหนดไซต์ที่เชื่อมโยงกับนโยบายป้าย |
| [isEnabled](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#isEnabled) and [setEnabled](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#setEnabled) | รับหรือกำหนดว่าป้ายเปิดใช้งานหรือไม่ |
| [isRemoved](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#isRemoved) and [setRemoved](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#setRemoved) | รับหรือกำหนดว่าป้ายถูกลบหรือไม่ ตั้งค่าเป็น `True` เมื่อต้องคงสถานะการลบในเมตาดาต้า |
| [getAssignmentMethodType](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) and [setAssignmentMethodType](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | รับหรือกำหนดว่าป้ายถูกนำไปใช้โดยอัตโนมัติหรือผ่านการตัดสินใจของผู้ใช้ |
| [getContentMarkTypes](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | รับประเภทการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้าย |

The [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelassignmenttype/) class defines how a label was assigned:

- [Standard](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelassignmenttype/) แสดงป้ายเริ่มต้นหรือที่ถูกนำไปใช้โดยอัตโนมัติ
- [Privileged](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelassignmenttype/) แสดงป้ายที่นำไปใช้ผ่านการตัดสินใจของผู้ใช้ รวมถึงป้ายที่นำไปใช้ด้วยตนเอง, แนะนำ, และบังคับใช้

The [SensitivityLabelContentType](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcontenttype/) class defines the marking associated with a label:

| ค่า | ความหมาย |
| --- | --- |
| [None](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcontenttype/) | ป้ายถูกนำไปใช้โดยค่าเริ่มต้นหรือโดยอัตโนมัติ |
| [Header](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาส่วนหัวเชื่อมโยงกับป้าย |
| [Footer](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาส่วนท้ายเชื่อมโยงกับป้าย |
| [Watermark](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาน้ำลายน้ำเชื่อมโยงกับป้าย |
| [Encryption](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcontenttype/) | การป้องกันด้วยการเข้ารหัสเชื่อมโยงกับป้าย |

สามารถเชื่อมโยงหลายประเภทการทำเครื่องหมายกับป้ายเดียวได้.

## **แสดงรายการป้ายความอ่อนไหวที่มีอยู่**

Read the modern label collection from [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSensitivityLabels) and enumerate it. The following example lists every property and content marking stored for each label:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **เพิ่มป้ายความอ่อนไหวพร้อมการทำเครื่องหมายเนื้อหา**

Use [SensitivityLabelCollection.add](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcollection/#add) with the label identifier, site identifier, enabled state, and assignment method. After the method returns the new [SensitivityLabel](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/), add the required marking values through the list returned by [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

The following example adds a manually selected label associated with footer and watermark markings, and then saves the result as PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **อัปเดตป้ายความอ่อนไหว**

The [SensitivityLabel](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/) values are read/write, except that the list returned by [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) is modified through its list operations. After locating the required label, you can update its identifier, site identifier, enabled state, assignment method, removal state, and content marking types. Save the presentation to persist the changes.

The following example updates the enabled state and assignment method of the first label:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ทำเครื่องหมายป้ายความอ่อนไหวเป็นการลบ**

To preserve the fact that a label was removed, find the label and call [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#setRemoved) with `True`. This retains the label entry while recording its removed state. If you instead need to delete an entry from the modern collection, use [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); use [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcollection/#clear) to delete every entry.

The following example marks a specific label as removed and saves the updated presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **อ่านและย้ายป้ายความอ่อนไหว MIP รุ่นเก่า**

Older MIP-based workflows can store sensitivity label metadata in custom document properties instead of the modern label collection. Read that metadata with [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getSensitivityLabels). The method parses the legacy custom properties and returns an array of [SensitivityLabel](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/) objects.

To migrate the metadata, add each returned label to the modern [SensitivityLabelCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcollection/) through [SensitivityLabelCollection.add](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcollection/#add). Because adding a duplicate label identifier raises an exception, the example checks the destination collection before copying each label. You can add further validation to confirm that each legacy label still exists in the current Purview policy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The migration copies the parsed label objects into the modern collection. It does not require clearing all custom document properties, so unrelated document metadata remains intact. Use [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) with [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/) to write the modern label metadata to a PPTX file.

## **คำถามที่พบบ่อย**

**การเพิ่มประเภทการทำเครื่องหมายเนื้อหาจะสร้างส่วนหัว, ส่วนท้าย หรือภาพลายน้ำที่มองเห็นได้บนสไลด์หรือไม่?**

No. Values added through the list returned by [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) describe the markings associated with the sensitivity label. They do not create visible text or shapes in the presentation. Add the corresponding slide content separately if your workflow must render those markings.

**ความแตกต่างระหว่างการทำเครื่องหมายป้ายว่าเป็นการลบกับการลบออกจากคอลเลกชันคืออะไร?**

Calling [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#setRemoved) with `True` keeps the label entry and records its removed state. Calling [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) deletes the entry from the modern collection. Choose the operation that matches your organization's metadata retention requirements.

**การนำเสนอสามารถมีเมตาดาต้า MIP รุ่นเก่าและป้ายความอ่อนไหวสมัยใหม่พร้อมกันได้หรือไม่?**

Yes. Legacy labels can remain in custom document properties while modern labels are available through [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSensitivityLabels). Use [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getSensitivityLabels) to read the legacy metadata and migrate only the valid labels that are not already present in the modern collection.

**อะไรจะเกิดขึ้นเมื่อมีการเพิ่มป้ายที่มีตัวระบุเดียวกันหลายครั้ง?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabelcollection/#add) raises an exception when the collection already contains a label with the same identifier. Check existing values returned by [SensitivityLabel.getId](https://reference.aspose.com/slides/th/python-java/aspose.slides/sensitivitylabel/#getId) before adding or migrating labels.

**รูปแบบผลลัพธ์ใดที่ควรใช้เพื่อรักษาป้ายความอ่อนไหวที่อัปเดต?**

Save the presentation as PPTX by calling [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) with [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/), as shown in the examples above.