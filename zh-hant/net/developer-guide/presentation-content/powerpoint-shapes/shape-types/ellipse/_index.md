---
title: 在 .NET 中為簡報新增橢圓形
linktitle: 橢圓形
type: docs
weight: 30
url: /zh-hant/net/ellipse/
keywords:
- 橢圓
- 形狀
- 新增橢圓
- 建立橢圓
- 繪製橢圓
- 格式化橢圓
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中於 PPT 與 PPTX 簡報建立、格式化與操作橢圓形狀——並附有 C# 程式碼範例。"
---
## **概觀**

本篇文章說明如何使用 Aspose.Slides 在 PowerPoint 投影片中新增橢圓形狀。內容涵蓋建立簡易橢圓、建立格式化的橢圓，以及將更新後的簡報儲存為 PPTX 檔案。同時也會提及相關問題，例如處理橢圓的位置與大小、控制堆疊順序以及套用動畫效果。

## **建立橢圓形**
要在簡報的選取投影片中新增簡易橢圓形，請依照以下步驟操作：

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例  
2. 使用索引取得投影片的參考  
3. 透過 IShapes 物件的 AddAutoShape 方法加入類型為 Ellipse 的 AutoShape  
4. 將修改後的簡報寫入為 PPTX 檔案  

以下範例示範了如何在第一張投影片加入橢圓形。

```c#
 // 實例化代表 PPTX 的 Presentation 類別
 using (Presentation pres = new Presentation())
 {
 
     // 取得第一張投影片
     ISlide sld = pres.Slides[0];
 
     // 新增類型為橢圓的 AutoShape
     sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
 
     //Write 將 PPTX 檔案寫入磁碟
     pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
 }
```

## **建立格式化的橢圓形**
要在投影片中加入更具格式的橢圓形，請依照以下步驟操作：

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 使用索引取得投影片的參考。  
3. 透過 IShapes 物件的 AddAutoShape 方法加入類型為 Ellipse 的 AutoShape。  
4. 將橢圓形的填滿類型設為實心。  
5. 透過與 IShape 相關聯的 FillFormat 物件的 SolidFillColor.Color 屬性設定橢圓形的填充顏色。  
6. 設定橢圓形邊框的顏色。  
7. 設定橢圓形邊框的寬度。  
8. 將修改後的簡報寫入為 PPTX 檔案。  

以下範例示範了如何在簡報的第一張投影片加入格式化的橢圓形。

```c#
 // 實例化代表 PPTX 的 Presentation 類別
 using (Presentation pres = new Presentation())
 {
 
     // 取得第一張投影片
     ISlide sld = pres.Slides[0];
 
     // 新增類型為橢圓的 AutoShape
     IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
 
     // 為橢圓形狀套用一些格式設定
     shp.FillFormat.FillType = FillType.Solid;
     shp.FillFormat.SolidFillColor.Color = Color.Chocolate;
 
     // 為橢圓的線條套用一些格式設定
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
     shp.LineFormat.Width = 5;
 
     // 將 PPTX 檔案寫入磁碟
     pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
 }
```

## **常見問題**

**如何設定橢圓相對於投影片單位的精確位置與大小？**

座標與尺寸通常以 **點** 為單位指定。為了得到可預測的結果，請以投影片大小為基礎，並在賦值前將所需的毫米或英吋轉換為點。

**如何將橢圓置於其他物件之上或之下（控制堆疊順序）？**

透過將物件移至最上層或最下層來調整繪圖順序。這樣即可讓橢圓覆蓋其他物件或顯示其下方的物件。

**如何為橢圓加入出現或強調的動畫效果？**

[Apply](/slides/zh-hant/net/shape-animation/) 入口、強調或退出效果至形狀，並設定觸發條件與時間，以安排動畫的播放時機與方式。