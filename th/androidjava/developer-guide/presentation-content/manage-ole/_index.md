---
title: จัดการ OLE ในการนำเสนอบน Android
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/androidjava/manage-ole/
keywords:
- ออบเจกต์ OLE
- การเชื่อมโยงและฝังออบเจกต์
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มออบเจกต์
- ฝังออบเจกต์
- เพิ่มไฟล์
- ฝังไฟล์
- ออบเจกต์ที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยน OLE
- ไอคอน OLE
- ชื่อ OLE
- สกัด OLE
- สกัดออบเจกต์
- สกัดไฟล์
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการออบเจกต์ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. ฝัง, ปรับอัปเดต และส่งออกเนื้อหา OLE อย่างราบรื่น."
---
## **บทนำ**

{{% alert color="primary" %}} 
OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่อนุญาตให้ข้อมูลและออบเจกต์ที่สร้างในแอปพลิเคชันหนึ่งถูกวางในแอปพลิเคชันอื่นผ่านการเชื่อมโยงหรือการฝัง. 
{{% /alert %}} 

พิจารณาชาร์ตที่สร้างใน MS Excel ชาร์ตนั้นถูกวางไว้ในสไลด์ PowerPoint ซึ่งชาร์ต Excel นี้ถือเป็นออบเจกต์ OLE. 

- ออบเจกต์ OLE อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณคลิกสองครั้งที่ไอคอน ชาร์ตจะเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือระบบจะขอให้คุณเลือกแอปพลิเคชันเพื่อเปิดหรือแก้ไขออบเจกต์. 
- ออบเจกต์ OLE อาจแสดงเนื้อหาจริงของมัน เช่น เนื้อหาของชาร์ต ในกรณีนี้ชาร์ตจะทำงานใน PowerPoint อินเทอร์เฟซของชาร์ตจะโหลดและคุณจะสามารถแก้ไขข้อมูลของชาร์ตภายใน PowerPoint. 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/th/androidjava/) ช่วยให้คุณแทรก OLE Objects ลงในสไลด์เป็น OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OleObjectFrame)).

## **เพิ่ม OLE Object Frames ลงในสไลด์**

สมมติว่าคุณได้สร้างชาร์ตใน Microsoft Excel แล้วต้องการฝังลงในสไลด์เป็น OLE object frame ด้วย Aspose.Slides for Android via Java คุณสามารถทำได้ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) class. 
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
1. อ่านไฟล์ Excel เป็นอาเรย์ของไบต์. 
1. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OleObjectFrame) ไปยังสไลด์โดยใส่ข้อมูลไบต์และข้อมูลอื่น ๆ ของ OLE object. 
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX. 

ในตัวอย่างด้านล่าง เราได้เพิ่มชาร์ตจากไฟล์ Excel ไปยังสไลด์เป็น OLE object frame ด้วย Aspose.Slides for Android via Java. **หมายเหตุ** ว่า constructor ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OleEmbeddedDataInfo) รับส่วนขยายของออบเจกต์ที่สามารถฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ทำให้ PowerPoint สามารถตีความประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสำหรับการเปิด OLE object นี้. 

```java
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// เตรียมข้อมูลสำหรับออบเจกต์ OLE.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// เพิ่มเฟรมออบเจกต์ OLE ไปยังสไลด์.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **เพิ่ม OLE Object Frames แบบลิงก์**

Aspose.Slides for Android via Java อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OleObjectFrame) โดยไม่ฝังข้อมูล แต่เชื่อมโยงไปยังไฟล์เท่านั้น. 

โค้ด Java นี้แสดงวิธีการเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OleObjectFrame) ที่เชื่อมโยงกับไฟล์ Excel ไปยังสไลด์: 

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มเฟรมออบเจกต์ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **เข้าถึง OLE Object Frames**

หากออบเจกต์ OLE ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถค้นหาหรือเข้าถึงได้ตามขั้นตอนต่อไปนี้:

1. โหลดการนำเสนอที่มี OLE object ฝังอยู่โดยสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) class. 
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน. 
3. เข้าถึง shape ของ [OleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OleObjectFrame). ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมี shape เพียงหนึ่งบนสไลด์แรก แล้ว *cast* ออบเจกต์นั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleobjectframe/) ซึ่งเป็น OLE object frame ที่ต้องการเข้าถึง. 
4. เมื่อเข้าถึง OLE object frame แล้ว คุณสามารถดำเนินการใด ๆ บนมันได้. 

ในตัวอย่างด้านล่าง OLE object frame (ออบเจกต์ชาร์ต Excel ที่ฝังในสไลด์) และข้อมูลไฟล์ของมันถูกเข้าถึง. 

```java
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

