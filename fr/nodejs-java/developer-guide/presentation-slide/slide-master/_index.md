---
title: Maître de diapositive
type: docs
weight: 70
url: /fr/nodejs-java/slide-master/
keywords: "Ajouter maître de diapositive, diapositive maître PPT, maître de diapositive PowerPoint, image au maître de diapositive, espace réservé, plusieurs maîtres de diapositive, comparer les maîtres de diapositive, Java, Aspose.Slides pour Node.js via Java"
description: "Ajouter ou modifier le maître de diapositive dans une présentation PowerPoint en JavaScript"
---

## **Qu'est-ce qu'un Maître de diapositive dans PowerPoint**

Un **Slide Master** est un modèle de diapositive qui définit la mise en page, les styles, le thème, les polices, l'arrière-plan et d'autres propriétés pour les diapositives d'une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et le même modèle pour votre entreprise, vous pouvez utiliser un maître de diapositive.

Un maître de diapositive est utile car il vous permet de définir et de modifier l'apparence de toutes les diapositives d'une présentation en même temps. Aspose.Slides prend en charge le mécanisme du maître de diapositive de PowerPoint.

VBA permet également de manipuler un maître de diapositive et d'exécuter les mêmes opérations prises en charge dans PowerPoint : modifier les arrière-plans, ajouter des formes, personnaliser la mise en page, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d'utiliser les maîtres de diapositive et d'effectuer des tâches de base avec eux.

Voici les opérations de base sur les maîtres de diapositive :

- Créer un Slide Master.
- Appliquer le Slide Master aux diapositives de la présentation.
- Modifier l'arrière‑plan du Slide Master. 
- Ajouter une image, un espace réservé, un Smart Art, etc. au Slide Master.

Voici des opérations plus avancées impliquant le maître de diapositive :

- Comparer les maîtres de diapositive.
- Fusionner les maîtres de diapositive.
- Appliquer plusieurs maîtres de diapositive.
- Copier une diapositive avec son maître de diapositive vers une autre présentation.
- Détecter les maîtres de diapositive en double dans les présentations.
- Définir le maître de diapositive comme vue par défaut de la présentation.

{{% alert color="primary" %}} 

Vous souhaiterez peut‑être consulter l'[**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) d'Aspose, car il s'agit d'une implémentation en direct de certains des processus principaux décrits ici.

{{% /alert %}} 


## **Comment le maître de diapositive est appliqué**

Avant de travailler avec un maître de diapositive, vous voudrez peut‑être comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives. 

* Chaque présentation possède au moins un maître de diapositive par défaut. 
* Une présentation peut contenir plusieurs maîtres de diapositive. Vous pouvez ajouter plusieurs maîtres de diapositive et les utiliser pour styliser différentes parties d'une présentation de façon distincte. 

Dans **Aspose.Slides**, un maître de diapositive est représenté par le type [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/).

L'objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) d'Aspose.Slides contient la liste [**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--) de type [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), qui renvoie la liste de tous les maîtres de diapositive définis dans une présentation.

Outre les opérations CRUD, la classe [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) propose ces méthodes utiles : [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) et [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-). Ces méthodes sont héritées de la fonction de clonage de base des diapositives. Mais lorsqu'on travaille avec des maîtres de diapositive, elles permettent de mettre en place des configurations complexes.

Lorsqu'une nouvelle diapositive est ajoutée à une présentation, un maître de diapositive lui est appliqué automatiquement. Le maître de diapositive de la diapositive précédente est sélectionné par défaut. 

**Note** : Les diapositives de la présentation sont stockées dans la liste [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--), et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation ne comporte qu'un seul maître de diapositive, ce maître est sélectionné pour toutes les nouvelles diapositives. C’est la raison pour laquelle vous n’avez pas besoin de définir le maître de diapositive pour chaque nouvelle diapositive que vous créez.

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle diapositive, il suffit de cliquer sur la ligne située sous la dernière diapositive et une nouvelle diapositive (avec le maître de diapositive de la dernière présentation) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez réaliser l’opération équivalente avec la méthode [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).


