---
title: Convertir des présentations OpenDocument en JavaScript
linktitle: Convertir OpenDocument
type: docs
weight: 10
url: /fr/nodejs-java/convert-openoffice-odp/
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
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides pour Node.js vous permet de convertir ODP en PDF, HTML et formats d'image facilement. Accélérez vos applications avec une conversion de présentations rapide et précise."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) permet de convertir des présentations OpenDocument (ODP) en de nombreux formats (HTML, PDF, TIFF, SWF, XPS, etc.). L'API utilisée pour convertir les fichiers ODP en d'autres formats de document est la même que celle utilisée pour les opérations de conversion PowerPoint (PPT et PPTX).

Par exemple, si vous devez convertir une présentation ODP en PDF, vous pouvez le faire comme suit :
```js
let presentation = null;
try {
  presentation = new aspose.slides.Presentation("presentation.odp");
  presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Que se passe-t-il si le formatage de mon fichier ODP change après la conversion ?**

ODP et PowerPoint utilisent des modèles de présentation différents, et certains éléments—comme les tableaux, les polices personnalisées ou les styles de remplissage—peuvent ne pas être rendus exactement de la même façon. Il est recommandé de vérifier le résultat et d'ajuster la mise en page ou le formatage dans le code si nécessaire.

**Dois‑je installer OpenOffice ou LibreOffice pour utiliser la conversion ODP ?**

Non, Aspose.Slides est une bibliothèque autonome et ne nécessite pas l'installation d'OpenOffice ou de LibreOffice sur votre système.

**Puis‑je personnaliser le format de sortie lors de la conversion ODP (par ex., définir des options PDF) ?**

Oui, Aspose.Slides offre de nombreuses options pour personnaliser la sortie. Par exemple, lors de l'enregistrement au format PDF, vous pouvez contrôler la compression, la qualité des images, le rendu du texte, etc., via la classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**Aspose.Slides convient‑il au traitement ODP côté serveur ou dans le cloud ?**

Absolument. Aspose.Slides est conçu pour fonctionner à la fois sur les postes de travail et sur les serveurs, y compris les plateformes cloud comme Azure, AWS et les conteneurs Docker, sans aucune dépendance UI.