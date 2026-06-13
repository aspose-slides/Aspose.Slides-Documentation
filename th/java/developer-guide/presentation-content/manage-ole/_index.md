---
title: จัดการ OLE ในงานนำเสนอด้วย Java
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/java/manage-ole/
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
- Java
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการวัตถุ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java ฝัง ปรับปรุง และส่งออกเนื้อหา OLE อย่างราบรื่น"
---
## **บทนำ**

{{% alert color="primary" %}} 
OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่อนุญาตให้ข้อมูลและวัตถุที่สร้างในแอปพลิเคชันหนึ่งสามารถวางในแอปพลิเคชันอื่นผ่านการเชื่อมโยงหรือการฝังตัว
{{% /alert %}} 

ให้นึกถึงแผนภูมิที่สร้างใน MS Excel แผนภูมินั้นถูกวางไว้ในสไลด์ PowerPoint แผนภูมิ Excel นี้ถือเป็นวัตถุ OLE

- OLE object อาจแสดงเป็นไอคอน ในกรณีนี้เมื่อคุณดับเบิลคลิกที่ไอคอน แผนภูมิจะเปิดในแอปพลิเคชันที่เชื่อมโยง (Excel) หรือคุณจะถูกถามให้เลือกแอปพลิเคชันสำหรับการเปิดหรือแก้ไขวัตถุ
- OLE object อาจแสดงเนื้อหาจริงของมัน เช่น เนื้อหาของแผนภูมิ ในกรณีนี้แผนภูมิจะทำงานใน PowerPoint อินเตอร์เฟซของแผนภูมิจะโหลด และคุณสามารถแก้ไขข้อมูลของแผนภูมิได้ภายใน PowerPoint

[Aspose.Slides for Java](https://products.aspose.com/slides/th/java/) ช่วยให้คุณแทรก OLE Objects ลงในสไลด์เป็น OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/OleObjectFrame))

## **เพิ่ม OLE Object Frames ลงในสไลด์**

สมมติว่าคุณได้สร้างแผนภูมิใน Microsoft Excel แล้วต้องการฝังมันลงในสไลด์เป็น OLE object frame ด้วย Aspose.Slides for Java คุณสามารถทำได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
2. รับการอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. อ่านไฟล์ Excel เป็นอาเรย์ของไบต์
4. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/OleObjectFrame) ไปยังสไลด์พร้อมอาเรย์ไบต์และข้อมูลอื่น ๆ เกี่ยวกับ OLE object
5. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มแผนภูมิจากไฟล์ Excel ลงในสไลด์เป็น OLE object frame ด้วย Aspose.Slides for Java  
**หมายเหตุ** ว่า constructor ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/OleEmbeddedDataInfo) รับส่วนขยายของวัตถุที่สามารถฝังได้เป็นพารามิเตอร์ตัวที่สอง ส่วนขยายนี้ทำให้ PowerPoint สามารถตีความประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิด OLE object นี้

