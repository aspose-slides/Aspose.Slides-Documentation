---
title: Convertir PowerPoint en PDF avec Node.js via .NET
linktitle: PowerPoint en PDF
type: docs
weight: 30
url: /fr/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint en PDF
- convertir PowerPoint en PDF
- PPTX en PDF
- PPT en PDF
- ODP en PDF
- enregistrer la présentation en PDF
- PDF/A
- PdfOptions
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir des présentations PPTX, PPT et ODP en PDF en JavaScript avec Aspose.Slides pour Node.js via .NET, et produire des fichiers PDF/A d'archivage avec PdfOptions."
---
## **Aperçu**

Aspose.Slides for Node.js via .NET convertit les présentations PowerPoint et OpenDocument en PDF sans Microsoft PowerPoint. Chaque diapositive visible devient une page PDF de la même taille que la diapositive, et le texte reste sélectionnable et recherchable. Cet article montre la conversion par défaut et une conversion en PDF/A avec [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/).

Les exemples supposent une présentation nommée `sample.pptx` dans le dossier du projet que vous avez configuré dans [Installation](/slides/fr/nodejs-net/installation/). Toute présentation PowerPoint convient. Enregistrez chaque exemple comme un fichier `.js` dans le dossier du projet et exécutez-le depuis ce dossier avec `node`.

{{% alert color="info" title="Remarque" %}}
Aspose.Slides for Node.js via .NET n’a pas de référence API propre. Il reflète l’API Aspose.Slides for .NET avec des noms camelCase, de sorte que les liens API de cet article mènent aux classes et membres correspondants dans la [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/fr/net/).
{{% /alert %}}

## **Convertir une présentation en PDF**

Pour convertir une présentation en PDF, suivez ces étapes :

1. Ouvrez la présentation en passant son chemin au constructeur [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/presentation/). Le même code fonctionne pour les fichiers PPTX, PPT et ODP.
2. Appelez la méthode [save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) en lui fournissant le chemin de sortie et `SaveFormat.Pdf`.
3. Appelez `dispose` dans un bloc `finally` pour libérer les ressources .NET sous‑jacent la présentation.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

Le script écrit `sample.pdf` dans le dossier du projet. La conversion utilise les paramètres par défaut : chaque diapositive qui n’est pas masquée devient une page, dans l’ordre des diapositives. Sans licence, chaque page affiche également un filigrane d’évaluation ; consultez [Licensing](/slides/fr/nodejs-net/licensing/).

## **Convertir une présentation en PDF/A**

Pour contrôler la sortie, passez un objet [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/) comme troisième argument de `save`. L’exemple suivant définit la propriété [compliance](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/compliance/) sur `PdfCompliance.PdfA2b`, ce qui produit un fichier PDF/A-2b. PDF/A est la norme ISO pour l’archivage à long terme : parmi d’autres règles, il exige que chaque police utilisée par le document soit incorporée dans le fichier.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

Le script écrit `sample-pdfa.pdf` avec les mêmes pages que la conversion par défaut. Pour confirmer qu’un fichier respecte la norme, vérifiez‑le avec un validateur PDF/A tel que [veraPDF](https://verapdf.org/). D’autres valeurs [PdfCompliance](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfcompliance/) sélectionnent d’autres normes, comme `PdfA1b`, `PdfA2a` ou `PdfUa` pour l’accessibilité.

## **FAQ**

**Comment inclure les diapositives masquées dans le PDF ?**

Les diapositives masquées sont ignorées par défaut. Réglez la propriété [showHiddenSlides](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/showhiddenslides/) de `PdfOptions` sur `true` et passez les options à `save`.

**Puis-je protéger le PDF avec un mot de passe ?**

Oui. Définissez la propriété [password](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/password/) de `PdfOptions` avant d’appeler `save`. Les lecteurs PDF demanderont alors ce mot de passe avant d’ouvrir le fichier.

**Puis-je convertir seulement certaines diapositives ?**

Oui. Passez un tableau de positions de diapositives comme quatrième argument de `save`. Les positions commencent à 1, et le troisième argument peut être `null` si vous n’avez pas besoin d’options : `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` génère un PDF contenant la première et la troisième diapositive.

**Pourquoi le texte apparaît‑il différent lorsque je convertis sous Linux ?**

Aspose.Slides ne peut utiliser que les polices installées sur la machine qui effectue la conversion. Lorsqu’une présentation utilise une police absente, comme Calibri sur un serveur Linux typique, Aspose.Slides substitue une police installée, ce qui peut modifier l’apparence du texte et le point de césure. Installez les polices utilisées par vos présentations pour obtenir le même résultat qu sous Windows.

**Puis-je obtenir le PDF sous forme de Buffer au lieu d’un fichier ?**

Oui. `presentation.saveToBuffer(SaveFormat.Pdf)` renvoie le PDF sous forme d’un `Buffer` Node.js, ce qui est pratique lorsque vous envoyez le résultat dans une réponse HTTP. Il accepte également `PdfOptions` comme second argument.