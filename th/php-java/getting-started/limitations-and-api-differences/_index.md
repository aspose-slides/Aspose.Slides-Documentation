---
title: ข้อจำกัดและความแตกต่างของ API
type: docs
weight: 100
url: /th/php-java/limitations-and-api-differences/
keywords:
- ข้อจำกัด
- ความแตกต่างของ API
- การเปรียบเทียบแพ็กเกจ
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เปรียบเทียบข้อจำกัดและความแตกต่างของ API ระหว่าง Aspose.Slides สำหรับ PHP ผ่าน Java และ Aspose.Slides สำหรับ Java."
---
## **ความแตกต่างของ API สาธารณะ**

รายการนี้ใช้ตัวอย่างโค้ดเพื่อแสดงความแตกต่างบางประการระหว่าง Aspose.Slides for Java และ Aspose.Slides for PHP ผ่าน API ของ Java

### **การนำเข้าห้องสมุด (การเปรียบเทียบแพ็กเกจ)**

**Aspose.Slides for Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides for PHP via Java**

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\sldes;
use aspose\sldes\Presentation;
```

### **การสร้างการนำเสนอใหม่**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **Enum หรือ ค่าคงที่**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **ตัวอย่าง**

**Aspose.Slides for Java**

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

public class Test
{
    public static void main(String[] args) throws Exception
    {
        // สร้างวัตถุ Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
        Presentation pres = new Presentation();
        try
        {
            // ดึงสไลด์แรก
            ISlide slide = pres.getSlides().get_Item(0);

            // เพิ่มออโต้เชปกับประเภทเป็นเส้น
            slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
            pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
        }
        finally
        {
            if (pres != null) pres.dispose();
        }
    }
}
```

**Aspose.Slides for PHP via Java**

```php
<?php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$pres = new Presentation();
try
{
    // ดึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);

    // เพิ่มออโต้เชปโดยตั้งค่าชนิดเป็นเส้น
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **ข้อจำกัดอื่นของ Aspose.Slides for PHP ผ่าน Java API เมื่อเทียบกับ Aspose.Slides for Java API**

เนมสเปซของ Aspose.Slides และคลาส Java ที่ใช้เป็น wrapper ที่สร้างโดย PhpJavaBridge บนคลาส Java ชื่อเดียวกันจากแพ็คเกจ com.aspose.slides

#### **1. การห่อหุ้มพารามิเตอร์และอาร์กิวเมนต์ของ Java**

พารามิเตอร์และอาร์กิวเมนต์ที่พวกเขาส่งคืนและรับเข้ามานั้นเป็น wrapper บนคลาส Java ที่มีชื่อเดียวกัน เพียงสตริงและชนิดตัวเลขเท่านั้นที่แปลงโดยอัตโนมัติ ส่วนอาเรย์, คอลเลกชัน, ไบต์ และบูลีนจะไม่ถูกแปลง  

**ข้อผิดพลาดที่พบบ่อย:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. การขยายคลาส Java และตัวดำเนินการ instanceof**

คุณไม่สามารถขยายคลาส Java จากคลาส PHP ได้ หากต้องการทางแก้ คุณสามารถใช้การประกอบ (composition) เมื่อจำเป็น
ตัวดำเนินการ instanceof ทำงานได้เฉพาะกับคลาสที่เป็นคอนกรีตเท่านั้น ไม่ทำงานกับอินเทอร์เฟซหรือคลาสพ่อแม่ของคลาส  

[วิธีแก้](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. อาเรย์ Java ไม่ใช่อาเรย์ PHP**

การสร้างอาเรย์ Java ใน PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. ความยาวของอาเรย์ Java**

``` php
$data->length; - ไม่ทำงาน
```
วิธีแก้
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. เมธอด Java Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
วิธีแก้
``` php
$file = new Java("java.io.File", "embedOle.html");
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = new JavaClass("java.lang.Byte");
$htmlBytes = $Array->newInstance($Byte, $Array->getLength($file));
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file));
    $dis->readFully($htmlBytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
```

#### **6. เมธอด Java Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - ไม่ทำงาน
```
วิธีแก้
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```