---
title: Gérer les masques de diapositive de présentation en Java
linktitle: Masque de diapositive
type: docs
weight: 70
url: /fr/java/slide-master/
keywords:
- masque de diapositive
- masque de diapositive
- masque de diapositive PPT
- plusieurs masques de diapositives
- comparer les masques de diapositives
- arrière-plan
- espace réservé
- cloner le masque de diapositive
- copier le masque de diapositive
- dupliquer le masque de diapositive
- masque de diapositive inutilisé
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Gérer les masques de diapositive dans Aspose.Slides pour Java : créer, modifier et appliquer des mises en page, des thèmes et des espaces réservés aux PPT, PPTX et ODP avec des exemples Java concis."
---

## **Qu'est-ce qu'un Slide Master dans PowerPoint**

Un **Slide Master** est un modèle de diapositive qui définit la disposition, les styles, le thème, les polices, l'arrière-plan et d’autres propriétés des diapositives d’une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et le même modèle pour votre entreprise, vous pouvez utiliser un Slide Master. 

Un Slide Master est utile car il vous permet de définir et de modifier l’apparence de toutes les diapositives d’une présentation en une seule fois. Aspose.Slides prend en charge le mécanisme de Slide Master de PowerPoint. 

VBA permet également de manipuler un Slide Master et d’exécuter les mêmes opérations prises en charge dans PowerPoint : changer les arrière-plans, ajouter des formes, personnaliser la disposition, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d’utiliser les Slide Masters et d’effectuer les tâches de base avec eux. 

Voici les opérations de base du Slide Master :

- Créer un Slide Master.
- Appliquer le Slide Master aux diapositives de la présentation.
- Modifier l’arrière-plan du Slide Master. 
- Ajouter une image, un espace réservé, un SmartArt, etc. au Slide Master.

Voici des opérations plus avancées impliquant le Slide Master : 

- Comparer des Slide Masters.
- Fusionner des Slide Masters.
- Appliquer plusieurs Slide Masters.
- Copier une diapositive avec son Slide Master vers une autre présentation.
- Trouver les Slide Masters en double dans les présentations.
- Définir le Slide Master comme vue par défaut de la présentation.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter l'[**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) d’Aspose car il s’agit d’une implémentation en direct de certains des processus fondamentaux décrits ici.

{{% /alert %}} 


## **Comment le Slide Master est‑il appliqué**

Avant de travailler avec un Slide Master, vous voudrez peut‑être comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives. 

* Chaque présentation possède au moins un Slide Master par défaut. 
* Une présentation peut contenir plusieurs Slide Masters. Vous pouvez ajouter plusieurs Slide Masters et les utiliser pour mettre en forme différentes parties d’une présentation de manières différentes. 

En **Aspose.Slides**, un Slide Master est représenté par le type [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/). 

L’objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) d’Aspose.Slides contient la liste [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) de type [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), qui contient la liste de tous les masques de diapositives définis dans une présentation. 

En plus des opérations CRUD, l’interface [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) propose ces méthodes utiles : [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) et [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) . Ces méthodes sont héritées de la fonction de clonage de diapositive de base. Mais lorsqu’il s’agit de Slide Masters, ces méthodes vous permettent de mettre en place des configurations compliquées. 

Lorsqu’une nouvelle diapositive est ajoutée à une présentation, un Slide Master lui est appliqué automatiquement. Le Slide Master de la diapositive précédente est sélectionné par défaut. 

**Note** : Les diapositives de la présentation sont stockées dans la liste [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--), et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation ne contient qu’un seul Slide Master, ce masque est sélectionné pour toutes les nouvelles diapositives. C’est la raison pour laquelle vous n’avez pas à définir le Slide Master pour chaque nouvelle diapositive que vous créez.

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle diapositive, il suffit de cliquer sur la ligne inférieure sous la dernière diapositive et une nouvelle diapositive (avec le Slide Master de la dernière présentation) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez réaliser la même opération avec la méthode [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).


## **Slide Master dans la hiérarchie des diapositives**

L’utilisation des dispositions de diapositives avec le Slide Master offre une flexibilité maximale. Une disposition de diapositive vous permet de définir les mêmes styles que le Slide Master (arrière‑plan, polices, formes, etc.). Cependant, lorsque plusieurs dispositions de diapositives sont combinées sur un Slide Master, un nouveau style est créé. Lorsque vous appliquez une disposition de diapositive à une seule diapositive, vous pouvez modifier son style par rapport à celui appliqué par le Slide Master.

Le Slide Master domine tous les éléments de configuration : Slide Master → Slide Layout → Slide :

![todo:image_alt_text](slide-master_2)



Chaque objet [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) possède la propriété [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) qui renvoie une liste de dispositions de diapositives. Un type [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) possède la propriété [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) qui pointe vers la disposition de diapositive appliquée à la diapositive. L’interaction entre une diapositive et le Slide Master se fait via une disposition de diapositive.

{{% alert color="info" title="Note" %}}

