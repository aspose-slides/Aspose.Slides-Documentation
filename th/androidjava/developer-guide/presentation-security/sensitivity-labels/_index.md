---
title: จัดการป้ายกำกับความสำคัญในงานนำเสนอ PowerPoint บน Android
linktitle: ป้ายกำกับความสำคัญ
type: docs
weight: 50
url: /th/androidjava/sensitivity-labels/
keywords:
- ป้ายกำกับความสำคัญ
- Microsoft Purview
- Microsoft Information Protection
- เมตาดาต้า MIP
- การทำเครื่องหมายเนื้อหา
- การปกป้องข้อมูล
- การกำกับเอกสาร
- PowerPoint
- PPTX
- ความปลอดภัยของการนำเสนอ
- Android
- Java
- Aspose.Slides
description: "อ่าน, เพิ่ม, ปรับปรุง, ลบ, และย้ายป้ายกำกับความสำคัญของ Microsoft Purview ในงานนำเสนอ PowerPoint PPTX ด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Microsoft Purview sensitivity labels ช่วยให้องค์กรจำแนกและควบคุมเอกสารได้ ในกระบวนการประมวลผลการนำเสนออัตโนมัติ แอปพลิเคชันอาจต้องรักษาป้ายกำกับที่มีอยู่, ใช้ป้ายที่เลือกโดยนโยบาย, ปรับปรุงสถานะ, หรือย้ายเมตาดาต้าป้ายที่เขียนโดยเวิร์กโฟลว์ Microsoft Information Protection (MIP) รุ่นเก่า

Aspose.Slides for Android ผ่าน Java เปิดเผยเมตาดาต้าป้ายกำกับความสำคัญสมัยใหม่ผ่าน [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). วิธีนี้ส่งคืน [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/) ที่สามารถตรวจสอบและแก้ไขได้ก่อนบันทึกการนำเสนอเป็น PPTX

{{% alert color="info" title="Note" %}}
ตัวระบุป้ายกำกับความสำคัญและข้อมูลนโยบายถูกกำหนดโดยการกำหนดค่า Microsoft Purview ของคุณ ตรวจสอบความพร้อมของป้ายและความต้องการของนโยบายในสภาพแวดล้อมของคุณก่อนที่จะเพิ่มหรือย้ายเมตาดาต้า ค่าของ [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) อธิบายการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้าย; ค่าเหล่านี้ไม่ได้เพิ่มข้อความหรือรูปทรงที่มองเห็นได้ลงบนสไลด์โดยตรง
{{% /alert %}}

## **ทำความเข้าใจคุณสมบัติของป้ายกำกับความสำคัญ**

แต่ละ [ISensitivityLabel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/) มีเมตาดาต้าดังต่อไปนี้:

| วิธีการ | วัตถุประสงค์ |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getId--) และ [ISensitivityLabel.setId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | รับหรือกำหนดตัวระบุป้ายกำกับความสำคัญในนโยบาย Purview |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) และ [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | รับหรือกำหนดไซต์ที่เชื่อมโยงกับนโยบายป้าย |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) และ [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | รับหรือกำหนดว่าป้ายถูกเปิดใช้งานหรือไม่ |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) และ [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | รับหรือกำหนดว่าป้ายถูกลบหรือไม่ ตั้งค่าเป็น `true` เมื่อต้องการเก็บสถานะการลบไว้ในเมตาดาต้า |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) และ [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | รับหรือกำหนดว่าป้ายถูกกำหนดโดยอัตโนมัติหรือโดยการตัดสินใจของผู้ใช้ |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | รับประเภทการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับป้าย |

คลาส [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) กำหนดวิธีที่ป้ายถูกกำหนด:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) แสดงถึงป้ายที่เป็นค่าเริ่มต้นหรือถูกกำหนดโดยอัตโนมัติ
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) แสดงถึงป้ายที่กำหนดโดยการตัดสินใจของผู้ใช้ รวมถึงป้ายที่กำหนดด้วยตนเอง, แนะนำ, และบังคับใช้

