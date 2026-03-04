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
description: "Управляйте темами презентаций в Aspose.Slides для C++, создавайте, настраивайте и конвертируйте файлы PowerPoint с единообразным брендингом."
---
Тема презентации определяет свойства элементов дизайна. При выборе темы презентации вы фактически выбираете определённый набор визуальных элементов и их свойства.

В PowerPoint тема включает цвета, [шрифты](/slides/ru/cpp/powerpoint-fonts/), [стили фона](/slides/ru/cpp/presentation-background/) и эффекты.

![theme-constituents](theme-constituents.png)

## **Изменить цвет темы**

Тема PowerPoint использует определённый набор цветов для различных элементов слайда. Если вам не нравятся цвета, вы меняете их, применяя новые цвета к теме. Чтобы позволить вам выбрать новый цвет темы, Aspose.Slides предоставляет значения в перечислении [SchemeColor](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Этот код C++ демонстрирует, как изменить цвет акцента для темы:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Таким образом вы можете определить эффективное значение полученного цвета:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Цвет [A=255, R=128, G=100, B=162])
```

Чтобы дополнительно продемонстрировать операцию изменения цвета, мы создаём другой элемент и назначаем ему цвет акцента (из первоначальной операции). Затем меняем цвет в теме:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Новый цвет автоматически применяется к обоим элементам.

### **Установить цвет темы из дополнительной палитры**

Когда вы применяете преобразования яркости к основному цвету темы(1), формируются цвета из дополнительной палитры(2). Затем вы можете установить и получить эти цвета темы.

![additional-palette-colors](additional-palette-colors.png)

**1**‑ Основные цвета темы  
**2**‑ Цвета из дополнительной палитры.

Этот код C++ демонстрирует операцию, при которой цвета дополнительной палитры получаются из основного цвета темы и затем используются в фигурах:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Lighter 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Lighter 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Lighter 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Darker 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Darker 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **Отобразить `SchemeColor` на цвета `IColorScheme`**

Работая с [SchemeColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/schemecolor/), вы можете заметить, что он содержит следующие значения цветов темы: `Background1`, `Background2`, `Text1` и `Text2`.

Однако `Presentation::get_MasterTheme()::get_ColorScheme()` возвращает [IColorScheme](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/icolorscheme/), который предоставляет соответствующие цвета как: `Dark1`, `Dark2`, `Light1` и `Light2`.

Это различие только в названиях. Эти значения относятся к тем же ячейкам цветов темы, и сопоставление фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Динамического преобразования между `Text`/`Background` и `Dark`/`Light` нет. Это просто альтернативные названия одних и тех же цветов темы.

Это различие в названиях происходит из терминологии Microsoft Office. Старые версии Office использовали `Dark 1`, `Light 1`, `Dark 2` и `Light 2`, тогда как новые версии интерфейса отображают те же слоты как `Text 1`, `Background 1`, `Text 2` и `Background 2`.

## **Изменить шрифт темы**

Чтобы позволить вам выбирать шрифты для тем и других целей, Aspose.Slides использует эти специальные идентификаторы (аналогичные используемым в PowerPoint):

* **+mn-lt** ‑ основной (тело) шрифт латиницы (Minor Latin Font)
* **+mj-lt** ‑ заголовочный шрифт латиницы (Major Latin Font)
* **+mn-ea** ‑ основной (тело) шрифт восточно‑азиатский (Minor East Asian Font)
* **+mj-ea** ‑ заголовочный шрифт восточно‑азиатский (Major East Asian Font)

Этот код C++ демонстрирует, как назначить латинский шрифт элементу темы:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Этот код C++ демонстрирует, как изменить шрифт темы презентации:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Шрифт во всех текстовых полях будет обновлён.

{{% alert color="primary" title="TIP" %}} 
Возможно, вам будет полезно посмотреть [шрифты PowerPoint](/slides/ru/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Изменить стиль фона темы**

По умолчанию приложение PowerPoint предоставляет 12 предустановленных фонов, но в типичной презентации сохраняются только 3 из этих 12 фонов.

![todo:image_alt_text](presentation-design_8.png)

Например, после сохранения презентации в приложении PowerPoint вы можете выполнить этот код C++, чтобы узнать количество предустановленных фонов в презентации:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
Используя свойство [BackgroundFillStyles](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) из класса [FormatScheme](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.theme.i_format_scheme/), вы можете добавить или получить доступ к стилю фона в теме PowerPoint. 
{{% /alert %}}

Этот код C++ демонстрирует, как установить фон для презентации:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Руководство по индексам**: 0 используется для отсутствия заливки. Индекс начинается с 1.

{{% alert color="primary" title="TIP" %}} 
Возможно, вам будет полезно посмотреть [фон PowerPoint](/slides/ru/cpp/presentation-background/).
{{% /alert %}}

## **Изменить эффект темы**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы комбинируются в 3 эффекта: тонкий, умеренный и интенсивный. Например, это результат применения эффектов к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) из класса [FormatScheme](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.theme.i_format_scheme/) вы можете изменять элементы темы (даже более гибко, чем варианты в PowerPoint).

Этот код C++ демонстрирует, как изменить эффект темы, изменяя части элементов:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Полученные изменения в цвете заливки, типе заливки, эффекте тени и т.д.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Можно ли применить тему к отдельному слайду без изменения мастера?**  
Да. Aspose.Slides поддерживает переопределения темы на уровне слайда, поэтому вы можете применить локальную тему только к этому слайду, оставив тему мастера неизменной (через [SlideThemeManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides.theme/slidethememanager/)).

**Какой самый безопасный способ перенести тему из одной презентации в другую?**  
[Клонировать слайды](/slides/ru/cpp/clone-slides/) вместе с их мастер‑шаблоном в целевую презентацию. Это сохраняет оригинальный мастер, макеты и связанную тему, поэтому внешний вид остаётся одинаковым.

**Как увидеть «эффективные» значения после всего наследования и переопределений?**  
Используйте «эффективные» представления API ["effective" views](/slides/ru/cpp/shape-effective-properties/) для темы/цвета/шрифта/эффекта. Они возвращают окончательные, разрешённые свойства после применения мастера и всех локальных переопределений.