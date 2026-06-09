---
title: Ενότητα
type: docs
weight: 90
url: /el/php-java/examples/elements/section/
keywords:
- ενότητα
- ενότητα διαφάνειας
- προσθήκη ενότητας
- πρόσβαση σε ενότητα
- αφαίρεση ενότητας
- μετονομασία ενότητας
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε τις ενότητες διαφανειών σε PHP με το Aspose.Slides: δημιουργήστε, μετονομάστε, αναδιατάξτε εύκολα, μετακινήστε διαφάνειες μεταξύ ενοτήτων και ελέγξτε την ορατότητα για PPT, PPTX και ODP."
---
Παραδείγματα διαχείρισης ενοτήτων παρουσίασης—προσθήκη, πρόσβαση, διαγραφή και μετονομασία προγραμματιστικά χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη ενότητας**

Δημιουργήστε μια ενότητα που ξεκινά σε μια συγκεκριμένη διαφάνεια.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Καθορίστε τη διαφάνεια που σηματοδοτεί την αρχή της ενότητας.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε ενότητα**

Ανάγνωση πληροφοριών ενότητας από μια παρουσίαση.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Πρόσβαση σε ενότητα με δείκτη.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση ενότητας**

Διαγραφή μιας προηγουμένως προστιθέμενης ενότητας.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Αφαίρεση της ενότητας.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Μετονομασία ενότητας**

Αλλαγή του ονόματος μιας υπάρχουσας ενότητας.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```