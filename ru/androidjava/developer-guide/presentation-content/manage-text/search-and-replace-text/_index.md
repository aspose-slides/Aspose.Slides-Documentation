---
title: Поиск и замена текста в презентациях PowerPoint на Android
linktitle: Поиск и замена текста
type: docs
weight: 55
url: /ru/androidjava/search-and-replace-text/
keywords:
- поиск текста
- выделение текста
- замена текста
- регулярное выражение
- обратный вызов результата
- текстовый фрейм
- аудиторский отчёт
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Ищите, выделяйте и заменяйте текст в презентациях PowerPoint, собирая каждое совпадение с помощью Aspose.Slides for Android via Java."
---
## **Обзор**

Aspose.Slides for Android via Java может искать, выделять и заменять текст в отдельном текстовом фрейме или во всей презентации. Каждая операция также может уведомлять приложение о каждом совпадении через обратный вызов результата. Это позволяет обновлять презентацию и одновременно создавать журнал аудита, содержащий найденный текст, его контекст, позицию, текстовый фрейм и номер слайда.

Эти возможности полезны для рецензирования, редактирования, проверки терминологии, очистки шаблонов и автоматизированных процессов отчётности.

В первых примерах ниже мы используем файл с именем "sample.pptx", который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выбор области поиска**

Используйте методы интерфейса [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) для ограничения операции одним текстовым фреймом. Используйте методы интерфейса [IPresentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/) для обработки всего применимого текста в презентации.

| Операция | Один текстовый фрейм | Вся презентация |
|---|---|---|
| Выделить буквальный текст | [ITextFrame.highlightText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Выделить совпадения регулярного выражения | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Заменить буквальный текст | [ITextFrame.replaceText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Заменить совпадения регулярного выражения | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Настройка сопоставления текста**

Для операций с буквальным текстом используйте [TextSearchOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textsearchoptions/) для управления сопоставлением:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ограничивает совпадения полными словами.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) управляет тем, должен ли регистр символов совпадать.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) включает заметки слайдов в операции поиска, замены и выделения на уровне презентации.

Операции с регулярными выражениями используют Java `Pattern`, поэтому правила сопоставления, такие как чувствительность к регистру и границы слов, задаются выражением и его флагами.

## **Определение владельца текстового фрейма**

Общие рабочие процессы обработки текста часто получают объект [ITextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/) при поиске, замене, проверке или экспорте текста. Используйте [ITextFrame.getParentShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#getParentShape--) и [ITextFrame.getParentCell](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#getParentCell--) , чтобы определить, какой объект презентации владеет этим текстовым фреймом.

Ожидаемые значения зависят от владельца:

| Владелец текстового фрейма | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape или другая форма, содержащая текст | Владелец [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/) | `null` |
| Ячейка таблицы | `null` | Владелец [ICell](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icell/) |

Оба метода предоставляют только навигацию для чтения. Их вызов не перемещает текстовый фрейм и не меняет его владельца. Общий код должен проверять оба значения на `null` и обрабатывать возможность, что ни один владелец недоступен.

Следующий пример использует [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) для перебора текстовых фреймов в презентации. Для фигур он выводит имя фигуры, тип в runtime Java и содержащий слайд. Для ячеек таблицы он выводит координаты столбца и строки, начинающиеся с нуля, и содержащий слайд.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Для содержимого SmartArt перебирайте фигуры в [ISmartArtNode.getShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ismartartnode/#getShapes--) и получайте каждую [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--). Текстовый фрейм можно отнести к своей связанной фигуре через [ITextFrame.getParentShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#getParentShape--), в то время как [ITextFrame.getParentCell](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#getParentCell--) возвращает `null`. Поэтому ветка фигур в примере также обрабатывает текст из узлов SmartArt.

## **Сбор информации о совпадениях с помощью обратного вызова**

Реализуйте [IFindResultCallback](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifindresultcallback/) , чтобы получать уведомление о каждом совпадении. Его метод [IFindResultCallback.foundResult](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) предоставляет связанный текстовый фрейм, исходный текст, найденный текст и позицию совпадения.

Обратный вызов не получает номер слайда напрямую. Ниже приведённая реализация получает его из родительского слайда и также обрабатывает текст, найденный в заметках слайда. Допускающий значение `null` тип `Integer` позволяет той же модели результата представлять текст, связанный с другими типами слайдов.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

Для операций замены `foundText` содержит оригинальный найденный текст, поэтому обратный вызов может точно зафиксировать, какие термины были заменены.

## **Выделение текста**

Используйте метод [ITextFrame.highlightText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) для выделения совпадений буквального текста в текстовом фрейме. Передайте [TextSearchOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textsearchoptions/) для управления поиском и обратный вызов для сбора деталей совпадений.

Пример кода ниже выделяет все вхождения символов **"try"**, а затем выделяет только полное слово **"to"**. Оба поиска сообщают свои совпадения в один и тот же обратный вызов.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // Выделить каждое вхождение "try" в текстовом фрейме.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Выделить только полное слово "to".
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Выделенный текст](highlighted_text.png)

## **Выделение текста с помощью регулярных выражений**

Метод [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) выделяет совпадения текста, найденные регулярным выражением, в текстовом фрейме.

Следующий код выделяет все слова, содержащие семь и более символов, и собирает каждое совпадение:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Выделенный текст с использованием регулярного выражения](highlighted_text_using_regex.png)

