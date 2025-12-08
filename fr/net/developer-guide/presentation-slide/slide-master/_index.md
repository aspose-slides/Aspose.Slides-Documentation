---
title: Qu'est-ce qu'un masque de diapositive dans PowerPoint? Guide de définition et d'utilisation
linktitle: Masque de diapositive
type: docs
weight: 80
url: /fr/net/slide-master/
keywords: "Ajouter un masque de diapositive, diapositive maître PPT, masque de diapositive PowerPoint, Image au masque de diapositive, Espace réservé, Masques de diapositive multiples, Comparer les masques de diapositive, C#, Csharp, .NET, Aspose.Slides"
description: "Apprenez ce qu'est un masque de diapositive dans PowerPoint et comment il vous aide à contrôler la disposition des diapositives, les polices, les couleurs et l'image de marque. Guide simple étape par étape avec des exemples en C# ou .NET."
---

## **Qu’est‑ce qu’un masque de diapositive dans PowerPoint**
Un **Slide Master** dans PowerPoint est une fonctionnalité qui contrôle la mise en page, les polices et les styles de plusieurs diapositives. Elle aide à maintenir la cohérence et l’image de marque dans les présentations. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et modèle pour votre entreprise, vous pouvez utiliser un masque de diapositive. 

Un masque de diapositive est utile car il vous permet de définir et de modifier l’apparence de toutes les diapositives de la présentation en une seule fois. Aspose.Slides prend en charge le mécanisme de masque de diapositive de PowerPoint. 

VBA vous permet également de manipuler un masque de diapositive et d’exécuter les mêmes opérations prises en charge dans PowerPoint : changer les arrière‑plans, ajouter des formes, personnaliser la mise en page, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d’utiliser les masques de diapositive et d’effectuer des tâches de base avec eux. 

Voici les opérations de base sur le masque de diapositive :

- Créer ou sélectionner un masque de diapositive.  
- Appliquer le masque de diapositive aux diapositives de la présentation.  
- Modifier l’arrière‑plan du masque de diapositive.  
- Ajouter une image, un espace réservé, SmartArt, etc. au masque de diapositive.  

Voici des opérations plus avancées impliquant le masque de diapositive : 

- Comparer les masques de diapositive.  
- Fusionner les masques de diapositive.  
- Appliquer plusieurs masques de diapositive.  
- Copier une diapositive avec le masque de diapositive vers une autre présentation.  
- Détecter les masques de diapositive en double dans les présentations.  
- Définir le masque de diapositive comme vue par défaut de la présentation.  

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter l’[**Visionneur PowerPoint en ligne**](https://products.aspose.app/slides/viewer) d’Aspose car il s’agit d’une implémentation en direct de certains des processus clés décrits ici.

{{% /alert %}} 


## **Comment le masque de diapositive est appliqué**
Avant de travailler avec un masque de diapositive, vous voudrez peut-être comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives. 

* Chaque présentation possède au moins un masque de diapositive par défaut. 
* Une présentation peut contenir plusieurs masques de diapositive. Vous pouvez ajouter plusieurs masques de diapositive et les utiliser pour styliser différentes parties d’une présentation de manières différentes. 

Dans **Aspose.Slides**, un masque de diapositive est représenté par le type [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide). 

L’objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) d’Aspose.Slides contient la liste [**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) de type [**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection), qui contient la liste de tous les masques de diapositive définis dans une présentation. 

En plus des opérations CRUD, l’interface [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) contient ces méthodes utiles : [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) et [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone). Ces méthodes sont héritées de la fonction de clonage de diapositive de base. Mais lorsqu’on travaille avec des masques de diapositive, ces méthodes permettent de mettre en œuvre des configurations compliquées. 

Lorsqu’une nouvelle diapositive est ajoutée à une présentation, un masque de diapositive lui est appliqué automatiquement. Le masque de diapositive de la diapositive précédente est sélectionné par défaut. 

