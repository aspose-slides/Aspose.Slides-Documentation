---
title: รวมการนำเสนออย่างมีประสิทธิภาพใน Java
linktitle: รวมการนำเสนอ
type: docs
weight: 40
url: /th/java/merge-presentation/
keywords:
- รวม PowerPoint
- รวมการนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- ผสาน PowerPoint
- ผสานการนำเสนอ
- ผสานสไลด์
- ผสาน PPT
- ผสาน PPTX
- ผสาน ODP
- Java
- Aspose.Slides
description: "รวม PowerPoint (PPT, PPTX) และการนำเสนอ OpenDocument (ODP) อย่างง่ายดายด้วย Aspose.Slides for Java เพื่อทำให้กระบวนการทำงานของคุณราบรื่นขึ้น"
---
## **ภาพรวม**

การรวมไฟล์การนำเสนอ PowerPoint และ OpenDocument เป็นงานที่พบบ่อยในแอปพลิเคชัน Java จำนวนมาก โดยเฉพาะเมื่อสร้างรายงาน, รวบรวมสไลด์จากแหล่งที่ต่างกัน, หรืออัตโนมัติกระบวนการนำเสนอ Aspose.Slides for Java มี API ที่ทรงพลังและใช้งานง่ายเพื่อรวมไฟล์ PPT, PPTX หรือ ODP หลายไฟล์เข้าเป็นการนำเสนอเดียวโดยไม่ต้องติดตั้ง Microsoft PowerPoint, LibreOffice หรือ OpenOffice.

ในคู่มือนี้ คุณจะได้เรียนรู้วิธีการรวมไฟล์การนำเสนอ PowerPoint และ OpenDocument ด้วยโค้ด Java เพียงไม่กี่บรรทัด เราจะให้ตัวอย่างพร้อมใช้งานและแสดงวิธีการรักษาการจัดรูปแบบสไลด์, เลย์เอาต์ และองค์ประกอบอื่น ๆ ของการนำเสนอระหว่างกระบวนการรวม

ไม่ว่าคุณจะพัฒนาแอปพลิเคชันระดับองค์กรหรือเครื่องมืออัตโนมัติแบบง่าย Aspose.Slides ทำให้การรวมการนำเสนอใน Java รวดเร็ว เชื่อถือได้ และขยายขนาดได้ Aspose.Slides for Java อนุญาตให้คุณรวมการนำเสนอได้หลายวิธี คุณสามารถรวมการนำเสนอพร้อมกับรูปร่างทั้งหมด, สไตล์, ข้อความ, การจัดรูปแบบ, ความคิดเห็น, แอนิเมชันและอื่น ๆ — โดยไม่ต้องกังวลเรื่องการสูญเสียคุณภาพหรือข้อมูล.

{{% alert color="primary" %}}
ดูเพิ่มเติม: [Clone Slides](https://docs.aspose.com/slides/th/java/clone-slides/)
{{% /alert %}}

### **อะไรบ้างที่สามารถรวมได้?**

With Aspose.Slides, you can merge:

**การนำเสนอทั้งหมด** – สไลด์ทั้งหมดจากหลายการนำเสนอจะถูกรวมเป็นหนึ่งไฟล์

**สไลด์ที่เลือกเฉพาะ** – สไลด์ที่เลือกเท่านั้นจะถูกรวมเป็นการนำเสนอเดียว

**การนำเสนอในรูปแบบเดียวกัน** (เช่น PPT เป็น PPT, PPTX เป็น PPTX) และ **ในรูปแบบต่างกัน** (เช่น PPT เป็น PPTX, PPTX เป็น ODP)

### **ตัวเลือกการรวม**

You can apply options that determine whether:

- สไลด์แต่ละใบในการนำเสนอผลลัพธ์คงสไตล์เดิมไว้
- สไตล์เฉพาะจะถูกนำไปใช้กับสไลด์ทั้งหมดในการนำเสนอผลลัพธ์

เพื่อรวมการนำเสนอ Aspose.Slides มีเมธอด `AddClone` จากอินเตอร์เฟซ [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/) มีการโอเวอร์โหลดเมธอด `AddClone` หลายแบบที่กำหนดพฤติกรรมของกระบวนการรวม แต่ละอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) มีคอลเลกชัน Slides ดังนั้นคุณสามารถเรียกเมธอด `AddClone` บนการนำเสนอเป้าหมายที่ต้องการรวมสไลด์ได้

