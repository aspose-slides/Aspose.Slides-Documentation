---
title: 管理单元格
type: docs
weight: 30
url: /cpp/manage-cells/
keywords: "表格, 合并单元格, 拆分单元格, 表格单元格中的图像, C++, CPP, Aspose.Slides for C++"
description: "C++ 中 PowerPoint 演示文稿中的表格单元格"
---

## **识别合并单元格**
1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 从第一张幻灯片获取表格。
3. 遍历表格的行和列以找到合并单元格。
4. 当找到合并单元格时打印消息。

此 C++ 代码向您展示了如何识别演示文稿中的合并表格单元格：

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// 假设 Slide#0.Shape#0 是一个表格
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"单元格 {0};{1} 是合并单元格的一部分，RowSpan={2} 和 ColSpan={3}，起始于单元格 {4};{5}。", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **删除表格单元格边框**
1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义一个列宽数组。
4. 定义一个行高数组。
5. 通过 `AddTable` 方法向幻灯片添加表格。
6. 遍历每个单元格以清除顶部、底部、右侧和左侧边框。
7. 将修改后的演示文稿保存为 PPTX 文件。

此 C++ 代码向您展示了如何从表格单元格中删除边框：

``` cpp
// 实例化表示 PPTX 文件的 Presentation 类
auto pres = MakeObject<Presentation>();
// 访问第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 定义具有宽度的列和具有高度的行
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// 向幻灯片添加表格形状
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 设置每个单元格的边框格式
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// 将 PPTX 文件写入磁盘
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **合并单元格中的编号**
如果我们合并 2 组单元格 (1, 1) x (2, 1) 和 (1, 2) x (2, 2)，则生成的表格将被编号。此 C# 代码演示了该过程：

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定义具有宽度的列和具有高度的行
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 向幻灯片添加表格形状
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 设置每个单元格的边框格式
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
// 合并单元格 (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 合并单元格 (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// 将 PPTX 文件保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

我们随后通过合并 (1, 1) 和 (1, 2) 进一步合并单元格。结果是一个表格，其中心包含一个大型合并单元格：

```c++
// 文档目录的路径。
const String outPath = u"../out/MergeCells_out.pptx";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定义具有宽度的列和具有高度的行
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 向幻灯片添加表格形状
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 设置每个单元格的边框格式
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

// 合并单元格 (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 合并单元格 (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// 将 PPTX 文件保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **拆分单元格中的编号**
在之前的示例中，当表格单元格合并时，其他单元格中的编号或数值系统没有改变。

这次，我们使用一个常规表格（没有合并单元格的表格），然后尝试拆分单元格 (1,1) 来获得一个特殊表格。您可能想留意此表格的编号，可能被认为是奇怪的。然而，这就是 Microsoft PowerPoint 为表格单元格编号的方式，Aspose.Slides 也执行相同的操作。

此 C++ 代码演示了我们所描述的过程：

```c++
// 文档目录的路径。
const String outPath = u"../out/CellSplit_out.pptx";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定义具有宽度的列和具有高度的行
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 向幻灯片添加表格形状
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 设置每个单元格的边框格式
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

// 合并单元格 (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 合并单元格 (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// 拆分单元格 (1, 1)。
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// 将 PPTX 文件保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **更改表格单元格背景颜色**

此 C++ 代码向您展示了如何更改表格单元格的背景颜色：

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// 创建一个新表格
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// 为单元格设置背景颜色 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **在表格单元格中添加图像**
1. 创建 `Presentation` 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义一个列宽数组。
4. 定义一个行高数组。
5. 通过 `AddTable` 方法向幻灯片添加表格。 
6. 创建一个 `Bitmap` 对象来保存图像文件。
7. 将位图图像添加到 `IPPImage` 对象。
8. 将表格单元格的 `FillFormat` 设置为 `Picture`。
9. 将图像添加到表格的第一个单元格。
10. 将修改后的演示文稿保存为 PPTX 文件。

此 C# 代码向您展示了如何在创建表格时将图像放置在表格单元格中：

```c++
// 文档目录的路径。
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定义具有宽度的列和具有高度的行
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// 向幻灯片添加表格形状
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// 获取图像
auto img = Images::FromFile(ImagePath);

// 将图像添加到演示文稿的图像集合中
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// 将图像添加到第一个表格单元格
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// 将 PPTX 文件保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```