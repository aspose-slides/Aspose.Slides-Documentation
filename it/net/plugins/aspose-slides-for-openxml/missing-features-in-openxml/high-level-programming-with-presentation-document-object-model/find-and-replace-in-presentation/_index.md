---
title: Trova e sostituisci nella presentazione
type: docs
weight: 20
url: /it/net/find-and-replace-in-presentation/
---
Di seguito sono riportati i passaggi da seguire:

1. Apri una presentazione.
1. Cerca il testo.
1. Sostituisci il testo.
1. Scrivi la presentazione.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Apri la presentazione

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Ottieni tutte le caselle di testo nella presentazione

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Trova il testo da sostituire

        if (port.Text.Contains(strToFind))

        //Sostituisci il testo esistente con il nuovo testo

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **Scarica il codice di esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)