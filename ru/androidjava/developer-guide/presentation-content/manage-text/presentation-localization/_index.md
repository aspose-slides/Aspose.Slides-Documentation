---
title: Автоматизация локализации презентаций на Android
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/androidjava/presentation-localization/
keywords:
- изменение языка
- проверка орфографии
- подавление проверки орфографии
- язык проверки
- идентификатор языка
- многоязычный текст
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Установите языки проверки для текста презентаций PowerPoint и OpenDocument на Android с помощью Aspose.Slides for Android via Java, включая параметры по умолчанию и многоязычные абзацы."
---
## **Обзор**

Aspose.Slides for Android via Java позволяет настраивать метаданные проверки для отдельных частей текста. Используйте [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) для указания языка проверки, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) для включения или подавления проверок орфографии, а также [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) для управления более широким состоянием «не проверять». Поскольку эти настройки применяются на уровне части текста, один абзац может содержать несколько языков и разных правил проверки.

В этой статье объясняется, как назначить язык определённому фрагменту текста, установить язык по умолчанию для нового текста с помощью [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), создавать многоязычные абзацы, выбирать между `SpellCheck` и `ProofDisabled`, а также сохранять нужные параметры при использовании [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Эти свойства хранят метаданные для приложений презентаций; они не переводят текст, не выполняют словарную проверку орфографии и не возвращают список ошибочно написанных слов.

## **Установка языка проверки для текста**

Создайте или загрузите [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/), получите нужный фрагмент текста через [IPortion.getPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#getPortionFormat--), и задайте его идентификатор языка. В следующем примере создаётся форма, задаётся британский английский как язык проверки, а результат сохраняется с помощью [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка языка по умолчанию для нового текста**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) для указания языка проверки, который Aspose.Slides будет присваивать только что созданному тексту. Эта настройка полезна, когда большинство или весь новый текст в презентации использует один и тот же язык. Она не меняет метаданные языка у уже существующего текста с явно указанным языком.

В следующем примере создаётся презентация, в которой новый текст использует немецкие правила проверки:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Использование нескольких языков в одном абзаце**

[IParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iparagraph/) содержит коллекцию фрагментов текста. Создайте отдельный [Portion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/portion/) для каждого языка и задайте его `LanguageId` независимо.

В этом примере создаётся один абзац с английскими и французскими фрагментами:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Включение или подавление проверки орфографии для отдельных фрагментов**

[IPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportionformat/) наследует общие текстовые свойства, определённые в [IBasePortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/). Получите формат фрагмента через [IPortion.getPortionFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iportion/#getPortionFormat--) и используйте [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) для управления тем, будет ли приложение презентации проверять орфографию этого фрагмента. Значение по умолчанию — `false`: `true` разрешает проверку, а `false` подавляет её.

Настройка применяется к отдельным фрагментам текста. Разные фрагменты в одном абзаце могут иметь разные значения. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) и `setSpellCheck` выполняют взаимодополняющие функции: `setLanguageId` указывает язык проверки, а `setSpellCheck` определяет, разрешена ли проверка орфографии для данного фрагмента.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) также управляет проверкой, но представляет более общее состояние «не проверять» как [NullableBool](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/nullablebool/). Используйте `setSpellCheck`, когда нужен простой переключатель Boolean именно для проверки орфографии. Используйте `setProofDisabled`, когда необходимо сохранить или явно управлять метаданными презентации о том, что проверка не производится, включая её состояние `NotDefined`. Если вы задаёте оба свойства, держите их значения согласованными; не комбинируйте `setSpellCheck(true)` с `setProofDisabled(NullableBool.True)`.

Эти свойства конфигурируют метаданные проверки, используемые PowerPoint и другими приложениями презентаций. Aspose.Slides не использует их для выполнения словарной проверки орфографии или возврата списка ошибочно написанных слов.

В следующем полном примере создаётся входная презентация, загружается, устанавливаются разные параметры проверки орфографии и языки проверки для двух фрагментов в одном абзаце, сохраняется результат, открывается снова и проверяются сохранённые значения:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) объединяет соседние фрагменты, имеющие одинаковое форматирование. Различие только в `SpellCheck` не сохраняет их раздельными; после объединения полученный фрагмент сохраняет значение `SpellCheck` первого фрагмента. Если фрагменты требуют разных настроек проверки орфографии, вызовите `joinPortionsWithSameFormatting` до назначения этих настроек либо проанализируйте границы полученного фрагмента и примените настройки повторно. Фрагменты с разными значениями `LanguageId` остаются отдельными, поскольку их форматирование языка проверки различается.

## **Вопросы и ответы**

**Переводит ли идентификатор языка текст?**

Нет. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) сохраняет метаданные проверки орфографии и грамматики; он не изменяет содержание текста. Переводите текст отдельно, а затем задавайте соответствующий идентификатор языка для каждого переведённого фрагмента.

**Контролирует ли язык проверки шрифты, переносы или перенесение строк?**

Нет. Идентификатор языка предназначен только для проверки. Отображение текста и разметка в основном зависят от доступных [шрифтов](/slides/ru/androidjava/powerpoint-fonts/), системы письма и настроек текстового кадра. Для надёжного отображения предоставьте необходимые шрифты, настройте [замену шрифтов](/slides/ru/androidjava/font-substitution/) или [встроенные шрифты](/slides/ru/androidjava/embedded-font/) в презентации.

**Можно ли в одном абзаце использовать несколько языков проверки?**

Да. Назначьте каждый язык отдельному фрагменту, как показано в примере многоязычного абзаца.

**Что использовать: `setDefaultTextLanguage` или `setLanguageId`?**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), когда нужен язык по умолчанию для только что создаваемого текста. Используйте [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), когда конкретному фрагменту требуется явно указанный язык проверки или когда абзац содержит несколько языков.