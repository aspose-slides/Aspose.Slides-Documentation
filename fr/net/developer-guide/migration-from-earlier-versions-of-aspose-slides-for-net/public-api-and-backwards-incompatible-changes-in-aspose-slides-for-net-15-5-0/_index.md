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
description: "Examinez les mises à jour de l'API publique et les changements disruptifs dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentations PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/), ainsi que les autres changements introduits avec l'API Aspose.Slides pour .NET 15.5.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **La classe CommonSlideViewProperties et l'interface ICommonSlideViewProperties ont été ajoutées**
La classe Aspose.Slides.CommonSlideViewProperties et l'interface Aspose.Slides.ICommonSlideViewProperties représentent les propriétés communes de la vue des diapositives (actuellement les options d'échelle de la vue).
#### **La propriété IAxis.LabelOffset a été ajoutée**
La propriété IAxis.LabelOffset spécifie la distance des étiquettes par rapport à l'axe. Appliquée à l'axe de catégorie ou de date.
#### **La propriété IChartTextBlockFormat.AutofitType a été ajoutée**
La modification de cette propriété peut avoir une influence uniquement sur ces parties du graphique : DataLabel et DataLabelFormat (support complet dans PowerPoint 2013 ; dans PowerPoint 2007 il n’y a aucun effet lors du rendu).
#### **La propriété IChartTextBlockFormat.WrapText a été ajoutée**
La modification de cette propriété peut avoir une influence uniquement sur ces parties du graphique : DataLabel et DataLabelFormat (support complet dans PowerPoint 2007/2013).
#### **Les propriétés de marge ont été ajoutées à IChartTextBlockFormat**
La modification de ces propriétés peut avoir une influence uniquement sur ces parties du graphique : DataLabel et DataLabelFormat (support complet dans PowerPoint 2013 ; dans PowerPoint 2007 il n’y a aucun effet lors du rendu).
#### **La propriété ViewProperties.NotesViewProperties a été ajoutée**
La propriété Aspose.Slides.ViewProperties.NotesViewProperties a été ajoutée. Elle spécifie les propriétés de vue communes associées au mode de vue des notes.
#### **La propriété ViewProperties.SlideViewProperties a été ajoutée**
La propriété Aspose.Slides.ViewProperties.SlideViewProperties a été ajoutée. Elle spécifie les propriétés de vue communes associées au mode de vue des diapositives.