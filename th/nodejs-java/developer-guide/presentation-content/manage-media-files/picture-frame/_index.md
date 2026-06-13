---
title: จัดการ Picture Frame ในการนำเสนอโดยใช้ JavaScript
linktitle: กรอบรูป
type: docs
weight: 10
url: /th/nodejs-java/picture-frame/
keywords:
- กรอบรูป
- เพิ่มกรอบรูป
- สร้างกรอบรูป
- เพิ่มภาพ
- สร้างภาพ
- สกัดภาพ
- ภาพแรสเตอร์
- ภาพเวกเตอร์
- ตัดภาพ
- พื้นที่ที่ถูกตัด
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบรูป
- คุณสมบัติกรอบรูป
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนภาพ
- ความโปร่งแสงของภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่มกรอบรูปในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java ทำให้กระบวนการทำงานของคุณราบรื่นและเพิ่มประสิทธิภาพการออกแบบสไลด์"
---
## **บทนำ**

Picture frame คือรูปทรงที่บรรจุภาพ—มันเหมือนภาพที่อยู่ในกรอบ  

คุณสามารถเพิ่มภาพลงในสไลด์ผ่าน picture frame ทำให้คุณสามารถจัดรูปแบบภาพโดยการจัดรูปแบบ picture frame ได้  

{{% alert title="เคล็ดลับ" color="primary" %}} 

Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างงานนำเสนออย่างรวดเร็วจากภาพ  

{{% /alert %}} 

## **สร้าง Picture Frame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ `PPImage` โดยเพิ่มภาพลงใน [ImagesCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ImageCollection) ที่เชื่อมกับอ็อบเจ็กต์ presentation ซึ่งจะใช้เติมรูปทรง  
4. กำหนดความกว้างและความสูงของภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFrame) ตามความกว้างและความสูงของภาพโดยใช้เมธอด `addPictureFrame` ที่เปิดให้ใช้จากอ็อบเจ็กต์ shape ที่เชื่อมกับสไลด์ที่อ้างอิง  
6. เพิ่ม picture frame (ซึ่งบรรจุภาพ) ไปยังสไลด์  
7. เขียน presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด JavaScript นี้แสดงวิธีการสร้าง picture frame:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // สร้างอินสแตนซ์ของคลาส Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // เพิ่ม picture frame ด้วยความสูงและความกว้างที่เท่ากับภาพ
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

Picture frame ช่วยให้คุณสร้างสไลด์งานนำเสนอจากภาพได้อย่างรวดเร็ว เมื่อผสาน picture frame กับตัวเลือกรูปแบบการบันทึก Aspose.Slides คุณสามารถจัดการการป้อน/ส่งออกเพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้  

## **สร้าง Picture Frame ด้วยสเกลสัมพัทธ์**

โดยการปรับสเกลสัมพัทธ์ของภาพ คุณสามารถสร้าง picture frame ที่ซับซ้อนได้มากขึ้น  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มภาพลงในคอลเลกชันภาพของ presentation  
4. สร้างอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PPImage) โดยเพิ่มภาพลงใน [ImagesCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ImageCollection) ที่เชื่อมกับอ็อบเจ็กต์ presentation ซึ่งจะใช้เติมรูปทรง  
5. กำหนดความกว้างและความสูงสัมพัทธ์ของภาพใน picture frame  
6. เขียน presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด JavaScript นี้แสดงวิธีการสร้าง picture frame ด้วยสเกลสัมพัทธ์:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // สร้างอินสแตนซ์ของคลาส Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // เพิ่ม Picture Frame ด้วยความสูงและความกว้างที่เท่ากับภาพ
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // กำหนดสเกลสัมพัทธ์ของความกว้างและความสูง
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

## **สกัดภาพ Raster จาก Picture Frames**

คุณสามารถสกัดภาพ raster จากอ็อบเจ็กต์ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFrame) และบันทึกเป็น PNG, JPG และรูปแบบอื่น ๆ ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดภาพจากไฟล์เอกสาร “sample.pptx” และบันทึกเป็นรูปแบบ PNG

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

## **สกัดภาพ SVG จาก Picture Frames**

เมื่อ presentation มีกราฟิก SVG ที่วางอยู่ใน shape ประเภท [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) Aspose.Slides for Node.js via Java สามารถดึงภาพเวกเตอร์ต้นฉบับที่คงความละเอียดเต็มได้โดยการวนผ่านคอลเลกชัน shape ของสไลด์ เพื่อตรวจสอบแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) ว่า [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) ที่อยู่ภายในมีเนื้อหา SVG หรือไม่ แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีสกัดภาพ SVG จาก picture frame:

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

## **รับค่าความโปร่งแสงของภาพ**

Aspose.Slides ให้คุณดึงค่าผลกระทบความโปร่งแสงที่ใช้กับภาพ โค้ด JavaScript นี้สาธิตการทำงาน:

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

