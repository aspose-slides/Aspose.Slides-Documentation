---
title: スライドを SVG 画像として作成
type: docs
weight: 70
url: /ja/net/create-slide-as-svg-image/
---

任意のスライドから SVG 画像を生成するには、Aspose.Slides.Pptx for .NET を使用して、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- ID またはインデックスを使用して目的のスライドの参照を取得します。
- メモリストリームで SVG 画像を取得します。
- メモリストリームをファイルに保存します。
## **Example**

```

 //Instantiate a Presentation class that represents the presentation file

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Access the second slide

   ISlide sld = pres.Slides[1];

   //Create a memory stream object

   MemoryStream SvgStream = new MemoryStream();

   //Generate SVG image of slide and save in memory stream

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Save memory stream to file

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
## **Download Running Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

詳細については、[Render Presentation Slides as SVG Images in .NET](/slides/ja/net/render-a-slide-as-an-svg-image/) をご覧ください。

{{% /alert %}}