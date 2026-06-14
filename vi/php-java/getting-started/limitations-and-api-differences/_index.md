---
title: Hạn chế và khác biệt API
type: docs
weight: 100
url: /vi/php-java/limitations-and-api-differences/
keywords:
- hạn chế
- khác biệt API
- so sánh gói
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "So sánh các hạn chế và khác biệt API giữa Aspose.Slides for PHP thông qua Java và Aspose.Slides cho Java."
---
## **Khác biệt API công khai**

Danh sách này, sử dụng các đoạn mã mẫu, minh họa một số khác biệt giữa Aspose.Slides for Java và Aspose.Slides for PHP thông qua API Java.

### **Nhập thư viện (So sánh gói)**

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

### **Khởi tạo một bản thuyết trình mới**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **Enum hoặc Hằng số**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Ví dụ**

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
        // Khởi tạo một đối tượng Presentation đại diện cho tệp trình chiếu
        Presentation pres = new Presentation();
        try
        {
            // Lấy slide đầu tiên
            ISlide slide = pres.getSlides().get_Item(0);

            // Thêm một hình tự động với loại được đặt thành đường thẳng
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
    // Lấy slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);

    // Thêm một hình tự động với loại được đặt thành đường thẳng
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Các hạn chế khác của Aspose.Slides for PHP thông qua API Java so với Aspose.Slides for Java API**

Không gian tên Aspose.Slides và các lớp Java mà chúng sử dụng là các wrapper được tạo bởi PhpJavaBridge trên các lớp Java cùng tên trong gói com.aspose.slides.

#### **1. Đóng gói Tham số và Đối số Java**

Các tham số và đối số mà chúng trả về và nhận vào là các wrapper dựa trên các lớp Java có cùng tên. Chỉ các chuỗi và kiểu số được chuyển đổi tự động. Mảng, collection, byte và boolean không được chuyển đổi.  

**Một lỗi thường gặp:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Kế thừa Lớp Java và Toán tử instanceof**

Bạn không thể kế thừa một lớp Java từ một lớp PHP. Để khắc phục, bạn có thể áp dụng composition khi cần.  
Toán tử instanceof chỉ hoạt động với một lớp cụ thể. Nó không hoạt động với interface hoặc lớp cha của một lớp.  

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Mảng Java KHÔNG phải là Mảng PHP**

Tạo mảng Java trong PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. Độ dài của Mảng Java**

``` php
$data->length; - không hoạt động
```
cách khắc phục
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. Phương thức Java Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
cách khắc phục
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

#### **6. Phương thức Java Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
```
cách khắc phục
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```