---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอบน Android
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/androidjava/managing-tags-and-custom-data
keywords:
- คุณสมบัติเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- XML กำหนดเอง
- ส่วน XML กำหนดเอง
- เมทาดาต้า XML
- ItemId
- เพิ่มแท็ก
- ค่าคู่
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการจัดการแท็กและข้อมูล XML กำหนดเองในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java รวมถึงการเพิ่ม การอ่าน การอัปเดต การตรวจสอบ และการลบส่วน XML กำหนดเอง"
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลแบบกำหนดเองในงานนำเสนอ PowerPoint อย่างไร ข้อมูลที่เฉพาะเจาะจงต่อการนำเสนอสามารถเก็บเป็นแท็กหรือส่วน XML แบบกำหนดเองได้ แท็กเป็นคู่คีย์‑ค่าแบบสตริงที่ง่าย ๆ ในขณะที่ส่วน XML แบบกำหนดเองสามารถเก็บเมทาดาต้ารูปร่างและ payload XML เฉพาะแอปพลิเคชัน

Aspose.Slides มี API สำหรับเพิ่ม อ่าน ปรับปรุง ตรวจสอบ และลบส่วน XML แบบกำหนดเองในระดับการนำเสนอ สไลด์ และรูปทรง ส่วน XML แบบกำหนดเองมีประโยชน์ในการรวมข้อมูลเช่น ตัวระบุการจัดการเอกสาร สถานะเวิร์กโฟลว์ เมทาดาต้าการปฏิบัติตามข้อกำหนด ข้อมูลการผูกเทมเพลต หรือข้อมูลแอปพลิเคชันเชิงโครงสร้างอื่น ๆ ภายในงานนำเสนอ

## **การจัดเก็บข้อมูลในไฟล์การนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีสกุล `.pptx` — ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปก Office Open XML Office Open XML กำหนดโครงสร้างแพ็กเกจและความสัมพันธ์ที่ใช้ในการเก็บเนื้อหาและข้อมูลที่เกี่ยวข้องของการนำเสนอ

การนำเสนอประกอบด้วยหลายส่วนที่เชื่อมต่อกันด้วยความสัมพันธ์ ตัวอย่างเช่น ส่วนสไลด์จะบรรจุเนื้อหาของสไลด์เดียวและสามารถมีความสัมพันธ์ชัดเจนกับส่วนอื่น ๆ ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลแบบกำหนดเองสามารถเก็บเป็นแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITagCollection)) หรือส่วน XML แบบกำหนดเอง ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPartCollection)) ทั้งสองสามารถเข้าถึงได้ผ่านอินเทอร์เฟซ [`ICustomData`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomData/)  

{{% alert color="info" %}}
แท็กเก็บคู่คีย์‑ค่าที่เป็นสตริงอย่างง่าย ส่วน XML แบบกำหนดเองเก็บข้อมูล XML รูปร่างและสามารถเชื่อมโยงกับการนำเสนอ สไลด์ หรือรูปทรงได้
{{% /alert %}}

## **ทำงานกับส่วน XML แบบกำหนดเอง**

เมธอด [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) คืนคอลเลกชันของส่วน XML แบบกำหนดเองที่เชื่อมโยงกับออบเจกต์การนำเสนอเฉพาะ ตัวอย่างเช่น  

- `presentation.getCustomData().getCustomXmlParts()` มีส่วน XML แบบกำหนดเองที่เชื่อมโยงกับการนำเสนอเอง  
- `slide.getCustomData().getCustomXmlParts()` มีส่วน XML แบบกำหนดเองที่เชื่อมโยงกับสไลด์เฉพาะ  
- `shape.getCustomData().getCustomXmlParts()` มีส่วน XML แบบกำหนดเองที่เชื่อมโยงกับรูปทรงเฉพาะ  

ใช้ [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) เมื่อคุณต้องการตรวจสอบส่วน XML แบบกำหนดเองทั้งหมดในงานนำเสนอโดยไม่คำนึงว่าถูกเชื่อมโยงกับออบเจกต์ใด

### **เพิ่มส่วน XML แบบกำหนดเองในระดับการนำเสนอ**

