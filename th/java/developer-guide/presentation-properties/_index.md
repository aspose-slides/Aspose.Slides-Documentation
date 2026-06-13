---
title: จัดการคุณสมบัติการนำเสนอใน Java
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติมาตรฐาน
- คุณสมบัติแบบกำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาตรวจสอบ
- ภาษาตั้งค่าเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เชี่ยวชาญการจัดการคุณสมบัติการนำเสนอใน Aspose.Slides สำหรับ Java และทำให้การค้นหา, การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นไปอย่างราบรื่น."
---
## **บทนำ**

Aspose.Slides รองรับคุณสมบัติของเอกสารสองประเภท: **Built-in** และ **Custom**. ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ Aspose.Slides API.

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติเอกสารของงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/) . อินสแตนซ์ของอินเทอร์เฟซนี้จะถูกส่งกลับโดยเมธอด [Presentation.getDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getDocumentProperties--) . ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข และจัดการคุณสมบัติเหล่านี้.

{{% alert color="primary" %}} 
โปรดทราบว่า ฟิลด์ **Application** และ **Producer** ไม่สามารถแก้ไขได้ เพราะฟิลด์เหล่านี้จะแสดงเสมอว่า "Aspose Ltd." และ "Aspose.Slides for Java x.x.x".
{{% /alert %}} 

## **คุณสมบัติเอกสารใน PowerPoint**

Microsoft PowerPoint 2007 อนุญาตให้จัดการคุณสมบัติเอกสารของไฟล์งานนำเสนอ เพียงคลิกที่ไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 ตามที่แสดงด้านล่าง:

|**เลือกเมนู Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

หลังจากคุณเลือกเมนู **Advanced Properties** กล่องโต้ตอบจะปรากฏขึ้นเพื่อให้คุณจัดการคุณสมบัติเอกสารของไฟล์ PowerPoint ตามที่แสดงในรูปต่อไปนี้:

|**กล่องโต้ตอบ Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

ใน **กล่องโต้ตอบ Properties** ด้านบน คุณจะเห็นว่า มีแท็บหลายหน้าเช่น **General**, **Summary**, **Statistics**, **Contents** และ **Custom**. ทั้งหมดนี้ช่วยกำหนดค่าข้อมูลต่าง ๆ ที่เกี่ยวกับไฟล์ PowerPoint. แท็บ **Custom** ใช้จัดการคุณสมบัติ custom ของไฟล์ PowerPoint.

ทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides for Java

อย่างที่ได้อธิบายไว้ก่อนหน้านี้ Aspose.Slides for Java รองรับคุณสมบัติเอกสารสองประเภทคือ **Built-in** และ **Custom**. ดังนั้นนักพัฒนาสามารถเข้าถึงคุณสมบัติทั้งสองประเภทได้ด้วย API ของ Aspose.Slides for Java. Aspose.Slides for Java มีคลาส [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties) ที่แสดงคุณสมบัติเอกสารที่เชื่อมโยงกับไฟล์งานนำเสนอผ่านพร็อพเพอร์ตี้ **Presentation.DocumentProperties**.

นักพัฒนาสามารถใช้พร็อพเพอร์ตี้ **IDocumentProperties** ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติเอกสารของไฟล์งานนำเสนอได้ตามที่อธิบายด้านล่าง:

## **เข้าถึงคุณสมบัติ Built-in**

คุณสมบัติเหล่านี้ที่เปิดเผยโดยอ็อบเจ็กต์ [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties) ประกอบด้วย: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** และ **Title**

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของการนำเสนอ
Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงไปยังอ็อบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
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

การแก้ไขคุณสมบัติ Built-in ของไฟล์งานนำเสนอทำได้ง่ายเหมือนการเข้าถึงมัน คุณเพียงกำหนดค่าเป็นสตริงให้กับคุณสมบัติใดก็ได้ที่ต้องการและค่าจะถูกแก้ไข ในตัวอย่างด้านล่าง เราได้สาธิตวิธีการแก้ไขคุณสมบัติเอกสาร Built-in ของไฟล์งานนำเสนอโดยใช้ Aspose.Slides for Java

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงไปยังอ็อบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ตั้งค่าคุณสมบัติ Built-in
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // บันทึกการนำเสนอของคุณลงไฟล์
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติ Built-in ของงานนำเสนอซึ่งสามารถดูได้ตามด้านล่าง:

|**คุณสมบัติเอกสาร Built-in หลังการแก้ไข**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **เพิ่มคุณสมบัติเอกสาร Custom**

Aspose.Slides for Java ยังอนุญาตให้ผู้พัฒนาสามารถเพิ่มค่าที่กำหนดเองสำหรับคุณสมบัติเอกสารของงานนำเสนอได้ ตัวอย่างด้านล่างแสดงวิธีตั้งค่าคุณสมบัติ custom สำหรับงานนำเสนอ

