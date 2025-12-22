---
title: Gestion des masques de diapositives de présentation sur Android
linktitle: Masque de diapositive
type: docs
weight: 70
url: /fr/androidjava/slide-master/
keywords:
- masque de diapositive
- diapositive maître
- diapositive maître PPT
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
- Android
- Java
- Aspose.Slides
description: "Gérez les masques de diapositives dans Aspose.Slides pour Android : créez, modifiez et appliquez des mises en page, des thèmes et des espaces réservés aux fichiers PPT, PPTX et ODP avec des exemples Java concis."
---

## **Qu’est‑ce qu’un masque de diapositive dans PowerPoint**

Un **masque de diapositive** est un modèle de diapositive qui définit la mise en page, les styles, le thème, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et le même modèle pour votre entreprise, vous pouvez utiliser un masque de diapositive.  

Un masque de diapositive est utile car il vous permet de définir et de modifier l’apparence de toutes les diapositives d’une présentation en une seule fois. Aspose.Slides prend en charge le mécanisme de masque de diapositive de PowerPoint.  

VBA vous permet également de manipuler un masque de diapositive et d’exécuter les mêmes opérations que PowerPoint : modifier les arrière‑plans, ajouter des formes, personnaliser la mise en page, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d’utiliser les masques de diapositive et d’exécuter les tâches de base avec eux.  

Voici les opérations de base sur les masques de diapositive :

- Créer ou **Slide Master**.
- Appliquer le **Slide Master** aux diapositives de la présentation.
- Modifier l’arrière‑plan du **Slide Master**. 
- Ajouter une image, un espace réservé, un Smart Art, etc. au **Slide Master**.

Voici des opérations plus avancées impliquant le masque de diapositive :  

- Comparer des masques de diapositive.
- Fusionner des masques de diapositive.
- Appliquer plusieurs masques de diapositive.
- Copier une diapositive avec son masque vers une autre présentation.
- Rechercher les masques de diapositive en double dans les présentations.
- Définir le masque de diapositive comme vue par défaut de la présentation.

{{% alert color="primary" %}} 

Vous pouvez consulter l’[**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) d’Aspose car il s’agit d’une implémentation en direct de certains des processus décrits ici.

{{% /alert %}} 


## **Comment un masque de diapositive est‑il appliqué**

Avant de travailler avec un masque de diapositive, vous devez comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives.  

* Chaque présentation possède au moins un masque de diapositive par défaut. 
* Une présentation peut contenir plusieurs masques de diapositive. Vous pouvez ajouter plusieurs masques et les utiliser pour styliser différentes parties d’une présentation de manières différentes. 

Dans **Aspose.Slides**, un masque de diapositive est représenté par le type [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/).  

L’objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) d’Aspose.Slides contient la liste [**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) de type [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), qui contient toutes les diapositives maîtres définies dans une présentation.  

