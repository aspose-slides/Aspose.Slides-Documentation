---
title: Gérer les masques de diapositives de présentation en C++
linktitle: Masque de diapositive
type: docs
weight: 80
url: /fr/cpp/slide-master/
keywords:
- masque de diapositive
- diapositive maître
- diapositive maître PPT
- plusieurs diapositives maîtres
- comparer les diapositives maîtres
- arrière-plan
- espace réservé
- cloner la diapositive maître
- copier la diapositive maître
- dupliquer la diapositive maître
- diapositive maître inutilisée
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Gérez les masques de diapositives dans Aspose.Slides pour C++ : créez, modifiez et appliquez des dispositions, des thèmes et des espaces réservés aux fichiers PPT, PPTX et ODP avec des exemples C++ concis."
---

## **Qu’est‑ce qu’un Masque des diapositives dans PowerPoint**

Un **Masque des diapositives** est un modèle de diapositive qui définit la disposition, les styles, le thème, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et le même modèle pour votre entreprise, vous pouvez utiliser un masque des diapositives.  

Un masque des diapositives est utile car il permet de définir et de modifier l’aspect de toutes les diapositives de la présentation en une seule fois. Aspose.Slides prend en charge le mécanisme de masque des diapositives de PowerPoint.  

VBA permet également de manipuler un masque des diapositives et d’exécuter les mêmes opérations prises en charge dans PowerPoint : modifier les arrière‑plans, ajouter des formes, personnaliser la disposition, etc. Aspose.Slides offre des mécanismes flexibles pour vous permettre d’utiliser les masques des diapositives et d’effectuer des tâches de base avec eux.  

Voici les opérations de base sur les masques des diapositives :

- Créer ou modifier un masque des diapositives.  
- Appliquer le masque des diapositives aux diapositives de la présentation.  
- Modifier l’arrière‑plan du masque des diapositives.  
- Ajouter une image, un espace réservé, Smart Art, etc. au masque des diapositives.  

Voici des opérations plus avancées impliquant les masques des diapositives :  

- Comparer des masques des diapositives.  
- Fusionner des masques des diapositives.  
- Appliquer plusieurs masques des diapositives.  
- Copier une diapositive avec son masque des diapositives vers une autre présentation.  
- Détecter les masques des diapositives en double dans des présentations.  
- Définir le masque des diapositives comme affichage par défaut de la présentation.  

{{% alert color="primary" %}}  

