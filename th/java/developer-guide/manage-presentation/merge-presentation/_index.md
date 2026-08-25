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
description: "เรียนรู้วิธีการรวมการนำเสนอ PowerPoint และ OpenDocument ใน Java ด้วยการโคลนสไลด์, ควบคุมมาสเตอร์และเลเอาต์, ปรับขนาดเนื้อหาสไลด์, คงส่วน, และจัดการไฟล์ที่มีการป้องกันหรือขนาดใหญ่."
---
## **ภาพรวม**

Aspose.Slides for Java รวมการนำเสนอโดยการโคลนสไลด์จากหนึ่ง [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ไปยังอีกอันหนึ่ง การดำเนินการหลักคือ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), ซึ่งสามารถคงรูปแบบของสไลด์ต้นฉบับหรือแนบสไลด์ที่โคลนไปยังมาสตาหรือเลเอาต์ในการนำเสนอปลายทางได้

บทความนี้ครอบคลุมการทำงานที่พบบ่อยที่สุดสำหรับการรวม:

- รวมสไลด์ทั้งหมดโดยคงรูปแบบของแหล่งที่มา
- รวมสไลด์ที่เลือกเท่านั้น
- ใช้มาสเตอร์จากการนำเสนอปลายทาง
- ใช้เลเอาต์เฉพาะจากการนำเสนอปลายทาง
- ปรับขนาดสไลด์ให้เป็นมาตรฐานก่อนการรวม
- เพิ่มสไลด์ที่โคลนไปยังส่วน (section)
- รวมหลายการนำเสนอในกระบวนการปลายทางต่อเนื่องหนึ่งขั้นตอน
- จัดการมาสตา, ทรัพยากร, โน้ต, ความคิดเห็น, สื่อ, ฟอนต์, รหัสผ่าน, ไฟล์ขนาดใหญ่, และประเด็นการทำงานหลายเธรด

## **วิธีที่การโคลนสไลด์มีผลต่อมาสเตอร์และเลเอาต์**

สไลด์สืบทอดลักษณะหลายอย่างจากเลเอาต์และมาสเตอร์ ด้วยเหตุนี้ การโอเวอร์โหลดการโคลนที่คุณเลือกจึงกำหนดว่าการรวมสไลด์จะถูกบูรณาการอย่างไรในการนำเสนอปลายทาง

ใช้ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/) ในหนึ่งจากวิธีต่อไปนี้:

- `addClone(sourceSlide)` — คงเลเอาต์และรูปแบบของสไลด์ต้นฉบับ หากจำเป็น มาสเตอร์ต้นฉบับสามารถถูกโคลนเข้าสู่การนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตามมาสตาที่ถูกโคลนโดยอัตโนมัติเพื่อไม่ให้สไลด์ที่ใช้มาสเตอร์เดียวกันโคลนมาสเตอร์ซ้ำหลายครั้ง
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — แนบสไลด์ที่โคลนไปยัง [IMasterSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslide/) ปลายทางที่ระบุ Aspose.Slides จะค้นหาเลเอาต์ที่ตรงกันภายใต้มาสเตอร์นั้นตามประเภทหรือชื่อของเลเอาต์
- `addClone(sourceSlide, destinationLayout)` — แนบสไลด์ที่โคลนโดยตรงไปยัง [ILayoutSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/) ปลายทางที่ระบุ

มาสเตอร์หรือเลเอาต์ที่ส่งให้โอเวอร์โหลด `addClone` ต้องเป็นของ **การนำเสนอปลายทาง**, ไม่ใช่ของการนำเสนอแหล่งที่มา

## **รวมการนำเสนอทั้งหมดและคงรูปแบบของแหล่งที่มา**

การรวมที่ง่ายที่สุดคือคัดลอกทุกสไลด์จากการนำเสนอแหล่งที่มายังการนำเสนอปลายทาง นี่เป็นตัวเลือกที่เหมาะเมื่อสไลด์ที่นำเข้าต้องคงธีม, มาสเตอร์, และความสัมพันธ์ของเลเอาต์เดิมของมัน

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

