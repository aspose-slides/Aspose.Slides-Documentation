---
title: Получить эффективные свойства фигур из презентаций на C++
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/cpp/shape-effective-properties/
keywords:
- свойства формы
- свойства камеры
- система освещения
- форма фаски
- текстовый кадр
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для C++ чтобы различать локальное, унаследованное и эффективное форматирование фигур в презентациях PowerPoint."
---
## **Поймите локальные, унаследованные и эффективные свойства**

PowerPoint форматирование может поступать из нескольких источников. Значение, хранящееся непосредственно в объекте, является его **локальным значением**. Если это значение не задано, PowerPoint смотрит на родительские источники форматирования, такие как стиль абзаца по умолчанию, стиль текста, разметка или шаблонный слайд, тема или значения по умолчанию уровня презентации. Эти значения являются **унаследованными значениями**. Значение, которое остается после разрешения всей иерархии, — это **эффективное значение** — значение, используемое для отображения объекта.

Для примера часть текста может не определять собственный размер шрифта. Ее локальный [font height](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/) будет `std::numeric_limits<float>::quiet_NaN()`, что означает «не задано здесь». Часть может унаследовать высоту от своего абзаца, стиля текста по умолчанию презентации или другого применимого источника. Вызов [GetEffective](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformat/) для формата части возвращает окончательно разрешённую высоту.

Используйте два типа данных форматирования для разных целей:

- Читать или изменять объект локального формата, такой как [IPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformat/), когда необходимо контролировать, где определяется значение.
- Читать объект эффективных данных, такой как [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformateffectivedata/), когда нужен окончательный отрисованный результат. Эффективные данные только для чтения.

## **Сравнение локальных, унаследованных и эффективных значений**

В следующем полном примере создаётся shape и задаются размеры шрифта на уровнях презентации, абзаца и части. На каждом шаге выводятся значения, определённые на этих уровнях, и получаемое эффективное значение для той же части текста. Также демонстрируется, почему эффективные данные необходимо считывать повторно после изменения форматирования.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Определите унаследованные значения на двух разных уровнях.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Прочитайте эффективные данные после предыдущих изменений.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Локальное значение в части переопределяет оба унаследованных значения.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Изменение унаследованного значения не переопределяет существующее локальное значение.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Сбросьте локальное значение. Теперь часть снова наследует от абзаца.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Сбросьте значение абзаца. Теперь результат берётся из значения по умолчанию презентации.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Приоритет в этом примере: локальное форматирование части, затем форматирование абзаца, затем значение по умолчанию презентации. Другие объекты могут иметь разные цепочки наследования, но принцип тот же: более конкретное явно заданное значение выигрывает, и [GetEffective](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformat/) возвращает окончательный результат.

## **Получение эффективных текстовых свойств**

Форматирование текста распределено по нескольким объектам:

- Метод [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/) определяет свойства текстового кадра, такие как отступы, привязка, автоподгонка и вертикальное направление текста.
- Метод [ITextStyle::GetEffective](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextstyle/) определяет форматирование абзаца для каждого уровня стиля текста.
- Метод [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/) определяет свойства абзаца, такие как выравнивание, отступы и маркеры.
- Метод [IPortionFormat::GetEffective](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformat/) определяет свойства символов, такие как высота шрифта, гарнитура, цвет, полужирный и курсив.

Для следующего примера файл `text-formatting.pptx` должен содержать как минимум один слайд и одну [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) с непустым текстовым кадром. IAutoShape может находиться в любой позиции коллекции фигур; код ищет подходящий объект и проверяет его перед использованием.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Получение эффективных 3D‑свойств**

Метод [IThreeDFormat::GetEffective](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformat/) возвращает один объект [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ithreedformateffectivedata/), который группирует все разрешённые 3D‑настройки. Его данные [camera](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapebeveleffectivedata/) и [bottom bevel](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapebeveleffectivedata/) раскрывают соответствующие эффективные настройки. Одновременное чтение этих связанных настроек упрощает понимание окончательного 3D‑вида фигуры.

Для этого примера файл `shape-3d.pptx` должен содержать как минимум одну фигуру на первом слайде. Примените к этой фигуре 3D‑камеру, освещение или настройки фаски, если хотите, чтобы вывод содержал значения, отличные от стандартных.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Получение эффективного форматирования таблицы**

Форматирование таблицы может поступать из стиля таблицы и из форматов, применённых ко всей таблице, столбцу, строке или отдельной ячейке. При конфликте явно заданных заливок приоритет такой: ячейка, строка, столбец и затем вся таблица. Эффективный формат ячейки — это окончательный формат, используемый для отрисовки этой ячейки.

Для этого примера файл `table-formatting.pptx` должен содержать как минимум одну таблицу на первом слайде. Таблица должна иметь как минимум одну строку и один столбец. Код ищет объект [ITable](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itable/), а не предполагает, что первая фигура — это таблица.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Если вам нужен цвет, а не только тип заливки, сначала проверьте эффективный [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifillformateffectivedata/), а затем считайте свойство, соответствующее этому типу — например, [SolidFillColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifillformateffectivedata/) для сплошной заливки.

## **Повторное чтение эффективных данных после изменений**

Эффективные данные описывают иерархию форматирования в момент её разрешения. Вызовите `GetEffective` повторно после изменения любого элемента, который может участвовать в этой иерархии, включая:

- локальное форматирование объекта;
- значения по умолчанию абзаца или текстового кадра;
- стиль таблицы, таблицу, столбец, строку или формат ячейки;
- форматирование разметки или шаблонного слайда;
- данные темы или значения по умолчанию уровня презентации;
- разметка или шаблон, назначенные слайду.

Не храните объект эффективных данных как постоянный снимок. Aspose.Slides может кэшировать некоторые эффективные данные внутри, и последующий вызов `GetEffective` может обновить эти данные. Если необходимо сравнить значения до и после изменения, скопируйте нужные скалярные значения — например, высоту шрифта, цвет, выравнивание или ширину фаски — в свои переменные перед внесением изменения.

Чтобы изменить значение, обновите соответствующий объект локального формата, а затем вызовите `GetEffective` для проверки результата. Объекты эффективных данных сами по себе только для чтения.

## **Часто задаваемые вопросы**

**Как определить, какой уровень предоставил эффективное значение?**

Эффективные данные содержат окончательное значение, а не его источник. Проверяйте соответствующие локальные объекты, начиная с самого конкретного уровня и продвигаясь наружу. Для текста это могут быть часть, абзац, текстовый кадр, разметка, шаблон, тема и значения по умолчанию презентации. Неопределённые значения, такие как `std::numeric_limits<float>::quiet_NaN()` или `nullptr`, указывают, что поиск продолжается на следующем уровне.

**Что происходит, когда ни один уровень не определяет свойство?**

Aspose.Slides определяет соответствующее значение по умолчанию PowerPoint или библиотеки. Это разрешённое значение появляется в эффективных данных, даже если ни один локальный объект явно его не задаёт.

**Почему эффективное значение иногда совпадает с локальным значением?**

Локальное значение победило в расчёте наследования. Это ожидаемо, когда свойство явно задано в объекте и никакое более конкретное правило его не переопределяет.

**Когда следует использовать локальные данные вместо эффективных?**

Используйте локальные данные для проверки или изменения конкретного уровня форматирования. Используйте эффективные данные, когда нужен окончательный вид после применения наследования, правил темы и соответствующих стилей. [полный пример сравнения](#compare-local-inherited-and-effective-values) демонстрирует оба подхода в одном рабочем процессе.