---
title: Gérer les masques de diapositives de présentation en Java
linktitle: Masque de diapositive
type: docs
weight: 70
url: /fr/java/slide-master/
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
- Java
- Aspose.Slides
description: "Gérez les masques de diapositives dans Aspose.Slides pour Java : créez, modifiez et appliquez des mises en page, des thèmes et des espaces réservés aux formats PPT, PPTX et ODP avec des exemples Java concis."
---

## **Qu'est‑ce qu'un Masque de diapositives dans PowerPoint**

Un **Slide Master** est un modèle de diapositive qui définit la mise en page, les styles, le thème, les polices, l'arrière‑plan et d'autres propriétés des diapositives d'une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et le même modèle pour votre entreprise, vous pouvez utiliser un masque de diapositives.

Un masque de diapositives est utile car il vous permet de définir et de modifier l'apparence de toutes les diapositives d'une présentation en une seule fois. Aspose.Slides prend en charge le mécanisme de Masque de diapositives de PowerPoint.

VBA vous permet également de manipuler un Masque de diapositives et d'exécuter les mêmes opérations prises en charge dans PowerPoint : modifier les arrière‑plans, ajouter des formes, personnaliser la mise en page, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d’utiliser les Masques de diapositives et d’effectuer des tâches de base avec eux.

Voici les opérations de base sur les Masques de diapositives :

- Créer ou Masque de diapositives.
- Appliquer le Masque de diapositives aux diapositives de la présentation.
- Modifier l'arrière‑plan du Masque de diapositives. 
- Ajouter une image, un espace réservé, SmartArt, etc. au Masque de diapositives.

Voici des opérations plus avancées impliquant les Masques de diapositives :

- Comparer les Masques de diapositives.
- Fusionner les Masques de diapositives.
- Appliquer plusieurs Masques de diapositives.
- Copier une diapositive avec son Masque de diapositives vers une autre présentation.
- Détecter les Masques de diapositives en double dans les présentations.
- Définir le Masque de diapositives comme vue par défaut de la présentation.

{{% alert color="primary" %}} 
Vous souhaiterez peut‑être consulter Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) car il s'agit d'une implémentation en direct de certains des processus de base décrits ici.
{{% /alert %}} 


## **Comment un Masque de diapositives est‑il appliqué**

Avant de travailler avec un masque de diapositives, vous voudrez peut‑être comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives.

* Chaque présentation possède au moins un Masque de diapositives par défaut. 
* Une présentation peut contenir plusieurs Masques de diapositives. Vous pouvez ajouter plusieurs Masques de diapositives et les utiliser pour styliser différentes parties d’une présentation de manières distinctes. 

Dans **Aspose.Slides**, un Masque de diapositives est représenté par le type [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/).

L’objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) d’Aspose.Slides contient la liste [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) de type [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), qui contient la liste de tous les masques de diapositives définis dans une présentation.

Outre les opérations CRUD, l’interface [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) propose les méthodes utiles : [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) et [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Ces méthodes sont héritées de la fonction de clonage de base des diapositives. Mais lorsqu’on travaille avec des Masques de diapositives, elles permettent d’implémenter des configurations complexes. 

Lorsqu’une nouvelle diapositive est ajoutée à une présentation, un Masque de diapositives lui est appliqué automatiquement. Le Masque de diapositives de la diapositive précédente est sélectionné par défaut. 

**Note** : Les diapositives de la présentation sont stockées dans la liste [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--). Chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation ne contient qu’un seul Masque de diapositives, ce masque est sélectionné pour toutes les nouvelles diapositives. C’est la raison pour laquelle vous n’avez pas besoin de définir le Masque de diapositives pour chaque nouvelle diapositive que vous créez.

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle diapositive, il suffit de cliquer sur la ligne du bas sous la dernière diapositive ; une nouvelle diapositive (avec le Masque de diapositives de la présentation précédente) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez effectuer la tâche équivalente avec la méthode [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).


## **Masque de diapositives dans la hiérarchie des diapositives**

L’utilisation des dispositions de diapositives avec le Masque de diapositives permet une flexibilité maximale. Une disposition de diapositive vous permet de définir les mêmes styles que le Masque de diapositives (arrière‑plan, polices, formes, etc.). Cependant, lorsque plusieurs dispositions sont combinées sur un Masque de diapositives, un nouveau style est créé. En appliquant une disposition à une seule diapositive, vous pouvez modifier son style par rapport à celui appliqué par le Masque de diapositives.

Le Masque de diapositives prime sur tous les éléments de configuration : Masque de diapositives → Disposition de diapositive → Diapositive :

![todo:image_alt_text](slide-master_2)

Chaque objet [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) possède la propriété [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) qui renvoie une liste de dispositions de diapositives. Un objet de type [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) possède la propriété [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) qui référence la disposition appliquée à la diapositive. L’interaction entre une diapositive et le Masque de diapositives s’effectue via une disposition de diapositive.

{{% alert color="info" title="Note" %}}
* Dans Aspose.Slides, toutes les configurations de diapositive (Masque de diapositives, Disposition de diapositive et la diapositive elle‑même) sont en réalité des objets de diapositive implémentant l’interface [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide).
* Ainsi, le Masque de diapositives et la Disposition de diapositive peuvent implémenter les mêmes propriétés et vous devez savoir comment leurs valeurs seront appliquées à un objet [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide). Le Masque de diapositives est appliqué en premier, puis la Disposition de diapositive. Par exemple, si les deux définissent une couleur d'arrière‑plan, la diapositive affichera la couleur provenant de la Disposition de diapositive.
{{% /alert %}}


## **Ce que contient un Masque de diapositives**

Pour comprendre comment modifier un Masque de diapositives, vous devez connaître ses composants. Il s’agit des propriétés de base de [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) : obtenir/definir l’arrière‑plan de la diapositive.
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) : obtenir/definir les styles de texte du corps de la diapositive.
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) : obtenir/definir toutes les formes du Masque de diapositives (espaces réservés, cadres d’image, etc.).
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) : obtenir/definir les contrôles ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) : obtenir le gestionnaire de thème.
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) : obtenir le gestionnaire d’en‑tête et de pied de page.

