---
title: จัดการป้ายความละเอียดในงานนำเสนอ PowerPoint บน Android
linktitle: ป้ายความละเอียด
type: docs
weight: 50
url: /th/androidjava/sensitivity-labels/
keywords:
- ป้ายความละเอียด
- Microsoft Purview
- Microsoft Information Protection
- MIP metadata
- ทำเครื่องหมายเนื้อหา
- การปกป้องข้อมูล
- การกำกับดูแลเอกสาร
- PowerPoint
- PPTX
- ความปลอดภัยของการนำเสนอ
- Android
- Java
- Aspose.Slides
description: "อ่าน, เพิ่ม, ปรับปรุง, ลบ, และย้ายป้ายความละเอียดของ Microsoft Purview ในงานนำเสนอ PowerPoint PPTX ด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Microsoft Purview sensitivity labels ช่วยให้องค์กรจัดประเภทและควบคุมเอกสารได้ ในระหว่างการประมวลผลงานนำเสนออัตโนมัติ แอปพลิเคชันอาจต้องคงฉลากที่มีอยู่ไว้, ใช้ฉลากที่นโยบายเลือกไว้, อัปเดตสถานะ, หรือย้ายเมตาดาต้า​ฉลากที่เขียนโดยเวิร์กโฟลว์ Microsoft Information Protection (MIP) รุ่นเก่า

Aspose.Slides for Android via Java เปิดเผยเมตาดาต้า​ฉลากความละเอียดระดับสูงผ่าน [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). วิธีนี้จะคืนค่า [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/) ที่สามารถตรวจสอบและแก้ไขได้ก่อนบันทึกงานนำเสนอเป็น PPTX

{{% alert color="primary" title="หมายเหตุ" %}}

ตัวระบุฉลากความละเอียดและข้อมูลนโยบายถูกกำหนดโดยการกำหนดค่า Microsoft Purview ของคุณ ยืนยันความพร้อมใช้งานของฉลากและความต้องการของนโยบายในสภาพแวดล้อมของคุณก่อนเพิ่มหรือย้ายเมตาดาต้า​ค่า [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) อธิบายการทำเครื่องหมายเนื้อหาที่เกี่ยวข้องกับฉลาก; ค่าดังกล่าวไม่ได้เพิ่มข้อความหรือรูปทรงที่มองเห็นได้ลงในสไลด์โดยตรง

{{% /alert %}}

## **ทำความเข้าใจคุณสมบัติของ Sensitivity Label**

แต่ละ [ISensitivityLabel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/) มีเมตาดาต้​ต่อไปนี้:

| Methods | Purpose |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getId--) และ [ISensitivityLabel.setId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | รับหรือกำหนดตัวระบุฉลากความละเอียดในนโยบาย Purview |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) และ [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | รับหรือกำหนดไซต์ที่เชื่อมโยงกับนโยบายฉลาก |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) และ [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | รับหรือกำหนดว่าฉลากเปิดใช้งานหรือไม่ |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) และ [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | รับหรือกำหนดว่าฉลากถูกลบหรือไม่ ตั้งค่าเป็น `true` เมื่อต้องการเก็บสถานะการลบไว้ในเมตาดาต้า |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) และ [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | รับหรือกำหนดว่าฉลากถูกกำหนดโดยอัตโนมัติหรือโดยการตัดสินใจของผู้ใช้ |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | รับประเภทการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับฉลาก |

คลาส [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) กำหนดวิธีที่ฉลากถูกกำหนด:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) แสดงถึงฉลากที่เป็นค่าเริ่มต้นหรือถูกกำหนดโดยอัตโนมัติ
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) แสดงถึงฉลากที่กำหนดผ่านการตัดสินใจของผู้ใช้ รวมถึงฉลากที่กำหนดด้วยตนเอง, แนะนำ, และบังคับใช้

คลาส [SensitivityLabelContentType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) กำหนดการทำเครื่องหมายที่เชื่อมโยงกับฉลาก:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | ฉลากถูกกำหนดโดยค่าเริ่มต้นหรืออัตโนมัติ |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหา Header เชื่อมโยงกับฉลาก |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหา Footer เชื่อมโยงกับฉลาก |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหา Watermark เชื่อมโยงกับฉลาก |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | การปกป้องด้วย Encryption เชื่อมโยงกับฉลาก |

หลายประเภทการทำเครื่องหมายสามารถเชื่อมโยงกับฉลากเดียวได้

## **แสดงรายการ Sensitivity Labels ที่มีอยู่**

อ่านคอลเลกชันฉลากสมัยใหม่จาก [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) และวนลูปแสดงผล ตัวอย่างต่อไปนี้แสดงทุกคุณสมบัติและการทำเครื่องหมายเนื้อหาที่เก็บไว้สำหรับแต่ละฉลาก:

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

## **เพิ่ม Sensitivity Label พร้อมการทำเครื่องหมายเนื้อหา**

ใช้ [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) พร้อมระบุตัวระบุฉลาก, ตัวระบุไซต์, สถานะเปิดใช้งาน, และวิธีการกำหนด หลังจากเมธอดคืนค่า [ISensitivityLabel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/) ใหม่แล้ว ให้เพิ่มค่าการทำเครื่องหมายที่ต้องการผ่านรายการที่คืนจาก [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--)

ตัวอย่างต่อไปนี้เพิ่มฉลากที่เลือกด้วยตนเองพร้อมการทำเครื่องหมาย Footer และ Watermark แล้วบันทึกผลลัพธ์เป็น PPTX:

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

## **อัปเดต Sensitivity Label**

