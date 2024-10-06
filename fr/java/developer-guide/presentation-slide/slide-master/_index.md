---
title: Maître de diapositive
type: docs
weight: 70
url: /java/slide-master/
keywords: "Ajouter Maître de diapositive, diapositive maître PPT, maître de diapositive PowerPoint, image au maître de diapositive, espace réservé, plusieurs maîtres de diapositive, comparer les maîtres de diapositive, Java, Aspose.Slides pour Java"
description: "Ajouter ou modifier le maître de diapositive dans une présentation PowerPoint en Java"
---

## **Qu'est-ce qu'un Maître de Diapositive dans PowerPoint**

Un **Maître de Diapositive** est un modèle de diapositive qui définit la disposition, les styles, le thème, les polices, l'arrière-plan et d'autres propriétés des diapositives dans une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et modèle pour votre entreprise, vous pouvez utiliser un maître de diapositive.

Un Maître de Diapositive est utile car il vous permet de définir et de modifier l'apparence de toutes les diapositives de la présentation d'un coup. Aspose.Slides prend en charge le mécanisme de Maître de Diapositive de PowerPoint.

VBA permet également de manipuler un Maître de Diapositive et d'exécuter les mêmes opérations prises en charge dans PowerPoint : changer les arrière-plans, ajouter des formes, personnaliser la mise en page, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d'utiliser des Maîtres de Diapositive et d'effectuer des tâches de base avec eux.

Voici les opérations de base sur le Maître de Diapositive :

- Créer ou Slide Master.
- Appliquer le Maître de Diapositive aux diapositives de présentation.
- Changer l'arrière-plan du Maître de Diapositive.
- Ajouter une image, un espace réservé, une œuvre intelligente, etc. au Maître de Diapositive.

Voici des opérations plus avancées impliquant le Maître de Diapositive :

