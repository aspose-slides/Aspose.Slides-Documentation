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
## **Vue d'ensemble**

Cet article explique comment Aspose.Slides fonctionne avec les balises et les données personnalisées dans les présentations PowerPoint. Il décrit brièvement comment les données sont stockées dans les fichiers PPTX, indique que des données propres à la présentation peuvent exister sous forme de balises et de parties XML personnalisées, et décrit les balises comme des paires clé-valeur de chaînes.  

Il montre également comment lire les valeurs des balises et comment ajouter des balises à une présentation, à une diapositive individuelle ou à une forme. De plus, l'article couvre les tâches courantes de gestion des balises telles que la suppression de toutes les balises, la suppression d'une balise par son nom et la récupération de la liste des noms de balises.

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX - éléments portant l'extension .pptx - sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations.  

Une *diapositive* étant l'un des éléments d'une présentation, une *partie de diapositive* contient le contenu d'une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties - telles que les Balises définies par l'utilisateur - définies par ISO/IEC 29500.  

Les données personnalisées (spécifiques à une présentation) ou l'utilisateur peuvent exister sous forme de balises ([ITagCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itagcollection/)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icustomxmlpartcollection/)).  

{{% alert color="primary" %}} 

Les balises sont essentiellement des paires clé-valeur de chaînes. 

{{% /alert %}} 

## **Obtenir les valeurs des balises**

Dans les présentations, une balise correspond à la propriété IDocumentProperties.Keywords. Ce code d'exemple montre comment obtenir la valeur d'une balise avec Aspose.Slides pour C++ pour [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Ajouter des balises aux présentations**

Aspose.Slides vous permet d'ajouter des balises aux présentations. Une balise se compose généralement de deux éléments :

- le nom d'une propriété personnalisée - `MyTag`
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous devez classer certaines présentations en fonction d'une règle ou d'une propriété spécifique, vous pouvez tirer parti de l'ajout de balises à ces présentations. Par exemple, si vous souhaitez regrouper toutes les présentations provenant des pays d'Amérique du Nord, vous pouvez créer une balise Amérique du Nord puis assigner les pays concernés (États-Unis, Mexique et Canada) comme valeurs.  

Ce code d'exemple montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) en utilisant Aspose.Slides pour C++ :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Les balises peuvent également être définies pour [Slide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slide/) :

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Ou toute [Shape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/) individuelle :

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Limitations**

Les balises ajoutées via la collection de balises de données personnalisées en utilisant `get_CustomData()->get_Tags()` sont stockées uniquement dans le fichier PowerPoint. Elles ne sont **pas** transférées vers la structure de balises PDF lorsque la présentation est exportée en PDF. Par conséquent, un identifiant personnalisé assigné comme balise ne peut pas être récupéré à partir du PDF balisé.

**Solution alternative** : Vous pouvez stocker un identifiant personnalisé dans le **Alt Text** de l'objet (par ex., `shape->set_AlternativeText(u"MyId")`). Après l'exportation en PDF, le Alt Text peut apparaître dans la structure de balises du PDF.

## **FAQ**

**Puis-je supprimer toutes les balises d'une présentation, d'une diapositive ou d'une forme en une seule opération ?**

Oui. La [tag collection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/tagcollection/) prend en charge une opération [clear](https://reference.aspose.com/slides/fr/cpp/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé-valeur d'un seul coup.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez l'opération [Remove(name)](https://reference.aspose.com/slides/fr/cpp/aspose.slides/tagcollection/remove/) sur [TagCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises pour l'analyse ou le filtrage ?**

Utilisez [GetNamesOfTags](https://reference.aspose.com/slides/fr/cpp/aspose.slides/tagcollection/getnamesoftags/) sur la [tag collection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/tagcollection/) ; il renvoie un tableau de tous les noms de balises.