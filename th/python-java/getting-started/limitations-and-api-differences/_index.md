---
title: ข้อจำกัดและความแตกต่างของ API
type: docs
weight: 100
url: /th/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides for Python via Java
- ความแตกต่างของ API
- Python
- Java
- JPype
- ข้อจำกัดของ JVM
- PowerPoint
description: "เรียนรู้เกี่ยวกับข้อจำกัดของ JVM และความแตกต่างของ API ระหว่าง Aspose.Slides for Java และ Python via Java รวมถึงการนำเข้า การทำความสะอาดทรัพยากรและการจัดการไฟล์"
---
## **ภาพรวม**

Aspose.Slides for Python via Java ใช้ JPype เพื่อเข้าถึงไลบรารี Java จาก Python ตัวอย่างด้านล่างเปรียบเทียบการนำเข้าชุดแพ็กเกจ การสร้างงานนำเสนอ และการจัดการไฟล์ใน API ทั้งสอง

## **ข้อจำกัดที่ทราบ**

- **วงจรชีวิต JVM:** JPype รองรับ JVM หนึ่งตัวต่อกระบวนการ Python หลังจากปิด JVM แล้ว คุณไม่สามารถรีสตาร์ทในกระบวนการเดียวกันได้ เริ่มต้นครั้งเดียวและใช้ซ้ำสำหรับการดำเนินงานงานนำต่อไป
- **ความเข้ากันได้ของสถาปัตยกรรม:** Python และ Java ต้องมีสถาปัตยกรรมที่ตรงกัน ดูที่ [System Requirements](/slides/th/python-java/system-requirements/#python-java-and-jpype-requirements) สำหรับรายละเอียด

ดูที่ [JPype User Guide](https://jpype.readthedocs.io/en/latest/userguide.html) สำหรับรายละเอียดเกี่ยวกับข้อจำกัดเหล่านี้และการทำงานร่วมกับ Java

## **ความแตกต่างของ Public API**

เปรียบเทียบตัวอย่าง Java และ Python ด้านล่าง สำหรับรายละเอียดของสมาชิก Python ผ่าน Java ดูที่ [API Reference](/slides/th/python-java/api-reference/).

### **นำเข้าห้องสมุด**

Java นำเข้าคลาสจาก `com.aspose.slides` ใน Python ให้นำเข้า `asposeslides` ก่อนเริ่ม JVM แล้วจึงนำเข้าคลาสจาก `asposeslides.api` หลังจาก JVM ทำงานแล้ว ใช้ [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) เพื่อหลีกเลี่ยงการเริ่ม JVM ที่กำลังทำงานอยู่แล้ว

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
ตัวอย่าง Python จะปล่อยให้ JVM ทำงานต่อจนกระบวนการ Python สิ้นสุด ในโน้ตบุ๊ก ให้ใช้ JVM ที่ทำงานอยู่ซ้ำในหลายเซลล์ หาก JVM ถูกปิดไปแล้ว ให้รีสตาร์ทเคอร์เนลของโน้ตบุ๊กก่อนใช้วัตถุ Java อีกครั้ง
{{% /alert %}}

### **สร้างงานนำเสนอ**

Java ใช้คีย์เวิร์ด `new`; Python เรียกคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) โดยตรง ปลดปล่อยทรัพยากรของงานนำเสนอด้วย [Presentation.dispose](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#dispose) ในบล็อก `finally`

ตัวอย่างทั้งสองบันทึกงานนำเสนอเปล่าด้วยการใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) และ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#pptx).

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **อ่านไฟล์และใช้ค่าคงที่รูปแบบ**

Java สามารถโหลดงานนำเสนอจาก Java input stream ได้ ใน Python ให้อ่านไฟล์เป็นข้อมูลไบนารีและส่งไบต์ที่ได้ไปที่ [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#createpresentationfrombytes) วัตถุไฟล์ของ Python ไม่ใช่ Java input stream

ตัวอย่างด้านล่างต้องมีไฟล์ `presentation.pptx` อยู่ในไดเรกทอรีทำงานและบันทึกสำเนาเป็น `result.pptx` ตัวอย่างทั้งสองปิดไฟล์อินพุตและปลดปล่อยทรัพยากรงานนำเสนอ ตัวอย่าง Python จะอ่านไฟล์อินพุตทั้งหมดเข้าสู่หน่วยความจำ

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ต้องรีสตาร์ท JVM สำหรับแต่ละงานนำเสนอหรือไม่?**

ไม่ จำเป็นต้องให้ JVM ทำงานต่อและสร้างและปลดปล่อยวัตถุงานนำเสนอตามต้องการ การปิด JVM จะทำให้ไม่สามารถทำงานกับ Java ต่อในกระบวนการ Python เดียวกันได้

**ฉันสามารถเปิดงานนำเสนอโดยตรงจากพาธไฟล์ได้หรือไม่?**

ได้ ตัวสร้าง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ยอมรับพาธไฟล์ ใช้ตัวช่วยแบบไบต์เมื่อข้อมูลงานนำมือพร้อมเป็นไบต์ของ Python แล้ว

**ฉันควรเปลี่ยนชื่อค่าคงที่รูปแบบเมื่อแปลตัวอย่าง Java ไปเป็น Python หรือไม่?**

ไม่ ตัวอย่างเช่น [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#pptx) ใช้การสะกดและการใช้อักษรตัวพิมพ์ใหญ่เหมือนกันใน API ทั้งสอง