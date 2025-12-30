---
title: "القيود واختلافات API"
type: docs
weight: 100
url: /ar/php-java/limitations-and-api-differences/
keywords:
- قيد
- اختلافات API
- مقارنة الحزم
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "قارن بين القيود واختلافات API بين Aspose.Slides لـ PHP عبر Java و Aspose.Slides لـ Java."
---

## **اختلافات واجهة برمجة التطبيقات العامة**

هذه القائمة، باستخدام مقاطع شفرة عينة، تُظهر بعض الاختلافات بين Aspose.Slides لـ Java و Aspose.Slides لـ PHP عبر واجهات برمجة تطبيقات Java.

### **استيراد المكتبة (مقارنات الحزم)**

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


### **إنشاء عرض تقديمي جديد**

**Aspose.Slides for Java**  
```java
Presentation presentation = new Presentation();
```


**Aspose.Slides for PHP via Java**  
```php
$presentation = new Presentation();
```


### **التعدادات أو الثوابت**

**Aspose.Slides for Java**  
```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```


**Aspose.Slides for PHP via Java**  
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
        // ينشئ كائن Presentation يمثل ملف عرض تقديمي
        Presentation pres = new Presentation();
        try
        {
            // يحصل على الشريحة الأولى
            ISlide slide = pres.getSlides().get_Item(0);

            // يضيف شكلًا تلقائيًا مع ضبط النوع إلى خط
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
    // الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);

    // يضيف شكلًا تلقائيًا مع ضبط النوع إلى خط
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```


### **قيود أخرى على Aspose.Slides لـ PHP عبر واجهة برمجة تطبيقات Java مقارنةً بـ Aspose.Slides لـ Java**

مساحات الأسماء Aspose.Slides والفئات الجاوية التي يستخدمونها هي أغلفة تم إنشاؤها بواسطة PhpJavaBridge فوق فئات Java ذات الاسم نفسه من حزمة com.aspose.slides.

#### **1. تغليف معلمات Java والوسائط**

المعلمات والوسائط التي تُرجعها وتستقبلها هي أغلفة فوق فئات Java ذات نفس الأسماء. يتم تحويل السلاسل وأنواع الأعداد تلقائيًا فقط. لا يتم تحويل المصفوفات، والمجموعات، والبايتات، والأنواع البوليانية.  

**خطأ شائع:**  
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```


#### **2. توسيع فئة Java ومشغل instanceof**

لا يمكنك توسيع فئة Java من فئة PHP. كحل بديل، يمكنك تطبيق التركيب عند الحاجة. مشغل instanceof يعمل فقط مع فئة محددة. لا يعمل مع واجهة الفئة أو الفئة الأصلية.  

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. مصفوفة Java ليست مصفوفة PHP**

إنشاء مصفوفة Java في PHP:  
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```


#### **4. طول مصفوفة Java**  
``` php
$data->length; - does NOT work
```
  
workaround  
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```


#### **5. طريقة Java Files.readAllBytes**  
``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
  
workaround  
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


#### **6. طريقة Java Files.write**  
``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
```
  
workaround  
```php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```
