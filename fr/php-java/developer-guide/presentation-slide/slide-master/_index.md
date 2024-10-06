---
title: Maître des diapositives
type: docs
weight: 70
url: /php-java/slide-master/
keywords: "Ajouter Maître des diapositives, diapositive maître PPT, maître des diapositives PowerPoint, image au Maître des diapositives, espace réservé, plusieurs maîtres des diapositives, comparer maîtres des diapositives, Java, Aspose.Slides pour PHP via Java"
description: "Ajouter ou modifier le maître des diapositives dans une présentation PowerPoint"
---

## **Qu'est-ce qu'un Maître des Diapositives dans PowerPoint**

Un **Maître des Diapositives** est un modèle de diapositive qui définit la mise en page, les styles, le thème, les polices, l'arrière-plan et d'autres propriétés des diapositives dans une présentation. Si vous voulez créer une présentation (ou une série de présentations) avec le même style et modèle pour votre entreprise, vous pouvez utiliser un maître des diapositives.

Un Maître des Diapositives est utile car il vous permet de définir et de modifier l’apparence de toutes les diapositives de la présentation en une seule fois. Aspose.Slides prend en charge le mécanisme de Maître des Diapositives de PowerPoint.

VBA vous permet également de manipuler un Maître des Diapositives et d'exécuter les mêmes opérations prises en charge dans PowerPoint : changer les arrière-plans, ajouter des formes, personnaliser la mise en page, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d'utiliser les Maîtres des Diapositives et d'effectuer des tâches de base avec eux.

Voici les opérations de base du Maître des Diapositives :

- Créer ou modifier un Maître des Diapositives.
- Appliquer un Maître des Diapositives aux diapositives de la présentation.
- Changer l'arrière-plan du Maître des Diapositives.
- Ajouter une image, un espace réservé, un Smart Art, etc. au Maître des Diapositives.

Voici des opérations plus avancées impliquant le Maître des Diapositives :

- Comparer les Maîtres des Diapositives.
- Fusionner les Maîtres des Diapositives.
- Appliquer plusieurs Maîtres des Diapositives.
- Copier une diapositive avec un Maître des Diapositives vers une autre présentation.
- Découvrir les Maîtres des Diapositives en double dans les présentations.
- Définir le Maître des Diapositives comme la vue par défaut de la présentation.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter le [**Visionneur PowerPoint en ligne**](https://products.aspose.app/slides/viewer) d'Aspose car il s'agit d'une mise en œuvre en direct de certains des processus clés décrits ici.

{{% /alert %}} 

## **Comment le Maître des Diapositives est appliqué**

Avant de travailler avec un maître des diapositives, vous voudrez peut-être comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives.

* Chaque présentation a au moins un Maître des Diapositives par défaut.
* Une présentation peut contenir plusieurs Maîtres des Diapositives. Vous pouvez ajouter plusieurs Maîtres des Diapositives et les utiliser pour styliser différentes parties d'une présentation de différentes manières.

Dans **Aspose.Slides**, un Maître des Diapositives est représenté par [**IMasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslide/) type.

L'objet [Présentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) d'Aspose.Slides contient la liste [**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--) de type [**IMasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/), qui contient une liste de toutes les diapositives maîtres définies dans une présentation.

En plus des opérations CRUD, l’interface [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/) contient ces méthodes utiles : [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) et [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) méthodes. Ces méthodes sont héritées de la fonction de clonage de diapositive de base. Mais en ce qui concerne les Maîtres des Diapositives, ces méthodes vous permettent de mettre en œuvre des configurations compliquées.

Lorsqu'une nouvelle diapositive est ajoutée à une présentation, un Maître des Diapositives lui est automatiquement appliqué. Le Maître des Diapositives de la diapositive précédente est sélectionné par défaut.

**Remarque** : Les diapositives de présentation sont stockées dans la liste [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides--) et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation contient un Maître des Diapositives unique, ce maître des diapositives est sélectionné pour toutes les nouvelles diapositives. C'est la raison pour laquelle vous n'avez pas à définir le Maître des Diapositives pour chaque nouvelle diapositive que vous créez.

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle présentation, vous pouvez simplement appuyer sur la ligne du bas sous la dernière diapositive, puis une nouvelle diapositive (avec le Maître des Diapositives de la dernière présentation) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez effectuer la tâche équivalente avec la méthode [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) sous la classe [Présentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).

## **Maître des Diapositives dans la hiérarchie des diapositives**

L'utilisation de Dispositions de Diapositives avec le Maître des Diapositives permet une flexibilité maximale. Une Disposition de Diapositive vous permet de définir tous les mêmes styles qu'un Maître des Diapositives (arrière-plan, polices, formes, etc.). Cependant, lorsque plusieurs Dispositions de Diapositives sont combinées sur un Maître des Diapositives, un nouveau style est créé. Lorsque vous appliquez une Disposition de Diapositive à une seule diapositive, vous pouvez changer son style par rapport à celui appliqué par le Maître des Diapositives.

Le Maître des Diapositives prime sur tous les éléments de configuration : Maître des Diapositives -> Disposition de Diapositive -> Diapositive :

![todo:image_alt_text](slide-master_2)

Chaque [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) objet a une propriété [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getLayoutSlides--) avec une liste de Dispositions de Diapositives. Un type [Diapositive](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) a une propriété [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getLayoutSlide--) avec un lien sur une Disposition de Diapositive appliquée à la diapositive. L'interaction entre une diapositive et le Maître des Diapositives se produit par le biais d'une Disposition de Diapositive.

{{% alert color="info" title="Remarque" %}}

* Dans Aspose.Slides, toutes les configurations de diapositives (Maître des Diapositives, Disposition de Diapositive et la diapositive elle-même) sont en réalité des objets de diapositive implémentant l'interface [**IBaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide).
* Par conséquent, le Maître des Diapositives et la Disposition de Diapositive peuvent implémenter les mêmes propriétés et vous devez savoir comment leurs valeurs seront appliquées à un objet [Diapositive](https://reference.aspose.com/slides/php-java/aspose.slides/Slide). Le Maître des Diapositives est appliqué en premier à une diapositive, puis la Disposition de Diapositive est appliquée. Par exemple, si le Maître des Diapositives et la Disposition de Diapositive ont tous deux une valeur d'arrière-plan, la diapositive aura finalement l'arrière-plan de la Disposition de Diapositive.

{{% /alert %}}

## **Ce que comprend un Maître des Diapositives**

Pour comprendre comment un Maître des Diapositives peut être modifié, vous devez connaître ses constituants. Voici les propriétés de base de [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getBackground--) récupérer/définir l'arrière-plan de la diapositive.
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getBodyStyle--) - récupérer/définir les styles de texte du corps de la diapositive.
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getShapes--) récupérer/définir toutes les formes du Maître des Diapositives (espaces réservés, cadres d'images, etc.).
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getControls--) récupérer/définir les contrôles ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterThemeable#getThemeManager--) - récupérer le gestionnaire de thème.
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getHeaderFooterManager--) - récupérer le gestionnaire d'en-tête et de pied de page.

