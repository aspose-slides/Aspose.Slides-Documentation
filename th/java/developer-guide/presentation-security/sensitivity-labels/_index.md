---
title: จัดการป้ายกำกับความละเอียดอ่อนในงานนำเสนอ PowerPoint ด้วย Java
linktitle: ป้ายกำกับความละเอียดอ่อน
type: docs
weight: 50
url: /th/java/sensitivity-labels/
keywords:
- ป้ายกำกับความละเอียดอ่อน
- Microsoft Purview
- Microsoft Information Protection
- เมตาดาต้า MIP
- การทำเครื่องหมายเนื้อหา
- การปกป้องข้อมูล
- การกำกับดูแลเอกสาร
- PowerPoint
- PPTX
- ความปลอดภัยของการนำเสนอ
- Java
- Aspose.Slides
description: "อ่าน, เพิ่ม, อัปเดต, ลบ และโอนย้ายป้ายกำกับความละเอียดอ่อนของ Microsoft Purview ในงานนำเสนอ PowerPoint PPTX ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Microsoft Purview sensitivity labels ช่วยให้องค์กรจัดประเภทและกำกับเอกสารได้ ในระหว่างการประมวลผลงานนำเสนออัตโนมัติ แอปพลิเคชันอาจต้องคงรักษาป้ายกำกับที่มีอยู่แล้ว ใช้ป้ายกำกับที่เลือกโดยนโยบาย อัปเดตสถานะของมัน หรือโอนย้ายเมตาดาต้าป้ายกำกับที่เขียนโดยกระบวนการทำงาน Microsoft Information Protection (MIP) รุ่นเก่า

Aspose.Slides เปิดเผยเมตาดาต้าป้ายกำกับความละเอียดอ่อนสมัยใหม่ผ่าน [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). วิธีการนี้จะคืนค่า [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/) ที่สามารถตรวจสอบและแก้ไขได้ก่อนบันทึกงานนำเสนอเป็น PPTX.

{{% alert color="info" title="Note" %}}
ตัวระบุป้ายกำกับความละเอียดอ่อนและข้อมูลนโยบายถูกกำหนดโดยการกำหนดค่า Microsoft Purview ของคุณ ตรวจสอบความพร้อมของป้ายกำกับและข้อกำหนดของนโยบายในสภาพแวดล้อมของคุณก่อนทำการเพิ่มหรือโอนย้ายเมตาดาต้า ค่า [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) อธิบายการทำเครื่องหมายเนื้อหาที่เกี่ยวข้องกับป้ายกำกับ; ค่าเหล่านี้ไม่ทำให้มีข้อความหรือรูปทรงที่มองเห็นได้บนสไลด์โดยตรง.
{{% /alert %}}

## **ทำความเข้าใจคุณสมบัติป้ายกำกับความละเอียดอ่อน**

แต่ละ [ISensitivityLabel](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/) มีเมตาดาต้าต่อไปนี้:

| เมธอด | วัตถุประสงค์ |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getId--) และ [ISensitivityLabel.setId](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | รับหรือกำหนดตัวระบุป้ายกำกับความละเอียดอ่อนในนโยบาย Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getSiteId--) และ [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | รับหรือกำหนดไซต์ที่เชื่อมโยงกับนโยบายป้ายกำกับ. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#isEnabled--) และ [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | รับหรือกำหนดว่าป้ายกำกับเปิดใช้งานหรือไม่. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#isRemoved--) และ [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | รับหรือกำหนดว่าป้ายกำกับถูกลบหรือไม่ ตั้งค่าเป็น `true` เมื่อสถานะการลบต้องคงไว้ในเมตาดาต้า. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) และ [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | รับหรือกำหนดว่าป้ายกำกับได้รับการประยุกต์โดยอัตโนมัติหรือผ่านการตัดสินใจของผู้ใช้. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | รับประเภทการทำเครื่องหมายเนื้อหาที่เกี่ยวข้องกับป้ายกำกับ. |

คลาส [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelassignmenttype/) กำหนดวิธีการที่ป้ายกำกับถูกกำหนด:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelassignmenttype/) แสดงป้ายกำกับเริ่มต้นหรือที่ถูกประยุกต์โดยอัตโนมัติ.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelassignmenttype/) แสดงป้ายกำกับที่ประยุกต์ผ่านการตัดสินใจของผู้ใช้ รวมถึงการประยุกต์ด้วยตนเอง, แนะนำ, และบังคับใช้.

