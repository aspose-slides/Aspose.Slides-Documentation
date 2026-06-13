---
title: จัดการ OLE ในการนำเสนอโดยใช้ JavaScript
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
- เปลี่ยนแปลง OLE
- ไอคอน OLE
- หัวข้อ OLE
- สกัด OLE
- สกัดวัตถุ
- สกัดไฟล์
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการวัตถุ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java ฝัง ปรับปรุง และส่งออกเนื้อหา OLE อย่างราบรื่น"
---
## **บทนำ**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่ช่วยให้ข้อมูลและวัตถุที่สร้างในแอปพลิเคชันหนึ่งสามารถถูกวางในแอปพลิเคชันอื่นผ่านการเชื่อมโยงหรือฝังตัวได้  

{{% /alert %}} 

ลองพิจารณากราฟที่สร้างใน MS Excel แล้วนำกราฟนั้นใส่ลงในสไลด์ PowerPoint กราฟ Excel นี้ถือเป็นวัตถุ OLE  

- วัตถุ OLE อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณคลิกสองครั้งที่ไอคอน กราฟจะเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือระบบจะให้คุณเลือกแอปพลิเคชันสำหรับเปิดหรือแก้ไขวัตถุ  
- วัตถุ OLE อาจแสดงเนื้อหาจริง เช่น เนื้อหาของกราฟ ในกรณีนี้กราฟจะทำงานใน PowerPoint อินเทอร์เฟซของกราฟจะโหลดและคุณสามารถแก้ไขข้อมูลของกราฟภายใน PowerPoint ได้  

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/th/nodejs-java/) ช่วยให้คุณแทรกวัตถุ OLE ลงในสไลด์เป็นกรอบวัตถุ OLE ([OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/OleObjectFrame))  

## **การเพิ่มกรอบวัตถุ OLE ลงในสไลด์**

สมมติว่าคุณได้สร้างกราฟใน Microsoft Excel แล้วต้องการฝังลงในสไลด์เป็นกรอบวัตถุ OLE ด้วย Aspose.Slides for Node.js via Java คุณสามารถทำได้ดังนี้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
1. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. อ่านไฟล์ Excel เป็นอาร์เรย์ไบต์  
1. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/OleObjectFrame) ลงในสไลด์โดยใช้ไบต์อาร์เรย์และข้อมูลอื่น ๆ ของวัตถุ OLE  
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง เราได้เพิ่มกราฟจากไฟล์ Excel ลงในสไลด์เป็นกรอบวัตถุ OLE ด้วย Aspose.Slides for Node.js via Java  
**Note** ว่า constructor ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/OleEmbeddedDataInfo) รับส่วนขยายของวัตถุที่สามารถฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ทำให้ PowerPoint สามารถตีความประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดวัตถุ OLE นี้  

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// เตรียมข้อมูลสำหรับวัตถุ OLE.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// เพิ่มกรอบวัตถุ OLE ไปยังสไลด์.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **การเพิ่มกรอบวัตถุ OLE ที่เชื่อมโยง**

Aspose.Slides for Node.js via Java อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/OleObjectFrame) โดยไม่ต้องฝังข้อมูล แต่เพียงแค่เชื่อมโยงไปยังไฟล์เท่านั้น  

โค้ด JavaScript นี้แสดงวิธีการเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/OleObjectFrame) ที่เชื่อมโยงไฟล์ Excel ไปยังสไลด์:  

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// เพิ่มกรอบวัตถุ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **การเข้าถึงกรอบวัตถุ OLE**

หากวัตถุ OLE ถูกฝังไว้ในสไลด์แล้ว คุณสามารถค้นหาหรือเข้าถึงได้ง่าย ๆ ดังนี้  

1. โหลดพรีเซนเทชันที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เข้าถึง shape ของ [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/OleObjectFrame) ในตัวอย่างของเราจะใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมี shape เพียงอันเดียวบนสไลด์แรก  
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถดำเนินการใด ๆ กับมันได้  

ในตัวอย่างด้านล่าง เราเข้าถึงกรอบวัตถุ OLE (วัตถุกราฟ Excel ที่ฝังอยู่ในสไลด์) พร้อมกับข้อมูลไฟล์ของมัน  

