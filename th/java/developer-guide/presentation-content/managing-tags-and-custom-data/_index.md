---
title: จัดการแท็กและข้อมูลแบบกำหนดเองในงานนำเสนอโดยใช้ Java
linktitle: แท็กและข้อมูลแบบกำหนดเอง
type: docs
weight: 300
url: /th/java/managing-tags-and-custom-data/
keywords:
- คุณสมบัติเอกสาร
- แท็ก
- ข้อมูลแบบกำหนดเอง
- XML แบบกำหนดเอง
- ส่วน XML แบบกำหนดเอง
- เมทาดาต้า XML
- ItemId
- เพิ่มแท็ก
- คู่ค่า
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการแท็กและข้อมูล XML แบบกำหนดเองในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java รวมถึงการเพิ่ม, การอ่าน, การอัปเดต, การตรวจสอบ, และการลบส่วน XML แบบกำหนดเอง"
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลแบบกำหนดเองในงานนำเสนอ PowerPoint อย่างไร ข้อมูลที่เฉพาะเจาะจงต่อการนำเสนอสามารถจัดเก็บเป็นแท็กหรือส่วน XML แบบกำหนดเองได้ แท็กเป็นคู่ค่ากุญแจ‑ค่าแบบสตริงง่าย ๆ ขณะที่ส่วน XML แบบกำหนดเองสามารถเก็บเมทาดาต้าที่จัดโครงสร้างและข้อมูล XML ที่เฉพาะต่อแอปพลิเคชัน

Aspose.Slides ให้ API สำหรับการเพิ่ม, อ่าน, อัปเดต, ตรวจสอบ, และลบส่วน XML แบบกำหนดเองในระดับงานนำเสนอ, สไลด์, และวัตถุรูปทรง ส่วน XML แบบกำหนดเองมีประโยชน์สำหรับการรวมระบบที่ต้องจัดเก็บข้อมูลเช่น ตัวระบุการจัดการเอกสาร, สถานะเวิร์กโฟลว์, เมทาดาต้าการปฏิบัติตาม, ข้อมูลการผูกเทมเพลต หรือข้อมูลแอปพลิเคชันที่มีโครงสร้างอื่น ๆ ภายในงานนำเสนอ

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีนามสกุล `.pptx` — ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML Office Open XML กำหนดโครงสร้างแพ็กเกจและความสัมพันธ์ที่ใช้เพื่อจัดเก็บเนื้อหาการนำเสนอและข้อมูลที่เกี่ยวข้อง

งานนำเสนอประกอบด้วยหลายส่วนที่เชื่อมต่อกันด้วยความสัมพันธ์ ตัวอย่างเช่น ส่วนสไลด์ประกอบด้วยเนื้อหาของสไลด์เดียวและอาจมีความสัมพันธ์ที่ชัดเจนไปยังส่วนอื่น ๆ ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลแบบกำหนดเองสามารถจัดเก็บเป็นแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITagCollection)) หรือส่วน XML แบบกำหนดเอง ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPartCollection)) ทั้งสองแบบเข้าถึงได้ผ่านอินเทอร์เฟซ [`ICustomData`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomData/)  

{{% alert color="primary" %}}
แท็กเก็บคู่ค่ากุญแจ‑ค่าที่เป็นสตริงอย่างง่าย ส่วน XML แบบกำหนดเองเก็บข้อมูล XML ที่มีโครงสร้างและสามารถเชื่อมโยงกับงานนำเสนอ, สไลด์, หรือรูปทรงได้
{{% /alert %}}

## **ทำงานกับส่วน XML แบบกำหนดเอง**