Vous pouvez consulter la [**Visionneuse PowerPoint en ligne**](https://products.aspose.app/slides/viewer) d’Aspose, car il s’agit d’une implémentation en direct de certains des processus décrits ici.  

{{% /alert %}}  

## **Comment le masque des diapositives est‑il appliqué**

Avant de travailler avec un masque des diapositives, il est utile de comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives.  

* Chaque présentation possède au moins un masque des diapositives par défaut.  
* Une présentation peut contenir plusieurs masques des diapositives. Vous pouvez ajouter plusieurs masques des diapositives et les utiliser pour styliser différentes parties d’une présentation de manières différentes.  

Dans **Aspose.Slides**, un masque des diapositives est représenté par le type [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide).  

L’objet [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) d’Aspose.Slides contient la liste [**get_Masters()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) de type [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection), qui contient toutes les diapositives maîtres définies dans une présentation.  

En plus des opérations CRUD, l’interface [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) propose les méthodes utiles : [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) et [**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311). Ces méthodes proviennent de la fonction de clonage de base des diapositives, mais lorsqu’on travaille avec des masques des diapositives, elles permettent de mettre en place des configurations complexes.  

Lorsqu’une nouvelle diapositive est ajoutée à une présentation, un masque des diapositives lui est appliqué automatiquement. Le masque des diapositives de la diapositive précédente est sélectionné par défaut.  

**Note** : les diapositives de la présentation sont stockées dans la liste [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation ne contient qu’un seul masque des diapositives, ce masque est sélectionné pour toutes les nouvelles diapositives. C’est la raison pour laquelle vous n’avez pas besoin de définir le masque des diapositives pour chaque nouvelle diapositive que vous créez.  

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle diapositive, il suffit de cliquer sur la ligne située sous la dernière diapositive ; une nouvelle diapositive (avec le même masque des diapositives que la présentation précédente) sera créée :  

![todo:image_alt_text](slide-master_1.jpg)  

Dans Aspose.Slides, vous pouvez effectuer la tâche équivalente avec la méthode [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  

## **Masque des diapositives dans la hiérarchie des diapositives**

Utiliser des dispositions de diapositives avec le masque des diapositives offre une flexibilité maximale. Une disposition de diapositive vous permet de définir les mêmes styles que le masque des diapositives (arrière‑plan, polices, formes, etc.). Cependant, lorsque plusieurs dispositions de diapositives sont combinées sur un même masque des diapositives, un nouveau style est créé. Lorsque vous appliquez une disposition de diapositive à une diapositive unique, vous pouvez modifier son style par rapport à celui appliqué par le masque des diapositives.  

Le masque des diapositives prime sur tous les éléments de configuration : Masque des diapositives → Disposition de diapositive → Diapositive :  

![todo:image_alt_text](slide-master_2)  

Chaque objet [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) possède la propriété [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) contenant une liste de dispositions de diapositives. Un objet de type [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) possède la propriété [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8) pointant vers la disposition de diapositive appliquée à la diapositive. L’interaction entre une diapositive et le masque des diapositives s’effectue via la disposition de diapositive.  

{{% alert color="info" title="Remarque" %}}  

* Dans Aspose.Slides, toutes les configurations de diapositive (masque des diapositives, disposition de diapositive et la diapositive elle‑même) sont en fait des objets de diapositive implémentant l’interface [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide).  
* Ainsi, le masque des diapositives et la disposition de diapositive peuvent implémenter les mêmes propriétés et il faut savoir comment leurs valeurs seront appliquées à un objet [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide). Le masque des diapositives est appliqué en premier, puis la disposition de diapositive. Par exemple, si le masque des diapositives et la disposition de diapositive possèdent tous deux une valeur d’arrière‑plan, la diapositive affichera l’arrière‑plan de la disposition de diapositive.  

{{% /alert %}}  

## **Ce que comporte un masque des diapositives**

Pour comprendre comment un masque des diapositives peut être modifié, il faut connaître ses constituants. Ce sont les propriétés essentielles de [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) :  

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) – obtenir/ définir l’arrière‑plan de la diapositive.  
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) – obtenir/ définir les styles de texte du corps de la diapositive.  
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) – obtenir/ définir toutes les formes du masque des diapositives (espaces réservés, cadres d’image, etc.).  
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) – obtenir/ définir les contrôles ActiveX.  
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) – obtenir le gestionnaire de thèmes.  
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) – obtenir le gestionnaire d’en‑tête et de pied de page.  

Méthodes du masque des diapositives :  

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) – récupérer toutes les diapositives dépendant du masque des diapositives.  
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) – créer un nouveau masque des diapositives à partir du masque actuel et d’un nouveau thème, puis l’appliquer à toutes les diapositives dépendantes.  

## **Obtenir un masque des diapositives**

Dans PowerPoint, le masque des diapositives est accessible via le menu Affichage → Masque des diapositives :  

![todo:image_alt_text](slide-master_3.jpg)  

Avec Aspose.Slides, vous pouvez accéder à un masque des diapositives de cette façon :  
```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```
  

L’interface [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) représente un masque des diapositives. La propriété [get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) (associée au type [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)) contient la liste de tous les masques des diapositives définis dans la présentation.  

## **Ajouter une image à un masque des diapositives**

Lorsque vous ajoutez une image à un masque des diapositives, cette image apparaît sur toutes les diapositives dépendant de ce masque.  

