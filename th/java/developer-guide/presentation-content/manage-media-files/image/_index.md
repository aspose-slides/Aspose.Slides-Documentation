---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในงานนำเสนอโดยใช้ Java
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/java/image/
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
- Java
- Aspose.Slides
description: "ทำให้การจัดการรูปภาพใน PowerPoint และ OpenDocument ง่ายขึ้นด้วย Aspose.Slides สำหรับ Java ปรับปรุงประสิทธิภาพและทำให้งานของคุณเป็นอัตโนมัติ"
---
## **บทนำ**

ภาพทำให้การนำเสนอมีความดึงดูดและน่าสนใจมากขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพจากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่นลงบนสไลด์ได้ เช่นเดียวกับ Aspose.Slides ที่อนุญาตให้คุณเพิ่มภาพลงในสไลด์ของการนำเสนอผ่านกระบวนการที่ต่างกัน

{{% alert title="เคล็ดลับ" color="primary" %}} 

Aspose ให้บริการตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างการนำเสนออย่างรวดเร็วจากภาพ 

{{% /alert %}} 

{{% alert title="ข้อมูล" color="info" %}}

หากคุณต้องการเพิ่มภาพเป็นอ็อบเจ็กต์กรอบ—โดยเฉพาะอย่างยิ่งหากคุณวางแผนจะใช้ตัวเลือกการจัดรูปแบบมาตรฐานเพื่อเปลี่ยนขนาด เพิ่มเอฟเฟกต์ ฯลฯ—ดูที่ [Picture Frame](https://docs.aspose.com/slides/th/java/picture-frame/) 

{{% /alert %}} 

{{% alert title="หมายเหตุ" color="warning" %}}

คุณสามารถจัดการการดำเนินการเข้า/ออกที่เกี่ยวข้องกับภาพและการนำเสนอ PowerPoint เพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง ดูหน้านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/java/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/java/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/java/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/java/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/java/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/java/conversion/svg-to-png/) 

{{% /alert %}}

Aspose.Slides รองรับการทำงานกับภาพในรูปแบบที่เป็นที่นิยม ได้แก่ JPEG, PNG, GIF และอื่น ๆ 

## **เพิ่มรูปภาพที่จัดเก็บไว้ในเครื่องไปยังสไลด์**

คุณสามารถเพิ่มหนึ่งหรือหลายรูปภาพจากคอมพิวเตอร์ของคุณลงบนสไลด์ในงานนำเสนอ โค้ดตัวอย่างใน Java นี้แสดงวิธีเพิ่มภาพลงบนสไลด์:

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

## **เพิ่มรูปภาพจากเว็บไปยังสไลด์**

หากภาพที่คุณต้องการเพิ่มลงสไลด์ไม่มีในเครื่องของคุณ คุณสามารถเพิ่มภาพโดยตรงจากเว็บได้

โค้ดตัวอย่างนี้แสดงวิธีเพิ่มภาพจากเว็บไปยังสไลด์ใน Java:

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

## **เพิ่มรูปภาพไปยังมาสเตอร์สไลด์**

มาสเตอร์สไลด์คือสไลด์บนสุดที่เก็บและควบคุมข้อมูล (ธีม,เลย์เอาต์ ฯลฯ) ของสไลด์ทั้งหมดที่อยู่ภายใต้มัน ดังนั้นเมื่อคุณเพิ่มภาพไปยังมาสเตอร์สไลด์ ภาพนั้นจะปรากฏบนทุกสไลด์ที่อยู่ภายใต้มาสเตอร์สไลด์นั้น

โค้ดตัวอย่าง Java นี้แสดงวิธีเพิ่มภาพไปยังมาสเตอร์สไลด์:

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

## **เพิ่มรูปภาพเป็นพื้นหลังสไลด์**

คุณอาจต้องการใช้รูปเป็นพื้นหลังสำหรับสไลด์เฉพาะหรือหลายสไลด์ ในกรณีนั้นคุณต้องดู *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/th/java/presentation-background/#setting-images-as-background-for-slides)*

## **เพิ่ม SVG ไปยังการนำเสนอ**

คุณสามารถเพิ่มหรือแทรกรูปภาพใด ๆ ลงในงานนำเสนอโดยใช้เมธอด [addPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ที่เป็นส่วนหนึ่งของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection)

เพื่อสร้างอ็อบเจ็กต์ภาพจาก SVG คุณสามารถทำตามขั้นตอนต่อไปนี้:

1. สร้างอ็อบเจ็กต์ SvgImage เพื่อนำเข้าไปยัง ImageShapeCollection
2. สร้างอ็อบเจ็กต์ PPImage จาก ISvgImage
3. สร้างอ็อบเจ็กต์ PictureFrame โดยใช้อินเทอร์เฟซ IPPImage

