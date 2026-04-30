---
title: Gestion des balises et des données personnalisées dans les présentations en .NET
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/net/managing-tags-and-custom-data/
keywords:
- propriétés du document
- balise
- données personnalisées
- ajouter une balise
- valeurs de paires
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez comment ajouter, lire, mettre à jour et supprimer les balises et les données personnalisées dans Aspose.Slides pour .NET, avec des exemples pour les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Cet article explique comment Aspose.Slides fonctionne avec les balises et les données personnalisées dans les présentations PowerPoint. Il décrit brièvement comment les données sont stockées dans les fichiers PPTX, indique que des données spécifiques à la présentation peuvent exister sous forme de balises et de parties XML personnalisées, et définit les balises comme des paires de chaînes clé‑valeur.

Il montre également comment lire les valeurs des balises et comment ajouter des balises à une présentation, à une diapositive individuelle ou à une forme. En outre, l’article couvre les tâches courantes de gestion des balises telles que la suppression de toutes les balises, la suppression d’une balise par son nom et la récupération de la liste des noms de balises.

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX—éléments portant l’extension .pptx—sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations. 

Une *diapositive* étant l’un des éléments des présentations, une *partie de diapositive* contient le contenu d’une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties—telles que les Balises définies par l’utilisateur—définies par ISO/IEC 29500. 

Les données personnalisées (spécifiques à une présentation) ou de l’utilisateur peuvent exister sous forme de balises ([ITagCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/itagcollection)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 
Les balises sont essentiellement des paires clé‑valeur de chaînes. 
{{% /alert %}} 

## **Obtenir les valeurs des balises**

Dans Slides, une balise correspond à la propriété IDocumentProperties.Keywords. Ce code d’exemple montre comment obtenir la valeur d’une balise avec Aspose.Slides pour .NET pour [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Ajouter des balises aux présentations**

Aspose.Slides vous permet d’ajouter des balises aux présentations. Une balise se compose généralement de deux éléments :

- le nom d’une propriété personnalisée – `MyTag` 
- la valeur de la propriété personnalisée – `My Tag Value`

Si vous devez classer certaines présentations selon une règle ou une propriété spécifique, vous pouvez tirer parti de l’ajout de balises à ces présentations. Par exemple, si vous voulez regrouper toutes les présentations provenant des pays d’Amérique du Nord, vous pouvez créer une balise « North American » puis attribuer les pays pertinents (États‑Unis, Mexique et Canada) comme valeurs. 

Ce code d’exemple montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) en utilisant Aspose.Slides pour .NET :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Les balises peuvent également être définies pour [Slide](https://reference.aspose.com/slides/fr/net/aspose.slides/slide) :

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Ou pour toute [Shape](https://reference.aspose.com/slides/fr/net/aspose.slides/shape) individuelle :

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Limitations**

Les balises ajoutées via la collection `CustomData.Tags` sont stockées uniquement dans le fichier PowerPoint. Elles ne sont **pas** transférées vers la structure de balises PDF lors de l’exportation de la présentation au format PDF. Par conséquent, un identifiant personnalisé affecté en tant que balise ne peut pas être récupéré à partir du PDF balisé.

**Solution de contournement** : vous pouvez stocker un identifiant personnalisé dans le **texte alternatif** de l’objet (par ex. `shape.AlternativeText = "MyId"`). Après l’exportation en PDF, le texte alternatif peut apparaître dans la structure de balises du PDF.

## **FAQ**

**Puis‑je supprimer toutes les balises d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [collection de balises](https://reference.aspose.com/slides/fr/net/aspose.slides/tagcollection/) prend en charge une opération [clear](https://reference.aspose.com/slides/fr/net/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé‑valeur d’un coup.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez l’opération [Remove(name)](https://reference.aspose.com/slides/fr/net/aspose.slides/tagcollection/remove/) sur [TagCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/tagcollection/) pour effacer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises à des fins d’analyse ou de filtrage ?**

Utilisez [GetNamesOfTags](https://reference.aspose.com/slides/fr/net/aspose.slides/tagcollection/getnamesoftags/) sur la [collection de balises](https://reference.aspose.com/slides/fr/net/aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de balises.