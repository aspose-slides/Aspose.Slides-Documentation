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

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

string filePath = @"..\..\..\Sample Files\";
string strToFind = "old text";
string strToReplaceWith = "new text";

//Open the presentation
using (Presentation pres = new Presentation(filePath + "Find and Replace.pptx"))
{
    //Get all text boxes in the first slide
    ITextFrame[] textFrames = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

    foreach (ITextFrame textFrame in textFrames)
        foreach (IParagraph para in textFrame.Paragraphs)
            foreach (IPortion port in para.Portions)
            {
                //Find the text to be replaced
                int idx = port.Text.IndexOf(strToFind);
                if (idx < 0)
                    continue;

                //Replace the existing text with the new text
                string str = port.Text;
                string strStartText = str.Substring(0, idx);
                string strEndText = str.Substring(idx + strToFind.Length);

                port.Text = strStartText + strToReplaceWith + strEndText;
            }

    pres.Save(filePath + "Find and Replace.pptx", SaveFormat.Pptx);
}
``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)
