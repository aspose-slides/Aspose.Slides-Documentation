---
title: Управление темами презентации в C++
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/cpp/presentation-theme/
keywords:
- Тема PowerPoint
- тема презентации
- тема слайда
- установить тему
- изменить тему
- управлять темой
- внешняя тема
- THMX
- цвет темы
- дополнительная палитра
- шрифт темы
- стиль темы
- эффект темы
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Мастер темы презентаций в Aspose.Slides для C++ для создания, настройки и конвертации файлов PowerPoint с единым брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо того, чтобы хранить каждое визуальное свойство как фиксированное значение, поэтому изменение темы может одновременно обновить множество объектов.

В Aspose.Slides тема уровня презентации доступна через [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_mastertheme/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределять тему презентации через [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), в то время как макет или отдельный слайд могут использовать [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). На практике эффективная тема для слайда определяется через эту цепочку наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Нижеприведённые разделы показывают самые распространённые сценарии работы с темой: просмотр темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Просмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/mastertheme/) раскрывает методы темы: [get_ColorScheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), и [get_FormatScheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Просмотр этих коллекций перед их изменением особенно полезен, когда презентация поступает из внешнего источника, поскольку количество и содержание записей стилей могут различаться.

Следующий пример считывает основные свойства темы и сообщает, сколько стилей фона, заливки, линий и эффектов хранится в теме:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Если файл использует несколько мастеров, не предполагаете, что каждый слайд имеет одинаковую эффективную тему. Просмотрите мастер, связанный со слайдом, и используйте рабочий процесс эффективной темы, показанный позже в статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Объекты, учитывающие тему, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/schemecolor/). Когда вы изменяете соответствующую запись в теме через [IColorScheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/icolorscheme/), все объекты, которые продолжают ссылаться на этот цвет темы, используют новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий пример полностью реализует процесс: создаёт фигуру, использующую `Accent4`, меняет цвет `Accent4` темы на красный, сохраняет презентацию, открывает её снова и выводит эффективный цвет заливки:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Поскольку прямоугольник остаётся привязанным к `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы прямым цветом в фигуре, последующие изменения `Accent4` более не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя преобразования цветов. Aspose.Slides раскрывает эти преобразования через [ColorTransformOperation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, сгенерированные из дополнительной палитры](additional-palette-colors.png)

**1** - Основные цвета темы.  
**2** - Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `Accent4`, применяя преобразования яркости к пяти из них, и сохраняет результат:

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Эти варианты остаются основанными на цвете темы. Если `Accent4` изменится позже, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Соответствие значений `SchemeColor` слотам `IColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, в то время как [IColorScheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/icolorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Отображение фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не представляют значения, динамически преобразуемые из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор для основного текста. Методы [FontScheme::get_Major()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/fontscheme/get_major/) и [FontScheme::get_Minor()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/fontscheme/get_minor/) раскрывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, можно использовать в форматировании текста:

* `+mn-lt` - шрифт тела Latin (Minor Latin Font)
* `+mj-lt` - шрифт заголовка Latin (Major Latin Font)
* `+mn-ea` - шрифт тела East Asian (Minor East Asian Font)
* `+mj-ea` - шрифт заголовка East Asian (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку текста, использующую вспомогательный латинский шрифт темы. Затем меняет шрифты темы и сохраняет результат:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

Заголовок использует основной шрифт, а основной текст — вспомогательный шрифт. Текст, в котором указано конкретное имя шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

Основные и вспомогательные наборы шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. [Script-Specific Theme Fonts](/slides/ru/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Совет" %}}
Для получения дополнительной информации о шрифтах презентаций см. [PowerPoint Fonts](/slides/ru/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Ниже приведённые сценарии решают различные задачи, связанные с темой.

### **Применение внешней темы к слайдам, зависящим от мастера**

Используйте [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/), когда у вас есть файл темы PowerPoint (`.thmx`) и необходимо изменить стили всех слайдов, зависящих от конкретного мастера. Выберите мастер из коллекции [Presentation::get_Masters](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_masters/), реализующей [IMasterSlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/), и передайте путь к файлу темы методу.

Метод выполняет следующие операции:
1. Создаёт новый слайд‑мастер на основе выбранного мастера.
2. Применяет внешнюю тему к новому мастеру.
3. Назначает новый мастер всем слайдам, которые ранее зависели от выбранного мастера.
4. Возвращает вновь созданный [IMasterSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/).

Следующий пример применяет внешнюю тему к слайдам, зависящим от первого мастера, и сохраняет презентацию:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

Недопустимая, повреждённая или неподдерживаемая тема может вызвать [PptxException](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pptxexception/) или один из её подклассов, связанных с форматом. Проверяйте пути, вводимые пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переназначаются только слайды, зависевшие от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои текущие мастера и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, учитывающие тему, вычисляются на основе внешней темы. Прямо назначенные цвета, шрифты, заливки и другие явные форматирования могут остаться без изменений. Переопределения уровня макета и уровня слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, недоступные в текущей среде выполнения. Для согласованного отображения и экспорта установите требуемые шрифты, предоставьте их через [custom font sources](/slides/ru/cpp/custom-font/), либо настройте [font substitution](/slides/ru/cpp/font-substitution/).

Это прямой рабочий процесс уровня мастера: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы уровня слайда или макета.

### **Применение разных внешних тем в презентации с несколькими мастерами**

Когда нужный мастер неизвестен заранее, получите его из представительного слайда через [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/get_layoutslide/) и [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/get_masterslide/). Сохраните оригинальные ссылки на мастера перед применением тем, поскольку каждый вызов создаёт новый мастер в презентации.

Следующий пример использует слайды из двух разделов, чтобы найти их мастера, и применяет к каждому набору свою внешнюю тему:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

Первый вызов влияет только на слайды, зависевшие от `firstGroupMaster`, а второй — только на слайды, зависевшие от `secondGroupMaster`. Слайды, принадлежащие другим мастерам, не переоформляются.

### **Сохранение исходной темы при перемещении слайдов**

Если нужно переместить слайд в другую презентацию и сохранить его оригинальный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/addclone/), затем клонируйте слайд с помощью [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) и клонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

Это предпочтительный процесс, когда исходный слайд должен выглядеть одинаково в целевом документе. Простое копирование содержимого на несвязанный мастер‑назначения может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применение значений темы к существующему слайду**

Если целевой слайд должен оставаться на текущем мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) и [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) копируют три основных компонента темы в переопределение.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

Это изменяет тему, применяемую к данному слайду, не меняя тему, унаследованную другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme::Clear()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/overridetheme/clear/).

### **Применение переопределения темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации можно использовать через [IOverrideThemeManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ioverridethememanager/) макета:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Используйте тему мастера или уровня презентации, когда многие макеты и слайды должны использовать один базовый дизайн; переопределение макета — когда одной группе макетов нужен иной стиль; и переопределение слайда — только для исключительных случаев. Чрезмерное количество переопределений уровня слайда усложняет предсказание последующих глобальных изменений темы.

## **Обновление стилей фона темы**

Заливки фона темы хранятся в [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint может предлагать в интерфейсе больше вариантов фона, чем фактически определено в этой коллекции, поскольку UI может комбинировать заливки темы с её цветами и другими ссылками на стили.

![Галерея стилей фона PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием стиля фона проверьте хранящуюся коллекцию и текущий [Background::get_StyleIndex()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` использует `0` для отсутствия тематической заливки; положительные значения являются ссылками на стили фона темы. Это отличается от индексации C++‑коллекции напрямую через `idx_get(0)`, где `0` означает первый элемент. Не предполагаете, что каждая презентация содержит одинаковое количество стилей заливки фона.

Следующий пример выводит количество доступных стилей заливки фона, задаёт ссылку на тематический фон для первого мастера и сохраняет презентацию:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

Видимый результат зависит от ссылки на запись темы, используемой мастером, и от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фона мастера может не повлиять на него. При необходимости узнать окончательный фон после применения наследования используйте [Background::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/background/geteffective/).

{{% alert color="warning" title="Внимание" %}}
Не рассматривайте `StyleIndex` как нулевой индекс коллекции. Также избегайте жёсткого кодирования номера стиля из одного файла и предположения, что он будет выглядеть одинаково в другом файле; определения стилей темы зависят от конкретной презентации.
{{% /alert %}}

{{% alert color="info" title="Совет" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/cpp/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема формата темы содержит отдельные коллекции [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/formatscheme/get_linestyles/) и [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Типичные темы Office часто включают три основных стиля, визуально соответствующие тонкому, умеренному и интенсивному форматированию, однако код должен проверять каждую коллекцию, а не полагаться на фиксированное количество.

![Тонкие, умеренные и интенсивные эффекты темы, применённые к одной фигуре](presentation-design_10.png)

При доступе к этим коллекциям в C++ индексация начинается с нуля: `idx_get(0)` — первый стиль, `idx_get(2)` — третий. Индексы ссылки на стиль у фигуры — отдельная концепция, раскрытая через [IShapeStyle](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapestyle/). Изменение стиля темы влияет на фигуры, которые ссылаются на этот стиль; фигуры с прямым форматированием могут остаться без изменений.

Следующий пример проверяет наличие требуемых записей стилей, меняет первый стиль линии, меняет третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Для фигур, ссылающихся на эти слоты, первый стиль линии темы становится красным, третий стиль заливки темы — сплошным тёмно‑зелёным, а третий стиль эффекта получает внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей использует каждая фигура и переопределяется ли прямое форматирование.

![Стили эффектов темы после изменения настроек линии, заливки и тени](presentation-design_11.png)

## **Определение, использует ли эффективная сплошная заливка цвет темы**

Заливка может быть сохранена непосредственно в объекте или унаследована от абзаца, макета, мастера, стиля темы или другого уровня форматирования. Вызовите [IFillFormat::GetEffective](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifillformat/geteffective/) для получения неизменяемого [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifillformateffectivedata/). Сначала проверьте [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Только если тип `FillType::Solid`, читайте свойства сплошной заливки.

Для сплошной заливки [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) возвращает окончательное отображаемое RGB‑значение после применения наследования, поиска в теме и преобразований цветов. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) возвращает соответствующий логический слот [SchemeColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/schemecolor/), например `Text1` или `Accent6`. Значение `SchemeColor::NotDefined` означает, что эффективная сплошная заливка не основана на цвете схемы. В рабочих процессах, где заливки либо цвета темы, либо прямые RGB‑цвета, это значение указывает на прямую RGB‑заливку.

Не используйте только локальное значение [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icolorformat/get_schemecolor/) для классификации заливки. Например, у части текста может не быть локального цвета схемы, поэтому локальное значение `NotDefined`, тогда как его эффективная заливка наследует цвет темы и приводит к `Text1` или `Accent6`. Обратное, `get_SolidFillSchemeColor` сообщает, какой логический слот темы создал эффективный цвет, но не указывает, от какого уровня (объект, абзац, макет, мастер и т.д.) он пришёл.

Следующий пример загружает презентацию, проверяет заливки фигур и заливки текстовых фрагментов, выводит каждый окончательный RGB‑значение и соответствующий цвет схемы, а также отмечает сплошные заливки, не привязанные к теме:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

Ветка `NotDefined` предоставляет список сплошных заливок, которые не будут реагировать на изменения цветовых слотов темы. Просмотрите эти объекты, когда презентация должна соответствовать новой фирменной палитре. Выведенное RGB‑значение всё равно показывает текущий вид, а значение схемы объясняет, связано ли он с темой.

Объекты эффективного формата являются снимками. После изменения темы презентации, переопределения темы или любого унаследованного форматирования вызовите `GetEffective` снова и получите новый объект `IFillFormatEffectiveData` перед сравнением или выводом цветов.

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура действительно используют после применения наследования и локальных переопределений. Для слайда вызовите [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Для фона используйте [Background::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/background/geteffective/), а для заливки — [FillFormat::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fillformat/geteffective/).

Следующий пример считывает эффективную тему, фон и первую заливку фигуры со слайда:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Используйте эффективные данные для диагностики отрисовки, валидации и сравнения. Если вы проверяете только [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_mastertheme/), вы можете упустить переопределения мастера, макета, слайда или фигуры, изменяющие окончательный вид.

## **Вопросы и ответы**

**Влияет ли применение внешней темы на каждый слайд в презентации?**

Нет. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) переassigns только те слайды, которые зависят от выбранного мастера. Слайды, использующие другие мастеры, сохраняют свои текущие темы.

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [IOverrideThemeManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ioverridethememanager/) слайда и инициализируйте его переопределение темы. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой самый безопасный способ перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного вида клонируйте исходный мастер в целевую презентацию с помощью [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/addclone/) и клонируйте слайд с этим мастером через [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/). Это сохраняет мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) для слайда или темы макета и соответствующие методы получения эффективных данных для объектов формата, таких как [Background::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/background/geteffective/) и [FillFormat::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fillformat/geteffective/). Эти API возвращают разрешённые значения после применения наследования и переопределений.