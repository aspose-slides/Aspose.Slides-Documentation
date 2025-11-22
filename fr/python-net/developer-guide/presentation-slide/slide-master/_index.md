---
title: Gérer les maîtres de diapositives PowerPoint en Python
linktitle: Maître de diapositive
type: docs
weight: 80
url: /fr/python-net/slide-master/
keywords:
- maître de diapositive
- maître de diapositive
- maître de diapositive PPT
- plusieurs maîtres de diapositives
- comparer les maîtres de diapositives
- arrière-plan
- espace réservé
- cloner le maître de diapositive
- copier le maître de diapositive
- dupliquer le maître de diapositive
- maître de diapositive inutilisé
- Python
- Aspose.Slides
description: "Automatisez les maîtres de diapositives PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET afin d'optimiser l'efficacité du développement. Un guide complet pour les débutants et les utilisateurs avancés."
---

## **Vue d'ensemble**

Un **Slide Master** est un modèle de diapositive qui définit la mise en page, les styles, le thème, les polices, l'arrière‑plan et d’autres propriétés des diapositives d’une présentation. Si vous souhaitez créer une présentation (ou une série de présentations) avec le même style et le même modèle pour votre entreprise, vous pouvez utiliser un Slide Master.

Un Slide Master est utile car il vous permet de définir et de modifier l’apparence de toutes les diapositives d’une présentation en une seule fois. Aspose.Slides prend en charge le mécanisme de Slide Master de PowerPoint.

VBA permet également de manipuler le Slide Master et d’exécuter les mêmes opérations prises en charge dans PowerPoint : modifier les arrière‑plans, ajouter des formes, personnaliser les mises en page, etc. Aspose.Slides fournit des API flexibles qui vous permettent de travailler avec les Slide Masters et d’exécuter des tâches courantes.

Voici les opérations de base sur le Slide Master :

- Créer un Slide Master.
- Appliquer le Slide Master aux diapositives de la présentation.
- Modifier l’arrière‑plan du Slide Master.
- Ajouter une image, un espace réservé, un SmartArt, etc., au Slide Master.

Voici des opérations plus avancées impliquant le Slide Master :

- Comparer des Slide Masters.
- Fusionner des Slide Masters.
- Appliquer plusieurs Slide Masters.
- Copier une diapositive avec son Slide Master vers une autre présentation.
- Identifier les Slide Masters en double dans les présentations.
- Définir le Slide Master comme vue par défaut de la présentation.

{{% alert color="primary" %}}
Vous pouvez consulter l’[Visionneuse PowerPoint en ligne Aspose](https://products.aspose.app/slides/viewer) car il s’agit d’une implémentation en direct de certains des processus fondamentaux décrits ici.
{{% /alert %}}

## **Comment le Slide Master est appliqué**

Avant de travailler avec un Slide Master, vous pourriez vouloir comprendre comment les Slide Masters sont utilisés dans les présentations et appliqués aux diapositives.

- Chaque présentation possède au moins un Slide Master par défaut.
- Une présentation peut contenir plusieurs Slide Masters. Vous pouvez ajouter plusieurs Slide Masters et les utiliser pour styliser différentes parties d’une présentation de différentes manières.

Dans Aspose.Slides, un Slide Master est représenté par le type [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/).

L’objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) d’Aspose.Slides contient la collection [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) de type [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/), qui regroupe toutes les diapositives maîtres définies dans une présentation.

Au‑delà des opérations CRUD, la classe [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) fournit des méthodes utiles telles que [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) et [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/insert_clone/). Elles étendent la fonctionnalité de clonage de diapositives de base et, lors de la manipulation des Slide Masters, permettent de mettre en œuvre des configurations plus complexes.

Lorsqu’une nouvelle diapositive est ajoutée à une présentation, un Slide Master lui est appliqué automatiquement. Par défaut, le Slide Master de la diapositive précédente est sélectionné.

**Remarque :** Les diapositives de la présentation sont stockées dans la collection [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/), et chaque nouvelle diapositive est ajoutée à la fin de cette collection par défaut. Si une présentation ne contient qu’un seul Slide Master, ce Slide Master est sélectionné pour toutes les nouvelles diapositives. Pour cette raison, vous n’avez pas besoin de spécifier le Slide Master pour chaque nouvelle diapositive que vous créez.

Le même principe s’applique dans PowerPoint et Aspose.Slides. Par exemple, dans PowerPoint, lorsque vous ajoutez une nouvelle diapositive, vous pouvez cliquer dans la zone sous la dernière diapositive, et une nouvelle diapositive (utilisant le Slide Master de la diapositive précédente) sera créée.

![todo:image_alt_text](slide-master_1.jpg)

Dans Aspose.Slides, vous pouvez effectuer la tâche équivalente en utilisant la méthode [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) de la classe [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).

## **Slide Master dans la hiérarchie des diapositives**

