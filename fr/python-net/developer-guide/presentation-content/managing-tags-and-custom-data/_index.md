---
title: Gestion des balises et des données personnalisées dans les présentations avec Python
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/python-net/managing-tags-and-custom-data/
keywords:
- propriétés du document
- balise
- données personnalisées
- ajouter une balise
- valeurs de paires
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment ajouter, lire, mettre à jour et supprimer les balises et les données personnalisées dans Aspose.Slides pour Python via .NET, avec des exemples pour les présentations PowerPoint et OpenDocument."
---

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX — les éléments avec l’extension .pptx — sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations. 

Dans une présentation, une *diapositive* est l’un des éléments, et une *partie de diapositive* contient le contenu d’une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties — comme les balises définies par l’utilisateur — définies par la norme ISO/IEC 29500. 

Les données personnalisées (spécifiques à une présentation) ou utilisateur peuvent exister sous forme de balises ([ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 
Les balises sont essentiellement des valeurs de paires clé‑chaîne. 
{{% /alert %}} 

## **Obtenir les valeurs des balises**

Dans les diapositives, une balise correspond à la propriété IDocumentProperties.Keywords. Ce code d’exemple montre comment obtenir la valeur d’une balise avec Aspose.Slides pour Python via .NET pour [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/):
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```


## **Ajouter des balises aux présentations**

Aspose.Slides vous permet d’ajouter des balises aux présentations. Une balise se compose généralement de deux éléments :
- le nom d’une propriété personnalisée - `MyTag` 
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous devez classer certaines présentations selon une règle ou une propriété spécifique, vous pouvez tirer parti de l’ajout de balises à ces présentations. Par exemple, si vous souhaitez regrouper toutes les présentations des pays d’Amérique du Nord, vous pouvez créer une balise « North American » et attribuer aux pays concernés (les États‑Unis, le Mexique et le Canada) comme valeurs. 

Ce code d’exemple montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en utilisant Aspose.Slides pour Python via .NET :
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```


Les balises peuvent également être définies pour [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/):
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```


Ou pour n’importe quel [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/):
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```


## **FAQ**

**Puis-je supprimer toutes les balises d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) prend en charge une opération [clear](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé‑valeur d’un seul coup.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez l’opération [remove(name)](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/remove/) sur [TagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises pour l’analyse ou le filtrage ?**

Utilisez [get_names_of_tags](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/get_names_of_tags/) sur la [tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/); cela renvoie un tableau de tous les noms de balises.