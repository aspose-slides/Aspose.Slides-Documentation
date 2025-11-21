---
title: Spécifier les polices par défaut de la présentation en .NET
linktitle: Police par défaut
type: docs
weight: 30
url: /fr/net/default-font/
keywords:
- police par défaut
- police régulière
- police normale
- police asiatique
- export PDF
- export XPS
- export d'images
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Définir les polices par défaut dans Aspose.Slides pour .NET afin d'assurer une conversion correcte de PowerPoint (PPT, PPTX) et OpenDocument (ODP) vers PDF, XPS et images."
---

## **Utilisation des polices par défaut pour le rendu de la présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation en PDF, XPS ou vignettes. Cet article montre comment définir DefaultRegularFont et DefaultAsianFont à utiliser comme polices par défaut. Veuillez suivre les étapes ci‑dessous pour charger des polices à partir de répertoires externes en utilisant l’API Aspose.Slides pour .NET :

1. Créez une instance de LoadOptions.  
1. Définissez DefaultRegularFont sur la police souhaitée. Dans l’exemple suivant, j’ai utilisé Wingdings.  
1. Définissez DefaultAsianFont sur la police souhaitée. J’ai utilisé Wingdings dans l’exemple suivant.  
1. Chargez la présentation en utilisant Presentation et en appliquant les options de chargement.  
1. Enfin, générez la vignette de diapositive, le PDF et le XPS pour vérifier le résultat.  

L’implémentation ci‑dessus est fournie ci‑après.  
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

**Que affectent exactement DefaultRegularFont et DefaultAsianFont — uniquement l’exportation ou également les vignettes, PDF, XPS, HTML et SVG ?**  
Ils participent au pipeline de rendu pour toutes les sorties prises en charge. Cela inclut les vignettes de diapositive, [PDF](/slides/fr/net/convert-powerpoint-to-pdf/), [XPS](/slides/fr/net/convert-powerpoint-to-xps/), [images matricielles](/slides/fr/net/convert-powerpoint-to-png/), [HTML](/slides/fr/net/convert-powerpoint-to-html/), et [SVG](/slides/fr/net/render-a-slide-as-an-svg-image/), car Aspose.Slides utilise la même logique de mise en page et de résolution de glyphes pour ces cibles.

**Les polices par défaut sont‑elles appliquées lors d’une simple lecture et sauvegarde d’un PPTX sans aucun rendu ?**  
Non. Les polices par défaut interviennent lorsque le texte doit être mesuré et dessiné. Un simple enregistrement ouvert‑fermé d’une présentation ne modifie pas les exécutions de police stockées ni la structure du fichier. Les polices par défaut sont utilisées lors des opérations qui rendent ou réagencent le texte.

**Si j’ajoute mes propres dossiers de polices ou fournis des polices depuis la mémoire, seront‑ils pris en compte lors du choix des polices par défaut ?**  
Oui. [Custom font sources](/slides/fr/net/custom-font/) élargissent le catalogue des familles et glyphes disponibles que le moteur peut utiliser. Les polices par défaut et les éventuelles [fallback rules](/slides/fr/net/fallback-font/) seront résolues en priorité avec ces sources, offrant une couverture plus fiable sur les serveurs et dans les conteneurs.

**Les polices par défaut affecteront‑elles les métriques du texte (crénage, avances) et donc les sauts de ligne et le retour à la ligne ?**  
Oui. Modifier la police change les métriques des glyphes et peut altérer les sauts de ligne, le retour à la ligne et la pagination lors du rendu. Pour assurer la stabilité de la mise en page, [embed the original fonts](/slides/fr/net/embedded-font/) ou choisissez des familles par défaut et de secours compatibles métriquement.

**Y a‑t‑il un intérêt à définir des polices par défaut si toutes les polices utilisées dans la présentation sont intégrées ?**  
Souvent ce n’est pas nécessaire, car les [embedded fonts](/slides/fr/net/embedded-font/) assurent déjà une apparence cohérente. Les polices par défaut restent utiles comme filet de sécurité pour les caractères non couverts par le sous‑ensemble intégré ou lorsqu’un fichier mélange du texte intégré et non intégré.