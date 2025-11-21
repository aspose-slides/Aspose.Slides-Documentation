---
title: 在 .NET 中管理演示文稿的表格单元格
linktitle: 管理单元格
type: docs
weight: 30
url: /zh/net/manage-cells/
keywords:
- 表格单元格
- 合并单元格
- 移除边框
- 拆分单元格
- 单元格中的图片
- 背景颜色
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET，轻松管理 PowerPoint 中的表格单元格。快速掌握单元格的访问、修改和样式设置，实现无缝的幻灯片自动化。"
---

## **标识合并的表格单元格**

1. 创建 `Presentation` 类的实例。
2. 从第一张幻灯片获取表格。 
3. 遍历表格的行和列以查找合并的单元格。
4. 当发现合并的单元格时输出提示信息。

下面的 C# 代码演示了如何在演示文稿中标识合并的表格单元格：
```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // 假设 Slide#0.Shape#0 是一个表格
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```


## **移除表格单元格边框**
1. 创建 `Presentation` 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 定义列宽数组。
4. 定义行高数组。
5. 使用 `AddTable` 方法向幻灯片添加表格。
6. 遍历每个单元格，清除上、下、左、右边框。
7. 将修改后的演示文稿保存为 PPTX 文件。

下面的 C# 代码演示了如何移除表格单元格的边框：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation pres = new Presentation())
{
   // 访问第一张幻灯片
    Slide sld = (Slide)pres.Slides[0];

    // 定义列宽和行高
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 向幻灯片添加表格形状
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 为每个单元格设置边框格式
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // 将 PPTX 文件写入磁盘
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **合并单元格中的编号**
如果我们合并两对单元格 (1, 1) x (2, 1) 和 (1, 2) x (2, 2)，生成的表格会进行编号。下面的 C# 代码演示了此过程：
```c#
 // 实例化表示 PPTX 文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片
    ISlide sld = presentation.Slides[0];

    // 定义列宽和行高
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 向幻灯片添加表格形状
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 为每个单元格设置边框格式
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // 合并单元格 (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // 合并单元格 (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```


随后我们进一步合并单元格，将 (1, 1) 与 (1, 2) 合并。结果是在表格中心出现一个大的合并单元格：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片
    ISlide slide = presentation.Slides[0];

    // 定义列宽和行高
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 向幻灯片添加表格形状
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 为每个单元格设置边框格式
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // 合并单元格 (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // 合并单元格 (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // 合并单元格 (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    // 将 PPTX 文件写入磁盘
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```


## **拆分单元格后的编号**
在前面的示例中，表格单元格合并后，其他单元格的编号或编号体系并未改变。

这一次，我们使用一个普通表格（没有合并单元格），然后尝试拆分单元格 (1,1) 以得到一个特殊的表格。请注意该表格的编号方式，可能看起来有些奇怪。但这正是 Microsoft PowerPoint 对表格单元格进行编号的方式，Aspose.Slides 也采用了相同的实现。

下面的 C# 代码演示了上述过程：
```c#
 // 实例化表示 PPTX 文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片
    ISlide slide = presentation.Slides[0];

    // 定义列宽和行高
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 向幻灯片添加表格形状
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 为每个单元格设置边框格式
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // 合并单元格 (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // 合并单元格 (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // 拆分单元格 (1, 1)。
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // 将 PPTX 文件写入磁盘
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```


## **更改表格单元格背景颜色**

下面的 C# 代码演示了如何更改表格单元格的背景颜色：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // 创建一个新表格
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // 设置单元格的背景颜色 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```


## **在表格单元格内添加图片**

1. 创建 `Presentation` 类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义列宽数组。
4. 定义行高数组。
5. 使用 `AddTable` 方法向幻灯片添加表格。 
6. 创建 `Bitmap` 对象以保存图像文件。
7. 将位图图像添加到 `IPPImage` 对象。
8. 将表格单元格的 `FillFormat` 设置为 `Picture`。
9. 将图像添加到表格的第一个单元格。
10. 将修改后的演示文稿保存为 PPTX 文件。

下面的 C# 代码演示了在创建表格时如何将图像放置在表格单元格内部：
```c#
// 实例化表示 PPTX 文件的 Presentation 类
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片
    ISlide slide = presentation.Slides[0];

    // 定义列宽和行高
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // 向幻灯片添加表格形状
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // 从文件加载图像并将其添加到演示文稿资源中
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 将图像添加到第一个表格单元格
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // 将 PPTX 文件保存至磁盘
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**我可以为单个单元格的不同边设置不同的线条粗细和样式吗？**

可以。上[top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)、下[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)、左[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)、右[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) 边框都有独立的属性，因此每一侧的粗细和样式都可以不同。这与文章中演示的单元格按侧分别控制边框的逻辑相符。

**如果在将图片设为单元格背景后更改列/行大小，图片会怎样？**

行为取决于[填充模式](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)（stretch/tile）。使用拉伸时，图片会随新的单元格大小调整；使用平铺时，会重新计算平铺方式。文章中提到了单元格中图像的显示模式。

**我可以为单元格的全部内容分配超链接吗？**

[超链接](/slides/zh/net/manage-hyperlinks/)可以在单元格文本框内的文本（段落）级别设置，也可以在整个表格/形状层级设置。实际操作时，您可以将链接分配给文本片段或整个单元格的全部文本。

**我可以在单个单元格内使用不同的字体吗？**

可以。单元格的文本框支持[段落](https://reference.aspose.com/slides/net/aspose.slides/portion/)（run）并拥有独立的格式设置——包括字体族、样式、大小和颜色。