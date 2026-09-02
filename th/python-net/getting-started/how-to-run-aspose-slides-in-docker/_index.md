---
title: วิธีการรัน Aspose.Slides ใน Docker
linktitle: Aspose.Slides ใน Docker
type: docs
weight: 150
url: /th/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides ใน Docker
- คอนเทนเนอร์ Docker
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- แบบอักษร
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "รัน Aspose.Slides สำหรับ Python ผ่าน .NET ใน Docker: Dockerfile ที่ทำงานได้, ไลบรารีเนทีฟที่แพคเกจต้องการ, การตั้งค่าแบบอักษร, และการให้สิทธิ์ภายในคอนเทนเนอร์"
---
## **ภาพรวม**

Aspose.Slides for Python via .NET ทำงานในคอนเทนเนอร์ Linux แต่แพคเกจเป็น wrapper ของ Python ที่ห่อหุ้มรันไทม์ **.NET Core 3.1** ที่รวมมาใน ตัวรันไทม์นี้ต้องการไลบรารีเนทีฟสามตัวที่ภาพ Python แบบ slim ไม่ได้จัดส่ง และมันต้องการเวอร์ชันที่ตรงกัน บทความนี้ให้ตัวอย่าง Dockerfile ที่ทำงานได้ อธิบายเหตุผลที่ต้องมีแต่ละ dependency และแสดงวิธีเพิ่มแบบอักษรและไลเซนส์

## **Dockerfile ที่ทำงานได้**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

สร้างและเรียกใช้:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **เหตุผลที่ภาพฐานเป็น Debian 11**

`aspose.slides` wheel รวมรันไทม์ **.NET Core 3.1** และรันไทม์นั้นมาก่อนเวอร์ชันไลบรารีที่มาพร้อมกับการปล่อย Debian ปัจจุบัน ใน Debian 12 และ 13 คอนเทนเนอร์จะสร้างสำเร็จแล้วล้มเหลวที่การเรียก `Presentation()` ครั้งแรก:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

ข้อความอาจทำให้เข้าใจผิด — ICU *ได้* ติดตั้งบนภาพนั้นแล้ว แต่เป็น ICU 72 หรือ 76 ส่วน .NET Core 3.1 จะรับรู้เฉพาะเวอร์ชันหลักที่เก่ากว่าเท่านั้น Debian 12 ยังส่งมาพร้อม OpenSSL 3 อีกด้วย ซึ่งทำให้เกิดความล้มเหลวครั้งที่สอง:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` คือ Debian 11 ซึ่งให้ทั้งสองเวอร์ชันที่รันไทม์ที่รวมมาคาดหวัง:

| แพคเกจ | เวอร์ชันบน Debian 11 |เหตุผลที่ต้องการ |
|---|---|---|
| `libgdiplus` | 6.0.4 | การดำเนินการ GDI+ ที่ใช้สำหรับการเรนเดอร์รูปทรง, ข้อความ, และภาพ |
| `libicu67` | 67.1 | ข้อมูลการทำ Globalization. เวอร์ชันหลักที่ใหม่กว่าไม่ถูกจดจำโดย .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | การเข้ารหัส. ติดตั้งล่วงหน้าบน Debian 11; ไม่ปรากฏบน Debian 12+ |
| `libfontconfig1` | — | การค้นหาแบบอักษร |

`libssl1.1` มีอยู่แล้วในภาพฐาน ดังนั้นจึงไม่จำเป็นต้องระบุใน `apt-get install`.

หากต้องใช้ภาพฐานที่ใหม่กว่า ตั้งค่า `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` เพื่อข้ามข้อกำหนดของ ICU การตั้งค่านี้จะปิดการจัดรูปแบบตามวัฒนธรรมและ **ไม่** แก้ปัญหา OpenSSL ดังนั้น Debian 11 ยังคงเป็นตัวเลือกที่ง่ายกว่า

## **แบบอักษร**

ภาพ slim ไม่มีแบบอักษรเลย หากไม่มีแบบอักษรอย่างน้อยหนึ่งตัวติดตั้ง ข้อความจะแสดงเป็นกล่องว่างในผลลัพธ์ PDF, รูปภาพ, และ HTML `fonts-dejavu-core` เป็นจุดเริ่มต้นขนาดเล็กที่ใช้ทั่วไป

เพื่อให้ตรงกับลักษณะที่ผู้ใช้ต้องการในงานนำเสนอ ให้คัดลอกแบบอักษรที่ใช้งานเข้าสู่ภาพและชี้ Aspose.Slides ไปที่แบบอักษรเหล่านั้น:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **การให้สิทธิ์ภายในคอนเทนเนอร์**

ไม่ควรสร้างไฟล์ไลเซนส์ลงในภาพ — ใครดึงภาพก็จะได้ไลเซนส์เช่นกัน ให้เมาท์ไฟล์ในขณะรันเท่านั้น:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

หากไม่มีไลเซนส์ ไลบรารีจะทำงานในโหมดประเมินผล ซึ่งจะเพิ่มลายน้ำและจำกัดจำนวนสไลด์ที่ประมวลผล ดูรายละเอียดเพิ่มเติมที่ [Licensing](/slides/th/python-net/licensing/)

## **หน่วยความจำ**

การเรนเดอร์เป็น PDF หรือรูปภาพต้องการหน่วยความจำมากกว่าการอ่านไฟล์ คอนเทนเนอร์ที่มีขีดจำกัดหน่วยความจำต่ำอาจถูก OOM killer ฆ่าในกระบวนการแปลงกลางทาง ซึ่งมักปรากฏเป็นกระบวนการหายไปโดยไม่มี traceback ของ Python หากเกิดเหตุนี้ ให้เพิ่มขีดจำกัดหน่วยความจำของคอนเทนเนอร์ก่อนตรวจสอบโค้ด.