## **การจัดรูปแบบ Picture Frame**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายอย่างที่สามารถใช้กับ picture frame โดยใช้ตัวเลือกเหล่านี้ คุณสามารถปรับ picture frame ให้ตรงกับความต้องการที่ระบุได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PPImage) โดยเพิ่มภาพลงใน [ImagesCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ImageCollection) ที่เชื่อมกับอ็อบเจ็กต์ presentation ซึ่งจะใช้เติมรูปทรง  
4. กำหนดความกว้างและความสูงของภาพ  
5. สร้าง `PictureFrame` ตามความกว้างและความสูงของภาพโดยใช้เมธอด [addPictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) ที่เปิดให้ใช้จากอ็อบเจ็กต์ [Shapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection) ที่เชื่อมกับสไลด์ที่อ้างอิง  
6. เพิ่ม picture frame (ซึ่งบรรจุภาพ) ไปยังสไลด์  
7. ตั้งค่าสีเส้นของ picture frame  
8. ตั้งค่าความกว้างของเส้น picture frame  
9. หมุน picture frame โดยกำหนดค่าบวกหรือค่าลบ  
   * ค่าบวกจะหมุนภาพตามเข็มนาฬิกา  
   * ค่าเป็นลบจะหมุนภาพย้อนเข็มนาฬิกา  
10. เพิ่ม picture frame (ซึ่งบรรจุภาพ) ไปยังสไลด์ (ขั้นตอนซ้ำเพื่อให้สอดคล้องกับตัวอย่างต้นฉบับ)  
11. เขียน presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด JavaScript นี้สาธิตกระบวนการจัดรูปแบบ picture frame:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // สร้างอินสแตนซ์ของคลาส Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // เพิ่ม Picture Frame ด้วยความสูงและความกว้างที่เท่ากับภาพ
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // กำหนดการจัดรูปแบบบางอย่างให้กับ PictureFrameEx
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

{{% alert title="เคล็ดลับ" color="primary" %}}

