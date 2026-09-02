---
title: จัดการคุณสมบัติการนำเสนอบน Android
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/androidjava/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติในตัว
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาการตรวจสอบ
- ภาษาปริยาย
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เชี่ยวชาญการจัดการคุณสมบัติการนำเสนอใน Aspose.Slides สำหรับ Android ผ่าน Java และทำให้การค้นหา การสร้างแบรนด์ และการทำงานเป็นกระบวนการราบรื่นในไฟล์ PowerPoint และ OpenDocument ของคุณ."
---
## **บทนำ**

Aspose.Slides รองรับประเภทของคุณสมบัติเบื้องต้นสองประเภท: **Built-in** และ **Custom**. ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ API ของ Aspose.Slides.

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติละเอียดของการนำเสนอผ่านอินเทอร์เฟซ [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties/) อินสแตนซ์ของอินเทอร์เฟซนี้จะถูกส่งคืนโดยเมธอด [Presentation.getDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" title="Note" %}}
โปรดทราบว่า ฟิลด์ **Application** และ **AppVersion** ไม่สามารถแก้ไขได้ Aspose.Slides จะเขียนทับฟิลด์เหล่านี้ทุกครั้งที่บันทึก ดังนั้นการนำเสนอที่บันทึกไว้จะรายงานชื่อผลิตภัณฑ์ Aspose.Slides และเวอร์ชันของไลบรารีที่สร้างมัน ค่าที่ส่งไปยัง `setNameOfApplication` จะถูกละเว้นเมื่อเขียนการนำเสนอ.
{{% /alert %}} 

## **คุณสมบัติของเอกสารใน PowerPoint**

Microsoft PowerPoint 2007 อนุญาตให้จัดการคุณสมบัติของเอกสารไฟล์การนำเสนอ คุณต้องทำเพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007 ตามที่แสดงด้านล่าง:

|**เลือกเมนู Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
หลังจากคุณเลือกเมนู **Advanced Properties** หน้าต่างจะปรากฏขึ้นเพื่อให้คุณจัดการคุณสมบัติของไฟล์ PowerPoint ตามที่แสดงในรูปด้านล่าง:

|**กล่องโต้ตอบคุณสมบัติ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
ใน **กล่องโต้ตอบคุณสมบัติ** ด้านบน คุณจะเห็นว่ามีแท็บหลายหน้าเช่น **General**, **Summary**, **Statistics**, **Contents** และ **Custom** แท็บเหล่านี้ช่วยให้กำหนดค่าข้อมูลประเภทต่าง ๆ ที่เกี่ยวข้องกับไฟล์ PowerPoint ได้ แท็บ **Custom** ใช้สำหรับจัดการคุณสมบัติที่กำหนดเองของไฟล์ PowerPoint.

การทำงานกับคุณสมบัติของเอกสารโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java

As we described earlier, Aspose.Slides สำหรับ Android ผ่าน Java รองรับคุณสมบัติของเอกสารสองประเภทคือ **Built-in** และ **Custom** ดังนั้นนักพัฒนาจึงสามารถเข้าถึงคุณสมบัติเช่นนี้ได้โดยใช้ API ของ Aspose.Slides สำหรับ Android ผ่าน Java Aspose.Slides สำหรับ Android ผ่าน Java มีคลาส [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties) ที่เป็นตัวแทนของคุณสมบัติเอกสารที่เชื่อมโยงกับไฟล์การนำเสนอผ่านคุณสมบัติ **Presentation.DocumentProperties**.

นักพัฒนาสามารถใช้คุณสมบัติ **IDocumentProperties** ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) เพื่อเข้าถึงคุณสมบัติของเอกสารไฟล์การนำเสนอได้ตามที่อธิบายด้านล่าง:

## **เข้าถึงคุณสมบัติ Built-in**

คุณสมบัติเหล่านี้ที่เปิดเผยโดยอ็อบเจ็กต์ [IDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties) มีดังนี้: **Creator** (ผู้เขียน), **Description**, **Keywords**, **Created** (วันที่สร้าง), **Modified** (วันที่แก้ไข), **Printed** (วันที่พิมพ์ครั้งล่าสุด), **LastModifiedBy**, **Keywords**, **SharedDoc** (แชร์ระหว่างผู้ผลิตต่าง ๆ?), **PresentationFormat**, **Subject** และ **Title**

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงการนำเสนอ
Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงถึงอ็อบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // แสดงคุณสมบัติที่มีในตัว
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

การแก้ไขคุณสมบัติ Built-in ของไฟล์การนำเรียกง่ายเท่ากับการเข้าถึงคุณสมบัติเหล่านั้น คุณสามารถกำหนดค่าแบบสตริงให้กับคุณสมบัติใดก็ได้ที่ต้องการและค่าของคุณสมบัตินั้นจะถูกแก้ไข ในตัวอย่างด้านล่าง เราได้แสดงวิธีการแก้ไขคุณสมบัติเอกสาร Built-in ของไฟล์การนำเสนอโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงถึงอ็อบเจ็กต์ IDocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // ตั้งค่าคุณสมบัติในตัว
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // บันทึกการนำเสนอของคุณลงในไฟล์
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติ Built-in ของการนำเสนอ ซึ่งสามารถดูได้ตามด้านล่าง:

|**คุณสมบัติเอกสาร Built-in หลังการแก้ไข**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **เพิ่มคุณสมบัติเอกสารแบบ Custom**

