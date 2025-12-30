---
title: Gérer les masques de diapositive de présentation en PHP
linktitle: Masque de diapositive
type: docs
weight: 70
url: /fr/php-java/slide-master/
keywords:
- masque de diapositive
- masque de diapositive
- masque de diapositive PPT
- plusieurs masques de diapositive
- comparer les masques de diapositive
- arrière-plan
- espace réservé
- cloner le masque de diapositive
- copier le masque de diapositive
- dupliquer le masque de diapositive
- masque de diapositive inutilisé
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Gérer les masques de diapositive dans Aspose.Slides pour PHP via Java : créer, modifier et appliquer des mises en page, des thèmes et des espaces réservés aux fichiers PPT, PPTX et ODP avec des exemples concis."
---

## **Qu’est‑ce qu’un masque de diapositive dans PowerPoint**

Un **masque de diapositive** est un modèle de diapositive qui définit la mise en page, les styles, le thème, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et le même modèle pour votre entreprise, vous pouvez utiliser un masque de diapositive.  

Un masque de diapositive est utile car il vous permet de définir et de modifier l’apparence de toutes les diapositives d’une présentation en une seule fois. Aspose.Slides prend en charge le mécanisme de masque de diapositive de PowerPoint.  

VBA vous permet également de manipuler un masque de diapositive et d’exécuter les mêmes opérations prises en charge dans PowerPoint : modifier les arrière‑plans, ajouter des formes, personnaliser la mise en page, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d’utiliser les masques de diapositive et d’effectuer les tâches de base avec eux.  

Voici les opérations de base sur les masques de diapositive :

- Créer ou masquer de diapositive.
- Appliquer le masque de diapositive aux diapositives de la présentation.
- Modifier l’arrière‑plan du masque de diapositive. 
- Ajouter une image, un espace réservé, un Smart Art, etc. au masque de diapositive.

Voici des opérations plus avancées impliquant le masque de diapositive : 

- Comparer les masques de diapositive.
- Fusionner les masques de diapositive.
- Appliquer plusieurs masques de diapositive.
- Copier une diapositive avec masque de diapositive vers une autre présentation.
- Détecter les masques de diapositive en double dans les présentations.
- Définir le masque de diapositive comme vue par défaut de la présentation.

{{% alert color="primary" %}} 

Vous souhaiterez peut‑être consulter l’[**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) d’Aspose, car il s’agit d’une implémentation en direct de certains des processus principaux décrits ici.

{{% /alert %}} 


## **Comment le masque de diapositive est‑il appliqué**

Avant de travailler avec un masque de diapositive, vous voudrez comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives. 

* Chaque présentation possède au moins un masque de diapositive par défaut. 
* Une présentation peut contenir plusieurs masques de diapositive. Vous pouvez ajouter plusieurs masques et les utiliser pour styliser différentes parties d’une présentation de manières différentes. 

Dans **Aspose.Slides**, un masque de diapositive est représenté par le type [**IMasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslide/).  

L’objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) d’Aspose.Slides contient la liste [**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--) de type [**IMasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/), qui renvoie une liste de tous les masques définis dans une présentation.  