คลาส [SensitivityLabelContentType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) กำหนดการทำเครื่องหมายที่เชื่อมโยงกับป้าย:

| ค่า | ความหมาย |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | ป้ายถูกกำหนดเป็นค่าเริ่มต้นหรือโดยอัตโนมัติ |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาส่วนหัวเชื่อมโยงกับป้าย |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาส่วนท้ายเชื่อมโยงกับป้าย |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาน้ำแม่พิมพ์เชื่อมโยงกับป้าย |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | การปกป้องด้วยการเข้ารหัสเชื่อมโยงกับป้าย |

สามารถเชื่อมโยงหลายประเภทการทำเครื่องหมายกับป้ายเดียวได้

## **แสดงรายการป้ายกำกับความสำคัญที่มีอยู่**

อ่านชุดป้ายสมัยใหม่จาก [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) และทำการวนลูป รายการตัวอย่างต่อไปนี้แสดงคุณสมบัติและการทำเครื่องหมายเนื้อหาที่เก็บไว้สำหรับแต่ละป้าย:

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

## **เพิ่มป้ายกำกับความสำคัญพร้อมการทำเครื่องหมายเนื้อหา**

ใช้ [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) พร้อมตัวระบุป้าย, ตัวระบุไซต์, สถานะเปิดใช้งาน, และวิธีการกำหนด หลังจากเมธอดคืนค่า [ISensitivityLabel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/) ใหม่ ให้เพิ่มค่าการทำเครื่องหมายที่ต้องการผ่านรายการที่คืนจาก [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--)

ตัวอย่างต่อไปนี้เพิ่มป้ายที่ผู้ใช้เลือกด้วยตนเองซึ่งเชื่อมโยงกับการทำเครื่องหมายส่วนท้ายและลายน้ำ แล้วบันทึกผลลัพธ์เป็น PPTX:

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

## **อัปเดตป้ายกำกับความสำคัญ**

ค่าใน [ISensitivityLabel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/) สามารถอ่านและเขียนได้ ยกเว้นรายการที่คืนจาก [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) ต้องแก้ไขผ่านการดำเนินการของรายการ หลังจากค้นพบป้ายที่ต้องการ คุณสามารถอัปเดตตัวระบุ, ตัวระบุไซต์, สถานะเปิดใช้งาน, วิธีการกำหนด, สถานะการลบ, และประเภทการทำเครื่องหมายเนื้อหาได้ บันทึกการนำเสนอเพื่อบันทึกการเปลี่ยนแปลง

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

## **ทำเครื่องหมายป้ายกำกับความสำคัญว่าเป็นการลบ**

เพื่อเก็บข้อเท็จจริงว่าป้ายถูกลบ ให้ค้นหาป้ายและเรียก [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) ด้วย `true` คำสั่งนี้จะเก็บรายการป้ายไว้พร้อมบันทึกสถานะการลบ หากต้องการลบรายการออกจากชุดสมัยใหม่ ให้ใช้ [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); ใช้ [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) เพื่อลบทุกรายการ

ตัวอย่างต่อไปนี้ทำเครื่องหมายป้ายเฉพาะว่าเป็นการลบแล้วบันทึกการนำเสนอที่อัปเดต:

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

## **อ่านและย้ายป้ายกำกับความสำคัญ MIP รุ่นเก่า**

เวิร์กโฟลว์ที่อิง MIP เก่าอาจจัดเก็บเมตาดาต้าป้ายกำกับความสำคัญในคุณสมบัติเ�เอกสารแบบกำหนดเองแทนชุดป้ายสมัยใหม่ อ่านเมตาดาต้านั้นด้วย [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). เมธอดจะวิเคราะห์คุณสมบัติแบบกำหนดเองรุ่นเก่าและคืนอาร์เรย์ของอ็อบเจ็กต์ [ISensitivityLabel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/)

