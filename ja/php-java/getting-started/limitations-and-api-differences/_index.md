---
title: 制限とAPIの違い
type: docs
weight: 100
url: /php-java/limitations-and-api-differences/
---


## **公開APIの違い**

このリストは、サンプルコードセグメントを使用して、Aspose.Slides for JavaとAspose.Slides for PHP via Java APIの間の特定の違いを示しています。

### **ライブラリのインポート（パッケージの比較）**

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

### **新しいプレゼンテーションのインスタンス化**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **列挙型または定数**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **例**

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
        // プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化する
        Presentation pres = new Presentation();
        try
        {
            // 最初のスライドを取得する
            ISlide slide = pres.getSlides().get_Item(0);

            // タイプをラインとしてオートシェイプを追加する
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
    // 最初のスライドを取得する
    $slide = $pres->getSlides()->get_Item(0);

    // タイプをラインとしてオートシェイプを追加する
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Aspose.Slides for PHP via Java APIの他の制限（Aspose.Slides for Java APIに対して）**

Aspose.Slidesの名前空間とそれが使用するjavaクラスは、com.aspose.slidesパッケージの同名のJavaクラスの上にPhpJavaBridgeによって作成されたラッパーです。

#### 1. **Javaパラメーターと引数のラッピング**

返却されるパラメーターと引数は、同名のJavaクラスの上に重ねられたラッパーです。文字列と数値型のみが自動的に変換されます。配列、コレクション、バイト、ブール値は変換されません。  

**一般的な間違い:**
``` php
if ($node->isAssistant()) - 誤り！
if (java_values($node->isAssistant())) - 正しい！
```

#### 2. **Javaクラスの拡張とinstanceof演算子**

PHPクラスからJavaクラスを拡張することはできません。必要に応じて、コンポジションを実装することで回避できます。
instanceof演算子は具体的なクラスに対してのみ機能します。クラスのインターフェースや親クラスには機能しません。 

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### 3. **Java配列はPHP配列ではない**

PHPにおけるJava配列の作成:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### 4. **Java配列の長さ**

``` php
$data->length; - 動作しない
```
回避策
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### 5. **JavaメソッドFiles.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - 動作しない
```
回避策
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

#### 6. **JavaメソッドFiles.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - 動作しない
```
回避策
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```