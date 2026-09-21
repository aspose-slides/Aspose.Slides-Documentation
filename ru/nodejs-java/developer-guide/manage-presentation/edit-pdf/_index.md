---
title: "Редактировать PDF-документы на JavaScript"
linktitle: "Редактировать PDF"
type: docs
weight: 65
url: /ru/nodejs-java/edit-pdf/
keywords:
- "редактировать PDF"
- "заменить текст PDF"
- "PDF в PPTX"
- "PPTX в PDF"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Редактировать PDF-документы на JavaScript, импортируя их в Aspose.Slides, заменяя текст и сохраняя изменённую презентацию обратно в PDF."
---
## **Обзор**

Aspose.Slides for Node.js via Java позволяет редактировать содержимое PDF, импортируя его страницы в виде слайдов, изменяя презентацию и экспортируя её обратно в PDF. Эта статья демонстрирует простую замену текста. Презентация остаётся в памяти, поэтому сохранение промежуточного файла PPTX необязательно.

## **Замена текста в PDF**

Используйте [addFromPdf](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidecollection/#addFromPdf) для импорта страниц, [replaceText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#replaceText) для обновления текста и [save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save) для экспорта результата.

В следующем примере предполагается, что `input.pdf` содержит слово «Draft» как редактируемый текст после импорта. Оно заменяет это слово на «Final» и записывает `edited.pdf`. Очистка начального слайда перед импортом предотвращает появление лишней пустой страницы в результате. Поиск совпадает с целыми словами с учётом регистра; `null` означает, что обратный вызов результата не нужен.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Для получения дополнительных вариантов см. [Search and Replace Text](/slides/ru/nodejs-java/search-and-replace-text/) и [Convert PowerPoint to PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Замена текста работает с импортированным текстом, а не с текстом внутри отсканированных изображений. Конверсия может повлиять на макет и форматирование, поэтому проверьте результат, особенно если заменяемый текст длиннее оригинала.
{{% /alert %}}

## **FAQ**

**Нужно ли сохранять файл PPTX перед экспортом в PDF?**

Нет. Вы можете редактировать и экспортировать одну и ту же презентацию в памяти. Сохраните копию PPTX только если вы также хотите продолжать редактировать её в PowerPoint; см. [Save Presentations](/slides/ru/nodejs-java/save-presentation/).

**Почему некоторый текст может оставаться неизменным?**

В примере ищется полное слово «Draft» с точным регистром. Текст, импортированный как изображение, или разбитый на отдельные текстовые фреймы, может не совпадать с поиском. Проверьте импортированное содержимое и скорректируйте поиск для вашего документа.