---
title: あるプレゼンテーションから別のプレゼンテーションに段落を移動する
type: docs
weight: 130
url: /net/move-a-paragraph-from-one-presentation-to-another/
---

## **OpenXML プレゼンテーション**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// ソースドキュメント内の TextBody 形状の段落範囲を

// ターゲットドキュメント内の別の TextBody 形状に移動します。

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// ソースファイルを読み書きモードで開きます。

using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // ターゲットファイルを読み書きモードで開きます。

    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // ソースプレゼンテーションの最初のスライドを取得します。

        SlidePart slide1 = GetFirstSlide(sourceDoc);

        // それにおける最初の TextBody 形状を取得します。

        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();

        // TextBody 形状内の最初の段落を取得します。

        // 注意: "Drawing" は DocumentFormat.OpenXml.Drawing の名前空間のエイリアスです

        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();

        // ターゲットプレゼンテーションの最初のスライドを取得します。

        SlidePart slide2 = GetFirstSlide(targetDoc);

        // それにおける最初の TextBody 形状を取得します。

        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();

        // ソース段落をクローンし、クローンした段落をターゲットの TextBody 形状に挿入します。

        // "true" を渡すことでディープクローンが作成され、段落オブジェクトとそのオブジェクトが直接または間接的に参照するすべてのもののコピーが作成されます。

        textBody2.Append(p1.CloneNode(true));

        // ソースファイルからソース段落を削除します。

        textBody1.RemoveChild<Drawing.Paragraph>(p1);

        // 削除された段落をプレースホルダーで置き換えます。

        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());

        // ソースファイル内のスライドを保存します。

        slide1.Slide.Save();

        // ターゲットファイル内のスライドを保存します。

        slide2.Slide.Save();

    }

}

}

// プレゼンテーションドキュメント内の最初のスライドのスライド部分を取得します。

public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// 最初のスライドのリレーションシップIDを取得します

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// リレーションシップIDを使用してスライド部分を取得します。

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}

``` 
## **Aspose.Slides**
開発者がプレゼンテーションからテキストを抽出する必要があるのは珍しいことではありません。これを行うには、プレゼンテーション内のすべてのスライドのすべてのシェイプからテキストを抽出する必要があります。この記事では、Aspose.Slides を使用して Microsoft PowerPoint PPTX プレゼンテーションからテキストを抽出する方法を説明します。1つのスライドまたは全体のプレゼンテーションからテキストを抽出する場合でも、Aspose.Slides は PresentationScanner クラスとその提供する静的メソッドを使用します。これらはすべて名前空間 [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil) にパックされています。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// ソースドキュメントの TextBody 形状内の段落範囲を

// ターゲットドキュメントの別の TextBody 形状に移動します。

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    // PPTX を表す Presentation クラスをインスタンス化します

    Presentation sourcePres = new Presentation(sourceFile);

    // 最初のスライドの最初のシェイプにアクセスします

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        // プレースホルダーからテキストを取得します

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    // 最初のスライドの最初のシェイプにアクセスします

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        // プレースホルダーからテキストを取得します

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   

``` 
## **ダウンロード 実行コード例**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **サンプルコード**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Move a Paragraph/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)