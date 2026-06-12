---
title: Zoeken en vervangen in presentatie
type: docs
weight: 20
url: /nl/net/find-and-replace-in-presentation/
---
Hieronder staan de te volgen stappen:

1. Open een presentatie.
1. Zoek de tekst.
1. Vervang de tekst.
1. Schrijf de presentatie.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Open de presentatie

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Haal alle tekstvakken op in de presentatie

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Zoek de te vervangen tekst

        if (port.Text.Contains(strToFind))

        //Vervang bestaande tekst door de nieuwe tekst

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)