เมธอด `AddClone` จะคืนค่าอ็อบเจกต์ [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/) ซึ่งเป็นสำเนาของสไลด์ต้นทาง สไลด์ที่ได้ในการนำเสนอผลลัพธ์เป็นเพียงสำเนาของสไลด์เดิม ซึ่งหมายความว่าคุณสามารถแก้ไขสไลด์ที่ถูกสำเนาได้อย่างปลอดภัย เช่น การนำสไตล์, ตัวเลือกการจัดรูปแบบ หรือเลย์เอาต์ โดยไม่กระทบต่อการนำเสนอต้นฉบับ

## **รวมการนำเสนอ**

Aspose.Slides มีเมธอด [AddClone(ISlide)](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) ซึ่งช่วยให้คุณรวมสไลด์โดยคงเลย์เอาต์และสไตล์เดิมไว้ (พฤติกรรมเริ่มต้น).

โค้ด Java ด้านล่างแสดงวิธีการรวมการนำเสนอ:

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **รวมการนำเสนอด้วย Slide Master**

Aspose.Slides มีเมธอด [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.IMasterSlide-boolean-) ซึ่งช่วยให้คุณรวมสไลด์โดยใช้ slide master จากเท็มเพลตการนำเสนอ ซึ่งทำให้คุณสามารถเปลี่ยนสไตล์ของสไลด์ในการนำเสนอผลลัพธ์ได้หากจำเป็น

โค้ด Java ด้านล่างแสดงการดำเนินการนี้:

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation2.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

