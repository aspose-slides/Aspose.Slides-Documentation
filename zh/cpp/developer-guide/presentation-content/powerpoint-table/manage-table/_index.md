---
title: 在 C++ 中管理演示文稿表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh/cpp/manage-table/
keywords:
- 添加表格
- 创建表格
- 访问表格
- 宽高比
- 对齐文本
- 文本格式化
- 表格样式
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 幻灯片中创建和编辑表格。发现简洁的代码示例，以简化表格工作流。"
---

PowerPoint 中的表格是展示和呈现信息的高效方式。以网格形式（按行列排列）的信息简洁易懂。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) 类、[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 接口、[Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) 类、[ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) 接口以及其他类型，以便您在各种演示文稿中创建、更新和管理表格。

## **从头创建表格**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义 `columnWidth` 数组。  
4. 定义 `rowHeight` 数组。  
5. 通过 [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 方法将 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象添加到幻灯片。  
6. 遍历每个 [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)，为上、下、左、右边框应用格式。  
7. 合并表格第一行的前两个单元格。  
8. 访问 [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) 的 [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/)。  
9. 向 [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) 添加一些文本。  
10. 保存修改后的演示文稿。

下面的 C++ 代码演示了如何在演示文稿中创建表格：
```c++
// 实例化一个表示 PPTX 文件的 Presentation 类
auto pres = System::MakeObject<Presentation>();

// 访问第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 定义列宽和行高
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// 向幻灯片添加表格形状
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 为每个单元格设置边框格式
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}
// 合并第 1 行的第 1 和第 2 个单元格
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// 向合并的单元格添加文本
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// 将演示文稿保存到磁盘
pres->Save(u"table.pptx", SaveFormat::Pptx);
```


## **标准表格中的编号**

在标准表格中，单元格的编号直观且从零开始。表格中的第一个单元格索引为 0,0（第 0 列，第 0 行）。

例如，具有 4 列 4 行的表格单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

下面的 C++ 代码演示了如何为表格中的单元格指定编号：
```c++
// 实例化表示 PPTX 文件的 Presentation 类
auto pres = System::MakeObject<Presentation>();

// 访问第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 定义列宽和行高
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// 向幻灯片添加表格形状
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 为每个单元格设置边框格式
for (const auto& row : tbl->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

// 将演示文稿保存到磁盘
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```


## **访问现有表格**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取包含表格的幻灯片的引用。  
3. 创建一个 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象并将其设为 null。  
4. 遍历所有 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 对象，直到找到表格。  

   如果您怀疑当前幻灯片只包含一个表格，可以直接检查它所包含的所有形状。当形状被识别为表格时，可以将其强制转换为 [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) 对象。但是如果幻灯片中包含多个表格，则最好通过其 [set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/) 来搜索所需的表格。  

5. 使用 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象对表格进行操作。下面的示例在表格中添加了一行新行。  
6. 保存修改后的演示文稿。

下面的 C++ 代码演示了如何访问并操作现有表格：
```c++
// 实例化一个表示 PPTX 文件的 Presentation 类
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// 访问第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 初始化为空表
System::SharedPtr<ITable> tbl;

// 遍历形状并设置对找到的表的引用
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// 为第二行第一列设置文本
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// 将修改后的演示文稿保存到磁盘
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```


## **在表格中对齐文本**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 将一个 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象添加到幻灯片。  
4. 从表格中访问一个 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 对象。  
5. 访问 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 的 [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/)。  
6. 垂直对齐文本。  
7. 保存修改后的演示文稿。

下面的 C++ 代码演示了如何在表格中对齐文本：
```c++
// 创建 Presentation 类的实例
auto presentation = System::MakeObject<Presentation>();

// 获取第一张幻灯片 
auto slide = presentation->get_Slides()->idx_get(0);

// 定义列宽和行高
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// 向幻灯片添加表格形状
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// 访问文本框
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// 为文本框创建 Paragraph 对象
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// 为段落创建 Portion 对象
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// 垂直对齐文本
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// 将演示文稿保存到磁盘
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```


## **在表格级别设置文本格式**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 从幻灯片中访问一个 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象。  
4. 为文本设置 [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) 。  
5. 设置 [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 和 [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/)。  
6. 设置 [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/)。  
7. 保存修改后的演示文稿。  

下面的 C++ 代码演示了如何对表格中的文本应用所需的格式设置：
```c++
// 创建 Presentation 类的实例
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// 假设第一张幻灯片上的第一个形状是表格
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// 设置表格单元格的字体高度
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// 一次调用设置表格单元格的文本对齐方式和右边距
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// 设置表格单元格的文本垂直方向
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```


## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便将在其他表格或其他位置使用这些细节。下面的 C++ 代码演示了如何从表格预设样式中获取样式属性：
```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```


## **锁定表格的宽高比**

几何形状的宽高比是其在不同维度上的尺寸比例。Aspose.Slides 提供了 `AspectRatioLocked()` 属性，以便您为表格和其他形状锁定宽高比设置。  

下面的 C++ 代码演示了如何锁定表格的宽高比：
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **常见问题**

**我能为整个表格及其单元格中的文本启用从右到左 (RTL) 阅读方向吗？**

可以。表格公开了 [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) 方法，段落则有 [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/)。两者结合使用可确保单元格内部的正确 RTL 顺序和渲染。

**如何防止用户在最终文件中移动或调整表格的大小？**

使用 [shape locks](/slides/zh/cpp/applying-protection-to-presentation/) 禁用移动、调整大小、选择等。这些锁同样适用于表格。

**是否支持在单元格内部插入图像作为背景？**

支持。您可以为单元格设置 [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/)，图像将根据所选模式（拉伸或平铺）覆盖单元格区域。