---
title: จัดการป้ายระดับความละเอียดในงานนำเสนอ PowerPoint ด้วย Python
linktitle: ป้ายระดับความละเอียด
type: docs
weight: 50
url: /th/python-net/sensitivity-labels/
keywords:
- ป้ายระดับความละเอียด
- Microsoft Purview
- Microsoft Information Protection
- เมตาดาต้า MIP
- การทำเครื่องหมายเนื้อหา
- การปกป้องข้อมูล
- การกำกับดูเอกสาร
- PowerPoint
- PPTX
- ความปลอดภัยของงานนำเสนอ
- Python
- Aspose.Slides
description: "อ่าน, เพิ่ม, ปรับปรุง, ลบ,และย้ายป้ายระดับความละเอียดของ Microsoft Purview ในงานนำเสนอ PowerPoint PPTX ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Microsoft Purview sensitivity labels ช่วยให้องค์กรจัดประเภทและควบคุมการจัดการเอกสารได้ ในกระบวนการประมวลผลงานนำเสนอแบบอัตโนมัติ แอปพลิเคชันอาจต้องรักษาป้ายระดับความละเอียดที่มีอยู่แล้ว ประยุกต์ใช้ป้ายที่นโยบายเลือกไว้ ปรับปรุงสถานะของป้าย หรือย้ายเมตาดาต้าป้ายที่สร้างโดยเวิร์กโฟลว์ Microsoft Information Protection (MIP) รุ่นเก่า

Aspose.Slides for Python via .NET เปิดเผยเมตาดาต้าป้ายระดับความละเอียดสมัยใหม่ผ่าน [Presentation.sensitivity_labels](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/sensitivity_labels/). คุณสมบัตินี้คืนค่า [SensitivityLabelCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcollection/) ที่สามารถตรวจสอบและแก้ไขได้ก่อนบันทึกงานนำเสนอเป็น PPTX

{{% alert color="primary" title="Note" %}}
ตัวระบุป้ายระดับความละเอียดและข้อมูลนโยบายถูกกำหนดโดยการกำหนดค่า Microsoft Purview ของคุณ ตรวจสอบความพร้อมใช้งานของป้ายและข้อกำหนดนโยบายในสภาพแวดล้อมของคุณก่อนเพิ่มหรือย้ายเมตาดาต้า ค่า [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/content_mark_types/) บรรยายประเภทเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้าย; ค่าดังกล่าวไม่ได้เพิ่มข้อความหรือรูปทรงที่มองเห็นได้ลงในสไลด์ด้วยตัวเอง
{{% /alert %}}

## **ทำความเข้าใจคุณสมบัติป้ายระดับความละเอียด**

แต่ละ [SensitivityLabel](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/) มีเมตาดาต้าดังต่อไปนี้:

| คุณสมบัติ | วัตถุประสงค์ |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/id/) | ระบุป้ายระดับความละเอียดในนโยบาย Purview |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/site_id/) | ระบุไซต์ที่เชื่อมโยงกับนโยบายป้าย |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/is_enabled/) | บ่งบอกว่าป้ายถูกเปิดใช้งานหรือไม่ |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/is_removed/) | บ่งบอกว่าป้ายถูกลบแล้ว ตั้งค่านี้เป็น `True` เมื่อสถานะการลบต้องถูกเก็บไว้ในเมตาดาต้า |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | ระบุว่าป้ายถูกประยุกต์โดยอัตโนมัติหรือผ่านการตัดสินใจของผู้ใช้ |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | แสดงรายการประเภทเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้าย |

การนับจำนวน [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelassignmenttype/) บรรยายวิธีการที่ป้ายถูกกำหนด:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelassignmenttype/) แทนป้ายเริ่มต้นหรือที่ประยุกต์อัตโนมัติ
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelassignmenttype/) แทนป้ายที่ประยุกต์ผ่านการตัดสินใจของผู้ใช้ รวมถึงป้ายที่ประยุกต์ด้วยตนเอง แนะนำ หรือบังคับใช้

การนับจำนวน [SensitivityLabelContentType](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcontenttype/) ระบุเครื่องหมายที่เชื่อมโยงกับป้าย:

