---
title: การสกัดข้อความขั้นสูงจากงานนำเสนอบน Android
linktitle: สกัดข้อความ
type: docs
weight: 90
url: /th/androidjava/extract-text-from-presentation/
keywords:
- สกัดข้อความ
- สกัดข้อความจากสไลด์
- สกัดข้อความจากงานนำเสนอ
- สกัดข้อความจาก PowerPoint
- สกัดข้อความจาก OpenDocument
- สกัดข้อความจาก PPT
- สกัดข้อความจาก PPTX
- สกัดข้อความจาก ODP
- ดึงข้อความ
- ดึงข้อความจากสไลด์
- ดึงข้อความจากงานนำเสนอ
- ดึงข้อความจาก PowerPoint
- ดึงข้อความจาก OpenDocument
- ดึงข้อความจาก PPT
- ดึงข้อความจาก PPTX
- ดึงข้อความจาก ODP
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สกัดข้อความจากงานนำเสนอ PowerPoint และ OpenDocument อย่างรวดเร็วโดยใช้ Aspose.Slides for Android ผ่าน Java ปฏิบัติตามคู่มือขั้นตอนง่าย ๆ ของเราเพื่อประหยัดเวลา"
---
## **ภาพรวม**

การสกัดข้อความจากงานนำเสนอเป็นงานที่พบบ่อยแต่จำเป็นสำหรับนักพัฒนาที่ทำงานกับเนื้อหาในสไลด์ ไม่ว่าคุณจะทำงานกับไฟล์ Microsoft PowerPoint ในรูปแบบ PPT หรือ PPTX หรือการนำเสนอ OpenDocument (ODP) การเข้าถึงและดึงข้อมูลข้อความสามารถเป็นสิ่งสำคัญสำหรับการวิเคราะห์ การทำอัตโนมัติ การทำดัชนี หรือการย้ายเนื้อหา

บทความนี้ให้คำแนะนำอย่างครบถ้วนเกี่ยวกับวิธีการสกัดข้อความอย่างมีประสิทธิภาพจากรูปแบบงานนำเสนอหลายประเภท ได้แก่ PPT, PPTX, และ ODP โดยใช้ Aspose.Slides for Android via Java คุณจะได้เรียนรู้วิธีการวนลูปผ่านองค์ประกอบของงานนำเสนออย่างเป็นระเบียบเพื่อดึงข้อความที่ต้องการได้อย่างแม่นยำ

## **สกัดข้อความจากสไลด์**

Aspose.Slides for Android via Java มีคลาส [SlideUtil](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideutil/) คลาสนี้เปิดเผยเมธอดสเตติกหลายแบบที่อัดแน่นสำหรับการสกัดข้อความทั้งหมดจากงานนำเสนอหรือสไลด์ เพื่อสกัดข้อความจากสไลด์ในงานนำเสนอ ให้ใช้เมธอด [getAllTextBoxes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) วิธีนี้รับอ็อบเจกต์ชนิด [IBaseSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/) เป็นพารามิเตอร์ เมื่อทำงานเมธอดจะสแกนสไลด์ทั้งหมดเพื่อค้นหาข้อความและคืนค่าอาร์เรย์ของอ็อบเจกต์ชนิด [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) พร้อมรักษาการจัดรูปแบบข้อความ

โค้ดตัวอย่างต่อไปนี้สกัดข้อความทั้งหมดจากสไลด์แรกของงานนำเสนอ:

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

## **สกัดข้อความจากงานนำเสนอ**

เพื่อสแกนข้อความจากงานนำเสนอทั้งหมด ให้ใช้เมธอดสเตติก [getAllTextFrames](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) ที่เปิดเผยโดยคลาส [SlideUtil](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideutil/) เมธอดนี้รับพารามิเตอร์สองค่า:

1. ครั้งแรก คืออ็อบเจกต์ [IPresentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/) ที่แสดงถึงงานนำเสนอ PowerPoint หรือ OpenDocument ที่จะสกัดข้อความจากมัน
1. ครั้งที่สอง คือค่า `boolean` ที่บ่งชี้ว่าควรรวมสไลด์มาสเตอร์ไว้ในการสแกนข้อความจากงานนำเสนอหรือไม่

