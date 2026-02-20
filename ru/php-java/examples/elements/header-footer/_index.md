---
title: "Заголовок и нижний колонтитул"
type: docs
weight: 220
url: /ru/php-java/examples/elements/header-footer/
keywords:
- "заголовок и нижний колонтитул"
- "добавить заголовок и нижний колонтитул"
- "обновить заголовок и нижний колонтитул"
- "примеры кода"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "PHP"
- "Aspose.Slides"
description: "Контролируйте заголовки и нижние колонтитулы в PHP с Aspose.Slides: добавляйте или редактируйте дату/время, номера слайдов и текст нижнего колонтитула, показывайте или скрывайте заполнители в PPT, PPTX и ODP."
---
Показывает, как добавить нижние колонтитулы и обновить заполнители даты и времени с использованием **Aspose.Slides for PHP via Java**.

## **Добавить нижний колонтитул**

Добавьте текст в область нижнего колонтитула слайда и сделайте его видимым.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Обновить дату и время**

Измените заполнитель даты и времени на слайде.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```