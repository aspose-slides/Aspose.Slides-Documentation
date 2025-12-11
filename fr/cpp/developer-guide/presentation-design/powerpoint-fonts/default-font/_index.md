---
title: Spécifier les polices de présentation par défaut en C++
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
description: "Définir les polices par défaut dans Aspose.Slides pour C++ afin d’assurer une conversion correcte des fichiers PowerPoint (PPT, PPTX) et OpenDocument (ODP) vers PDF, XPS et images."
---

## **Définir une police par défaut**
Avec Aspose.Slides pour C++ vous pouvez définir la police par défaut dans les présentations PowerPoint. Une nouvelle méthode [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) a été ajoutée à la classe [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/) . Elle permet de définir la police par défaut utilisée à la place de toutes les polices manquantes lors de l’enregistrement des présentations dans différents formats sans recharger les présentations .

Le fragment de code ci‑dessous montre comment enregistrer une présentation au format [HTML](https://docs.fileformat.com/web/html/) et [PDF](https://docs.fileformat.com/pdf/) avec une police régulière par défaut différente.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}

## **Utiliser les polices par défaut pour le rendu d’une présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation au format PDF, XPS ou en miniatures. Cet article montre comment définir DefaultRegular Font et DefaultAsian Font à utiliser comme polices par défaut. Veuillez suivre les étapes ci‑dessous pour charger des polices à partir de répertoires externes en utilisant l’API Aspose.Slides pour C++ :

1. Créer une instance de LoadOptions.  
2. Définir DefaultRegularFont sur la police souhaitée. Dans l’exemple suivant, j’ai utilisé Wingdings.  
3. Définir DefaultAsianFont sur la police souhaitée. J’ai utilisé Wingdings dans l’exemple suivant.  
4. Charger la présentation à l’aide de Presentation en spécifiant les options de chargement.  
5. Ensuite, générer la miniature de diapositive, le PDF et le XPS pour vérifier les résultats.

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

**Quel est exactement l’impact de DefaultRegularFont et DefaultAsianFont — seulement l’exportation ou aussi les miniatures, PDF, XPS, HTML et SVG ?**

Ils participent à la chaîne de rendu pour toutes les sorties prises en charge. Cela inclut les miniatures de diapositives, [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/fr/cpp/convert-powerpoint-to-xps/), [images raster](/slides/fr/cpp/convert-powerpoint-to-png/), [HTML](/slides/fr/cpp/convert-powerpoint-to-html/), et [SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/), car Aspose.Slides utilise la même logique de mise en page et de résolution des glyphes pour ces cibles.

**Les polices par défaut sont‑elles appliquées lorsqu’on lit et enregistre simplement un PPTX sans rendu ?**

Non. Les polices par défaut n’interviennent que lorsque le texte doit être mesuré et dessiné. Un simple enregistrement d’une présentation ne modifie pas les séquences de polices stockées ni la structure du fichier. Les polices par défaut entrent en jeu lors des opérations de rendu ou de re‑flux du texte.

**Si j’ajoute mes propres dossiers de polices ou fournis des polices en mémoire, seront‑ils pris en compte lors du choix des polices par défaut ?**

Oui. Les [sources de polices personnalisées](/slides/fr/cpp/custom-font/) élargissent le catalogue des familles et des glyphes disponibles pour le moteur. Les polices par défaut et les [règles de secours](/slides/fr/cpp/fallback-font/) seront résolues en priorité contre ces sources, offrant une couverture plus fiable sur les serveurs et dans les conteneurs.

**Les polices par défaut affectent‑elles les métriques du texte (crénage, avances) et donc les sauts de ligne et le retour à la ligne ?**

Oui. Modifier la police change les métriques des glyphes et peut altérer les sauts de ligne, le retour à la ligne et la pagination lors du rendu. Pour garantir la stabilité de la mise en page, [intégrez les polices originales](/slides/fr/cpp/embedded-font/) ou choisissez des familles de secours métriquement compatibles.

**Y a‑t‑il un intérêt à définir des polices par défaut si toutes les polices de la présentation sont intégrées ?**

Souvent ce n’est pas nécessaire, car les [polices intégrées](/slides/fr/cpp/embedded-font/) assurent déjà une apparence cohérente. Les polices par défaut restent utiles comme filet de sécurité pour les caractères non couverts par le sous‑ensemble intégré ou lorsqu’un fichier combine du texte intégré et non intégré.