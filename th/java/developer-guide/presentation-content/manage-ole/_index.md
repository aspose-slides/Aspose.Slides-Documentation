---
title: จัดการ OLE ในงานนำเสนอด้วย Java
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/java/manage-ole/
keywords:
- อ็อบเจกต์ OLE
- การลิงก์และฝังอ็อบเจกต์
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มอ็อบเจกต์
- ฝังอ็อบเจกต์
- เพิ่มไฟล์
- ฝังไฟล์
- อ็อบเจกต์ที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยน OLE
- ไอคอน OLE
- ชื่อเรื่อง OLE
- สกัด OLE
- สกัดอ็อบเจกต์
- สกัดไฟล์
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการอ็อบเจกต์ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Java. ฝัง, อัปเดต และส่งออกเนื้อหา OLE ได้อย่างราบรื่น."
---
## **บทนำ**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่ช่วยให้ข้อมูลและอ็อบเจกต์ที่สร้างในแอปพลิเคชันหนึ่งสามารถวางในแอปพลิเคชันอื่นโดยผ่านการลิงก์หรือการฝัง 

{{% /alert %}} 

ลองพิจารณากราฟที่สร้างใน MS Excel แล้วกราฟถูกวางอยู่ในสไลด์ของ PowerPoint กราฟ Excel นี้ถือเป็นอ็อบเจกต์ OLE 

- OLE object อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณดับเบิลคลิกที่ไอคอนกราฟจะเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือคุณจะถูกขอให้เลือกแอปพลิเคชันสำหรับการเปิดหรือแก้ไขอ็อบเจกต์  
- OLE object อาจแสดงเนื้อหาจริงของมัน เช่น เนื้อหาของกราฟ ในกรณีนี้กราฟจะทำงานใน PowerPoint อินเตอร์เฟซของกราฟจะโหลดและคุณสามารถแก้ไขข้อมูลของกราฟได้ภายใน PowerPoint  

[Aspose.Slides for Java](https://products.aspose.com/slides/th/java/) ช่วยให้คุณแทรก OLE Objects ลงในสไลด์เป็น OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/OleObjectFrame))  

## **เพิ่ม OLE Object Frames ลงในสไลด์**

สมมติว่าคุณได้สร้างกราฟใน Microsoft Excel แล้วต้องการฝังมันในสไลด์เป็น OLE object frame ด้วย Aspose.Slides for Java คุณสามารถทำตามขั้นตอนต่อไปนี้ได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
3. อ่านไฟล์ Excel เป็นอาร์เรย์ของไบต์  
4. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/OleObjectFrame) ลงในสไลด์โดยใส่อาร์เรย์ของไบต์และข้อมูลอื่น ๆ ของ OLE object  
5. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

**Note** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/OleEmbeddedDataInfo) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.  

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// เตรียมข้อมูลสำหรับอ็อบเจกต์ OLE.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **เพิ่ม OLE Object Frames ที่เชื่อมโยง**

Aspose.Slides for Java ช่วยให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/OleObjectFrame) โดยไม่ฝังข้อมูล แต่เพียงแค่เชื่อมโยงไปยังไฟล์  

โค้ด Java ด้านล่างแสดงวิธีการเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/OleObjectFrame) ที่เชื่อมโยงไฟล์ Excel ไปยังสไลด์:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มเฟรมอ็อบเจกต์ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **เข้าถึง OLE Object Frames**

หาก OLE object ได้ถูกฝังไว้ในสไลด์แล้ว คุณสามารถค้นหา หรือเข้าถึงได้ง่ายตามวิธีนี้  

1. โหลดการนำเสนอที่มี OLE object ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
3. เข้าถึงรูปทรง [OleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/OleObjectFrame) ในสไลด์ ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างขึ้นก่อนหน้านี้ซึ่งมีรูปทรงเดียวบนสไลด์แรก จากนั้น*cast* อ็อบเจกต์นั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/IOleObjectFrame) ซึ่งเป็น OLE object frame ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึง OLE object frame แล้ว คุณสามารถทำการดำเนินการใด ๆ กับมันได้  

