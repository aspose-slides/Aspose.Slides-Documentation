---
title: Gérer les propriétés de la présentation avec Python
linktitle: Propriétés de la présentation
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
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour Python via .NET et rationalisez la recherche, la marque et le flux de travail dans vos fichiers PowerPoint."
---
## **Introduction**

Aspose.Slides prend en charge deux types de propriétés de document : **Built-in** et **Custom**. Ces deux types de propriétés peuvent être facilement accessibles et gérées à l'aide de l'API Aspose.Slides.

Aspose.Slides vous permet de travailler avec les propriétés de document de présentation via la classe [DocumentProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/). Une instance de cette classe est renvoyée par la propriété [Presentation.document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/document_properties/). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides for Python via .NET x.x.x seront affichés dans ces champs.
{{% /alert %}} 

## **Gérer les propriétés de la présentation**

Microsoft PowerPoint offre une fonctionnalité permettant d'ajouter des propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit

- Propriétés définies par le système (Built-in)
- Propriétés définies par l'utilisateur (Custom)

**Built-in** les propriétés contiennent des informations générales sur le document telles que le titre du document, le nom de l'auteur, les statistiques du document, etc. **Custom** les propriétés sont celles définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont définis par l'utilisateur. En utilisant Aspose.Slides for Python via .NET, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées. Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Il suffit de cliquer sur l'icône Office puis sur l'élément de menu **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007. Après avoir sélectionné l'élément de menu **Advanced Properties**, une boîte de dialogue apparaît permettant de gérer les propriétés de document du fichier PowerPoint. Dans la **Properties Dialog**, vous voyez de nombreux onglets tels que **General, Summary, Statistics, Contents and Custom**. Tous ces onglets permettent de configurer différents types d'informations liées aux fichiers PowerPoint. L'onglet **Custom** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

## **Lire les propriétés publiques d'une présentation chiffrée**

Un mot de passe d'ouverture protège normalement à la fois le contenu de la présentation et les propriétés du document. Lorsqu'une présentation est chiffrée avec [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) défini sur `False`, ses propriétés de document restent publiques. Une application peut alors définir [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/only_load_document_properties/) sur `True` et lire les métadonnées publiques sans fournir le mot de passe d'ouverture.

`only_load_document_properties` contrôle ce que Aspose.Slides charge ; il ne déchiffre rien. Si les propriétés étaient incluses dans le chiffrement, les charger sans le mot de passe échoue. Si la présentation n'est pas chiffrée, l'option est ignorée et la présentation complète est chargée.

L'exemple suivant vérifie le mode de chargement via [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) puis lit les propriétés intégrées via [Presentation.document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/document_properties/) :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Dans ce mode, le contenu des diapositives n'est pas chargé. Les diapositives, maîtres, dispositions, formes, médias et autres objets de présentation sont indisponibles. Les applications doivent toujours vérifier `is_only_document_properties_loaded` avant d'effectuer une opération nécessitant le modèle d'objet complet de la présentation.

{{% alert color="warning" title="Security" %}}
Les métadonnées publiques peuvent révéler les noms d'auteur, les titres, les sujets, les mots‑clés, les informations d'entreprise, les commentaires et les valeurs personnalisées. Chiffrez les propriétés sensibles avec la présentation. Ne les laissez publiques que lorsqu'un système d'indexation, de classification, de recherche ou de gestion de documents a un besoin spécifique d'y accéder sans mot de passe.
{{% /alert %}}

## **Mettre à jour les propriétés d'une présentation chiffrée**

Pour un fichier PPTX chiffré, une présentation chargée avec `only_load_document_properties` est destinée à la lecture des métadonnées publiques. Aspose.Slides ne peut pas enregistrer les propriétés modifiées à partir de cet objet contenant uniquement les métadonnées, car les propriétés publiques doivent rester cohérentes avec les données correspondantes dans la présentation chiffrée. Leur mise à jour nécessite donc le bon mot de passe d'ouverture et un chargement complet.

