---
title: 제한 사항 및 API 차이점
type: docs
weight: 100
url: /ko/php-java/limitations-and-api-differences/
keywords:
- 제한 사항
- API 차이점
- 패키지 비교
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java와 Aspose.Slides for Java 간의 제한 사항 및 API 차이점을 비교합니다."
---
## **공용 API 차이점**

이 목록은 샘플 코드 조각을 사용하여 Aspose.Slides for Java와 Aspose.Slides for PHP via Java API 간의 특정 차이점을 보여줍니다.

### **라이브러리 가져오기 (패키지 비교)**

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

### **새 프레젠테이션 인스턴스화**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **열거형 또는 상수**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **예제**

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
        // 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
        Presentation pres = new Presentation();
        try
        {
            // 첫 번째 슬라이드를 가져옵니다
            ISlide slide = pres.getSlides().get_Item(0);

            // 라인으로 설정된 자동 도형을 추가합니다
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
    // 첫 번째 슬라이드를 가져옵니다
    $slide = $pres->getSlides()->get_Item(0);

    // 타입이 라인인 자동 도형을 추가합니다
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Aspose.Slides for PHP via Java API가 Aspose.Slides for Java API와 비교했을 때의 기타 제한 사항**

Aspose.Slides 네임스페이스와 그들이 사용하는 Java 클래스는 com.aspose.slides 패키지의 동일한 이름을 가진 Java 클래스를 기반으로 PhpJavaBridge가 만든 래퍼입니다.

#### **1. Java 매개변수 및 인수 래핑**

그들이 반환하고 수락하는 매개변수와 인수는 동일한 이름을 가진 Java 클래스 위에 래핑된 형태입니다. 문자열과 숫자형은 자동으로 변환되지만, 배열, 컬렉션, 바이트 및 불리언은 변환되지 않습니다.  

**일반적인 실수:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Java 클래스 상속 및 instanceof 연산자**

PHP 클래스에서 Java 클래스를 상속할 수 없습니다. 해결 방법으로 필요할 경우 컴포지션을 구현할 수 있습니다.  
instanceof 연산자는 구체적인 클래스에만 작동합니다. 클래스의 인터페이스나 부모 클래스에는 작동하지 않습니다.  

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Java 배열은 PHP 배열이 아닙니다**

PHP에서 Java 배열 생성:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. Java 배열 길이**

``` php
$data->length; - does NOT work
```
우회 방법
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. Java 메서드 Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
우회 방법
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

#### **6. Java 메서드 Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - does NOT work
```
우회 방법
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```