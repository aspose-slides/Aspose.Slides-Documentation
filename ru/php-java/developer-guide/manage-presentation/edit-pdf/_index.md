---
title: Редактирование PDF-документов в PHP
linktitle: Редактировать PDF
type: docs
weight: 65
url: /ru/php-java/edit-pdf/
keywords:
- редактировать PDF
- заменить текст PDF
- PDF в PPTX
- PPTX в PDF
- PHP
- Aspose.Slides
description: "Редактируйте PDF-документы в PHP, импортируя их в Aspose.Slides, заменяя текст и сохраняя изменённую презентацию обратно в PDF."
---
## **Обзор**

Aspose.Slides for PHP via Java позволяет редактировать содержимое PDF, импортируя его страницы как слайды, изменяя презентацию и экспортируя её обратно в PDF. В этой статье показана простая замена текста. Презентация остаётся в памяти, поэтому сохранение промежуточного файла PPTX необязательно.

## **Замена текста в PDF**

Используйте [SlideCollection::addFromPdf](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidecollection/#addFromPdf) для импорта страниц, [Presentation::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#replaceText) для обновления текста и [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save) для экспорта результата.

Следующий пример ожидает, что `input.pdf` содержит слово «Draft» как редактируемый текст после импорта. Он заменяет это слово на «Final» и записывает `edited.pdf`. Очистка начального слайда перед импортом предотвращает появление лишней пустой страницы в выводе. Поиск совпадает с полными словами с учётом регистра; `null` означает, что обратный вызов результата не нужен.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

Для дополнительных вариантов см. [Search and Replace Text](/slides/ru/php-java/search-and-replace-text/) и [Convert PowerPoint to PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Замена текста работает с импортированным текстом, а не с текстом внутри отсканированных изображений. Конверсия может изменить макет и форматирование, поэтому проверьте результат, особенно если заменяемый текст длиннее оригинального.
{{% /alert %}}

## **Вопросы и ответы**

**Нужно ли сохранять файл PPTX перед экспортом в PDF?**

Нет. Вы можете редактировать и экспортировать одну и ту же презентацию в памяти. Сохраняйте копию PPTX только если хотите продолжить её редактирование в PowerPoint; см. [Save Presentations](/slides/ru/php-java/save-presentation/).

**Почему часть текста может остаться неизменной?**

В примере ищется полное слово «Draft» с точным регистром. Текст, импортированный как изображение, или разбитый на отдельные текстовые кадры, может не соответствовать поиску. Проверьте импортированное содержимое и скорректируйте поиск под ваш документ.