**Note** : Les diapositives de la présentation sont stockées dans la liste [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation ne contient qu’un seul masque de diapositive, ce masque est sélectionné pour toutes les nouvelles diapositives. C’est pourquoi vous n’avez pas à définir le masque de diapositive pour chaque nouvelle diapositive que vous créez.

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle diapositive, vous pouvez simplement cliquer sur la ligne inférieure sous la dernière diapositive et une nouvelle diapositive (avec le masque de diapositive de la dernière présentation) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez exécuter la tâche équivalente avec la méthode [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) sous la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 


## **Masque de diapositive dans la hiérarchie des diapositives**
Utiliser les dispositions de diapositive avec le masque de diapositive permet une flexibilité maximale. Une disposition de diapositive vous permet de définir les mêmes styles que le masque de diapositive (arrière‑plan, polices, formes, etc.). Cependant, lorsque plusieurs dispositions de diapositive sont combinées sur un même masque, un nouveau style est créé. Lorsque vous appliquez une disposition à une seule diapositive, vous pouvez modifier son style par rapport à celui appliqué par le masque de diapositive.

Le masque de diapositive prime sur tous les éléments de configuration : Masque de diapositive → Disposition de diapositive → Diapositive :

![todo:image_alt_text](slide-master_2)

Chaque objet [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) possède une propriété [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) contenant une liste de dispositions de diapositive. Un type [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) possède une propriété [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) qui pointe vers la disposition de diapositive appliquée à la diapositive. L’interaction entre une diapositive et le masque de diapositive se fait via une disposition de diapositive.

{{% alert color="info" title="Note" %}}

* Dans Aspose.Slides, toutes les configurations de diapositive (Masque de diapositive, Disposition de diapositive et la diapositive elle‑même) sont en réalité des objets de diapositive implémentant l’interface [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide).
* Ainsi, le masque de diapositive et la disposition de diapositive peuvent implémenter les mêmes propriétés et vous devez savoir comment leurs valeurs seront appliquées à un objet [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/). Le masque de diapositive est appliqué en premier à une diapositive, puis la disposition de diapositive est appliquée. Par exemple, si le masque et la disposition ont tous deux une valeur d’arrière‑plan, la diapositive finira avec l’arrière‑plan de la disposition.

{{% /alert %}}


## **Ce que comprend un masque de diapositive**
Pour comprendre comment un masque de diapositive peut être modifié, vous devez connaître ses composants. Voici les propriétés de base du [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) :

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - obtenir/definir l'arrière‑plan de la diapositive.  
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - obtenir/definir les styles de texte du corps de la diapositive.  
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - obtenir/definir toutes les formes du masque de diapositive (espaces réservés, cadres d’image, etc.).  
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - obtenir/definir les contrôles ActiveX.  
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - obtenir le gestionnaire de thème.  
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - obtenir le gestionnaire d’en‑tête et de pied de page.  

Méthodes du masque de diapositive :

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - obtenir toutes les diapositives dépendant du masque de diapositive.  
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - permettre de créer un nouveau masque de diapositive basé sur le masque actuel et un nouveau thème. Le nouveau masque sera alors appliqué à toutes les diapositives dépendantes.  


## **Obtenir le masque de diapositive**
Dans PowerPoint, le masque de diapositive est accessible via le menu Affichage → Masque des diapositives :

![todo:image_alt_text](slide-master_3.jpg)

Avec Aspose.Slides, vous pouvez accéder à un masque de diapositive de cette façon :
```c#
IMasterSlide master = pres.Masters[0];
```


L’interface [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) représente un masque de diapositive. La propriété [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) (liée au type [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)) contient une liste de tous les masques de diapositive définis dans la présentation.  


## **Ajouter une image au masque de diapositive**
Lorsque vous ajoutez une image à un masque de diapositive, cette image apparaîtra sur toutes les diapositives dépendant de ce masque. 

Par exemple, vous pouvez placer le logo de votre société et quelques images sur le masque de diapositive, puis revenir en mode d’édition des diapositives. Vous devriez voir l’image sur chaque diapositive. 

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


## **Ajouter un espace réservé au masque de diapositive**
Ces zones de texte sont des espaces réservés standard sur un masque de diapositive :

* Cliquez pour modifier le style du titre du masque
* Modifier les styles de texte du masque
* Deuxième niveau
* Troisième niveau

  Elles apparaissent également sur les diapositives basées sur le masque de diapositive. Vous pouvez modifier ces espaces réservés sur le masque et les changements sont appliqués automatiquement aux diapositives. 

Dans PowerPoint, vous pouvez ajouter un espace réservé via le chemin Masque de diapositive → Insérer un espace réservé :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus compliqué d’espaces réservés avec Aspose.Slides. Considérez une diapositive avec des espaces réservés provenant du masque de diapositive :

![todo:image_alt_text](slide-master_6.png)

Nous souhaitons modifier le format du titre et du sous‑titre sur le masque de diapositive de la manière suivante :

![todo:image_alt_text](slide-master_7.png)

Tout d’abord, nous récupérons le contenu de l’espace réservé du titre à partir de l’objet masque de diapositive, puis nous utilisons le champ `PlaceHolder.FillFormat` :
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

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/net/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **Modifier l'arrière‑plan du masque de diapositive**
Lorsque vous modifiez la couleur d’arrière‑plan d’un masque de diapositive, toutes les diapositives normales de la présentation obtiennent la nouvelle couleur. Ce code C# montre l’opération :
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
- [Presentation Background](https://docs.aspose.com/slides/net/presentation-background/)

- [Presentation Theme](https://docs.aspose.com/slides/net/presentation-theme/)

{{% /alert %}}


## **Cloner le masque de diapositive vers une autre présentation**
Pour cloner un masque de diapositive vers une autre présentation, appelez la méthode [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) de la présentation de destination en passant un masque de diapositive. Ce code C# montre comment cloner un masque de diapositive vers une autre présentation :
```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```



## **Ajouter plusieurs masques de diapositive à une présentation**
Aspose.Slides vous permet d’ajouter plusieurs masques de diapositive et dispositions de diapositive à une présentation donnée. Cela vous permet de configurer les styles, les mises en page et les options de formatage des diapositives de nombreuses manières. 

Dans PowerPoint, vous pouvez ajouter de nouveaux masques de diapositive et dispositions (à partir du « menu Masque de diapositive ») de cette façon :

![todo:image_alt_text](slide-master_9.jpg)

Avec Aspose.Slides, vous pouvez ajouter un nouveau masque de diapositive en appelant la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) :
```c#
pres.Masters.AddClone(pres.Masters[0]);
```



## **Comparer les masques de diapositive**
Un masque de diapositive implémente l’interface [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) contenant la méthode [Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals), qui peut être utilisée pour comparer les diapositives. Elle renvoie `true` pour les masques de diapositive identiques en structure et contenu statique. 

Deux masques de diapositive sont égaux si leurs formes, styles, textes, animations et autres paramètres sont égaux. La comparaison ne prend pas en compte les valeurs d’identifiant uniques (par ex. SlideId) ni le contenu dynamique (par ex. la valeur de date actuelle dans l’espace réservé Date). 


## **Définir le masque de diapositive comme vue par défaut de la présentation**
Aspose.Slides vous permet de définir un masque de diapositive comme vue par défaut d’une présentation. La vue par défaut est ce que vous voyez en premier en ouvrant une présentation. 

Ce code montre comment définir un masque de diapositive comme vue par défaut d’une présentation en C# :
```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```



## **Supprimer le masque de diapositive inutilisé**
Aspose.Slides fournit la méthode [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) pour supprimer les masques de diapositive indésirables et inutilisés. Ce code C# montre comment supprimer un masque de diapositive d’une présentation PowerPoint :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```



## **FAQ**

**Qu’est‑ce qu’un masque de diapositive dans PowerPoint ?**

Un masque de diapositive est un modèle de diapositive qui définit la mise en page, les styles, les thèmes, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Il vous permet de définir et de modifier l’apparence de toutes les diapositives d’une présentation en une seule fois.  

**Comment un masque de diapositive est‑il appliqué dans une présentation ?**

Chaque présentation possède au moins un masque de diapositive par défaut. Lorsqu’une nouvelle diapositive est ajoutée, un masque de diapositive lui est appliqué automatiquement, héritant généralement du masque de la diapositive précédente. Une présentation peut contenir plusieurs masques de diapositive pour styliser différemment des parties distinctes.  

**Quels éléments peuvent être personnalisés dans un masque de diapositive ?**

Un masque de diapositive comprend plusieurs propriétés de base qui peuvent être personnalisées :

- **Background** : définir l’arrière‑plan de la diapositive.  
- **BodyStyle** : définir les styles de texte du corps de la diapositive.  
- **Shapes** : gérer toutes les formes du masque, y compris les espaces réservés et les cadres d’image.  
- **Controls** : gérer les contrôles ActiveX.  
- **ThemeManager** : accéder au gestionnaire de thème.  
- **HeaderFooterManager** : gérer les en‑têtes et les pieds de page.  

**Comment ajouter une image à un masque de diapositive ?**

Ajouter une image à un masque de diapositive garantit qu’elle apparaît sur toutes les diapositives dépendant de ce masque. Par exemple, placer le logo de l’entreprise sur le masque de diapositive l’affichera sur chaque diapositive de la présentation.  

**Comment les masques de diapositive sont‑ils liés aux dispositions de diapositive ?**

Les dispositions de diapositive fonctionnent en conjonction avec les masques de diapositive pour offrir de la flexibilité dans la conception. Alors qu’un masque définit les styles et thèmes globaux, les dispositions permettent des variations dans l’arrangement du contenu. La hiérarchie est la suivante :

- **Masque de diapositive** → Définit les styles globaux.  
- **Disposition de diapositive** → Fournit différents arrangements de contenu.  
- **Diapositive** → Hérite du design de sa disposition.  

**Puis‑je avoir plusieurs masques de diapositive dans une même présentation ?**

Oui, une présentation peut contenir plusieurs masques de diapositive. Cela vous permet de styliser différentes sections de la présentation de diverses manières, offrant ainsi une flexibilité de conception.  

**Comment accéder et modifier un masque de diapositive avec Aspose.Slides ?**

Dans Aspose.Slides, un masque de diapositive est représenté par l’interface `IMasterSlide`. Vous pouvez accéder à un masque de diapositive via la propriété `Masters` de l’objet `Presentation`.