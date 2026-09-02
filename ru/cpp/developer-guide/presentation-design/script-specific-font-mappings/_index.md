---
title: Управление шрифтами темы, специфичными для скриптов, в C++
linktitle: Шрифты темы, специфические для скриптов
type: docs
weight: 15
url: /ru/cpp/script-specific-font-mappings/
keywords:
- шрифт, специфичный для скрипта
- сопоставление шрифта темы
- многоязычная презентация
- система письма
- кириллический шрифт
- арабский шрифт
- японский шрифт
- грузинский шрифт
- таана шрифт
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Просматривайте, добавляйте, заменяйте и удаляйте скрипт‑специфичные сопоставления шрифтов в темах PowerPoint с помощью Aspose.Slides для C++."
---
## **Обзор**

Тема презентации может выбирать различные семейства шрифтов для разных систем письма. Это позволяет использовать многоязычный текст, который всё равно использует шрифты темы, следуя единой согласованной схеме шрифтов, при этом применяя подходящие шрифты для кириллицы, арабского, японского, грузинского, таана и других сценариев.

Тема содержит объект [IFontScheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ifontscheme/), в котором есть основная коллекция шрифтов, обычно используемая для заголовков, и вспомогательная коллекция шрифтов, обычно используемая для основного текста. Помимо их свойств шрифтов для латиницы и Восточно‑азиатских наборов, обе коллекции предоставляют сопоставления от тегов систем письма к названиям семейств шрифтов через интерфейс [IFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifonts/).

В этой статье показано, как просматривать и изменять эти сопоставления в главной теме презентации и проверять, сохраняются ли изменения после сохранения и повторного открытия файла.

## **Понимание тегов скриптов**

Методы работы со шрифтами скриптов используют четырёхбуквенные под‑теги BCP 47 для идентификации систем письма. Общие значения включают:

| Тег скрипта | Система письма |
|---|---|
| `Cyrl` | Кириллическая |
| `Arab` | Арабская |
| `Hans` | Упрощённый китайский |
| `Jpan` | Японская |
| `Geor` | Грузинская |
| `Thaa` | Таана |

Эти сопоставления относятся к схеме шрифтов темы, а не к отдельным участкам текста. Презентация может задавать разные сопоставления для основной и вспомогательной коллекций, а также может не определять сопоставления для некоторых скриптов.

## **Доступ и просмотр сопоставлений шрифтов скриптов**

Используйте [Presentation::get_MasterTheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_mastertheme/) для получения темы уровня презентации. Методы [FontScheme::get_Major](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/fontscheme/get_major/) и [FontScheme::get_Minor](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/fontscheme/get_minor/) возвращают две коллекции [IFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifonts/).

Вызовите [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fonts/getscriptfontmap/) для получения всех сопоставлений из коллекции. Чтобы найти шрифт для конкретной системы письма, вызовите [Fonts::GetScriptFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fonts/getscriptfont/) с её тегом скрипта. `GetScriptFont` возвращает пустую строку, если в этой коллекции нет заданного сопоставления.

## **Изменение сопоставлений и проверка их сохранения**

Используйте [Fonts::SetScriptFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fonts/setscriptfont/) для создания сопоставления или замены текущего семейства шрифта. Для удаления сопоставления применяйте [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fonts/removescriptfont/).

Ниже показан сквозной пример, который читает все существующие основные и вспомогательные сопоставления, ищет основной шрифт для японского, меняет основной шрифт для кириллицы, удаляет вспомогательное сопоставление для таана, сохраняет презентацию и открывает её снова для проверки обеих изменений. Чтобы шаг удаления был независим от исходной темы, пример сначала создаёт сопоставление для таана только в том случае, если оно ещё не определено.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

Проверка использует то же поведение возврата пустой строки, что и обычный поиск: после сохранения удаления `GetScriptFont(u"Thaa")` возвращает пустую строку для вспомогательной коллекции.

## **Отличие сопоставлений темы от других настроек шрифтов**

