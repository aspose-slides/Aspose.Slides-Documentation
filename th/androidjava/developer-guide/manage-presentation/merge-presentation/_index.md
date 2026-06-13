---
title: ผสานงานนำเสนออย่างมีประสิทธิภาพบน Android
linktitle: ผสานงานนำเสนอ
type: docs
weight: 40
url: /th/androidjava/merge-presentation/
keywords:
- รวม PowerPoint
- รวมงานนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- รวม PowerPoint
- รวมงานนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- Android
- Java
- Aspose.Slides
description: "ผสานงานนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อทำให้กระบวนการทำงานของคุณเป็นระเบียบและเร็วขึ้น."
---
## **ภาพรวม**

การผสานรวมงานนำเสนอ PowerPoint และ OpenDocument เป็นงานที่พบบ่อยในหลายแอปพลิเคชัน Android โดยเฉพาะเมื่อสร้างรายงาน การรวบรวมสไลด์จากแหล่งต่าง ๆ หรือการทำงานอัตโนมัติของงานนำเสนอ Aspose.Slides ให้ API ที่ทรงพลังและใช้งานง่ายสำหรับรวมไฟล์ PPT, PPTX หรือ ODP หลายไฟล์เป็นงานนำเสนอเดียวโดยไม่ต้องติดตั้ง Microsoft PowerPoint, LibreOffice หรือ OpenOffice.

ในคู่มือนี้ คุณจะได้เรียนรู้วิธีผสานรวมงานนำเสนอ PowerPoint และ OpenDocument ด้วยเพียงไม่กี่บรรทัดของโค้ด เราจะให้ตัวอย่างที่พร้อมใช้งานและแสดงวิธีรักษาการจัดรูปแบบสไลด์, เค้าโครงและองค์ประกอบอื่น ๆ ของงานนำเสนอระหว่างกระบวนการผสาน.

ไม่ว่าคุณจะสร้างแอปพลิเคชันระดับองค์กรหรือเครื่องมืออัตโนมัติแบบง่าย Aspose.Slides ทำให้การผสานรวมงานนำเสนอเป็นเรื่องเร็ว เชื่อถือได้และขยายได้ Aspose.Slides ให้คุณผสานงานนำเสนอได้หลากหลายวิธี คุณสามารถรวมงานนำเสนอพร้อมกับรูปร่าง, สไตล์, ข้อความ, การจัดรูปแบบ, คอมเมนต์, แอนิเมชัน และอื่น ๆ อีกมากมายโดยไม่ต้องกังวลเรื่องการสูญเสียคุณภาพหรือข้อมูล.

