---
title: การสกัดข้อความขั้นสูงจากงานพรีเซนเทชันใน Java
linktitle: สกัดข้อความ
type: docs
weight: 90
url: /th/java/extract-text-from-presentation/
keywords:
- สกัดข้อความ
- สกัดข้อความจากสไลด์
- สกัดข้อความจากพรีเซนเทชัน
- สกัดข้อความจาก PowerPoint
- สกัดข้อความจาก OpenDocument
- สกัดข้อความจาก PPT
- สกัดข้อความจาก PPTX
- สกัดข้อความจาก ODP
- ดึงข้อความ
- ดึงข้อความจากสไลด์
- ดึงข้อความจากพรีเซนเทชัน
- ดึงข้อความจาก PowerPoint
- ดึงข้อความจาก OpenDocument
- ดึงข้อความจาก PPT
- ดึงข้อความจาก PPTX
- ดึงข้อความจาก ODP
- PowerPoint
- OpenDocument
- งานพรีเซนเทชัน
- Java
- Aspose.Slides
description: "สกัดข้อความอย่างรวดเร็วจากงานพรีเซนเทชัน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java. ปฏิบัติตามคู่มือแบบง่ายขั้นตอนต่อขั้นตอนของเราเพื่อประหยัดเวลา."
---
## **ภาพรวม**

การสกัดข้อความจากงานพรีเซนเทชันเป็นงานที่พบบ่อยแต่สำคัญสำหรับนักพัฒนาที่ทำงานกับเนื้อหาสไลด์ ไม่ว่าคุณจะต้องจัดการไฟล์ Microsoft PowerPoint ในรูปแบบ PPT หรือ PPTX หรือพรีเซนเทชัน OpenDocument (ODP) การเข้าถึงและดึงข้อมูลข้อความอาจเป็นสิ่งจำเป็นสำหรับการวิเคราะห์ การทำอัตโนมัติ การทำดัชนี หรือการย้ายเนื้อหา

บทความนี้ให้คำแนะนำอย่างละเอียดเกี่ยวกับวิธีสกัดข้อความจากรูปแบบพรีเซนเทชันต่าง ๆ อย่างมีประสิทธิภาพ รวมถึง PPT, PPTX และ ODP โดยใช้ Aspose.Slides for Java คุณจะได้เรียนรู้วิธีวนลูปผ่านองค์ประกอบของพรีเซนเทชันอย่างเป็นระบบเพื่อดึงข้อความที่ต้องการได้อย่างแม่นยำ

## **สกัดข้อความจากสไลด์**

Aspose.Slides for Java มีคลาส [SlideUtil](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideutil/) คลาสนี้เปิดเผยเมธอด static ที่มีการโอเวอร์โหลดหลายรูปแบบสำหรับสกัดข้อความทั้งหมดจากพรีเซนเทชันหรือสไลด์ เพื่อสกัดข้อความจากสไลด์ในพรีเซนเทชัน ให้ใช้เมธอด [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) เมธอดนี้รับอ็อบเจกต์ประเภท [IBaseSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/) เป็นพารามิเตอร์ เมื่อทำงาน เมธอดจะสแกนสไลด์ทั้งหมดเพื่อค้นหาข้อความและคืนค่าอาเรย์ของอ็อบเจกต์ประเภท [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) โดยคงรูปแบบข้อความไว้

โค้ดตัวอย่างต่อไปนี้สกัดข้อความทั้งหมดจากสไลด์แรกของพรีเซนเทชัน:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **สกัดข้อความจากพรีเซนเทชัน**

เพื่อสแกนข้อความจากพรีเซนเทชันทั้งหมด ให้ใช้เมธอด static [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) ที่เปิดเผยโดยคลาส [SlideUtil](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideutil/) เมธอดนี้รับพารามิเตอร์สองค่า:

1. อ็อบเจกต์ [IPresentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/) ที่แสดงถึงพรีเซนเทชัน PowerPoint หรือ OpenDocument ที่จะสกัดข้อความ
1. ค่า `boolean` ที่ระบุว่าจะรวมสไลด์แม่ (master slides) ในการสแกนข้อความจากพรีเซนเทชันหรือไม่

