---
title: ผสานการนำเสนออย่างมีประสิทธิภาพบน Android
linktitle: ผสานการนำเสนอ
type: docs
weight: 40
url: /th/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีผสานการนำเสนอ PowerPoint และ OpenDocument บน Android ด้วยการโคลนสไลด์, ควบคุมมาสเตอร์และเลเอาต์, ปรับขนาดเนื้อหาสไลด์, คงส่วน, และจัดการไฟล์ที่มีการป้องกันหรือขนาดใหญ่."
---
## **ภาพรวม**

Aspose.Slides for Android via Java ผสานการนำเสนอโดยการโคลนสไลด์จากหนึ่ง [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ไปยังอีกอัน หน่วยงานหลักคือ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) ซึ่งสามารถรักษาการจัดรูปแบบของสไลด์ต้นฉบับหรือแนบสไลด์ที่โคลนไปยังมาสเตอร์หรือเลเอาต์ในการนำเสนอปลายทางได้

บทความนี้ครอบคลุมขั้นตอนการผสานที่ใช้บ่อยที่สุด:

- ผสานสไลด์ทั้งหมดพร้อมคงการจัดรูปแบบของต้นฉบับ;
- ผสานสไลด์ที่เลือก;
- ใช้มาสเตอร์จากการนำเสนอปลายทาง;
- ใช้เลเอาต์เฉพาะจากการนำเสนอปลายทาง;
- ปรับขนาดสไลด์ที่แตกต่างกันก่อนการผสาน;
- เพิ่มสไลด์ที่โคลนไปยังส่วน;
- ผสานหลายการนำเสนอในกระบวนการต้นสุดถึงปลายสุดหนึ่งเดียว;
- จัดการมาสเตอร์, แหล่งข้อมูล, โน้ต, ความคิดเห็น, สื่อ, ฟอนต์, รหัสผ่าน, ไฟล์ขนาดใหญ่, และข้อกังวลเกี่ยวกับการทำงานหลายเธรด

## **การโคลนสไลด์มีผลต่อมาสเตอร์และเลเอาต์อย่างไร**

สไลด์สืบทอดลักษณะที่ปรากฏส่วนใหญ่จากเลเอาต์และมาสเตอร์ ด้วยเหตุนี้ การเลือก overload ของการโคลนที่คุณใช้จะกำหนดว่าการผสานสไลด์จะถูกผสานเข้ากับการนำเสนอปลายทางอย่างไร

ใช้ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/) ด้วยวิธีใดวิธีหนึ่งต่อไปนี้:

- `addClone(sourceSlide)` — คงเลเอาต์และการจัดรูปแบบของสไลด์ต้นฉบับ เมื่อจำเป็น มาสเตอร์ต้นฉบับจะถูกโคลนเข้าไปในการนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตามมาสเตอร์ที่โคลนอัตโนมัติ เพื่อไม่ให้สไลด์ที่ใช้มาสเตอร์เดียวกันถูกโคลนซ้ำหลายครั้ง
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — แนบสไลด์ที่โคลนไปยัง [IMasterSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/) เฉพาะของปลายทาง Aspose.Slides จะค้นหาเลเอาต์ที่ตรงกับประเภทหรือชื่อภายใต้มาสเตอร์นั้น
- `addClone(sourceSlide, destinationLayout)` — แนบสไลด์ที่โคลนตรงไปยัง [ILayoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/) เฉพาะของปลายทาง

มาสเตอร์หรือเลเอาต์ที่ส่งให้ overload `addClone` ต้องเป็นของ **การนำเสนอปลายทาง** ไม่ใช่ของการนำเสนอแหล่ง

## **ผสานการนำเสนอทั้งหมดและคงการจัดรูปแบบของต้นฉบับ**

การผสานที่ง่ายที่สุดคือคัดลอกสไลด์ทุกสไลด์จากการนำเสนอแหล่งไปยังการนำเสนอปลายทาง นี่เป็นตัวเลือกที่เหมาะสมเมื่อสไลด์ที่นำเข้าควรคงธีม, มาสเตอร์, และความสัมพันธ์ของเลเอาต์เดิม

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

การนำเสนอที่ได้อาจมีมาสเตอร์หลายตัวเมื่อแหล่งและปลายทางใช้ดีไซน์ที่แตกต่างกัน ซึ่งเป็นพฤติกรรมที่คาดหวังเมื่อต้องการคงการจัดรูปแบบของต้นฉบับ

## **ผสานสไลด์ที่เลือก**

