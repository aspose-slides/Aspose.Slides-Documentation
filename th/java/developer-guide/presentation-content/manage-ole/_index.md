---
title: จัดการ OLE ในการนำเสนอโดยใช้ Java
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
- การนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการวัตถุ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java ฝัง ปรับปรุง และส่งออกเนื้อหา OLE อย่างราบรื่น"
---
## **บทนำ**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) คือเทคโนโลยีของ Microsoft ที่ช่วยให้ข้อมูลและวัตถุที่สร้างในแอปพลิเคชันหนึ่งสามารถวางไว้ในแอปพลิเคชันอื่นได้ผ่านการเชื่อมโยงหรือฝัง  

{{% /alert %}} 

ลองพิจารณากราฟที่สร้างใน MS Excel แล้ววางไว้ในสไลด์ PowerPoint กราฟ Excel นี้ถือเป็นวัตถุ OLE  

- วัตถุ OLE อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณดับเบิลคลิกที่ไอคอน กราฟจะเปิดในแอปพลิเคชันที่เกี่ยวข้อง (Excel) หรือคุณจะถูกถามให้เลือกแอปพลิเคชันเพื่อเปิดหรือแก้ไขวัตถุ
- วัตถุ OLE อาจแสดงเนื้อหาจริง เช่น เนื้อหาของกราฟ ในกรณีนี้กราฟจะทำงานใน PowerPoint อินเทอร์เฟซของกราฟจะโหลดและคุณสามารถแก้ไขข้อมูลของกราฟได้ภายใน PowerPoint  

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) อนุญาตให้คุณแทรก OLE Objects ลงในสไลด์เป็นกรอบวัตถุ OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame))

## **เพิ่มกรอบวัตถุ OLE ลงในสไลด์**

สมมติว่าคุณได้สร้างกราฟใน Microsoft Excel แล้วต้องการฝังมันลงในสไลด์เป็นกรอบวัตถุ OLE โดยใช้ Aspose.Slides for Java คุณทำได้ดังนี้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)  
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. อ่านไฟล์ Excel เป็นอาร์เรย์ไบต์  
1. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) ลงในสไลด์โดยใส่อาร์เรย์ไบต์และข้อมูลอื่น ๆ ของวัตถุ OLE  
1. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง เราได้เพิ่มกราฟจากไฟล์ Excel ลงในสไลด์เป็นกรอบวัตถุ OLE โดยใช้ Aspose.Slides for Java  
**Note** ว่า คอนสตรัคเตอร์ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) รับส่วนขยายของวัตถุที่สามารถฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ช่วยให้ PowerPoint ตีความประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดวัตถุ OLE นี้  

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// เตรียมข้อมูลสำหรับวัตถุ OLE.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **เพิ่มกรอบวัตถุ OLE ที่เชื่อมโยง**

Aspose.Slides for Java อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) โดยไม่ฝังข้อมูล แต่เพียงเชื่อมโยงไปยังไฟล์เท่านั้น  

โค้ด Java นี้แสดงวิธีการเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) ที่เชื่อมโยงกับไฟล์ Excel ลงในสไลด์:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มกรอบวัตถุ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **เข้าถึงกรอบวัตถุ OLE**

หากวัตถุ OLE ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถค้นหาและเข้าถึงได้โดยทำตามขั้นตอนต่อไปนี้  

1. โหลดพรีเซนเทชันที่มีวัตถุ OLE ฝังอยู่โดยการสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เข้าถึงรูปทรง [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)  
   ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมีรูปทรงเดียวบนสไลด์แรก แล้วเราจึง *cast* วัตถุนั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) นี่คือลูกกรอบวัตถุ OLE ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถทำการดำเนินการใด ๆ บนมันได้  

ในตัวอย่างด้านล่าง จะเข้าถึงกรอบวัตถุ OLE (วัตถุกราฟ Excel ที่ฝังในสไลด์) และข้อมูลไฟล์ของมัน  

