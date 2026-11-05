---
title: Изменение размера и ориентации страницы заметок в Java
linktitle: Размер страницы заметок
type: docs
weight: 10
url: /ru/java/notes-size/
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
- Java
- Aspose.Slides
description: "Читать и изменять размеры страницы заметок в Aspose.Slides для Java, переключать ориентацию, проверять сохранённые размеры и экспортировать заметки или раздаточные листы в PDF и изображения."
---
## **Обзор**

Используйте [Presentation.getNotesSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getNotesSize--) для доступа к настройкам страницы заметок презентации. Он возвращает объект [INotesSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/inotessize/), метод [setSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) которого задает размеры страницы. Хотя сам объект настроек нельзя заменить, вы можете назначить новые размеры с помощью этого метода.

Ширина и высота указываются в **точках**, по 72 точки на дюйм. Например, 900 × 600 точек — это 12,5 × 8⅓ дюйма. Эти настройки применяются к презентации в целом, а не к отдельным слайдам с заметками.

| Параметр | Назначение |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getNotesSize--) | Управляет размерами страницы заметок и размерами страницы, используемыми при экспорте раздаточных листов. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSlideSize--) | Управляет обычными размерами слайдов презентации через [ISlideSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidesize/). |

Изменение любой из настроек не меняет автоматически другую. Изменение ориентации страницы заметок также не вращает обычные слайды. См. [Slide Size](/slides/ru/java/slide-size/) чтобы изменить размеры обычных слайдов.

Примеры ниже используют существующий файл `sample.pptx`. Для примеров экспорта используйте презентацию с хотя бы одним слайдом, содержащим заметки выступающего. Каждый пример можно запускать независимо.

## **Чтение размеров и ориентации страницы заметок**

Прочитайте ширину и высоту и сравните их, чтобы определить ориентацию: более широкая страница — альбомная, более высокая — портретная, одинаковые размеры — квадратная страница. Этот пример выводит фактические размеры в точках, не предполагая стандартный размер бумаги.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
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

## **Переключить в альбомную ориентацию без изменения размера бумаги**

Чтобы изменить только ориентацию, поменяйте местами текущие ширину и высоту. Это сохраняет длины обеих сторон, включая пользовательский размер бумаги. Условие ниже предотвращает переключение уже альбомной страницы обратно в портрет и оставляет квадратную страницу без изменений.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для портретной ориентации используйте то же присваивание, когда `size.getWidth() > size.getHeight()`. Не подставляйте размеры A4 или Letter, если только не хотите изменить размер бумаги.

## **Установить и проверить пользовательский размер страницы заметок**

Назначьте оба измерения одновременно, затем используйте [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-) для записи презентации. Этот пример задаёт альбомную страницу 900 × 600 точек, сохраняет её как PPTX и снова открывает сохранённый файл для проверки сохранённых значений. Сравнение допускает погрешность 0,01 точки для значений с плавающей запятой; это не гарантирует точность для каждого формата файла.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
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

Ожидаемый результат: `900.0 x 600.0 points` и `Size preserved: true`. Проверка вновь открытой презентации подтверждает сохранённый файл, а не только параметры в памяти.

## **Экспорт заметок и раздаточных материалов**

Размеры страницы определяют доступную область для макетов заметок или раздаточных листов. Они не включают эти макеты автоматически: необходимо также настроить параметры экспорта. Экспорт обычных слайдов продолжает использовать размеры слайда.

### **Экспорт заметок в PDF и PNG**

Назначьте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/notescommentslayoutingoptions/) параметру [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) для включения заметок в PDF. Этот пример также рендерит первый слайд с заметками в PNG с помощью [Slide.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) и [RenderingOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/renderingoptions/).

