---
title: จัดการ OLE ในงานนำเสนอบน Android
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/androidjava/manage-ole/
keywords:
- วัตถุ OLE
- การเชื่อมโยงและฝังวัตถุ
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มวัตถุ
- ฝันวัตถุ
- เพิ่มไฟล์
- ฝังไฟล์
- วัตถุที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยน OLE
- ไอคอน OLE
- หัวข้อ OLE
- สกัด OLE
- สกัดวัตถุ
- สกัดไฟล์
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการวัตถุ OLE ใน PowerPoint และไฟล์ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. ฝัง, อัปเดตและส่งออกเนื้อหา OLE อย่างราบรื่น."
---
## **บทนำ**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) เป็นเทคโนโลยีของ Microsoft ที่อนุญาตให้ข้อมูลและวัตถุที่สร้างในแอปพลิเคชันหนึ่งถูกวางในแอปพลิเคชันอื่นผ่านการลิงก์หรือการฝัง  
{{% /alert %}} 

ลองพิจารณากราฟที่สร้างใน MS Excel กราฟนั้นจะถูกวางไว้ในสไลด์ของ PowerPoint กราฟ Excel นี้ถือเป็นวัตถุ OLE  

- วัตถุ OLE อาจปรากฏเป็นไอคอน ในกรณีนี้เมื่อคุณดับเบิลคลิกไอคอน กราฟจะเปิดในแอปพลิเคชันที่เชื่อมโยง (Excel) หรือคุณจะถูกขอให้เลือกแอปพลิเคชันเพื่อเปิดหรือแก้ไขวัตถุ  
- วัตถุ OLE อาจแสดงเนื้อหาจริงของมัน เช่น เนื้อหาของกราฟ ในกรณีนี้กราฟจะถูกเปิดใช้งานใน PowerPoint อินเทอร์เฟซของกราฟจะโหลดขึ้นและคุณสามารถแก้ไขข้อมูลของกราฟภายใน PowerPoint  

[Aspose.Slides สำหรับ Android ผ่าน Java](https://products.aspose.com/slides/androidjava/) ทำให้คุณสามารถแทรกวัตถุ OLE ลงในสไลด์เป็นกรอบวัตถุ OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **เพิ่มกรอบวัตถุ OLE ลงในสไลด์**

Assuming you have already created a chart in Microsoft Excel and want to embed it in a slide as an OLE object frame using Aspose.Slides for Android via Java, you can do it this way:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)  
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
1. อ่านไฟล์ Excel เป็นอาร์เรย์ไบต์  
1. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) ลงในสไลด์โดยใส่อาร์เรย์ไบต์และข้อมูลอื่น ๆ ของวัตถุ OLE  
1. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง เราได้เพิ่มกราฟจากไฟล์ Excel ลงในสไลด์เป็นกรอบวัตถุ OLE โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java.  
**หมายเหตุ** ว่า constructor ของ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) รับส่วนขยายของวัตถุที่สามารถฝังได้เป็นพารามิเตอร์ที่สอง ส่วนขยายนี้ทำให้ PowerPoint สามารถตีความประเภทไฟล์ได้อย่างถูกต้องและเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดวัตถุ OLE นี้.

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

### **เพิ่มกรอบวัตถุ OLE ที่เชื่อมโยง**

Aspose.Slides สำหรับ Androidผ่าน Java อนุญาตให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) โดยไม่ฝังข้อมูล แต่เพียงแค่ลิงก์ไปยังไฟล์  

This Java code shows you how to add an [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) with a linked Excel file to a slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// เพิ่มกรอบวัตถุ OLE ที่เชื่อมโยงไฟล์ Excel.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **เข้าถึงกรอบวัตถุ OLE**

If an OLE object is already embedded in a slide, you can easily find or access it this way:

1. โหลดพรีเซนเทชันที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
3. เข้าถึงรูปร่าง [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่สร้างไว้ก่อนซึ่งมีรูปร่างเดียวบนสไลด์แรก จากนั้นเราจะ *cast* วัตถุนั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). นี่คือกรอบวัตถุ OLE ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถทำการดำเนินการใด ๆ กับมันได้  

In the example below, an OLE object frame (an Excel chart object embedded in a slide) and its file data are accessed.

