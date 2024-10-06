---
title: Modèle de Diapositive
type: docs
weight: 70
url: /androidjava/slide-master/
keywords: "Ajouter Modèle de Diapositive, diapositive maître PPT, modèle de diapositive PowerPoint, image au Modèle de Diapositive, espace réservé, plusieurs Modèles de Diapositive, comparer les Modèles de Diapositive, Java, Aspose.Slides pour Android via Java"
description: "Ajouter ou modifier le modèle de diapositive dans une présentation PowerPoint en Java"
---

## **Qu'est-ce qu'un Modèle de Diapositive dans PowerPoint**

Un **Modèle de Diapositive** est un modèle de diapositive qui définit la mise en page, les styles, le thème, les polices, l'arrière-plan et d'autres propriétés pour les diapositives d'une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et modèle pour votre entreprise, vous pouvez utiliser un modèle de diapositive.

Un Modèle de Diapositive est utile car il permet de définir et de modifier l'apparence de toutes les diapositives d'une présentation en une seule fois. Aspose.Slides prend en charge le mécanisme de Modèle de Diapositive de PowerPoint.

VBA permet également de manipuler un Modèle de Diapositive et d'exécuter les mêmes opérations prises en charge dans PowerPoint : changer les arrière-plans, ajouter des formes, personnaliser la mise en page, etc. Aspose.Slides offre des mécanismes flexibles pour vous permettre d'utiliser des Modèles de Diapositive et d'effectuer des tâches de base avec eux.

Voici les opérations de base concernant le Modèle de Diapositive :

- Créer ou Modifier un Modèle de Diapositive.
- Appliquer un Modèle de Diapositive aux diapositives de la présentation.
- Changer l'arrière-plan du Modèle de Diapositive.
- Ajouter une image, un espace réservé, un Smart Art, etc. au Modèle de Diapositive.

Voici des opérations plus avancées impliquant le Modèle de Diapositive :

