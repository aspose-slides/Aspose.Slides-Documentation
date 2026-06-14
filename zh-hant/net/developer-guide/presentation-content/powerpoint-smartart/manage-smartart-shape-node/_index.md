---
title: 在 .NET 中管理簡報的 SmartArt 形狀節點
linktitle: SmartArt 形狀節點
type: docs
weight: 30
url: /zh-hant/net/manage-smartart-shape-node/
keywords:
- SmartArt 節點
- 子節點
- 新增節點
- 節點位置
- 存取節點
- 移除節點
- 自訂位置
- 助理節點
- 填充格式
- 渲染節點
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 管理 PPT 和 PPTX 中的 SmartArt 形狀節點。取得清晰的程式碼範例與技巧，提升簡報效率。"
---
## **概觀**

PowerPoint 簡報中的 SmartArt 圖形是透過包含文字的節點來組織，這些節點定義了圖表的結構。Aspose.Slides 允許您以程式方式操作這些 SmartArt 節點：新增節點與子節點、在特定位置插入子節點、存取現有節點，並讀取它們的文字、層級與位置。

本文說明如何管理 SmartArt 形狀節點。內容包括如何移除節點、依索引或位置操作子節點、將助理節點轉為普通節點、調整 SmartArt 節點形狀的位置、大小與旋轉、設定節點填充格式，以及為 SmartArt 子節點產生縮圖影像。

## **新增 SmartArt 節點**
Aspose.Slides for .NET 提供了最簡單的 API 以最容易的方式管理 SmartArt 形狀。以下範例程式碼說明如何在 SmartArt 形狀內新增節點與子節點。

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例，並載入含有 SmartArt Shape 的簡報。
- 依索引取得第一張投影片的參考。
- 巡覽第一張投影片內的每個形狀。
- 若形狀為 SmartArt 類型，則將選取的形狀型別轉換為 SmartArt。
- 在 SmartArt 的 NodeCollection 中加入新節點，並在 TextFrame 中設定文字。
- 接著在剛新增的 SmartArt 節點中加入子節點，並在 TextFrame 中設定文字。
- 儲存簡報。

```c#
// 載入所需的簡報
Presentation pres = new Presentation("AddNodes.pptx");

// 巡覽第一張投影片內的每個形狀
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // 檢查形狀是否為 SmartArt 類型
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // 將形狀型別轉換為 SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // 新增 SmartArt 節點
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // 新增文字
        TemNode.TextFrame.Text = "Test";

        // 在父節點中新增子節點。它會被加入至集合的末端
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // 新增文字
        newNode.TextFrame.Text = "New Node Added";

    }
}

// 儲存簡報
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **在特定位置新增 SmartArt 節點**
以下範例程式碼說明如何在 SmartArt 形狀的相對節點中於特定位置加入子節點。

- 建立 `Presentation` 類別的實例。
- 依索引取得第一張投影片的參考。
- 在取得的投影片中加入一個 StackedList 類型的 SmartArt 形狀。
- 取得已加入 SmartArt 形狀的第一個節點。
- 接著在選取的節點的第 2 個位置加入子節點，並設定其文字。
- 儲存簡報。

```c#
// 建立簡報實例
Presentation pres = new Presentation();

// 取得簡報投影片
ISlide slide = pres.Slides[0];

// 新增 SmartArt IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// 取得索引為 0 的 SmartArt 節點
ISmartArtNode node = smart.AllNodes[0];

// 在父節點的第 2 個位置新增子節點
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// 新增文字
chNode.TextFrame.Text = "Sample Text Added";

// 儲存簡報
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **存取 SmartArt 節點**
以下範例程式碼說明如何存取 SmartArt 形狀內的節點。請注意，SmartArt 的 LayoutType 為唯讀，僅在加入 SmartArt 形狀時設定。

- 建立 `Presentation` 類別的實例，並載入含有 SmartArt Shape 的簡報。

- 依索引取得第一張投影片的參考。

- 巡覽第一張投影片內的每個形狀。

- 若形狀為 SmartArt 類型，則將選取的形狀型別轉換為 SmartArt。

- 巡覽 SmartArt 形狀內的所有節點。

