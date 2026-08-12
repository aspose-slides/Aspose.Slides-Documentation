---
title: จัดการป้ายความอ่อนไหวในงานนำเสนอ PowerPoint ด้วย Java
linktitle: ป้ายความอ่อนไหว
type: docs
weight: 50
url: /th/java/sensitivity-labels/
keywords:
- ป้ายความอ่อนไหว
- Microsoft Purview
- Microsoft Information Protection
- เมตาข้อมูล MIP
- การทำเครื่องหมายเนื้อหา
- การปกป้องข้อมูล
- การกำหนดแนวนโยบายเอกสาร
- PowerPoint
- PPTX
- ความปลอดภัยของงานนำเสนอ
- Java
- Aspose.Slides
description: "อ่าน เพิ่ม อัปเดต ลบ และย้ายป้ายความอ่อนไหวของ Microsoft Purview ในงานนำเสนอ PowerPoint PPTX ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Microsoft Purview sensitivity labels ช่วยองค์กรในการจัดประเภทและจัดการเอกสาร ระหว่างการประมวลผลพรีเซนเทชันอัตโนมัติ แอปพลิเคชันอาจต้องเก็บรักษาป้ายที่มีอยู่แล้ว ใช้ป้ายที่เลือกโดยนโยบาย อัปเดตสถานะของมัน หรือย้ายข้อมูลเมตาป้ายที่เขียนโดยกระบวนการทำงาน Microsoft Information Protection (MIP) รุ่นเก่า

Aspose.Slides เปิดเผยข้อมูลเมตาป้ายความอ่อนไหวสมัยใหม่ผ่าน [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). วิธีการนี้จะคืนค่า [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/) ที่สามารถตรวจสอบและแก้ไขได้ก่อนบันทึกพรีเซนเทชันเป็น PPTX.

{{% alert color="primary" title="Note" %}}
ตัวระบุป้ายความอ่อนไหวและข้อมูลนโยบายถูกกำหนดโดยการกำหนดค่า Microsoft Purview ของคุณ ตรวจสอบความพร้อมใช้งานของป้ายและข้อกำหนดนโยบายในสภาพแวดล้อมของคุณก่อนเพิ่มหรือย้ายข้อมูลเมตา ค่าของ [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) อธิบายการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้าย; พวกมันเองไม่ได้เพิ่มข้อความหรือรูปร่างที่มองเห็นได้บนสไลด์
{{% /alert %}}

## **ทำความเข้าใจคุณสมบัติของป้ายความอ่อนไหว**

แต่ละ [ISensitivityLabel](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/) มีเมตาข้อมูลต่อไปนี้:

| Methods | Purpose |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getId--) และ [ISensitivityLabel.setId](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | รับหรือกำหนดตัวระบุป้ายความอ่อนไหวในนโยบายของ Purview |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getSiteId--) และ [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | รับหรือกำหนดไซต์ที่เชื่อมโยงกับนโยบายของป้าย |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#isEnabled--) และ [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | รับหรือกำหนดว่าป้ายเปิดใช้งานหรือไม่ |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#isRemoved--) และ [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | รับหรือกำหนดว่าป้ายถูกลบหรือไม่ ตั้งค่าเป็น `true` เมื่อต้องการเก็บสถานะการลบไว้ในข้อมูลเมตา |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) และ [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | รับหรือกำหนดว่าป้ายถูกนำไปใช้โดยอัตโนมัติหรือผ่านการตัดสินใจของผู้ใช้ |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | รับประเภทการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้าย |

คลาส [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelassignmenttype/) กำหนดวิธีการที่ป้ายถูกกำหนด:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelassignmenttype/) แสดงป้ายเริ่มต้นหรือที่นำไปใช้โดยอัตโนมัติ
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelassignmenttype/) แสดงป้ายที่นำไปใช้ผ่านการตัดสินใจของผู้ใช้ รวมถึงป้ายที่นำไปใช้ด้วยตนเอง, แนะนำ, และบังคับใช้

