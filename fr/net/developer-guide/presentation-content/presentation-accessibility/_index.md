---
title: Gérer l'accessibilité des présentations dans .NET
linktitle: Accessibilité des présentations
type: docs
weight: 30
url: /fr/net/presentation-accessibility/
keywords:
- accessibilité des présentations
- marquer comme décoratif
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Automatisez les vérifications d'accessibilité des présentations dans les fichiers PPT, PPTX et ODP avec Aspose.Slides pour .NET—améliorez l'expérience des lecteurs d'écran et renforcez la conformité."
---

## **Aperçu**

L’accessibilité des présentations garantit que les personnes utilisant des technologies d’assistance—telles que les lecteurs d’écran, les affichages braille ou la navigation clavier uniquement—peuvent comprendre et parcourir vos diapositives aussi efficacement que les spectateurs voyants utilisant une souris. Les bonnes pratiques portent sur un ordre de lecture clair, un texte alternatif significatif pour les visuels informatifs, un contraste de couleur suffisant, une typographie lisible, un texte de lien descriptif et l’évitement de la transmission de sens uniquement par la couleur ou la position. Lorsqu’on planifie l’accessibilité dès le départ, le résultat est une structure plus propre, des visuels plus cohérents et un contenu qui atteint chaque lecteur sans solutions de contournement.

## **Marquer comme décoratif**

Marquer comme décoratif identifie les visuels purement ornementaux afin que les lecteurs d’écran les ignorent, réduisant le bruit et maintenant le focus sur le contenu pertinent. Appliquez‑le aux arrière‑plans, aux embellissements et aux espaces—jamais aux graphiques, icônes ou images qui transmettent des informations. Aspose.Slides expose ce drapeau pour la détection et la validation, permettant des vérifications d’accessibilité automatisées et un nettoyage.

![Marquer comme décoratif](mark_as_decorative.png)

Le fragment de code suivant montre comment déterminer si une forme est marquée comme décorative.
```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```
