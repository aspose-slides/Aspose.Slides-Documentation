---
title: 在簡報中變更形狀的填充顏色
type: docs
weight: 40
url: /zh-hant/net/change-the-fill-color-of-a-shape-in-a-presentation/
---
## **OpenXML 簡報**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

SetPPTShapeColor(FileName);

// 變更形狀的填充顏色。

// 測試檔必須在第一張投影片的第一個形狀上具有已填充的形狀。

public static void SetPPTShapeColor(string docName)

{
    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))
    {
        // 取得第一張投影片的關係 ID。
        PresentationPart part = ppt.PresentationPart;
        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;
        string relId = (slideIds[0] as SlideId).RelationshipId;
        // 從關係 ID 取得投影片部件。
        SlidePart slide = (SlidePart)part.GetPartById(relId);
        if (slide != null)
        {
            // 取得包含欲變更形狀的形狀樹。
            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;
            // 取得形狀樹中的第一個形狀。
            Shape shape = tree.GetFirstChild<Shape>();
            if (shape != null)
            {
                // 取得形狀的樣式。
                ShapeStyle style = shape.ShapeStyle;
                // 取得填充參考。
                Drawing.FillReference fillRef = style.FillReference;
                // 設定填充顏色為 SchemeColor Accent 6;
                fillRef.SchemeColor = new Drawing.SchemeColor();
                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;
                // 儲存已修改的投影片。
                slide.Slide.Save();
            }
        }
    }
}
``` 
## **Aspose.Slides**
我們需要遵循以下步驟在簡報中填充形狀：

- 建立 Presentation 類別的實例。
- 使用 Index 取得投影片的參考。
- 將 IShape 新增至投影片。
- 將形狀的填充類型設為實心。
- 設定形狀的顏色。
- 將修改後的簡報寫入為 PPTX 檔案。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Fill color of a shape.pptx";

//實例化代表 PPTX 的 PrseetationEx 類別
using (Presentation pres = new Presentation())
{
    //取得第一張投影片
    ISlide sld = pres.Slides[0];
    //新增矩形類型的自動圖形
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    //將填充類型設為實心
    shp.FillFormat.FillType = FillType.Solid;
    //設定矩形的顏色
    shp.FillFormat.SolidFillColor.Color = Color.Yellow;
    //將 PPTX 檔寫入磁碟
    pres.Save(FileName, SaveFormat.Pptx);
}
``` 
## **下載執行的程式碼範例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)