---
title: Gérer les hyperliens de présentation en Python
linktitle: Gérer les hyperliens
type: docs
weight: 20
url: /fr/python-net/manage-hyperlinks/
keywords:
- ajouter URL
- ajouter hyperlien
- créer hyperlien
- formater hyperlien
- supprimer hyperlien
- mettre à jour hyperlien
- hyperlien texte
- hyperlien diapositive
- hyperlien forme
- hyperlien image
- hyperlien vidéo
- hyperlien modifiable
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajoutez, formatez, mettez à jour et supprimez des hyperliens dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET, en utilisant des exemples Python."
---
## **Introduction**

Un hyperlien relie le contenu d’une présentation à un site Web ou à un emplacement à l’intérieur de la présentation. Dans PowerPoint, les hyperliens servent généralement deux objectifs :

* Ouvrir un site Web à partir d’un texte, d’une forme ou d’un cadre multimédia.
* Naviguer vers une autre diapositive, par exemple depuis une table des matières.

Aspose.Slides for Python via .NET vous permet d’ajouter ces liens, de contrôler leur apparence et leur son, de mettre à jour leurs propriétés et de les supprimer. Les exemples ci‑dessous montrent comment travailler avec les hyperliens sur des éléments individuels et comment accéder aux hyperliens au niveau de la présentation, de la diapositive ou du cadre de texte.

{{% alert color="info" title="Remarque" %}}
Vous pouvez également modifier les présentations avec l’[éditeur en ligne gratuit Aspose PowerPoint](https://products.aspose.app/slides/fr/editor).
{{% /alert %}}

## **Ajouter des hyperliens URL**

Vous pouvez attribuer une URL de site Web à du texte, à une forme ou à un cadre multimédia. L’élément auquel vous attribuez l’hyperlien détermine la zone cliquable : une portion de texte lie le texte sélectionné, tandis qu’une forme ou un cadre lie l’objet de la diapositive.

### **Ajouter des hyperliens URL au texte**

Pour lier du texte à un site Web, attribuez un [Hyperlink](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/) à la propriété [hyperlink_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/hyperlink_click/) de la portion de texte, comme indiqué ci‑dessous. Seule cette portion de texte devient cliquable.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Ajouter des hyperliens URL aux formes et aux cadres multimédia**

Pour rendre une forme ou un cadre cliquable, définissez sa propriété [hyperlink_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/hyperlink_click/). L’hyperlien appartient à l’objet lui‑même plutôt qu’à une portion de texte à l’intérieur.

La même approche s’applique aux cadres d’image, audio et vidéo : attribuez l’hyperlien au cadre et, si besoin, définissez le [tooltip](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/tooltip/) du lien.

L’exemple suivant rend un rectangle cliquable :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Utiliser les hyperliens pour créer une table des matières**

Les hyperliens internes permettent aux lecteurs de passer d’une table des matières à une diapositive spécifique. L’exemple suivant utilise [set_internal_hyperlink_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) pour lier le texte « Page 2 » de la première diapositive à la deuxième diapositive.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Formater les hyperliens**

### **Couleur**

La propriété [color_source](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/color_source/) de [Hyperlink](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/) détermine si un hyperlien utilise la couleur d’hyperlien de la présentation ou le format de la portion de texte. Pour appliquer une couleur de texte personnalisée, choisissez [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkcolorsource/) et définissez la couleur de remplissage de la portion. Cette fonctionnalité a été introduite dans PowerPoint 2019 ; les versions antérieures n’appliquent pas ce paramètre.

L’exemple suivant ajoute deux hyperliens texte à la même diapositive. Le premier utilise un remplissage rouge, tandis que le second conserve la couleur d’hyperlien par défaut.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Son**

Un hyperlien peut jouer un son lorsqu’il est activé ou arrêter un son déjà en cours de lecture. Utilisez les propriétés suivantes pour configurer ces comportements :

- [Hyperlink.sound](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/sound/) indique le fichier audio associé à l’hyperlien.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/stop_sound_on_click/) contrôle si l’activation de l’hyperlien arrête le son précédent.

#### **Ajouter un son à un hyperlien**

L’exemple suivant charge `sampleaudio.wav` et l’associe à un bouton sur la première diapositive. Cliquer sur le bouton joue le son et passe à la diapositive suivante. Une seconde forme sur la même diapositive arrête le son précédent lorsqu’on clique dessus, sans effectuer d’action de navigation.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Extraire le son d’un hyperlien**

