---
title: Gérer les balises et les données personnalisées dans les présentations en .NET
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/net/managing-tags-and-custom-data/
keywords:
- propriétés du document
- balise
- données personnalisées
- ajouter une balise
- paires de valeurs
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez comment ajouter, lire, mettre à jour et supprimer des balises et des données personnalisées dans Aspose.Slides pour .NET, avec des exemples pour les présentations PowerPoint et OpenDocument."
---

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX—éléments avec l’extension .pptx—sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations. 

Avec un *slide* étant l’un des éléments des présentations, une *slide part* contient le contenu d’une seule diapositive. Une slide part peut avoir des relations explicites avec de nombreuses parties—comme les User Defined Tags—définies par la norme ISO/IEC 29500. 

Les données personnalisées (spécifiques à une présentation) ou utilisateur peuvent exister sous forme de tags ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 
Les tags sont essentiellement des paires clé‑valeur de type chaîne. 
{{% /alert %}} 

## **Obtention des valeurs des tags**

Dans les diapositives, un tag correspond à la propriété IDocumentProperties.Keywords. Ce code d'exemple montre comment obtenir la valeur d’un tag avec Aspose.Slides pour .NET pour [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation):
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```


## **Ajout de tags aux présentations**

Aspose.Slides vous permet d’ajouter des tags aux présentations. Un tag se compose généralement de deux éléments :
- le nom d’une propriété personnalisée - `MyTag` 
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous devez classer certaines présentations selon une règle ou une propriété spécifique, vous pouvez bénéficier de l’ajout de tags à ces présentations. Par exemple, si vous voulez regrouper toutes les présentations provenant des pays d’Amérique du Nord, vous pouvez créer un tag North American puis assigner les pays pertinents (les États‑Unis, le Mexique et le Canada) comme valeurs. 

Ce code d'exemple montre comment ajouter un tag à un [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) en utilisant Aspose.Slides pour .NET:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```


Les tags peuvent également être définis pour [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) :
```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```


Ou pour n’importe quel [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape) individuel :
```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```


## **FAQ**

**Puis-je supprimer tous les tags d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) prend en charge l’opération [clear](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé‑valeur en même temps.

**Comment supprimer un seul tag par son nom sans parcourir toute la collection ?**

Utilisez l’opération [Remove(name)](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/remove/) sur [TagCollection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) pour supprimer le tag par sa clé.

**Comment récupérer la liste complète des noms de tags pour l’analyse ou le filtrage ?**

Utilisez [GetNamesOfTags](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/getnamesoftags/) sur la [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/); elle renvoie un tableau de tous les noms de tags.