- 存取並顯示資訊，如 SmartArt 節點的位置、層級與文字。

  ```c#
  // 載入所需的簡報
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // 巡覽第一張投影片內的每個形狀
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // 檢查形狀是否為 SmartArt 類型
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // 將形狀型別轉換為 SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // 巡覽 SmartArt 內的所有節點
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // 取得索引 i 的 SmartArt 節點
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // 列印 SmartArt 節點參數
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```


## **存取 SmartArt 子節點**
以下範例程式碼說明如何存取屬於 SmartArt 形狀各節點的子節點。

- 建立 PresentationEx 類別的實例，並載入含有 SmartArt Shape 的簡報。
- 依索引取得第一張投影片的參考。
- 巡覽第一張投影片內的每個形狀。
- 若形狀為 SmartArt 類型，則將選取的形狀型別轉換為 SmartArtEx。
- 巡覽 SmartArt 形狀內的所有節點。
- 對每個選取的 SmartArt 形狀節點，巡覽該節點內的所有子節點。
- 存取並顯示資訊，如子節點的位置、層級與文字。

```c#
// 載入所需的簡報
Presentation pres = new Presentation("AccessChildNodes.pptx");

// 巡覽第一張投影片內的每個形狀
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // 檢查形狀是否為 SmartArt 類型
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // 將形狀型別轉換為 SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // 巡覽 SmartArt 內的所有節點
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // 取得索引 i 的 SmartArt 節點
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // 巡覽索引 i 的 SmartArt 節點的子節點
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // 取得 SmartArt 節點的子節點
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // 列印 SmartArt 子節點參數
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```



## **在特定位置存取 SmartArt 子節點**
本範例示範如何在特定位置存取屬於 SmartArt 形狀各節點的子節點。

- 建立 `Presentation` 類別的實例。
- 依索引取得第一張投影片的參考。
- 加入一個 StackedList 類型的 SmartArt 形狀。
- 取得已加入的 SmartArt 形狀。
- 取得索引為 0 的節點。
- 使用 GetNodeByPosition() 方法取得該節點的第 1 個子節點。
- 存取並顯示資訊，如子節點的位置、層級與文字。

```c#
// 建立簡報實例
Presentation pres = new Presentation();

// 取得第一張投影片
ISlide slide = pres.Slides[0];

// 在第一張投影片中加入 SmartArt 形狀
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// 取得索引為 0 的 SmartArt 節點
ISmartArtNode node = smart.AllNodes[0];

// 取得父節點中位置為 1 的子節點
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// 列印 SmartArt 子節點參數
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```



## **移除 SmartArt 節點**
本範例說明如何移除 SmartArt 形狀內的節點。

- 建立 `Presentation` 類別的實例，並載入含有 SmartArt Shape 的簡報。
- 依索引取得第一張投影片的參考。
- 巡覽第一張投影片內的每個形狀。
- 若形狀為 SmartArt 類型，則將選取的形狀型別轉換為 SmartArt。
- 檢查 SmartArt 是否有超過 0 個節點。
- 選取要刪除的 SmartArt 節點。
- 使用 RemoveNode() 方法移除選取的節點，並儲存簡報。

```c#
// 載入所需的簡報
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // 巡覽第一張投影片內的每個形狀
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // 檢查形狀是否為 SmartArt 類型
        if (shape is ISmartArt)
        {
            // 將形狀型別轉換為 SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // 取得索引為 0 的 SmartArt 節點
                ISmartArtNode node = smart.AllNodes[0];

                // 移除選取的節點
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // 儲存簡報
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **在特定位置移除 SmartArt 節點**
本範例說明如何在特定位置移除 SmartArt 形狀內的節點。

- 建立 `Presentation` 類別的實例，並載入含有 SmartArt Shape 的簡報。
- 依索引取得第一張投影片的參考。
- 巡覽第一張投影片內的每個形狀。
- 若形狀為 SmartArt 類型，則將選取的形狀型別轉換為 SmartArt。
- 選取索引為 0 的 SmartArt 形狀節點。
- 檢查所選的 SmartArt 節點是否有超過 2 個子節點。
- 使用 RemoveNodeByPosition() 方法移除位置為 1 的子節點。
- 儲存簡報。

```c#
// 載入所需的簡報             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// 巡覽第一張投影片內的每個形狀
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // 檢查形狀是否為 SmartArt 類型
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // 將形狀型別轉換為 SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // 取得索引為 0 的 SmartArt 節點
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // 移除位置為 1 的子節點
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// 儲存簡報
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **為 SmartArt 物件中的子節點設定自訂位置**
現在 Aspose.Slides for .NET 支援設定 SmartArtShape 的 X 與 Y 屬性。以下程式碼片段示範如何設定自訂的 SmartArtShape 位置、大小與旋轉，另請注意，新增節點會重新計算所有節點的位置與大小。