```javascript
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

### **การเข้าถึงคุณสมบัติของกรอบวัตถุ OLE ที่เชื่อมโยง**

Aspose.Slides อนุญาตให้คุณเข้าถึงคุณสมบัติของกรอบวัตถุ OLE ที่เชื่อมโยง  

โค้ด JavaScript นี้แสดงวิธีการตรวจสอบว่าวัตถุ OLE ถูกเชื่อมโยงหรือไม่และรับพาธของไฟล์ที่เชื่อมโยง:  

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // ตรวจสอบว่าวัตถุ OLE ถูกเชื่อมโยงหรือไม่.
    if (oleFrame.isObjectLink()) {
        // พิมพ์พาธเต็มของไฟล์ที่เชื่อมโยง.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // พิมพ์พาธสัมพัทธ์ของไฟล์ที่เชื่อมโยงหากมี.
        // เฉพาะการนำเสนอ PPT เท่านั้นที่สามารถมีพาธสัมพัทธ์ได้.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **การเปลี่ยนแปลงข้อมูลของวัตถุ OLE**

{{% alert color="primary" %}} 

ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for Java](/cells/java/)  

{{% /alert %}}  

หากวัตถุ OLE ถูกฝังไว้ในสไลด์แล้ว คุณสามารถเข้าถึงวัตถุและแก้ไขข้อมูลของมันได้ดังนี้  

1. โหลดพรีเซนเทชันที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เข้าถึง shape ของกรอบวัตถุ OLE ในตัวอย่างของเราจะใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมี shape หนึ่งอันบนสไลด์แรก  
4. หลังจากเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถดำเนินการใด ๆ กับมันได้  
5. สร้างอ็อบเจกต์ `Workbook` แล้วเข้าถึงข้อมูล OLE  
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล  
7. บันทึก `Workbook` ที่อัปเดตเป็นสตรีม  
8. เปลี่ยนข้อมูลวัตถุ OLE จากสตรีม  

ในตัวอย่างด้านล่าง เราเข้าถึงกรอบวัตถุ OLE (วัตถุกราฟ Excel ที่ฝังอยู่ในสไลด์) แล้วแก้ไขข้อมูลไฟล์ของมันเพื่ออัปเดตข้อมูลกราฟ  

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // อ่านข้อมูลวัตถุ OLE เป็นอ็อบเจกต์ Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // แก้ไขข้อมูลของ workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // เปลี่ยนข้อมูลอ็อบเจกต์ของกรอบ OLE.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **การฝังไฟล์ประเภทอื่นในสไลด์**

นอกจากกราฟ Excel แล้ว Aspose.Slides for Node.js via Java ยังรองรับการฝังไฟล์ประเภทอื่น ๆ ลงในสไลด์ เช่น คุณสามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นวัตถุ เมื่อผู้ใช้คลิกสองครั้งบนวัตถุที่แทรกไว้ ระบบจะเปิดไฟล์โดยอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือจะแจ้งให้ผู้ใช้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์  

โค้ด JavaScript นี้แสดงวิธีการฝัง HTML และ ZIP ลงในสไลด์:  

```javascript
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

## **การกำหนดประเภทไฟล์สำหรับวัตถุที่ฝังไว้**

เมื่อต้องทำงานกับพรีเซนเทชัน บางครั้งคุณอาจต้องการแทนที่วัตถุ OLE เก่าโดยวัตถุใหม่ หรือแทนที่วัตถุ OLE ที่ไม่รองรับด้วยวัตถุที่รองรับ Aspose.Slides for Node.js via Java ให้คุณกำหนดประเภทไฟล์สำหรับวัตถุที่ฝังไว้ได้ เพื่อให้คุณสามารถอัปเดตข้อมูลเฟรม OLE หรือส่วนขยายของมัน  

โค้ด JavaScript นี้แสดงวิธีการตั้งค่าประเภทไฟล์สำหรับวัตถุ OLE ที่ฝังเป็น `zip`:  