คุณไม่จำเป็นต้องโคลนสไลด์ทุกสไลด์ ตัวอย่างต่อไปนี้จะนำเข้าเฉพาะดัชนีสไลด์ที่เลือกจากการนำเสนอแหล่ง

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

ตรวจสอบดัชนีสไลด์ก่อนโคลนเมื่อมาจากการป้อนข้อมูลของผู้ใช้หรือการตั้งค่าภายนอก

## **ผสานสไลด์โดยใช้มาสเตอร์ปลายทาง**

ใช้ overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) เมื่อสไลด์ที่นำเข้าควรปฏิบัติตามมาสเตอร์ที่มีอยู่แล้วในการนำเสนอปลายทาง

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides จะเลือกเลเอาต์ที่เหมาะสมภายใต้มาสเตอร์ที่ระบุโดยการจับคู่ประเภทหรือชื่อของเลเอาต์ต้นฉบับ หากไม่มีเลเอาต์ที่เหมาะสมและ `allowCloneMissingLayout` เป็น `true` เลเอาต์ต้นฉบับจะถูกโคลนเพื่อให้สไลด์สามารถเพิ่มได้ หากเป็น `false` จะเกิด [PptxEditException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxeditexception/) ขึ้น

ใช้ค่า `false` เมื่อคุณต้องการให้การผสานล้มเหลวแทนที่จะเพิ่มเลเอาต์ใหม่ในมาสเตอร์ปลายทาง

## **ผสานสไลด์โดยใช้เลเอาต์ปลายทางเฉพาะ**

ใช้ overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) เมื่อคุณทราบเลเอาต์ปลายทางที่สไลด์นำเข้าควรใช้อย่างชัดเจน

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

การใช้เลเอาต์ปลายทางจะเปลี่ยนความสัมพันธ์เลเอาต์ที่สืบทอด แต่ไม่ได้ออกแบบเนื้อหาของสไลด์ต้นฉบับใหม่ หากเลเอาต์ของแหล่งและปลายทางมีโครงสร้าง placeholder ที่แตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบและพฤติกรรม placeholder ที่สืบทอดนั้นเหมาะสม

## **ผสานการนำเสนอที่มีขนาดสไลด์ต่างกัน**

การนำเสนอที่มีขนาดสไลด์ต่างกันสามารถผสานได้ แต่การโคลนสไลด์ไปยังการนำเสนอที่มีขนาดสไลด์อื่น ๆ จะไม่ออกแบบเนื้อหาใหม่โดยอัตโนมัติสำหรับพื้นที่ผืนผ้าใบใหม่ รูปร่างอาจปรากฏถูกย้าย, ยืดหรือหายไปนอกพื้นที่ที่มองเห็นได้

แนวทางที่เป็นประโยชน์คือปรับขนาดการนำเสนอแหล่งก่อนโคลน วิธีการ [SlideSize.setSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) สามารถขยายเนื้อหาเดิมพร้อมกับเปลี่ยนขนาดสไลด์ได้ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidesizescaletype/) จะสเกลเนื้อหาให้พอดีกับขนาดที่ร้องขอ

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

การปรับขนาดจะเปลี่ยนวัตถุการนำเสนอแหล่งในหน่วยความจำ หากคุณต้องการให้การนำเสนอแหล่งต้นฉบับคงอยู่สำหรับการดำเนินการอื่น ๆ ให้เปิดอินสแตนซ์แยกสำหรับการผสาน

## **ผสานสไลด์เข้าส่วนของการนำเสนอ**

