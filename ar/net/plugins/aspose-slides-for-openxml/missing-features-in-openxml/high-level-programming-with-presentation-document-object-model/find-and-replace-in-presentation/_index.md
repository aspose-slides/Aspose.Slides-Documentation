---
title: العثور على النص واستبداله في العرض التقديمي
type: docs
weight: 20
url: /ar/net/find-and-replace-in-presentation/
---

الخطوات التالية التي يجب اتباعها:

1. فتح عرض تقديمي.
1. بحث النص.
1. استبدال النص.
1. كتابة العرض التقديمي.

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
## **تنزيل عينة الكود**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)