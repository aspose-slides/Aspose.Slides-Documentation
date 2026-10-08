---
title: Настройка замены шрифтов в презентациях с использованием Java
linktitle: Замена шрифтов
type: docs
weight: 70
url: /ru/java/font-substitution/
keywords:
- шрифт
- замена шрифта
- замена шрифтов
- заменить шрифт
- замена шрифта
- правило замены
- правило замены
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Настройте правила замены шрифтов и проверьте заменённые шрифты в Aspose.Slides для Java при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Замена шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому нельзя получить доступ при рендеринге или преобразовании презентации. Замена влияет только на отрисованный вывод; она не изменяет шрифт, назначенный содержимому презентации.

Вы можете указать шрифт, который следует использовать, когда определённый шрифт недоступен, а также просматривать замены, которые Aspose.Slides выполнит во время рендеринга. Это помогает поддерживать согласованность вывода в средах с разными установленными шрифтами.

Если шрифт доступен, но у него нет отдельного жирного начертания, см. [Обработка шрифтов без отдельного жирного начертания](/slides/ru/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). В этом разделе объясняется, как растеризовать затронутый текст при экспорте в PDF и какие последствия это имеет для выбора текста, поиска и масштабирования.

## **Получение замен шрифтов**

Используйте метод [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) для определения, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/), содержащие оригинальные и заменённые имена шрифтов.

Ниже приведён пример на Java, выводящий все замены шрифтов для презентации:

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

## **Получение замен шрифтов для выбранных слайдов**

Используйте перегрузку [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) с аргументом `int[] slides`, чтобы просматривать только замены, необходимые для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, проверяете большую презентацию поэтапно, определяете слайды, зависящие от недоступных шрифтов, подготавливаете минимальный пакет шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки нерелевантных слайдов.

Массив `slides` содержит индексы слайдов, начиная с 1: `1` обозначает первый слайд. В то время как доступ к коллекции [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) использует нулевую индексацию, поэтому тот же слайд доступен как `presentation.getSlides().get_Item(0)`. Учитывайте эту разницу при построении массива, чтобы избежать ошибок «на‑один вперёд/назад».

Вызовите перегрузку через метод [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) . Он возвращает только те замены, которые определены во время рендеринга выбранных слайдов. Каждый результат — объект [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/), содержащий оригинальное и заменённое имя шрифта. Результат отражает текущую среду шрифтов, настроенные правила fallback и [внешне загруженные шрифты](/slides/ru/java/custom-font/). Правила замены, хранящиеся в [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/), применяются при рендеринге презентации, но они не выводятся в результате; проверьте шрифты в выходном файле.

Одна и та же замена может потребоваться более чем одному выбранному слайду. Удалите дубликаты из результатов при формировании инвентаря шрифтов или отчёта о проверке. Ниже приведён пример, который выводит каждую найденную замену, а затем создаёт отсортированный список уникальных сопоставлений шрифтов:

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

Интерфейс [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) предоставляет обе перегрузки. Выбирайте подходящую в зависимости от объёма операции рендеринга:

| Перегрузка | Когда использовать |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) без аргументов | Требуются замены для всей презентации. |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) с `int[] slides` | Требуются замены для выбранного диапазона, поэтапной проверки или частичного экспорта. |

## **Установка правил замены шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.  
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.  
3. Создайте объект [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/).  
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/).  
5. Присвойте коллекцию, используя метод [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. Выполните рендеринг или преобразование презентации.

Ниже пример на Java, заменяющий `Arial` на `SomeRareFont`, когда `SomeRareFont` недоступен, а затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

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
Для безусловного изменения шрифтов, используемых по всей презентации, см. [Замена шрифтов](/slides/ru/java/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила замены шрифтов являются частью стандартного процесса выбора шрифтов, используемого при рендеринге и преобразовании. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным шрифтом, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для вычисления и рендеринга макета уравнения. Правило, заменяющее шрифт на другой математический шрифт, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сигнализировать, что требуется **Cambria Math**.

Чтобы рендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [внешний шрифт](/slides/ru/java/custom-font/).

Это ограничение относится к макету уравнений. Описанные выше правила замены продолжают применяться к обычному тексту презентации.

## **FAQ**

**В чём разница между заменой шрифтов и их заменой?**

[Font replacement](/slides/ru/java/font-replacement/) намеренно меняет один шрифт на другой по всей презентации. Замена шрифтов выбирает шрифт для отрисованного вывода, когда выполнено настроенное условие, например когда исходный шрифт недоступен.

**Когда применяются правила замены?**

Правила участвуют в [последовательности выбора шрифта](/slides/ru/java/font-selection-sequence/) во время рендеринга и конвертации. При условии `WhenInaccessible` правило используется только когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило замены не настроено?**

Aspose.Slides выбирает самый близкий доступный шрифт согласно своему процессу выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Могу ли я загрузить внешние шрифты, чтобы избежать замены?**

Да. Вы можете [загружать внешние шрифты](/slides/ru/java/custom-font/), чтобы Aspose.Slides использовал их при рендеринге и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы отвечаете за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты замены различаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места их поиска различаются в зависимости от операционной системы, поэтому шрифт, доступный на одной машине, может потребовать замену на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одинаковые файлы шрифтов и их версии на каждой машине или в контейнере, [загружайте требуемые внешние шрифты](/slides/ru/java/custom-font/), и [встраивайте шрифты](/slides/ru/java/embedded-font/), если лицензия это позволяет. Вы также можете вызвать [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) перед экспортом, чтобы выявить неожиданные замены.