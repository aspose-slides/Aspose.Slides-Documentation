---
title: จัดการป้ายความลับในงานนำเสนอ PowerPoint ด้วย PHP
linktitle: ป้ายความลับ
type: docs
weight: 50
url: /th/php-java/sensitivity-labels/
keywords:
- ป้ายความลับ
- Microsoft Purview
- การปกป้องข้อมูลของ Microsoft
- เมตาดาต้า MIP
- การทำเครื่องหมายเนื้อหา
- การปกป้องข้อมูล
- การกำกับดูแลเอกสาร
- PowerPoint
- PPTX
- ความปลอดภัยของการนำเสนอ
- PHP
- Aspose.Slides
description: "อ่าน, เพิ่ม, ปรับปรุง, ลบ และย้ายป้ายความลับของ Microsoft Purview ในงานนำเสนอ PowerPoint PPTX ด้วย PHP."
---
## **ภาพรวม**

Microsoft Purview sensitivity labels ช่วยองค์กรจัดประเภทและกำกับเอกสาร ระหว่างการประมวลผลการนำเสนอแบบอัตโนมัติ แอปพลิเคชันอาจต้องคงรักษา label ที่มีอยู่แล้ว ใช้ label ที่นโยบายกำหนด ปรับสถานะของ label หรือแม้กระทั่งย้ายข้อมูลเมตา label ที่เขียนโดย workflow ของ Microsoft Information Protection (MIP) รุ่นเก่า

Aspose.Slides for PHP via Java เปิดเผยเมตา label ความลับสมัยใหม่ผ่าน [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSensitivityLabels) วิธีการนี้จะคืนค่า [SensitivityLabelCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcollection/) ที่สามารถตรวจสอบและแก้ไขได้ก่อนบันทึกการนำเสนอเป็น PPTX

{{% alert color="primary" title="Note" %}}
ตัวระบุของ sensitivity label และข้อมูลนโยบายถูกกำหนดโดยการตั้งค่า Microsoft Purview ของคุณ ตรวจสอบความพร้อมใช้งานของ label และความต้องการของนโยบายในสภาพแวดล้อมของคุณก่อนที่จะเพิ่มหรือย้ายข้อมูลเมตา ค่าของ [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) จะอธิบายลักษณะการทำเครื่องหมายเนื้อหาที่เกี่ยวข้องกับ label; ค่าดังกล่าวไม่ได้สร้างข้อความหรือรูปทรงที่มองเห็นได้บนสไลด์โดยตรง
{{% /alert %}}

## **ทำความเข้าใจคุณสมบัติของ Sensitivity Label**

แต่ละ [SensitivityLabel](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/) มีเมตาดาต้าดังต่อไปนี้:

| วิธีการ | วัตถุประสงค์ |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#getId) และ [SensitivityLabel::setId](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#setId) | รับหรือกำหนดตัวระบุของ sensitivity label ในนโยบาย Purview |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#getSiteId) และ [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#setSiteId) | รับหรือกำหนดไซต์ที่เชื่อมโยงกับนโยบายของ label |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#isEnabled) และ [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#setEnabled) | รับหรือกำหนดว่า label ถูกเปิดใช้งานหรือไม่ |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#isRemoved) และ [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#setRemoved) | รับหรือกำหนดว่า label ถูกลบหรือไม่ ตั้งค่าเป็น `true` เมื่อต้องการเก็บสถานะการลบไว้ในเมตาดาต้า |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) และ [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | รับหรือกำหนดว่า label ถูกกำหนดโดยอัตโนมัติหรือโดยการตัดสินใจของผู้ใช้ |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | รับประเภทการทำเครื่องหมายเนื้อหาที่เชื่อมโยงกับ label |

คลาส [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelassignmenttype/) กำหนดวิธีที่ label ถูกกำหนด:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelassignmenttype/) แสดงถึง label เริ่มต้นหรือที่ถูกกำหนดโดยอัตโนมัติ
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelassignmenttype/) แสดงถึง label ที่กำหนดโดยการตัดสินใจของผู้ใช้ รวมถึงการกำหนดแบบมือ, แนะนำ, และบังคับใช้