``` java
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// เตรียมข้อมูลสำหรับวัตถุ OLE.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// เพิ่มเฟรมวัตถุ OLE ลงในสไลด์.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **เพิ่ม Linked OLE Object Frames**

Aspose.Slides for Java อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/OleObjectFrame) โดยไม่ต้องฝังข้อมูล แต่เพียงเชื่อมโยงไปยังไฟล์เท่านั้น  
โค้ด Java นี้แสดงวิธีการเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/OleObjectFrame) พร้อมไฟล์ Excel ที่เชื่อมโยงไปยังสไลด์:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มเฟรมวัตถุ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **เข้าถึง OLE Object Frames**

หาก OLE object ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถค้นหาและเข้าถึงได้ง่ายๆ ดังนี้:

1. โหลดพรีเซนเทชันที่มี OLE object ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
2. รับการอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. เข้าถึง shape ของ [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/OleObjectFrame) 
   ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมีเพียง shape หนึ่งบนสไลด์แรก จากนั้นเราจึง *cast* วัตถุนี้เป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/IOleObjectFrame) นี่คือ OLE object frame ที่ต้องการเข้าถึง
4. เมื่อเข้าถึง OLE object frame แล้ว คุณสามารถดำเนินการใดๆ กับมันได้

ในตัวอย่างด้านล่าง เราเข้าถึง OLE object frame (วัตถุแผนภูมิ Excel ที่ฝังในสไลด์) และข้อมูลไฟล์ของมัน

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // ดึงข้อมูลไฟล์ที่ฝังไว้.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // ดึงส่วนขยายของไฟล์ที่ฝังไว้.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **เข้าถึงคุณสมบัติของ Linked OLE Object Frame**

Aspose.Slides อนุญาตให้คุณเข้าถึงคุณสมบัติของ linked OLE object frame  
โค้ด Java นี้แสดงวิธีการตรวจสอบว่า OLE object ถูกเชื่อมโยงหรือไม่และจากนั้นรับเส้นทางของไฟล์ที่เชื่อมโยง:

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // ตรวจสอบว่า OLE object เชื่อมโยงหรือไม่
    if (oleFrame.isObjectLink()) {
        // พิมพ์เส้นทางเต็มของไฟล์ที่เชื่อมโยง
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // พิมพ์เส้นทาง relative ของไฟล์ที่เชื่อมโยงหากมี
        // เฉพาะงานนำเสนอ PPT เท่านั้นที่สามารถมีเส้นทาง relative ได้
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **เปลี่ยนข้อมูล OLE Object**

{{% alert color="primary" %}} 
ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for Java](/cells/java/)
{{% /alert %}}

หาก OLE object ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถเข้าถึงและแก้ไขข้อมูลของมันได้ดังนี้:

1. โหลดพรีเซนเทชันที่มี OLE object ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
2. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เข้าถึง shape ของ OLE object frame 
   ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมี shape หนึ่งบนสไลด์แรก จากนั้นเราจึง *cast* วัตถุนี้เป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/IOleObjectFrame) นี่คือ OLE object frame ที่ต้องการเข้าถึง
4. เมื่อเข้าถึง OLE object frame แล้ว คุณสามารถดำเนินการใดๆ กับมันได้
5. สร้างอ็อบเจกต์ `Workbook` และเข้าถึงข้อมูล OLE
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล
7. บันทึก `Workbook` ที่อัปเดตลงในสตรีม
8. เปลี่ยนข้อมูล OLE object จากสตรีม

ในตัวอย่างด้านล่าง เราเข้าถึง OLE object frame (วัตถุแผนภูมิ Excel ที่ฝังในสไลด์) และแก้ไขข้อมูลไฟล์ของมันเพื่ออัปเดตข้อมูลแผนภูมิ

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // อ่านข้อมูล OLE object เป็นอ็อบเจกต์ Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // แก้ไขข้อมูล workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // เปลี่ยนข้อมูลอ็อบเจกต์ OLE frame.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ฝังประเภทไฟล์อื่นในสไลด์**

นอกจากแผนภูมิ Excel แล้ว Aspose.Slides for Java ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ ตัวอย่างเช่น คุณสามารถแทรกไฟล์ HTML, PDF, และ ZIP เป็นวัตถุได้ เมื่อผู้ใช้ดับเบิลคลิกที่วัตถุที่แทรกไว้ มันจะเปิดโดยอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือผู้ใช้จะถูกถามให้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์นั้น  
โค้ด Java นี้แสดงวิธีการฝัง HTML และ ZIP ลงในสไลด์:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ตั้งค่าชนิดไฟล์สำหรับวัตถุที่ฝัง**

เมื่อทำงานกับพรีเซนเทชัน คุณอาจต้องการแทนที่ OLE object เก่าโดยอันใหม่หรือแทนที่ OLE object ที่ไม่รองรับด้วยอันที่รองรับ Aspose.Slides for Java อนุญาตให้คุณตั้งค่าชนิดไฟล์สำหรับวัตถุที่ฝัง เพื่อให้คุณสามารถอัปเดตข้อมูลของ OLE frame หรือส่วนขยายของมันได้  
โค้ด Java นี้แสดงวิธีการตั้งค่าชนิดไฟล์สำหรับ OLE object ที่ฝังเป็น `zip`:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ตั้งค่าภาพไอคอนและชื่อสำหรับวัตถุที่ฝัง**

หลังจากฝัง OLE object แล้ว การแสดงตัวอย่างที่ประกอบด้วยภาพไอคอนจะถูกเพิ่มโดยอัตโนมัติ การแสดงตัวอย่างนี้คือสิ่งที่ผู้ใช้เห็นก่อนเข้าถึงหรือเปิด OLE object หากคุณต้องการใช้ภาพและข้อความเฉพาะเป็นส่วนประกอบของการแสดงตัวอย่าง คุณสามารถตั้งค่าภาพไอคอนและชื่อโดยใช้ Aspose.Slides for Java  
โค้ด Java นี้แสดงวิธีการตั้งค่าภาพไอคอนและชื่อสำหรับวัตถุที่ฝัง:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// เพิ่มภาพไปยังทรัพยากรของพรีเซนเทชัน.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// ตั้งชื่อและภาพสําหรับการแสดงตัวอย่าง OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ป้องกันไม่ให้ OLE Object Frame ถูกปรับขนาดและย้ายตำแหน่ง**

หลังจากคุณเพิ่ม OLE object ที่เชื่อมโยงไปยังสไลด์พรีเซนเทชันแล้ว เมื่อเปิดพรีเซนเทชันใน PowerPoint คุณอาจพบข้อความให้ทำการอัปเดตลิงก์ การคลิกปุ่ม "Update Links" อาจทำให้ขนาดและตำแหน่งของ OLE object frame เปลี่ยนแปลง เพราะ PowerPoint จะอัปเดตข้อมูลจาก OLE object ที่เชื่อมโยงและรีเฟรชการแสดงตัวอย่างของวัตถุ เพื่อป้องกันไม่ให้ PowerPoint เตือนให้ทำการอัปเดตข้อมูลของวัตถุ ให้ตั้งค่าเมธอด `setUpdateAutomatic` ของอินเทอร์เฟซ [IOleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ioleobjectframe/) เป็น `false`:

```java
oleFrame.setUpdateAutomatic(false);
```

## **สกัดไฟล์ที่ฝัง**

Aspose.Slides for Java อนุญาตให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็น OLE objects ได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่มี OLE objects ที่คุณต้องการสกัด
2. วนลูปผ่าน shape ทั้งหมดในพรีเซนเทชันและเข้าถึง shape ของ [OLEObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/oleobjectframe)
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจาก OLE object frames แล้วบันทึกลงดิสก์

โค้ด Java นี้แสดงวิธีการสกัดไฟล์ที่ฝังในสไลด์เป็น OLE objects:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **FAQ**

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?**  
สิ่งที่มองเห็นบนสไลด์คือสิ่งที่ถูกเรนเดอร์—ไอคอน/รูปภาพแทน (preview) เนื้อหา OLE แบบ “live” ไม่ถูกประมวลผลขณะเรนเดอร์ หากต้องการ ให้ตั้งค่าภาพ preview ของคุณเองเพื่อให้แน่ใจว่าปรากฏตามที่คาดใน PDF ที่ส่งออก

**จะล็อก OLE object บนสไลด์เพื่อให้ผู้ใช้ไม่สามารถย้าย/แก้ไขมันใน PowerPoint อย่างไร?**  
ล็อก shape: Aspose.Slides มี [shape-level locks](/slides/th/java/applying-protection-to-presentation/) ซึ่งไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือการย้ายโดยไม่ได้ตั้งใจได้อย่างมีประสิทธิภาพ

**ทำไม OLE object Excel ที่เชื่อมโยงจึง "กระโดด" หรือเปลี่ยนขนาดเมื่อเปิดพรีเซนเทชัน?**  
PowerPoint อาจรีเฟรช preview ของ OLE ที่เชื่อมโยง เพื่อให้รูปแบบคงที่ ให้ทำตามแนวทางใน [Working Solution for Worksheet Resizing](/slides/th/java/working-solution-for-worksheet-resizing/) — ปรับเฟรมให้พอดีกับช่วงข้อมูล หรือสเกลช่วงให้เข้ากับเฟรมคงที่และตั้งค่าภาพแทนที่เหมาะสม

**เส้นทาง relative สำหรับ OLE objects ที่เชื่อมโยงจะคงอยู่ในรูปแบบ PPTX หรือไม่?**  
ใน PPTX ข้อมูล “relative path” ไม่สามารถใช้ได้—มีเฉพาะเส้นทางเต็มเท่านั้น เส้นทาง relative พบได้ในรูปแบบ PPT เก่า สำหรับการพกพา ควรใช้เส้นทาง absolute ที่เชื่อถือได้/URI ที่เข้าถึงได้หรือการฝังไฟล์  