## **Maître de diapositive dans la hiérarchie des diapositives**

L’utilisation des mises en page de diapositive avec le maître de diapositive offre une flexibilité maximale. Une mise en page de diapositive vous permet de définir les mêmes styles que le maître de diapositive (arrière‑plan, polices, formes, etc.). Cependant, lorsqu’il existe plusieurs mises en page de diapositive combinées à un maître de diapositive, un nouveau style est créé. Lorsque vous appliquez une mise en page de diapositive à une diapositive unique, vous pouvez modifier son style par rapport à celui appliqué par le maître de diapositive.

Le maître de diapositive prime sur tous les éléments de configuration : Maître de diapositive → Mise en page de diapositive → Diapositive :

![todo:image_alt_text](slide-master_2)



Chaque objet [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) possède la propriété [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) contenant une liste de mises en page de diapositive. Un type [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) possède la propriété [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) pointant vers la mise en page de diapositive appliquée à la diapositive. L’interaction entre une diapositive et le maître de diapositive s’effectue via une mise en page de diapositive.

{{% alert color="info" title="Note" %}}

* Dans Aspose.Slides, toutes les configurations de diapositive (maître de diapositive, mise en page de diapositive et la diapositive elle‑même) sont en fait des objets de diapositive implémentant la classe [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide).
* Par conséquent, le maître de diapositive et la mise en page de diapositive peuvent implémenter les mêmes propriétés et vous devez connaître la façon dont leurs valeurs seront appliquées à un objet [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide). Le maître de diapositive est appliqué en premier à une diapositive, puis la mise en page de diapositive est appliquée. Par exemple, si le maître de diapositive et la mise en page de diapositive possèdent tous deux une valeur d'arrière‑plan, la diapositive finira par afficher l'arrière‑plan de la mise en page de diapositive.

{{% /alert %}}


## **Ce qui compose un maître de diapositive**

Pour comprendre comment un maître de diapositive peut être modifié, il faut connaître ses composants. Voici les propriétés principales de [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) :

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) : obtenir/definir l'arrière‑plan de la diapositive.
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) : obtenir/definir les styles de texte du corps de la diapositive.
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) : obtenir/definir toutes les formes du maître de diapositive (espaces réservés, cadres image, etc.).
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) : obtenir/definir les contrôles ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterThemeable#getThemeManager--) : obtenir le gestionnaire de thèmes.
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) : obtenir le gestionnaire d’en‑têtes et de pieds de page.

Méthodes du maître de diapositive :

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) : obtenir toutes les diapositives dépendant du maître de diapositive.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) : crée un nouveau maître de diapositive basé sur le maître actuel et un nouveau thème. Le nouveau maître sera alors appliqué à toutes les diapositives dépendantes.


## **Obtenir le maître de diapositive**

Dans PowerPoint, le maître de diapositive est accessible via le menu Affichage → Maître de diapositive :

![todo:image_alt_text](slide-master_3.jpg)



Avec Aspose.Slides, vous pouvez accéder à un maître de diapositive de cette façon :
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Donne accès à la diapositive maître de la présentation
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


La classe [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) représente un maître de diapositive. La propriété [Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) (relative au type [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection)) contient la liste de tous les maîtres de diapositive définis dans la présentation.


## **Ajouter une image au maître de diapositive**

Lorsque vous ajoutez une image à un maître de diapositive, cette image apparaîtra sur toutes les diapositives dépendant de ce maître.

Par exemple, vous pouvez placer le logo de votre société et quelques images sur le maître de diapositive, puis repasser en mode édition des diapositives. Vous verrez alors l’image sur chaque diapositive.

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un maître de diapositive avec Aspose.Slides :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="Voir aussi" %}} 