### **เข้าถึงคุณสมบัติของ OLE Object Frame ที่เชื่อมโยง**

Aspose.Slides ช่วยให้คุณเข้าถึงคุณสมบัติของ OLE object frame ที่เชื่อมโยงได้. 

โค้ด Java นี้แสดงวิธีตรวจสอบว่าออบเจกต์ OLE ถูกเชื่อมโยงหรือไม่และรับเส้นทางของไฟล์ที่เชื่อมโยง: 

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // ตรวจสอบว่าออบเจกต์ OLE ถูกลิงก์หรือไม่.
    if (oleFrame.isObjectLink()) {
        // พิมพ์เส้นทางเต็มของไฟล์ที่ลิงก์.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // พิมพ์เส้นทางสัมพัทธ์ของไฟล์ที่ลิงก์หากมี.
        // เฉพาะการนำเสนอ PPT เท่านั้นที่สามารถมีเส้นทางสัมพัทธ์ได้.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **เปลี่ยนข้อมูล OLE Object**

{{% alert color="primary" %}} 
ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for Android via Java](/cells/androidjava/). 
{{% /alert %}} 

หากออบเจกต์ OLE ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถเข้าถึงและแก้ไขข้อมูลของออบเจกต์ได้ตามขั้นตอนต่อไปนี้:

1. โหลดการนำเสนอที่มี OLE object ฝังอยู่โดยสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) class. 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เข้าถึง shape ของ OLE object frame. ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมี shape หนึ่งบนสไลด์แรก แล้ว *cast* ออบเจกต์นั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleobjectframe/) ซึ่งเป็น OLE object frame ที่ต้องการเข้าถึง. 
4. เมื่อเข้าถึง OLE object frame แล้ว คุณสามารถดำเนินการใด ๆ บนมันได้. 
5. สร้างออบเจกต์ `Workbook` และเข้าถึงข้อมูล OLE. 
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล. 
7. บันทึก `Workbook` ที่อัปเดตในสตรีม. 
8. แทนที่ข้อมูล OLE object ด้วยข้อมูลจากสตรีม. 

ในตัวอย่างด้านล่าง OLE object frame (ออบเจกต์ชาร์ต Excel ที่ฝังในสไลด์) ถูกเข้าถึงและข้อมูลไฟล์ของมันถูกแก้ไขเพื่ออัปเดตข้อมูลชาร์ต. 

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // อ่านข้อมูลอ็อบเจกต์ OLE เป็นอ็อบเจกต์ Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // แก้ไขข้อมูลของ workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // เปลี่ยนข้อมูลอ็อบเจกต์ของ OLE frame.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ฝังไฟล์ประเภทอื่นในสไลด์**

นอกจากชาร์ต Excel แล้ว Aspose.Slides for Android via Java ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ ตัวอย่างเช่น คุณสามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นออบเจกต์ เมื่อผู้ใช้คลิกสองครั้งที่ออบเจกต์ที่แทรกไว้ ระบบจะเปิดไฟล์นั้นในโปรแกรมที่เกี่ยวข้องโดยอัตโนมัติ หรือให้ผู้ใช้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์. 

โค้ด Java นี้แสดงวิธีการฝัง HTML และ ZIP ลงในสไลด์: 

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **กำหนดประเภทไฟล์สำหรับออบเจกต์ที่ฝัง**

เมื่อทำงานกับการนำเสนอ คุณอาจต้องการแทนที่ออบเจกต์ OLE เก่าแทนออบเจกต์ใหม่ หรือแทนที่ออบเจกต์ OLE ที่ไม่รองรับด้วยออบเจกต์ที่รองรับ Aspose.Slides for Android via Java อนุญาตให้คุณกำหนดประเภทไฟล์สำหรับออบเจกต์ที่ฝัง เพื่อให้คุณสามารถอัปเดตข้อมูลของเฟรม OLE หรือส่วนขยายของไฟล์ได้. 

โค้ด Java นี้แสดงวิธีการตั้งค่าประเภทไฟล์สำหรับออบเจกต์ OLE ที่ฝังเป็น `zip`: 

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// เปลี่ยนประเภทไฟล์เป็น ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ตั้งค่าภาพไอคอนและหัวข้อสำหรับออบเจกต์ที่ฝัง**

