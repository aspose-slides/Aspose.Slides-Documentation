---
title: จัดการป้ายกำกับความอ่อนไหวในงานนำเสนอ PowerPoint ด้วย .NET
linktitle: ป้ายกำกับความอ่อนไหว
type: docs
weight: 50
url: /th/net/sensitivity-labels/
keywords:
- ป้ายกำกับความอ่อนไหว
- Microsoft Purview
- การป้องกันข้อมูลของ Microsoft
- เมทาดาต้า MIP
- การทำเครื่องหมายเนื้อหา
- การป้องกันข้อมูล
- การกำกับดูแลเอกสาร
- PowerPoint
- PPTX
- ความปลอดภัยของการนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "อ่าน, เพิ่ม, ปรับปรุง, ลบ, และย้ายป้ายกำกับความอ่อนไหวของ Microsoft Purview ในงานนำเสนอ PowerPoint PPTX ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Microsoft Purview sensitivity labels ช่วยให้องค์กรจัดประเภทและควบคุมเอกสารได้ ในระหว่างการประมวลผลการนำเสนออัตโนมัติ แอปพลิเคชันอาจต้องคงไว้ซึ่งป้ายกำกับที่มีอยู่แล้ว ใส่ป้ายที่เลือกโดยนโยบาย อัปเดตสภาพของมัน หรือย้ายเมทาดาต้าป้ายที่เขียนโดยกระบวนการ Microsoft Information Protection (MIP) รุ่นเก่า

Aspose.Slides เปิดเผยเมทาดาต้าป้ายกำกับความอ่อนไหวสมัยใหม่ผ่าน [Presentation.SensitivityLabels](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sensitivitylabels/). คุณสมบัตินี้คืนค่า [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/) ที่สามารถตรวจสอบและแก้ไขได้ก่อนบันทึกการนำเสนอเป็น PPTX.

{{% alert color="primary" title="Note" %}}
ตัวระบุป้ายกำกับความอ่อนไหวและข้อมูลนโยบายถูกกำหนดโดยการกำหนดค่า Microsoft Purview ของคุณ ตรวจสอบความพร้อมใช้งานของป้ายและข้อกำหนดนโยบายในสภาพแวดล้อมของคุณก่อนเพิ่มหรือย้ายเมทาดาต้า ค่าใน [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/contentmarktypes/) อธิบายการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้าย; พวกมันเองไม่ได้เพิ่มข้อความหรือรูปทรงที่มองเห็นได้บนสไลด์.
{{% /alert %}}

## **ทำความเข้าใจคุณสมบัติป้ายกำกับความอ่อนไหว**

| คุณสมบัติ | จุดประสงค์ |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/id/) | ระบุป้ายกำกับความอ่อนไหวในนโยบาย Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/siteid/) | ระบุไซต์ที่เชื่อมโยงกับนโยบายป้ายกำกับ. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/isenabled/) | ระบุว่าป้ายกำกับเปิดใช้งานหรือไม่. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/isremoved/) | ระบุว่าป้ายกำกับถูกลบแล้ว ตั้งค่าสิ่งนี้เป็น `true` เมื่อต้องการบันทึกสถานะการลบในเมทาดาต้า. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | กำหนดว่าป้ายกำกับถูกใส่โดยอัตโนมัติหรือผ่านการตัดสินใจของผู้ใช้. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/contentmarktypes/) | แสดงประเภทการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้ายกำกับ. |

การนับจำนวน [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelassignmenttype/) ระบุวิธีการที่ป้ายกำกับถูกกำหนด:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelassignmenttype/) แสดงป้ายกำกับเริ่มต้นหรือที่ใส่อัตโนมัติ.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelassignmenttype/) แสดงป้ายที่ใส่ผ่านการตัดสินใจของผู้ใช้ รวมถึงการใส่ด้วยตนเอง, แนะนำ, และบังคับ.

การนับจำนวน [SensitivityLabelContentType](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelcontenttype/) ระบุการทำเครื่องหมายที่เชื่อมโยงกับป้ายกำกับ:

