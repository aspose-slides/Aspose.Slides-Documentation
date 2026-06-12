---
title: Batasan dan Perbedaan API
type: docs
weight: 100
url: /id/php-java/limitations-and-api-differences/
keywords:
- keterbatasan
- perbedaan API
- perbandingan paket
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Bandingkan batasan dan perbedaan API antara Aspose.Slides untuk PHP via Java dan Aspose.Slides untuk Java."
---
## **Perbedaan API Publik**

Daftar ini, menggunakan segmen kode contoh, menunjukkan beberapa perbedaan antara Aspose.Slides untuk Java dan Aspose.Slides untuk PHP via API Java.

### **Mengimpor pustaka (Perbandingan Paket)**

**Aspose.Slides untuk Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides untuk PHP via Java**

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\sldes;
use aspose\sldes\Presentation;
```

### **Membuat Presentasi Baru**

**Aspose.Slides untuk Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides untuk PHP via Java**

```php
$presentation = new Presentation();
```

### **Enum atau Konstanta**

**Aspose.Slides untuk Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides untuk PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Contoh**

**Aspose.Slides untuk Java**

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

public class Test
{
    public static void main(String[] args) throws Exception
    {
        // Membuat objek Presentation yang mewakili file presentasi
        Presentation pres = new Presentation();
        try
        {
            // Mendapatkan slide pertama
            ISlide slide = pres.getSlides().get_Item(0);

            // Menambahkan autoshape dengan tipe garis
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

**Aspose.Slides untuk PHP via Java**

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
    // Mendapatkan slide pertama
    $slide = $pres->getSlides()->get_Item(0);

    // Menambahkan autoshape dengan tipe garis
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Keterbatasan Lain dari Aspose.Slides untuk PHP via API Java dibandingkan dengan Aspose.Slides untuk API Java**

Namespace Aspose.Slides dan kelas java yang mereka gunakan adalah pembungkus yang dibuat oleh PhpJavaBridge di atas kelas Java dengan nama yang sama dari paket com.aspose.slides.

#### **1. Membungkus Parameter dan Argumen Java**

Parameter dan argumen yang mereka kembalikan dan terima merupakan pembungkus di atas kelas Java dengan nama yang sama. Hanya string dan tipe numerik yang dikonversi secara otomatis. Array, koleksi, byte, dan boolean tidak dikonversi.  

**Kesalahan umum:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Memperluas Kelas Java dan Operator Instanceof**

Anda tidak dapat memperluas kelas Java dari kelas PHP. Sebagai solusi, Anda dapat menerapkan komposisi bila diperlukan.  
Operator instanceof hanya berfungsi untuk kelas konkret. Ia tidak berfungsi untuk antarmuka atau kelas induk suatu kelas.  

[solusi](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Array Java BUKAN Array PHP**

Pembuatan array Java di PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. Panjang Array Java**

``` php
$data->length; - tidak berfungsi
```
solusi
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. Metode Java Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
solusi
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

#### **6. Metode Java Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
```
solusi
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```