---
title: オープンオフィス ドキュメントの変換
type: docs
weight: 30
url: /ja/net/conversion-of-openoffice-document/
---

Aspose.Slides for .NET は、プレゼンテーション ファイルを表す **Presentation** クラスを提供します。**Presentation** クラスは、オブジェクトがインスタンス化される際に Presentation コンストラクタを通じて **ODP** にもアクセスできるようになりました。

以下は ODP から PPT/PPTX への変換例です。
## **Example**
```
 //プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))
{
   //PPTX 形式でプレゼンテーションを保存する
   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);
}
``` 

以下は PPT/PPTX から ODP への変換例です。
## **Example**
```
 //プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))
{
   //ODP 形式でプレゼンテーションを保存する
   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);
}
``` 
## **実行サンプルのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)