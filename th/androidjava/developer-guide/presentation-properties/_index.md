---
title: "จัดการคุณสมบัติงานนำเสนอบน Android"
linktitle: "คุณสมบัติงานนำเสนอ"
type: docs
weight: 70
url: /th/androidjava/presentation-properties/
keywords:
- "คุณสมบัติ PowerPoint"
- "คุณสมบัติงานนำเสนอ"
- "คุณสมบัติเอกสาร"
- "คุณสมบัติมาตรฐาน"
- "คุณสมบัติกำหนดเอง"
- "คุณสมบัติเบื้องลึก"
- "จัดการคุณสมบัติ"
- "แก้ไขคุณสมบัติ"
- "เมตาดาต้าเอกสาร"
- "แก้ไขเมตาดาต้า"
- "ภาษาตรวจสอบ"
- "ภาษาเริ่มต้น"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "Android"
- "Java"
- "Aspose.Slides"
description: "ควบคุมคุณสมบัติงานนำเสนอใน Aspose.Slides สำหรับ Android ผ่าน Java อย่างเชี่ยวชาญและทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นเรื่องง่าย"
---
## **บทนำ**

Aspose.Slides รองรับคุณสมบัติเสมือนเอกสารสองประเภท: **Built-in** และ **Custom**. ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ Aspose.Slides API.

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติเอกสารของงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/) อินเทอร์เฟซนี้จะถูกคืนค่าจากเมธอด [Presentation.getDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) ตัวอย่างต่อไปนี้จะแสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้.

{{% alert color="primary" %}} 
โปรดทราบว่า ฟิลด์ **Application** และ **Producer** ไม่สามารถแก้ไขได้ เนื่องจากฟิลด์เหล่านี้จะแสดงเสมอว่า "Aspose Ltd." และ "Aspose.Slides for Android via Java x.x.x".
{{% /alert %}} 

## **คุณสมบัติเอกสารใน PowerPoint**

Microsoft PowerPoint 2007 ช่วยให้จัดการคุณสมบัติเอกสารของไฟล์งานนำเสนอได้ เพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 ตามที่แสดงด้านล่าง:

|**เลือกเมนู Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

หลังจากที่คุณเลือกเมนู **Advanced Properties** จะปรากฏกล่องโต้ตอบที่ให้คุณจัดการคุณสมบัติเอกสารของไฟล์ PowerPoint ตามที่แสดงในรูปด้านล่าง:

|**กล่องโต้ตอบคุณสมบัติ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

ใน **Properties Dialog** ด้านบน คุณจะเห็นว่ามีแท็บหลายหน้าเช่น **General**, **Summary**, **Statistics**, **Contents** และ **Custom** แท็บเหล่านี้ช่วยให้กำหนดค่าข้อมูลประเภทต่าง ๆ ที่เกี่ยวข้องกับไฟล์ PowerPoint ได้ แท็บ **Custom** ใช้สำหรับจัดการคุณสมบัติแบบกำหนดเองของไฟล์ PowerPoint.

การทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides for Android via Java

ตามที่เราอธิบายไว้ก่อนหน้านี้ว่า Aspose.Slides for Android via Java รองรับคุณสมบัติเอกสารสองประเภท คือคุณสมบัติ **Built-in** และ **Custom** ดังนั้นนักพัฒนาจึงสามารถเข้าถึงคุณสมบัติเบอร์สองประเภทได้โดยใช้ Aspose.Slides for Android via Java API Aspose.Slides for Android via Java มีคลาส [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties) ที่แสดงคุณสมบัติเอกสารที่เชื่อมโยงกับไฟล์งานนำเสนอผ่านคุณสมบัติ **Presentation.DocumentProperties**.

นักพัฒนาสามารถใช้คุณสมบัติ **IDocumentProperties** ที่เปิดโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติเอกสารของไฟล์งานนำเสนอได้ตามที่อธิบายในต่อไปนี้:

## **เข้าถึงคุณสมบัติ Built-in**

คุณสมบัติเหล่านี้ที่เปิดโดยอ็อบเจกต์ [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties) ประกอบด้วย: **Creator** (ผู้เขียน), **Description**, **Keywords**, **Created** (วันที่สร้าง), **Modified** (วันที่แก้ไข), **Printed** (วันที่พิมพ์ล่าสุด), **LastModifiedBy**, **Keywords**, **SharedDoc** (แชร์ระหว่างผู้ผลิตต่าง ๆ?), **PresentationFormat**, **Subject** และ **Title**

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของงานนำเสนอ
Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงไปยังอ็อบเจกต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // แสดงคุณสมบัติ Built-in
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

## **แก้ไขคุณสมบัติ Built-in**

การแก้ไขคุณสมบัติ Built-in ของไฟล์งานนำเสนอทำได้ง่ายเท่ากับการเข้าถึง เพียงกำหนดค่าแบบสตริงให้กับคุณสมบัติที่ต้องการแล้วค่าจะถูกแก้ไข ในตัวอย่างด้านล่าง เราได้สาธิตวิธีการแก้ไขคุณสมบัติเบอร์ของไฟล์งานนำเสนอโดยใช้ Aspose.Slides for Android via Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงไปยังอ็อบเจกต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ตั้งค่าคุณสมบัติ Built-in
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // บันทึกงานนำเสนอของคุณไปยังไฟล์
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้จะแก้ไขคุณสมบัติ Built-in ของงานนำเสนอ ซึ่งสามารถดูได้ตามด้านล่าง:

|**คุณสมบัติเอกสาร Built-in หลังจากการแก้ไข**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **เพิ่มคุณสมบัติเอกสารแบบกำหนดเอง**