เมธอด [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomData#getCustomXmlParts--) คืนค่าคอลเลกชันของส่วน XML แบบกำหนดเองที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอที่ระบุ ตัวอย่างเช่น

- `presentation.getCustomData().getCustomXmlParts()` มีส่วน XML แบบกำหนดเองที่เชื่อมโยงกับงานนำเสนอเอง
- `slide.getCustomData().getCustomXmlParts()` มีส่วน XML แบบกำหนดเองที่เชื่อมโยงกับสไลด์เฉพาะ
- `shape.getCustomData().getCustomXmlParts()` มีส่วน XML แบบกำหนดเองที่เชื่อมโยงกับรูปทรงเฉพาะ

ใช้ [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) เมื่อคุณต้องการตรวจสอบส่วน XML แบบกำหนดเองทั้งหมดในงานนำเสนอโดยไม่คำนึงว่าถูกเชื่อมโยงกับอ็อบเจ็กต์ใด  

### **เพิ่มส่วน XML แบบกำหนดเองให้กับงานนำเสนอ**

ใช้เมธอด [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) เพื่อเพิ่มข้อมูล XML ไปยังคอลเลกชันส่วน XML แบบกำหนดเอง XML ต้องเป็นไปตามมาตรฐานและไม่เป็นค่าว่าง

ตัวอย่างต่อไปนี้เพิ่มเมทาดาต้าที่จัดโครงสร้างลงในคอลเลกชันข้อมูลแบบกำหนดเองระดับงานนำเสนอ  

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

    // การเพิ่มจะกำหนดตัวระบุโดยอัตโนมัติ ตั้ง UUID เฉพาะเมื่อจำเป็นเท่านั้น.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมธอด `add` ยังสามารถรับ XML เป็นอาเรย์ไบท์หรือสตรีมอินพุตได้ ซึ่งมีประโยชน์เมื่อเนื้อหา XML มีอยู่แล้วในรูปแบบไบท์  

### **เพิ่มส่วน XML แบบกำหนดเองให้กับสไลด์หรือรูปทรง**

ข้อมูล XML แบบกำหนดเองสามารถเชื่อมโยงกับสไลด์หรือรูปทรงเฉพาะแทนที่ระดับงานนำเสนอทั้งหมด สิ่งนี้มีประโยชน์เมื่อเมทาดาต้าอธิบายวัตถุเดียวเท่านั้น เช่น คีย์เทมเพลต, ตัวระบุบันทึกภายนอก, หรือข้อมูลการผูก

ตัวอย่างต่อไปนี้เพิ่มส่วน XML แบบกำหนดเองหนึ่งส่วนให้กับสไลด์และอีกส่วนให้กับรูปทรง  

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

ระดับที่ส่วนถูกเพิ่มจะกำหนดว่าคอลเลกชัน `getCustomData().getCustomXmlParts()` ของอ็อบเจ็กต์ใดบ้างที่มีความสัมพันธ์กับส่วนนั้น ข้อมูลระดับงานนำเสนอเหมาะกับเมทาดาต้าระดับเอกสารทั้งหมด, ข้อมูลระดับสไลด์สำหรับข้อมูลที่เป็นของสไลด์เฉพาะ, และข้อมูลระดับรูปทรงสำหรับเมทาดาต้าที่ผูกกับรูปทรงเดี่ยว  

### **รายการและตรวจสอบส่วน XML แบบกำหนดเองทั้งหมด**

ใช้ [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) เพื่อดึงส่วน XML แบบกำหนดเองทั้งหมดจากงานนำเสนอ แต่ละ [`ICustomXmlPart`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart/) จะเปิดเผยตัวระบุ, เนื้อหา XML, และสคีมเนมสเปซที่เชื่อมโยง

ตัวอย่างต่อไปนี้แสดงรายการส่วน XML แบบกำหนดเองทั้งหมดพร้อมสคีมเนมสเปซ  

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) คืนค่า XML สคีมที่เชื่อมโยงกับส่วน XML แบบกำหนดเอง ข้อมูลนี้อาจมีประโยชน์เมื่อทำการตรวจสอบงานนำเสนอที่มี XML มาจากระบบภายนอก  

### **อ่านและอัปเดตเนื้อหา XML และ ItemId**

ใช้ [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) และ [`setXmlAsString()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) เพื่อทำงานกับ XML เป็นสตริง UTF‑8 หรือใช้ [`getXmlData()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#getXmlData--) และ [`setXmlData()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) เพื่อทำงานกับไบท์ XML ดิบ

เมธอด [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#getItemId--) คืนค่า UUID ที่ระบุส่วน XML แบบกำหนดเองในเอกสาร Office Open XML ใช้ [`setItemId()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) เมื่อการรวมระบบต้องการตัวระบุใหม่

ตัวอย่างต่อไปนี้อัปเดตเนื้อหา XML และตัวระบุ  

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

    // getXmlData ให้เนื้อหา XML เดียวกันในรูปแบบไบต์ดิบ.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // แทนที่ตัวระบุเมื่อการรวมระบบต้องการ.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมื่อเรียก `setXmlAsString` หรือ `setXmlData` ให้ใส่ XML ที่เป็นไปตามมาตรฐานและไม่เป็นค่าว่าง ใช้ตัวแทนแบบใดแบบหนึ่งขึ้นอยู่กับว่าแอปพลิเคชันทำงานหลักกับสตริงหรือไบท์  

### **ลบส่วน XML แบบกำหนดเอง**

Aspose.Slides มีหลายวิธีในการลบข้อมูล XML แบบกำหนดเอง:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPart#remove--) ลบส่วน XML แบบกำหนดเองจากงานนำเสนอ
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) ลบส่วนเฉพาะจากคอลเลกชันส่วน XML แบบกำหนดเอง
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) ลบส่วนตามดัชนีที่ระบุในคอลเลกชัน
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICustomXmlPartCollection#clear--) ลบทุกส่วนจากคอลเลกชันที่ระบุ

