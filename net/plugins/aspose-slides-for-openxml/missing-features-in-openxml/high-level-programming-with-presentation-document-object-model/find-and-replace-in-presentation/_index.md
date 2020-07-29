---
title: Find and Replace in Presentation
type: docs
weight: 20
url: /net/find-and-replace-in-presentation/
---

Following are the steps to follow:

1. Open a presentation.
1. Search the text.
1. Replace the text.
1. Write the presentation.

{{< highlight csharp >}}

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


{{< /highlight >}}
## **Download Sample Code**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)
