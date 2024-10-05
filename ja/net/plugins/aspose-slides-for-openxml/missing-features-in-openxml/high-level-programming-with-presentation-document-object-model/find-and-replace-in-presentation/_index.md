---  
title: プレゼンテーション内の検索と置換  
type: docs  
weight: 20  
url: /net/find-and-replace-in-presentation/  
---  

以下は従うべき手順です：

1. プレゼンテーションを開く。
1. テキストを検索する。
1. テキストを置換する。
1. プレゼンテーションを保存する。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//プレゼンテーションを開く

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//プレゼンテーション内のすべてのテキストボックスを取得する

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //置換対象のテキストを見つける

        if (port.Text.Contains(strToFind))

        //既存のテキストを新しいテキストで置換する

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
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)  
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)  
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)  