{{% alert title="Note" color="warning" %}}
เลย์เอาต์ของสไลด์จะถูกกำหนดโดยอัตโนมัติ. เมื่อไม่พบเลย์เอาต์ที่เหมาะสม และพารามิเตอร์ boolean `allowCloneMissingLayout` ของเมธอด `AddClone` ถูกตั้งค่าเป็น `true` ระบบจะใช้เลย์เอาต์จากสไลด์ต้นฉบับ. ในกรณีอื่น จะเกิดข้อผิดพลาดประเภท [PptxEditException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **รวมสไลด์เฉพาะจากการนำเสนอ**

การรวมสไลด์เฉพาะจากหลายการนำเสนอเป็นประโยชน์ในการสร้างชุดสไลด์แบบกำหนดเอง Aspose.Slides for Java อนุญาตให้คุณเลือกและนำเข้าสไลด์ที่ต้องการเท่านั้น API จะคงการจัดรูปแบบ, เลย์เอาต์ และการออกแบบของสไลด์ต้นฉบับ

โค้ด Java ด้านล่างสร้างการนำเสนอใหม่ เพิ่มสไลด์หัวข้อจากสองการนำเสนออื่น และบันทึกผลลัพธ์เป็นไฟล์:

```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **รวมการนำเสนอด้วย Slide Layout**

เพื่อใช้เลย์เอาต์สไลด์ที่แตกต่างกับสไลด์ผลลัพธ์ระหว่างการรวม ให้ใช้เมธอด [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ILayoutSlide-) แทน

โค้ด Java ด้านล่างแสดงวิธีการรวมสไลด์จากหลายการนำเสนอพร้อมกับใช้เลย์เอาต์สไลด์ที่คุณต้องการ สิ่งนี้จะได้การนำเสนอผลลัพธ์เดียว:

```java
int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation2.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **รวมการนำเสนอที่มีขนาดสไลด์ต่างกัน**

เพื่อรวมสองการนำเสนอที่มีขนาดสไลด์ต่างกัน คุณต้องปรับขนาดของหนึ่งให้ตรงกับขนาดสไลด์ของการนำเสนออีกอันหนึ่ง

โค้ด Java ด้านล่างแสดงการดำเนินการนี้:

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    Dimension2D slideSize = presentation1.getSlideSize().getSize();
    float slideWidth = (float) slideSize.getWidth();
    float slideHeight = (float) slideSize.getHeight();
    
    presentation2.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **รวมสไลด์เข้าส่วนของการนำเสนอ**

การรวมสไลด์เข้าส่วนที่กำหนดของการนำเสนอช่วยจัดระเบียบเนื้อหาและปรับปรุงการนำทางสไลด์ Aspose.Slides อนุญาตให้คุณรวมสไลด์เข้าส่วนที่มีอยู่แล้ว ซึ่งช่วยให้โครงสร้างชัดเจนพร้อมคงการจัดรูปแบบเดิมของแต่ละสไลด์

โค้ด Java ด้านล่างแสดงวิธีการรวมสไลด์เฉพาะเข้าส่วนในการนำเสนอ:

```java
int sectionIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ISection section = presentation1.getSections().get_Item(sectionIndex);
        presentation1.getSlides().addClone(slide, section);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

สไลด์จะถูกเพิ่มไปยังส่วนสุดท้ายของส่วน

## **ดูเพิ่มเติม**

Aspose มีบริการ [FREE Online Collage Maker](https://products.aspose.app/slides/th/collage) ออนไลน์ ที่คุณสามารถรวมรูปแบบ [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG เป็น PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) และอื่น ๆ

ลองใช้ [Aspose FREE Online Merger](https://products.aspose.app/slides/th/merger) ซึ่งช่วยให้คุณรวมไฟล์ PowerPoint ในรูปแบบเดียวกัน (เช่น PPT เป็น PPT, PPTX เป็น PPTX) หรือข้ามรูปแบบต่างกัน (เช่น PPT เป็น PPTX, PPTX เป็น ODP)

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/th/merger)

นอกจากการนำเสนอแล้ว Aspose.Slides ยังสามารถรวมไฟล์อื่น ๆ ได้:

- [**ภาพ**](https://products.aspose.com/slides/th/java/merger/image-to-image/), เช่น [JPG to JPG](https://products.aspose.com/slides/th/java/merger/jpg-to-jpg/) หรือ [PNG to PNG](https://products.aspose.com/slides/th/java/merger/png-to-png/)
- **เอกสาร**, เช่น [PDF to PDF](https://products.aspose.com/slides/th/java/merger/pdf-to-pdf/) หรือ [HTML to HTML](https://products.aspose.com/slides/th/java/merger/html-to-html/)
- **ประเภทไฟล์ผสม**, เช่น [image to PDF](https://products.aspose.com/slides/th/java/merger/image-to-pdf/), [JPG to PDF](https://products.aspose.com/slides/th/java/merger/jpg-to-pdf/), หรือ [TIFF to PDF](https://products.aspose.com/slides/th/java/merger/tiff-to-pdf/)

## **FAQ**

**มีข้อจำกัดใดเกี่ยวกับจำนวนสไลด์เมื่อรวมการนำเสนอหรือไม่?**

ไม่มีข้อจำกัดที่เข้มงวด Aspose.Slides สามารถจัดการไฟล์ขนาดใหญ่ได้ แต่ประสิทธิภาพขึ้นอยู่กับขนาดไฟล์และทรัพยากรของระบบ สำหรับการนำเสนอขนาดใหญ่มาก แนะนำให้ใช้ JVM 64-bit และจัดสรรหน่วยความจำ heap อย่างเพียงพอ

**ฉันสามารถรวมการนำเสนอที่มีวิดีโอหรือเสียงฝังอยู่ได้หรือไม่?**

ได้ Aspose.Slides คงเนื้อหามัลติมีเดียที่ฝังอยู่ในสไลด์ไว้ แต่อาจทำให้ไฟล์การนำเสนอสุดท้ายใหญ่ขึ้นอย่างมาก

**ฟอนต์จะถูกคงไว้เมื่อรวมการนำเสนอหรือไม่?**

ใช่ ฟอนต์ที่ใช้ในการนำเสนอแหล่งต้นจะถูกคงไว้ในไฟล์ผลลัพธ์ หากฟอนต์นั้นติดตั้งอยู่ในระบบหรือ [ฝังไว้](/slides/th/java/embedded-font/).