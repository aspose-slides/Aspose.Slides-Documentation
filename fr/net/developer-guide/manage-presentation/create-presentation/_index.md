---
title: Créer une présentation en .NET
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/net/create-presentation/
keywords: "Créer PowerPoint, PPTX, PPT, Créer une présentation, Initialiser une présentation, C#, .NET"
description: "Créer des présentations PowerPoint de façon programmatique en C# par ex. PPT, PPTX, ODP, etc."
---

## **Créer une présentation PowerPoint**
Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe Presentation.
1. Obtenir la référence d’une diapositive en utilisant son Index.
1. Ajouter une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l’objet Shapes.
1. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessus, nous avons ajouté une ligne à la première diapositive de la présentation.
```c#
 // Instancie un objet Presentation qui représente un fichier de présentation
 using (Presentation presentation = new Presentation())
 {
     // Obtient la première diapositive
     ISlide slide = presentation.Slides[0];

     // Ajoute une autoshape de type ligne
     slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
     presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
 }
```


## **Créer et enregistrer une présentation**

<a name="csharp-create-save-presentation"><strong>Étapes : Créer et enregistrer une présentation en C#</strong></a>

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Enregistrer _Presentation_ dans n'importe quel format pris en charge par [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Ouvrir et enregistrer une présentation**

<a name="csharp-open-save-presentation"><strong>Étapes : Ouvrir et enregistrer une présentation en C#</strong></a>

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) avec n'importe quel format, par ex. PPT, PPTX, ODP, etc.
2. Enregistrer _Presentation_ dans n'importe quel format pris en charge par [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
 // Chargez n'importe quel fichier pris en charge dans Presentation, par ex. ppt, pptx, odp, etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Quels formats puis‑je enregistrer pour une nouvelle présentation ?**

Vous pouvez enregistrer au format [PPTX, PPT, et ODP](/slides/fr/net/save-presentation/), et exporter vers [PDF](/slides/fr/net/convert-powerpoint-to-pdf/), [XPS](/slides/fr/net/convert-powerpoint-to-xps/), [HTML](/slides/fr/net/convert-powerpoint-to-html/), [SVG](/slides/fr/net/convert-powerpoint-to-png/), ainsi que [images](/slides/fr/net/convert-powerpoint-to-png/), entre autres.

**Puis‑je partir d’un modèle (POTX/POTM) et l’enregistrer en PPTX standard ?**

Oui. Chargez le modèle et enregistrez‑le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/net/supported-file-formats/).

**Comment contrôler la taille/rapport d’aspect d’une diapositive lors de la création d’une présentation ?**

Définissez la [taille de la diapositive](/slides/fr/net/slide-size/) (y compris les préréglages comme 4:3 et 16:9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l’échelle.

**En quelles unités les tailles et coordonnées sont‑elles mesurées ?**

En points : 1 pouce équivaut à 72 unités.

**Comment gérer des présentations très volumineuses (avec de nombreux fichiers multimédias) pour réduire l’utilisation de la mémoire ?**

Utilisez les [stratégies de gestion des BLOB](/slides/fr/net/manage-blob/), limitez le stockage en mémoire en exploitant des fichiers temporaires, et privilégiez les flux de travail basés sur des fichiers plutôt que les flux purement en mémoire.

**Puis‑je créer/enregistrer des présentations en parallèle ?**

Vous ne pouvez pas manipuler la même instance de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/net/multithreading/). Exécutez des instances séparées et isolées par thread ou par processus.

**Comment supprimer le filigrane d’essai et les limitations ?**

[Appliquer une licence](/slides/fr/net/licensing/) une fois par processus. Le XML de licence doit rester inchangé, et la configuration de la licence doit être synchronisée si plusieurs threads sont impliqués.

**Puis‑je signer numériquement le PPTX que je crée ?**

Oui. Les [signatures numériques](/slides/fr/net/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

**Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?**

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/net/presentation-via-vba/) et enregistrer des fichiers activés pour les macros tels que PPTM/PPSM.