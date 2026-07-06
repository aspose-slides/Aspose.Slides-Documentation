---
title: จัดการกรอบภาพในงานนำเสนอโดยใช้ JavaScript
linktitle: กรอบภาพ
type: docs
weight: 10
url: /th/nodejs-java/picture-frame/
keywords:
- กรอบภาพ
- เพิ่มกรอบภาพ
- สร้างกรอบภาพ
- เพิ่มภาพ
- สร้างภาพ
- สกัดภาพ
- ภาพแรสเตอร์
- ภาพเวกเตอร์
- ตัดภาพ
- พื้นที่ที่ถูกตัด
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบภาพ
- คุณสมบัติกรอบภาพ
- สเกลสัมพันธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนภาพ
- ความโปร่งแสงของภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่มกรอบภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js via Java. ปรับกระบวนการทำงานของคุณให้มีประสิทธิภาพและยกระดับการออกแบบสไลด์."
---
## **บทนำ**

กรอบรูปคือรูปร่างที่บรรจุภาพ—เหมือนภาพที่อยู่ในกรอบ

คุณสามารถเพิ่มภาพลงในสไลด์ผ่านกรอบรูปได้ วิธีนี้จะทำให้คุณสามารถจัดรูปแบบภาพโดยจัดรูปแบบกรอบรูป

{{% alert  title="Tip" color="primary" %}} 
Aspose ให้บริการตัวแปลงฟรี—[JPEG ไปยัง PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG ไปยัง PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างงานนำเสนออย่างรวดเร็วจากภาพ 
{{% /alert %}} 

## **สร้างกรอบรูป**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน 
3. สร้างอ็อบเจกต์ `PPImage` โดยเพิ่มภาพลงใน [ImagesCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ImageCollection) ที่เชื่อมโยงกับอ็อบเจกต์ Presentation ซึ่งจะใช้เติมรูปร่าง 
4. ระบุความกว้างและความสูงของภาพ 
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFrame) ตามความกว้างและความสูงของภาพผ่านเมธอด `addPictureFrame` ที่เปิดให้ใช้โดยอ็อบเจกต์ Shape ที่เชื่อมโยงกับสไลด์ที่อ้างอิง 
6. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์ 
7. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

โค้ด JavaScript นี้แสดงวิธีสร้างกรอบรูป:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // สร้างอินสแตนซ์ของคลาส Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // เพิ่มกรอบรูปโดยใช้ความสูงและความกว้างที่เท่ากับของภาพ
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

กรอบรูปช่วยให้คุณสร้างสไลด์งานนำเสนอจากภาพได้อย่างรวดเร็ว เมื่อรวมกรอบรูปกับตัวเลือกการบันทึกของ Aspose.Slides คุณสามารถจัดการการทำงานเข้า/ออกเพื่อแปลงภาพจากฟอร์แมตหนึ่งเป็นอีกฟอร์แมตหนึ่งได้

## **สร้างกรอบรูปด้วยสเกลสัมพันธ์**

โดยการปรับสเกลสัมพันธ์ของภาพ คุณสามารถสร้างกรอบรูปที่ซับซ้อนมากขึ้นได้ 

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน 
3. เพิ่มภาพลงในคอลเลกชันภาพของการนำเสนอ 
4. สร้างอ็อบเจกต์ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PPImage) โดยเพิ่มภาพลงใน [ImagesCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ImageCollection) ที่เชื่อมโยงกับอ็อบเจกต์ Presentation เพื่อใช้เติมรูปร่าง 
5. ระบุความกว้างและความสูงสัมพันธ์ของภาพในกรอบรูป 
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

โค้ด JavaScript นี้แสดงวิธีสร้างกรอบรูปด้วยสเกลสัมพันธ์:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // สร้างอินสแตนซ์ของคลาส Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // เพิ่มกรอบรูปโดยมีความสูงและความกว้างเท่ากับของรูป
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // ตั้งค่าสเกลสัมพันธ์ของความกว้างและความสูง
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **สกัดภาพ Raster จากกรอบรูป**

