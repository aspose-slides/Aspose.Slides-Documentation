---
title: ผสานงานนำเสนออย่างมีประสิทธิภาพใน JavaScript
linktitle: ผสานงานนำเสนอ
type: docs
weight: 40
url: /th/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีผสานงานนำเสนอ PowerPoint และ OpenDocument ใน JavaScript ด้วยการโคลนสไลด์, การควบคุมมาสเตอร์และเลย์เอาต์, การปรับขนาดเนื้อหาสไลด์, การคงส่วน, และการจัดการไฟล์ที่มีการปกป้องหรือขนาดใหญ่."
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java ผสานงานนำเสนอด้วยการโคลนสไลด์จาก [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) หนึ่งไปยังอีกอันหนึ่ง การทำงานหลักคือ [SlideCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) ซึ่งสามารถคงรูปแบบของสไลด์ต้นทางไว้ได้หรือแนบสไลด์ที่โคลนไปยังมาสเตอร์หรือเลย์เอาต์ในงานนำเสนอปลายทาง

บทความนี้ครอบคลุมเวิร์กโฟลว์การผสานที่พบบ่อยที่สุด:

- ผสานสไลด์ทั้งหมดพร้อมคงรูปแบบต้นทาง
- ผสานสไลด์ที่เลือก
- ใช้มาสเตอร์จากงานนำเสนอปลายทาง
- ใช้เลย์เอาต์เฉพาะจากงานนำเสนอปลายทาง
- ปรับขนาดสไลด์ที่ต่างกันก่อนผสาน
- เพิ่มสไลด์ที่โคลนเข้าไปในส่วน (section)
- ผสานหลายงานนำเสนอในเวิร์กโฟลว์แบบต้นถึงปลาย
- จัดการมาสเตอร์, ทรัพยากร, โน้ต, ความคิดเห็น, สื่อ, ฟอนต์, รหัสผ่าน, ไฟล์ขนาดใหญ่, และประเด็นการทำงานหลายเธรด

## **ผลของการโคลนสไลด์ต่อมาสเตอร์และเลย์เอาต์**

สไลด์สืบทอดรูปลักษณ์ส่วนใหญ่จากเลย์เอาต์และมาสเตอร์ ดังนั้นการเลือก overload ของการโคลนจะกำหนดว่าสไลด์ที่ผสานจะถูกผสานเข้ากับงานนำเสนอปลายทางอย่างไร

ใช้ [SlideCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/) หนึ่งในวิธีต่อไปนี้:

- `addClone(sourceSlide)` — คงเลย์เอาต์และรูปแบบของสไลด์ต้นทาง เมื่อจำเป็น มาสเตอร์ต้นทางจะถูกโคลนเข้าไปในงานนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตามมาสเตอร์ที่ถูกโคลนอัตโนมัติเพื่อไม่ให้สไลด์ที่ใช้มาสเตอร์เดียวกันถูกโคลนซ้ำหลายครั้ง
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — แนบสไลด์ที่โคลนไปยัง [MasterSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/) ปลายทางที่ระบุ Aspose.Slides จะค้นหาเลย์เอาต์ที่ตรงกันภายใต้มาสเตอร์นั้นตามประเภทหรือชื่อของเลย์เอาต์
- `addClone(sourceSlide, destinationLayout)` — แนบสไลด์ที่โคลนโดยตรงไปยัง [LayoutSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/) ปลายทางที่ระบุ

มาสเตอร์หรือเลย์เอาต์ที่ส่งให้ overload ของ `addClone` ต้องเป็นของ **งานนำเสนอปลายทาง** ไม่ใช่งานนำเสนอต้นทาง

## **ผสานงานนำเสนอทั้งหมดและคงรูปแบบต้นทาง**

การผสานที่ง่ายที่สุดคือคัดลอกทุกสไลด์จากงานนำเสนอต้นทางไปยังงานนำเสนอปลายทาง นี้เป็นตัวเลือกที่เหมาะเมื่อสไลด์ที่นำเข้าต้องรักษาธีม, มาสเตอร์, และความสัมพันธ์ของเลย์เอาต์เดิมไว้

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

