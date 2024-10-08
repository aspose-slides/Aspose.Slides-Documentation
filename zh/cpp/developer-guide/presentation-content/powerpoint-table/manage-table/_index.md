---
title: 管理表格
type: docs
weight: 10
url: /cpp/manage-table/
keywords: "表格, 创建表格, 访问表格, 表格纵横比, PowerPoint 演示文稿, C++, Aspose.Slides for C++"
description: "在 C++ 中创建和管理 PowerPoint 演示文稿中的表格"
---

在 PowerPoint 中，表格是一种高效的信息展示和表现方式。网格中的信息（按行和列排列）简单明了，易于理解。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) 类、[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 接口、[Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) 类、[ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) 接口和其他类型，使您能够在各种演示文稿中创建、更新和管理表格。

## **从头创建表格**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 定义一个 `columnWidth` 数组。
4. 定义一个 `rowHeight` 数组。
5. 通过 [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 方法将 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象添加到幻灯片中。
6. 遍历每个 [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)，为顶部、底部、右侧和左侧边框应用格式。
7. 合并表格第一行的前两个单元格。
8. 访问 [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) 的 [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/)。
9. 向 [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) 添加一些文本。
10. 保存修改后的演示文稿。

以下 C++ 代码演示了如何在演示文稿中创建表格：

```c++
// 实例化一个代表 PPTX 文件的 Presentation 类
auto pres = System::MakeObject<Presentation>();

// 访问第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 定义具有宽度的列和具有高度的行
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// 将表格形状添加到幻灯片
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 设置每个单元格的边框格式
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
// 合并行 1 的单元格 1 和 2
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// 向合并的单元格添加文本
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"合并的单元格");

// 将演示文稿保存到磁盘
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **标准表格中的编号**

在标准表格中，单元格的编号是简单的且基于零的。表格中的第一个单元格被索引为 0,0（列 0，行 0）。

例如，包含 4 列和 4 行的表格中的单元格编号如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 C++ 代码演示了如何指定表格中单元格的编号：

```c++
// 实例化一个代表 PPTX 文件的 Presentation 类
auto pres = System::MakeObject<Presentation>();

// 访问第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 定义具有宽度的列和具有高度的行
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// 将表格形状添加到幻灯片
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 设置每个单元格的边框格式
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

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。

2. 通过其索引获取包含表格的幻灯片的引用。

3. 创建一个 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象并将其设置为 null。

4. 遍历所有 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 对象，直到找到表格。

   如果您怀疑正在处理的幻灯片只包含一个表格，可以简单地检查它包含的所有形状。当一个形状被确定为表格时，您可以将其强制转换为 [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) 对象。但是，如果您处理的幻灯片包含多个表格，则最好通过其 [set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/) 方法搜索所需的表格。

5. 使用 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象操作表格。在下面的示例中，我们向表格添加了一行。

6. 保存修改后的演示文稿。

以下 C++ 代码演示了如何访问并操作现有表格：

```c++
// 实例化一个代表 PPTX 文件的 Presentation 类
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// 访问第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 初始化 null Table
System::SharedPtr<ITable> tbl;

// 遍历形状并设置对找到的表格的引用
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// 设置第二行第一列的文本
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"新");

// 将修改后的演示文稿保存到磁盘
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **对齐表格中的文本**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 将 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象添加到幻灯片中。
4. 从表格访问 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 对象。
5. 访问 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 的 [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/)。
6. 垂直对齐文本。
7. 保存修改后的演示文稿。

以下 C++ 代码演示了如何对齐表格中的文本：

```c++
// 创建 Presentation 类的实例
auto presentation = System::MakeObject<Presentation>();

// 获取第一张幻灯片
auto slide = presentation->get_Slides()->idx_get(0);

// 定义具有宽度的列和具有高度的行
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// 将表格形状添加到幻灯片
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// 访问文本框
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// 为文本框创建段落对象
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// 为段落创建部分对象
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"这里的文本");
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

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 从幻灯片访问 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象。
4. 为文本设置 [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/)。
5. 设置 [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 和 [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/)。
6. 设置 [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/)。
7. 保存修改后的演示文稿。

以下 C++ 代码演示了如何将您喜欢的格式选项应用于表格中的文本：

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

// 在一次调用中设置表格单元格的文本对齐和右边距
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// 设置表格单元格的文本垂直类型
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **获取表格样式属性**

Aspose.Slides 允许您检索表格的样式属性，以便您可以将这些细节用于另一个表格或其他地方。以下 C++ 代码演示了如何从表格预设样式中获取样式属性：

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **锁定表格的纵横比**

几何形状的纵横比是其在不同维度上的大小比率。Aspose.Slides 提供了 `AspectRatioLocked()` 属性，以允许您锁定表格和其他形状的纵横比设置。

以下 C++ 代码演示了如何锁定表格的纵横比：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"锁定纵横比设置: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"锁定纵横比设置: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```