Outre les opérations CRUD, l’interface [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) propose les méthodes utiles : [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) et [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Ces méthodes proviennent de la fonction de clonage de diapositive de base. Mais lorsqu’on travaille avec des masques de diapositive, elles permettent de mettre en œuvre des configurations complexes.  

Lorsqu’une nouvelle diapositive est ajoutée à une présentation, un masque de diapositive lui est appliqué automatiquement. Le masque de la diapositive précédente est sélectionné par défaut.  

**Note** : Les diapositives de la présentation sont stockées dans la liste [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--), et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation ne contient qu’un seul masque de diapositive, ce masque est choisi pour toutes les nouvelles diapositives. C’est pourquoi vous n’avez pas besoin de définir le masque de diapositive pour chaque nouvelle diapositive que vous créez.  

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle diapositive, vous pouvez simplement cliquer sur la ligne inférieure sous la dernière diapositive et une nouvelle diapositive (avec le même masque que la présentation précédente) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez réaliser la même opération avec la méthode [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).  


## **Masque de diapositive dans la hiérarchie des diapositives**

Utiliser les mises en page de diapositive avec le masque de diapositive permet une flexibilité maximale. Une mise en page de diapositive vous permet de définir les mêmes styles que le masque de diapositive (arrière‑plan, polices, formes, etc.). Cependant, lorsque plusieurs mises en page sont combinées sur un même masque, un nouveau style est créé. Lorsque vous appliquez une mise en page à une diapositive unique, vous pouvez modifier son style par rapport à celui appliqué par le masque.  

Le masque de diapositive domine tous les éléments de configuration : Masque → Mise en page → Diapositive :

![todo:image_alt_text](slide-master_2)



Chaque objet [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) possède la propriété [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) qui renvoie une liste de mises en page de diapositive. Un objet de type [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) possède la propriété [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) qui indique la mise en page appliquée à la diapositive. L’interaction entre une diapositive et le masque se fait via la mise en page.  

{{% alert color="info" title="Note" %}}

* Dans Aspose.Slides, toutes les configurations de diapositive (masque, mise en page et diapositive elle‑même) sont en réalité des objets de diapositive implémentant l’interface [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide).  
* Ainsi, le masque et la mise en page peuvent partager les mêmes propriétés et vous devez savoir comment leurs valeurs seront appliquées à un objet [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide). Le masque est appliqué en premier, puis la mise en page. Par exemple, si le masque et la mise en page définissent tous deux une couleur d’arrière‑plan, la diapositive affichera l’arrière‑plan de la mise en page.

{{% /alert %}}


## **Contenu d’un masque de diapositive**

Pour comprendre comment modifier un masque, vous devez connaître ses constituants. Voici les propriétés de base du [MasterSlide](https://reference.aspose.com/slides/androidjava/aspose.slides/masterslide/) :

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) : obtient/definit l’arrière‑plan de la diapositive.  
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) : obtient/definit les styles de texte du corps de la diapositive.  
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) : obtient/definit toutes les formes du masque (espaces réservés, cadres d’image, etc.).  
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) : obtient/definit les contrôles ActiveX.  
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) : obtient le gestionnaire de thème.  
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) : obtient le gestionnaire d’en‑têtes et de pieds de page.  

Méthodes du masque de diapositive :

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) : obtient toutes les diapositives dépendant du masque.  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) : permet de créer un nouveau masque basé sur le masque actuel et un nouveau thème. Le nouveau masque sera alors appliqué à toutes les diapositives dépendantes.  


## **Obtenir un masque de diapositive**

Dans PowerPoint, le masque se trouve dans le menu **Affichage → Masque des diapositives** :

![todo:image_alt_text](slide-master_3.jpg)



Avec Aspose.Slides, vous pouvez accéder à un masque ainsi :  
```java
Presentation pres = new Presentation();
try {
    // Donne accès au masque maître de la présentation
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


L’interface [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) représente un masque de diapositive. La propriété [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) (lié au type [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)) contient la liste de tous les masques définis dans la présentation.  


## **Ajouter une image à un masque de diapositive**

Lorsque vous ajoutez une image à un masque, celle‑ci apparaît sur toutes les diapositives dépendant du masque.  

Par exemple, vous pouvez placer le logo de votre société et quelques images sur le masque, puis revenir en mode édition : l’image sera visible sur chaque diapositive.  

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un masque avec Aspose.Slides :  
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

Pour plus d’informations sur l’ajout d’images à une diapositive, consultez l’article [Picture Frame](/slides/fr/androidjava/picture-frame/#create-picture-frame).

{{% /alert %}}


## **Ajouter un espace réservé à un masque de diapositive**

Ces champs de texte sont des espaces réservés standards sur un masque :  

* Cliquez pour modifier le style du titre du maître  
* Modifier les styles de texte du maître  
* Niveau 2  
* Niveau 3  

Ils apparaissent également sur les diapositives basées sur le masque. Vous pouvez les modifier sur le masque et les changements seront appliqués automatiquement aux diapositives.  

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin **Masque des diapositives → Insérer un espace réservé** :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus complexe d’espaces réservés avec Aspose.Slides. Considérons une diapositive avec des espaces réservés provenant du masque :

![todo:image_alt_text](slide-master_6.png)

Nous voulons modifier le format du titre et du sous‑titre sur le masque ainsi :

![todo:image_alt_text](slide-master_7.png)

Tout d’abord, nous récupérons le contenu du titre depuis l’objet masque puis utilisons le champ `PlaceHolder.FillFormat` :  
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


Le style et le format du titre changeront pour toutes les diapositives basées sur le masque :

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/androidjava/manage-placeholder/)  
* [Text Formatting](https://docs.aspose.com/slides/androidjava/text-formatting/)

{{% /alert %}}


## **Modifier l’arrière‑plan d’un masque de diapositive**

Lorsque vous changez la couleur d’arrière‑plan d’un masque, toutes les diapositives normales de la présentation adoptent la nouvelle couleur. Ce code Java montre l’opération :  
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

- [Presentation Background](https://docs.aspose.com/slides/androidjava/presentation-background/)  
- [Presentation Theme](https://docs.aspose.com/slides/androidjava/presentation-theme/)

{{% /alert %}}

## **Cloner un masque de diapositive vers une autre présentation**

Pour cloner un masque vers une autre présentation, appelez la méthode [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) de la présentation de destination en lui passant le masque à cloner. Ce code Java montre comment cloner un masque vers une autre présentation :  
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```