| ค่า | ความหมาย |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcontenttype/) | ป้ายถูกประยุกต์โดยค่าเริ่มต้นหรืออัตโนมัติ |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcontenttype/) | มีเครื่องหมายเนื้อหาในส่วนหัวของสไลด์ |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcontenttype/) | มีเครื่องหมายเนื้อหาในส่วนท้ายของสไลด์ |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcontenttype/) | มีเครื่องหมายเนื้อหาเป็นลายน้ำ |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcontenttype/) | มีการป้องกันด้วยการเข้ารหัส |

หลายประเภทเครื่องหมายสามารถเชื่อมโยงกับป้ายเดียวกันได้

## **แสดงรายการป้ายระดับความละเอียดที่มีอยู่**

อ่านคอลเลกชันป้ายสมัยใหม่จาก [Presentation.sensitivity_labels](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/sensitivity_labels/) แล้วทำการวนลูป ตัวอย่างต่อไปนี้แสดงทุกคุณสมบัติและเครื่องหมายเนื้อหาที่เก็บไว้สำหรับแต่ละป้าย:

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

## **เพิ่มป้ายระดับความละเอียดพร้อมเครื่องหมายเนื้อหา**

ใช้ [SensitivityLabelCollection.add](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcollection/add/) พร้อมตัวระบุป้าย, ตัวระบุไซต์, สถานะเปิดใช้งาน, และวิธีการกำหนดค่า ส่งตัวระบุไซต์เป็นอ็อบเจ็กต์ Python `uuid.UUID` หลังจากเมธอดคืนค่า [SensitivityLabel](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/) ใหม่ให้เพิ่มค่าเครื่องหมายที่ต้องการลงใน [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/content_mark_types/)

ตัวอย่างต่อไปนี้เพิ่มป้ายที่ผู้ใช้เลือกด้วยตนเองโดยมีเครื่องหมายส่วนท้ายและลายน้ำ แล้วบันทึกผลลัพธ์เป็น PPTX:

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

## **อัปเดตป้ายระดับความละเอียด**

คุณสมบัติของ [SensitivityLabel](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/) สามารถอ่านและเขียนได้ ยกเว้นรายการที่คืนค่าจาก [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/content_mark_types/) ซึ่งต้องแก้ไขผ่านการดำเนินการของรายการ หลังจากค้นพบป้ายที่ต้องการ คุณสามารถอัปเดตตัวระบุ, ตัวระบุไซต์, สถานะเปิดใช้งาน, วิธีการกำหนดค่า, สถานะการลบ และประเภทเครื่องหมายเนื้อหา แล้วบันทึกงานนำเสนอเพื่อบันทึกการเปลี่ยนแปลง

ตัวอย่างต่อไปนี้อัปเดตสถานะเปิดใช้งานและวิธีการกำหนดค่าของป้ายแรก:

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

## **ทำเครื่องหมายป้ายระดับความละเอียดว่าเป็นการลบ**

เพื่อเก็บข้อมูลว่าป้ายถูกลบแล้ว ให้ค้นหาป้ายและตั้งค่า [SensitivityLabel.is_removed](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/is_removed/) เป็น `True` วิธีนี้จะรักษาบันทึกป้ายไว้พร้อมบันทึกสถานะการลบ หากต้องการลบบันทึกจากคอลเลกชันสมัยใหม่จริง ๆ ให้ใช้ [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); หรือใช้ [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcollection/clear/) เพื่อลบทุกรายการ

ตัวอย่างต่อไปนี้ทำเครื่องหมายป้ายเฉพาะว่าเป็นการลบแล้วบันทึกงานนำเสนอที่อัปเดตแล้ว:

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

## **อ่านและย้ายป้ายระดับความละเอียด MIP รุ่นเก่า**

เวิร์กโฟลว์ที่อิง MIP รุ่นเก่าสามารถเก็บเมตาดาต้าป้ายระดับความละเอียดในคุณสมบัติเสริมของเอกสารแทนคอลเลกชันป้ายสมัยใหม่ อ่านเมตาดาต้านั้นด้วย [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). เมธอดนี้จะแปลงคุณสมบัติพิเศษแบบเก่าและคืนค่าอ็อบเจ็กต์ [SensitivityLabel](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/)

