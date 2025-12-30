---
title: 限制与 API 差异
type: docs
weight: 100
url: /zh/php-java/limitations-and-api-differences/
keywords:
- 限制
- API 差异
- 包比较
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "比较 Aspose.Slides for PHP via Java 与 Aspose.Slides for Java 之间的限制和 API 差异。"
---

## **公共 API 差异**

此列表使用示例代码段，演示 Aspose.Slides for Java 与 Aspose.Slides for PHP via Java API 之间的某些差异。

### **导入库（包比较）**

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


### **实例化新演示文稿**

**Aspose.Slides for Java**
```java
Presentation presentation = new Presentation();
```


**Aspose.Slides for PHP via Java**
```php
$presentation = new Presentation();
```


### **枚举或常量**

**Aspose.Slides for Java**
```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```


**Aspose.Slides for PHP via Java**
```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```


### **示例**

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
        // 实例化一个表示演示文稿文件的 Presentation 对象
        Presentation pres = new Presentation();
        try
        {
            // 获取第一张幻灯片
            ISlide slide = pres.getSlides().get_Item(0);

            // 添加一个类型设置为线的自动形状
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
    // 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);

    // 添加一个类型设置为线的自动形状
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```


### **Aspose.Slides for PHP via Java API 相较于 Aspose.Slides for Java API 的其他限制**

Aspose.Slides 命名空间及其使用的 java 类是由 PhpJavaBridge 在 com.aspose.slides 包的同名 Java 类之上创建的包装器。

#### **1. 包装 Java 参数和实参**

它们返回和接受的参数与实参是基于同名 Java 类的包装器。仅字符串和数值类型会自动转换。数组、集合、字节和布尔值不会转换。

**常见错误：**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```


#### **2. 扩展 Java 类和 instanceof 运算符**

不能从 PHP 类扩展 Java 类。作为变通方法，可以在需要时实现组合。instanceof 运算符仅对具体类有效，对接口或父类无效。

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Java 数组不是 PHP 数组**

在 PHP 中创建 Java 数组：
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```


#### **4. Java 数组长度**
``` php
$data->length; - does NOT work
```

变通方法
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```


#### **5. Java 方法 Files.readAllBytes**
``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```

变通方法
```php
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


#### **6. Java 方法 Files.write**
``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
```

变通方法
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```
