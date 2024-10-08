---
title: Maître de diapositive
type: docs
weight: 80
url: /fr/net/slide-master/
keywords: "Ajouter Maître de diapositive, diapositive maître PPT, maître de diapositive PowerPoint, image au Maître de diapositive, espace réservé, plusieurs Maîtres de diapositive, comparer Maîtres de diapositive, C#, Csharp, .NET, Aspose.Slides"
description: "Ajouter ou modifier le maître de diapositive dans une présentation PowerPoint en C# ou .NET"
---


## **Qu'est-ce qu'un Maître de diapositive dans PowerPoint**
Un **Maître de diapositive** est un modèle de diapositive qui définit la mise en page, les styles, le thème, les polices, l'arrière-plan et d'autres propriétés pour les diapositives d'une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et modèle pour votre entreprise, vous pouvez utiliser un maître de diapositive.

Un Maître de diapositive est utile car il vous permet de définir et de changer l'apparence de toutes les diapositives de présentation en une seule fois. Aspose.Slides prend en charge le mécanisme du Maître de diapositive de PowerPoint.

VBA permet également de manipuler un Maître de diapositive et d'exécuter les mêmes opérations prises en charge dans PowerPoint : changer les arrière-plans, ajouter des formes, personnaliser la mise en page, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d'utiliser des Maîtres de diapositive et d'effectuer des tâches de base avec eux.

Voici les opérations de base sur les Maîtres de diapositive :

- Créer ou mettre à jour le Maître de diapositive.
- Appliquer le Maître de diapositive aux diapositives de présentation.
- Changer l'arrière-plan du Maître de diapositive.
- Ajouter une image, un espace réservé, un Smart Art, etc. au Maître de diapositive.

Voici des opérations plus avancées impliquant le Maître de diapositive :

- Comparer des Maîtres de diapositive.
- Fusionner des Maîtres de diapositive.
- Appliquer plusieurs Maîtres de diapositive.
- Copier une diapositive avec le Maître de diapositive vers une autre présentation.
- Détecter les Maîtres de diapositive en double dans les présentations.
- Définir le Maître de diapositive comme vue par défaut de la présentation.

{{% alert color="primary" %}} 