| ค่า | ความหมาย |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelcontenttype/) | ป้ายกำกับถูกใส่โดยค่าเริ่มต้นหรืออัตโนมัติ. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาส่วนหัวเชื่อมโยงกับป้าย. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาส่วนท้ายเชื่อมโยงกับป้าย. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายวอเตอร์มาร์คเชื่อมโยงกับป้าย. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelcontenttype/) | การป้องกันด้วยการเข้ารหัสเชื่อมโยงกับป้าย. |

หลายประเภทการทำเครื่องหมายสามารถเชื่อมโยงกับป้ายเดียวได้.

## **แสดงรายการป้ายกำกับความอ่อนไหวที่มีอยู่**

อ่านคอลเลกชันป้ายสมัยใหม่จาก [Presentation.SensitivityLabels](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sensitivitylabels/) และทำการวนลูป แสดงตัวอย่างต่อไปนี้แสดงคุณสมบัติและการทำเครื่องหมายเนื้อหาที่จัดเก็บสำหรับแต่ละป้าย:

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

## **เพิ่มป้ายกำกับความอ่อนไหวพร้อมการทำเครื่องหมายเนื้อหา**

ใช้ [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/add/) กับตัวระบุป้าย, ตัวระบุไซต์, สภาพการเปิดใช้งาน, และวิธีการกำหนด หลังจากเมธอดคืนค่า [ISensitivityLabel](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/) ใหม่ ให้เพิ่มค่าการทำเครื่องหมายที่จำเป็นผ่าน [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/contentmarktypes/).

ตัวอย่างต่อไปนี้เพิ่มป้ายที่เลือกด้วยตนเองซึ่งเชื่อมโยงกับการทำเครื่องหมายส่วนท้ายและวอเตอร์มาร์ค แล้วบันทึกผลลัพธ์เป็น PPTX:

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

## **อัปเดตป้ายกำกับความอ่อนไหว**

คุณสมบัติของ [ISensitivityLabel](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/) สามารถอ่าน/เขียนได้ ยกเว้นคอลเลกชันที่คืนค่าจาก [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/contentmarktypes/) จะถูกแก้ไขผ่านการดำเนินการรายการ หลังจากค้นหาป้ายที่ต้องการ คุณสามารถอัปเดตตัวระบุ, ตัวระบุไซต์, สภาพการเปิดใช้งาน, วิธีการกำหนด, สภาพการลบ, และประเภทการทำเครื่องหมายเนื้อหา บันทึกการนำเสนอเพื่อบันทึกการเปลี่ยนแปลง

ตัวอย่างต่อไปนี้อัปเดตสภาพการเปิดใช้งานและวิธีการกำหนดของป้ายแรก:

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

## **ทำเครื่องหมายป้ายกำกับความอ่อนไหวว่าเป็นการลบ**

เพื่อคงไว้ซึ่งข้อเท็จจริงว่าป้ายถูกลบ ให้ค้นหาป้ายและตั้ง [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/isremoved/) เป็น `true` สิ่งนี้จะรักษารายการป้ายไว้พร้อมบันทึกสถานะการลบ หากต้องการลบรายการจากคอลเลกชันสมัยใหม่ ให้ใช้ [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/removeat/); ใช้ [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/clear/) เพื่อลบทุกรายการ

ตัวอย่างต่อไปนี้ทำเครื่องหมายป้ายเฉพาะว่าเป็นการลบและบันทึกการนำเสนอที่อัปเดต:

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

## **อ่านและย้ายป้ายกำกับความอ่อนไหว MIP รุ่นเก่า**

เวิร์กโฟลว์ที่อิง MIP รุ่นเก่าสามารถเก็บเมทาดาต้าป้ายกำกับความอ่อนไหวในคุณสมบัติเ�เอกสารที่กำหนดเองแทนคอลเลกชันสมัยใหม่ อ่านเมทาดาต้านั้นด้วย [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/getsensitivitylabels/). เมธอดจะวิเคราะห์คุณสมบัติกำหนดเองรุ่นเก่าและคืนค่าอาเรย์ของวัตถุ [ISensitivityLabel](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/).