Utiliser les **Slide Layouts** avec le **Slide Master** offre une flexibilité maximale. Un Slide Layout peut définir les mêmes types de styles que le Slide Master (arrière‑plan, polices, formes, etc.). Lorsque plusieurs Slide Layouts sont définis sous un Slide Master, ils forment ensemble un système de style cohérent. En appliquant un Slide Layout à une diapositive individuelle, vous pouvez ajuster son style par rapport à ce que le Slide Master fournit.

La priorité est : **Slide Master** → **Slide Layout** → **Slide**.

![todo:image_alt_text](slide-master_2.jpg)

Chaque objet [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) possède une propriété [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) qui contient la liste des mises en page de diapositives. Un [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) possède une propriété [layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) qui référence la mise en page appliquée. L’interaction entre une diapositive et le Slide Master se fait via son Slide Layout.

{{% alert color="info" title="Note" %}}
- Dans Aspose.Slides, toutes les constructions de diapositive (Slide Master, Slide Layout et la diapositive elle‑maître) sont des objets de diapositive qui étendent la classe [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/).
- Étant donné que le Slide Master et le Slide Layout exposent de nombreuses propriétés similaires, vous devez savoir comment leurs valeurs sont appliquées à un objet [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). Le Slide Master est appliqué en premier, suivi du Slide Layout. Par exemple, si le Slide Master et le Slide Layout définissent tous deux un arrière‑plan, la diapositive utilise l’arrière‑plan du Slide Layout.
{{% /alert %}}

## **Ce que comprend un Slide Master**

Pour comprendre comment un Slide Master peut être modifié, vous devez connaître ses composants. Voici les propriétés fondamentales de [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) :

- `background` — obtient/ définit l’arrière‑plan de la diapositive.
- `body_style` — obtient/ définit les styles de texte du corps de la diapositive.
- `shapes` — obtient/ définit toutes les formes du Slide Master (espaces réservés, cadres d’image, etc.).
- `controls` — obtient/ définit les contrôles ActiveX.
- `theme_manager` — obtient le gestionnaire de thème.
- `header_footer_manager` — obtient le gestionnaire d’en‑tête et de pied de page.

Méthodes du Slide Master :

- `get_depending_slides()` — récupère toutes les diapositives dépendant du Slide Master.
- `apply_external_theme_to_depending_slides(fname)` — crée un nouveau Slide Master basé sur le actuel et un thème extérieur, puis applique le nouveau Slide Master à toutes les diapositives dépendantes.

## **Obtenir le Slide Master**

Dans PowerPoint, vous pouvez accéder au Slide Master via **Affichage** → **Slide Master** :

![todo:image_alt_text](slide-master_3.jpg)

En utilisant Aspose.Slides, vous pouvez accéder à un Slide Master comme suit :
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obtenez la première diapositive maître de la présentation.
    master_slide = presentation.masters[0]
```


La classe [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) représente un Slide Master. La propriété [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) (une [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) contient tous les Slide Masters définis dans la présentation.

## **Ajouter une image au Slide Master**

Lorsque vous ajoutez une image à un Slide Master, cette image apparaît sur toutes les diapositives qui dépendent de ce maître.

Par exemple, placez le logo de votre entreprise ou d’autres images sur le Slide Master, puis revenez à la vue Normale. Vous verrez l’image sur chaque diapositive dépendante.

![todo:image_alt_text](slide-master_4.png)

Vous pouvez ajouter des images à un Slide Master avec Aspose.Slides :
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    with open("image.png", "rb") as image_stream:
        image = presentation.images.add_image(image_stream.read())

    master_slide = presentation.masters[0]
    master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" title="See also" %}}
Pour plus d’informations sur l’ajout d’images à une diapositive, consultez l’article [Ajouter des cadres d’image aux présentations avec Python](/slides/fr/python-net/picture-frame/).
{{% /alert %}}

## **Ajouter un espace réservé au Slide Master**

Ces champs de texte sont les espaces réservés standard sur un Slide Master :

- Cliquez pour modifier le style de titre du maître
- Modifier les styles de texte du maître
- Deuxième niveau
- Troisième niveau

Ces espaces réservés apparaissent également sur les diapositives basées sur le Slide Master. Vous pouvez les modifier sur le Slide Master, et les changements sont appliqués automatiquement aux diapositives.

Dans PowerPoint, vous pouvez ajouter un espace réservé via **Slide Master** → **Insert Placeholder** :

![todo:image_alt_text](slide-master_5.png)

Examinons un exemple plus complexe d’espaces réservés dans Aspose.Slides. Considérez une diapositive avec des espaces réservés hérités du Slide Master :

![todo:image_alt_text](slide-master_6.png)

Nous voulons mettre à jour le formatage du titre et du sous‑titre sur le Slide Master comme suit :

![todo:image_alt_text](slide-master_7.png)

Tout d’abord, récupérez l’espace réservé du titre depuis le Slide Master, puis utilisez la propriété `PlaceHolder.fill_format` :
```python
# Obtenez une référence à l'espace réservé du titre de la diapositive maître.
title_placeholder = master_slide.shapes[0]

