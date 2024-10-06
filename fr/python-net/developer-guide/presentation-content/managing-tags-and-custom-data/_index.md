---
title: Gestion des balises et des données personnalisées
type: docs
weight: 300
url: /python-net/managing-tags-and-custom-data/
keywords: "Balises, Données personnalisées, Valeur des balises, Ajouter des balises, Présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter des balises et des données personnalisées aux présentations PowerPoint en Python"
---

## Stockage des données dans les fichiers de présentation

Les fichiers PPTX — éléments avec l'extension .pptx — sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations.

Avec une *diapositive* étant l'un des éléments dans les présentations, une *partie de diapositive* contient le contenu d'une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties — telles que les balises définies par l'utilisateur — définies par l'ISO/IEC 29500.

Les données personnalisées (spécifiques à une présentation) ou à l'utilisateur peuvent exister sous forme de balises ([ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 

Les balises sont essentiellement des valeurs de paires clé-valeur de type chaîne. 

{{% /alert %}} 

## Obtention des valeurs pour les balises

Dans les diapositives, une balise correspond à la propriété IDocumentProperties.Keywords. Ce code d'exemple vous montre comment obtenir la valeur d'une balise avec Aspose.Slides pour Python via .NET pour [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## Ajout de balises aux présentations

Aspose.Slides vous permet d'ajouter des balises aux présentations. Une balise se compose généralement de deux éléments : 

- le nom d'une propriété personnalisée - `MyTag` 
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous avez besoin de classer certaines présentations en fonction d'une règle ou d'une propriété spécifique, vous pourriez bénéficier de l'ajout de balises à ces présentations. Par exemple, si vous souhaitez catégoriser ou regrouper toutes les présentations des pays d'Amérique du Nord, vous pouvez créer une balise nord-américaine et ensuite attribuer les pays concernés (les États-Unis, le Mexique et le Canada) en tant que valeurs.

Ce code d'exemple vous montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en utilisant Aspose.Slides pour Python via .NET :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Des balises peuvent également être définies pour une [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Ou pour une [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) individuelle :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "Mon texte"
    shape.custom_data.tags.add("tag", "value")
```