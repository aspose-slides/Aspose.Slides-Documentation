---
title: จัดการ OLE ในงานนำเสนอด้วย JavaScript
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/nodejs-java/manage-ole/
keywords:
- วัตถุ OLE
- การเชื่อมโยงและฝังวัตถุ
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มวัตถุ
- ฝังวัตถุ
- เพิ่มไฟล์
- ฝังไฟล์
- วัตถุที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยน OLE
- ไอคอน OLE
- ชื่อ OLE
- สกัด OLE
- สกัดวัตถุ
- สกัดไฟล์
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการวัตถุ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java. ฝัง, อัปเดต และส่งออกเนื้อหา OLE อย่างราบรื่น."
---
## **บทนำ**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่ทำให้ข้อมูลและวัตถุที่สร้างในแอปพลิเคชันหนึ่งสามารถวางในแอปพลิเคชันอื่นผ่านการเชื่อมโยงหรือการฝัง
{{% /alert %}}

พิจารณาแผนภูมิที่สร้างใน MS Excel แผนภูมินั้นถูกวางไว้ในสไลด์ PowerPoint แผนภูมิ Excel นี้ถือเป็นวัตถุ OLE

- OLE object อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณดับคลิกที่ไอคอน แผนภูมิจะเปิดในแอปพลิเคชันที่เชื่อมโยง (Excel) หรือจะมีการให้คุณเลือกแอปพลิเคชันเพื่อเปิดหรือแก้ไขวัตถุ
- OLE object อาจแสดงเนื้อหาจริงของมัน เช่น เนื้อหาของแผนภูมิ ในกรณีนี้แผนภูมิจะถูกเปิดใช้งานใน PowerPoint อินเทอร์เฟซของแผนภูมิจะโหลดและคุณสามารถแก้ไขข้อมูลของแผนภูมิภายใน PowerPoint

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) ช่วยให้คุณแทรก OLE Objects ลงในสไลด์เป็นกรอบวัตถุ OLE ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **การเพิ่มกรอบวัตถุ OLE ลงในสไลด์**

สมมติว่าคุณได้สร้างแผนภูมิใน Microsoft Excel แล้วและต้องการฝังมันลงในสไลด์เป็นกรอบวัตถุ OLE ด้วย Aspose.Slides for Node.js via Java คุณสามารถทำได้ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)
1. รับการอ้างอิงสไลด์ผ่านดัชนีของมัน
1. อ่านไฟล์ Excel เป็นอาเรย์ของไบต์
1. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) ลงในสไลด์โดยใส่อาเรย์ของไบต์และข้อมูลอื่น ๆ ของวัตถุ OLE
1. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มแผนภูมิจากไฟล์ Excel ลงในสไลด์เป็นกรอบวัตถุ OLE ด้วย Aspose.Slides for Node.js via Java. **หมายเหตุ** ว่า ตัวสร้าง [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) รับส่วนขยายของวัตถุที่สามารถฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ทำให้ PowerPoint สามารถตีความประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดวัตถุ OLE นี้.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **การเพิ่มกรอบวัตถุ OLE ที่เชื่อมโยง**

Aspose.Slides for Node.js via Java อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) โดยไม่ฝังข้อมูล แต่เพียงเชื่อมโยงไปยังไฟล์เท่านั้น

โค้ด JavaScript นี้แสดงวิธีการเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) พร้อมไฟล์ Excel ที่เชื่อมโยงไปยังสไลด์:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// เพิ่มกรอบวัตถุ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **การเข้าถึงกรอบวัตถุ OLE**

หากวัตถุ OLE มีการฝังไว้ในสไลด์แล้ว คุณสามารถค้นหา หรือเข้าถึงมันได้ง่าย ๆ ด้วยวิธีนี้:

