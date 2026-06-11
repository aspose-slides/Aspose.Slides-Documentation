---
title: Hitta och ersätt i presentation
type: docs
weight: 20
url: /sv/net/find-and-replace-in-presentation/
---
Följande är stegen att följa:

1. Öppna en presentation.
1. Sök efter texten.
1. Byt ut texten.
1. Skriv presentationen.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Öppna presentationen

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Hämta alla textrutor i presentationen

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Hitta text som ska ersättas

        if (port.Text.Contains(strToFind))

        //Ersätt befintlig text med den nya texten

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Ladda ner exempelkod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)