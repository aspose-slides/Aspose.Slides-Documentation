---
title: Найти и заменить в презентации
type: docs
weight: 20
url: /net/find-and-replace-in-presentation/
---

Следуйте указанным шагам:

1. Откройте презентацию.
1. Найдите текст.
1. Замените текст.
1. Запишите презентацию.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Откройте презентацию

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Получите все текстовые рамки в презентации

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Найдите текст для замены

        if (port.Text.Contains(strToFind))

        //Замените существующий текст на новый текст

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **Скачать образец кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)