Par exemple, vous pouvez placer le logo de votre entreprise et quelques images sur le masque des diapositives, puis repasser en mode édition des diapositives. L’image apparaîtra sur chaque diapositive.  

![todo:image_alt_text](slide-master_4.png)  

Vous pouvez ajouter des images à un masque des diapositives avec Aspose.Slides :  
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```
  

{{% alert color="primary" title="Voir aussi" %}}  

Pour plus d’informations sur l’ajout d’images à une diapositive, consultez l’article [Cadre d’image](/slides/fr/cpp/picture-frame/#create-picture-frame).  
{{% /alert %}}  

## **Ajouter un espace réservé à un masque des diapositives**

Ces champs de texte sont des espaces réservés standards sur un masque des diapositives :  

* Cliquez pour modifier le style du titre du masque  

* Modifier les styles de texte du masque  

* Niveau secondaire  

* Niveau tertiaire  

Ils apparaissent également sur les diapositives basées sur le masque des diapositives. Vous pouvez modifier ces espaces réservés sur le masque et les changements seront appliqués automatiquement aux diapositives.  

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin Masque des diapositives → Insérer un espace réservé :  

![todo:image_alt_text](slide-master_5.png)  

Examinons un exemple plus complexe d’espaces réservés avec Aspose.Slides. Considérons une diapositive dont les espaces réservés proviennent du masque des diapositives :  

![todo:image_alt_text](slide-master_6.png)  

Nous voulons modifier la mise en forme du titre et du sous‑titre du masque des diapositives ainsi :  

![todo:image_alt_text](slide-master_7.png)  

Tout d’abord, nous récupérons le contenu de l’espace réservé du titre depuis l’objet masque des diapositives, puis nous utilisons le champ `PlaceHolder.FillFormat` :  
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
  

Le style et la mise en forme du titre changeront pour toutes les diapositives basées sur le masque :  

![todo:image_alt_text](slide-master_8.png)  

{{% alert color="primary" title="Voir aussi" %}}  

* [Définir le texte d’invite dans un espace réservé](https://docs.aspose.com/slides/cpp/manage-placeholder/)  
* [Mise en forme du texte](https://docs.aspose.com/slides/cpp/text-formatting/)  

{{% /alert %}}  

## **Modifier l’arrière‑plan d’un masque des diapositives**

Lorsque vous modifiez la couleur d’arrière‑plan d’une diapositive maître, toutes les diapositives normales de la présentation recevront la nouvelle couleur. Ce code C++ montre l’opération :  
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

- [Arrière‑plan de la présentation](https://docs.aspose.com/slides/cpp/presentation-background/)  
- [Thème de la présentation](https://docs.aspose.com/slides/cpp/presentation-theme/)  

{{% /alert %}}  

## **Cloner un masque des diapositives vers une autre présentation**

Pour cloner un masque des diapositives vers une autre présentation, appelez la méthode [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) de la présentation de destination en lui transmettant le masque des diapositives. Ce code C++ montre comment cloner un masque des diapositives vers une autre présentation :  
```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```
  

## **Ajouter plusieurs masques des diapositives à une présentation**

Aspose.Slides vous permet d’ajouter plusieurs masques des diapositives et plusieurs dispositions de diapositives à une même présentation. Cela vous permet de configurer les styles, les dispositions et les options de mise en forme des diapositives de nombreuses manières.  

Dans PowerPoint, vous pouvez ajouter de nouveaux masques des diapositives et dispositions (via le « Menu Masque des diapositives ») de cette façon :  

![todo:image_alt_text](slide-master_9.jpg)  

Avec Aspose.Slides, vous pouvez ajouter un nouveau masque des diapositives en appelant la méthode [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) :  
```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```
  

## **Comparer des masques des diapositives**

Une diapositive maître implémente l’interface [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) contenant la méthode [**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f), qui peut être utilisée pour comparer des diapositives. Elle renvoie `true` lorsque les diapositives maîtres sont identiques en structure et en contenu statique.  

Deux diapositives maîtres sont égales si leurs formes, styles, textes, animations et autres paramètres sont identiques. La comparaison ne tient pas compte des valeurs d’identifiant uniques (par exemple : SlideId) ni du contenu dynamique (par exemple : la date actuelle dans un espace réservé de date).  

## **Définir un masque des diapositives comme affichage par défaut de la présentation**

Aspose.Slides vous permet de définir un masque des diapositives comme affichage par défaut d’une présentation. L’affichage par défaut est ce que vous voyez en premier lorsque vous ouvrez une présentation.  

Ce code montre comment définir un masque des diapositives comme affichage par défaut d’une présentation en C++ :  
```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```
  

## **Supprimer les masques des diapositives inutilisés**

Aspose.Slides fournit la méthode [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la classe [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) pour supprimer les masques des diapositives indésirables et inutilisés. Ce code C++ montre comment supprimer un masque des diapositives d’une présentation PowerPoint :  
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```
  