En plus des opérations CRUD, l’interface [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/) propose les méthodes utiles : [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) et [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Ces méthodes sont héritées de la fonction de clonage de diapositive de base. Mais lorsqu’on travaille avec des masques de diapositive, elles permettent de mettre en œuvre des configurations complexes.  

Lorsqu’une nouvelle diapositive est ajoutée à une présentation, un masque de diapositive lui est appliqué automatiquement. Le masque de la diapositive précédente est sélectionné par défaut.  

**Note** : Les diapositives de la présentation sont stockées dans la liste [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides--) et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation ne comporte qu’un seul masque de diapositive, ce masque est sélectionné pour toutes les nouvelles diapositives. C’est la raison pour laquelle vous n’avez pas à définir le masque pour chaque nouvelle diapositive que vous créez.  

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle diapositive, il suffit de cliquer sur la ligne inférieure sous la dernière diapositive ; une nouvelle diapositive (avec le masque de la dernière présentation) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez réaliser l’opération équivalente avec la méthode [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  


## **Masque de diapositive dans la hiérarchie des diapositives**

Utiliser des mises en page de diapositive avec le masque de diapositive permet une flexibilité maximale. Une mise en page de diapositive vous permet de définir les mêmes styles que le masque (arrière‑plan, polices, formes, etc.). Cependant, lorsque plusieurs mises en page sont combinées sur un même masque, un nouveau style est créé. Lorsque vous appliquez une mise en page à une seule diapositive, vous pouvez modifier son style par rapport à celui appliqué par le masque.  

Le masque de diapositive domine tous les éléments de configuration : Masque de diapositive → Mise en page → Diapositive :

![todo:image_alt_text](slide-master_2)



Chaque objet [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) possède la propriété [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getLayoutSlides--) contenant la liste des mises en page. Un type [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) possède la propriété [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getLayoutSlide--) qui établit un lien vers la mise en page appliquée à la diapositive. L’interaction entre une diapositive et le masque se fait via la mise en page.  

{{% alert color="info" title="Note" %}}

* Dans Aspose.Slides, toutes les configurations de diapositive (masque, mise en page et diapositive elle‑même) sont en fait des objets de diapositive implémentant l’interface [**IBaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide).  
* Ainsi, le masque et la mise en page peuvent implémenter les mêmes propriétés et il faut savoir comment leurs valeurs seront appliquées à un objet [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide). Le masque est appliqué en premier, puis la mise en page. Par exemple, si le masque et la mise en page définissent tous deux une couleur d’arrière‑plan, la diapositive conservera la couleur provenant de la mise en page.  

{{% /alert %}}


## **Ce que contient un masque de diapositive**

Pour comprendre comment modifier un masque, il faut connaître ses constituants. Voici les principales propriétés du [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) :

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getBackground--) : obtenir/paramétrer l’arrière‑plan de la diapositive.  
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getBodyStyle--) : obtenir/paramétrer les styles de texte du corps.  
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getShapes--) : obtenir/paramétrer toutes les formes du masque (espaces réservés, cadres image, etc.).  
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getControls--) : obtenir/paramétrer les contrôles ActiveX.  
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterThemeable#getThemeManager--) : obtenir le gestionnaire de thème.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getHeaderFooterManager--) : obtenir le gestionnaire d’en‑têtes et pieds‑de‑page.  

Méthodes du masque de diapositive :

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getDependingSlides--) : obtenir toutes les diapositives dépendantes du masque.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) : permet de créer un nouveau masque à partir du masque actuel et d’un nouveau thème. Le nouveau masque sera alors appliqué à toutes les diapositives dépendantes.  


## **Obtenir un masque de diapositive**

Dans PowerPoint, le masque de diapositive est accessible via le menu Affichage → Masque des diapositives :

![todo:image_alt_text](slide-master_3.jpg)



Avec Aspose.Slides, vous pouvez accéder à un masque de cette manière : 
```php
  $pres = new Presentation();
  try {
    # Donne accès au masque de diapositive de la présentation
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


L’interface [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) représente un masque. La propriété [Masters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getMasters--) (relatif au type [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection)) contient la liste de tous les masques définis dans la présentation.  


## **Ajouter une image à un masque de diapositive**

Lorsque vous ajoutez une image à un masque, celle‑ci apparaît sur toutes les diapositives dépendantes de ce masque.  

Par exemple, vous pouvez placer le logo de votre société et quelques images sur le masque, puis revenir en mode édition des diapositives. Vous verrez l’image sur chaque diapositive.  

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un masque avec Aspose.Slides :
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

Pour plus d’informations sur l’ajout d’images à une diapositive, consultez l’article [Picture Frame](/slides/fr/php-java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Ajouter un espace réservé à un masque de diapositive**

Ces champs de texte sont des espaces réservés standard sur un masque : 

* Cliquez pour modifier le style du titre du masque
* Modifier les styles de texte du masque
* Deuxième niveau
* Troisième niveau 

Ils apparaissent également sur les diapositives basées sur le masque. Vous pouvez modifier ces espaces réservés sur le masque et les changements seront appliqués automatiquement aux diapositives.  

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin Masque des diapositives → Insérer un espace réservé :



![todo:image_alt_text](slide-master_5.png)



Examinons un exemple plus complexe d’espaces réservés avec Aspose.Slides. Considérez une diapositive contenant des espaces réservés provenant du masque :



![todo:image_alt_text](slide-master_6.png)



Nous voulons modifier le format du titre et du sous‑titre sur le masque de cette façon :

![todo:image_alt_text](slide-master_7.png)



Tout d’abord, récupérez le contenu de l’espace réservé du titre depuis l’objet masque et utilisez le champ `PlaceHolder.FillFormat` : 
```php

