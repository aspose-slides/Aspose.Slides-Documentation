---
title: ActiveX
type: docs
weight: 200
url: /ru/php-java/examples/elements/activex/
keywords:
- ActiveX
- элемент управления ActiveX
- добавить ActiveX
- получить доступ к ActiveX
- удалить ActiveX
- свойства ActiveX
- примеры кода
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как находить, редактировать и удалять элементы управления ActiveX в PHP с помощью Aspose.Slides, включая обновление свойств для презентаций PowerPoint."
---
Показывает, как добавлять, получать доступ, удалять и настраивать элементы управления ActiveX в презентации с использованием **Aspose.Slides for PHP via Java**.

## **Add an ActiveX Control**
Вставьте новый элемент управления ActiveX.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Добавить новый элемент управления ActiveX.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Освободить презентацию.
        $presentation->dispose();
    }
}
```

## **Access an ActiveX Control**
Прочитайте информацию о первом элементе управления ActiveX на слайде.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Получить доступ к первому элементу управления ActiveX.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Освободить презентацию.
        $presentation->dispose();
    }
}
```

## **Remove an ActiveX Control**
Удалите существующий элемент управления ActiveX со слайда.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Удалить первый элемент управления ActiveX.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Освободить презентацию.
        $presentation->dispose();
    }
}
```

## **Set ActiveX Properties**
Настройте несколько свойств ActiveX.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первый элемент управления — тот, который мы добавили.
        $control = $slide->getControls()->get_Item(0);

        // Настроить свойства.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Освободить презентацию.
        $presentation->dispose();
    }
}
```