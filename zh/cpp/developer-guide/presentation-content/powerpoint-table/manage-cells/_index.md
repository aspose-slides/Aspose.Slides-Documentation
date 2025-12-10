---
title: 在演示文稿中使用 C++ 管理表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/cpp/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 删除边框
- 拆分单元格
- 单元格中的图片
- 背景颜色
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++，轻松管理 PowerPoint 中的表格单元格。快速掌握访问、修改和样式设置，实现无缝幻灯片自动化。"
---

## **识别合并单元格**
1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。  
2. 从第一张幻灯片获取表格。  
3. 遍历表格的行和列以查找合并的单元格。  
4. 找到合并单元格时打印消息。  

下面的 C++ 代码演示如何在演示文稿中识别合并的表格单元格：  
``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// assuming that Slide#0.Shape#0 is a table
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```


## **移除表格单元格边框**
1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义列宽数组。  
4. 定义行高数组。  
5. 通过 `AddTable` 方法向幻灯片添加表格。  
6. 遍历每个单元格，清除上、下、左、右四边的边框。  
7. 将修改后的演示文稿保存为 PPTX 文件。  

下面的 C++ 代码演示如何移除表格单元格的边框：  
``` cpp
// 实例化表示 PPTX 文件的 Presentation 类
auto pres = MakeObject<Presentation>();
// 访问第一张幻灯片
auto sld = pres->get_Slides()->idx_get(0);

// 定义列宽和行高
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// 向幻灯片添加表格形状
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 为每个单元格设置边框格式
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
如果我们合并两对单元格 (1,1)×(2,1) 和 (1,2)×(2,2)，得到的表格将会编号。下面的 C# 代码演示了该过程：  
```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Loads the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accesses the first slide
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Defines columns with widths and rows with heights
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Adds a table shape to the slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Sets the border format for each cell
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
// Merges cells (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Merges cells (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Saves the PPTX file to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


随后我们进一步合并 (1,1) 和 (1,2) 单元格。结果是在表格中心出现一个大型合并单元格：  
```c++
// 文档目录的路径。
const String outPath = u"../out/MergeCells_out.pptx";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定义列宽和行高
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 向幻灯片添加表格形状
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

// 合并单元格 (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 合并单元格 (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// 将 PPTX 文件保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **拆分单元格中的编号**
在前面的示例中，表格单元格被合并后，其他单元格的编号体系保持不变。

这一次，我们使用一个普通表格（即没有合并单元格的表格），将单元格 (1,1) 拆分，以得到一个特殊的表格。请注意该表格的编号方式，这可能看起来有些奇怪。不过，这正是 Microsoft PowerPoint 对表格单元格进行编号的方式，Aspose.Slides 与其保持一致。

下面的 C++ 代码演示了上述过程：  
```c++
// 文档目录的路径。
const String outPath = u"../out/CellSplit_out.pptx";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定义列宽和行高
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 向幻灯片添加表格形状
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

下面的 C++ 代码演示如何更改表格单元格的背景颜色：  
```cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// 创建新表格
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// 设置单元格的背景颜色
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```


## **在表格单元格中添加图片**
1. 创建 `Presentation` 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 定义列宽数组。  
4. 定义行高数组。  
5. 通过 `AddTable` 方法向幻灯片添加表格。  
6. 创建 `Bitmap` 对象以保存图片文件。  
7. 将位图图片添加到 `IPPImage` 对象。  
8. 将单元格的 `FillFormat` 设置为 `Picture`。  
9. 将图片添加到表格的第一个单元格。  
10. 将修改后的演示文稿保存为 PPTX 文件。  

下面的 C# 代码演示在创建表格时如何在表格单元格中放置图片：  
```c++
// 文档目录的路径。
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定义列宽和行高
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// 向幻灯片添加表格形状
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// 获取图片
auto img = Images::FromFile(ImagePath);

// 将图片添加到演示文稿的图像集合中
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);

// 将图片添加到第一个表格单元格
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// 将 PPTX 文件保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **常见问题解答**

**我可以为单个单元格的不同边设置不同的线粗和样式吗？**

可以。上[borderTop](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)、下[borderBottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)、左[borderLeft](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)和右[borderRight](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/)边框都有独立的属性，因此每一侧的粗细和样式可以不同。这与文章中演示的针对单元格每侧边框的控制逻辑一致。

**如果在将图片设为单元格背景后修改列/行大小，图片会怎样？**

行为取决于[填充模式](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)（stretch/tile）。拉伸模式下，图片会随新单元格大小调整；平铺模式下，平铺会重新计算。文章中提到了单元格内图片的显示模式。

**我能为单元格的所有内容分配超链接吗？**

[超链接](/slides/zh/cpp/manage-hyperlinks/)可以在单元格文本框的文字（portion）层级上设置，也可以在整个表格/形状层级上设置。实际操作中，你可以将链接分配给文字的某一部分或整个单元格的全部文字。

**我可以在单个单元格内使用不同的字体吗？**

可以。单元格的文本框支持[段落](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)（run）拥有独立的格式——包括字体族、样式、大小和颜色。