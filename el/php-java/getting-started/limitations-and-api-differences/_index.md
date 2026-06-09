---
title: Περιορισμοί και Διαφορές API
type: docs
weight: 100
url: /el/php-java/limitations-and-api-differences/
keywords:
- περιορισμός
- διαφορές API
- σύγκριση πακέτων
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Συγκρίνετε τους περιορισμούς και τις διαφορές του API μεταξύ Aspose.Slides για PHP μέσω Java και Aspose.Slides για Java."
---
## **Διαφορές Δημόσιου API**

Αυτή η λίστα, χρησιμοποιώντας δείγματα κώδικα, παρουσιάζει ορισμένες διαφορές μεταξύ του Aspose.Slides for Java και του Aspose.Slides for PHP μέσω των Java APIs.

### **Εισαγωγή βιβλιοθήκης (Συγκρίσεις Πακέτων)**

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

### **Δημιουργία νέας Παρουσίασης**

**Aspose.Slides for Java**

```java
Presentation presentation = new Presentation();
```

**Aspose.Slides for PHP via Java**

```php
$presentation = new Presentation();
```

### **Απαριθμήσεις ή Σταθερές**

**Aspose.Slides for Java**

```java
arc2.getLineFormat().setDashStyle(MsoLineDashStyle.SOLID);
```

**Aspose.Slides for PHP via Java**

```php
$arc2->getLineFormat()->setDashStyle(slides\MsoLineDashStyle::SOLID);
```

### **Παράδειγμα**

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
        // Δημιουργεί ένα αντικείμενο Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης
        Presentation pres = new Presentation();
        try
        {
            // Παίρνει την πρώτη διαφάνεια
            ISlide slide = pres.getSlides().get_Item(0);

            // Προσθέτει ένα αυτόματο σχήμα με τύπο γραμμή
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
    // Παίρνει την πρώτη διαφάνεια
    $slide = $pres->getSlides()->get_Item(0);

    // Προσθέτει ένα αυτόματο σχήμα με τύπο γραμμή
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
}
finally
{
    if (!java_is_null($pres)) $pres->dispose();
}
?>
```

### **Άλλοι περιορισμοί του Aspose.Slides for PHP μέσω Java API σε σύγκριση με το Aspose.Slides for Java API**

Οι χώροι ονομάτων Aspose.Slides και οι κλάσεις Java που χρησιμοποιούν είναι περιβλήματα που δημιουργήθηκαν από το PhpJavaBridge πάνω στις κλάσεις Java με το ίδιο όνομα από το πακέτο com.aspose.slides.

#### **1. Περιτύλιγμα Παραμέτρων και Ορισμάτων Java**

Οι παράμετροι και τα ορίσματα που επιστρέφουν και δέχονται είναι περιβλήματα πάνω στις κλάσεις Java με τα ίδια ονόματα. Μόνο οι συμβολοσειρές και οι αριθμητικοί τύποι μετατρέπονται αυτόματα. Πίνακες, συλλογές, bytes και booleans δεν μετατρέπονται.

**Ένα συνηθισμένο λάθος:**
``` php
if ($node->isAssistant()) - wrong!
if (java_values($node->isAssistant())) - correct!
```

#### **2. Επέκταση Κλάσης Java και Τελεστής instanceof**

Δεν μπορείτε να επεκτείνετε μια κλάση Java από κλάση PHP. Ως παρακάμψη, μπορείτε να εφαρμόσετε σύνθεση όταν χρειάζεται.
Ο τελεστής instanceof λειτουργεί μόνο για μια συγκεκριμένη κλάση. Δεν λειτουργεί για την διεπαφή ή την γονική κλάση μιας κλάσης.

[παράκαμψη](https://stackoverflow.com/questions/36840618/php-java-bridge-usage-of-extend)

#### **3. Μία Java Array ΔΕΝ είναι PHP Array**

Δημιουργία Java array σε PHP:
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Integer = new JavaClass("java.lang.Integer");
$IntegerArray = $Array->newInstance($Integer, 2);
$IntegerArray[0] = 1;
$IntegerArray[1] = 0;
```

#### **4. Μήκος μιας Java Array**

``` php
$data->length; - does NOT work
```
παράκαμψη
``` php
$Array = new JavaClass("java.lang.reflect.Array");
$Array->getLength($data);
```

#### **5. Η μέθοδος Java Files.readAllBytes**

``` php
$htmlBytes = Files->readAllBytes(Paths->get("embedOle.html")); - does NOT work
```
παράκαμψη
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

#### **6. Η μέθοδος Java Files.write**

``` php
Files->write(new File($path)->toPath(), $fontData, StandardOpenOption::CREATE); - δεν λειτουργεί
```
παράκαμψη
``` php
$fstr = new Java("java.io.FileOutputStream", $path);
$Array = new java_class("java.lang.reflect.Array");
try {
    $fstr->write($fontData, 0, $Array->getLength($fontData));
} finally {
	$fstr->close();
}
```