---
title: Gérer les callouts dans les graphiques de présentation avec C++
linktitle: Callout
type: docs
url: /fr/cpp/callout/
keywords:
- callout de graphique
- utiliser le callout
- étiquette de données
- format d'étiquette
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créez et stylisez des callouts dans Aspose.Slides pour C++ avec des exemples de code concis, compatibles avec PPT et PPTX pour automatiser les flux de travail des présentations."
---

## **Utilisation des callouts**
La nouvelle propriété **ShowLabelAsDataCallout** a été ajoutée à la classe **DataLabelFormat** et à l'interface **IDataLabelFormat**, qui détermine si l'étiquette de données du graphique spécifié sera affichée sous forme de callout ou d'étiquette de données. Dans l'exemple ci-dessous, nous avons défini les callouts.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Définir un callout pour un diagramme en anneau**
Aspose.Slides for C++ offre la prise en charge de la définition de la forme du callout d'étiquette de données de série pour un diagramme en anneau. L'exemple suivant est fourni.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Les callouts sont-ils conservés lors de la conversion d’une présentation en PDF, HTML5, SVG ou images ?**

Oui. Les callouts font partie du rendu du graphique, de sorte que lors de l’exportation vers [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/fr/cpp/export-to-html5/), [SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/) ou [images raster](/slides/fr/cpp/convert-powerpoint-to-png/), ils sont conservés avec le formatage de la diapositive.

**Les polices personnalisées fonctionnent-elles dans les callouts, et leur apparence peut-elle être conservée lors de l’exportation ?**

Oui. Aspose.Slides prend en charge [l'incorporation de polices](/slides/fr/cpp/embedded-font/) dans la présentation et contrôle l'incorporation des polices lors des exportations telles que [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), garantissant que les callouts conservent le même aspect sur différents systèmes.