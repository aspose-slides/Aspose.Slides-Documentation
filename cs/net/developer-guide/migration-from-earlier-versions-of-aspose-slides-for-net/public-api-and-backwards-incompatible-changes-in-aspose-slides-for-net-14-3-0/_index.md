---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 14.3.0
linktitle: Aspose.Slides pro .NET 14.3.0
type: docs
weight: 50
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a kritické změny v Aspose.Slides pro .NET, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
## **Veřejné API a zpětně nekompatibilní změny**
### **Přidáno výčtové typy Aspose.Slides.ShapeThumbnailBounds a metody Aspose.Slides.IShape.GetThumbnail()**
Metody GetThumbnail() a GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) slouží k vytvoření samostatné miniatury tvaru. Výčtový typ ShapeThumbnailBounds definuje možné typy ohraničení miniatury tvaru.
### **Vlastnost UniqueId byla přidána do Aspose.Slides.IShape**
Vlastnost Aspose.Slides.IShape.UniqueId vrací jedinečný identifikátor tvaru v rámci prezentace. Tyto jedinečné identifikátory jsou uloženy v uživatelských štítcích tvaru.
### **Podpis metody SetGroupingItem byl změněn v IChartCategoryLevelsManager**
Podpis metody IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

je nyní zastaralý a byl nahrazen podpisem

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Nyní je potřeba změnit volání jako

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

na volání jako

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

Předávejte do SetGroupingItem hodnotu jako "Group 1", nikoli hodnotu typu IChartDataCell. Vytvoření IChartDataCell s definovaným listem, řádkem a sloupcem pro úrovně kategorií musí splňovat určité požadavky a bylo zabaleno do metody SetGroupingItem(int, object).
### **Vlastnost SlideId přidána do rozhraní Aspose.Slides.IBaseSlide**
Vlastnost SlideId vrací jedinečný identifikátor snímku.
### **Vlastnost SoundName přidána do ISlideShowTransition**
Řetězec s možností čtení i zápisu. Určuje čitelný název zvuku přechodu. Vlastnost Sound musí být přiřazena pro získání nebo nastavení názvu zvuku. Tento název se zobrazí v uživatelském rozhraní PowerPointu při ručním nastavení zvuku přechodu. Může vyvolat PptxException, pokud není vlastnost Sound přiřazena.
### **Typ vlastnosti ChartSeriesGroup.Type byl změněn**
Vlastnost ChartSeriesGroup.Type byla změněna z výčtového typu ChartType na nový výčtový typ CombinableSeriesTypesGroup. Výčtový typ CombinableSeriesTypesGroup představuje skupiny kombinovatelných typů sérií.
### **Přidána podpora pro generování individuálních miniatur tvarů**
Aspose.Slides.ShapeThumbnailBounds

Nové členy v Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)