- Comparer les Maîtres de Diapositive.
- Fusionner des Maîtres de Diapositive.
- Appliquer plusieurs Maîtres de Diapositive.
- Copier une diapositive avec le Maître de Diapositive vers une autre présentation.
- Identifier les Maîtres de Diapositive en double dans les présentations.
- Définir un Maître de Diapositive comme vue par défaut de la présentation.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter [**Visualiseur PowerPoint en ligne**](https://products.aspose.app/slides/viewer) d'Aspose car c'est une mise en œuvre en direct de certains des processus fondamentaux décrits ici.

{{% /alert %}} 

## **Comment le Maître de Diapositive est appliqué**

Avant de travailler avec un maître de diapositive, vous pouvez vouloir comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives.

* Chaque présentation a au moins un Maître de Diapositive par défaut.
* Une présentation peut contenir plusieurs Maîtres de Diapositive. Vous pouvez ajouter plusieurs Maîtres de Diapositive et les utiliser pour styliser différentes parties d'une présentation de différentes manières.

Dans **Aspose.Slides**, un Maître de Diapositive est représenté par le type [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/).

L'objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) d'Aspose.Slides contient la liste [**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) de type [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), qui contient une liste de toutes les diapositives maîtres définies dans une présentation.

En plus des opérations CRUD, l'interface [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) contient ces méthodes utiles : [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) et [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) . Ces méthodes sont héritées de la fonction de clonage de diapositive de base. Mais lorsqu'il s'agit de Maîtres de Diapositive, ces méthodes vous permettent de mettre en œuvre des configurations compliquées.

Lorsqu'une nouvelle diapositive est ajoutée à une présentation, un Maître de Diapositive lui est automatiquement appliqué. Le Maître de Diapositive de la diapositive précédente est sélectionné par défaut.

**Remarque** : Les diapositives de présentation sont stockées dans la liste [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation contient un seul Maître de Diapositive, ce maître de diapositive est sélectionné pour toutes les nouvelles diapositives. C'est la raison pour laquelle vous n'avez pas besoin de définir le Maître de Diapositive pour chaque nouvelle diapositive que vous créez.

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle présentation, vous pouvez simplement cliquer sur la ligne du bas sous la dernière diapositive et une nouvelle diapositive (avec le Maître de Diapositive de la dernière présentation) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez effectuer la tâche équivalente avec la méthode [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).


## **Maître de Diapositive dans la hiérarchie des diapositives**

L'utilisation des mises en page de diapositive avec le Maître de Diapositive permet une flexibilité maximale. Une Mise en page de Diapositive vous permet de définir tous les mêmes styles que le Maître de Diapositive (arrière-plan, polices, formes, etc.). Cependant, lorsque plusieurs Mises en page de Diapositive sont combinées dans un Maître de Diapositive, un nouveau style est créé. Lorsque vous appliquez une Mise en page de Diapositive à une seule diapositive, vous pouvez modifier son style par rapport à celui appliqué par le Maître de Diapositive.

Le Maître de Diapositive prévaut sur tous les éléments de configuration : Maître de Diapositive -> Mise en page de Diapositive -> Diapositive :

![todo:image_alt_text](slide-master_2)

Chaque [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) possède une propriété [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) avec une liste de Mises en page de Diapositive. Un type [Diapositive](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) a une propriété [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) avec un lien vers une Mise en page de Diapositive appliquée à la diapositive. L'interaction entre une diapositive et le Maître de Diapositive se produit à travers une Mise en page de Diapositive.

{{% alert color="info" title="Remarque" %}}

* Dans Aspose.Slides, toutes les configurations de diapositive (Maître de Diapositive, Mise en page de Diapositive, et la diapositive elle-même) sont en réalité des objets de diapositive implémentant l'interface [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide).
* Par conséquent, le Maître de Diapositive et la Mise en page de Diapositive peuvent implémenter les mêmes propriétés et vous devez savoir comment leurs valeurs seront appliquées à un objet [Diapositive](https://reference.aspose.com/slides/java/com.aspose.slides/Slide). Le Maître de Diapositive est appliqué en premier à une diapositive, puis la Mise en page de Diapositive est appliquée. Par exemple, si le Maître de Diapositive et la Mise en page de Diapositive ont tous deux une valeur d'arrière-plan, la Diapositive finira par avoir l'arrière-plan provenant de la Mise en page de Diapositive.

{{% /alert %}}


## **Ce que comprend un Maître de Diapositive**

Pour comprendre comment un Maître de Diapositive peut être modifié, vous devez connaître ses composants. Voici les propriétés essentielles de [MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) obtenir/définir l'arrière-plan de la diapositive.
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) - obtenir/définir les styles de texte du corps de la diapositive.
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) obtenir/définir toutes les formes du Maître de Diapositive (espaces réservés, cadres d'image, etc.).
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) obtenir/définir les contrôles ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) - obtenir le gestionnaire de thème.
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - obtenir le gestionnaire des en-têtes et pieds de page.

Méthodes du Maître de Diapositive :

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) - obtenir toutes les diapositives dépendant du Maître de Diapositive.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - vous permet de créer un nouveau Maître de Diapositive basé sur le Maître de Diapositive actuel et un nouveau thème. Le nouveau Maître de Diapositive sera ensuite appliqué à toutes les diapositives dépendantes.


## **Obtenir le Maître de Diapositive**

Dans PowerPoint, le Maître de Diapositive peut être accédé depuis le menu Affichage -> Maître de Diapositive :

![todo:image_alt_text](slide-master_3.jpg)

En utilisant Aspose.Slides, vous pouvez accéder à un Maître de Diapositive de cette manière : 

