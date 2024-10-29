---
title: البحث والاستبدال في العرض التقديمي
type: docs
weight: 20
url: /ar/net/find-and-replace-in-presentation/
---

فيما يلي الخطوات التي يجب اتباعها:

1. افتح عرضًا تقديميًا.
1. ابحث عن النص.
1. استبدل النص.
1. احفظ العرض التقديمي.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//افتح العرض التقديمي

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//احصل على جميع صناديق النص في العرض التقديمي

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //ابحث عن النص المراد استبداله

        if (port.Text.Contains(strToFind))

        //استبدل النص الحالي بالنص الجديد

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **تحميل كود العينة**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)