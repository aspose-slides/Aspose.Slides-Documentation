---
title: จัดการคุณสมบัติการพรีเซนต์ชันใน Java
linktitle: คุณสมบัติการพรีเซนต์ชัน
type: docs
weight: 70
url: /th/java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการพรีเซนต์ชัน
- คุณสมบัติเอกสาร
- คุณสมบัติในตัว
- คุณสมบัติแบบกำหนดเอง
- คุณสมบัตุล้ำหน้า
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาทาเอกสาร
- แก้ไขเมตาดาทา
- ภาษาตรวจสอบ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- พรีเซนต์ชัน
- Java
- Aspose.Slides
description: "ควบคุมคุณสมบัติการพรีเซนต์ชันใน Aspose.Slides for Java และทำให้การค้นหา การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นระบบระเบียบมากขึ้น."
---
## **บทนำ**

Aspose.Slides รองรับประเภทของคุณสมบัติเอกสารสองประเภท: **Built-in** และ **Custom** ทั้งสองประเภทนี้สามารถเข้าถึงและจัดการได้ง่ายผ่าน Aspose.Slides API

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเอกสารของการพรีเซนต์ชันผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/) อินสแตนซ์ของอินเทอร์เฟซนี้จะถูกคืนค่าจากเมธอด [Presentation.getDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getDocumentProperties--) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไขและจัดการคุณสมบัติเหล่านี้

{{% alert color="info" title="หมายเหตุ" %}}
กรุณาทราบว่า ฟิลด์ **Application** และ **AppVersion** ไม่สามารถแก้ไขได้ Aspose.Slides จะเขียนทับค่าเหล่านี้ทุกครั้งที่บันทึก ดังนั้นการพรีเซนต์ชันที่บันทึกแล้วจึงจะรายงานว่า “Aspose.Slides for Java” พร้อมเวอร์ชันของไลบรารีที่สร้างมัน ค่าใด ๆ ที่ส่งให้ `setNameOfApplication` จะถูกละทิ้งเมื่อเขียนพรีเซนต์ชัน
{{% /alert %}} 

## **คุณสมบัติเอกสารใน PowerPoint**

Microsoft PowerPoint 2007 อนุญาตให้จัดการคุณสมบัติเอกสารของไฟล์พรีเซนต์ชัน เพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 ตามที่แสดงด้านล่าง:

|**เลือกเมนู Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
หลังจากคุณเลือกเมนู **Advanced Properties** จะปรากฏกล่องโต้ตอบที่ให้คุณจัดการคุณสมบัติเอกสารของไฟล์ PowerPoint ตามที่แสดงในรูปด้านล่าง:

|**กล่องโต้ตอบ Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
ใน **กล่องโต้ตอบ Properties** ด้านบน คุณจะเห็นแท็บหลายหน้า เช่น **General**, **Summary**, **Statistics**, **Contents** และ **Custom** แท็บเหล่านี้ทั้งหมดให้คุณกำหนดค่าเนื้อหาต่าง ๆ ที่เกี่ยวกับไฟล์ PowerPoint **Custom** แท็บใช้สำหรับจัดการคุณสมบัติแบบกำหนดเองของไฟล์ PowerPoint

### ทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides for Java

ตามที่อธิบายไปก่อนหน้านี้ Aspose.Slides for Java รองรับคุณสมบัติเอกสารสองประเภท คือ **Built-in** และ **Custom** ดังนั้นนักพัฒนาจึงสามารถเข้าถึงคุณสมบัติทั้งสองประเภทได้ผ่าน Aspose.Slides for Java API Aspose.Slides for Java มีคลาส [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties) ที่แสดงคุณสมบัติเอกสารที่เชื่อมโยงกับไฟล์พรีเซนต์ชันผ่านคุณสมบัติ **Presentation.DocumentProperties**

นักพัฒนาสามารถใช้คุณสมบัติ **IDocumentProperties** ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติเอกสารของไฟล์พรีเซนต์ชันตามที่อธิบายด้านล่าง:

## **เข้าถึง Built-in Properties**

คุณสมบัติเหล่านี้ที่เปิดเผยโดยอ็อบเจ็กต์ [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties) มีรวมถึง: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** และ **Title**

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของพรีเซนต์ชัน
Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงถึงอ็อบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // แสดงคุณสมบัติแบบ Built-in
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **แก้ไข Built-in Properties**

การแก้ไขคุณสมบัติแบบ Built-in ของไฟล์พรีเซนต์ชันง่ายเท่ากับการเข้าถึง คุณสามารถกำหนดค่าเป็นสตริงให้กับคุณสมบัติที่ต้องการและค่าจะถูกแก้ไข ในตัวอย่างด้านล่าง เราได้แสดงวิธีการแก้ไขคุณสมบัติเอกสารแบบ Built-in ของไฟล์พรีเซนต์ชันโดยใช้ Aspose.Slides for Java

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงถึงอ็อบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ตั้งค่าคุณสมบัติแบบ Built-in
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // บันทึกพรีเซนต์ชันของคุณไปยังไฟล์
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติ Built-in ของพรีเซนต์ชันซึ่งสามารถดูผลลัพธ์ได้ตามด้านล่าง:

|**คุณสมบัติเอกสาร Built-in หลังการแก้ไข**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **เพิ่ม Custom Document Properties**

