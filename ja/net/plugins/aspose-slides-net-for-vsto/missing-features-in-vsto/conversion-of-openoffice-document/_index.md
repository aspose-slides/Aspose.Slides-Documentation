---
title: OpenOfficeドキュメントの変換
type: docs
weight: 30
url: /ja/net/conversion-of-openoffice-document/
---

Aspose.Slides for .NETは、プレゼンテーションファイルを表す**Presentation**クラスを提供します。**Presentation**クラスは、オブジェクトがインスタンス化されるときにPresentationコンストラクターを介して**ODP**にもアクセスできるようになりました。

以下は、ODPからPPT/PPTXへの変換の例です。
## **例**
```

 // プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   // PPTX形式でPPTXプレゼンテーションを保存します

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

以下は、PPT/PPTXからODPへの変換の例です。
## **例**
``` 

 // プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   // PPTX形式でPPTXプレゼンテーションを保存します

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **実行例のダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Conversion from ODP to PPTX/Converting From and To ODP/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **サンプルコードのダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)