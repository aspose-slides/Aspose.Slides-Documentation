---
title: Convertir les présentations OpenDocument (ODP) en C#
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
description: "Aspose.Slides pour .NET vous permet de convertir ODP en PDF, HTML et formats d'image en toute simplicité. Accélérez vos applications .NET avec une conversion de présentations rapide et précise."
---

## **Aperçu**

Aspose.Slides for .NET fournit une API robuste pour convertir des présentations OpenDocument (ODP) en divers autres formats. En suivant une approche similaire à celle utilisée pour les fichiers PowerPoint (PPT et PPTX), les développeurs peuvent facilement exporter des documents ODP vers des formats tels que HTML, PDF, TIFF, JPG, XPS, et plus encore.

Ces exemples montrent comment convertir des documents ODP vers d’autres formats (il suffit de changer la source pour un fichier ODP) :

- [Convertir ODP en HTML](/slides/fr/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convertir ODP en PDF](/slides/fr/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convertir ODP en TIFF](/slides/fr/net/convert-powerpoint-to-tiff/)
- [Convertir ODP en SWF](/slides/fr/net/convert-powerpoint-to-swf-flash/)
- [Convertir ODP en XPS](/slides/fr/net/convert-powerpoint-to-xps/)
- [Convertir ODP en PDF avec notes](/slides/fr/net/convert-powerpoint-to-pdf-with-notes/)
- [Convertir ODP en TIFF avec notes](/slides/fr/net/convert-powerpoint-to-tiff-with-notes/)

Par exemple, convertir une présentation ODP en PDF ne nécessite que quelques lignes de code en C# :
```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```


## **Présentations OpenDocument dans différentes applications**

Lorsqu’un fichier de présentation OpenDocument (ODP) est ouvert dans PowerPoint, il peut ne pas conserver la mise en forme d’origine de l’application dans laquelle il a été créé. Cela se produit parce que l’application de présentation OpenDocument et l’application PowerPoint offrent des fonctionnalités et des comportements de rendu différents.

Voici quelques-unes des différences :

- Dans PowerPoint, les tableaux sont généralement rendus en dernier et peuvent se superposer à d’autres formes, quel que soit leur ordre sur la diapositive ODP.
- Le remplissage d’image pour les tableaux ODP n’est pas pris en charge dans PowerPoint.
- La rotation verticale du texte (270°, empilé) et l’alignement distribué ne sont pas pris en charge dans LibreOffice/OpenOffice Impress.
- Le remplissage d’image, le remplissage en dégradé et le remplissage en motif pour le texte ne sont pas pris en charge dans LibreOffice/OpenOffice Impress.

MS PowerPoint et LibreOffice/OpenOffice Impress gèrent également les listes différemment. Un fichier ODP créé dans PowerPoint peut ne pas s’afficher correctement dans LibreOffice/OpenOffice Impress, et inversement.

L’image ci-dessous montre comment une liste apparaît lorsqu’elle est créée dans LibreOffice Impress :

![ODP list example](odp-list-example.png)

Aspose.Slides enregistre les listes ODP de manière à garantir qu’elles sont affichées correctement dans LibreOffice/OpenOffice Impress.

[En savoir plus sur le format OpenDocument et PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**Que se passe-t-il si la mise en forme de mon fichier ODP change après la conversion ?**

ODP et PowerPoint utilisent des modèles de présentation différents, et certains éléments—comme les tableaux, les polices personnalisées ou les styles de remplissage—peuvent ne pas être rendus exactement de la même manière. Il est recommandé de vérifier la sortie et d’ajuster la mise en page ou la mise en forme dans le code si nécessaire.

**Dois-je installer OpenOffice ou LibreOffice pour utiliser la conversion ODP ?**

Non, Aspose.Slides for .NET est une bibliothèque autonome et ne nécessite pas l’installation d’OpenOffice ou de LibreOffice sur votre système.

**Puis-je personnaliser le format de sortie lors de la conversion ODP (par ex., définir des options PDF) ?**

Oui, Aspose.Slides offre de nombreuses options pour personnaliser la sortie. Par exemple, lors de l’enregistrement en PDF, vous pouvez contrôler la compression, la qualité des images, le rendu du texte, et plus encore via la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

**Aspose.Slides convient-il au traitement ODP côté serveur ou dans le cloud ?**

Absolument. Aspose.Slides for .NET est conçu pour fonctionner à la fois sur des postes de travail et sur des environnements serveur, y compris les plateformes cloud telles qu’Azure, AWS et les conteneurs Docker, sans aucune dépendance UI.