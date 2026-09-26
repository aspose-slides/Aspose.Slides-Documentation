---
title: Créer des présentations en .NET
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/net/create-presentation/
keywords:
- créer une présentation
- nouvelle présentation
- créer PPT
- nouveau PPT
- créer PPTX
- nouveau PPTX
- créer ODP
- nouveau ODP
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer des présentations en .NET avec Aspose.Slides — produire des fichiers PPT, PPTX et ODP, bénéficier du support OpenDocument et les enregistrer programmatiquement pour des résultats fiables."
---
## **Vue d'ensemble**

Cet article montre comment créer une présentation avec Aspose.Slides, ajouter une zone de texte à sa première diapositive et enregistrer le résultat dans un fichier. Il montre également comment créer et enregistrer une présentation vide, ainsi que comment ouvrir une présentation existante dans un format pris en charge et l’enregistrer dans un autre format. Une courte FAQ à la fin répond aux questions courantes concernant les formats, les modèles, la taille des diapositives, les unités, l’utilisation de la mémoire, le multithreading, la licence, les signatures numériques et la prise en charge de VBA.

Avant de commencer, ajoutez Aspose.Slides à votre projet depuis NuGet. Voir [Installation](/slides/fr/net/installation/) pour le paquet à utiliser sous Windows, Linux et macOS.

## **Créer une présentation PowerPoint**

Pour créer une présentation et placer une zone de texte sur sa première diapositive, suivez les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). Une nouvelle présentation contient déjà une diapositive vide.  
2. Récupérez cette diapositive dans la collection [Slides](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/slides/fr/) en utilisant son index, 0.  
3. Ajoutez un rectangle avec la méthode [AddAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addautoshape/) et définissez son [text](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/text/).  
4. Enregistrez la présentation au format PPTX à l’aide de la méthode [Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

La partie supérieure gauche du rectangle se trouve à 50 points du bord gauche et à 50 points du bord supérieur de la diapositive, et le rectangle mesure 400 points de largeur et 100 points de hauteur. Le fichier enregistré contient une diapositive avec ce rectangle et son texte. Sans licence, Aspose.Slides ajoute également un filigrane d’évaluation à chaque diapositive enregistrée ; voir [Licensing](/slides/fr/net/licensing/).

## **Créer et enregistrer une présentation**

<a name="csharp-create-save-presentation"></a>

Pour créer une présentation vide et l’enregistrer, créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) et enregistrez‑la dans n’importe quel format de l’énumération [SaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/). Le résultat est une présentation contenant une diapositive vide.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Ouvrir et enregistrer une présentation**

<a name="csharp-open-save-presentation"></a>

Pour convertir une présentation d’un format à un autre, ouvrez‑la en passant son chemin au constructeur [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/presentation/), puis enregistrez‑la dans le format cible. Aspose.Slides détecte le format d’entrée, comme PPT, PPTX ou ODP, à partir du fichier lui‑même.

L’exemple ci‑dessus attend une présentation OpenDocument nommée *Sample.odp* dans le répertoire de travail et l’enregistre au format PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### Quels formats puis‑je enregistrer pour une nouvelle présentation ?

Vous pouvez enregistrer au format [PPTX, PPT, et ODP](/slides/fr/net/save-presentation/), et exporter vers [PDF](/slides/fr/net/convert-powerpoint-to-pdf/), [XPS](/slides/fr/net/convert-powerpoint-to-xps/), [HTML](/slides/fr/net/convert-powerpoint-to-html/), [SVG](/slides/fr/net/render-a-slide-as-an-svg-image/) et [images](/slides/fr/net/convert-powerpoint-to-png/), entre autres.

### Puis‑je partir d’un modèle (POTX/POTM) et enregistrer en PPTX standard ?

Oui. Chargez le modèle et enregistrez‑le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/net/supported-file-formats/).

### Comment contrôler la taille/la proportion des diapositives lors de la création d’une présentation ?

Définissez la [slide size](/slides/fr/net/slide-size/) (y compris les préréglages comme 4 : 3 et 16 : 9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l’échelle.

### Dans quelles unités les tailles et les coordonnées sont‑elles mesurées ?

En points : 1 pouce équivaut à 72 unités.

### Comment gérer des présentations très volumineuses (avec de nombreux fichiers multimédias) pour réduire l’utilisation de la mémoire ?

Utilisez les [BLOB management strategies](/slides/fr/net/manage-blob/), limitez le stockage en mémoire en vous appuyant sur des fichiers temporaires, et privilégiez les flux de travail basés sur des fichiers plutôt que les flux purement en mémoire.

### Puis‑je créer/enregistrer des présentations en parallèle ?

Vous ne pouvez pas manipuler la même instance [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) depuis [multiple threads](/slides/fr/net/multithreading/). Exécutez des instances séparées et isolées par thread ou par processus.

### Comment supprimer le filigrane d’évaluation et les limitations ?

[Apply a license](/slides/fr/net/licensing/) une fois par processus. Le XML de licence doit rester intact, et la configuration de la licence doit être synchronisée si plusieurs threads sont impliqués.

### Puis‑je signer numériquement le PPTX que je crée ?

Oui. Les [Digital signatures](/slides/fr/net/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

### Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?

Oui. Vous pouvez [create/edit VBA projects](/slides/fr/net/presentation-via-vba/) et enregistrer des fichiers contenant des macros tels que PPTM/PPSM.