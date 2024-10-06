---
title: ノート付きのTiffへの変換
type: docs
weight: 10
url: /ja/net/conversion-to-tiff-with-notes/
---

TIFFは、Aspose.Slides for .NETがノート付きのプレゼンテーションを画像に変換するためにサポートする、いくつかの広く使用されている画像フォーマットの1つです。また、ノートスライドビューでスライドのサムネイルを生成することもできます。以下は、ノートスライドビューでプレゼンテーションのTIFF画像を生成する方法を示す2つのコードスニペットです。

**Presentation**クラスによって公開されている**Save**メソッドを使用して、ノートスライドビューでプレゼンテーション全体をTIFFに変換できます。また、個々のスライドのノートスライドビューでスライドのサムネイルを生成することもできます。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "ノート付きのTiff変換.pptx";

string destFileName = FilePath + "ノート付きのTiff変換.tiff";

//プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化

Presentation pres = new Presentation(srcFileName);

//TIFFノートにプレゼンテーションを保存

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)