คุณสามารถสกัดภาพ raster จากอ็อบเจกต์ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFrame) แล้วบันทึกเป็น PNG, JPG หรือฟอร์แมตอื่น ๆ ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดภาพจากเอกสาร “sample.pptx” และบันทึกเป็นฟอร์แมต PNG

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **สกัดภาพ SVG จากกรอบรูป**

เมื่อการนำเสนอมีกราฟิก SVG อยู่ภายในรูปร่าง [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) Aspose.Slides for Node.js via Java สามารถดึงภาพเวกเตอร์ต้นฉบับด้วยความแม่นยำเต็มที่ได้ โดยการวนลูปคอลเลกชันรูปร่างของสไลด์ คุณสามารถระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/), ตรวจสอบว่า [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) มีเนื้อหา SVG หรือไม่ แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในฟอร์แมต SVG ดั้งเดิม

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีสกัดภาพ SVG จากกรอบรูป:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **รับความโปร่งใสของภาพ**

Aspose.Slides อนุญาตให้คุณรับค่าผลกระทบความโปร่งใสที่ถูกนำไปใช้กับภาพ โค้ด JavaScript นี้แสดงการดำเนินการ:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **รับความสว่างและคอนทราสต์ของภาพ**

Aspose.Slides อนุญาตให้คุณรับค่าผลกระทบความสว่างและคอนทราสต์ที่ถูกนำไปใช้กับภาพ คลาส [Luminance](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/luminance/) แสดงถึงการแปลงผลกระทบนี้

โค้ด JavaScript นี้แสดงวิธีรับการตั้งค่าความสว่างและคอนทราสต์จากกรอบรูป:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **การจัดรูปแบบกรอบรูป**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายอย่างที่สามารถใช้กับกรอบรูปได้ ด้วยตัวเลือกเหล่านี้คุณสามารถปรับกรอบรูปให้ตรงตามความต้องการเฉพาะได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน 
3. สร้างอ็อบเจกต์ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PPImage) โดยเพิ่มภาพลงใน [ImagesCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ImageCollection) ที่เชื่อมโยงกับอ็อบเจกต์ Presentation เพื่อใช้เติมรูปร่าง 
4. ระบุความกว้างและความสูงของภาพ 
5. สร้าง `PictureFrame` ตามความกว้างและความสูงของภาพผ่านเมธอด [addPictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) ที่เปิดให้ใช้โดยอ็อบเจกต์ [Shapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection) ของสไลด์ที่อ้างอิง 
6. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์ 
7. ตั้งค่าสีของเส้นกรอบรูป 
8. ตั้งค่าความกว้างของเส้นกรอบรูป 
9. หมุนกรอบรูปโดยให้ค่าบวกหรือค่าลบ  
   * ค่าบวกจะหมุนภาพตามเข็มนาฬิกา  
   * ค่าลบจะหมุนภาพทวนเข็มนาฬิกา 
10. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์ 
11. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

โค้ด JavaScript นี้แสดงกระบวนการจัดรูปแบบกรอบรูป:

