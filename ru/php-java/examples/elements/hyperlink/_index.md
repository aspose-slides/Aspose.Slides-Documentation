---
title: Гиперссылка
type: docs
weight: 130
url: /ru/php-java/examples/elements/hyperlink/
keywords:
- гиперссылка
- добавить гиперссылку
- доступ к гиперссылке
- удалить гиперссылку
- обновить гиперссылку
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Добавляйте, редактируйте и удаляйте гиперссылки в PHP с Aspose.Slides: текст ссылки, фигуры, слайды, URL и электронная почта; задавайте цели и действия для PPT, PPTX и ODP."
---
Продемонстрировано добавление, доступ, удаление и обновление гиперссылок на фигурах с использованием **Aspose.Slides for PHP via Java**.

## **Add a Hyperlink**
Создайте прямоугольную фигуру с гиперссылкой, указывающей на внешний веб‑сайт.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a Hyperlink**
Прочитайте информацию о гиперссылке из текстовой части фигуры.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая фигура содержит гиперссылку.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Hyperlink**
Очистите гиперссылку из текста фигуры.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая фигура содержит гиперссылку.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Update a Hyperlink**
Измените цель существующей гиперссылки. Используйте `HyperlinkManager` для изменения текста, уже содержащего гиперссылку, что имитирует безопасное обновление гиперссылок в PowerPoint.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая фигура содержит гиперссылку.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Изменение гиперссылки внутри существующего текста должно выполняться через
        // HyperlinkManager, а не прямое задание свойства.
        // Это имитирует то, как PowerPoint безопасно обновляет гиперссылки.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```