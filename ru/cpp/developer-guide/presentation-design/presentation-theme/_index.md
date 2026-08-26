---
title: Управление темами презентаций в C++
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/cpp/presentation-theme/
keywords:
- Тема PowerPoint
- Тема презентации
- Тема слайда
- Установить тему
- Изменить тему
- Управление темой
- Внешняя тема
- THMX
- Цвет темы
- Дополнительная палитра
- Шрифт темы
- Стиль темы
- Эффект темы
- PowerPoint
- OpenDocument
- Презентация
- C++
- Aspose.Slides
description: "Управляйте темами презентаций в Aspose.Slides для C++, создавайте, настраивайте и конвертируйте файлы PowerPoint с единым фирменным стилем."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо того, чтобы хранить каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить множество объектов одновременно.

В Aspose.Slides тема уровня презентации доступна через [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_mastertheme/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределить тему презентации через [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), а макет или отдельный слайд могут использовать [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). На практике эффективная тема слайда определяется по этой цепочке наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Ниже представлены самые распространённые рабочие процессы с темами: просмотр темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после применения наследования и переопределений.

## **Просмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/mastertheme/) предоставляет методы [get_ColorScheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) и [get_FormatScheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Просмотр этих коллекций перед их изменением особенно полезен, когда презентация поступает из внешнего источника, поскольку количество и содержание элементов стиля могут различаться.

Следующий пример считывает основные свойства темы и сообщает, сколько стилей фона, заливки, линий и эффектов сохранено в теме:

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

Если файл использует несколько мастеров, не следует полагать, что каждый слайд имеет одну и ту же эффективную тему. Просмотрите мастер, ассоциированный со слайдом, и используйте рабочий процесс эффекта темы, показанный далее в статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Заливки, линии и текст, учитывающие тему, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/schemecolor/). При изменении соответствующей записи в [IColorScheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/icolorscheme/) темы все объекты, продолжающие ссылаться на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт фигуру, использующую `Accent4`, меняет цвет `Accent4` темы на красный, сохраняет презентацию, открывает её снова и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся связанным с `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет в фигуре, последующие изменения `Accent4` уже не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint генерирует более светлые и более тёмные варианты из цвета темы, применяя преобразования цвета. Aspose.Slides предоставляет эти преобразования через [ColorTransformOperation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Основные цвета темы.

**2** – Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `Accent4`, применяет к пяти из них преобразования яркости и сохраняет результат:

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

Эти варианты остаются привязанными к цвету темы. Если `Accent4` изменится позже, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Отображение значений `SchemeColor` в слоты `IColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [IColorScheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/icolorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Соответствие фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, которые динамически преобразуются из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор для основного текста. Методы [FontScheme::get_Major()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/fontscheme/get_major/) и [FontScheme::get_Minor()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/fontscheme/get_minor/) раскрывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться при форматировании текста:

* `+mn-lt` – основной шрифт тела (Minor Latin Font)
* `+mj-lt` – шрифт заголовка (Major Latin Font)
* `+mn-ea` – основной шрифт восточно‑азиатского текста (Minor East Asian Font)
* `+mj-ea` – шрифт заголовка восточно‑азиатского текста (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем он меняет шрифты темы и сохраняет результат:

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

Заголовок следует основному шрифту, а основной текст – вспомогательному. Текст, у которого явно указано название шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

Основные и вспомогательные коллекции шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. [Script-Specific Theme Fonts](/slides/ru/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Для получения дополнительной информации о шрифтах презентаций смотрите [PowerPoint Fonts](/slides/ru/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Ниже приведённые рабочие процессы решают различные задачи, связанные с темами.

### **Применить внешнюю тему к слайдам, зависящим от мастера**

Используйте [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) когда у вас есть файл темы PowerPoint (`.thmx`) и нужно изменить стиль всех слайдов, зависящих от конкретного мастера. Выберите мастер из коллекции [Presentation::get_Masters](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_masters/), реализующей [IMasterSlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/), и передайте путь к файлу темы в метод.

Метод выполняет следующие операции:

1. Создаёт новый мастер‑слайд на основе выбранного мастера.  
2. Применяет внешнюю тему к новому мастеру.  
3. Присваивает новый мастер всем слайдам, ранее зависящим от выбранного мастера.  
4. Возвращает только что созданный [IMasterSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/).

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

Неправильный, повреждённый или неподдерживаемый файл темы может вызвать [PptxException](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pptxexception/) или один из его подклассов, связанных с форматом. Проверяйте пути, предоставленные пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переназначаются только те слайды, которые зависели от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои текущие мастера и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, учитывающие тему, разрешаются относительно внешней темы. Прямо назначенные цвета, шрифты, заливки и другие явные свойства могут остаться без изменений. Переопределения на уровне макета и слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, отсутствующие в среде выполнения. Для согласованного рендеринга и экспорта установите требуемые шрифты, предоставьте их через [custom font sources](/slides/ru/cpp/custom-font/), либо настройте [font substitution](/slides/ru/cpp/font-substitution/).

Это прямой рабочий процесс уровня мастера: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы на уровне слайда или макета.

### **Применить разные внешние темы в презентации с несколькими мастерами**

Когда нужный мастер неизвестен заранее, получите его из представительного слайда через [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/get_layoutslide/) и [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/get_masterslide/). Сохраните исходные ссылки на мастера до применения тем, поскольку каждый вызов создаёт новый мастер в презентации.

Следующий пример использует слайды из двух секций, определяет их мастера и применяет к каждой группе различную внешнюю тему:

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

Первый вызов влияет только на слайды, зависимые от `firstGroupMaster`, а второй – только на слайды, зависимые от `secondGroupMaster`. Слайды, принадлежащие другим мастерам, не изменяются.

### **Сохранить исходную тему при перемещении слайдов**

Если нужно перенести слайд в другую презентацию, сохранив его оригинальный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/addclone/), затем клонируйте слайд с помощью [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) и клонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

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

Такой подход рекомендуется, когда исходный слайд должен выглядеть одинаково в целевом документе. Простое копирование содержимого на несвязанный мастер получателя может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применить значения темы к существующему слайду**

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

Это изменяет тему, используемую этим слайдом, без изменения темы, наследуемой другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme::Clear()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/overridetheme/clear/).

### **Применить переопределение темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только у конкретного слайда нет собственного переопределения. Те же методы инициализации могут быть использованы через [IOverrideThemeManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ioverridethememanager/) макета:

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

Используйте тему уровня мастера или презентации, когда многие макеты и слайды должны делить один базовый дизайн; переопределение макета – когда одной семье макетов нужен иной стиль; и переопределение слайда – только для истинных исключений. Чрезмерное количество переопределений на уровне слайда усложняет предсказуемость последующих глобальных изменений темы.

## **Обновление стилей фона темы**

Заливки фона темы хранятся в [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint может показывать в пользовательском интерфейсе больше вариантов фоновых стилей, чем фактически определено в этой коллекции, поскольку UI может комбинировать заливки темы с цветовыми ссылками и другими стилями.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Перед использованием фонового стиля просмотрите хранимую коллекцию и текущий [Background::get_StyleIndex()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` использует `0` для отсутствия тематической заливки; положительные значения – ссылки на стили фоновой темы. Это отличается от обычного индекса C++‑коллекции, где `idx_get(0)` означает первый элемент. Не предполагайте, что у каждой презентации одинаковое количество фоновых стилей заливки.

Следующий пример выводит количество доступных фоновых заливок, присваивает тематическую ссылку фона первому мастеру и сохраняет презентацию:

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

Видимый результат зависит от записи темы, на которую ссылается мастер, и от возможных переопределений фона на уровне макета или слайда. Если у слайда собственный фон, изменение только фона мастера может не затронуть этот слайд. Используйте [Background::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/background/geteffective/) когда нужно узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Warning" %}}
Не воспринимайте `StyleIndex` как индекс коллекции, начинающийся с нуля. Также избегайте жёстко задавать номер стиля из одного файла и ожидать одинакового внешнего вида в другом файле; определения стилей темы специфичны для каждой презентации.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/cpp/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема формата темы содержит отдельные коллекции [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/formatscheme/get_linestyles/) и [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Типичные темы Office часто включают три основных стиля, визуально соответствующие «тонким», «умеренным» и «интенсивным» форматам, однако код должен проверять каждую коллекцию, а не полагаться на фиксированное количество.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

При доступе к этим коллекциям в C++ их индексы начинаются с нуля: `idx_get(0)` – первый сохранённый стиль, `idx_get(2)` – третий. Индексы ссылок стиля в фигуре – отдельная концепция, представляемая через [IShapeStyle](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapestyle/). Изменение темы стиля влияет на фигуры, которые ссылаются на этот стиль; фигуры с прямым форматированием могут остаться без изменений.

Следующий пример проверяет наличие необходимых записей стилей, изменяет первый стиль линии, третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

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

Для фигур, ссылающихся на эти слоты, первый стиль линии темы становится красным, третий стиль заливки – сплошным лесным зеленым, а третий стиль эффекта получает внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей каждая фигура использует и переопределяется ли она прямым форматированием.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Чтение эффективных значений темы**

Сырые объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура действительно используют после применения наследования и локальных переопределений. Для слайда вызовите [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Для фона используйте [Background::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/background/geteffective/), а для заливки – [FillFormat::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fillformat/geteffective/).

Следующий пример считывает эффективную тему, фон и заливку первой фигуры со слайда:

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

Используйте эффективные данные для диагностики рендеринга, валидации и сравнения. Если вы проверяете только [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_mastertheme/), можно пропустить переопределения мастера, макета, слайда или фигуры, меняющие окончательный вид.

## **FAQ**

**Применение внешней темы затрагивает каждый слайд в презентации?**

Нет. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) переназначает только те слайды, которые зависели от выбранного мастера. Слайды, использующие другие мастера, сохраняют свои текущие темы.

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [IOverrideThemeManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ioverridethememanager/) слайда и инициализируйте его переопределяющую тему. Изменение будет локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой способ является самым надёжным для переноса темы из одной презентации в другую?**

При перемещении слайда и сохранении его исходного внешнего вида клонируйте исходный мастер в целевой документ с помощью [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/addclone/) и клонируйте слайд вместе с этим мастером, используя [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/). Это сохраняет мастер, макеты и тему в едином комплекте.

**Как увидеть эффективные значения после применения наследования и переопределений?**

Используйте [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) для темы слайда или макета и соответствующие методы получения эффективных данных для объектов формата, таких как [Background::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/background/geteffective/) и [FillFormat::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fillformat/geteffective/). Эти API возвращают разрешённые значения после применения наследования и переопределений.