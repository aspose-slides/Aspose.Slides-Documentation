---
title: สร้างตัวดูพรีเซนเทชันบน Android
linktitle: ตัวดูพรีเซนเทชัน
type: docs
weight: 50
url: /th/androidjava/presentation-viewer/
keywords:
- ดูพรีเซนเทชัน
- ตัวดูพรีเซนเทชัน
- สร้างตัวดูพรีเซนเทชัน
- ดู PPT
- ดู PPTX
- ดู ODP
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: สร้างตัวดูพรีเซนเทชันแบบกำหนดเองใน Java ด้วย Aspose.Slides สำหรับ Android แสดงไฟล์ PowerPoint และ OpenDocument อย่างง่ายโดยไม่ต้องใช้ Microsoft PowerPoint.
---
## **บทนำ**

Aspose.Slides สำหรับ Android ผ่าน Java ใช้ในการสร้างไฟล์พรีเซนเทชันที่มีสไลด์ สไลด์เหล่านี้สามารถดูได้โดยเปิดพรีเซนเทชันใน Microsoft PowerPoint ตัวอย่างเช่น อย่างไรก็ตาม บางครั้งนักพัฒนาอาจต้องการดูสไลด์เป็นรูปภาพในโปรแกรมดูรูปภาพที่ต้องการหรือสร้างตัวดูพรีเซนเทชันของตนเอง ในกรณีเช่นนั้น Aspose.Slides อนุญาตให้คุณส่งออกสไลด์เดี่ยวเป็นรูปภาพ บทความนี้อธิบายวิธีทำ

## **สร้างภาพ SVG จากสไลด์**

เพื่อสร้างภาพ SVG จากสไลด์พรีเซนเทชันด้วย Aspose.Slides โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) .
2. รับอ้างอิงสไลด์ตามดัชนีของมัน.
3. เปิดสตรีมไฟล์.
4. บันทึกสไลด์เป็นภาพ SVG ไปยังสตรีมไฟล์.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **สร้าง SVG พร้อม ID ของรูปร่างที่กำหนดเอง**

Aspose.Slides สามารถใช้เพื่อสร้าง [SVG](https://docs.fileformat.com/page-description-language/svg/) จากสไลด์พร้อม ID ของรูปร่างที่กำหนดเอง ได้โดยการใช้เมธอด `setId` จาก [ISvgShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgshape/) `CustomSvgShapeFormattingController` สามารถใช้เพื่อกำหนดค่า ID ของรูปร่างได้.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **สร้างภาพย่อของสไลด์**

Aspose.Slides ช่วยให้คุณสร้างภาพย่อของสไลด์ได้ เพื่อสร้างภาพย่อของสไลด์โดยใช้ Aspose.Slides โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) .
2. รับอ้างอิงสไลด์ตามดัชนีของมัน.
3. รับภาพย่อของสไลด์ที่อ้างอิงด้วยสเกลที่กำหนด.
4. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใด ๆ

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **สร้างภาพย่อของสไลด์ด้วยขนาดที่กำหนดโดยผู้ใช้**

เพื่อสร้างภาพย่อของสไลด์ด้วยขนาดที่กำหนดโดยผู้ใช้ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) .
2. รับอ้างอิงสไลด์ตามดัชนีของมัน.
3. รับภาพย่อของสไลด์ที่อ้างอิงด้วยขนาดที่กำหนด.
4. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใด ๆ

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **สร้างภาพย่อของสไลด์พร้อมบันทึกผู้พูด**

เพื่อสร้างภาพย่อของสไลด์พร้อมบันทึกผู้พูดโดยใช้ Aspose.Slides โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [RenderingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/renderingoptions/) .
2. ใช้เมธอด `RenderingOptions.setSlidesLayoutOptions` เพื่อกำหนดตำแหน่งของบันทึกผู้พูด.
3. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) .
4. รับอ้างอิงสไลด์ตามดัชนีของมัน.
5. รับภาพย่อของสไลด์ที่อ้างอิงด้วยตัวเลือกการเรนเดอร์.
6. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใด ๆ

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **ตัวอย่างสด**

คุณสามารถลองแอปฟรี [**Aspose.Slides Viewer**](https://products.aspose.app/slides/th/viewer/) เพื่อดูว่าคุณสามารถนำไปใช้งานกับ Aspose.Slides API อย่างไร:

![ตัวดู PowerPoint ออนไลน์](online-PowerPoint-viewer.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถฝังตัวดูพรีเซนเทชันในเว็บแอปพลิเคชันได้หรือไม่?**

ได้ คุณสามารถใช้ Aspose.Slides บนเซิร์ฟเวอร์เพื่อเรนเดอร์สไลด์เป็นภาพหรือ HTML และแสดงผลในเบราว์เซอร์ คุณสามารถทำการนำทางและซูมด้วย JavaScript เพื่อสร้างประสบการณ์ที่โต้ตอบได้

**วิธีที่ดีที่สุดในการแสดงสไลด์ภายในตัวดูแบบกำหนดเองคืออะไร?**

แนะนำให้เรนเดอร์แต่ละสไลด์เป็นภาพ (เช่น PNG หรือ SVG) หรือแปลงเป็น HTML ด้วย Aspose.Slides แล้วแสดงผลลัพธ์ภายในกล่องรูปภาพ (สำหรับเดสก์ท็อป) หรือคอนเทนเนอร์ HTML (สำหรับเว็บ)

**ฉันจะจัดการพรีเซนเทชันขนาดใหญ่ที่มีสไลด์จำนวนมากอย่างไร?**

สำหรับพรีเซนเทชันขนาดใหญ่ ควรใช้การโหลดแบบ lazy‑loading หรือการเรนเดอร์ตามความต้องการของสไลด์ ซึ่งหมายความว่าจะสร้างเนื้อหาของสไลด์เฉพาะเมื่อผู้ใช้เลื่อนไปยังสไลด์นั้น เพื่อลดการใช้หน่วยความจำและเวลาการโหลด.