---
title: ผสานการนำเสนออย่างมีประสิทธิภาพใน Java
linktitle: ผสานการนำเสนอ
type: docs
weight: 40
url: /th/java/merge-presentation/
keywords:
- ผสาน PowerPoint
- ผสานการนำเสนอ
- ผสานสไลด์
- ผสาน PPT
- ผสาน PPTX
- ผสาน ODP
- รวม PowerPoint
- รวมการนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- Java
- Aspose.Slides
description: "ผสานการนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) อย่างไม่มีขั้นตอนยุ่งยากด้วย Aspose.Slides สำหรับ Java ช่วยให้การทำงานของคุณเป็นระบบระเบียบ"
---
## **ภาพรวม**

การผสานการนำเสนอ PowerPoint และ OpenDocument เป็นงานที่พบบ่อยในแอปพลิเคชัน Java หลาย ๆ ตัว โดยเฉพาะเมื่อต้องสร้างรายงาน รวบรวมสไลด์จากแหล่งต่าง ๆ หรือทำงานอัตโนมัติของการนำเสนอ Aspose.Slides for Java มอบ API ที่ทรงพลังและใช้งานง่ายเพื่อรวมไฟล์ PPT, PPTX หรือ ODP หลายไฟล์เป็นการนำเสนอเดียวโดยไม่ต้องติดตั้ง Microsoft PowerPoint, LibreOffice หรือ OpenOffice

ในคู่มือนี้ คุณจะได้เรียนรู้วิธีผสานการนำเสนอ PowerPoint และ OpenDocument ด้วยโค้ด Java เพียงไม่กี่บรรทัด เราจะให้ตัวอย่างพร้อมใช้ และแสดงวิธีการคงรูปแบบสไลด์ การจัดวาง และองค์ประกอบการนำเสนออื่น ๆ ระหว่างกระบวนการผสาน

ไม่ว่าคุณจะสร้างแอประดับองค์กรหรือเครื่องมืออัตโนมัติแบบง่าย Aspose.Slides ทำให้การผสานการนำเสนอใน Java รวดเร็ว เชื่อถือได้ และขยายได้ Aspose.Slides for Java ช่วยให้คุณผสานการนำเสนอได้หลายวิธี คุณสามารถรวมการนำเสนอพร้อมรูปทรงสไตล์ ข้อความ การจัดรูปแบบ ความคิดเห็น แอนิเมชัน และอื่น ๆ — โดยไม่ต้องกังวลเรื่องการสูญเสียคุณภาพหรือข้อมูล

{{% alert color="info" %}}
ดูเพิ่มเติม: [คัดลอกสไลด์](https://docs.aspose.com/slides/th/java/clone-slides/)
{{% /alert %}}

### **สิ่งที่สามารถผสานได้?**

ด้วย Aspose.Slides คุณสามารถผสาน:

**การนำเสนอทั้งหมด** – สไลด์ทั้งหมดจากหลายการนำเสนอจะถูกรวมเป็นหนึ่งไฟล์

**สไลด์เฉพาะ** – เพียงสไลด์ที่เลือกจะถูกรวมเป็นการนำเสนอเดียว

**การนำเสนอในรูปแบบเดียวกัน** (เช่น PPT → PPT, PPTX → PPTX) และ **ในรูปแบบต่างกัน** (เช่น PPT → PPTX, PPTX → ODP)

### **ตัวเลือกการผสาน**

คุณสามารถกำหนดตัวเลือกเพื่อระบุว่า:

- สไลด์แต่ละสไลด์ในผลลัพธ์จะคงสไตล์เดิม
- จะใช้สไตล์เฉพาะกับสไลด์ทั้งหมดในผลลัพธ์

ในการผสานการนำเสนอ Aspose.Slides ให้เมธอด `AddClone` จากอินเทอร์เฟซ [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/) มีหลายรูปแบบการอัปโหลดที่กำหนดพฤติกรรมของกระบวนการผสาน แต่ละวัตถุ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) มีคอลเลกชัน Slides ดังนั้นคุณสามารถเรียกเมธอด `AddClone` บนการนำเป้าหมายที่ต้องการผสานสไลด์เข้าไปได้

