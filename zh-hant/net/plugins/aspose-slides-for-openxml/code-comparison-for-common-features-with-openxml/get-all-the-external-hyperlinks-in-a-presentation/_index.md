---
title: 取得簡報中所有外部超連結
type: docs
weight: 90
url: /zh-hant/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **OpenXML 簡報**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// 傳回簡報投影片中所有外部超連結。

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// 宣告一個字串清單。

List<string> ret = new List<string>();

// 以唯讀方式開啟簡報檔案。

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // 遍歷簡報部件中的所有投影片部件。

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // 遍歷投影片部件中的所有連結。

        foreach (Drawing.HyperlinkType link in links)

        {

            // 遍歷投影片部件中的所有外部關聯。 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // 如果關聯 ID 與連結 ID 相符...

                if (relation.Id.Equals(link.Id))

                {

                    // 將外部關聯的 URI 加入字串清單。

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// 傳回字串清單。

return ret;

}


``` 
## **Aspose.Slides**
Aspose.Slides for .NET 允許開發人員在簡報、投影片和文字框層級上管理超連結。**IHyperlinkQueries** 類別協助在簡報中管理超連結。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

// 實例化表示 PPTX 檔案的 Presentation 物件

Presentation pres = new Presentation(FileName);

//Get the hyperlinks from presentation

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **下載執行程式碼範例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)