```javascript
// สร้างอินสแทนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // สร้างอินสแทนซ์ของคลาส Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // เพิ่มกรอบรูปโดยใช้ความสูงและความกว้างเท่ากับของรูป
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // ใช้การจัดรูปแบบบางอย่างกับ PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}} 
Aspose เพิ่งพัฒนา [เครื่องมือสร้างคอลลาจฟรี](https://products.aspose.app/slides/th/collage) หากคุณต้องการผสานรวมภาพ JPG/JPEG หรือ PNG, หรือสร้างกริดจากรูปภาพ, คุณสามารถใช้บริการนี้ได้ 
{{% /alert %}}

## **เพิ่มภาพเป็นลิงก์**

เพื่อหลีกเลี่ยงขนาดการนำเสนอที่ใหญ่ คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์โดยตรงเข้าไปในงานนำเสนอ โค้ด JavaScript นี้แสดงวิธีเพิ่มภาพและวิดีโอลงในตัวเก็บข้อมูล:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **ครอบแม่นภาพ**

โค้ด JavaScript นี้แสดงวิธีครอบภาพที่มีอยู่ในสไลด์:

```javascript
var pres = new aspose.slides.Presentation();
// Creates new image object
// สร้างอ็อบเจกต์ภาพใหม่
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Adds a PictureFrame to a Slide
    // เพิ่ม PictureFrame ไปยังสไลด์
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Crops the image (percentage values)
    // ครอบตัดภาพ (ค่าร้อยละ)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Saves the result
    // บันทึกผลลัพธ์
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ลบพื้นที่ที่ถูกครอปของกรอบรูป**

หากต้องการลบพื้นที่ที่ถูกครอปของภาพที่อยู่ในกรอบรูป คุณสามารถใช้เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) เมธอดนี้จะคืนค่าภาพที่ถูกครอปหรือภาพต้นฉบับหากไม่จำเป็นต้องครอป

โค้ด JavaScript นี้แสดงการดำเนินการ:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // ดึง PictureFrame จากสไลด์แรก
    var picFrame = slide.getShapes().get_Item(0);
    // ลบพื้นที่ที่ถูกครอปของภาพใน PictureFrame และคืนค่าภาพที่ถูกครอป
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // บันทึกผลลัพธ์
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) จะเพิ่มภาพที่ถูกครอปไปยังคอลเลกชันภาพของการนำเสนอ หากภาพถูกใช้เฉพาะใน [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) ที่ประมวลผลแล้ว การตั้งค่านี้สามารถลดขนาดการนำเสนอได้ มิฉะนั้นจำนวนภาพในผลลัพธ์จะเพิ่มขึ้น 

เมธอดนี้แปลงไฟล์เมต้าไฟล์ WMF/EMF เป็นภาพ PNG raster ในกระบวนการครอป 
{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดรูปภาพในงานนำเสนอโดยใช้เมธอด [PictureFillFormat.compressImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-)  
เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดรูปร่างและความละเอียดที่ระบุ พร้อมตัวเลือกให้ลบพื้นที่ที่ถูกครอป 

มันปรับขนาดและความละเอียดของภาพคล้ายกับคุณลักษณะ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint

ตัวอย่าง JavaScript ด้านล่างแสดงวิธีบีบอัดภาพในงานนำเสนอโดยระบุความละเอียดเป้าหมายและโดยออปชันลบพื้นที่ที่ถูกครอป:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอป
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // ตรวจสอบผลของการบีบอัด
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หรือใช้ค่า DPI ที่กำหนดไว้ล่วงหน้าอื่น:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // บีบอัดภาพเป็น 96 DPI (ความละเอียดอีเมล), ลบพื้นที่ที่ถูกครอป
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
เมธอดนี้แปลงภาพเป็นความละเอียดต่ำกว่าตามขนาดของรูปร่างและ DPI ที่ให้ไว้ พื้นที่ที่ถูกครอปสามารถลบได้เพื่อเพิ่มประสิทธิภาพขนาดไฟล์  
หากภาพเป็นเมต้าไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ และคุณภาพ JPEG จะถูกเก็บไว้หรือสูญเสียเล็กน้อยตามความละเอียด เช่นเดียวกับที่ PowerPoint จัดการกับ JPEG ความละเอียดสูง 
{{% /alert %}}

## **ล็อกอัตราส่วนภาพ**

หากต้องการให้รูปร่างที่บรรจุภาพคงอัตราส่วนภาพแม้หลังจากเปลี่ยนขนาดภาพ คุณสามารถใช้เมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) เพื่อตั้งค่าการล็อกอัตราส่วนภาพ