เมธอด `AddClone` จะคืนค่าเป็นวัตถุ [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/) ซึ่งเป็นสำเนาของสไลด์ต้นฉบับ สไลด์ผลลัพธ์ในการนำเสนอจะเป็นสำเนาเดียวกับสไลด์ต้นฉบับ ซึ่งหมายความว่าคุณสามารถแก้ไขสไลด์ที่คัดลอกได้อย่างปลอดภัย เช่น การปรับสไตล์ ตัวเลือกการจัดรูปแบบ หรือการจัดวาง โดยไม่กระทบต่อการนำเสนอแหล่งที่มา

## **ผสานการนำเสนอ** 

Aspose.Slides ให้เมธอด [AddClone(ISlide)](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) ซึ่งช่วยให้คุณรวมสไลด์พร้อมคงการจัดวางและสไตล์เดิม (พฤติกรรมเริ่มต้น)

โค้ด Java ต่อไปนี้แสดงวิธีผสานการนำเสนอ:

```java
import com.aspose.slides.*;

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

## **ผสานการนำเสนอพร้อม Slide Master** 

Aspose.Slides ให้เมธอด [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ที่ช่วยให้คุณรวมสไลด์พร้อมใช้ Slide Master จากเทมเพลตการนำเสนอ วิธีนี้ทำให้คุณสามารถเปลี่ยนสไตล์ของสไลด์ในผลลัพธ์ได้หากต้องการ

โค้ด Java ตัวอย่างต่อไปนี้แสดงการดำเนินการนี้:

```java
import com.aspose.slides.*;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation1.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

{{% alert title="หมายเหตุ" color="warning" %}}
รูปแบบสไลด์สำหรับสไลด์จะถูกกำหนดอัตโนมัติ หากไม่พบรูปแบบที่เหมาะสมและพารามิเตอร์ `allowCloneMissingLayout` ของเมธอด `AddClone` ถูกตั้งค่าเป็น `true` จะใช้รูปแบบจากสไลด์ต้นฉบับ มิฉะนั้นจะเกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxeditexception/)
{{% /alert %}}

## **ผสานสไลด์เฉพาะจากการนำเสนอ** 

การผสานสไลด์เฉพาะจากหลายการนำเสนอเป็นประโยชน์เมื่อสร้างชุดสไลด์ที่กำหนดเอง Aspose.Slides for Java อนุญาตให้คุณเลือกและนำเข้าสไลด์ที่ต้องการเท่านั้น API จะคงการจัดรูปแบบ การจัดวาง และการออกแบบของสไลด์ต้นฉบับ

โค้ด Java ด้านล่างนี้สร้างการนำเสนอใหม่ เพิ่มสไลด์หัวเรื่องจากสองการนำเสนออื่น ๆ แล้วบันทึกผลลัพธ์เป็นไฟล์:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **ผสานการนำเสนอพร้อม Layout สไลด์** 

หากต้องการใช้ Layout สไลด์ที่ต่างออกไปสำหรับสไลด์ผลลัพธ์ระหว่างการผสาน ให้ใช้เมธอด [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) แทน

โค้ด Java ต่อไปนี้แสดงวิธีรวมสไลด์จากหลายการนำเสนอพร้อมใช้ Layout สไลด์ที่คุณต้องการ ผลลัพธ์คือการนำเสนอเดียวที่มี Layout สไลด์สอดคล้องกัน:

