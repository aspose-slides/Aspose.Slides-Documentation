---
title: 演示文稿中的查找和替换
type: docs
weight: 20
url: /zh/net/find-and-replace-in-presentation/
---

以下是要遵循的步骤：

1. 打开演示文稿。
1. 搜索文本。
1. 替换文本。
1. 保存演示文稿。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Open the presentation

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Get all text boxes in the presentation

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Find text to be replaced

        if (port.Text.Contains(strToFind))

        //Replace exisitng text with the new text

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)