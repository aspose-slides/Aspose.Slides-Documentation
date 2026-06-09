---
title: Μετατροπή Παρουσιάσεων σε HTML5 με PHP
linktitle: Παρουσίαση σε HTML5
type: docs
weight: 40
url: /el/php-java/export-to-html5/
keywords:
- PowerPoint σε HTML5
- OpenDocument σε HTML5
- παρουσίαση σε HTML5
- διαφάνεια σε HTML5
- PPT σε HTML5
- PPTX σε HTML5
- ODP σε HTML5
- αποθήκευση PPT ως HTML5
- αποθήκευση PPTX ως HTML5
- αποθήκευση ODP ως HTML5
- εξαγωγή PPT σε HTML5
- εξαγωγή PPTX σε HTML5
- εξαγωγή ODP σε HTML5
- PHP
- Aspose.Slides
description: "Εξαγωγή παρουσιάσεων PowerPoint & OpenDocument σε προσαρμοστικό HTML5 με Aspose.Slides για PHP μέσω Java. Διατήρηση μορφοποίησης, κινήσεων και διαδραστικότητας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να μετατρέψετε παρουσιάσεις PowerPoint σε HTML5 χρησιμοποιώντας το Aspose.Slides. Καλύπτει τη βασική εξαγωγή σε HTML5 χωρίς επεκτάσεις ιστού ή πρόσθετες εξαρτήσεις, καθώς και επιλογές ελέγχου των κινήσεων σχήματος και των μεταβάσεων διαφανειών. Το άρθρο δείχνει επίσης τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML, εξηγεί πώς να δημιουργήσετε έξοδο HTML5 σε λειτουργία προβολής διαφάνειας και παρουσιάζει πώς να συμπεριλάβετε σχόλια στο εξαγόμενο έγγραφο ρυθμίζοντας τη διάταξή τους.

## **Εξαγωγή PowerPoint σε HTML5**

Αυτός ο κώδικας PHP δείχνει πώς να εξάγετε μια παρουσίαση σε HTML5 χωρίς επεκτάσεις ιστού και εξαρτήσεις:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Σε αυτήν την περίπτωση, λαμβάνετε καθαρό HTML. 
{{% /alert %}}

Μπορείτε να θέσετε τις ρυθμίσεις για τις κινήσεις σχήματος και τις μεταβάσεις διαφανών με αυτόν τον τρόπο:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Εξαγωγή PowerPoint σε HTML**

Αυτό το Java δείχνει τη στάνταρ διαδικασία εξαγωγής PowerPoint σε HTML:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Σε αυτήν την περίπτωση, το περιεχόμενο της παρουσίασης αποδίδεται μέσω SVG με τη μορφή όπως παρακάτω:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="Note" color="warning" %}} 

When you use this method to export PowerPoint to HTML, due to the SVG rendering, you will not be to apply styles or animate specific elements. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** allows you to convert a PowerPoint presentation to an HTML5 document in which the slides are presented in a slide view mode. In this case, when you open the resulting HTML5 file in a browser, you see the presentation in slide view mode on a web page. 

This PHP code demonstrates the PowerPoint to HTML5 Slide View export process:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convert Presentations to HTML5 Documents with Comments**

Comments in PowerPoint are a tool that allows users to leave notes or feedback on presentation slides. They are especially useful in collaborative projects, where multiple people can add their suggestions or remarks to specific slide elements without altering the main content. Each comment shows the author's name, making it easy to track who left the remark.

Let's say we have the following PowerPoint presentation saved in the "sample.pptx" file.

![Two comments on the presentation slide](two_comments_pptx.png)

When you convert a PowerPoint presentation to an HTML5 document, you can easily specify whether to include comments from the presentation in the output document. To do this, you need to specify the display parameters for comments in the `getNotesCommentsLayouting` method of the `Html5Options` class.

The following code example converts a presentation to an HTML5 document with comments displayed to the right of the slides.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```

Το έγγραφο "output.html" εμφανίζεται στην παρακάτω εικόνα.

![Τα σχόλια στο εξαγόμενο έγγραφο HTML5](two_comments_html5.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω αν οι κινήσεις αντικειμένων και οι μεταβάσεις διαφανειών θα αναπαράγονται σε HTML5;**

Ναι, το HTML5 παρέχει ξεχωριστές επιλογές για την ενεργοποίηση ή απενεργοποίηση των [κινήσεων σχήματος](https://reference.aspose.com/slides/el/php-java/aspose.slides/html5options/setanimateshapes/) και των [μεταβάσεων διαφανειών](https://reference.aspose.com/slides/el/php-java/aspose.slides/html5options/setanimatetransitions/).

**Υποστηρίζεται η εξαγωγή σχολίων και πού μπορούν να τοποθετηθούν σε σχέση με τη διαφάνεια;**

Ναι, μπορούν να προστεθούν σχόλια σε HTML5 και να τοποθετηθούν (π.χ. δεξιά της διαφάνειας) μέσω των [ρυθμίσεων διάταξης](https://reference.aspose.com/slides/el/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) για σημειώσεις και σχόλια.

**Μπορώ να παραλείψω συνδέσμους που καλούν JavaScript για λόγους ασφαλείας ή CSP;**

Ναι, υπάρχει μια [ρύθμιση](https://reference.aspose.com/slides/el/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) που σας επιτρέπει να παραλείψετε συνδέσμους με κλήσεις JavaScript κατά την αποθήκευση. Αυτό βοηθά στη συμμόρφωση με αυστηρές πολιτικές ασφαλείας.