Aspose เพิ่งพัฒนา [Collage Maker ฟรี](https://products.aspose.app/slides/th/collage) หากคุณต้องการรวมภาพ JPG/JPEG หรือ PNG, หรือสร้างกริดจากภาพ คุณสามารถใช้บริการนี้ได้  

{{% /alert %}}

## **เพิ่มภาพเป็นลิงก์**

เพื่อหลีกเลี่ยงขนาด presentation ที่ใหญ่เกินไป คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์โดยตรงใน presentation โค้ด JavaScript นี้แสดงวิธีการเพิ่มภาพและวิดีโอลงใน placeholder:

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

## **ตัดภาพ**

โค้ด JavaScript นี้แสดงวิธีการตัดภาพที่มีอยู่บนสไลด์:

```javascript
var pres = new aspose.slides.Presentation();
// สร้างวัตถุภาพใหม่
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
    // เพิ่ม PictureFrame ไปยังสไลด์
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // ตัดภาพ (ค่าร้อยละ)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // บันทึกผลลัพธ์
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ลบพื้นที่ที่ถูกตัดของ Picture**

หากคุณต้องการลบพื้นที่ที่ถูกตัดของภาพที่อยู่ในกรอบ คุณสามารถใช้เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) เมธอดนี้จะคืนค่าภาพที่ตัดแล้วหรือภาพต้นฉบับหากไม่จำเป็นต้องตัด  

โค้ด JavaScript นี้แสดงการทำงาน:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // ดึง PictureFrame จากสไลด์แรก
    var picFrame = slide.getShapes().get_Item(0);
    // ลบพื้นที่ที่ถูกตัดของภาพ PictureFrame และคืนค่าภาพที่ถูกตัด
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // บันทึกผลลัพธ์
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 

เมธอด [deletePictureCroppedAreas()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) จะเพิ่มภาพที่ตัดแล้วลงในคอลเลกชันภาพของ presentation หากภาพนั้นถูกใช้เฉพาะใน [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) ที่ประมวลผลแล้ว การตั้งค่านี้สามารถลดขนาด presentation ได้ มิฉะนั้น จำนวนภาพใน presentation ที่ได้จะเพิ่มขึ้น  

เมธอดนี้แปลงไฟล์เมตา WMF/EMF เป็นภาพ raster PNG ในขั้นตอนการตัด  

{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดรูปภาพใน presentation ด้วยเมธอด [PictureFillFormat.compressImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-)  
เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาด shape และความละเอียดที่กำหนด พร้อมตัวเลือกให้ลบพื้นที่ที่ถูกตัด  

มันปรับขนาดและความละเอียดของรูปภาพคล้ายกับฟีเจอร์ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint  

ตัวอย่าง JavaScript ด้านล่างแสดงวิธีบีบอัดภาพใน presentation โดยระบุความละเอียดเป้าหมายและอาจลบพื้นที่ที่ถูกตัด:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกตัด
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // ตรวจสอบผลลัพธ์ของการบีบอัด
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

    // บีบอัดภาพเป็น 96 DPI (ความละเอียดอีเมล) โดยลบพื้นที่ที่ถูกตัด
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 

เมธอดนี้แปลงภาพเป็นความละเอียดต่ำตามขนาด shape และ DPI ที่ระบุ พื้นที่ที่ถูกตัดสามารถลบได้เพื่อเพิ่มประสิทธิภาพขนาดไฟล์  
หากภาพเป็นเมตาไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ นอกจากนี้คุณภาพ JPEG จะคงไว้หรือถูกลดลงเล็กน้อยตามความละเอียด เหมือนกับที่ PowerPoint จัดการกับ JPEG ความละเอียดสูง  

{{% /alert %}}

## **ล็อกอัตราส่วนรูปภาพ**

หากคุณต้องการให้ shape ที่บรรจุภาพคงอัตราส่วนรูปร่างแม้หลังจากเปลี่ยนขนาดภาพ คุณสามารถใช้เมธอด [setAspectRatioLocked](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) เพื่อตั้งค่า *Lock Aspect Ratio*  

โค้ด JavaScript นี้แสดงวิธีการล็อกอัตราส่วนของ shape:

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
    // ตั้งค่า shape ให้คงอัตราส่วนเมื่อปรับขนาด
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 

การตั้งค่า *Lock Aspect Ratio* นี้จะคงอัตราส่วนของ shape เท่านั้น ไม่ได้คงอัตราส่วนของภาพที่บรรจุอยู่  

{{% /alert %}}

## **ใช้คุณสมบัติ StretchOff**

โดยใช้เมธอด [setStretchOffsetLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) และ [setStretchOffsetBottom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) จากคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PictureFillFormat) คุณสามารถระบุสี่เหลี่ยมเติม  

เมื่อกำหนดการยืดสำหรับภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่ระบุ แต่ละขอบของสี่เหลี่ยมเติมจะกำหนดโดยออฟเซ็ตเปอร์เซ็นต์จากขอบที่สอดคล้องของกล่องรอบ shape ค่าเปอร์เซ็นต์บวกหมายถึงการย่อเข้ามา ส่วนค่าเปอร์เซ็นต์ลบหมายถึงการขยายออกไป  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสี่เหลี่ยม `AutoShape`  
4. สร้างภาพ  
5. ตั้งค่าชนิดการเติมของ shape  
6. ตั้งค่าโหมดเติมภาพของ shape  
7. เพิ่มภาพที่ตั้งค่าเพื่อเติม shape  
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องรอบ shape  
9. เขียน presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด JavaScript นี้สาธิตกระบวนการใช้คุณสมบัติ StretchOff:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
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
    // เพิ่ม AutoShape ตั้งค่ารูปแบบเป็นสี่เหลี่ยมผืนผ้า
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // ตั้งค่าชนิดการเติมของ shape
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // ตั้งค่าโหมดการเติมภาพของ shape
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // ตั้งค่าภาพเพื่อเติม shape
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตของ shape
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**ฉันจะตรวจสอบว่ารูปแบบภาพใดบ้างที่รองรับสำหรับ PictureFrame?**  

Aspose.Slides รองรับทั้งภาพ raster (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจ็กต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) รายการรูปแบบที่รองรับโดยทั่วไปจะสอดคล้องกับความสามารถของเอนจิ้นแปลงสไลด์และภาพ  

**การเพิ่มภาพจำนวนมากที่มีขนาดใหญ่จะส่งผลต่อขนาดและประสิทธิภาพของ PPTX อย่างไร?**  

การฝังภาพขนาดใหญ่จะเพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การเชื่อมโยงภาพช่วยลดขนาด presentation แต่ไฟล์ภายนอกต้องยังคงเข้าถึงได้ Aspose.Slides มีฟังก์ชันเพิ่มภาพโดยลิงก์เพื่อช่วยลดขนาดไฟล์  

**ฉันจะล็อกอ็อบเจ็กต์ภาพไม่ให้เคลื่อนย้ายหรือปรับขนาดโดยผิดพลาดได้อย่างไร?**  

ใช้ [shape locks](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือการปรับขนาด) กลไกการล็อกนี้รองรับรูปแบบ shape ต่าง ๆ รวมถึง [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/)  

**ความคมชัดของเวกเตอร์ SVG จะถูกเก็บรักษาเมื่อส่งออก presentation เป็น PDF/รูปภาพหรือไม่?**  

Aspose.Slides อนุญาตให้สกัด SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) เป็นเวกเตอร์ดั้งเดิม เมื่อนำออกเป็น PDF ([export to PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/)) หรือรูปแบบ raster ([export to PNG](/slides/th/nodejs-java/convert-powerpoint-to-png/)) ผลลัพธ์อาจถูกแปลงเป็น raster ขึ้นอยู่กับการตั้งค่าการส่งออก; การที่ SVG ดั้งเดิมถูกเก็บเป็นเวกเตอร์จะได้รับการยืนยันจากพฤติกรรมการสกัด.