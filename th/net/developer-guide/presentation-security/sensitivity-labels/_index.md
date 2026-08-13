---
title: จัดการป้ายกำกับความละเอียดอ่อนในงานพรีเซนเทชัน PowerPoint ด้วย .NET
linktitle: ป้ายกำกับความละเอียดอ่อน
type: docs
weight: 50
url: /th/net/sensitivity-labels/
keywords:
- ป้ายความละเอียดอ่อน
- Microsoft Purview
- Microsoft Information Protection
- เมทาดาต้า MIP
- การทำเครื่องหมายเนื้อหา
- การปกป้องข้อมูล
- การกำกับดูแลเอกสาร
- PowerPoint
- PPTX
- ความปลอดภัยของพรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "อ่าน, เพิ่ม, อัปเดต, ลบ และย้ายป้ายความละเอียดอ่อนของ Microsoft Purview ในงานพรีเซนเทชัน PowerPoint PPTX ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Microsoft Purview sensitivity labels ช่วยให้องค์กรจัดประเภทและกำกับดูแลเอกสารได้ ในระหว่างการประมวลผลพรีเซนเทชันอัตโนมัติ แอปพลิเคชันอาจต้องคงรักษาป้ายที่มีอยู่เดิม, ใช้ป้ายที่เลือกโดยนโยบาย, ปรับปรุงสถานะของมัน, หรือย้ายข้อมูลเมทาดาทาป้ายที่เขียนโดยเวิร์กฟลอว์ Microsoft Information Protection (MIP) เวอร์ชันเก่า

Aspose.Slides เปิดเผยเมทาดาทาป้ายกำกับความละเอียดอ่อนสมัยใหม่ผ่าน [Presentation.SensitivityLabels](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sensitivitylabels/). คุณสมบัตินี้คืนค่า [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/) ที่สามารถตรวจสอบและแก้ไขได้ก่อนบันทึกพรีเซนเทชันเป็น PPTX

{{% alert color="info" title="Note" %}}
ตัวระบุป้ายกำกับความละเอียดอ่อนและข้อมูลนโยบายถูกกำหนดโดยการกำหนดค่า Microsoft Purview ของคุณ ตรวจสอบความพร้อมของป้ายและความต้องการของนโยบายในสภาพแวดล้อมของคุณก่อนเพิ่มหรือย้ายเมทาดาต้า ค่าของ [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/contentmarktypes/) บรรยายการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้าย; ค่าดังกล่าวไม่เพิ่มข้อความหรือรูปทรงที่มองเห็นได้ลงบนสไลด์ด้วยตนเอง
{{% /alert %}}

## **ทำความเข้าใจคุณสมบัติป้ายกำกับความละเอียดอ่อน**

แต่ละ [ISensitivityLabel](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/) มีเมทาดาทาต่อไปนี้:

| คุณสมบัติ | วัตถุประสงค์ |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/id/) | ระบุป้ายกำกับความละเอียดอ่อนในนโยบายของ Purview |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/siteid/) | ระบุไซต์ที่เชื่อมโยงกับนโยบายป้าย |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/isenabled/) | บ่งชี้ว่าป้ายถูกเปิดใช้งานหรือไม่ |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/isremoved/) | บ่งชี้ว่าป้ายได้ถูกลบออกแล้ว ตั้งค่าสินค้านี้เป็น `true` เมื่อสถานะการลบต้องการคงอยู่ในเมทาดาทา |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | กำหนดว่าป้ายถูกใช้โดยอัตโนมัติหรือผ่านการตัดสินใจของผู้ใช้ |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/contentmarktypes/) | รายการประเภทการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้าย |

Enumeration [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelassignmenttype/) อธิบายว่าได้กำหนดป้ายอย่างไร:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelassignmenttype/) แสดงถึงป้ายเริ่มต้นหรือป้ายที่กำหนดโดยอัตโนมัติ
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelassignmenttype/) แสดงถึงป้ายที่กำหนดผ่านการตัดสินใจของผู้ใช้ รวมถึงป้ายที่กำหนดด้วยตนเอง, แนะนำ, และบังคับใช้

Enumeration [SensitivityLabelContentType](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelcontenttype/) ระบุการทำเครื่องหมายที่เชื่อมโยงกับป้าย:

