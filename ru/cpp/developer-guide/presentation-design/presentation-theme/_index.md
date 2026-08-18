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
- Управлять темой
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
description: "Главные темы презентаций в Aspose.Slides для C++ позволяют создавать, настраивать и конвертировать файлы PowerPoint с единообразным брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения, а не хранят каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить множество объектов одновременно.

В Aspose.Slides тема уровня презентации доступна через [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_mastertheme/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределять тему презентации через [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), тогда как макет или отдельный слайд могут использовать [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). На практике эффективная тема для слайда определяется через эту цепочку наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже показаны самые распространённые сценарии работы с темой: просмотр темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Просмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/mastertheme/) предоставляет методы темы: [get_ColorScheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) и [get_FormatScheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Просмотр этих коллекций перед их изменением особенно полезен, когда презентация поступает из внешнего источника, поскольку количество и содержание записей стилей могут различаться.

Следующий пример считывает основные свойства темы и сообщает, сколько стилей фона, заливки, линии и эффектов хранится в теме:

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

Если файл использует несколько мастеров, не следует предполагать, что у каждого слайда одинаковая эффективная тема. Просмотрите мастер, связанный со слайдом, и используйте сценарий работы с эффективной темой, показанный ниже, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Заливки, линии и текст, учитывающие тему, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/schemecolor/). Когда вы меняете соответствующую запись в теме [IColorScheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/icolorscheme/), все объекты, продолжающие ссылаться на этот цвет темы, получают новое значение. Объекты, использующие прямой цвет RGB, не изменяются при обновлении цвета темы.

