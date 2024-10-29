---
title: Convertir OpenOffice ODP
type: docs
weight: 10
url: /fr/net/convert-openoffice-odp/
keywords: "Convertir ODP en PDF, ODP en PPT, ODP en PPTX, ODP en XPS, ODP en HTML, ODP en TIFF"
description: "Convertir ODP en PDF, ODP en PPT, ODP en PPTX, ODP en HTML et d'autres formats avec Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) vous permet de convertir des présentations OpenOffice ODP en plusieurs formats. L'API utilisée pour convertir des fichiers ODP en d'autres formats de document est la même que celle utilisée pour les opérations de conversion PowerPoint (PPT et PPTX).

Ces exemples vous montrent comment convertir des documents ODP en d'autres formats (il suffit de changer le fichier ODP source) :

- [Convertir ODP en HTML](/slides/fr/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convertir ODP en PDF](/slides/fr/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convertir ODP en TIFF](/slides/fr/net/convert-powerpoint-to-tiff/)
- [Convertir ODP en SWF Flash](/slides/fr/net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Convertir ODP en XPS](/slides/fr/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Convertir ODP en PDF avec des notes](/slides/fr/net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Convertir ODP en TIFF avec des notes](/slides/fr/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Par exemple, si vous devez convertir une présentation ODP en PDF, cela peut se faire de cette manière :

```csharp
using (Presentation pres = new Presentation("pres.odp"))
{
    pres.Save("pres.pdf", SaveFormat.Pdf);
}
```



## Présentation OpenDocument dans différentes applications

Lorsque un fichier de présentation OpenDocument est ouvert dans PowerPoint, il peut manquer de mise en forme par rapport à celle qu'il avait dans l'application d'origine où il a été créé, car l'application de présentation OpenDocument et l'application PowerPoint offrent des fonctionnalités et options différentes.

Voici quelques-unes des différences :
- Dans PowerPoint, tous les tableaux sont généralement chargés en dernier et superposés à d'autres formes (quel que soit l'agencement des formes sur la diapositive ODP). 
- Le remplissage d'image pour les tableaux ODP n'est pas pris en charge dans PowerPoint. 
- La rotation verticale du texte (270, empilé) et l'alignement distribué ne sont pas pris en charge dans LibreOffice/OpenOffice Impress.
- Le remplissage d'image, le remplissage dégradé et le remplissage de motif pour le texte ne sont pas pris en charge dans LibreOffice/OpenOffice Impress.

MS PowerPoint et LibreOffice/OpenOffice Impress gèrent également les listes différemment. Un fichier ODP créé dans PowerPoint ne s'ouvrira pas correctement dans LibreOffice/OpenOffice et vice versa.

Cette image montre la vue de la liste créée dans LibreOffice Impress :

![odp-list-example](odp-list-example.png)



**Aspose.Slides** enregistre les listes ODP pour s'assurer qu'elles s'affichent correctement dans LibreOffice/OpenOffice Impress.

[En savoir plus sur le format OpenDocument et PowerPoint](https://support.microsoft.com/en-gb/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0/).