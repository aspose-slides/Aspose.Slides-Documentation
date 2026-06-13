---
title: ข้อจำกัดและความแตกต่างของ API
type: docs
weight: 100
url: /th/python-java/limitations-and-api-differences/
keywords: "โหนด, PowerPoint, ข้อจำกัด, API, ความแตกต่าง"
description: "ข้อจำกัดและความแตกต่างของ API ของ Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ข้อบกพร่อง/ข้อจำกัดที่รู้จัก**
คลาส Java ที่อยู่นอกแพคเกจ (ใน `default`) ไม่สามารถนำเข้าได้.
เนื่องจากขาดการสนับสนุน JVM คุณไม่สามารถปิดการทำงานของ JVM แล้วเริ่มใหม่ได้ รวมถึงไม่สามารถเริ่มต้น JVM มากกว่าหนึ่งสำเนาได้.
การผสม Python 64 บิตกับ Java 32 บิต หรือในทางกลับกัน จะทำให้เกิดการล่มเมื่อทำการนำเข้าโมดูล jpipe.

## **ความแตกต่างของ Public API**
รายการต่อไปนี้ (พร้อมตัวอย่างโค้ด) แสดงความแตกต่างบางประการระหว่าง Aspose.Slides for Java และ Aspose.Slides for Python ผ่าน Java API.

### **การนำเข้าห้องสมุด (เปรียบเทียบแพคเกจ)**

**Aspose.Slides for Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()
```

### **การสร้าง Presentation ใหม่**

**Aspose.Slides for Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **การสตรีมไฟล์และคอนสแตนต์**

**Aspose.Slides for Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input = open("presentation.pptx", mode="rb")
data = input.read()
pres = Presentation.createPresentationFromBytes(data)
pres.save("result.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

### **ข้อจำกัดอื่น ๆ ของ Aspose.Slides for Python ผ่าน Java API เมื่อเทียบกับ Aspose.Slides for Java API**

หากต้องการข้อมูลเพิ่มเติมเกี่ยวกับข้อจำกัดอื่น ๆ โปรดดูเอกสาร jpype:
- https://jpype.readthedocs.io/en/latest/