คลาส [SensitivityLabelContentType](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcontenttype/) กำหนดการทำเครื่องหมายที่เชื่อมโยงกับ label:

| ค่า | ความหมาย |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcontenttype/) | label ถูกกำหนดโดยค่าเริ่มต้นหรืออัตโนมัติ |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcontenttype/) | มีการทำเครื่องหมายเนื้อหา Header ที่เชื่อมโยงกับ label |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcontenttype/) | มีการทำเครื่องหมายเนื้อหา Footer ที่เชื่อมโยงกับ label |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcontenttype/) | มีการทำเครื่องหมายเนื้อหา Watermark ที่เชื่อมโยงกับ label |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcontenttype/) | มีการปกป้องด้วย Encryption ที่เชื่อมโยงกับ label |

ประเภทการทำเครื่องหมายหลายประเภทสามารถสัมพันธ์กับ label หนึ่งรายการได้

## **แสดงรายการ Sensitivity Labels ที่มีอยู่**

อ่านคอลเลกชัน label สมัยใหม่จาก [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSensitivityLabels) และทำการวนลูป ตัวอย่างต่อไปนี้จะแสดงทุกคุณสมบัติและการทำเครื่องหมายเนื้อหาที่เก็บไว้สำหรับแต่ละ label:

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

## **เพิ่ม Sensitivity Label พร้อมการทำเครื่องหมายเนื้อหา**

