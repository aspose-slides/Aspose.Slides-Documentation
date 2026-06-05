---
title: Получение эффективных свойств фигуры из презентаций на C++
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/cpp/shape-effective-properties/
keywords:
- свойства фигуры
- свойства камеры
- осветительное оборудование
- фаска фигуры
- текстовый кадр
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для C++ рассчитывает и применяет эффективные свойства фигур для точного отображения в PowerPoint."
---
## **Обзор**

В этой статье объясняется разница между **локальными** и **эффективными** свойствами. Локальные значения – это значения, которые задаются непосредственно на определённом уровне форматирования, например:

1. Свойства фрагментов на слайде.  
2. Текстовые стили прототипа фигур в макете или базовом слайде, когда у формы текстового кадра фрагмента есть такой стиль.  
3. Глобальные текстовые параметры в презентации.

Локальные значения могут быть определены или опущены на любом уровне. Когда Aspose.Slides нужен окончательный «как отрендерено» формат, он прослеживает цепочку наследования и возвращает **эффективные** значения. Получить их можно, вызвав метод `GetEffective` у локального объекта формата.

Ниже показан пример получения эффективных значений. Предполагается, что первая фигура на первом слайде – это [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) с текстовым кадром и как минимум одним фрагментом.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
Эффективные данные форматирования представляют текущие рассчитанные параметры после применения наследования. В текущей реализации некоторые объекты эффективных данных, такие как [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformateffectivedata/), могут кэшироваться внутри. Повторный вызов `GetEffective` после изменения родительского или унаследованного форматирования может обновить кэш, и ранее полученный объект может уже не отражать прежнее состояние. Если необходимо сохранить эффективные значения для последующего использования, скопируйте требуемые свойства (например, высоту шрифта, цвет заливки, стиль шрифта или выравнивание) в собственный объект данных.
{{% /alert %}}

## **Получить эффективные свойства камеры**

Aspose.Slides позволяет получить эффективные свойства камеры. Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icameraeffectivedata/) представляет неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр [ICameraEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icameraeffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/).

Ниже пример кода, показывающий, как получить эффективные свойства камеры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **Получить эффективные свойства светового оборудования**

Aspose.Slides позволяет получить эффективные свойства светового оборудования. Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilightrigeffectivedata/) представляет неизменяемый объект, содержащий эффективные свойства светового оборудования. Экземпляр [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilightrigeffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/).

Ниже пример кода, показывающий, как получить эффективные свойства светового оборудования. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **Получить эффективные свойства фаски фигуры**

Aspose.Slides позволяет получить эффективные свойства фаски фигуры. Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapebeveleffectivedata/) представляет неизменяемый объект, содержащий эффективные свойства рельефа фаски фигуры. Экземпляр [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapebeveleffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [IThreeDFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/).

Ниже пример кода, показывающий, как получить эффективные свойства верхней фаски фигуры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **Получить эффективные свойства текстового кадра**

С помощью Aspose.Slides вы можете получить эффективные свойства текстового кадра. Интерфейс [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformateffectivedata/) содержит эффективные параметры форматирования текстового кадра.

Ниже пример кода, показывающий, как получить эффективные параметры форматирования текстового кадра. Предполагается, что первая фигура на первом слайде – это [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) с текстовым кадром.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **Получить эффективные свойства стиля текста**

С помощью Aspose.Slides вы можете получить эффективные свойства стиля текста. Интерфейс [ITextStyleEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextstyleeffectivedata/) содержит эффективные параметры стиля текста.

Ниже пример кода, показывающий, как получить эффективные свойства стиля текста. Предполагается, что первая фигура на первом слайде – это [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) с текстовым кадром.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **Получить значение эффективной высоты шрифта**

С помощью Aspose.Slides вы можете получить эффективную высоту шрифта. Ниже код, демонстрирующий, как изменяется эффективная высота шрифта фрагмента после задания локальных значений высоты шрифта на разных уровнях структуры презентации.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Получить эффективный формат заливки для таблицы**

С помощью Aspose.Slides вы можете получить эффективное форматирование заливки для различных частей таблицы. Интерфейс [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifillformateffectivedata/) содержит эффективные параметры форматирования заливки. Форматирование ячейки имеет более высокий приоритет, чем форматирование строки; форматирование строки – выше, чем форматирование столбца; форматирование столбца – выше, чем форматирование всей таблицы.

В результате свойства [ICellFormatEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icellformateffectivedata/) используются при отрисовке ячейки таблицы. Ниже пример кода, показывающий, как получить эффективное форматирование заливки для различных частей таблицы. Предполагается, że первая фигура на первом слайде – это [ITable](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itable/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **Часто задаваемые вопросы**

**Возвращает ли `GetEffective` снимок состояния?**

Не всегда. Эффективные данные представляют рассчитанное форматирование после применения наследования, но некоторые объекты эффективных данных могут кэшироваться внутри. Последующий вызов `GetEffective` может пересчитать форматирование и обновить кэш, поэтому ранее полученный объект нельзя рассматривать как постоянный снимок.

**Когда следует вновь читать эффективные свойства?**

Вызовите `GetEffective` повторно после изменения локального форматирования, стилей‑родителей, форматирования макета, форматирования базового слайда или значений по умолчанию на уровне презентации. Следующий вызов переоценит иерархию форматирования и вернёт актуальный эффективный результат.

**Влияет ли изменение или удаление макета/базового слайда на уже полученные эффективные свойства?**

Да, но изменение отразится только при следующем вызове `GetEffective`. Если источник форматирования‑родителя изменён или удалён, ранее полученные эффективные данные могут стать устаревшими. После повторного вызова `GetEffective` Aspose.Slides переоценит дерево форматирования, и полученные шрифты, цвета, размеры или другие значения могут измениться.

**Можно ли изменять значения через объекты эффективных данных?**

Нет. Объекты эффективных данных лишь предоставляют вычисленные значения. Вносите изменения в локальные объекты форматирования, а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано ни на уровне фигуры, ни в макете/базовом слайде, ни в глобальных настройках?**

Эффективное значение определяется механизмом по умолчанию, включающим настройки PowerPoint и Aspose.Slides. Полученное значение становится частью текущих эффективных данных.

**Можно ли по эффективному значению шрифта определить, какой уровень предоставил размер или гарнитуру?**

Не напрямую. Эффективные данные возвращают окончательное значение. Чтобы найти источник, проверьте локальные значения на уровне фрагмента, абзаца, текстового кадра и стилей текста в макете, базовом слайде и презентации, чтобы увидеть, где первое явное определение находится.

**Почему иногда эффективные значения выглядят идентичными локальным?**

Потому что локальное значение оказалось конечным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте эффективные данные, когда нужен результат «как отрендерено» после применения всего наследования, например для согласования цветов, отступов или размеров. Если требуется сохранить эти значения независимо от последующих изменений форматирования, скопируйте нужные свойства в собственный объект. Если необходимо изменить форматирование на конкретном уровне, изменяйте локальные свойства и при необходимости опять считывайте эффективные данные для проверки результата.