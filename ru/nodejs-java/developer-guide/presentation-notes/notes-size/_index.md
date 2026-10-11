---
title: Изменение размера и ориентации страницы заметок в JavaScript
linktitle: Размер страницы заметок
type: docs
weight: 10
url: /ru/nodejs-java/notes-size/
keywords:
- размер страницы заметок
- ориентация заметок
- альбомные заметки
- портретные заметки
- размер раздаточного листа
- PowerPoint
- презентация
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Чтение и изменение размеров страницы заметок в Aspose.Slides для Node.js через Java, переключение ориентации, проверка сохранённых размеров и экспорт заметок или раздаточных листов в PDF и изображения."
---
## **Обзор**

Используйте [Presentation.getNotesSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getnotessize/) чтобы получить настройки страницы заметок презентации. Он возвращает объект [NotesSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notessize/) чей метод [setSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notessize/setsize/) задает размеры страницы. Хотя сам объект настроек нельзя заменить, вы можете назначить новые размеры через этот метод.

Ширина и высота указываются в **точках**, по 72 точки на дюйм. Например, 900 × 600 точек соответствует 12,5 × 8⅓ дюйма. Эти настройки применяются к презентации, а не к заметкам отдельного слайда.

| Настройка | Назначение |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getnotessize/) | Контролирует размеры страницы заметок и размеры страницы, используемые при экспорте раздаточного листа. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getslidesize/) | Контролирует размеры обычных слайдов презентации через [SlideSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidesize/). |

Изменение любой из настроек не меняет автоматически другую. Изменение ориентации страницы заметок также не вращает обычные слайды. Смотрите [Размер слайдов](/slides/ru/nodejs-java/slide-size/) чтобы изменить размер обычных слайдов.

Ниже приведённые примеры используют существующий файл `sample.pptx`. Для примеров экспорта используйте презентацию, содержащую хотя бы один слайд с примечаниями докладчика. Каждый пример может быть выполнен независимо.

## **Чтение размеров и ориентации страницы заметок**

Считайте ширину и высоту и сравните их, чтобы определить ориентацию: более широкая страница — альбомная, более высокая — портретная, а одинаковые размеры описывают квадратную страницу. Этот пример выводит реальные размеры в точках, не предполагая стандартный размер бумаги.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Переключить на альбомный режим без изменения размера бумаги**

Чтобы изменить только ориентацию, поменяйте местами текущие ширину и высоту. Это сохраняет длины обеих сторон, включая пользовательский размер бумаги. Условие ниже предотвращает переключение уже альбомной страницы обратно в портрет и оставляет квадратную страницу без изменений.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для портретной ориентации используйте то же присваивание, когда `size.getWidth() > size.getHeight()`. Не подставляйте размеры A4 или Letter, если вы не хотите также менять размер бумаги.

## **Установить и проверить пользовательский размер страницы заметок**

Назначьте оба измерения одновременно, затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/save/) для записи презентации. Этот пример устанавливает альбомную страницу 900 × 600 точек, сохраняет её как PPTX и снова открывает сохранённый файл, чтобы проверить сохранённые значения. Сравнение допускает погрешность 0,01 точки для значений с плавающей запятой; это не является гарантией точности для каждого формата файла.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Ожидаемый результат: `900 x 600 points` и `Size preserved: true`. Проверка только что открытой презентации подтверждает сохранённый файл, а не только настройки в памяти.

## **Экспорт заметок и раздаточных листов**

Размеры страницы определяют доступную область для макетов заметок или раздаточных листов. Они сами по себе не включают эти макеты: также необходимо настроить параметры экспорта. Экспорт обычных слайдов продолжает использовать размеры слайда.

### **Экспорт заметок в PDF и PNG**

