---
title: Gestion des étiquettes et des données personnalisées
type: docs
weight: 300
url: /net/managing-tags-and-custom-data
keywords: "Étiquettes, Données personnalisées, Valeur des étiquettes, Ajouter des étiquettes, Présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter des étiquettes et des données personnalisées aux présentations PowerPoint en C# ou .NET"
---

## Stockage des données dans les fichiers de présentation

Les fichiers PPTX—éléments avec l'extension .pptx—sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations.

Avec une *diapositive* étant l'un des éléments dans les présentations, une *partie de diapositive* contient le contenu d'une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties—telles que les Étiquettes définies par l'utilisateur—définies par l'ISO/IEC 29500.

Les données personnalisées (spécifiques à une présentation) ou à l'utilisateur peuvent exister sous forme d'étiquettes ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)).

{{% alert color="primary" %}}

Les étiquettes sont essentiellement des valeurs de paire clé-string.

{{% /alert %}}

## Obtenir les valeurs des étiquettes

Dans les diapositives, une étiquette correspond à la propriété IDocumentProperties.Keywords. Ce code d'exemple vous montre comment obtenir la valeur d'une étiquette avec Aspose.Slides pour .NET pour [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## Ajouter des étiquettes aux présentations

Aspose.Slides vous permet d'ajouter des étiquettes aux présentations. Une étiquette se compose généralement de deux éléments : 

- le nom d'une propriété personnalisée - `MyTag`
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous avez besoin de classer certaines présentations en fonction d'une règle ou d'une propriété spécifique, vous pourriez bénéficier de l'ajout d'étiquettes à ces présentations. Par exemple, si vous souhaitez classer ou regrouper toutes les présentations des pays nord-américains, vous pouvez créer une étiquette nord-américaine et ensuite attribuer les pays concernés (les États-Unis, le Mexique et le Canada) comme valeurs.

Ce code d'exemple vous montre comment ajouter une étiquette à une [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) à l'aide d'Aspose.Slides pour .NET :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Les étiquettes peuvent également être définies pour une [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) :

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Ou pour toute forme individuelle [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape) :

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "Mon texte";
    shape.CustomData.Tags["tag"] = "value";
}
```