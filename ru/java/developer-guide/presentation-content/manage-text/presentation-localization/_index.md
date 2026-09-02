---
title: Автоматизация локализации презентаций в Java
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/java/presentation-localization/
keywords:
- изменение языка
- проверка орфографии
- подавление проверки орфографии
- язык корректуры
- идентификатор языка
- многоязычный текст
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Устанавливайте языки корректуры для текста презентаций PowerPoint и OpenDocument в Java с помощью Aspose.Slides, включая настройки по умолчанию и многоязычные абзацы."
---
## **Обзор**

Aspose.Slides for Java позволяет настраивать метаданные корректуры для отдельных текстовых фрагментов. Используйте [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) для указания языка корректуры, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) — для разрешения или подавления проверки орфографии, и [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) — для управления более широким состоянием «не выполнять корректуру». Поскольку эти параметры применяются на уровне фрагмента, один абзац может содержать несколько языков и разных правил корректуры.

В этой статье объясняется, как назначить язык конкретному тексту, задать язык по умолчанию для нового текста с помощью [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), создавать многоязычные абзацы, выбирать между `SpellCheck` и `ProofDisabled`, а также сохранять заданные параметры при использовании [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Эти свойства хранят метаданные для приложений презентаций; они не переводят текст, не выполняют проверку орфографии по словарю и не возвращают ошибки орфографии.

## **Установить язык корректуры для текста**

Создайте или загрузите [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/), получите нужный текстовый фрагмент через [IPortion.getPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/#getPortionFormat--) и задайте его идентификатор языка. В следующем примере создаётся фигура, устанавливается британский английский как язык корректуры и результат сохраняется с помощью [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#save-java.lang.String-int-):

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

## **Установить язык по умолчанию для нового текста**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) для указания языка корректуры, который Aspose.Slides присваивает вновь создаваемому тексту. Эта настройка полезна, когда большинство или весь новый текст в презентации использует один и тот же язык. Она не изменяет метаданные языка текста, у которого уже явно указан язык.

В следующем примере создаётся презентация, в которой новый текст использует немецкие правила корректуры:

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

## **Использовать несколько языков в одном абзаце**

Объект [IParagraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/) содержит коллекцию текстовых фрагментов. Создайте отдельный [Portion](https://reference.aspose.com/slides/ru/java/com.aspose.slides/portion/) для каждого языка и задайте его `LanguageId` независимо.

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

## **Включить или подавить проверку орфографии для отдельных фрагментов**

[IPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportionformat/) наследует общие свойства текста, определённые в [IBasePortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/). Доступ к формату фрагмента осуществляется через [IPortion.getPortionFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iportion/#getPortionFormat--), а с помощью [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) можно управлять тем, будет ли приложение презентации проверять орфографию этого фрагмента. Значение по умолчанию — `false`: `true` разрешает проверку орфографии, а `false` её подавляет.

Эта настройка применяется к отдельным текстовым фрагментам. Поэтому разные фрагменты в одном абзаце могут иметь разные значения. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) и `setSpellCheck` выполняют взаимодополняющие функции: `setLanguageId` указывает язык корректуры, а `setSpellCheck` определяет, разрешена ли проверка орфографии для фрагмента.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) также управляет корректурой, но представляет более общее состояние «не выполнять корректуру» как [NullableBool](https://reference.aspose.com/slides/ru/java/com.aspose.slides/nullablebool/). Используйте `setSpellCheck`, когда нужен прямой логический переключатель именно для проверки орфографии. Используйте `setProofDisabled`, когда необходимо сохранить или явно управлять метаданными «не корректировать» презентации, включая состояние `NotDefined`. Если задаёте оба свойства, поддерживайте их значения согласованными; не сочетайте `setSpellCheck(true)` с `setProofDisabled(NullableBool.True)`.

Эти свойства настраивают метаданные корректуры, используемые PowerPoint и другими приложениями презентаций. Aspose.Slides не использует их для выполнения словарной проверки орфографии или возврата списка ошибок.

В следующем полном примере создаётся входная презентация, загружается, двум фрагментам в одном абзаце назначаются разные настройки проверки орфографии и языки корректуры, результат сохраняется, открывается повторно и проверяются сохранённые значения:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) объединяет соседние фрагменты с одинаковым форматированием. Одно лишь различие в `SpellCheck` не сохраняет такие фрагменты раздельными; после их объединения полученный фрагмент сохраняет значение `SpellCheck` первого фрагмента. Если фрагменты требуют разных настроек проверки орфографии, вызывайте `joinPortionsWithSameFormatting` до назначения этих настроек, либо проанализируйте границы полученного фрагмента и примените настройки повторно. Фрагменты с разными значениями `LanguageId` остаются раздельными, поскольку их форматирование языка корректуры отличается.

## **Часто задаваемые вопросы**

**Переводит ли идентификатор языка текст?**

Нет. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) сохраняет метаданные корректуры для орфографии и грамматики; он не изменяет содержимое текста. Переведите текст отдельно, а затем задайте соответствующий идентификатор языка для каждого переведённого фрагмента.

**Контролирует ли язык корректуры шрифты, переносы или перенос строк?**

Нет. Идентификатор языка предназначен только для корректуры. Отображение и разметка текста в основном зависят от доступных [fonts](/slides/ru/java/powerpoint-fonts/), системы письма и настроек текстового фрейма. Для надёжного отображения предоставьте необходимые шрифты, настройте [font substitution](/slides/ru/java/font-substitution/) или [embed fonts](/slides/ru/java/embedded-font/) в презентации.

**Может ли один абзац использовать несколько языков корректуры?**

Да. Назначьте каждый язык отдельному фрагменту, как показано в примере многоязычного абзаца.

**Следует ли использовать `setDefaultTextLanguage` или `setLanguageId`?**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), когда нужен язык по умолчанию для вновь создаваемого текста. Используйте [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), когда конкретному фрагменту нужен явно указанный язык корректуры или когда абзац содержит несколько языков.