Méthodes du Masque de diapositives :

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) : obtenir toutes les diapositives dépendantes du Masque de diapositives.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) : permet de créer un nouveau Masque de diapositives basé sur le masque actuel et un nouveau thème. Le nouveau masque sera alors appliqué à toutes les diapositives dépendantes.


## **Obtenir un Masque de diapositives**

Dans PowerPoint, le Masque de diapositives est accessible via le menu **Affichage → Masque de diapositives** :

![todo:image_alt_text](slide-master_3.jpg)

Avec Aspose.Slides, vous pouvez accéder à un Masque de diapositives de cette façon :
```java
Presentation pres = new Presentation();
try {
    // Donne accès au masque de diapositive de la présentation
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


L’interface [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) représente un Masque de diapositives. La propriété [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (associée au type [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)) contient la liste de tous les Masques de diapositives définis dans la présentation.


## **Ajouter une image à un Masque de diapositives**

Lorsque vous ajoutez une image à un Masque de diapositives, cette image apparaîtra sur toutes les diapositives qui en dépendent.

Par exemple, vous pouvez placer le logo de votre entreprise et quelques images sur le Masque de diapositives, puis revenir en mode édition des diapositives. Vous verrez alors l’image sur chaque diapositive.

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un Masque de diapositives avec Aspose.Slides :
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


{{% alert color="primary" title="Voir aussi" %}} 
Pour plus d’informations sur l’ajout d’images à une diapositive, consultez l’article [Picture Frame](/slides/fr/java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Ajouter un espace réservé à un Masque de diapositives**

Ces champs texte sont des espaces réservés standard sur un Masque de diapositives :

* Cliquer pour modifier le style du titre du masque
* Modifier les styles de texte du masque
* Deuxième niveau
* Troisième niveau

Ils apparaissent également sur les diapositives basées sur le Masque de diapositives. Vous pouvez modifier ces espaces réservés sur le Masque de diapositives et les changements seront appliqués automatiquement aux diapositives.

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin **Masque de diapositives → Insérer un espace réservé** :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus complexe d’espaces réservés avec Aspose.Slides. Considérons une diapositive contenant des espaces réservés provenant du Masque de diapositives :

![todo:image_alt_text](slide-master_6.png)

Nous voulons modifier la mise en forme du titre et du sous‑titre du Masque de diapositives de la manière suivante :

![todo:image_alt_text](slide-master_7.png)

Tout d’abord, nous récupérons le contenu de l’espace réservé du titre à partir de l’objet Masque de diapositives, puis nous utilisons le champ `PlaceHolder.FillFormat` :
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


Le style et la mise en forme du titre changeront pour toutes les diapositives basées sur le masque :

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Voir aussi" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/java/text-formatting/)
{{% /alert %}}


## **Modifier l'arrière‑plan d'un Masque de diapositives**

Lorsque vous modifiez la couleur d’arrière‑plan d’un masque de diapositives, toutes les diapositives normales de la présentation recevront la nouvelle couleur. Ce code Java montre l’opération :
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


{{% alert color="primary" title="Voir aussi" %}} 
- [Presentation Background](https://docs.aspose.com/slides/java/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/java/presentation-theme/)
{{% /alert %}}

## **Cloner un Masque de diapositives vers une autre présentation**

Pour cloner un Masque de diapositives vers une autre présentation, appelez la méthode [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) de la présentation de destination en lui transmettant le Masque de diapositives. Ce code Java montre comment cloner un Masque de diapositives vers une autre présentation :
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```