Режим [BottomTruncated](https://reference.aspose.com/slides/ru/java/com.aspose.slides/notespositions/) оставляет заметки на одной странице; заметки, не помещающиеся полностью, могут быть усечены. PDF использует страницы 900 × 600 точек. При масштабе изображения 1 × 1, указанном ниже, PNG имеет размер 900 × 600 пикселей. Точки описывают геометрию страницы; пиксели описывают растровый вывод, размеры которого также зависят от масштаба рендеринга.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
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

Для экспорта PDF с длинными заметками [BottomFull](https://reference.aspose.com/slides/ru/java/com.aspose.slides/notespositions/) позволяет добавлять дополнительные страницы по мере необходимости. Не используйте этот режим с вызовом рендеринга отдельного слайда выше, который его не поддерживает. После изменения размеров проверьте вывод на наличие обрезанных заметок и расположения существующих объектов мастера заметок; изменение только размеров страницы не гарантирует, что весь контент поместится. См. [Convert PowerPoint to PDF with Notes](/slides/ru/java/convert-powerpoint-to-pdf-with-notes/) для получения дополнительной информации об экспорте заметок.

### **Экспорт раздаточных материалов в PDF**

Используйте [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/handoutlayoutingoptions/) для размещения нескольких миниатюр слайдов на одной странице. В следующем примере задаётся страница 900 × 600 точек и используется [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ru/java/com.aspose.slides/handouttype/) для размещения до четырёх слайдов на странице. Горизонтальная предустановка управляет порядком слайдов; ориентация страницы берётся из её ширины и высоты.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
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

Изменение размера страницы меняет область, доступную для сетки раздаточных листов, без изменения размеров исходных слайдов. Для изображений раздаточных листов используйте [Presentation.getImages](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) с раздаточным макетом, а не метод получения изображения отдельного слайда. В Aspose.Slides рендеринг раздаточных листов на уровне презентации использует размеры страницы заметок, тогда как вызов получения изображения отдельного слайда не создаёт страницу раздаточного листа. См. [Handout Mode](/slides/ru/java/convert-powerpoint-in-handout-mode/) для вариантов макетов.

## **Размер страницы в просмоторщиках, экспорте и печати**

Сохраняйте различие между размером, хранимым в презентации, экспортируемым размером страницы и печатным размером бумаги:

- **Просмотрщики презентаций:** Просмотрщик может отображать или печатать заметки, используя свои собственные правила макета. Если другое приложение сохраняет файл, откройте его снова и проверьте размеры; преобразование формата этим приложением может их нормализовать.
- **Экспортные форматы:** Примеры экспорта заметок и раздаточных листов в PDF выше используют настроенные размеры страницы. Растровые изображения используют целочисленные размеры в пикселях и масштаб рендеринга, поэтому дробные значения точек могут быть округлены в выводе изображения. Экспорт обычных слайдов не применяет размер страницы заметок.
- **Драйверы принтера:** Выбор бумаги, автоматическое вращение и настройки «подогнать к странице» могут изменить физический вывод без изменения размеров, хранящихся в презентации или PDF. Для конкретного размера бумаги согласуйте настройки принтера и проверьте предварительный просмотр печати.

## **Часто задаваемые вопросы**

**Могу ли я установить размер заметок только для одного слайда?**

Размер страницы заметок задаётся на уровне всей презентации. Отдельные слайды могут иметь разное содержание заметок, но это свойство не предоставляет отдельный размер страницы для каждого слайда.

**Почему изменение ориентации заметок не изменило мои слайды?**

Страницы заметок и обычные слайды имеют независимые размеры. Используйте настройки размера обычных слайдов, когда нужно изменить размеры самих слайдов.

**Почему мой сохранённый или распечатанный результат имеет другой размер?**

Сначала откройте сохранённую презентацию снова и сравните её размеры заметок. Если они изменились, проверьте, изменили ли размер страницы при сохранении или конвертации файла в другом приложении. Если нет, проверьте макет экспорта, масштаб изображения, настройки просмотрщика и выбор бумаги принтера.