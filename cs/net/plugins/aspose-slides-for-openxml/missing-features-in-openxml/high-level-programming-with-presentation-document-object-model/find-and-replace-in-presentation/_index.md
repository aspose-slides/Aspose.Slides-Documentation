---
title: Najít a nahradit v prezentaci
type: docs
weight: 20
url: /cs/net/find-and-replace-in-presentation/
---
Následující kroky je třeba provést:

1. Otevřete prezentaci.
1. Vyhledejte text.
1. Nahraďte text.
1. Napište prezentaci.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Otevřít prezentaci

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Získat všechna textová pole v prezentaci

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Najít text k nahrazení

        if (port.Text.Contains(strToFind))

        //Nahradit existující text novým textem

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)