```javascript
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

## **การกำหนดรูปไอคอนและชื่อเรื่องสำหรับวัตถุที่ฝังไว้**

หลังจากฝังวัตถุ OLE แล้ว ระบบจะเพิ่มภาพตัวอย่างที่เป็นไอคอนโดยอัตโนมัติ ภาพตัวอย่างนี้คือสิ่งที่ผู้ใช้เห็นก่อนจะเข้าถึงหรือเปิดวัตถุ OLE หากคุณต้องการใช้รูปภาพและข้อความเฉพาะเป็นส่วนประกอบของภาพตัวอย่าง คุณสามารถตั้งค่ารูปไอคอนและชื่อเรื่องได้โดยใช้ Aspose.Slides for Node.js via Java  

โค้ด JavaScript นี้แสดงวิธีการตั้งค่ารูปไอคอนและชื่อเรื่องสำหรับวัตถุที่ฝังไว้:  

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// เพิ่มรูปภาพไปยังทรัพยากรของพรีเซนเทชัน.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// กำหนดชื่อและรูปภาพสำหรับตัวอย่าง OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **ป้องกันไม่ให้กรอบวัตถุ OLE ถูกปรับขนาดและตำแหน่งอัตโนมัติ**

หลังจากที่คุณเพิ่มวัตถุ OLE ที่เชื่อมโยงลงในสไลด์พรีเซนเทชัน เมื่อเปิดพรีเซนเทชันใน PowerPoint อาจแสดงข้อความให้คุณอัปเดตลิงก์ การคลิกปุ่ม "Update Links" อาจทำให้กรอบวัตถุ OLE เปลี่ยนขนาดและตำแหน่ง เนื่องจาก PowerPoint อัปเดตข้อมูลจากวัตถุ OLE ที่เชื่อมโยงและรีเฟรชภาพตัวอย่าง เพื่อป้องกันไม่ให้ PowerPoint ตั้งค่าการอัปเดตข้อมูลอัตโนมัติ ให้ใช้เมธอด `setUpdateAutomatic` ของคลาส [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/oleobjectframe/) โดยกำหนดค่าเป็น `false`:  

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **การสกัดไฟล์ที่ฝังไว้**

Aspose.Slides for Node.js via Java ให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นวัตถุ OLE ได้ดังนี้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่มีวัตถุ OLE ที่ต้องการสกัด  
2. วนลูปผ่าน shape ทั้งหมดในพรีเซนเทชันและเข้าถึง shape ของ [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/oleobjectframe)  
3. เข้าถึงข้อมูลไฟล์ที่ฝังอยู่จากกรอบวัตถุ OLE แล้วบันทึกลงดิสก์  

โค้ด JavaScript นี้แสดงวิธีการสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นวัตถุ OLE:  

```javascript
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

## **FAQ**

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?**  

สิ่งที่มองเห็นบนสไลด์จะถูกเรนเดอร์ — คือไอคอนหรือภาพตัวอย่าง (preview) เนื้อหา OLE แบบ “สด” จะไม่ถูกประมวลผลระหว่างการเรนเดอร์ หากต้องการ ให้ตั้งค่ารูปภาพตัวอย่างของคุณเองเพื่อให้ได้ลักษณะที่ต้องการใน PDF ที่ส่งออก  

**ทำอย่างไรจึงจะล็อกวัตถุ OLE บนสไลด์เพื่อให้ผู้ใช้ไม่สามารถย้ายหรือแก้ไขมันใน PowerPoint?**  

ล็อก shape: Aspose.Slides มีการล็อกระดับ shape ซึ่งไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขและการย้ายโดยไม่ได้ตั้งใจ  

**เส้นทางสัมพัทธ์ของวัตถุ OLE ที่เชื่อมโยงจะถูกเก็บไว้ในรูปแบบ PPTX หรือไม่?**  

ใน PPTX ข้อมูล “เส้นทางสัมพัทธ์” ไม่ได้มีอยู่ — มีเพียงเส้นทางเต็มเท่านั้น เส้นทางสัมพัทธ์พบได้ในรูปแบบไฟล์ PPT เก่า ๆ สำหรับความพกพา ควรใช้เส้นทางแน่นอนที่เชื่อถือได้หรือ URI ที่เข้าถึงได้ หรือฝังไฟล์ไว้เลย