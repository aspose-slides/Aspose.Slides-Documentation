---
title: จัดการคุณสมบัตินำเสนอใน Java
linktitle: คุณสมบัตินำเสนอ
type: docs
weight: 70
url: /th/java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัตินำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติมาตรฐาน
- คุณสมบัติกำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาตรวจสอบการพิสูจน์
- ภาษาปริยาย
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมคุณสมบัตินำเสนอใน Aspose.Slides for Java และทำให้การค้นหา, การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นไปอย่างมีประสิทธิภาพ"
---
## **บทนำ**

Aspose.Slides รองรับสองประเภทของคุณสมบัติเอกสาร: **Built-in** และ **Custom**. ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ Aspose.Slides API.

Aspose.Slides ช่วยให้คุณทำงานกับคุณสมบัติเอกสารของงานนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties/) อินเทอร์เฟซ ตัวอย่างของอินเทอร์เฟซนี้จะถูกส่งคืนโดยเมธอด [Presentation.getDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getDocumentProperties--) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไขและจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" %}} 
โปรดทราบว่า ฟิลด์ **Application** และ **AppVersion** ไม่สามารถแก้ไขได้ Aspose.Slides จะเขียนทับฟิลด์เหล่านี้ทุกครั้งที่บันทึก ดังนั้นงานนำเสนอที่บันทึกแล้วจะรายงานว่า "Aspose.Slides for Java" และเวอร์ชันของไลบรารีที่สร้างมัน ค่าที่ส่งไปยัง `setNameOfApplication` จะถูกละทิ้งเมื่อเขียนงานนำเสนอ
{{% /alert %}} 

## **คุณสมบัติเอกสารใน PowerPoint**

Microsoft PowerPoint 2007 อนุญาตให้จัดการคุณสมบัติเอกสารของไฟล์งานนำเสนอ คุณต้องทำเพียงคลิกที่ไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 ตามที่แสดงด้านล่าง:

|**เลือกเมนู Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

หลังจากคุณเลือกเมนู **Advanced Properties** จะปรากฏหน้าต่างที่ให้คุณจัดการคุณสมบัติเอกสารของไฟล์ PowerPoint ตามที่แสดงในรูปด้านล่าง:

|**หน้าต่าง Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

ใน **หน้าต่าง Properties** ด้านบนคุณจะเห็นว่ามีหลายแท็บเช่น **General**, **Summary**, **Statistics**, **Contents** และ **Custom** แท็บเหล่านี้ช่วยให้กำหนดค่าข้อมูลประเภทต่างๆ ที่เกี่ยวข้องกับไฟล์ PowerPoint ได้ แท็บ **Custom** ใช้สำหรับจัดการคุณสมบัติแบบกำหนดเองของไฟล์ PowerPoint

ทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides for Java

ดังที่เราอธิบายไว้ก่อนหน้านี้ว่า Aspose.Slides for Java รองรับสองประเภทของคุณสมบัติเอกสาร คือคุณสมบัติ **Built-in** และ **Custom** ดังนั้นนักพัฒนาสามารถเข้าถึงทั้งสองประเภทโดยใช้ Aspose.Slides for Java API Aspose.Slides for Java มีคลาส [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties) ที่แสดงคุณสมบัติเอกสารที่เชื่อมโยงกับไฟล์งานนำเสนอผ่านคุณสมบัติ **Presentation.DocumentProperties**.

นักพัฒนาสามารถใช้คุณสมบัติ **IDocumentProperties** ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติเอกสารของไฟล์งานนำเสนอได้ตามที่อธิบายด้านล่าง:

## **เข้าถึงคุณสมบัติ Built-in**

