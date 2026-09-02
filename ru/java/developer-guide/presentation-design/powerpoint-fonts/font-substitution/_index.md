---
title: Настройка подстановки шрифтов в презентациях с использованием Java
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/java/font-substitution/
keywords:
- шрифт
- заменяющий шрифт
- подстановка шрифтов
- замена шрифта
- замена шрифтов
- правило подстановки
- правило замены
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Настройте правила подстановки шрифтов и просмотрите подставленные шрифты в Aspose.Slides для Java при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Подстановка шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому нельзя получить доступ при рендеринге или конвертации презентации. Подстановка влияет только на вывод рендеринга; она не меняет шрифт, назначенный содержимому презентации.

Вы можете определить шрифт, который будет использоваться, когда определённый шрифт недоступен, а также просмотреть подстановки, которые Aspose.Slides выполнит во время рендеринга. Это помогает поддерживать согласованность вывода в разных средах с различными установленными шрифтами.

## **Получить подстановки шрифтов**

Используйте метод [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) для определения того, какие шрифты будут подменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsubstitutioninfo/), которые идентифицируют оригинальные и подставленные имена шрифтов.

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

Используйте перегрузку [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) с аргументом `int[] slides`, чтобы просмотреть только подстановки, необходимые для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, инкрементно проверяете большую презентацию, находите слайды, зависящие от недоступных шрифтов, готовите минимальный пакет шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки ненужных слайдов.

Массив `slides` содержит индексы слайдов, начиная с 1: `1` обозначает первый слайд. В отличие от этого, accessor коллекции [Presentation.getSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSlides--) использует нулевую индексацию, поэтому тот же слайд доступен как `presentation.getSlides().get_Item(0)`. Учтите это различие при построении массива, чтобы избежать ошибок смещения на один.

Вызовите перегрузку через метод [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getFontsManager--). Он возвращает только подстановки, определённые при рендеринге выбранных слайдов. Каждый результат представляет собой объект [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsubstitutioninfo/), содержащий оригинальные и подставленные имена шрифтов. Результат отражает текущую среду шрифтов, настроенные правила резервирования, правила подстановки, хранящиеся в [IFontSubstRuleCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsubstrulecollection/), и [внешно загруженные шрифты](/slides/ru/java/custom-font/).

Одна и та же подстановка может потребоваться более чем одному выбранному слайду. Удаляйте дубликаты результатов при создании инвентаризации шрифтов или отчёта о проверке. В следующем примере выводятся все полученные подстановки, а затем создаётся отсортированный список уникальных сопоставлений шрифтов:

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

Интерфейс [IFontsManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/) предоставляет обе перегрузки. Выберите одну в зависимости от объёма операции рендеринга:

| Перегрузка | Когда использовать |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) без аргументов | Вам нужны подстановки для всей презентации. |
| [getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) с `int[] slides` | Вам нужны подстановки для выбранного диапазона, инкрементной проверки или частного экспорта. |

## **Установить правила подстановки шрифтов**

Для указания шрифта, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.
3. Создайте [FontSubstRule](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsubstcondition/).
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsubstrulecollection/).
5. Назначьте коллекцию, используя метод [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Выполните рендеринг или конвертацию презентации.

В следующем примере на Java шрифт `Arial` используется вместо `SomeRareFont`, когда `SomeRareFont` недоступен, после чего рендерится первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

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
Для безусловного изменения шрифтов, используемых по всей презентации, см. [Font Replacement](/slides/ru/java/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила подстановки шрифтов являются частью стандартного процесса выбора шрифтов, используемого при рендеринге и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным шрифтом, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если в уравнении используется **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для расчёта и рендеринга макета уравнения. Правило, заменяющее на другой математический шрифт, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы отрендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [внешний шрифт](/slides/ru/java/custom-font/).

Это ограничение относится к макету уравнений. Описанные выше правила подстановки по‑прежнему применимы к обычному тексту презентации.

## **Часто задаваемые вопросы**

**В чём разница между заменой шрифтов и их подстановкой?**

[Font replacement](/slides/ru/java/font-replacement/) намеренно меняет один шрифт на другой по всей презентации. Подстановка шрифтов выбирает шрифт для вывода рендеринга, когда выполнено настроенное условие, например когда оригинальный шрифт недоступен.

**Когда применяются правила подстановки?**

Правила участвуют в [последовательности выбора шрифта](/slides/ru/java/font-selection-sequence/) во время рендеринга и конвертации. При условии `WhenInaccessible` правило используется только тогда, когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило подстановки не настроено?**

Aspose.Slides выбирает наиболее подходящий доступный шрифт в соответствии со своим процессом выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Можно ли загрузить внешние шрифты, чтобы избежать подстановки?**

Да. Вы можете [загружать внешние шрифты](/slides/ru/java/custom-font/), чтобы Aspose.Slides мог использовать их во время рендеринга и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы несёте ответственность за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки отличаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места их поиска различаются в разных операционных системах, поэтому шрифт, доступный на одной машине, может потребовать подстановки на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одинаковые файлы шрифтов и их версии на каждом компьютере или в контейнере, [загружайте необходимые внешние шрифты](/slides/ru/java/custom-font/), и [встраивайте шрифты](/slides/ru/java/embedded-font/), если лицензия позволяет. Вы также можете вызвать [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) перед экспортом, чтобы определить неожиданные подстановки.