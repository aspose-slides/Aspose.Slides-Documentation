---
title: "จัดการคุณสมบัติการนำเสนอใน JavaScript"
linktitle: "คุณสมบัติการนำเสนอ"
type: docs
weight: 70
url: /th/nodejs-java/presentation-properties/
keywords:
- คุณสมบัติโปรแกรม PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติเบื้องต้น
- คุณสมบัติแบบกำหนดล่วงหน้า
- คุณสมบัติแบบกำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาทาเอกสาร
- แก้ไขเมตาดาทา
- ภาษาการตรวจสอบ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides for Node.js via Java อย่างเต็มที่และทำให้การค้นหา แบรนด์ดิ้ง และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นไปอย่างราบรื่น"
---
## **บทนำ**

Aspose.Slides รองรับประเภทของคุณสมบัติเอกสารสองชนิด: **Built-in** และ **Custom**. ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ Aspose.Slides API.

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติโดกุเมนต์ของการนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/) คลาสนี้จะคืนค่าอินสแตนซ์โดยเมธอด [Presentation.getDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getDocumentProperties) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน แก้ไข และจัดการคุณสมบัติเหล่านี้

{{% alert color="primary" %}} 
โปรดทราบว่าคุณไม่สามารถตั้งค่าต่าง ๆ ให้กับฟิลด์ **Application** และ **Producer** ได้ เนื่องจาก Aspose Ltd. และ Aspose.Slides for Node.js via Java x.x.x จะถูกแสดงในฟิลด์เหล่านี้
{{% /alert %}} 

## **จัดการคุณสมบัติการนำเสนอ**

Microsoft PowerPoint มีฟีเจอร์ในการเพิ่มคุณสมบัติบางอย่างลงในไฟล์การนำเสนอ คุณสมบัติเอกสารเหล่านี้ทำให้สามารถจัดเก็บข้อมูลที่เป็นประโยชน์พร้อมกับเอกสาร (ไฟล์การนำเสนอ) มีคุณสมบัติเอกสารสองประเภทดังต่อไปนี้

- คุณสมบัติที่กำหนดโดยระบบ (Built-in)
- คุณสมบัติที่กำหนดโดยผู้ใช้ (Custom)

คุณสมบัติ **Built-in** มีข้อมูลทั่วไปเกี่ยวกับเอกสาร เช่น ชื่อเอกสาร, ชื่อผู้เขียน, สถิติเอกสาร เป็นต้น คุณสมบัติ **Custom** คือคุณสมบัติที่ผู้ใช้กำหนดเป็นคู่ **Name/Value** โดยที่ชื่อและค่าแต่ละคู่กำหนดโดยผู้ใช้ ใช้ Aspose.Slides for Node.js via Java นักพัฒนาสามารถเข้าถึงและแก้ไขค่าของคุณสมบัติ built-in รวมถึง custom ได้

## **คุณสมบัติเอกสารใน PowerPoint**

Microsoft PowerPoint 2007 อนุญาตให้จัดการคุณสมบัติเอกสารของไฟล์การนำเสนอ ทั้งหมดที่คุณต้องทำคือคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 ตามภาพด้านล่าง:

|**เลือกเมนู Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

หลังจากคุณเลือกเมนู **Advanced Properties** หน้าต่างจะปรากฏขึ้นเพื่อให้คุณจัดการคุณสมบัติเอกสารของไฟล์ PowerPoint ตามรูปด้านล่าง:

|**กล่องโต้ตอบ Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

ใน **กล่องโต้ตอบ Properties** ข้างต้น คุณจะเห็นว่ามีหน้าแท็บหลายหน้าเช่น **General**, **Summary**, **Statistics**, **Contents** และ **Custom** ทั้งหมดนี้ใช้กำหนดค่าข้อมูลต่าง ๆ ที่เกี่ยวกับไฟล์ PowerPoint แท็บ **Custom** ใช้จัดการคุณสมบัติ custom ของไฟล์ PowerPoint

ทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides for Node.js via Java

ตามที่เราได้อธิบายก่อนหน้านี้ว่า Aspose.Slides for Node.js via Java รองรับคุณสมบัติเอกสารสองประเภท คือ **Built-in** และ **Custom** ดังนั้นนักพัฒนาสามารถเข้าถึงคุณสมบัติกิจต่างได้โดยใช้ API ของ Aspose.Slides for Node.js via Java Aspose.Slides for Node.js via Java มีคลาส [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties) ที่แสดงถึงคุณสมบัติเอกสารที่เชื่อมโยงกับไฟล์การนำเสนอผ่านคุณสมบัติ **Presentation.DocumentProperties**.

นักพัฒนาสามารถใช้คุณสมบัติ **DocumentProperties** ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติเอกสารของไฟล์การนำเสนอได้ตามที่อธิบายด้านล่าง:

## **เข้าถึงคุณสมบัติ Built-in**

คุณสมบัติเหล่านี้ที่เปิดเผยโดยอ็อบเจกต์ [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties) รวมถึง: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** และ **Title**

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนการนำเสนอ
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงถึงอ็อบเจกต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    var dp = pres.getDocumentProperties();
    // แสดงคุณสมบัติ built-in
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **แก้ไขคุณสมบัติ Built-in**

การแก้ไขคุณสมบัติ built-in ของไฟล์การนำเสนอทำได้ง่ายเพียงเท่ากับการเข้าถึง เพียงกำหนดค่าข้อความให้กับคุณสมบัติตามที่ต้องการแล้วค่าจะถูกแก้ไข ตัวอย่างด้านล่างแสดงวิธีการแก้ไขคุณสมบัติเอกสาร built-in ของไฟล์การนำเสนอโดยใช้ Aspose.Slides for Node.js via Java

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงถึงอ็อบเจกต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    var dp = pres.getDocumentProperties();
    // ตั้งค่าคุณสมบัติ built-in
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // บันทึกการนำเสนอของคุณลงไฟล์
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติ built-in ของการนำเสนอที่สามารถดูได้ตามด้านล่าง:

|**คุณสมบัติเอกสาร Built-in หลังการแก้ไข**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **เพิ่มคุณสมบัติเอกสาร Custom**

Aspose.Slides for Node.js via Java ยังอนุญาตให้ผู้พัฒนาสร้างค่า custom สำหรับคุณสมบัติเอกสารของการนำเสนอ ตัวอย่างด้านล่างแสดงวิธีตั้งค่าคุณสมบัติ custom สำหรับการนำเสนอ