Скрипт‑специфическое сопоставление шрифтов темы участвует в выборе шрифта, но решает другую задачу, чем прямое форматирование текста, подстановка и откат:

| Механизм | Назначение | Эффект изменения сопоставления темы |
|---|---|---|
| Скрипт‑специфическое сопоставление шрифтов темы | Выбирает основной или вспомогательный шрифт темы для системы письма. | Текст, который продолжает использовать соответствующий шрифт темы, может быть отображён с использованием нового сопоставленного семейства. |
| Шрифт, явно назначенный участку текста | Фиксирует запрашиваемое семейство шрифта для этого участка вместо использования темы. | Участок может остаться неизменным, потому что его прямое форматирование переопределяет выбор темы. |
| Подстановка шрифтов | Заменяет запрошенный шрифт, когда он недоступен или применяется правило подстановки. | Выполняется после запроса шрифта; не переопределяет скрипт‑сопоставление темы. |
| Откат шрифтов | Предоставляет глифы, которых нет в выбранном шрифте, обычно для определённых диапазонов Unicode. | Заполняет недостающие глифы; не меняет сохранённое сопоставление темы. |

Для получения дополнительной информации о последних двух механизмах см. [Font Substitution](/slides/ru/cpp/font-substitution/) и [Fallback Fonts](/slides/ru/cpp/fallback-font/).

Изменение сопоставления в [Presentation::get_MasterTheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_mastertheme/) влияет только на содержимое, чьё эффективное форматирование всё ещё зависит от этой темы. Текст может наследовать переопределённую тему от мастера, макета или слайда, либо использовать явно назначенный шрифт. Проверяйте эти уровни, когда видимый результат не соответствует сопоставлению уровня презентации.

## **Обеспечение доступности сопоставленных шрифтов и проверка результата**

Скрипт‑сопоставление хранит только название семейства шрифта; оно не устанавливает и не загружает соответствующий файл шрифта. Для согласованного рендеринга и экспорта каждый сопоставленный шрифт должен быть установлен в системе либо предоставлен Aspose.Slides через пользовательский источник, например [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsloader/loadexternalfonts/) или [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). Смотрите раздел [Custom Fonts](/slides/ru/cpp/custom-font/) для доступных вариантов загрузки.

Проверка сохранённого сопоставления подтверждает лишь то, что определение темы было сохранено. Это не доказывает, что шрифт доступен, содержит все необходимые глифы или обеспечивает ожидаемую разметку. Отрендерите представительный текст для каждой требуемой системы письма в изображение или PDF и проверьте результат. Это выявит отсутствующие шрифты, неполное покрытие глифов, поведение отката и изменения разметки до распространения презентации. См. [Convert PowerPoint Presentations](/slides/ru/cpp/convert-powerpoint/) для примеров рендеринга и экспорта.

## **FAQ**

**Что возвращает `GetScriptFont`, когда скрипт не сопоставлен?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fonts/getscriptfont/) возвращает пустую строку, когда запрашиваемое сопоставление скрипта не определено в этой основной или вспомогательной коллекции шрифтов.

**Добавляет ли `SetScriptFont` второе сопоставление, если скрипт уже существует?**

Нет. [Fonts::SetScriptFont](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fonts/setscriptfont/) создаёт сопоставление, если его нет, и заменяет существующее семейство шрифта, когда тег скрипта уже присутствует.

**Почему изменение сопоставления темы не изменило некоторый текст?**

Текст может иметь явно назначенный шрифт, наследовать другую тему через переопределение или подвергаться подстановке или откату при рендеринге. Сопоставление скрипта уровня презентации управляет только тем текстом, чьё эффективное форматирование всё ещё ссылается на эту коллекцию шрифтов темы.

**Достаточно ли сохранить и открыть файл заново для проверки многоязычного вывода?**

Нет. Повторное открытие подтверждает лишь сохранность данных темы. Кроме того, необходимо отрендерить представительный текст для каждой требуемой системы письма, чтобы убедиться, что сопоставленные шрифты доступны и содержат необходимые глифы.