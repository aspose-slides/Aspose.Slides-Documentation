---
title: จัดการ OLE ในงานนำเสนอบน Android
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/androidjava/manage-ole/
keywords:
- วัตถุ OLE
- การเชื่อมโยงและฝังออบเจกต์
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มออบเจกต์
- ฝังออบเจกต์
- เพิ่มไฟล์
- ฝังไฟล์
- ออบเจกต์ที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยนแปลง OLE
- ไอคอน OLE
- หัวข้อ OLE
- สกัด OLE
- สกัดออบเจกต์
- สกัดไฟล์
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ปรับปรุงการจัดการวัตถุ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. ฝัง, อัพเดตและส่งออกเนื้อหา OLE อย่างราบรื่น."
---
## **บทนำ**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) คือเทคโนโลยีของ Microsoft ที่ทำให้ข้อมูลและออบเจกต์ที่สร้างในแอปพลิเคชันหนึ่งสามารถใส่ลงในแอปพลิเคชันอื่นได้ผ่านการลิงก์หรือการฝัง (embedding) 

{{% /alert %}} 

ให้พิจารณาชาร์ตที่สร้างใน MS Excel แล้วนำชาร์ตนั้นไปวางในสไลด์ PowerPoint ชาร์ต Excel นี้ถือเป็นออบเจกต์ OLE

- ออบเจกต์ OLE อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณดับเบิลคลิกที่ไอคอน ชาร์ตจะเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือระบบอาจขอให้คุณเลือกแอปพลิเคชันเพื่อเปิดหรือแก้ไขออบเจกต์
- ออบเจกต์ OLE อาจแสดงเนื้อหาจริงของมัน เช่น เนื้อหาของชาร์ต ในกรณีนี้ชาร์ตจะทำงานใน PowerPoint อินเทอร์เฟซของชาร์ตจะโหลดและคุณสามารถแก้ไขข้อมูลของชาร์ตภายใน PowerPoint ได้

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/th/androidjava/) ช่วยให้คุณแทรก OLE Objects ลงในสไลด์เป็น OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OleObjectFrame))

## **เพิ่ม OLE Object Frames ไปยังสไลด์**

สมมติว่าคุณได้สร้างชาร์ตใน Microsoft Excel แล้วต้องการฝังมันลงในสไลด์เป็น OLE object frame ด้วย Aspose.Slides for Android via Java คุณสามารถทำได้ตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. อ่านไฟล์ Excel เป็นอาเรย์ไบต์  
4. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OleObjectFrame) ลงในสไลด์โดยใส่อาเรย์ไบต์และข้อมูลอื่น ๆ เกี่ยวกับ OLE object  
5. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง เราได้เพิ่มชาร์ตจากไฟล์ Excel ลงในสไลด์เป็น OLE object frame ด้วย Aspose.Slides for Android via Java  
**หมายเหตุ** ว่าตัวสร้าง [OleEmbeddedDataInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OleEmbeddedDataInfo) รับส่วนขยายของออบเจกต์ที่สามารถฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ทำให้ PowerPoint สามารถตีความชนิดไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิด OLE object นี้

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **เพิ่ม Linked OLE Object Frames**

Aspose.Slides for Android via Java ช่วยให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OleObjectFrame) โดยไม่ต้องฝังข้อมูล แต่เพียงแค่ลิงก์ไปยังไฟล์เท่านั้น

โค้ด Java ด้านล่างแสดงวิธีการเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OleObjectFrame) ที่ลิงก์ไปยังไฟล์ Excel บนสไลด์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่ม OLE object frame พร้อมไฟล์ Excel ที่เชื่อมโยง
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **เข้าถึง OLE Object Frames**

หากออบเจกต์ OLE ถูกฝังไว้ในสไลด์แล้ว คุณสามารถค้นหาและเข้าถึงได้ตามขั้นตอนต่อไปนี้

1. โหลดงานนำเสนอที่มี OLE object ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
3. เข้าถึง shape ของ [OleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OleObjectFrame)  
   ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมี shape เพียงอันเดียวบนสไลด์แรก จากนั้น *cast* ออบเจกต์นั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleobjectframe/) ซึ่งเป็น OLE object frame ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึง OLE object frame แล้ว คุณสามารถดำเนินการใด ๆ กับมันได้