## **Ajouter plusieurs Masques de diapositives à une présentation**

Aspose.Slides vous permet d’ajouter plusieurs Masques de diapositives et dispositions à n’importe quelle présentation. Cela vous permet de définir des styles, des mises en page et des options de formatage pour les diapositives de façon très variée.

Dans PowerPoint, vous pouvez ajouter de nouveaux Masques de diapositives et dispositions (à partir du **menu Masque de diapositives**) de la manière suivante :

![todo:image_alt_text](slide-master_9.jpg)

Avec Aspose.Slides, vous pouvez ajouter un nouveau Masque de diapositives en appelant la méthode [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) :
```java
// Ajoute un nouveau masque de diapositive
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Comparer les Masques de diapositives**

Un Master Slide implémente l’interface [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) contenant la méthode [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), qui peut être utilisée pour comparer les masques. Elle renvoie `true` lorsque les Masques de diapositives sont identiques en structure et en contenu statique.

Deux Masques de diapositives sont égaux si leurs formes, styles, textes, animations et autres paramètres sont identiques. La comparaison ne tient pas compte des valeurs d’identifiants uniques (par ex. SlideId) ni du contenu dynamique (par ex. la date actuelle dans un espace réservé Date).


## **Définir un Masque de diapositives comme vue par défaut de la présentation**

Aspose.Slides vous permet de définir un Masque de diapositives comme vue par défaut d’une présentation. La vue par défaut est ce que vous voyez en premier lorsque vous ouvrez une présentation.

Ce code montre comment définir un Masque de diapositives comme vue par défaut d’une présentation en Java :
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



## **Supprimer les Masques de diapositives inutilisés**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) pour supprimer les masques inutilisés. Ce code Java montre comment supprimer un masque de diapositives d’une présentation PowerPoint :
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

**Qu'est‑ce qu'un Masque de diapositives dans PowerPoint ?**

Un Masque de diapositives est un modèle qui définit la mise en page, les styles, les thèmes, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Il vous permet de définir et de modifier l’apparence de toutes les diapositives d’une présentation en une seule fois.  

**Comment un Masque de diapositives est‑il appliqué dans une présentation ?**

Chaque présentation possède au moins un Masque de diapositives par défaut. Lorsqu’une nouvelle diapositive est ajoutée, un Masque de diapositives lui est appliqué automatiquement, généralement en héritant du masque de la diapositive précédente. Une présentation peut contenir plusieurs Masques de diapositives afin de styliser différentes parties de manière unique.  

**Quels éléments peuvent être personnalisés dans un Masque de diapositives ?**

Un Masque de diapositives comprend plusieurs propriétés de base qui peuvent être personnalisées :

- **Arrière‑plan** : définir l’arrière‑plan de la diapositive.
- **BodyStyle** : définir les styles de texte du corps de la diapositive.
- **Shapes** : gérer toutes les formes du Masque de diapositives, y compris les espaces réservés et les cadres d’image.
- **Controls** : gérer les contrôles ActiveX.
- **ThemeManager** : accéder au gestionnaire de thème.
- **HeaderFooterManager** : gérer les en‑têtes et pieds de page.  

**Comment ajouter une image à un Masque de diapositives ?**

Ajouter une image à un Masque de diapositives garantit qu’elle apparaît sur toutes les diapositives qui en dépendent. Par exemple, placer le logo de l’entreprise sur le Masque de diapositives l’affichera sur chaque diapositive de la présentation.  

**Comment les Masques de diapositives se rapportent‑ils aux Dispositions de diapositives ?**

Les Dispositions de diapositives fonctionnent en conjonction avec les Masques de diapositives pour offrir de la flexibilité dans la conception des diapositives. Alors qu’un Masque de diapositives définit les styles et thèmes généraux, les Dispositions permettent des variations dans l’agencement du contenu. La hiérarchie est la suivante :

- **Masque de diapositives** → Définit les styles globaux.
- **Disposition de diapositives** → Propose différents agencements de contenu.
- **Diapositive** → Hérite du design de sa Disposition de diapositives.

**Peut‑on avoir plusieurs Masques de diapositives dans une même présentation ?**

Oui, une présentation peut contenir plusieurs Masques de diapositives. Cela vous permet de styliser différentes sections d’une présentation de manières variées, offrant ainsi une grande flexibilité de conception.  

**Comment accéder et modifier un Masque de diapositives avec Aspose.Slides ?**

Dans Aspose.Slides, un Masque de diapositives est représenté par l’interface [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/). Vous pouvez accéder à un Masque de diapositives à l’aide de la méthode [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) de l’objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).