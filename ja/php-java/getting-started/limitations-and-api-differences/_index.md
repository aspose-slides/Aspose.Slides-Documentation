---
title: 制限とAPIの違い
type: docs
weight: 100
url: /ja/php-java/limitations-and-api-differences/
keywords:
- 制限
- APIの違い
- パッケージ比較
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java と Aspose.Slides for Java の間の制限と API の違いを比較します。"
---

## **Public API Differences**

このリストは、サンプルコードセグメントを使用して、Aspose.Slides for Java と Aspose.Slides for PHP via Java API の間のいくつかの違いを示しています。

### **Importing library (Package Comparisons)**

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


### **Instantiating a New Presentation**

**Aspose.Slides for Java**
```java
Presentation presentation = new Presentation();
```


**Aspose.Slides for PHP via Java**
```php
$presentation = new Presentation();
```


### **Enums or Constants**

**Aspose.Slides for Java**
```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```


**Aspose.Slides for PHP via Java**
```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```


### **Example**

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
        // プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
        Presentation pres = new Presentation();
        try
        {
            // 最初のスライドを取得する
            ISlide slide = pres.getSlides().get_Item(0);

            // タイプがラインに設定されたオートシェイプを追加する
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
    // 最初のスライドを取得します
    $slide = $pres->getSlides()->get_Item(0);

    // タイプがラインに設定されたオートシェイプを追加します
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```


### **Other Limitations of Aspose.Slides for PHP via Java API Compared to Aspose.Slides for Java API**

Aspose.Slides の名前空間とそれらが使用する Java クラスは、PhpJavaBridge が com.aspose.slides パッケージの同名 Java クラスの上に作成したラッパーです。

#### **1. Wrapping Java Parameters and Arguments**

返却および受け取るパラメータと引数は、同名の Java クラスの上にあるラッパーです。文字列と数値型のみが自動的に変換されます。配列、コレクション、バイト、およびブール値は変換されません。  

**A common mistake:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```


#### **2. Extending Java Class and Instanceof Operator**

PHP クラスから Java クラスを継承することはできません。回避策として、必要に応じてコンポジションを実装できます。instanceof 演算子は具体クラスに対してのみ機能し、インターフェイスや親クラスには機能しません。  

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. A Java Array Is NOT a PHP Array**

PHP での Java 配列作成:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```


#### **4. A Java Array Length**
``` php
$data->length; - does NOT work
```

workaround
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```


#### **5. The Java Method Files.readAllBytes**
``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```

workaround
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


#### **6. The Java Method Files.write**
``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
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
