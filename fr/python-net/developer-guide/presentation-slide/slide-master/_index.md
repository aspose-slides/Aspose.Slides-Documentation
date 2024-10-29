---
title: Maître de Diapositive
type: docs
weight: 80
url: /fr/python-net/slide-master/
keywords: "Ajouter Maître de Diapositive, diapositive maître PPT, maître de diapositive PowerPoint, Image au Maître de Diapositive, Espace réservé, Plusieurs Maîtres de Diapositives, Comparer Maîtres de Diapositives, Python, Aspose.Slides"
description: "Ajouter ou modifier le maître de diapositive dans la présentation PowerPoint en Python"
---

## **Qu'est-ce qu'un Maître de Diapositive dans PowerPoint**

Un **Maître de Diapositive** est un modèle de diapositive qui définit la mise en page, les styles, le thème, les polices, l'arrière-plan et d'autres propriétés pour les diapositives d'une présentation. Si vous souhaitez créer une présentation (ou série de présentations) avec le même style et modèle pour votre entreprise, vous pouvez utiliser un maître de diapositive.

Un Maître de Diapositive est utile car il vous permet de définir et de changer l'apparence de toutes les diapositives de la présentation en une seule fois. Aspose.Slides prend en charge le mécanisme Maître de Diapositive de PowerPoint.

VBA vous permet également de manipuler un Maître de Diapositive et d'exécuter les mêmes opérations prises en charge dans PowerPoint : changer les arrière-plans, ajouter des formes, personnaliser la mise en page, etc. Aspose.Slides fournit des mécanismes flexibles pour vous permettre d'utiliser les Maîtres de Diapositives et d'effectuer des tâches de base avec eux.

Voici les opérations de base sur le Maître de Diapositive :

- Créer ou Modifier un Maître de Diapositive.
- Appliquer un Maître de Diapositive aux diapositives de présentation.
- Changer l'arrière-plan du Maître de Diapositive.
- Ajouter une image, un espace réservé, Smart Art, etc. au Maître de Diapositive.

Voici des opérations plus avancées impliquant le Maître de Diapositive :