Aspose.Slides สำหรับ Android ผ่าน Java ยังอนุญาตให้นักพัฒนาเพิ่มค่าที่กำหนดเองสำหรับคุณสมบัติเอกสารของการนำเสนอ ตัวอย่างด้านล่างเพิ่มคุณสมบัติแบบ Custom สามรายการ จากนั้นค้นหาชื่อที่เก็บที่ดัชนี 2 และลบคุณสมบัตินั้น ดังนั้นการนำเสนอที่บันทึกจะเหลือสองรายการ คุณสมบัติแบบ Custom จะจัดทำดัชนีตามลำดับอักษร ไม่ตามลำดับที่เพิ่ม.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // การดึงคุณสมบัติเอกสาร
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // เพิ่มคุณสมบัติแบบ Custom
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // ดึงชื่อคุณสมบัติที่ตำแหน่งดัชนีเฉพาะ
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // ลบคุณสมบัติที่เลือก
    dProps.removeCustomProperty(getPropertyName);
    
    // บันทึกการนำเสนอ
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**คุณสมบัติเอกสาร Custom ที่เพิ่ม**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **เข้าถึงและแก้ไขคุณสมบัติ Custom**

Aspose.Slides สำหรับ Android ผ่าน Java ยังอนุญาตให้นักพัฒนาเข้าถึงค่าของคุณสมบัติ Custom ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติ Custom ทั้งหมดสำหรับการนำเสนอ.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // สร้างอ้างอิงถึงอ็อบเจ็กต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // เข้าถึงและแก้ไขคุณสมบัติแบบ Custom
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // แสดงชื่อและค่าของคุณสมบัติแบบ Custom
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // แก้ไขค่าของคุณสมบัติแบบ Custom
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // บันทึกการนำเสนอของคุณลงในไฟล์
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ตัวอย่างนี้แก้ไขคุณสมบัติ Custom ของการนำเสนอ [PPTX ](https://docs.fileformat.com/presentation/pptx/) รูปต่อไปนี้แสดงคุณสมบัติ Custom ของการนำเสนอ ก่อนและหลังการแก้ไข:

|**คุณสมบัติ Custom ก่อนการแก้ไข**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**คุณสมบัติ Custom หลังการแก้ไข**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **คุณสมบัติเอกสารขั้นสูง**

{{% alert color="info" title="Note" %}}
เพิ่มเมธอดใหม่ [ReadDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), และ [WriteBindedPresentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ไปยัง [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo) การตั้งค่าคุณสมบัติ [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) ได้ถูกเปลี่ยนแปลง.
{{% /alert %}} 

เมธอดใหม่สองอย่าง [ReadDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) และ [UpdateDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ถูกเพิ่มเข้าสู่อินเทอร์เฟซ [IPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentationInfo) พวกมันให้การเข้าถึงคุณสมบัติเอกสารอย่างรวดเร็วและอนุญาตให้เปลี่ยนและอัปเดตคุณสมบัติโดยไม่ต้องโหลดการนำเสนอทั้งหมด.

สถานการณ์ทั่วไปที่โหลดคุณสมบัติ, เปลี่ยนค่าบางอย่างและอัปเดตเอกสาร สามารถทำได้ตามวิธีต่อไปนี้:

```java
import com.aspose.slides.*;

// อ่านข้อมูลของการนำเสนอ
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

อีกวิธีหนึ่งคือใช้คุณสมบัติของการนำเสนอหนึ่งเป็นเทมเพลตเพื่ออัปเดตคุณสมบัติในการนำเสนออื่น ๆ:

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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

สามารถสร้างเทมเพลตใหม่ตั้งแต่ต้นแล้วใช้เพื่ออัปเดตการนำเสนอหลายไฟล์:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **ตั้งค่าภาษาการตรวจสอบ**

Aspose.Slides มีคุณสมบัติ LanguageId (เปิดเผยโดยคลาส PortionFormat) เพื่อให้คุณตั้งค่าภาษาการตรวจสอบสำหรับเอกสาร PowerPoint ภาษาการตรวจสอบคือภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint.

โค้ด Java นี้แสดงวิธีตั้งค่าภาษาการตรวจสอบสำหรับ PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

    portionFormat.setLanguageId("zh-CN"); // ตั้งค่า Id ของภาษาการตรวจสอบ

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าภาษาดีฟอลต์**

โค้ด Java นี้แสดงวิธีตั้งค่าภาษาดีฟอลต์สำหรับการนำเสนอ PowerPoint ทั้งหมด:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // เพิ่มรูปร่างสี่เหลี่ยมใหม่พร้อมข้อความ
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // ตรวจสอบภาษาของส่วนแรก
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตัวอย่างสด**

ลองแอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติของเอกสารผ่าน API ของ Aspose.Slides:

[![ดูและแก้ไขเมทาดาทา PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ Built-in จากการนำเสนอได้อย่างไร?**

คุณสมบัติ Built-in เป็นส่วนสำคัญของการนำเสนอและไม่สามารถลบออกได้อย่างสมบูรณ์ อย่างไรก็ตาม คุณสามารถเปลี่ยนค่า หรือกำหนดเป็นค่าว่างได้ หากคุณสมบัตินั้นอนุญาตให้ทำเช่นนั้น.

**ถ้าฉันเพิ่มคุณสมบัติ Custom ที่มีอยู่แล้วจะเกิดอะไรขึ้น?**

หากคุณเพิ่มคุณสมบัติ Custom ที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ.

**ฉันสามารถเข้าถึงคุณสมบัติของการนำเสนอโดยไม่ต้องโหลดการนำเสนอทั้งหมดได้ไหม?**

ได้ ใช้เมธอด [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) แล้วตามด้วย [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) เพื่ออ่านเมตาดาต้าเอกสารที่จัดเก็บโดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ดูตัวอย่างการสร้างรายงานแบบเต็มและข้อจำกัดของฟอร์แมตได้ที่ [Build a Lightweight Presentation Inventory](/slides/th/androidjava/examine-presentation/).