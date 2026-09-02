---
title: Gérer les propriétés de présentation avec Python
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/python-net/presentation-properties/
keywords:
- Propriétés PowerPoint
- propriétés de présentation
- propriétés de document
- propriétés intégrées
- propriétés personnalisées
- propriétés avancées
- gérer les propriétés
- modifier les propriétés
- métadonnées du document
- modifier les métadonnées
- langue de relecture
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides for Python via .NET et rationalisez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint."
---
## **Introduction**

Aspose.Slides prend en charge deux types de propriétés de document : **Built-in** et **Custom**. Ces deux types de propriétés peuvent être facilement accédés et gérés à l’aide de l’API Aspose.Slides.

Aspose.Slides vous permet de travailler avec les propriétés de document de présentation via la classe [DocumentProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/). Une instance de cette classe est renvoyée par la propriété [Presentation.document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/document_properties/). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides for Python via .NET x.x.x seront affichés dans ces champs.
{{% /alert %}} 

## **Gérer les propriétés de la présentation**

Microsoft PowerPoint fournit une fonctionnalité permettant d’ajouter certaines propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit

- Propriétés définies par le système (Built-in)
- Propriétés définies par l'utilisateur (Custom)

Les propriétés **Built-in** contiennent des informations générales sur le document, comme le titre du document, le nom de l’auteur, les statistiques du document, etc. Les propriétés **Custom** sont celles définies par les utilisateurs sous forme de paires **Name/Value**, où le nom et la valeur sont définis par l’utilisateur. Avec Aspose.Slides for Python via .NET, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées. Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Il suffit de cliquer sur l’icône Office et ensuite sur l’élément de menu **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007. Après avoir sélectionné l’élément de menu **Advanced Properties**, une boîte de dialogue apparaît, vous permettant de gérer les propriétés du fichier PowerPoint. Dans la **Properties Dialog**, vous voyez de nombreux onglets tels que **General, Summary, Statistics, Contents and Custom**. Tous ces onglets permettent de configurer différents types d’informations relatives aux fichiers PowerPoint. L’onglet **Custom** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

## **Accéder aux propriétés Built-in**
Ces propriétés exposées par l’objet **IDocumentProperties** comprennent : **Creator(Author)**, **Description**, **Keywords**, **Created** (date de création), **Modified** (date de modification), **Printed** (date du dernier impression), **LastModifiedBy**, **Keywords**, **SharedDoc** (est partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente la présentation
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Créer une référence à l'objet associé à Presentation
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
La modification des propriétés built-in des fichiers de présentation est aussi simple que leur accès. Vous pouvez simplement affecter une valeur de chaîne à n’importe quelle propriété souhaitée et la valeur sera modifiée. Dans l’exemple ci‑dessous, nous montrons comment modifier les propriétés de document built-in du fichier de présentation.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente la Presentation
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Créer une référence à l'objet associé à Presentation
    documentProperties = presentation.document_properties

    # Définir les propriétés intégrées
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # enregistrer votre présentation dans un fichier
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des propriétés Custom de présentation**
Aspose.Slides for Python via .NET permet également aux développeurs d’ajouter des valeurs personnalisées aux propriétés de document de la présentation. Un exemple est fourni ci‑dessous montrant comment définir les propriétés custom pour une présentation.

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
Aspose.Slides for Python via .NET permet également aux développeurs d’accéder aux valeurs des propriétés custom. Un exemple est fourni ci‑dessus montrant comment accéder et modifier toutes ces propriétés custom pour une présentation.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente le PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Créer une référence à l'objet document_properties associé à la Présentation
    documentProperties = presentation.document_properties

    # Accéder et modifier les propriétés personnalisées
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Afficher les noms et valeurs des propriétés personnalisées
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Modifier les valeurs des propriétés personnalisées
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # enregistrer votre présentation dans un fichier
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` renvoie la valeur via la liste à un seul élément passée comme deuxième argument, et la valeur stockée est convertie vers le type de l’élément déjà présent dans cette liste. L’exemple ci‑dessus utilise `[""]`, ce qui lit les propriétés de type chaîne ; pour lire une propriété stockée comme un nombre, passez un espace réservé numérique tel que `[0]`—sinon l’appel lève une `InvalidCastException`.

## **Définir la langue de relecture**
Aspose.Slides fournit la propriété `Language_Id` (exposée par la classe [PortionFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/)) pour vous permettre de définir la langue de relecture d’un document PowerPoint. La langue de relecture est la langue selon laquelle l’orthographe et la grammaire du PowerPoint sont vérifiées.

Ce code Python montre comment définir la langue de relecture pour un PowerPoint :

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # définir l'Id d'une langue de relecture
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
Essayez l’application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés de document via l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## **FAQ**

**Comment puis‑je supprimer une propriété built-in d’une présentation ?**

Les propriétés built-in font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Cependant, vous pouvez soit modifier leurs valeurs, soit les définir comme vides si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété custom qui existe déjà ?**

Si vous ajoutez une propriété custom déjà existante, sa valeur actuelle sera remplacée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, car Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés d’une présentation sans charger complètement la présentation ?**

Oui. Utilisez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) puis [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/read_document_properties/) pour lire les métadonnées du document stockées sans créer d’instance de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/). Consultez [Build a Lightweight Presentation Inventory](/slides/fr/python-net/examine-presentation/) pour un exemple complet de rapport et les limitations spécifiques aux formats.