``` java 
import com.aspose.slides.*;

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

### **เข้าถึงคุณสมบัติกรอบวัตถุ OLE ที่เชื่อมโยง**

Aspose.Slides อนุญาตให้คุณเข้าถึงคุณสมบัติของกรอบวัตถุ OLE ที่เชื่อมโยง  

โค้ด Java นี้แสดงวิธีตรวจสอบว่าวัตถุ OLE ถูกเชื่อมโยงหรือไม่และรับเส้นทางของไฟล์ที่เชื่อมโยง:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // ตรวจสอบว่าวัตถุ OLE ถูกเชื่อมโยงหรือไม่.
    if (oleFrame.isObjectLink()) {
        // พิมพ์เส้นทางเต็มของไฟล์ที่เชื่อมโยง.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // พิมพ์เส้นทางสัมพัทธ์ของไฟล์ที่เชื่อมโยงหากมี.
        // เฉพาะพรีเซนเทชัน PPT เท่านั้นที่สามารถบรรจุเส้นทางสัมพัทธ์ได้.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **เปลี่ยนแปลงข้อมูลวัตถุ OLE**

{{% alert color="info" title="Note" %}}

ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for Java](https://docs.aspose.com/cells/java/)  

{{% /alert %}}

หากวัตถุ OLE ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถเข้าถึงและแก้ไขข้อมูลของวัตถุนั้นได้โดยทำตามขั้นตอนต่อไปนี้  

1. โหลดพรีเซนเทชันที่มีวัตถุ OLE ฝังอยู่โดยการสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงรูปทรงกรอบวัตถุ OLE  
   ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมีรูปทรงเดียวบนสไลด์แรก แล้วเราจึง *cast* วัตถุนั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) นี่คือลูกกรอบวัตถุ OLE ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถทำการดำเนินการใด ๆ บนมันได้  
5. สร้างอ็อบเจ็กต์ `Workbook` และเข้าถึงข้อมูล OLE  
6. เข้าถึง `Worksheet` ที่ต้องการและปรับปรุงข้อมูล  
7. บันทึก `Workbook` ที่อัปเดตลงในสตรีม  
8. เปลี่ยนข้อมูลวัตถุ OLE จากสตรีม  

ในตัวอย่างด้านล่าง จะเข้าถึงกรอบวัตถุ OLE (วัตถุกราฟ Excel ที่ฝังในสไลด์) และแก้ไขข้อมูลไฟล์ของมันเพื่ออัปเดตข้อมูลกราฟ  

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

    // อ่านข้อมูลวัตถุ OLE เป็นอ็อบเจกต์ Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // แก้ไขข้อมูล workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // เปลี่ยนข้อมูลวัตถุของกรอบ OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ฝังไฟล์ประเภทอื่นในสไลด์**

นอกจากกราฟ Excel แล้ว Aspose.Slides for Java ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ เช่น HTML, PDF และ ZIP เมื่อผู้ใช้ดับเบิลคลิกวัตถุที่แทรกเข้าไป มันจะเปิดอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือผู้ใช้จะถูกขอให้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์นั้น  

โค้ด Java นี้แสดงวิธีการฝัง HTML และ ZIP ลงในสไลด์:  

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

## **กำหนดประเภทไฟล์สำหรับวัตถุที่ฝัง**

เมื่อทำงานกับพรีเซนเทชัน คุณอาจต้องการแทนที่วัตถุ OLE เก่าโดยวัตถุใหม่ หรือแทนที่วัตถุ OLE ที่ไม่รองรับด้วยวัตถุที่รองรับ Aspose.Slides for Java อนุญาตให้คุณกำหนดประเภทไฟล์สำหรับวัตถุที่ฝังไว้ เพื่ออัปเดตข้อมูลกรอบ OLE หรือส่วนขยายของมัน  

โค้ด Java นี้แสดงวิธีการกำหนดประเภทไฟล์สำหรับวัตถุ OLE ที่ฝังเป็น `zip`:  

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

## **ตั้งค่าภาพไอคอนและหัวเรื่องสำหรับวัตถุที่ฝัง**

หลังจากฝังวัตถุ OLE แล้ว ระบบจะเพิ่มตัวอย่างที่มีภาพไอคอนโดยอัตโนมัติ ตัวอย่างนี้คือสิ่งที่ผู้ใช้เห็นก่อนเข้าถึงหรือเปิดวัตถุ OLE หากต้องการใช้ภาพและข้อความเฉพาะเป็นองค์ประกอบของตัวอย่าง คุณสามารถตั้งค่าภาพไอคอนและหัวเรื่องได้โดยใช้ Aspose.Slides for Java  

โค้ด Java นี้แสดงวิธีการตั้งค่าภาพไอคอนและหัวเรื่องสำหรับวัตถุที่ฝัง:  

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// เพิ่มรูปภาพไปยังทรัพยากรของพรีเซนเทชัน.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **ป้องกันไม่ให้กรอบวัตถุ OLE ถูกปรับขนาดหรือเปลี่ยนตำแหน่ง**

หลังจากคุณเพิ่มวัตถุ OLE ที่เชื่อมโยงลงในสไลด์พรีเซนเทชัน เมื่อเปิดพรีเซนเทชันใน PowerPoint คุณอาจเห็นข้อความแจ้งให้คุณอัปเดตลิงก์ การคลิกปุ่ม “Update Links” อาจทำให้ขนาดและตำแหน่งของกรอบวัตถุ OLE เปลี่ยนแปลง เนื่องจาก PowerPoint อัปเดตข้อมูลจากวัตถุ OLE ที่เชื่อมโยงและรีเฟรชตัวอย่างวัตถุ เพื่อป้องกันไม่ให้ PowerPoint ขออัปเดตข้อมูลของวัตถุ ให้เรียกเมธอด [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) ของอินเทอร์เฟซ [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) ด้วยค่า `false`  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **สกัดไฟล์ที่ฝังอยู่**

Aspose.Slides for Java อนุญาตให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็น OLE Objects ได้ตามขั้นตอนต่อไปนี้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) ที่มีวัตถุ OLE ที่ต้องการสกัด  
2. วนลูปผ่านรูปทรงทั้งหมดในพรีเซนเทชันและเข้าถึงรูปทรง [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe)  
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจากกรอบวัตถุ OLE แล้วเขียนลงดิสก์  

โค้ด Java นี้แสดงวิธีสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็น OLE Objects:  

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

## **FAQ**

**OLE content จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?**  

สิ่งที่มองเห็นบนสไลด์จะถูกเรนเดอร์—ไอคอน/รูปภาพแทน (preview) เนื้อหา OLE แบบ “สด” จะไม่ถูกประมวลผลในระหว่างการเรนเดอร์ หากต้องการให้แสดงผลตามที่คาดไว้ใน PDF ให้ตั้งค่ารูปภาพตัวอย่างของคุณเอง  

หากต้องการเก็บไฟล์ที่ฝังเป็นไฟล์แนบใน PDF ให้เรียกเมธอด [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) ด้วยค่า `true` ตัวเลือกนี้ปิดอยู่เป็นค่าเริ่มต้น ดูตัวอย่างและวิธีตรวจสอบไฟล์แนบได้ที่ [Preserve Embedded OLE Files as PDF Attachments](/slides/th/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)  

**จะล็อกวัตถุ OLE บนสไลด์เพื่อไม่ให้ผู้ใช้ย้ายหรือแก้ไขใน PowerPoint อย่างไร?**  

ล็อกรูปทรง: Aspose.Slides มี [shape-level locks](/slides/th/java/applying-protection-to-presentation/) ซึ่งไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือย้ายโดยบังเอิญ  

**ทำไมวัตถุ Excel ที่เชื่อมโยงถึง “กระโดด” หรือเปลี่ยนขนาดเมื่อเปิดพรีเซนเทชัน?**  

PowerPoint อาจรีเฟรชตัวอย่างของ OLE ที่เชื่อมโยง เพื่อให้ได้รูปลักษณ์ที่เสถียรให้ทำตามแนวทางของ [Working Solution for Worksheet Resizing](/slides/th/java/working-solution-for-worksheet-resizing/) ไม่ว่าจะเป็นการปรับกรอบให้พอดีกับช่วงข้อมูล หรือสเกลช่วงให้พอดีกับกรอบที่กำหนดและตั้งค่าภาพแทนที่เหมาะสม  

**เส้นทางสัมพันธ์ของวัตถุ OLE ที่เชื่อมโยงจะถูกเก็บไว้ในรูปแบบ PPTX หรือไม่?**  

ใน PPTX ไม่มีข้อมูล “relative path”—มีเพียงเส้นทางเต็มเท่านั้น เส้นทางสัมพันธ์พบได้ในรูปแบบ PPT เก่า สำหรับความพกพา แนะนำให้ใช้เส้นทางแบบเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้หรือการฝังไฟล์แทน