ในตัวอย่างด้านล่าง OLE object frame (อ็อบเจกต์กราฟ Excel ที่ฝังในสไลด์) และข้อมูลไฟล์ของมันถูกเข้าถึง  

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // รับข้อมูลไฟล์ที่ฝังไว้.
    // รับส่วนขยายของไฟล์ที่ฝังไว้.
    // ...
}
```

### **เข้าถึงคุณสมบัติของ OLE Object Frame ที่เชื่อมโยง**

Aspose.Slides ช่วยให้คุณเข้าถึงคุณสมบัติของ OLE object frame ที่เชื่อมโยง  

โค้ด Java ด้านล่างแสดงวิธีการตรวจสอบว่า OLE object ถูกเชื่อมโยงหรือไม่ และรับเส้นทางของไฟล์ที่เชื่อมโยง  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // ตรวจสอบว่าอ็อบเจกต์ OLE ถูกลิงก์หรือไม่.
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

## **เปลี่ยนแปลงข้อมูล OLE Object**

{{% alert color="info" %}} 

ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for Java](/cells/java/)  

{{% /alert %}}  

หาก OLE object ถูกฝังไว้ในสไลด์แล้ว คุณสามารถเข้าถึงอ็อบเจกต์นั้นและแก้ไขข้อมูลของมันได้ตามขั้นตอนต่อไปนี้  

1. โหลดการนำเสนอที่มี OLE object ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
3. เข้าถึงรูปทรง OLE object frame ในสไลด์ ในตัวอย่างของเรา เราใช้ PPTX ที่มีรูปทรงเดียวบนสไลด์แรก แล้ว*cast* อ็อบเจกต์นั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/IOleObjectFrame) ซึ่งเป็น OLE object frame ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึง OLE object frame แล้ว คุณสามารถทำการดำเนินการใด ๆ กับมันได้  
5. สร้างอ็อบเจกต์ `Workbook` และเข้าถึงข้อมูล OLE  
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล  
7. บันทึก `Workbook` ที่อัปเดตลงในสตรีม  
8. เปลี่ยนข้อมูล OLE object จากสตรีม  

ในตัวอย่างด้านล่าง OLE object frame (อ็อบเจกต์กราฟ Excel ที่ฝังในสไลด์) ถูกเข้าถึงและข้อมูลไฟล์ของมันถูกแก้ไขเพื่ออัปเดตข้อมูลกราฟ  

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

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

นอกจากกราฟ Excel แล้ว Aspose.Slides for Java ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ ตัวอย่างเช่น คุณสามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นอ็อบเจกต์ เมื่อผู้ใช้ดับเบิลคลิกอ็อบเจกต์ที่แทรกไว้ มันจะเปิดโดยอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือผู้ใช้จะถูกขอให้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์  

โค้ด Java ด้านล่างแสดงวิธีการฝัง HTML และ ZIP ลงในสไลด์  

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **กำหนดประเภทไฟล์สำหรับอ็อบเจกต์ที่ฝัง**

เมื่อทำงานกับการนำเสนอ คุณอาจต้องการแทนที่ OLE object เก่าด้วยอ็อบเจกต์ใหม่ หรือแทนที่ OLE object ที่ไม่รองรับด้วยอ็อบเจกต์ที่รองรับ Aspose.Slides for Java ช่วยให้คุณตั้งค่าประเภทไฟล์สำหรับอ็อบเจกต์ที่ฝัง เพื่อให้คุณอัปเดตข้อมูลของเฟรม OLE หรือส่วนขยายของไฟล์ได้  

โค้ด Java ด้านล่างแสดงวิธีการตั้งค่าประเภทไฟล์สำหรับ OLE object ที่ฝังเป็น `zip`  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// เปลี่ยนนามสกุลไฟล์เป็น ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ตั้งค่าภาพไอคอนและชื่อเรื่องสำหรับอ็อบเจกต์ที่ฝัง**

หลังจากฝัง OLE object แล้ว ระบบจะเพิ่มตัวอย่างภาพ (preview) ที่ประกอบด้วยไอคอนโดยอัตโนมัติ ตัวอย่างภาพนี้คือสิ่งที่ผู้ใช้เห็นก่อนที่จะเข้าถึงหรือเปิด OLE object หากคุณต้องการใช้ภาพและข้อความเฉพาะเป็นองค์ประกอบในตัวอย่างภาพ คุณสามารถตั้งค่าภาพไอคอนและชื่อเรื่องโดยใช้ Aspose.Slides for Java  

โค้ด Java ด้านล่างแสดงวิธีตั้งค่าภาพไอคอนและชื่อเรื่องสำหรับอ็อบเจกต์ที่ฝัง  

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// เพิ่มรูปภาพไปยังทรัพยากรของการนำเสนอ.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ป้องกันไม่ให้ OLE Object Frame ถูกปรับขนาดและเปลี่ยนตำแหน่ง**

หลังจากที่คุณเพิ่ม OLE object ที่เชื่อมโยงลงในสไลด์การนำเสนอ เมื่อเปิดการนำเสนอใน PowerPoint คุณอาจเห็นข้อความขอให้อัปเดตลิงก์ การคลิกปุ่ม “Update Links” อาจทำให้ขนาดและตำแหน่งของ OLE object frame เปลี่ยนไปเนื่องจาก PowerPoint อัปเดตข้อมูลจาก OLE object ที่เชื่อมโยงและรีเฟรชตัวอย่างภาพ เพื่อป้องกันไม่ให้ PowerPoint ขออัปเดตข้อมูลของอ็อบเจกต์ ให้ตั้งค่าเมธอด `setUpdateAutomatic` ของอินเทอร์เฟซ [IOleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ioleobjectframe/) เป็น `false`  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **สกัดไฟล์ที่ฝัง**

Aspose.Slides for Java ช่วยให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็น OLE objects ได้ตามขั้นตอนต่อไปนี้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่มี OLE objects ที่คุณต้องการสกัด  
2. ลูปผ่านรูปทรงทั้งหมดในการนำเสนอและเข้าถึงรูปทรง [OLEObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/oleobjectframe)  
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจาก OLE object frames แล้วบันทึกลงดิสก์  

โค้ด Java ด้านล่างแสดงวิธีสกัดไฟล์ที่ฝังในสไลด์เป็น OLE objects  

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

## **คำถามที่พบบ่อย**

### OLE content จะถูกแสดงผลเมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?

สิ่งที่มองเห็นได้บนสไลด์จะถูกเรนเดอร์ — ไอคอน/ภาพแทน (preview) ส่วน “live” OLE content จะไม่ทำงานระหว่างการเรนเดอร์ หากต้องการ ให้ตั้งค่าภาพตัวอย่างของคุณเองเพื่อให้แน่ใจว่าการแสดงผลใน PDF ที่ส่งออกตรงตามที่คาดหวัง  

### ฉันจะล็อก OLE object บนสไลด์เพื่อให้ผู้ใช้ไม่สามารถย้าย/แก้ไขได้ใน PowerPoint อย่างไร?

ล็อกรูปทรง: Aspose.Slides มี [shape-level locks](/slides/th/java/applying-protection-to-presentation/) ให้ใช้ วิธีนี้ไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือการย้ายโดยบังเอิญได้อย่างมีประสิทธิภาพ  

### ทำไม OLE Excel ที่เชื่อมโยงถึง “กระโดด” หรือเปลี่ยนขนาดเมื่อเปิดการนำเสนอ?

PowerPoint อาจรีเฟรชตัวอย่างภาพของ OLE ที่เชื่อมโยง เพื่อให้รูปลักษณ์คงที่ ให้ทำตามแนวทางใน [Working Solution for Worksheet Resizing](/slides/th/java/working-solution-for-worksheet-resizing/) — หรือปรับเฟรมให้พอดีกับช่วงข้อมูล หรือตั้งค่าช่วงให้สเกลตามเฟรมคงที่และกำหนดภาพแทนที่เหมาะสม  

### เส้นทางแบบ relative สำหรับ OLE object ที่เชื่อมโยงจะถูกเก็บไว้ในรูปแบบ PPTX หรือไม่?

ใน PPTX ข้อมูล “relative path” ไม่มีให้ใช้ — มีเพียงเส้นทางเต็มเท่านั้น เส้นทางแบบ relative พบได้ในรูปแบบ PPT เก่า สำหรับความพกพา ควรใช้เส้นทาง absolute ที่เชื่อถือได้ หรือ URI ที่เข้าถึงได้ หรือทำการฝังไฟล์แทน.