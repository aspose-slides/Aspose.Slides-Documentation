---
title: API Public et Changements Incompatibles avec les Versions Précédentes dans Aspose.Slides pour .NET 15.7.0
type: docs
weight: 180
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) ou [suppressions](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) de classes, méthodes, propriétés, etc., ainsi que d'autres changements introduits avec l'API Aspose.Slides pour .NET 15.7.0.

{{% /alert %}} 
## **Changements de l'API Public**
#### **L'énumération ImagePixelFormat a été ajoutée**
L'énumération Aspose.Slides.Export.ImagePixelFormat a été ajoutée pour spécifier le format de pixel pour les images générées.
#### **La méthode IChartDataPoint.GetAutomaticDataPointColor() a été ajoutée**
Renvoie une couleur automatique du point de données basée sur l'index de la série, l'index du point de données, ParentSeriesGroup, la propriété IsColorVaried et le style du graphique.
Cette couleur est utilisée par défaut si FillType est égal à NotDefined.
#### **La méthode RenderToGraphics a été ajoutée à Slide**
La méthode RenderToGraphics (et ses surcharges) a été ajoutée à Aspose.Slides.Slide pour le rendu d'une diapositive vers un objet Graphics.
#### **La propriété PixelFormat a été ajoutée à ITiffOptions et TiffOptions**
La propriété PixelFormat a été ajoutée à Aspose.Slides.Export.ITiffOptions et Aspose.Slides.Export.TiffOptions pour spécifier le format de pixel pour les images TIFF générées.