โค้ดตัวอย่างนี้แสดงวิธีดำเนินการตามขั้นตอนข้างต้นเพื่อเพิ่มภาพ SVG ลงในงานนำเสนอ:
```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
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

## **แปลง SVG เป็นชุดของรูปทรง**

การแปลง SVG เป็นชุดของรูปทรงของ Aspose.Slides มีความคล้ายคลึงกับฟังก์ชัน PowerPoint ที่ใช้ทำงานกับภาพ SVG:

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ให้บริการโดยหนึ่งใน overload ของเมธอด [addGroupShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) ของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection) ที่รับอ็อบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISvgImage) เป็นอาร์กิวเมนต์แรก

โค้ดตัวอย่างนี้แสดงวิธีใช้เมธอดที่อธิบายเพื่อแปลงไฟล์ SVG เป็นชุดของรูปทรง:

```java 
// สร้างการนำเสนอใหม่
IPresentation presentation = new Presentation();
try {
    // อ่านเนื้อหาไฟล์ SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // สร้างอ็อบเจ็กต์ SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // รับขนาดสไลด์
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // แปลงภาพ SVG เป็นกลุ่มของรูปทรงโดยปรับสเกลให้พอกับขนาดสไลด์
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // บันทึกการนำเสนอในรูปแบบ PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **เพิ่มรูปภาพเป็น EMF ไปยังสไลด์**

Aspose.Slides for Java อนุญาตให้คุณสร้างภาพ EMF จากชีต Excel และเพิ่มภาพเหล่านั้นเป็น EMF ในสไลด์ด้วย Aspose.Cells  

โค้ดตัวอย่างนี้แสดงวิธีทำงานตามที่อธิบาย:

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

Aspose.Slides ให้คุณแทนที่ภาพที่เก็บอยู่ใน Image Collection ของงานนำเสนอ (รวมถึงภาพที่ใช้โดยรูปทรงสไลด์) ส่วนนี้แสดงหลายวิธีการอัปเดตภาพในคอลเลกชัน API มีเมธอดที่ตรงไปตรงมาเพื่อแทนที่ภาพโดยใช้ข้อมูลไบต์ดิบ, อินสแตนซ์ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) หรือภาพอื่นที่มีอยู่แล้วในคอลเลกชัน

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์งานนำเสนอที่มีภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. โหลดภาพใหม่จากไฟล์เข้าสู่ byte array
3. แทนที่ภาพเป้าหมายด้วยภาพใหม่โดยใช้ byte array
4. ในวิธีที่สอง โหลดภาพเข้าสู่วัตถุ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) แล้วแทนที่ภาพเป้าหมายด้วยวัตถุนั้น
5. ในวิธีที่สาม แทนที่ภาพเป้าหมายด้วยภาพที่มีอยู่แล้วใน Image Collection ของงานนำเสนอ
6. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // วิธีที่หนึ่ง.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
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

{{% alert title="ข้อมูล" color="info" %}}

โดยใช้ Aspose FREE [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) converter คุณสามารถทำให้ข้อความเคลื่อนไหว สร้าง GIF จากข้อความ เป็นต้นได้อย่างง่ายดาย 

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความละเอียดต้นฉบับของภาพยังคงอยู่หลังการแทรกหรือไม่?**

ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่ลักษณะสุดท้ายขึ้นกับวิธีที่ [picture](/slides/th/java/picture-frame/) ถูกสเกลบนสไลด์และการบีบอัดที่ทำขณะบันทึก

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันบนหลายสิบสไลด์พร้อมกันคืออะไร?**

ใส่โลโก้บนมาสเตอร์สไลด์หรือเลย์เอาต์และแทนที่ใน Image Collection ของงานนำเสนอ—การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น

**สามารถแปลง SVG ที่แทรกแล้วให้เป็นรูปทรงที่สามารถแก้ไขได้หรือไม่?**

ได้ คุณสามารถแปลง SVG เป็นกลุ่มของรูปทรง หลังจากนั้นส่วนย่อยต่าง ๆ จะกลายเป็นรูปทรงที่แก้ไขได้ด้วยคุณสมบัติมาตรฐานของรูปทรง

**จะตั้งค่าภาพเป็นพื้นหลังสำหรับหลายสไลด์พร้อมกันอย่างไร?**

[Assign the image as the background](/slides/th/java/presentation-background/) บนมาสเตอร์สไลด์หรือเลย์เอาต์ที่เกี่ยวข้อง—สไลด์ใด ๆ ที่ใช้มาสเตอร์/เลย์เอาต์นั้นจะสืบทอดพื้นหลังโดยอัตโนมัติ

**จะป้องกันไม่ให้ไฟล์งานนำเสนอขยายขนาดมากเกินไปจากภาพจำนวนมากได้อย่างไร?**

ใช้ทรัพยากรภาพเดียวแทนการทำซ้ำ เลือกความละเอียดที่สมเหตุสมผล ใช้การบีบอัดขณะบันทึก และเก็บกราฟิกที่ใช้บ่อยไว้บนมาสเตอร์เมื่อเหมาะสม