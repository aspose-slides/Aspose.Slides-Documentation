---
title: รวมงานนำเสนออย่างมีประสิทธิภาพใน Java
linktitle: รวมงานนำเสนอ
type: docs
weight: 40
url: /th/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "เรียนรู้วิธีรวมงานนำเสนอ PowerPoint และ OpenDocument ใน Java ด้วยการโคลนสไลด์, ควบคุมมาสเตอร์และเลเอาต์, ปรับขนาดเนื้อหาสไลด์, คงส่วน, และจัดการไฟล์ที่มีการป้องกันหรือขนาดใหญ่."
---
## **ภาพรวม**

Aspose.Slides for Java รวมการนำเสนอโดยการโคลนสไลด์จากหนึ่ง [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ไปยังอีกอันหนึ่ง การดำเนินการหลักคือ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) ซึ่งสามารถคงรูปแบบของสไลด์ต้นฉบับหรือแนบสไลด์ที่โคลนไปยังมาสเตอร์หรือเลเอาต์ในงานนำเสนอปลายทาง

บทความนี้ครอบคลุมขั้นตอนการรวมที่พบบ่อยที่สุด:

- รวมสไลด์ทั้งหมดพร้อมคงรูปแบบต้นฉบับ;
- รวมสไลด์ที่เลือก;
- ใช้มาสเตอร์จากงานนำเสนอปลายทาง;
- ใช้เลเอาต์เฉพาะจากงานนำเสนอปลายทาง;
- ปรับขนาดสไลด์ที่แตกต่างกันก่อนทำการรวม;
- เพิ่มสไลด์ที่โคลนเข้าไปในส่วน;
- รวมหลายงานนำเสนอในกระบวนการเริ่มต้นถึงจบหนึ่งขั้นตอน;
- จัดการมาสเตอร์, แหล่งข้อมูล, โน้ต, ความคิดเห็น, สื่อ, ฟอนต์, รหัสผ่าน, ไฟล์ขนาดใหญ่, และประเด็นเกี่ยวกับการทำงานหลายเธรด

## **การโคลนสไลด์ส่งผลต่อมาสเตอร์และเลเอาต์อย่างไร**

สไลด์สืบทอดลักษณะส่วนใหญ่จากเลเอาต์และมาสเตอร์ ดังนั้นรูปแบบการโคลนที่คุณเลือกจะกำหนดวิธีที่สไลด์ที่รวมเข้ามาถูกบูรณาการในงานนำเสนอปลายทาง

ใช้ [ISlideCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/) หนึ่งวิธีต่อไปนี้:

- `addClone(sourceSlide)` — คงเลเอาต์และการจัดรูปแบบของสไลด์ต้นฉบับ เมื่อจำเป็น มาสเตอร์ต้นฉบับสามารถถูกโคลนเข้าไปในงานนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตามมาสเตอร์ที่โคลนอัตโนมัติเพื่อให้สไลด์ที่ใช้มาสเตอร์เดียวกันไม่ทำการโคลนซ้ำหลายครั้ง
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — แนบสไลด์ที่โคลนไปยัง [IMasterSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslide/) ปลายทางที่ระบุ Aspose.Slides จะค้นหาเลเอาต์ที่ตรงกันภายใต้มาสเตอร์นั้นตามประเภทหรือชื่อของเลเอาต์
- `addClone(sourceSlide, destinationLayout)` — แนบสไลด์ที่โคลนโดยตรงไปยัง [ILayoutSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/) ปลายทางที่ระบุ

มาสเตอร์หรือเลเอาต์ที่ส่งให้กับการ overload `addClone` ต้องเป็นของ **งานนำเสนอปลายทาง** ไม่ใช่งานนำเสนอต้นทาง

## **รวมงานนำเสนอทั้งหมดและคงรูปแบบต้นฉบับ**

การรวมที่ง่ายที่สุดคือคัดลอกทุกสไลด์จากงานนำเสนอต้นทางไปยังงานนำเสนอปลายทาง นี่เป็นทางเลือกที่เหมาะสมเมื่อสไลด์ที่นำเข้าควรคงธีม, มาสเตอร์, และความสัมพันธ์ของเลเอาต์เดิม

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

งานนำเสนอที่ได้อาจมีหลายมาสเตอร์เมื่อทั้งต้นทางและปลายทางใช้ดีไซน์ที่ต่างกัน ซึ่งเป็นผลตามคาดเมื่อคงรูปแบบต้นฉบับโดยเจตนา

## **รวมสไลด์ที่เลือก**

