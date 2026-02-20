---
title: VbaMakro
type: docs
weight: 150
url: /de/php-java/examples/elements/vba-macro/
keywords:
- VBA-Makro
- VBA-Makro hinzufügen
- Zugriff auf VBA-Makro
- VBA-Makro entfernen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Arbeiten Sie mit VBA-Makros in PHP unter Verwendung von Aspose.Slides: Projekte und Module hinzufügen oder bearbeiten, Makros signieren oder entfernen und Präsentationen in PPT, PPTX und ODP speichern."
---
Veranschaulicht, wie VBA-Makros mit **Aspose.Slides for PHP via Java** hinzugefügt, zugegriffen und entfernt werden.

## **VBA-Makro hinzufügen**

Erstellen Sie eine Präsentation mit einem VBA-Projekt und einem einfachen Makro-Modul.

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

## **Zugriff auf ein VBA-Makro**

Rufen Sie das erste Modul aus dem VBA-Projekt ab.

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

## **VBA-Makro entfernen**

Löschen Sie ein Modul aus dem VBA-Projekt.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Angenommen, es gibt mindestens ein Modul im VBA-Projekt.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```