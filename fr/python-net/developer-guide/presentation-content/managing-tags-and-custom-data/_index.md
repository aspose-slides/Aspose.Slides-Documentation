---
title: Gestion des tags et des données personnalisées dans les présentations avec Python
linktitle: Tags et données personnalisées
type: docs
weight: 300
url: /fr/python-net/managing-tags-and-custom-data/
keywords:
- propriétés du document
- tag
- données personnalisées
- ajouter un tag
- paires de valeurs
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment ajouter, lire, mettre à jour et supprimer les tags et les données personnalisées dans Aspose.Slides pour Python via .NET, avec des exemples pour les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Cet article explique comment Aspose.Slides fonctionne avec les tags et les données personnalisées dans les présentations PowerPoint. Il décrit brièvement comment les données sont stockées dans les fichiers PPTX, indique que des données spécifiques à la présentation peuvent exister sous forme de tags et de parties XML personnalisées, et décrit les tags comme des paires clé‑valeur de chaînes.

Il montre également comment lire les valeurs des tags et comment ajouter des tags à une présentation, à une diapositive individuelle ou à une forme. De plus, l'article couvre les tâches courantes de gestion des tags telles que la suppression de tous les tags, la suppression d'un tag par son nom et la récupération de la liste des noms de tags.

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX — les éléments avec l’extension .pptx — sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations.  

Une *diapositive* étant l’un des éléments des présentations, une *partie de diapositive* contient le contenu d’une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties — telles que les User Defined Tags — définies par ISO/IEC 29500.  

Les données personnalisées (spécifiques à une présentation) ou de l'utilisateur peuvent exister sous forme de tags ([ITagCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/itagcollection/)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/icustomxmlpartcollection/)).  

{{% alert color="primary" %}} 
Les tags sont essentiellement des paires clé‑valeur de chaînes. 
{{% /alert %}} 

## **Obtenir les valeurs des tags**

Dans les diapositives, un tag correspond à la propriété IDocumentProperties.Keywords. Ce code d’exemple montre comment obtenir la valeur d’un tag avec Aspose.Slides for Python via .NET pour [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Ajouter des tags aux présentations**

Aspose.Slides vous permet d’ajouter des tags aux présentations. Un tag se compose généralement de deux éléments : 

- le nom d’une propriété personnalisée - `MyTag` 
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous devez classer certaines présentations selon une règle ou une propriété spécifique, vous pouvez tirer parti de l’ajout de tags à ces présentations. Par exemple, si vous souhaitez regrouper toutes les présentations provenant des pays d’Amérique du Nord, vous pouvez créer un tag North American et attribuer ensuite les pays concernés (les États‑Unis, le Mexique et le Canada) comme valeurs.  

Ce code d’exemple montre comment ajouter un tag à une [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) en utilisant Aspose.Slides for Python via .NET :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Les tags peuvent également être définis pour [Slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/) :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Ou toute [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/) individuelle :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Limitations**

Les tags ajoutés via la collection `custom_data.tags` sont stockés uniquement dans le fichier PowerPoint. Ils ne sont **pas** transférés vers la structure de tags PDF lorsque la présentation est exportée au format PDF. Par conséquent, un identifiant personnalisé assigné en tant que tag ne peut pas être récupéré à partir du PDF balisé.  

**Solution de contournement** : vous pouvez stocker un identifiant personnalisé dans le **Texte alternatif** de l’objet (par ex., `shape.alternative_text = "MyId"`). Après l’exportation au format PDF, le Texte alternatif peut apparaître dans la structure de tags du PDF.  

## **FAQ**

**Puis-je supprimer tous les tags d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**  
Oui. La [tag collection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/) prend en charge une opération [clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé‑valeur d’un coup.  

**Comment supprimer un seul tag par son nom sans parcourir toute la collection ?**  
Utilisez l’opération [remove(name)](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/remove/) sur la [TagCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/) pour supprimer le tag par sa clé.  

**Comment récupérer la liste complète des noms de tags pour l’analyse ou le filtrage ?**  
Utilisez [get_names_of_tags](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/get_names_of_tags/) sur la [tag collection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de tags.