ใช้เมธอด [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) เพื่อเพิ่มข้อมูล XML ไปยังคอลเลกชันส่วน XML แบบกำหนดเอง XML ต้องเป็นรูปแบบที่ถูกต้องและไม่เป็นค่าว่าง  

ตัวอย่างต่อไปนี้เพิ่มเมทาดาต้ารูปร่างลงในคอลเลกชันข้อมูลแบบกำหนดเองระดับการนำเสนอ  

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

    // add จัดสรรตัวระบุโดยอัตโนมัติ ตั้งค่า UUID เฉพาะเมื่อจำเป็นเท่านั้น.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมธอด `add` ยังรับ XML เป็นอาเรย์ไบต์หรือสตรีมอินพุต ซึ่งมีประโยชน์เมื่อเนื้อหา XML มีอยู่แล้วในรูปแบบไบนารี

### **เพิ่มส่วน XML แบบกำหนดเองในสไลด์หรือรูปทรง**

ข้อมูล XML แบบกำหนดเองสามารถเชื่อมโยงกับสไลด์หรือรูปทรงเฉพาะแทนการเชื่อมโยงกับการนำเสนอทั้งหมด ซึ่งเหมาะเมื่อเมทาดาต้าอธิบายเพียงออบเจกต์เดียว เช่น คีย์เทมเพลต ตัวระบุบันทึกภายนอก หรือข้อมูลการผูกมัด  

ตัวอย่างต่อไปนี้เพิ่มส่วน XML แบบกำหนดเองหนึ่งส่วนในสไลด์และอีกส่วนในรูปทรง  

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

ระดับที่เพิ่มส่วนกำหนดว่าคอลเลกชัน `getCustomData().getCustomXmlParts()` ของออบเจกต์ใดจะมีความสัมพันธ์กับส่วนนั้น ข้อมูลระดับการนำเสนอเหมาะกับเมทาดาต้าระดับเอกสารทั้งหมด ข้อมูลระดับสไลด์เหมาะกับข้อมูลที่เป็นของสไลด์เฉพาะ และข้อมูลระดับรูปทรงเหมาะกับเมทาดาต้าที่ผูกกับรูปทรงแต่ละอัน

### **แสดงรายการและตรวจสอบส่วน XML แบบกำหนดเองทั้งหมด**

ใช้ [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) เพื่อดึงส่วน XML แบบกำหนดเองทั้งหมดจากการนำเสนอ แต่ละออบเจกต์ [`ICustomXmlPart`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart/) จะเปิดเผยตัวระบุ เนื้อหา XML และสคีมเนมสเปซที่เชื่อมโยง  

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

เมธอด [`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) คืนค่า XML schema ที่เชื่อมโยงกับส่วน XML แบบกำหนดเอง ข้อมูลนี้อาจมีประโยชน์เมื่อทำการตรวจสอบงานนำเสนอที่มี XML มาจากระบบภายนอก

### **อ่านและปรับปรุงเนื้อหา XML และ ItemId**

ใช้เมธอด [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) และ [`setXmlAsString()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) เพื่อทำงานกับ XML เป็นสตริง UTF‑8 หรือใช้เมธอด [`getXmlData()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) และ [`setXmlData()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) เพื่อทำงานกับไบต์ XML ดิบ  