ในตัวอย่างด้านล่าง เราเข้าถึง OLE object frame (ออบเจกต์ชาร์ต Excel ที่ฝังในสไลด์) และข้อมูลไฟล์ของมัน

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // รับข้อมูลไฟล์ที่ฝังอยู่
    // รับส่วนขยายของไฟล์ที่ฝังอยู่
    // ...
}
```

### **เข้าถึงคุณสมบัติของ Linked OLE Object Frame**

Aspose.Slides ช่วยให้คุณเข้าถึงคุณสมบัติของ linked OLE object frame

โค้ด Java ด้านล่างแสดงวิธีตรวจสอบว่าออบเจกต์ OLE ถูกลิงก์หรือไม่และจากนั้นรับพาธของไฟล์ที่ลิงก์ไว้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // ตรวจสอบว่าออบเจกต์ OLE ถูกลิงก์หรือไม่
    if (oleFrame.isObjectLink()) {
        // พิมพ์พาธเต็มของไฟล์ที่ลิงก์
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // พิมพ์พาธสัมพัทธ์ของไฟล์ที่ลิงก์หากมี
        // เฉพาะงานนำเสนอ PPT เท่านั้นที่สามารถมีพาธสัมพัทธ์ได้
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **เปลี่ยนแปลงข้อมูลของ OLE Object**

{{% alert color="info" %}} 

ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for Android via Java](/cells/androidjava/) 

{{% /alert %}}

หากออบเจกต์ OLE ถูกฝังไว้ในสไลด์แล้ว คุณสามารถเข้าถึงและแก้ไขข้อมูลของออบเจกต์นั้นได้ตามขั้นตอนต่อไปนี้

1. โหลดงานนำเสนอที่มี OLE object ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เข้าถึง shape ของ OLE object frame  
   ในตัวอย่างของเรา เราใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมี shape หนึ่งอันบนสไลด์แรก จากนั้น *cast* ออบเจกต์นั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleobjectframe/) ซึ่งเป็น OLE object frame ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึง OLE object frame แล้ว คุณสามารถดำเนินการใด ๆ กับมันได้  
5. สร้างออบเจกต์ `Workbook` และเข้าถึงข้อมูล OLE  
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล  
7. บันทึก `Workbook` ที่อัพเดตเป็นสตรีม  
8. แทนที่ข้อมูล OLE object ด้วยสตรีมที่ได้

ในตัวอย่างด้านล่าง เราเข้าถึง OLE object frame (ออบเจกต์ชาร์ต Excel ที่ฝังในสไลด์) และแก้ไขข้อมูลไฟล์ของมันเพื่ออัพเดตข้อมูลชาร์ต

```java 
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

    // อ่านข้อมูลออบเจกต์ OLE เป็นออบเจกต์ Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // แก้ไขข้อมูล workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // เปลี่ยนข้อมูลออบเจกต์ของ OLE frame.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ฝังไฟล์ประเภทอื่นลงในสไลด์**

นอกจากชาร์ต Excel แล้ว Aspose.Slides for Android via Java ยังรองรับการฝังไฟล์ประเภทอื่นลงในสไลด์ เช่น HTML, PDF และ ZIP เมื่อผู้ใช้ดับเบิลคลิกออบเจกต์ที่แทรกเข้าไป ระบบจะเปิดไฟล์นั้นในโปรแกรมที่เกี่ยวข้องโดยอัตโนมัติ หรือจะแสดงข้อความให้ผู้ใช้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์

โค้ด Java ด้านล่างแสดงวิธีฝัง HTML และ ZIP ลงในสไลด์

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

เมื่อทำงานกับงานนำเสนอ คุณอาจต้องการแทนที่ OLE object เก่าโดยออบเจกต์ใหม่ หรือแทนที่ OLE object ที่ไม่รองรับด้วยออบเจกต์ที่รองรับ Aspose.Slides for Android via Java ช่วยให้คุณตั้งค่าประเภทไฟล์สำหรับออบเจกต์ที่ฝังได้ ทำให้คุณสามารถอัพเดตข้อมูลของ OLE frame หรือส่วนขยายของไฟล์ได้

โค้ด Java ด้านล่างแสดงวิธีตั้งค่าประเภทไฟล์สำหรับ OLE object ที่ฝังเป็น `zip`

