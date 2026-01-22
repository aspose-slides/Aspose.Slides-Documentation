---
title: Gérer les masques de diapositives de présentation en JavaScript
linktitle: Masque de diapositive
type: docs
weight: 70
url: /fr/nodejs-java/slide-master/
keywords:
- masque de diapositive
- diapositive maître
- diapositive maître PPT
- plusieurs diapositives maîtres
- comparer les diapositives maîtres
- arrière-plan
- espace réservé
- cloner diapositive maître
- copier diapositive maître
- dupliquer diapositive maître
- diapositive maître inutilisée
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Gérez les masques de diapositives dans Aspose.Slides pour Node.js via Java: créez, modifiez et appliquez des mises en page, des thèmes et des espaces réservés aux fichiers PPT, PPTX et ODP avec des exemples concis."
---

## **Qu’est‑ce qu’un Masque de diapositive dans PowerPoint**

Un **Masque de diapositive** est un modèle de diapositive qui définit la mise en page, les styles, le thème, les polices, l’arrière‑plan et d’autres propriétés pour les diapositives d’une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et le même modèle pour votre entreprise, vous pouvez utiliser un masque de diapositive.  

Un masque de diapositive est utile parce qu’il vous permet de définir et de modifier l’apparence de toutes les diapositives de la présentation en une seule fois. Aspose.Slides prend en charge le mécanisme de masque de diapositive de PowerPoint.  

VBA permet également de manipuler un masque de diapositive et d’exécuter les mêmes opérations prises en charge dans PowerPoint : changer les arrière‑plans, ajouter des formes, personnaliser la mise en page, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d’utiliser les masques de diapositives et d’effectuer les tâches de base avec eux.  

Voici les opérations de base sur les masques de diapositives :

- Créer ou supprimer un masque de diapositive.  
- Appliquer le masque de diapositives aux diapositives de la présentation.  
- Modifier l’arrière‑plan du masque de diapositive.  
- Ajouter une image, un espace réservé, un SmartArt, etc. au masque de diapositive.  

Voici des opérations plus avancées impliquant les masques de diapositives :  

- Comparer des masques de diapositives.  
- Fusionner des masques de diapositives.  
- Appliquer plusieurs masques de diapositives.  
- Copier une diapositive avec son masque de diapositive vers une autre présentation.  
- Trouver les masques de diapositives en double dans les présentations.  
- Définir le masque de diapositive comme vue par défaut de la présentation.  

{{% alert color="primary" %}} 

Vous pouvez consulter l’[**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) d’Aspose car il s’agit d’une implémentation en direct de certains des processus fondamentaux décrits ici.

{{% /alert %}} 


## **Comment le masque de diapositive est‑il appliqué**

Avant de travailler avec un masque de diapositive, vous voudrez peut‑être comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives.  

* Chaque présentation possède au moins un masque de diapositive par défaut.  
* Une présentation peut contenir plusieurs masques de diapositives. Vous pouvez ajouter plusieurs masques de diapositives et les utiliser pour styliser différentes parties d’une présentation de manières différentes.  

Dans **Aspose.Slides**, un masque de diapositive est représenté par le type [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/).  

L’objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) d’Aspose.Slides contient la liste [**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--) de type [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), qui réunit toutes les masques de diapositives définis dans une présentation.  

Outre les opérations CRUD, la classe [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) propose les méthodes utiles : [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) et [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-). Ces méthodes héritent de la fonction de clonage de diapositive de base. Mais lorsqu’on travaille avec des masques de diapositives, elles permettent d’implémenter des configurations complexes.  

Lorsqu’une nouvelle diapositive est ajoutée à une présentation, un masque de diapositive lui est appliqué automatiquement. Le masque de la diapositive précédente est sélectionné par défaut.  

**Remarque** : les diapositives de la présentation sont stockées dans la liste [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--) et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation ne contient qu’un seul masque de diapositive, ce masque est sélectionné pour toutes les nouvelles diapositives. C’est la raison pour laquelle vous n’avez pas à définir le masque de diapositive pour chaque nouvelle diapositive que vous créez.  

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle diapositive, il suffit de cliquer sur la ligne du bas sous la dernière diapositive et une nouvelle diapositive (avec le masque de la dernière présentation) sera créée :  

![todo:image_alt_text](slide-master_1.jpg)  

