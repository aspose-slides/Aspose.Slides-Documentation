---
title: القيود والفروقات في واجهة البرمجة
type: docs
weight: 100
url: /php-java/limitations-and-api-differences/
---


## **فروقات واجهة البرمجة العامة**

تظهر هذه القائمة، باستخدام مقاطع كود عينة، بعض الفروقات بين Aspose.Slides لـ Java و Aspose.Slides لـ PHP عبر واجهات برمجة Java.

### **استيراد المكتبة (مقارنات الحزم)**

**Aspose.Slides لـ Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides لـ PHP عبر Java**

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\sldes;
use aspose\sldes\Presentation;
```

### **إنشاء عرض تقديمي جديد**

**Aspose.Slides لـ Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides لـ PHP عبر Java**

```php
$presentation = new Presentation();
```

### **الثوابت أو التعدادات**

**Aspose.Slides لـ Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides لـ PHP عبر Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **مثال**

**Aspose.Slides لـ Java**

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

public class Test
{
    public static void main(String[] args) throws Exception
    {
        // ينشئ كائن Presentation يمثل ملف عرض تقديمي
        Presentation pres = new Presentation();
        try
        {
            // يحصل على الشريحة الأولى
            ISlide slide = pres.getSlides().get_Item(0);

            // يضيف شكل تلقائي بالنوع المحدد إلى الخط
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

**Aspose.Slides لـ PHP عبر Java**

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
    // يحصل على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);

    // يضيف شكل تلقائي بالنوع المحدد إلى الخط
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **قيود أخرى لـ Aspose.Slides لـ PHP عبر واجهة برمجة Java بالمقارنة مع واجهة برمجة Java لـ Aspose.Slides**

مساحة أسماء Aspose.Slides والفئات الجافا التي تستخدمها هي أغلفة تم إنشاؤها بواسطة PhpJavaBridge فوق الفئات الجافا بنفس الاسم من حزمة com.aspose.slides.

#### 1. **لف المعايير والحجج الجافا**

المعايير والحجج التي ترجعها وتقبلها هي أغلفة فوق الفئات الجافا بنفس الأسماء. يتم تحويل السلاسل وأنواع الأرقام فقط تلقائيًا. المصفوفات والمجموعات والبايتات والقيم المنطقية لا يتم تحويلها.  

**خطأ شائع:**
``` php
if ($node->isAssistant()) - خطأ!
if (java_values($node->isAssistant())) - صحيح!
```

#### 2. **تمديد فئة جافا و оператор instanceof**

لا يمكنك توسيع فئة جافا من فئة PHP. كحل بديل، يمكنك تنفيذ التركيب عند الحاجة.
يعمل مشغل instanceof فقط لفئة معينة. لا يعمل مع واجهة الفئة أو الفئة الأصلية. 

[حل بديل](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### 3. **مصفوفة جافا ليست مصفوفة PHP**

إنشاء مصفوفة جافا في PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### 4. **طول مصفوفة جافا**

``` php
$data->length; - لا يعمل
```
حل بديل
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### 5. **طريقة جافا Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - لا يعمل
```
حل بديل
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

#### 6. **طريقة جافا Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - لا يعمل
```
حل بديل
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```