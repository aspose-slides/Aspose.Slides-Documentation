---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอโดยใช้ Java
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/java/managing-tags-and-custom-data/
keywords:
- คุณสมบัติของเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- XML กำหนดเอง
- ส่วน XML กำหนดเอง
- เมทาดาต้า XML
- ItemId
- เพิ่มแท็ก
- ค่าแบบคู่
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการแท็กและข้อมูล XML กำหนดเองในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java รวมถึงการเพิ่ม, การอ่าน, การอัปเดต, การตรวจสอบ, และการลบส่วน XML กำหนดเอง."
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร ข้อมูลที่เฉพาะเจจาะกับงานนำเสนอสามารถจัดเก็บเป็นแท็กหรือส่วน XML แบบกำหนดเองได้ แท็กเป็นคู่คีย์‑ค่าแบบสตริงง่าย ๆ ในขณะที่ส่วน XML แบบกำหนดเองสามารถเก็บเมทาดาต้าแบบโครงสร้างและข้อมูล XML เฉพาะแอปพลิเคชัน

Aspose.Slides มี API สำหรับการเพิ่ม, อ่าน, ปรับปรุง, ตรวจสอบ, และลบส่วน XML แบบกำหนดเองในระดับงานนำเสนอ, สไลด์, และรูปทรง ส่วน XML แบบกำหนดเองเป็นประโยชน์สำหรับการรวมระบบที่จัดเก็บข้อมูลเช่น ตัวระบุการจัดการเอกสาร, สถานะของเวิร์กโฟลว์, เมทาดาต้าในการปฏิบัติตาม, ข้อมูลการผูกเทมเพลต, หรือข้อมูลแอปพลิเคชันแบบโครงสร้างอื่น ๆ ภายในงานนำเสนอ

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีส่วนขยาย `.pptx` — จะถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML. Office Open XML กำหนดโครงสร้างแพคเกจและความสัมพันธ์ที่ใช้จัดเก็บเนื้อหาและข้อมูลที่เกี่ยวข้องของงานนำเสนอ

งานนำเสนอประกอบด้วยหลายส่วนที่เชื่อมต่อกันด้วยความสัมพันธ์ ตัวอย่างเช่น ส่วนสไลด์จะมีเนื้อหาของสไลด์เดียวและอาจมีความสัมพันธ์ที่ชัดเจนกับส่วนอื่น ๆ ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลกำหนดเองสามารถจัดเก็บเป็นแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITagCollection)) หรือส่วน XML แบบกำหนดเอง ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPartCollection)) ทั้งสองแบบสามารถเข้าถึงได้ผ่านอินเทอร์เฟซ [`ICustomData`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomData/)

{{% alert color="info" %}}
แท็กเก็บคู่คีย์‑ค่าแบบสตริงง่าย ๆ ส่วน XML แบบกำหนดเองเก็บข้อมูล XML แบบโครงสร้างและสามารถเชื่อมโยงกับงานนำเสนอ, สไลด์ หรือรูปทรง
{{% /alert %}}

## **ทำงานกับส่วน XML แบบกำหนดเอง**

