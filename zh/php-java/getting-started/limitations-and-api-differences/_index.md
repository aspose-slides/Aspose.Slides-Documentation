---
title: 限制和API差异
type: docs
weight: 100
url: /zh/php-java/limitations-and-api-differences/
---

## **公共API差异**

此列表使用示例代码段演示了Aspose.Slides for Java和Aspose.Slides for PHP通过Java API之间的某些差异。

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
        // 实例化一个表示演示文件的Presentation对象
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

### **与Aspose.Slides for Java API相比，Aspose.Slides for PHP via Java API的其他限制**

Aspose.Slides命名空间及其使用的java类是由PhpJavaBridge在com.aspose.slides包中创建的具有相同名称的Java类的包装器。

#### 1. **包装java参数和参数**

它们返回和接受的参数和参数是对具有相同名称的Java类的包装。只有字符串和数值类型会自动转换。数组、集合、字节和布尔值不会被转换。

**一个常见的错误：**
``` php
if ($node->isAssistant()) - 错误!
if (java_values($node->isAssistant())) - 正确!
```

#### 2. **扩展Java类和instanceof运算符**

您不能从PHP类扩展Java类。作为替代方法，您可以在需要时实现组合。
instanceof运算符仅适用于具体类。它不适用于类的接口或父类。

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### 3. **Java数组不是PHP数组**

在PHP中创建Java数组：
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### 4. **Java数组长度**

``` php
$data->length; - 不起作用
```
解决方法
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### 5. **Java方法Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - 不起作用
```
解决方法
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

#### 6. **Java方法Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - 不起作用
```
解决方法
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```