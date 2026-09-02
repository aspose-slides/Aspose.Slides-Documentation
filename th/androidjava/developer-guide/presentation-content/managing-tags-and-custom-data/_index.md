---
title: "จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอบน Android"
linktitle: "แท็กและข้อมูลกำหนดเอง"
type: docs
weight: 300
url: /th/androidjava/managing-tags-and-custom-data
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
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการแท็กและข้อมูล XML กำหนดเองในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java รวมถึงการเพิ่ม, การอ่าน, การอัปเดต, การตรวจสอบ, และการลบส่วน XML กำหนดเอง."
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลแบบกำหนดเองในงานนำเสนอ PowerPoint อย่างไร ข้อมูลเฉพาะงานนำเสนอสามารถจัดเก็บเป็นแท็กหรือส่วน XML กำหนดเองได้ แท็กเป็นคู่คีย์‑ค่าแบบสตริงทั่วไป ในขณะที่ส่วน XML กำหนดเองสามารถจัดเก็บเมทาดาต้ารูปแบบโครงสร้างและข้อมูล XML ที่เฉพาะต่อแอปพลิเคชันได้

Aspose.Slides มี API สำหรับการเพิ่ม, อ่าน, ปรับปรุง, ตรวจสอบ, และลบส่วน XML กำหนดเองในระดับงานนำเสนอ, สไลด์, และรูปร่าง ส่วน XML กำหนดเองเป็นประโยชน์สำหรับการบูรณาการที่ต้องเก็บข้อมูลเช่น ตัวระบุการจัดการเอกสาร, สถานะขั้นตอนทำงาน, เมทาดาต้าการปฏิบัติตาม, ข้อมูลการผูกเทมเพลต, หรือข้อมูลแอปพลิเคชันเชิงโครงสร้างอื่น ๆ ภายในงานนำเสนอ

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX—ไฟล์ที่มีส่วนขยาย `.pptx`—ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML Office Open XML กำหนดโครงสร้างแพ็กเกจและความสัมพันธ์ที่ใช้ในการจัดเก็บเนื้อหางานนำเสนอและข้อมูลที่เกี่ยวข้อง

งานนำเสนอประกอบด้วยหลายส่วนที่เชื่อมต่อกันด้วยความสัมพันธ์ ตัวอย่างเช่น ส่วนสไลด์จะบรรจุเนื้อหาของสไลด์เดียวและอาจมีความสัมพันธ์อย่างชัดเจนกับส่วนอื่น ๆ ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลแบบกำหนดเองสามารถจัดเก็บเป็นแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITagCollection)) หรือส่วน XML กำหนดเอง ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPartCollection)) ทั้งสองแบบสามารถเข้าถึงได้ผ่านอินเทอร์เฟซ [`ICustomData`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomData/) 

{{% alert color="primary" %}}
แท็กเก็บคู่คีย์‑ค่าแบบสตริงง่าย ๆ ส่วน XML กำหนดเองเก็บข้อมูล XML แบบโครงสร้างและสามารถเชื่อมโยงกับงานนำเสนอ, สไลด์ หรือรูปร่างได้
{{% /alert %}}

## **ทำงานกับส่วน XML กำหนดเอง**

เมธอด [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) จะคืนคอลเลกชันของส่วน XML กำหนดเองที่เชื่อมโยงกับออบเจกต์งานนำเสนอที่ระบุ ตัวอย่างเช่น:

- `presentation.getCustomData().getCustomXmlParts()` มีส่วน XML กำหนดเองที่เชื่อมโยงกับงานนำเสนอเอง
- `slide.getCustomData().getCustomXmlParts()` มีส่วน XML กำหนดเองที่เชื่อมโยงกับสไลด์เฉพาะ
- `shape.getCustomData().getCustomXmlParts()` มีส่วน XML กำหนดเองที่เชื่อมโยงกับรูปร่างเฉพาะ

ใช้เมธอด [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) เมื่อคุณต้องการตรวจสอบส่วน XML กำหนดเองทั้งหมดในงานนำเสนอโดยไม่สนใจว่าถูกเชื่อมโยงกับออบเจกต์ใด

### **เพิ่มส่วน XML กำหนดเองในงานนำเสนอ**

