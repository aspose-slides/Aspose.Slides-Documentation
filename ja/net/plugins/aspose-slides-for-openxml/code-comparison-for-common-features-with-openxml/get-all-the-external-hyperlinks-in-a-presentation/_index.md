---
title: プレゼンテーション内のすべての外部ハイパーリンクを取得する
type: docs
weight: 90
url: /ja/net/get-all-the-external-hyperlinks-in-a-presentation/
---

## **OpenXML プレゼンテーション**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// プレゼンテーションのスライド内のすべての外部ハイパーリンクを返します。

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// 文字列のリストを宣言します。

List<string> ret = new List<string>();

// プレゼンテーションファイルを読み取り専用として開きます。

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // プレゼンテーションパート内のすべてのスライドパートを繰り返します。

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // スライドパート内のすべてのリンクを繰り返します。

        foreach (Drawing.HyperlinkType link in links)

        {

            // スライドパート内のすべての外部関係を繰り返します。 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // 関係のIDがリンクのIDと一致する場合...

                if (relation.Id.Equals(link.Id))

                {

                    // 外部関係のURIを文字列のリストに追加します。

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// 文字列のリストを返します。

return ret;

}


``` 
## **Aspose.Slides**
Aspose.Slides for .NET は、プレゼンテーション、スライド、およびテキストフレームレベルでハイパーリンクを管理する開発者をサポートします。**IHyperlinkQueries** クラスは、プレゼンテーション内のハイパーリンクを管理するのに役立ちます。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

// PPTXファイルを表すプレゼンテーションオブジェクトをインスタンス化します。

Presentation pres = new Presentation(FileName);

// プレゼンテーションからハイパーリンクを取得します。

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **動作コード例のダウンロード**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **サンプルコード**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Get all the External Hyperlinks/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)