---
title: Simplifier le remplacement de polices dans les présentations avec PHP
linktitle: Remplacement de police
type: docs
weight: 60
url: /fr/php-java/font-replacement/
keywords:
- police
- remplacer une police
- remplacement de police
- changer police
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Remplacez sans effort les polices dans Aspose.Slides pour PHP via Java afin d'assurer une typographie cohérente dans les présentations PowerPoint et OpenDocument."
---

## **Remplacer les polices**

Si vous changez d'avis concernant l'utilisation d'une police, vous pouvez remplacer cette police par une autre. Toutes les occurrences de l'ancienne police seront remplacées par la nouvelle police. 

Aspose.Slides vous permet de remplacer une police de la manière suivante :

1. Chargez la présentation concernée. 
2. Chargez la police qui sera remplacée. 
3. Chargez la nouvelle police. 
4. Remplacez la police. 
5. Enregistrez la présentation modifiée au format PPTX. 

Ce code PHP illustre le remplacement de police :
```php
  # Charge une présentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Charge la police source qui sera remplacée
    $sourceFont = new FontData("Arial");
    # Charge la nouvelle police
    $destFont = new FontData("Times New Roman");
    # Remplace les polices
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Enregistre la présentation
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Note" color="warning" %}} 

Pour définir des règles déterminant ce qui se passe dans certaines conditions (par exemple si une police est inaccessible), consultez [**Substitution de police**](/slides/fr/php-java/font-substitution/).

{{% /alert %}}

## **FAQ**

**Quelle est la différence entre « remplacement de police », « substitution de police » et « polices de secours » ?**

Le remplacement est un changement intentionnel d'une famille à une autre dans l'ensemble du document. [Substitution](/slides/fr/php-java/font-substitution/) est une règle du type « si la police est indisponible, utilisez X ». [Police de secours](/slides/fr/php-java/fallback-font/) est appliqué de manière ciblée pour les glyphes manquants lorsque la police de base est installée mais ne contient pas les caractères requis.

**Le remplacement s'applique-t-il aux diapositives maîtres, aux mises en page, aux notes et aux commentaires ?**

Oui. Le remplacement affecte tous les objets de la présentation qui utilisent la police d'origine, y compris les diapositives maîtres et les notes ; les commentaires font également partie du document et sont pris en compte par le moteur de polices.

**La police sera-t-elle modifiée à l'intérieur des objets OLE intégrés (par exemple, Excel) ?**

Non. Le [contenu OLE](/slides/fr/php-java/manage-ole/) est contrôlé par son propre application. Le remplacement dans la présentation ne reformate pas les données OLE internes ; elles peuvent être affichées sous forme d'image ou de contenu éditable à l'extérieur.

**Puis-je remplacer une police uniquement dans une partie de la présentation (par diapositives ou régions) ?**

Un remplacement ciblé est possible si vous changez la police au niveau des objets/plages requis plutôt que d'appliquer un remplacement global à l'ensemble du document. La logique de sélection des polices globale pendant le rendu reste la même.

**Comment puis‑je déterminer à l'avance quelles polices la présentation utilise réellement ?**

Utilisez le [gestionnaire de polices](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) : il fournit une liste des [familles utilisées](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/) et des informations sur les [substitutions/\"polices inconnues\"](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/), ce qui aide à planifier le remplacement.

**Le remplacement de police fonctionne‑t‑il lors de la conversion en PDF/images ?**

Oui. Lors de l'exportation, Aspose.Slides applique la même [séquence de sélection/substitution des polices](/slides/fr/php-java/font-selection-sequence/), de sorte qu'un remplacement effectué à l'avance sera respecté lors de la conversion.

**Dois‑je installer la police cible dans le système, ou puis‑je joindre un dossier de polices ?**

L'installation n'est pas requise : la bibliothèque permet le [chargement de polices externes](/slides/fr/php-java/custom-font/) depuis des dossiers utilisateurs pour une utilisation lors du [rendu et de l'export](/slides/fr/php-java/convert-powerpoint/).

**Le remplacement corrigera‑t‑il les « tofu » (carrés) à la place des caractères ?**

Seulement si la police cible contient réellement les glyphes requis. Sinon, [configurez la police de secours](/slides/fr/php-java/fallback-font/) pour couvrir les caractères manquants.