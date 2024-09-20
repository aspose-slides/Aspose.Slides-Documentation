---
title: Ограничения и различия API
type: docs
weight: 100
url: /php-java/limitations-and-api-differences/
---

## **Различия в публичном API**

Этот список, используя примеры кода, демонстрирует некоторые различия между Aspose.Slides для Java и Aspose.Slides для PHP через Java API.

### **Импорт библиотеки (Сравнение пакетов)**

**Aspose.Slides для Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides для PHP через Java**

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\sldes;
use aspose\sldes\Presentation;
```

### **Создание новой Презентации**

**Aspose.Slides для Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides для PHP через Java**

```php
$presentation = new Presentation();
```

### **Enums или Константы**

**Aspose.Slides для Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides для PHP через Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Пример**

**Aspose.Slides для Java**

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

public class Test
{
    public static void main(String[] args) throws Exception
    {
        // Создает объект Presentation, представляющий файл презентации
        Presentation pres = new Presentation();
        try
        {
            // Получает первый слайд
            ISlide slide = pres.getSlides().get_Item(0);

            // Добавляет автозакрашенный объект типа линия
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

**Aspose.Slides для PHP через Java**

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
    // Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);

    // Добавляет автозакрашенный объект типа линия
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Другие ограничения Aspose.Slides для PHP через Java API по сравнению с Aspose.Slides для Java API**

Пространства имен Aspose.Slides и классы Java, которые они используют, являются оболочками, созданными PhpJavaBridge поверх классов Java с теми же именами из пакета com.aspose.slides.

#### 1. **Оборачивание java параметров и аргументов**

Параметры и аргументы, которые они возвращают и принимают, являются оболочками над классами Java с теми же именами. Только строки и числовые типы автоматически конвертируются. Массивы, коллекции, байты и логические значения не Конвертируются.

**Распространенная ошибка:**
``` php
if ($node->isAssistant()) - неверно!
if (java_values($node->isAssistant())) - верно!
```

#### 2. **Расширение класса Java и оператор instanceof**

Вы не можете расширять класс Java из PHP класса. В качестве обходного пути вы можете реализовать композицию, когда это необходимо. Оператор instanceof работает только для конкретного класса. Он не работает для интерфейса класса или родительского класса.

[обходной путь](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### 3. **Массив Java не является массивом PHP**

Создание массива Java в PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### 4. **Длина массива Java**

``` php
$data->length; - не работает
```
обходной путь
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### 5. **Метод Java Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - не работает
```
обходной путь
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

#### 6. **Метод Java Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - не работает
```
обходной путь
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```