```java
import com.aspose.slides.*;

int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation1.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **ผสานการนำเสนอที่มีขนาดสไลด์ต่างกัน** 

เพื่อผสานการนำเสนอสองไฟล์ที่มีขนาดสไลด์ต่างกัน คุณควรปรับขนาดหนึ่งไฟล์ให้ตรงกับขนาดสไลด์ของอีกไฟล์หนึ่ง

โค้ด Java ตัวอย่างต่อไปนี้แสดงการดำเนินการนี้:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

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

## **ผสานสไลด์เข้าส่วนของการนำเสนอ** 

การผสานสไลด์เข้าส่วนของการนำเสนอช่วยจัดระเบียบเนื้อหาและปรับปรุงการนำทางสไลด์ Aspose.Slides รองรับการผสานสไลด์เข้าส่วนที่มีอยู่แล้ว ซึ่งช่วยให้โครงสร้างชัดเจนพร้อมคงรูปแบบต้นฉบับของแต่ละสไลด์

โค้ด Java ด้านล่างนี้แสดงวิธีผสานสไลด์เฉพาะเข้าส่วนของการนำเสนอ:

```java
import com.aspose.slides.*;

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

สไลด์จะถูกเพิ่มไปที่ท้ายส่วน

## **ดูเพิ่มเติม** 

Aspose มีบริการ [FREE Online Collage Maker](https://products.aspose.app/slides/th/collage) ออนไลน์ คุณสามารถผสานภาพ [JPG ไป JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG ไป PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) และอื่น ๆ

ลองใช้ [Aspose FREE Online Merger](https://products.aspose.app/slides/th/merger) ซึ่งช่วยผสานการนำเสนอ PowerPoint ในรูปแบบเดียวกัน (เช่น PPT → PPT, PPTX → PPTX) หรือข้ามรูปแบบ (เช่น PPT → PPTX, PPTX → ODP)

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/th/merger)

นอกจากการนำเสนอแล้ว Aspose.Slides ยังสามารถผสานไฟล์ประเภทอื่นได้:

- [**ภาพ**](https://products.aspose.com/slides/th/java/merger/image-to-image/), เช่น [JPG ไป JPG](https://products.aspose.com/slides/th/java/merger/jpg-to-jpg/) หรือ [PNG ไป PNG](https://products.aspose.com/slides/th/java/merger/png-to-png/)
- **เอกสาร**, เช่น [PDF ไป PDF](https://products.aspose.com/slides/th/java/merger/pdf-to-pdf/) หรือ [HTML ไป HTML](https://products.aspose.com/slides/th/java/merger/html-to-html/)
- **ไฟล์ชนิดผสม**, เช่น [image ไป PDF](https://products.aspose.com/slides/th/java/merger/image-to-pdf/), [JPG ไป PDF](https://products.aspose.com/slides/th/java/merger/jpg-to-pdf/), หรือ [TIFF ไป PDF](https://products.aspose.com/slides/th/java/merger/tiff-to-pdf/)

## **คำถามที่พบบ่อย** 

### มีข้อจำกัดเรื่องจำนวนสไลด์เมื่อผสานการนำเสนอหรือไม่?

ไม่มีข้อจำกัดที่เข้มงวด Aspose.Slides สามารถจัดการไฟล์ขนาดใหญ่ได้ แต่ประสิทธิภาพขึ้นกับขนาดไฟล์และทรัพยากรของระบบ สำหรับการนำเสนอขนาดใหญ่มาก ควรใช้ JVM 64‑bit และจัดสรรหน่วยความจำ heap เพียงพอ

### ฉันสามารถผสานการนำเสนอที่มีวิดีโอหรือเสียงฝังอยู่ได้หรือไม่?

ได้ Aspose.Slides คงเนื้อหามัลติมีเดียที่ฝังอยู่ในสไลด์ไว้ แต่ไฟล์ผลลัพธ์อาจมีขนาดใหญ่ขึ้นอย่างมาก

### ตัวอักษรจะยังคงอยู่เมื่อตอนผสานการนำเสนอหรือไม่?

ใช่ ตัวอักษรที่ใช้ในการนำเสนอแหล่งที่มาจะถูกคงไว้ในไฟล์ผลลัพธ์ หากอักษรนั้นติดตั้งบนระบบหรือ [embedded](/slides/th/java/embedded-font/)