เพื่อย้ายเมตาดาต้า ให้เพิ่มแต่ละป้ายที่คืนจากเมธอดเข้าสู่ [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/) สมัยใหม่ผ่าน [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). เนื่องจากการเพิ่มตัวระบุป้ายซ้ำทำให้เกิดข้อยกเว้น ตัวอย่างตรวจสอบชุดปลายทางก่อนคัดลอกแต่ละป้าย คุณยังสามารถเพิ่มการตรวจสอบเพิ่มเติมเพื่อยืนยันว่าป้ายรุ่นเก่ายังคงมีอยู่ในนโยบาย Purview ปัจจุบันหรือไม่

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

การย้ายจะคัดลอกอ็อบเจ็กต์ป้ายที่วิเคราะห์แล้วเข้าสู่ชุดสมัยใหม่ ไม่จำเป็นต้องลบคุณสมบัติเ�เอกสารแบบกำหนดเองทั้งหมด ดังนั้นเมตาดาต้าเอกสารที่ไม่เกี่ยวข้องจึงคงอยู่ ใช้ [IPresentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/) เพื่อเขียนเมตาดาต้าป้ายสมัยใหม่ลงในไฟล์ PPTX

## **คำถามที่พบบ่อย**

**การเพิ่มประเภทการทำเครื่องหมายเนื้อหาจะสร้างส่วนหัว, ส่วนท้าย หรือภาพลายน้ำที่มองเห็นได้บนสไลด์หรือไม่?**

ไม่ ค่าเหล่านั้นที่เพิ่มผ่านรายการที่คืนจาก [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) เพียงอธิบายการทำเครื่องหมายที่เชื่อมโยงกับป้าย ไม่ได้สร้างข้อความหรือรูปทรงที่มองเห็นได้ในงานนำเสนอ หากเวิร์กโฟลว์ของคุณต้องแสดงการทำเครื่องหมายเหล่านั้น ให้เพิ่มเนื้อหาสไลด์ที่สอดคล้องกันแยกต่างหาก

**ความแตกต่างระหว่างการทำเครื่องหมายป้ายว่าเป็นการลบและการลบออกจากชุดคืออะไร?**

เรียก [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) ด้วย `true` จะคงรายการป้ายไว้และบันทึกสถานะการลบไว้ ส่วนการเรียก [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) จะลบรายการออกจากชุดสมัยใหม่ เลือกวิธีที่สอดคล้องกับข้อกำหนดการเก็บรักษาเมตาดาต้าขององค์กรคุณ

**งานนำเสนอสามารถมีเมตาดาต้า MIP รุ่นเก่าและป้ายกำกับสมัยใหม่ได้หรือไม่?**

ได้ ป้ายเก่าสามารถคงอยู่ในคุณสมบัติเ�เอกสารแบบกำหนดเองในขณะที่ป้ายสมัยใหม่เข้าถึงได้ผ่าน [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). ใช้ [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) เพื่ออ่านเมตาดาต้าเก่าและย้ายเฉพาะป้ายที่ยังไม่มีอยู่ในชุดสมัยใหม่

**จะเกิดอะไรขึ้นเมื่อเพิ่มป้ายที่มีตัวระบุเดียวกันหลายครั้ง?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) จะทำให้เกิดข้อยกเว้นเมื่อชุดมีป้ายที่มีตัวระบุเดียวกันอยู่แล้ว ตรวจสอบค่าที่คืนจาก [ISensitivityLabel.getId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getId--) ก่อนทำการเพิ่มหรือย้ายป้าย

**ควรใช้รูปแบบการส่งออกใดเพื่อรักษาป้ายกำกับความสำคัญที่อัปเดต?**

บันทึกการนำเสนอเป็น PPTX โดยเรียก [IPresentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/) ตามที่แสดงในตัวอย่างข้างต้น