- Comparer des Modèles de Diapositive.
- Fusionner des Modèles de Diapositive.
- Appliquer plusieurs Modèles de Diapositive.
- Copier une diapositive avec un Modèle de Diapositive vers une autre présentation.
- Découvrir les Modèles de Diapositive en double dans les présentations.
- Définir un Modèle de Diapositive comme la vue par défaut de la présentation.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter Aspose [**Visualiseur PowerPoint en ligne**](https://products.aspose.app/slides/viewer) car il s'agit d'une mise en œuvre en direct de certains des processus fondamentaux décrits ici.

{{% /alert %}} 

## **Comment le Modèle de Diapositive est-il appliqué**

Avant de travailler avec un modèle de diapositive, vous souhaiterez peut-être comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives.

* Chaque présentation a par défaut au moins un Modèle de Diapositive.
* Une présentation peut contenir plusieurs Modèles de Diapositive. Vous pouvez ajouter plusieurs Modèles de Diapositive et les utiliser pour styliser différentes parties d'une présentation de différentes manières.

Dans **Aspose.Slides**, un Modèle de Diapositive est représenté par le type [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).

L'objet [Présentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) d'Aspose.Slides contient la liste des [**getMasters** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) de type [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), qui contient une liste de toutes les diapositives maîtresses définies dans une présentation.

En plus des opérations CRUD, l'interface [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) contient ces méthodes utiles : [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) et [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) . Ces méthodes sont héritées de la fonction de clonage de diapositive de base. Mais lors de la manipulation des Modèles de Diapositive, ces méthodes vous permettent de mettre en œuvre des configurations compliquées.

Lorsqu'une nouvelle diapositive est ajoutée à une présentation, un Modèle de Diapositive lui est appliqué automatiquement. Le Modèle de Diapositive de la diapositive précédente est sélectionné par défaut.

**Remarque** : Les diapositives de présentation sont stockées dans la liste [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation ne contient qu'un seul Modèle de Diapositive, ce modèle est sélectionné pour toutes les nouvelles diapositives. C'est pourquoi vous n'avez pas à définir le Modèle de Diapositive pour chaque nouvelle diapositive que vous créez.

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle présentation, vous pouvez simplement appuyer sur la ligne du bas sous la dernière diapositive, puis une nouvelle diapositive (avec le Modèle de Diapositive de la dernière présentation) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez effectuer la tâche équivalente avec la méthode [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) de la classe [Présentation ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).

## **Modèle de Diapositive dans la hiérarchie des Diapositives**

L'utilisation de Dispositions de Diapositives avec le Modèle de Diapositive permet une flexibilité maximale. Une Disposition de Diapositive vous permet de définir tous les mêmes styles que le Modèle de Diapositive (arrière-plan, polices, formes, etc.). Cependant, lorsque plusieurs Dispositions de Diapositives sont combinées sur un Modèle de Diapositive, un nouveau style est créé. Lorsque vous appliquez une Disposition de Diapositive à une diapositive unique, vous pouvez modifier son style par rapport à celui appliqué par le Modèle de Diapositive.

Le Modèle de Diapositive a la priorité sur tous les éléments de configuration : Modèle de Diapositive -> Disposition de Diapositive -> Diapositive :

![todo:image_alt_text](slide-master_2)

Chaque [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) a une propriété [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) avec une liste de Dispositions de Diapositives. Un type [Diapositive](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) a une propriété [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) avec un lien vers une Disposition de Diapositive appliquée à la diapositive. L'interaction entre une diapositive et le Modèle de Diapositive se fait via une Disposition de Diapositive.

{{% alert color="info" title="Remarque" %}}

* Dans Aspose.Slides, toutes les configurations de diapositive (Modèle de Diapositive, Disposition de Diapositive, et la diapositive elle-même) sont en réalité des objets diapositive implémentant l'interface [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide).
* Par conséquent, le Modèle de Diapositive et la Disposition de Diapositive peuvent implémenter les mêmes propriétés et vous devez savoir comment leurs valeurs seront appliquées à un objet [Diapositive](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide). Le Modèle de Diapositive est appliqué en premier à une diapositive, puis la Disposition de Diapositive est appliquée. Par exemple, si le Modèle de Diapositive et la Disposition de Diapositive ont tous deux une valeur d'arrière-plan, la Diapositive se retrouvera avec l'arrière-plan provenant de la Disposition de Diapositive.

{{% /alert %}}

## **Ce que comprend un Modèle de Diapositive**

Pour comprendre comment un Modèle de Diapositive peut être modifié, vous devez connaître ses constituants. Voici les propriétés fondamentales de [MasterSlide](https://reference.aspose.com/slides/androidjava/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) obtenir/définir l'arrière-plan de la diapositive.
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) - obtenir/définir les styles de texte du corps de la diapositive.
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) obtenir/définir toutes les formes du Modèle de Diapositive (espaces réservés, cadres photo, etc.).
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) obtenir/définir les contrôles ActiveX.
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) - obtenir le gestionnaire de thème.
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - obtenir le gestionnaire d'en-tête et de pied de page.

Méthodes du Modèle de Diapositive :

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) - obtenir toutes les Diapositives dépendant du Modèle de Diapositive.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - vous permet de créer un nouveau Modèle de Diapositive basé sur le Modèle de Diapositive actuel et un nouveau thème. Le nouveau Modèle de Diapositive sera ensuite appliqué à toutes les diapositives dépendantes.

## **Obtenir le Modèle de Diapositive**

Dans PowerPoint, le Modèle de Diapositive peut être accédé via le menu Affichage -> Modèle de Diapositive :

![todo:image_alt_text](slide-master_3.jpg)

En utilisant Aspose.Slides, vous pouvez accéder à un Modèle de Diapositive de cette manière : 