การนำเสนอที่ได้อาจมีมาสตาหลายตัวเมื่อแหล่งที่มาและปลายทางใช้การออกแบบที่แตกต่างกัน ซึ่งเป็นพฤติกรรมที่คาดหวังเมื่อคงรูปแบบของแหล่งที่มาโดยเจตนา

## **รวมสไลด์ที่เลือกเท่านั้น**

คุณไม่จำเป็นต้องโคลนทุกสไลด์ ตัวอย่างต่อไปนี้นำเข้าเฉพาะดัชนีสไลด์ที่เลือกจากการนำเสนอแหล่งที่มา

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

ตรวจสอบดัชนีสไลด์ก่อนการโคลนเมื่อมาจากการป้อนข้อมูลของผู้ใช้หรือการกำหนดค่าภายนอก

## **รวมสไลด์โดยใช้มาสเตอร์ปลายทาง**

ใช้โอเวอร์โหลด [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) เมื่อสไลด์ที่นำเข้าต้องปฏิบัติตามมาสเตอร์ที่เป็นของการนำเสนอปลายทางแล้ว

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

Aspose.Slides จะเลือกเลเอาต์ที่เหมาะสมภายใต้มาสเตอร์ที่ระบุโดยการจับคู่ประเภทหรือชื่อของเลเอาต์ต้นฉบับ หากไม่มีเลเอาต์ที่เหมาะสมและ `allowCloneMissingLayout` เป็น `true` จะมีการโคลนเลเอาต์ต้นฉบับเพื่อให้สามารถเพิ่มสไลด์ได้ หากเป็น `false` จะมีการโยน [PptxEditException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxeditexception/)

ใช้ `false` เมื่อคุณต้องการให้การรวมล้มเหลวแทนการเพิ่มเลเอาต์เพิ่มเติมเข้าสู่มาสเตอร์ปลายทาง

## **รวมสไลด์โดยใช้เลเอาต์ปลายทางที่เฉพาะเจาะจง**

ใช้โอเวอร์โหลด [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) เมื่อคุณรู้ชัดเจนว่าต้องการใช้เลเอาต์ปลายทางใดสำหรับสไลด์ที่นำเข้า

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

การใช้เลเอาต์ปลายทางจะเปลี่ยนความสัมพันธ์ของเลเอาต์ที่สืบทอด; มันไม่ทำการออกแบบใหม่ของเนื้อหาสไลด์ต้นฉบับ หากเลเอาต์ของแหล่งที่มาและปลายทางมีโครงสร้าง placeholder ที่แตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบและพฤติกรรมของ placeholder ที่สืบทอดนั้นเหมาะสม

## **รวมการนำเสนอที่มีขนาดสไลด์ต่างกัน**

การนำเสนอที่มีมิติสไลด์ต่างกันสามารถรวมกันได้ แต่การโคลนสไลด์เข้าสู่การนำเสนอที่มีขนาดสไลด์อื่นไม่ทำการออกแบบเนื้อหาใหม่อัตโนมัติสำหรับผ้าใบใหม่ รูปร่างอาจปรากฏถูกเคลื่อนที่, ย่อ/ขยายอย่างไม่คาดคิด, หรืออยู่นอกพื้นที่สไลด์ที่มองเห็นได้

