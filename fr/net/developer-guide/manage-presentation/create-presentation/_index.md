---
title: Créer une Présentation en .NET
linktitle: Créer une Présentation
type: docs
weight: 10
url: /fr/net/create-presentation/
keywords: "Créer PowerPoint, PPTX, PPT, Créer Présentation, Initialiser Présentation, C#, .NET"
description: "Création de Présentations PowerPoint par Programmation en C# par ex. PPT, PPTX, ODP, etc."
---

## Créer une Présentation PowerPoint
Pour ajouter une simple ligne à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe Presentation.
1. Obtenez la référence d'une diapositive en utilisant son Index.
1. Ajoutez un AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

```c#
// Instanciez un objet Presentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation())
{
    // Obtenez la première diapositive
    ISlide slide = presentation.Slides[0];

    // Ajoutez une autoshape de type ligne
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## Créer et Enregistrer une Présentation

<a name="csharp-create-save-presentation"><strong>Étapes : Créer et Enregistrer une Présentation en C#</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Enregistrez _Presentation_ dans n'importe quel format pris en charge par [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## Ouvrir et Enregistrer une Présentation

<a name="csharp-open-save-presentation"><strong>Étapes : Ouvrir et Enregistrer une Présentation en C#</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) avec n'importe quel format c'est-à-dire PPT, PPTX, ODP, etc.
2. Enregistrez _Presentation_ dans n'importe quel format pris en charge par [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
// Chargez n'importe quel fichier pris en charge dans Presentation par ex. ppt, pptx, odp, etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```