คุณสมบัติเหล่านี้ที่เปิดเผยโดยอ็อบเจกต์ [IDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties) ประกอบด้วย: **Creator** (ผู้เขียน), **Description**, **Keywords**, **Created** (วันที่สร้าง), **Modified** (วันที่แก้ไข), **Printed** (วันที่พิมพ์ครั้งล่าสุด), **LastModifiedBy**, **Keywords**, **SharedDoc** (แชร์ระหว่างผู้ผลิตต่างๆ?), **PresentationFormat**, **Subject** และ **Title**

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงการนำเสนอ
Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างออปเจ็กต์อ้างอิงถึง IDocumentProperties ที่เชื่อมโยงกับการนำเสนอ
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // แสดงคุณสมบัติ built-in
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **แก้ไขคุณสมบัติ Built-in**

การแก้ไขคุณสมบัติ Built-in ของไฟล์งานนำเสนอง่ายเท่ากับการเข้าถึงคุณสมบัตินั้น คุณสามารถกำหนดค่าข้อความให้กับคุณสมบัติใดก็ได้ที่ต้องการและค่าของคุณสมบัตินั้นจะถูกแก้ไข ในตัวอย่างด้านล่างเราจะแสดงวิธีการแก้ไขคุณสมบัติเอกสาร Built-in ของไฟล์งานนำเสนอโดยใช้ Aspose.Slides for Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างออปเจ็กต์อ้างอิงถึง IDocumentProperties ที่เชื่อมโยงกับการนำเสนอ
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // กำหนดคุณสมบัติ built-in
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // บันทึกงานนำเสนอของคุณลงไฟล์
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้จะแก้ไขคุณสมบัติ Built-in ของงานนำเสนอซึ่งสามารถดูได้ตามด้านล่าง:

|**คุณสมบัติเอกสาร Built-in หลังการแก้ไข**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **เพิ่มคุณสมบัติเอกสารแบบกำหนดเอง**

Aspose.Slides for Java ยังอนุญาตให้ผู้พัฒนาสามารถเพิ่มค่าที่กำหนดเองสำหรับคุณสมบัติเอกสารของงานนำเสนอ ตัวอย่างด้านล่างเพิ่มคุณสมบัติแบบกำหนดเองสามรายการ จากนั้นค้นหาชื่อที่จัดเก็บในดัชนี 2 และลบคุณสมบัตินั้นออก ดังนั้นงานนำเสนอที่บันทึกไว้จะเหลือสองรายการ คุณสมบัติแบบกำหนดเองจะถูกจัดเรียงตามตัวอักษร ไม่ใช่ตามลำดับการเพิ่ม

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // รับคุณสมบัติเอกสาร
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // เพิ่มคุณสมบัติกำหนดเอง
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // รับชื่อคุณสมบัติที่ตำแหน่งดัชนีเฉพาะ
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // ลบคุณสมบัติที่เลือก
    dProps.removeCustomProperty(getPropertyName);
    
    // บันทึกงานนำเสนอ
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**เพิ่มคุณสมบัติเอกสารแบบกำหนดเอง**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง**

