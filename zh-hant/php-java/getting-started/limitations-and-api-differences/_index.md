---
title: 限制與 API 差異
type: docs
weight: 100
url: /zh-hant/php-java/limitations-and-api-differences/
keywords:
- 限制
- API 差異
- 套件比較
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "比較 Aspose.Slides for PHP via Java 與 Aspose.Slides for Java 之間的限制與 API 差異。"
---
## **公共 API 差異**

此清單使用範例程式碼段，展示 Aspose.Slides for Java 與透過 Java API 的 Aspose.Slides for PHP 之間的若干差異。

### **匯入函式庫（套件比較）**

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

### **建立新的簡報**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **列舉或常數**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **範例**

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
        // 實例化一個表示簡報檔案的 Presentation 物件
        Presentation pres = new Presentation();
        try
        {
            // 取得第一張投影片
            ISlide slide = pres.getSlides().get_Item(0);

            // 新增一個類型設定為線條的自動形狀
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
    // 取得第一張投影片
    $slide = $pres->getSlides()->get_Item(0);

    // 新增一個類型設定為線條的自動形狀
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **相較於 Aspose.Slides for Java API，Aspose.Slides for PHP via Java API 的其他限制**

Aspose.Slides 的命名空間以及其使用的 Java 類別，都是由 PhpJavaBridge 以 com.aspose.slides 套件中同名的 Java 類別為基礎所建立的包裝器。

#### **1. 包裝 Java 參數與引數**

它們回傳與接受的參數與引數都是以相同名稱的 Java 類別為基礎的包裝器。只有字串與數值型別會自動轉換，陣列、集合、位元組與布林值則不會轉換。  

**常見錯誤：**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. 繼承 Java 類別與 instanceof 運算子**

不能從 PHP 類別繼承 Java 類別。作為變通方法，您可以在需要時使用組合。instanceof 運算子僅適用於具體類別，無法用於類別的介面或父類別。  

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Java 陣列不是 PHP 陣列**

在 PHP 中建立 Java 陣列：
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. 取得 Java 陣列長度**

``` php
$data->length; - does NOT work
```
workaround
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. Java 方法 Files.readAllBytes**

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

#### **6. Java 方法 Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - 無法運作
```
workaround
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```