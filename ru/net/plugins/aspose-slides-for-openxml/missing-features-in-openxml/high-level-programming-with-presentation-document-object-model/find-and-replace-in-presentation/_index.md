---
title: Найти и заменить в презентации
type: docs
weight: 20
url: /ru/net/find-and-replace-in-presentation/
---

Ниже приведены шаги, которые следует выполнить:

1. Откройте презентацию.
1. Найдите текст.
1. Замените текст.
1. Сохраните презентацию.

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
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)