คลาส [SensitivityLabelContentType](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelcontenttype/) กำหนดการทำเครื่องหมายที่เชื่อมโยงกับป้ายกำกับ:

| ค่า | ความหมาย |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelcontenttype/) | ป้ายกำกับถูกประยุกต์โดยค่าเริ่มต้นหรือโดยอัตโนมัติ. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาส่วนหัวเชื่อมโยงกับป้ายกำกับ. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาส่วนท้ายเชื่อมโยงกับป้ายกำกับ. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelcontenttype/) | การทำเครื่องหมายเนื้อหาน้ำเงาเชื่อมโยงกับป้ายกำกับ. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/th/java/com.aspose.slides/sensitivitylabelcontenttype/) | การป้องกันด้วยการเข้ารหัสเชื่อมโยงกับป้ายกำกับ. |

หลายประเภทของการทำเครื่องหมายสามารถเชื่อมโยงกับป้ายกำกับเดียวได้.

## **แสดงรายการป้ายกำกับความละเอียดอ่อนที่มีอยู่**

อ่านคอลเลกชันป้ายกำกับสมัยใหม่จาก [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) และทำการวนซ้ำ ค่าตัวอย่างต่อไปนี้แสดงรายการคุณสมบัติและการทำเครื่องหมายเนื้อหาที่เก็บไว้สำหรับแต่ละป้ายกำกับ:

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

## **เพิ่มป้ายกำกับความละเอียดอ่อนพร้อมการทำเครื่องหมายเนื้อหา**