```javascript
var pres = new aspose.slides.Presentation();
try {
    // กำลังดึงคุณสมบัติเอกสาร
    var dProps = pres.getDocumentProperties();
    // กำลังเพิ่มคุณสมบัติแบบกำหนดเอง
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // กำลังดึงชื่อคุณสมบัติที่ตำแหน่งเฉพาะ
    var getPropertyName = dProps.getCustomPropertyName(2);
    // กำลังลบคุณสมบัติที่เลือก
    dProps.removeCustomProperty(getPropertyName);
    // กำลังบันทึกการนำเสนอ
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**คุณสมบัติเอกสาร Custom ที่เพิ่มแล้ว**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **เข้าถึงและแก้ไขคุณสมบัติ Custom**

Aspose.Slides for Node.js via Java ยังอนุญาตให้ผู้พัฒนาสามารถเข้าถึงค่า custom ได้ ตัวอย่างด้านล่างแสดงวิธีเข้าถึงและแก้ไขคุณสมบัติ custom ทั้งหมดของการนำเสนอ

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // สร้างการอ้างอิงถึงอ็อบเจกต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    var dp = pres.getDocumentProperties();
    // เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // แสดงชื่อและค่าของคุณสมบัติแบบกำหนดเอง
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // แก้ไขค่าของคุณสมบัติแบบกำหนดเอง
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // บันทึกการนำเสนอของคุณลงไฟล์
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติ custom ของ [PPTX ](https://docs.fileformat.com/presentation/pptx/)การนำเสนอ รูปต่อไปนี้แสดงคุณสมบัติ custom ก่อนและหลังการแก้ไข:

|**คุณสมบัติ Custom ก่อนการปรับแก้**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**คุณสมบัติ Custom หลังการปรับแก้**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **คุณสมบัติเอกสารขั้นสูง**

{{% alert color="primary" %}} 
เมธอดใหม่ [ReadDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), และ [WriteBindedPresentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) ได้ถูกเพิ่มไปยังคลาส [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo) ส่วนการตั้งค่าคุณสมบัติ [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) ได้ถูกเปลี่ยนแปลง
{{% /alert %}} 

เมธอดใหม่สองตัว [ReadDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) และ [UpdateDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) ได้ถูกเพิ่มไปยังคลาส [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo) พวกมันให้การเข้าถึงคุณสมบัติเอกสารอย่างรวดเร็วและอนุญาตให้เปลี่ยนแปลงและอัปเดตคุณสมบัติได้โดยไม่ต้องโหลดการนำเสนอทั้งหมด

สถานการณ์ทั่วไปคือโหลดคุณสมบัติ, เปลี่ยนค่าบางอย่างและอัปเดตเอกสาร สามารถทำได้ตามตัวอย่างต่อไปนี้:

```javascript
// อ่านข้อมูลของการนำเสนอ
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
var props = info.readDocumentProperties();
props.setAuthor("New Author");
props.setTitle("New Title");
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

อีกวิธีหนึ่งคือใช้คุณสมบัติของการนำเสนอหนึ่งเป็นแม่แบบเพื่ออัปเดตคุณสมบัติในการนำเสนออื่น ๆ:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
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

```javascript
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

สามารถสร้างแม่แบบใหม่จากศูนย์แล้วใช้เพื่ออัปเดตหลายการนำเสนอได้:

```javascript
var template = new aspose.slides.DocumentProperties();
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

```javascript
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มีคุณสมบัติ LanguageId (เปิดเผยโดยคลาส PortionFormat) เพื่อให้คุณตั้งค่าภาษา proofing สำหรับเอกสาร PowerPoint ภาษา proofing คือภาษาที่จะตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ด JavaScript นี้แสดงวิธีตั้งค่าภาษา proofing สำหรับ PowerPoint: xxx ทำไม LanguageId ถึงหายไปจากคลาส PortionFormat ของ JavaScript?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าภาษาเริ่มต้น**

โค้ด JavaScript นี้แสดงวิธีตั้งค่าภาษาเริ่มต้นสำหรับการนำเสนอ PowerPoint ทั้งหมด:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // เพิ่มรูปสี่เหลี่ยมใหม่พร้อมข้อความ
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // ตรวจสอบภาษาของส่วนแรก
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตัวอย่างสด**

ลองใช้แอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเบื้องต้นผ่าน Aspose.Slides API:

[![ดูและแก้ไขเมตาดาทา PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## ***คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built-in จากการนำเสนอได้อย่างไร?**

คุณสมบัติ built-in เป็นส่วนสำคัญของการนำเสนอและไม่สามารถลบออกได้โดยสมบูรณ์ อย่างไรก็ตามคุณสามารถเปลี่ยนค่าของมันหรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**จะเกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อนหน้า Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดการนำเสนอทั้งหมดได้หรือไม่?**

ได้ คุณสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดการนำเสนอทั้งหมดโดยใช้เมธอด `getPresentationInfo` จากคลาส [PresentationFactory](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/) จากนั้นใช้เมธอด `readDocumentProperties` ของคลาส [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/) เพื่ออ่านคุณสมบัติอย่างมีประสิทธิภาพ ช่วยประหยัดหน่วยความจำและเพิ่มประสิทธิภาพ.