ลูปโคลนสไลด์พื้นฐานจะไม่สร้างลำดับชั้นส่วนของการนำเสนอแหล่ง หากส่วนสำคัญในผลลัพธ์ ให้สร้างหรือเลือกส่วนในการนำเสนอปลายทางและโคลนสไลด์เข้าไปโดยใช้ [addClone(ISlide, ISection)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

สไลด์ที่โคลนจะถูกเพิ่มต่อท้ายส่วนปลายทางที่ระบุ เพื่อคงหลายส่วนแหล่ง ให้วนลูป [Presentation.getSections](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSections--) ดึงสไลด์ของแต่ละส่วนแหล่งด้วย [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) สร้างส่วนในปลายทางใหม่ แล้วโคลนสไลด์ที่ได้เข้าไปยังส่วนที่สอดคล้องกัน ดูตัวอย่างการจัดการส่วนสไลด์เต็มรูปแบบที่ [Manage Slide Sections](/slides/th/androidjava/slide-section/) ซึ่งรวมถึงส่วนที่ว่างเปล่าและการเปลี่ยนแปลงโครงสร้าง

## **ผสานหลายการนำเสนออย่างปลอดภัย**

ตัวอย่าง end-to-end ด้านล่างใช้การนำเสนอแรกเป็นปลายทาง ปรับขนาดสไลด์ของแต่ละแหล่งเพิ่มเติม เปิดแต่ละแหล่งเฉพาะในช่วงที่กำลังคัดลอก และบันทึกไฟล์สุดท้ายเพียงครั้งเดียว

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

นี่เป็นฐานที่เป็นประโยชน์สำหรับการคงการจัดรูปแบบของสไลด์ที่นำเข้า หากผลลัพธ์ของคุณต้องใช้ธีมเดียวของปลายทาง ให้แทนที่การเรียก `addClone(slide)` อย่างง่ายด้วย overload มาสเตอร์หรือเลเอาต์ปลายทางที่แสดงไว้ก่อนหน้านี้

## **ข้อพิจารณาเชิงปฏิบัติ**

### **มาสเตอร์, เลเอาต์, และความแม่นยำของการจัดรูปแบบ**

การโคลนสไลด์เริ่มต้นสามารถนำมาสเตอร์ที่จำเป็นจากแหล่งเข้าสู่การนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะเก็บ registry ภายในสำหรับมาสเตอร์ที่โคลนอัตโนมัติเพื่อหลีกเลี่ยงการโคลนมาสเตอร์เดียวกันซ้ำหลายครั้ง มาสเตอร์ที่โคลนด้วยมือจะไม่ได้รับการติดตามโดย registry นั้น ดังนั้นหลีกเลี่ยงการโคลนมาสเตอร์ล่วงหน้า เว้นแต่คุณต้องการควบคุมโครงสร้างมาสเตอร์อย่างชัดเจน

อย่าสมมติว่ามาสเตอร์หรือเลเอาต์สองตัวที่มีชื่อเดียวกันจะมีลักษณะเหมือนกัน หากเทมเพลตองค์กรต้องควบคุมรูปลักษณ์สุดท้าย ให้เลือกมาสเตอร์หรือเลเอาต์ปลายทางอย่างชัดเจนและตรวจสอบผลลัพธ์หลังการผสาน

### **โน้ตและความคิดเห็น**

โน้ตของผู้พูดและความคิดเห็นของสไลด์เชื่อมโยงกับเนื้อหาสไลด์และจะถูกคัดลอกเมื่อสไลด์ถูกโคลน Aspose.Slides ยังมี API เฉพาะสำหรับ [presentation notes](/slides/th/androidjava/presentation-notes/) และ [presentation comments](/slides/th/androidjava/presentation-comments/)

หากการจัดรูปแบบของหน้าโน้ตสำคัญ ให้ตรวจสอบการนำเสนอที่ผสานแล้ว เนื่องจากโน้ตมาสเตอร์เป็นออบเจ็กต์ระดับการนำเสนอและอาจแตกต่างกันระหว่างไฟล์แหล่ง สำหรับกระบวนการตรวจสอบ ให้ตรวจสอบผู้เขียนความคิดเห็นและชุดความคิดเห็นแบบเธรดหลังจากรวมไฟล์จากผู้เขียนหรือเทมเพลตที่ต่างกัน

### **รูปภาพ, เสียง, วีดีโอ, วัตถุ OLE, และลิงก์ภายนอก**

สไลด์อาจอ้างอิงทรัพยากรระดับการนำเสนอ เช่น รูปภาพ, เสียงฝัง, วีดีโอฝัง, และข้อมูล OLE ให้โคลนสไลด์ทั้งหมดแทนที่จะคัดลอกแค่รูปร่างที่มองเห็น เพื่อให้ Aspose.Slides รักษาความสัมพันธ์ของสไลด์กับทรัพยากรเหล่านั้น

ทรัพยากรที่ฝังและที่ลิงก์ควรจัดการแยกกัน ลิงก์เสียง, วีดีโอ, วัตถุ OLE หรือไฮเปอร์ลิงก์ที่ลิงก์จะยังคงพึ่งพาเป้าหมายภายนอก; การโคลนสไลด์จะไม่เปลี่ยนลิงก์ภายนอกเป็นเนื้อหาที่ฝัง ทดสอบเส้นทางและ URL ของทรัพยากรลิงก์ในสภาพแวดล้อมที่การนำเสนอที่ผสานจะถูกเปิด

แม้ Aspose.Slides จะติดตามมาสเตอร์ที่โคลนอัตโนมัติ แต่ไม่ควรถือว่าเป็นการรับประกันทั่วไปว่าทรัพยากรไบนารีที่เหมือนกันจากแหล่งที่ไม่เกี่ยวข้องจะถูกดึงซ้ำโดยอัตโนมัติ หากขนาดไฟล์ผลลัพธ์สำคัญ ให้ตรวจสอบแพ็กเกจที่ผสานและวัดผลลัพธ์แทนการพึ่งพาการดึงซ้ำโดยนัย

### **ฟอนต์ที่ฝังและความพร้อมใช้งานของฟอนต์**

ฟอนต์ถูกจัดการระดับการนำเสนอ หากต้องการให้การพิมพ์คงที่บนเครื่องต่าง ๆ อย่าสมมติว่าการโคลนสไลด์อย่างเดียวจะทำให้ฟอนต์ที่ต้องการทั้งหมดพร้อมใช้งานในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ที่ฝังด้วย [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) และจัดการการฝังอย่างชัดเจนตามที่อธิบายใน [Embed Fonts in Presentations](/slides/th/androidjava/embedded-font/)

นอกจากนี้ ให้ตรวจสอบว่าคุณมีสิทธิ์ฝังฟอนต์ที่ใช้ในไฟล์แหล่งหรือไม่ เนื่องจากสัญญาอนุญาตฟอนต์อาจจำกัดการฝัง

### **การนำเสนอที่มีรหัสผ่าน**

แหล่งที่มีรหัสผ่านต้องเปิดสำเร็จก่อนที่สไลด์จะถูกโคลน ให้ส่งรหัสผ่านผ่าน [LoadOptions.setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // ทำงานกับการนำเสนอที่ถอดรหัสแล้ว.
} finally {
    source.dispose();
}
```

การเปิดแหล่งที่เข้ารหัสจะไม่ได้ทำให้การนำเสนอปลายทางได้รับการป้องกันเดียวกัน ให้กำหนดการป้องกันผลลัพธ์แยกต่างหากเมื่อจำเป็น

### **การนำเสนอขนาดใหญ่และการใช้หน่วยความจำ**

การนำเสนอขนาดใหญ่ที่มีรูปภาพความละเอียดสูง, เสียง, วีดีโอ, หรือวัตถุไบนารีขนาดใหญ่สามารถใช้หน่วยความจำอย่างมากได้ [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) ให้การควบคุมการจัดการ BLOB และการใช้ไฟล์ชั่วคราว ดู [Manage Presentation BLOBs](/slides/th/androidjava/manage-blob/) สำหรับกลยุทธ์ไฟล์ขนาดใหญ่

สำหรับไฟล์ขนาดใหญ่ ควรโหลดจากเส้นทางไฟล์เมื่อทำได้, ปล่อยการนำเสนอแหล่งแต่ละอันทันทีที่ผสานเสร็จ, และหลีกเลี่ยงการบันทึกผลลัพธ์กลางบ่อยเกินไปหากเวิร์กโฟลว์ไม่ต้องการจุดตรวจ

### **ความปลอดภัยของเธรด**

ห้ามโหลด, แก้ไข, บันทึก, หรือโคลนอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้แต่ละอินสแตนซ์การนำเสนออยู่ในกระบวนการผสานเดียว หากคุณทำงานแบบขนานกับงานที่อิสระ ให้ใช้อินสแตนซ์การนำเสนอแยกกันและปฏิบัติตามคำแนะนำการทำงานหลายเธรดของ Aspose.Slides [/slides/th/androidjava/multithreading/]

## **FAQ**

**ฉันจะรักษาการออกแบบดั้งเดิมของแต่ละการนำเสนอแหล่งได้อย่างไร?**

ใช้ [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) โดยไม่ระบุมาสเตอร์หรือเลเอาต์ปลายทาง Aspose.Slides สามารถโคลนมาสเตอร์ต้นฉบับโดยอัตโนมัติเมื่อสไลด์ที่นำเข้าต้องการ

**ฉันจะทำให้สไลด์ที่นำเข้าใช้ธีมของปลายทางได้อย่างไร?**

ใช้ overload ที่รับมาสเตอร์ปลายทาง ส่งมาสเตอร์จากการนำเสนอปลายทาง ไม่ใช่จากแหล่ง Aspose.Slides จะพยายามแมปสไลด์ต้นฉบับแต่ละสไลด์ไปยังเลเอตต์ที่เหมาะสมภายใต้มาสเตอร์นั้น

**ควรใช้เลเอาต์ปลายทางเฉพาะเมื่อใดแทนมาสเตอร์ปลายทาง?**

ใช้เลเอาต์เฉพาะเมื่อสไลด์ที่นำเข้าทุกสไลด์ต้องใช้เลเอาต์ที่รู้จักอย่างชัดเจน ใช้มาสเตอร์เมื่อคุณต้องการให้ Aspose.Slides เลือกจากเลเอตต์ของมาสเตอร์นั้นตามประเภทหรือชื่อของเลเอตต์ต้นฉบับ

**สามารถผสานการนำเสนอที่มีขนาดสไลด์ต่างกันได้หรือไม่?**

ทำได้ แต่เนื้อหาสไลด์จะไม่ถูกออกแบบใหม่โดยอัตโนมัติสำหรับมิติปลายทาง ปรับขนาดการนำเสนอแหล่งก่อนเมื่อคุณต้องการตำแหน่งที่คาดการณ์ได้ เช่น ด้วย [SlideSize.setSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) และ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidesizescaletype/)

**ฉันสามารถผสานไฟล์ PPT, PPTX, และ ODP เข้าเป็นไฟล์เดียวได้หรือไม่?**

ทำได้ โหลดแต่ละการนำเสนอแหล่ง โคลนสไลด์ที่ต้องการเข้าสู่ปลายทางหนึ่ง และบันทึกปลายทางในรูปแบบที่รองรับ เนื่องจากฟอร์แมตการนำเสนออาจไม่สนับสนุนคุณลักษณะเดียวกันทั้งหมด โปรดตรวจสอบเนื้อหาซับซ้อนหลังการผสานข้ามฟอร์แมต ดูที่ [Supported File Formats](/slides/th/androidjava/supported-file-formats/)

**ส่วนของแหล่งถูกเก็บรักษาโดยอัตโนมัติหรือไม่?**

ไม่ใช่ด้วยลูปพื้นฐานที่โคลนสไลด์เท่านั้น ต้องสร้างส่วนที่ต้องการในปลายทางและใช้ overload ส่วนของ [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) เมื่อจำเป็นต้องคงโครงสร้างส่วน

**โน้ตและความคิดเห็นถูกเก็บรักษาหรือไม่?**

ถูกคัดลอกพร้อมกับสไลด์ที่โคลน สำหรับเวิร์กโฟลว์ที่ขึ้นกับการจัดรูปแบบของโน้ตมาสเตอร์, ผู้เขียนความคิดเห็น, หรือข้อมูลรีวิวแบบเธรด โปรดตรวจสอบผลลัพธ์การผสาน เพราะสถานการณ์เหล่านั้นเกี่ยวข้องกับโครงสร้างระดับการนำเสนอเช่นเดียวกับเนื้อหาระดับสไลด์

**เสียง, วีดีโอ, วัตถุ OLE, และไฮเปอร์ลิงก์จะเกิดอะไรขึ้น?**

เนื้อหาที่ฝังจะถูกพกพาเป็นส่วนหนึ่งของความสัมพันธ์ทรัพยากรของสไลด์ที่โคลน ลิงก์ภายนอกจะคงเป็นลิงก์ภายนอก ดังนั้นไฟล์หรือ URL เป้าหมายต้องยังคงพร้อมใช้งานหลังการผสาน

**ฟอนต์ที่ฝังจากทุกแหล่งรับประกันว่าจะพร้อมใช้งานในการนำเสนอที่ผสานหรือไม่?**

อย่าอ้างอิงการโคลนสไลด์อย่างเดียวสำหรับการจัดหาฟอนต์ ตรวจสอบฟอนต์ที่ฝังในปลายทางและจัดการการฝังฟอนต์หรือความพร้อมใช้งานฟอนต์ภายนอกอย่างชัดเจนเมื่อการพิมพ์เป็นสิ่งสำคัญ

**ฉันจะผสานไฟล์ที่มีรหัสผ่านได้อย่างไร?**

เปิดด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ที่ถูกต้องแล้วโคลนสไลด์ตามปกติ การปกป้องผลลัพธ์ต้องกำหนดแยกต่างหาก

**ควรจัดการการนำเสนอขนาดใหญ่อย่างไร?**

ใช้การจัดการ BLOB เมื่อวัตถุไบนารีใหญ่เป็นส่วนใหญ่ของหน่วยความจำ เลือกโหลดจากเส้นทางไฟล์สำหรับไฟล์ขนาดใหญ่ ปล่อยการนำเสนอแหล่งโดยเร็วหลังการผสาน และบันทึกผลลัพธ์สุดท้ายเฉพาะเมื่อจำเป็น

**ฉันสามารถผสานสไลด์จากหลายเธรดได้หรือไม่?**

ห้ามใช้อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้แต่ละกระบวนการผสานแยกออกเป็นอินสแตนซ์การนำเสนอของตนเอง