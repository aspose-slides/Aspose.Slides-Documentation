---
title: Maître de Diapositive
type: docs
weight: 80
url: /cpp/slide-master/
keywords: "Ajouter Maître de Diapositive, diapositive maître PPT, maître de diapositive PowerPoint, Image au Maître de Diapositive, Espace réservé, Plusieurs Maîtres de Diapositive, Comparer Maîtres de Diapositive, C++, CPP, Aspose.Slides pour C++"
description: "Ajouter ou modifier le maître de diapositive dans la présentation PowerPoint en C++"
---

## **Qu'est-ce qu'un Maître de Diapositive dans PowerPoint**

Un **Maître de Diapositive** est un modèle de diapositive qui définit la mise en page, les styles, le thème, les polices, l'arrière-plan et d'autres propriétés pour les diapositives d'une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et modèle pour votre entreprise, vous pouvez utiliser un maître de diapositive.

Un Maître de Diapositive est utile car il vous permet de définir et de changer l'apparence de toutes les diapositives de la présentation en une seule fois. Aspose.Slides prend en charge le mécanisme de Maître de Diapositive de PowerPoint.

VBA vous permet également de manipuler un Maître de Diapositive et d'exécuter les mêmes opérations prises en charge dans PowerPoint : changer les arrière-plans, ajouter des formes, personnaliser la mise en page, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d'utiliser des Maîtres de Diapositive et d'effectuer des tâches de base avec eux.

Voici les opérations de base du Maître de Diapositive :

- Créer ou modifier un Maître de Diapositive.
- Appliquer des Maîtres de Diapositive aux diapositives de présentation.
- Changer l'arrière-plan du Maître de Diapositive.
- Ajouter une image, un espace réservé, un Smart Art, etc. au Maître de Diapositive.

Voici des opérations plus avancées impliquant le Maître de Diapositive :

- Comparer des Maîtres de Diapositive.
- Fusionner des Maîtres de Diapositive.
- Appliquer plusieurs Maîtres de Diapositive.
- Copier une diapositive avec un Maître de Diapositive vers une autre présentation.
- Trouver des Maîtres de Diapositive en double dans les présentations.
- Définir le Maître de Diapositive comme la vue par défaut de la présentation.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter le [**Visualiseur PowerPoint en ligne**](https://products.aspose.app/slides/viewer) Aspose car c'est une mise en œuvre en direct de certains des processus fondamentaux décrits ici.

{{% /alert %}} 

## **Comment le Maître de Diapositive est-il appliqué**

Avant de travailler avec un maître de diapositive, vous voudrez peut-être comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives.

* Chaque présentation a au moins un Maître de Diapositive par défaut.
* Une présentation peut contenir plusieurs Maîtres de Diapositive. Vous pouvez ajouter plusieurs Maîtres de Diapositive et les utiliser pour styliser différentes parties d'une présentation de différentes manières.

Dans **Aspose.Slides**, un Maître de Diapositive est représenté par le type [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide).

L'objet [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) d'Aspose.Slides contient la liste [**get_Masters()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) de type [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection), qui contient une liste de toutes les diapositives maîtres définies dans une présentation.

En plus des opérations CRUD, l'interface [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) contient ces méthodes utiles : [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) et [**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311) . Ces méthodes sont héritées de la fonction de clonage de diapositive de base. Mais lors du traitement des Maîtres de Diapositive, ces méthodes vous permettent de mettre en œuvre des configurations compliquées.

Lorsque qu'une nouvelle diapositive est ajoutée à une présentation, un Maître de Diapositive lui est appliqué automatiquement. Le Maître de Diapositive de la diapositive précédente est sélectionné par défaut.

**Remarque** : Les diapositives de présentation sont stockées dans la liste [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) , et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation contient un seul Maître de Diapositive, ce maître de diapositive est sélectionné pour toutes les nouvelles diapositives. C'est la raison pour laquelle vous n'avez pas à définir le Maître de Diapositive pour chaque nouvelle diapositive que vous créez.

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle présentation, vous pouvez simplement appuyer sur la ligne inférieure sous la dernière diapositive, puis une nouvelle diapositive (avec le Maître de Diapositive de la dernière présentation) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez effectuer la tâche équivalente avec la méthode [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).

## **Maître de Diapositive dans la hiérarchie des Diapositives**

Utiliser des Dispositions de Diapositive avec le Maître de Diapositive permet une flexibilité maximale. Une Disposition de Diapositive permet de définir tous les mêmes styles que le Maître de Diapositive (arrière-plan, polices, formes, etc.). Cependant, lorsque plusieurs Dispositions de Diapositive sont combinées sur un Maître de Diapositive, un nouveau style est créé. Lorsque vous appliquez une Disposition de Diapositive à une diapositive unique, vous pouvez changer son style de celui appliqué par le Maître de Diapositive.

Le Maître de Diapositive l'emporte sur tous les éléments de configuration : Maître de Diapositive -> Disposition de Diapositive -> Diapositive :

![todo:image_alt_text](slide-master_2)

Chaque objet [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) a une propriété [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) avec une liste de Dispositions de Diapositive. Un type [Diapositive](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) a une propriété [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8) avec un lien vers une Disposition de Diapositive appliquée à la diapositive. L'interaction entre une diapositive et le Maître de Diapositive se produit à travers une Disposition de Diapositive.

{{% alert color="info" title="Note" %}}

* Dans Aspose.Slides, toutes les configurations de diapositive (Maître de Diapositive, Disposition de Diapositive, et la diapositive elle-même) sont en fait des objets de diapositive implémentant l'interface [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide).
* Par conséquent, le Maître de Diapositive et la Disposition de Diapositive peuvent implémenter les mêmes propriétés et vous devez savoir comment leurs valeurs seront appliquées à un objet [Diapositive](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide). Le Maître de Diapositive est appliqué en premier à une diapositive et ensuite la Disposition de Diapositive est appliquée. Par exemple, si le Maître de Diapositive et la Disposition de Diapositive ont tous deux une valeur d'arrière-plan, la Diapositive se terminera avec l'arrière-plan de la Disposition de Diapositive.

{{% /alert %}}

## **Ce qu'un Maître de Diapositive comprend**

Pour comprendre comment un Maître de Diapositive peut être changé, vous devez connaître ses constituants. Voici les propriétés essentielles de [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) :

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) - obtenir/définir l'arrière-plan de la diapositive.
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) - obtenir/définir les styles de texte du corps de la diapositive.
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) - obtenir/définir toutes les formes du Maître de Diapositive (espaces réservés, cadres d'images, etc.).
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) - obtenir/définir les contrôles ActiveX.
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) - obtenir le gestionnaire de thème.
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) - obtenir le gestionnaire d'en-têtes et de pieds de page.

