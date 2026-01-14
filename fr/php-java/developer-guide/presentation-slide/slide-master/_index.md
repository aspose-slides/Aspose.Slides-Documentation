---
title: Gérer les masques de diapositives de présentation en PHP
linktitle: Masque de diapositive
type: docs
weight: 70
url: /fr/php-java/slide-master/
keywords:
- masque de diapositive
- diapositive maître
- diapositive maître PPT
- plusieurs masques maîtres
- comparer les masques maîtres
- arrière-plan
- espace réservé
- cloner le masque maître
- copier le masque maître
- dupliquer le masque maître
- masque maître inutilisé
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérez les masques de diapositives dans Aspose.Slides pour PHP via Java : créez, modifiez et appliquez des dispositions, des thèmes et des espaces réservés aux formats PPT, PPTX et ODP avec des exemples concis."
---

## **Qu’est‑ce qu’un masque des diapositives dans PowerPoint**

Un **masque des diapositives** est un modèle de diapositive qui définit la disposition, les styles, le thème, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et le même modèle pour votre entreprise, vous pouvez utiliser un masque des diapositives.  

Un masque des diapositives est utile car il vous permet de définir et de modifier l’apparence de toutes les diapositives d’une présentation en une seule opération. Aspose.Slides prend en charge le mécanisme du masque des diapositives provenant de PowerPoint.  

VBA vous permet également de manipuler un masque des diapositives et d’exécuter les mêmes opérations prises en charge dans PowerPoint : modifier les arrière‑plans, ajouter des formes, personnaliser la disposition, etc. Aspose.Slides fournit des mécanismes flexibles vous permettant d’utiliser les masques des diapositives et d’accomplir des tâches de base avec eux.  

Voici les opérations de base du masque des diapositives :

- Créer un masque des diapositives.  
- Appliquer le masque des diapositives aux diapositives de la présentation.  
- Modifier l’arrière‑plan du masque des diapositives.  
- Ajouter une image, un espace réservé, SmartArt, etc. au masque des diapositives.  

Voici des opérations plus avancées impliquant le masque des diapositives :

- Comparer les masques des diapositives.  
- Fusionner les masques des diapositives.  
- Appliquer plusieurs masques des diapositives.  
- Copier une diapositive avec le masque des diapositives vers une autre présentation.  
- Détecter les masques des diapositives en double dans les présentations.  
- Définir le masque des diapositives comme affichage par défaut de la présentation.  