## **Выделение текста во всей презентации**

Используйте [IPresentation.highlightText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) и [IPresentation.highlightRegex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) для поиска во всех применимых текстовых фреймах презентации. Следующий пример выделяет буквальный термин и все адреса электронной почты, при этом сохраняет отдельные коллекции результатов для двух поисков.

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Замена текста в текстовом фрейме**

Используйте [ITextFrame.replaceText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) для буквального текста и [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) для замены по шаблону. Эти методы обновляют найденный текст внутри существующего текстового фрейма, сохраняя форматирование окружающих частей, вместо пересоздания фрейма из простой строки.

Следующий пример стандартизирует вариант написания, а затем заменяет метки версий. Тот же обратный вызов записывает оригинальные термины, найденные обеими операциями.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если одно совпадение охватывает части с разным форматированием, проверьте результат, чтобы подтвердить, какое форматирование должно применяться к заменяемому тексту.

## **Замена текста во всей презентации**

Используйте [IPresentation.replaceText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) и [IPresentation.replaceRegex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) для применения одинаковых операций по всей презентации. Это полезно для очистки шаблонов, обновления терминологии и редактирования.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Группировка совпадений для отчётов**

Поскольку каждый результат хранит номер слайда и текстовый фрейм, приложения могут группировать совпадения для аудита, отчётности или процессов рецензирования. Следующий пример группирует собранные результаты сначала по слайдам, затем по текстовым фреймам:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **FAQ**

**Как выполнить поиск только в одном текстовом поле, а не во всей презентации?**

Получите текстовый фрейм формы и вызовите [ITextFrame.highlightText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), или [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) для этого фрейма. Методы уровня презентации обрабатывают все применимые текстовые фреймы вместо этого.

**Как сопоставить полные слова с учётом правильного регистра?**

Установите [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) и [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) в `true` и передайте опции методу выделения или замены буквального текста. Для регулярных выражений определите границы слов и чувствительность к регистру непосредственно в Java `Pattern`.

**Можно ли включить в поиск и замену текст из заметок слайдов?**

Да. Установите [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) в `true` при использовании операции буквального текста уровня презентации. Реализация обратного вызова, приведённая выше, сопоставляет совпадение в слайде заметок с номером его родительского слайда.

**Как создать отчёт, не сканируя презентацию второй раз?**

Передайте реализацию [IFindResultCallback](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifindresultcallback/) в операцию выделения или замены. Обратный вызов получает каждое совпадение во время выполнения операции, поэтому приложение может сохранять исходный текст, найденный текст, позицию, текстовый фрейм и полученный номер слайда для последующей группировки или экспорта.

**Сохраняет ли замена текста его форматирование?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) и [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) изменяют найденный текст внутри существующего текстового фрейма и сохраняют форматирование окружающих частей. Если совпадение охватывает части с разным форматированием, проверьте результат, чтобы убедиться, что замена использует требуемый стиль.