Следующий сквозной пример создаёт фигуру, использующую `Accent4`, меняет цвет темы `Accent4` на красный, сохраняет презентацию, открывает её снова и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся связанным с `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы прямым цветом на фигуре, последующие изменения `Accent4` больше не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя цветовые преобразования. Aspose.Slides раскрывает эти преобразования через [ColorTransformOperation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, сгенерированные из дополнительной палитры](additional-palette-colors.png)

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

Эти варианты остаются основанными на цвете темы. Если позже `Accent4` изменится, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Отображение значений `SchemeColor` в слоты `IColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [IColorScheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/icolorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Отображение фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не представляют значения, динамически преобразуемые из одной формы в другую.

## **Изменение шрифтов темы**

Шрифтовая схема темы содержит основной набор шрифтов для заголовков и вспомогательный набор шрифтов для основного текста. Методы [FontScheme::get_Major()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/fontscheme/get_major/) и [FontScheme::get_Minor()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/fontscheme/get_minor/) раскрывают эти наборы.

Идентификаторы шрифтов, совместимые с PowerPoint, могут использоваться при форматировании текста:

* `+mn-lt` – Основной шрифт латиницы (Minor Latin Font)
* `+mj-lt` – Шрифт заголовка латиницы (Major Latin Font)
* `+mn-ea` – Основной шрифт восточноазиатского (Minor East Asian Font)
* `+mj-ea` – Шрифт заголовка восточноазиатского (Major East Asian Font)

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

Заголовок следует основному шрифту, а основной текст – вспомогательному. Текст, в котором явно указано имя шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении шрифтовой схемы темы.

{{% alert color="info" title="Подсказка" %}}
Для получения дополнительной информации о шрифтах презентации см. [PowerPoint Fonts](/slides/ru/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Существует два распространённых сценария, решающих разные задачи.

### **Сохранение исходной темы при перемещении слайдов**

Если необходимо переместить слайд в другую презентацию и сохранить его оригинальный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/addclone/), затем клонируйте слайд с помощью [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/) и клонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

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

Это предпочтительный подход, когда исходный слайд должен выглядеть одинаково в целевой презентации. Простое клонирование содержимого на несвязанный мастер назначения может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

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

Это меняет тему, используемую этим слайдом, не изменяя тему, наследуемую другими слайдами. Чтобы удалить локальное переопределение и вернуться к наследуемым значениям, вызовите [OverrideTheme::Clear()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/overridetheme/clear/).

### **Применение переопределения темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации могут быть использованы через [IOverrideThemeManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ioverridethememanager/) макета:

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

Используйте тему уровня мастера или презентации, когда многие макеты и слайды должны делить один базовый дизайн; переопределение макета – когда одной семье макетов нужен иной стиль; и переопределение слайда – только для истинных исключений. Чрезмерное количество переопределений на уровне слайда усложняет предсказание последствий глобальных изменений темы.

## **Обновление стилей фона темы**

Фоны темы хранятся в [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint может предлагать в пользовательском интерфейсе больше вариантов фона, чем количество фактически хранящихся определений заливок, поскольку UI может комбинировать заливки темы с цветовыми ссылками и другими стилями.

![Галерея стилей фона PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием стиля фона проверьте хранимую коллекцию и текущий [Background::get_StyleIndex()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` использует `0` для отсутствия тематической заливки; положительные значения являются ссылками на стили фоновой темы. Это отличается от индексации C++‑коллекции через `idx_get(0)`, где `0` означает первый сохранённый элемент. Не предполагайте, что у каждой презентации одинаковое количество стилей фоновых заливок.

Следующий пример сообщает количество доступных фоновых заливок, назначает ссылку на тематический фон первому мастеру и сохраняет презентацию:

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

Видимый результат зависит от записи темы, на которую ссылается мастер, и от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фона мастера может не затронуть этот слайд. Используйте [Background::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/background/geteffective/), когда нужно узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Предупреждение" %}}
Не рассматривайте `StyleIndex` как нулевой индекс коллекции. Также избегайте жёсткого указания номера стиля из одного файла, предполагая, что он будет выглядеть одинаково в другом файле; определения стилей темы специфичны для презентации.
{{% /alert %}}

{{% alert color="info" title="Подсказка" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/cpp/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема формата темы содержит отдельные коллекции [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/formatscheme/get_linestyles/) и [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Типичные темы Office часто включают три основных стиля, визуально соответствующие «тонкому», «среднему» и «интенсивному» форматированию, но код должен проверять каждую коллекцию, а не предполагать фиксированное количество.

![Тонкие, средние и интенсивные эффекты темы, применённые к одной фигуре](presentation-design_10.png)

При доступе к этим коллекциям в C++ индекс коллекции начинается с нуля: `idx_get(0)` – первая сохранённая стилизация, `idx_get(2)` – третья. Индексы ссылок стилей фигуры – отдельная концепция, раскрытая через [IShapeStyle](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapestyle/). Изменение стиля темы влияет на фигуры, ссылающиеся на этот стиль; фигуры с прямым форматированием могут оставаться без изменений.

Следующий пример проверяет наличие требуемых записей стилей, меняет первый стиль линии, третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

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

Для фигур, ссылающихся на эти слоты, первый стиль линии темы становится красным, третий стиль заливки – сплошным лесным зелёным, а третий эффект получает внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё‑равно зависит от того, какие слоты стилей использует каждая фигура и переопределяется ли тема прямым форматированием.

![Стили эффектов темы после изменения линий, заливки и настроек тени](presentation-design_11.png)

## **Чтение эффективных значений темы**

Сырые объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура действительно используют после разрешения наследования и локальных переопределений. Для слайда вызовите [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Для фона используйте [Background::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/background/geteffective/), а для заливки – [FillFormat::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fillformat/geteffective/).

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

Используйте эффективные данные для диагностики рендеринга, проверки и сравнения. Если вы проверяете только [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_mastertheme/), можете упустить переопределения мастер‑, макет‑, слайд‑ или фигурные, меняющие окончательный вид.

## **FAQ**

**Можно ли применить тему к отдельному слайду без изменения мастера?**  
Да. Используйте [IOverrideThemeManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ioverridethememanager/) слайда и инициализируйте его переопределённую тему. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой способ самый надёжный для переноса темы из одной презентации в другую?**  
При перемещении слайда и сохранении его исходного оформления клонируйте исходный мастер в целевую презентацию и клонируйте сам слайд с этим мастером, используя [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/addclone/) и [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecollection/addclone/). Это сохраняет мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**  
Используйте [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) для темы слайда или макета и соответствующие методы получения эффективных данных для объектных форматов, таких как [Background::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/background/geteffective/) и [FillFormat::GetEffective()](https://reference.aspose.com/slides/ru/cpp/aspose.slides/fillformat/geteffective/). Эти API возвращают разрешённые значения после применения наследования и переопределений.