งานนำเสนอที่ได้อาจมีมาสเตอร์หลายชุดเมื่อทั้งต้นทางและปลายทางใช้ดีไซน์ที่แตกต่างกัน ซึ่งเป็นพฤติกรรมตามที่คาดเมื่อรูปแบบต้นทางได้รับการคงไว้โดยเจตนา

## **ผสานสไลด์ที่เลือก**

คุณไม่จำเป็นต้องโคลนทุกสไลด์ ตัวอย่างต่อไปนี้นำเข้าเฉพาะดัชนีสไลด์ที่เลือกจากงานนำเสนอต้นทาง

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

ตรวจสอบดัชนีสไลด์ก่อนโคลนเมื่อมาจากข้อมูลผู้ใช้หรือการกำหนดค่าภายนอก

## **ผสานสไลด์โดยใช้มาสเตอร์ปลายทาง**

ใช้ overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) เมื่อสไลด์ที่นำเข้าควรใช้งานมาสเตอร์ที่มีอยู่แล้วในงานนำเสนอปลายทาง

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides จะเลือกเลย์เอาต์ที่เหมาะสมภายใต้มาสเตอร์ที่ระบุโดยการจับคู่ประเภทหรือชื่อของเลย์เอาต์ต้นทาง หากไม่มีเลย์เอาต์ที่เหมาะสมและ `allowCloneMissingLayout` เป็น `true` เลย์เอาต์ต้นทางจะถูกโคลนเพื่อให้สไลด์สามารถเพิ่มได้ หากเป็น `false` จะเกิดการโยน [PptxEditException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxeditexception/)

ใช้ `false` เมื่อคุณต้องการให้การผสานล้มเหลวแทนที่จะเพิ่มเลย์เอาต์ใหม่เข้าสู่มาสเตอร์ปลายทาง

## **ผสานสไลด์โดยใช้เลย์เอาต์ปลายทางเฉพาะ**

ใช้ overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) เมื่อคุณทราบเลย์เอาต์ปลายทางที่ต้องการให้สไลด์ที่นำเข้าใช้

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

การใช้เลย์เอาต์ปลายทางเปลี่ยนความสัมพันธ์ของเลย์เอาต์ที่สืบทอด; มันไม่เปลี่ยนการออกแบบเนื้อหาของสไลด์ต้นทาง หากเลย์เอาต์ต้นทางและปลายทางมีโครงสร้าง placeholder ที่แตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบและพฤติกรรมของ placeholder เหมาะสม

## **ผสานงานนำเสนอที่มีขนาดสไลด์ต่างกัน**

งานนำเสนอที่มีขนาดสไลด์ต่างกันสามารถผสานได้ แต่การโคลนสไลด์ไปยังงานนำเสนอที่มีขนาดสไลด์ต่างกันจะไม่ได้ออกแบบเนื้อหาใหม่อัตโนมัติเพื่อให้พอดีกับพื้นที่ใหม่ รูปร่างอาจถูกเลื่อนไป, ย่อ/ขยายอย่างไม่คาดคิด, หรืออยู่นอกพื้นที่สไลด์ที่มองเห็นได้

วิธีที่เป็นประโยชน์คือปรับขนาดงานนำเสนอต้นทางก่อนโคลน วิธีการ [SlideSize.setSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) สามารถสเกลเนื้อหาที่มีอยู่พร้อมเปลี่ยนขนาดสไลด์ได้ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesizescaletype/) จะสเกลเนื้อหาให้พอดีกับขนาดที่ต้องการ

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

การปรับขนาดจะเปลี่ยนวัตถุงานนำเสนอต้นทางในหน่วยความจำ หากคุณต้องการให้งานนำเสนอต้นทางยังคงอยู่สำหรับการดำเนินการอื่น ๆ ให้เปิดอินสแตนซ์แยกสำหรับการผสาน

