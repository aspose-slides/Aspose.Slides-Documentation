---
title: ノート付きTiffへの変換
type: docs
weight: 10
url: /ja/net/conversion-to-tiff-with-notes/
---

TIFF は、Aspose.Slides for .NET がサポートする、ノート付きプレゼンテーションを画像に変換するための、広く使用されている画像フォーマットの一つです。また、Notes Slide ビューでスライドのサムネイルを生成することもできます。以下は、Notes Slide ビューでプレゼンテーションの TIFF 画像を生成する方法を示す 2 つのコード スニペットです。

**Presentation** クラスが提供する **Save** メソッドを使用して、Notes Slide ビューのプレゼンテーション全体を TIFF に変換できます。また、個々のスライドに対して Notes Slide ビューでスライドのサムネイルを生成することもできます。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF notes

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)