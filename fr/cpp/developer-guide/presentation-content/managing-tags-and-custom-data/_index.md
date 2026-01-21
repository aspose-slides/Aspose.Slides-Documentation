---
title: Gérer les balises et les données personnalisées dans les présentations avec C++
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/cpp/managing-tags-and-custom-data/
keywords:
- propriétés du document
- balise
- données personnalisées
- ajouter une balise
- paires de valeurs
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à ajouter, lire, mettre à jour et supprimer les balises et les données personnalisées dans Aspose.Slides pour C++, avec des exemples pour les présentations PowerPoint et OpenDocument."
---

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX—éléments avec l’extension .pptx—sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations. 

Avec une *diapositive* étant l’un des éléments des présentations, une *partie de diapositive* contient le contenu d’une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties—telles que les Balises définies par l’utilisateur—définies par ISO/IEC 29500. 

Les données personnalisées (spécifiques à une présentation) ou l’utilisateur peuvent exister sous forme de balises ([ITagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/itagcollection/)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 

Les balises sont essentiellement des paires clé‑valeur de type chaîne. 

{{% /alert %}} 

## **Obtenir les valeurs des balises**

Dans les diapos, une balise correspond à la propriété IDocumentProperties.Keywords. Ce code d’exemple montre comment obtenir la valeur d’une balise avec Aspose.Slides pour C++ pour [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) :
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```


## **Ajouter des balises aux présentations**

Aspose.Slides vous permet d’ajouter des balises aux présentations. Une balise se compose généralement de deux éléments : 

- le nom d’une propriété personnalisée - `MyTag` 
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous devez classer certaines présentations selon une règle ou une propriété spécifique, vous pouvez tirer parti de l’ajout de balises à ces présentations. Par exemple, si vous souhaitez regrouper toutes les présentations des pays d’Amérique du Nord, vous pouvez créer une balise « North American » puis affecter les pays pertinents (États‑Unis, Mexique et Canada) comme valeurs. 

Ce code d’exemple montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) en utilisant Aspose.Slides pour C++ :
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```


Les balises peuvent également être définies pour [Slide](https://reference.aspose.com/slides/cpp/aspose.slides/slide/) :
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


Ou pour n’importe quel [Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/) individuel :
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


## **FAQ**

**Puis‑je supprimer toutes les balises d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) prend en charge une opération [clear](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé‑valeur d’un coup.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez l’opération [Remove(name)](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/remove/) sur [TagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises à des fins d’analyse ou de filtrage ?**

Utilisez [GetNamesOfTags](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/getnamesoftags/) sur la [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de balises.