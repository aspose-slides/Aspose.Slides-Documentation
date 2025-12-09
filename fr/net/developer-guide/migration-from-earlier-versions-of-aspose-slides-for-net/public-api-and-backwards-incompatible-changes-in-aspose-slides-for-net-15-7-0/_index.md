---
title: API publique et changements incompatibles avec les versions antérieures dans Aspose.Slides pour .NET 15.7.0
linktitle: Aspose.Slides pour .NET 15.7.0
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
description: "Passez en revue les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) classes, méthodes, propriétés, etc., et d’autres changements introduits avec l’API Aspose.Slides pour .NET 15.7.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **Enum ImagePixelFormat a été ajouté**
Enum Aspose.Slides.Export.ImagePixelFormat a été ajouté pour spécifier le format de pixel des images générées.
#### **Méthode IChartDataPoint.GetAutomaticDataPointColor() a été ajoutée**
Renvoie une couleur automatique du point de données basée sur l'index de la série, l'index du point de données, ParentSeriesGroup, la propriété IsColorVaried et le style du graphique.
Cette couleur est utilisée par défaut si FillType est égal à NotDefined.
#### **Méthode RenderToGraphics a été ajoutée à Slide**
La méthode RenderToGraphics (et ses surcharges) a été ajoutée à Aspose.Slides.Slide pour rendre une diapositive vers un objet Graphics.
#### **Propriété PixelFormat a été ajoutée à ITiffOptions et TiffOptions**
La propriété PixelFormat a été ajoutée à Aspose.Slides.Export.ITiffOptions et Aspose.Slides.Export.TiffOptions pour spécifier le format de pixel des images TIFF générées.