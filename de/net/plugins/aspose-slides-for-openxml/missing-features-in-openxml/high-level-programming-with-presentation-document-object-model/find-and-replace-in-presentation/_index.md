---  
title: Suchen und Ersetzen in Präsentationen  
type: docs  
weight: 20  
url: /de/net/find-and-replace-in-presentation/  
---  
  
Folgende Schritte sind zu befolgen:  
  
1. Öffnen Sie eine Präsentation.  
1. Suchen Sie den Text.  
1. Ersetzen Sie den Text.  
1. Schreiben Sie die Präsentation.  
  
``` csharp  
  
 string FilePath = @"..\..\..\Sample Files\";  
  
//Öffnen Sie die Präsentation  
  
Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");  
  
//Holen Sie sich alle Textfelder in der Präsentation  
  
ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);  
  
for (int i = 0; i < tb.Length; i++)  
  
foreach (Paragraph para in tb[i].Paragraphs)  
  
    foreach (Portion port in para.Portions)  
  
        //Finden Sie den Text, der ersetzt werden soll  
  
        if (port.Text.Contains(strToFind))  
  
        //Ersetzen Sie den vorhandenen Text durch den neuen Text  
  
        {  
  
            string str = port.Text;  
  
            int idx = str.IndexOf(strToFind);  
  
            string strStartText = str.Substring(0, idx);  
  
            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));  
  
            port.Text = strStartText + strToReplaceWith + strEndText;  
  
        }  
  
pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);  
  
```  
## **Beispielcode herunterladen**  
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)  
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)  
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)  