Méthodes du Maître de Diapositive :

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) - obtenir toutes les Diapositives dépendant du Maître de Diapositive.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) - vous permet de créer un nouveau Maître de Diapositive basé sur le Maître de Diapositive actuel et un nouveau thème. Le nouveau Maître de Diapositive sera ensuite appliqué à toutes les diapositives dépendantes.

## **Obtenir le Maître de Diapositive**

Dans PowerPoint, le Maître de Diapositive peut être accessible depuis le menu Affichage -> Maître de Diapositive :

![todo:image_alt_text](slide-master_3.jpg)

En utilisant Aspose.Slides, vous pouvez accéder à un Maître de Diapositive de cette manière :

```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```

L'interface [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) représente un Maître de Diapositive. La propriété [get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) (liée au type [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)) contient une liste de tous les Maîtres de Diapositive définis dans la présentation.

## **Ajouter une Image au Maître de Diapositive**

Lorsque vous ajoutez une image à un Maître de Diapositive, cette image apparaîtra sur toutes les diapositives dépendantes de ce maître de diapositive.

Par exemple, vous pouvez placer le logo de votre entreprise et quelques images sur le Maître de Diapositive, puis revenir en mode d'édition de diapositive. Vous devriez voir l'image sur chaque diapositive.

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un maître de diapositive avec Aspose.Slides :

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" title="Voir aussi" %}} 