# Définir le format de remplissage sur un dégradé.
title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
title_placeholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
title_placeholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
title_placeholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```


Le style et le formatage du titre changeront sur toutes les diapositives basées sur le Slide Master :

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}}
* [Gérer les espaces réservés dans les présentations avec Python](/slides/fr/python-net/manage-placeholder/)
* [Formater le texte PowerPoint en Python](/slides/fr/python-net/text-formatting/)
{{% /alert %}}

## **Modifier l’arrière‑plan du Slide Master**

Lorsque vous modifiez la couleur d’arrière‑plan d’un Slide Master, toutes les diapositives ordinaires de la présentation héritent de la nouvelle couleur. Le code Python suivant le démontre :
```python
master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
master_slide.background.fill_format.fill_type = slides.FillType.SOLID
master_slide.background.fill_format.solid_fill_color.color = draw.Color.gray
```


{{% alert color="primary" title="See also" %}}
* [Gérer les arrière‑plans de présentation en Python](/slides/fr/python-net/presentation-background/)
* [Gérer les thèmes de présentation PowerPoint en Python](/slides/fr/python-net/presentation-theme/)
{{% /alert %}}

## **Ajouter plusieurs Slide Masters à une présentation**

Aspose.Slides vous permet d’ajouter plusieurs Slide Masters et Slide Layouts à n’importe quelle présentation. Cela vous permet de configurer les styles, les mises en page et les options de formatage des diapositives de nombreuses manières différentes.

Dans PowerPoint, vous pouvez ajouter de nouveaux Slide Masters et Slide Layouts depuis le menu **Slide Master** comme suit :

![todo:image_alt_text](slide-master_9.jpg)

En utilisant Aspose.Slides, vous pouvez ajouter un nouveau Slide Master en appelant la méthode `add_clone` :
```python
# Ajouter une nouvelle diapositive maître.
master_slide2 = presentation.masters.add_clone(master_slide1)
```


## **Comparer les Slide Masters**

Un Slide Master étend la classe [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) qui comprend la méthode `equals(slide)` pour comparer des diapositives. Cette méthode renvoie vrai lorsque les Slide Masters sont identiques en structure et en contenu statique.

Deux Slide Masters sont considérés égaux si leurs formes, styles, texte, animations et autres paramètres sont les mêmes. La comparaison ignore les valeurs d’identifiants uniques (par ex., `slide_id`) et le contenu dynamique (par ex., la date actuelle dans un espace réservé de type Date).

## **Définir le Slide Master comme vue par défaut de la présentation**

Aspose.Slides vous permet de définir un Slide Master comme vue par défaut de la présentation. La vue par défaut est ce que vous voyez en premier lorsque vous ouvrez la présentation. L’exemple Python suivant montre comment définir un Slide Master comme vue par défaut de la présentation :
```py
import aspose.slides as slides

# Instanciez la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:
    # Définissez la vue par défaut comme la vue Slide Master.
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # Enregistrez la présentation.
    presentation.save("presentation_view.pptx", slides.export.SaveFormat.PPTX)
```


## **Supprimer un Slide Master inutilisé**

Aspose.Slides fournit la méthode `remove_unused_master_slides` (dans la classe [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) pour supprimer les diapositives maîtres indésirables et inutilisées. Le code Python suivant montre comment retirer les diapositives maîtres inutilisées d’une présentation PowerPoint :
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Qu’est‑ce qu’un Slide Master dans PowerPoint ?**

Un Slide Master est un modèle de diapositive qui définit la mise en page, les styles, les thèmes, les polices, l’arrière‑plan et d’autres propriétés des diapositives d’une présentation. Il vous permet de définir et de modifier l’apparence de toutes les diapositives de la présentation en une seule fois.

**Comment les Slide Masters sont‑ils liés aux Slide Layouts ?**

Les Slide Layouts fonctionnent en conjonction avec les Slide Masters pour offrir de la flexibilité dans la conception des diapositives. Alors qu’un Slide Master définit des styles et thèmes globaux, les [Slide Layouts](/slides/fr/python-net/slide-layout/) permettent des variantes dans l’agencement du contenu. La hiérarchie est la suivante :

- **Slide Master** → Définit les styles globaux.
- **Slide Layout** → Fournit différents agencements de contenu.
- **Slide** → Hérite du design de son Slide Layout.

**Puis‑je avoir plusieurs Slide Masters dans une même présentation ?**

Oui, une présentation peut contenir plusieurs Slide Masters. Cela vous permet de styliser différentes sections d’une présentation de plusieurs manières, offrant ainsi de la flexibilité dans le design.

**Comment accéder et modifier un Slide Master avec Aspose.Slides ?**

Dans Aspose.Slides, un Slide Master est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). Vous pouvez accéder à un Slide Master via la propriété [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) de l’objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).