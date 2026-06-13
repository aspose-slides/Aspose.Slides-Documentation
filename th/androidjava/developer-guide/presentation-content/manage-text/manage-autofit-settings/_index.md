---
title: เพิ่มประสิทธิภาพการนำเสนอของคุณด้วย AutoFit บน Android
linktitle: การตั้งค่า Autofit
type: docs
weight: 30
url: /th/androidjava/manage-autofit-settings/
keywords:
- กล่องข้อความ
- ปรับอัตโนมัติ
- ไม่ปรับอัตโนมัติ
- ให้ข้อความพอดี
- ย่อข้อความ
- ตัดบรรทัดข้อความ
- ปรับขนาดรูปร่าง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการการตั้งค่า AutoFit ใน Aspose.Slides สำหรับ Android ผ่าน Java เพื่อเพิ่มประสิทธิภาพการแสดงผลข้อความใน PowerPoint และการนำเสนอ OpenDocument ของคุณและเพิ่มความอ่านง่ายของเนื้อหา"
---
## **บทนำ**

โดยค่าเริ่มต้นเมื่อคุณเพิ่มกล่องข้อความ Microsoft PowerPoint จะใช้การตั้งค่า **Resize shape to fix text** สำหรับกล่องข้อความ — มันจะปรับขนาดของกล่องข้อความโดยอัตโนมัติเพื่อให้ข้อความในนั้นพอดีเสมอ

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* เมื่อข้อความในกล่องข้อความยาวหรือใหญ่ขึ้น PowerPoint จะขยายขนาดของกล่องข้อความโดยเพิ่มความสูงเพื่อให้สามารถบรรจุข้อความได้มากขึ้น  
* เมื่อข้อความในกล่องข้อความสั้นหรือเล็กลง PowerPoint จะลดขนาดของกล่องข้อความโดยลดความสูงเพื่อกำจัดพื้นที่ที่เหลือใช้ไม่ได้  

ใน PowerPoint มีพารามิเตอร์หรือทางเลือกสำคัญ 4 อย่างที่ควบคุมพฤติกรรม Autofit ของกล่องข้อความ:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java มีตัวเลือกคล้ายกัน—บางคุณสมบัติภายใต้คลาส [TextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrameFormat)—ที่ให้คุณควบคุมพฤติกรรม Autofit ของกล่องข้อความในงานนำเสนอ

## **ปรับขนาดรูปให้พอดีกับข้อความ**

หากคุณต้องการให้ข้อความในกล่องพอดีกับกล่องเสมอหลังจากมีการแก้ไขข้อความ คุณต้องใช้ตัวเลือก **Resize shape to fix text** เพื่อระบุการตั้งค่านี้ ให้ตั้งค่าคุณสมบัติ [AutofitType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrameFormat)) เป็น `Shape`

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

โค้ด Java นี้แสดงวิธีระบุว่าข้อความต้องพอดีกับกล่องเสมอในงานนำเสนอ PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

หากข้อความยาวหรือใหญ่ขึ้น กล่องข้อความจะถูกปรับขนาดโดยอัตโนมัติ (เพิ่มความสูง) เพื่อให้ข้อความทั้งหมดพอดี หากข้อความสั้นลง จะทำในทางกลับกัน

## **Do Not Autofit**

หากคุณต้องการให้กล่องข้อความหรือรูปคงขนาดเดิมไม่ว่าข้อความจะมีการเปลี่ยนแปลงอย่างไร คุณต้องใช้ตัวเลือก **Do not Autofit** เพื่อระบุการตั้งค่านี้ ให้ตั้งค่าคุณสมบัติ [AutofitType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrameFormat)) เป็น `None`

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

โค้ด Java นี้แสดงวิธีระบุว่ากล่องข้อความต้องคงขนาดเดิมเสมอในงานนำเสนอ PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

เมื่อข้อความยาวเกินกว่ากล่อง ข้อความจะล้นออกมานอกกล่อง

## **Shrink Text on Overflow**

หากข้อความยาวเกินกว่ากล่อง คุณสามารถใช้ตัวเลือก **Shrink text on overflow** เพื่อระบุให้ขนาดและช่องว่างของข้อความถูกลดลงให้พอดีกับกล่องได้ เพื่อทำเช่นนี้ ให้ตั้งค่าคุณสมบัติ [AutofitType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrameFormat)) เป็น `Normal`

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

โค้ด Java นี้แสดงวิธีระบุว่าข้อความต้องย่อตอนล้นในงานนำเสนอ PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
เมื่อใช้ตัวเลือก **Shrink text on overflow** การตั้งค่าจะถูกนำมาใช้เฉพาะเมื่อข้อความยาวเกินกว่ากล่องเท่านั้น
{{% /alert %}}

## **Wrap Text**

หากคุณต้องการให้ข้อความในรูปตัดบรรทัดภายในรูปเมื่อข้อความเกินขอบของรูป (เฉพาะความกว้าง) คุณต้องใช้พารามิเตอร์ **Wrap text in shape** เพื่อระบุการตั้งค่านี้ ให้ตั้งค่าคุณสมบัติ [WrapText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TextFrameFormat)) เป็น `true`

โค้ด Java นี้แสดงวิธีใช้การตั้งค่า Wrap Text ในงานนำเสนอ PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
หากคุณตั้งค่าคุณสมบัติ `WrapText` เป็น `False` สำหรับรูป เมื่อข้อความภายในรูปยาวเกินกว่าความกว้างของรูป ข้อความจะขยายออกไปนอกขอบของรูปในบรรทัดเดียว
{{% /alert %}}

## **FAQ**

**ขอบเขตภายในของกรอบข้อความมีผลต่อ AutoFit หรือไม่?**  
ใช่ การเพิ่ม Padding (ขอบเขตภายใน) จะลดพื้นที่ใช้ได้สำหรับข้อความ ดังนั้น AutoFit จะทำงานเร็วขึ้นโดยการย่อฟอนต์หรือปรับขนาดรูปก่อน ตรวจสอบและปรับขอบเขตก่อนทำการจูน AutoFit

**AutoFit ทำงานอย่างไรกับการขึ้นบรรทัดใหม่แบบมือและแบบอ่อน?**  
การบังคับขึ้นบรรทัดจะคงอยู่ และ AutoFit จะปรับขนาดฟอนต์และระยะห่างรอบๆ ตามนั้น การลบบรรทัดที่ไม่จำเป็นมักช่วยลดความรุนแรงของการย่อข้อความโดย AutoFit

**การเปลี่ยนธีมฟอนต์หรือการทำให้ฟอนต์แทนที่มีผลต่อผลลัพธ์ของ AutoFit หรือไม่?**  
ใช่ การแทนที่ฟอนต์ด้วยฟอนต์ที่มีเมตริกซ์ต่างกันจะเปลี่ยนความกว้าง/ความสูงของข้อความ ซึ่งอาจทำให้ขนาดฟอนต์สุดท้ายและการตัดบรรทัดเปลี่ยนแปลง หลังจากเปลี่ยนฟอนต์ใด ๆ ควรตรวจสอบสไลด์อีกครั้ง