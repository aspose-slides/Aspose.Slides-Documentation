---
title: Изменение размера и ориентации страницы заметок на Android
linktitle: Размер страницы заметок
type: docs
weight: 10
url: /ru/androidjava/notes-size/
keywords:
- размер страницы заметок
- ориентация заметок
- альбомные заметки
- портретные заметки
- размер раздатки
- PowerPoint
- презентация
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Чтение и изменение размеров страницы заметок в Aspose.Slides для Android через Java, смена ориентации, проверка сохранённых размеров и экспорт заметок или раздаточных материалов в PDF и изображения."
---
## **Обзор**

Используйте [Presentation.getNotesSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getNotesSize--) для доступа к настройкам страницы заметок презентации. Он возвращает объект [INotesSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/inotessize/), чей метод [setSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) задаёт размеры страницы. Хотя сам объект настроек заменить нельзя, вы можете назначить новые размеры через этот метод.

Ширина и высота указываются в **точках**, при этом в одном дюйме 72 точки. Например, 900 × 600 точек — это 12,5 × 8⅓ дюйма. Эти настройки применяются к презентации, а не к заметкам отдельного слайда.

| Параметр | Назначение |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Управляет размерами страницы заметок и размерами страницы, используемыми при экспорте раздаточных материалов. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Управляет размерами обычных слайдов презентации через [ISlideSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidesize/). |

Изменение любой из этих настроек автоматически не меняет другую. Изменение ориентации страницы заметок также не вращает обычные слайды. См. [Slide Size](/slides/ru/androidjava/slide-size/) для изменения размеров обычных слайдов.

В примерах ниже используется существующий `sample.pptx`. Для примеров экспорта используйте презентацию, содержащую хотя бы один слайд с примечаниями к докладчику. Каждый пример может быть выполнен независимо.

## **Чтение размеров и ориентации страницы заметок**

Считайте ширину и высоту и сравните их, чтобы определить ориентацию: более широкая страница — альбомная, более высокая — портретная, а одинаковые размеры описывают квадратную страницу. Этот пример выводит фактические размеры в точках, не предполагая стандартный размер бумаги.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Переход в альбомный режим без изменения размера бумаги**

Чтобы изменить только ориентацию, поменяйте местами текущие ширину и высоту. Это сохраняет длины обеих сторон, включая пользовательский размер бумаги. Условие ниже предотвращает переключение уже альбомной страницы обратно в портретный режим и оставляет квадратную страницу без изменений.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для портретной ориентации используйте то же присваивание, когда `size.getWidth() > size.getHeight()`. Не заменяйте размеры A4 или Letter, если вы не хотите также изменить размер бумаги.

## **Установка и проверка пользовательского размера страницы заметок**

Присвойте обе размеры одновременно, затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) для записи презентации. Этот пример устанавливает альбомную страницу 900 × 600 точек, сохраняет её как PPTX и открывает сохранённый файл снова для проверки сохранённых значений. Сравнение допускает погрешность 0.01 точки для значений с плавающей запятой; это не гарантирует точность для каждого формата файлов.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Ожидаемый результат: `900.0 x 600.0 points` и `Size preserved: true`. Проверка только что открытой презентации подтверждает сохранённый файл, а не только настройки в памяти.

## **Экспорт заметок и раздаточных материалов**

Размеры страниц определяют доступную область для макетов заметок или раздаточных материалов. Они не активируют эти макеты сами по себе: также настройте параметры экспорта. Экспорт обычных слайдов по‑прежнему использует размеры слайдов.

### **Экспорт заметок в PDF и PNG**

Присвойте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/notescommentslayoutingoptions/) методу [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) для включения заметок в PDF. Этот пример также рендерит первый слайд с заметками в PNG с помощью [Slide.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) и [RenderingOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/renderingoptions/).

Режим [BottomTruncated](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/notespositions/) оставляет заметки на одной странице; заметки, которые не помещаются, могут быть усечены. PDF использует страницы 900 × 600 точек. При масштабе изображения 1 × 1, используемом ниже, PNG имеет размер 900 × 600 пикселей. Точки описывают геометрию страницы; пиксели описывают растровый вывод, размеры которого также зависят от масштаба рендеринга.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Для экспорта PDF с длинными заметками [BottomFull](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/notespositions/) позволяет добавлять дополнительные страницы по мере необходимости. Не используйте этот режим с вызовом одиночного слайда изображения выше, который его не поддерживает. После изменения размера проверьте вывод на обрезанные заметки и расположение существующих объектов master‑заметок; изменение размеров страницы само по себе не гарантирует, что всё содержимое поместится. См. [Convert PowerPoint to PDF with Notes](/slides/ru/androidjava/convert-powerpoint-to-pdf-with-notes/) для получения дополнительной информации об экспорте заметок.

### **Экспорт раздаточных материалов в PDF**

Используйте [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/handoutlayoutingoptions/) для нескольких миниатюр слайдов на одной странице. Следующий пример задаёт страницу 900 × 600 точек и использует [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/handouttype/) для размещения до четырёх слайдов на странице. Горизонтальный предустановленный параметр управляет порядком слайдов; ориентация страницы берётся из её ширины и высоты.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Изменение размера страницы изменяет область, доступную для сетки раздаточных материалов, не изменяя размеры исходных слайдов. Для изображений раздаточных материалов используйте [Presentation.getImages](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) с макетом раздатки, а не метод получения изображения отдельного слайда. В Aspose.Slides рендеринг раздаточных материалов уровня презентации использует размеры страницы заметок, тогда как вызов получения изображения отдельного слайда не создаёт страницу раздатки. См. [Handout Mode](/slides/ru/androidjava/convert-powerpoint-in-handout-mode/) для вариантов макета.

## **Размер страницы в просмотрщиках, экспорте и печати**

Сохраняйте различие между размером, хранимым в презентации, размером экспортируемой страницы и размером печатной бумаги:

- **Просмотрщики презентаций:** Просмотрщик может отображать или печатать заметки, используя свои правила расположения. Если другое приложение сохраняет файл, откройте его снова и проверьте размеры; конверсия формата этого приложения может их нормализовать.
- **Форматы экспорта:** Примеры PDF с заметками и раздаткой выше используют настроенные размеры страниц. Растровые изображения используют целочисленные размеры пикселей и масштаб рендеринга, поэтому дробные значения точек могут быть округлены в выводе изображения. Экспорт обычных слайдов не применяет размер страницы заметок.
- **Драйверы принтеров:** Выбор бумаги, автоматическое вращение и настройки «подгонки к странице» могут изменить физический вывод без изменения размеров, хранящихся в презентации или PDF. Для конкретного размера бумаги сопоставьте настройки принтера и проверьте предварительный просмотр печати.

## **FAQ**

**Можно ли задать размер заметок только для одного слайда?**

Размер страницы заметок задаётся на уровне презентации. Отдельные слайды могут иметь различное содержание заметок, но это свойство не предоставляет отдельный размер страницы для каждого слайда.

**Почему изменение ориентации заметок не изменило мои слайды?**

Страницы заметок и обычные слайды имеют независимые размеры. Используйте настройки размеров обычных слайдов, когда хотите изменить размер самих слайдов.

**Почему мой сохранённый или печатный результат имеет другой размер?**

Сначала откройте сохранённую презентацию снова и сравните её размеры заметок. Если они изменились, проверьте, изменили ли сохранение или конверсия файла в другом приложении настройки страниц. Если нет, проверьте макет экспорта, масштаб изображения, настройки просмотрщика и выбор бумаги принтером.