{{% alert color="primary" %}}
ดูเพิ่มเติม: [คัดลอกสไลด์](https://docs.aspose.com/slides/th/androidjava/clone-slides/)
{{% /alert %}}

### **สิ่งที่สามารถผสานได้**

With Aspose.Slides, you can merge 

* งานนำเสนอทั้งหมด. สไลด์ทั้งหมดจากงานนำเสนอจะถูกรวมไว้ในงานนำเสนอเดียว
* สไลด์เฉพาะ. สไลด์ที่เลือกจะถูกรวมไว้ในงานนำเสนอเดียว
* งานนำเสนอในรูปแบบเดียวกัน (PPT ไปเป็น PPT, PPTX ไปเป็น PPTX ฯลฯ) และในรูปแบบที่แตกต่างกัน (PPT ไปเป็น PPTX, PPTX ไปเป็น ODP ฯลฯ) ให้กันและกัน. 

### **ตัวเลือกการผสาน**

You can apply options that determine whether

* แต่ละสไลด์ในงานนำเสนอผลลัพธ์ยังคงสไตล์ที่เป็นเอกลักษณ์
* สไตล์เฉพาะใช้กับสไลด์ทั้งหมดในงานนำเสนอผลลัพธ์. 

To merge presentations, Aspose.Slides provides [AddClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methods (from the [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection) interface). There are several implementations of the `AddClone` methods that define the presentation merging process parameters. Every Presentation object has a [Slides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) collection, so you can call a `AddClone` method from the presentation to which you want to merge slides.

The `AddClone` method returns an `ISlide` object, which is a clone of the source slide. The slides in an output presentation are simply a copy of the slides from the source. Therefore, you can make changes the resulting slides (for example, apply styles or formatting options or layouts) without worrying about the source presentations becoming affected. 

## **ผสานงานนำเสนอ** 

Aspose.Slides provides the [**AddClone(ISlide)**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) method that allows you to combine slides while the slides retain their layouts and styles (default parameters).

This Java code shows you how to merge presentations:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **ผสานงานนำเสนอด้วย Slide Master** 

Aspose.Slides provides the [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) method that allows you to combine slides while applying a slide master presentation template. This way, if necessary, you get to change the style for slides in the output presentation.

This code in Java demonstrates the described operation:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
เค้าโครงสไลด์สำหรับ slide master จะถูกกำหนดโดยอัตโนมัติ หากไม่สามารถกำหนดเค้าโครงที่เหมาะสมได้ หากพารามิเตอร์บูลีน `allowCloneMissingLayout` ของเมธอด `AddClone` ถูกตั้งค่าเป็น true จะใช้เค้าโครงของสไลด์ต้นฉบับ มิฉะนั้นจะเกิดข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PptxEditException).
{{% /alert %}}

If you want the slides in the output presentation to have a different slide layout, use the [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) method instead when merging.

## **ผสานสไลด์เฉพาะจากงานนำเสนอ** 

Merging specific slides from multiple presentations is useful for creating custom slide decks. Aspose.Slides for Android via Java allows you to select and import only the slides you need. The API preserves formatting, layout, and design of the original slides.

The following Java code creates a new presentation, adds title slides from two other presentations, and saves the result to a file:
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

## **ผสานงานนำเสนอด้วยเค้าโครงสไลด์** 

This Java code shows you how to combine slides from presentations while applying your preferred slide layout to them to get one output presentation:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **ผสานงานนำเสนอด้วยขนาดสไลด์ที่ต่างกัน** 

{{% alert title="Note" color="warning" %}} 
คุณไม่สามารถผสานงานนำเสนอที่มีขนาดสไลด์ต่างกันได้. 
{{% /alert %}}

To merge 2 presentations with different slide sizes, you have to resize one of the presentations to make its size match that of the other presentation. 

This sample code demonstrates the described operation:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **ผสานสไลด์เข้าส่วนของงานนำเสนอ** 

This Java code shows you how to merge a specific slide to a section in a presentation:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

The slide is added at the end of the section. 

{{% alert title="Tip" color="primary" %}} 
Aspose มีแอปเว็บ [Collage ฟรี](https://products.aspose.app/slides/th/collage) ให้ใช้ บริการออนไลน์นี้คุณสามารถผสานภาพ [JPG เป็น JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG เป็น PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) และอื่น ๆ 
{{% /alert %}}

## **คำถามที่พบบ่อย** 

**มีข้อจำกัดเรื่องจำนวนสไลด์เมื่อผสานงานนำเสนอหรือไม่?**  

ไม่มีข้อจำกัดอย่างเคร่งครัด Aspose.Slides สามารถจัดการไฟล์ขนาดใหญ่ได้ แต่ประสิทธิภาพขึ้นอยู่กับขนาดไฟล์และทรัพยากรของระบบ สำหรับงานนำเสนอที่ใหญ่มาก แนะนำให้ใช้ JVM แบบ 64-bit และจัดสรรหน่วยความจำ heap อย่างเพียงพอ.  

**ฉันสามารถผสานงานนำเสนอที่ฝังวิดีโอหรือเสียงได้หรือไม่?**  

ได้ Aspose.Slides จะรักษาเนื้อหามัลติมีเดียที่ฝังอยู่ในสไลด์ แต่ไฟล์งานนำเสนอสุดท้ายอาจใหญ่ขึ้นอย่างมีนัยสำคัญ.  

**ฟอนต์จะถูกเก็บรักษาไว้เมื่อตอนผสานงานนำเสนอหรือไม่?**  

ใช่ ฟอนต์ที่ใช้ในงานนำเสนอเดิมจะถูกเก็บไว้ในไฟล์ผลลัพธ์ โดยสมมติว่าฟอนต์ถูกติดตั้งในระบบหรือ [ฝังไว้](/slides/th/androidjava/embedded-font/).