---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในงานนำเสนอบน Android
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/androidjava/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มภาพ
- เพิ่มบิตแมพ
- แทนที่รูปภาพ
- แทนที่ภาพ
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
- Android
- Java
- Aspose.Slides
description: "ทำให้การจัดการรูปภาพใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java มีประสิทธิภาพยิ่งขึ้น ปรับปรุงประสิทธิภาพและทำให้การทำงานของคุณเป็นอัตโนมัติ"
---
## **บทนำ**

ภาพทำให้การนำเสนอมีความน่าสนใจและดึงดูดมากขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพจากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ ลงในสไลด์ได้ ในทำนองเดียวกัน Aspose.Slides ให้คุณเพิ่มรูปภาพลงในสไลด์ของการนำเสนอผ่านวิธีการต่าง ๆ

{{% alert  title="Tip" color="primary" %}} 

Aspose ให้บริการตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างการนำเสนอได้อย่างรวดเร็วจากภาพ

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

หากคุณต้องการเพิ่มรูปภาพเป็นออบเจกต์แบบกรอบ—โดยเฉพาะหากคุณตั้งใจใช้ตัวเลือกการจัดรูปแบบมาตรฐานเพื่อเปลี่ยนขนาด เพิ่มเอฟเฟ็กต์ ฯลฯ—ดูที่ [Picture Frame](https://docs.aspose.com/slides/th/androidjava/picture-frame/).

{{% /alert %}} 

Aspose.Slides รองรับการทำงานกับภาพในรูปแบบที่เป็นที่นิยมเหล่านี้: JPEG, PNG, GIF และอื่น ๆ.

## **เพิ่มรูปภาพที่เก็บไว้ในเครื่องลงในสไลด์**

คุณสามารถเพิ่มหนึ่งหรือหลายรูปภาพจากคอมพิวเตอร์ของคุณลงในสไลด์ของการนำเสนอได้ โค้ดตัวอย่างนี้ใน Java แสดงวิธีการเพิ่มรูปภาพลงในสไลด์:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **เพิ่มรูปภาพจากเว็บลงในสไลด์**

หากรูปภาพที่คุณต้องการเพิ่มลงในสไลด์ไม่มีอยู่ในคอมพิวเตอร์ของคุณ คุณสามารถเพิ่มรูปภาพนั้นโดยตรงจากเว็บได้

โค้ดตัวอย่างนี้แสดงวิธีการเพิ่มรูปภาพจากเว็บลงในสไลด์ด้วย Java:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **เพิ่มรูปภาพลงใน Slide Master**

Slide Master คือสไลด์ระดับบนสุดที่เก็บและควบคุมข้อมูล (ธีม, การจัดวาง ฯลฯ) ของสไลด์ทั้งหมดที่อยู่ภายใต้ มั่นใจว่าเมื่อคุณเพิ่มรูปภาพลงใน Slide Master รูปภาพนั้นจะปรากฏบนทุกสไลด์ที่ใช้ Slide Master นั้น

โค้ดตัวอย่าง Java นี้แสดงวิธีการเพิ่มรูปภาพลงใน Slide Master:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **เพิ่มรูปภาพเป็นพื้นหลังของสไลด์**

คุณอาจเลือกใช้รูปภาพเป็นพื้นหลังของสไลด์หนึ่งหรือหลายสไลด์ ในกรณีนั้นคุณควรดู *[ตั้งค่ารูปภาพเป็นพื้นหลังสำหรับสไลด์](https://docs.aspose.com/slides/th/androidjava/presentation-background/#setting-images-as-background-for-slides)*

## **เพิ่ม SVG ลงในงานนำเสนอ**
คุณสามารถเพิ่มหรือแทรกรูปภาพใด ๆ ลงในงานนำเสนอโดยใช้เมธอด [addPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ที่เป็นส่วนหนึ่งของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection).

เพื่อสร้างอ็อบเจกต์รูปภาพจากไฟล์ SVG คุณสามารถทำได้ตามนี้:

1. สร้างอ็อบเจกต์ SvgImage เพื่อแทรกเข้าไปใน ImageShapeCollection
2. สร้างอ็อบเจกต์ PPImage จาก ISvgImage
3. สร้างอ็อบเจกต์ PictureFrame โดยใช้อินเทอร์เฟซ IPPImage

โค้ดตัวอย่างนี้แสดงวิธีการดำเนินขั้นตอนข้างต้นเพื่อเพิ่มภาพ SVG ลงในงานนำเสนอ:
```java 
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **แปลง SVG เป็นชุดของรูปร่าง**
การแปลง SVG เป็นชุดของรูปร่างของ Aspose.Slides มีลักษณะคล้ายกับฟังก์ชันของ PowerPoint ที่ใช้ทำงานกับภาพ SVG:

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ให้บริการโดยหนึ่งใน overload ของเมธอด [addGroupShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) ของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection) ที่รับอ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISvgImage) เป็นอาร์กิวเมนต์แรก

โค้ดตัวอย่างนี้แสดงวิธีการใช้เมธอดที่อธิบายเพื่อแปลงไฟล์ SVG เป็นชุดของรูปร่าง:

```java 
// สร้างการนำเสนอใหม่
IPresentation presentation = new Presentation();
try {
    // อ่านเนื้อหาไฟล์ SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // สร้างอ็อบเจกต์ SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // รับขนาดสไลด์
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // แปลงภาพ SVG เป็นกลุ่มของรูปร่างโดยปรับขนาดให้พอดีกับสไลด์
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // บันทึกการนำเสนอในรูปแบบ PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **เพิ่มรูปภาพเป็น EMF ลงในสไลด์**
Aspose.Slides สำหรับ Android ผ่าน Java ให้คุณสร้างภาพ EMF จากแผ่นงาน Excel และเพิ่มภาพเหล่านั้นเป็น EMF ในสไลด์ด้วย Aspose.Cells. 

โค้ดตัวอย่างนี้แสดงวิธีการทำงานตามที่อธิบาย:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//บันทึกเวิร์กบุ๊กไปยังสตรีม
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **แทนที่รูปภาพใน Image Collection**

Aspose.Slides ให้คุณแทนที่รูปภาพที่เก็บอยู่ใน Image Collection ของงานนำเสนอ (รวมถึงรูปภาพที่ใช้โดยรูปร่างของสไลด์) ส่วนนี้แสดงวิธีการหลายวิธีในการอัปเดตรูปภาพในคอลเลกชัน API มีเมธอดที่ง่ายต่อการแทนที่รูปภาพโดยใช้ข้อมูลไบต์ดิบ, อินสแตนซ์ของ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/), หรือรูปภาพอื่นที่มีอยู่แล้วในคอลเลกชัน

1. โหลดไฟล์งานนำเสนอที่มีรูปภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/).
2. โหลดรูปภาพใหม่จากไฟล์ลงในอาร์เรย์ไบต์.
3. แทนที่รูปภาพเป้าหมายด้วยรูปภาพใหม่โดยใช้แอตร์เรย์ไบต์.
4. ในวิธีที่สอง โหลดรูปภาพเข้าอ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) แล้วแทนที่รูปภาพเป้าหมายด้วยอ็อบเจกต์นั้น.
5. ในวิธีที่สาม แทนที่รูปภาพเป้าหมายด้วยรูปภาพที่มีอยู่แล้วใน Image Collection ของงานนำเสนอ.
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // วิธีที่หนึ่ง.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // วิธีที่สอง.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // วิธีที่สาม.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // บันทึกงานนำเสนอลงไฟล์.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

