---
title: Obtenir tous les hyperliens externes dans une présentation
type: docs
weight: 90
url: /fr/net/get-all-the-external-hyperlinks-in-a-presentation/
---

## **Présentation OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Renvoie tous les hyperliens externes dans les diapositives d'une présentation.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Déclare une liste de chaînes.

List<string> ret = new List<string>();

// Ouvre le fichier de présentation en lecture seule.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Itère à travers toutes les parties de diapositives dans la partie de présentation.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Itère à travers tous les liens dans la partie de diapositive.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Itère à travers toutes les relations externes dans la partie de diapositive. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Si l'ID de la relation correspond à l'ID du lien...

                if (relation.Id.Equals(link.Id))

                {

                    // Ajoute l'URI de la relation externe à la liste de chaînes.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Renvoie la liste de chaînes.

return ret;

}


``` 
## **Aspose.Slides**
Aspose.Slides pour .NET permet aux développeurs de gérer les hyperliens dans la présentation, au niveau de la présentation, de la diapositive et du cadre de texte. La classe **IHyperlinkQueries** aide à gérer les hyperliens dans une présentation.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Instancier un objet Presentation qui représente un fichier PPTX

Presentation pres = new Presentation(FileName);

//Obtenir les hyperliens de la présentation

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);

``` 
## **Télécharger l'exemple de code en cours d'exécution**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Exemple de code**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Get all the External Hyperlinks/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)