```java
Presentation pres = new Presentation();
try {
    // รับคุณสมบัติเอกสาร
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // เพิ่มคุณสมบัติแบบกำหนดเอง
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // รับชื่อคุณสมบัติที่ตำแหน่งดัชนีเฉพาะ
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // ลบคุณสมบัติที่เลือก
    dProps.removeCustomProperty(getPropertyName);
    
    // บันทึกการนำเสนอ
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**เพิ่มคุณสมบัติเอกสาร Custom**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **เข้าถึงและแก้ไขคุณสมบัติ Custom**

Aspose.Slides for Java ยังอนุญาตให้ผู้พัฒนาสามารถเข้าถึงค่าของคุณสมบัติ custom ได้ ตัวอย่างด้านล่างแสดงวิธีที่คุณสามารถเข้าถึงและแก้ไขคุณสมบัติ custom ทั้งหมดของงานนำเสนอ

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงไปยังอ็อบเจ็กต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // แสดงชื่อและค่าของคุณสมบัติแบบกำหนดเอง
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // แก้ไขค่าของคุณสมบัติแบบกำหนดเอง
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // บันทึกการนำเสนอของคุณลงไฟล์
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติ custom ของ [PPTX](https://docs.fileformat.com/presentation/pptx/) งานนำเสนอ รูปต่อไปนี้แสดงคุณสมบัติ custom ของงานนำหน้าก่อนและหลังการแก้ไข:

|**คุณสมบัติ Custom ก่อนการแก้ไข**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**คุณสมบัติ Custom หลังการแก้ไข**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **คุณสมบัติเอกสารขั้นสูง**

{{% alert color="primary" %}} 
เมธอดใหม่ [ReadDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), และ [WriteBindedPresentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ได้รับการเพิ่มเข้าไปใน [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo) และตรรกะของเซตเตอร์ [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ถูกเปลี่ยนแปลง
{{% /alert %}} 

เมธอดใหม่สองตัว [ReadDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) และ [UpdateDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ได้รับการเพิ่มเข้าไปในอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo) พวกมันให้การเข้าถึงคุณสมบัติเอกสารอย่างรวดเร็วและอนุญาตให้เปลี่ยนแปลงและอัปเดตคุณสมบัติโดยไม่ต้องโหลดงานนำเสนอทั้งหมด

สถานการณ์ทั่วไปคือโหลดคุณสมบัติ, เปลี่ยนค่าบางอย่างและอัปเดตเอกสารสามารถทำได้ตามวิธีต่อไปนี้:

```java
// อ่านข้อมูลของการนำเสนอ
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// รับคุณสมบัติปัจจุบัน
IDocumentProperties props = info.readDocumentProperties();

// ตั้งค่าข้อมูลใหม่ของฟิลด์ Author และ Title
props.setAuthor("New Author");
props.setTitle("New Title");

// อัปเดตการนำเสนอด้วยค่าที่ใหม่
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

มีอีกวิธีหนึ่งคือนำคุณสมบัติของงานนำเสนอเฉพาะหนึ่งไปใช้เป็นเทมเพลตเพื่ออัปเดตคุณสมบัติในงานนำเสนออื่น ๆ:

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

เทมเพลตใหม่สามารถสร้างจากศูนย์และนำไปใช้เพื่ออัปเดตหลายงานนำเสนอได้:

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

Aspose.Slides มีพร็อพเพอร์ตี้ LanguageId (เผยโดยคลาส PortionFormat) เพื่อให้คุณตั้งค่าภาษา proofing สำหรับเอกสาร PowerPoint ภาษา proofing คือภาษาที่จะตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ด Java นี้จะแสดงวิธีตั้งค่าภาษา proofing สำหรับ PowerPoint: xxx ทำไม LanguageId ถึงไม่มีอยู่ในคลาส Java PortionFormat?

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

โค้ด Java นี้จะแสดงวิธีตั้งค่าภาษาเริ่มต้นสำหรับงานนำเสนอ PowerPoint ทั้งหมด:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // เพิ่มรูปสี่เหลี่ยมใหม่พร้อมข้อความ
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // ตรวจสอบภาษาของ portion แรก
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตัวอย่างสด**

ลองใช้แอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารผ่าน Aspose.Slides API:

[![ดูและแก้ไขเมทาดาต้า PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## ***คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ Built-in ออกจากงานนำเสนอได้อย่างไร?**

คุณสมบัติ Built-in เป็นส่วนหนึ่งของงานนำเสนอที่ไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตามคุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาตให้ทำเช่นนั้น

**เกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เพราะ Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติของงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอทั้งหมดหรือไม่?**

ได้ คุณสามารถเข้าถึงคุณสมบัติของงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอทั้งหมดโดยใช้เมธอด `getPresentationInfo` จากคลาส [PresentationFactory](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/) แล้วใช้เมธอด `readDocumentProperties` ของอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/) เพื่ออ่านคุณสมบัติอย่างมีประสิทธิภาพ ลดการใช้หน่วยความจำและเพิ่มประสิทธิภาพ.