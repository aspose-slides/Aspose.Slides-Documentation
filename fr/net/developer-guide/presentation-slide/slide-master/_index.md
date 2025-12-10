---
title: Gérer les masques de diapositives de présentation en .NET
linktitle: Masque de diapositive
type: docs
weight: 80
url: /fr/net/slide-master/
keywords:
- masque de diapositive
- diapositive maître
- diapositive maître PPT
- plusieurs diapositives maîtres
- comparer les diapositives maîtres
- arrière-plan
- espace réservé
- cloner la diapositive maître
- copier la diapositive maître
- dupliquer la diapositive maître
- diapositive maître inutilisée
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérer les masques de diapositives dans Aspose.Slides pour .NET : créer, modifier et appliquer des mises en page, des thèmes et des espaces réservés aux fichiers PPT, PPTX et ODP avec des exemples C# concis."
---

## **Qu'est-ce qu'un masque de diapositive dans PowerPoint**
Un **masque de diapositive** dans PowerPoint est une fonctionnalité qui contrôle la disposition, les polices et les styles sur plusieurs diapositives. Il permet de maintenir la cohérence et l’image de marque dans les présentations. Si vous voulez créer une présentation (ou une série de présentations) avec le même style et le même modèle pour votre entreprise, vous pouvez utiliser un masque de diapositive. 

Un masque de diapositive est utile car il vous permet de définir et de modifier l’aspect de toutes les diapositives de la présentation en une seule fois. Aspose.Slides prend en charge le mécanisme de masque de diapositive de PowerPoint. 

VBA vous permet également de manipuler un masque de diapositive et d’exécuter les mêmes opérations prises en charge dans PowerPoint : modifier les arrière-plans, ajouter des formes, personnaliser la disposition, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d’utiliser les masques de diapositives et d’effectuer des tâches de base avec eux. 

Voici les opérations de base sur les masques de diapositives :

- Créer un masque de diapositive.
- Appliquer le masque de diapositives aux diapositives de la présentation.
- Modifier l’arrière-plan du masque de diapositive. 
- Ajouter une image, un espace réservé, SmartArt, etc. au masque de diapositive.

Voici des opérations plus avancées impliquant les masques de diapositives : 

- Comparer des masques de diapositives.
- Fusionner des masques de diapositives.
- Appliquer plusieurs masques de diapositives.
- Copier une diapositive avec masque de diapositive vers une autre présentation.
- Détecter les masques de diapositives dupliqués dans les présentations.
- Définir le masque de diapositive comme affichage par défaut de la présentation.

{{% alert color="primary" %}} 

Vous pouvez consulter l’[**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) d’Aspose car il s’agit d’une implémentation en direct de certains des processus principaux décrits ici.

{{% /alert %}} 


## **Comment un masque de diapositive est appliqué**
Avant de travailler avec un masque de diapositive, vous voudrez peut‑être comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives. 

* Chaque présentation possède au moins un masque de diapositive par défaut. 
* Une présentation peut contenir plusieurs masques de diapositives. Vous pouvez ajouter plusieurs masques de diapositives et les utiliser pour styliser différentes parties d’une présentation de manières différentes. 

Dans **Aspose.Slides**, un masque de diapositive est représenté par le type [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide). 

L’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) d’Aspose.Slides contient la liste [**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) de type [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), qui contient la liste de tous les masques de diapositives définis dans une présentation. 

Outre les opérations CRUD, l’interface [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) comprend ces méthodes utiles : [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) et [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). Ces méthodes sont héritées de la fonction de clonage de diapositive de base. Mais lorsqu’on travaille avec des masques de diapositives, ces méthodes vous permettent de mettre en œuvre des configurations complexes. 

Lorsqu’une nouvelle diapositive est ajoutée à une présentation, un masque de diapositive lui est appliqué automatiquement. Le masque de diapositive de la diapositive précédente est sélectionné par défaut. 