Aspose.Slides for Java ยังอนุญาตให้ผู้พัฒนาสามารถเข้าถึงค่าของคุณสมบัติแบบกำหนดเอง ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติเหล่านี้ทั้งหมดสำหรับงานนำเสนอหนึ่งชุด

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างออปเจ็กต์อ้างอิงถึง DocumentProperties ที่เชื่อมโยงกับการนำเสนอ
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // เข้าถึงและแก้ไขคุณสมบัติกำหนดเอง
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // แสดงชื่อและค่าของคุณสมบัติกำหนดเอง
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // แก้ไขค่าของคุณสมบัติกำหนดเอง
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // บันทึกงานนำเสนอของคุณลงไฟล์
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติแบบกำหนดเองของงานนำเสนอ [PPTX ](https://docs.fileformat.com/presentation/pptx/) รูปต่อไปนี้แสดงคุณสมบัติแบบกำหนดเองของงานนำเสนอก่อนและหลังการแก้ไข:

|**คุณสมบัติแบบกำหนดเองก่อนการแก้ไข**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**คุณสมบัติแบบกำหนดเองหลังการแก้ไข**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **คุณสมบัติเอกสารขั้นสูง**

{{% alert color="info" %}} 

มีเมธอดใหม่ [ReadDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), และ [WriteBindedPresentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ถูกเพิ่มไปยังอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo) โดยตรรกะของตัวตั้งค่า [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ได้ถูกเปลี่ยนแปลง

{{% /alert %}} 

เมธอดใหม่สองตัว [ReadDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) และ [UpdateDocumentProperties](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ได้ถูกเพิ่มเข้าไปในอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPPresentationInfo) พวกมันให้การเข้าถึงคุณสมบัติเอกสารอย่างรวดเร็วและอนุญาตให้เปลี่ยนแปลงและอัปเดตคุณสมบัติได้โดยไม่ต้องโหลดงานนำเสนอทั้งหมด

สถานการณ์ทั่วไปคือโหลดคุณสมบัติ, เปลี่ยนค่าแล้วอัปเดตเอกสาร ซึ่งสามารถทำได้ตามวิธีต่อไปนี้:

```java
import com.aspose.slides.*;

// อ่านข้อมูลของงานนำเสนอ
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// ดึงคุณสมบัติปัจจุบัน
IDocumentProperties props = info.readDocumentProperties();

// ตั้งค่าข้อมูลใหม่ของฟิลด์ Author และ Title
props.setAuthor("New Author");
props.setTitle("New Title");

// อัปเดตงานนำเสนอด้วยค่าใหม่
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

อีกวิธีหนึ่งคือใช้คุณสมบัติของงานนำเสนอหนึ่งเป็นแม่แบบเพื่ออัปเดตคุณสมบัติในงานนำเสนออื่น ๆ:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

สามารถสร้างแม่แบบใหม่จากศูนย์แล้วใช้เพื่ออัปเดตหลายงานนำเสนอ:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **กำหนดภาษาตรวจสอบการพิสูจน์**

Aspose.Slides มีคุณสมบัติ LanguageId (เปิดเผยโดยคลาส PortionFormat) เพื่อให้คุณตั้งค่าภาษาตรวจสอบการพิสูจน์สำหรับเอกสาร PowerPoint ได้ ภาษาตรวจสอบการพิสูจน์คือภาษาที่จะทำการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint

โค้ด Java นี้แสดงวิธีการตั้งค่าภาษาตรวจสอบการพิสูจน์สำหรับ PowerPoint:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // ตั้งค่า Id ของภาษาตรวจสอบการพิสูจน์

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **กำหนดภาษาปริยาย**

โค้ด Java นี้แสดงวิธีตั้งค่าภาษาปริยายสำหรับงานนำเสนอ PowerPoint ทั้งหมด:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // เพิ่มรูปสี่เหลี่ยมใหม่พร้อมข้อความ
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // ตรวจสอบภาษาของส่วนแรก
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตัวอย่างสด**

ลองแอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารผ่าน Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## ***คำถามที่พบบ่อย**

### ฉันจะลบคุณสมบัติ Built-in จากงานนำเสนอได้อย่างไร?

คุณสมบัติ Built-in เป็นส่วนสำคัญของงานนำเสนอและไม่สามารถลบออกได้อย่างสมบูรณ์ อย่างไรก็ตามคุณสามารถเปลี่ยนค่าได้หรือกำหนดให้เป็นค่าว่างถ้าคุณสมบัตินั้นอนุญาต

### จะเกิดอะไรขึ้นถ้าฉันเพิ่มคุณสมบัติแบบกำหนดเองที่มีอยู่แล้ว?

หากคุณเพิ่มคุณสมบัติแบบกำหนดเองที่มีอยู่แล้ว ค่าเดิมจะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เพราะ Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

### ฉันสามารถเข้าถึงคุณสมบัติของงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบได้หรือไม่?

ได้ คุณสามารถเข้าถึงคุณสมบัติของงานนำเสนอโดยไม่ต้องโหลดเต็มโดยใช้เมธอด `getPresentationInfo` จากคลาส [PresentationFactory](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/) จากนั้นใช้เมธอด `readDocumentProperties` ของอินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationinfo/) เพื่ออ่านคุณสมบัติอย่างมีประสิทธิภาพ ช่วยประหยัดหน่วยความจำและปรับปรุงประสิทธิภาพ