{{% alert color="primary" %}} 
Vous voudrez peut‑être consulter Aspose [**Visionneuse PowerPoint en ligne**](https://products.aspose.app/slides/viewer) car il s’agit d’une implémentation en direct de certains des processus principaux décrits ici.
{{% /alert %}} 

## **Comment le masque des diapositives est‑il appliqué**

Avant de travailler avec un masque des diapositives, vous voudrez peut‑être comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives.  

- Chaque présentation possède au moins un masque des diapositives par défaut.  
- Une présentation peut contenir plusieurs masques des diapositives. Vous pouvez ajouter plusieurs masques des diapositives et les utiliser pour styliser différentes parties d’une présentation de manières différentes.  

Dans **Aspose.Slides**, un masque des diapositives est représenté par le type [**MasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).  

L’objet [Presentation ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) d’Aspose.Slides contient la liste [**getMasters** ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters) de type [**MasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), qui renvoie la liste de toutes les masques de diapositives définies dans une présentation.  

En plus des opérations CRUD, la classe [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) contient ces méthodes utiles : [**addClone(LayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/#addClone) et [**insertClone(int index, MasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/#insertClone). Ces méthodes proviennent de la fonction de clonage de diapositives de base. Mais lorsqu’on travaille avec des masques des diapositives, ces méthodes permettent de mettre en place des configurations complexes.  

Lorsqu’une nouvelle diapositive est ajoutée à une présentation, un masque des diapositives lui est appliqué automatiquement. Le masque des diapositives de la diapositive précédente est sélectionné par défaut.  

**Note** : Les diapositives de la présentation sont stockées dans la liste [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) , et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation ne contient qu’un seul masque des diapositives, ce masque est sélectionné pour toutes les nouvelles diapositives. C’est la raison pour laquelle vous n’avez pas besoin de définir le masque des diapositives pour chaque nouvelle diapositive que vous créez.  

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle diapositive, vous pouvez simplement cliquer sur la ligne inférieure sous la dernière diapositive et une nouvelle diapositive (avec le masque des diapositives de la dernière présentation) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez réaliser la tâche équivalente avec la méthode [addClone(Slide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) de la classe [Presentation ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  

## **Masque des diapositives dans la hiérarchie des diapositives**

Utiliser les dispositions de diapositives avec le masque des diapositives permet une flexibilité maximale. Une disposition de diapositive vous permet de définir les mêmes styles que le masque des diapositives (arrière‑plan, polices, formes, etc.). Cependant, lorsque plusieurs dispositions sont combinées sur un même masque des diapositives, un nouveau style est créé. Lorsque vous appliquez une disposition à une seule diapositive, vous pouvez modifier son style par rapport à celui appliqué par le masque des diapositives.  

Le masque des diapositives prime sur tous les éléments de configuration : Masque des diapositives → Disposition de diapositive → Diapositive :

![todo:image_alt_text](slide-master_2)

Chaque objet [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide) possède la propriété [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getLayoutSlides) contenant une liste de dispositions de diapositives. Un type [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) possède la propriété [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/Slide/#getLayoutSlide) qui pointe vers la disposition de diapositive appliquée à la diapositive. L’interaction entre une diapositive et le masque des diapositives se fait via la disposition de diapositive.  

{{% alert color="info" title="Note" %}} 
* Dans Aspose.Slides, toutes les configurations de diapositives (masque des diapositives, disposition de diapositive et la diapositive elle‑même) sont en réalité des objets diapositive qui héritent de la classe [**BaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide).  
* Par conséquent, le masque des diapositives et la disposition de diapositive peuvent implémenter les mêmes propriétés et vous devez savoir comment leurs valeurs seront appliquées à un objet [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide). Le masque des diapositives est appliqué en premier à une diapositive, puis la disposition de diapositive est appliquée. Par exemple, si le masque des diapositives et la disposition de diapositive possèdent tous deux une valeur d’arrière‑plan, la diapositive affichera l’arrière‑plan provenant de la disposition de diapositive.  
{{% /alert %}}  

## **Ce que contient un masque des diapositives**

Pour comprendre comment un masque des diapositives peut être modifié, vous devez connaître ses constituants. Voici les propriétés principales de [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).  

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getBackground) obtenir/definir l’arrière‑plan de la diapositive.  
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getBodyStyle) – obtenir/definir les styles de texte du corps de la diapositive.  
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getShapes) obtenir/definir toutes les formes du masque des diapositives (espaces réservés, cadres d’image, etc.).  
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getControls) obtenir/definir les contrôles ActiveX.  
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/#getThemeManager) – obtenir le gestionnaire de thème.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getHeaderFooterManager) – obtenir le gestionnaire d’en‑tête et de pied de page.  

Méthodes du masque des diapositives :  

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getDependingSlides) – obtenir toutes les diapositives dépendant du masque des diapositives.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#applyExternalThemeToDependingSlides) – vous permet de créer un nouveau masque des diapositives basé sur le masque actuel et un nouveau thème. Le nouveau masque sera alors appliqué à toutes les diapositives dépendantes.  

## **Obtenir un masque des diapositives**

Dans PowerPoint, le masque des diapositives est accessible via le menu **Affichage → Masque des diapositives** :  

![todo:image_alt_text](slide-master_3.jpg)  

En utilisant Aspose.Slides, vous pouvez accéder à un masque des diapositives de cette manière :  
```php
  $pres = new Presentation();
  try {
    # Donne accès au masque maître de la présentation
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```
  

La classe [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide) représente un masque des diapositives. La méthode [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getMasters) (associée au type [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection)) renvoie une liste de tous les masques des diapositives définis dans la présentation.  

## **Ajouter une image à un masque des diapositives**

Lorsque vous ajoutez une image à un masque des diapositives, cette image apparaîtra sur toutes les diapositives dépendant de ce masque.  

Par exemple, vous pouvez placer le logo de votre société et quelques images sur le masque des diapositives, puis revenir en mode édition des diapositives. Vous devriez voir l’image sur chaque diapositive.  

![todo:image_alt_text](slide-master_4.png)  

Vous pouvez ajouter des images à un masque des diapositives avec Aspose.Slides :  
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
Pour plus d’informations sur l’ajout d’images à une diapositive, consultez l’article [Cadre d’image](/slides/fr/php-java/picture-frame/#create-picture-frame).  
{{% /alert %}}  

## **Ajouter un espace réservé à un masque des diapositives**

Ces champs de texte sont des espaces réservés standard sur un masque des diapositives :  

* Cliquez pour modifier le style du titre du masque  
* Modifier les styles de texte du masque  
* Deuxième niveau  
* Troisième niveau  

Ils apparaissent également sur les diapositives basées sur le masque des diapositives. Vous pouvez modifier ces espaces réservés sur le masque des diapositives et les modifications seront automatiquement appliquées aux diapositives.  

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin **Masque des diapositives → Insérer un espace réservé** :  

![todo:image_alt_text](slide-master_5.png)  

Examinons un exemple plus complexe d’espaces réservés avec Aspose.Slides. Considérez une diapositive contenant des espaces réservés provenant du masque des diapositives :  

![todo:image_alt_text](slide-master_6.png)  

Nous voulons modifier le format du titre et du sous‑titre sur le masque des diapositives de cette façon :  

![todo:image_alt_text](slide-master_7.png)  

Tout d’abord, nous récupérons le contenu du titre de l’espace réservé à partir de l’objet masque des diapositives puis nous utilisons le champ `PlaceHolder.FillFormat` :  
```php

```
  

Le style et le format du titre changeront pour toutes les diapositives basées sur le masque des diapositives :  

![todo:image_alt_text](slide-master_8.png)  

{{% alert color="primary" title="Voir aussi" %}} 
* [Définir le texte d’invite dans l’espace réservé](https://docs.aspose.com/slides/php-java/manage-placeholder/)  
* [Mise en forme du texte](https://docs.aspose.com/slides/php-java/text-formatting/)  
{{% /alert %}}  

## **Modifier l’arrière‑plan d’un masque des diapositives**

Lorsque vous modifiez la couleur d’arrière‑plan d’un masque de diapositive, toutes les diapositives normales de la présentation recevront la nouvelle couleur. Ce code PHP montre l’opération :  
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
- [Arrière‑plan de la présentation](https://docs.aspose.com/slides/php-java/presentation-background/)  
- [Thème de la présentation](https://docs.aspose.com/slides/php-java/presentation-theme/)  
{{% /alert %}}  

## **Cloner un masque des diapositives vers une autre présentation**

Pour cloner un masque des diapositives vers une autre présentation, appelez la méthode [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) de la présentation de destination en lui passant le masque des diapositives à cloner. Ce code PHP montre comment cloner un masque des diapositives vers une autre présentation :  
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
  

## **Ajouter plusieurs masques des diapositives à une présentation**

Aspose.Slides vous permet d’ajouter plusieurs masques des diapositives et plusieurs dispositions de diapositives à une présentation donnée. Cela vous permet de configurer les styles, les dispositions et les options de formatage des diapositives de la présentation de nombreuses façons.  

Dans PowerPoint, vous pouvez ajouter de nouveaux masques des diapositives et dispositions (à partir du **menu Masque des diapositives**) de cette façon :  

![todo:image_alt_text](slide-master_9.jpg)  

En utilisant Aspose.Slides, vous pouvez ajouter un nouveau masque des diapositives en appelant la méthode [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) :  
```php
  # Ajoute une nouvelle diapositive maître
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```
  

## **Comparer les masques des diapositives**

Un Master Slide implémente la classe [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide) contenant la méthode [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#equals), qui peut ensuite être utilisée pour comparer des diapositives. Elle renvoie `true` pour les masques identiques en structure et en contenu statique.  

Deux masques sont égaux si leurs formes, styles, textes, animations et autres paramètres, etc., sont identiques. La comparaison ne prend pas en compte les valeurs d’identifiants uniques (p. ex. SlideId) ni le contenu dynamique (p. ex. valeur de date actuelle dans l’espace réservé Date).  

## **Définir un masque des diapositives comme affichage par défaut de la présentation**

Aspose.Slides vous permet de définir un masque des diapositives comme affichage par défaut d’une présentation. L’affichage par défaut est ce que vous voyez en premier lorsque vous ouvrez une présentation.  

Ce code montre comment définir un masque des diapositives comme affichage par défaut d’une présentation :  
```php
  # Instancie une classe Presentation qui représente le fichier de présentation
  $presentation = new Presentation();
  try {
    # Définit la vue par défaut comme SlideMasterView
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # Enregistre la présentation
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```
  

## **Supprimer les masques de diapositives inutilisés**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides) (de la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) pour vous permettre de supprimer les masques de diapositives indésirables et inutilisés. Ce code PHP montre comment supprimer un masque de diapositive d’une présentation PowerPoint :  
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
  

## **FAQ**

**Qu’est‑ce qu’un masque des diapositives dans PowerPoint ?**  

Un masque des diapositives est un modèle de diapositive qui définit la disposition, les styles, les thèmes, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Il vous permet de définir et de modifier l’apparence de toutes les diapositives d’une présentation en une seule opération.  

**Comment un masque des diapositives est‑il appliqué dans une présentation ?**  

Chaque présentation possède au moins un masque des diapositives par défaut. Lorsqu’une nouvelle diapositive est ajoutée, un masque des diapositives lui est appliqué automatiquement, généralement celui de la diapositive précédente. Une présentation peut contenir plusieurs masques des diapositives pour styliser différentes parties de manière unique.  

**Quels éléments peuvent être personnalisés dans un masque des diapositives ?**  

Un masque des diapositives comprend plusieurs propriétés principales qui peuvent être personnalisées :  

- **Background** : Définir l’arrière‑plan de la diapositive.  
- **BodyStyle** : Définir les styles de texte du corps de la diapositive.  
- **Shapes** : Gérer toutes les formes du masque (espaces réservés, cadres d’image, etc.).  
- **Controls** : Gérer les contrôles ActiveX.  
- **ThemeManager** : Accéder au gestionnaire de thème.  
- **HeaderFooterManager** : Gérer les en‑têtes et pieds de page.  

**Comment puis‑je ajouter une image à un masque des diapositives ?**  

L’ajout d’une image à un masque des diapositives garantit qu’elle apparaît sur toutes les diapositives dépendant de ce masque. Par exemple, placer le logo de votre entreprise sur le masque affichera le logo sur chaque diapositive de la présentation.  

**Comment les masques des diapositives se rapportent‑ils aux dispositions de diapositives ?**  

Les dispositions de diapositives travaillent en conjonction avec les masques des diapositives pour offrir de la flexibilité dans la conception. Le masque définit les styles et thèmes globaux, tandis que les dispositions permettent des variations dans l’arrangement du contenu. La hiérarchie est la suivante :  

- **Masque des diapositives** → Définit les styles globaux.  
- **Disposition de diapositive** → Propose différentes dispositions de contenu.  
- **Diapositive** → Hérite du design de sa disposition.  

**Puis‑je avoir plusieurs masques des diapositives dans une même présentation ?**  

Oui, une présentation peut contenir plusieurs masques des diapositives. Cela vous permet de styliser différentes sections de la présentation de manières variées, offrant ainsi une plus grande flexibilité de conception.  

**Comment accéder et modifier un masque des diapositives avec Aspose.Slides ?**  

Dans Aspose.Slides, un masque des diapositives est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). Vous pouvez accéder à un masque des diapositives en utilisant la méthode [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) de l’objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  

