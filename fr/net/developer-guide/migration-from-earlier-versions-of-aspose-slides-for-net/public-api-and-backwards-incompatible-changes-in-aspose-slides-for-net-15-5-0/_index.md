---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides pour .NET 15.5.0
linktitle: Aspose.Slides pour .NET 15.5.0
type: docs
weight: 160
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Passez en revue les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/), ainsi que d'autres changements introduits avec l'API Aspose.Slides for .NET 15.5.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **La classe CommonSlideViewProperties et l'interface ICommonSlideViewProperties ont été ajoutées**
La classe Aspose.Slides.CommonSlideViewProperties et l'interface Aspose.Slides.ICommonSlideViewProperties représentent des propriétés communes de la vue de diapositive (actuellement les options d'échelle de vue).

#### **La propriété IAxis.LabelOffset a été ajoutée**
La propriété IAxis.LabelOffset spécifie la distance des libellés par rapport à l'axe. Appliquée à l'axe de catégorie ou de date.

#### **La propriété IChartTextBlockFormat.AutofitType a été ajoutée**
Modifier cette propriété ne peut produire qu'une influence certaine uniquement sur ces parties du diagramme : DataLabel et DataLabelFormat (prise en charge complète dans PowerPoint 2013 ; dans PowerPoint 2007 il n'y a aucun effet lors du rendu).

#### **La propriété IChartTextBlockFormat.WrapText a été ajoutée**
Modifier cette propriété ne peut produire qu'une influence certaine uniquement sur ces parties du diagramme : DataLabel et DataLabelFormat (prise en charge complète dans PowerPoint 2007/2013).

#### **Des propriétés de marge ont été ajoutées à IChartTextBlockFormat**
Modifier ces propriétés ne peut produire qu'une influence certaine uniquement sur ces parties du diagramme : DataLabel et DataLabelFormat (prise en charge complète dans PowerPoint 2013 ; dans PowerPoint 2007 il n'y a aucun effet lors du rendu).

#### **La propriété ViewProperties.NotesViewProperties a été ajoutée**
La propriété Aspose.Slides.ViewProperties.NotesViewProperties a été ajoutée. Elle spécifie les propriétés de vue communes associées au mode de vue des notes.

#### **La propriété ViewProperties.SlideViewProperties a été ajoutée**
La propriété Aspose.Slides.ViewProperties.SlideViewProperties a été ajoutée. Elle spécifie les propriétés de vue communes associées au mode de vue des diapositives.