คุณไม่จำเป็นต้องโคลนทุกสไลด์ ตัวอย่างต่อไปนี้จะนำเข้าเฉพาะสไลด์ที่เลือกจากงานนำเสนอต้นทาง

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

ตรวจสอบดัชนีสไลด์ก่อนทำการโคลนเมื่อมาจากข้อมูลผู้ใช้หรือการกำหนดค่าภายนอก

## **รวมสไลด์โดยใช้มาสเตอร์ปลายทาง**

ใช้ overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) เมื่อสไลด์ที่นำเข้าควรใช้มาสเตอร์ที่มีอยู่แล้วในงานนำเสนอปลายทาง

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

Aspose.Slides จะเลือกเลเอาต์ที่เหมาะสมภายใต้มาสเตอร์ที่ระบุโดยการจับคู่ประเภทหรือชื่อของเลเอาต์ต้นทาง หากไม่มีเลเอาต์ที่เหมาะสมและ `allowCloneMissingLayout` เป็น `true` เลเอาต์ต้นทางจะถูกโคลนเพื่อให้สไลด์สามารถเพิ่มได้ หากเป็น `false` จะมีการโยน [PptxEditException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxeditexception/)

ใช้ `false` เมื่อคุณต้องการให้การรวมล้มเหลวแทนที่จะเพิ่มเลเอาต์ใหม่เข้าไปในมาสเตอร์ปลายทาง

## **รวมสไลด์โดยใช้เลเอาต์ปลายทางที่เฉพาะเจาะจง**

ใช้ overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) เมื่อคุณรู้แน่นอนว่าเลเอาต์ปลายทางใดที่สไลด์ที่นำเข้าควรใช้

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

การใช้เลเอาต์ปลายทางจะเปลี่ยนความสัมพันธ์ของเลเอาต์ที่สืบทอด; แต่ไม่ได้ออกแบบเนื้อหาของสไลด์ต้นฉบับใหม่ หากเลเอาต์ต้นทางและปลายทางมีโครงสร้าง placeholder แตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบและพฤติกรรม placeholder ที่สืบทอดนั้นเหมาะสม

## **รวมงานนำเสนอที่มีขนาดสไลด์แตกต่างกัน**

งานนำเสนอที่มีมิติสไลด์ต่างกันสามารถรวมกันได้ แต่การโคลนสไลด์เข้าไปในงานนำเสนอที่มีขนาดสไลด์อื่นจะไม่ออกแบบเนื้อหาใหม่โดยอัตโนมัติสำหรับพื้นที่ผ้าใบใหม่ ดังนั้นรูปร่างอาจปรากฏตำแหน่งเลื่อน, ขยายผิดปกติ, หรืออยู่นอกพื้นที่สไลด์ที่มองเห็น

