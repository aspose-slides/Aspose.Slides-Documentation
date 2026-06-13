---
title: การสกัดข้อความขั้นสูงจากงานนำเสนอใน JavaScript
linktitle: สกัดข้อความ
type: docs
weight: 90
url: /th/nodejs-java/extract-text-from-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "ดึงข้อความจากงานนำเสนอ PowerPoint และ OpenDocument อย่างรวดเร็วโดยใช้ Aspose.Slides for Node.js via Java. ปฏิบัติตามคู่มือขั้นตอนง่ายของเราเพื่อประหยัดเวลา."
---
## **ภาพรวม**

การสกัดข้อความจากงานนำเสนอเป็นงานที่พบบ่อยแต่จำเป็นสำหรับนักพัฒนาที่ทำงานกับเนื้อหาสไลด์ ไม่ว่าคุณจะทำงานกับไฟล์ Microsoft PowerPoint ในรูปแบบ PPT หรือ PPTX หรือกับงานนำเสนอ OpenDocument (ODP) การเข้าถึงและดึงข้อมูลข้อความสามารถเป็นสิ่งสำคัญสำหรับการวิเคราะห์ การทำอัตโนมัติ การทำดัชนี หรือการย้ายเนื้อหา

บทความนี้ให้คำแนะนำอย่างครอบคลุมเกี่ยวกับวิธีการสกัดข้อความจากรูปแบบงานนำเสนอหลายรูปแบบอย่างมีประสิทธิภาพ รวมถึง PPT, PPTX และ ODP โดยใช้ Aspose.Slides for Node.js via Java คุณจะได้เรียนรู้วิธีการวนผ่านองค์ประกอบของงานนำเสนออย่างระบบระเบียบเพื่อดึงข้อความที่ต้องการอย่างแม่นยำ

## **สกัดข้อความจากสไลด์**

Aspose.Slides for Node.js via Java มีคลาส [SlideUtil](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideutil/) คลาสนี้ให้เมธอดสเตติกหลายแบบที่มีการโอเวอร์โหลดสำหรับสกัดข้อความทั้งหมดจากงานนำเสนอหรือสไลด์ เพื่อสกัดข้อความจากสไลด์ในงานนำเสนอ ให้ใช้เมธอด [getAllTextBoxes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) เมธอดนี้รับอ็อบเจ็กต์สไลด์เป็นพารามิเตอร์ เมื่อทำงาน เมธอดจะสแกนสไลด์ทั้งหมดเพื่อค้นหาข้อความและคืนค่าเป็นอาร์เรย์ของอ็อบเจ็กต์ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) โดยคงรูปแบบข้อความไว้

โค้ดตัวอย่างต่อไปนี้สกัดข้อความทั้งหมดจากสไลด์แรกของงานนำเสนอ:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **สกัดข้อความจากงานนำเสนอ**

เพื่อสแกนข้อความจากงานนำเสนอทั้งหมด ให้ใช้เมธอดสเตติก [getAllTextFrames](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) ซึ่งเปิดให้บริการโดยคลาส [SlideUtil](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideutil/) เมธอดนี้รับพารามิเตอร์สองค่า:

1. แรก คืออ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ที่แสดงงานนำเสนอ PowerPoint หรือ OpenDocument ที่ต้องการสกัดข้อความ
1. ที่สอง คือค่า `boolean` ที่ระบุว่าควรรวมสไลด์มาสเตอร์ในการสแกนข้อความจากงานนำเสนอหรือไม่

เมธอดจะคืนค่าเป็นอาร์เรย์ของอ็อบเจ็กต์ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) โดยรวมข้อมูลการจัดรูปแบบข้อความด้วย โค้ดด้านล่างจะแสกนข้อความและรายละเอียดการจัดรูปแบบจากงานนำเสนอ รวมถึงสไลด์มาสเตอร์ด้วย

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **การสกัดข้อความแบบจัดหมวดหมู่และรวดเร็ว**