Aspose.Slides for Android via Java ยังอนุญาตให้นักพัฒนาสามารถเพิ่มค่าแบบกำหนดเองสำหรับคุณสมบัติเอกสารของงานนำเสนอ ตัวอย่างด้านล่างจะแสดงวิธีการตั้งค่าคุณสมบัติแบบกำหนดเองสำหรับงานนำเสนอ

```java
Presentation pres = new Presentation();
try {
    // รับคุณสมบัติเอกสาร
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // เพิ่มคุณสมบัติกำหนดเอง
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // รับชื่อคุณสมบัติที่ตำแหน่งเฉพาะ
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // ลบคุณสมบัติที่เลือก
    dProps.removeCustomProperty(getPropertyName);
    
    // บันทึกงานนำเสนอ
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**เพิ่มคุณสมบัติเอกสารแบบกำหนดเอง**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง**

Aspose.Slides for Android via Java ยังอนุญาตให้นักพัฒนาสามารถเข้าถึงค่าของคุณสมบัติแบบกำหนดเองได้ ตัวอย่างด้านล่างจะแสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเองทั้งหมดสำหรับงานนำเสนอ

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงไปยังอ็อบเจกต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // เข้าถึงและแก้ไขคุณสมบัติกำหนดเอง
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // แสดงชื่อและค่า ของคุณสมบัติกำหนดเอง
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // แก้ไขค่าของคุณสมบัติกำหนดเอง
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // บันทึกงานนำเสนอของคุณไปยังไฟล์
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติแบบกำหนดเองของงานนำเสนอ [PPTX ](https://docs.fileformat.com/presentation/pptx/) รูปต่อไปนี้แสดงคุณสมบัติแบบกำหนดเองของงานนำหน้า​ก่อนและหลังการแก้ไข:

|**คุณสมบัติแบบกำหนดเองก่อนการแก้ไข**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**คุณสมบัติแบบกำหนดเองหลังการแก้ไข**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **คุณสมบัติเบื้องลึกของเอกสาร**

{{% alert color="primary" %}} 
มีเมธอดใหม่ [ReadDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), และ [WriteBindedPresentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ได้ถูกเพิ่มเข้ามาใน [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo), โดยตรรกะของตัวตั้งค่า property [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ได้รับการเปลี่ยนแปลง.
{{% /alert %}} 

เมธอดใหม่สองตัว [ReadDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) และ [UpdateDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ได้ถูกเพิ่มเข้ามาในอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo) พวกมันให้การเข้าถึงคุณสมบัติเอกสารอย่างรวดเร็วและอนุญาตให้เปลี่ยนแปลงและอัปเดตคุณสมบัติได้โดยไม่ต้องโหลดงานนำเสนอทั้งหมด

สถานการณ์ทั่วไปคือโหลดคุณสมบัติ, เปลี่ยนค่าบางส่วนและอัปเดตเอกสาร สามารถทำได้ตามวิธีต่อไปนี้:

```java
// อ่านข้อมูลของงานนำเสนอ
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// ดึงคุณสมบัติปัจจุบัน
IDocumentProperties props = info.readDocumentProperties();

// ตั้งค่าใหม่ให้ช่องผู้เขียนและหัวข้อ
props.setAuthor("New Author");
props.setTitle("New Title");

// อัปเดตงานนำเสนอด้วยค่าที่ใหม่
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

อีกวิธีหนึ่งคือใช้คุณสมบัติของงานนำเสนอเฉพาะหนึ่งเป็นแม่แบบเพื่ออัปเดตคุณสมบัติในงานนำเสนออื่น ๆ:

```java
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
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

สามารถสร้างแม่แบบใหม่จากศูนย์แล้วใช้เพื่ออัปเดตหลายงานนำเสนอได้:

```java
DocumentProperties template = new DocumentProperties();\

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
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มีคุณสมบัติ LanguageId (เปิดโดยคลาส PortionFormat) เพื่อให้คุณตั้งค่าภาษา proofing สำหรับเอกสาร PowerPoint ภาษา proofing คือภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint. โค้ด Java นี้แสดงวิธีตั้งค่าภาษา proofing สำหรับ PowerPoint: xxx ทำไม LanguageId ถึงไม่มีในคลาส PortionFormat ของ Java?

```java
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

โค้ด Java นี้แสดงวิธีตั้งค่าภาษาเริ่มต้นสำหรับงานนำเสนอ PowerPoint ทั้งหมด:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // เพิ่มรูปทรงสี่เหลี่ยมใหม่พร้อมข้อความ
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

[![ดูและแก้ไขเมตาดาต้า PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## ***คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ Built-in ออกจากงานนำเสนอได้อย่างไร?**

คุณสมบัติ Built-in เป็นส่วนสำคัญของงานนำเสนอและไม่สามารถลบออกได้อย่างสมบูรณ์ อย่างไรก็ตาม คุณสามารถเปลี่ยนค่าเหล่านั้นหรือกำหนดค่าเป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**เกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติแบบกำหนดเองที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติแบบกำหนดเองที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบหรือไม่?**

ได้ คุณสามารถเข้าถึงคุณสมบัติงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอทั้งหมดได้โดยใช้เมธอด `getPresentationInfo` จากคลาส [PresentationFactory](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/) จากนั้นใช้เมธอด `readDocumentProperties` ที่มาจากอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/) เพื่ออ่านคุณสมบัติอย่างมีประสิทธิภาพ ช่วยประหยัดหน่วยความจำและปรับปรุงประสิทธิภาพ