---
title: รับการแจ้งเตือน Callback สำหรับการแทนที่ฟอนต์
type: docs
weight: 90
url: /th/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- การแจ้งเตือน callback
- การแทนที่ฟอนต์
- กระบวนการเรนเดอร์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้การรับการแจ้งเตือน callback สำหรับการแทนที่ฟอนต์ใน Aspose.Slides สำหรับ Java และแสดงการนำเสนอ PowerPoint และ OpenDocument อย่างแม่นยำ."
---
## **บทนำ**

Aspose.Slides for Java อนุญาตให้คุณรับการแจ้งเตือนแบบ Callback สำหรับการแทนที่ฟอนต์เมื่อฟอนต์ที่จำเป็นไม่มีอยู่บนเครื่องระหว่างการเรนเดอร์ การแจ้งเตือนเหล่านี้ช่วยวินิจฉัยปัญหาฟอนต์ที่ขาดหายหรือไม่สามารถเข้าถึงได้

## **เปิดใช้งานการแจ้งเตือนแบบ Callback**

Aspose.Slides for Java มี API ที่ใช้งานง่ายสำหรับรับการแจ้งเตือนแบบ Callback ระหว่างการเรนเดอร์สไลด์การนำเสนอ ทำตามขั้นตอนต่อไปนี้เพื่อกำหนดค่าการแจ้งเตือนแบบ Callback:

1. สร้างคลาส Callback แบบกำหนดเองที่ดำเนินการตามอินเทอร์เฟซ [IWarningCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarningcallback/) เพื่อจัดการการแจ้งเตือน
1. ตั้งค่าการแจ้งเตือนแบบ Callback โดยใช้คลาสตัวเลือกเช่น [RenderingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/htmloptions/), และอื่น ๆ
1. โหลดการนำเสนอที่ใช้ฟอนต์ที่ไม่มีบนเครื่องเป้าหมาย
1. สร้างภาพย่อสไลด์หรือส่งออกการนำเสนอเพื่อสังเกตผลลัพธ์

**คลาส Callback การแจ้งเตือนแบบกำหนดเอง:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// ตัวอย่างผลลัพธ์:
//
// ฟอนต์จะถูกแทนที่จาก XYZ เป็น {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**สร้างภาพย่อสไลด์:**

```java
// ตั้งค่า callback การแจ้งเตือนเพื่อจัดการการแจ้งเตือนเกี่ยวกับฟอนต์ในระหว่างการเรนเดอร์สไลด์.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// โหลดการนำเสนอจากเส้นทางไฟล์ที่ระบุ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // สร้างภาพย่อสำหรับแต่ละสไลด์ในการนำเสนอ.
    for (ISlide slide : presentation.getSlides()) {
        // รับภาพย่อสไลด์โดยใช้ตัวเลือกการเรนเดอร์ที่ระบุ.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**ส่งออกเป็นรูปแบบ PDF:**

```java
// ตั้งค่า callback การแจ้งเตือนเพื่อจัดการการแจ้งเตือนเกี่ยวกับฟอนต์ในระหว่างการส่งออกเป็น PDF.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// โหลดการนำเสนอจากเส้นทางไฟล์ที่ระบุ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // ส่งออกการนำเสนอเป็น PDF.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**ส่งออกเป็นรูปแบบ HTML:**

```java
// ตั้งค่า callback การแจ้งเตือนเพื่อจัดการการแจ้งเตือนเกี่ยวกับฟอนต์ในระหว่างการส่งออกเป็น HTML.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// โหลดการนำเสนอจากเส้นทางไฟล์ที่ระบุ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // ส่งออกการนำเสนอในรูปแบบ HTML.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```