Dans Aspose.Slides, vous pouvez réaliser la tâche équivalente avec la méthode [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  



## **Masque de diapositive dans la hiérarchie des diapositives**

Utiliser des dispositions de diapositive avec le masque de diapositive offre une flexibilité maximale. Une disposition de diapositive vous permet de définir les mêmes styles que le masque de diapositive (arrière‑plan, polices, formes, etc.). Cependant, lorsque plusieurs dispositions de diapositive sont combinées sur un masque de diapositive, un nouveau style est créé. Lorsque vous appliquez une disposition de diapositive à une seule diapositive, vous pouvez modifier son style par rapport à celui appliqué par le masque de diapositive.  

Le masque de diapositive domine tous les éléments de configuration : Masque de diapositive → Disposition de diapositive → Diapositive :  

![todo:image_alt_text](slide-master_2)  



Chaque objet [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) possède la propriété [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) contenant la liste des dispositions de diapositive. Un type [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) possède la propriété [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) qui fait le lien vers la disposition de diapositive appliquée à la diapositive. L’interaction entre une diapositive et le masque de diapositive s’opère via la disposition de diapositive.  

{{% alert color="info" title="Remarque" %}}

* Dans Aspose.Slides, toutes les configurations de diapositive (masque de diapositive, disposition de diapositive et la diapositive elle‑même) sont en réalité des objets diapositive implémentant la classe [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide).  
* Ainsi, le masque de diapositive et la disposition de diapositive peuvent implémenter les mêmes propriétés et il faut savoir comment leurs valeurs seront appliquées à un objet [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide). Le masque de diapositive est appliqué en premier à une diapositive, puis la disposition de diapositive. Par exemple, si le masque de diapositive et la disposition de diapositive possèdent tous deux une valeur d’arrière‑plan, la diapositive affichera l’arrière‑plan de la disposition de diapositive.

{{% /alert %}}  



## **Ce que comprend un masque de diapositive**

Pour comprendre comment un masque de diapositive peut être modifié, vous devez connaître ses constituants. Ce sont les propriétés de base du [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) :  

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) obtenir/definir l’arrière‑plan de la diapositive.  
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) obtenir/definir les styles de texte du corps de la diapositive.  
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) obtenir/definir toutes les formes du masque de diapositive (espaces réservés, cadres d’image, etc.).  
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) obtenir/definir les contrôles ActiveX.  
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getThemeManager) – obtenir le gestionnaire de thèmes.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) – obtenir le gestionnaire d’en‑tête et de pied de page.  

Méthodes du masque de diapositive :  

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) – obtenir toutes les diapositives dépendant du masque de diapositive.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) – permet de créer un nouveau masque de diapositive basé sur le masque actuel et un nouveau thème. Le nouveau masque sera alors appliqué à toutes les diapositives dépendantes.  



## **Obtenir le masque de diapositive**

Dans PowerPoint, le masque de diapositive est accessible via le menu Affichage → Masque des diapositives :  

![todo:image_alt_text](slide-master_3.jpg)  