1. โหลดงานนำเสนอที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. รับการอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. เข้าถึงรูปร่าง [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างขึ้นก่อนหน้านี้ซึ่งมีรูปร่างเดียวบนสไลด์แรก
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถดำเนินการใด ๆ กับมันได้

ในตัวอย่างด้านล่าง เราได้เข้าถึงกรอบวัตถุ OLE (วัตถุแผนภูมิ Excel ที่ฝังในสไลด์) และข้อมูลไฟล์ของมัน.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // รับข้อมูลไฟล์ที่ฝังไว้.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // รับส่วนขยายของไฟล์ที่ฝังไว้.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **การเข้าถึงคุณสมบัติกรอบวัตถุ OLE ที่เชื่อมโยง**

Aspose.Slides อนุญาตให้คุณเข้าถึงคุณสมบัติกรอบวัตถุ OLE ที่เชื่อมโยง

โค้ด JavaScript นี้แสดงวิธีตรวจสอบว่าวัตถุ OLE ถูกเชื่อมโยงหรือไม่และจากนั้นรับเส้นทางของไฟล์ที่เชื่อมโยง:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // ตรวจสอบว่าวัตถุ OLE ถูกเชื่อมโยงหรือไม่.
    if (oleFrame.isObjectLink()) {
        // พิมพ์เส้นทางเต็มของไฟล์ที่เชื่อมโยง.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // พิมพ์เส้นทางสัมพัทธ์ของไฟล์ที่เชื่อมโยงหากมี.
        // เฉพาะงานนำเสนอ PPT เท่านั้นที่สามารถมีเส้นทางสัมพัทธ์ได้.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **การเปลี่ยนแปลงข้อมูลวัตถุ OLE**

{{% alert color="info" title="Note" %}}
ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).
{{% /alert %}}

หากวัตถุ OLE มีการฝังไว้ในสไลด์แล้ว คุณสามารถเข้าถึงวัตถุนั้นและแก้ไขข้อมูลของมันได้ง่าย ๆ ด้วยวิธีนี้:

1. โหลดงานนำเสนอที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)
2. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เข้าถึงรูปร่าง OLE object frame ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างขึ้นก่อนหน้านี้ซึ่งมีรูปร่างหนึ่งบนสไลด์แรก
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถดำเนินการใด ๆ กับมันได้
5. สร้างออบเจกต์ `Workbook` และเข้าถึงข้อมูล OLE
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล
7. บันทึก `Workbook` ที่อัปเดตลงในสตรีม
8. เปลี่ยนข้อมูลวัตถุ OLE จากสตรีม

ในตัวอย่างด้านล่าง เราได้เข้าถึงกรอบวัตถุ OLE (วัตถุแผนภูมิ Excel ที่ฝังในสไลด์) และแก้ไขข้อมูลไฟล์ของมันเพื่ออัปเดตข้อมูลแผนภูมิ.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // อ่านข้อมูลวัตถุ OLE เป็นออบเจกต์ Workbook.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // แก้ไขข้อมูล workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // เปลี่ยนข้อมูลออบเจกต์ของกรอบ OLE.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **การฝังประเภทไฟล์อื่นในสไลด์**

นอกเหนือจากแผนภูมิ Excel, Aspose.Slides for Node.js via Java อนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ ตัวอย่างเช่น คุณสามารถแทรกไฟล์ HTML, PDF, และ ZIP เป็นวัตถุได้ เมื่อผู้ใช้ดับคลิกที่วัตถุที่แทรกเข้ามา มันจะเปิดโดยอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือผู้ใช้จะได้รับข้อความให้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์

โค้ด JavaScript นี้แสดงวิธีการฝัง HTML และ ZIP ลงในสไลด์:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **การกำหนดประเภทไฟล์สำหรับวัตถุที่ฝัง**

เมื่อทำงานกับงานนำเสนอ คุณอาจต้องการแทนที่วัตถุ OLE เก่าโดยวัตถุใหม่ หรือแทนที่วัตถุ OLE ที่ไม่รองรับด้วยวัตถุที่รองรับ Aspose.Slides for Node.js via Java อนุญาตให้คุณกำหนดประเภทไฟล์สำหรับวัตถุที่ฝัง เพื่อให้คุณสามารถอัปเดตข้อมูลกรอบ OLE หรือส่วนขยายของมันได้.

โค้ด JavaScript นี้แสดงวิธีการตั้งค่าประเภทไฟล์สำหรับวัตถุ OLE ที่ฝังเป็น `zip`:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// เปลี่ยนประเภทไฟล์เป็น ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **การตั้งค่าภาพไอคอนและหัวข้อสำหรับวัตถุที่ฝัง**

