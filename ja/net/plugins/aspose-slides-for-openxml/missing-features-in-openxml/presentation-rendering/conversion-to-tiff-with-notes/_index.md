---
title: ノート付きの Tiff 変換
type: docs
weight: 10
url: /ja/net/conversion-to-tiff-with-notes/
---
TIFF は、Aspose.Slides for .NET がサポートする、ノート付きプレゼンテーションを画像に変換するための、広く使用されている画像フォーマットの一つです。Notes Slide ビューでスライドのサムネイルを生成することもできます。以下は、Notes Slide ビューでプレゼンテーションの TIFF 画像を生成する方法を示す 2 つのコードスニペットです。

**Save** メソッド（**Presentation** クラスが提供）は、Notes Slide ビュー内のプレゼンテーション全体を TIFF に変換するために使用できます。また、個々のスライドの Notes Slide ビュー用サムネイルを生成することも可能です。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
using (Presentation pres = new Presentation(srcFileName))
{
    //各レンダリングされたスライドの下にスピーカーノートを配置します
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //ノート付きでプレゼンテーションを TIFF に保存します
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)