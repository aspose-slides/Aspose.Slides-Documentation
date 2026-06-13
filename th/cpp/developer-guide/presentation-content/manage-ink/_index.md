---
title: จัดการวัตถุอินค์ของงานนำเสนอด้วย C++
linktitle: จัดการอินค์
type: docs
weight: 95
url: /th/cpp/manage-ink/
keywords:
- หมึก
- วัตถุหมึก
- รอยเท้าหมึก
- จัดการหมึก
- วาดหมึก
- การวาด
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "จัดการวัตถุอินค์ของ PowerPoint—สร้าง, แก้ไขและจัดรูปแบบอินค์ดิจิทัลด้วย Aspose.Slides สำหรับ C++. รับตัวอย่างโค้ดสำหรับรอยเท้า, สีและขนาดของแปรง."
---
## **บทนำ**

PowerPoint มีฟังก์ชันอินค์ที่ช่วยให้คุณวาดรูปที่ไม่เป็นมาตรฐาน ซึ่งสามารถใช้เพื่อไฮไลท์วัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงดูดความสนใจไปยังรายการเฉพาะบนสไลด์  

Aspose.Slides มีอินเทอร์เฟซ [Aspose.Slides.Ink](https://reference.aspose.com/slides/th/cpp/aspose.slides.ink/) ซึ่งประกอบด้วยประเภทที่คุณต้องการเพื่อสร้างและจัดการวัตถุอินค์  

## **ความแตกต่างระหว่างวัตถุปกติและวัตถุอินค์**

วัตถุบนสไลด์ PowerPoint มักจะแสดงเป็นวัตถุรูปทรง (shape) วัตถุรูปทรงในรูปแบบที่ง่ายที่สุดคือคอนเทนเนอร์ที่กำหนดพื้นที่ของวัตถุเอง (กรอบของมัน) พร้อมกับคุณสมบัติต่าง ๆ ซึ่งรวมถึงขนาดพื้นที่คอนเทนเนอร์ รูปร่างของคอนเทนเนอร์ พื้นหลังของคอนเทนเนอร์ เป็นต้น สำหรับข้อมูลเพิ่มเติม ดูที่ [Shape Layout Format](https://docs.aspose.com/slides/th/cpp/shape-manipulations/#access-layout-formats-for-shape)  

อย่างไรก็ตามเมื่อ PowerPoint ทำงานกับวัตถุอินค์ มันจะละเลยคุณสมบัติทั้งหมดของกรอบวัตถุ (คอนเทนเนอร์) ยกเว้นขนาดของมัน ขนาดของพื้นที่คอนเทนเนอร์จะกำหนดโดยค่า `width` และ `height` มาตรฐาน:  

![ink_powerpoint1](ink_powerpoint1.png)

## **รอยเท้า Inkshape**

รอยเท้าเป็นองค์ประกอบพื้นฐานหรือมาตรฐานที่ใช้บันทึกเส้นทางของปากกาขณะที่ผู้ใช้เขียนอินค์ดิจิทัล รอยเท้าคือการบันทึกที่อธิบายลำดับของจุดที่เชื่อมต่อกัน  

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุพิกัด X และ Y ของแต่ละจุดตัวอย่าง เมื่อจุดที่เชื่อมต่อทั้งหมดถูกเรนเดอร์ จะได้ภาพเช่นนี้:  

![ink_powerpoint2](ink_powerpoint2.png)

## **คุณสมบัติ Brush สำหรับการวาด**

คุณสามารถใช้ brush เพื่อวาดเส้นที่เชื่อมต่อจุดขององค์ประกอบรอยเท้าได้ Brush มีสีและขนาดของตัวเอง ซึ่งสอดคล้องกับคุณสมบัติ `Brush.Color` และ `Brush.Size`  

### **ตั้งค่าสี Brush อินค์**

โค้ด C++ นี้แสดงวิธีตั้งค่าสีสำหรับ brush:  

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **ตั้งค่าขนาด Brush อินค์**

โค้ด C++ นี้แสดงวิธีตั้งค่าขนาดสำหรับ brush:  

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

โดยทั่วไป ความกว้างและความสูงของ brush จะไม่ตรงกัน จึงทำให้ PowerPoint ไม่แสดงขนาดของ brush (ส่วนข้อมูลจะเป็นสีเทา) แต่เมื่อความกว้างและความสูงของ brush ตรงกัน PowerPoint จะแสดงขนาดของมันดังนี้:  

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อความชัดเจน ให้เพิ่มความสูงของวัตถุอินค์และตรวจสอบมิติที่สำคัญ:  

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (กรอบ) ไม่พิจารณาขนาดของ brush — มันสมมติว่าความหนาของเส้นเป็นศูนย์ (ดูรูปภาพสุดท้าย)  

ดังนั้น เพื่อกำหนดพื้นที่ที่มองเห็นได้ของวัตถุอินค์ทั้งหมด เราต้องพิจารณาขนาด brush ของวัตถุรอยเท้า ที่นี่วัตถุเป้าหมาย (วัตถุรอยเท้าข้อความที่เขียนด้วยมือ) ถูกสเกลให้ตรงกับขนาดของคอนเทนเนอร์ (กรอบ) เมื่อขนาดของคอนเทนเนอร์ (กรอบ) เปลี่ยนแปลง ขนาดของ brush จะคงที่และในทางกลับกัน  

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint แสดงพฤติกรรมเดียวกันเมื่อทำงานกับข้อความ:  

![ink_powerpoint6](ink_powerpoint6.png)

**Further reading**

* เพื่ออ่านเกี่ยวกับรูปทรงโดยทั่วไป ให้ดูส่วน [PowerPoint Shapes](https://docs.aspose.com/slides/th/cpp/powerpoint-shapes/)  
* สำหรับข้อมูลเพิ่มเติมเกี่ยวกับค่าที่มีประสิทธิภาพ ให้ดู [Shape Effective Properties](https://docs.aspose.com/slides/th/cpp/shape-effective-properties/#get-effective-font-height-value)  