Aspose.Slides for Java ยังอนุญาตให้ผู้พัฒนากำหนดค่า Custom สำหรับคุณสมบัติเอกสารของพรีเซนต์ชัน ตัวอย่างด้านล่างเพิ่มคุณสมบัติแบบกำหนดเองสามรายการ จากนั้นค้นหาชื่อที่เก็บไว้ที่ตำแหน่งดัชนี 2 และลบคุณสมบัตินั้น ทำให้พรีเซนต์ชันที่บันทึกไว้เหลือสองรายการ คุณสมบัติแบบกำหนดเองจะจัดเรียงตามลำดับอักษร ไม่ใช่ตามลำดับที่เพิ่ม

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // รับคุณสมบัติเอกสาร
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // เพิ่มคุณสมบัติแบบกำหนดเอง
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // รับชื่อคุณสมบัติที่ตำแหน่งเฉพาะ
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // ลบคุณสมบัติที่เลือก
    dProps.removeCustomProperty(getPropertyName);
    
    // บันทึกพรีเซนต์ชัน
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Custom Document Properties ที่เพิ่ม**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **เข้าถึงและแก้ไข Custom Properties**

Aspose.Slides for Java ยังอนุญาตให้ผู้พัฒนาถึงค่าของคุณสมบัติแบบกำหนดเอง ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติเหล่านี้ทั้งหมดสำหรับพรีเซนต์ชัน

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงถึงอ็อบเจ็กต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // แสดงชื่อและค่าของคุณสมบัติแบบกำหนดเอง
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // แก้ไขค่าของคุณสมบัติแบบกำหนดเอง
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // บันทึกพรีเซนต์ชันของคุณไปยังไฟล์
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติแบบกำหนดเองของ [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentation รูปต่อไปนี้แสดงคุณสมบัติแบบกำหนดเองก่อนและหลังการแก้ไข:

|**Custom Properties ก่อนการแก้ไข**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Custom Properties หลังการแก้ไข**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced Document Properties**

{{% alert color="info" title="หมายเหตุ" %}}
เมธอดใหม่ [ReadDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), และ [WriteBindedPresentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ได้ถูกเพิ่มเข้าไปใน [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo) โดยลอจิกของตัวตั้งค่า [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ได้ถูกเปลี่ยนแปลง
{{% /alert %}} 

เมธอดใหม่สองตัว [ReadDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) และ [UpdateDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ได้ถูกเพิ่มเข้าไปในอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo) พวกมันให้การเข้าถึงคุณสมบัติเอกสารอย่างรวดเร็วและอนุญาตให้เปลี่ยนแปลงและอัปเดตคุณสมบัติโดยไม่ต้องโหลดพรีเซนต์ชันเต็ม

สถานการณ์ทั่วไปคือโหลดคุณสมบัติ, เปลี่ยนค่าบางอย่างและอัปเดตเอกสาร สามารถทำได้ดังนี้:

```java
import com.aspose.slides.*;

// อ่านข้อมูลของพรีเซนต์ชัน
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// ดึงคุณสมบัติปัจจุบัน
IDocumentProperties props = info.readDocumentProperties();

// ตั้งค่าข้อมูลใหม่ของฟิลด์ Author และ Title
props.setAuthor("New Author");
props.setTitle("New Title");

// อัปเดตพรีเซนต์ชันด้วยค่าใหม่
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

มีวิธีอีกหนึ่งวิธีในการใช้คุณสมบัติของพรีเซนต์ชันหนึ่งเป็นเทมเพลตเพื่ออัปเดตคุณสมบัติในพรีเซนต์ชันอื่น ๆ:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

เทมเพลตใหม่สามารถสร้างจากศูนย์และจากนั้นใช้เพื่ออัปเดตพรีเซนต์ชันหลายไฟล์:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มีคุณสมบัติ LanguageId (เปิดเผยโดยคลาส PortionFormat) เพื่อให้คุณตั้งค่าภาษา proofing สำหรับเอกสาร PowerPoint ภาษา proofing คือภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ด Java นี้แสดงวิธีตั้งค่าภาษา proofing สำหรับ PowerPoint:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // ตั้งค่า Id ของภาษาตรวจสอบ

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าภาษาเริ่มต้น**

โค้ด Java นี้แสดงวิธีตั้งค่าภาษาเริ่มต้นสำหรับพรีเซนต์ชัน PowerPoint ทั้งหมด:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // เพิ่มรูปร่างสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // ตรวจสอบภาษาของส่วนแรก
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตัวอย่างสด**

ลองใช้แอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารผ่าน Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **FAQ**

**ฉันจะลบคุณสมบัติ Built-in ออกจากพรีเซนต์ชันได้อย่างไร?**

คุณสมบัติ Built-in เป็นส่วนหนึ่งของพรีเซนต์ชันและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตามคุณสามารถเปลี่ยนค่า หรือกำหนดเป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**ถ้าฉันเพิ่มคุณสมบัติ Custom ที่มีอยู่แล้วจะเกิดอะไรขึ้น?**

หากคุณเพิ่มคุณสมบัติ Custom ที่มีอยู่แล้ว มูลค่าเดิมจะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือตรวจสอบคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติพรีเซนต์ชันโดยไม่ต้องโหลดพรีเซนต์ชันทั้งหมดได้หรือไม่?**

ได้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) แล้วตามด้วย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่านเมตาเดตาของเอกสารโดยไม่ต้องสร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ดูตัวอย่างการรายงานเต็มใน [Build a Lightweight Presentation Inventory](/slides/th/java/examine-presentation/) และข้อจำกัดตามรูปแบบไฟล์.