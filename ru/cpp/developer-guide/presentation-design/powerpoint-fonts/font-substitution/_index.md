---
title: Настройка подстановки шрифтов в презентациях на C++
linktitle: Подстановка шрифтов
type: docs
weight: 70
url: /ru/cpp/font-substitution/
keywords:
- шрифт
- замена шрифта
- подстановка шрифтов
- заменить шрифт
- замена шрифтов
- правило подстановки
- правило замены
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Настройте правила подстановки шрифтов и проверьте заменённые шрифты в Aspose.Slides для C++ при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Замена шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому невозможно получить доступ при рендеринге или конвертации презентации. Замена влияет на вывод рендеринга; она не изменяет шрифт, присвоенный содержимому презентации.

Вы можете определить шрифт, который будет использоваться, когда определённый шрифт недоступен, и просматривать замены, которые Aspose.Slides выполнит во время рендеринга. Это помогает сохранять согласованность вывода в разных средах с различными установленными шрифтами.

Если шрифт доступен, но у него нет отдельного полужирного начертания, см. [Обработка шрифтов без отдельного полужирного начертания](/slides/ru/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Этот раздел объясняет, как растеризовать затронутый текст во время экспорта в PDF и какие последствия это имеет для выделения текста, поиска и масштабирования.

## **Получение замен шрифтов**

Используйте метод [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) для определения, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/), которые определяют оригинальные и заменённые имена шрифтов.

В следующем примере C++ перечислены все замены шрифтов для презентации:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Получение замен шрифтов для выбранных слайдов**

Используйте перегрузку метода [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) с аргументом `System::ArrayPtr<int32_t> slides`, чтобы просматривать только те замены, которые необходимы для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, постепенно проверяете большую презентацию, находите слайды, зависящие от недоступных шрифтов, готовите минимальный пакет шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки несвязанных слайдов.

Массив `slides` содержит индексы слайдов, начинающиеся с единицы: `1` обозначает первый слайд. В отличие от этого, метод [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) использует нулевой индекс, поэтому тот же слайд доступен как `presentation->get_Slide(0)`. Учтите эту разницу при формировании массива, чтобы избежать ошибок смещения на один.

Вызовите перегрузку через метод [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/). Он возвращает только те замены, которые были определены при рендеринге выбранных слайдов. Каждый результат представляет собой объект [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/), содержащий оригинальные и заменённые имена шрифтов. Результат отражает текущую среду шрифтов, настроенные правила резервирования, правила замены, хранящиеся в [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/), и [внешне загруженные шрифты](/slides/ru/cpp/custom-font/).

Одну и ту же замену может потребовать более одного выбранного слайда. Удаляйте дубликаты результатов при создании инвентаризации шрифтов или отчёта предусмотра. В следующем примере выводятся все полученные замены, а затем создаётся отсортированный список уникальных сопоставлений шрифтов:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

Интерфейс [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) предоставляет обе перегрузки. Выберите одну в зависимости от области операции рендеринга:

| Перегрузка | Когда использовать |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Вам нужны замены для всей презентации. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | Вам нужны замены для выбранного диапазона, инкрементной проверки или частичного экспорта. |

## **Установка правил замены шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.  
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.  
3. Создайте объект [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/).  
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/).  
5. Назначьте коллекцию, используя метод [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).  
6. Выполните рендеринг или конвертацию презентации.

В следующем примере C++ заменяется шрифт `SomeRareFont` шрифтом `Arial` при отсутствии `SomeRareFont`, после чего рендерится первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Для безусловного изменения шрифтов, используемых во всей презентации, см. [Font Replacement](/slides/ru/cpp/font-replacement/).
{{% /alert %}}

## **Ограничения для шрифтов математических уравнений**

Правила замены шрифтов являются частью стандартного процесса выбора шрифтов, используемого при рендеринге и конвертации. Они работают для обычного текста, когда Aspose.Slides может заменить недоступный шрифт доступным шрифтом, указанным в правиле.

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребовать именно этот шрифт для вычисления и рендеринга макета уравнения. Правило, заменяющее его другим математическим шрифтом, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы отрендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [внешний шрифт](/slides/ru/cpp/custom-font/).

Это ограничение относится к макету уравнений. Описанные выше правила замены по‑прежнему применяются к обычному тексту презентации.

## **Часто задаваемые вопросы**

**В чём разница между заменой шрифтов и их подстановкой?**

[Font replacement](/slides/ru/cpp/font-replacement/) намеренно изменяет один шрифт на другой во всей презентации. Замена шрифтов выбирает шрифт для рендеринга вывода, когда выполнено настроенное условие, например, когда оригинальный шрифт недоступен.

**Когда применяются правила замены?**

Правила участвуют в [font selection sequence](/slides/ru/cpp/font-selection-sequence/) во время рендеринга и конвертации. При `WhenInaccessible` правило используется только тогда, когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило замены не настроено?**

Aspose.Slides выбирает наиболее подходящий доступный шрифт в соответствии со своим процессом выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Можно ли загрузить внешние шрифты, чтобы избежать подстановки?**

Да. Вы можете [загрузить внешние шрифты](/slides/ru/cpp/custom-font/), чтобы Aspose.Slides мог использовать их во время рендеринга и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы отвечаете за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки отличаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места их поиска различаются в зависимости от операционной системы, поэтому шрифт, доступный на одном компьютере, может потребовать подстановки на другом.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одинаковые файлы шрифтов и их версии на каждой машине или в контейнере, [загружайте необходимые внешние шрифты](/slides/ru/cpp/custom-font/), и [встраивайте шрифты](/slides/ru/cpp/embedded-font/), когда лицензия позволяет. Вы также можете вызвать [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) перед экспортом, чтобы выявить неожиданные подстановки.