ตัวอย่างต่อไปนี้ลบส่วน XML แบบกำหนดเองระดับงานนำเสนอหนึ่งส่วนโดยอ้างอิง  

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

หากคุณมี `ICustomXmlPart` อยู่แล้วและต้องการลบส่วนนั้นจากงานนำเสนอแทนการระบุคอลเลกชันเฉพาะ ให้เรียก `customXmlPart.remove()`  

คุณยังสามารถลบรายการตามดัชนีได้เช่นกัน  

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **ลบส่วน XML แบบกำหนดเองทั้งหมดจากคอลเลกชัน**

ใช้ `clear` เมื่อส่วน XML แบบกำหนดเองทั้งหมดที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอใด ๆ ต้องการถูกลบ  

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

`clear` มีผลต่อคอลเลกชันที่เลือกเท่านั้น ตัวอย่างเช่น การล้างคอลเลกชันของสไลด์จะไม่ล้างคอลเลกชันระดับงานนำเสนอหรือระดับรูปทรง

เพื่อทำการลบส่วน XML แบบกำหนดเองทุกส่วนในงานนำเสนอ ให้ทำการวนลูป `getAllCustomXmlParts()` แล้วลบแต่ละส่วน  

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

### **จัดการส่วน XML แบบกำหนดเองที่เชื่อมโยงหรือใช้ร่วมกัน**

ในงานนำเสนอ Office Open XML ส่วน XML แบบกำหนดเองเดียวอาจถูกอ้างอิงจากอ็อบเจ็กต์งานนำเสนอมากกว่าหนึ่งอ็อบเจ็กต์ ตัวอย่างเช่นไฟล์ที่มีอยู่แล้วอาจมีความสัมพันธ์จากหลายสไลด์หรือรูปทรงไปยังส่วน XML แบบกำหนดเองเดียวกัน

ส่วนที่ใช้ร่วมกันควรถือเป็นวัตถุข้อมูลหนึ่งที่มีการอ้างอิงหลายตำแหน่ง:

- การอัปเดตด้วย `setXmlAsString`, `setXmlData` หรือ `setItemId` จะเปลี่ยนส่วน XML แบบกำหนดเองพื้นฐาน ดังนั้นการเปลี่ยนแปลงจะส่งผลต่อทุกตำแหน่งที่อ้างอิงส่วนนั้น
- `getItemId()` สามารถใช้เพื่อระบุส่วน XML แบบกำหนดเองเดียวกันขณะตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์
- การลบส่วนจากคอลเลกชัน `getCustomXmlParts()` เฉพาะจะลบส่วนนั้นจากคอลเลกชันนั้นเท่านั้น ใช้ `ICustomXmlPart.remove()` เมื่อส่วนนั้นเองต้องการถูกลบออกจากงานนำเสนอทั้งหมด
- ก่อนลบหรือแทนที่ส่วนที่ใช้ร่วมกัน ให้ตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์เพื่อดูว่ายังมีสไลด์หรือรูปทรงอื่นอ้างอิงหรือไม่

เมธอด `add` สร้างส่วน XML แบบกำหนดใหม่จากเนื้อหา XML; ไม่รับ `ICustomXmlPart` ที่มีอยู่แล้ว ดังนั้นความสัมพันธ์ที่ใช้ร่วมกันมักพบเมื่อต้องโหลดงานนำเสนอที่มีอยู่แล้ว

ตัวอย่างต่อไปนี้ตรวจสอบคอลเลกชันระดับงานนำเสนอ, สไลด์, และรูปทรงโดย `ItemId` และรายงานส่วนที่ถูกอ้างอิงจากหลายตำแหน่ง  

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

