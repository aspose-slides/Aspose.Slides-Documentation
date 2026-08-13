---
title: 从演示文稿中获取形状的有效属性（C++）
linktitle: 有效属性
type: docs
weight: 50
url: /zh/cpp/shape-effective-properties/
keywords:
- 形状属性
- 摄像机属性
- 光源装置
- 斜角形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中区分本地、继承和有效的形状格式化。"
---
## **了解本地、继承和有效属性**

PowerPoint 的格式化可以来源于多个位置。直接存储在对象上的值称为 **本地值**。如果该值未设置，PowerPoint 会查找父级格式来源，例如段落默认值、文本样式、布局或母版幻灯片、主题或演示文稿级别的默认值。这些值是 **继承值**。在整个层次结构解析完毕后剩余的值就是 **有效值**——用于渲染对象的值。

例如，文本片段可能未定义自己的字体高度。它的本地 [font height](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/) 为 `std::numeric_limits<float>::quiet_NaN()`，表示“此处未设置”。该片段可以从其段落、演示文稿的默认文本样式或其他适用来源继承高度。对片段格式调用 [GetEffective](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformat/) 将返回最终解析后的高度。

针对不同目的使用这两种格式化数据：

- 在需要控制值定义位置时，读取或更改本地格式对象，例如 [IPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformat/)。
- 在需要最终渲染结果时，读取有效数据对象，例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformateffectivedata/)。有效数据是只读的。

## **比较本地、继承和有效值**

下面的完整示例创建一个形状并在演示文稿、段落和片段层级上应用字体高度。每一步都会打印这些层级定义的值以及同一文本片段的最终有效值。它还演示了为什么在格式更改后必须重新读取有效数据。

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

// 在两个不同层级定义继承值。
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

    // 在前面的更改后读取有效数据。
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// 片段上的本地值覆盖两个继承值。
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// 更改继承值不会覆盖已有的本地值。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// 清除本地值。片段现在再次从段落继承。
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// 清除段落值。演示文稿的默认值现在提供结果。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

此示例中，优先级为片段本地格式，其次是段落格式，最后是演示文稿默认。其他对象可能具有不同的继承链，但原理相同：更具体的显式值获胜，且 [GetEffective](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformat/) 返回最终结果。

## **获取有效的文本属性**

文本格式分布在多个对象中：

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/) 解析文本框属性，例如边距、锚点、自动适应和垂直文字方向。
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextstyle/) 解析每个文本样式层级的段落格式。
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/) 解析段落属性，例如对齐、缩进和项目符号。
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformat/) 解析字符属性，例如字体高度、字形、颜色、粗体和斜体。

对于下一个示例，`text-formatting.pptx` 必须至少包含一张幻灯片和一个带有非空文本框的 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。IAutoShape 可以出现在形状集合中的任何位置；代码会搜索合适的对象并在使用前进行验证。

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

## **获取有效的 3D 属性**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformat/) 返回一个 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ithreedformateffectivedata/) 对象，汇总所有解析后的 3D 设置。其 [camera](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icameraeffectivedata/)、[light rig](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilightrigeffectivedata/)、[top bevel](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapebeveleffectivedata/) 和 [bottom bevel](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapebeveleffectivedata/) 数据公开相应的有效设置。一起读取这些相关设置可以更容易理解形状的最终 3D 外观。

对于此示例，`shape-3d.pptx` 必须在其第一页至少包含一个形状。如果希望输出包含除默认值外的数值，请对该形状应用 3D 摄像机、光照或斜角设置。

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

## **获取有效的表格格式化**

表格格式可以来源于表格样式，也可以来源于应用于整个表格、列、行或单元格的格式。对于显式定义的填充冲突，优先级为单元格、行、列，最后是整个表格。单元格的有效格式是用于绘制该单元格的最终格式。

对于此示例，`table-formatting.pptx` 必须在其第一页至少包含一个表格。该表格必须至少有一行和一列。代码会搜索 [ITable](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itable/)，而不是假设第一个形状是表格。

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

如果需要颜色而不仅仅是填充类型，请先检查有效的 [FillType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifillformateffectivedata/)，然后读取适用于该类型的属性，例如针对纯色填充的 [SolidFillColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifillformateffectivedata/)。

## **更改后重新读取有效数据**

有效数据描述了解析时的格式层次结构。在更改任何可能参与该层次结构的内容后，请再次调用 `GetEffective`，包括：

- 对象的本地格式；
- 段落或文本框默认值；
- 表格样式、表格、列、行或单元格格式；
- 布局或母版幻灯片格式；
- 主题数据或演示文稿级别的默认值；
- 分配给幻灯片的布局或母版。

不要将有效数据对象作为永久快照保存。Aspose.Slides 可能在内部缓存部分有效数据，后续的 `GetEffective` 调用可以刷新这些数据。如果需要比较更改前后的值，请在修改前将所需的标量值（例如字体高度、颜色、对齐方式或斜角宽度）复制到自己的变量中。

若要更改值，请更新相应的本地格式对象，然后调用 `GetEffective` 验证结果。有效数据对象本身是只读的。

## **FAQ**

**我如何判断是哪个层级提供的有效值？**

有效数据只包含最终值，而不指示其来源。请从最具体的层级向外检查相应的本地对象。对于文本，这可能包括片段、段落、文本框、布局、母版、主题以及演示文稿默认值。`std::numeric_limits<float>::quiet_NaN()` 或 `nullptr` 等未定义值表明搜索将继续到更高层级。

**当没有任何层级定义属性时会发生什么？**

Aspose.Slides 会解析出相应的 PowerPoint 或库默认值。即使没有本地对象显式定义，该解析后的值仍会出现在有效数据中。

**为什么有效值有时等于本地值？**

本地值在继承计算中获胜。当属性在对象上被显式设置且没有更具体的规则覆盖时，这种情况是预期的。

**何时应使用本地数据而非有效数据？**

在检查或编辑特定的格式层级时使用本地数据。需要在继承、主题规则和适用样式解析后得到最终外观时使用有效数据。完整的比较示例 [complete comparison example](#compare-local-inherited-and-effective-values) 在同一工作流中演示了两者的使用。