ใช้ [SensitivityLabelCollection::add](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcollection/#add) พร้อมตัวระบุ label, ตัวระบุไซต์, สถานะเปิดใช้งาน, และวิธีการกำหนด หลังจากเมธอดคืนค่า [SensitivityLabel](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/) ใหม่ ให้เพิ่มค่าการทำเครื่องหมายที่จำเป็นผ่านรายการที่คืนจาก [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes)

ตัวอย่างต่อไปนี้เพิ่ม label ที่ผู้ใช้เลือกด้วยตนเองซึ่งสัมพันธ์กับการทำเครื่องหมาย Footer และ Watermark แล้วบันทึกผลลัพธ์เป็น PPTX:

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

## **อัปเดต Sensitivity Label**

ค่าของ [SensitivityLabel](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/) สามารถอ่าน/เขียนได้ ยกเว้นรายการที่คืนจาก [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) ซึ่งต้องแก้ไขผ่านการดำเนินการของรายการ หลังจากค้นหา label ที่ต้องการ คุณสามารถอัปเดตตัวระบุ, ตัวระบุไซต์, สถานะเปิดใช้งาน, วิธีการกำหนด, สถานะการลบ, และประเภทการทำเครื่องหมายเนื้อหา แล้วบันทึกการนำเสนอเพื่อบันทึกการเปลี่ยนแปลง

ตัวอย่างต่อไปนี้อัปเดตสถานะเปิดใช้งานและวิธีการกำหนดของ label แรก:

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

## **ทำเครื่องหมาย Sensitivity Label ว่า ถูกลบ**

เพื่อเก็บข้อมูลว่ามีการลบ label ให้ค้นหา label นั้นและเรียก [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#setRemoved) ด้วยค่า `true` ค่า นี้จะคงรายการ label อยู่พร้อมกับบันทึกสถานะการลบ หากต้องการลบรายการออกจากคอลเลกชันสมัยใหม่ ให้ใช้ [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); ใช้ [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcollection/#clear) เพื่อลบทุกรายการ

ตัวอย่างต่อไปนี้ทำเครื่องหมาย label เฉพาะว่า ถูกลบและบันทึกการนำเสนอที่อัปเดตแล้ว:

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

## **อ่านและย้าย Sensitivity Labels ของ MIP รุ่นเก่า**

Workflow ที่ใช้ MIP รุ่นเก่าสามารถจัดเก็บเมตาดาต้า sensitivity label ใน custom document properties แทนคอลเลกชัน label สมัยใหม่ อ่านเมตาดาต้านั้นด้วย [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getSensitivityLabels) เมธอดจะวิเคราะห์ custom properties รุ่นเก่าและคืนค่าอาร์เรย์ Java ของอ็อบเจกต์ [SensitivityLabel](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/)

เพื่อย้ายเมตาดาต้า ให้เพิ่มแต่ละ label ที่คืนมาลงใน [SensitivityLabelCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcollection/) สมัยใหม่ผ่าน [SensitivityLabelCollection::add](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcollection/#add) เนื่องจากการเพิ่ม label ที่มีตัวระบุซ้ำจะทำให้เกิดข้อยกเว้น ตัวอย่างจึงตรวจสอบคอลเลกชันปลายทางก่อนคัดลอกแต่ละ label คุณอาจเพิ่มการตรวจสอบเพิ่มเติมเพื่อยืนยันว่า label รุ่นเก่ายังคงมีอยู่ในนโยบาย Purview ปัจจุบัน

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

การย้ายจะคัดลอกอ็อบเจกต์ label ที่解析แล้วเข้าไปในคอลเลกชันสมัยใหม่ ไม่จำเป็นต้องลบ custom document properties ทั้งหมด ดังนั้นเมตาดาต้าเอกสารที่ไม่เกี่ยวข้องจะคงอยู่ ใช้ [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) พร้อม [SaveFormat::Pptx](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/) เพื่อเขียนเมตาดาต้า label สมัยใหม่ลงไฟล์ PPTX

## **คำถามที่พบบ่อย**

**การเพิ่มประเภทการทำเครื่องหมายเนื้อหาจะสร้าง Header, Footer หรือ Watermark ที่มองเห็นได้บนสไลด์หรือไม่?**

ไม่ ค่าที่เพิ่มผ่านรายการที่คืนจาก [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) เพียงอธิบายการทำเครื่องหมายที่เชื่อมโยงกับ sensitivity label เท่านั้น ไม่ได้สร้างข้อความหรือรูปทรงที่มองเห็นได้ในงานนำเสนอ ให้เพิ่มเนื้อหาในสไลด์ที่สอดคล้องกันแยกต่างหากหาก workflow ของคุณต้องการแสดงการทำเครื่องหมายเหล่านั้น

**ความแตกต่างระหว่างการทำเครื่องหมาย label ว่า ถูกลบและการลบจากคอลเลกชันคืออะไร?**

การเรียก [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#setRemoved) ด้วยค่า `true` จะคงรายการ label อยู่และบันทึกสถานะการลบ ส่วนการเรียก [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) จะลบรายการออกจากคอลเลกชันสมัยใหม่ เลือกการดำเนินการที่สอดคล้องกับข้อกำหนดการเก็บรักษาเมตาดาต้าขององค์กรคุณ

**งานนำเสนอสามารถมีเมตาดาต้า MIP รุ่นเก่าและ sensitivity label สมัยใหม่พร้อมกันได้หรือไม่?**

ได้ รายการ label รุ่นเก่าสามารถคงอยู่ใน custom document properties ในขณะที่ label สมัยใหม่เข้าถึงได้ผ่าน [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSensitivityLabels) ใช้ [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getSensitivityLabels) เพื่ออ่านเมตาดาต้าแบบเก่าและย้ายเฉพาะ label ที่ยังไม่มีอยู่ในคอลเลกชันสมัยใหม่

**จะเกิดอะไรขึ้นเมื่อมีการเพิ่ม label ที่มีตัวระบุเดียวกันหลายครั้ง?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabelcollection/#add) จะขว้างข้อยกเว้นเมื่อคอลเลกชันมี label ที่มีตัวระบุเดียวกันอยู่แล้ว ควรตรวจสอบค่าที่คืนจาก [SensitivityLabel::getId](https://reference.aspose.com/slides/th/php-java/aspose.slides/sensitivitylabel/#getId) ก่อนทำการเพิ่มหรือย้าย label

**ควรใช้รูปแบบการบันทึกใดเพื่อรักษา label ที่อัปเดตไว้?**

บันทึกงานนำเสนอเป็น PPTX โดยเรียก [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) พร้อม [SaveFormat::Pptx](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/) ตามตัวอย่างที่แสดงด้านบน