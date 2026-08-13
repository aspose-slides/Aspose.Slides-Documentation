---
title: รวมการนำเสนออย่างมีประสิทธิภาพบน Android
linktitle: รวมการนำเสนอ
type: docs
weight: 40
url: /th/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "รวม PowerPoint (PPT, PPTX) และการนำเสนอ OpenDocument (ODP) อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android ผ่าน Java ช่วยทำให้กระบวนการทำงานของคุณเป็นระเบียบมากขึ้น."
---
## **ภาพรวม**

การรวมไฟล์นำเสนอ PowerPoint และ OpenDocument เป็นงานที่พบบ่อยในหลายแอปพลิเคชัน Android โดยเฉพาะเมื่อสร้างรายงาน รวบรวมสไลด์จากแหล่งต่าง ๆ หรืออัตโนมัติขั้นตอนการทำงานของการนำเสนอ Aspose.Slides ให้ API ที่ทรงพลังและใช้งานง่ายเพื่อรวมไฟล์ PPT, PPTX หรือ ODP หลายไฟล์เป็นการนำเสนอเดียวโดยไม่ต้องติดตั้ง Microsoft PowerPoint, LibreOffice หรือ OpenOffice.

ในคู่มือนี้ คุณจะได้เรียนรู้วิธีการรวมไฟล์นำเสนอ PowerPoint และ OpenDocument โดยใช้เพียงไม่กี่บรรทัดของโค้ด เราจะให้ตัวอย่างที่พร้อมใช้งาน และแสดงวิธีการรักษาการจัดรูปแบบสไลด์, รูปแบบหน้า, และองค์ประกอบอื่น ๆ ของการนำเสนอระหว่างกระบวนการรวม.

ไม่ว่าจะคุณกำลังสร้างแอปพลิเคชันระดับองค์กรหรือเครื่องมืออัตโนมัติแบบง่าย Aspose.Slides ทำให้การรวมการนำเสนอเร็ว, น่าเชื่อถือและขยายได้ Aspose.Slides อนุญาตให้คุณรวมการนำเสนอได้หลายวิธี คุณสามารถรวมการนำเสนอพร้อมกับรูปทรง, สไตล์, ข้อความ, การจัดรูปแบบ, ความคิดเห็น, แอนิเมชัน และอื่น ๆ — โดยไม่ต้องกังวลเรื่องการสูญเสียคุณภาพหรือข้อมูล.

{{% alert color="info" %}}
See also: [Clone Slides](https://docs.aspose.com/slides/th/androidjava/clone-slides/)
{{% /alert %}}

### **สิ่งที่สามารถรวมได้**

* การนำเสนอทั้งหมด. สไลด์ทั้งหมดจากการนำเสนอจะถูกรวมเข้าในการนำเสนอเดียว
* สไลด์เฉพาะ. สไลด์ที่เลือกจะรวมเป็นการนำเสนอเดียว
* การนำเสนอในรูปแบบเดียวกัน (เช่น PPT ไปยัง PPT, PPTX ไปยัง PPTX เป็นต้น) และในรูปแบบที่ต่างกัน (เช่น PPT ไปยัง PPTX, PPTX ไปยัง ODP เป็นต้น) ต่อกัน

### **ตัวเลือกการรวม**

* แต่ละสไลด์ในการนำเสนอผลลัพธ์จะคงสไตล์ที่เป็นเอกลักษณ์
* ใช้สไตล์เฉพาะสำหรับสไลด์ทั้งหมดในการนำเสนอผลลัพธ์.

เพื่อรวมการนำเสนอ Aspose.Slides ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (จากอินเทอร์เฟซ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection)) มีการนำเสนอหลายรูปแบบของเมธอด `AddClone` ที่กำหนดพารามิเตอร์ของกระบวนการรวมการนำเสนอ แต่ละอ็อบเจกต์ Presentation มีคอลเลกชัน [Slides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) ดังนั้นคุณสามารถเรียกเมธอด `AddClone` จากการนำเสนอที่ต้องการรวมสไลด์เข้าได้.

เมธอด `AddClone` จะคืนค่าอ็อบเจกต์ `ISlide` ซึ่งเป็นสำเนาของสไลด์ต้นทาง สไลด์ในการนำเสนอผลลัพธ์เป็นเพียงสำเนาของสไลด์จากต้นทาง ดังนั้นคุณสามารถเปลี่ยนแปลงสไลด์ที่ได้ (เช่น การใช้สไตล์หรือตัวเลือกการจัดรูปแบบหรือเลย์เอาต์) ได้โดยไม่ต้องกังวลว่าการนำเสนอเดิมจะได้รับผลกระทบ.

## **รวมการนำเสนอ**

