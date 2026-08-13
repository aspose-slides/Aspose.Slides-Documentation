---
title: API publique et modifications incompatibles rétrogrades dans Aspose.Slides for .NET 15.7.0
linktitle: Aspose.Slides for .NET 15.7.0
type: docs
weight: 180
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
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
description: "Passez en revue les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides for .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés et ainsi de suite [ajoutés](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) ou [supprimés](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/), ainsi que les autres changements introduits avec l'API Aspose.Slides for .NET 15.7.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **Enum ImagePixelFormat a été ajouté**
L'énumération Aspose.Slides.Export.ImagePixelFormat a été ajoutée pour spécifier le format de pixel des images générées.
#### **Méthode IChartDataPoint.GetAutomaticDataPointColor() a été ajoutée**
Renvoie une couleur automatique du point de données basée sur l'index de la série, l'index du point de données, ParentSeriesGroup, la propriété IsColorVaried et le style du graphique.
Cette couleur est utilisée par défaut si FillType est égal à NotDefined.
#### **Méthode RenderToGraphics a été ajoutée à Slide**
La méthode RenderToGraphics (et ses surcharges) a été ajoutée à Aspose.Slides.Slide pour rendre une diapositive dans un objet Graphics.
#### **Propriété PixelFormat a été ajoutée à ITiffOptions et TiffOptions**
La propriété PixelFormat a été ajoutée à Aspose.Slides.Export.ITiffOptions et Aspose.Slides.Export.TiffOptions pour spécifier le format de pixel des images TIFF générées.