---
title: Конвертировать презентации PowerPoint в HTML в Node.js
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/nodejs-java/convert-powerpoint-to-html/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в HTML
- презентацию в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- сохранить PowerPoint как HTML
- сохранить презентацию как HTML
- сохранить слайд как HTML
- сохранить PPT как HTML
- сохранить PPTX как HTML
- экспортировать PPT в HTML
- экспортировать PPTX в HTML
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в HTML в Node.js. Используйте Aspose.Slides for Node.js via Java для экспорта файлов PPT и PPTX, выбранных слайдов, заметок, шрифтов, изображений, SVG и медиа."
---
## **Обзор**

Aspose.Slides for Node.js via Java может сохранять презентации PowerPoint в виде HTML без Microsoft PowerPoint. Основное преобразование состоит из единичной загрузки [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) и вызова `save` с [SaveFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/). Используйте [HtmlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/), когда необходимо управлять экспортируемым макетом, шрифтами, изображениями, заметками, комментариями, выводом SVG или связанными ресурсами.

Это руководство сосредоточено на практических сценариях экспорта в HTML:

- Экспорт всей презентации или выбранных слайдов.
- Генерация HTML фиксированного макета, адаптивного или основанного на SVG.
- Включение заметок выступающего и комментариев.
- Управление качеством изображений и данными обрезанных изображений.
- Встраивание шрифтов или отдельное сохранение файлов шрифтов.
- Выбор способа записи и ссылки на внешние ресурсы и медиафайлы.

По умолчанию экспорт в HTML создаёт автономный HTML‑документ, в котором большинство ресурсов внедрено. Это удобно для обмена одним файлом, но может увеличить размер вывода. Для публикации в вебе рассмотрите возможность использования внешних ресурсов, снижения DPI изображений и встраивания только тех шрифтов, которые недоступны в целевой среде.

## **Преобразовать презентацию в HTML**

Чтобы экспортировать презентацию в HTML, загрузите её с помощью [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) и сохраните с помощью [SaveFormat.Html](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

В этом примере записывается один HTML‑файл. Объект презентации освобождается в блоке `finally`, что закрывает файловые дескрипторы и освобождает ресурсы рендеринга после экспорта.

## **Использовать HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/) — основной класс конфигурации экспорта в HTML. Распространённые параметры включают:

- `SlidesLayoutOptions`: добавляет заметки, комментарии, раздаточные материалы или другую информацию о макете.
- `HtmlFormatter`: изменяет структуру HTML‑документа или делегирует форматирование контроллеру.
- `SlideImageFormat`: изменяет способ представления слайдов, например как SVG.
- `PicturesCompression`: контролирует DPI изображений и размер вывода.
- `DeletePicturesCroppedAreas`: сохраняет или удаляет данные обрезанных изображений.
- `SvgResponsiveLayout`: заставляет экспортированный SVG‑контент адаптироваться к своему контейнеру.
- `ShowHiddenSlides`: включает скрытые слайды при необходимости.

В следующих разделах показаны наиболее часто используемые параметры отдельно, чтобы вы могли комбинировать только те, которые нужны вашему рабочему процессу.

## **Экспорт выбранных слайдов в HTML**

Перегрузка `Presentation.save`, принимающая номера слайдов, использует 1‑based индексацию. Цикл ниже сохраняет каждый слайд в отдельный HTML‑файл.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Используйте этот шаблон, когда веб‑сайт или приложение требует одну HTML‑страницу на каждый слайд. Если каждый слайд должен иметь одинаковый макет, создайте один экземпляр [HtmlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/) и передавайте его каждому вызову `save`.

## **Создание адаптивного HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/responsivehtmlcontroller/) обеспечивает адаптивный вывод HTML через [HtmlFormatter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmlformatter/). Используйте его, когда экспортируемая страница должна лучше подстраиваться под ширину браузера.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Для адаптивного макета на основе SVG задайте `SvgResponsiveLayout` в [HtmlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/). Это полезно, когда содержимое слайда экспортируется как масштабируемая SVG‑разметка.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Включить заметки выступающего и комментарии**

Используйте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notescommentslayout