คลาส [PresentationFactory](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationfactory/) ยังมีเมธอดสำหรับสกัดข้อความทั้งหมดจากงานนำเสนอ:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

อาร์กิวเมนต์ enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textextractionarrangingmode/) ระบุโหมดการจัดระเบียบผลลัพธ์การสกัดข้อความและสามารถตั้งค่าได้เป็นค่าต่อไปนี้:
- `Unarranged` - ข้อความดิบที่ไม่คำนึงถึงตำแหน่งบนสไลด์
- `Arranged` - ข้อความถูกจัดเรียงตามลำดับเดียวกับบนสไลด์

โหมด Unarranged สามารถใช้เมื่อความเร็วเป็นสิ่งสำคัญ; มันเร็วกว่าโหมด Arranged

[PresentationText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationtext/) แทนข้อความดิบที่สกัดจากงานนำเสนอ เมธอด `getSlidesText` ของมันคืนค่าเป็นอาร์เรย์ของอ็อบเจ็กต์ แต่ละอ็อบเจ็กต์แทนข้อความของสไลด์ที่สอดคล้องกัน แต่ละอ็อบเจ็กต์ของข้อความสไลด์มีเมธอดต่อไปนี้:
- `getText` เมธอดนี้คืนค่าข้อความภายในรูปทรงของสไลด์
- `getMasterText` เมธอดนี้คืนค่าข้อความภายในรูปทรงของสไลด์มาสเตอร์ที่สัมพันธ์กับสไลด์นี้
- `getLayoutText` เมธอดนี้คืนค่าข้อความภายในรูปทรงของสไลด์เลย์เอาต์ที่สัมพันธ์กับสไลด์นี้
- `getNotesText` เมธอดนี้คืนค่าข้อความภายในรูปทรงของสไลด์บันทึกย่อที่สัมพันธ์กับสไลด์นี้
- `getCommentsText` เมธอดนี้คืนค่าขข้อความภายในความคิดเห็นที่สัมพันธ์กับสไลด์นี้

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **คำถามที่พบบ่อย**

**Aspose.Slides ประมวลผลงานนำเสนอขนาดใหญ่ระหว่างการสกัดข้อความเร็วแค่ไหน?**

Aspose.Slides ถูกปรับให้ทำงานด้วยประสิทธิภาพสูงและสามารถประมวลผลแม้ว่าจะเป็น [งานนำเสนอขนาดใหญ่](/slides/th/nodejs-java/open-presentation/) ทำให้เหมาะสำหรับสถานการณ์การประมวลผลแบบเรียลไทม์หรือเป็นกลุ่ม

**Aspose.Slides สามารถสกัดข้อความจากตารางและแผนภูมิภายในงานนำเสนอได้หรือไม่?**

ได้ Aspose.Slides สามารถสกัดข้อความจากหลายองค์ประกอบของสไลด์ รวมถึงตารางและอ็อบเจ็กต์ที่เกี่ยวข้องกับแผนภูมิ ทำให้คุณสามารถเข้าถึงและวิเคราะห์เนื้อหาแบบข้อความในโครงสร้างงานนำเสนอทั่วไป

**ฉันต้องการไลเซนส์พิเศษของ Aspose.Slides เพื่อสกัดข้อความจากงานนำเสนอหรือไม่?**

คุณสามารถสกัดข้อความได้โดยใช้เวอร์ชันทดลองใช้ฟรีของ Aspose.Slides แม้ว่าจะมี [ข้อจำกัดบางประการ](/slides/th/nodejs-java/licensing/) เช่น การประมวลผลเพียงจำนวนสไลด์จำกัด สำหรับการใช้งานไม่มีข้อจำกัดและการจัดการงานนำเสนอขนาดใหญ่ แนะนำให้ซื้อไลเซนส์เต็มรูปแบบ