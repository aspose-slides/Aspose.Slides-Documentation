---
title: Настройка подстановки шрифтов в презентациях с использованием Java
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/java/font-substitution/
keywords:
- шрифт
- заменяющий шрифт
- подстановка шрифта
- заменить шрифт
- замена шрифта
- правило подстановки
- правило замены
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Настройте правила подстановки шрифтов и проверьте заменённые шрифты в Aspose.Slides для Java при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Замена шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, который невозможно получить при рендеринге или конвертации презентации. Замена влияет только на вывод рендеринга; она не изменяет шрифт, назначенный содержимому презентации.

Вы можете определить шрифт, который будет использоваться, когда определённый шрифт недоступен, а также просмотреть замены, которые Aspose.Slides выполнит во время рендеринга. Это помогает сохранять консистентность вывода в разных средах с различными установленными шрифтами.

## **Получить замену шрифтов**

Используйте метод [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) для определения, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsubstitutioninfo/), которые содержат оригинальные и заменённые имена шрифтов.

Следующий пример на Java выводит все замены шрифтов для презентации:

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

Используйте перегрузку [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) с аргументом `int[] slides` для проверки только тех замен, которые необходимы для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, проверяете большую презентацию поэтапно, находите слайды, зависящие от недоступных шрифтов, подготавливаете минимальный пакет шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки несвязанных слайдов.

Массив `slides` содержит индексы слайдов, начинающиеся с 1: `1` обозначает первый слайд. В то время как доступ к коллекции через [Presentation.getSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSlides--) использует нулевую индексацию, поэтому тот же слайд доступен как `presentation.getSlides().get_Item(0)`. Учтите это различие при построении массива, чтобы избежать ошибок «на один».

Вызовите перегрузку через метод [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getFontsManager--). Он возвращает только те замены, которые определены при рендеринге выбранных слайдов. Каждый результат представляет собой объект [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsubstitutioninfo/), содержащий оригинальное и заменённое имя шрифта. Результат отражает текущую среду шрифтов, настроенные правила резервирования и [внешне загруженные шрифты](/slides/ru/java/custom-font/). Правила замены, хранящиеся в [IFontSubstRuleCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsubstrulecollection/), применяются при рендеринге презентации, но результат их не перечисляет; проверьте шрифты в выходном файле.

Одна и та же замена может потребоваться более чем одним выбранным слайдом. Удаляйте дубликаты результатов при создании инвентаризации шрифтов или отчёта предполетной проверки. Следующий пример выводит каждую возвращённую замену, а затем создаёт отсортированный список уникальных сопоставлений шрифтов:

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
| [getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) без аргументов | Вам нужны замены для всей презентации. |
| [getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) с `int[] slides` | Вам нужны замены для выбранного диапазона, поэтапной проверки или частичного экспорта. |

## **Установить правила замены шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.
3. Создайте объект [FontSubstRule](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsubstcondition/).
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsubstrulecollection/).
5. Назначьте коллекцию с помощью метода [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ru/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Выполните рендеринг или конвертацию презентации.

Следующий пример на Java заменяет `Arial` на `SomeRareFont` когда `SomeRareFont` недоступен, а затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен для Aspose.Slides.

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
Для безусловного изменения шрифтов, используемых во всей презентации, смотрите [Замена шрифтов](/slides/ru/java/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила замены шрифтов являются частью стандартного процесса выбора шрифтов, используемого при рендеринге и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным шрифтом, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребоваться именно этот шрифт для вычисления и рендеринга макета уравнения. Правило, заменяющее его другим математическим шрифтом, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что нужен **Cambria Math**.

Чтобы рендерить или конвертировать такую презентацию, обеспечьте доступность **Cambria Math** для Aspose.Slides. Установите его в операционной системе или загрузите как [внешний шрифт](/slides/ru/java/custom-font/).

Это ограничение относится к макету уравнения. Описанные выше правила замены по‑прежнему применимы к обычному тексту презентации.

## **FAQ**

**В чём разница между заменой шрифтов и их подстановкой?**

[Замена шрифтов](/slides/ru/java/font-replacement/) намеренно меняет один шрифт на другой во всей презентации. Замена шрифтов выбирает шрифт для выводимого результата, когда выполнено настроенное условие, например когда исходный шрифт недоступен.

**Когда применяются правила замены?**

Правила участвуют в [последовательности выбора шрифта](/slides/ru/java/font-selection-sequence/) во время рендеринга и конвертации. При `WhenInaccessible` правило используется только когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило замены не настроено?**

Aspose.Slides выбирает ближайший доступный шрифт в соответствии со своим процессом выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Могу ли я загрузить внешние шрифты, чтобы избежать замены?**

Да. Вы можете [загрузить внешние шрифты](/slides/ru/java/custom-font/), чтобы Aspose.Slides мог использовать их при рендеринге и конвертации.

**Поставляется ли шрифты вместе с библиотекой Aspose?**

Нет. Вы несёте ответственность за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты замены различаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места поиска шрифтов различаются в зависимости от операционной системы, поэтому шрифт, доступный на одной машине, может потребовать замены на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одни и те же файлы шрифтов и их версии на каждом компьютере или в контейнере, [загружайте необходимые внешние шрифты](/slides/ru/java/custom-font/) и [встраивайте шрифты](/slides/ru/java/embedded-font/) при наличии соответствующей лицензии. Также можно вызвать [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) перед экспортом, чтобы выявить неожиданные замены.