เพื่อย้ายเมตาดาต้า ให้เพิ่มป้ายที่คืนค่ามาแต่ละรายการลงใน [SensitivityLabelCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcollection/) ผ่าน [SensitivityLabelCollection.add](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcollection/add/). เนื่องจากการเพิ่มป้ายที่มีตัวระบุซ้ำจะทำให้เกิดข้อยกเว้น ตัวอย่างจึงตรวจสอบคอลเลกชันปลายทางก่อนคัดลอกแต่ละป้าย คุณสามารถเพิ่มการตรวจสอบเพิ่มเติมเพื่อให้แน่ใจว่าป้ายเก่ายังคงอยู่ในนโยบาย Purview ปัจจุบัน

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

การย้ายจะคัดลอกอ็อบเจ็กต์ป้ายที่แปลงแล้วไปยังคอลเลกชันสมัยใหม่ ไม่จำเป็นต้องลบคุณสมบัติเสริมของเอกสารทั้งหมด ดังนั้นเมตาดาต้าเอกสารที่ไม่เกี่ยวข้องจะยังคงอยู่ ใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) ร่วมกับ [SaveFormat.PPTX](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/) เพื่อเขียนเมตาดาต้าป้ายสมัยใหม่ลงไฟล์ PPTX

## **คำถามที่พบบ่อย**

**การเพิ่มประเภทเครื่องหมายเนื้อหา จะทำให้หัวส่วน, ส่วนท้าย หรือลายน้ำปรากฏบนสไลด์หรือไม่?**

ไม่ ค่าใน [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/content_mark_types/) อธิบายเครื่องหมายที่เชื่อมโยงกับป้ายระดับความละเอียดเท่านั้น ไม่ได้สร้างข้อความหรือรูปทรงที่มองเห็นได้ในงานนำเสนอ หากขั้นตอนการทำงานของคุณต้องแสดงเครื่องหมายเหล่านั้น ให้เพิ่มเนื้อหาสไลด์ที่สอดคล้องกันแยกต่างหาก

**การทำเครื่องหมายป้ายว่าเป็นการลบ กับการลบป้ายออกจากคอลเลกชัน มีความแตกต่างอย่างไร?**

การตั้งค่า [SensitivityLabel.is_removed](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/is_removed/) เป็น `True` จะคงรายการป้ายไว้และบันทึกสถานะการลบ ส่วนการเรียกใช้ [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) จะลบรายการนั้นออกจากคอลเลกชันสมัยใหม่ เลือกกระบวนการที่สอดคล้องกับนโยบายการเก็บรักษาเมตาดาต้าขององค์กรคุณ

**งานนำเสนอสามารถมีเมตาดาต้า MIP รุ่นเก่าและป้ายระดับความละเอียดสมัยใหม่พร้อมกันได้หรือไม่?**

ได้ ป้ายรุ่นเก่าสามารถคงอยู่ในคุณสมบัติเสริมของเอกสารได้ในขณะที่ป้ายสมัยใหม่จะเข้าถึงได้ผ่าน [Presentation.sensitivity_labels](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/sensitivity_labels/). ใช้ [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) เพื่ออ่านเมตาดาต้าแบบเก่าและย้ายเฉพาะป้ายที่ยังไม่มีในคอลเลกชันสมัยใหม่

**หากเพิ่มป้ายที่มีตัวระบุเดียวกันหลายครั้ง จะเกิดอะไรขึ้น?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabelcollection/add/) จะโยนข้อยกเว้นเมื่อคอลเลกชันมีป้ายที่มีตัวระบุเดียวกันอยู่แล้ว ตรวจสอบค่าของ [SensitivityLabel.id](https://reference.aspose.com/slides/th/python-net/aspose.slides/sensitivitylabel/id/) ก่อนทำการเพิ่มหรือย้ายป้าย

**ควรใช้รูปแบบไฟล์ใดเพื่อรักษาป้ายระดับความละเอียดที่อัปเดต?**

บันทึกงานนำเสนอเป็น PPTX โดยเรียก [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) ร่วมกับ [SaveFormat.PPTX](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/) ตามที่แสดงในตัวอย่างข้างต้น