---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอด้วย PHP
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/php-java/managing-tags-and-custom-data/
keywords:
- คุณสมบัติของเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- XML กำหนดเอง
- ส่วน XML กำหนดเอง
- เมตาดาต้า XML
- ItemId
- เพิ่มแท็ก
- ค่าคู่
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดการแท็กและข้อมูล XML กำหนดเองในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java รวมถึงการเพิ่ม, การอ่าน, การอัปเดต, การตรวจสอบ, และการลบส่วน XML กำหนดเอง."
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร ข้อมูลเฉพาะงานนำเสนอสามารถจัดเก็บเป็นแท็กหรือส่วน XML กำหนดเอง แท็กเป็นคู่คีย์‑ค่าแบบสตริงง่าย ๆ ในขณะที่ส่วน XML กำหนดเองสามารถเก็บเมตาดาต้าแบบโครงสร้างและข้อมูล XML เฉพาะแอปพลิเคชันได้

Aspose.Slides มี API สำหรับการเพิ่ม, อ่าน, ปรับปรุง, ตรวจสอบ, และการลบส่วน XML กำหนดเองในระดับงานนำเสนอ, สไลด์, และรูปร่าง ส่วน XML กำหนดเองมีประโยชน์สำหรับการบูรณาการที่จัดเก็บข้อมูลเช่น ตัวระบุการจัดการเอกสาร, สถานะของเวิร์กโฟลว์, เมตาดาต้าการปฏิบัติตาม, ข้อมูลการผูกเทมเพลต, หรือข้อมูลแอปพลิเคชันแบบโครงสร้างอื่น ๆ ภายในงานนำเสนอ

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX—ไฟล์ที่มีนามสกุล `.pptx`—จะถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML Office Open XML กำหนดโครงสร้างแพ็กเกจและความสัมพันธ์ที่ใช้ในการจัดเก็บเนื้อหาและข้อมูลที่เกี่ยวข้องของงานนำเสนอ

งานนำเสนอประกอบด้วยหลายส่วนที่เชื่อมต่อด้วยความสัมพันธ์ ตัวอย่างเช่น ส่วนสไลด์จะบรรจุเนื้อหาของสไลด์เดียวและอาจมีความสัมพันธ์อย่างชัดเจนกับส่วนอื่น ๆ ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลกำหนดเองสามารถจัดเก็บเป็นแท็ก ([TagCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/tagcollection/)) หรือส่วน XML กำหนดเอง ([CustomXmlPartCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpartcollection/)) ทั้งสองแบบสามารถเข้าถึงได้ผ่านคลาส [`CustomData`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customdata/)

{{% alert color="primary" %}}
แท็กเก็บคู่คีย์‑ค่าแบบสตริงง่าย ๆ ส่วน XML กำหนดเองเก็บข้อมูล XML แบบโครงสร้างและสามารถเชื่อมโยงกับงานนำเสนอ, สไลด์, หรือรูปร่างได้
{{% /alert %}}

## **ทำงานกับส่วน XML กำหนดเอง**