| ค่า | ความหมาย |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelcontenttype/) | ป้ายถูกกำหนดโดยค่าเริ่มต้นหรือโดยอัตโนมัติ |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาส่วนหัวเชื่อมโยงกับป้าย |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาส่วนท้ายเชื่อมโยงกับป้าย |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาน้ำรูปเชื่อมโยงกับป้าย |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/th/net/aspose.slides/sensitivitylabelcontenttype/) | การป้องกันการเข้ารหัสเชื่อมโยงกับป้าย |

หลายประเภทการทำเครื่องหมายสามารถเชื่อมโยงกับป้ายเดียวได้

## **แสดงรายการป้ายกำกับความละเอียดอ่อนที่มีอยู่**

อ่านคอลเลกชันป้ายสมัยใหม่จาก [Presentation.SensitivityLabels](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sensitivitylabels/) และทำการวนลูป ตัวอย่างต่อไปนี้แสดงทุกคุณสมบัติและการทำเครื่องหมายเนื้อหาที่เก็บสำหรับแต่ละป้าย:

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

## **เพิ่มป้ายกำกับความละเอียดอ่อนพร้อมการทำเครื่องหมายเนื้อหา**

ใช้ [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/add/) พร้อมตัวระบุป้าย, ตัวระบุไซต์, สถานะเปิดใช้งาน, และวิธีการกำหนด หลังจากเมธอดคืนค่า [ISensitivityLabel](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/) ใหม่ ให้เพิ่มค่าการทำเครื่องหมายที่ต้องการผ่าน [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/contentmarktypes/)

ตัวอย่างต่อไปนี้เพิ่มป้ายที่เลือกด้วยตนเองซึ่งเชื่อมโยงกับการทำเครื่องหมายส่วนท้ายและน้ำรูป, แล้วบันทึกผลลัพธ์เป็น PPTX:

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

## **อัปเดตป้ายกำกับความละเอียดอ่อน**

คุณสมบัติของ [ISensitivityLabel](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/) สามารถอ่าน/เขียนได้ ยกเว้นคอลเลกชันที่คืนค่าโดย [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/contentmarktypes/) จะถูกแก้ไขผ่านการดำเนินการรายการหลังจากค้นพบป้ายที่ต้องการ คุณสามารถอัปเดตตัวระบุ, ตัวระบุไซต์, สถานะเปิดใช้งาน, วิธีการกำหนด, สถานะการลบ, และประเภทการทำเครื่องหมายเนื้อหา แล้วบันทึกพรีเซนเทชันเพื่อบันทึกการเปลี่ยนแปลง

ตัวอย่างต่อไปนี้อัปเดตสถานะเปิดใช้งานและวิธีการกำหนดของป้ายแรก:

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

## **ทำเครื่องหมายป้ายกำกับความละเอียดอ่อนว่าได้ถูกลบ**

เพื่อคงรักษาข้อเท็จจริงว่าป้ายถูกลบ ให้ค้นหาป้ายและตั้งค่า [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/isremoved/) เป็น `true` การทำเช่นนี้จะคงรายการป้ายไว้พร้อมบันทึกสถานะการลบ หากคุณต้องการลบรายการออกจากคอลเลกชันสมัยใหม่ให้ใช้ [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/removeat/) ; ใช้ [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/clear/) เพื่อลบทุกรายการ

ตัวอย่างต่อไปนี้ทำเครื่องหมายป้ายเฉพาะว่าได้ถูกลบและบันทึกพรีเซนเทชันที่อัปเดต:

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

## **อ่านและย้ายป้ายกำกับความละเอียดอ่อนรุ่นเก่า MIP**

เวิร์กฟลอว์เก่าที่ใช้ MIP สามารถเก็บเมทาดาทาป้ายกำกับความละเอียดอ่อนในคุณสมบัติเสมือนเอกสารแบบกำหนดเองแทนคอลเลกชันป้ายสมัยใหม่ อ่านเมทาดาต้านั้นด้วย [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/getsensitivitylabels/). เมธอดจะวิเคราะห์คุณสมบัติเฉพาะที่กำหนดเองแบบเก่าและคืนค่าอาเรย์ของวัตถุ [ISensitivityLabel](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/)