Méthodes du Maître des Diapositives :

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getDependingSlides--) - récupérer toutes les Diapositives dépendantes du Maître des Diapositives.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - vous permet de créer un nouveau Maître des Diapositives basé sur le Maître des Diapositives actuel et un nouveau thème. Le nouveau Maître des Diapositives sera alors appliqué à toutes les diapositives dépendantes.

## **Obtenir le Maître des Diapositives**

Dans PowerPoint, le Maître des Diapositives peut être accédé depuis le menu Affichage -> Maître des Diapositives :

![todo:image_alt_text](slide-master_3.jpg)

Avec Aspose.Slides, vous pouvez accéder à un Maître des Diapositives de cette manière : 

```php
  $pres = new Presentation();
  try {
    # Donne accès à la diapositive maître de la Présentation
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

L'interface [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) représente un Maître des Diapositives. La propriété [Masters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getMasters--) (liée au type [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection)) contient une liste de tous les Maîtres des Diapositives définis dans la présentation.

## **Ajouter une image au Maître des Diapositives**

Lorsque vous ajoutez une image à un Maître des Diapositives, cette image apparaîtra sur toutes les diapositives dépendantes de ce maître des diapositives.

Par exemple, vous pouvez placer le logo de votre entreprise et quelques images sur le Maître des Diapositives, puis revenir au mode d'édition des diapositives. Vous devriez voir l'image sur chaque diapositive.

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un maître des diapositives avec Aspose.Slides :

```php
  $pres = new Presentation();
  try {
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pres->getMasters()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Voir aussi" %}} 

Pour plus d'informations sur l'ajout d'images à une diapositive, consultez l'article [Cadre d'image](/slides/php-java/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Ajouter un espace réservé au Maître des Diapositives**

Ces champs de texte sont des espaces réservés standard sur un Maître des Diapositives :

* Cliquez pour modifier le style de titre du Maître

* Modifier les styles de texte du Maître

* Deuxième niveau

* Troisième niveau 

Ils apparaissent également sur les diapositives basées sur le Maître des Diapositives. Vous pouvez modifier ces espaces réservés sur un Maître des Diapositives et les modifications sont automatiquement appliquées aux diapositives.

Dans PowerPoint, vous pouvez ajouter un espace réservé par le chemin Maître des Diapositives -> Insérer un espace réservé :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus compliqué pour les espaces réservés avec Aspose.Slides. Considérons une diapositive avec des espaces réservés modélisés à partir du Maître des Diapositives :

![todo:image_alt_text](slide-master_6.png)

Nous voulons changer le formatage du Titre et du Sous-titre sur le Maître des Diapositives de cette manière :

![todo:image_alt_text](slide-master_7.png)

Tout d'abord, nous récupérons le contenu de l'espace réservé du titre à partir de l'objet Maître des Diapositives, puis nous utilisons le champ `PlaceHolder.FillFormat` :

```php

```

Le style et le formatage du titre changeront pour toutes les diapositives basées sur le maître des diapositives :

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Voir aussi" %}} 

* [Définir le texte d'invite dans l'espace réservé](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [Formatage du texte](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}

## **Changer l'arrière-plan sur le Maître des Diapositives**

Lorsque vous changez la couleur d'arrière-plan d'un maître de diapositive, toutes les diapositives normales de la présentation recevront la nouvelle couleur. Ce code PHP démontre l'opération :

```php
  $pres = new Presentation();
  try {
    $master = $pres->getMasters()->get_Item(0);
    $master->getBackground()->setType(BackgroundType::OwnBackground);
    $master->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $master->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Voir aussi" %}} 

- [Arrière-plan de présentation](https://docs.aspose.com/slides/php-java/presentation-background/)

- [Thème de présentation](https://docs.aspose.com/slides/php-java/presentation-theme/)

  {{% /alert %}}

## **Cloner le Maître des Diapositives vers une autre présentation**

Pour cloner un Maître des Diapositives vers une autre présentation, appelez la méthode [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) de la présentation de destination avec un Maître des Diapositives passé en paramètre. Ce code PHP vous montre comment cloner un Maître des Diapositives vers une autre présentation :

```php
  $presSource = new Presentation();
  $presTarget = new Presentation();
  try {
    $master = $presTarget->getMasters()->addClone($presSource->getMasters()->get_Item(0));
  } finally {
    if (!java_is_null($presSource)) {
      $presSource->dispose();
    }
  }
```

## **Ajouter plusieurs Maîtres des Diapositives à une présentation**

Aspose.Slides vous permet d'ajouter plusieurs Maîtres des Diapositives et Dispositions de Diapositives à une présentation donnée. Cela vous permet de configurer styles, mises en page et options de formatage pour les diapositives de présentation de plusieurs manières.

Dans PowerPoint, vous pouvez ajouter de nouveaux Maîtres des Diapositives et Dispositions (depuis le menu "Maître des Diapositives") de cette manière :

![todo:image_alt_text](slide-master_9.jpg)

Avec Aspose.Slides, vous pouvez ajouter un nouveau Maître des Diapositives en appelant la méthode [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) :

```php
  # Ajoute un nouveau maître de diapositive
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```

## **Comparer les Maîtres des Diapositives**

Un Maître des Diapositives implémente l'interface [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) contenant la méthode [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), qui peut ensuite être utilisée pour comparer les diapositives. Elle retourne `true` pour les Maîtres des Diapositives identiques en structure et contenu statique.

Deux Maîtres des Diapositives sont égaux si leurs formes, styles, textes, animations et autres paramètres, etc., sont égaux. La comparaison ne prend pas en compte les valeurs d'identificateur unique (par exemple, SlideId) et le contenu dynamique (par exemple, la valeur de date actuelle dans l'Espace réservé de Date).

## **Définir le Maître des Diapositives comme vue par défaut de la présentation**

Aspose.Slides vous permet de définir un Maître des Diapositives comme vue par défaut d'une présentation. La vue par défaut est ce que vous voyez en premier lorsque vous ouvrez une présentation.

Ce code vous montre comment définir un Maître des Diapositives comme la vue par défaut d'une présentation :

```php
  # Instancie une classe Présentation qui représente le fichier de présentation
  $presentation = new Presentation();
  try {
    # Définit la vue par défaut comme SlideMasterView
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # Sauvegarde la présentation
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Supprimer les Maîtres des Diapositives inutilisés**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) pour vous permettre de supprimer les maitre slides non désirés et inutilisés. Ce code PHP vous montre comment supprimer un maître des diapositives d'une présentation PowerPoint :

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```