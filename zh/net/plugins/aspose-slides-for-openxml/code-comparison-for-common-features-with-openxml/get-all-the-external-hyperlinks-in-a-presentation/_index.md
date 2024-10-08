---
title: 获取演示文稿中的所有外部超链接
type: docs
weight: 90
url: /net/get-all-the-external-hyperlinks-in-a-presentation/
---

## **OpenXML 演示文稿**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "获取所有外部超链接.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// 返回演示文稿幻灯片中的所有外部超链接。

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// 声明一个字符串列表。

List<string> ret = new List<string>();

// 以只读方式打开演示文稿文件。

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // 遍历演示文稿部分中的所有幻灯片部分。

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // 遍历幻灯片部分中的所有链接。

        foreach (Drawing.HyperlinkType link in links)

        {

            // 遍历幻灯片部分中的所有外部关系。

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // 如果关系 ID 与链接 ID 匹配...

                if (relation.Id.Equals(link.Id))

                {

                    // 将外部关系的 URI 添加到字符串列表中。

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// 返回字符串列表。

return ret;

}


``` 
## **Aspose.Slides**
Aspose.Slides for .NET 允许开发人员在演示文稿、幻灯片和文本框级别管理超链接。**IHyperlinkQueries** 类帮助管理演示文稿中的超链接。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "获取所有外部超链接.pptx";

//实例化一个表示 PPTX 文件的 Presentation 对象

Presentation pres = new Presentation(FileName);

//从演示文稿中获取超链接

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **下载运行代码示例**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **示例代码**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/获取所有外部超链接/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)