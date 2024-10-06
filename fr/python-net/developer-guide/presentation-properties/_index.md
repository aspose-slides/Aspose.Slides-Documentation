---
title: Propriétés de Présentation
type: docs
weight: 70
url: /python-net/presentation-properties/
keywords: "propriétés PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Propriétés de présentation PowerPoint en Python"
---

## **Exemple en Direct**
Essayez [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) l'application en ligne pour voir comment travailler avec les propriétés de document via Aspose.Slides API :

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **À propos des Propriétés de Présentation**
Comme nous l'avons décrit précédemment, Aspose.Slides pour Python via .NET prend en charge deux types de propriétés de document, qui sont des propriétés **Intégrées** et **Personnalisées**. Ainsi, les développeurs peuvent accéder à ces deux types de propriétés à l'aide d'Aspose.Slides pour Python via .NET API. Aspose.Slides pour Python via .NET fournit une classe [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) qui représente les propriétés de document associées à un fichier de présentation via la propriété [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). Les développeurs peuvent utiliser la propriété [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) exposée par l'objet **Presentation** pour accéder aux propriétés de document des fichiers de présentation comme décrit ci-dessous :

{{% alert color="primary" %}} 

Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides pour Python via .NET x.x.x seront affichés dans ces champs.

{{% /alert %}} 


## **Gérer les Propriétés de Présentation**
Microsoft PowerPoint offre une fonctionnalité permettant d'ajouter certaines propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit :

- Propriétés Définies par le Système (Intégrées)
- Propriétés Définies par l'Utilisateur (Personnalisées)

Les propriétés **Intégrées** contiennent des informations générales sur le document, telles que le titre du document, le nom de l'auteur, les statistiques du document, etc. Les propriétés **Personnalisées** sont celles qui sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, où à la fois le nom et la valeur sont définis par l'utilisateur. En utilisant Aspose.Slides pour Python via .NET, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées. Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Tout ce que vous avez à faire est de cliquer sur l'icône Office et ensuite sur le menu **Préparer | Propriétés | Propriétés Avancées** de Microsoft PowerPoint 2007. Après avoir sélectionné le menu **Propriétés Avancées**, une boîte de dialogue apparaîtra vous permettant de gérer les propriétés de document du fichier PowerPoint. Dans la **Boîte de Dialogue des Propriétés**, vous pouvez voir qu'il existe de nombreux onglets comme **Général, Résumé, Statistiques, Contenu et Personnalisé**. Tous ces onglets permettent de configurer différents types d'informations liées aux fichiers PowerPoint. L'onglet **Personnalisé** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

## **Accéder aux Propriétés Intégrées**
Ces propriétés exposées par l'objet **IDocumentProperties** comprennent : **Creator(Author)**, **Description**, **Keywords** **Created** (Date de Création), **Modified** Date de Modification, **Printed** Dernière Date d'Impression, **LastModifiedBy**, **Keywords**, **SharedDoc** (Est partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente la présentation
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Créer une référence à l'objet associé à la Présentation
    documentProperties = pres.document_properties

    # Afficher les propriétés intégrées
    print("catégorie : " + documentProperties.category)
    print("Statut Actuel : " + documentProperties.content_status)
    print("Date de Création : " + str(documentProperties.created_time))
    print("Auteur : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("Mots-Clés : " + documentProperties.keywords)
    print("Dernier Modifié par : " + documentProperties.last_saved_by)
    print("Superviseur : " + documentProperties.manager)
    print("Date de Modification : " + str(documentProperties.last_saved_time))
    print("Format de Présentation : " + documentProperties.presentation_format)
    print("Dernière Date d'Impression : " + str(documentProperties.last_printed))
    print("Est Partagé entre producteurs : " + str(documentProperties.shared_doc))
    print("Sujet : " + documentProperties.subject)
    print("Titre : " + documentProperties.title)
```
## **Modifier les Propriétés Intégrées**
Modifier les propriétés intégrées des fichiers de présentation est aussi facile que d'y accéder. Vous pouvez simplement attribuer une valeur de chaîne à n'importe quelle propriété désirée et la valeur de la propriété serait modifiée. Dans l'exemple ci-dessous, nous avons démontré comment nous pouvons modifier les propriétés de document intégrées du fichier de présentation.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente la Présentation
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Créer une référence à l'objet associé à la Présentation
    documentProperties = presentation.document_properties

    # Définir les propriétés intégrées
    documentProperties.author = "Aspose.Slides pour .NET"
    documentProperties.title = "Modification des Propriétés de Présentation"
    documentProperties.subject = "Sujet Aspose"
    documentProperties.comments = "Description Aspose"
    documentProperties.manager = "Gestionnaire Aspose"

    # enregistrez votre présentation dans un fichier
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des Propriétés Personnalisées de Présentation**
Aspose.Slides pour Python via .NET permet également aux développeurs d'ajouter des valeurs personnalisées pour les propriétés de Document de présentation. Un exemple est donné ci-dessous qui montre comment définir les propriétés personnalisées pour une présentation.

```py
import aspose.slides as slides

# Instancier la classe Presentation
with slides.Presentation() as presentation:
    # Obtenir les Propriétés du Document
    documentProperties = presentation.document_properties

    # Ajout de Propriétés Personnalisées
    documentProperties.set_custom_property_value("Nouvelle Personnalisée", 12)
    documentProperties.set_custom_property_value("Mon Nom", "Mudassir")
    documentProperties.set_custom_property_value("Personnalisé", 124)

    # Obtenir le nom de la propriété à un index particulier
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Supprimer la propriété sélectionnée
    documentProperties.remove_custom_property(getPropertyName)

    # Enregistrer la présentation
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder et Modifier les Propriétés Personnalisées**
Aspose.Slides pour Python via .NET permet également aux développeurs d'accéder aux valeurs des propriétés personnalisées. Un exemple est donné ci-dessous qui montre comment accéder et modifier toutes ces propriétés personnalisées pour une présentation.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente le PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Créer une référence à l'objet document_properties associé à la Présentation
    documentProperties = presentation.document_properties

    # Accéder et modifier les propriétés personnalisées
    for i in range(documentProperties.count_of_custom_properties):
        # Afficher les noms et valeurs des propriétés personnalisées
        print("Nom de la Propriété Personnalisée : " + documentProperties.get_custom_property_name(i))
        print("Valeur de la Propriété Personnalisée : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Modifier les valeurs des propriétés personnalisées
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "Nouvelle Valeur " + str(i + 1))
    # enregistrez votre présentation dans un fichier
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Vérifier si la Présentation est Modifiée ou Créée**
Aspose.Slides pour Python via .NET fournit une fonctionnalité pour vérifier si une présentation est modifiée ou créée. Un exemple est donné ci-dessous qui montre comment vérifier si la présentation est créée ou modifiée.

```py
import aspose.slides as slides

info =slides.PresentationFactory.instance.get_presentation_info(path + "AccessModifyingProperties.pptx")
props = info.read_document_properties()

print(props.name_of_application)
print(props.app_version)
```

## **Définir la Langue de Vérification**

Aspose.Slides fournit la propriété `Language_Id` (exposée par la classe [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)) pour vous permettre de définir la langue de vérification pour un document PowerPoint. La langue de vérification est la langue pour laquelle les orthographes et la grammaire dans PowerPoint sont vérifiées.

Ce code Python vous montre comment définir la langue de vérification pour un PowerPoint :

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # définir l'Id d'une langue de vérification
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Définir la Langue par Défaut**

Ce code Python vous montre comment définir la langue par défaut pour l'ensemble d'une présentation PowerPoint :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "Nouveau Texte"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```