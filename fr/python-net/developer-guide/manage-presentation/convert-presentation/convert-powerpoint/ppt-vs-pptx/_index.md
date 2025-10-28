---
title: "Comprendre la différence : PPT vs PPTX"
linktitle: PPT vs PPTX
type: docs
weight: 10
url: /fr/python-net/ppt-vs-pptx/
keywords:
- PPT vs PPTX
- PPT ou PPTX
- format hérité
- format moderne
- format binaire
- norme moderne
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Comparez PPT et PPTX pour PowerPoint avec Aspose.Slides Python via .NET, en explorant les différences de format, les avantages, la compatibilité et les astuces de conversion."
---

## **Qu'est-ce que le PPT ?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) est un format de fichier binaire, i.e. il est impossible d'en visualiser le contenu sans outils spéciaux. Les premières versions de PowerPoint 97‑2003 utilisaient le format de fichier PPT, cependant son extensibilité est limitée.  

## **Qu'est-ce que le PPTX ?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) est un nouveau format de fichier de présentation, basé sur la norme Office Open XML (ISO 29500:2008‑2016, ECMA‑376). Le PPTX est un ensemble archivé de fichiers XML et multimédia. Le format PPTX est facilement extensible. Par exemple, il est aisé d’ajouter la prise en charge d’un nouveau type de graphique ou de forme, sans modifier le format PPTX dans chaque nouvelle version de PowerPoint. Le format PPTX est utilisé à partir de PowerPoint 2007.

## **PPT vs PPTX**
Bien que le PPTX offre une fonctionnalité beaucoup plus large, le PPT reste très populaire. La nécessité de convertir de PPT vers PPTX et vice‑versa est fortement demandée.

Cependant, la conversion entre l’ancien format PPT et le nouveau format PPTX représente le défi le plus compliqué parmi les autres formats Microsoft Office. Bien que la spécification du format PPT soit ouverte, il est difficile de travailler avec. PowerPoint peut créer des parties spéciales (MetroBlob) dans les fichiers PPT pour stocker des informations provenant du PPTX qui ne sont pas prises en charge par le format PPT et ne peuvent pas être affichées dans les anciennes versions de PowerPoint. Ces informations peuvent être restaurées lorsqu’un fichier PPT est chargé dans une version moderne de PowerPoint ou converti au format PPTX.

Aspose.Slides propose une interface commune pour travailler avec tous les formats de présentation. Elle permet de convertir de PPT vers PPTX et de PPTX vers PPT de manière très simple. Aspose.Slides supporte pleinement la conversion de PPT vers PPTX et prend également en charge la conversion de PPTX vers PPT avec certaines restrictions. Nous recommandons d’utiliser le format PPTX autant que possible.

{{% alert color="primary" %}} 
Vérifiez la qualité des conversions de PPT vers PPTX et de PPTX vers PPT avec l’application en ligne [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPTX file
pres = slides.Presentation("PPTtoPPTX.ppt")

# Saving the PPTX presentation to PPTX format
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
En savoir plus [**Comment convertir des présentations PPT en PPTX**](/slides/fr/python-net/convert-ppt-to-pptx/)
{{% /alert %}} 

## **FAQ**

**Y a-t-il un intérêt à conserver les anciennes présentations au format PPT si elles s'ouvrent sans erreur ?**  
Si une présentation s’ouvre de manière fiable et n’a pas besoin de collaboration ou de fonctionnalités récentes, vous pouvez la conserver au format PPT. Mais pour la compatibilité et l’extensibilité futures, il est préférable de [convertir en PPTX](/slides/fr/python-net/convert-ppt-to-pptx/) : le format repose sur la norme OOXML ouverte et est davantage pris en charge par les outils modernes.

**Comment décider quelles fichiers sont critiques à convertir d'abord en PPTX ?**  
Convertissez d’abord les présentations qui : sont éditées par plusieurs personnes ; contiennent des [graphes](/slides/fr/python-net/create-chart/)/[formes](/slides/fr/python-net/shape-manipulations/) complexes ; sont utilisées dans des communications externes ; ou déclenchent des avertissements lorsqu’elles sont [ouvertes](/slides/fr/python-net/open-presentation/).

**La protection par mot de passe sera-t-elle conservée lors de la conversion de PPT en PPTX et inversement ?**  
Le mot de passe n’est conservé que si la conversion et le chiffrement sont correctement pris en charge par l’outil utilisé. Il est plus fiable de [supprimer la protection](/slides/fr/python-net/password-protected-presentation/), [convertir](/slides/fr/python-net/convert-ppt-to-pptx/), puis de réappliquer la protection selon votre politique de sécurité.

**Pourquoi certains effets disparaissent ou sont simplifiés lors de la conversion de PPTX vers PPT ?**  
Parce que le PPT ne prend pas en charge certains objets/propriétés plus récents. PowerPoint et les outils peuvent stocker des « traces » de ces informations dans des blocs spéciaux pour une restauration ultérieure, mais les anciennes versions de PowerPoint ne les rendront pas.