```


Le style et le format du titre seront modifiés pour toutes les diapositives basées sur le masque :



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Voir aussi" %}} 

* [Définir le texte d’invite dans un espace réservé](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [Mise en forme du texte](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}


## **Modifier l’arrière‑plan d’un masque de diapositive**

Lorsque vous modifiez la couleur d’arrière‑plan d’un masque, toutes les diapositives normales de la présentation recevront la nouvelle couleur. Ce code PHP montre l’opération :
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

## **Cloner un masque de diapositive vers une autre présentation**

Pour cloner un masque vers une autre présentation, appelez la méthode [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) de la présentation cible en y passant le masque à cloner. Ce code PHP montre comment cloner un masque vers une autre présentation :
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



## **Ajouter plusieurs masques de diapositive à une présentation**

Aspose.Slides vous permet d’ajouter plusieurs masques et mises en page à n’importe quelle présentation. Cela vous permet de configurer les styles, les mises en page et les options de formatage des diapositives de multiples façons.  

Dans PowerPoint, vous pouvez ajouter de nouveaux masques et mises en page (depuis le « menu Masque des diapositives ») de cette façon :

![todo:image_alt_text](slide-master_9.jpg)

Avec Aspose.Slides, vous pouvez ajouter un nouveau masque en appelant la méthode [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) :
```php
  # Ajoute un nouveau masque de diapositive
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```



## **Comparer les masques de diapositive**

Un masque implémente l’interface [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) contenant la méthode [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), qui peut être utilisée pour comparer les masques. Elle renvoie `true` lorsque les masques sont identiques en structure et en contenu statique.  

Deux masques sont égaux si leurs formes, styles, textes, animations et autres réglages sont identiques. La comparaison ne tient pas compte des identifiants uniques (par ex. SlideId) ni du contenu dynamique (par ex. valeur de date dans un espace réservé de date).  


## **Définir un masque de diapositive comme vue par défaut de la présentation**

Aspose.Slides vous permet de définir un masque comme vue par défaut d’une présentation. La vue par défaut est ce que vous voyez en premier lorsque vous ouvrez la présentation.  

Ce code montre comment définir un masque comme vue par défaut :
```php
  # Instancie une classe Presentation qui représente le fichier de présentation
  $presentation = new Presentation();
  try {
    # Définit la vue par défaut sur SlideMasterView
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # Enregistre la présentation
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Supprimer les masques de diapositive inutilisés**

Aspose.Slides propose la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) pour supprimer les masques inutilisés. Ce code PHP montre comment enlever un masque d’une présentation PowerPoint :
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

**Qu’est‑ce qu’un masque de diapositive dans PowerPoint ?**

Un masque de diapositive est un modèle qui définit la mise en page, les styles, les thèmes, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Il vous permet de définir et de modifier l’apparence de toutes les diapositives en une seule fois.  

**Comment un masque est‑il appliqué dans une présentation ?**

Chaque présentation possède au moins un masque par défaut. Lorsqu’une nouvelle diapositive est ajoutée, un masque lui est appliqué automatiquement, généralement en héritant du masque de la diapositive précédente. Une présentation peut contenir plusieurs masques pour styliser différemment ses parties.  

**Quels éléments peuvent être personnalisés dans un masque ?**

Un masque comprend plusieurs propriétés de base qui peuvent être personnalisées :

- **Background** : définir l’arrière‑plan de la diapositive.  
- **BodyStyle** : définir les styles de texte du corps.  
- **Shapes** : gérer toutes les formes du masque, y compris les espaces réservés et les cadres image.  
- **Controls** : gérer les contrôles ActiveX.  
- **ThemeManager** : accéder au gestionnaire de thème.  
- **HeaderFooterManager** : gérer les en‑têtes et pieds‑de‑page.  

**Comment ajouter une image à un masque ?**

Ajouter une image à un masque garantit qu’elle apparaît sur toutes les diapositives dépendantes. Par exemple, placer le logo de l’entreprise sur le masque l’affichera sur chaque diapositive de la présentation.  

**Comment les masques et les mises en page sont‑ils liés ?**

Les mises en page fonctionnent avec les masques pour offrir de la flexibilité dans la conception. Le masque définit les styles globaux, tandis que les mises en page offrent des variations d’agencement du contenu. La hiérarchie est :

- **Masque de diapositive** → définit les styles globaux.  
- **Mise en page** → propose différents agencements de contenu.  
- **Diapositive** → hérite du design de sa mise en page.  

**Puis‑je avoir plusieurs masques dans une même présentation ?**

Oui, une présentation peut contenir plusieurs masques. Cela permet de styliser différentes sections de façon variée, offrant ainsi une plus grande flexibilité de conception.  

**Comment accéder et modifier un masque avec Aspose.Slides ?**

Dans Aspose.Slides, un masque est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/). Vous pouvez accéder à un masque via la méthode [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) de l’objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).