เมธอดจะคืนค่าอาเรย์ของอ็อบเจกต์ประเภท [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) พร้อมข้อมูลรูปแบบของข้อความ โค้ดด้านล่างสแกนข้อความและรายละเอียดรูปแบบจากพรีเซนเทชันรวมถึงสไลด์แม่ด้วย

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **การสกัดข้อความแบบจัดหมวดหมู่และรวดเร็ว**

คลาส [PresentationFactory](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationfactory/) ยังมีเมธอดสำหรับสกัดข้อความทั้งหมดจากพรีเซนเทชัน:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

อาร์กิวเมนต์ enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/textextractionarrangingmode/) ระบุโหมดสำหรับจัดระเบียบผลลัพธ์การสกัดข้อความและสามารถกำหนดเป็นค่าต่อไปนี้ได้:

- `Unarranged` - ข้อความดิบโดยไม่คำนึงถึงตำแหน่งบนสไลด์
- `Arranged` - ข้อความถูกจัดเรียงตามลำดับบนสไลด์

โหมด Unarranged สามารถใช้เมื่อความเร็วเป็นเรื่องสำคัญ; มันเร็วกว่าโหมด Arranged

[IPresentationText](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationtext/) แสดงถึงข้อความดิบที่สกัดจากพรีเซนเทชัน เมธอด `getSlidesText` จะคืนค่าอาเรย์ของอ็อบเจกต์ประเภท [ISlideText](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidetext/) แต่ละอ็อบเจกต์แทนข้อความบนสไลด์ที่สอดคล้องกัน อ็อบเจกต์ประเภท [ISlideText](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidetext/) มีเมธอดดังต่อไปนี้:

- `getText` - ข้อความภายในรูปร่างของสไลด์
- `getMasterText` - ข้อความภายในรูปร่างของสไลด์แม่ที่สัมพันธ์กับสไลด์นี้
- `getLayoutText` - ข้อความภายในรูปร่างของสไลด์เลเอาต์ที่สัมพันธ์กับสไลด์นี้
- `getNotesText` - ข้อความภายในรูปร่างของสไลด์บันทึกย่อที่สัมพันธ์กับสไลด์นี้
- `getCommentsText` - ข้อความภายในคอมเมนต์ที่สัมพันธ์กับสไลด์นี้

```java
String presentationPath = "presentation.ppt";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **FAQ**

**Aspose.Slides ประมวลผลพรีเซนเทชันขนาดใหญ่ระหว่างการสกัดข้อความได้เร็วแค่ไหน?**

Aspose.Slides ถูกปรับให้ทำงานด้วยประสิทธิภาพสูงและสามารถประมวลผลแม้จะเป็น [พรีเซนเทชันขนาดใหญ่](/slides/th/java/open-presentation/) ทำให้เหมาะสำหรับสถานการณ์ที่ต้องการการประมวลผลแบบเรียลไทม์หรือแบบเป็นกลุ่ม

**Aspose.Slides สามารถสกัดข้อความจากตารางและแผนภูมิภายในพรีเซนเทชันได้หรือไม่?**

ได้ Aspose.Slides สามารถสกัดข้อความจากหลายองค์ประกอบของสไลด์ รวมถึงตารางและวัตถุที่เกี่ยวกับแผนภูมิ ทำให้คุณสามารถเข้าถึงและวิเคราะห์เนื้อหาข้อความในโครงสร้างพรีเซนเทชันที่พบบ่อยได้

**ฉันต้องการใบอนุญาต Aspose.Slides พิเศษเพื่อสกัดข้อความจากพรีเซนเทชันหรือไม่?**

คุณสามารถสกัดข้อความโดยใช้เวอร์ชันทดลองฟรีของ Aspose.Slides แม้ว่าจะมี [ข้อจำกัดบางประการ](/slides/th/java/licensing/) เช่น การประมวลผลจำนวนสไลด์ที่จำกัด หากต้องการใช้งานโดยไม่มีข้อจำกัดและจัดการพรีเซนเทชันขนาดใหญ่ การซื้อใบอนุญาตเต็มรูปแบบจึงเป็นทางเลือกที่แนะนำ