หลังจากฝังวัตถุ OLE จะมีการเพิ่มตัวอย่างที่ประกอบด้วยภาพไอคอนโดยอัตโนมัติ ตัวอย่างนี้คือสิ่งที่ผู้ใช้เห็นก่อนที่จะเข้าถึงหรือเปิดวัตถุ OLE หากคุณต้องการใช้ภาพและข้อความเฉพาะเป็นองค์ประกอบในตัวอย่าง คุณสามารถตั้งค่าภาพไอคอนและหัวข้อได้โดยใช้ Aspose.Slides for Node.js via Java.

โค้ด JavaScript นี้แสดงวิธีตั้งค่าภาพไอคอนและหัวข้อสำหรับวัตถุที่ฝัง:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **ป้องกันไม่ให้กรอบวัตถุ OLE ถูกปรับขนาดและย้ายตำแหน่ง**

หลังจากคุณเพิ่มวัตถุ OLE ที่เชื่อมโยงลงในสไลด์ของงานนำเสนอ เมื่อเปิดงานนำเสนอใน PowerPoint คุณอาจเห็นข้อความให้คุณอัปเดตลิงก์ การคลิกปุ่ม “Update Links” อาจทำให้ขนาดและตำแหน่งของกรอบวัตถุ OLE เปลี่ยนไปเนื่องจาก PowerPoint อัปเดตข้อมูลจากวัตถุ OLE ที่เชื่อมโยงและรีเฟรชตัวอย่างวัตถุ เพื่อป้องกันไม่ให้ PowerPoint แจ้งให้คุณอัปเดตข้อมูลของวัตถุ ให้เรียกใช้เมธอด [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) ของคลาส [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) ด้วยค่า `false`:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **การสกัดไฟล์ที่ฝัง**

Aspose.Slides for Node.js via Java อนุญาตให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นวัตถุ OLE ด้วยวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) ที่มีวัตถุ OLE ที่คุณต้องการสกัด
2. วนลูปผ่านรูปร่างทั้งหมดในงานนำเสนอและเข้าถึงรูปร่าง [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe)
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจากกรอบวัตถุ OLE และเขียนลงดิสก์

โค้ด JavaScript นี้แสดงวิธีการสกัดไฟล์ที่ฝังในสไลด์เป็นวัตถุ OLE:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **คำถามที่พบบ่อย**

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?**

สิ่งที่มองเห็นบนสไลด์จะถูกเรนเดอร์—ไอคอน/รูปภาพทดแทน (ตัวอย่าง). เนื้อหา OLE แบบ “สด” จะไม่ถูกประมวลผลระหว่างการเรนเดอร์ หากจำเป็นให้ตั้งค่าภาพตัวอย่างของคุณเองเพื่อให้แน่ใจว่าการแสดงผลที่ต้องการใน PDF ที่ส่งออก. เพื่อรักษาไฟล์ที่ฝังเป็นไฟล์แนบใน PDF ด้วย ให้เรียกใช้ [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) ด้วยค่า `true`. ตัวเลือกนี้ปิดการใช้งานโดยค่าเริ่มต้น สำหรับตัวอย่างและคำแนะนำในการตรวจสอบไฟล์แนบ ดูที่ [Preserve Embedded OLE Files as PDF Attachments](/slides/th/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**ฉันจะล็อกวัตถุ OLE บนสไลด์เพื่อไม่ให้ผู้ใช้ย้าย/แก้ไขใน PowerPoint ได้อย่างไร?**

ล็อกรูปร่าง: Aspose.Slides มีการล็อกระดับรูปร่าง ซึ่งไม่ใช่การเข้ารหัส แต่จะป้องกันการแก้ไขหรือการย้ายโดยบังเอิญได้อย่างมีประสิทธิภาพ.

**เส้นทางสัมพัทธ์สำหรับวัตถุ OLE ที่เชื่อมโยงจะถูกเก็บไว้ในรูปแบบ PPTX หรือไม่?**

ใน PPTX ไม่รองรับข้อมูล “เส้นทางสัมพัทธ์” — มีเพียงเส้นทางเต็มเท่านั้น เส้นทางสัมพัทธ์พบได้ในรูปแบบ PPT เก่ากว่า เพื่อความพกพา ควรใช้เส้นทางเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้หรือการฝังไฟล์.