Pour plus d’informations sur l’ajout d’images à une diapositive, consultez l’article [Picture Frame](/slides/fr/nodejs-java/picture-frame/#create-picture-frame).

{{% /alert %}}


## **Ajouter un espace réservé au maître de diapositive**

Ces champs de texte sont des espaces réservés standard sur un maître de diapositive :

* Cliquez pour modifier le style du titre du maître
* Modifier les styles de texte du maître
* Deuxième niveau
* Troisième niveau

Ils apparaissent également sur les diapositives basées sur le maître de diapositive. Vous pouvez modifier ces espaces réservés sur le maître de diapositive et les changements seront appliqués automatiquement aux diapositives.

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin Maître de diapositive → Insérer un espace réservé :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus compliqué d'espaces réservés avec Aspose.Slides. Considérons une diapositive contenant des espaces réservés provenant du maître de diapositive :

![todo:image_alt_text](slide-master_6.png)

Nous voulons modifier le format du titre et du sous‑titre sur le maître de diapositive ainsi :

![todo:image_alt_text](slide-master_7.png)

Tout d'abord, nous récupérons le contenu de l'espace réservé du titre depuis l'objet MasterSlide, puis nous utilisons le champ `PlaceHolder.FillFormat` :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    var placeHolder = findPlaceholder(master, aspose.slides.PlaceholderType.Title);
    placeHolder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    placeHolder.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    var awtColor = java.import('java.awt.Color');
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, java.newInstanceSync('java.awt.Color', 255, 0, 0));
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, java.newInstanceSync('java.awt.Color', 128, 0, 128));

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

