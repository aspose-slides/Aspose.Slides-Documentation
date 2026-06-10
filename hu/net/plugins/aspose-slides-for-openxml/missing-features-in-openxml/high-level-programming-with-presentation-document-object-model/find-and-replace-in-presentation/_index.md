---
title: Keresés és csere a prezentációban
type: docs
weight: 20
url: /hu/net/find-and-replace-in-presentation/
---
Az alábbiak a követendő lépések:

1. Nyisson meg egy prezentációt.
1. Keresse meg a szöveget.
1. Cserélje le a szöveget.
1. Mentse el a prezentációt.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Nyissa meg a prezentációt

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Az összes szövegdoboz lekérése a prezentációból

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Keresendő szöveg megtalálása

        if (port.Text.Contains(strToFind))

        //A meglévő szöveg cseréje az új szövegre

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)