* Dans Aspose.Slides, toutes les configurations de diapositive (Slide Master, Slide Layout et la diapositive elle‑même) sont en fait des objets diapositive implémentant l’interface [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide).
* Par conséquent, le Slide Master et le Slide Layout peuvent implémenter les mêmes propriétés et vous devez savoir comment leurs valeurs seront appliquées à un objet [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide). Le Slide Master est appliqué en premier à une diapositive, puis le Slide Layout est appliqué. Par exemple, si le Slide Master et le Slide Layout possèdent tous deux une valeur d’arrière‑plan, la diapositive affichera l’arrière‑plan provenant du Slide Layout.

{{% /alert %}}


## **Ce que contient un Slide Master**

Pour comprendre comment un Slide Master peut être modifié, vous devez connaître ses constituants. Voici les propriétés principales du [MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/) :

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) obtenir/definir l’arrière‑plan de la diapositive.
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) obtenir/definir les styles de texte du corps de la diapositive.
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) obtenir/definir toutes les formes du Slide Master (espaces réservés, cadres d’image, etc.).
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) obtenir/definir les contrôles ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) obtenir le gestionnaire de thème.
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) obtenir le gestionnaire d’en‑tête et de pied de page.

Méthodes du Slide Master :

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) obtenir toutes les diapositives dépendantes du Slide Master.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) : permet de créer un nouveau Slide Master basé sur le Slide Master actuel et un nouveau thème. Le nouveau Slide Master sera ensuite appliqué à toutes les diapositives dépendantes.


## **Obtenir un Slide Master**

Dans PowerPoint, le Slide Master est accessible via le menu Affichage → Masque des diapositives :

![todo:image_alt_text](slide-master_3.jpg)



Avec Aspose.Slides, vous pouvez accéder à un Slide Master de cette façon : 
```java
Presentation pres = new Presentation();
try {
    // Donne accès au masque de diapositive de la présentation
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


L’interface [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) représente un Slide Master. La propriété [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (relative au type [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)) contient la liste de tous les Slide Masters définis dans la présentation. 


## **Ajouter une image à un Slide Master**

Lorsque vous ajoutez une image à un Slide Master, cette image apparaîtra sur toutes les diapositives dépendantes de ce master. 

Par exemple, vous pouvez placer le logo de votre société et quelques images sur le Slide Master, puis revenir en mode édition des diapositives. Vous devriez voir l’image sur chaque diapositive. 

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un Slide Master avec Aspose.Slides :
```java
Presentation pres = new Presentation();
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="See also" %}} 

