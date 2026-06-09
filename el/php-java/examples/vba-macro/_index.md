---
title: Μακροεντολή VBA
type: docs
weight: 150
url: /el/php-java/examples/elements/vba-macro/
keywords:
- μακροεντολή vba
- προσθήκη μακροεντολής vba
- πρόσβαση σε μακροεντολή vba
- διαγραφή μακροεντολής vba
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δουλέψτε με μακροεντολές VBA σε PHP χρησιμοποιώντας το Aspose.Slides: προσθέστε ή επεξεργαστείτε έργα και μονάδες, υπογράψτε ή αφαιρέστε μακροεντολές και αποθηκεύστε παρουσιάσεις σε PPT, PPTX και ODP."
---
Εικονογραφεί πώς να προσθέσετε, να προσπελάσετε και να καταργήσετε μακροεντολές VBA χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη μακροεντολής VBA**

Δημιουργήστε μια παρουσίαση με ένα έργο VBA και μια απλή μονάδα μακροεντολών.

```php
function addVbaMacro() {
    $presentation = new Presentation();
    try {
        $presentation->setVbaProject(new VbaProject());

        $module = $presentation->getVbaProject()->getModules()->addEmptyModule("Module");
        $module->setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        $presentation->save("vba_macro.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε μακροεντολή VBA**

Ανακτήστε την πρώτη μονάδα από το έργο VBA.

```php
function accessVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        $firstModule = $presentation->getVbaProject()->getModules()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Κατάργηση μακροεντολής VBA**

Διαγράψτε μια μονάδα από το έργο VBA.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Υποθέτοντας ότι υπάρχει τουλάχιστον μία μονάδα στο έργο VBA.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```