Назначьте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notescommentslayoutingoptions/) параметру [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) чтобы включить заметки в PDF. Этот пример также рендерит первый слайд с заметками в PNG, используя [Slide.getImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#getImage) и [RenderingOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/renderingoptions/).

Режим [BottomTruncated](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notespositions/) сохраняет заметки на одной странице; заметки, которые не помещаются, могут быть обрезаны. PDF использует страницы размером 900 × 600 точек. При масштабе изображения 1 × 1, используемом ниже, PNG имеет 900 × 600 пикселей. Точки описывают геометрию страницы; пиксели описывают растровый вывод, размеры которого также зависят от масштаба рендеринга.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Для экспорта PDF с длинными заметками [BottomFull](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notespositions/) позволяет добавлять дополнительные страницы по необходимости. Не используйте этот режим с вызовом рендеринга одиночного слайда выше, который его не поддерживает. После изменения размеров проверьте вывод на наличие обрезанных заметок и расположение существующих объектов notes-master; изменение размеров страницы само по себе не гарантирует, что всё содержимое поместится. См. [Convert PowerPoint to PDF with Notes](/slides/ru/nodejs-java/convert-powerpoint-to-pdf-with-notes/) для получения дополнительной информации об экспорте заметок.

### **Экспорт раздаточных листов в PDF**

Используйте [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/handoutlayoutingoptions/) для размещения нескольких миниатюр слайдов на одной странице. В следующем примере задаётся страница 900 × 600 точек и используется [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/handouttype/) для размещения до четырёх слайдов на странице. Горизонтальная предустановка управляет порядком слайдов; ориентация страницы определяется её шириной и высотой.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Изменение размера страницы меняет область, доступную для сетки раздаточного листа, не изменяя размеры исходных слайдов. Для изображений раздатки используйте [Presentation.getImages](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getimages/) с раздаточным макетом, а не метод получения изображения отдельного слайда. В Aspose.Slides рендеринг раздатки на уровне презентации использует размеры страницы заметок, тогда как отдельный вызов получения изображения слайда не создаёт страницу раздатки. См. [Handout Mode](/slides/ru/nodejs-java/convert-powerpoint-in-handout-mode/) для вариантов макета.

## **Размер страницы в просмотрщиках, экспорте и печати**

Сохраняйте различие между размером сохранённой презентации, размером экспортируемой страницы и размером печатаемой бумаги:

- **Просмотрщики презентаций:** Просмотрщик может отображать или печатать заметки, используя свои правила разметки. Если другое приложение сохраняет файл, откройте его снова и проверьте размеры; преобразование формата этим приложением может их нормализовать.
- **Форматы экспорта:** Приведённые выше примеры PDF с заметками и раздаточными листами используют настроенные размеры страницы. Растровые изображения используют целочисленные размеры пикселей и масштаб рендеринга, поэтому дробные значения точек могут быть округлены в выводе изображения. Экспорт обычных слайдов не применяет размер страницы заметок.
- **Драйверы принтера:** Выбор бумаги, автоматическое вращение и настройки вписать‑по‑странице могут изменить физический вывод без изменения размеров, хранящихся в презентации или PDF. Для конкретного размера бумаги согласуйте настройки принтера и проверьте предварительный просмотр печати.

## **FAQ**

**Можно ли задать размер заметок только для одного слайда?**

Размер страницы заметок задаётся на уровне презентации. Отдельные слайды могут иметь различное содержание заметок, но это свойство не предоставляет отдельный размер страницы для каждого слайда.

**Почему изменение ориентации заметок не изменило мои слайды?**

Страницы заметок и обычные слайды имеют независимые размеры. Используйте настройки размеров обычных слайдов, когда хотите изменить размер самих слайдов.

**Почему сохранённый или напечатанный результат имеет другой размер?**

Сначала откройте сохранённую презентацию вновь и сравните её размеры заметок. Если они изменились, проверьте, изменило ли сохранение или конвертация файла в другом приложении параметры страницы. Если нет, проверьте макет экспорта, масштаб изображения, настройки просмотрщика и выбор бумаги принтера.