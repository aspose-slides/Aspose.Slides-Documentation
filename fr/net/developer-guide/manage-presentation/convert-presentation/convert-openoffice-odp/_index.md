---
title: Convertir les présentations OpenDocument en .NET
linktitle: Convertir OpenDocument
type: docs
weight: 10
url: /fr/net/convert-openoffice-odp/
keywords:
- convertir ODP
- ODP en image
- ODP en GIF
- ODP en HTML
- ODP en JPG
- ODP en MD
- ODP en PDF
- ODP en PNG
- ODP en PPT
- ODP en PPTX
- ODP en TIFF
- ODP en vidéo
- ODP en Word
- ODP en XPS
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides pour .NET vous permet de convertir les fichiers ODP en PDF, HTML et formats d'image facilement. Optimisez vos applications .NET avec une conversion de présentations rapide et précise."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) permet de convertir des présentations OpenDocument (ODP) en de nombreux formats (HTML, PDF, TIFF, SWF, XPS, etc.). L'API utilisée pour convertir les fichiers ODP vers d’autres formats de documents est la même que celle utilisée pour les opérations de conversion PowerPoint (PPT et PPTX).

Par exemple, si vous devez convertir une présentation ODP en PDF, vous pouvez le faire comme suit :
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **Présentation OpenDocument dans différentes applications**

Lorsqu'un fichier de présentation OpenDocument (ODP) est ouvert dans PowerPoint, il peut ne pas conserver la mise en forme originale de l'application dans laquelle il a été créé. Cela se produit parce que l'application de présentation OpenDocument et l'application PowerPoint offrent des fonctionnalités et des comportements de rendu différents.

Voici quelques‑unes des différences :

- Dans PowerPoint, les tableaux sont généralement rendus en dernier et peuvent se superposer à d'autres formes, quel que soit leur ordre sur la diapositive ODP.
- Le remplissage d'image pour les tableaux ODP n'est pas pris en charge dans PowerPoint.
- La rotation verticale du texte (270°, empilé) et l'alignement distribué ne sont pas pris en charge dans LibreOffice/OpenOffice Impress.
- Le remplissage d'image, le remplissage en dégradé et le remplissage en motif pour le texte ne sont pas pris en charge dans LibreOffice/OpenOffice Impress.

MS PowerPoint et LibreOffice/OpenOffice Impress gèrent également les listes différemment. Un fichier ODP créé dans PowerPoint peut ne pas s'afficher correctement dans LibreOffice/OpenOffice Impress, et inversement.

L'image ci‑dessous montre comment une liste apparaît lorsqu'elle est créée dans LibreOffice Impress :

![ODP list example](odp-list-example.png)

Aspose.Slides enregistre les listes ODP de manière à garantir qu'elles s'affichent correctement dans LibreOffice/OpenOffice Impress.

[En savoir plus sur le format OpenDocument et PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**Que faire si la mise en forme de mon fichier ODP change après la conversion ?**

ODP et PowerPoint utilisent des modèles de présentation différents, et certains éléments — tels que les tableaux, les polices personnalisées ou les styles de remplissage — peuvent ne pas être rendus exactement de la même façon. Il est recommandé de vérifier le résultat et d’ajuster la mise en page ou la mise en forme dans le code si nécessaire.

**Dois‑je installer OpenOffice ou LibreOffice pour utiliser la conversion ODP ?**

Non, Aspose.Slides pour .NET est une bibliothèque autonome et ne nécessite pas l’installation d’OpenOffice ou de LibreOffice sur votre système.

**Puis‑je personnaliser le format de sortie lors de la conversion ODP (par ex., définir des options PDF) ?**

Oui, Aspose.Slides offre de nombreuses options pour personnaliser la sortie. Par exemple, lors de l’enregistrement au format PDF, vous pouvez contrôler la compression, la qualité des images, le rendu du texte, etc., via la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

**Aspose.Slides convient‑il au traitement ODP côté serveur ou basé sur le cloud ?**

Absolument. Aspose.Slides pour .NET est conçu pour fonctionner à la fois sur les postes de travail et sur les environnements serveur, y compris les plateformes cloud comme Azure, AWS et les conteneurs Docker, sans aucune dépendance UI.