function findPlaceholder(master, type)
{    
    for (var i = 0 ; i < master.getShapes().size(); i++)
    {
        var autoShape = master.getShapes().get_Item(i);
        if (autoShape != null)
        {
            if (autoShape.getPlaceholder().getType() == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```


Le style et le format du titre changeront pour toutes les diapositives basées sur le maître de diapositive :

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Voir aussi" %}} 

* [Définir le texte d’invite dans un espace réservé](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)
* [Mise en forme du texte](https://docs.aspose.com/slides/nodejs-java/text-formatting/)

{{% /alert %}}


## **Modifier l'arrière‑plan du maître de diapositive**

Lorsque vous modifiez la couleur d’arrière‑plan d’un maître de diapositive, toutes les diapositives normales de la présentation recevront la nouvelle couleur. Ce code JavaScript démontre l’opération :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    master.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    master.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="Voir aussi" %}} 

- [Arrière‑plan de la présentation](https://docs.aspose.com/slides/nodejs-java/presentation-background/)
- [Thème de la présentation](https://docs.aspose.com/slides/nodejs-java/presentation-theme/)

{{% /alert %}}

## **Cloner le maître de diapositive vers une autre présentation**

Pour cloner un maître de diapositive vers une autre présentation, appelez la méthode [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) depuis la présentation de destination en lui passant le maître de diapositive. Ce code JavaScript montre comment cloner un maître de diapositive vers une autre présentation :
```javascript
var presSource = new aspose.slides.Presentation();
var presTarget = new aspose.slides.Presentation();
try {
    var master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) {
        presSource.dispose();
    }
}
```



## **Ajouter plusieurs maîtres de diapositive à une présentation**

Aspose.Slides vous permet d’ajouter plusieurs maîtres de diapositive et mises en page de diapositive à n’importe quelle présentation. Cela vous permet de configurer les styles, les mises en page et les options de mise en forme des diapositives de présentation de multiples façons.

Dans PowerPoint, vous pouvez ajouter de nouveaux maîtres de diapositive et mises en page (depuis le « Menu Maître de diapositive ») ainsi :

![todo:image_alt_text](slide-master_9.jpg)

Avec Aspose.Slides, vous pouvez ajouter un nouveau maître de diapositive en appelant la méthode [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) :
```javascript
// Ajoute une nouvelle diapositive maître
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Comparer les maîtres de diapositive**

Un Master Slide implémente la classe [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) contenant la méthode [**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-), qui peut être utilisée pour comparer les diapositives. Elle renvoie `true` pour les maîtres de diapositive identiques en structure et en contenu statique.

Deux maîtres de diapositive sont égaux si leurs formes, styles, textes, animations et autres paramètres sont identiques. La comparaison ne prend pas en compte les valeurs d’identifiants uniques (p. ex. SlideId) ni le contenu dynamique (p. ex. la date actuelle dans un espace réservé de date).


## **Définir le maître de diapositive comme vue par défaut de la présentation**

Aspose.Slides vous permet de définir un maître de diapositive comme vue par défaut d’une présentation. La vue par défaut est ce que vous voyez en premier lors de l’ouverture d’une présentation.

Ce code montre comment définir un maître de diapositive comme vue par défaut d’une présentation en JavaScript :
```javascript
// Instancie une classe Presentation qui représente le fichier de présentation
var presentation = new aspose.slides.Presentation();
try {
    // Définit la vue par défaut sur SlideMasterView
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    // Enregistre la présentation
    presentation.save("PresView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Supprimer les maîtres de diapositive inutilisés**

Aspose.Slides propose la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) pour vous permettre de supprimer les maîtres de diapositive indésirables et inutilisés. Ce code JavaScript montre comment supprimer un maître de diapositive d’une présentation PowerPoint :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Qu’est‑ce qu’un maître de diapositive dans PowerPoint ?**

Un maître de diapositive est un modèle de diapositive qui définit la mise en page, les styles, les thèmes, les polices, l’arrière‑plan et d’autres propriétés pour les diapositives d’une présentation. Il vous permet de définir et de modifier l’apparence de toutes les diapositives d’une présentation en une seule fois.  

**Comment un maître de diapositive est‑il appliqué dans une présentation ?**

Chaque présentation possède au moins un maître de diapositive par défaut. Lorsqu’une nouvelle diapositive est ajoutée, un maître de diapositive lui est appliqué automatiquement, généralement en héritant du maître de la diapositive précédente. Une présentation peut contenir plusieurs maîtres de diapositive pour styliser différentes parties de façon distincte.  

**Quels éléments peuvent être personnalisés dans un maître de diapositive ?**

Un maître de diapositive comprend plusieurs propriétés de base pouvant être personnalisées :

- **Arrière‑plan** : définir l’arrière‑plan de la diapositive.
- **BodyStyle** : définir les styles de texte du corps de la diapositive.
- **Shapes** : gérer toutes les formes du maître de diapositive, y compris les espaces réservés et les cadres image.
- **Controls** : gérer les contrôles ActiveX.
- **ThemeManager** : accéder au gestionnaire de thèmes.
- **HeaderFooterManager** : gérer les en‑têtes et pieds de page.  

**Comment ajouter une image à un maître de diapositive ?**

Ajouter une image à un maître de diapositive garantit qu’elle apparaît sur toutes les diapositives dépendant de ce maître. Par exemple, placer le logo de l’entreprise sur le maître de diapositive l’affichera sur chaque diapositive de la présentation.  

**Comment les maîtres de diapositive sont‑ils liés aux mises en page de diapositive ?**

Les mises en page de diapositive fonctionnent avec le maître de diapositive pour offrir une flexibilité dans la conception des diapositives. Le maître de diapositive définit les styles et thèmes globaux, tandis que les mises en page de diapositive permettent des variations dans la disposition du contenu. La hiérarchie est la suivante :

- **Maître de diapositive** → Définit les styles globaux.
- **Mise en page de diapositive** → Fournit différentes dispositions de contenu.
- **Diapositive** → Hérite du design de sa mise en page de diapositive.

**Puis‑je avoir plusieurs maîtres de diapositive dans une même présentation ?**

Oui, une présentation peut contenir plusieurs maîtres de diapositive. Cela vous permet de styliser différentes sections d’une présentation de diverses manières, offrant ainsi une grande flexibilité de conception.  

**Comment accéder et modifier un maître de diapositive avec Aspose.Slides ?**

Dans Aspose.Slides, un maître de diapositive est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/). Vous pouvez accéder à un maître de diapositive en utilisant la méthode [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) de l’objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).