ใช้เมธอด [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) เพื่อเพิ่มข้อมูล XML ลงในคอลเลกชันส่วน XML กำหนดเอง XML ต้องเป็นรูปแบบที่ถูกต้องและไม่ว่างเปล่า

ตัวอย่างต่อไปนี้เพิ่มเมทาดาต้าโครงสร้างไปยังคอลเลกชันข้อมูลกำหนดเองระดับงานนำเสนอ:

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

    // add กำหนดตัวระบุโดยอัตโนมัติ ตั้งค่า UUID เฉพาะเมื่อจำเป็น
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมธอด `add` ยังสามารถรับ XML เป็นอาร์เรย์ไบต์หรือสตรีมอินพุตได้ ซึ่งมีประโยชน์เมื่อเนื้อหา XML มีอยู่ในรูปแบบไบต์แล้ว

### **เพิ่มส่วน XML กำหนดเองในสไลด์หรือรูปร่าง**

ข้อมูล XML กำหนดเองสามารถเชื่อมโยงกับสไลด์หรือรูปร่างเฉพาะแทนที่จะเป็นทั้งงานนำเสนอ ซึ่งมีประโยชน์เมื่อเมทาดาต้าอธิบายเพียงออบเจกต์เดียว เช่น คีย์เทมเพลต, ตัวระบุบันทึกภายนอก, หรือข้อมูลการผูก

ตัวอย่างต่อไปนี้เพิ่มส่วน XML กำหนดเองหนึ่งส่วนในสไลด์และอีกส่วนหนึ่งในรูปร่าง:

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

ระดับที่ส่วนถูกเพิ่มจะกำหนดว่าคอลเลกชัน `getCustomData().getCustomXmlParts()` ของออบเจกต์ใดจะมีความสัมพันธ์กับส่วนนั้น ข้อมูลระดับงานนำเสนอเหมาะกับเมทาดาต้าทั่วเอกสาร, ข้อมูลระดับสไลด์สำหรับข้อมูลที่เป็นของสไลด์นั้น, และข้อมูลระดับรูปร่างสำหรับเมทาดาต้าที่ผูกกับรูปร่างแต่ละอัน

### **แสดงรายการและตรวจสอบส่วน XML กำหนดเองทั้งหมด**

ใช้เมธอด [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) เพื่อดึงส่วน XML กำหนดเองทั้งหมดจากงานนำเสนอ แต่ละออบเจกต์ [`ICustomXmlPart`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart/) จะเปิดเผยตัวระบุ, เนื้อหา XML, และสคีมเนมสเปซที่เชื่อมโยง

ตัวอย่างต่อไปนี้แสดงรายการส่วน XML กำหนดเองทั้งหมดพร้อมสคีมเนมสเปซ:

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

เมธอด [`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) คืนค่าสคีม XML ที่เชื่อมโยงกับส่วน XML กำหนดเอง ข้อมูลนี้อาจมีประโยชน์เมื่อตรวจสอบงานนำเสนอที่มี XML มาจากระบบภายนอก

### **อ่านและอัปเดตเนื้อหา XML และ ItemId**

ใช้เมธอด [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) และ [`setXmlAsString()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) เพื่อทำงานกับ XML ในรูปแบบสตริง UTF‑8 หรือใช้เมธอด [`getXmlData()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) และ [`setXmlData()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) เพื่อทำงานกับไบต์ XML ดิบ

