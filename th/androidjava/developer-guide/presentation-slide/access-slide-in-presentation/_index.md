---
title: เข้าถึงสไลด์พรีเซนเทชันบน Android
linktitle: เข้าถึงสไลด์
type: docs
weight: 20
url: /th/androidjava/access-slide-in-presentation/
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
- presentation
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการเข้าถึงและจัดการสไลด์ในพรีเซนเทชัน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android เพิ่มประสิทธิภาพการทำงานด้วยตัวอย่างโค้ด Java"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเข้าถึงและจัดการสไลด์ในพรีเซนเทชันโดยใช้ Aspose.Slides แสดงวิธีการดึงสไลด์โดยใช้ดัชนีเริ่มจากศูนย์จากคอลเลกชันสไลด์และวิธีการเข้าถึงสไลด์โดยใช้รหัสที่ไม่ซ้ำกันด้วยเมธอด `getSlideById`  
คุณยังจะได้เรียนรู้วิธีการเปลี่ยนตำแหน่งของสไลด์โดยใช้เมธอด `setSlideNumber` และวิธีการกำหนดหมายเลขสไลด์เริ่มต้นสำหรับพรีเซนเทชันด้วยเมธอด `setFirstSlideNumber` ตัวอย่างจะแสดงการโหลดพรีเซนเทชัน การอ้างอิงสไลด์ การอัปเดตลำดับหรือหมายเลขสไลด์ และการบันทึกพรีเซนเทชันที่แก้ไขแล้ว  

## **เข้าถึงสไลด์โดยดัชนี**

สไลด์ทั้งหมดในพรีเซนเทชันจะเรียงลำดับเป็นตัวเลขโดยอิงตามตำแหน่งสไลด์เริ่มจาก 0 สไลด์แรกสามารถเข้าถึงได้ผ่านดัชนี 0; สไลด์ที่สองผ่านดัชนี 1; เป็นต้น  
คลาส Presentation ซึ่งเป็นตัวแทนไฟล์พรีเซนเทชัน จะเปิดเผยสไลด์ทั้งหมดเป็นคอลเลกชัน [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/) (คอลเลกชันของอ็อบเจกต์ [ISlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/)) โค้ด Java นี้แสดงวิธีการเข้าถึงสไลด์ผ่านดัชนีของมัน:

```java
// สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("demo.pptx");
try {
    // เข้าถึงสไลด์โดยใช้ดัชนีสไลด์
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **เข้าถึงสไลด์โดย ID**

สไลด์แต่ละสไลด์ในพรีเซนเทชันจะมี ID ที่ไม่ซ้ำกัน คุณสามารถใช้เมธอด [getSlideById](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlideById-long-) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)) เพื่อระบุ ID นั้น โค้ด Java นี้แสดงวิธีการให้ ID สไลด์ที่ถูกต้องและเข้าถึงสไลด์ผ่านเมธอด [getSlideById](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlideById-long-):

```java
// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("demo.pptx");
try {
    // รับไอดีของสไลด์
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // เข้าถึงสไลด์โดยใช้ไอดีของมัน
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **เปลี่ยนตำแหน่งสไลด์**

Aspose.Slides ให้คุณเปลี่ยนตำแหน่งของสไลด์ได้ ตัวอย่างเช่น คุณสามารถระบุให้สไลด์แรกกลายเป็นสไลด์ที่สอง  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
1. ดึงอ้างอิงของสไลด์ (ตำแหน่งที่ต้องการเปลี่ยน) ผ่านดัชนีของมัน
1. ตั้งค่าตำแหน่งใหม่ให้สไลด์ผ่านคุณสมบัติ [setSlideNumber](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#setSlideNumber-int-)
1. บันทึกพรีเซนเทชันที่แก้ไขแล้ว  

โค้ด Java นี้แสดงการดำเนินการที่สไลด์ในตำแหน่งที่ 1 ถูกย้ายไปยังตำแหน่งที่ 2:  

```java
// สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("Presentation.pptx");
try {
    // รับสไลด์ที่ตำแหน่งจะถูกเปลี่ยน
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ตั้งค่าตำแหน่งใหม่สำหรับสไลด์
    sld.setSlideNumber(2);
    
    // บันทึกพรีเซนเทชันที่แก้ไขแล้ว
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

สไลด์แรกกลายเป็นสไลด์ที่สอง; สไลด์ที่สองกลายเป็นสไลด์แรก เมื่อคุณเปลี่ยนตำแหน่งของสไลด์ สไลด์อื่นจะปรับโดยอัตโนมัติ  

## **กำหนดหมายเลขสไลด์**

โดยใช้คุณสมบัติ [setFirstSlideNumber](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)) คุณสามารถระบุหมายเลขใหม่สำหรับสไลด์แรกในพรีเซนเทชัน การดำเนินการนี้จะทำให้หมายเลขสไลด์อื่น ๆ ถูกคำนวณใหม่  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
1. ดึงหมายเลขสไลด์
1. ตั้งค่าหมายเลขสไลด์
1. บันทึกพรีเซนเทชันที่แก้ไขแล้ว  

โค้ด Java นี้แสดงการดำเนินการที่กำหนดหมายเลขสไลด์แรกเป็น 10:  

```java
// สร้างอ็อบเจกต์ Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // รับหมายเลขสไลด์
    int firstSlideNumber = pres.getFirstSlideNumber();

    // ตั้งค่าหมายเลขสไลด์
    pres.setFirstSlideNumber(10);
	
    // บันทึกพรีเซนเทชันที่แก้ไขแล้ว
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

หากคุณต้องการข้ามสไลด์แรก คุณสามารถเริ่มการนับหมายเลขจากสไลด์ที่สอง (และซ่อนการแสดงหมายเลขสำหรับสไลด์แรก) ได้ดังนี้:  

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // ตั้งหมายเลขสำหรับสไลด์แรกของพรีเซนเทชัน
    // แสดงหมายเลขสไลด์สำหรับสไลด์ทั้งหมด
    // ซ่อนหมายเลขสไลด์สำหรับสไลด์แรก
    // บันทึกพรีเซนเทชันที่แก้ไขแล้ว
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**หมายเลขสไลด์ที่ผู้ใช้เห็นตรงกับดัชนีเริ่มจากศูนย์ของคอลเลกชันหรือไม่?**  
จำนวนที่แสดงบนสไลด์สามารถเริ่มจากค่าใดค่าหนึ่ง (เช่น 10) และไม่ได้ต้องตรงกับดัชนี; ความสัมพันธ์นี้ถูกควบคุมโดยการตั้งค่า [first slide number](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) ของพรีเซนเทชัน  

**สไลด์ที่ซ่อนอยู่มีผลต่อการจัดลำดับดัชนีหรือไม่?**  
ใช่ สไลด์ที่ซ่อนอยู่ยังคงอยู่ในคอลเลกชันและนับรวมในการจัดลำดับดัชนี; “ซ่อน” หมายถึงการแสดงผล ไม่ได้หมายถึงตำแหน่งในคอลเลกชัน  

**ดัชนีของสไลด์จะเปลี่ยนเมื่อมีการเพิ่มหรือเอาสไลด์อื่นออกหรือไม่?**  
ใช่ ดัชนีจะสะท้อนลำดับปัจจุบันของสไลด์เสมอและจะถูกคำนวณใหม่เมื่อทำการแทรก, ลบ หรือย้ายสไลด์