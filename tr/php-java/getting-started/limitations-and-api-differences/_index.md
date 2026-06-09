---
title: Kısıtlamalar ve API Farklılıkları
type: docs
weight: 100
url: /tr/php-java/limitations-and-api-differences/
keywords:
- kısıtlama
- API farklılıkları
- paket karşılaştırması
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile Aspose.Slides for Java arasındaki kısıtlamaları ve API farklılıklarını karşılaştırın."
---
## **Genel API Farklılıkları**

Bu liste, örnek kod bölümlerini kullanarak Aspose.Slides for Java ile Aspose.Slides for PHP via Java API'leri arasındaki belirli farklılıkları göstermektedir.

### **Kütüphane İçe Aktarma (Paket Karşılaştırmaları)**

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

### **Yeni Sunum Oluşturma**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **Enum'lar veya Sabitler**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Örnek**

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
        // Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
        Presentation pres = new Presentation();
        try
        {
            // İlk slaytı alır
            ISlide slide = pres.getSlides().get_Item(0);

            // Tipi çizgi olarak ayarlanmış bir otomatik şekil ekler
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
    // İlk slaytı alır
    $slide = $pres->getSlides()->get_Item(0);

    // Tipi çizgi olarak ayarlanmış bir otomatik şekil ekler
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Aspose.Slides for PHP via Java API'nin Aspose.Slides for Java API'ye Göre Diğer Kısıtlamaları**

Aspose.Slides ad alanları ve kullandıkları java sınıfları, com.aspose.slides paketindeki aynı isimli Java sınıfları üzerine PhpJavaBridge tarafından oluşturulan sarmalayıcılardır.

#### **1. Java Parametrelerinin ve Argümanlarının Sarılması**

Geri döndürdükleri ve kabul ettikleri parametre ve argümanlar aynı ada sahip Java sınıfları üzerine sarmalayıcılardır. Yalnızca string ve sayısal tipler otomatik olarak **dönüştürülür**. Diziler, koleksiyonlar, baytlar ve boolean değerler **dönüştürülmez**.  

**Yaygın bir hata:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Java Sınıfını Uzatma ve instanceof Operatörü**

Bir PHP sınıfından bir Java sınıfını genişletemezsiniz. Bir çözüm olarak, gerektiğinde bileşim (composition) uygulayabilirsiniz.
instanceof operatörü yalnızca somut bir sınıf için çalışır. Bir sınıfın arabirimi veya üst sınıfı için çalışmaz. 

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Java Dizisi PHP Dizisi DEĞİLDİR**

PHP içinde Java dizisi oluşturma:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. Java Dizi Uzunluğu**

``` php
$data->length; - does NOT work
```
workaround
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. Java Metodu Files.readAllBytes**

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

#### **6. Java Metodu Files.write**

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