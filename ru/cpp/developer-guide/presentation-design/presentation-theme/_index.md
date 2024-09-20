---
title: Тема презентации
type: docs
weight: 10
url: /cpp/presentation-theme/
keywords: "Тема, тема PowerPoint, презентация PowerPoint, CPP, C++, Aspose.Slides для C++"
description: "Тема презентации PowerPoint на C++"
---

Тема презентации определяет свойства элементов дизайна. Когда вы выбираете тему презентации, вы, по сути, выбираете определенный набор визуальных элементов и их свойства.

В PowerPoint тема включает цвета, [шрифты](/slides/cpp/powerpoint-fonts/), [стили фона](/slides/cpp/presentation-background/) и эффекты.

![составляющие темы](theme-constituents.png)

## **Изменить цвет темы**

Тема PowerPoint использует определенный набор цветов для различных элементов на слайде. Если вам не нравятся цвета, вы можете изменить их, применив новые цвета к теме. Чтобы вы могли выбрать новый цвет темы, Aspose.Slides предоставляет значения в перечислении [SchemeColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Этот код C++ показывает, как изменить акцентный цвет для темы:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Вы можете определить эффективное значение результирующего цвета следующим образом:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

Чтобы дополнительно продемонстрировать операцию изменения цвета, мы создаем другой элемент и присваиваем ему акцентный цвет (из начальной операции). Затем мы изменяем цвет в теме:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Новый цвет автоматически применяется ко всем элементам.

### **Установить цвет темы из дополнительной палитры**

Когда вы применяете трансформации яркости к основному цвету темы(1), формируются цвета из дополнительной палитры(2). Затем вы можете установить и получить эти цвета темы. 

![цвета дополнительной палитры](additional-palette-colors.png)

**1**- Основные цвета темы

**2** - Цвета из дополнительной палитры.

Этот код C++ демонстрирует операцию, когда цвета дополнительной палитры получаются из основного цвета темы и затем используются в фигурах:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Акцент 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Акцент 4, Светлее на 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Акцент 4, Светлее на 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Акцент 4, Темнее на 25%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Акцент 4, Темнее на 50%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

## **Изменить шрифт темы**

Чтобы вы могли выбрать шрифты для тем и других целей, Aspose.Slides использует эти специальные идентификаторы (аналогичные тем, которые используются в PowerPoint):

* **+mn-lt** - Шрифт текста (малый латинский шрифт)
* **+mj-lt** - Шрифт заголовков (основной латинский шрифт)
* **+mn-ea** - Шрифт текста Восточной Азии (малый восточноазиатский шрифт)
* **+mj-ea** - Шрифт заголовков Восточной Азии (основной восточноазиатский шрифт)

Этот код C++ показывает, как присвоить латинский шрифт элементу темы:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Формат текста темы");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Этот код C++ показывает, как изменить шрифт темы презентации:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Шрифт во всех текстовых полях будет обновлен.

{{% alert color="primary" title="Совет" %}} 

Вы можете посмотреть [шрифты PowerPoint](/slides/cpp/powerpoint-fonts/).

{{% /alert %}}

## **Изменить стиль фона темы**

По умолчанию приложение PowerPoint предоставляет 12 предустановленных фонов, но только 3 из этих 12 фонов сохраняются в типичной презентации. 

![todo:image_alt_text](presentation-design_8.png)

Например, после сохранения презентации в приложении PowerPoint вы можете запустить этот код C++, чтобы узнать количество предустановленных фонов в презентации:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Количество стилей заполнения фона для темы равно {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 

Используя свойство [BackgroundFillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) из класса [FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/), вы можете добавить или получить стиль фона в теме PowerPoint. 

{{% /alert %}}

Этот код C++ показывает, как задать фон для презентации:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Справочник по индексам**: 0 используется для отсутствия заполнения. Индекс начинается с 1.

{{% alert color="primary" title="Совет" %}} 

Вы можете посмотреть [фон PowerPoint](/slides/cpp/presentation-background/).

{{% /alert %}}

## **Изменить эффект темы**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы объединяются в 3 эффекта: тонкий, умеренный и интенсивный. Например, таков результат применения эффектов к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства ([FillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) из класса [FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/) вы можете изменить элементы в теме (даже более гибко, чем в опциях PowerPoint).

Этот код C++ показывает, как изменить эффект темы, изменив части элементов:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Результирующие изменения цвета заливки, типа заливки, эффекта тени и т.д.:

![todo:image_alt_text](presentation-design_11.png)