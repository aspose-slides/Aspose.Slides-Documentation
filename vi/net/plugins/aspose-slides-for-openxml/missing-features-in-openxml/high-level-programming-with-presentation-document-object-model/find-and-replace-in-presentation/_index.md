---
title: Tìm và Thay thế trong Bài thuyết trình
type: docs
weight: 20
url: /vi/net/find-and-replace-in-presentation/
---
Dưới đây là các bước cần thực hiện:

1. Mở một bài thuyết trình.
1. Tìm kiếm văn bản.
1. Thay thế văn bản.
1. Lưu bài thuyết trình.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Mở bài thuyết trình

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Lấy tất cả các hộp văn bản trong bài thuyết trình

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Tìm văn bản cần thay thế

        if (port.Text.Contains(strToFind))

        //Thay thế văn bản hiện có bằng văn bản mới

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)