L'exemple suivant ouvre la présentation avec [LoadOptions.password](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/password/), met à jour les propriétés intégrées publiques, et enregistre le résultat. Il utilise ensuite [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/is_encrypted/) pour vérifier que le chiffrement est préservé et rouvre les métadonnées publiques sans mot de passe afin de vérifier les nouvelles valeurs :

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Si une application n'est pas autorisée à déchiffrer ou à charger le contenu de la présentation, elle doit considérer les propriétés publiques d'un fichier PPTX chiffré comme en lecture seule.

## **Accéder aux propriétés intégrées**
Ces propriétés exposées par l'objet **IDocumentProperties** comprennent : **Creator(Author)**, **Description**, **Keywords**, **Created** (date de création), **Modified** (date de modification), **Printed** (date du dernier impression), **LastModifiedBy**, **Keywords**, **SharedDoc** (est partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**
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

## **Modifier les propriétés intégrées**

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que d'y accéder. Vous pouvez simplement assigner une valeur chaîne à n'importe quelle propriété souhaitée et la valeur sera modifiée. Dans l'exemple ci‑dessus, nous montrons comment modifier les propriétés intégrées du document de la présentation.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente la présentation
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

## **Ajouter des propriétés personnalisées à la présentation**

Aspose.Slides for Python via .NET permet également aux développeurs d'ajouter des valeurs personnalisées aux propriétés du document de présentation. Un exemple est donné ci‑dessus montrant comment définir les propriétés personnalisées pour une présentation.

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

## **Accéder et modifier les propriétés personnalisées**

Aspose.Slides for Python via .NET permet également aux développeurs d'accéder aux valeurs des propriétés personnalisées. Un exemple est donné ci‑dessus montrant comment accéder et modifier toutes ces propriétés personnalisées pour une présentation.

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
    # Enregistrer votre présentation dans un fichier
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` renvoie la valeur via la liste à un élément passée comme deuxième argument, et la valeur stockée est convertie vers le type de l'élément déjà présent dans cette liste. L'exemple ci‑dessus utilise `[""]`, ce qui lit les propriétés de type chaîne ; pour lire une propriété stockée comme nombre, passez un espace réservé numérique tel que `[0]`—sinon l'appel déclenche une `InvalidCastException`.

## **Définir la langue de vérification**

Aspose.Slides fournit la propriété `Language_Id` (exposée par la classe [PortionFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/)) pour vous permettre de définir la langue de vérification d'un document PowerPoint. La langue de vérification est la langue selon laquelle l'orthographe et la grammaire du PowerPoint sont contrôlées.

Ce code Python montre comment définir la langue de vérification pour un PowerPoint :

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

    # définir l'Id d'une langue de vérification
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Définir la langue par défaut**

Ce code Python montre comment définir la langue par défaut pour l'ensemble d'une présentation PowerPoint :

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

Essayez l'application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés de document via l'API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## **FAQ**

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être entièrement supprimées. Cependant, vous pouvez soit modifier leurs valeurs, soit les définir comme vides si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée qui existe déjà, sa valeur existante sera écrasée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, car Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés de la présentation sans charger complètement la présentation ?**

Oui. Utilisez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) puis [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/read_document_properties/) pour lire les métadonnées du document stockées sans créer d'instance de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/). Consultez [Build a Lightweight Presentation Inventory](/slides/fr/python-net/examine-presentation/) pour un exemple complet de reporting et les limitations propres au format.

**Puis‑je lire les propriétés publiques d’une présentation chiffrée sans son mot de passe d’ouverture ?**

Oui. La présentation doit avoir été chiffrée avec `encrypt_document_properties` défini sur `False`, et elle doit être chargée avec `only_load_document_properties` défini sur `True`.

**Puis‑je mettre à jour un fichier PPTX chiffré en mode uniquement propriétés du document ?**

Non. Les données publiques et chiffrées des propriétés doivent rester cohérentes, donc la mise à jour d'un fichier PPTX chiffré nécessite de charger la présentation complète avec le mot de passe d’ouverture correct.