Pour plus d’informations sur l’ajout d’images à une diapositive, consultez l’article [Picture Frame](/slides/fr/java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Ajouter un espace réservé à un Slide Master**

Ces champs de texte sont des espaces réservés standard sur un Slide Master : 

* Cliquez pour modifier le style du titre du Master
* Modifier les styles de texte du Master
* Niveau secondaire
* Niveau tertiaire

Ils apparaissent également sur les diapositives basées sur le Slide Master. Vous pouvez modifier ces espaces réservés sur le Slide Master et les changements seront appliqués automatiquement aux diapositives. 

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin Masque des diapositives → Insérer un espace réservé :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus compliqué d’espaces réservés avec Aspose.Slides. Considérez une diapositive avec des espaces réservés provenant du Slide Master :

![todo:image_alt_text](slide-master_6.png)

Nous voulons modifier le format du titre et du sous‑titre sur le Slide Master ainsi :

![todo:image_alt_text](slide-master_7.png)

Tout d’abord, nous récupérons le contenu de l’espace réservé du titre depuis l’objet Slide Master puis nous utilisons le champ `PlaceHolder.FillFormat` : 
```java
public static void main(String[] args) {
    Presentation pres = new Presentation();
    try {
        IMasterSlide master = pres.getMasters().get_Item(0);
        IAutoShape placeHolder = findPlaceholder(master, PlaceholderType.Title);
        placeHolder.getFillFormat().setFillType(FillType.Gradient);
        placeHolder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, new Color(255, 0, 0));
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, new Color(128, 0, 128));

        pres.save("pres.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
}

static IAutoShape findPlaceholder(IMasterSlide master, int type)
{
    for (IShape shape : master.getShapes())
    {
        IAutoShape autoShape = (IAutoShape) shape;
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


Le style et le format du titre seront modifiés pour toutes les diapositives basées sur le master :

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/java/text-formatting/)

{{% /alert %}}


## **Modifier l’arrière‑plan d’un Slide Master**

Lorsque vous modifiez la couleur d’arrière‑plan d’une diapositive maîtresse, toutes les diapositives normales de la présentation recevront la nouvelle couleur. Ce code Java montre l’opération :
```java
Presentation pres = new Presentation();
try {
    IMasterSlide master = pres.getMasters().get_Item(0);
    master.getBackground().setType(BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(FillType.Solid);
    master.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="See also" %}} 

- [Presentation Background](https://docs.aspose.com/slides/java/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/java/presentation-theme/)

{{% /alert %}}

## **Cloner un Slide Master vers une autre présentation**

Pour cloner un Slide Master vers une autre présentation, appelez la méthode [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) de la présentation destination en lui passant le Slide Master. Ce code Java montre comment cloner un Slide Master vers une autre présentation :
```java
Presentation presSource = new Presentation();
Presentation persTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```



## **Ajouter plusieurs Slide Masters à une présentation**

Aspose.Slides vous permet d’ajouter plusieurs Slide Masters et dispositions de diapositives à n’importe quelle présentation. Cela vous permet de définir des styles, des dispositions et des options de formatage pour les diapositives de présentation de nombreuses manières. 

Dans PowerPoint, vous pouvez ajouter de nouveaux Slide Masters et Layouts (à partir du menu « Slide Master ») ainsi :

![todo:image_alt_text](slide-master_9.jpg)

Avec Aspose.Slides, vous pouvez ajouter un nouveau Slide Master en appelant la méthode [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) :
```java
// Ajoute un nouveau masque de diapositive
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Comparer des Slide Masters**

Un Slide Master implémente l’interface [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) contenant la méthode [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) qui peut être utilisée pour comparer des diapositives. Elle renvoie `true` pour les Slide Masters identiques en structure et en contenu statique. 

Deux Slide Masters sont égaux si leurs formes, styles, textes, animations et autres paramètres sont égaux. La comparaison ne tient pas compte des valeurs d’identifiant uniques (par ex. SlideId) ni du contenu dynamique (par ex. valeur de date actuelle dans un espace réservé de date). 


## **Définir un Slide Master comme vue par défaut de la présentation**

Aspose.Slides vous permet de définir un Slide Master comme vue par défaut d’une présentation. La vue par défaut est ce que vous voyez en premier quand vous ouvrez une présentation. 

Ce code montre comment définir un Slide Master comme vue par défaut d’une présentation en Java :
```java
// Instancie une classe Presentation qui représente le fichier de présentation
Presentation presentation = new Presentation();
try {
    // Définit la vue par défaut sur SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // Enregistre la présentation
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```



## **Supprimer les Slide Masters inutilisés**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) pour vous permettre de supprimer les Slide Masters indésirables et inutilisés. Ce code Java montre comment supprimer un Slide Master d’une présentation PowerPoint :
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```


## **FAQ**

**Qu'est‑ce qu'un Slide Master dans PowerPoint ?**

Un Slide Master est un modèle de diapositive qui définit la disposition, les styles, les thèmes, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Il vous permet de définir et de modifier l’apparence de toutes les diapositives d’une présentation en une seule fois.  

**Comment le Slide Master est‑il appliqué dans une présentation ?**

Chaque présentation possède au moins un Slide Master par défaut. Lorsqu’une nouvelle diapositive est ajoutée, un Slide Master lui est appliqué automatiquement, héritant généralement du master de la diapositive précédente. Une présentation peut contenir plusieurs Slide Masters pour styliser différemment des parties distinctes.  

**Quels éléments peuvent être personnalisés dans un Slide Master ?**

Un Slide Master comprend plusieurs propriétés principales pouvant être personnalisées :

- **Arrière‑plan** : définir l’arrière‑plan de la diapositive.
- **BodyStyle** : définir les styles de texte du corps de la diapositive.
- **Shapes** : gérer toutes les formes du Slide Master, y compris les espaces réservés et les cadres d’image.
- **Controls** : gérer les contrôles ActiveX.
- **ThemeManager** : accéder au gestionnaire de thème.
- **HeaderFooterManager** : gérer les en‑têtes et pieds de page.  

**Comment ajouter une image à un Slide Master ?**

Ajouter une image à un Slide Master garantit qu’elle apparaît sur toutes les diapositives dépendantes de ce master. Par exemple, placer le logo de l’entreprise sur le Slide Master l’affichera sur chaque diapositive de la présentation.  

**Comment les Slide Masters sont‑ils liés aux Slide Layouts ?**

Les Slide Layouts fonctionnent en combinaison avec les Slide Masters pour offrir de la flexibilité dans la conception des diapositives. Tandis qu’un Slide Master définit les styles et thèmes globaux, les Slide Layouts permettent des variations dans l’agencement du contenu. La hiérarchie est la suivante :

- **Slide Master** → définit les styles globaux.
- **Slide Layout** → offre différents agencements de contenu.
- **Slide** → hérite du design de son Slide Layout.

**Puis‑je avoir plusieurs Slide Masters dans une même présentation ?**

Oui, une présentation peut contenir plusieurs Slide Masters. Cela vous permet de styliser différentes sections d’une présentation de plusieurs façons, offrant ainsi une flexibilité de conception.  

**Comment accéder et modifier un Slide Master avec Aspose.Slides ?**

Dans Aspose.Slides, un Slide Master est représenté par l’interface [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/). Vous pouvez accéder à un Slide Master en utilisant la méthode [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) de l’objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).