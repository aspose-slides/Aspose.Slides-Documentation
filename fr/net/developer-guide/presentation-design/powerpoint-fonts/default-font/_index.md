---
title: Police par défaut - API PowerPoint C#
linktitle: Police par défaut
type: docs
weight: 30
url: /fr/net/default-font/
keywords:
- police
- police par défaut
- rendu de présentation
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: "L'API PowerPoint C# vous permet de définir la police par défaut pour le rendu des présentations en PDF, XPS ou vignettes"
---

## **Utilisation des polices par défaut pour le rendu de la présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation au format PDF, XPS ou vignettes. Cet article montre comment définir DefaultRegularFont et DefaultAsianFont à utiliser comme polices par défaut. Veuillez suivre les étapes ci‑dessous pour charger des polices depuis des répertoires externes en utilisant l’API Aspose.Slides pour .NET :

1. Créez une instance de LoadOptions.
1. Définissez le DefaultRegularFont sur la police souhaitée. Dans l’exemple suivant, j’ai utilisé Wingdings.
1. Définissez le DefaultAsianFont sur la police souhaitée. J’ai utilisé Wingdings dans l’exemple suivant.
1. Chargez la présentation avec Presentation en appliquant les options de chargement.
1. Générez maintenant la vignette de diapositive, le PDF et le XPS pour vérifier les résultats.

L’implémentation ci‑dessus est présentée ci‑après.
```c#
// Utilisez les options de chargement pour spécifier les polices régulières et asiatiques par défaut
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```


## **FAQ**

**Qu’est‑ce que DefaultRegularFont et DefaultAsianFont affectent exactement — uniquement l’exportation ou aussi les vignettes, PDF, XPS, HTML et SVG ?**

Ils participent à la chaîne de rendu pour toutes les sorties prises en charge. Cela inclut les vignettes de diapositive, [PDF](/slides/fr/net/convert-powerpoint-to-pdf/), [XPS](/slides/fr/net/convert-powerpoint-to-xps/), [images raster](/slides/fr/net/convert-powerpoint-to-png/), [HTML](/slides/fr/net/convert-powerpoint-to-html/), et [SVG](/slides/fr/net/render-a-slide-as-an-svg-image/), car Aspose.Slides utilise la même logique de mise en page et de résolution des glyphes pour ces cibles.

**Les polices par défaut sont‑elles appliquées lors d’une simple lecture et sauvegarde d’un PPTX sans rendu ?**

Non. Les polices par défaut n’interviennent que lorsque le texte doit être mesuré et dessiné. Un simple « ouvrir‑sauvegarder » d’une présentation ne modifie pas les runs de police stockés ni la structure du fichier. Les polices par défaut entrent en jeu lors d’opérations qui rendent ou réagencent le texte.

**Si j’ajoute mes propres dossiers de polices ou fournis des polices depuis la mémoire, seront‑ils pris en compte lors du choix des polices par défaut ?**

Oui. Les [sources de polices personnalisées](/slides/fr/net/custom-font/) élargissent le catalogue des familles et glyphes accessibles au moteur. Les polices par défaut et les [règles de secours](/slides/fr/net/fallback-font/) seront résolues en priorité à partir de ces sources, offrant une couverture plus fiable sur les serveurs et dans les conteneurs.

**Les polices par défaut affectent‑elles les métriques du texte (crénage, avances) et donc les sauts de ligne et le retour à la ligne ?**

Oui. Modifier la police modifie les métriques des glyphes et peut changer les sauts de ligne, le retour à la ligne et la pagination lors du rendu. Pour garantir la stabilité de la mise en page, [intégrez les polices d’origine](/slides/fr/net/embedded-font/) ou choisissez des familles par défaut et de secours compatibles métriquement.

**Y a‑t‑il un intérêt à définir des polices par défaut si toutes les polices utilisées dans la présentation sont intégrées ?**

Souvent, ce n’est pas nécessaire, car les [polices intégrées](/slides/fr/net/embedded-font/) assurent déjà une apparence cohérente. Les polices par défaut restent utiles comme filet de sécurité pour les caractères non couverts par le sous‑ensemble intégré ou lorsqu’un fichier mélange texte intégré et non intégré.