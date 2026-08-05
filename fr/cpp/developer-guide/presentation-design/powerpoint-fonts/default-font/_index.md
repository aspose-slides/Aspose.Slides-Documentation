---
title: Spécifier les polices par défaut de la présentation en C++
linktitle: Police par défaut
type: docs
weight: 30
url: /fr/cpp/default-font/
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
- C++
- Aspose.Slides
description: "Définir les polices par défaut dans Aspose.Slides pour C++ afin d'assurer une conversion correcte de PowerPoint (PPT, PPTX) et OpenDocument (ODP) vers PDF, XPS et images."
---
## **Aperçu**

Aspose.Slides vous permet de spécifier les polices par défaut utilisées lors du rendu d'une présentation. Cela est utile lors de la génération de miniatures de diapositives ou de l'exportation d'une présentation vers des formats tels que PDF et XPS. Les polices par défaut sont configurées via `LoadOptions` avant le chargement de la présentation.

La méthode `set_DefaultRegularFont` définit la police par défaut pour le texte standard, tandis que `set_DefaultAsianFont` définit la police par défaut pour le texte asiatique. Après avoir défini ces options, la présentation peut être chargée et rendue en utilisant les polices spécifiées.

## **Utiliser les polices par défaut pour rendre une présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation en PDF, XPS ou miniatures. Cet article montre comment définir DefaultRegularFont et DefaultAsianFont pour les utiliser comme polices par défaut. Veuillez suivre les étapes ci‑dessous pour charger des polices à partir de répertoires externes en utilisant l'API Aspose.Slides pour C++ :

1. Créez une instance de LoadOptions.  
2. Définissez DefaultRegularFont sur la police de votre choix. Dans l'exemple suivant, j'ai utilisé Wingdings.  
3. Définissez DefaultAsianFont sur la police de votre choix. J'ai utilisé Wingdings dans l'exemple suivant.  
4. Chargez la présentation en utilisant Presentation et en définissant les options de chargement.  
5. Ensuite, générez la miniature de la diapositive, le PDF et le XPS pour vérifier le résultat.  

L'implémentation ci‑dessus est fournie ci‑après.

```cpp
// Utilisez les options de chargement pour spécifier les polices régulières et asiatiques par défaut
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **FAQ**

**Qu'est-ce que DefaultRegularFont et DefaultAsianFont affectent exactement — seulement l'exportation ou également les miniatures, PDF, XPS, HTML et SVG ?**

Ils participent à la chaîne de rendu pour toutes les sorties supportées. Cela comprend les miniatures de diapositives, [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/fr/cpp/convert-powerpoint-to-xps/), [images raster](/slides/fr/cpp/convert-powerpoint-to-png/), [HTML](/slides/fr/cpp/convert-powerpoint-to-html/), et [SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/), car Aspose.Slides utilise la même logique de mise en page et de résolution de glyphes pour ces cibles.

**Les polices par défaut sont‑elles appliquées lors d'une simple lecture et sauvegarde d'un PPTX sans aucun rendu ?**

Non. Les polices par défaut sont importantes lorsque le texte doit être mesuré et dessiné. Un simple enregistrement direct d’une présentation ne modifie pas les segments de police stockés ni la structure du fichier. Les polices par défaut entrent en jeu lors des opérations qui rendent ou réorganisent le texte.

**Si j’ajoute mes propres dossiers de polices ou fournis des polices depuis la mémoire, seront‑ils pris en compte lors du choix des polices par défaut ?**

Oui. Les [Sources de polices personnalisées](/slides/fr/cpp/custom-font/) étendent le catalogue des familles et glyphes disponibles que le moteur peut utiliser. Les polices par défaut et toutes les [règles de secours](/slides/fr/cpp/fallback-font/) seront résolues en priorité contre ces sources, offrant une couverture plus fiable sur les serveurs et dans les conteneurs.

**Les polices par défaut affecteront‑elles les métriques du texte (crénage, avances) et donc les sauts de ligne et le retour à la ligne ?**

Oui. Modifier la police change les métriques des glyphes et peut altérer les sauts de ligne, le retour à la ligne et la pagination lors du rendu. Pour assurer la stabilité de la mise en page, [intégrez les polices d'origine](/slides/fr/cpp/embedded-font/) ou choisissez des familles par défaut et de secours compatibles métriquement.

**Y a‑t‑il un intérêt à définir des polices par défaut si toutes les polices utilisées dans la présentation sont incorporées ?**

Souvent, ce n’est pas nécessaire, car les [polices incorporées](/slides/fr/cpp/embedded-font/) assurent déjà une apparence cohérente. Les polices par défaut restent utiles comme filet de sécurité pour les caractères non couverts par le sous‑ensemble incorporé ou lorsqu’un fichier combine du texte incorporé et non incorporé.