---
title: پیدا کردن و جایگزین کردن در ارائه
type: docs
weight: 20
url: /fa/net/find-and-replace-in-presentation/
---
مراحل زیر را دنبال کنید:

1. یک ارائه باز کنید.
1. متن را جستجو کنید.
1. متن را جایگزین کنید.
1. ارائه را بنویسید.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//باز کردن ارائه

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//تمام جعبه‌های متن در ارائه را دریافت کنید

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //متن مورد جایگزینی را پیدا کنید

        if (port.Text.Contains(strToFind))

        //متن موجود را با متن جدید جایگزین کنید

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **دانلود کد نمونه**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)