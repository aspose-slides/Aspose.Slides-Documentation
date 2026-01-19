---
title: プレゼンテーションでの検索と置換
type: docs
weight: 20
url: /ja/net/find-and-replace-in-presentation/
---

以下の手順に従ってください:

1. プレゼンテーションを開く。
1. テキストを検索する。
1. テキストを置換する。
1. プレゼンテーションを書き込む。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//プレゼンテーションを開く

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//プレゼンテーション内のすべてのテキストボックスを取得

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //置換対象のテキストを検索

        if (port.Text.Contains(strToFind))

        //既存のテキストを新しいテキストに置換

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)