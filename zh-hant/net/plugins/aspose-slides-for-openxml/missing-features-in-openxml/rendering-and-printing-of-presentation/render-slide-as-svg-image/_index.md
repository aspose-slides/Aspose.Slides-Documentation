---
title: 將投影片呈現為 SVG 圖像
type: docs
weight: 50
url: /zh-hant/net/render-slide-as-svg-image/
---
SVG—Scalable Vector Graphics 的縮寫—是一種用於呈現二維圖像的標準圖形類型或格式。SVG 將圖像以向量形式儲存在 XML 中，並包含定義其行為或外觀的詳細資訊。  

SVG 是少數符合以下高標準的圖像格式之一：可縮放性、互動性、效能、可存取性、可程式化等。正因如此，它在網頁開發中被廣泛使用。  

在以下情境中，您可能會想使用 SVG 檔案：

- 當您計畫將簡報以極大尺寸列印時。SVG 圖像可隨意縮放至任何解析度或層級，您可以多次調整 SVG 圖像大小而不會影響品質。  
- 當您打算在不同媒介或平台上使用投影片中的圖表與曲線圖時。大多數閱讀器均能解析 SVG 檔案。  
- 當您需要盡可能縮小圖像大小時。SVG 檔案通常比其他格式的高解析度對應檔案更小，尤其是基於點陣圖的格式（如 JPEG 或 PNG）。  

Aspose.Slides for .NET 允許您將簡報中的投影片匯出為 **SVG** 圖像。若要從任何投影片產生 SVG 圖像，請按以下步驟操作：

- 建立 Presentation 類別的執行個體。  
- 遍歷簡報中的所有投影片。  
- 透過 FileStream 將每張投影片寫入各自的 SVG 檔案。  

{{% alert color="primary" %}} 
您可以試用我們的[免費網路應用程式](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-svg)，我們在其中實作了 Aspose.Slides for .NET 的 PPT 轉 SVG 功能。 
{{% /alert %}} 

以下 C# 範例程式碼示範如何使用 Aspose.Slides 將 PPT 轉換為 SVG：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```