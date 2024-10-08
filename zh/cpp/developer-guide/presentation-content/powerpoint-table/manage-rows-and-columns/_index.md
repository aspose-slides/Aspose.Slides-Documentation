---
title: 管理行和列
type: docs
weight: 20
url: /zh/cpp/manage-rows-and-columns/
keywords: "表格, 表格行和列, PowerPoint 演示文稿, C++, CPP, Aspose.Slides for C++"
description: "在 C++ 中管理 PowerPoint 演示文稿中的表格行和列"

---

为了让您能够在 PowerPoint 演示文稿中管理表格的行和列，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) 类、[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 接口以及许多其他类型。

## **将第一行设置为标题**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例并加载演示文稿。
2. 通过索引获取幻灯片的引用。
3. 创建一个 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象并将其设置为 null。
4. 迭代所有 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 对象以找到相关的表格。
5. 将表格的第一行设置为其标题。

以下 C++ 代码演示了如何将表格的第一行设置为其标题：

```c++
// 实例化 Presentation 类
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// 访问第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 初始化 null TableEx
SharedPtr<ITable> tbl;

// 迭代形状并设置表格的引用
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// 将表格的第一行设置为标题
tbl->set_FirstRow(true);
```

## **克隆表格的行或列**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例并加载演示文稿，
2. 通过索引获取幻灯片的引用。
3. 定义一个 `columnWidth` 数组。
4. 定义一个 `rowHeight` 数组。
5. 通过 [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 方法将 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象添加到幻灯片中。
6. 克隆表格行。
7. 克隆表格列。
8. 保存修改后的演示文稿。

以下 C++ 代码演示了如何克隆 PowerPoint 表格的行或列：

```c++
// 文档目录的路径。
const String outPath = u"../out/CloningInTable_out.pptx";

// 实例化 Presentation 类
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定义带宽度的列和带高度的行
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 为幻灯片添加一个表格形状
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 为每个单元格设置边框格式
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
	SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
	for (int y = 0; y < row->get_Count(); y++)
	{
		SharedPtr<ICell> cell = row->idx_get(y);

		cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderTop()->set_Width(5);

		cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderBottom()->set_Width(5);

		cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderLeft()->set_Width(5);

		cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderRight()->set_Width(5);
	}
}

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone 在表格末尾添加一行
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone 在表格的特定位置插入一行
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone 在表格末尾添加一列
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone 在表格的特定位置插入一列
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// 将演示文稿保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **从表中删除行或列**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例并加载演示文稿，
2. 通过索引获取幻灯片的引用。
3. 定义一个 `columnWidth` 数组。
4. 定义一个 `rowHeight` 数组。
5. 通过 [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) 方法将 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象添加到幻灯片中。
6. 删除表格行。
7. 删除表格列。
8. 保存修改后的演示文稿。

以下 C++ 代码演示了如何从表格中删除行或列：

```c++
// 文档目录的路径。
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// 实例化 Presentation 类
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定义带宽度的列和带高度的行
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 为幻灯片添加一个表格形状
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// 合并单元格 (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 合并单元格 (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// 将演示文稿保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **在表行级别设置文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例并加载演示文稿，
2. 通过索引获取幻灯片的引用。
3. 从幻灯片中访问相关的 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象。
4. 设置第一行单元格的 [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/)。
5. 设置第一行单元格的 [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 和 [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/)。
6. 设置第二行单元格的 [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/)。
7. 保存修改后的演示文稿。

以下 C++ 代码演示了操作。

```c++
// 创建 Presentation 类的实例
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// 假设第一张幻灯片上的第一个形状是一个表格
// 设置第一行单元格的字体高度
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// 设置第一行单元格的文本对齐和右边距
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// 设置第二行单元格的文本竖排类型
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// 将演示文稿保存到磁盘
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **在表列级别设置文本格式**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例并加载演示文稿，
2. 通过索引获取幻灯片的引用。
3. 从幻灯片中访问相关的 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 对象。
4. 设置第一列单元格的 [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/)。
5. 设置第一列单元格的 [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 和 [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/)。
6. 设置第二列单元格的 [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/)。
7. 保存修改后的演示文稿。

以下 C++ 代码演示了操作：

```c++
// 创建 Presentation 类的实例
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// 假设第一张幻灯片上的第一个形状是一个表格

// 设置第一列单元格的字体高度
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// 在一次调用中设置第一列单元格的文本对齐和右边距
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// 设置第二列单元格的文本竖排类型
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
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