L’exemple suivant ouvre la présentation créée ci‑haut et lit le son d’hyperlien de la première forme dans la mémoire via [sound](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/sound/) et [binary_data](https://reference.aspose.com/slides/fr/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Infobulle et paramètres d’interaction**

Vous pouvez mettre à jour les propriétés suivantes de [Hyperlink](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/) après avoir attribué un hyperlien à du texte ou à une forme :

- [tooltip](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/tooltip/) définit le texte que le lecteur peut afficher comme indice pour le lien.
- [target_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/target_frame/) indique le cadre cible au sein d’un frameset HTML parent, le cas échéant.
- [history](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/history/) contrôle si l’activation du lien ajoute sa destination à la liste des hyperliens consultés.
- [highlight_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/highlight_click/) contrôle si l’hyperlien est mis en évidence lorsqu’on clique dessus.

## **Supprimer les hyperliens des présentations**

Utilisez [get_any_hyperlinks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) pour collecter les conteneurs d’hyperliens, y compris les liens de portions de texte, avant de les modifier. L’exemple suivant supprime les deux types d’activation de la première diapositive. Pour ne supprimer qu’un seul type, appelez uniquement [remove_hyperlink_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) ou [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) ; la suppression d’une action de clic ne supprime pas son pendant‑survol correspondant.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Pour une suppression inconditionnelle, [remove_all_hyperlinks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) supprime les deux types d’activation dans la portée sélectionnée en un seul appel. Pour un nettoyage sélectif couvrant les maîtres, les dispositions et les notes, consultez [Rapporter, assainir et vérifier les hyperliens](#report-sanitize-and-verify-hyperlinks).

## **Construire un inventaire complet des hyperliens**

Avant de distribuer une présentation, inventoriez ses actions interactives ainsi que ses liens Web. [get_any_hyperlinks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) renvoie des objets [IHyperlinkContainer](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ihyperlinkcontainer/), pas une liste plate de chaînes URL. Examinez à la fois [hyperlink_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) et [hyperlink_mouse_over](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) sur chaque conteneur. Ils sont indépendants : le même conteneur peut exposer les deux actions, de sorte qu’un rapport complet nécessite jusqu’à deux lignes par conteneur.

Ne scanner que les hyperliens au niveau des formes peut manquer les liens attachés aux portions de texte. Interrogez plutôt la portée appropriée et conservez les conteneurs retournés afin de pouvoir mettre à jour ou supprimer leurs actions ultérieurement.

### **Interroger les portées Présentation, Diapositive et Cadre de texte**

La classe [HyperlinkQueries](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkqueries/) est accessible via [Presentation.hyperlink_queries](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslide/hyperlink_queries/) et [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/hyperlink_queries/). Chaque portée prend en charge les mêmes requêtes :

- [get_hyperlink_clicks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) renvoie les conteneurs avec une action de clic.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) renvoie les conteneurs avec une action de survol.
- [get_any_hyperlinks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) renvoie les conteneurs avec l’une ou l’autre des actions.

L’exemple suivant crée `hyperlink-audit-input.pptx` avec un lien de clic externe, un lien de survol de fichier, une navigation interne de diapositive, un lien de survol de texte et une action macro. Aucun de ces actions n’est exécuté. Les trois requêtes fonctionnent à chaque portée ; les comptes décrivent des conteneurs, pas le nombre total d’actions. La portée du cadre de texte exclut les liens propres à la forme englobante.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

Dans cet exemple, les requêtes de présentation et de diapositive rapportent chacune trois conteneurs de clic, deux conteneurs de survol et trois conteneurs avec l’une ou l’autre des actions. La requête du cadre de texte rapporte un conteneur dans chaque catégorie.

### **Classer les actions et destinations**

Utilisez [Hyperlink.action_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/action_type/) pour interpréter une action avant d’interpréter sa destination. Les valeurs de [HyperlinkActionType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkactiontype/) couvrent plus que la navigation Web :

| Valeurs | Signification pour un audit |
| --- | --- |
| `HYPERLINK` | Hyperlien externe ; inspectez l’URL et son schéma. |
| `JUMP_SPECIFIC_SLIDE` | Navigation interne vers une diapositive particulière. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Navigation de diaporama intégrée, résolue dans le contexte du diaporama. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Terminer le diaporama en cours ou démarrer un diaporama personnalisé. |
| `START_MACRO` | Exécuter une macro. |
| `START_PROGRAM` | Lancer un programme. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Ouvrir un fichier ou une autre présentation ; à examiner séparément des URL Web. |
| `START_STOP_MEDIA` | Démarrer ou arrêter la lecture multimédia. |
| `NO_ACTION`, `UNKNOWN` | Aucun acte de navigation, ou une action non reconnue nécessitant une révision. |

Lisez les destinations externes via [external_url](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/external_url/) et les destinations internes spécifiques via [target_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/target_slide/). Les actions internes et les commandes intégrées peuvent ne pas avoir d’URL externe ; une URL vide ne signifie pas que le conteneur est dépourvu d’action. Conservez [external_url_original](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/external_url_original/) lorsqu’elle diffère de l’URL normalisée, et incluez le [tooltip](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlink/tooltip/) lorsqu’il est disponible.

### **Rapporter, assainir et vérifier les hyperliens**

L’exemple Python suivant lit une présentation existante (utilisez le fichier créé précédemment), écrit `hyperlink-audit.json`, applique une politique, enregistre `hyperlink-sanitized.pptx` et le rouvre afin de vérifier à nouveau les deux types d’activation. Il collecte les conteneurs avant de les modifier et interroge chaque portée de diapositive une seule fois pour éviter les traitements en double. Les requêtes de présentation couvrent les diapositives ordinaires ; pour un inventaire à l’échelle du package, l’exemple interroge les diapositives ordinaires, les maîtres, les dispositions, les notes et les maîtres de notes et de documents d’accompagnement lorsqu’ils sont présents.

Le rapport enregistre un index de diapositive basé sur 1 et le [slide_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslide/slide_id/) lorsqu’il est disponible. Le collecteur conserve la diapositive propriétaire et la portée avec chaque conteneur retourné. Les maîtres, dispositions et notes n’ont pas d’index de diapositive ordinaire et sont identifiés par leur portée. Les conteneurs de forme et les conteneurs de format de portion de texte sont étiquetés séparément ; les autres types de conteneurs conservent leur nom de type d’exécution. Chaque conteneur reçoit un ID local au rapport afin que ses deux actions puissent être corrélées.

Cette politique d’application délibérément restrictive n’autorise que les URL HTTPS absolues et les cibles de diapositives internes valides. Elle rejette les macros, programmes, actions de fichiers, autres actions de diaporama, actions inconnues et autres schémas d’URL. Ces rejets sont des décisions de politique, pas un verdict de sécurité d’Aspose.Slides. HTTPS seul n’établit pas la confiance : ajoutez des listes blanches d’hôtes et d’autres contrôles pour votre application. Les URL externes d’origine et normalisées sont toutes deux vérifiées. L’exemple examine les métadonnées sans suivre les liens ni exécuter les actions.

Pour la remédiation, le [hyperlink_manager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) du conteneur prend en charge [set_external_hyperlink_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) et [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Ici, les liens de clic externes interdits sont remplacés par une page d’atterrissage HTTPS fixe ; les autres clics interdits et les actions de survol interdites sont supprimés séparément. Définissez `replace_external_clicks` à `False` pour supprimer toutes les violations de politique. Choisissez une page de remplacement détenue par l’application avant le déploiement.

Le drapeau d’exportation du rapport utilise une politique de révision PDF conservatrice : signalez les actions de survol et tout ce qui n’est pas un lien externe ou un saut de diapositive spécifique comme potentiellement non pris en charge. Il s’agit d’un indice de révision, pas d’un test de capacité ou d’une garantie que les liens non signalés survivront à l’export. Les exportations PDF et HTML prises en charge peuvent préserver les hyperliens, selon l’action, les options d’exportation et le visualiseur. Les [images](/slides/fr/python-net/convert-powerpoint-to-png/) et [vidéos](/slides/fr/python-net/convert-powerpoint-to-video/) raster ne peuvent pas préserver les hyperliens interactifs ; signalez chaque action lors d’un audit pour ces sorties.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Query each slide scope once, retaining its owner with each container.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

Avec l’entrée créée ci‑haut, le rapport contient cinq lignes d’action. Le lien de survol de fichier et la macro de clic sont supprimés, tandis que les liens HTTPS et la navigation interne de diapositive restent. La vérification indique zéro action interdite. Une entrée contenant une URL de clic externe interdite teste également la branche de remplacement. Un conteneur avec un clic autorisé et un survol interdit conserve son action de clic.

Ce nettoyage sélectif diffère de [remove_all_hyperlinks](https://reference.aspose.com/slides/fr/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), qui supprime les deux types d’activation dans la portée sélectionnée quel que soit la politique. La vérification ici ne contrôle que les actions d’hyperlien ; elle ne supprime pas les projets VBA intégrés, les objets OLE ou tout autre contenu actif, et ne valide pas un fichier PDF ou HTML exporté.

## **FAQ**

**Comment puis‑je créer un lien vers une section ou sa première diapositive ?**

Les sections dans PowerPoint regroupent les diapositives, mais un hyperlien interne cible une diapositive individuelle. Pour créer une navigation vers une section, liez‑la à la première diapositive de cette section.

**Puis‑je attacher un hyperlien aux éléments du maître afin qu’il fonctionne sur toutes les diapositives ?**

Oui. Les éléments du maître et des dispositions prennent en charge les hyperliens. Les liens sur ces éléments sont disponibles pendant le diaporama sur les diapositives qui utilisent le maître ou la disposition correspondante.

**Les hyperliens seront‑ils conservés lors de l’exportation vers PDF, HTML, images ou vidéo ?**

Les exportations PDF et HTML prises en charge peuvent conserver les hyperliens ; les images raster et les vidéos ne le peuvent pas. Consultez les considérations d’exportation dans [Rapporter, assainir et vérifier les hyperliens](#report-sanitize-and-verify-hyperlinks).