```java
Presentation pres = new Presentation();
try {
    // Donne accès au maître de diapositive de la présentation
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

L'interface [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) représente un Maître de Diapositive. La propriété [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) (relative à [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) ) contient une liste de tous les Maîtres de Diapositive définis dans la présentation.


## **Ajouter une image au Maître de Diapositive**

Lorsque vous ajoutez une image à un Maître de Diapositive, cette image apparaîtra sur toutes les diapositives dépendantes de ce maître de diapositive.

Par exemple, vous pouvez placer le logo de votre entreprise et quelques images sur le Maître de Diapositive, puis revenir au mode d'édition des diapositives. Vous devriez voir l'image sur chaque diapositive.

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un maître de diapositive avec Aspose.Slides :

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

Pour plus d'informations sur l'ajout d'images à une diapositive, consultez l'article [Image Frame](/slides/java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Ajouter un espace réservé au Maître de Diapositive**

Ces champs de texte sont des espaces réservés standard sur un Maître de Diapositive :

* Cliquez pour modifier le style de titre maître

* Modifier les styles de texte maître

* Deuxième niveau

* Troisième niveau 

  Ils apparaissent également sur les diapositives basées sur le Maître de Diapositive. Vous pouvez modifier ces espaces réservés sur un Maître de Diapositive et les changements seront appliqués automatiquement aux diapositives.

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin Maître de Diapositive -> Insérer un espace réservé :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus compliqué pour les espaces réservés avec Aspose.Slides. Considérons une diapositive avec des espaces réservés templates du Maître de Diapositive :

![todo:image_alt_text](slide-master_6.png)

Nous voulons changer le formatage du Titre et du Sous-titre sur le Maître de Diapositive de cette manière :

![todo:image_alt_text](slide-master_7.png)

Tout d'abord, nous récupérons le contenu de l'espace réservé de titre à partir de l'objet Maître de Diapositive, puis nous utilisons le champ `PlaceHolder.FillFormat` : 

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

Le style et le formatage du titre changeront pour toutes les diapositives basées sur le maître de diapositive :

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Voir aussi" %}} 

* [Définir le texte d'invite dans l'espace réservé](https://docs.aspose.com/slides/java/manage-placeholder/)
* [Formatage du texte](https://docs.aspose.com/slides/java/text-formatting/)

{{% /alert %}}


## **Changer l'arrière-plan sur le Maître de Diapositive**

Lorsque vous changez la couleur d'arrière-plan d'un maître de diapositive, toutes les diapositives normales de la présentation recevront la nouvelle couleur. Ce code Java démontre l'opération :

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

- [Arrière-plan de présentation](https://docs.aspose.com/slides/java/presentation-background/)

- [Thème de présentation](https://docs.aspose.com/slides/java/presentation-theme/)

  {{% /alert %}}

## **Cloner le Maître de Diapositive vers une autre présentation**

Pour cloner un Maître de Diapositive vers une autre présentation, appelez la méthode [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) de la présentation de destination en passant un Maître de Diapositive à celui-ci. Ce code Java vous montre comment cloner un Maître de Diapositive vers une autre présentation :

```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```


## **Ajouter Plusieurs Maîtres de Diapositive à la Présentation**

Aspose.Slides vous permet d'ajouter plusieurs Maîtres de Diapositive et Mises en page à toute présentation donnée. Cela vous permet de configurer des styles, des mises en page et des options de formatage pour les diapositives de présentation de plusieurs manières.

Dans PowerPoint, vous pouvez ajouter de nouveaux Maîtres de Diapositive et Mises en page (depuis le menu "Maître de Diapositive) de cette manière :

![todo:image_alt_text](slide-master_9.jpg)

En utilisant Aspose.Slides, vous pouvez ajouter un nouveau Maître de Diapositive en appelant la méthode [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) :

```java
// Ajoute un nouveau maître de diapositive
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **Comparer les Maîtres de Diapositive**

Un Maître de Diapositive implémente l'interface [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) contenant la méthode [**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), qui peut alors être utilisée pour comparer les diapositives. Elle retourne `true` pour les Maîtres de Diapositive identiques dans leur structure et leur contenu statique.

Deux Maîtres de Diapositive sont égaux si leurs formes, styles, textes, animations et autres paramètres, etc. sont égaux. La comparaison ne prend pas en compte les valeurs d'identifiant unique (par ex. SlideId) et le contenu dynamique (par ex. la valeur actuelle de date dans l'espace réservé de Date).

## **Définir le Maître de Diapositive comme vue par défaut de la Présentation**

Aspose.Slides vous permet de définir un Maître de Diapositive comme vue par défaut pour une présentation. La vue par défaut est ce que vous voyez en premier lorsque vous ouvrez une présentation.

Ce code vous montre comment définir un Maître de Diapositive comme vue par défaut d'une présentation en Java :

```java
// Instancie une classe Presentation qui représente le fichier de présentation
Presentation presentation = new Presentation();
try {
    // Définit la vue par défaut comme SlideMasterView
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // Enregistre la présentation
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Supprimer les Maîtres de Diapositive non utilisés**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) ) pour vous permettre de supprimer des maîtres de diapositive non désirés et non utilisés. Ce code Java vous montre comment supprimer un maître de diapositive d'une présentation PowerPoint :

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```