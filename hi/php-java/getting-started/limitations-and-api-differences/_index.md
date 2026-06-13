---
title: सीमाओं और API अंतर
type: docs
weight: 100
url: /hi/php-java/limitations-and-api-differences/
keywords:
- सीमा
- API अंतर
- पैकेज तुलना
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java और Aspose.Slides for Java के बीच सीमाओं और API अंतर की तुलना करें।"
---
## **सार्वजनिक API अंतर**

यह सूची, नमूना कोड अंशों का उपयोग करके, Aspose.Slides for Java और Aspose.Slides for PHP via Java API के बीच कुछ अंतर दर्शाती है।

### **लाइब्रेरी आयात (पैकेज तुलना)**

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

### **नए प्रेजेंटेशन का निर्माण**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **एनम्स या स्थिरांक**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **उदाहरण**

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
        // एक प्रस्तुति फ़ाइल को दर्शाने वाला Presentation ऑब्जेक्ट बनाता है
        Presentation pres = new Presentation();
        try
        {
            // पहली स्लाइड प्राप्त करता है
            ISlide slide = pres.getSlides().get_Item(0);

            // लाइन प्रकार के साथ एक ऑटोशेप जोड़ता है
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
    // पहली स्लाइड प्राप्त करता है
    $slide = $pres->getSlides()->get_Item(0);

    // लाइन प्रकार के साथ एक ऑटोशेप जोड़ता है
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Aspose.Slides for PHP via Java API की अन्य सीमाएँ, Aspose.Slides for Java API की तुलना में**

Aspose.Slides नेमस्पेस और वे Java क्लासेज जिन्हें वे उपयोग करते हैं, PhpJavaBridge द्वारा उनके समान नाम वाले Java क्लासेज (com.aspose.slides पैकेज) के ऊपर बनाए गए रैपर होते हैं।

#### **1. Java पैरामीटर और तर्कों को रैप करना**

वे पैरामीटर और तर्क जो वे लौटाते और स्वीकार करते हैं, समान नाम वाले Java क्लासेज के ऊपर बनाए गए रैपर होते हैं। केवल स्ट्रिंग्स और संख्यात्मक प्रकार स्वचालित रूप से परिवर्तित होते हैं। एरेज़, कलेक्शन, बाइट्स, और बूलियन्स परिवर्तित नहीं होते।  

**एक आम गलती:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Java क्लास को विस्तारित करना और instanceof ऑपरेटर**

आप PHP क्लास से Java क्लास को विस्तारित नहीं कर सकते। एक वैकल्पिक उपाय के रूप में, आवश्यक होने पर आप संरचना (composition) लागू कर सकते हैं।  
instanceof ऑपरेटर केवल ठोस क्लास के लिए काम करता है। यह क्लास के इंटरफ़ेस या पैरेंट क्लास के लिए कार्य नहीं करता।  

[workaround](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Java एरे PHP एरे नहीं है**

PHP में Java एरे निर्माण:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. Java एरे की लंबाई**

``` php
$data->length; - does NOT work
```
workaround
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. Java मेथड Files.readAllBytes**

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

#### **6. Java मेथड Files.write**

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