```c#
// 載入所需的簡報
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// 移動 SmartArt 形狀至新位置
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// 更改 SmartArt 形狀的寬度
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// 更改 SmartArt 形狀的高度
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// 更改 SmartArt 形狀的旋轉
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```



## **檢查助理節點**
以下範例程式碼說明如何在 SmartArt 節點集合中識別助理節點並變更其狀態。

- 建立 PresentationEx 類別的實例，並載入含有 SmartArt Shape 的簡報。
- 依索引取得第二張投影片的參考。
- 巡覽第一張投影片內的每個形狀。
- 若形狀為 SmartArt 類型，則將選取的形狀型別轉換為 SmartArtEx。
- 巡覽 SmartArt 形狀內的所有節點，並檢查它們是否為助理節點。
- 將助理節點的狀態變更為普通節點。
- 儲存簡報。

```c#
// 建立簡報實例
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // 巡覽第一張投影片內的每個形狀
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // 檢查形狀是否為 SmartArt 類型
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // 將形狀型別轉換為 SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // 巡覽 SmartArt 形狀的所有節點

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // 檢查節點是否為助理節點
                if (node.IsAssistant)
                {
                    // 將助理節點設為 false，並將其轉為普通節點
                    node.IsAssistant = false;
                }
            }
        }
    }
    // 儲存簡報
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **設定節點的填充格式**
Aspose.Slides for .NET 允許您新增自訂的 SmartArt 形狀並設定其填充格式。本文說明如何建立與存取 SmartArt 形狀，以及使用 Aspose.Slides for .NET 為其節點設定填充格式。

請依照以下步驟操作：

- 建立 `Presentation` 類別的實例。
- 依索引取得投影片的參考。
- 透過設定 LayoutType 新增 SmartArt 形狀。
- 為 SmartArt 形狀的節點設定 FillFormat。
- 將修改後的簡報寫入 PPTX 檔案。

```c#
using (Presentation presentation = new Presentation())
{
    // 存取投影片
    ISlide slide = presentation.Slides[0];

    // 新增 SmartArt 形狀和節點
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // 設定節點填充顏色
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // 儲存簡報
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```



## **產生 SmartArt 子節點的縮圖**
開發人員可以依照以下步驟產生 SmartArt 子節點的縮圖：

1. 建立代表 PPTX 檔案的 `Presentation` 類別。
2. 新增 SmartArt。
3. 依索引取得節點的參考。
4. 取得縮圖影像。
5. 以任意所需的影像格式儲存縮圖。

以下範例示範產生 SmartArt 子節點的縮圖

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **常見問題集**

**支援 SmartArt 動畫嗎？**

是的。SmartArt 被視為一般形狀，您可以[套用標準動畫](/slides/zh-hant/net/shape-animation/)（進入、退出、強調、移動路徑）並調整時間。必要時亦可為 SmartArt 節點內的形狀加入動畫。

**如果不知道內部 ID，如何可靠地在投影片上定位特定的 SmartArt？**

請使用[替代文字]https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/alternativetext/）進行指定並搜尋。為 SmartArt 設定具辨識性的 AltText，即可在程式中不依賴內部識別碼而找到它。

**將簡報轉為 PDF 時，SmartArt 的外觀會被保留嗎？**

會。Aspose.Slides 在[PDF 匯出](/slides/zh-hant/net/convert-powerpoint-to-pdf/)過程中以高視覺保真度呈現 SmartArt，保持版面、色彩與效果。

**我可以擷取整個 SmartArt 的影像（用於預覽或報告）嗎？**

可以。您可以將 SmartArt 形狀渲染為[點陣圖格式]https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getimage/）或[SVG]https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/writeassvg/），以產生可縮圖、報告或網路使用的向量或點陣圖輸出。