เมธอด [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customdata/#getCustomXmlParts) คืนค่าคอลเลกชันของส่วน XML กำหนดเองที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอที่ระบุ ตัวอย่างเช่น:

- `$presentation->getCustomData()->getCustomXmlParts()` มีส่วน XML กำหนดเองที่เชื่อมโยงกับงานนำเสนอเอง
- `$slide->getCustomData()->getCustomXmlParts()` มีส่วน XML กำหนดเองที่เชื่อมโยงกับสไลด์เฉพาะหนึ่งสไลด์
- `$shape->getCustomData()->getCustomXmlParts()` มีส่วน XML กำหนดเองที่เชื่อมโยงกับรูปร่างเฉพาะหนึ่งรูปร่าง

ใช้ [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getAllCustomXmlParts) เมื่อคุณต้องการตรวจสอบส่วน XML กำหนดเองทั้งหมดในงานนำเสนอไม่ว่ามีการเชื่อมโยงกับที่ใด

### **เพิ่มส่วน XML กำหนดเองลงในงานนำเสนอ**

ใช้ [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpartcollection/#add) เพื่อเพิ่มข้อมูล XML ไปยังคอลเลกชันส่วน XML กำหนดเอง XML ต้องเป็นรูปแบบที่ถูกต้องและไม่ว่างเปล่า

ตัวอย่างต่อไปนี้เพิ่มเมตาดาต้าแบบโครงสร้างไปยังคอลเลกชันข้อมูลกำหนดเองระดับงานนำเสนอ:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // การเพิ่มจะกำหนดตัวระบุโดยอัตโนมัติ ตั้งค่า UUID เฉพาะเมื่อจำเป็นเท่านั้น.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เมธอด `add` ยังสามารถรับ XML เป็นอาร์เรย์ของไบต์หรือสตรีมอินพุตได้ ซึ่งมีประโยชน์เมื่อเนื้อหา XML มีอยู่แล้วในรูปแบบไบนารี

### **เพิ่มส่วน XML กำหนดเองลงในสไลด์หรือรูปร่าง**

ข้อมูล XML กำหนดเองสามารถเชื่อมโยงกับสไลด์หรือรูปร่างเฉพาะแทนที่จะเป็นงานนำเสนอทั้งหมด ซึ่งเหมาะกับเมตาดาต้าที่อธิบายเพียงอ็อบเจ็กต์หนึ่ง เช่น คีย์เทมเพลต, ตัวระบุบันทึกภายนอก, หรือข้อมูลการผูก

ตัวอย่างต่อไปนี้เพิ่มส่วน XML กำหนดเองหนึ่งส่วนลงในสไลด์และอีกส่วนหนึ่งลงในรูปร่าง:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ระดับที่ส่วนถูกเพิ่มจะกำหนดว่าคอลเลกชัน `getCustomData()->getCustomXmlParts()` ของอ็อบเจ็กต์ใดจะมีความสัมพันธ์กับส่วนนั้น ข้อมูลระดับงานนำเสนอเหมาะกับเมตาดาต้าทั่วทั้งเอกสาร ข้อมูลระดับสไลด์เหมาะกับข้อมูลที่เป็นของสไลด์เฉพาะ และข้อมูลระดับรูปร่างเหมาะกับเมตาดาต้าที่ผูกกับรูปร่างหนึ่งรูปร่าง

### **แสดงรายการและตรวจสอบส่วน XML กำหนดเองทั้งหมด**

ใช้ [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getAllCustomXmlParts) เพื่อดึงส่วน XML กำหนดเองทั้งหมดจากงานนำเสนอแต่ละ [`CustomXmlPart`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpart/) จะเผยให้เห็นตัวระบุ, เนื้อหา XML, และสคีมเนมสเปซที่เชื่อมโยง

ตัวอย่างต่อไปนี้แสดงรายการส่วน XML กำหนดเองทั้งหมดและสคีมเนมสเปซของมัน:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) คืนค่าสคีม XML ที่เชื่อมโยงกับส่วน XML กำหนดเอง ข้อมูลนี้อาจเป็นประโยชน์เมื่อทำการตรวจสอบงานนำเสนอที่มี XML สร้างจากระบบภายนอก

### **อ่านและอัปเดตเนื้อหา XML และ ItemId**

ใช้ [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpart/#getXmlAsString) และ [`setXmlAsString()`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpart/#setXmlAsString) เพื่อทำงานกับ XML ในรูปแบบสตริง UTF‑8 หรือใช้ [`getXmlData()`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpart/#getXmlData) และ [`setXmlData()`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpart/#setXmlData) เพื่อทำงานกับไบต์ XML ดิบ

เมธอด [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpart/#getItemId) คืนค่า UUID ที่ระบุส่วน XML กำหนดเองในเอกสาร Office Open XML ใช้ [`setItemId()`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpart/#setItemId) เมื่อการบูรณาการต้องการตัวระบุใหม่

ตัวอย่างต่อไปนี้อัปเดตเนื้อหา XML และตัวระบุ:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // อ่าน XML ปัจจุบันเป็นข้อความ.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // อัปเดต XML เป็นสตริง UTF-8.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData ให้เนื้อหา XML เดียวกันเป็นไบต์ดิบ.
    $customXmlData = $customXmlPart->getXmlData();

    // แทนที่ตัวระเมื่อการบูรณาการต้องการ.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เมื่อเรียก `setXmlAsString` หรือ `setXmlData` ให้ส่ง XML ที่ถูกต้องและไม่ว่างเปล่า ใช้ตัวแทนใดตัวหนึ่งขึ้นกับว่าการประยุกต์ทำงานหลักกับสตริงหรือไบต์ ทั้งสองตัวแทนอ้างอิงถึงเนื้อหา XML ของส่วน XML กำหนดเดียวกัน

### **ลบส่วน XML กำหนดเอง**

Aspose.Slides มีวิธีหลายอย่างในการลบข้อมูล XML กำหนดเอง:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpart/#remove) ลบส่วน XML กำหนดเองจากงานนำเสนอ
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpartcollection/#remove) ลบส่วนเฉพาะจากคอลเลกชันส่วน XML กำหนดเอง
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpartcollection/#removeAt) ลบส่วนที่ตำแหน่งดัชนีที่กำหนดในคอลเลกชัน
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/th/php-java/aspose.slides/customxmlpartcollection/#clear) ลบส่วนทั้งหมดจากคอลเลกชันที่ระบุ

ตัวอย่างต่อไปนี้ลบส่วน XML กำหนดเองระดับงานนำเสนอหนึ่งส่วนโดยอ้างอิง:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ถ้าคุณมี `CustomXmlPart` อยู่แล้วและต้องการลบส่วนนั้นจากงานนำเสนอโดยตรงแทนการอ้างอิงคอลเลกชัน ให้เรียก `$customXmlPart->remove()`.

คุณสามารถลบรายการตามดัชนีได้เช่นกัน:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **ลบส่วน XML กำหนดเองทั้งหมดจากคอลเลกชัน**

ใช้ `clear` เมื่อส่วน XML กำหนดเองทั้งหมดที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอใด ๆ ควรถูกลบ

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` มีผลต่อคอลเลกชันที่เลือกเท่านั้น ตัวอย่างเช่น การล้างคอลเลกชันของสไลด์จะไม่ล้างคอลเลกชันระดับงานนำเสนอหรือระดับรูปร่าง

เพื่อทำการลบทุกส่วน XML กำหนดเองในงานนำเสนอ ให้วนลูปผ่าน `getAllCustomXmlParts()` และลบแต่ละส่วน:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **จัดการส่วน XML กำหนดเองที่เชื่อมโยงหรือใช้ร่วมกัน**

ในงานนำเสนอ Office Open XML ส่วน XML กำหนดเองเดียวกันอาจถูกอ้างอิงจากอ็อบเจ็กต์งานนำเสนอหลายอัน ตัวอย่างเช่นไฟล์ที่มีความสัมพันธ์จากหลายสไลด์หรือรูปร่างไปยังส่วน XML กำหนดเดียวกัน

ส่วนที่ใช้ร่วมควรถือเป็นอ็อบเจ็กต์ข้อมูลชุดเดียวที่มีหลายการอ้างอิง:

- การอัปเดตด้วย `setXmlAsString`, `setXmlData` หรือ `setItemId` จะเปลี่ยนส่วน XML กำหนดเองพื้นฐาน ดังนั้นการเปลี่ยนแปลงจะส่งผลทุกที่ที่ส่วนนั้นถูกอ้างอิง
- `getItemId()` สามารถใช้ระบุส่วน XML กำหนดเดียวกันขณะตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์
- การลบส่วนจากคอลเลกชัน `getCustomXmlParts()` เฉพาะจะลบจากคอลเลกชันนั้น ใช้ `CustomXmlPart::remove()` เมื่อส่วนนั้นควรถูกลบจากงานนำเสนอทั้งหมด
- ก่อนลบหรือแทนที่ส่วนที่ใช้ร่วม ควรตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์เพื่อดูว่ายังมีสไลด์หรือรูปร่างอื่นอ้างอิงอยู่หรือไม่

เมธอด `add` สร้างส่วน XML กำหนดใหม่จากเนื้อหา XML; ไม่รับส่วน XML กำหนดที่มีอยู่แล้ว ดังนั้นความสัมพันธ์ที่ใช้ร่วมมักพบเมื่อโหลดงานนำเสนอที่มีส่วนเหล่านั้นอยู่แล้ว

ตัวอย่างต่อไปนี้ตรวจสอบคอลเลกชันระดับงานนำเสนอ, สไลด์, และรูปร่างโดย `ItemId` และรายงานส่วนที่ถูกอ้างอิงจากมากกว่าหนึ่งตำแหน่ง:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

การตรวจสอบลักษณะนี้เป็นประโยชน์ก่อนทำการแก้ไขหรือลบข้อมูล XML กำหนดเองในงานนำเสนอที่สร้างจากระบบภายนอก เพราะส่วนเมตาดาต้าเดียวกันอาจมีส่วนร่วมในความสัมพันธ์หลายแห่ง

## **รับค่าของแท็ก**

ใน Slides แท็กสอดคล้องกับเมธอด `DocumentProperties::getKeywords()` ตัวอย่างโค้ดนี้แสดงวิธีรับค่าของแท็กด้วย Aspose.Slides for PHP via Java สำหรับ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **เพิ่มแท็กลงในงานนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กลงในงานนำเสนอ แท็กทั่วไปประกอบด้วยสองส่วน:

- ชื่อของคุณสมบัติกำหนดเอง เช่น `MyTag`
- ค่าของคุณสมบัติกำหนดเอง เช่น `My Tag Value`

หากคุณต้องการจัดประเภทงานนำเสนอตามกฎหรือคุณสมบัติเฉพาะ คุณสามารถเพิ่มแท็กเพื่อวัตถุประสงค์นั้นได้ ตัวอย่างเช่น หากต้องการจัดประเภทงานนำเสนอจากประเทศในอเมริกาเหนือ คุณสามารถสร้างแท็กอเมริกาเหนือและกำหนดค่าประเทศที่เกี่ยวข้องเป็นค่าแท็ก

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กลงใน [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ด้วย Aspose.Slides for PHP via Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

สามารถตั้งค่าแท็กสำหรับ [Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/) ได้เช่นกัน:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

หรือตั้งค่าสำหรับ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) รายบุคคล:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชัน `getCustomData()->getTags()` จะถูกเก็บไว้เฉพาะในไฟล์ PowerPoint เท่านั้น **ไม่ได้** ถูกโอนย้ายไปยังโครงสร้างแท็กของ PDF เมื่อนำออกเป็น PDF ดังนั้นตัวระบุกำหนดเองที่กำหนดเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้

**วิธีแก้**: คุณสามารถเก็บตัวระบุกำหนดเองใน **Alt Text** ของอ็อบเจ็กต์ (เช่น `$shape->setAlternativeText("MyId")`) หลังจากส่งออกเป็น PDF Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์ หรือรูปร่างในหนึ่งครั้งได้หรือไม่?**

ได้. คอลเลกชันแท็ก ([tag collection](https://reference.aspose.com/slides/th/php-java/aspose.slides/tagcollection/)) รองรับการดำเนินการ [clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/tagcollection/#clear) ซึ่งจะลบคู่คีย์‑ค่าทั้งหมดพร้อมกัน

**ฉันจะลบแท็กเดี่ยวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปคอลเลกชันทั้งหมดได้อย่างไร?**

ใช้ [remove(name)](https://reference.aspose.com/slides/th/php-java/aspose.slides/tagcollection/#remove) บนคอลเลกชันแท็ก ([tag collection](https://reference.aspose.com/slides/th/php-java/aspose.slides/tagcollection/)) เพื่อลบแท็กตามคีย์

**ฉันจะดึงรายชื่อแท็กทั้งหมดเพื่อการวิเคราะห์หรือการกรองได้อย่างไร?**

ใช้ [getNamesOfTags](https://reference.aspose.com/slides/th/php-java/aspose.slides/tagcollection/#getNamesOfTags) บนคอลเลกชันแท็ก ([tag collection](https://reference.aspose.com/slides/th/php-java/aspose.slides/tagcollection/)); มันจะคืนอาร์เรย์ของชื่อแท็กทั้งหมด

**ฉันจะค้นหาส่วน XML กำหนดเองทั้งหมดโดยไม่คำนึงว่ามันถูกจัดเก็บที่ใดได้อย่างไร?**

ใช้ [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getAllCustomXmlParts) เพื่อดึงส่วน XML กำหนดเองทั้งหมดในงานนำเสนอ

**ควรใช้ `getXmlAsString`/`setXmlAsString` หรือ `getXmlData`/`setXmlData` เพื่ออัปเดตส่วน XML กำหนดเอง?**

ใช้ `getXmlAsString` และ `setXmlAsString` เมื่อแอปทำงานกับข้อความ XML แบบ UTF‑8 ใช้ `getXmlData` และ `setXmlData` เมื่อ XML มีอยู่แล้วเป็นอาร์เรย์ไบต์หรือเมื่อการประมวลผลแบบไบต์สะดวกกว่า ทั้งคู่อ้างอิงถึงเนื้อหา XML ของส่วน XML กำหนดเดียวกัน