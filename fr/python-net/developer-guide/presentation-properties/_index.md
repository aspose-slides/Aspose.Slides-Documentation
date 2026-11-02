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
- Métadonnées du document
- Modifier les métadonnées
- Langue de révision
- Langue par défaut
- PowerPoint
- OpenDocument
- Présentation
- Python
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour Python via .NET et rationalisez la recherche, l'image de marque et le flux de travail dans vos fichiers PowerPoint."
---
## **Introduction**

Aspose.Slides for Python via .NET prend en charge les propriétés de document **intégrées** et **personnalisées**. Utilisez ces propriétés pour lire et mettre à jour les métadonnées de la présentation, telles que l'auteur, le titre et les valeurs définies par l'utilisateur.

Aspose.Slides vous permet de travailler avec les propriétés de document de la présentation via la classe [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) . Une instance de cette classe est renvoyée par [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Aspose.Slides gère les métadonnées d'application et de producteur lors de l'enregistrement des présentations ; ces champs identifient le logiciel qui a créé le résultat.
{{% /alert %}}

## **Gérer les propriétés de la présentation**

Les propriétés de document stockent des informations descriptives avec le contenu de la présentation. Elles se répartissent en deux catégories :

- **Propriétés intégrées** contiennent des métadonnées standard, telles que le titre, l'auteur et les statistiques du document.
- **Propriétés personnalisées** stockent des paires nom/valeur définies par l'utilisateur.

Aspose.Slides for Python via .NET donne accès aux deux catégories. Dans PowerPoint, sélectionnez **File → Info → Properties → Advanced Properties** pour examiner les métadonnées du document. La boîte de dialogue regroupe les informations dans des onglets tels que **Summary**, **Statistics**, **Contents** et **Custom**. Utilisez l'onglet **Custom** pour gérer les propriétés définies par l'utilisateur.

## **Lire les propriétés publiques d’une présentation chiffrée**

Un mot de passe d'ouverture protège normalement à la fois le contenu de la présentation et les propriétés du document. Lorsqu'une présentation est chiffrée avec [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) défini sur `False`, ses propriétés de document restent publiques. Une application peut alors définir [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) sur `True` et lire les métadonnées publiques sans fournir le mot de passe d'ouverture.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) contrôle ce qu'Aspose.Slides charge ; il ne déchiffre rien. Si les propriétés ont été incluses dans le chiffrement, les charger sans le mot de passe échoue. Si la présentation n'est pas chiffrée, l'option est ignorée et la présentation complète est chargée.

L'exemple nécessite une présentation chiffrée dont les propriétés de document ont été laissées publiques. Il vérifie le mode de chargement via [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) puis lit les propriétés intégrées via [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Dans ce mode, le contenu des diapositives n'est pas chargé. Les diapositives, maîtres, dispositions, formes, médias et autres objets de la présentation ne sont pas disponibles. Les applications doivent toujours vérifier [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) avant d'effectuer une opération nécessitant le modèle complet d'objets de la présentation.

{{% alert color="warning" title="Security" %}}
Les métadonnées publiques peuvent révéler les noms d'auteur, les titres, les sujets, les mots‑clés, les informations d'entreprise, les commentaires et les valeurs personnalisées. Chiffrez les propriétés sensibles avec la présentation. Ne les laissez publiques que lorsque l'indexation, la classification, la recherche ou les systèmes de gestion de documents ont une exigence spécifique d'accès sans mot de passe.
{{% /alert %}}

## **Mettre à jour les propriétés d’une présentation chiffrée**

Pour un fichier PPTX chiffré, une présentation chargée avec [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) est destinée à lire les métadonnées publiques. Aspose.Slides ne peut pas enregistrer les propriétés modifiées à partir de cet objet contenant uniquement les métadonnées car les propriétés publiques doivent rester cohérentes avec les données correspondantes à l'intérieur de la présentation chiffrée. Les mettre à jour nécessite donc le mot de passe d'ouverture correct et un chargement complet.

L'exemple nécessite une présentation PPTX chiffrée avec des propriétés de document publiques et un mot de passe d'ouverture connu. Il ouvre la présentation complète avec [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), met à jour les propriétés intégrées publiques, puis enregistre le résultat. Il utilise ensuite [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) pour vérifier que le chiffrement est conservé et rouvre les métadonnées publiques sans mot de passe afin de vérifier les nouvelles valeurs :

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
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

Si une application n'est pas autorisée à déchiffrer ou charger le contenu de la présentation, elle doit considérer les propriétés publiques d'un fichier PPTX chiffré comme en lecture seule.

## **Accéder aux propriétés intégrées**

La classe [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) expose les métadonnées intégrées via des propriétés typées, notamment [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), et [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Cet exemple ouvre une présentation existante et affiche ses métadonnées stockées dans la console. Les valeurs dépendent de la présentation d'entrée ; certains champs peuvent être vides.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **Modifier les propriétés intégrées**

Pour mettre à jour les métadonnées intégrées, attribuez des valeurs aux propriétés modifiables exposées par [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Cet exemple ouvre une présentation existante, définit [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), et [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/), puis enregistre la présentation mise à jour avec [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Le PPTX enregistré contient les nouvelles métadonnées.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gérer la base des hyperliens**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) stocke la base au niveau du document pour les hyperliens relatifs. Cela est utile lors du déplacement d'une présentation et de ses fichiers liés vers un autre emplacement. C'est distinct de [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) d'un hyperlien individuel : modifier la base ne réécrit pas les adresses de lien stockées ni ne change les destinations absolues.

L'exemple nécessite une présentation contenant à la fois un lien relatif, tel que `target.html`, et un lien absolu vers un fichier ou un site Web. Il lit la base existante, assigne une nouvelle adresse de base, puis enregistre et rouvre la présentation pour vérifier la valeur. Il efface ensuite la base avec `""` et vérifie la valeur vide dans un fichier enregistré séparément. Remplacez l'adresse de base de l'exemple par l'emplacement de vos fichiers liés.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

Les deux messages de vérification doivent afficher `True`. La suppression de la base laisse les adresses des hyperliens individuels intactes.

Un lien relatif vers `target.pptx` ouvrait `old/target.pptx` lorsque la base pointait vers le dossier `old`. Après avoir changé la base vers le dossier `new`, enregistré et rouvert la présentation, le même lien a ouvert `new/target.pptx`. Un lien absolu a continué d'ouvrir le même fichier. Testez vos liens relatifs dans PowerPoint avant et après avoir déplacé la présentation ou changé sa base.

## **Ajouter des propriétés personnalisées à la présentation**

Les propriétés personnalisées stockent des métadonnées qui n'ont aucun champ intégré correspondant. La méthode [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) vous permet d'assigner une valeur par le nom de la propriété. Cet exemple crée une présentation, ajoute deux valeurs texte et une valeur de version entière, puis enregistre la présentation avec [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Attribuer une valeur à un nom existant remplace la valeur de cette propriété.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder et modifier les propriétés personnalisées**

Cet exemple ouvre une présentation contenant des propriétés personnalisées et utilise [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) pour les parcourir. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) accepte un indice zéro‑basé et renvoie le nom utilisé par [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). L'exemple nécessite une présentation dont les propriétés personnalisées sont toutes des chaînes. Il affiche chaque nom et valeur d'origine, remplace chaque valeur par une chaîne numérotée, puis enregistre les modifications. S'il n'y a aucune propriété personnalisée, la boucle ne fait aucun changement.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) renvoie la valeur via la liste à un élément passée en second argument. L'espace réservé doit correspondre au type de la propriété stockée : utilisez `[""]` pour une chaîne ou `[0]` pour un entier. Un type incompatible lève une `InvalidCastException` ; choisissez l'espace réservé selon le schéma de vos propriétés personnalisées.

## **Exemple en direct**

Essayez l'application en ligne [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) pour voir comment travailler avec les propriétés de document en utilisant l'API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Cependant, vous pouvez soit modifier leurs valeurs, soit les définir comme vides si la propriété spécifique le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée qui existe déjà, sa valeur existante sera écrasée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, car Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés d’une présentation sans charger complètement la présentation ?**

Oui. Utilisez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) puis [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) pour lire les métadonnées du document stockées sans créer d’instance [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Consultez [Construire un inventaire de présentation léger](/slides/fr/python-net/examine-presentation/) pour un exemple complet de rapport et les limitations spécifiques aux formats.

**Puis‑je lire les propriétés publiques d’une présentation chiffrée sans son mot de passe d’ouverture ?**

Oui. La présentation doit avoir été chiffrée avec [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) défini sur `False`, et elle doit être chargée avec [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) défini sur `True`.

**Puis‑je mettre à jour un fichier PPTX chiffré en mode uniquement propriétés du document ?**

Non. Les données des propriétés publiques et chiffrées doivent rester cohérentes, ainsi la mise à jour d’un fichier PPTX chiffré nécessite de charger la présentation complète avec le mot de passe d’ouverture correct.