```java
Presentation pres = new Presentation();
try {
    // Accès au modèle de diapositive de la présentation
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

L'interface [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) représente un Modèle de Diapositive. La propriété [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) (relative à [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) type) contient une liste de tous les Modèles de Diapositive qui sont définis dans la présentation.

## **Ajouter une Image au Modèle de Diapositive**

Lorsque vous ajoutez une image à un Modèle de Diapositive, cette image apparaîtra sur toutes les diapositives dépendant de ce modèle de diapositive.

Par exemple, vous pouvez placer le logo de votre entreprise et quelques images sur le Modèle de Diapositive, puis revenir à la mode d'édition des diapositives. Vous devriez voir l'image sur chaque diapositive.

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un modèle de diapositive avec Aspose.Slides :

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

Pour plus d'informations sur l'ajout d'images à une diapositive, consultez l'article [Cadre d'image](/slides/androidjava/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Ajouter un Espace Réservé au Modèle de Diapositive**

Ces champs de texte sont des espaces réservés standards sur un Modèle de Diapositive :

* Cliquez pour modifier le style du titre principal

* Modifier les styles de texte principaux

* Deuxième niveau

* Troisième niveau 

Ils apparaissent également sur les diapositives basées sur le Modèle de Diapositive. Vous pouvez modifier ces espaces réservés sur un Modèle de Diapositive et les changements sont automatiquement appliqués aux diapositives.

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin Modèle de Diapositive -> Insérer un espace réservé :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus compliqué pour les espaces réservés avec Aspose.Slides. Considérez une diapositive avec des espaces réservés issus du Modèle de Diapositive :

![todo:image_alt_text](slide-master_6.png)

Nous voulons modifier le formatage du Titre et du Sous-titre sur le Modèle de Diapositive de cette manière :

![todo:image_alt_text](slide-master_7.png)

Tout d'abord, nous récupérons le contenu de l'espace réservé du titre à partir de l'objet Modèle de Diapositive, puis utilisons le champ `PlaceHolder.FillFormat` : 

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

Le style et le formatage du titre changeront pour toutes les diapositives basées sur le modèle de diapositive :

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Voir aussi" %}} 

* [Définir le Texte d'Invité dans l'Espace Réservé](https://docs.aspose.com/slides/androidjava/manage-placeholder/)
* [Formatage du Texte](https://docs.aspose.com/slides/androidjava/text-formatting/)

{{% /alert %}}

## **Changer l'Arrière-plan sur le Modèle de Diapositive**

Lorsque vous changez la couleur d'arrière-plan d'un modèle de diapositive, toutes les diapositives normales de la présentation recevront la nouvelle couleur. Ce code Java démontre l'opération :

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

- [Arrière-plan de la Présentation](https://docs.aspose.com/slides/androidjava/presentation-background/)

- [Thème de la Présentation](https://docs.aspose.com/slides/androidjava/presentation-theme/)

  {{% /alert %}}

## **Cloner un Modèle de Diapositive vers une Autre Présentation**

Pour cloner un Modèle de Diapositive vers une autre présentation, appelez la méthode [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) de la présentation destination, en passant un Modèle de Diapositive. Ce code Java montre comment cloner un Modèle de Diapositive vers une autre présentation :

```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```

## **Ajouter Plusieurs Modèles de Diapositive à la Présentation**

Aspose.Slides vous permet d'ajouter plusieurs Modèles de Diapositive et Dispositions de Diapositive à une présentation donnée. Cela vous permet de configurer des styles, des mises en page et des options de formatage pour les diapositives de présentation de nombreuses manières.

Dans PowerPoint, vous pouvez ajouter de nouveaux Modèles de Diapositive et Dispositions (à partir du menu "Modèle de Diapositive") de cette manière :

![todo:image_alt_text](slide-master_9.jpg)

En utilisant Aspose.Slides, vous pouvez ajouter un nouveau Modèle de Diapositive en appelant la méthode [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) :

```java
// Ajoute un nouveau modèle de diapositive
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```

## **Comparer des Modèles de Diapositive**

Un Modèle de Diapositive implémente l'interface [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) contenant la méthode [**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-), qui peut ensuite être utilisée pour comparer des diapositives. Elle retourne `true` pour les Modèles de Diapositive identiques en termes de structure et de contenu statique.

Deux Modèles de Diapositive sont considérés comme égaux si leurs formes, styles, textes, animations et autres paramètres, etc., sont égaux. La comparaison ne prend pas en compte les valeurs d'identificateur uniques (par exemple, SlideId) et le contenu dynamique (par exemple, la valeur actuelle de la date dans l'Espace Réservé Date).

## **Définir le Modèle de Diapositive comme Vue par Défaut de la Présentation**

Aspose.Slides vous permet de définir un Modèle de Diapositive comme la vue par défaut pour une présentation. La vue par défaut est ce que vous voyez en premier lorsque vous ouvrez une présentation.

Ce code montre comment définir un Modèle de Diapositive comme vue par défaut d'une présentation en Java :

```java
// Instancie une classe Présentation représentant le fichier de présentation
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

## **Supprimer les Diapositives Maîtresses Non Utilisées**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la classe [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) pour vous permettre de supprimer les diapositives maîtresses non désirées et inutilisées. Ce code Java montre comment supprimer un modèle de diapositive d'une présentation PowerPoint :

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```