โค้ด JavaScript นี้แสดงวิธีล็อกอัตราส่วนของรูปร่าง:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // ตั้งรูปร่างให้คงอัตราส่วนภาพเมื่อเปลี่ยนขนาด
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
การตั้งค่า *Lock Aspect Ratio* นี้รักษาเฉพาะอัตราส่วนของรูปร่าง ไม่ได้รักษาภาพที่บรรจุอยู่ 
{{% /alert %}}

## **ใช้คุณสมบัติ StretchOff**

โดยใช้เมธอด [setStretchOffsetLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) และ [setStretchOffsetBottom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) จากคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFillFormat) คุณสามารถกำหนดสี่เหลี่ยมเติมได้ 

เมื่อกำหนดการยืดสำหรับภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่กำหนด แต่ละขอบของสี่เหลี่ยมเติมจะถูกกำหนดโดยออฟเซ็ตเปอร์เซ็นต์จากขอบของกล่องขอบเขตของรูปร่าง ข้อบวกเป็นการย่อตรงขอบ ส่วนลบเป็นการขยายออกจากขอบ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน 
3. เพิ่มสี่เหลี่ยม `AutoShape` 
4. สร้างภาพ 
5. ตั้งค่าประเภทการเติมของรูปร่าง 
6. ตั้งค่าโหมดการเติมภาพของรูปร่าง 
7. เพิ่มภาพที่ตั้งค่าให้เติมรูปร่าง 
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตของรูปร่าง 
9. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

โค้ด JavaScript นี้แสดงกระบวนการที่ใช้คุณสมบัติ StretchOff:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // สร้างอินสแตนซ์ของคลาส ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // เพิ่ม AutoShape ที่ตั้งค่าเป็น Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // ตั้งค่าประเภทการเติมของรูปร่าง
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // ตั้งค่าโหมดการเติมภาพของรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // ตั้งค่าภาพเพื่อเติมรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตของรูปร่าง
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**ฉันจะตรวจสอบได้ว่า ฟอร์แมตภาพใดรองรับสำหรับ PictureFrame?**

Aspose.Slides รองรับทั้งภาพ raster (PNG, JPEG, BMP, GIF ฯลฯ) และภาพ vector (เช่น SVG) ผ่านอ็อบเจกต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) รายการฟอร์แมตที่รองรับมักสอดคล้องกับความสามารถของเอนจิ้นการแปลงสไลด์และภาพ

**การเพิ่มรูปภาพขนาดใหญ่หลายสิบรูปจะส่งผลต่อขนาดและประสิทธิภาพของไฟล์ PPTX อย่างไร?**

การฝังภาพขนาดใหญ่จะเพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การเชื่อมโยงภาพช่วยลดขนาดการนำเสนอแต่ต้องให้ไฟล์ภายนอกสามารถเข้าถึงได้ Aspose.Slides มีความสามารถในการเพิ่มภาพโดยใช้ลิงก์เพื่อบรรเทาขนาดไฟล์

**ฉันจะล็อกอ็อบเจกต์ภาพไม่ให้เคลื่อนย้าย/เปลี่ยนขนาดโดยไม่ตั้งใจได้อย่างไร?**

ใช้ [shape locks](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือการปรับขนาด) กลไกการล็อกนี้รองรับหลายประเภทของรูปร่างรวมถึง [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/)

**ความแม่นยำของเวกเตอร์ SVG จะถูกเก็บไว้เมื่อส่งออกงานนำเสนอเป็น PDF/ภาพหรือไม่?**

Aspose.Slides อนุญาตให้สกัด SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) เป็นเวกเตอร์ดั้งเดิม เมื่อ [ส่งออกเป็น PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/) หรือ [ฟอร์แมต raster](/slides/th/nodejs-java/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกเรสเตอร์ไลซ์ขึ้นอยู่กับการตั้งค่าการส่งออก; การที่ SVG ดั้งเดิมถูกเก็บเป็นเวกเตอร์ได้รับการยืนยันจากพฤติกรรมการสกัดภาพ