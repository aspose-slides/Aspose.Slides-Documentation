---
title: สร้างการนำเสนอใน Java
linktitle: สร้างการนำเสนอ
type: docs
weight: 10
url: /th/java/create-presentation/
keywords:
- สร้างการนำเสนอ
- การนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างการนำเสนอใน Java ด้วย Aspose.Slides—สร้างไฟล์ PPT, PPTX และ ODP, ใช้ประโยชน์จากการสนับสนุน OpenDocument, และบันทึกโดยโปรแกรมเพื่อผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานนำเสนอใน Aspose.Slides, เพิ่มรูปร่างที่มีข้อความบนสไลด์แรก, และบันทึกผลลัพธ์เป็นไฟล์ PPTX. เพื่อเปิดงานนำเสนอที่มีอยู่และบันทึกเป็นรูปแบบอื่น, ดู [เปิดการนำเสนอ](/slides/th/java/open-presentation/) และ [บันทึกการนำเสนอ](/slides/th/java/save-presentation/). ส่วน FAQ สั้น ๆ ที่ส่วนท้ายครอบคลุมคำถามทั่วไปเกี่ยวกับรูปแบบ, แม่แบบ, การกำหนดขนาดสไลด์, หน่วย, การใช้หน่วยความจำ, การทำงานหลายเธรด, การให้สิทธิ์, ลายเซ็นดิจิทัล, และการสนับสนุน VBA.

ก่อนเริ่ม, เพิ่ม Aspose.Slides for Java ลงในโปรเจกต์ของคุณจาก Maven repository ของ Aspose. ดู [การติดตั้ง](/slides/th/java/installation/) สำหรับการตั้งค่า Maven และสิ่งที่ Linux ต้องการเพิ่มเติม.

## **สร้างงานนำเสนอ**

การสร้างไฟล์ PowerPoint ตั้งแต่ต้นใน Aspose.Slides for Java เริ่มต้นด้วยการสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ตัวสร้างจะให้งานนำเสนอเปล่าที่มีสไลด์เดียว, พร้อมสำหรับรูปร่าง, ข้อความ, ชาร์ต, หรือเนื้อหาอื่นใดที่แอปพลิเคชันของคุณต้องการ. เมื่อคุณแก้ไขสไลด์นั้นหรือเพิ่มสไลด์ใหม่, คุณสามารถบันทึกผลลัพธ์เป็นรูปแบบ PPTX, PPT ดั้งเดิม, หรือ OpenDocument