ค่าใน [ISensitivityLabel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/) สามารถอ่าน/เขียนได้ ยกเว้นรายการที่คืนจาก [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) ซึ่งต้องแก้ไขผ่านการดำเนินการของรายการหลังจากค้นพบฉลากที่ต้องการแล้ว คุณสามารถอัปเดตตัวระบุ, ตัวระบุไซต์, สถานะเปิดใช้งาน, วิธีการกำหนด, สถานะการลบ และประเภทการทำเครื่องหมายเนื้อหาได้ บันทึกงานนำเสนอเพื่อบันทึกการเปลี่ยนแปลง

ตัวอย่างต่อไปนี้อัปเดตสถานะเปิดใช้งานและวิธีการกำหนดของฉลากแรก:

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

## **ทำเครื่องหมาย Sensitivity Label ว่าถูกลบ**

เพื่อรักษาข้อเท็จจริงว่าฉลากถูกลบ ให้ค้นหาฉลากนั้นและเรียกใช้ [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) ด้วยค่า `true` การทำเช่นนี้จะเก็บรายการฉลากไว้พร้อมบันทึกสถานะการลบ หากต้องการลบรายการออกจากคอลเลกชันสมัยใหม่ ให้ใช้ [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); ใช้ [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) เพื่อลบทุกรายการ

ตัวอย่างต่อไปนี้ทำเครื่องหมายฉลากเฉพาะว่าเป็นการลบและบันทึกงานนำเสนอที่อัปเดตแล้ว:

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

## **อ่านและย้าย Sensitivity Labels แบบ Legacy ของ MIP**

เวิร์กโฟลว์แบบ MIP รุ่นเก่าสามารถเก็บเมตาดาต้า​ฉลากความละเอียดในคุณสมบัติเพิ่มเติมของเอกสารแทนคอลเลกชันฉลากสมัยใหม่ อ่านเมตาดาต้านั้นด้วย [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). เมธอดจะวิเคราะห์คุณสมบัติเพิ่มเติมแบบ legacy และคืนค่าอาเรย์ของออบเจกต์ [ISensitivityLabel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/)

เพื่อย้ายเมตาดาต้า​ให้เพิ่มแต่ละฉลากที่คืนจากเมธอดลงใน [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/) ผ่าน [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) เนื่องจากการเพิ่มฉลากที่มีตัวระบุซ้ำจะทำให้เกิดข้อยกเว้น ตัวอย่างจึงตรวจสอบคอลเลกชันปลายทางก่อนคัดลอกแต่ละฉลาก คุณสามารถเพิ่มการตรวจสอบเพิ่มเติมเพื่อยืนยันว่าฉลาก legacy ยังมีอยู่ในนโยบาย Purview ปัจจุบันหรือไม่

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

การย้ายนี้คัดลอกออบเจกต์ฉลากที่วิเคราะห์แล้วเข้าสู่คอลเลกชันสมัยใหม่ ไม่จำเป็นต้องล้างคุณสมบัติเพิ่มเติมทั้งหมดของเอกสาร ดังนั้นเมตาดาต้า​เอกสารที่ไม่เกี่ยวข้องจึงยังคงอยู่ ใช้ [IPresentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) กับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/) เพื่อเขียนเมตาดาต้า​ฉลากสมัยใหม่ลงไฟล์ PPTX

## **FAQ**

**การเพิ่มประเภทการทำเครื่องหมายเนื้อหาจะสร้าง Header, Footer หรือ Watermark ที่มองเห็นได้บนสไลด์หรือไม่?**

ไม่ได้ ค่าในรายการที่คืนจาก [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) อธิบายการทำเครื่องหมายที่เชื่อมโยงกับฉลากความละเอียด แต่ไม่สร้างข้อความหรือรูปทรงที่มองเห็นได้ในงานนำเสนอ หากเวิร์กโฟลว์ของคุณต้องแสดงการทำเครื่องหมายเหล่านั้น ให้เพิ่มเนื้อหาสไลด์ที่สอดคล้องกันแยกต่างหาก

**ความแตกต่างระหว่างทำเครื่องหมายฉลากว่าเป็นการลบและการลบออกจากคอลเลกชันคืออะไร?**

การเรียก [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) ด้วยค่า `true` จะเก็บรายการฉลากไว้และบันทึกสถานะการลบ การเรียก [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) จะลบรายการนั้นออกจากคอลเลกชันสมัยใหม่ เลือกวิธีที่ตรงกับข้อกำหนดการเก็บรักษาเมตาดาต้า​ขององค์กรคุณ

**งานนำเสนอสามารถมีเมตาดาต้า​MIP legacy และ Sensitivity Labels สมัยใหม่พร้อมกันได้หรือไม่?**

ได้ ฉลาก legacy สามารถคงอยู่ในคุณสมบัติเพิ่มเติมของเอกสารได้ขณะที่ฉลากสมัยใหม่เข้าถึงได้ผ่าน [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) ใช้ [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) เพื่ออ่านเมตาดาต้า​แบบ legacy แล้วย้ายเฉพาะฉลากที่ยังไม่ปรากฏในคอลเลกชันสมัยใหม่

**ถ้าฉลากที่มีตัวระบุเดียวกันถูกเพิ่มหลายครั้งจะเกิดอะไรขึ้น?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) จะยกข้อยกเว้นเมื่อคอลเลกชันมีฉลากที่มีตัวระบุเดียวกันอยู่แล้ว ตรวจสอบค่าที่มีอยู่แล้วจาก [ISensitivityLabel.getId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isensitivitylabel/#getId--) ก่อนทำการเพิ่มหรือย้ายฉลาก

**ควรใช้รูปแบบไฟล์ใดเพื่อรักษา Sensitivity Labels ที่อัปเดต?**

บันทึกงานนำเสนอเป็น PPTX โดยเรียก [IPresentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/) ตามที่แสดงในตัวอย่างด้านบน