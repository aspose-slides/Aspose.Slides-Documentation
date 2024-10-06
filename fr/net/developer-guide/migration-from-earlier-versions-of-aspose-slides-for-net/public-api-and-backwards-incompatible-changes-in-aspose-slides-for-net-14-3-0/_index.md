---
title: API publique et changements incompatibles avec les versions précédentes dans Aspose.Slides pour .NET 14.3.0
type: docs
weight: 50
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
---

## **API publique et changements incompatibles avec les versions précédentes**
### **Énumération Aspose.Slides.ShapeThumbnailBounds et méthodes Aspose.Slides.IShape.GetThumbnail() ajoutées**
Les méthodes GetThumbnail() et GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) sont utilisées pour créer une miniature de forme distincte. L'énumération ShapeThumbnailBounds définit les types de bornes de miniature de forme possibles.
### **La propriété UniqueId a été ajoutée à Aspose.Slides.IShape**
La propriété Aspose.Slides.IShape.UniqueId obtient un identifiant unique de forme dans le cadre d'une présentation. Ces identifiants uniques sont stockés dans des balises personnalisées de forme.
### **Signature de la méthode SetGroupingItem modifiée dans IChartCategoryLevelsManager**
La signature de la méthode IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

est désormais obsolète et remplacée par la signature

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Les appels comme

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Groupe 1"));

``` 

doivent maintenant être modifiés en appels comme

``` csharp

 .SetGroupingItem(1, "Groupe 1");

``` 

Passez une valeur comme "Groupe 1" dans SetGroupingItem mais pas une valeur de type IChartDataCell. La construction d'IChartDataCell avec une feuille de calcul définie, une ligne et une colonne pour les niveaux de catégorie doit satisfaire à certaines exigences et a été encapsulée dans la méthode SetGroupingItem(int, object).
### **Propriété SlideId ajoutée à l'interface Aspose.Slides.IBaseSlide**
La propriété SlideId obtient un identifiant unique de diapositive.
### **Propriété SoundName ajoutée à ISlideShowTransition**
Chaîne en lecture-écriture. Spécifie un nom lisible par un humain pour le son de la transition. La propriété Sound doit être assignée pour obtenir ou définir le nom du son. Ce nom apparaît dans l'interface utilisateur de PowerPoint lors de la configuration manuelle du son de la transition. Peut lancer PptxException lorsque la propriété Sound n'est pas assignée.
### **Type de propriété ChartSeriesGroup.Type modifié**
La propriété ChartSeriesGroup.Type a été modifiée de l'énumération ChartType à la nouvelle énumération CombinableSeriesTypesGroup. L'énumération CombinableSeriesTypesGroup représente les groupes de types de séries combinables.
### **Support pour la génération de miniatures de formes individuelles ajouté**
Aspose.Slides.ShapeThumbnailBounds

Nouveaux membres dans Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)