Pour plus d'informations sur l'ajout d'images à une diapositive, consultez l'article [Image de cadre](https://docs.aspose.com/slides/cpp/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Ajouter un Espace Réservé au Maître de Diapositive**

Ces champs de texte sont des espaces réservés standard sur un Maître de Diapositive : 

* Cliquez pour modifier le style du titre maître

* Modifier les styles de texte du maître

* Deuxième niveau

* Troisième niveau 

  Ils apparaissent également sur les diapositives basées sur le Maître de Diapositive. Vous pouvez modifier ces espaces réservés sur un Maître de Diapositive et les changements sont appliqués automatiquement aux diapositives.

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin Maître de Diapositive -> Insérer un espace réservé :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus compliqué pour les espaces réservés avec Aspose.Slides. Considérez une diapositive avec des espaces réservés modélisés à partir du Maître de Diapositive :

![todo:image_alt_text](slide-master_6.png)

Nous voulons changer le formatage du Titre et du Sous-titre sur le Maître de Diapositive de cette manière :

![todo:image_alt_text](slide-master_7.png)

Tout d'abord, nous récupérons le contenu de l'espace réservé pour le titre à partir de l'objet Maître de Diapositive, puis utilisons le champ `PlaceHolder.FillFormat` :

```c++
System::SharedPtr<IAutoShape> FindPlaceholder(System::SharedPtr<IMasterSlide> master, PlaceholderType type)
{
    for (auto& shape : master->get_Shapes())
    {
        System::SharedPtr<IAutoShape> autoShape = System::AsCast<Aspose::Slides::IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            if (autoShape->get_Placeholder()->get_Type() == type)
            {
                return autoShape;
            }
        }
    }
    return nullptr;
}

void Main()
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
    System::SharedPtr<IAutoShape> placeHolder = FindPlaceholder(master, Aspose::Slides::PlaceholderType::Title);
    auto fillFormat = placeHolder->get_FillFormat();
    fillFormat->set_FillType(Aspose::Slides::FillType::Gradient);
    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(Aspose::Slides::GradientShape::Linear);
    gradientFormat->get_GradientStops()->Add(0.0f, System::Drawing::Color::FromArgb(255, 0, 0));
    gradientFormat->get_GradientStops()->Add(255.0f, System::Drawing::Color::FromArgb(128, 0, 128));
    
    pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
}
```

Le style et le formatage du titre changeront pour toutes les diapositives basées sur le maître de diapositive :

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Voir aussi" %}} 

* [Définir le Texte de Message dans l'Espace Réservé](https://docs.aspose.com/slides/cpp/manage-placeholder/)
* [Formatage de Texte](https://docs.aspose.com/slides/cpp/text-formatting/)

{{% /alert %}}

## **Changer l'Arrière-plan du Maître de Diapositive**

Lorsque vous changez la couleur d'arrière-plan d'un maître de diapositive, toutes les diapositives normales de la présentation obtiendront la nouvelle couleur. Ce code C++ démontre l'opération :

```c++
auto pres = System::MakeObject<Presentation>();

auto master = pres->get_Masters()->idx_get(0);
auto background = master->get_Background();
background->set_Type(Aspose::Slides::BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
background->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
    
pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="primary" title="Voir aussi" %}} 

- [Arrière-plan de la Présentation](https://docs.aspose.com/slides/cpp/presentation-background/)

- [Thème de la Présentation](https://docs.aspose.com/slides/cpp/presentation-theme/)

  {{% /alert %}}

## **Cloner un Maître de Diapositive vers une Autre Présentation**

Pour cloner un Maître de Diapositive vers une autre présentation, appelez la méthode [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) de la présentation de destination avec un Maître de Diapositive passé en paramètre. Ce code C++ vous montre comment cloner un Maître de Diapositive vers une autre présentation :

```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```

## **Ajouter Plusieurs Maîtres de Diapositive à une Présentation**

Aspose.Slides vous permet d'ajouter plusieurs Maîtres de Diapositive et Dispositions de Diapositive à toute présentation donnée. Cela vous permet de configurer des styles, des dispositions et des options de formatage pour les diapositives de présentation de plusieurs manières.

Dans PowerPoint, vous pouvez ajouter de nouveaux Maîtres de Diapositive et Dispositions (à partir du menu "Maître de Diapositive") de cette manière :

![todo:image_alt_text](slide-master_9.jpg)

En utilisant Aspose.Slides, vous pouvez ajouter un nouveau Maître de Diapositive en appelant la méthode [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) :

```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```

## **Comparer les Maîtres de Diapositive**

Un Maître de Diapositive implémente l'interface [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) contenant la méthode [**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f), qui peut être utilisée pour comparer les diapositives. Elle retourne `true` pour les Maîtres de Diapositive identiques en structure et en contenu statique.

Deux Maîtres de Diapositive sont égaux si leurs formes, styles, textes, animations et autres réglages, etc. sont égaux. La comparaison ne prend pas en compte les valeurs d'identifiant unique (par exemple, SlideId) et le contenu dynamique (par exemple, la valeur de date actuelle dans un Espace Réservé Date).

## **Définir le Maître de Diapositive comme Vue par Défaut de la Présentation**

Aspose.Slides vous permet de définir un Maître de Diapositive comme la vue par défaut d'une présentation. La vue par défaut est ce que vous voyez en premier lorsque vous ouvrez une présentation.

Ce code vous montre comment définir un Maître de Diapositive comme vue par défaut d'une présentation en C++ :

```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```

## **Supprimer les Maîtres de Diapositive Non Utilisés**

Aspose.Slides fournit la méthode [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la classe [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) pour vous permettre de supprimer les diapositives maîtres indésirables et inutilisées. Ce code C++ vous montre comment supprimer un maître de diapositive d'une présentation PowerPoint :

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```