เมธอด [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) คืนค่า UUID ที่ระบุส่วน XML แบบกำหนดเองในเอกสาร Office Open XML ใช้เมธอด [`setItemId()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) เมื่อการรวมระบบต้องการตัวระบุใหม่  

ตัวอย่างต่อไปนี้ปรับปรุงเนื้อหา XML และตัวระบุ  

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

เมื่อเรียก `setXmlAsString` หรือ `setXmlData` ให้ส่ง XML ที่ถูกต้องและไม่เป็นค่าว่าง ใช้วิธีใดวิธีหนึ่งตามที่แอปพลิเคชันทำงานหลักกับสตริงหรือไบต์ข้อมูล

### **ลบส่วน XML แบบกำหนดเอง**

Aspose.Slides มีหลายวิธีในการลบข้อมูล XML แบบกำหนดเอง  

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPart#remove--) ลบส่วน XML แบบกำหนดเองจากการนำเสนอ  
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) ลบส่วนเฉพาะจากคอลเลกชันส่วน XML  
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) ลบส่วนที่ตำแหน่งดัชนีกำหนดในคอลเลกชัน  
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) ลบส่วนทั้งหมดจากคอลเลกชันที่ระบุ  

ตัวอย่างต่อไปนี้ลบส่วน XML แบบกำหนดเองระดับการนำเสนอหนึ่งส่วนโดยอ้างอิง  

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

หากคุณมีออบเจกต์ `ICustomXmlPart` อยู่แล้วและต้องการลบส่วนนั้นจากการนำเสนอแทนการอ้างอิงคอลเลกชันใด ๆ ให้เรียก `customXmlPart.remove()`  

คุณยังสามารถลบรายการโดยใช้ดัชนีได้เช่นกัน  

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **ล้างส่วน XML แบบกำหนดเองทั้งหมดจากคอลเลกชัน**

ใช้ `clear` เมื่อส่วน XML แบบกำหนดเองทั้งหมดที่เชื่อมโยงกับออบเจกต์การนำเสนอใด ๆ ต้องการถูกลบ  

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

`clear` มีผลต่อคอลเลกชันที่เลือกเท่านั้น ตัวอย่างเช่น การล้างคอลเลกชันของสไลด์จะไม่ล้างคอลเลกชันระดับการนำเสนอหรือระดับรูปทรง  

เพื่อลบส่วน XML แบบกำหนดเองทุกส่วนในงานนำเสนอ ให้วนลูปผ่าน `getAllCustomXmlParts()` แล้วลบแต่ละส่วน  

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

### **จัดการส่วน XML แบบกำหนดเองที่เชื่อมโยงหรือแชร์กัน**

ในงานนำเสนอ Office Open XML ส่วน XML แบบกำหนดเองเดียวกันอาจถูกอ้างอิงจากออบเจกต์การนำเสนอหลายตัว ตัวอย่างเช่น ไฟล์ที่มีอยู่แล้วอาจมีความสัมพันธ์จากหลายสไลด์หรือหลายรูปทรงไปยังส่วน XML แบบกำหนดเองเดียวกัน  

ส่วนที่แชร์ควรถือเป็นออบเจกต์ข้อมูลเดียวที่มีการอ้างอิงหลายครั้ง  

- การอัปเดตด้วย `setXmlAsString` `setXmlData` หรือ `setItemId` จะเปลี่ยนส่วน XML แบบกำหนดเองพื้นฐาน ดังนั้นการเปลี่ยนแปลงจะปรากฏทุกที่ที่อ้างอิงส่วนนั้น  
- `getItemId()` สามารถใช้ระบุส่วน XML แบบกำหนดเองเดียวกันขณะตรวจสอบคอลเลกชันระดับออบเจกต์  
- การลบส่วนจากคอลเลกชัน `getCustomXmlParts()` เฉพาะเจาะจงจะลบออกจากคอลเลกชันนั้น ใช้ `ICustomXmlPart.remove()` เมื่อส่วนนั้นควรลบออกจากการนำเสนอทั้งหมด  
- ก่อนลบหรือแทนที่ส่วนที่แชร์ ควรตรวจสอบคอลเลกชันระดับออบเจกต์เพื่อดูว่าสไลด์หรือรูปทรงอื่นยังอ้างอิงส่วนนั้นอยู่หรือไม่  

เมธอด `add` สร้างส่วน XML แบบกำหนดใหม่จากเนื้อหา XML; มันไม่รับ `ICustomXmlPart` ที่มีอยู่แล้ว ดังนั้นความสัมพันธ์ที่แชร์มักพบเมื่อโหลดงานนำเสนอที่มีส่วนเหล่านั้นอยู่แล้ว  

ตัวอย่างต่อไปนี้ตรวจสอบคอลเลกชันระดับการนำเสนอ – สไลด์ – รูปทรงโดยใช้ `ItemId` และรายงานส่วนที่ถูกอ้างอิงจากหลายตำแหน่ง  

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

การตรวจสอบแบบนี้มีประโยชน์ก่อนทำการแก้ไขหรือลบข้อมูล XML แบบกำหนดเองในงานนำเสนอที่สร้างโดยระบบภายนอก เพราะส่วนเมทาดาต้าเดียวกันอาจมีส่วนร่วมในหลายความสัมพันธ์

## **ดึงค่าของแท็ก**

ใน Slides แท็กสอดคล้องกับเมธอด `IDocumentProperties.getKeywords()` ตัวอย่างโค้ดนี้แสดงวิธีดึงค่าของแท็กด้วย Aspose.Slides for Android via Java สำหรับ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **เพิ่มแท็กในงานนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กในงานนำเสนอ แท็กโดยทั่วไปประกอบด้วยสองรายการ  

- ชื่อของคุณสมบัติแบบกำหนดเอง เช่น `MyTag`  
- ค่าของคุณสมบัติแบบกำหนดเอง เช่น `My Tag Value`  

หากคุณต้องการจัดประเภทงานนำเสนอโดยใช้กฎหรือคุณสมบัติเฉพาะ สามารถเพิ่มแท็กเพื่อจุดประสงค์นั้นได้ ตัวอย่างเช่น หากต้องการจัดประเภทงานนำเสนอจากประเทศในอเมริกาเหนือ คุณสามารถสร้างแท็ก “NorthAmerican” แล้วกำหนดค่าชื่อประเทศที่เกี่ยวข้อง  

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กให้กับ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ด้วย Aspose.Slides for Android via Java  

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

แท็กยังสามารถตั้งค่าให้กับ [Slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlide) ได้เช่นกัน  

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

หรือสำหรับ [Shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) แต่ละอัน  

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

แท็กที่เพิ่มผ่านคอลเลกชัน `getCustomData().getTags()` จะถูกจัดเก็บไว้เฉพาะในไฟล์ PowerPoint เท่านั้น **ไม่ได้** ถูกถ่ายโอนไปยังโครงสร้างแท็ก PDF เมื่อส่งออกงานนำเสนอเป็น PDF ดังนั้น ตัวระบุแบบกำหนดเองที่ตั้งเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้  

**วิธีแก้**: คุณสามารถเก็บตัวระบุแบบกำหนดเองไว้ใน **Alt Text** ของออบเจกต์ (เช่น `shape.setAlternativeText("MyId")`) หลังจากส่งออกเป็น PDF Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากการนำเสนอ สไลด์ หรือรูปทรงในขั้นตอนเดียวได้หรือไม่?**  

ใช่ คอลเลกชันแท็ก ([tag collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/)) รองรับการดำเนินการ [clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/#clear--) ที่ลบคู่คีย์‑ค่าทั้งหมดพร้อมกัน

**ฉันจะลบแท็กเดี่ยวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปคอลเลกชันทั้งหมดได้อย่างไร?**  

ใช้เมธอด [remove(name)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) บนคอลเลกชันแท็กเพื่อทำการลบแท็กโดยใช้คีย์ของมัน

**ฉันจะดึงรายการชื่อแท็กทั้งหมดสำหรับการวิเคราะห์หรือการกรองได้อย่างไร?**  

ใช้เมธอด [getNamesOfTags](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) บนคอลเลกชันแท็ก; มันจะคืนอาเรย์ของชื่อแท็กทั้งหมด

**ฉันจะค้นหาส่วน XML แบบกำหนดเองทั้งหมดโดยไม่คำนึงว่ามันเก็บไว้ที่ใด?**  

ใช้ [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) เพื่อดึงส่วน XML แบบกำหนดเองทั้งหมดในงานนำเสนอ

**ควรใช้ `getXmlAsString`/`setXmlAsString` หรือ `getXmlData`/`setXmlData` เพื่ออัปเดตส่วน XML แบบกำหนดเอง?**  

ใช้ `getXmlAsString` และ `setXmlAsString` เมื่อแอปพลิเคชันทำงานกับข้อความ XML แบบ UTF‑8 ใช้ `getXmlData` และ `setXmlData` เมื่อ XML มีอยู่แล้วในรูปแบบอาเรย์ไบต์หรือเมื่อการประมวลผลแบบไบนารีสะดวกกว่า ทั้งสองวิธีอ้างอิงถึงเนื้อหา XML ของส่วน XML แบบกำหนดเดียวกัน.