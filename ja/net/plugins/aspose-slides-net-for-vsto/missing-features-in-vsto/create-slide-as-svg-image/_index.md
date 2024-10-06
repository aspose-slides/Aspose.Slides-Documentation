---
title: SVG画像としてスライドを作成
type: docs
weight: 70
url: /ja/net/create-slide-as-svg-image/
---

Aspose.Slides.Pptx for .NETを使用して任意のスライドからSVG画像を生成するには、以下の手順に従ってください:

- Presentationクラスのインスタンスを作成します。
- IDまたはインデックスを使用して、目的のスライドの参照を取得します。
- メモリストリームを使ってSVG画像を取得します。
- メモリストリームをファイルに保存します。
## **例**

```
//プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //2番目のスライドにアクセス

   ISlide sld = pres.Slides[1];

   //メモリストリームオブジェクトを作成

   MemoryStream SvgStream = new MemoryStream();

   //スライドのSVG画像を生成し、メモリストリームに保存

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //メモリストリームをファイルに保存

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
## **実行例のダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Creating Slide SVG Image/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **サンプルコードのダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

詳細については、[スライドSVG画像の作成](/slides/ja/net/presentation-viewer/)をご覧ください。

{{% /alert %}}