**Note** : Les diapositives de la présentation sont stockées dans la liste [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation ne contient qu’un seul masque de diapositive, ce masque est sélectionné pour toutes les nouvelles diapositives. C’est la raison pour laquelle vous n’avez pas besoin de définir le masque de diapositive pour chaque nouvelle diapositive que vous créez.

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle présentation, vous pouvez simplement cliquer sur la ligne inférieure sous la dernière diapositive et une nouvelle diapositive (avec le masque de diapositive de la dernière présentation) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez réaliser la même tâche avec la méthode [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).


## **Masque de diapositive dans la hiérarchie des diapositives**
L’utilisation des dispositions de diapositive avec le masque de diapositive permet la plus grande flexibilité. Une disposition de diapositive vous permet de définir tous les mêmes styles que le masque de diapositive (arrière‑plan, polices, formes, etc.). Cependant, lorsque plusieurs dispositions de diapositive sont combinées sur un masque de diapositive, un nouveau style est créé. Lorsque vous appliquez une disposition de diapositive à une seule diapositive, vous pouvez modifier son style par rapport à celui appliqué par le masque de diapositive.

Le masque de diapositive domine tous les éléments de configuration : Masque de diapositive → Disposition de diapositive → Diapositive :

![todo:image_alt_text](slide-master_2)



Chaque objet [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) possède une propriété [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) contenant une liste de dispositions de diapositive. Un type [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) a une propriété [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) qui pointe vers la disposition de diapositive appliquée à la diapositive. L’interaction entre une diapositive et le masque de diapositive se fait via une disposition de diapositive.

{{% alert color="info" title="Note" %}}

* Dans Aspose.Slides, toutes les configurations de diapositive (masque de diapositive, disposition de diapositive et la diapositive elle‑même) sont en réalité des objets diapositive implémentant l’interface [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide).  
* Par conséquent, le masque de diapositive et la disposition de diapositive peuvent implémenter les mêmes propriétés et vous devez savoir comment leurs valeurs seront appliquées à un objet [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/). Le masque de diapositive est appliqué en premier à une diapositive, puis la disposition de diapositive est appliquée. Par exemple, si le masque de diapositive et la disposition de diapositive possèdent toutes deux une valeur d’arrière‑plan, la diapositive finira avec l’arrière‑plan de la disposition de diapositive.

{{% /alert %}}


## **Ce que contient un masque de diapositive**
Pour comprendre comment un masque de diapositive peut être modifié, vous devez connaître ses constituants. Ce sont les propriétés de base du [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) :

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - obtenir/definir l’arrière‑plan de la diapositive.  
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - obtenir/definir les styles de texte du corps de la diapositive.  
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - obtenir/definir toutes les formes du masque de diapositive (espaces réservés, cadres d’image, etc.).  
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - obtenir/definir les contrôles ActiveX.  
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - obtenir le gestionnaire de thème.  
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - obtenir le gestionnaire d’en‑têtes et de pieds de page.  

Méthodes du masque de diapositive :

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - obtenir toutes les diapositives dépendantes du masque de diapositive.  
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - vous permet de créer un nouveau masque de diapositive basé sur le masque actuel et un nouveau thème. Le nouveau masque sera alors appliqué à toutes les diapositives dépendantes.  


## **Obtenir un masque de diapositive**
Dans PowerPoint, le masque de diapositive est accessible via le menu Affichage → Masque des diapositives :

![todo:image_alt_text](slide-master_3.jpg)



Avec Aspose.Slides, vous pouvez accéder à un masque de diapositive de la façon suivante :
```c#
IMasterSlide master = pres.Masters[0];
```


L’interface [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) représente un masque de diapositive. La propriété [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (liée au type [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) contient la liste de tous les masques de diapositives définis dans la présentation. 


## **Ajouter une image à un masque de diapositive**
Lorsque vous ajoutez une image à un masque de diapositive, cette image apparaîtra sur toutes les diapositives dépendantes de ce masque. 

Par exemple, vous pouvez placer le logo de votre société et quelques images sur le masque de diapositive puis revenir en mode édition des diapositives. Vous devriez voir l’image sur chaque diapositive. 

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un masque de diapositive avec Aspose.Slides : 
```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" title="Voir aussi" %}} 

Pour plus d’informations sur l’ajout d’images à une diapositive, consultez l’article [Picture Frame](/slides/fr/net/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Ajouter un espace réservé à un masque de diapositive**
Ces champs texte sont des espaces réservés standard sur un masque de diapositive : 

* Cliquer pour modifier le style du titre du masque

* Modifier les styles de texte du masque

* Niveau secondaire

* Niveau tertiaire 

  Ils apparaissent également sur les diapositives basées sur le masque de diapositive. Vous pouvez modifier ces espaces réservés sur le masque et les changements seront appliqués automatiquement aux diapositives. 

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin Masque de diapositive → Insérer un espace réservé :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus complexe d’espaces réservés avec Aspose.Slides. Considérez une diapositive avec des espaces réservés provenant du masque de diapositive :

![todo:image_alt_text](slide-master_6.png)

Nous voulons modifier le format du titre et du sous‑titre sur le masque de diapositive ainsi :

![todo:image_alt_text](slide-master_7.png)

Tout d’abord, nous récupérons le contenu de l’espace réservé du titre à partir de l’objet masque de diapositive puis utilisons le champ `PlaceHolder.FillFormat` : 
```c#
public static void Main()
{
    using (var pres = new Presentation())
    {
        IMasterSlide master = pres.Masters[0];
        IAutoShape placeHolder = FindPlaceholder(master, PlaceholderType.Title);
        placeHolder.FillFormat.FillType = FillType.Gradient;
        placeHolder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(0, Color.FromArgb(255, 0, 0));
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(255, Color.FromArgb(128, 0, 128));
        
        pres.Save("pres.pptx", SaveFormat.Pptx);
    }
}

static IAutoShape FindPlaceholder(IMasterSlide master, PlaceholderType type)
{
    foreach (IShape shape in master.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            if (autoShape.Placeholder.Type == type)
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

* [Définir le texte d’invite dans l’espace réservé](https://docs.aspose.com/slides/net/manage-placeholder/)  
* [Mise en forme du texte](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **Modifier l’arrière‑plan d’un masque de diapositive**
Lorsque vous modifiez la couleur d’arrière‑plan d’un masque de diapositive, toutes les diapositives normales de la présentation recevront la nouvelle couleur. Ce code C# montre l’opération :
```c#
using (var pres = new Presentation())
{
    IMasterSlide master = pres.Masters[0];
    master.Background.Type = BackgroundType.OwnBackground;
    master.Background.FillFormat.FillType = FillType.Solid;
    master.Background.FillFormat.SolidFillColor.Color = Color.Green;
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" title="Voir aussi" %}} 
- [Arrière‑plan de la présentation](https://docs.aspose.com/slides/net/presentation-background/)  

- [Thème de la présentation](https://docs.aspose.com/slides/net/presentation-theme/)  

{{% /alert %}}

## **Cloner un masque de diapositive vers une autre présentation**
Pour cloner un masque de diapositive vers une autre présentation, appelez la méthode [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) de la présentation de destination en lui transmettant le masque de diapositive. Ce code C# vous montre comment cloner un masque de diapositive vers une autre présentation :
```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```



## **Ajouter plusieurs masques de diapositives à une présentation**
Aspose.Slides vous permet d’ajouter plusieurs masques de diapositives et dispositions de diapositives à toute présentation donnée. Cela vous permet de configurer des styles, mises en page et options de formatage pour les diapositives de la présentation de multiples façons. 

Dans PowerPoint, vous pouvez ajouter de nouveaux masques de diapositives et dispositions (depuis le « menu Masque de diapositive ») ainsi :

![todo:image_alt_text](slide-master_9.jpg)

Avec Aspose.Slides, vous pouvez ajouter un nouveau masque de diapositive en appelant la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) :
```c#
pres.Masters.AddClone(pres.Masters[0]);
```



## **Comparer des masques de diapositives**
Un Master Slide implémente l’interface [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) contenant la méthode [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals), qui peut être utilisée pour comparer des diapositives. Elle renvoie `true` pour les Master Slides identiques en structure et en contenu statique. 

Deux Master Slides sont égaux si leurs formes, styles, textes, animations et autres paramètres, etc. sont identiques. La comparaison ne prend pas en compte les valeurs d’identifiants uniques (par ex. SlideId) ni le contenu dynamique (par ex. la valeur de date actuelle dans un espace réservé Date). 


## **Définir un masque de diapositive comme affichage par défaut de la présentation**
Aspose.Slides vous permet de définir un masque de diapositive comme affichage par défaut d’une présentation. L’affichage par défaut est ce que vous voyez en premier lorsque vous ouvrez une présentation. 

Ce code vous montre comment définir un masque de diapositive comme affichage par défaut d’une présentation en C# :
```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```



## **Supprimer les masques de diapositives inutilisés**

Aspose.Slides fournit la méthode [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) pour vous permettre de supprimer les masques de diapositives indésirables et inutilisés. Ce code C# montre comment supprimer un masque de diapositive d’une présentation PowerPoint :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```



## **FAQ**

**Qu’est‑ce qu’un masque de diapositive dans PowerPoint ?**

Un masque de diapositive est un modèle de diapositive qui définit la disposition, les styles, les thèmes, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Il vous permet de définir et de modifier l’aspect de toutes les diapositives de la présentation en une seule fois.  

**Comment un masque de diapositive est‑il appliqué dans une présentation ?**

Chaque présentation possède au moins un masque de diapositive par défaut. Lorsqu’une nouvelle diapositive est ajoutée, un masque de diapositive lui est appliqué automatiquement, généralement en héritant du masque de la diapositive précédente. Une présentation peut contenir plusieurs masques de diapositives pour styliser différemment les différentes parties.  

**Quels éléments peuvent être personnalisés dans un masque de diapositive ?**

Un masque de diapositive comprend plusieurs propriétés de base qui peuvent être personnalisées :

- **Background** : définir l’arrière‑plan de la diapositive.  
- **BodyStyle** : définir les styles de texte du corps de la diapositive.  
- **Shapes** : gérer toutes les formes du masque, y compris les espaces réservés et les cadres d’image.  
- **Controls** : gérer les contrôles ActiveX.  
- **ThemeManager** : accéder au gestionnaire de thème.  
- **HeaderFooterManager** : gérer les en‑têtes et pieds de page.  

**Comment ajouter une image à un masque de diapositive ?**

L’ajout d’une image à un masque de diapositive garantit qu’elle apparaît sur toutes les diapositives dépendantes de ce masque. Par exemple, placer le logo de l’entreprise sur le masque de diapositive l’affichera sur chaque diapositive de la présentation.  

**Comment les masques de diapositives se rapportent‑ils aux dispositions de diapositives ?**

Les dispositions de diapositives fonctionnent en conjonction avec les masques de diapositives pour offrir de la flexibilité dans la conception. Alors qu’un masque de diapositive définit les styles et thèmes globaux, les dispositions permettent des variations dans l’agencement du contenu. La hiérarchie est la suivante :

- **Masque de diapositive** → définit les styles globaux.  
- **Disposition de diapositive** → offre différents agencements de contenu.  
- **Diapositive** → hérite du design de sa disposition.  

**Puis‑je avoir plusieurs masques de diapositives dans une même présentation ?**

Oui, une présentation peut contenir plusieurs masques de diapositives. Cela vous permet de styliser différentes sections de la présentation de façons variées, offrant ainsi une plus grande flexibilité de conception.  

**Comment accéder et modifier un masque de diapositive avec Aspose.Slides ?**

Dans Aspose.Slides, un masque de diapositive est représenté par l’interface `IMasterSlide`. Vous pouvez accéder à un masque de diapositive via la propriété `Masters` de l’objet `Presentation`.