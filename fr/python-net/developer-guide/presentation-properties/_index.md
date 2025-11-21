---
title: Gérer les propriétés de présentation avec Python
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/python-net/presentation-properties/
keywords:
- Propriétés PowerPoint
- Propriétés de présentation
- Propriétés de document
- Propriétés intégrées
- Propriétés personnalisées
- Propriétés avancées
- Gérer les propriétés
- Modifier les propriétés
- Métadonnées de document
- Modifier les métadonnées
- Langue de vérification
- Langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides for Python via .NET et simplifiez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint."
---

## **À propos des propriétés de présentation**

Comme nous l'avons décrit précédemment, Aspose.Slides for Python via .NET prend en charge deux types de propriétés de document, à savoir les propriétés **Built-in** et **Custom**. Ainsi, les développeurs peuvent accéder aux deux types de propriétés à l'aide de l'API Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET fournit une classe [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) qui représente les propriétés du document associées à un fichier de présentation via la propriété [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/). Les développeurs peuvent utiliser la propriété [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) exposée par l'objet **Presentation** pour accéder aux propriétés du document des fichiers de présentation comme décrit ci-dessous :

{{% alert color="primary" %}} 
Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides for Python via .NET x.x.x seront affichés dans ces champs.
{{% /alert %}} 

## **Gestion des propriétés de présentation**

Microsoft PowerPoint propose une fonction permettant d'ajouter des propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit

- Propriétés définies par le système (Built-in)
- Propriétés définies par l'utilisateur (Custom)

Les propriétés **Built-in** contiennent des informations générales sur le document, telles que le titre du document, le nom de l'auteur, les statistiques du document, etc. Les propriétés **Custom** sont celles définies par les utilisateurs sous forme de paires **Name/Value**, où le nom et la valeur sont définis par l'utilisateur. En utilisant Aspose.Slides for Python via .NET, les développeurs peuvent accéder aux valeurs des propriétés built-in ainsi qu'aux propriétés custom et les modifier. Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Il suffit de cliquer sur l'icône Office puis sur le menu **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007. Après avoir sélectionné l'élément de menu **Advanced Properties**, une boîte de dialogue apparaît, vous permettant de gérer les propriétés du fichier PowerPoint. Dans la **Properties Dialog**, vous constatez plusieurs onglets tels que **General, Summary, Statistics, Contents and Custom**. Tous ces onglets permettent de configurer différents types d'informations liées aux fichiers PowerPoint. L'onglet **Custom** est utilisé pour gérer les propriétés custom des fichiers PowerPoint.

## **Accéder aux propriétés Built-in**

Ces propriétés exposées par l'objet **IDocumentProperties** comprennent : **Creator(Author)**, **Description**, **Keywords**, **Created** (date de création), **Modified** (date de modification), **Printed** (date du dernier impression), **LastModifiedBy**, **Keywords**, **SharedDoc** (est‑il partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente la présentation
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Créer une référence à l'objet associé à la présentation
    documentProperties = pres.document_properties

    # Afficher les propriétés intégrées
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```


## **Modifier les propriétés Built-in**

Modifier les propriétés built-in des fichiers de présentation est aussi simple que de les accéder. Il suffit d'assigner une chaîne de caractères à la propriété souhaitée et la valeur de la propriété sera modifiée. Dans l'exemple ci‑dessus, nous montrons comment modifier les propriétés de document built-in du fichier de présentation.
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente la présentation
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Créer une référence à l'objet associé à la présentation
    documentProperties = presentation.document_properties

    # Définir les propriétés intégrées
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Enregistrer votre présentation dans un fichier
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Ajouter des propriétés Custom à la présentation**

Aspose.Slides for Python via .NET permet également aux développeurs d'ajouter des valeurs custom aux propriétés de document d'une présentation. Un exemple est fourni ci‑dessus montrant comment définir les propriétés custom d'une présentation.
```py
import aspose.slides as slides

# Instancier la classe Presentation
with slides.Presentation() as presentation:
    # Récupérer les propriétés du document
    documentProperties = presentation.document_properties

    # Ajouter des propriétés personnalisées
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Obtenir le nom de la propriété à un indice particulier
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Supprimer la propriété sélectionnée
    documentProperties.remove_custom_property(getPropertyName)

    # Enregistrer la présentation
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Accéder et modifier les propriétés Custom**

Aspose.Slides for Python via .NET permet également aux développeurs d'accéder aux valeurs des propriétés custom. Un exemple est fourni ci‑dessus montrant comment accéder et modifier toutes ces propriétés custom pour une présentation.
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente le PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Créer une référence à l'objet document_properties associé à la Présentation
    documentProperties = presentation.document_properties

    # Accéder et modifier les propriétés personnalisées
    for i in range(documentProperties.count_of_custom_properties):
        # Afficher les noms et les valeurs des propriétés personnalisées
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Modifier les valeurs des propriétés personnalisées
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # enregistrer votre présentation dans un fichier
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la langue de vérification**

Aspose.Slides fournit la propriété `Language_Id` (exposée par la classe [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)) permettant de définir la langue de vérification d'un document PowerPoint. La langue de vérification est la langue pour laquelle l'orthographe et la grammaire du PowerPoint sont contrôlées.

Ce code Python montre comment définir la langue de vérification pour un PowerPoint :
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

    # définir l'Id de la langue de vérification
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```


## **Définir la langue par défaut**

Ce code Python montre comment définir la langue par défaut pour l’ensemble d’une présentation PowerPoint :
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```


## **Exemple en direct**

Essayez l'application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) pour découvrir comment travailler avec les propriétés de document via l'API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Comment puis‑je supprimer une propriété built‑in d’une présentation ?**

Les propriétés built‑in font partie intégrante de la présentation et ne peuvent pas être entièrement supprimées. Cependant, vous pouvez soit modifier leurs valeurs, soit les définir à vide si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété custom qui existe déjà ?**

Si vous ajoutez une propriété custom qui existe déjà, sa valeur actuelle sera écrasée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés d’une présentation sans charger complètement la présentation ?**

Oui, il est possible d’accéder aux propriétés d’une présentation sans la charger entièrement en utilisant la méthode [get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) de la classe [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/). Ensuite, utilisez la méthode [read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) de la classe [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) afin de lire les propriétés de manière efficace, ce qui économise de la mémoire et améliore les performances.