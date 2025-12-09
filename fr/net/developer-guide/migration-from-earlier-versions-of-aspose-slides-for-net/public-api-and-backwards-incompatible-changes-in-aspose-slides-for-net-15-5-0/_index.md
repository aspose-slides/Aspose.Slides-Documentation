---
title: API publique et changements non rétrocompatibles dans Aspose.Slides pour .NET 15.5.0
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
description: "Examinez les mises à jour de l'API publique et les changements non rétrocompatibles dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 
Cette page répertorie toutes les [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) classes, méthodes, propriétés, etc., ainsi que les autres modifications introduites avec l'API Aspose.Slides for .NET 15.5.0.
{{% /alert %}} 
## **Modifications de l'API publique**
#### **CommonSlideViewProperties class and ICommonSlideViewProperties interface have been added**
La classe Aspose.Slides.CommonSlideViewProperties et l'interface Aspose.Slides.ICommonSlideViewProperties représentent les propriétés communes de la vue de diapositive (actuellement les options d'échelle de la vue).
#### **IAxis.LabelOffset property has been added**
La propriété IAxis.LabelOffset spécifie la distance des étiquettes par rapport à l'axe. Appliquée à l'axe de catégorie ou de date.
#### **IChartTextBlockFormat.AutofitType property has been added**
La propriété IChartTextBlockFormat.AutofitType a été ajoutée.
La modification de cette propriété peut exercer une influence uniquement sur ces éléments du graphique : DataLabel et DataLabelFormat (prise en charge complète dans PowerPoint 2013 ; dans PowerPoint 2007 il n'y a aucun effet lors du rendu).
#### **IChartTextBlockFormat.WrapText property has been added**
La propriété IChartTextBlockFormat.WrapText a été ajoutée.
La modification de cette propriété peut exercer une influence uniquement sur ces éléments du graphique : DataLabel et DataLabelFormat (prise en charge complète dans PowerPoint 2007/2013).
#### **Margin properties have been added to IChartTextBlockFormat**
Les propriétés de marge ont été ajoutées à IChartTextBlockFormat.
La modification de ces propriétés peut exercer une influence uniquement sur ces éléments du graphique : DataLabel et DataLabelFormat (prise en charge complète dans PowerPoint 2013 ; dans PowerPoint 2007 il n'y a aucun effet lors du rendu).
#### **ViewProperties.NotesViewProperties property has been added**
La propriété Aspose.Slides.ViewProperties.NotesViewProperties a été ajoutée. Elle spécifie les propriétés communes de la vue associées au mode d'affichage des notes.
#### **ViewProperties.SlideViewProperties property has been added**
La propriété Aspose.Slides.ViewProperties.SlideViewProperties a été ajoutée. Elle spécifie les propriétés communes de la vue associées au mode d'affichage des diapositives.