---
title: สร้างตัวชมการนำเสนอใน Java
linktitle: ตัวชมการนำเสนอ
type: docs
weight: 50
url: /th/java/presentation-viewer/
keywords:
- ดูการนำเสนอ
- ตัวชมการนำเสนอ
- สร้างตัวชมการนำเสนอ
- ดู PPT
- ดู PPTX
- ดู ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างตัวชมการนำเสนอที่กำหนดเองใน Java ด้วย Aspose.Slides. แสดงไฟล์ PowerPoint และ OpenDocument ได้อย่างง่ายดายโดยไม่ต้องใช้ Microsoft PowerPoint."
---
## **บทนำ**

Aspose.Slides for Java ใช้เพื่อสร้างไฟล์การนำเสนอที่มีสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดการนำเสนอใน Microsoft PowerPoint เป็นต้น อย่างไรก็ตาม บางครั้งนักพัฒนาอาจต้องการดูสไลด์เป็นรูปภาพในโปรแกรมดูรูปภาพที่ตัวเองชอบหรือสร้างตัวชมการนำเสนอของตนเอง ในกรณีเช่นนั้น Aspose.Slides อนุญาตให้คุณส่งออกสไลด์แต่ละสไลด์เป็นรูปภาพ บทความนี้อธิบายวิธีทำ

## **สร้างภาพ SVG จากสไลด์**

เพื่อสร้างภาพ SVG จากสไลด์การนำเสนอด้วย Aspose.Slides โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. รับการอ้างอิงสไลด์ตามดัชนี
3. เปิดสตรีมไฟล์
4. บันทึกสไลด์เป็นภาพ SVG ลงในสตรีมไฟล์

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **สร้าง SVG ด้วย ID รูปร่างที่กำหนดเอง**

Aspose.Slides สามารถใช้เพื่อสร้าง [SVG](https://docs.fileformat.com/page-description-language/svg/) จากสไลด์ด้วย ID ของรูปร่างที่กำหนดเองได้。ในการทำเช่นนี้ ใช้วิธี `setId` จาก [ISvgShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgshape/)。 `CustomSvgShapeFormattingController` สามารถใช้เพื่อกำหนด ID ของรูปร่าง

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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **สร้างภาพย่อของสไลด์**

Aspose.Slides ช่วยคุณสร้างภาพย่อของสไลด์ เพื่อสร้างภาพย่อของสไลด์โดยใช้ Aspose.Slides โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. รับการอ้างอิงสไลด์ตามดัชนี
3. รับภาพย่อของสไลด์ที่อ้างอิงที่อัตราส่วนขนาดที่กำหนด
4. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใดก็ได้

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

## **สร้างภาพย่อสไลด์ด้วยมิติที่กำหนดโดยผู้ใช้**

เพื่อสร้างภาพย่อของสไลด์ด้วยมิติที่กำหนดโดยผู้ใช้ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. รับการอ้างอิงสไลด์ตามดัชนี
3. รับภาพย่อของสไลด์ที่อ้างอิงด้วยมิติที่กำหนด
4. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใดก็ได้

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **สร้างภาพย่อของสไลด์พร้อมบันทึกผู้บรรยาย**

เพื่อสร้างภาพย่อของสไลด์พร้อมบันทึกผู้บรรยายโดยใช้ Aspose.Slides โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [RenderingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/renderingoptions/)
2. ใช้เมธอด `RenderingOptions.setSlidesLayoutOptions` เพื่อตั้งตำแหน่งของบันทึกผู้บรรยาย
3. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
4. รับการอ้างอิงสไลด์ตามดัชนี
5. รับภาพย่อของสไลด์ที่อ้างอิงด้วยตัวเลือกการเรนเดอร์
6. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใดก็ได้

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

คุณสามารถลองแอปฟรี [**Aspose.Slides Viewer**](https://products.aspose.app/slides/th/viewer/) เพื่อดูว่าคุณสามารถนำ Aspose.Slides API ไปใช้ทำอะไรได้บ้าง:

![ตัวชม PowerPoint ออนไลน์](online-PowerPoint-viewer.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถฝังตัวชมการนำเสนอในเว็บแอปพลิเคชันได้ไหม?**

ใช่ คุณสามารถใช้ Aspose.Slides บนเซิร์ฟเวอร์เพื่อเรนเดอร์สไลด์เป็นรูปภาพหรือ HTML แล้วแสดงในเบราว์เซอร์ คุณลักษณะการนำทางและการซูมสามารถทำได้ด้วย JavaScript เพื่อประสบการณ์แบบโต้ตอบ

**วิธีที่ดีที่สุดในการแสดงสไลด์ภายในตัวชมแบบกำหนดเองคืออะไร?**

วิธีที่แนะนำคือเรนเดอร์แต่ละสไลด์เป็นรูปภาพ (เช่น PNG หรือ SVG) หรือแปลงเป็น HTML ด้วย Aspose.Slides แล้วแสดงผลลัพธ์ภายใน picture box (สำหรับเดสก์ท็อป) หรือคอนเทนเนอร์ HTML (สำหรับเว็บ)

**ฉันจะจัดการกับการนำเสนอขนาดใหญ่ที่มีสไลด์จำนวนมากอย่างไร?**

สำหรับเด็คขนาดใหญ่ ควรพิจารณาการโหลดแบบ lazy‑loading หรือการเรนเดอร์ตามความต้องการของสไลด์ ซึ่งหมายถึงการสร้างเนื้อหาของสไลด์เฉพาะเมื่อผู้ใช้นำทางไปยังสไลด์นั้น ช่วยลดการใช้หน่วยความจำและเวลาในการโหลด