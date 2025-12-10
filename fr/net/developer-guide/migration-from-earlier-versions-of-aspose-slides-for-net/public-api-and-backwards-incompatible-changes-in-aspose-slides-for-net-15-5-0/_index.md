---
title: API publique et modifications incompatibles rétroactives dans Aspose.Slides pour .NET 15.5.0
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
description: "Examinez les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/), ainsi que les autres modifications introduites avec l’API Aspose.Slides for .NET 15.5.0.  

{{% /alert %}} 
## **Modifications de l'API publique**
#### **Classe CommonSlideViewProperties et interface ICommonSlideViewProperties ont été ajoutées**
La classe Aspose.Slides.CommonSlideViewProperties et l'interface Aspose.Slides.ICommonSlideViewProperties représentent les propriétés communes de la vue des diapositives (actuellement les options d'échelle de la vue).

#### **Propriété IAxis.LabelOffset ajoutée**
La propriété IAxis.LabelOffset spécifie la distance des étiquettes par rapport à l'axe. Appliquée aux axes de catégorie ou de date.

#### **Propriété IChartTextBlockFormat.AutofitType ajoutée**
La modification de cette propriété peut avoir une influence uniquement sur ces parties du diagramme : DataLabel et DataLabelFormat (prise en charge complète dans PowerPoint 2013 ; dans PowerPoint 2007 il n’y a aucun effet lors du rendu).

#### **Propriété IChartTextBlockFormat.WrapText ajoutée**
La modification de cette propriété peut avoir une influence uniquement sur ces parties du diagramme : DataLabel et DataLabelFormat (prise en charge complète dans PowerPoint 2007/2013).

#### **Propriétés de marge ajoutées à IChartTextBlockFormat**
La modification de ces propriétés peut avoir une influence uniquement sur ces parties du diagramme : DataLabel et DataLabelFormat (prise en charge complète dans PowerPoint 2013 ; dans PowerPoint 2007 il n’y a aucun effet lors du rendu).

#### **Propriété ViewProperties.NotesViewProperties ajoutée**
La propriété Aspose.Slides.ViewProperties.NotesViewProperties a été ajoutée. Elle spécifie les propriétés communes de la vue associées au mode d’affichage des notes.

#### **Propriété ViewProperties.SlideViewProperties ajoutée**
La propriété Aspose.Slides.ViewProperties.SlideViewProperties a été ajoutée. Elle spécifie les propriétés communes de la vue associées au mode d’affichage des diapositives.