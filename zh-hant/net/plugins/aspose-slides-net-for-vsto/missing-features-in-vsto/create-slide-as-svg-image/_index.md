---
title: 建立投影片為 SVG 圖像
type: docs
weight: 70
url: /zh-hant/net/create-slide-as-svg-image/
---
若要使用 Aspose.Slides.Pptx for .NET 從任意指定的投影片產生 SVG 圖像，請依照以下步驟操作：

- 建立 Presentation 類別的執行個體。
- 使用投影片的 ID 或索引取得目標投影片的參考。
- 於記憶體串流中取得 SVG 圖像。
- 將記憶體串流儲存為檔案。

## **範例**

``` 

 //實例化一個代表簡報檔案的 Presentation 類別

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
   //存取第二張投影片
   ISlide sld = pres.Slides[1];
   //建立記憶體串流物件
   MemoryStream SvgStream = new MemoryStream();
   //產生投影片的 SVG 圖像並儲存於記憶體串流中
   sld.WriteAsSvg(SvgStream);
   SvgStream.Position = 0;
   //將記憶體串流儲存至檔案
   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))
   {
     byte[] buffer = new byte[8 * 1024];
     int len;
     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
     {
       fileStream.Write(buffer, 0, len);
     }
   }
   
SvgStream.Close();

``` 
## **下載執行範例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)

## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
欲取得更多資訊，請參閱 [Render Presentation Slides as SVG Images in .NET](/slides/zh-hant/net/render-a-slide-as-an-svg-image/)。
{{% /alert %}}