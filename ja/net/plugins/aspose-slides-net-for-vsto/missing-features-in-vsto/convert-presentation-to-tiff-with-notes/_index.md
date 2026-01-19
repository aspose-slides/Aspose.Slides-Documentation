---
title: ノート付きプレゼンテーションを Tiff に変換
type: docs
weight: 50
url: /ja/net/convert-presentation-to-tiff-with-notes/
---

TIFF は、Aspose.Slides for .NET がノート付きプレゼンテーションを画像に変換する際にサポートしている、広く使用されている画像フォーマットの一つです。また、ノート スライド ビューでスライドのサムネイルを生成することもできます。以下は、ノート スライド ビューでプレゼンテーションの TIFF 画像を生成する方法を示す 2 つのコードスニペットです。

[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) メソッドは、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスによって提供され、ノート スライド ビュー全体のプレゼンテーションを TIFF に変換するために使用できます。また、個々のスライドに対してノート スライド ビューでスライドのサムネイルを生成することも可能です。
## **例**

``` 

  //Instantiate a Presentation object that represents a presentation file

 Presentation pres = new Presentation("Conversion.pptx");

 //Saving the presentation to TIFF notes

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **実行サンプルのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
詳細については、[PowerPoint プレゼンテーションをノート付きで TIFF に変換する (.NET)](/slides/ja/net/convert-powerpoint-to-tiff-with-notes/)をご覧ください。
{{% /alert %}}