---
title: การทำงานหลายเธรดใน Aspose.Slides สำหรับ Android ผ่าน Java
linktitle: การทำงานหลายเธรด
type: docs
weight: 310
url: /th/androidjava/multithreading/
keywords:
- การทำงานหลายเธรด
- หลายเธรด
- งานแบบขนาน
- แปลงสไลด์
- สไลด์เป็นภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "การทำงานหลายเธรดของ Aspose.Slides สำหรับ Android ผ่าน Java ช่วยเพิ่มประสิทธิภาพการประมวลผล PowerPoint และ OpenDocument ค้นหาวิธีปฏิบัติที่ดีที่สุดสำหรับกระบวนการทำงานการนำเสนอที่มีประสิทธิภาพ"
---
## **บทนำ**

แม้การทำงานแบบขนานกับการนำเสนอจะเป็นไปได้ (besides parsing/loading/cloning) และส่วนใหญ่ทุกอย่างทำงานได้ดี แต่ก็มีโอกาสเล็กน้อยที่คุณอาจได้รับผลลัพธ์ที่ไม่ถูกต้องเมื่อใช้ไลบรารีในหลายเธรด

เราขอแนะนำอย่างยิ่งว่า **ไม่** ควรใช้อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) เพียงอันเดียวในสภาพแวดล้อมแบบหลายเธรด เนื่องจากอาจทำให้เกิดข้อผิดพลาดหรือความล้มเหลวที่ไม่คาดคิดและตรวจจับได้ยาก

ไม่ปลอดภัยที่จะโหลด, บันทึก, และ/หรือคล cloning อินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ในหลายเธรด การดำเนินการเช่นนี้ **ไม่** รองรับ หากคุณต้องการทำงานดังกล่าว คุณต้องทำงานแบบขนานโดยใช้กระบวนการหลายตัวที่ทำงานแบบเดียวเท่านั้น — และแต่ละกระบวนการควรใช้อินสแตนซ์การนำเสนอของตนเอง

## **แปลงสไลด์การนำเสนอเป็นภาพในแบบขนาน**

สมมติว่าเราต้องการแปลงสไลด์ทั้งหมดจากการนำเสนอ PowerPoint เป็นภาพ PNG แบบขนาน เนื่องจากไม่ปลอดภัยที่จะใช้อินสแตนซ์ `Presentation` เพียงอันเดียวในหลายเธรด เราจึงแบ่งสไลด์การนำเสนอเป็นการนำเสนอแยกส่วนและแปลงสไลด์เป็นภาพแบบขนาน โดยใช้การนำเสนอแต่ละอันในเธรดแยกต่างหาก ตัวอย่างโค้ดต่อไปนี้แสดงวิธีทำเช่นนั้น

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// ดึงสไลด์ i ออกเป็นการนำเสนอแยก.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// แปลงสไลด์เป็นภาพในงานแยก.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// รอให้ทุกงานเสร็จสมบูรณ์.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **คำถามที่พบบ่อย**

**ฉันต้องเรียกตั้งค่าลิขสิทธิ์ในทุกเธรดหรือไม่?**

ไม่ จำเป็นเพียงทำครั้งเดียวต่อกระบวนการ/โดเมนแอป ก่อนที่เธรดจะเริ่ม หาก [license setup](/slides/th/androidjava/licensing/) อาจถูกเรียกพร้อมกัน (เช่น ระหว่างการเริ่มต้นแบบขี้เกียจ) ให้ทำการซิงโครไนซ์การเรียกนั้น เพราะเมธอดตั้งค่าลิขสิทธิ์เองไม่รองรับหลายเธรด

**ฉันสามารถส่งอ็อบเจ็กต์ `Presentation` หรือ `Slide` ระหว่างเธรดได้หรือไม่?**

ไม่แนะนำให้ส่งอ็อบเจ็กต์การนำเสนอที่กำลังทำงานระหว่างเธรด: ใช้อินสแตนซ์แยกสำหรับแต่ละเธรดหรือสร้างการนำเสนอ/คอนเทนเนอร์สไลด์แยกล่วงหน้าสำหรับแต่ละเธรด วิธีนี้สอดคล้องกับคำแนะนำทั่วไปไม่ให้แชร์อินสแตนซ์การนำเสนอเดียวกันข้ามเธรด

**ปลอดภัยหรือไม่ในการทำการส่งออกแบบขนานเป็นฟอร์แมตต่าง ๆ (PDF, HTML, images) หากแต่ละเธรดมีอินสแตนซ์ `Presentation` ของตนเอง?**

ใช่ ด้วยอินสแตนซ์แยกและเส้นทางการส่งออกแยก การทำงานเหล่านี้มักจะทำงานแบบขนานได้อย่างถูกต้อง; หลีกเลี่ยงการใช้วัตถุการนำเสนอหรือสตรีม I/O ที่แชร์กัน

**ฉันควรทำอย่างไรกับการตั้งค่าแบบอักษรระดับโลก (โฟลเดอร์, การแทนที่) ในการทำงานหลายเธรด?**

ให้เริ่มต้นการตั้งค่าแบบอักษรระดับโลกทั้งหมดใน [font settings](/slides/th/androidjava/powerpoint-fonts/) ก่อนเริ่มเธรดและไม่เปลี่ยนแปลงในระหว่างการทำงานแบบขนาน สิ่งนี้จะขจัดการแข่งขันเมื่อเข้าถึงทรัพยากรแบบอักษรที่แชร์กัน