หลังจากฝังออบเจกต์ OLE แล้ว ระบบจะเพิ่มตัวอย่างพรีวิวที่ประกอบด้วยภาพไอคอนโดยอัตโนมัติ ตัวพรีวิวนี้เป็นสิ่งที่ผู้ใช้จะเห็นก่อนเข้าถึงหรือเปิดออบเจกต์ OLE หากคุณต้องการใช้ภาพและข้อความเฉพาะเป็นส่วนประกอบของพรีวิว คุณสามารถตั้งค่าภาพไอคอนและหัวข้อโดยใช้ Aspose.Slides for Android via Java. 

โค้ด Java นี้แสดงวิธีตั้งค่าภาพไอคอนและหัวข้อสำหรับออบเจกต์ที่ฝัง: 

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// เพิ่มภาพไปยังทรัพยากรของการนำเสนอ.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ป้องกันไม่ให้ OLE Object Frame ถูกปรับขนาดและย้ายตำแหน่ง**

หลังจากคุณเพิ่ม OLE object ที่เชื่อมโยงลงในสไลด์ การเปิดการนำเสนอใน PowerPoint อาจแสดงข้อความขอให้คุณอัปเดตลิงก์ การคลิกปุ่ม “Update Links” อาจทำให้ขนาดและตำแหน่งของ OLE object frame เปลี่ยนไป เพราะ PowerPoint จะอัปเดตข้อมูลจาก OLE object ที่เชื่อมโยงและรีเฟรชพรีวิวของออบเจกต์ เพื่อป้องกันไม่ให้ PowerPoint เตือนให้อัปเดตข้อมูลของออบเจกต์ ให้ตั้งค่าเมธอด `setUpdateAutomatic` ของอินเทอร์เฟซ [IOleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleobjectframe/) เป็น `false`: 

```java
oleFrame.setUpdateAutomatic(false);
```

## **สกัดไฟล์ที่ฝัง**

Aspose.Slides for Android via Java อนุญาตให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นออบเจกต์ OLE ได้ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่มี OLE object ที่คุณต้องการสกัด. 
2. วนลูปผ่าน shape ทั้งหมดในการนำเสนอและเข้าถึง shape ของ [OLEObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/oleobjectframe). 
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจาก OLE object frames และเขียนข้อมูลลงดิสก์. 

โค้ด Java นี้แสดงวิธีสกัดไฟล์ที่ฝังในสไลด์เป็นออบเจกต์ OLE: 

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **FAQ**

**OLE content จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/ภาพหรือไม่?**

สิ่งที่ปรากฏบนสไลด์จะถูกเรนเดอร์คือ ไอคอน/ภาพแทน (พรีวิว) ส่วนเนื้อหา “สด” ของ OLE จะไม่ถูกประมวลผลในขณะเรนเดอร์ หากต้องการให้แสดงตามที่คาดไว้ใน PDF ให้ตั้งค่าภาพพรีวิวของคุณเอง.

**ฉันจะล็อกออบเจกต์ OLE บนสไลด์เพื่อไม่ให้ผู้ใช้ย้าย/แก้ไขใน PowerPoint อย่างไร?**

ล็อก shape: Aspose.Slides มีการล็อกระดับ shape ซึ่งไม่ใช่การเข้ารหัสแต่ช่วยป้องกันการแก้ไขและการเคลื่อนย้ายโดยบังเอิญ.

**ทำไมออบเจกต์ Excel ที่เชื่อมโยงถึง “กระโดด” หรือเปลี่ยนขนาดเมื่อเปิดการนำเสนอ?**

PowerPoint อาจรีเฟรชพรีวิวของ OLE ที่เชื่อมโยง เพื่อให้แสดงผลคงที่ ให้ปฏิบัติตาม [Working Solution for Worksheet Resizing](/slides/th/androidjava/working-solution-for-worksheet-resizing/) เช่น ปรับเฟรมให้พอดีกับช่วงข้อมูล หรือสเกลช่วงให้พอดีกับเฟรมคงที่และตั้งค่าภาพแทนที่เหมาะสม.

**เส้นทางแบบ relative สำหรับ OLE object ที่เชื่อมโยงจะถูกเก็บไว้ในรูปแบบ PPTX หรือไม่?**

ใน PPTX ข้อมูล “relative path” ไม่ได้บันทึกไว้ มีเฉพาะเส้นทางเต็มเท่านั้น เส้นทางแบบ relative พบได้ในรูปแบบ PPT เก่า สำหรับการพกพาแนะนำให้ใช้เส้นทางแบบ absolute ที่เชื่อถือได้หรือ URI ที่เข้าถึงได้หรือฝังไฟล์.