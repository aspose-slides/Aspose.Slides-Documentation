---
title: プレゼンテーションをノート付きでTiffに変換
type: docs
weight: 50
url: /ja/net/convert-presentation-to-tiff-with-notes/
---

TIFFは、Aspose.Slides for .NETがノート付きプレゼンテーションを画像に変換するためにサポートしているいくつかの広く使用されている画像フォーマットの1つです。また、ノートスライドビューでスライドのサムネイルを生成することもできます。以下に、ノートスライドビューでプレゼンテーションのTIFF画像を生成する方法を示す2つのコードスニペットがあります。

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスが公開する[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)メソッドを使用して、ノートスライドビューの全プレゼンテーションをTIFFに変換できます。また、個々のスライドのノートスライドビューでサムネイルを生成することも可能です。
## **例**

``` 

  // プレゼンテーションファイルを表すプレゼンテーションオブジェクトをインスタンス化

 Presentation pres = new Presentation("Conversion.pptx");

 // 限定されたノートでプレゼンテーションをTIFFに保存

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **実行例のダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Tiff conversion with note/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **サンプルコードのダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

詳細については、[ノート付きプレゼンテーションの変換](/slides/ja/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)をご覧ください。

{{% /alert %}}