---
title: จัดการคุณสมบัติการนำเสนอใน JavaScript
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/nodejs-java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติเบรนด์
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติเพิ่มเติม
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมทาดาทาเอกสาร
- แก้ไขเมทาดาทา
- ภาษาการตรวจสอบ
- ภาษาเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides สำหรับ Node.js ผ่าน Java และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นไปอย่างราบรื่น"
---
## **บทนำ**

Aspose.Slides รองรับคุณสมบัติของเอกสารสองประเภท: **Built-in** และ **Custom**. ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ Aspose.Slides API.

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเบรนด์ของการนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties/) . ตัวอย่างของคลาสนี้จะถูกคืนค่าจากเมธอด [Presentation.getDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" title="Note" %}}
โปรดทราบว่า ฟิลด์ **Application** และ **AppVersion** ไม่สามารถแก้ไขได้ Aspose.Slides จะเขียนทับฟิลด์เหล่านี้ทุกครั้งที่บันทึก ดังนั้นการนำเสนอที่บันทึกแล้วจะรายงานว่า "Aspose.Slides for Node.js via Java" และเวอร์ชันของไลบรารีที่สร้างมัน ค่าใด ๆ ที่ส่งให้ `setNameOfApplication` จะถูกละทิ้งเมื่อบันทึกการนำเสนอ.
{{% /alert %}} 

## **จัดการคุณสมบัติการนำเสนอ**

Microsoft PowerPoint มีฟีเจอร์ให้เพิ่มคุณสมบัติบางอย่างลงในไฟล์การนำเสนอ คุณสมบัติเบรนด์เหล่านี้ช่วยให้ข้อมูลที่เป็นประโยชน์สามารถเก็บร่วมกับเอกสาร (ไฟล์การนำเสนอ) ได้ มีสองประเภทของคุณสมบัติเบรนด์ดังต่อไปนี้

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** properties มีข้อมูลทั่วไปเกี่ยวกับเอกสาร เช่น ชื่อเอกสาร, ชื่อผู้เขียน, สถิติของเอกสาร ฯลฯ **Custom** properties คือคุณสมบัติที่ผู้ใช้กำหนดเป็นคู่ **Name/Value** โดยผู้ใช้ระบุทั้งชื่อและค่าเอง โดยใช้ Aspose.Slides for Node.js via Java นักพัฒนาสามารถเข้าถึงและแก้ไขค่าของคุณสมบัติเบรนด์และคุณสมบัติที่กำหนดเองได้

## **คุณสมบัติของเอกสารใน PowerPoint**

Microsoft PowerPoint 2007 รองรับการจัดการคุณสมบัติของไฟล์การนำเสนอ เพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ดังที่แสดงด้านล่าง:

|**เลือกเมนู Advanced Properties**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)||

หลังจากเลือกเมนู **Advanced Properties** จะปรากฏกล่องโต้ตอบที่ให้คุณจัดการคุณสมบัติของไฟล์ PowerPoint ตามภาพด้านล่าง:

|**กล่องโต้ตอบ Properties**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)||

ใน **กล่องโต้ตอบ Properties** จะเห็นหลายแท็บเช่น **General**, **Summary**, **Statistics**, **Contents** และ **Custom** แท็บเหล่านี้ให้คุณกำหนดข้อมูลประเภทต่าง ๆ ของไฟล์ PowerPoint ส่วนแท็บ **Custom** ใช้สำหรับจัดการคุณสมบัติที่กำหนดเองของไฟล์ PowerPoint

### การทำงานกับคุณสมบัติของเอกสารโดยใช้ Aspose.Slides for Node.js via Java

ดังที่ได้อธิบายไว้ก่อนหน้านี้ Aspose.Slides for Node.js via Java รองรับคุณสมบัติของเอกสารสองประเภท คือ **Built-in** และ **Custom** ดังนั้นนักพัฒนาสามารถเข้าถึงคุณสมบัติทั้งสองประเภทได้ผ่าน API ของ Aspose.Slides for Node.js via Java Aspose.Slides for Node.js via Java มีคลาส [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties) ซึ่งแสดงคุณสมบัติของเอกสารที่เชื่อมโยงกับไฟล์การนำเสนอผ่านคุณสมบัติ **Presentation.DocumentProperties**

นักพัฒนาสามารถใช้คุณสมบัติ **DocumentProperties** ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติของไฟล์การนำเสนอได้ตามที่อธิบายด้านล่าง:

## **เข้าถึง Built-in Properties**

คุณสมบัติเบรนด์ที่เปิดเผยโดยอ็อบเจ็กต์ [DocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties) ได้แก่: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject**, และ **Title**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนการนำเสนอ
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงถึงอ็อบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    var dp = pres.getDocumentProperties();
    // แสดงคุณสมบัติเบรนด์
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

## **แก้ไข Built-in Properties**

การแก้ไขคุณสมบัติเบรนด์ของไฟล์การนำเสนอทำได้ง่ายเช่นเดียวกับการเข้าถึง เพียงกำหนดค่าแบบสตริงให้กับคุณสมบัติที่ต้องการและค่าจะถูกแก้ไข ตัวอย่างด้านล่างแสดงวิธีการแก้ไขคุณสมบัติเบรนด์ของไฟล์การนำเสนอโดยใช้ Aspose.Slides for Node.js via Java

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงถึงอ็อบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    var dp = pres.getDocumentProperties();
    // ตั้งค่าคุณสมบัติเบรนด์
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