## **ผสานสไลด์เข้าส่วนของงานนำเสนอ**

ลูปการโคลนสไลด์พื้นฐานจะไม่สร้างลำดับส่วน (section) ของงานนำแหล่งต้นทาง หากส่วนสำคัญในผลลัพธ์ ให้สร้างหรือเลือกส่วนในงานนำเสนอปลายทางและโคลนสไลด์เข้าไปในส่วนเหล่านั้นโดยใช้ [addClone(Slide, Section)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-)

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

สไลด์ที่โคลนจะถูกต่อท้ายส่วนปลายทางที่ระบุ เพื่อคงหลายส่วนต้นทาง ให้วนลูป [Presentation.getSections](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSections) ดึงสไลด์ของแต่ละส่วนด้วย [Section.getSlidesListOfSection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/section/#getSlidesListOfSection) สร้างส่วนในปลายทางใหม่และโคลนสไลด์ที่ได้รับกลับเข้าไปในส่วนที่สอดคล้องกัน ดูตัวอย่างการจัดการส่วนสไลด์เต็มรูปแบบที่ [Manage Slide Sections](/slides/th/nodejs-java/slide-section/) ซึ่งรวมถึงส่วนว่างและการเปลี่ยนแปลงโครงสร้าง

## **ผสานหลายงานนำเสนออย่างปลอดภัย**

ตัวอย่างแบบต้นถึงปลายต่อไปนี้ใช้งานนำเสนอแรกเป็นปลายทาง, ปรับขนาดสไลด์ของแหล่งเพิ่มเติมแต่ละแหล่ง, เปิดแต่ละแหล่งเฉพาะในช่วงที่ทำการคัดลอก, และบันทึกไฟล์สุดท้ายครั้งเดียว

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

นี่เป็นแนวทางสำคัญสำหรับการคงรูปแบบต้นทางของสไลด์ที่นำเข้า หากผลลัพธ์ต้องใช้ธีมเดียวของปลายทาง ให้แทนที่การเรียก `addClone(sourceSlide)` อย่างง่ายด้วย overload มาสเตอร์หรือเลย์เอาต์ปลายทางที่แสดงไว้ก่อนหน้า

## **ข้อควรพิจารณาเชิงปฏิบัติ**

### **มาสเตอร์, เลย์เอาต์, และความเที่ยงตรงของการจัดรูปแบบ**

การโคลนสไลด์ค่าเริ่มต้นสามารถนำมาสเตอร์ต้นทางที่จำเป็นเข้าสู่งานนำเสนอปลายทางได้โดยอัตโนมัติ Aspose.Slides จะเก็บเรจิสทรีภายในสำหรับมาสเตอร์ที่โคลนอัตโนมัติเพื่อหลีกเลี่ยงการโคลนมาสเตอร์เดียวกันซ้ำหลายครั้ง มาสเตอร์ที่โคลนด้วยตนเองจะไม่ถูกบันทึกในเรจิสทรีนั้น ดังนั้นหลีกเลี่ยงการโคลนมาสเตอร์ล่วงหน้า เว้นแต่คุณต้องการควบคุมโครงสร้างมาสเตอร์อย่างชัดเจน

อย่าถือว่ามาสเตอร์หรือเลย์เอาต์สองตัวที่มีชื่อเดียวกันเป็นภาพลักษณ์ที่เท่ากัน หากเทมเพลตองค์กรต้องควบคุมรูปลักษณ์สุดท้าย ควรเลือกมาสเตอร์หรือเลย์เอาต์ปลายทางโดยเจตนาและตรวจสอบผลลัพธ์หลังการผสาน

### **โน้ตและความคิดเห็น**

โน้ตผู้พูดและความเห็นบนสไลด์เชื่อมโยงกับเนื้อหาสไลด์และจะถูกคัดลอกเมื่อสไลด์ถูกโคลน Aspose.Slides ยังมี API เฉพาะสำหรับ [presentation notes](/slides/th/nodejs-java/presentation-notes/) และ [presentation comments](/slides/th/nodejs-java/presentation-comments/)

หากรูปแบบหน้าหนังสือโน้ตสำคัญ ให้ตรวจสอบงานนำเสนอที่ผสานแล้วเนื่องจากโน้ตมาสเตอร์เป็นอ็อบเจกต์ระดับงานนำเสนอและอาจแตกต่างกันระหว่างไฟล์ต้นทาง สำหรับเวิร์กโฟลว์การตรวจสอบ ให้ตรวจสอบผู้เขียนความเห็นและเธรดของความเห็นหลังการรวมไฟล์จากผู้เขียนหรือเทมเพลตที่ต่างกัน

### **รูปภาพ, เสียง, วิดีโอ, วัตถุ OLE, และลิงก์ภายนอก**

สไลด์อาจอ้างอิงทรัพยากรระดับงานนำเสนอเช่นรูปภาพ, เสียงฝัง, วิดีโอฝัง, และข้อมูล OLE ให้โคลนสไลด์เองแทนการคัดลอกเฉพาะรูปร่างที่มองเห็นได้ เพื่อให้ Aspose.Slides รักษาความสัมพันธ์ของสไลด์ต่อทรัพยากรเหล่านั้น

ทรัพยากรที่ฝังและที่ลิงก์ควรจัดการแยกกัน ลิงก์เสียง, วิดีโอ, OLE หรือไฮเปอร์ลิงก์ที่ลิงก์ไว้จะยังคงพึ่งพาเป้าหมายภายนอก; การโคลนสไลด์จะไม่เปลี่ยนลิงก์ภายนอกให้เป็นเนื้อหาฝัง ทดสอบเส้นทางและ URL ของทรัพยากรที่ลิงก์ในสภาพแวดล้อมที่จะเปิดงานนำเสนอที่ผสานแล้ว

Aspose.Slides ติดตามมาสเตอร์ที่โคลนอัตโนมัติอย่างชัดเจน แต่ไม่ควรถือว่าเป็นการรับประกันทั่วไปว่าทรัพยากรไบนารีที่เหมือนกันจากงานนำเสนอแหล่งที่ไม่เกี่ยวข้องจะถูกลดทอนโดยอัตโนมัติ หากขนาดไฟล์ผลลัพธ์สำคัญ ให้ตรวจสอบแพ็กเกจที่ผสานและวัดผลลัพธ์แทนการพึ่งพาการลดทอนโดยนัย

### **ฟอนต์ฝังและความพร้อมใช้งานของฟอนต์**

ฟอนต์ถูกจัดการระดับงานนำเสนอ หากต้องการให้การพิมพ์ข้อความคงที่บนอุปกรณ์ต่าง ๆ อย่ assumesว่าการโคลนสไลด์เพียงอย่างเดียวทำให้ฟอนต์ที่จำเป็นทั้งหมดพร้อมใช้งานในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ที่ฝังด้วย [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) และจัดการการฝังอย่างชัดเจนตามที่อธิบายใน [Embed Fonts in Presentations](/slides/th/nodejs-java/embedded-font/)

นอกจากนี้ตรวจสอบว่าคุณได้รับอนุญาตให้ฝังฟอนต์ที่ใช้ในไฟล์ต้นทางหรือไม่ ใบอนุญาตฟอนต์อาจจำกัดการฝัง

### **งานนำเสนอที่มีรหัสผ่าน**

แหล่งที่มีรหัสผ่านต้องเปิดสำเร็จก่อนที่สไลด์จะถูกโคลน ให้ใส่รหัสผ่านผ่าน [LoadOptions.setPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setPassword-String-)

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // ทำงานกับการนำเสนอที่ถอดรหัสแล้ว.
} finally {
    source.dispose();
}
```

การเปิดไฟล์ที่เข้ารหัสจะไม่ทำให้งานนำเสนอปลายทางได้รับการปกป้องแบบเดียวโดยอัตโนมัติ จำเป็นต้องกำหนดการปกป้องผลลัพธ์แยกต่างหากเมื่อจำเป็น

### **งานนำเสนอขนาดใหญ่และการใช้หน่วยความจำ**

งานนำเสนอขนาดใหญ่ที่มีรูปภาพความละเอียดสูง, เสียง, วิดีโอ หรือไบต์ข้อมูลขนาดใหญ่อื่น ๆ สามารถใช้หน่วยความจำมาก [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) มีตัวเลือกสำหรับการจัดการ BLOB และการใช้ไฟล์ชั่วคราว ดู [Manage Presentation BLOBs](/slides/th/nodejs-java/manage-blob/) สำหรับกลยุทธ์ไฟล์ขนาดใหญ่

สำหรับไฟล์ขนาดใหญ่ ให้โหลดจากพาธไฟล์เมื่อเป็นไปได้, ปิดการใช้งานงานนำเสนอแหล่งทันทีหลังการผสาน, และหลีกเลี่ยงการบันทึกผลลัพธ์กลางหลายครั้ง เว้นแต่เวิร์กโฟลว์ต้องการจุดตรวจ

### **ความปลอดภัยของเธรด**

ห้ามโหลด, บันทึก, หรือโคลนอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ในหลายเธรด การดำเนินการเหล่านี้ไม่ได้รับการสนับสนุนสำหรับการใช้หลายเธรด หากต้องการทำงานผสานแบบขนานให้ใช้หลายกระบวนการแบบเดี่ยว (single‑threaded) แต่ละกระบวนการมีอินสแตนซ์งานนำเสนอของตนเอง และปฏิบัติตาม [Aspose.Slides multithreading guidance](/slides/th/nodejs-java/multithreading/)

## **FAQ**

**ฉันจะรักษาการออกแบบเดิมของแต่ละงานนำเสนออย่างไร?**

ใช้ [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) โดยไม่ระบุมาสเตอร์หรือเลย์เอาต์ปลายทาง Aspose.Slides สามารถโคลนมาสเตอร์ต้นทางโดยอัตโนมัติเมื่อสไลด์ที่นำเข้าต้องการมัน

**ฉันจะทำให้สไลด์ที่นำเข้าใช้ธีมของปลายทางอย่างไร?**

ใช้ overload ที่รับมาสเตอร์ปลายทาง ส่งมาสเตอร์จากงานนำเสนอปลายทาง ไม่ใช่จากต้นทาง Aspose.Slides จะพยายามแมปสไลด์ต้นทางแต่ละสไลด์ไปยังเลย์เอาต์ที่เหมาะสมภายใต้มาสเตอร์นั้น

**ควรใช้เลย์เอาต์ปลายทางเฉพาะเมื่อไหร่ แทนมาสเตอร์ปลายทาง?**

ใช้เลย์เอาต์เฉพาะเมื่อสไลด์ที่นำเข้าทุกสไลด์ควรใช้เลย์เอาต์เดียวที่รู้จัก ใช้มาสเตอร์เมื่อคุณต้องการให้ Aspose.Slides เลือกเลย์เอาต์จากมาสเตอร์นั้นตามประเภทหรือชื่อของเลย์เอาต์ต้นทาง

**งานนำเสนอที่มีขนาดสไลด์ต่างกันสามารถผสานได้หรือไม่?**

ได้ แต่เนื้อหาสไลด์จะไม่ถูกออกแบบใหม่อัตโนมัติเพื่อให้เข้ากับมิติปลายทาง ปรับขนาดงานนำเสนอต้นทางก่อนเมื่อคุณต้องการการวางตำแหน่งที่คาดการณ์ได้ เช่นใช้ [SlideSize.setSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) และ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidesizescaletype/)

**ฉันสามารถผสานไฟล์ PPT, PPTX, และ ODP เป็นไฟล์เดียวได้หรือไม่?**

ได้ เปิดแต่ละงานนำเสนอแหล่ง, โคลนสไลด์ที่ต้องการเข้าสู่งานนำเสนอปลายทางหนึ่ง และบันทึกปลายทางในรูปแบบที่สนับสนุน เนื่องจากฟอร์แมตงานนำเสนอแต่ละแบบอาจมีชุดคุณสมบัติที่แตกต่างกัน ให้ตรวจสอบเนื้อหาซับซ้อนหลังการผสานข้ามฟอร์แมต ดูที่ [Supported File Formats](/slides/th/nodejs-java/supported-file-formats/)

**ส่วนต้นทางจะถูกคงไว้โดยอัตโนมัติหรือไม่?**

ไม่กับลูปพื้นฐานที่เพียงโคลนสไลด์เท่านั้น ให้สร้างส่วนที่ต้องการในปลายทางและใช้ overload ส่วนของ [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) เมื่อโครงสร้างส่วนต้องคงไว้

**โน้ตผู้พูดและความคิดเห็นจะถูกคงไว้หรือไม่?**

พวกมันจะถูกคัดลอกพร้อมสไลด์ที่โคลน สำหรับเวิร์กโฟลว์ที่ต้องพึ่งพาการจัดสไตล์ของโน้ตมาสเตอร์, ผู้เขียนความคิดเห็น, หรือข้อมูลการตรวจสอบแบบเธรด ให้ตรวจสอบผลลัพธ์ที่ผสาน เพราะสถานการณ์เหล่านั้นเกี่ยวข้องกับโครงสร้างระดับงานนำเสนอและระดับสไลด์พร้อมกัน

**เสียง, วิดีโอ, วัตถุ OLE, และไฮเปอร์ลิงก์จะเกิดอะไรขึ้น?**

เนื้อหาที่ฝังจะถูกนำมาพร้อมกับความสัมพันธ์ของทรัพยากรในสไลด์ที่โคลน ลิงก์ภายนอกจะคงเป็นลิงก์ภายนอก ดังนั้นไฟล์หรือ URL เป้าหมายต้องยังคงเข้าถึงได้หลังการผสาน

**ฟอนต์ฝังจากทุกแหล่งจะได้รับการรับประกันว่าพร้อมใช้งานในงานนำเสนอที่ผสานหรือไม่?**

อย่าอาศัยการโคลนสไลด์อย่างเดียวสำหรับการจัดหาฟอนต์ ตรวจสอบฟอนต์ที่ฝังในปลายทางและจัดการการฝังฟอนต์หรือความพร้อมของฟอนต์ภายนอกอย่างชัดเจนเมื่อการพิมพ์ข้อความมีความสำคัญ

**ฉันจะผสานไฟล์ที่มีรหัสผ่านได้อย่างไร?**

เปิดไฟล์ด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) ที่ถูกต้อง แล้วโคลนสไลด์ตามปกติ การปกป้องผลลัพธ์ต้องกำหนดแยกต่างหาก

**ฉันควรจัดการงานนำเสนอขนาดใหญ่อย่างไร?**

ใช้การจัดการ BLOB เมื่อวัตถุไบนารีขนาดใหญ่เป็นสาเหตุการใช้หน่วยความจำ, โหลดจากพาธไฟล์สำหรับไฟล์ขนาดใหญ่อย่างเต็มที่, ปิดการใช้งานงานนำเสนอแหล่งทันทีหลังการผสาน, และบันทึกผลลัพธ์สุดท้ายเมื่อจำเป็นเท่านั้น

**ฉันสามารถผสานสไลด์จากหลายเธรดได้หรือไม่?**

ห้ามโหลด, บันทึก, หรือโคลนอินสแตนซ์ของงานนำเสนอในหลายเธรด สำหรับงานผสานแบบขนาน ให้ใช้กระบวนการเดี่ยวหลายตัวที่มีอินสแตนซ์งานนำเสนอแยกกัน.