## **Ajouter plusieurs masques de diapositive à une présentation**

Aspose.Slides vous permet d’ajouter plusieurs masques et plusieurs mises en page à une même présentation. Cela vous permet de configurer styles, mises en page et options de formatage de nombreuses façons.  

Dans PowerPoint, vous pouvez ajouter de nouveaux masques et mises en page (depuis le **menu Masque des diapositives**) ainsi :

![todo:image_alt_text](slide-master_9.jpg)

Avec Aspose.Slides, vous pouvez ajouter un nouveau masque en appelant la méthode [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) :  
```java
// Ajoute une nouvelle diapositive maître
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **Comparer des masques de diapositive**

Un masque implémente l’interface [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) qui possède la méthode [**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-). Elle permet de comparer deux masques. Elle renvoie `true` lorsque les masques sont identiques en structure et en contenu statique.  

Deux masques sont égaux si leurs formes, styles, textes, animations et autres paramètres sont identiques. La comparaison n’inclut pas les identifiants uniques (par ex. SlideId) ni le contenu dynamique (par ex. date actuelle dans un espace réservé).  


## **Définir un masque comme vue par défaut de la présentation**

Aspose.Slides permet de définir un masque comme vue par défaut d’une présentation. La vue par défaut est ce que vous voyez en ouvrant la présentation.  

Ce code montre comment définir un masque comme vue par défaut en Java :  
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



## **Supprimer les masques inutilisés**

Aspose.Slides fournit la méthode [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (classe [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) pour supprimer les masques superflus. Ce code Java montre comment supprimer un masque d’une présentation :  
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

**Qu’est‑ce qu’un masque de diapositive dans PowerPoint ?**

Un masque de diapositive est un modèle qui définit la mise en page, les styles, les thèmes, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Il permet de définir et de modifier l’apparence de toutes les diapositives en une seule fois.  

**Comment le masque de diapositive est‑il appliqué dans une présentation ?**

Chaque présentation possède au moins un masque par défaut. Lorsqu’une nouvelle diapositive est ajoutée, le masque est appliqué automatiquement, généralement celui de la diapositive précédente. Une présentation peut contenir plusieurs masques pour styliser différemment diverses sections.  

**Quels éléments peuvent être personnalisés dans un masque de diapositive ?**

Un masque comprend plusieurs propriétés de base pouvant être personnalisées :

- **Background** : définir l’arrière‑plan.  
- **BodyStyle** : définir les styles de texte du corps.  
- **Shapes** : gérer toutes les formes, y compris les espaces réservés et les cadres d’image.  
- **Controls** : gérer les contrôles ActiveX.  
- **ThemeManager** : accéder au gestionnaire de thème.  
- **HeaderFooterManager** : gérer les en‑têtes et pieds de page.  

**Comment ajouter une image à un masque de diapositive ?**

Ajouter une image au masque la rend visible sur toutes les diapositives qui en dépendent. Par exemple, placer le logo de l’entreprise sur le masque l’affichera sur chaque diapositive de la présentation.  

**Comment les masques de diapositive sont‑ils liés aux mises en page ?**

Les mises en page travaillent avec les masques pour offrir de la flexibilité. Le masque définit les styles globaux ; les mises en page permettent des variations d’agencement du contenu. La hiérarchie est :

- **Masque de diapositive** → styles globaux.  
- **Mise en page** → agencements de contenu différents.  
- **Diapositive** → hérite du design de sa mise en page.  

**Puis‑je avoir plusieurs masques dans une même présentation ?**

Oui, une présentation peut contenir plusieurs masques, ce qui permet de styliser différentes sections de manières variées.  

**Comment accéder et modifier un masque avec Aspose.Slides ?**

Dans Aspose.Slides, un masque est représenté par l’interface [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/). Vous pouvez y accéder via la méthode [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) de l’objet [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).