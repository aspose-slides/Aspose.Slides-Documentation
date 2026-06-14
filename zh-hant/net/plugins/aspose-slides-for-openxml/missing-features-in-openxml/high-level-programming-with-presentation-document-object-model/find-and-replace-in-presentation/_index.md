---
title: 在簡報中搜尋與取代
type: docs
weight: 20
url: /zh-hant/net/find-and-replace-in-presentation/
---
以下是要遵循的步驟：

1. 開啟簡報。
1. 搜尋文字。
1. 取代文字。
1. 撰寫簡報。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//開啟簡報

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//取得簡報中的所有文字方塊

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //尋找要取代的文字

        if (port.Text.Contains(strToFind))

        //以新文字取代現有文字

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)