เมธอด [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) จะคืนค่า UUID ที่ใช้ระบุส่วน XML กำหนดเองในเอกสาร Office Open XML ใช้เมธอด [`setItemId()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) เมื่อการบูรณาการต้องการตัวระบุใหม่

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

    // getXmlData ให้ XML เดียวกันในรูปแบบไบต์ดิบ.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // แทนที่ตัวระบุเมื่อการบูรณาการต้องการ.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมื่อเรียก `setXmlAsString` หรือ `setXmlData` ให้ส่ง XML ที่ถูกต้องและไม่ว่างเปล่า ใช้รูปแบบใดรูปแบบหนึ่งตามที่แอปพลิเคชันทำงานกับสตริงหรือไบต์เป็นหลัก

### **ลบส่วน XML กำหนดเอง**

Aspose.Slides มีหลายวิธีในการลบข้อมูล XML กำหนดเอง:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#remove--) ลบส่วน XML กำหนดเองจากงานนำเสนอ
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) ลบส่วนเฉพาะจากคอลเลกชันส่วน XML กำหนดเอง
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) ลบส่วนที่ตำแหน่งดัชนีที่ระบุในคอลเลกชัน
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) ลบส่วนทั้งหมดจากคอลเลกชันที่ระบุ

ตัวอย่างต่อไปนี้ลบส่วน XML กำหนดเองระดับงานนำเสนอหนึ่งส่วนโดยอ้างอิง:

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

หากคุณมีออบเจกต์ `ICustomXmlPart` แล้วต้องการลบส่วนนั้นจากงานนำเสนอแทนการอ้างอิงคอลเลกชันเฉพาะ ให้เรียก `customXmlPart.remove()`

คุณสามารถลบรายการตามดัชนีได้เช่นกัน:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **ล้างส่วน XML กำหนดเองทั้งหมดจากคอลเลกชัน**

ใช้ `clear` เมื่อส่วน XML กำหนดเองทั้งหมดที่เชื่อมโยงกับออบเจกต์งานนำเสนอที่ระบุควรถูกลบ

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

`clear` มีผลต่อคอลเลกชันที่เลือกเท่านั้น ตัวอย่างเช่น การล้างคอลเลกชันของสไลด์จะไม่ล้างคอลเลกชันระดับงานนำเสนอหรือระดับรูปร่าง

หากต้องการลบส่วน XML กำหนดเองทุกส่วนในงานนำเสนอ ให้วนลูปผ่าน `getAllCustomXmlParts()` และลบแต่ละส่วน:

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

### **จัดการส่วน XML กำหนดเองที่เชื่อมโยงหรือใช้ร่วมกัน**

ในงานนำเสนอ Office Open XML ส่วน XML กำหนดเองเดียวกันอาจถูกอ้างอิงจากออบเจกต์งานนำเสนอหลายออบเจกต์ ตัวอย่างเช่น ไฟล์ที่มีอยู่แล้วอาจมีความสัมพันธ์จากหลายสไลด์หรือรูปร่างไปยังส่วน XML กำหนดเองเดียวกัน

ส่วนที่ใช้ร่วมกันควรถือเป็นวัตถุข้อมูลหนึ่งที่มีการอ้างอิงหลายตำแหน่ง:

- การอัปเดตด้วย `setXmlAsString`, `setXmlData` หรือ `setItemId` จะเปลี่ยนส่วน XML กำหนดเองพื้นฐาน ดังนั้นการเปลี่ยนแปลงจะนำไปใช้ทุกที่ที่ส่วนนั้นถูกอ้างอิง
- `getItemId()` สามารถใช้เพื่อระบุส่วน XML กำหนดเดียวกันขณะตรวจสอบคอลเลกชันระดับออบเจกต์
- การลบส่วนจากคอลเลกชัน `getCustomXmlParts()` ใด ๆ จะลบส่วนจากคอลเลกชันนั้นเท่านั้น ใช้ `ICustomXmlPart.remove()` เมื่อส่วนนั้นควรถูกลบออกจากงานนำเสนอทั้งหมด
- ก่อนลบหรือแทนที่ส่วนที่ใช้ร่วมกัน ควรตรวจสอบคอลเลกชันระดับออบเจกต์เพื่อดูว่าสไลด์หรือรูปร่างอื่น ๆ ยังอ้างอิงส่วนนั้นอยู่หรือไม่

เมธอด `add` overloads สร้างส่วน XML กำหนดใหม่จากเนื้อหา XML; ไม่รับ `ICustomXmlPart` ที่มีอยู่แล้ว ดังนั้นความสัมพันธ์ที่ใช้ร่วมกันมักพบเมื่อโหลดงานนำเสนอที่มีส่วนเหล่านั้นอยู่แล้ว

ตัวอย่างต่อไปนี้ตรวจสอบคอลเลกชันระดับงานนำเสนอ, สไลด์, และรูปร่างโดย `ItemId` และรายงานส่วนที่อ้างอิงจากมากกว่าหนึ่งตำแหน่ง:

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

การตรวจสอบแบบนี้มีประโยชน์ก่อนทำการแก้ไขหรือ删除ข้อมูล XML กำหนดเองในงานนำเสนอที่สร้างโดยระบบภายนอก เนื่องจากส่วนเมทาดาต้าเดียวกันอาจมีส่วนร่วมในหลายความสัมพันธ์

## **รับค่าของแท็ก**

ใน Slides, แท็กสอดคล้องกับเมธอด `IDocumentProperties.getKeywords()` ตัวอย่างโค้ดนี้แสดงวิธีดึงค่าของแท็กด้วย Aspose.Slides for Android via Java สำหรับ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **เพิ่มแท็กลงในงานนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กลงในงานนำเสนอ แท็กโดยทั่วไปประกอบด้วยสองรายการ:

- ชื่อของคุณสมบัติกำหนดเอง, ตัวอย่างเช่น `MyTag`
- ค่า ของคุณสมบัติกำหนดเอง, ตัวอย่างเช่น `My Tag Value`

หากคุณต้องการจัดประเภทงานนำเสนอโดยกฎหรือคุณสมบัติเฉพาะ คุณสามารถเพิ่มแท็กเพื่อวัตถุนั้นได้ ตัวอย่างเช่น หากต้องการจำแนกงานนำเสนอจากประเทศในอเมริกาเหนือ คุณสามารถสร้างแท็ก North American แล้วกำหนดค่าชื่อประเทศที่เกี่ยวข้องเป็นค่า

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กลงใน [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ด้วย Aspose.Slides for Android via Java:

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

แท็กยังสามารถกำหนดให้กับ [Slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlide) ได้เช่นกัน:

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

หรือกำหนดให้กับ [Shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) รายบุคคล:

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

แท็กที่เพิ่มผ่านคอลเลกชัน `getCustomData().getTags()` จะถูกจัดเก็บเฉพาะในไฟล์ PowerPoint เท่านั้น ซึ่ง **ไม่ได้** ถูกถ่ายโอนไปยังโครงสร้างแท็ก PDF เมื่อส่งออกงานนำเสนอเป็น PDF ดังนั้นตัวระบุที่กำหนดเป็นแท็กจะไม่สามารถเรียกคืนจาก PDF ที่มีแท็กได้

**วิธีแก้**: คุณสามารถเก็บตัวระบุกำหนดเองไว้ใน **Alt Text** ของออบเจกต์ (เช่น `shape.setAlternativeText("MyId")`) หลังจากส่งออกเป็น PDF Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามยอดนิยม**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์ หรือรูปร่างในหนึ่งการดำเนินการได้หรือไม่?**

ได้. คอลเลกชัน [tag collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/) รองรับการทำงาน [clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/#clear--) ที่ลบคู่คีย์‑ค่าทั้งหมดพร้อมกัน

**ฉันจะลบแท็กเดียวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปคอลเลกชันทั้งหมดอย่างไร?**

ใช้เมธอด [remove(name)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) บน [tag collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/) เพื่อทำการลบแท็กตามคีย์

**ฉันจะดึงรายการชื่อแท็กทั้งหมดสำหรับการวิเคราะห์หรือการกรองได้อย่างไร?**

ใช้เมธอด [getNamesOfTags](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) บน [tag collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/) ซึ่งจะคืนอาเรย์ของชื่อแท็กทั้งหมด

**ฉันจะค้นหาส่วน XML กำหนดเองทั้งหมดโดยไม่คำนึงว่าถูกจัดเก็บที่ไหน?**

ใช้เมธอด [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) เพื่อดึงส่วน XML กำหนดเองทั้งหมดในงานนำเสนอ

**ควรใช้ `getXmlAsString`/`setXmlAsString` หรือ `getXmlData`/`setXmlData` เพื่ออัปเดตส่วน XML กำหนดเอง?**

ใช้ `getXmlAsString` และ `setXmlAsString` เมื่อแอปพลิเคชันทำงานกับข้อความ XML แบบ UTF‑8 ใช้ `getXmlData` และ `setXmlData` เมื่อ XML มีอยู่แล้วเป็นอาร์เรย์ไบต์หรือเมื่อการประมวลผลแบบไบต์สะดวกกว่า ทั้งสองรูปแบบอ้างอิงถึงเนื้อหา XML ของส่วน XML กำหนดเดียวกัน