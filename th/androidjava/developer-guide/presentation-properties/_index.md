---
title: จัดการคุณสมบัติการนำเสนอบน Android
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/androidjava/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติของเอกสาร
- คุณสมบัติมาตรฐาน
- คุณสมบัติกำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาตรวจสอบ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides สำหรับ Android ผ่าน Java และปรับให้การค้นหา การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นเรื่องง่าย"
---
## **บทนำ**

Aspose.Slides รองรับคุณสมบัติของเอกสารสองประเภท: **Built-in** และ **Custom** ทั้งสองประเภทนี้สามารถเข้าถึงและจัดการได้ง่ายโดยใช้ Aspose.Slides API

Aspose.Slides ช่วยให้คุณทำงานกับคุณสมบัติของเอกสารงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/) ตัวอย่างของอินเทอร์เฟซนี้จะได้รับจากเมธอด [Presentation.getDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไขและจัดการคุณสมบัติเหล่านี้

{{% alert color="info" %}} 

โปรดทราบว่า ฟิลด์ **Application** และ **AppVersion** ไม่สามารถแก้ไขได้ Aspose.Slides จะเขียนทับค่าเหล่านี้ทุกครั้งที่บันทึก ดังนั้นการบันทึกงานนำเสนอจะรายงานชื่อผลิตภัณฑ์ Aspose.Slides และเวอร์ชันของไลบรารีที่สร้างมัน ค่าใด ๆ ที่ส่งให้ `setNameOfApplication` จะถูกละทิ้งเมื่อเขียนงานนำเสนอ

{{% /alert %}} 

## **คุณสมบัติของเอกสารใน PowerPoint**

Microsoft PowerPoint 2007 อนุญาตให้จัดการคุณสมบัติของไฟล์งานนำเสนอ เพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 ดังที่แสดงด้านล่าง:

|**Selecting Advanced Properties menu item**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
เมื่อคุณเลือกเมนู **Advanced Properties** จะปรากฏกล่องโต้ตอบที่ให้คุณจัดการคุณสมบัติของไฟล์ PowerPoint ตามรูปด้านล่าง:

|**Properties Dialog**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
ใน **Properties Dialog** ด้านบน คุณจะเห็นแท็บหลายหน้าเช่น **General**, **Summary**, **Statistics**, **Contents** และ **Custom** แท็บเหล่านี้ใช้กำหนดข้อมูลต่าง ๆ ที่เกี่ยวข้องกับไฟล์ PowerPoint ส่วนแท็บ **Custom** ใช้จัดการคุณสมบัติกำหนดเองของไฟล์ PowerPoint

### ทำงานกับคุณสมบัติของเอกสารโดยใช้ Aspose.Slides for Android via Java

ดังที่ได้อธิบายไว้ก่อนหน้านี้ Aspose.Slides for Android via Java รองรับคุณสมบัติของเอกสารสองประเภทคือ **Built-in** และ **Custom** นักพัฒนาจึงสามารถเข้าถึงคุณสมบัติจำนวนสองประเภทนี้ด้วย API ของ Aspose.Slides for Android via Java Aspose.Slides for Android via Java มีคลาส [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties) ที่แทนคุณสมบัติของเอกสารที่เชื่อมโยงกับไฟล์งานนำเสนอผ่านคุณสมบัติ **Presentation.DocumentProperties**

นักพัฒนาสามารถใช้คุณสมบัติ **IDocumentProperties** ที่เปิดให้บริการโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติของไฟล์งานนำเสนอได้ตามที่อธิบายต่อไปนี้

## **เข้าถึงคุณสมบัติ Built‑in**

คุณสมบัติเหล่านี้ที่เปิดให้บริการโดยอ็อบเจ็กต์ [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties) รวมถึง: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** และ **Title**

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนการนำเสนอ
Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงถึงอ็อบเจกต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // แสดงคุณสมบัติมาตรฐาน
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

## **แก้ไขคุณสมบัติ Built‑in**

การแก้ไขคุณสมบัติ Built‑in ของไฟล์งานนำเสนอทำได้ง่าย ๆ เพียงกำหนดค่าข้อความให้กับคุณสมบัติที่ต้องการ แล้วค่าในคุณสมบัติจะถูกปรับปรุง ในตัวอย่างด้านล่างนี้ เราได้แสดงวิธีการแก้ไขคุณสมบัติเบื้องต้นของไฟล์งานนำเสนอโดยใช้ Aspose.Slides for Android via Java

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงถึงอ็อบเจกต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // กำหนดคุณสมบัติมาตรฐาน
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // บันทึกการนำเสนอของคุณไปยังไฟล์
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติ Built‑in ของงานนำเสนอ ซึ่งจะแสดงผลดังต่อไปนี้:

|**Built-in document properties after modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **เพิ่มคุณสมบัติกำหนดเอง**

Aspose.Slides for Android via Java ยังอนุญาตให้นักพัฒนาเพิ่มค่ากำหนดเองสำหรับคุณสมบัติของงานนำเสนอ ตัวอย่างด้านล่างเพิ่มคุณสมบัติกำหนดเองสามรายการ แล้วค้นหาชื่อที่เก็บไว้ที่ดัชนี 2 และลบคุณสมบัตินั้น ดังนั้นไฟล์งานนำเสนอที่บันทึกไว้จะเหลือสองรายการ คุณสมบัติกำหนดเองจะถูกจัดลำดับตามตัวอักษร ไม่ได้ตามลำดับที่เพิ่ม

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // กำลังดึงคุณสมบัติของเอกสาร
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // กำลังเพิ่มคุณสมบัติกำหนดเอง
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // ดึงชื่อคุณสมบัติที่ตำแหน่งดัชนีเฉพาะ
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // กำลังลบคุณสมบัติที่เลือก
    dProps.removeCustomProperty(getPropertyName);
    
    // กำลังบันทึกการนำเสนอ
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Custom Document Properties Added**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **เข้าถึงและแก้ไขคุณสมบัติกำหนดเอง**

Aspose.Slides for Android via Java ยังอนุญาตให้นักพัฒนาเข้าถึงค่าของคุณสมบัติกำหนดเอง ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติกำหนดเองทั้งหมดของงานนำเสนอ

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงถึงอ็อบเจกต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // เข้าถึงและแก้ไขคุณสมบัติกำหนดเอง
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // แสดงชื่อและค่าของคุณสมบัติกำหนดเอง
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // แก้ไขค่าของคุณสมบัติกำหนดเอง
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // บันทึกการนำเสนอของคุณไปยังไฟล์
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติกำหนดเองของ [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentation ภาพต่อไปนี้แสดงคุณสมบัติกำหนดเองก่อนและหลังการแก้ไข:

|**Custom Properties before Modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Custom Properties after Modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **คุณสมบัติของเอกสารขั้นสูง**

{{% alert color="info" %}} 

เมธอดใหม่ [ReadDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), และ [WriteBindedPresentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ได้ถูกเพิ่มลงใน [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo) การตั้งค่า property setter ของ [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ถูกเปลี่ยนแปลง

{{% /alert %}} 

สองเมธอดใหม่ [ReadDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) และ [UpdateDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ได้ถูกเพิ่มในอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo) พวกมันให้การเข้าถึงคุณสมบัติของเอกสารอย่างรวดเร็วและอนุญาตให้เปลี่ยนแปลงและอัปเดตคุณสมบัติได้โดยไม่ต้องโหลดงานนำเสนอทั้งหมด

สถานการณ์ทั่วไปคือโหลดคุณสมบัติ, แก้ไขค่าแล้วอัปเดตเอกสาร สามารถทำได้ตามตัวอย่างต่อไปนี้:

```java
import com.aspose.slides.*;

// อ่านข้อมูลของการนำเสนอ
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// ดึงคุณสมบัติปัจจุบัน
IDocumentProperties props = info.readDocumentProperties();

// ตั้งค่าข้อมูลใหม่ของฟิลด์ Author และ Title
props.setAuthor("New Author");
props.setTitle("New Title");

// อัปเดตการนำเสนอด้วยค่าที่ใหม่
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

อีกวิธีหนึ่งคือใช้คุณสมบัติของงานนำเสนอหนึ่งเป็นแม่แบบเพื่ออัปเดตคุณสมบัติในงานนำเสนออื่น ๆ:

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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

สามารถสร้างแม่แบบใหม่จากศูนย์แล้วใช้เพื่ออัปเดตหลายงานนำเสนอได้:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มี property LanguageId (เปิดให้บริการโดยคลาส PortionFormat) เพื่อให้คุณตั้งค่าภาษา proofing สำหรับเอกสาร PowerPoint ภาษานี้จะใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ด Java ด้านล่างแสดงวิธีตั้งค่าภาษา proofing สำหรับ PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

โค้ด Java ด้านล่างแสดงวิธีตั้งค่าภาษาเริ่มต้นสำหรับงานนำเสนอ PowerPoint ทั้งหมด:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // เพิ่มรูปทรงสี่เหลี่ยมผืนผ้าใหม่พร้อมข้อความ
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // ตรวจสอบภาษาของส่วนแรก
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตัวอย่างสด**

ลองใช้แอป [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) ออนไลน์เพื่อดูวิธีทำงานกับคุณสมบัติของเอกสารผ่าน Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## ***FAQ**

### ฉันจะลบคุณสมบัติ Built‑in จากงานนำเสนอได้อย่างไร?

คุณสมบัติ Built‑in เป็นส่วนสำคัญของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตามคุณสามารถเปลี่ยนค่าของมันหรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

### จะเกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว?

หากคุณเพิ่มคุณสมบัติกำหนดเองที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าโดยอัตโนมัติ

### ฉันสามารถเข้าถึงคุณสมบัติของงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบได้หรือไม่?

ได้ คุณสามารถเข้าถึงคุณสมบัติของงานนำเสนอโดยไม่ต้องโหลดเต็มรูปแบบโดยใช้เมธอด `getPresentationInfo` จากคลาส [PresentationFactory](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/) จากนั้นใช้เมธอด `readDocumentProperties` ของอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/) เพื่ออ่านคุณสมบัติอย่างมีประสิทธิภาพ ลดการใช้หน่วยความจำและเพิ่มประสิทธิภาพ.