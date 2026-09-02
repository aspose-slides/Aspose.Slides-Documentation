---
title: Получить и обновить информацию о презентации на C++
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/cpp/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- прочитать свойства
- изменить свойства
- модифицировать свойства
- обновить свойства
- анализ PPTX
- анализ PPT
- анализ ODP
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Исследуйте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью C++ для более быстрых инсайтов и интеллектуальных проверок контента."
---
## **Обзор**

Aspose.Slides может определить формат презентации и прочитать её метаданные документа без создания полной модели объекта презентации. Это полезно, когда необходимо классифицировать файлы, создать инвентарь или проверить свойства перед тем, как решить, загружать и обрабатывать содержимое презентации.

В этой статье демонстрируется лёгкая инспекция с помощью [PresentationFactory](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentationfactory/) и [IPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/), а также целенаправленные обновления с помощью [IDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/).

## **Проверка формата презентации**

Используйте [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) для проверки файла без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/). Метод [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/get_loadformat/) сообщает обнаруженный формат, например PPTX, PPT или ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Создание лёгкого инвентаря презентаций**

Когда вы обрабатываете много файлов презентаций, может потребоваться компактный инвентарь для проверки, индексации или системы управления документами. В этом случае используйте [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) для получения объекта [IPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/), а затем вызовите [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) для чтения метаданных документа. Этот подход не создаёт экземпляр [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и не требует обхода полной модели объекта презентации.

Расширенные свойства, предоставленные [IDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/), дают следующие значения инвентаря:

| Метод | Значение инвентаря |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/get_slides/) | Общее количество слайдов. |
| [get_HiddenSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Количество скрытых слайдов. |
| [get_Notes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/get_notes/) | Количество слайдов, содержащих заметки. |
| [get_Paragraphs](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Общее количество абзацев, если доступно. |
| [get_Words](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/get_words/) | Общее количество слов. |
| [get_MultimediaClips](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Общее количество аудио‑ и видеоклипов. |

Следующий пример считывает эти значения без создания объекта [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и выводит компактный инвентарь. Он также сочетает [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/get_headingpairs/) с [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) для отображения групп содержимого, таких как шрифты, темы и заголовки слайдов.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Каждый [IHeadingPair](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iheadingpair/) предоставляет имя группы через [IHeadingPair::get_Name](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iheadingpair/get_name/) и количество элементов в этой группе через [IHeadingPair::get_Count](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) возвращает плоский упорядоченный массив, поэтому используйте количество последовательных заголовков, указанное каждым заголовочным парой.

### **Хранённые метаданные и ограничения формата**

Свойства инвентаря, возвращаемые [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/), отражают метаданные, доступные в исходном документе. Aspose.Slides не загружает и не обходит модель объекта презентации для пересчёта этих значений при вызове. Отсутствующие свойства отображаются значениями по умолчанию, а сохранённые значения могут быть устаревшими, если приложение, сохранившее файл последним, не обновило свойства документа.

- **PPTX:** Формат предоставляет расширенные свойства документа для количества слайдов, заметок, скрытых слайдов, абзацев, слов и мультимедиа, а также пар заголовков и названий частей. Доступность зависит от того, какие свойства были записаны производителем документа.
- **PPT:** Бинарный формат может хранить соответствующие свойства‑резюме документа. Если свойство отсутствует или не было обновлено производителем, Aspose.Slides возвращает его сохранённое или значение по умолчанию, а не рассчитывает его из слайдов.
- **ODP:** Метаданные OpenDocument предоставляют общую статистику документа, такую как количество страниц, абзацев и слов, но эти значения не сопоставляются со всеми расширенными свойствами PowerPoint. Метаданные о скрытых слайдах, заметках, мультимедиа, парах заголовков и названиях частей могут быть недоступны, и свойства инвентаря могут возвращать значения по умолчанию. Не рассматривайте нулевое значение или пустой массив как окончательное доказательство отсутствия соответствующего содержимого.

Используйте лёгкий подход к метаданным для инвентарей и предварительных проверок. Загружайте презентацию и проверяйте её живую модель объекта, когда результат должен отражать изменения в памяти или когда необходимо подтвердить фактическое содержимое презентации.

## **Обновление свойств презентации**

Свойства, возвращаемые [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/), также могут быть изменены без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/). Примените изменения с помощью [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/), а затем запишите привязанную презентацию с помощью [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

Следующее изображение показывает исходные свойства документа PowerPoint презентации.

![Исходные свойства документа PowerPoint презентации](input_properties.png)

Следующий пример изменяет заголовок и время последнего сохранения и записывает результат в новый файл:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

Следующее изображение показывает изменённые свойства документа PowerPoint презентации.

![Изменённые свойства документа PowerPoint презентации](output_properties.png)

## **Полезные ссылки**

Для связанных проверок безопасности и настроек защиты см. следующие статьи:

- [Защита презентаций паролем](/slides/ru/cpp/password-protected-presentation/)
- [Защита от записи презентаций](/slides/ru/cpp/write-protected-presentation/)

## **FAQ**

**Как проверить, встроены ли шрифты и какие именно?**

Загрузите презентацию и используйте [Presentation::get_FontsManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_fontsmanager/). Вызовите [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsmanager/getembeddedfonts/) для получения встроенных шрифтов и [FontsManager::GetFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fontsmanager/getfonts/) для получения шрифтов, используемых презентацией. Сравните два результата, чтобы найти шрифты, необходимые для отображения, но не встроенные.

**Как быстро определить, есть ли в файле скрытые слайды и их количество?**

Когда метаданные документа достаточны, прочитайте [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) через [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) и [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). Это подходит для лёгкого инвентаря. Если презентация была изменена в памяти, сохранённые метаданные могут быть отсутствующими или устаревшими, либо требуется проверка живых значений – пройдите по [Presentation::get_Slides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_slides/) и проверьте метод [Slide::get_Hidden](https://reference.aspose.com/slides/ru/cpp/aspose.slides/slide/get_hidden/) каждого слайда.

**Можно ли определить, использованы ли пользовательские размеры и ориентация слайда, и отличаются ли они от стандартных?**

Да. Загрузите презентацию и прочитайте [Presentation::get_SlideSize](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_slidesize/). Проверьте [ISlideSize::get_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidesize/get_size/) и [ISlideSize::get_Orientation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidesize/get_orientation/) для сравнения текущих настроек с ожидаемыми предустановками и размерами.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Найдите каждую [Chart](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chart/) и проверьте [ChartData::get_DataSourceType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Для внешней книги выполните чтение [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Тип источника данных и путь указывают внешнюю ссылку, но проверка доступности целевого ресурса требует отдельной проверки.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Нет единственного свойства сложности. Обойдите [Presentation::get_Slides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_slides/) и коллекцию [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/get_shapes/) каждого слайда. Используйте количество фигур и наличие больших изображений, эффектов, анимаций или мультимедиа как сигналы, и измерьте представительный рендеринг или экспорт, прежде чем считать слайд подтверждённым узким местом производительности.