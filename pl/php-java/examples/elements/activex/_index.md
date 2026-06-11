---
title: ActiveX
type: docs
weight: 200
url: /pl/php-java/examples/elements/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- dodaj ActiveX
- dostęp do ActiveX
- usuń ActiveX
- właściwości ActiveX
- przykłady kodu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak znajdować, edytować i usuwać kontrolki ActiveX w PHP z Aspose.Slides, w tym aktualizować właściwości w prezentacjach PowerPoint."
---
Pokazuje, jak dodać, uzyskać dostęp, usunąć i skonfigurować kontrolki ActiveX w prezentacji przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj kontrolkę ActiveX**

Wstaw nową kontrolkę ActiveX.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dodaj nową kontrolkę ActiveX.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Zwolnij prezentację.
        $presentation->dispose();
    }
}
```

## **Uzyskaj dostęp do kontrolki ActiveX**

Odczytaj informacje z pierwszej kontrolki ActiveX na slajdzie.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do pierwszej kontrolki ActiveX.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Zwolnij prezentację.
        $presentation->dispose();
    }
}
```

## **Usuń kontrolkę ActiveX**

Usuń istniejącą kontrolkę ActiveX ze slajdu.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Usuń pierwszą kontrolkę ActiveX.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Zwolnij prezentację.
        $presentation->dispose();
    }
}
```

## **Ustaw właściwości ActiveX**

Skonfiguruj kilka właściwości ActiveX.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwsza kontrolka jest tą, którą dodaliśmy.
        $control = $slide->getControls()->get_Item(0);

        // Skonfiguruj właściwości.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Zwolnij prezentację.
        $presentation->dispose();
    }
}
```