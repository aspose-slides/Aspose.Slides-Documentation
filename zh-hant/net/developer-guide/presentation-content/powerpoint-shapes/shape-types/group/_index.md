---
title: .NET 中的群組簡報形狀
linktitle: 形狀群組
type: docs
weight: 40
url: /zh-hant/net/group/
keywords:
- 群組形狀
- 形狀群組
- 新增群組
- 替代文字
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習使用 Aspose.Slides for .NET 在 PowerPoint 投影片中分組與取消分組形狀——快速、步驟式指南，提供免費的 C# 程式碼。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用群組形狀。它展示了如何在投影片上新增群組形狀、在其中放置形狀，並儲存更新後的簡報。它亦示範如何存取群組內的形狀並讀取其 `AlternativeText` 值。此外，本文還簡要介紹了相關的群組形狀功能，如巢狀群組、Z 軸順序與鎖定選項。

## **新增群組形狀**
Aspose.Slides 支援在投影片上使用群組形狀。此功能協助開發人員建立更豐富的簡報。Aspose.Slides for .NET 支援新增或存取群組形狀。您可以向已新增的群組形狀中加入形狀以填充內容，或存取群組形狀的任何屬性。若要使用 Aspose.Slides for .NET 在投影片上新增群組形狀：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 使用索引取得投影片的參考。
3. 將群組形狀新增至投影片。
4. 將形狀加入已新增的群組形狀。
5. 將已修改的簡報儲存為 PPTX 檔案。

以下範例會在投影片中新增群組形狀。

```c#
// 建立 Presentation 類別實例 
using (Presentation pres = new Presentation())
{
    // 取得第一張投影片 
    ISlide sld = pres.Slides[0];

    // 取得投影片的形狀集合 
    IShapeCollection slideShapes = sld.Shapes;

    // 在投影片上新增群組形狀 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // 在已新增的群組形狀內新增形狀 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // 新增群組形狀框架 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // 將 PPTX 檔寫入磁碟 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```

## **存取 AltText 屬性**
本主題示範簡單步驟，並附有程式碼範例，說明如何新增群組形狀以及存取投影片上群組形狀的 AltText 屬性。若要使用 Aspose.Slides for .NET 存取投影片中群組形狀的 AltText：

1. 實例化代表 PPTX 檔案的 `Presentation` 類別。
2. 使用索引取得投影片的參考。
3. 存取投影片的形狀集合。
4. 存取群組形狀。
5. 存取 AltText 屬性。

以下範例會存取群組形狀的替代文字。

```c#
// 建立代表 PPTX 檔案的 Presentation 類別實例
Presentation pres = new Presentation("AltText.pptx");

// 取得第一張投影片
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // 取得投影片的形狀集合
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // 取得群組形狀。
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // 取得 AltText 屬性
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **常見問題**

**是否支援巢狀群組（群組內的群組）？**  
是的。[GroupShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/groupshape/) 具備 [ParentGroup](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/parentgroup/) 屬性，可直接顯示階層支援（群組可以是另一個群組的子群組）。

**如何控制群組相對於投影片上其他物件的 Z 軸順序？**  
使用 [GroupShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/groupshape/) 的 [ZOrderPosition](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/zorderposition/) 屬性來檢查其在顯示堆疊中的位置。

**我可以防止移動/編輯/解除群組嗎？**  
是的。群組的鎖定區段可透過 [GroupShapeLock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/groupshape/groupshapelock/) 取得，讓您限制對該物件的操作。