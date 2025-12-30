---
title: Ограничения и различия API
type: docs
weight: 100
url: /ru/php-java/limitations-and-api-differences/
keywords:
- ограничение
- различия API
- сравнение пакетов
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Сравните ограничения и различия API между Aspose.Slides для PHP через Java и Aspose.Slides для Java."
---

## **Отличия публичного API**

Этот список, используя примеры кода, демонстрирует определённые различия между Aspose.Slides для Java и Aspose.Slides для PHP через Java API.

### **Импорт библиотеки (Сравнение пакетов)**

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


### **Создание новой презентации**

**Aspose.Slides for Java**
```java
Presentation presentation = new Presentation();
```


**Aspose.Slides for PHP via Java**
```php
$presentation = new Presentation();
```


### **Перечисления или константы**

**Aspose.Slides for Java**
```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```


**Aspose.Slides for PHP via Java**
```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```


### **Пример**

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
        // Создаёт объект Presentation, представляющий файл презентации
        Presentation pres = new Presentation();
        try
        {
            // Получает первый слайд
            ISlide slide = pres.getSlides().get_Item(0);

            // Добавляет автофигуру типа линия
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
    // Получает первый слайд
    $slide = $pres->getSlides()->get_Item(0);

    // Добавляет автофигуру типа линия
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

Пространства имён Aspose.Slides и используемые ими классы Java являются оболочками, созданными PhpJavaBridge поверх Java‑классов с тем же именем из пакета com.aspose.slides.

#### **1. Обёртка параметров и аргументов Java**

Параметры и аргументы, которые они возвращают и принимают, являются обёртками поверх Java‑классов с теми же именами. Автоматически преобразуются только строки и числовые типы. Массивы, коллекции, байты и логические типы не преобразуются.  

**Распространённая ошибка:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```


#### **2. Наследование Java‑класса и оператор instanceof**

Нельзя наследовать Java‑класс от PHP‑класса. В качестве обходного решения можно использовать композицию при необходимости. Оператор instanceof работает только с конкретным классом. Он не работает с интерфейсом класса или его базовым классом. 

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Java‑массив НЕ является PHP‑массивом**

Создание Java‑массива в PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```


#### **4. Длина Java‑массива**
``` php
$data->length; - does NOT work
```

workaround
```php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```


#### **5. Метод Java Files.readAllBytes**
```php
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


#### **6. Метод Java Files.write**
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
