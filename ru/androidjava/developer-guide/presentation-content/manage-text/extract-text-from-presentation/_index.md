---
title: Продвинутое извлечение текста из презентаций на Android
linktitle: Извлечение текста
type: docs
weight: 90
url: /ru/androidjava/extract-text-from-presentation/
keywords:
- извлечение текста
- извлечение текста со слайда
- извлечение текста из презентации
- извлечение текста из PowerPoint
- извлечение текста из OpenDocument
- извлечение текста из PPT
- извлечение текста из PPTX
- извлечение текста из ODP
- получение текста
- получение текста со слайда
- получение текста из презентации
- получение текста из PowerPoint
- получение текста из OpenDocument
- получение текста из PPT
- получение текста из PPTX
- получение текста из ODP
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Быстро извлекайте текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides for Android via Java. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---
## **Обзор**

Извлечение текста из презентаций — распространённая, но при этом важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, имеете ли вы дело с файлами Microsoft PowerPoint в формате PPT или PPTX, либо с презентациями OpenDocument (ODP), доступ к текстовым данным может быть критически важен для анализа, автоматизации, индексации или миграции контента.

В этой статье представлено полное руководство по эффективному извлечению текста из различных форматов презентаций, включая PPT, PPTX и ODP, с помощью Aspose.Slides for Android via Java. Вы узнаете, как систематически просматривать элементы презентации, чтобы точно получить нужный текстовый контент.

## **Извлечение текста со слайда**

Aspose.Slides for Android via Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideutil/). Этот класс содержит несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст со слайда в презентации, используйте метод [getAllTextBoxes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Этот метод принимает объект типа [IBaseSlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/) в качестве параметра. При выполнении метод просматривает весь слайд в поиске текста и возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/), сохраняя любое форматирование текста.

Следующий фрагмент кода извлекает весь текст с первого слайда презентации:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Извлечение текста из презентации**

Чтобы просканировать текст всей презентации, используйте статический метод [getAllTextFrames](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) класса [SlideUtil](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideutil/). Он принимает два параметра:

1. Сначала объект [IPresentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/) , представляющий презентацию PowerPoint или OpenDocument, из которой будет извлекаться текст.
1. Затем значение типа `boolean`, указывающее, следует ли включать мастер‑слайды при сканировании текста презентации.

Метод возвращает массив объектов типа [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/), включающий информацию о форматировании текста. Ниже приведён код, который сканирует текст и детали форматирования из презентации, включая мастер‑слайды.

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Категоризованное и быстрое извлечение текста**

Класс [PresentationFactory](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentationfactory/) также предоставляет методы для извлечения всего текста из презентаций:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

Аргумент перечисления [TextExtractionArrangingMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textextractionarrangingmode/) указывает режим организации результата извлечения текста и может принимать следующие значения:
- `Unarranged` — Неотформатированный текст без учёта его положения на слайде.
- `Arranged` — Текст упорядочен в том же порядке, что и на слайде.

Неотформатированный режим можно использовать, когда важна скорость; он быстрее, чем отформатированный режим.

[IPresentationText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentationtext/) представляет необработанный текст, извлечённый из презентации. Его метод `getSlidesText` возвращает массив объектов типа [ISlideText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidetext/). Каждый объект представляет текст соответствующего слайда. Объект типа [ISlideText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidetext/) имеет следующие методы:

- `getText` — Текст внутри фигур слайда.
- `getMasterText` — Текст внутри фигур мастер‑слайда, связанного с этим слайдом.
- `getLayoutText` — Текст внутри фигур шаблона слайда, связанного с этим слайдом.
- `getNotesText` — Текст внутри фигур слайда заметок, связанного с этим слайдом.
- `getCommentsText` — Текст внутри комментариев, связанных с этим слайдом.

```java
String presentationPath = "presentation.pptx";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **FAQ**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и может обрабатывать даже [большие презентации](/slides/ru/androidjava/open-presentation/), что делает его подходящим для сценариев в реальном времени или пакетной обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм внутри презентаций?**

Да. Aspose.Slides может извлекать текст из многих элементов слайда, включая таблицы и объекты, связанные с диаграммами, поэтому вы можете получать и анализировать текстовое содержание в типичных структурах презентаций.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, хотя она имеет [определённые ограничения](/slides/ru/androidjava/licensing/), например, обработку только ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.