เพื่อย้ายเมทาดาต้า ให้เพิ่มแต่ละป้ายที่ได้คืนค่าเข้าสู่ [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/) สมัยใหม่ผ่าน [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/add/). เนื่องจากการเพิ่มตัวระบุป้ายที่ซ้ำกันทำให้เกิดข้อยกเว้น ตัวอย่างจึงตรวจสอบคอลเลกชันปลายทางก่อนคัดลอกแต่ละป้าย คุณสามารถเพิ่มการตรวจสอบเพิ่มเติมเพื่อยืนยันว่าป้ายรุ่นเก่ายังคงมีอยู่ในนโยบาย Purview ปัจจุบัน

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

การย้ายข้อมูลจะคัดลอกวัตถุป้ายที่วิเคราะห์แล้วเข้าสู่คอลเลกชันสมัยใหม่ ไม่จำเป็นต้องล้างคุณสมบัติเสมือนเอกสารทั้งหมด ดังนั้นเมทาดาต้าอื่นของเอกสารที่ไม่เกี่ยวข้องจะคงอยู่ ใช้ [IPresentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/save/) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) เพื่อเขียนเมทาดาทาป้ายสมัยใหม่ลงในไฟล์ PPTX

## **คำถามที่พบบ่อย**

**การเพิ่มประเภทการทำเครื่องหมายเนื้อหาจะสร้างส่วนหัว, ส่วนท้าย หรือวอเตอร์มาร์คที่มองเห็นได้บนสไลด์หรือไม่?**

No. ค่าที่เพิ่มผ่าน [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/contentmarktypes/) บรรยายการทำเครื่องหมายที่เชื่อมโยงกับป้ายกำกับความละเอียดอ่อน ไม่ได้สร้างข้อความหรือรูปร่างที่มองเห็นได้ในพรีเซนเทชัน หากกระบวนการของคุณต้องการแสดงการทำเครื่องหมายเหล่านั้น ให้เพิ่มเนื้อหาในสไลด์แยกต่างหาก

**ความแตกต่างระหว่างการทำเครื่องหมายป้ายว่าได้ถูกลบและการลบออกจากคอลเลกชันคืออะไร?**

การตั้งค่า [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/isremoved/) เป็น `true` จะคงรายการป้ายไว้และบันทึกสถานะการลบ ส่วนการเรียก [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/removeat/) จะลบรายการออกจากคอลเลกชันสมัยใหม่ เลือกใช้งานตามความต้องการในการเก็บรักษาเมทาดาต้าขององค์กรของคุณ

**พรีเซนเทชันสามารถมีเมทาดาทา MIP รุ่นเก่าและป้ายกำกับความละเอียดอ่อนสมัยใหม่พร้อมกันได้หรือไม่?**

Yes. ป้ายรุ่นเก่าสามารถคงอยู่ในคุณสมบัติเสมือนเอกสารแบบกำหนดเองได้ในขณะที่ป้ายสมัยใหม่เข้าถึงได้ผ่าน [Presentation.SensitivityLabels](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/sensitivitylabels/). ใช้ [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/th/net/aspose.slides/idocumentproperties/getsensitivitylabels/) เพื่ออ่านเมทาดาต้าแบบเก่าและย้ายเฉพาะป้ายที่ยังไม่มีอยู่ในคอลเลกชันสมัยใหม่

**จะเกิดอะไรขึ้นเมื่อเพิ่มป้ายที่มีตัวระบุเดียวกันหลายครั้ง?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabelcollection/add/) จะโยน `ArgumentException` หากคอลเลกชันมีป้ายที่มีตัวระบุเดียวกันอยู่แล้ว ตรวจสอบค่าของ [ISensitivityLabel.Id](https://reference.aspose.com/slides/th/net/aspose.slides/isensitivitylabel/id/) ก่อนทำการเพิ่มหรือย้ายป้าย

**ควรใช้รูปแบบไฟล์ใดในการบันทึกเพื่อคงรักษาป้ายกำกับความละเอียดอ่อนที่อัปเดต?**

บันทึกพรีเซนเทชันเป็น PPTX โดยเรียก [IPresentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/save/) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) ตามที่แสดงในตัวอย่างข้างต้น