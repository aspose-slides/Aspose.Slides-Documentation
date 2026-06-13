---
title: การทำงานหลายเธรดใน Aspose.Slides สำหรับ Python
linktitle: การทำงานหลายเธรด
type: docs
weight: 200
url: /th/python-net/multithreading/
keywords:
- การทำงานหลายเธรด
- หลายเธรด
- งานขนาน
- แปลงสไลด์
- สไลด์เป็นภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "Aspose.Slides สำหรับ Python ผ่านการทำงานหลายเธรดใน .NET ช่วยเพิ่มประสิทธิภาพการประมวลผล PowerPoint และ OpenDocument. ค้นพบแนวทางที่ดีที่สุดสำหรับกระบวนการทำงานนำเสนอที่มีประสิทธิภาพ."
---
## **บทนำ**

แม้ว่าการทำงานแบบขนานกับ presentation จะเป็นไปได้ (นอกจากการแยกวิเคราะห์/การโหลด/การคัดลอก) และส่วนใหญ่แล้วทุกอย่างทำงานได้ดี แต่ก็ยังมีโอกาสเล็กน้อยที่คุณอาจได้รับผลลัพธ์ที่ไม่ถูกต้องเมื่อใช้ไลบรารีในหลายเธรด  

เราแนะนำอย่างยิ่งว่า **ไม่** ควรใช้ออบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพียงหนึ่งตัวในสภาพแวดล้อมแบบหลายเธรด เนื่องจากอาจทำให้เกิดข้อผิดพลาดหรือความล้มเหลวที่ไม่คาดคิดและยากต่อการตรวจจับ  

การโหลด, บันทึก, และ/หรือคัดลอกออบเจกต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ในหลายเธรด **ไม่** ปลอดภัย การดำเนินการดังกล่าว **ไม่ได้** รับการสนับสนุน หากคุณต้องการทำงานเหล่านี้ คุณต้องทำการประมวลผลแบบขนานโดยใช้หลายกระบวนการแบบเชิงลำดับเดียว และแต่ละกระบวนการควรใช้ออบเจกต์ presentation ของตนเอง  

## **แปลงสไลด์ Presentation เป็นภาพแบบขนาน**

สมมติว่าเราต้องการแปลงสไลด์ทั้งหมดจาก PowerPoint presentation เป็นรูปภาพ PNG แบบขนาน เนื่องจากไม่ปลอดภัยในการใช้ `Presentation` ตัวเดียวในหลายเธรด เราจึงแบ่งสไลด์ของ presentation ออกเป็นหลาย presentation แยกกันและแปลงสไลด์เป็นภาพแบบขนาน โดยใช้แต่ละ presentation ในเธรดแยกต่างหาก ตัวอย่างโค้ดต่อไปนี้แสดงวิธีทำเช่นนั้น  

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # ดึงสไลด์ i ไปยังงานนำเสนอแยกส่วน.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # แปลงสไลด์เป็นภาพ.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# รอให้งานทั้งหมดเสร็จสิ้น.
for task in conversion_tasks:
    task.result()

del presentation
```

## **คำถามที่พบบ่อย**

**ฉันจำเป็นต้องเรียกตั้งค่าลิขสิทธิ์ในทุกเธรดหรือไม่?**

ไม่ จำเป็นต้องทำครั้งเดียวต่อกระบวนการหรือโดเมนแอปก่อนที่เธรดจะเริ่มต้น หาก [license setup](/slides/th/python-net/licensing/) อาจถูกเรียกพร้อมกัน (เช่นในระหว่างการเริ่มต้นแบบขี้เกียจ) ให้ซิงโครไนซ์การเรียกนั้นเนื่องจากเมธอดตั้งค่าลิขสิทธิ์เองไม่รองรับการทำงานแบบหลายเธรด  

**ฉันสามารถส่งออบเจกต์ `Presentation` หรือ `Slide` ระหว่างเธรดได้หรือไม่?**

ไม่แนะนำให้ส่งออบเจกต์ presentation ที่กำลังใช้งานอยู่ระหว่างเธรด: ควรใช้อินสแตนซ์แยกแต่ละเธรดหรือสร้าง presentation/slide แยกไว้ล่วงหน้าสำหรับแต่ละเธรด วิธีนี้สอดคล้องกับคำแนะนำทั่วไปที่ไม่ควรแชร์อินสแตนซ์ presentation เดียวกันระหว่างเธรด  

**การทำการส่งออกเป็นรูปแบบต่าง ๆ (PDF, HTML, images) แบบขนานปลอดภัยหรือไม่ หากแต่ละเธรดมีอินสแตนซ์ `Presentation` ของตนเอง?**

ใช่ หากใช้อินสแตนซ์แยกกันและกำหนดเส้นทางเอาต์พุตแยกต่างหาก งานเหล่านี้มักจะทำงานขนานได้อย่างถูกต้อง; ควรหลีกเลี่ยงการใช้วัตถุ presentation หรือสตรีม I/O ที่แชร์ร่วมกัน  

**ฉันควรทำอย่างไรกับการตั้งค่าแบบอักษรระดับโลก (โฟลเดอร์, การทดแทน) ในการทำงานหลายเธรด?**

ควรกำหนดค่าการตั้งค่าแบบอักษรระดับโลกทั้งหมดก่อนเริ่มเธรดและไม่ควรเปลี่ยนแปลงในระหว่างการทำงานขนาน วิธีนี้จะขจัดการชนกันเมื่อเข้าถึงทรัพยากรแบบอักษรที่ใช้ร่วมกัน