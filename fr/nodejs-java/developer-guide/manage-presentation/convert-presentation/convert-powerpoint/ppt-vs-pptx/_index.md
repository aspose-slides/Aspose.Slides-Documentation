---
title: PPT vs PPTX
type: docs
weight: 10
url: /fr/nodejs-java/ppt-vs-pptx/
keywords: "PPT vs PPTX"
description: "Lisez les différences entre PPT et PPTX dans Aspose.Slides."
---

## **Qu'est-ce que le PPT ?**

[**PPT**](https://docs.fileformat.com/presentation/ppt/) est un format de fichier binaire, c’est-à-dire qu’il est impossible de visualiser son contenu sans outils spéciaux. Les premières versions de PowerPoint 97-2003 utilisaient le format de fichier PPT, mais son extensibilité est limitée.

## **Qu'est-ce que le PPTX ?**

[**PPTX**](https://docs.fileformat.com/presentation/pptx/) est un nouveau format de présentation, basé sur la norme Office Open XML (ISO 29500:2008-2016, ECMA-376). PPTX est un ensemble archivé de fichiers XML et multimédias. Le format PPTX est facilement extensible. Par exemple, il est facile d’ajouter la prise en charge d’un nouveau type de graphique ou de forme, sans modifier le format PPTX dans chaque nouvelle version de PowerPoint. Le format PPTX est utilisé depuis PowerPoint 2007.

## **PPT vs PPTX**

Bien que PPTX offre une fonctionnalité beaucoup plus étendue, le PPT reste assez populaire. La nécessité de convertir de PPT en PPTX et vice‑versa est fortement demandée.

Cependant, la conversion entre le vieux format PPT et le nouveau format PPTX représente le défi le plus compliqué parmi les autres formats Microsoft Office. Bien que la spécification du format PPT soit ouverte, il est difficile de travailler avec. PowerPoint peut créer des parties spéciales (MetroBlob) dans les fichiers PPT pour stocker des informations provenant de PPTX qui ne sont pas prises en charge par le format PPT et ne peuvent pas être affichées dans les anciennes versions de PowerPoint. Ces informations peuvent être restaurées lorsqu’un fichier PPT est chargé dans une version moderne de PowerPoint ou converti au format PPTX.

Aspose.Slides fournit une classe commune pour travailler avec tous les formats de présentation. Elle permet de convertir de PPT à PPTX et de PPTX à PPT de manière très simple. Aspose.Slides prend en charge entièrement la conversion de PPT à PPTX et prend également en charge la conversion de PPTX à PPT avec certaines restrictions. Nous recommandons d’utiliser le format PPTX chaque fois que possible.

{{% alert color="primary" %}} 
Vérifiez la qualité des conversions de PPT en PPTX et de PPTX en PPT avec l’application en ligne [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 
```javascript
// Instanciez un objet Presentation qui représente un fichier PPT
var pres = new aspose.slides.Presentation("PPTtoPPTX.ppt");
try {
    // Enregistrement de la présentation PPT au format PPTX
    pres.save("PPTtoPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
En savoir plus [**Comment convertir les présentations PPT en PPTX**](/slides/fr/nodejs-java/convert-ppt-to-pptx/)
{{% /alert %}} 

## **FAQ**

**Y a-t-il un intérêt à conserver les anciennes présentations en PPT si elles s’ouvrent sans erreur ?**

Si une présentation s’ouvre de façon fiable et n’a pas besoin de collaboration ou de nouvelles fonctionnalités, vous pouvez la conserver en PPT. Mais pour la compatibilité future et l’extensibilité, il vaut mieux [convertir en PPTX](/slides/fr/nodejs-java/convert-ppt-to-pptx/) : le format repose sur la norme OOXML ouverte et est plus facilement pris en charge par les outils modernes.

**Comment décider quels fichiers sont critiques à convertir en PPTX en premier ?**

Convertissez d’abord les présentations qui : sont éditées par plusieurs personnes ; contiennent des [graphiques](/slides/fr/nodejs-java/create-chart/)/[formes](/slides/fr/nodejs-java/shape-manipulations/) complexes ; sont utilisées dans des communications externes ; ou déclenchent des avertissements lors de l’[ouverture](/slides/fr/nodejs-java/open-presentation/).

**La protection par mot de passe sera-t-elle conservée lors de la conversion de PPT en PPTX et inversement ?**

La présence d’un mot de passe n’est transmise que si la conversion et le support du chiffrement sont corrects dans l’outil utilisé. Il est plus fiable de [supprimer la protection](/slides/fr/nodejs-java/password-protected-presentation/), [convertir](/slides/fr/nodejs-java/convert-ppt-to-pptx/), puis de réappliquer la protection selon votre politique de sécurité.

**Pourquoi certains effets disparaissent-ils ou sont-ils simplifiés lors de la conversion de PPTX en PPT ?**

Parce que le PPT ne prend pas en charge certains objets/propriétés plus récents. PowerPoint et les outils peuvent stocker des « traces » de ces informations dans des blocs spéciaux pour une restauration ultérieure, mais les anciennes versions de PowerPoint ne les rendront pas.