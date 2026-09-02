---
title: Настройка замены шрифтов в презентациях на Android
linktitle: Замена шрифтов
type: docs
weight: 70
url: /ru/androidjava/font-substitution/
keywords:
- шрифт
- заменяющий шрифт
- замена шрифта
- замена шрифта
- замена шрифта
- правило замены
- правило замены
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Настройте правила замены шрифтов и проверьте заменённые шрифты в Aspose.Slides для Android через Java при рендеринге или конвертации презентаций."
---
## **Обзор**

Замена шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, который невозможно получить при рендеринге или конвертации презентации. Замена влияет только на отрендеренный вывод; она не меняет шрифт, назначенный содержимому презентации.

Вы можете задать шрифт, который будет использоваться, когда конкретный шрифт недоступен, и можете просмотреть замены, которые Aspose.Slides выполнит во время рендеринга. Это помогает поддерживать согласованный вывод на устройствах Android и в средах с различными доступными шрифтами.

## **Получить замену шрифтов**

Используйте метод [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) для определения, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsubstitutioninfo/), содержащие оригинальные и заменённые имена шрифтов.

Ниже пример на Java, перечисляющий все замены шрифтов для презентации:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Получить замену шрифтов для выбранных слайдов**

Используйте перегруженный вариант [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) с аргументом `int[] slides`, чтобы просмотреть только те замены, которые требуются для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, проверяете большую презентацию по частям, ищете слайды, зависящие от недоступных шрифтов, подготавливаете минимальный пакет шрифтов для Android‑приложения или диагностируете различия в рендеринге без обработки нерелевантных слайдов.

Массив `slides` содержит индексы слайдов, начиная с единицы: `1` обозначает первый слайд. В отличие от этого, аксессор коллекции [Presentation.getSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getSlides--) использует нулевую индексацию, поэтому тот же слайд доступен как `presentation.getSlides().get_Item(0)`. Учтите это различие при построении массива, чтобы избежать ошибок «на один меньше/больше».

Вызов перегруженного метода производится через [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getFontsManager--) . Он возвращает только те замены, которые были определены во время рендеринга выбранных слайдов. Каждый результат — объект [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsubstitutioninfo/), содержащий оригинальное и заменённое имя шрифта. Результат отражает текущую среду шрифтов, настроенные правила резервирования, правила замены, хранящиеся в [IFontSubstRuleCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontsubstrulecollection/), и [внешне загруженные шрифты](/slides/ru/androidjava/custom-font/).

Одна и та же замена может потребоваться более чем одному выбранному слайду. Удаляйте дубли при формировании инвентаризации шрифтов или отчёта о предварительной проверке. Ниже пример, который выводит каждую найденную замену, а затем создаёт отсортированный список уникальных сопоставлений шрифтов:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

Интерфейс [IFontsManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontsmanager/) предоставляет оба перегруженных метода. Выберите тот, который соответствует области применения операции рендеринга:

| Перегрузка | Когда использовать |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) без аргументов | Вам нужны замены для всей презентации. |
| [getSubstitutions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) с `int[] slides` | Вам нужны замены для выбранного диапазона, инкрементной проверки или частичного экспорта. |

## **Задать правила замены шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.  
2. Создайте определения шрифтов для исходного и заменяющего шрифта.  
3. Создайте объект [FontSubstRule](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsubstcondition/).  
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsubstrulecollection/).  
5. Назначьте коллекцию с помощью метода [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Выполните рендеринг или конвертацию презентации.

Ниже пример на Java, заменяющий `Arial` на `SomeRareFont`, когда `SomeRareFont` недоступен, и затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Примечание" %}}
Для безусловного изменения шрифтов, используемых во всей презентации, смотрите раздел [Font Replacement](/slides/ru/androidjava/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила замены шрифтов являются частью стандартного процесса выбора шрифта, используемого при рендеринге и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт на указанный в правиле доступный шрифт.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для вычисления и рендеринга макета уравнения. Правило, заменяющее его на другой математический шрифт, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы рендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Загрузите его как [внешний шрифт](/slides/ru/androidjava/custom-font/), чтобы приложение могло использовать его во время рендеринга и конвертации.

Это ограничение относится к макету уравнений. Правила замены, описанные выше, по‑прежнему применяются к обычному тексту презентации.

## **FAQ**

**В чём разница между заменой шрифтов и их заменой (replacement)?**

[Font replacement](/slides/ru/androidjava/font-replacement/) намеренно меняет один шрифт на другой во всей презентации. Замена шрифтов (substitution) выбирает шрифт для отрендеренного вывода, когда выполнено условие, например когда оригинальный шрифт недоступен.

**Когда применяются правила замены?**

Правила участвуют в [последовательности выбора шрифта](/slides/ru/androidjava/font-selection-sequence/) во время рендеринга и конвертации. При условии `WhenInaccessible` правило используется только когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило замены не задано?**

Aspose.Slides выбирает наиболее подходящий доступный шрифт согласно своему процессу выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Можно ли загрузить внешние шрифты, чтобы избежать замены?**

Да. Вы можете [загрузить внешние шрифты](/slides/ru/androidjava/custom-font/), чтобы Aspose.Slides мог использовать их во время рендеринга и конвертации.

**Распространяет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы отвечаете за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты замены различаться между устройствами Android?**

Да. Доступные системные шрифты могут различаться между версиями Android, устройствами и производителями, поэтому шрифт, доступный в одной среде, может требовать замены в другой.

**Как обеспечить согласованность выбора шрифтов на разных устройствах Android?**

Пакуйте одинаковые необходимые файлы шрифтов вместе с приложением, [загружайте их как внешние шрифты](/slides/ru/androidjava/custom-font/), и [встраивайте шрифты](/slides/ru/androidjava/embedded-font/), если лицензия это позволяет. Вы также можете вызвать [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) перед экспортом, чтобы выявить неожиданные замены.