เพื่อสร้างงานนำเสนอและใส่รูปร่างที่มีข้อความบนสไลด์แรก, ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). งานนำเสนอใหม่จะมีสไลด์เปล่าหนึ่งสไลด์อยู่แล้ว
1. ดึงสไลด์นั้นโดยใช้ดัชนี 0 จากคอลเลกชันที่เมธอด [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) คืนค่า
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ชนิด `Cloud` ด้วยเมธอด [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) และกำหนดข้อความของรูปร่างด้วยเมธอด [setText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#setText-java.lang.String-)
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX ด้วยเมธอด [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)

ตัวอย่างด้านล่างเป็นโปรแกรมเต็มรูปแบบ. ในโปรเจกต์ Maven จาก [การติดตั้ง](/slides/th/java/installation/), บันทึกเป็น *src/main/java/HelloSlides.java* และเรียกใช้ `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // สร้างการนำเสนอ. มันมีสไลด์เปล่าหนึ่งสไลด์อยู่แล้ว.
        Presentation presentation = new Presentation();
        try {
            // ดึงสไลด์แรก.
            ISlide slide = presentation.getSlides().get_Item(0);

            // เพิ่มรูปร่างเมฆและใส่ข้อความลงในรูปร่าง.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // บันทึกการนำเสนอเป็นไฟล์ PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

มุมบนซ้ายของเมฆอยู่ห่างจากขอบซ้าย 20 พอยต์และห่างจากขอบบน 20 พอยต์ของสไลด์, รูปร่างกว้าง 200 พอยต์และสูง 80 พอยต์. โปรแกรมจะบันทึก *new_presentation.pptx* ที่มีสไลด์หนึ่งสไลด์ซึ่งมีเมฆและข้อความของมัน. หากไม่มีลิขสิทธิ์, Aspose.Slides จะเพิ่มลายน้ำการประเมินผลบนทุกสไลด์ที่บันทึก; ดู [การให้สิทธิ์](/slides/th/java/licensing/)

ผลลัพธ์:

![งานนำเสนอใหม่](new_presentation.png)

## **คำถามที่พบบ่อย**

### ฉันสามารถบันทึกงานนำเสนอใหม่เป็นรูปแบบใดได้บ้าง?

คุณสามารถบันทึกเป็น [PPTX, PPT, และ ODP](/slides/th/java/save-presentation/) และส่งออกเป็น [PDF](/slides/th/java/convert-powerpoint-to-pdf/), [XPS](/slides/th/java/convert-powerpoint-to-xps/), [HTML](/slides/th/java/convert-powerpoint-to-html/), [SVG](/slides/th/java/render-a-slide-as-an-svg-image/), และ [images](/slides/th/java/convert-powerpoint-to-png/) รวมถึงรูปแบบอื่น ๆ อีกหลายชนิด

### ฉันสามารถเริ่มจากเทมเพลต (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?

ได้. โหลดเทมเพลตและบันทึกเป็นรูปแบบที่ต้องการ; POTX/POTM/PPTM และรูปแบบคล้ายกัน [ได้รับการสนับสนุน](/slides/th/java/supported-file-formats/)

### ฉันจะควบคุมขนาด/อัตราส่วนของสไลด์เมื่อสร้างงานนำเสนออย่างไร?

ตั้งค่า [slide size](/slides/th/java/slide-size/) (รวมถึงค่าพรีเซ็ตเช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกวิธีที่เนื้อหาจะสเกล

### ขนาดและพิกัดวัดเป็นหน่วยอะไร?

เป็นพอยต์: 1 นิ้วเท่ากับ 72 หน่วย

### ฉันจะจัดการกับงานนำเสนอขนาดใหญ่ (มีไฟล์สื่อหลายไฟล์) เพื่อลดการใช้หน่วยความจำอย่างไร?

ใช้ [BLOB management strategies](/slides/th/java/manage-blob/), จำกัดการเก็บไว้ในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และควรใช้เวิร์กโฟลว์แบบไฟล์เป็นหลักแทนสตรีมในหน่วยความจำอย่างเดียว

### ฉันสามารถสร้าง/บันทึกงานนำเสนอแบบขนานได้หรือไม่?

คุณไม่สามารถทำงานกับอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) เดียวจากหลาย [threads](/slides/th/java/multithreading/) ได้. ให้สร้างอินสแตนซ์แยกกันสำหรับแต่ละเธรดหรือแต่ละกระบวนการ

### ฉันจะลบลายน้ำการทดลองและข้อจำกัดต่าง ๆ อย่างไร?

[Apply a license](/slides/th/java/licensing/) หนึ่งครั้งต่อกระบวนการ. ไฟล์ XML ของลิขสิทธิ์ต้องไม่มีการแก้ไข, และการตั้งค่าลิขสิทธิ์ควรทำให้สอดคล้องกันหากมีหลายเธรดเกี่ยวข้อง

### ฉันสามารถลงลายเซ็นดิจิทัลให้กับไฟล์ PPTX ที่สร้างได้หรือไม่?

ได้. [Digital signatures](/slides/th/java/digital-signature-in-powerpoint/) (การเพิ่มและตรวจสอบ) ได้รับการสนับสนุนสำหรับงานนำเสนอ

### งานนำเสนอที่สร้างมีการสนับสนุนมาโคร (VBA) หรือไม่?

ได้. คุณสามารถ [create/edit VBA projects](/slides/th/java/presentation-via-vba/) และบันทึกไฟล์ที่เปิดใช้งานมาโครเช่น PPTM/PPSM