Vous pouvez consulter le [**Visualiseur PowerPoint en ligne**](https://products.aspose.app/slides/viewer) d'Aspose, car il s'agit d'une mise en œuvre en direct de certains des processus de base décrits ici.

{{% /alert %}} 


## **Comment le Maître de diapositive est appliqué**
Avant de travailler avec un maître de diapositive, il peut être utile de comprendre comment il est utilisé dans les présentations et appliqué aux diapositives.

* Chaque présentation a au moins un Maître de diapositive par défaut.
* Une présentation peut contenir plusieurs Maîtres de diapositive. Vous pouvez ajouter plusieurs Maîtres de diapositive et les utiliser pour styliser différentes parties d'une présentation de différentes manières.

Dans **Aspose.Slides**, un Maître de diapositive est représenté par le type [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide).

L’objet [Présentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) d’Aspose.Slides contient la liste des [**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) de type [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), qui contient une liste de tous les maîtres de diapositive définis dans une présentation.

Outre les opérations CRUD, l'interface [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) contient ces méthodes utiles : [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) et [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). Ces méthodes sont héritées de la fonction de clonage de diapositive de base. Mais lorsqu'il s'agit de Maîtres de diapositive, ces méthodes vous permettent de mettre en œuvre des configurations compliquées.

Lorsque vous ajoutez une nouvelle diapositive à une présentation, un Maître de diapositive lui est automatiquement appliqué. Le Maître de diapositive de la diapositive précédente est sélectionné par défaut.

**Remarque** : les diapositives de présentation sont stockées dans la liste [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation contient un seul Maître de diapositive, ce maître de diapositive est sélectionné pour toutes les nouvelles diapositives. C'est la raison pour laquelle vous n'avez pas à définir le Maître de diapositive pour chaque nouvelle diapositive que vous créez.

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle présentation, vous pouvez simplement appuyer sur la ligne inférieure sous la dernière diapositive, et une nouvelle diapositive (avec le Maître de diapositive de la dernière présentation) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez effectuer la tâche équivalente avec la méthode [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) de la classe [Présentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).


## **Maître de diapositive dans la hiérarchie des diapositives**
L'utilisation des mises en page de diapositive avec le Maître de diapositive permet une flexibilité maximale. Une mise en page de diapositive vous permet de définir tous les mêmes styles que le Maître de diapositive (arrière-plan, polices, formes, etc.). Cependant, lorsque plusieurs mises en page de diapositive sont combinées sur un Maître de diapositive, un nouveau style est créé. Lorsque vous appliquez une mise en page de diapositive à une seule diapositive, vous pouvez changer son style par rapport à celui appliqué par le Maître de diapositive.

Le Maître de diapositive prédomine tous les éléments de configuration : Maître de diapositive -> Mise en page de diapositive -> Diapositive :

![todo:image_alt_text](slide-master_2)

Chaque [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) a une propriété [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) contenant une liste de mises en page de diapositive. Un type de [Diapositive](https://reference.aspose.com/slides/net/aspose.slides/slide) a une propriété [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) avec un lien vers une mise en page de diapositive appliquée à la diapositive. L'interaction entre une diapositive et le Maître de diapositive se fait par l'intermédiaire d'une mise en page de diapositive.

{{% alert color="info" title="Remarque" %}}

* 
   Dans Aspose.Slides, tous les éléments de configuration de la diapositive (Maître de diapositive, Mise en page de diapositive et la diapositive elle-même) sont en réalité des objets de diapositive implémentant l'interface [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide).
* Par conséquent, le Maître de diapositive et la Mise en page de diapositive peuvent implémenter les mêmes propriétés et vous devez savoir comment leurs valeurs seront appliquées à un objet [Diapositive](https://reference.aspose.com/slides/net/aspose.slides/slide/). Le Maître de diapositive est appliqué en premier à une diapositive, puis la Mise en page de diapositive est appliquée. Par exemple, si le Maître de diapositive et la Mise en page de diapositive ont tous deux une valeur d'arrière-plan, la diapositive finira par avoir l'arrière-plan de la Mise en page de diapositive.

{{% /alert %}}


## **Ce qu'un Maître de diapositive comprend**
Pour comprendre comment un Maître de diapositive peut être modifié, vous devez connaître ses constituants. Voici les propriétés de base de [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) :

- [Arrière-plan](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - obtenir/définir l'arrière-plan de la diapositive.
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - obtenir/définir les styles de texte du corps de la diapositive.
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - obtenir/définir toutes les formes du Maître de diapositive (espaces réservés, cadres photo, etc.).
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - obtenir/définir les contrôles ActiveX.
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - obtenir le gestionnaire de thème.
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - obtenir le gestionnaire d'en-tête et de pied de page.

Méthodes du Maître de diapositive :

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - obtenir toutes les diapositives dépendant du Maître de diapositive.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - vous permet de créer un nouveau Maître de diapositive basé sur le Maître de diapositive actuel et un nouveau thème. Le nouveau Maître de diapositive sera alors appliqué à toutes les diapositives dépendantes.


## **Obtenir le Maître de diapositive**
Dans PowerPoint, le Maître de diapositive peut être accessible depuis le menu Affichage -> Maître de diapositive :

![todo:image_alt_text](slide-master_3.jpg)

En utilisant Aspose.Slides, vous pouvez accéder à un Maître de diapositive de cette manière :

```c#
IMasterSlide master = pres.Masters[0];
```

L'interface [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) représente un Maître de diapositive. La propriété [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (liée au type [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) contient une liste de tous les Maîtres de diapositive définis dans la présentation.


## **Ajouter une image au Maître de diapositive**
Lorsque vous ajoutez une image à un Maître de diapositive, cette image apparaîtra sur toutes les diapositives dépendantes de ce maître de diapositive.

Par exemple, vous pouvez placer le logo de votre entreprise et quelques images sur le Maître de diapositive, puis revenir en mode d'édition des diapositives. Vous devriez voir l'image sur chaque diapositive.

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un maître de diapositive avec Aspose.Slides :

```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="Voir aussi" %}} 

Pour plus d'informations sur l'ajout d'images à une diapositive, voir l'article sur [Image Frame](/slides/fr/net/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Ajouter un espace réservé au Maître de diapositive**
Ces champs de texte sont des espaces réservés standard sur un Maître de diapositive : 

* Cliquez pour modifier le style de titre principal

* Modifier les styles de texte principaux

* Deuxième niveau

* Troisième niveau

  Ils apparaissent également sur les diapositives basées sur le Maître de diapositive. Vous pouvez modifier ces espaces réservés sur un Maître de diapositive et les modifications seront automatiquement appliquées aux diapositives.

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin Maître de diapositive -> Insérer un espace réservé :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus compliqué pour les espaces réservés avec Aspose.Slides. Considérons une diapositive avec des espaces réservés modélisés à partir du Maître de diapositive :

![todo:image_alt_text](slide-master_6.png)

Nous souhaitons changer la mise en forme du Titre et du Sous-titre sur le Maître de diapositive de cette manière :

![todo:image_alt_text](slide-master_7.png)

D'abord, nous récupérons le contenu de l'espace réservé pour le titre à partir de l'objet Maître de diapositive, puis nous utilisons le champ `PlaceHolder.FillFormat` : 

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

Le style et la mise en forme du titre changeront pour toutes les diapositives basées sur le maître de diapositive :

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Voir aussi" %}} 

* [Définir le texte d'invite dans l'espace réservé](https://docs.aspose.com/slides/net/manage-placeholder/)
* [Mise en forme du texte](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **Changer l'arrière-plan sur le Maître de diapositive**
Lorsque vous changez la couleur d'arrière-plan d'un maître de diapositive, toutes les diapositives normales de la présentation recevront la nouvelle couleur. Ce code C# démontre l'opération :

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
- [Arrière-plan de la présentation](https://docs.aspose.com/slides/net/presentation-background/)

- [Thème de la présentation](https://docs.aspose.com/slides/net/presentation-theme/)

  {{% /alert %}}

## **Cloner le Maître de diapositive vers une autre présentation**
Pour cloner un Maître de diapositive vers une autre présentation, appelez la méthode [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) de la présentation de destination avec un Maître de diapositive passé en paramètre. Ce code C# vous montre comment cloner un Maître de diapositive vers une autre présentation :

```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```


## **Ajouter plusieurs Maîtres de diapositive à la présentation**
Aspose.Slides vous permet d'ajouter plusieurs Maîtres de diapositive et mises en page de diapositive à n'importe quelle présentation donnée. Cela vous permet de configurer des styles, des mises en page et des options de formatage pour les diapositives de présentation de différentes façons.

Dans PowerPoint, vous pouvez ajouter de nouveaux Maîtres de diapositive et mises en page (à partir du menu "Maître de diapositive) de cette manière :

![todo:image_alt_text](slide-master_9.jpg)

En utilisant Aspose.Slides, vous pouvez ajouter un nouveau Maître de diapositive en appelant la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) :

```c#
pres.Masters.AddClone(pres.Masters[0]);
```


## **Comparer les Maîtres de diapositive**
Un Maître de diapositive implémente l'interface [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) contenant la méthode [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals), qui peut être utilisée pour comparer des diapositives. Elle retourne `true` pour des Maîtres de diapositive identiques dans leur structure et leur contenu statique.

Deux Maîtres de diapositive sont égaux si leurs formes, styles, textes, animations et autres paramètres, etc. sont égaux. La comparaison ne prend pas en compte les valeurs d'identifiant unique (par exemple, SlideId) et le contenu dynamique (par exemple, la valeur de date actuelle dans l'espace réservé de date).


## **Définir le Maître de diapositive comme vue par défaut de la présentation**
Aspose.Slides vous permet de définir un Maître de diapositive comme vue par défaut pour une présentation. La vue par défaut est celle que vous voyez en premier lorsque vous ouvrez une présentation.

Ce code vous montre comment définir un Maître de diapositive comme vue par défaut d'une présentation en C# :

```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```

## **Supprimer les Maîtres de diapositive inutilisés**

Aspose.Slides fournit la méthode [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) pour vous permettre de supprimer des maîtres de diapositive indésirables et inutilisés. Ce code C# vous montre comment supprimer un maître de diapositive d'une présentation PowerPoint :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```