- Comparer les Maîtres de Diapositives.
- Fusionner des Maîtres de Diapositives.
- Appliquer plusieurs Maîtres de Diapositives.
- Copier une diapositive avec son Maître de Diapositive vers une autre présentation.
- Découvrir les Maîtres de Diapositives dupliqués dans les présentations.
- Définir le Maître de Diapositive comme la vue par défaut de la présentation.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter le [**Visionneuse PowerPoint en Ligne**](https://products.aspose.app/slides/viewer) d'Aspose car c'est une implémentation live de certains des processus de base décrits ici.

{{% /alert %}} 

## **Comment le Maître de Diapositive est-il appliqué**

Avant de travailler avec un maître de diapositive, vous voudrez peut-être comprendre comment ils sont utilisés dans les présentations et appliqués aux diapositives.

* Chaque présentation a au moins un Maître de Diapositive par défaut.
* Une présentation peut contenir plusieurs Maîtres de Diapositives. Vous pouvez ajouter plusieurs Maîtres de Diapositives et les utiliser pour styliser différentes parties d'une présentation de différentes manières.

Dans **Aspose.Slides**, un Maître de Diapositive est représenté par le type [**IMasterSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/).

L'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) d'Aspose.Slides contient la liste [**masters**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) du type [**IMasterSlideCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/), qui contient une liste de toutes les diapositives maîtres définies dans une présentation.

En plus des opérations CRUD, l'interface [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) contient ces méthodes utiles : [**add_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) et [**insert_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/). Ces méthodes sont héritées de la fonction de clonage de diapositive de base. Mais lorsqu'il s'agit de Maîtres de Diapositives, ces méthodes vous permettent de mettre en œuvre des configurations compliquées.

Lorsqu'une nouvelle diapositive est ajoutée à une présentation, un Maître de Diapositive lui est appliqué automatiquement. Le Maître de Diapositive de la diapositive précédente est sélectionné par défaut.

**Remarque** : Les diapositives de présentation sont stockées dans la liste [Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), et chaque nouvelle diapositive est ajoutée à la fin de la collection par défaut. Si une présentation contient un seul Maître de Diapositive, ce maître de diapositive est sélectionné pour toutes les nouvelles diapositives. C'est la raison pour laquelle vous n'avez pas à définir le Maître de Diapositive pour chaque nouvelle diapositive que vous créez.

Le principe est le même pour PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle présentation, vous pouvez simplement appuyer sur la ligne du bas sous la dernière diapositive, puis une nouvelle diapositive (avec le Maître de Diapositive de la dernière présentation) sera créée :

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez effectuer la tâche équivalente avec la méthode [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

## **Maître de Diapositive dans la hiérarchie des Diapositives**

Utiliser les Dispositions de Diapositive avec le Maître de Diapositive permet une flexibilité maximale. Une Disposition de Diapositive vous permet de définir tous les mêmes styles que le Maître de Diapositive (arrière-plan, polices, formes, etc.). Cependant, lorsque plusieurs Dispositions de Diapositive sont combinées sur un Maître de Diapositive, un nouveau style est créé. Lorsque vous appliquez une Disposition de Diapositive à une seule diapositive, vous pouvez changer son style par rapport à celui appliqué par le Maître de Diapositive.

Le Maître de Diapositive a la priorité sur tous les éléments de configuration : Maître de Diapositive -> Disposition de Diapositive -> Diapositive :

![todo:image_alt_text](slide-master_2)

Chaque [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) a une propriété [**LayoutSlides**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) avec une liste des Dispositions de Diapositive. Un type [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide) a une propriété [**LayoutSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) avec un lien sur une Disposition de Diapositive appliquée à la diapositive. L'interaction entre une diapositive et un Maître de Diapositive se produit à travers une Disposition de Diapositive.

{{% alert color="info" title="Remarque" %}}

* Dans Aspose.Slides, tous les éléments de configuration des diapositives (Maître de Diapositive, Disposition de Diapositive, et la diapositive elle-même) sont en réalité des objets diapositives implémentant l'interface [**IBaseSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/).
* Par conséquent, le Maître de Diapositive et la Disposition de Diapositive peuvent implémenter les mêmes propriétés et vous devez savoir comment leurs valeurs seront appliquées à un objet [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). Le Maître de Diapositive est appliqué en premier à une diapositive, puis la Disposition de Diapositive est appliquée. Par exemple, si le Maître de Diapositive et la Disposition de Diapositive ont tous deux une valeur d'arrière-plan, la diapositive finira par avoir l'arrière-plan de la Disposition de Diapositive.

{{% /alert %}}

## **Ce que comprend un Maître de Diapositive**

Pour comprendre comment un Maître de Diapositive peut être modifié, vous devez connaître ses constituants. Voici les propriétés principales du [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) :

- `background` obtenir/définir l'arrière-plan de la diapositive.
- `body_style` obtenir/définir les styles de texte du corps de la diapositive.
- `shapes` obtenir/définir toutes les formes du Maître de Diapositive (espaces réservés, cadres photo, etc.).
- `controls` - obtenir/définir les contrôles ActiveX.
- `theme_manager` - obtenir le gestionnaire de thème.
- `header_footer_manager` - obtenir le gestionnaire d'en-tête et de pied de page.

Méthodes du Maître de Diapositive :

- `get_depending_slides()` - obtenir toutes les diapositives dépendant du Maître de Diapositive.
- `apply_external_theme_to_depending_slides(fname)` - permet de créer un nouveau Maître de Diapositive basé sur le Maître de Diapositive actuel et un nouveau thème. Le nouveau Maître de Diapositive sera ensuite appliqué à toutes les diapositives dépendantes.

## **Obtenir le Maître de Diapositive**

Dans PowerPoint, le Maître de Diapositive peut être accessible depuis le menu Affichage -> Maître de Diapositive :

![todo:image_alt_text](slide-master_3.jpg)

Avec Aspose.Slides, vous pouvez accéder à un Maître de Diapositive de cette manière :

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    # Donne accès au maître de diapositive de la présentation
    masterSlide = pres.masters[0]
```

L'interface [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) représente un Maître de Diapositive. La propriété `masters` (liée au type [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)) contient une liste de tous les Maîtres de Diapositives définis dans la présentation.

## **Ajouter une Image au Maître de Diapositive**

Lorsque vous ajoutez une image à un Maître de Diapositive, cette image apparaîtra sur toutes les diapositives dépendant de ce maître de diapositive.

Par exemple, vous pouvez placer le logo de votre entreprise et quelques images sur le Maître de Diapositive, puis revenir au mode d'édition des diapositives. Vous devriez voir l'image sur chaque diapositive.

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un Maître de Diapositive avec Aspose.Slides :

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = pres.images.add_image(open("image.png", "rb").read())
    pres.masters[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" title="À voir aussi" %}} 

Pour plus d'informations sur l'ajout d'images à une diapositive, consultez l'article sur le [Cadre d'Image](/slides/fr/python-net/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Ajouter un Espace Réservé au Maître de Diapositive**

Ces champs de texte sont des espaces réservés standards sur un Maître de Diapositive :

* Cliquez pour modifier le style de titre du Maître

* Modifier les styles de texte du Maître

* Deuxième niveau

* Troisième niveau

Ils apparaissent également sur les diapositives basées sur le Maître de Diapositive. Vous pouvez modifier ces espaces réservés sur un Maître de Diapositive et les modifications sont automatiquement appliquées aux diapositives.

Dans PowerPoint, vous pouvez ajouter un espace réservé par le chemin Maître de Diapositive -> Insérer un Espace Réservé :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus compliqué d'espaces réservés avec Aspose.Slides. Considérez une diapositive avec des espaces réservés modélisés à partir du Maître de Diapositive :

![todo:image_alt_text](slide-master_6.png)

Nous voulons modifier le formatage du Titre et du Sous-titre sur le Maître de Diapositive de cette manière :

![todo:image_alt_text](slide-master_7.png)

Tout d'abord, nous récupérons le contenu de l'espace réservé de titre à partir de l'objet Maître de Diapositive, puis utilisons le champ `PlaceHolder.FillFormat` :

```python
# Obtient la référence à l'espace réservé de titre du maître
titlePlaceholder = masterSlide.shapes[0]

# Définit le remplissage de format comme remplissage dégradé
titlePlaceholder.fill_format.fill_type = slides.FillType.GRADIENT
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```

Le style et le formatage du titre changeront pour toutes les diapositives basées sur le maître de diapositive :

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="À voir aussi" %}} 

* [Définir le Texte d'invite dans un Espace Réservé](https://docs.aspose.com/slides/python-net/manage-placeholder/)
* [Formatage du Texte](https://docs.aspose.com/slides/python-net/text-formatting/)

{{% /alert %}}

## **Changer l'Arrière-Plan sur le Maître de Diapositive**

Lorsque vous changez la couleur d'arrière-plan d'un maître de diapositive, toutes les diapositives normales de la présentation obtiendront la nouvelle couleur. Ce code Python démontre l'opération :

```python
masterSlide.background.type = slides.BackgroundType.OWN_BACKGROUND
masterSlide.background.fill_format.fill_type = slides.FillType.SOLID
masterSlide.background.fill_format.solid_fill_color.color = draw.Color.gray
```

{{% alert color="primary" title="À voir aussi" %}} 

- [Arrière-plan de Présentation](https://docs.aspose.com/slides/python-net/presentation-background/)

- [Thème de Présentation](https://docs.aspose.com/slides/python-net/presentation-theme/)

{{% /alert %}}

## **Cloner un Maître de Diapositive vers une Autre Présentation**

Pour cloner un Maître de Diapositive vers une autre présentation, appelez la méthode `add_clone(source_slide, dest_master, allow_clone_missing_layout)` à partir de la présentation de destination avec un Maître de Diapositive passé à celui-ci. Ce code Python vous montre comment cloner un Maître de Diapositive vers une autre présentation :

```python
# Ajoute un nouveau maître de diapositive 
pres1MasterSlide = pres.masters.add_clone(masterSlide)
```

## **Ajouter Plusieurs Maîtres de Diapositives à la Présentation**

Aspose.Slides vous permet d'ajouter plusieurs Maîtres de Diapositives et Dispositions de Diapositive à toute présentation donnée. Cela vous permet de mettre en place des styles, des dispositions et des options de formatage pour les diapositives de présentation de nombreuses manières.

Dans PowerPoint, vous pouvez ajouter de nouveaux Maîtres de Diapositives et Dispositions (depuis le menu "Maître de Diapositive") de cette manière :

![todo:image_alt_text](slide-master_9.jpg)

Avec Aspose.Slides, vous pouvez ajouter un nouveau Maître de Diapositive en appelant la méthode `add_clone` :

```python
# Ajoute un nouveau maître de diapositive
secondMasterSlide = pres.masters.add_clone(masterSlide)
```

## **Comparer les Maîtres de Diapositives**

Un Maître de Diapositive implémente l'interface [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) contenant la méthode `equals(slide)`, qui peut ensuite être utilisée pour comparer des diapositives. Elle renvoie `true` pour les Maîtres de Diapositives identiques en structure et contenu statique.

Deux Maîtres de Diapositives sont égaux si leurs formes, styles, textes, animations et autres paramètres, etc. sont égaux. La comparaison ne prend pas en compte les valeurs d'identifiant uniques (par exemple, SlideId) et le contenu dynamique (par exemple, la date actuelle dans l'Espace Réservé Date).

## **Définir le Maître de Diapositive comme la Vue Par Défaut de la Présentation**

Aspose.Slides vous permet de définir un Maître de Diapositive comme la vue par défaut pour une présentation. La vue par défaut est ce que vous voyez en premier lorsque vous ouvrez une présentation.

Ce code vous montre comment définir un Maître de Diapositive comme la vue par défaut d'une présentation en Python :

```py
import aspose.slides as slides

# Instancie une classe Presentation qui représente le fichier de présentation
with slides.Presentation() as presentation:
    # Définit la Vue Par Défaut comme SlideMasterView
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # Sauvegarde la présentation
    presentation.save("PresView.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer un Maître de Diapositive Non Utilisé**

Aspose.Slides fournit la méthode `remove_unused_master_slides` (de la classe [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) pour vous permettre de supprimer des maîtres de diapositives indésirables et non utilisés. Ce code Python vous montre comment supprimer un maître de diapositive d'une présentation PowerPoint :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```