---
title: Trouver et Remplacer dans une Présentation
type: docs
weight: 20
url: /net/find-and-replace-in-presentation/
---

Voici les étapes à suivre :

1. Ouvrir une présentation.
1. Rechercher le texte.
1. Remplacer le texte.
1. Enregistrer la présentation.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

//Ouvrir la présentation

Presentation pres = new Presentation(FilePath + "Find and Replace.pptx");

//Obtenir toutes les zones de texte dans la présentation

ITextFrame[] tb = SlideUtil.GetAllTextBoxes(pres.Slides[0]);

for (int i = 0; i < tb.Length; i++)

foreach (Paragraph para in tb[i].Paragraphs)

    foreach (Portion port in para.Portions)

        //Trouver le texte à remplacer

        if (port.Text.Contains(strToFind))

        //Remplacer le texte existant par le nouveau texte

        {

            string str = port.Text;

            int idx = str.IndexOf(strToFind);

            string strStartText = str.Substring(0, idx);

            string strEndText = str.Substring(idx + strToFind.Length, str.Length - 1 - (idx + strToFind.Length - 1));

            port.Text = strStartText + strToReplaceWith + strEndText;

        }

pres.Save(FilePath + "Find and Replace.pptx",Aspose.Slides.Export.SaveFormat.Pptx);


``` 
## **Télécharger le Code Exemple**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Find%20and%20Replace%20%28Aspose.Slides%29.zip)