```java 
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

Aspose.Slides allows you to access linked OLE object frame properties.  

This Java code shows you how to check if an OLE object is linked and then obtain the path to the linked file:

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
        // เฉพาะไฟล์พรีเซนเทชัน PPT เท่านั้นที่สามารถมีเส้นทางสัมพัทธ์ได้.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **เปลี่ยนข้อมูลวัตถุ OLE**

{{% alert color="info" title="Note" %}}
ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/)  
{{% /alert %}}

If an OLE object is already embedded in a slide, you can easily access that object and modify its data this way:

1. โหลดพรีเซนเทชันที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงรูปร่างกรอบวัตถุ OLE. ในตัวอย่างของเรา เราใช้ไฟล์ PPTX ที่สร้างไว้ก่อนซึ่งมีรูปร่างหนึ่งบนสไลด์แรก เราจะ *cast* วัตถุนั้นเป็น [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). นี่คือกรอบวัตถุ OLE ที่ต้องการเข้าถึง  
4. เมื่อเข้าถึงกรอบวัตถุ OLE แล้ว คุณสามารถทำการดำเนินการใด ๆ กับมันได้  
5. สร้างอ็อบเจกต์ `Workbook` และเข้าถึงข้อมูล OLE  
6. เข้าถึง `Worksheet` ที่ต้องการและแก้ไขข้อมูล  
7. บันทึก `Workbook` ที่อัปเดตลงในสตรีม  
8. เปลี่ยนข้อมูลวัตถุ OLE จากสตรีม  

In the example below, an OLE object frame (an Excel chart object embedded in a slide) is accessed, and its file data is modified to update the chart data.

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

## **ฝังประเภทไฟล์อื่นลงในสไลด์**

นอกจากกราฟ Excel แล้ว Aspose.Slides สำหรับ Androidผ่าน Java ยังอนุญาตให้คุณฝังไฟล์ประเภทอื่นลงในสไลด์ได้ ตัวอย่างเช่น คุณสามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นวัตถุ เมื่อผู้ใช้ดับเบิลคลิกวัตถุที่แทรกไว้ มันจะเปิดโดยอัตโนมัติในโปรแกรมที่เกี่ยวข้อง หรือผู้ใช้จะถูกขอให้เลือกโปรแกรมที่เหมาะสมเพื่อเปิดไฟล์นั้น  

This Java code shows you how to embed HTML and ZIP into a slide:

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

## **ตั้งค่าชนิดไฟล์สำหรับวัตถุที่ฝังอยู่**

When working with presentations, you may need to replace old OLE objects with new ones or replace an unsupported OLE object with a supported one. Aspose.Slides for Android via Java allows you to set the file type for an embedded object, enabling you to update the OLE frame data or its extension.  

This Java code shows you how to set the file type for an embedded OLE object to `zip`:

```java
import com.aspose.slides.*;

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

## **ตั้งค่าภาพไอคอนและหัวเรื่องสำหรับวัตถุที่ฝังอยู่**

After embedding an OLE object, a preview consisting of an icon image is added automatically. This preview is what users see before accessing or opening the OLE object. If you want to use a specific image and text as elements in the preview, you can set the icon image and title using Aspose.Slides for Android via Java.  

This Java code shows you how to set the icon image and title for an embedded object:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// เพิ่มรูปภาพไปยังทรัพยากรของพรีเซนเทชัน.
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

## **ป้องกันไม่ให้กรอบวัตถุ OLE ถูกปรับขนาดและย้ายตำแหน่ง**

After you add a linked OLE object to a presentation slide, when you open the presentation in PowerPoint, you might see a message asking you to update the links. Clicking the "Update Links" button may change the size and position of the OLE object frame because PowerPoint updates the data from the linked OLE object and refreshes the object preview. To prevent PowerPoint from prompting to update the object's data, call the [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) method of the [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) interface with `false`:

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

Aspose.Slides for Android via Java allows you to extract the files embedded in slides as OLE objects this way:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) ที่มีวัตถุ OLE ที่ต้องการสกัด  
2. วนลูปผ่านรูปร่างทั้งหมดในพรีเซนเทชันและเข้าถึงรูปร่าง [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe)  
3. เข้าถึงข้อมูลของไฟล์ที่ฝังจากกรอบวัตถุ OLE และเขียนลงดิสก์  

This Java code shows you how to extract files embedded in a slide as OLE objects:

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

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/ภาพหรือไม่?**

สิ่งที่ปรากฏบนสไลด์จะถูกเรนเดอร์ — ไอคอน/ภาพตัวแทน (preview) เนื้อหา OLE ที่เป็น “สด” จะไม่ถูกประมวลผลระหว่างการเรนเดอร์ หากต้องการให้แน่ใจว่าปรากฏตามที่คาดไว้ใน PDF ให้ตั้งค่าภาพพรีวิวของคุณเอง  

เพื่อให้ไฟล์ที่ฝังอยู่ยังคงเป็นไฟล์แนบใน PDF ให้เรียก [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) ด้วยค่า `true`. ตัวเลือกนี้ปิดการทำงานตามค่าเริ่มต้น สำหรับตัวอย่างและวิธีตรวจสอบไฟล์แนบ ดูที่ [Preserve Embedded OLE Files as PDF Attachments](/slides/th/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**ทำอย่างไรจึงจะล็อกวัตถุ OLE บนสไลด์เพื่อไม่ให้ผู้ใช้ย้าย/แก้ไขได้ใน PowerPoint?**

ล็อกรูปร่าง: Aspose.Slides มีการล็อกระดับรูปร่าง ไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือการย้ายโดยไม่ได้ตั้งใจ

**ทำไมวัตถุ Excel ที่เชื่อมโยงถึง “กระโดด” หรือเปลี่ยนขนาดเมื่อเปิดพรีเซนเทชัน?**

PowerPoint อาจรีเฟรชพรีวิวของ OLE ที่เชื่อมโยง เพื่อให้แสดงผลคงที่ ให้ทำตามแนวทาง [Working Solution for Worksheet Resizing](/slides/th/androidjava/working-solution-for-worksheet-resizing/) — ปรับกรอบให้พอดีกับช่วงข้อมูล หรือสเกลช่วงให้เข้ากับกรอบคงที่และตั้งค่าภาพแทนที่เหมาะสม

**เส้นทางสัมพัทธ์ของวัตถุ OLE ที่เชื่อมโยงจะถูกรักษาไว้ในรูปแบบ PPTX หรือไม่?**

ใน PPTX ข้อมูล “เส้นทางสัมพัทธ์” จะไม่พร้อมใช้งาน — มีเพียงเส้นทางเต็มเท่านั้น เส้นทางสัมพัทธ์พบได้ในรูปแบบไฟล์ PPT เก่า สำหรับการพกพา ควรใช้เส้นทางเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้หรือฝังไฟล์ไว้โดยตรง.