Avec Aspose.Slides, vous pouvez accéder à un masque de diapositive de cette manière :  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Donne accès au masque de la présentation
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```
  

La classe [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) représente un masque de diapositive. La propriété [Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) (associée au type [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection)) contient la liste de tous les masques de diapositives définis dans la présentation.  



## **Ajouter une image au masque de diapositive**

Lorsque vous ajoutez une image à un masque de diapositive, cette image apparaît sur toutes les diapositives dépendant de ce masque.  

Par exemple, vous pouvez placer le logo de votre entreprise et quelques images sur le masque de diapositive, puis revenir en mode édition de diapositive. Vous devriez voir l’image sur chaque diapositive.  

![todo:image_alt_text](slide-master_4.png)  

Vous pouvez ajouter des images à un masque de diapositive avec Aspose.Slides :  
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



## **Ajouter un espace réservé au masque de diapositive**

Ces champs de texte sont des espaces réservés standard sur un masque de diapositive :  

* Cliquer pour modifier le style du titre du masque  
* Modifier les styles de texte du masque  
* Niveau 2  
* Niveau 3  

Ils apparaissent également sur les diapositives basées sur le masque de diapositive. Vous pouvez modifier ces espaces réservés sur le masque et les changements seront appliqués automatiquement aux diapositives.  

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin Masque de diapositive → Insérer un espace réservé :  

![todo:image_alt_text](slide-master_5.png)  

Examinons un exemple plus compliqué d’espaces réservés avec Aspose.Slides. Considérez une diapositive avec des espaces réservés issus du masque de diapositive :  

![todo:image_alt_text](slide-master_6.png)  

Nous voulons modifier le format du titre et du sous‑titre sur le masque de diapositive de cette façon :  

![todo:image_alt_text](slide-master_7.png)  

Tout d’abord, nous récupérons le contenu de l’espace réservé titre depuis l’objet masque de diapositive, puis nous utilisons le champ `PlaceHolder.FillFormat` :  
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
  

Le style et le format du titre changeront pour toutes les diapositives basées sur le masque de diapositive :  

![todo:image_alt_text](slide-master_8.png)  

{{% alert color="primary" title="Voir aussi" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)  
* [Text Formatting](https://docs.aspose.com/slides/nodejs-java/text-formatting/)

{{% /alert %}}  



## **Modifier l’arrière‑plan du masque de diapositive**

Lorsque vous modifiez la couleur d’arrière‑plan d’un masque de diapositive, toutes les diapositives normales de la présentation recevront la nouvelle couleur. Ce code JavaScript démontre l’opération :  
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

- [Presentation Background](https://docs.aspose.com/slides/nodejs-java/presentation-background/)  
- [Presentation Theme](https://docs.aspose.com/slides/nodejs-java/presentation-theme/)

{{% /alert %}}  



## **Cloner un masque de diapositive vers une autre présentation**

Pour cloner un masque de diapositive vers une autre présentation, appelez la méthode [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) de la présentation de destination en lui transmettant le masque de diapositive à cloner. Ce code JavaScript montre comment cloner un masque de diapositive vers une autre présentation :  
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
  



## **Ajouter plusieurs masques de diapositive à une présentation**

Aspose.Slides vous permet d’ajouter plusieurs masques de diapositives et dispositions de diapositives à une présentation donnée. Cela vous permet de configurer les styles, les mises en page et les options de formatage des diapositives de présentation de nombreuses manières.  

Dans PowerPoint, vous pouvez ajouter de nouveaux masques de diapositives et dispositions (via le « Menu Masque de diapositive ») de cette façon :  

![todo:image_alt_text](slide-master_9.jpg)  

Avec Aspose.Slides, vous pouvez ajouter un nouveau masque de diapositive en appelant la méthode [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) :  
```javascript
// Ajoute un nouveau masque de diapositive
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```
  



## **Comparer les masques de diapositives**

Un MasterSlide implémente la classe [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) contenant la méthode [**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-), qui peut être utilisée pour comparer les masques. Elle renvoie `true` lorsque les masques sont identiques en structure et en contenu statique.  

Deux masques de diapositives sont égaux si leurs formes, styles, textes, animations et autres paramètres sont identiques. La comparaison ne prend pas en compte les valeurs d’identifiants uniques (par ex. SlideId) ni le contenu dynamique (par ex. valeur de date dans un espace réservé de date).  



## **Définir le masque de diapositive comme vue par défaut de la présentation**

Aspose.Slides vous permet de définir un masque de diapositive comme vue par défaut d’une présentation. La vue par défaut est ce que vous voyez en premier lorsque vous ouvrez une présentation.  

Ce code montre comment définir un masque de diapositive comme vue par défaut d’une présentation en JavaScript :  
```javascript
// Instancie une classe Presentation qui représente le fichier de présentation
var presentation = new aspose.slides.Presentation();
try {
    // Définit la vue par défaut comme SlideMasterView
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    // Enregistre la présentation
    presentation.save("PresView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
  



## **Supprimer un masque de diapositive inutilisé**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)) pour vous permettre de supprimer les masques de diapositives indésirables et inutilisés. Ce code JavaScript montre comment supprimer un masque de diapositive d’une présentation PowerPoint :  
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

**Qu’est‑ce qu’un masque de diapositive dans PowerPoint ?**  

Un masque de diapositive est un modèle qui définit la mise en page, les styles, les thèmes, les polices, l’arrière‑plan et d’autres propriétés pour les diapositives d’une présentation. Il vous permet de définir et de modifier l’apparence de toutes les diapositives d’une présentation en une fois.  

**Comment le masque de diapositive est‑il appliqué dans une présentation ?**  

Chaque présentation possède au moins un masque de diapositive par défaut. Lorsqu’une nouvelle diapositive est ajoutée, un masque de diapositive lui est appliqué automatiquement, héritant généralement du masque de la diapositive précédente. Une présentation peut contenir plusieurs masques de diapositives pour styliser différentes parties de manière unique.  

**Quels éléments peuvent être personnalisés dans un masque de diapositive ?**  

Un masque de diapositive comprend plusieurs propriétés de base pouvant être personnalisées :  

- **Background** : définir l’arrière‑plan de la diapositive.  
- **BodyStyle** : définir les styles de texte du corps de la diapositive.  
- **Shapes** : gérer toutes les formes du masque, y compris les espaces réservés et les cadres d’image.  
- **Controls** : gérer les contrôles ActiveX.  
- **ThemeManager** : accéder au gestionnaire de thèmes.  
- **HeaderFooterManager** : gérer les en‑têtes et pieds de page.  

**Comment ajouter une image à un masque de diapositive ?**  

Ajouter une image à un masque de diapositive garantit qu’elle apparaît sur toutes les diapositives dépendant de ce masque. Par exemple, placer le logo de l’entreprise sur le masque affichera le logo sur chaque diapositive de la présentation.  

**Comment les masques de diapositives sont‑ils liés aux dispositions de diapositives ?**  

Les dispositions de diapositives fonctionnent conjointement avec les masques pour offrir une grande flexibilité de conception. Un masque définit les styles et thèmes globaux, tandis que les dispositions permettent des variations dans l’arrangement du contenu. La hiérarchie est la suivante :  

- **Masque de diapositive** → définit les styles globaux.  
- **Disposition de diapositive** → propose différents arrangements de contenu.  
- **Diapositive** → hérite du design de sa disposition.  

**Puis‑je avoir plusieurs masques de diapositives dans une même présentation ?**  

Oui, une présentation peut contenir plusieurs masques de diapositives. Cela vous permet de styliser différentes sections d’une présentation de manière variée, offrant ainsi une plus grande flexibilité de conception.  

**Comment accéder et modifier un masque de diapositive avec Aspose.Slides ?**  

Dans Aspose.Slides, un masque de diapositive est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/). Vous pouvez accéder à un masque de diapositive en utilisant la méthode [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) de l’objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).