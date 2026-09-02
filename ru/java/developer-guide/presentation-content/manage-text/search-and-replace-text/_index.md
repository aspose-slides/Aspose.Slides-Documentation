---
title: Поиск и замена текста в презентациях PowerPoint на Java
linktitle: Поиск и замена текста
type: docs
weight: 55
url: /ru/java/search-and-replace-text/
keywords:
- поиск текста
- выделение текста
- замена текста
- регулярное выражение
- обратный вызов результата
- текстовый фрейм
- отчет аудита
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Ищите, выделяйте и заменяйте текст в презентациях PowerPoint, собирая каждое совпадение с помощью Aspose.Slides for Java."
---
## **Обзор**

Aspose.Slides for Java может выполнять поиск, выделение и замену текста в отдельном текстовом фрейме или во всей презентации. Каждая операция также может уведомлять приложение о каждом совпадении через обратный вызов результата. Это позволяет обновлять презентацию и одновременно создавать журнал аудита, содержащий найденный текст, его контекст, позицию, текстовый фрейм и номер слайда.

Эти возможности полезны для проверки, редактирования, проверок терминологии, очистки шаблонов и автоматизированных процессов создания отчетов.

В первых примерах ниже мы используем файл с именем "sample.pptx", который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выбор области поиска**

Используйте методы из [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) для ограничения операции одним текстовым фреймом. Используйте методы из [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) для обработки всего применимого текста в презентации.

| Операция | Один текстовый фрейм | Вся презентация |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Настройка сопоставления текста**

Для операций с буквальным текстом используйте [TextSearchOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textsearchoptions/) для управления сопоставлением:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ограничивает совпадения полными словами.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) определяет, должен ли регистр символов совпадать.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) включает примечания к слайдам в операции поиска, замены и выделения на уровне презентации.

Операции с регулярными выражениями используют Java `Pattern`, поэтому правила сопоставления, такие как чувствительность к регистру и границы слов, определяются выражением и его флагами.

## **Определение владельца текстового фрейма**

