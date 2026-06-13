---
title: เพิ่มประสิทธิภาพการจัดการภาพในงานนำเสนอด้วย JavaScript
linktitle: จัดการภาพ
type: docs
weight: 10
url: /th/nodejs-java/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มรูป
- เพิ่มบิตแมพ
- แทนที่รูปภาพ
- แทนที่รูป
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- งานนำเสนอ
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "ทำให้การจัดการภาพใน PowerPoint และ OpenDocument ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js มีประสิทธิภาพมากขึ้น โดยเพิ่มประสิทธิภาพการทำงานและอัตโนมัติกระบวนการของคุณ."
---
## **บทนำ**

ภาพทำให้การนำเสนอมีความน่าสนใจและดึงดูดมากขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพจากไฟล์ อินเทอร์เน็ต หรือที่อื่น ๆ ลงในสไลด์ได้ เช่นเดียวกับ Aspose.Slides ที่อนุญาตให้คุณเพิ่มภาพลงในสไลด์ของการนำเสนอของคุณผ่านขั้นตอนต่าง ๆ  

{{% alert  title="Tip" color="primary" %}} 

Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างการนำเสนออย่างรวดเร็วจากภาพ.  

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

หากคุณต้องการเพิ่มภาพเป็นอ็อบเจกต์กรอบ—โดยเฉพาะอย่างยิ่งหากคุณตั้งใจใช้ตัวเลือกการจัดรูปแบบมาตรฐานเพื่อเปลี่ยนขนาด เพิ่มเอฟเฟกต์ ฯลฯ—ให้ดูที่ [Picture Frame](https://docs.aspose.com/slides/th/nodejs-java/picture-frame/).  

{{% /alert %}} 

Aspose.Slides รองรับการดำเนินงานกับภาพในรูปแบบที่เป็นที่นิยมเหล่านี้: JPEG, PNG, GIF, และอื่น ๆ.  

## **การเพิ่มภาพที่จัดเก็บไว้ในเครื่องไปยังสไลด์**

คุณสามารถเพิ่มภาพหนึ่งหรือหลายภาพจากคอมพิวเตอร์ของคุณลงบนสไลด์ในงานนำเสนอได้ ตัวอย่างโค้ดใน JavaScript นี้จะแสดงวิธีเพิ่มภาพลงในสไลด์:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การเพิ่มภาพจากสตรีมไปยังสไลด์**

หากภาพที่คุณต้องการเพิ่มไปยังสไลด์ไม่อยู่ในคอมพิวเตอร์ของคุณ คุณสามารถเพิ่มภาพโดยตรงจากเว็บได้.  

ตัวอย่างโค้ดนี้จะแสดงวิธีเพิ่มภาพจากเว็บไปยังสไลด์ใน JavaScript:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // โหลดไฟล์ Excel ไปเป็นสตรีม
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // สร้างอ็อบเจ็กต์ข้อมูลสำหรับการฝัง
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // เพิ่มรูปแบบ Ole Object Frame
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การเพิ่มภาพไปยังมาสเตอร์สไลด์**

มาสเตอร์สไลด์เป็นสไลด์ระดับบนที่จัดเก็บและควบคุมข้อมูล (ธีม, การจัดวาง ฯลฯ) ของสไลด์ทั้งหมดที่อยู่ภายใต้มัน ดังนั้นเมื่อคุณเพิ่มภาพไปยังมาสเตอร์สไลด์ ภาพนั้นจะแสดงบนทุกสไลด์ที่อยู่ภายใต้มาสเตอร์สไลด์นั้น.  

ตัวอย่างโค้ด JavaScript นี้จะแสดงวิธีเพิ่มภาพไปยังมาสเตอร์สไลด์:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การเพิ่มภาพเป็นพื้นหลังสไลด์**

คุณอาจเลือกใช้รูปภาพเป็นพื้นหลังสำหรับสไลด์เดียวหรือหลายสไลด์ ในกรณีนั้นคุณต้องดู *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/th/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.  

## **การเพิ่ม SVG ไปยังการนำเสนอ**

คุณสามารถเพิ่มหรือแทรกภาพใด ๆ ลงในงานนำเสนอโดยใช้เมธอด [addPictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) ที่เป็นสมาชิกของคลาส [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection).  

เพื่อสร้างอ็อบเจกต์ภาพจากภาพ SVG คุณสามารถทำได้แบบนี้:  

1. สร้างอ็อบเจกต์ SvgImage เพื่อแทรกลงใน ImageShapeCollection  
2. สร้างอ็อบเจกต์ PPImage จาก ISvgImage  
3. สร้างอ็อบเจกต์ PictureFrame โดยใช้คลาส PPImage  

ตัวอย่างโค้ดนี้จะแสดงวิธีนำขั้นตอนข้างต้นไปใช้เพื่อเพิ่มภาพ SVG ลงในงานนำเสนอ:  

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การแปลง SVG เป็นชุดรูปแบบ**

การแปลง SVG เป็นชุดรูปแบบของ Aspose.Slides นั้นคล้ายกับฟังก์ชันของ PowerPoint ที่ใช้ทำงานกับภาพ SVG:  

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ถูกจัดให้โดยหนึ่งใน overload ของเมธอด [addGroupShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) ของคลาส [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection) ที่รับอ็อบเจกต์ [SvgImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SvgImage) เป็นอาร์กิวเมนต์แรก.  

ตัวอย่างโค้ดนี้จะแสดงวิธีใช้เมธอดที่อธิบายเพื่อแปลงไฟล์ SVG เป็นชุดรูปแบบ:  

```javascript
// สร้างงานนำเสนอใหม่
var presentation = new aspose.slides.Presentation();
try {
    // อ่านเนื้อหาไฟล์ SVG
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // สร้างอ็อบเจกต์ SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // รับขนาดสไลด์
    var slideSize = presentation.getSlideSize().getSize();
    // แปลงภาพ SVG เป็นกลุ่มของรูปทรงโดยปรับสเกลให้ตรงขนาดสไลด์
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // บันทึกงานนำเสนอในรูปแบบ PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **การเพิ่มภาพเป็น EMF ในสไลด์**

Aspose.Slides สำหรับ Node.js ผ่าน Java อนุญาตให้คุณสร้างภาพ EMF จากแผ่นงาน Excel และเพิ่มภาพเหล่านั้นเป็น EMF ในสไลด์ด้วย Aspose.Cells.  

ตัวอย่างโค้ดนี้จะแสดงวิธีทำงานที่อธิบายไว้:  

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Save the workbook to stream
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การแทนที่ภาพใน Image Collection**

Aspose.Slides ให้คุณแทนที่ภาพที่จัดเก็บอยู่ใน Image Collection ของการนำเสนอ (รวมถึงภาพที่ใช้โดยรูปแบบสไลด์) ส่วนนี้จะแสดงหลายวิธีในการอัปเดตภาพในคอลเลกชัน API มีเมธอดที่ง่ายสำหรับการแทนที่ภาพโดยใช้ข้อมูลไบต์ดิบ, อินสแตนซ์ของ [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/), หรือภาพอื่นที่มีอยู่แล้วในคอลเลกชัน.  

ทำตามขั้นตอนด้านล่าง:  

1. โหลดไฟล์การนำเสนอที่มีภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
2. โหลดภาพใหม่จากไฟล์ลงในอาร์เรย์ไบต์  
3. แทนที่ภาพเป้าหมายด้วยภาพใหม่โดยใช้เอาอาร์เรย์ไบต์  
4. ในวิธีที่สอง โหลดภาพเป็นอ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) และแทนที่ภาพเป้าหมายด้วยอ็อบเจกต์นั้น  
5. ในวิธีที่สาม แทนที่ภาพเป้าหมายด้วยภาพที่มีอยู่แล้วใน Image Collection ของการนำเสนอ  
6. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // วิธีแรก.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // วิธีที่สอง.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // วิธีที่สาม.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // บันทึกงานนำเสนอเป็นไฟล์.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

โดยใช้ตัวแปลง Aspose FREE [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) คุณสามารถทำให้ข้อความเคลื่อนไหวได้ง่ายๆ สร้าง GIF จากข้อความ ฯลฯ  

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ภาพต้นฉบับยังคงความละเอียดเดิมหลังการแทรกหรือไม่?**  

ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่รูปแบบสุดท้ายขึ้นอยู่กับวิธีการปรับขนาด [picture](/slides/th/nodejs-java/picture-frame/) บนสไลด์และการบีบอัดที่ทำในขณะบันทึก.  

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันในหลายสิบสไลด์พร้อมกันคืออะไร?**  

วางโลโก้บนมาสเตอร์สไลด์หรือเลย์เอาต์แล้วแทนที่ใน Image Collection ของการนำเสนอ—การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น.  

**สามารถแปลง SVG ที่แทรกแล้วให้เป็นรูปทรงแก้ไขได้หรือไม่?**  

ได้ คุณสามารถแปลง SVG เป็นกลุ่มของรูปทรงได้ หลังจากนั้นส่วนต่าง ๆ จะสามารถแก้ไขได้ด้วยคุณสมบัติมาตรฐานของรูปทรง.  

**จะตั้งรูปภาพเป็นพื้นหลังสำหรับหลายสไลด์พร้อมกันอย่างไร?**  

[Assign the image as the background](/slides/th/nodejs-java/presentation-background/) บนมาสเตอร์สไลด์หรือเลย์เอาต์ที่เกี่ยวข้อง—สไลด์ใด ๆ ที่ใช้มาสเตอร์/เลย์เอาต์นั้นจะรับพื้นหลังเดียวกัน.  

**จะป้องกันไม่ให้การนำเสนอขยายขนาดมากเกินไปจากภาพจำนวนมากได้อย่างไร?**  

ใช้ภาพเดียวซ้ำแทนการสร้างสำเนาหลายไฟล์, เลือกความละเอียดที่เหมาะสม, ใช้การบีบอัดเมื่อบันทึก, และเก็บกราฟิกที่ซ้ำกันไว้บนมาสเตอร์เมื่อต้องการ.