เมธอด [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomData#getCustomXmlParts--) จะคืนค่าคอลเลกชันของส่วน XML แบบกำหนดเองที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอที่ระบุ ตัวอย่างเช่น:

- `presentation.getCustomData().getCustomXmlParts()` มีส่วน XML แบบกำหนดเองที่เชื่อมโยงกับงานนำเสนอเอง
- `slide.getCustomData().getCustomXmlParts()` มีส่วน XML แบบกำหนดเองที่เชื่อมโยงกับสไลด์เฉพาะ
- `shape.getCustomData().getCustomXmlParts()` มีส่วน XML แบบกำหนดเองที่เชื่อมโยงกับรูปทรงเฉพาะ

ใช้เมธอด [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) เมื่อคุณต้องการตรวจสอบส่วน XML แบบกำหนดเองทั้งหมดในงานนำเสนอโดยไม่คำนึงว่ามันเชื่อมโยงอยู่ที่ไหน

### **เพิ่มส่วน XML แบบกำหนดเองไปยังงานนำเสนอ**

ใช้เมธอด [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) เพื่อเพิ่มข้อมูล XML ไปยังคอลเลกชันส่วน XML แบบกำหนดเอง XML ต้องเป็นไฟล์ที่ถูกต้องและไม่ว่าง

ตัวอย่างต่อไปนี้เพิ่มเมทาดาต้าแบบโครงสร้างไปยังคอลเลกชันข้อมูลกำหนดเองระดับงานนำเสนอ:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add กำหนดตัวระบุโดยอัตโนมัติ. ตั้งค่า UUID เฉพาะเมื่อจำเป็นเท่านั้น.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมธอด `add` ยังสามารถรับ XML เป็นอาร์เรย์ของไบต์หรือสตรีมอินพุต ซึ่งมีประโยชน์เมื่อเนื้อหา XML มีอยู่แล้วในรูปแบบไบนารี

### **เพิ่มส่วน XML แบบกำหนดเองไปยังสไลด์หรือรูปทรง**

ข้อมูล XML แบบกำหนดเองสามารถเชื่อมโยงกับสไลด์หรือรูปทรงเฉพาะแทนที่จะเป็นงานนำเสนอทั้งหมด ซึ่งเป็นประโยชน์เมื่อเมทาดาต้าอธิบายเพียงอ็อบเจ็กต์เดียว เช่น คีย์เทมเพลต, ตัวระบุบันทึกภายนอก, หรือข้อมูลการผูก

ตัวอย่างต่อไปนี้เพิ่มส่วน XML แบบกำหนดเองหนึ่งส่วนไปยังสไลด์และอีกส่วนหนึ่งไปยังรูปทรง:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ระดับที่ส่วนถูกเพิ่มจะกำหนดว่าคอลเลกชัน `getCustomData().getCustomXmlParts()` ของอ็อบเจ็กต์ใดบ้างที่มีความสัมพันธ์กับส่วนนั้น ข้อมูลระดับงานนำเสนอเหมาะกับเมทาดาต้าทั่วทั้งหมดของเอกสาร, ข้อมูลระดับสไลด์สำหรับข้อมูลที่เป็นของสไลด์เฉพาะ, และข้อมูลระดับรูปทรงสำหรับเมทาดาต้าที่เชื่อมโยงกับรูปทรงแต่ละรูป

### **แสดงรายการและตรวจสอบส่วน XML แบบกำหนดเองทั้งหมด**

ใช้เมธอด [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) เพื่อดึงส่วน XML แบบกำหนดเองทั้งหมดจากงานนำเสนอ แต่ละ [`ICustomXmlPart`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart/) จะเผยให้เห็นตัวระบุ, เนื้อหา XML, และสคีมเนมสเปซที่เชื่อมโยง

ตัวอย่างต่อไปนี้แสดงรายการส่วน XML แบบกำหนดเองทั้งหมดและสคีมเนมสเปซของพวกมัน:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

`[ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) คืนค่าสกีม XML ที่เชื่อมโยงกับส่วน XML แบบกำหนดเอง ข้อมูลนี้อาจเป็นประโยชน์เมื่อทำการตรวจสอบงานนำเสนอที่มี XML ที่ผลิตโดยระบบภายนอก

### **อ่านและอัปเดตเนื้อหา XML และ ItemId**

ใช้เมธอด [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) และ [`setXmlAsString()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) เพื่อทำงานกับ XML เป็นสตริง UTF-8 หรือใช้ [`getXmlData()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#getXmlData--) และ [`setXmlData()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) เพื่อทำงานกับไบต์ XML ดิบ

เมธอด [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#getItemId--) จะคืนค่า UUID ที่ระบุส่วน XML แบบกำหนดเองในเอกสาร Office Open XML ใช้เมธอด [`setItemId()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) เมื่อการรวมระบบต้องการตัวระบุใหม่

ตัวอย่างต่อไปนี้อัปเดตเนื้อหา XML และตัวระบุ:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // อ่าน XML ปัจจุบันเป็นข้อความ.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // อัปเดต XML เป็นสตริง UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData ให้เนื้อหา XML เดียวกันเป็นไบต์ดิบ.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // แทนที่ตัวระบุเมื่อการรวมระบบต้องการ.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมื่อเรียก `setXmlAsString` หรือ `setXmlData` ให้จัดหา XML ที่ถูกต้องและไม่ว่างเปล่า ใช้รูปแบบใดรูปแบบหนึ่งตามว่าการทำงานของแอปพลิเคชันใช้สตริงหรือข้อมูลไบต์เป็นหลัก

### **ลบส่วน XML แบบกำหนดเอง**

Aspose.Slides มีวิธีหลายวิธีในการลบข้อมูล XML แบบกำหนดเอง:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#remove--) ลบส่วน XML แบบกำหนดเองออกจากงานนำเสนอ
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) ลบส่วนที่ระบุจากคอลเลกชันส่วน XML แบบกำหนดเอง
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) ลบส่วนที่ตำแหน่งดัชนีที่ระบุในคอลเลกชัน
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPartCollection#clear--) ลบส่วนทั้งหมดจากคอลเลกชันที่ระบุ

