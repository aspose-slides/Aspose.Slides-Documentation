---
title: API publique et modifications incompatibles rétroactives dans Aspose.Slides pour .NET 14.3.0
linktitle: Aspose.Slides pour .NET 14.3.0
type: docs
weight: 50
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- migration
- code legacy
- code moderne
- approche legacy
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Passez en revue les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

## **API publique et modifications incompatibles rétroactives**
### **Énumération Aspose.Slides.ShapeThumbnailBounds et méthodes Aspose.Slides.IShape.GetThumbnail() ajoutées**
Les méthodes GetThumbnail() et GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) sont utilisées pour créer une vignette de forme distincte. L'énumération ShapeThumbnailBounds définit les types de limites de vignette de forme possibles.
### **La propriété UniqueId a été ajoutée à Aspose.Slides.IShape**
La propriété Aspose.Slides.IShape.UniqueId fournit un identifiant de forme unique dans le périmètre d'une présentation. Ces identifiants uniques sont stockés dans les balises personnalisées des formes.
### **Signature de la méthode SetGroupingItem modifiée dans IChartCategoryLevelsManager**
Signature de la méthode IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

est désormais obsolète et remplacée par la signature

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Désormais, les appels comme

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

doivent être modifiés en appels comme

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

Passez une valeur telle que "Group 1" à SetGroupingItem mais pas une valeur de type IChartDataCell. La création d'un IChartDataCell avec une feuille de calcul définie, une ligne et une colonne pour les niveaux de catégorie doit satisfaire certaines exigences et a été encapsulée dans la méthode SetGroupingItem(int, object).
### **Propriété SlideId ajoutée à l'interface Aspose.Slides.IBaseSlide**
La propriété SlideId fournit un identifiant de diapositive unique.
### **Propriété SoundName ajoutée à ISlideShowTransition**
Chaîne en lecture‑écriture. Spécifie un nom lisible par l'homme pour le son de la transition. La propriété Sound doit être attribuée pour obtenir ou définir le nom du son. Ce nom apparaît dans l'interface utilisateur de PowerPoint lors de la configuration manuelle du son de transition. Peut lever une PptxException si la propriété Sound n'est pas attribuée.
### **Type de la propriété ChartSeriesGroup.Type modifié**
La propriété ChartSeriesGroup.Type a été modifiée, passant de l'énumération ChartType à la nouvelle énumération CombinableSeriesTypesGroup. L'énumération CombinableSeriesTypesGroup représente les groupes de types de séries combinables.
### **Prise en charge de la génération de vignettes de forme individuelles ajoutée**
Aspose.Slides.ShapeThumbnailBounds

Nouveaux membres dans Aspose.Slides.IShape, Aspose.Slides.Shape :
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)