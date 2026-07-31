---
title: Gérer les infobulles dans les graphiques de présentation avec C++
linktitle: Infobulle
type: docs
url: /fr/cpp/callout/
keywords:
- infobulle de graphique
- utiliser l'infobulle
- étiquette de données
- format d'étiquette
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créez et stylisez des infobulles dans Aspose.Slides pour C++ avec des exemples de code concis, compatibles avec PPT et PPTX pour automatiser les flux de travail de présentation."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les infobulles pour les étiquettes de données de diagramme dans Aspose.Slides. Il montre comment utiliser la méthode `set_ShowLabelAsDataCallout` pour afficher les étiquettes sous forme d'infobulles, comment configurer les paramètres d'étiquette liés aux infobulles pour un diagramme en anneau, et indique que les infobulles et leur apparence sont conservées lors de l'exportation des présentations vers PDF, HTML5, SVG et les formats d'images matricielles.

## **Utilisation des infobulles**
La nouvelle propriété **ShowLabelAsDataCallout** a été ajoutée à la classe **DataLabelFormat** et à l'interface **IDataLabelFormat**, ce qui détermine si l'étiquette de données du graphique spécifié sera affichée sous forme d'infobulle ou d'étiquette de données. Dans l'exemple ci-dessous, nous avons défini les infobulles.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Définir une infobulle pour un diagramme en anneau**
Aspose.Slides pour C++ offre la prise en charge de la définition de la forme d'infobulle d'étiquette de données de série pour un diagramme en anneau. Un exemple de code ci-dessous est fourni.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Les infobulles sont‑elles conservées lors de la conversion d’une présentation en PDF, HTML5, SVG ou images ?**

Oui. Les infobulles font partie du rendu du graphique, donc lorsque vous exportez vers [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/fr/cpp/export-to-html5/), [SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/) ou [images matricielles](/slides/fr/cpp/convert-powerpoint-to-png/), elles sont conservées avec le formatage de la diapositive.

**Les polices personnalisées fonctionnent‑elles dans les infobulles, et leur apparence peut‑elle être conservée lors de l’exportation ?**

Oui. Aspose.Slides prend en charge l'[incorporation de polices](/slides/fr/cpp/embedded-font/) dans la présentation et contrôle l'incorporation des polices lors des exportations telles que [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), garantissant que les infobulles conservent le même aspect sur différents systèmes.