ตัวอย่างต่อไปนี้ลบส่วน XML แบบกำหนดเองระดับงานนำเสนอหนึ่งส่วนโดยอ้างอิง:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากคุณมี `ICustomXmlPart` อยู่แล้วและต้องการลบส่วนนั้นออกจากงานนำเสนอแทนการจัดการคอลเลกชันเฉพาะ ให้เรียก `customXmlPart.remove()`

คุณยังสามารถลบรายการโดยใช้ดัชนีได้:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **ล้างส่วน XML แบบกำหนดเองทั้งหมดจากคอลเลกชัน**

ใช้ `clear` เมื่อต้องการลบส่วน XML แบบกำหนดเองทั้งหมดที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอใดอ็อบเจ็กต์หนึ่ง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` มีผลต่อเพียงคอลเลกชันที่เลือกเท่านั้น ตัวอย่างเช่น การล้างคอลเลกชันของสไลด์จะไม่ล้างคอลเลกชันระดับงานนำเสนอหรือระดับรูปทรง

เพื่อทำการลบส่วน XML แบบกำหนดเองทั้งหมดในงานนำเสนอ ให้วนลูปผ่าน `getAllCustomXmlParts()` และลบแต่ละส่วน:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **จัดการส่วน XML แบบกำหนดเองที่เชื่อมโยงหรือแชร์**

ในงานนำเสนอ Office Open XML ส่วน XML แบบกำหนดเองเดียวกันอาจถูกอ้างอิงจากอ็อบเจ็กต์งานนำเสนอหลายอ็อบเจ็กต์ ตัวอย่างเช่น ไฟล์ที่มีอยู่สามารถมีความสัมพันธ์จากหลายสไลด์หรือรูปทรงไปยังส่วน XML แบบกำหนดพื้นฐานเดียวกัน

ส่วนที่แชร์ควรถือว่าเป็นอ็อบเจ็กต์ข้อมูลเดียวที่มีการอ้างอิงหลายครั้ง:

- การอัปเดตด้วย `setXmlAsString`, `setXmlData`, หรือ `setItemId` จะเปลี่ยนส่วน XML แบบกำหนดพื้นฐาน ดังนั้นการเปลี่ยนแปลงจะส่งผลทุกที่ที่ส่วนนั้นถูกอ้างอิง
- `getItemId()` สามารถใช้เพื่อระบุส่วน XML แบบกำหนดเดียวกันขณะตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์
- การลบส่วนจากคอลเลกชัน `getCustomXmlParts()` เฉพาะจะลบมันออกจากคอลเลกชันนั้น ใช้ `ICustomXmlPart.remove()` เมื่อต้องการลบส่วนนั้นออกจากงานนำเสนอ
- ก่อนลบหรือแทนที่ส่วนที่แชร์ ให้ตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์เพื่อดูว่าสไลด์หรือรูปทรงอื่น ๆ ยังอ้างอิงถึงมันหรือไม่

เมธอด `add` ที่มีการโอเวอร์โหลดจะสร้างส่วน XML แบบกำหนดใหม่จากเนื้อหา XML; พวกมันไม่รับ `ICustomXmlPart` ที่มีอยู่ ดังนั้นความสัมพันธ์ที่แชร์มักพบมากที่สุดเมื่อโหลดงานนำเสนอที่มีส่วนเหล่านั้นอยู่แล้ว

ตัวอย่างต่อไปนี้ตรวจสอบคอลเลกชันระดับงานนำเสนอ, สไลด์, และรูปทรงโดยใช้ `ItemId` และรายงานส่วนที่ถูกอ้างอิงจากหลายที่:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

การตรวจสอบประเภทนี้เป็นประโยชน์ก่อนทำการแก้ไขหรือทำลายข้อมูล XML แบบกำหนดเองในงานนำเสนอที่สร้างโดยระบบภายนอก เนื่องจากส่วนเมทาดาต้าเดียวกันอาจเข้าร่วมในความสัมพันธ์หลายครั้ง

## **รับค่าของแท็ก**

ในสไลด์, แท็กสอดคล้องกับเมธอด `IDocumentProperties.getKeywords()` ตัวอย่างโค้ดนี้แสดงวิธีรับค่าของแท็กด้วย Aspose.Slides สำหรับ Java สำหรับ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **เพิ่มแท็กไปยังงานนำเสนอ**

Aspose.Slides ให้คุณเพิ่มแท็กไปยังงานนำเสนอ แท็กโดยทั่วไปประกอบด้วยสองส่วน:

- ชื่อของคุณสมบัติกำหนดเอง เช่น `MyTag`;
- ค่าของคุณสมบัติกำหนดเอง เช่น `My Tag Value`.

หากต้องการจัดประเภทงานนำเสนอตามกฎหรือคุณสมบัติเฉพาะ คุณสามารถเพิ่มแท็กเพื่อจุดประสงค์นั้นได้ ตัวอย่างเช่น หากต้องการจำแนกงานนำเสนอจากประเทศในอเมริกาเหนือ คุณสามารถสร้างแท็กอเมริกาเหนือและกำหนดประเทศที่เกี่ยวข้องเป็นค่าของแท็ก

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กไปยัง [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) โดยใช้ Aspose.Slides สำหรับ Java:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

แท็กสามารถตั้งค่าให้กับ [Slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide) ด้วยเช่นกัน:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

หรือสำหรับ [Shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) รายบุคคล:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชัน `getCustomData().getTags()` จะถูกจัดเก็บไว้ในไฟล์ PowerPoint เท่านั้น พวกมัน **ไม่** ถูกโอนย้ายไปยังโครงสร้างแท็กของ PDF เมื่อทำการส่งออกงานนำเสนอเป็น PDF ดังนั้นตัวระบุกำหนดเองที่กำหนดเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้

**วิธีแก้**: คุณสามารถเก็บตัวระบุกำหนดเองใน **Alt Text** ของอ็อบเจ็กต์ (เช่น `shape.setAlternativeText("MyId")`) หลังจากส่งออกเป็น PDF, Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์ หรือรูปทรงในการทำรายการเดียวได้หรือไม่?**  
ใช่. [tag collection](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/) รองรับการทำงาน [clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/#clear--) ที่จะลบคู่คีย์‑ค่าทั้งหมดพร้อมกัน

**ฉันจะลบแท็กเดียวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปผ่านคอลเลกชันทั้งหมดได้อย่างไร?**  
ใช้เมธอด [remove(name)](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) บน [tag collection](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/) เพื่อลบแท็กโดยใช้คีย์ของมัน

**ฉันจะดึงรายการชื่อแท็กทั้งหมดเพื่อการวิเคราะห์หรือการกรองได้อย่างไร?**  
ใช้เมธอด [getNamesOfTags](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/#getNamesOfTags--) บน [tag collection](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/) จะคืนค่าอาเรย์ของชื่อแท็กทั้งหมด

**ฉันจะค้นหาส่วน XML แบบกำหนดเองทั้งหมดโดยไม่คำนึงว่ามันจัดเก็บอยู่ที่ไหนได้อย่างไร?**  
ใช้เมธอด [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) เพื่อดึงส่วน XML แบบกำหนดเองทั้งหมดในงานนำเสนอ

**ฉันควรใช้ `getXmlAsString`/`setXmlAsString` หรือ `getXmlData`/`setXmlData` เพื่ออัปเดตส่วน XML แบบกำหนดเอง?**  
ใช้ `getXmlAsString` และ `setXmlAsString` เมื่อแอปพลิเคชันทำงานกับข้อความ XML แบบ UTF-8 ใช้ `getXmlData` และ `setXmlData` เมื่อ XML มีอยู่แล้วเป็นอาร์เรย์ของไบต์หรือเมื่อการประมวลผลเชิงไบนารีสะดวกกว่า ทั้งสองรูปแบบอ้างอิงถึงเนื้อหา XMLของส่วน XML แบบกำหนดเดียวกัน