แนวทางที่เป็นประโยชน์คือปรับขนาดงานนำเสนอต้นทางก่อนทำการโคลน วิธี [SlideSize.setSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesize/#setSize-float-float-int-) สามารถปรับสเกลเนื้อหาที่มีอยู่ขณะเปลี่ยนขนาดสไลด์ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesizescaletype/) จะสเกลเนื้อหาให้พอดีกับขนาดที่ต้องการ

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

การปรับขนาดจะเปลี่ยนวัตถุงานนำเสนอต้นทางในหน่วยความจำ หากคุณต้องการให้งานนำเสนอต้นทางคงอยู่ไม่เปลี่ยนแปลงสำหรับการทำงานอื่น ๆ ให้เปิดอินสแตนซ์แยกสำหรับการรวม

## **รวมสไลด์เข้าส่วนของงานนำเสนอ**

ลูปโคลนสไลด์พื้นฐานจะไม่สร้างลำดับชั้นของส่วนจากงานนำเสนอต้นทาง หากส่วนสำคัญในผลลัพธ์ ให้สร้างหรือเลือกส่วนในงานนำเสนอปลายทางและโคลนสไลด์เข้าไปโดยเจาะจงด้วย [addClone(ISlide, ISection)](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)

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

สไลด์ที่โคลนจะถูกเพิ่มต่อท้ายส่วนปลายทางที่ระบุ เพื่อคงหลายส่วนต้นทาง ใหสร้างส่วนเหล่านั้นในปลายทางและแมปแต่ละสไลด์ต้นทางไปยังส่วนปลายทางที่สอดคล้องกัน

## **รวมหลายงานนำเสนออย่างปลอดภัย**

ตัวอย่างขั้นตอนเริ่มต้นถึงจบต่อไปนี้ใช้งานนำเสนอแรกเป็นปลายทาง, ปรับขนาดสไลด์ของแต่ละแหล่งเพิ่มเติม, เปิดแต่ละแหล่งเฉพาะในขณะที่ทำการคัดลอก, และบันทึกไฟล์สุดท้ายเพียงครั้งเดียว

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

นี่เป็นฐานข้อมูลที่มีประโยชน์สำหรับคงรูปแบบต้นฉบับของสไลด์ที่นำเข้า หากผลลัพธ์ของคุณต้องใช้ธีมปลายทางเดียวให้แทนที่การเรียก `addClone(slide)` ง่าย ๆ ด้วย overload มาสเตอร์หรือเลเอาต์ปลายทางที่แสดงไว้ก่อนหน้านี้

## **ข้อพิจารณาเชิงปฏิบัติ**

### **มาสเตอร์, เลเอาต์และความแม่นยำของการจัดรูปแบบ**

การโคลนสไลด์โดยค่าเริ่มต้นสามารถนำมาสเตอร์ต้นทางที่จำเป็นเข้ามาในงานนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะเก็บทะเบียนภายในสำหรับมาสเตอร์ที่โคลนอัตโนมัติเพื่อหลีกเลี่ยงการโคลนมาสเตอร์เดียวกันหลายครั้ง มาสเตอร์ที่โคลนด้วยตนเองจะไม่ได้รับการติดตามโดยทะเบียนนั้น ดังนั้นหลีกเลี่ยงการโคลนมาสเตอร์ล่วงหน้า เว้นแต่คุณต้องการควบคุมโครงสร้างมาสเตอร์อย่างชัดเจน

อย่าสมมติว่ามาสเตอร์หรือเลเออต์สองอันที่มีชื่อเดียวกันเป็นภาพที่เหมือนกัน หากเทมเพลตองค์กรต้องควบคุมลักษณะสุดท้าย ให้เลือกมาสเตอร์หรือเลเอาต์ปลายทางอย่างชัดเจนและตรวจสอบผลลัพธ์หลังการรวม

### **บันทึกข้อความและความคิดเห็น**

บันทึกของผู้พูดและความคิดเห็นของสไลด์เชื่อมโยงกับเนื้อหาสไลด์และจะถูกคัดลอกเมื่อสไลด์ถูกโคลน Aspose.Slides ยังมี API เฉพาะสำหรับ [presentation notes](https://docs.aspose.com/slides/th/java/presentation-notes/) และ [presentation comments](https://docs.aspose.com/slides/th/java/presentation-comments/)

หากการจัดรูปแบบของหน้าบันทึกสำคัญ ให้ตรวจสอบงานนำเสนอที่รวมแล้วเนื่องจากมาสเตอร์ของบันทึกเป็นวัตถุระดับงานนำเสนอและอาจแตกต่างกันระหว่างไฟล์ต้นทาง สำหรับกระบวนการตรวจทาน ให้ตรวจสอบผู้เขียนของความคิดเห็นและความคิดเห็นแบบเชือกหลังจากรวมไฟล์จากผู้เขียนหรือเทมเพลตต่างกัน

### **รูปภาพ, เสียง, วิดีโอ, วัตถุ OLE, และลิงก์ภายนอก**

สไลด์อาจอ้างอิงแหล่งทรัพยากรระดับงานนำเสนอเช่นรูปภาพ, เสียงฝัง, วิดีโอฝัง, และข้อมูล OLE ให้โคลนสไลด์เองแทนการคัดลอทรงรูปร่างที่มองเห็นเท่านั้นเพื่อให้ Aspose.Slides สามารถรักษาความสัมพันธ์ของสไลด์กับทรัพยากรเหล่านั้นได้

แหล่งทรัพยากรที่ฝังและที่เชื่อมโยงควรจัดการต่างกัน ลิงก์เสียง, วิดีโอ, วัตถุ OLE หรือไฮเปอร์ลิงก์ที่เชื่อมโยงจะยังคงพึ่งพาเป้าหมายภายนอก; การโคลนสไลด์จะไม่เปลี่ยนลิงก์ภายนอกให้เป็นเนื้อหาฝัง การทดสอบเส้นทางและ URL ของทรัพยากรที่เชื่อมโยงในสภาพแวดล้อมที่งานนำเสนอที่รวมจะถูกเปิดเป็นสิ่งสำคัญ

Aspose.Slides ติดตามมาสเตอร์ที่โคลนอัตโนมัติ แต่ไม่ควรถือว่าเป็นการรับประกันว่าทรัพยากรไบนารีที่เหมือนกันจากงานนำเสนอที่ไม่มีความสัมพันธ์จะถูกทำซ้ำอัตโนมัติ หากขนาดไฟล์ผลลัพธ์มีความสำคัญ ให้ตรวจสอบแพ็กเกจที่รวมและวัดผลลัพธ์แทนการพึ่งพาการทำซ้ำโดยนัย

### **ฟอนต์ที่ฝังและความพร้อมใช้งานของฟอนต์**

ฟอนต์จัดการระดับงานนำเสนอ หากต้องการให้การพิมพ์ตัวอักษรคงที่บนเครื่องต่าง ๆ อย่าสมมติว่าการโคลนสไลด์อย่างเดียวทำให้ฟอนต์ที่ต้องการทั้งหมดพร้อมใช้งานในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ที่ฝังด้วย [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) และจัดการการฝังอย่างชัดเจนตามที่อธิบายใน [Embed Fonts in Presentations](https://docs.aspose.com/slides/th/java/embedded-font/)

นอกจากนี้ ให้ตรวจสอบว่าคุณได้รับอนุญาตให้ฝังฟอนต์ที่ใช้ในไฟล์ต้นทางหรือไม่ เนื่องจากลิขสิทธิ์ฟอนต์อาจจำกัดการฝัง

### **งานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน**

แหล่งงานนำเสนอที่มีรหัสผ่านต้องเปิดสำเร็จก่อนที่สไลด์จะสามารถโคลนได้ ให้ใส่รหัสผ่านผ่าน [LoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // ทำงานกับงานนำเสนอที่ถูกถอดรหัส.
} finally {
    source.dispose();
}
```

การเปิดแหล่งที่เข้ารหัสไม่ได้ทำให้การป้องกันเดียวกันถูกนำไปใช้กับงานนำเสนอปลายทางโดยอัตโนมัติ ให้กำหนดการป้องกันผลลัพธ์แยกต่างหากเมื่อจำเป็น

### **งานนำเสนอขนาดใหญ่และการใช้หน่วยความจำ**

งานนำเสนอขนาดใหญ่ที่มีรูปภาพความละเอียดสูง, เสียง, วิดีโอ หรือวัตถุไบนารีขนาดใหญ่อื่น ๆ สามารถใช้หน่วยความจำได้มาก [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) มีการควบคุมการจัดการ BLOB และการใช้ไฟล์ชั่วคราว ดู [Manage Presentation BLOBs](https://docs.aspose.com/slides/th/java/manage-blob/) สำหรับกลยุทธ์ไฟล์ขนาดใหญ่

สำหรับไฟล์ใหญ่ ควรโหลดจากพาธไฟล์เมื่อเป็นไปได้ ปล่อยงานนำเสนอแหล่งที่มาทันทีหลังจากรวมเสร็จ และหลีกเลี่ยงการบันทึกผลลัพธ์กลางหลายครั้ง เว้นแต่กระบวนการต้องการจุดตรวจสอบ

### **ความปลอดภัยของเธรด**

ห้ามโหลด, แก้ไข, บันทึก หรือโคลนออบเจกต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้จำกัดออบเจกต์งานนำเสนอแต่ละออบเจกต์ให้ใช้ในกระบวนการรวมเดียว หากต้องทำงานแบบขนาน ให้ใช้ออบเจกต์งานนำเสนออิสระและปฏิบัติตาม [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/th/java/multithreading/)

## **คำถามที่พบบ่อย**

**ฉันจะคงการออกแบบเดิมของแต่ละงานนำเสนอได้อย่างไร?**

ใช้ [`addClone(sourceSlide)`](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) โดยไม่ระบุมาสเตอร์หรือเลเออต์ปลายทาง Aspose.Slides สามารถโคลนมาสเตอร์ต้นทางโดยอัตโนมัติเมื่อสไลด์ที่นำเข้าต้องการ

**ฉันจะทำให้สไลด์ที่นำเข้าใช้ธีมปลายทางได้อย่างไร?**

ใช้ overload ที่รับมาสเตอร์ปลายทาง ส่งมาสเตอร์จากงานนำเสนอปลายทาง, ไม่ใช่จากต้นทาง Aspose.Slides จะพยายามแมปสไลด์ต้นทางไปยังเลเอต็ที่เหมาะสมภายใต้มาสเตอร์นั้น

**ควรใช้เลเอาต์ปลายทางเฉพาะแทนมาสเตอร์ปลายทางเมื่อใด?**

ใช้เลเอาต์เฉพาะเมื่อสไลด์ที่นำเข้าทุกสไลด์ต้องใช้เลเอาต์ที่รู้จักเป็นอย่างเดียว ใช้มาสเตอร์เมื่อคุณต้องการให้ Aspose.Slides เลือกเลเอต็จากมาสเตอร์นั้นตามประเภทหรือชื่อของเลเอต็ต้นทาง

**งานนำเสนอที่มีขนาดสไลด์ต่างกันสามารถรวมกันได้หรือไม่?**

ได้, แต่เนื้อหาสไลด์จะไม่ออกแบบใหม่อัตโนมัติสำหรับมิติปลายทาง ให้ปรับขนาดงานนำต้นทางก่อนเมื่อจำเป็นต้องการตำแหน่งที่คาดเดาได้, ตัวอย่างเช่นใช้ [SlideSize.setSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesize/#setSize-float-float-int-) และ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidesizescaletype/)

**ฉันสามารถรวมไฟล์ PPT, PPTX, และ ODP เป็นไฟล์เดียวได้หรือไม่?**

ได้ เปิดแต่ละงานนำเสนอแหล่ง, โคลนสไลด์ที่ต้องการไปยังงานนำเสนอปลายทางหนึ่ง, แล้วบันทึกปลายทางในรูปแบบที่รองรับ เนื่องจากรูปแบบงานนำเสนออาจมีชุดคุณสมบัติเพิ่มเติมที่แตกต่างกัน, ควรตรวจสอบเนื้อหาซับซ้อนหลังการรวมข้ามรูปแบบ ดู [Supported File Formats](https://docs.aspose.com/slides/th/java/supported-file-formats/)

**ส่วนของต้นทางถูกคงไว้โดยอัตโนมัติหรือไม่?**

ไม่ใช่โดยลูปพื้นฐานที่เพียงโคลนสไลด์ให้สร้างส่วนใหม่ในผลลัพธ์ ให้สร้างส่วนที่ต้องการในปลายทางและใช้ overload ของ [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) เมื่อต้องคงโครงสร้างส่วน

**บันทึกข้อความและความคิดเห็นจะถูกคงไว้หรือไม่?**

พวกมันจะถูกคัดลอกพร้อมกับสไลด์ที่โคลน สำหรับกระบวนการที่พึ่งพาการจัดรูปแบบของโน้ต‑มาสเตอร์, ผู้เขียนความคิดเห็น, หรือข้อมูลการทบทวนแบบเชือก, ควรตรวจสอบผลลัพธ์ที่รวมเนื่องจากสถานการณ์เหล่านั้นเกี่ยวข้องกับโครงสร้างระดับงานนำเสนอเช่นกัน

**จะเกิดอะไรกับเสียง, วิดีโอ, วัตถุ OLE, และไฮเปอร์ลิงก์?**

เนื้อหาฝังจะถูกนำไปพร้อมกับความสัมพันธ์ของทรัพยากรของสไลด์ที่โคลน ลิงก์ภายนอกจะยังคงเป็นลิงก์ภายนอก ดังนั้นไฟล์หรือ URL ปลายทางต้องยังคงพร้อมใช้งานหลังการรวม

**ฟอนต์ที่ฝังจากทุกแหล่งจะถูกรับประกันว่าจะมีในงานนำเสนอที่รวมหรือไม่?**

อย่าพึ่งพาการโคลนสไลด์อย่างเดียวสำหรับการจัดจำหน่ายฟอนต์ ตรวจสอบฟอนต์ที่ฝังในปลายทางและจัดการการฝังฟอนต์หรือความพร้อมใช้งานฟอนต์ภายนอกอย่างชัดเจนเมื่อการพิมพ์ตัวอักษรสำคัญ

**จะรวมไฟล์ที่ป้องกันด้วยรหัสผ่านอย่างไร?**

เปิดไฟล์ด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ที่ถูกต้อง แล้วโคลนสไลด์ตามปกติ การป้องกันผลลัพธ์ต้องกำหนดแยกต่างหาก

**ควรจัดการงานนำเสนอขนาดใหญ่อย่างไร?**

ใช้การจัดการ BLOB เมื่อวัตถุไบนารีขนาดใหญ่เป็นหลัก, โหลดจากพาธไฟล์สำหรับไฟล์ขนาดใหญ่อย่างเต็มที่, ปล่อยงานนำเสนอแหล่งทันทีหลังการรวม, และบันทึกผลลัพธ์สุดท้ายเมื่อจำเป็นเท่านั้น

**ฉันสามารถโคลนสไลด์จากหลายเธรดได้หรือไม่?**

ห้ามใช้ออบเจกต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้แยกการดำเนินการรวมแต่ละอันเป็นออบเจกต์งานนำเสนอของตนเอง.