В типовых рабочих процессах обработки текста часто получают [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/), когда ищут, заменяют, проверяют или экспортируют текст. Используйте [ITextFrame.getParentShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#getParentShape--) и [ITextFrame.getParentCell](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#getParentCell--) , чтобы определить, какой объект презентации владеет текстовым фреймом.

Ожидаемые значения зависят от владельца:

| Владелец текстового фрейма | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape или другая форма, содержащая текст | The owning [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/) | `null` |
| Ячейка таблицы | `null` | The owning [ICell](https://reference.aspose.com/slides/ru/java/com.aspose.slides/icell/) |

Оба метода обеспечивают навигацию только для чтения. Их вызов не перемещает текстовый фрейм и не меняет его владельца. Общий код должен проверять оба значения на `null` и обрабатывать возможность, что ни один из владельцев недоступен.

В следующем примере используется [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) , чтобы перебрать текстовые фреймы в презентации. Для форм он выводит имя формы, тип Java во время выполнения и содержащий слайд. Для ячеек таблицы он выводит координаты столбца и строки, начинающиеся с нуля, и содержащий слайд.

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

Для содержимого SmartArt перебирайте формы в [ISmartArtNode.getShapes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ismartartnode/#getShapes--) и получайте каждую [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ismartartshape/#getTextFrame--). Текстовый фрейм можно проследить к связанной форме через [ITextFrame.getParentShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#getParentShape--) , в то время как [ITextFrame.getParentCell](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#getParentCell--) возвращает `null`. Поэтому ветка форм в примере также обрабатывает текст из узлов SmartArt.

## **Сбор информации о совпадениях с помощью обратного вызова**

Реализуйте [IFindResultCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifindresultcallback/) , чтобы получать уведомление о каждом совпадении. Его метод [IFindResultCallback.foundResult](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) предоставляет соответствующий текстовый фрейм, исходный текст, найденный текст и позицию совпадения.

Обратный вызов не получает номер слайда напрямую. Реализация ниже извлекает его из родительского слайда и также обрабатывает текст, найденный в примечаниях к слайдам. Nullable `Integer` позволяет использовать одну модель результата для представления текста, связанного с другими типами слайдов.

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

Для операций замены `foundText` содержит исходный найденный текст, поэтому обратный вызов может точно зафиксировать, какие термины были заменены.

## **Выделение текста**

Используйте метод [ITextFrame.highlightText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) , чтобы выделять совпадения буквального текста в текстовом фрейме. Передайте [TextSearchOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textsearchoptions/) , чтобы контролировать поиск, и обратный вызов для сбора деталей совпадения.

Пример кода ниже выделяет все вхождения символов **"try"** и затем выделяет только полное слово **"to"**. Оба поиска сообщают свои совпадения в один и тот же обратный вызов.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // Выделить каждое вхождение "try" в текстовом фрейме.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

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

## **Выделение текста с использованием регулярных выражений**

Метод [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) выделяет совпадения текста, найденные регулярным выражением, в текстовом фрейме.

Следующий код выделяет все слова, содержащие семь и более символов, и собирает каждое совпадение:

```java
import com.aspose.slides.*;
import java.awt.Color;
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

Используйте [Presentation.highlightText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) и [Presentation.highlightRegex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) , чтобы искать во всех применимых текстовых фреймах презентации. В следующем примере выделяется буквальный термин и все адреса электронной почты, при этом для двух поисков сохраняются отдельные коллекции результатов.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

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

Используйте [ITextFrame.replaceText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) для буквального текста и [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) для замены по шаблону. Эти методы обновляют найденный текст внутри существующего текстового фрейма, сохраняющего форматирование окружающих частей, вместо того чтобы перестраивать фрейм из простой строки.

В следующем примере стандартизируется вариант написания, а затем заменяются метки версии. Один и тот же обратный вызов фиксирует исходные термины, найденные в обеих операциях.

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

Если одно совпадение охватывает части с разным форматированием, проверьте результат, чтобы подтвердить, какое форматирование следует применить к заменяемому тексту.

## **Замена текста во всей презентации**

Используйте [Presentation.replaceText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) и [Presentation.replaceRegex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) , чтобы применить одинаковые операции ко всей презентации. Это полезно для очистки шаблонов, обновления терминологии и редактирования.

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

## **Группировка совпадений для отчетов**

Поскольку каждый результат хранит номер слайда и текстовый фрейм, приложения могут группировать совпадения для аудита, составления отчетов или процессов обзора. В следующем примере результаты группируются сначала по слайду, а затем по текстовому фрейму:

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

## **Часто задаваемые вопросы**

**Как выполнить поиск только в одном текстовом блоке вместо всей презентации?**

Получите текстовый фрейм формы и вызовите [ITextFrame.highlightText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), или [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) для этого фрейма. Методы уровня презентации обрабатывают все применимые текстовые фреймы.

**Как сопоставить полные слова с правильным регистром?**

Установите [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) и [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) в `true` и передайте параметры методу выделения или замены буквального текста. Для регулярных выражений определите границы слов и чувствительность к регистру непосредственно в Java `Pattern`.

**Можно ли включить поиск и замену текста из примечаний к слайдам?**

Да. Установите [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ru/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) в `true` при использовании операции буквального текста на уровне презентации. Реализация обратного вызова, показанная выше, сопоставляет совпадение в примечании к слайду с номером его родительского слайда.

**Как создать отчет, не просматривая презентацию во второй раз?**

Передайте реализацию [IFindResultCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifindresultcallback/) в операцию выделения или замены. Обратный вызов получает каждое совпадение во время выполнения операции, поэтому приложение может сохранять исходный текст, найденный текст, позицию, текстовый фрейм и вычисленный номер слайда для последующей группировки или экспорта.

**Сохраняет ли замена текста его форматирование?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) и [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) изменяют найденный текст внутри существующего текстового фрейма и сохраняют форматирование окружающих частей. Если совпадение охватывает части с разным форматированием, проверьте результат, чтобы убедиться, что замена использует требуемый стиль.