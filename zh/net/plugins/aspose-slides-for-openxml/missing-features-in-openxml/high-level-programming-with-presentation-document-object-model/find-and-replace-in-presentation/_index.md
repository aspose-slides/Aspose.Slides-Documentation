---
title: 在演示文稿中查找和替换
type: docs
weight: 20
url: /net/find-and-replace-in-presentation/
---

以下是需要遵循的步骤：

1. 打开演示文稿。
1. 搜索文本。
1. 替换文本。
1. 写入演示文稿。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//打开演示文稿

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//获取演示文稿中的所有文本框

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //查找需要替换的文本

        if (port.Text.Contains(strToFind))

        //将现有文本替换为新文本

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
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)