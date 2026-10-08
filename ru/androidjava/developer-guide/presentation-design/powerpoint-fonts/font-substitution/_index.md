---
title: Настройка подстановки шрифтов в презентациях на Android
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/androidjava/font-substitution/
keywords:
- шрифт
- заменяющий шрифт
- подстановка шрифтов
- замена шрифта
- замена шрифта
- правило подстановки
- правило замены
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Настройте правила подстановки шрифтов и проверьте подставленные шрифты в Aspose.Slides для Android через Java при рендеринге или конвертации презентаций."
---
## **Обзор**

Подстановка шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, который нельзя получить при рендеринге или конвертации презентации. Подстановка влияет только на отображаемый результат; она не изменяет шрифт, присвоенный содержимому презентации.

Вы можете определить шрифт, который будет использоваться, когда конкретный шрифт недоступен, а также просмотреть подстановки, которые Aspose.Slides выполнит во время рендеринга. Это помогает сохранять консистентность вывода на разных устройствах Android и в средах с различными доступными шрифтами.

Если шрифт доступен, но у него нет отдельного полужирного начертания, см. [Обработка шрифтов без отдельного полужирного начертания](/slides/ru/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). В этом разделе объясняется, как растеризовать затронутый текст при экспорте PDF и какие последствия это имеет для выделения текста, поиска и масштабирования.

## **Получить подстановки шрифтов**

Используйте метод [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) для определения, какие шрифты будут подставлены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/), которые указывают исходные и подставленные имена шрифтов.

Следующий пример на Java выводит все подстановки шрифтов для презентации:

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

## **Получить подстановки шрифтов для выбранных слайдов**

Используйте перегрузку [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) с аргументом `int[] slides`, чтобы просмотреть только те подстановки, которые необходимы для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, постепенно проверяете большую презентацию, находите слайды, зависящие от недоступных шрифтов, подготавливаете минимальный пакет шрифтов для Android‑приложения или диагностируете различия в рендеринге без обработки нерелевантных слайдов.

Массив `slides` содержит индексы слайдов, начинающиеся с единицы: `1` обозначает первый слайд. Для сравнения, доступ к коллекции через [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) использует нулевую индексацию, поэтому тот же слайд доступен как `presentation.getSlides().get_Item(0)`. Учтите это различие при построении массива, чтобы избежать ошибок смещения на один.

Вызовите перегрузку через метод [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--). Он возвращает только подстановки, определённые при рендеринге выбранных слайдов. Каждый результат — объект [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/), содержащий исходное и подставленное имя шрифта. Результат отражает текущую среду шрифтов, настроенные правила резервирования, правила подстановки, хранящиеся в [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/), и [внешне загруженные шрифты](/slides/ru/androidjava/custom-font/).

Одна и та же подстановка может потребоваться более чем одному выбранному слайду. Удаляйте дублирование результатов при создании инвентаризации шрифтов или отчёта предварительной проверки. Следующий пример выводит каждую полученную подстановку, а затем создаёт отсортированный список уникальных сопоставлений шрифтов:

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

Интерфейс [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) предоставляет обе перегрузки. Выберите одну в зависимости от области операции рендеринга:

| Перегрузка | Когда использовать |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Вам нужны подстановки для всей презентации. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Вам нужны подстановки для выбранного диапазона, постепенной проверки или частичного экспорта. |

## **Установить правила подстановки шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.
3. Создайте [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/).
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. Назначьте коллекцию, используя метод [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Выполните рендеринг или конвертацию презентации.

Следующий пример на Java заменяет `Arial` на `SomeRareFont`, когда `SomeRareFont` недоступен, а затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

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

{{% alert color="info" title="Note" %}}
Для безусловного изменения шрифтов, используемых во всей презентации, см. [Замена шрифтов](/slides/ru/androidjava/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила подстановки шрифтов являются частью стандартного процесса выбора шрифтов, используемого при рендеринге и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным шрифтом, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для вычисления и рендеринга макета уравнения. Правило, подставляющее другой математический шрифт, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы рендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Загрузите его как [внешний шрифт](/slides/ru/androidjava/custom-font/), чтобы приложение могло использовать его при рендеринге и конвертации.

Это ограничение относится к макету уравнений. Описанные выше правила подстановки по‑прежнему применимы к обычному тексту презентации.

## **Часто задаваемые вопросы**

**В чем разница между заменой шрифтов и их подстановкой?**

[Замена шрифтов](/slides/ru/androidjava/font-replacement/) сознательно меняет один шрифт на другой во всей презентации. Подстановка шрифтов выбирает шрифт для выводимого результата, когда выполнено настроенное условие, например когда исходный шрифт недоступен.

**Когда применяются правила подстановки?**

Правила участвуют в [последовательность выбора шрифтов](/slides/ru/androidjava/font-selection-sequence/) во время рендеринга и конвертации. При условии `WhenInaccessible` правило используется только когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, когда шрифт отсутствует и правило подстановки не настроено?**

Aspose.Slides выбирает ближайший доступный шрифт в соответствии со своим процессом выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Могу ли я загрузить внешние шрифты, чтобы избежать подстановки?**

Да. Вы можете [загрузить внешние шрифты](/slides/ru/androidjava/custom-font/), чтобы Aspose.Slides мог использовать их во время рендеринга и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы несёте ответственность за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки различаться между устройствами Android?**

Да. Доступные системные шрифты могут различаться между версиями Android, устройствами и производителями, поэтому шрифт, доступный в одной среде, может потребовать подстановки в другой.

**Как обеспечить согласованность выбора шрифтов на разных устройствах Android?**

Включите одинаковые необходимые файлы шрифтов в приложение, [загрузите их как внешние шрифты](/slides/ru/androidjava/custom-font/) и [встраивайте шрифты](/slides/ru/androidjava/embedded-font/) при наличии соответствующей лицензии. Вы также можете вызвать [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) перед экспортом, чтобы выявить неожиданные подстановки.