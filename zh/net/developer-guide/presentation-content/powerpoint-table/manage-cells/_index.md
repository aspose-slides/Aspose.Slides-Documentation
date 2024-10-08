---
title: 管理单元格
type: docs
weight: 30
url: /zh/net/manage-cells/
keywords:
- 表格
- 合并单元格
- 拆分单元格
- 表格单元格中的图片
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#或.NET中PowerPoint演示文稿中的表格单元格"
---

## **识别合并的表格单元格**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 从第一张幻灯片获取表格。
3. 遍历表格的行和列以查找合并单元格。
4. 当找到合并单元格时打印消息。

这段C#代码演示了如何识别演示文稿中的合并表格单元格：

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // 假设Slide#0.Shape#0是一个表格
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("单元格 {0};{1} 是合并单元格的一部分，RowSpan={2}和ColSpan={3}，从单元格 {4};{5} 开始。",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));
            }
        }
    }
}
```

## **移除表格单元格边框**
1. 创建一个`Presentation`类的实例。
2. 通过索引获取幻灯片的引用。 
3. 定义一个带有宽度的列数组。
4. 定义一个带有高度的行数组。
5. 通过`AddTable`方法将表格添加到幻灯片中。
6. 遍历每个单元格以清除顶部、底部、右侧和左侧边框。
7. 将修改后的演示文稿保存为PPTX文件。

这段C#代码演示了如何从表格单元格移除边框：

```c#
// 实例化表示PPTX文件的Presentation类
using (Presentation pres = new Presentation())
{
   // 访问第一张幻灯片
    Slide sld = (Slide)pres.Slides[0];

    // 定义带宽度的列和带高度的行
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 将表格形状添加到幻灯片
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

    // 将PPTX文件写入磁盘
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **合并单元格中的编号**
如果我们合并两个单元格对 (1, 1) x (2, 1) 以及 (1, 2) x (2, 2)，则结果表格将被编号。此C#代码演示了该过程：

```c#
// 实例化表示PPTX文件的Presentation类
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片
    ISlide sld = presentation.Slides[0];

    // 定义带宽度的列和带高度的行
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 将表格形状添加到幻灯片
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

然后我们进一步合并单元格，通过合并 (1, 1) 和 (1, 2)。结果是一个在其中心包含一个大合并单元格的表格：

```c#
// 实例化表示PPTX文件的Presentation类
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片
    ISlide slide = presentation.Slides[0];

    // 定义带宽度的列和带高度的行
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 将表格形状添加到幻灯片
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

    // 将PPTX文件写入磁盘
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **拆分单元格中的编号**
在之前的示例中，当表格单元格合并时，其他单元格中的编号或编号系统未发生更改。

这次，我们取一个常规表格（没有合并单元格的表格），然后尝试拆分单元格 (1,1) 来得到一个特殊的表格。您可能会想要注意该表格的编号，这可能被认为是奇怪的。然而，这就是Microsoft PowerPoint编号表格单元格的方式，而Aspose.Slides也做同样的事情。

这段C#代码演示了我们所描述的过程：

```c#
// 实例化表示PPTX文件的Presentation类
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片
    ISlide slide = presentation.Slides[0];

    // 定义带宽度的列和带高度的行
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 将表格形状添加到幻灯片
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

    // 将PPTX文件写入磁盘
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **更改单元格背景颜色**

这段C#代码演示了如何更改表格单元格的背景颜色：

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

1. 创建一个`Presentation`类的实例。
2. 通过索引获取幻灯片的引用。
3. 定义一个带有宽度的列数组。
4. 定义一个带有高度的行数组。
5. 通过`AddTable`方法将表格添加到幻灯片中。 
6. 创建一个`Bitmap`对象来保存图片文件。
7. 将位图图像添加到`IPPImage`对象。
8. 将表格单元格的`FillFormat`设置为`Picture`。
9. 将图片添加到表格的第一个单元格。
10. 将修改后的演示文稿保存为PPTX文件。

这段C#代码演示了如何在创建表格时将图片放置在表格单元格内：

```c#
// 实例化表示PPTX文件的Presentation类
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片
    ISlide slide = presentation.Slides[0];

    // 定义带宽度的列和带高度的行
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // 将表格形状添加到幻灯片
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // 从文件加载图片并将其添加到演示文稿资源中
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 将图片添加到第一个表格单元格
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // 将PPTX文件保存到磁盘
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```