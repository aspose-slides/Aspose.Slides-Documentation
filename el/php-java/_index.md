---
title: Aspose.Slides για PHP μέσω Java
second_title: Aspose.Slides για PHP
type: docs
weight: 45
url: /el/php-java/
keywords:
- τεκμηρίωση
- επεξεργασία παρουσίασης
- μετατροπή παρουσίασης
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Ξεκινήστε εδώ: εγκαταστήστε το Aspose.Slides για PHP μέσω Java, δημιουργήστε την πρώτη παρουσίαση και βρείτε τους οδηγούς για τις συνήθεις εργασίες, την αναφορά API και την υποστήριξη."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Το Aspose.Slides for PHP via Java είναι μια βιβλιοθήκη κλάσεων για δημιουργία, ανάγνωση, επεξεργασία και μετατροπή παρουσιάσεων PowerPoint και OpenDocument σε εφαρμογές PHP, χωρίς το Microsoft PowerPoint ή την Office Automation.

Φορτώνει και αποθηκεύει αρχεία PPT, PPTX, PPS, POT και ODP, συμπεριλαμβανομένων των εκδόσεων με μακροεντολές και προτύπων, και εξάγει σε PDF, XPS, HTML, SVG, TIFF, Markdown και εικόνες.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Ξεκινήστε</b></p>
<hr>
<p>ΞΕΚΙΝΗΣΗ</p>
<ul>
<li><a href="/slides/el/php-java/installation/">Εγκατάσταση</a></li>
<li><a href="/slides/el/php-java/create-presentation/">Δημιουργία της πρώτης σας παρουσίασης</a></li>
<li><a href="/slides/el/php-java/getting-started/">Οδηγός εκκίνησης</a></li>
</ul>
<p>ΑΞΙΟΛΟΓΗΣΗ</p>
<ul>
<li><a href="/slides/el/php-java/supported-file-formats/">Υποστηριζόμενες μορφές αρχείων</a></li>
<li><a href="/slides/el/php-java/evaluate-aspose-slides/">Περιορισμοί δοκιμής</a></li>
<li><a href="/slides/el/php-java/licensing/">Αδειοδότηση</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Κατασκευή με Slides</b></p>
<hr>
<p>ΚΑΝΟΝΙΚΕΣ ΕΡΓΑΣΙΕΣ</p>
<ul>
<li><a href="/slides/el/php-java/open-presentation/">Άνοιγμα παρουσίασης</a></li>
<li><a href="/slides/el/php-java/save-presentation/">Αποθήκευση παρουσίασης</a></li>
<li><a href="/slides/el/php-java/convert-powerpoint-to-pdf/">Μετατροπή σε PDF</a></li>
<li><a href="/slides/el/php-java/convert-slide/">Απόδοση διαφανειών ως εικόνες</a></li>
<li><a href="/slides/el/php-java/manage-text/">Επεξεργασία κειμένου και σχημάτων</a></li>
</ul>
<p>ΡΟές ΕΡΓΑΣΙΩΝ SLIDES</p>
<ul>
<li><a href="/slides/el/php-java/powerpoint-charts/">Διαγράμματα</a></li>
<li><a href="/slides/el/php-java/powerpoint-animation/">Κινούμενα σχέδια</a></li>
<li><a href="/slides/el/php-java/manage-media-files/">Ήχος και βίντεο</a></li>
<li><a href="/slides/el/php-java/presentation-design/">Σχεδίαση διαφάνειας</a></li>
<li><a href="/slides/el/php-java/merge-presentation/">Συγχώνευση παρουσιάσεων</a></li>
</ul>
<p>ΠΑΡΑΔΕΙΓΜΑΤΑ</p>
<ul>
<li><a href="/slides/el/php-java/examples/">Παραδείγματα ανά στοιχείο διαφάνειας</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Αναφορά &amp; Υποστήριξη</b></p>
<hr>
<p>ΑΝΑΦΟΡΑ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">Καθορισμός API</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Σημειώσεις έκδοσης</a></li>
<li><a href="/slides/el/php-java/known-issues/">Γνωστά ζητήματα</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Λήψη</a></li>
</ul>
<p>ΥΠΟΣΤΗΡΙΞΗ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Δωρεάν φόρουμ υποστήριξης</a></li>
<li><a href="https://helpdesk.aspose.com/">Πληρωμένη υποστήριξη μέσω helpdesk</a></li>
</ul>
</div>
</div>

------

## **Η πρώτη σας παρουσίαση**

Το Aspose.Slides for PHP via Java εκτελείται σε Java μέσα σε Apache Tomcat, και τα σενάρια PHP σας το προσεγγίζουν μέσω του PHP/Java Bridge. [Installation](/slides/el/php-java/installation/) ρυθμίζει το PHP 8.3 ή παλαιότερο, τη Java, τον Tomcat και τη γέφυρα, και στη συνέχεια εγκαθιστά το πακέτο από το Packagist σε φάκελο έργου:

```bash
composer require aspose/slides
```

Στη συνέχεια αντιγράψτε το αρχείο JAR του πακέτου στη γέφυρα και επανεκκινήστε τον Tomcat, όπως στο βήμα 4 του [Install on Linux](/slides/el/php-java/installation/#install-on-linux) ή στο βήμα 6 του [Install on Windows](/slides/el/php-java/installation/#install-on-windows). Με τον Tomcat σε λειτουργία, αποθηκεύστε αυτό το σενάριο ως *hello.php* στον φάκελο έργου και εκτελέστε `php hello.php`:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/el/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Το script αποθηκεύει *hello.pptx* δίπλα του, με μία διαφάνεια που περιέχει ένα πλαίσιο κειμένου. Χωρίς άδεια, το αποθηκευμένο αρχείο φέρει υδατογράφημα αξιολόγησης — δείτε [Licensing](/slides/el/php-java/licensing/). Για περισσότερους τρόπους δημιουργίας και συμπλήρωσης μιας παρουσίασης, δείτε [Create Presentations](/slides/el/php-java/create-presentation/).