เพื่อย้ายเมทาดาต้า ให้เพิ่มป้ายที่คืนค่ามาแต่ละอันไปยัง [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/) สมัยใหม่ผ่าน [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/add/). เนื่องจากการเพิ่มป้ายที่มีตัวระบุซ้ำจะทำให้เกิดข้อยกเว้น ตัวอย่างจึงตรวจสอบคอลเลกชันเป้าหมายก่อนคัดลอกแต่ละป้าย คุณสามารถเพิ่มการตรวจสอบเพิ่มเติมเพื่อยืนยันว่าป้ายรุ่นเก่ายังคงมีอยู่ในนโยบาย Purview ปัจจุบันหรือไม่

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

การย้ายจะคัดลอกวัตถุป้ายที่วิเคราะห์แล้วเข้าไปในคอลเลกชันสมัยใหม่ ไม่จำเป็นต้องลบคุณสมบัติเ�เอกสารที่กำหนดเองทั้งหมด ดังนั้นเมทาดาต้าเอกสารที่ไม่เกี่ยวข้องจึงคงอยู่ใช้ได้ ใช้ [IPresentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/save/) ร่วมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) เพื่อเขียนเมทาดาต้าป้ายสมัยใหม่ลงในไฟล์ PPTX

## **คำถามที่พบบ่อย**

**การเพิ่มประเภทการทำเครื่องหมายเนื้อหาจะสร้างส่วนหัว, ส่วนท้าย หรือวอเตอร์มาร์คที่มองเห็นได้บนสไลด์หรือไม่?**

ไม่ ค่าที่เพิ่มผ่าน [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/contentmarktypes/) อธิบายการทำเครื่องหมายที่เชื่อมโยงกับป้ายกำกับความอ่อนไหว พวกมันไม่สร้างข้อความหรือรูปทรงที่มองเห็นได้ในงานนำเสนอ ให้เพิ่มเนื้อหาสไลด์ที่สอดคล้องกันแยกต่างหากหากเวิร์กโฟลว์ของคุณต้องการแสดงการทำเครื่องหมายเหล่านั้น

**ความแตกต่างระหว่างทำเครื่องหมายป้ายว่าเป็นการลบและการลบออกจากคอลเลกชันคืออะไร?**

การตั้งค่า [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/isremoved/) เป็น `true` จะเก็บรายการป้ายไว้และบันทึกสถานะการลบ การเรียกใช้ [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/removeat/) จะลบรายการออกจากคอลเลกชันสมัยใหม่ เลือกการดำเนินการที่สอดคล้องกับความต้องการการเก็บเมทาดาต้าขององค์กรของคุณ

**งานนำเสนอสามารถมีเมทาดาต้า MIP รุ่นเก่าและป้ายกำกับความอ่อนไหวสมัยใหม่พร้อมกันได้หรือไม่?**

ได้ ป้ายรุ่นเก่าสามารถคงอยู่ในคุณสมบัติเ�เอกสารที่กำหนดเองในขณะที่ป้ายสมัยใหม่เข้าถึงได้ผ่าน [Presentation.SensitivityLabels](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sensitivitylabels/). ใช้ [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/getsensitivitylabels/) เพื่ออ่านเมทาดาต้าเก่าและย้ายเฉพาะป้ายที่ยังไม่ปรากฏในคอลเลกชันสมัยใหม่

**เกิดอะไรขึ้นเมื่อป้ายที่มีตัวระบุเดียวกันถูกเพิ่มหลายครั้ง?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/add/) จะโยน `ArgumentException` เมื่อคอลเลกชันมีป้ายที่มีตัวระบุเดียวกันอยู่แล้ว ตรวจสอบค่าของ [ISensitivityLabel.Id](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/id/) ก่อนทำการเพิ่มหรือย้ายป้าย

**ควรใช้รูปแบบไฟล์ใดเพื่อรักษาป้ายกำกับความอ่อนไหวที่อัปเดต?**

บันทึกงานนำเสนอเป็น PPTX โดยเรียก [IPresentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/save/) ร่วมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/), ตามที่แสดงในตัวอย่างข้างต้น.