```java
import com.aspose.slides.*;

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

## **กำหนดรูปภาพไอคอนและหัวเรื่องสำหรับออบเจกต์ที่ฝัง**

หลังจากฝัง OLE object แล้ว ระบบจะสร้างพรีวิวที่ประกอบด้วยรูปไอคอนโดยอัตโนมัติ พรีวิวนี้เป็นสิ่งที่ผู้ใช้เห็นก่อนจะเข้าถึงหรือเปิด OLE object หากคุณต้องการใช้รูปภาพและข้อความเฉพาะเป็นส่วนประกอบของพรีวิว คุณสามารถตั้งค่ารูปไอคอนและหัวเรื่องได้ด้วย Aspose.Slides for Android via Java

โค้ด Java ด้านล่างแสดงวิธีตั้งค่ารูปไอคอนและหัวเรื่องสำหรับออบเจกต์ที่ฝัง

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ป้องกันไม่ให้ OLE Object Frame ถูกปรับขนาดและย้ายตำแหน่ง**

หลังจากคุณเพิ่ม OLE object ที่ลิงก์ไว้ในสไลด์ เมื่อเปิดงานนำเสนอใน PowerPoint อาจมีข้อความถามว่าต้องการอัพเดทลิงก์หรือไม่ การคลิกปุ่ม "Update Links" อาจทำให้ขนาดและตำแหน่งของ OLE object frame เปลี่ยนแปลงไป เพราะ PowerPoint อัพเดทข้อมูลจาก OLE object ที่ลิงก์และรีเฟรชพรีวิวของออบเจกต์ เพื่อป้องกันไม่ให้ PowerPoint แสดงข้อความอัพเดทข้อมูล ให้ตั้งค่าเมธอด `setUpdateAutomatic` ของอินเทอร์เฟซ [IOleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleobjectframe/) เป็น `false`

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **สกัดไฟล์ที่ฝังอยู่**

Aspose.Slides for Android via Java ช่วยให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็น OLE objects ได้ตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่มี OLE objects ที่คุณต้องการสกัด  
2. วนลูปผ่าน shape ทั้งหมดในงานนำเสนอและเข้าถึง shape ประเภท [OLEObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/oleobjectframe)  
3. เข้าถึงข้อมูลของไฟล์ที่ฝังอยู่จาก OLE object frames และบันทึกลงดิสก์

โค้ด Java ด้านล่างแสดงวิธีสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็น OLE objects

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

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

### จะมีการเรนเดอร์เนื้อหา OLE เมื่อส่งออกสไลด์เป็น PDF/ภาพหรือไม่?

สิ่งที่ปรากฏบนสไลด์จะถูกเรนเดอร์ – ไอคอน/ภาพแทน (พรีวิว) เนื้อหา OLE แบบ “สด” จะไม่ถูกประมวลผลในขั้นตอนการเรนเดอร์ หากต้องการให้แสดงผลตามที่คาดไว้ใน PDF ให้ตั้งค่าภาพพรีวิวของคุณเอง

### จะล็อก OLE object บนสไลด์เพื่อไม่ให้ผู้ใช้ย้ายหรือแก้ไขใน PowerPoint ได้อย่างไร?

ล็อก shape: Aspose.Slides มีฟังก์ชันล็อกระดับ shape ซึ่งไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือการย้ายโดยไม่ได้ตั้งใจ

### ทำไม OLE object Excel ที่ลิงก์ไว้ถึง “กระโดด” หรือเปลี่ยนขนาดเมื่อเปิดงานนำเสนอ?

PowerPoint อาจรีเฟรชพรีวิวของ OLE ที่ลิงก์ไว้ เพื่อให้แสดงผลอย่างเสถียร ให้ทำตามแนวทางใน [Working Solution for Worksheet Resizing](/slides/th/androidjava/working-solution-for-worksheet-resizing/) – ปรับขนาดเฟรมให้พอดีกับช่วงข้อมูล หรือย่อส่วนข้อมูลให้พอดีกับเฟรมที่กำหนดและตั้งค่าภาพแทนที่เหมาะสม

### เส้นทางสัมพัทธ์ของ OLE objects ที่ลิงก์ไว้จะถูกรักษาไว้ในรูปแบบ PPTX หรือไม่?

ใน PPTX ไม่มีข้อมูล “เส้นทางสัมพัทธ์” – จะเก็บเป็นเส้นทางเต็มเท่านั้น เส้นทางสัมพัทธ์พบได้เฉพาะในรูปแบบ PPT เก่า สำหรับการพกพาแนะนำให้ใช้เส้นทางเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้หรือฝังไฟล์ไว้โดยตรง