Aspose.Slides ให้เมธอด [**AddClone(ISlide)**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ที่ช่วยให้คุณรวมสไลด์โดยที่สไลด์คงเลย์เอาต์และสไตล์ไว้ (พารามิเตอร์เริ่มต้น).

โค้ด Java นี้แสดงวิธีการรวมการนำเสนอ:
```java
import com.aspose.slides.*;

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

## **รวมการนำเสนอด้วย Slide Master**

Aspose.Slides ให้เมธอด [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ที่ช่วยให้คุณรวมสไลด์พร้อมกับการใช้เทมเพลต Slide Master ของการนำเสนอ วิธีนี้ทำให้คุณสามารถเปลี่ยนสไตล์ของสไลด์ในการนำเสนอผลลัพธ์ได้หากต้องการ.

โค้ด Java นี้สาธิตการทำงานที่อธิบาย:
```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
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
เลย์เอาต์ของสไลด์สำหรับ slide master จะถูกกำหนดโดยอัตโนมัติ เมื่อไม่สามารถกำหนดเลย์เอาต์ที่เหมาะสมได้ หากพารามิเตอร์ boolean `allowCloneMissingLayout` ของเมธอด `AddClone` ถูกตั้งเป็น true จะใช้เลย์เอาต์ของสไลด์ต้นทาง มิฉะนั้น จะเกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/PptxEditException).
{{% /alert %}}

หากคุณต้องการให้สไลด์ในการนำเสนอผลลัพธ์มีเลย์เอาต์สไลด์ที่แตกต่างกัน ให้ใช้เมธอด [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) แทนเมื่อทำการรวม.

## **รวมสไลด์เฉพาะจากการนำเสนอ**

การรวมสไลด์เฉพาะจากหลายการนำเสนอเป็นประโยชน์สำหรับการสร้างชุดสไลด์ที่กำหนดเอง Aspose.Slides สำหรับ Android ผ่าน Java ให้คุณเลือกและนำเข้าเฉพาะสไลด์ที่ต้องการ API จะรักษาการจัดรูปแบบ, เลย์เอาต์ และการออกแบบของสไลด์ต้นฉบับ.

โค้ด Java ด้านล่างสร้างการนำเสนอใหม่ เพิ่มสไลด์หัวเรื่องจากสองการนำเสนออื่นและบันทึกผลลัพธ์ลงไฟล์:
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

## **รวมการนำเสนอด้วยเลย์เอาต์สไลด์**

โค้ด Java นี้แสดงวิธีการรวมสไลด์จากการนำเสนอพร้อมกับการใช้เลย์เอาต์สไลด์ที่คุณต้องการ เพื่อให้ได้การนำเสนอผลลัพธ์หนึ่งไฟล์:
```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **รวมการนำเสนอที่มีขนาดสไลด์แตกต่างกัน**

{{% alert title="Note" color="warning" %}} 
คุณไม่สามารถรวมการนำเสนอที่มีขนาดสไลด์แตกต่างกันได้. 
{{% /alert %}}

เพื่อรวมการนำเสนอ 2 รายการที่มีขนาดสไลด์แตกต่างกัน คุณต้องปรับขนาดของหนึ่งการนำเสนอให้ตรงกับขนาดของอีกการนำเสนอหนึ่ง.

โค้ดตัวอย่างนี้สาธิตการทำงานที่อธิบาย:
```java
import com.aspose.slides.*;

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

## **รวมสไลด์ไปยังส่วนของการนำเสนอ**

โค้ด Java นี้แสดงวิธีการรวมสไลด์เฉพาะไปยังส่วนหนึ่งของการนำเสนอ:
```java
import com.aspose.slides.*;

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

สไลด์จะถูกเพิ่มไปที่ท้ายของส่วนนั้น.

{{% alert title="Tip" color="info" %}} 
Aspose มีแอปเว็บ [Collage ฟรี](https://products.aspose.app/slides/th/collage). ใช้บริการออนไลน์นี้คุณสามารถรวมภาพ [JPG เป็น JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG เป็น PNG, สร้าง [กริดภาพ](https://products.aspose.app/slides/th/collage/photo-grid) และอื่น ๆ 
{{% /alert %}}

## **คำถามที่พบบ่อย**

### มีข้อจำกัดเรื่องจำนวนสไลด์เมื่อทำการรวมการนำเสนอหรือไม่?

ไม่มีข้อจำกัดอย่างเข้มงวด Aspose.Slides สามารถจัดการไฟล์ขนาดใหญ่ได้ แต่ประสิทธิภาพขึ้นอยู่กับขนาดไฟล์และทรัพยากรของระบบ สำหรับการนำเสนอที่ใหญ่มาก แนะนำให้ใช้ JVM 64-bit และจัดสรรหน่วยความจำ heap ให้เพียงพอ.

### สามารถรวมการนำเสนอที่มีวิดีโอหรือเสียงฝังอยู่ได้หรือไม่?

ได้ Aspose.Slides จะรักษาเนื้อหามัลติมีเดียที่ฝังอยู่ในสไลด์ไว้ แต่ไฟล์การนำเสนอสุดท้ายอาจใหญ่ขึ้นอย่างมีนัยสำคัญ.

### ฟอนต์จะถูกเก็บรักษาไว้เมื่อตอนรวมการนำเสนอหรือไม่?

ใช่ ฟอนต์ที่ใช้ในการนำเสนอเดิมจะถูกเก็บไว้ในไฟล์ผลลัพธ์โดยสมมติว่าฟอนต์นั้นติดตั้งบนระบบหรือ [ฝังไว้](/slides/th/androidjava/embedded-font/).