เมธอดจะคืนค่าอาร์เรย์ของอ็อบเจกต์ชนิด [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) พร้อมข้อมูลการจัดรูปแบบข้อความ โค้ดด้านล่างสแกนข้อความและรายละเอียดการจัดรูปแบบจากงานนำเสนอ รวมถึงสไลด์มาสเตอร์ด้วย

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

## **การสกัดข้อความแบบจัดประเภทและรวดเร็ว**

คลาส [PresentationFactory](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationfactory/) ยังมีเมธอดสำหรับสกัดข้อความทั้งหมดจากงานนำเสนอ:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

อากิวเมนต์ enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textextractionarrangingmode/) ระบุโหมดสำหรับจัดระเบียบผลลัพธ์การสกัดข้อความและสามารถตั้งค่าเป็นค่าต่อไปนี้:
- `Unarranged` - ข้อความดิบโดยไม่คำนึงถึงตำแหน่งบนสไลด์
- `Arranged` - ข้อความถูกจัดเรียงตามลำดับเดียวกับบนสไลด์

โหมด Unarranged สามารถใช้เมื่อความเร็วเป็นสิ่งสำคัญ; มันเร็วกว่าโหมด Arranged

[IPresentationText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentationtext/) แสดงถึงข้อความดิบที่สกัดจากงานนำเสนอ เมธอด `getSlidesText` ของมันคืนค่าอาร์เรย์ของอ็อบเจกต์ชนิด [ISlideText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidetext/) แต่ละอ็อบเจกต์แทนข้อความบนสไลด์ที่สอดคล้องของมัน อ็อบเจกต์ชนิด [ISlideText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidetext/) มีเมธอดต่อไปนี้:

- `getText` - ข้อความภายในรูปร่างของสไลด์
- `getMasterText` - ข้อความภายในรูปร่างของสไลด์มาสเตอร์ที่เชื่อมโยงกับสไลด์นี้
- `getLayoutText` - ข้อความภายในรูปร่างของสไลด์เลเอาต์ที่เชื่อมโยงกับสไลด์นี้
- `getNotesText` - ข้อความภายในรูปร่างของสไลด์บันทึกย่อที่เชื่อมโยงกับสไลด์นี้
- `getCommentsText` - ข้อความภายในคอมเมนต์ที่เชื่อมโยงกับสไลด์นี้

```java
String presentationPath = "presentation.pptx";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **คำถามที่พบบ่อย**

**Aspose.Slides ประมวลผลงานนำเสนอขนาดใหญ่ในการสกัดข้อความเร็วแค่ไหน?**

Aspose.Slides ถูกปรับแต่งให้มีประสิทธิภาพสูงและสามารถประมวลผลแม้กระทั่ง [large presentations](/slides/th/androidjava/open-presentation/) ทำให้เหมาะสำหรับสถานการณ์การประมวลผลแบบเรียลไทม์หรือแบบก้อนใหญ่

**Aspose.Slides สามารถสกัดข้อความจากตารางและแผนภูมิภายในงานนำเสนอได้หรือไม่?**

ใช่. Aspose.Slides สามารถสกัดข้อความจากหลายองค์ประกอบของสไลด์ รวมถึงตารางและอ็อบเจกต์ที่เกี่ยวข้องกับแผนภูมิ ดังนั้นคุณจึงสามารถเข้าถึงและวิเคราะห์เนื้อหาข้อความในโครงสร้างงานนำเสนอทั่วไปได้

**ฉันต้องใช้ใบอนุญาต Aspose.Slides เฉพาะเพื่อสกัดข้อความจากงานนำเสนอหรือไม่?**

คุณสามารถสกัดข้อความโดยใช้เวอร์ชันทดลองฟรีของ Aspose.Slides แม้ว่าจะมี [certain limitations](/slides/th/androidjava/licensing/) เช่น การประมวลผลจำนวนสไลด์ที่จำกัด เพื่อการใช้งานไม่จำกัดและจัดการกับงานนำเสนอขนาดใหญ่ การซื้อใบอนุญาตเต็มเวอร์ชันจึงแนะนำ