โดยใช้ตัวแปลง Aspose FREE [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) คุณสามารถทำเอฟเฟ็กต์เคลื่อนไหวให้กับข้อความ, สร้าง GIF จากข้อความ ฯลฯ ได้อย่างง่ายดาย.

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความละเอียดของรูปภาพต้นฉบับยังคงสมบูรณ์หลังจากแทรกหรือไม่?**

ใช่ พิกเซลต้นฉบับจะถูกเก็บรักษาไว้ แต่ลักษณะสุดท้ายขึ้นอยู่กับว่าภาพ [picture](/slides/th/androidjava/picture-frame/) ถูกสเกลอย่างไรบนสไลด์และการบีบอัดที่ใช้เมื่อบันทึก.

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันบนหลายสิบสไลด์พร้อมกันคืออะไร?**

วางโลโก้บน master slide หรือ layout แล้วแทนที่ใน Image Collection ของงานนำเสนอ—การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น.

**สามารถแปลง SVG ที่แทรกแล้วเป็นรูปร่างที่แก้ไขได้หรือไม่?**

ใช่ คุณสามารถแปลง SVG ให้เป็นกลุ่มของรูปร่าง แล้วส่วนย่อยแต่ละส่วนจะสามารถแก้ไขได้ด้วยคุณสมบัติมาตรฐานของรูปร่าง.

**ฉันจะตั้งค่าภาพเป็นพื้นหลังของหลายสไลด์พร้อมกันได้อย่างไร?**

[กำหนดรูปภาพเป็นพื้นหลัง](/slides/th/androidjava/presentation-background/) บน master slide หรือ layout ที่เกี่ยวข้อง—สไลด์ใด ๆ ที่ใช้ master/layout นั้นจะสืบทอดพื้นหลัง.

**ฉันจะป้องกันไม่ให้การนำเสนอเพิ่มขนาดขึ้นอย่างมากจากรูปภาพจำนวนมากได้อย่างไร?**

ใช้ทรัพยากรรูปภาพเดียวซ้ำแทนการทำสำเนาเลือกความละเอียดที่เหมาะสม ใช้การบีบอัดเมื่อบันทึก และเก็บกราฟิกที่ทำซ้ำไว้บน master ตามที่เหมาะสม.