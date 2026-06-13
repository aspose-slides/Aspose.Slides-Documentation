---
title: เข้าถึงสไลด์การนำเสนอใน Java
linktitle: เข้าถึงสไลด์
type: docs
weight: 20
url: /th/java/access-slide-in-presentation/
keywords:
- เข้าถึงสไลด์
- ดัชนีสไลด์
- ไอดีสไลด์
- ตำแหน่งสไลด์
- เปลี่ยนตำแหน่ง
- คุณสมบัติสไลด์
- หมายเลขสไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการเข้าถึงและจัดการสไลด์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java เพิ่มประสิทธิภาพการทำงานด้วยตัวอย่างโค้ด"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเข้าถึงและจัดการสไลด์ในงานนำเสนอโดยใช้ Aspose.Slides ซึ่งแสดงวิธีดึงสไลด์โดยใช้ดัชนีเริ่มจากศูนย์จากคอลเลกชันสไลด์และวิธีเข้าถึงสไลด์โดยใช้ ID ที่ไม่ซ้ำกันด้วยเมธอด `getSlideById`  
คุณยังจะได้เรียนรู้วิธีเปลี่ยนตำแหน่งของสไลด์ด้วยเมธอด `setSlideNumber` และวิธีกำหนดหมายเลขสไลด์เริ่มต้นสำหรับงานนำเสนอด้วยเมธอด `setFirstSlideNumber` ตัวอย่างเหล่านี้แสดงการโหลดงานนำเสนอ, การดึงอ้างอิงสไลด์, การอัปเดตลำดับหรือหมายเลขสไลด์, และการบันทึกงานนำเสนอที่แก้ไขแล้ว  

## **เข้าถึงสไลด์ตามดัชนี**

สไลด์ทั้งหมดในงานนำเสนอจัดเรียงเป็นลำดับตัวเลขตามตำแหน่งสไลด์โดยเริ่มจาก 0 สไลด์แรกสามารถเข้าถึงได้ผ่านดัชนี 0; สไลด์ที่สองเข้าถึงผ่านดัชนี 1; ฯลฯ  
คลาส Presentation ซึ่งเป็นตัวแทนไฟล์งานนำเสนอ จะเปิดเผยสไลด์ทั้งหมดเป็นคอลเลกชัน [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/) (คอลเลกชันของอ็อบเจ็กต์ [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/)) โค้ด Java นี้แสดงวิธีเข้าถึงสไลด์ผ่านดัชนีของมัน: 

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("demo.pptx");
try {
    // เข้าถึงสไลด์โดยใช้ดัชนีสไลด์
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **เข้าถึงสไลด์ตาม ID**

แต่ละสไลด์ในงานนำเสนอมี ID ที่ไม่ซ้ำกันที่เชื่อมโยงกับมัน คุณสามารถใช้เมธอด [getSlideById](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSlideById-long-) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)) เพื่อเข้าถึง ID นั้น โค้ด Java นี้แสดงวิธีการให้ ID สไลด์ที่ถูกต้องและเข้าถึงสไลด์ผ่านเมธอด [getSlideById](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSlideById-long-):

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("demo.pptx");
try {
    // รับ ID ของสไลด์
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // เข้าถึงสไลด์ผ่าน ID ของมัน
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **เปลี่ยนตำแหน่งสไลด์**

Aspose.Slides อนุญาตให้คุณเปลี่ยนตำแหน่งของสไลด์ ตัวอย่างเช่น คุณสามารถระบุให้สไลด์แรกกลายเป็นสไลด์ที่สองได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)  
1. ดึงอ้างอิงสไลด์ (ที่ต้องการเปลี่ยนตำแหน่ง) ผ่านดัชนีของมัน  
1. ตั้งค่าตำแหน่งใหม่ให้สไลด์ผ่านคุณสมบัติ [setSlideNumber](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#setSlideNumber-int-)  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java นี้แสดงการดำเนินการที่สไลด์ตำแหน่ง 1 ถูกย้ายไปตำแหน่ง 2: 

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("Presentation.pptx");
try {
    // ดึงสไลด์ที่ตำแหน่งจะถูกเปลี่ยน
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ตั้งค่าตำแหน่งใหม่ให้สไลด์
    sld.setSlideNumber(2);
    
    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

สไลด์แรกกลายเป็นสไลด์ที่สอง; สไลด์ที่สองกลายเป็นสไลด์แรก เมื่อคุณเปลี่ยนตำแหน่งของสไลด์ สไลด์อื่นๆ จะปรับตำแหน่งโดยอัตโนมัติ  

## **กำหนดหมายเลขสไลด์**

โดยใช้คุณสมบัติ [setFirstSlideNumber](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)) คุณสามารถระบุหมายเลขใหม่สำหรับสไลด์แรกในงานนำเสนอ การดำเนินการนี้จะทำให้หมายเลขสไลด์อื่นๆ ถูกคำนวณใหม่  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)  
1. ดึงหมายเลขสไลด์  
1. ตั้งหมายเลขสไลด์  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java นี้แสดงการดำเนินการที่กำหนดหมายเลขสไลด์แรกเป็น 10: 

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // ดึงหมายเลขสไลด์แรก
    int firstSlideNumber = pres.getFirstSlideNumber();

    // ตั้งหมายเลขสไลด์แรก
    pres.setFirstSlideNumber(10);
	
    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

หากคุณต้องการข้ามสไลด์แรก คุณสามารถเริ่มนับเลขจากสไลด์ที่สอง (และซ่อนการแสดงเลขสำหรับสไลด์แรก) ได้ดังนี้: 

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // ตั้งค่าหมายเลขสำหรับสไลด์แรกของงานนำเสนอ
    presentation.setFirstSlideNumber(0);

    // แสดงหมายเลขสไลด์สำหรับสไลด์ทั้งหมด
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // ซ่อนหมายเลขสไลด์สำหรับสไลด์แรก
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**หมายเลขสไลด์ที่ผู้ใช้เห็นตรงกับดัชนีเริ่มจากศูนย์ของคอลเลกชันหรือไม่?**  
หมายเลขที่แสดงบนสไลด์สามารถเริ่มจากค่าที่กำหนดเอง (เช่น 10) และไม่จำเป็นต้องตรงกับดัชนี; ความสัมพันธ์นี้ถูกควบคุมโดยการตั้งค่า [first slide number](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) ของงานนำเสนอ  

**สไลด์ที่ซ่อนอยู่ส่งผลต่อการจัดดัชนีหรือไม่?**  
ใช่. สไลด์ที่ซ่อนอยู่ยังคงอยู่ในคอลเลกชันและถูกนับในการจัดดัชนี; "ซ่อน" หมายถึงการแสดงผล ไม่ได้หมายถึงตำแหน่งในคอลเลกชัน  

**ดัชนีของสไลด์จะเปลี่ยนเมื่อมีการเพิ่มหรือเอาสไลด์อื่นออกหรือไม่?**  
ใช่. ดัชนีจะสะท้อนลำดับปัจจุบันของสไลด์เสมอและถูกคำนวณใหม่เมื่อทำการแทรก, ลบ, หรือย้ายสไลด์