ตัวอย่างนี้แก้ไขคุณสมบัติเบรนด์ของการนำเสนอที่สามารถดูผลได้ตามด้านล่าง:

|**คุณสมบัติเบรนด์ของเอกสารหลังการแก้ไข**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)||

## **เพิ่ม Custom Document Properties**

Aspose.Slides for Node.js via Java ยังอนุญาตให้เพิ่มค่าที่กำหนดเองสำหรับคุณสมบัติของการนำเสนอ ตัวอย่างด้านล่างแสดงวิธีการตั้งค่าคุณสมบัติที่กำหนดเองสำหรับการนำเสนอ

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // ดึงคุณสมบัติของเอกสาร
    var dProps = pres.getDocumentProperties();
    // เพิ่มคุณสมบัติที่กำหนดเอง
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // ดึงชื่อคุณสมบัติที่ตำแหน่งเฉพาะ
    var getPropertyName = dProps.getCustomPropertyName(2);
    // ลบคุณสมบัติที่เลือก
    dProps.removeCustomProperty(getPropertyName);
    // บันทึกการนำเสนอ
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Custom Document Properties Added**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)||

## **เข้าถึงและแก้ไข Custom Properties**

Aspose.Slides for Node.js via Java ยังอนุญาตให้เข้าถึงค่าของคุณสมบัติที่กำหนดเอง ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติเหล่านี้สำหรับการนำเสนอ

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงถึงอ็อบเจ็กต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    var dp = pres.getDocumentProperties();
    // เข้าถึงและแก้ไขคุณสมบัติที่กำหนดเอง
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // แสดงชื่อและค่า ของคุณสมบัติที่กำหนดเอง
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // แก้ไขค่า ของคุณสมบัติที่กำหนดเอง
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

ตัวอย่างนี้แก้ไขคุณสมบัติที่กำหนดเองของ [PPTX ](https://docs.fileformat.com/presentation/pptx/) การนำเสนอ ภาพต่อไปนี้แสดงคุณสมบัติที่กำหนดเองก่อนและหลังการแก้ไข:

|**Custom Properties before Modification**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)||

|**Custom Properties after Modification**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)||

## **Advanced Document Properties**

{{% alert color="info" title="Note" %}}
เมธอดใหม่ [ReadDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), และ [WriteBindedPresentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) ได้ถูกเพิ่มเข้าไปใน [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo) การตั้งค่า [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) ได้ถูกเปลี่ยนแปลง
{{% /alert %}} 

เมธอดใหม่สองเมธอดคือ [ReadDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) และ [UpdateDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) ได้ถูกเพิ่มเข้าไปในคลาส [PresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PresentationInfo) พวกมันให้การเข้าถึงคุณสมบัติเบรนด์อย่างรวดเร็วและอนุญาตให้เปลี่ยนแปลงและอัปเดตคุณสมบัติได้โดยไม่ต้องโหลดการนำเสนอทั้งหมด

สถานการณ์ทั่วไปคือโหลดคุณสมบัติ, เปลี่ยนค่าและอัปเดตเอกสารสามารถทำได้ตามขั้นตอนต่อไปนี้:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// อ่านข้อมูลของการนำเสนอ
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtain the current properties
var props = info.readDocumentProperties();
// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");
// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

อีกวิธีหนึ่งคือใช้คุณสมบัติของการนำเสนอหนึ่งเป็นแม่แบบเพื่ออัปเดตคุณสมบัติในการนำเสนออื่น ๆ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

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
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

สามารถสร้างแม่แบบใหม่จากศูนย์แล้วใช้ในการอัปเดตการนำเสนอหลายไฟล์:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

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
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **ตั้งค่าภาษาการตรวจสอบ (Proofing Language)**

Aspose.Slides มีคุณสมบัติ LanguageId (เปิดเผยโดยคลาส PortionFormat) เพื่อให้คุณตั้งค่าภาษาการตรวจสอบสำหรับเอกสาร PowerPoint ภาษาการตรวจสอบคือภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ด JavaScript นี้แสดงวิธีตั้งค่าภาษาการตรวจสอบสำหรับ PowerPoint: xxx ทำไม LanguageId ถึงไม่มีในคลาส PortionFormat ของ JavaScript?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
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
    portionFormat.setLanguageId("zh-CN");// ตั้งค่า Id ของภาษาการตรวจสอบ
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าภาษาเริ่มต้น (Default Language)**

โค้ด JavaScript นี้แสดงวิธีตั้งค่าภาษาเริ่มต้นสำหรับการนำเสนอ PowerPoint ทั้งไฟล์:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Live Example**

ลองใช้แอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติของเอกสารผ่าน Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **FAQ**

**ฉันจะลบคุณสมบัติ Built-in ออกจากการนำเสนอได้อย่างไร?**

คุณสมบัติ Built-in เป็นส่วนหนึ่งของการนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตาม คุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**ถ้าฉันเพิ่มคุณสมบัติ Custom ที่มีอยู่แล้ว จะเกิดอะไรขึ้น?**

ถ้าคุณเพิ่มคุณสมบัติ Custom ที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดการนำเสนอเต็มรูปแบบได้หรือไม่?**

ได้ ใช้เมธอด [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) แล้วตามด้วย [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) เพื่ออ่านเมทาดาต้าโดยไม่ต้องสร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ดูตัวอย่างการสร้างรายงานแบบน้ำหนักเบาใน [Build a Lightweight Presentation Inventory](/slides/th/nodejs-java/examine-presentation/) เพื่อดูรายละเอียดเพิ่มเติมและข้อจำกัดของแต่ละรูปแบบ.