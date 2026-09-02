---
title: Настройка замены шрифтов в презентациях на C++
linktitle: Замена шрифтов
type: docs
weight: 70
url: /ru/cpp/font-substitution/
keywords:
- шрифт
- заменяющий шрифт
- замена шрифтов
- замена шрифта
- замена шрифта
- правило подстановки
- правило замены
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Настройте правила замены шрифтов и просмотрите заменённые шрифты в Aspose.Slides для C++ при рендеринге или конвертации презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Замена шрифтов позволяет Aspose.Slides использовать доступный шрифт вместо шрифта, к которому нельзя получить доступ при рендеринге или конвертации презентации. Замена влияет на выводимый результат; она не меняет шрифт, назначенный содержимому презентации.

Вы можете задать шрифт, который будет использоваться, когда конкретный шрифт недоступен, а также просмотреть замены, которые Aspose.Slides выполнит во время рендеринга. Это помогает поддерживать согласованность вывода в средах с разными установленными шрифтами.

## **Получить замену шрифтов**

Используйте метод [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/getsubstitutions/) для определения того, какие шрифты будут заменены при рендеринге презентации. Метод возвращает объекты [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsubstitutioninfo/), идентифицирующие оригинальные и заменённые имена шрифтов.

Следующий пример на C++ выводит все замены шрифтов для презентации:

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

## **Получить замену шрифтов для выбранных слайдов**

Используйте перегрузку [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/getsubstitutions/) с аргументом `System::ArrayPtr<int32_t> slides` для проверки только тех замен, которые требуются для рендеринга конкретных слайдов. Это полезно, когда вы рендерите или экспортируете часть презентации, проверяете большую презентацию поэтапно, ищете слайды, зависящие от недоступных шрифтов, подготавливаете минимальный пакет шрифтов для сервера или контейнера, либо диагностируете различия в рендеринге без обработки ненужных слайдов.

Массив `slides` содержит индексы слайдов, начинающиеся с единицы: `1` указывает на первый слайд. В отличие от этого, метод [Presentation::get_Slide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_slide/) использует нулевой индекс, поэтому тот же слайд доступен как `presentation->get_Slide(0)`. Учтите это различие при формировании массива, чтобы избежать ошибок «на один больше/меньше».

Вызовите перегрузку через метод [Presentation::get_FontsManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_fontsmanager/). Он возвращает только те замены, которые определены во время рендеринга выбранных слайдов. Каждый результат — объект [FontSubstitutionInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsubstitutioninfo/), содержащий оригинальное и заменённое имя шрифта. Результат отражает текущую среду шрифтов, настроенные правила резервирования, правила замены, хранящиеся в [IFontSubstRuleCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsubstrulecollection/), и [внешне загруженные шрифты](/slides/ru/cpp/custom-font/).

Одна и та же замена может потребоваться более чем одному выбранному слайду. Удалите дубликаты результатов, когда создаёте инвентарь шрифтов или отчёт о проверке. Следующий пример выводит каждую полученную замену, а затем создаёт отсортированный список уникальных сопоставлений шрифтов:

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

Интерфейс [IFontsManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/) предоставляет обе перегрузки. Выберите одну в зависимости от объёма операции рендеринга:

| Перегрузка | Когда использовать |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/getsubstitutions/) без аргументов | Нужно получить замены для всей презентации. |
| [GetSubstitutions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/getsubstitutions/) с `System::ArrayPtr<int32_t> slides` | Нужно получить замены для выбранного диапазона, поэтапной проверки или частичного экспорта. |

## **Задать правила замены шрифтов**

Чтобы указать шрифт, который Aspose.Slides должен использовать, когда исходный шрифт недоступен:

1. Загрузите презентацию.  
2. Создайте определения шрифтов для исходного и заменяющего шрифтов.  
3. Создайте [FontSubstRule](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsubstrule/) с условием [WhenInaccessible](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsubstcondition/).  
4. Добавьте правило в [FontSubstRuleCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsubstrulecollection/).  
5. Назначьте коллекцию, используя метод [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).  
6. Выполните рендеринг или конвертацию презентации.

Следующий пример на C++ заменяет `Arial` на `SomeRareFont`, когда `SomeRareFont` недоступен, а затем рендерит первый слайд для проверки результата. Заменяющий шрифт должен быть доступен Aspose.Slides.

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

Уравнения Office Math имеют дополнительное требование. Если уравнение использует **Cambria Math**, Aspose.Slides может потребоваться именно этот шрифт для вычисления и рендеринга макета уравнения. Правило, заменяющее другой математический шрифт, например **STIX Two Math**, не может заменить **Cambria Math** для этой цели, и рендеринг всё равно может сообщать, что требуется **Cambria Math**.

Чтобы рендерить или конвертировать такую презентацию, сделайте **Cambria Math** доступным для Aspose.Slides. Установите его в операционной системе или загрузите как [внешний шрифт](/slides/ru/cpp/custom-font/).

Это ограничение относится к макету уравнений. Описанные выше правила замены продолжают действовать для обычного текста презентации.

## **FAQ**

**В чём разница между заменой шрифтов и их подстановкой?**

[Font replacement](/slides/ru/cpp/font-replacement/) намеренно меняет один шрифт на другой по всей презентации. Подстановка шрифтов выбирает шрифт для рендеринга, когда выполнено заданное условие, например когда оригинальный шрифт недоступен.

**Когда применяются правила подстановки?**

Правила участвуют в [последовательности выбора шрифта](/slides/ru/cpp/font-selection-sequence/) во время рендеринга и конвертации. При условии `WhenInaccessible` правило используется только когда Aspose.Slides не может получить доступ к исходному шрифту.

**Что происходит, если шрифт отсутствует и правило подстановки не настроено?**

Aspose.Slides выбирает ближайший доступный шрифт согласно своему процессу выбора шрифтов. Результат зависит от шрифтов, доступных в среде выполнения.

**Могу ли я загрузить внешние шрифты, чтобы избежать подстановки?**

Да. Вы можете [загрузить внешние шрифты](/slides/ru/cpp/custom-font/), чтобы Aspose.Slides использовал их при рендеринге и конвертации.

**Поставляет ли Aspose шрифты вместе с библиотекой?**

Нет. Вы отвечаете за предоставление шрифтов и соблюдение их лицензий.

**Могут ли результаты подстановки отличаться между Windows, Linux и macOS?**

Да. Установленные шрифты и места их поиска различаются в зависимости от операционной системы, поэтому шрифт, доступный на одной машине, может потребовать подстановки на другой.

**Как обеспечить согласованность выбора шрифтов при пакетных конверсиях?**

Используйте одинаковые файлы шрифтов и их версии на каждой машине или в контейнере, [загружайте необходимые внешние шрифты](/slides/ru/cpp/custom-font/) и [встраивайте шрифты](/slides/ru/cpp/embedded-font/), если лицензия это позволяет. Также можно вызвать [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifontsmanager/getsubstitutions/) перед экспортом, чтобы выявить неожиданные подстановки.