คลาส [SensitivityLabelContentType](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelcontenttype/) กำหนดการทำเครื่องหมายที่เชื่อมโยงกับป้าย:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelcontenttype/) | ป้ายถูกนำไปใช้โดยค่าเริ่มต้นหรือโดยอัตโนมัติ |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหา Header เชื่อมโยงกับป้าย |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหา Footer เชื่อมโยงกับป้าย |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหา Watermark เชื่อมโยงกับป้าย |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelcontenttype/) | การปกป้องด้วยการเข้ารหัสเชื่อมโยงกับป้าย |

สามารถเชื่อมโยงหลายประเภทการทำเครื่องหมายกับป้ายเดียวได้

## **แสดงรายการป้ายความอ่อนไหวที่มีอยู่**

อ่านคอลเลกชันป้ายสมัยใหม่จาก [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) และทำการวนรอบ ตัวอย่างต่อไปนี้แสดงรายการคุณสมบัติและการทำเครื่องหมายเนื้อหาที่จัดเก็บสำหรับแต่ละป้าย:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **เพิ่มป้ายความอ่อนไหวพร้อมการทำเครื่องหมายเนื้อหา**

ใช้ [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) พร้อมกับตัวระบุป้าย, ตัวระบุไซต์, สถานะเปิดใช้งาน, และวิธีการกำหนด หลังจากเมธอดคืนค่าป้ายใหม่ [ISensitivityLabel](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/), ให้เพิ่มค่าการทำเครื่องหมายที่จำเป็นผ่านรายการที่คืนโดย [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

ตัวอย่างต่อไปนี้เพิ่มป้ายที่เลือกด้วยตนเองซึ่งเชื่อมโยงกับการทำเครื่องหมาย footer และ watermark, แล้วบันทึกผลลัพธ์เป็น PPTX:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **อัปเดตป้ายความอ่อนไหว**

ค่าใน [ISensitivityLabel](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/) สามารถอ่าน/เขียนได้ ยกเว้นรายการที่คืนโดย [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) จะถูกแก้ไขผ่านการดำเนินการของรายการนั้น หลังจากค้นพบป้ายที่ต้องการ คุณสามารถอัปเดตตัวระบุ, ตัวระบุไซต์, สถานะเปิดใช้งาน, วิธีการกำหนด, สถานะการลบ, และประเภทการทำเครื่องหมายเนื้อหาได้ บันทึกพรีเซนเทชันเพื่อบันทึกการเปลี่ยนแปลง

ตัวอย่างต่อไปนี้อัปเดตสถานะเปิดใช้งานและวิธีการกำหนดของป้ายแรก:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ทำเครื่องหมายป้ายความอ่อนไหวว่าได้ลบแล้ว**

เพื่อเก็บข้อมูลว่าป้ายถูกลบแล้ว ให้ค้นหาป้ายและเรียก [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) ด้วย `true` วิธีนี้จะเก็บรายการป้ายไว้ขณะบันทึกสถานะการลบ หากต้องการลบรายการออกจากคอลเลกชันสมัยใหม่ ให้ใช้ [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); ใช้ [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/#clear--) เพื่อลบรายการทั้งหมด

ตัวอย่างต่อไปนี้ทำเครื่องหมายป้ายเฉพาะว่าถูกลบแล้วและบันทึกพรีเซนเทชันที่อัปเดต:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **อ่านและย้ายป้ายความอ่อนไหว MIP รุ่นเก่า**

กระบวนการทำงานที่อิง MIP รุ่นเก่าสามารถเก็บข้อมูลเมตาป้ายความอ่อนไหวในคุณสมบัติเ�เอกสารที่กำหนดเองแทนคอลเลกชันป้ายสมัยใหม่ อ่านเมตานั้นด้วย [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). เมธอดจะวิเคราะห์คุณสมบัติกำหนดเองรุ่นเก่าและคืนค่าอาเรย์ของออบเจ็กต์ [ISensitivityLabel](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/)

เพื่อย้ายเมตาดาต้า ให้นำแต่ละป้ายที่คืนมาลงใน [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/) สมัยใหม่ผ่าน [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). เนื่องจากการเพิ่มป้ายที่มีตัวระบุซ้ำจะทำให้เกิดข้อยกเว้น ตัวอย่างจะตรวจสอบคอลเลกชันปลายทางก่อนคัดลอกแต่ละป้าย คุณสามารถเพิ่มการตรวจสอบเพิ่มเติมเพื่อยืนยันว่าป้ายรุ่นเก่ายังอยู่ในนโยบาย Purview ปัจจุบันหรือไม่

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การย้ายจะคัดลอกออบเจ็กต์ป้ายที่วิเคราะห์แล้วไปยังคอลเลกชันสมัยใหม่ ไม่จำเป็นต้องลบคุณสมบัติเ�เอกสารกำหนดเองทั้งหมด ดังนั้นเมตาดาต้าเอกสารที่ไม่เกี่ยวข้องจึงคงอยู่ ใช้ [IPresentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) พร้อมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/) เพื่อเขียนข้อมูลเมตาป้ายสมัยใหม่ลงในไฟล์ PPTX

## **คำถามที่พบบ่อย**

**การเพิ่มประเภทการทำเครื่องหมายเนื้อหาจะสร้างหัว, ท้ายกระดั๊ก, หรือลายน้ำที่มองเห็นได้บนสไลด์หรือไม่?**

ไม่ ค่าที่เพิ่มผ่านรายการที่คืนโดย [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) อธิบายการทำเครื่องหมายที่เชื่อมโยงกับป้ายความอ่อนไหว พวกมันไม่ได้สร้างข้อความหรือรูปร่างที่มองเห็นได้ในพรีเซนเทชัน หากเวิร์กโฟลว์ของคุณต้องการแสดงการทำเครื่องหมายเหล่านั้น ให้เพิ่มเนื้อหาสไลด์ที่เกี่ยวข้องแยกต่างหาก

**ความแตกต่างระหว่างการทำเครื่องหมายป้ายว่าได้ลบแล้วกับการลบออกจากคอลเลกชันคืออะไร?**

การเรียก [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) ด้วย `true` จะเก็บรายการป้ายไว้และบันทึกสถานะการลบ การเรียก [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) จะลบรายการออกจากคอลเลกชันสมัยใหม่ เลือกการดำเนินการที่สอดคล้องกับข้อกำหนดการเก็บรักษาเมตาดาต้าขององค์กรของคุณ

**พรีเซนเทชันสามารถมีทั้งเมตาดาต้า MIP รุ่นเก่าและป้ายความอ่อนไหวสมัยใหม่ได้หรือไม่?**

ได้ ป้ายรุ่นเก่าสามารถคงอยู่ในคุณสมบัติเ�เอกสารที่กำหนดเองได้ขณะป้ายสมัยใหม่เข้าถึงได้ผ่าน [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). ใช้ [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) เพื่ออ่านเมตาดาต้าแบบเก่าและย้ายเฉพาะป้ายที่ยังไม่ปรากฏในคอลเลกชันสมัยใหม่

**จะเกิดอะไรขึ้นเมื่อมีการเพิ่มป้ายที่มีตัวระบุเดียวกันหลายครั้ง?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) จะโยนข้อยกเว้นเมื่อคอลเลกชันมีป้ายที่มีตัวระบุเดียวกันอยู่แล้ว ตรวจสอบค่าที่มีอยู่โดยใช้ [ISensitivityLabel.getId](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getId--) ก่อนเพิ่มหรือย้ายป้าย

**ควรใช้รูปแบบไฟล์ใดเพื่อรักษาป้ายความอ่อนไหวที่อัปเดตไว้?**

บันทึกพรีเซนเทชันเป็น PPTX โดยเรียก [IPresentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) พร้อมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/), ตามที่แสดงในตัวอย่างข้างต้น.