ใช้ [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) พร้อมด้วยตัวระบุป้ายกำกับ, ตัวระบุไซต์, สถานะเปิดใช้งาน, และวิธีการกำหนด หลังจากเมธอดคืนค่า [ISensitivityLabel](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/) ใหม่, ให้เพิ่มค่าการทำเครื่องหมายที่ต้องการผ่านรายการที่คืนจาก [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

ตัวอย่างต่อไปนี้เพิ่มป้ายกำกับที่เลือกด้วยตนเองซึ่งเชื่อมโยงกับการทำเครื่องหมายส่วนท้ายและน้ำเงา, แล้วบันทึกผลลัพธ์เป็น PPTX:

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

## **อัปเดตป้ายกำกับความละเอียดอ่อน**

ค่าของ [ISensitivityLabel](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/) สามารถอ่าน/เขียนได้ ยกเว้นรายการที่คืนจาก [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) ซึ่งแก้ไขผ่านการดำเนินการของรายการนั้น หลังจากค้นหาป้ายกำกับที่ต้องการ, คุณสามารถอัปเดตตัวระบุ, ตัวระบุไซต์, สถานะเปิดใช้งาน, วิธีการกำหนด, สถานะการลบ, และประเภทการทำเครื่องหมายเนื้อหาได้ บันทึกงานนำเสนอเพื่อบันทึกการเปลี่ยนแปลง.

ตัวอย่างต่อไปนี้อัปเดตสถานะการเปิดใช้งานและวิธีการกำหนดของป้ายกำกับแรก:

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

## **ทำเครื่องหมายป้ายกำกับความละเอียดอ่อนว่าถูกลบ**

เพื่อคงรักษาข้อเท็จจริงว่าป้ายกำกับถูกลบ, ค้นหาป้ายกำกับและเรียก [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) ด้วย `true`. การกระทำนี้จะคงรายการป้ายกำกับไว้พร้อมบันทึกสถานะการลบ หากคุณต้องการลบรายการจากคอลเลกชันสมัยใหม่แทน, ใช้ [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); ใช้ [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/#clear--) เพื่อลบทุกรายการ.

ตัวอย่างต่อไปนี้ทำเครื่องหมายป้ายกำกับเฉพาะว่าเป็นการลบและบันทึกงานนำเสนอที่อัปเดต:

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

## **อ่านและโอนย้ายป้ายกำกับความละเอียดอ่อน MIP รุ่นเก่า**

กระบวนการทำงานที่ใช้ MIP รุ่นเก่าสามารถเก็บเมตาดาต้าป้ายกำกับความละเอียดอ่อนในคุณสมบัติเอกสารที่กำหนดเองแทนคอลเลกชันป้ายกำกับสมัยใหม่ อ่านเมตาดาต้านั้นด้วย [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). เมธอดจะวิเคราะห์คุณสมบัติที่กำหนดเองแบบเดิมและคืนค่าอาเรย์ของอ็อบเจ็กต์ [ISensitivityLabel](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/).

เพื่อโอนย้ายเมตาดาต้า, เพิ่มแต่ละป้ายกำกับที่คืนค่าเข้าสู่ [ISensitivityLabelCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/) สมัยใหม่ผ่าน [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). เนื่องจากการเพิ่มตัวระบุป้ายกำกับที่ซ้ำกันทำให้เกิดข้อยกเว้น ตัวอย่างจึงตรวจสอบคอลเลกชันปลายทางก่อนคัดลอกแต่ละป้ายกำกับ คุณสามารถเพิ่มการตรวจสอบเพิ่มเติมเพื่อยืนยันว่าป้ายกำกับรุ่นเก่ายังคงอยู่ในนโยบาย Purview ปัจจุบันหรือไม่.

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

การโอนย้ายคัดลอกรายการอ็อบเจ็กต์ป้ายกำกับที่วิเคราะห์แล้วเข้าไปในคอลเลกชันสมัยใหม่ ไม่จำเป็นต้องล้างคุณสมบัติเอกสารที่กำหนดเองทั้งหมด ดังนั้นเมตาดาต้าเอกสารที่ไม่เกี่ยวข้องจึงคงอยู่ ใช้ [IPresentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) ร่วมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/) เพื่อเขียนเมตาดาต้าป้ายกำกับสมัยใหม่ลงไฟล์ PPTX.

## **คำถามที่พบบ่อย**

**การเพิ่มประเภทการทำเครื่องหมายเนื้อหาจะสร้างส่วนหัว, ส่วนท้าย หรือภาพลายน้ำที่มองเห็นได้บนสไลด์หรือไม่?**

ไม่. ค่าที่เพิ่มผ่านรายการที่คืนจาก [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) อธิบายการทำเครื่องหมายที่เชื่อมโยงกับป้ายกำกับความละเอียดอ่อน. ค่าเหล่านี้ไม่ได้สร้างข้อความหรือรูปทรงที่มองเห็นได้ในงานนำเสนอ. หากกระบวนการของคุณต้องการแสดงการทำเครื่องหมายเหล่านั้น ให้เพิ่มเนื้อหาในสไลด์แยกต่างหาก.

**ความแตกต่างระหว่างการทำเครื่องหมายป้ายกำกับว่าเป็นการลบและการลบออกจากคอลเลกชันคืออะไร?**

การเรียก [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) ด้วย `true` จะคงรายการป้ายกำกับไว้และบันทึกสถานะการลบ. การเรียก [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) จะลบรายการออกจากคอลเลกชันสมัยใหม่. เลือกวิธีการที่สอดคล้องกับข้อกำหนดการเก็บรักษาเมตาดาต้าขององค์กรของคุณ.

**งานนำเสนอสามารถมีเมตาดาต้า MIP รุ่นเก่าและป้ายกำกับความละเอียดอ่อนสมัยใหม่พร้อมกันได้หรือไม่?**

ได้. ป้ายกำกับรุ่นเก่าสามารถคงอยู่ในคุณสมบัติเอกสารที่กำหนดเองในขณะที่ป้ายกำกับสมัยใหม่เข้าถึงได้ผ่าน [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). ใช้ [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) เพื่ออ่านเมตาดาต้ารุ่นเก่าและโอนย้ายเฉพาะป้ายกำกับที่ยังไม่มีอยู่ในคอลเลกชันสมัยใหม่.

**เกิดอะไรขึ้นเมื่อเพิ่มป้ายกำกับที่มีตัวระบุเดียวกันมากกว่าหนึ่งครั้ง?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) จะยกข้อยกเว้นเมื่อคอลเลกชันมีป้ายกำกับที่มีตัวระบุเดียวกันอยู่แล้ว. ตรวจสอบค่าที่คืนจาก [ISensitivityLabel.getId](https://reference.aspose.com/slides/th/java/com.aspose.slides/isensitivitylabel/#getId--) ก่อนทำการเพิ่มหรือโอนย้ายป้ายกำกับ.

**ควรใช้รูปแบบไฟล์ใดเพื่อคงป้ายกำกับความละเอียดอ่อนที่อัปเดต?**

บันทึกงานนำเสนอเป็น PPTX โดยเรียก [IPresentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) พร้อมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/), ตามตัวอย่างที่แสดงข้างต้น.