---
title: محدودیت‌ها و تفاوت‌های API
type: docs
weight: 100
url: /fa/php-java/limitations-and-api-differences/
keywords:
- محدودیت
- تفاوت‌های API
- مقایسه بسته
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "محدودیت‌ها و تفاوت‌های API بین Aspose.Slides برای PHP از طریق Java و Aspose.Slides برای Java را مقایسه کنید."
---
## **تفاوت‌های API عمومی**

این فهرست، با استفاده از قطعات نمونه کد، برخی تفاوت‌ها بین Aspose.Slides for Java و Aspose.Slides for PHP از طریق APIهای جاوا را نشان می‌دهد.

### **وارد کردن کتابخانه (مقایسه بسته‌ها)**

**Aspose.Slides for Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides for PHP از طریق جاوا**

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\sldes;
use aspose\sldes\Presentation;
```

### **ایجاد یک ارائه جدید**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP از طریق جاوا**

```php
$presentation = new Presentation();
```

### **Enums یا Constants**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP از طریق جاوا**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **مثال**

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
        // یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
        Presentation pres = new Presentation();
        try
        {
            // اسلاید اول را دریافت می‌کند
            ISlide slide = pres.getSlides().get_Item(0);

            // یک شکل خودکار با نوع خط اضافه می‌کند
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

**Aspose.Slides for PHP از طریق جاوا**

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
    // اسلاید اول را دریافت می‌کند
    $slide = $pres->getSlides()->get_Item(0);

    // یک شکل خودکار با نوع خط اضافه می‌کند
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **سایر محدودیت‌های Aspose.Slides for PHP از طریق API جاوا در مقایسه با Aspose.Slides for Java API**

فضای‌نام Aspose.Slides و کلاس‌های جاوایی که استفاده می‌شوند، بسته‌بندی‌های ایجاد شده توسط PhpJavaBridge بر روی کلاس‌های جاوا با همان نام از بسته com.aspose.slides هستند.

#### **1. بسته‌بندی پارامترها و آرگومان‌های جاوا**

پارامترها و آرگومان‌هایی که بر می‌گردانند و می‌پذیرند، بسته‌بندی‌هایی بر روی کلاس‌های جاوا با همان نام هستند. فقط رشته‌ها و نوع‌های عددی به‌طور خودکار تبدیل می‌شوند. آرایه‌ها، مجموعه‌ها، بایت‌ها و بولی‌ها تبدیل نمی‌شوند.  

**یک خطای رایج:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. ارث‌بری کلاس جاوا و عملگر instanceof**

نمی‌توانید یک کلاس جاوا را از کلاس PHP ارث‌ب ببرید. به‌عنوان راه‌حل، می‌توانید در صورت نیاز ترکیب (composition) را پیاده‌سازی کنید.
عملگر instanceof فقط برای یک کلاس مشخص کار می‌کند. برای رابط (interface) یا کلاس والد کار نمی‌کند. 

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. یک آرایه جاوا یک آرایه PHP نیست**

ایجاد آرایه جاوا در PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. طول آرایه جاوا**

``` php
$data->length; - does NOT work
```
راه‌حل
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. متد Java Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
راه‌حل
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

#### **6. متد Java Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
```
راه‌حل
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```