## **FAQ**

**Qu’est‑ce qu’un masque des diapositives dans PowerPoint ?**

Un masque des diapositives est un modèle de diapositive qui définit la disposition, les styles, les thèmes, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Il vous permet de définir et de modifier l’apparence de toutes les diapositives d’une présentation en une seule fois.  

**Comment un masque des diapositives est‑il appliqué dans une présentation ?**

Chaque présentation possède au moins un masque des diapositives par défaut. Lorsqu’une nouvelle diapositive est ajoutée, un masque des diapositives lui est appliqué automatiquement, généralement en héritant du masque de la diapositive précédente. Une présentation peut contenir plusieurs masques des diapositives pour styliser différentes parties de manière unique.  

**Quels éléments peuvent être personnalisés dans un masque des diapositives ?**

Un masque des diapositives comprend plusieurs propriétés essentielles qui peuvent être personnalisées :  

- **Background** : définir l’arrière‑plan de la diapositive.  
- **BodyStyle** : définir les styles de texte du corps de la diapositive.  
- **Shapes** : gérer toutes les formes du masque des diapositives, y compris les espaces réservés et les cadres d’image.  
- **Controls** : gérer les contrôles ActiveX.  
- **ThemeManager** : accéder au gestionnaire de thèmes.  
- **HeaderFooterManager** : gérer les en‑têtes et pieds de page.  

**Comment ajouter une image à un masque des diapositives ?**

Ajouter une image à un masque des diapositives garantit qu’elle apparaît sur toutes les diapositives dépendant de ce masque. Par exemple, placer le logo de l’entreprise sur le masque des diapositives l’affichera sur chaque diapositive de la présentation.  

**Comment les masques des diapositives sont‑ils liés aux dispositions de diapositives ?**

Les dispositions de diapositives fonctionnent en combinaison avec les masques des diapositives pour offrir une flexibilité dans la conception des diapositives. Le masque des diapositives définit les styles et thèmes globaux, tandis que les dispositions de diapositives permettent des variantes dans l’arrangement du contenu. La hiérarchie est la suivante :  

- **Masque des diapositives** → définit les styles globaux.  
- **Disposition de diapositive** → propose différents agencements de contenu.  
- **Diapositive** → hérite du design de sa disposition de diapositive.  

**Puis‑je avoir plusieurs masques des diapositives dans une même présentation ?**

Oui, une présentation peut contenir plusieurs masques des diapositives. Cela vous permet de styliser différentes sections d’une présentation de manières variées, offrant ainsi plus de souplesse au niveau du design.  

**Comment accéder et modifier un masque des diapositives avec Aspose.Slides ?**

Dans Aspose.Slides, un masque des diapositives est représenté par l’interface [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/). Vous pouvez accéder à un masque des diapositives à l’aide de la méthode [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) de l’objet [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).