การตรวจสอบลักษณะนี้มีประโยชน์ก่อนทำการแก้ไขหรือลบข้อมูล XML แบบกำหนดเองในงานนำเสนอที่สร้างโดยระบบภายนอก เนื่องจากส่วนเมทาดาต้าเดียวอาจมีส่วนร่วมในความสัมพันธ์หลาย ๆ จุด  

## **รับค่าแท็ก**

ใน Slides แท็กสอดคล้องกับเมธอด `IDocumentProperties.getKeywords()` ตัวอย่างโค้ดต่อไปนี้แสดงวิธีรับค่าของแท็กด้วย Aspose.Slides for Java สำหรับ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **เพิ่มแท็กให้กับงานนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กให้กับงานนำเสนอ แท็กทั่วไปประกอบด้วยสองรายการ:

- ชื่อของคุณสมบัติกำหนดเอง เช่น `MyTag`
- ค่าของคุณสมบัติกำหนดเอง เช่น `My Tag Value`

หากคุณต้องการจัดประเภทงานนำเสนอโดยกฎหรือคุณสมบัติเฉพาะ คุณสามารถเพิ่มแท็กเพื่อจุดประสงค์นั้นได้ ตัวอย่างเช่น หากต้องการจัดหมวดหมู่งานนำเสนอจากประเทศในอเมริกาเหนือ คุณสามารถสร้างแท็ก NorthAmerican แล้วกำหนดค่ารัฐหรือประเทศที่เกี่ยวข้องเป็นค่าแท็ก

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่มแท็กให้กับ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ด้วย Aspose.Slides for Java  

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

แท็กยังสามารถตั้งค่าให้กับ [Slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide) ได้เช่นกัน  

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

หรือตั้งค่าให้กับ [Shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) แยกตัว  

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

แท็กที่เพิ่มผ่านคอลเลกชัน `getCustomData().getTags()` จะถูกจัดเก็บไว้ในไฟล์ PowerPoint เท่านั้น พวกมัน **ไม่** ถูกถ่ายโอนไปยังโครงสร้างแท็กของ PDF เมื่อทำการส่งออกงานนำเสนอเป็น PDF ดังนั้น ตัวระบุแบบกำหนดเองที่ถูกตั้งเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้  

**วิธีแก้**: คุณสามารถเก็บตัวระบุแบบกำหนดเองใน **Alt Text** ของวัตถุ (เช่น `shape.setAlternativeText("MyId")`) หลังจากส่งออกเป็น PDF Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF  

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์ หรือรูปทรงในหนึ่งการทำงานได้หรือไม่?**

ได้ครับ คอลเลกชันแท็ก ([tag collection](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/)) รองรับการทำงาน `clear` ([clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/#clear--)) ที่ลบคู่ค่ากุญแจ‑ค่าทั้งหมดพร้อมกัน

**ฉันจะลบแท็กเดี่ยวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปผ่านคอลเลกชันทั้งหมดได้อย่างไร?**

ใช้ `remove(name)` ([remove(name)](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/#remove-java.lang.String-)) บนคอลเลกชันแท็ก ([tag collection](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/)) เพื่อทำการลบแท็กตามคีย์

**ฉันจะดึงรายการชื่อแท็กทั้งหมดสำหรับการวิเคราะห์หรือการกรองได้อย่างไร?**

ใช้ `getNamesOfTags` ([getNamesOfTags](https://reference.aspose.com/slides/th/java/com.aspose.slides/tagcollection/#getNamesOfTags--)) บนคอลเลกชันแท็ก; เมธอดนี้จะคืนค่าอาเรย์ของชื่อแท็กทั้งหมด

**ฉันจะค้นหาส่วน XML แบบกำหนดเองทั้งหมดโดยไม่สนใจว่ามันถูกเก็บที่ไหน?**

ใช้ [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) เพื่อดึงส่วน XML แบบกำหนดเองทั้งหมดในงานนำเสนอ

**ฉันควรใช้ `getXmlAsString`/`setXmlAsString` หรือ `getXmlData`/`setXmlData` เพื่ออัปเดตส่วน XML แบบกำหนดเอง?**

เมื่อแอปพลิเคชันทำงานกับข้อความ XML รูปแบบ UTF‑8 ให้ใช้ `getXmlAsString` และ `setXmlAsString` หาก XML มีอยู่แล้วเป็นอาเรย์ไบท์หรือการประมวลผลแบบไบท์เป็นหลัก ให้ใช้ `getXmlData` และ `setXmlData` ทั้งสองวิธีอ้างอิงถึงเนื้อหา XML ของส่วน XML แบบกำหนดเดียวกัน