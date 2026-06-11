---
title: Znajdź i zamień w prezentacji
type: docs
weight: 20
url: /pl/net/find-and-replace-in-presentation/
---
Poniżej znajdują się kroki do wykonania:

1. Otwórz prezentację.
1. Wyszukaj tekst.
1. Zastąp tekst.
1. Zapisz prezentację.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Otwórz prezentację

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Pobierz wszystkie pola tekstowe w prezentacji

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Znajdź tekst do zamiany

        if (port.Text.Contains(strToFind))

        //Zamień istniejący tekst na nowy tekst

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)