แนวทางที่เป็นประโยชน์คือปรับขนาดการนำเสนอแหล่งที่มาก่อนการโคลน วิธี [SlideSize.setSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesize/#setSize-float-float-int-) สามารถสเกลเนื้อหาที่มีอยู่ขณะเปลี่ยนขนาดสไลด์ได้ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesizescaletype/) จะสเกลเนื้อหาให้พอดีกับขนาดที่ร้องขอ

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
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

การปรับขนาดจะเปลี่ยนวัตถุการนำเสนอแหล่งที่มาในหน่วยความจำ หากคุณต้องการให้การนำเสนอแหล่งที่มาต้นฉบับไม่เปลี่ยนแปลงสำหรับการดำเนินการอื่น ๆ ให้เปิดอินสแตนซ์แยกสำหรับการรวม

## **รวมสไลด์เข้าสู่ส่วนของการนำเสนอ**

ลูปการโคลนสไลด์พื้นฐานจะไม่สร้างลำดับส่วนของการนำเสนอแหล่งที่มา หากส่วนมีความสำคัญในผลลัพธ์ ให้สร้างหรือเลือกส่วนในการนำเสนอปลายทางและโคลนสไลด์เข้าไปโดยเจาะจงด้วย [addClone(ISlide, ISection)](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)

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

สไลด์ที่โคลนจะถูกเพิ่มต่อท้ายส่วนปลายทางที่ระบุ เพื่อคงหลายส่วนของแหล่งที่มา ให้วนลูป [Presentation.getSections](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSections--) แล้วดึงสไลด์ปัจจุบันของแต่ละส่วนด้วย [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/th/java/com.aspose.slides/isection/#getSlidesListOfSection--) สร้างส่วนใหม่ในปลายทาง และโคลนสไลด์ที่คืนค่ามาเข้าสู่ส่วนที่สอดคล้องกัน ดูตัวอย่างการจัดการส่วนสไลด์ที่สมบูรณ์ที่ [Manage Slide Sections](/slides/th/java/slide-section/) ซึ่งรวมถึงส่วนที่ว่างเปล่าและการเปลี่ยนแปลงโครงสร้าง

## **รวมหลายการนำเสนออย่างปลอดภัย**

ตัวอย่างต่อไปนี้เป็นกระบวนการปลายทางต่อเนื่องที่ใช้การนำเสนอแรกเป็นปลายทาง, ปรับขนาดสไลด์ของแต่ละแหล่งที่มาเพิ่มเติม, เปิดแต่ละแหล่งที่มาเฉพาะขณะที่กำลังคัดลอก, และบันทึกไฟล์สุดท้ายเมื่อเสร็จ

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
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

นี่เป็นพื้นฐานที่มีประโยชน์สำหรับการคงรูปแบบของสไลด์ที่นำเข้า หากผลลัพธ์ของคุณต้องใช้ธีมเดียวของปลายทาง ให้แทนที่การเรียก `addClone(slide)` ธรรมดาด้วยโอเวอร์โหลดมาสเตอร์หรือเลเอาต์ปลายทางที่แสดงไว้ข้างต้น

## **ข้อพิจารณาเชิงปฏิบัติ**

### **มาสเตอร์, เลเอาต์, และความแม่นยำของการจัดรูปแบบ**

การโคลนสไลด์แบบเริ่มต้นสามารถนำมาสเตอร์ของแหล่งที่มาที่จำเป็นเข้าสู่การนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะเก็บทะเบียนภายในสำหรับมาสเตอร์ที่โคลนโดยอัตโนมัติเพื่อหลีกเลี่ยงการโคลนมาสเตอร์เดียวกันซ้ำหลายครั้ง มาสเตอร์ที่โคลนด้วยตนเองจะไม่ได้รับการติดตามโดยทะเบียนนั้น ดังนั้นหลีกเลี่ยงการโคลนมาสเตอร์ล่วงหน้าหากไม่ได้ต้องการควบคุมโครงสร้างมาสเตอร์อย่างชัดเจน

อย่าเทียบว่ามาสเตอร์หรือเลเอาต์สองตัวที่มีชื่อเดียวกันเป็นภาพที่เท่าเทียมกัน หากเทมเพลตองค์กรต้องควบคุมลักษณะสุดท้าย ให้เลือกมาสเตอร์หรือเลเอาต์ปลายทางโดยเจาะจงและตรวจสอบผลลัพธ์หลังการรวม

### **โน้ตและความคิดเห็น**

โน้ตผู้บรรยายและความเห็นในสไลด์เชื่อมโยงกับเนื้อหาสไลด์และจะถูกคัดลอกเมื่อสไลด์ถูกโคลน Aspose.Slides ยังมี API เฉพาะสำหรับ [presentation notes](/slides/th/java/presentation-notes/) และ [presentation comments](/slides/th/java/presentation-comments/)

หากการจัดรูปแบบของหน้าโน้ตสำคัญ ให้ตรวจสอบการนำเสนอที่รวมแล้ว เพราะโน้ตมาสเตอร์เป็นอ็อบเจกต์ระดับการนำเสนอและอาจแตกต่างกันระหว่างไฟล์แหล่งที่มา สำหรับกระบวนการตรวจสอบ ให้ตรวจสอบผู้เขียนความคิดเห็นและเธรดของความคิดเห็นหลังจากรวมไฟล์จากผู้เขียนหรือเทมเพลตต่าง ๆ

### **รูปภาพ, เสียง, วิดีโอ, วัตถุ OLE, และลิงก์ภายนอก**

สไลด์อาจอ้างอิงถึงทรัพยากรระดับการนำเสนอเช่นรูปภาพ, เสียงฝัง, วิดีโอฝัง, และข้อมูล OLE ให้โคลนสไลด์ทั้งหมดแทนการคัดลอรูปทรงที่มองเห็นเพียงอย่างเดียวเพื่อให้ Aspose.Slides รักษาความสัมพันธ์ของสไลด์ต่อทรัพยากรเหล่านั้น

ทรัพยากรที่ฝังและที่ลิงก์ควรจัดการแตกต่างกัน เสียง, วิดีโอ, วัตถุ OLE หรือไฮเปอร์ลิงก์ที่ลิงก์ไว้ยังคงพึ่งพาเป้าหมายภายนอก; การโคลนสไลด์ไม่ทำให้ลิงก์ภายนอกกลายเป็นเนื้อหาฝัง ตรวจสอบเส้นทางและ URL ของทรัพยากรที่ลิงก์ในสภาพแวดล้อมที่การนำเสนอที่รวมจะถูกเปิด

Aspose.Slides ติดตามมาสตาที่โคลนโดยอัตโนมัติ แต่ไม่ควรถือเป็นการรับประกันทั่วไปว่าทรัพยากรไบนารีที่เหมือนกันจากการนำเสนอแหล่งที่มาไม่เกี่ยวข้องจะถูกลบซ้ำเสมอ หากขนาดไฟล์ผลลัพธ์สำคัญ ให้ตรวจสอบแพ็กเกจที่รวมและวัดผลลัพธ์แทนการพึ่งพาการลบซ้ำโดยอัตโนมัติ

### **ฟอนต์ฝังและความพร้อมของฟอนต์**

ฟอนต์ถูกจัดการระดับการนำเสนอ หากต้องการให้การพิมพ์แบบตัวอักษรสอดคล้องกันบนเครื่องต่าง ๆ อย่าตั้งสมมติว่าการโคลนสไลด์อย่างเดียวรับประกันว่าฟอนต์ที่จำเป็นทั้งหมดจะพร้อมใช้งานในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ที่ฝังด้วย [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) และจัดการการฝังอย่างชัดเจนตามที่อธิบายใน [Embed Fonts in Presentations](/slides/th/java/embedded-font/)

นอกจากนี้ตรวจสอบว่าคุณได้รับอนุญาตให้ฝังฟอนต์ที่ใช้โดยไฟล์แหล่งที่มาหรือไม่ เนื่องจากสัญญาอนุญาตฟอนต์อาจจำกัดการฝัง

### **การนำเสนอที่ป้องกันด้วยรหัสผ่าน**

แหล่งที่มาที่มีการป้องกันด้วยรหัสผ่านต้องถูกเปิดสำเร็จก่อนที่สไลด์จะถูกโคลน ให้ระบุรหัสผ่านผ่าน [LoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)

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

การเปิดไฟล์ที่เข้ารหัสจะไม่ทำให้การป้องกันเดียวกันถูกนำไปใช้กับการนำเสนอปลายทางโดยอัตโนมัติ กำหนดการป้องกันเอาต์พุตแยกต่างหากเมื่อต้องการ

### **การนำเสนอขนาดใหญ่และการใช้หน่วยความจำ**

การนำเสนอขนาดใหญ่มักมีรูปภาพความละเอียดสูง, เสียง, วิดีโอ หรือวัตถุไบนารีขนาดใหญ่ ซึ่งอาจใช้หน่วยความจำมาก [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) ให้การควบคุมการจัดการ BLOB และการใช้ไฟล์ชั่วคราว ดู [Manage Presentation BLOBs](/slides/th/java/manage-blob/) สำหรับกลยุทธ์ไฟล์ขนาดใหญ่

สำหรับไฟล์ใหญ่ ควรโหลดจากเส้นทางไฟล์เมื่อเป็นไปได้, ทำลายการนำเสนอแหล่งที่มาทันทีหลังการรวม, และหลีกเลี่ยงการบันทึกผลลัพธ์กลางซ้ำหลายครั้ง หากเวิร์กโฟลว์ต้องการจุดตรวจสอบ

### **ความปลอดภัยในการทำงานหลายเธรด**

ห้ามโหลด, แก้ไข, บันทึก หรือโคลนอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้จำกัดอินสแตนซ์ของการนำเสนอแต่ละอันให้กับการดำเนินการรวมหนึ่งครั้ง หากคุณทำงานแบบขนานกับงานอิสระ ให้ใช้อินสแตนซ์การนำเสนอที่แยกจากกันและปฏิบัติตามคำแนะนำการทำงานหลายเธรดของ Aspose.Slides ที่ /slides/th/java/multithreading/

## **FAQ**

**ฉันจะรักษาการออกแบบเดิมของแต่ละการนำเสนอแหล่งที่มาได้อย่างไร?**

ใช้ [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) โดยไม่ระบุมาสเตอร์หรือเลเอาต์ปลายทาง Aspose.Slides จะโคลนมาสเตอร์ของแหล่งที่มาที่จำเป็นโดยอัตโนมัติเมื่อสไลด์ที่นำเข้าต้องการ

**ฉันจะทำให้สไลด์ที่นำเข้าใช้ธีมของปลายทางได้อย่างไร?**

ใช้โอเวอร์โหลดที่รับมาสเตอร์ปลายทาง ส่งมาสเตอร์จากการนำเสนอปลายทาง, ไม่ใช่จากแหล่งที่มา Aspose.Slides จะพยายามแมปสไลด์แต่ละสไลด์ของแหล่งที่มายังเลเอาต์ที่เหมาะสมภายใต้มาสเตอร์นั้น

**เมื่อใดควรใช้เลเอาต์ปลายทางเฉพาะแทนมาสเตอร์ปลายทาง?**

ใช้เลเอาต์เฉพาะเมื่อสไลด์ที่นำเข้าทุกสไลด์ต้องใช้เลเอาต์เดียวที่รู้จัก ใช้มาสเตอร์เมื่อคุณต้องการให้ Aspose.Slides เลือกเลเอาต์จากมาสเตอร์นั้นตามประเภทหรือชื่อของเลเอาต์ต้นฉบับ

**การนำเสนอที่มีขนาดสไลด์ต่างกันสามารถรวมกันได้หรือไม่?**

ได้, แต่เนื้อหาสไลด์จะไม่ถูกออกแบบใหม่อัตโนมัติสำหรับมิติปลายทาง ปรับขนาดการนำเสนอแหล่งที่มาชั้นแรกเมื่อคุณต้องการตำแหน่งที่คาดเดาได้, ตัวอย่างเช่นใช้ [SlideSize.setSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesize/#setSize-float-float-int-) และ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesizescaletype/)

**ฉันสามารถรวมไฟล์ PPT, PPTX, และ ODP เข้าด้วยกันเป็นไฟล์เดียวได้หรือไม่?**

ได้. โหลดแต่ละการนำเสนอแหล่งที่มา, โคลนสไลด์ที่ต้องการเข้าสู่ปลายทางเดียว, แล้วบันทึกปลายทางในรูปแบบเอาต์พุตที่สนับสนุน เนื่องจากฟีเจอร์ของรูปแบบการนำเสนอไม่เท่ากันทั้งหมด ให้ตรวจสอบเนื้อหาซับซ้อนหลังการรวมข้ามรูปแบบ ดู [Supported File Formats](/slides/th/java/supported-file-formats/)

**ส่วนของแหล่งที่มาถูกคงไว้โดยอัตโนมัติหรือไม่?**

ไม่, หากใช้ลูปพื้นฐานที่โคลนสไลด์เท่านั้น ต้องสร้างส่วนที่ต้องการในปลายทางและใช้โอเวอร์โหลดส่วนของ [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) เมื่อจำเป็นต้องคงโครงสร้างส่วน

**โน้ตผู้บรรยายและความคิดเห็นถูกคงไว้หรือไม่?**

พวกมันถูกคัดลอกพร้อมสไลด์ที่โคลน สำหรับเวิร์กโฟลว์ที่พึ่งพาการจัดรูปแบบโน้ตมาสเตอร์, ผู้เขียนความคิดเห็น, หรือข้อมูลการตรวจสอบแบบเธรด, ให้ตรวจสอบผลลัพธ์ที่รวมแล้วเพราะสถานการณ์เหล่านี้เกี่ยวข้องกับโครงสร้างระดับการนำเสนอเช่นเดียวกับเนื้อหาระดับสไลด์

**อะไรจะเกิดขึ้นกับเสียง, วิดีโอ, วัตถุ OLE, และไฮเปอร์ลิงก์?**

เนื้อหาที่ฝังจะถูกนำไปพร้อมกับความสัมพันธ์ของทรัพยากรของสไลด์ที่โคลน ลิงก์ภายนอกจะยังคงเป็นลิงก์ภายนอก ดังนั้นไฟล์หรือ URL เป้าหมายต้องพร้อมใช้งานหลังการรวม

**ฟอนต์ที่ฝังจากทุกแหล่งที่มาจะพร้อมใช้งานในการนำเสนอที่รวมหรือไม่?**

อย่าพึ่งพาการโคลนสไลด์อย่างเดียวสำหรับการจัดหา ฟอนต์ ตรวจสอบฟอนต์ฝังของปลายทางและจัดการการฝังฟอนต์หรือความพร้อมของฟอนต์ภายนอกอย่างชัดเจนเมื่อการจัดรูปแบบตัวอักษรสำคัญ

**ฉันจะรวมไฟล์ที่ป้องกันด้วยรหัสผ่านได้อย่างไร?**

เปิดไฟล์ด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ที่ถูกต้อง, แล้วโคลนสไลด์ตามปกติ การป้องกันเอาต์พุตต้องกำหนดแยกต่างหาก

**ฉันควรจัดการกับการนำเสนอใหญ่ๆ อย่างไร?**

ใช้การจัดการ BLOB เมื่อวัตถุไบนารีขนาดใหญ่ครอบงำหน่วยความจำ, โหลดจากเส้นทางไฟล์สำหรับไฟล์ใหญ่มาก, ทำลายการนำเสนอแหล่งที่มาทันทีหลังการรวม, และบันทึกผลลัพธ์สุดท้ายเมื่อจำเป็น

**ฉันสามารถโคลนสไลด์จากหลายเธรดพร้อมกันได้หรือไม่?**

ห้ามใช้อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้แยกการดำเนินการรวมแต่ละอันออกเป็นอินสแตนซ์การนำเสนอของตนเอง.