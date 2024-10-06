---
title: Gestion des Balises et des Données Personnalisées
type: docs
weight: 300
url: /cpp/managing-tags-and-custom-data

---

## Stockage des Données dans les Fichiers de Présentation

Les fichiers PPTX—éléments avec l'extension .pptx—sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations. 

Avec une *diapositive* étant l'un des éléments dans les présentations, une *partie de diapositive* contient le contenu d'une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties—comme les Balises Définies par l'Utilisateur—définies par l'ISO/IEC 29500. 

Les données personnalisées (spécifiques à une présentation) ou utilisateur peuvent exister sous forme de balises ([ITagCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_tag_collection)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_custom_xml_part_collection)). 

{{% alert color="primary" %}} 

Les balises sont essentiellement des valeurs de paires clé-valeur de type chaîne. 

{{% /alert %}} 

## Obtention des Valeurs des Balises

Dans les diapositives, une balise correspond à la propriété IDocumentProperties.Keywords. Ce code d'exemple vous montre comment obtenir la valeur d'une balise avec Aspose.Slides pour C++ pour [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## Ajout de Balises aux Présentations

Aspose.Slides vous permet d'ajouter des balises aux présentations. Une balise se compose généralement de deux éléments : 

- le nom d'une propriété personnalisée - `MyTag` 
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous devez classifier certaines présentations en fonction d'une règle ou d'une propriété spécifique, vous pourriez bénéficier de l'ajout de balises à ces présentations. Par exemple, si vous souhaitez catégoriser ou regrouper toutes les présentations des pays d'Amérique du Nord, vous pouvez créer une balise Nord-Américaine et ensuite assigner les pays pertinents (les États-Unis, le Mexique et le Canada) en tant que valeurs. 

Ce code d'exemple vous montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) en utilisant Aspose.Slides pour C++ :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Les balises peuvent également être définies pour une [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) :

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Ou pour une [Shape](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape) individuelle :

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```