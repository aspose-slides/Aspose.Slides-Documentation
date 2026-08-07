---
title: Gérer les balises et les données personnalisées dans les présentations avec Python
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/python-net/managing-tags-and-custom-data/
keywords:
- propriétés du document
- balise
- données personnalisées
- XML personnalisé
- partie XML personnalisée
- métadonnées XML
- ItemId
- ajouter une balise
- paires de valeurs
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à gérer les balises et les données XML personnalisées dans les présentations PowerPoint avec Aspose.Slides pour Python via .NET, y compris l'ajout, la lecture, la mise à jour, l'audit et la suppression des parties XML personnalisées."
---
## **Aperçu**

Cet article explique comment Aspose.Slides fonctionne avec les balises et les données personnalisées dans les présentations PowerPoint. Les données propres à une présentation peuvent être stockées sous forme de balises ou de parties XML personnalisées. Les balises sont de simples paires clé-valeur de chaînes, tandis que les parties XML personnalisées peuvent stocker des métadonnées structurées et des charges utiles XML spécifiques à l'application.

Aspose.Slides fournit des API pour ajouter, lire, mettre à jour, auditer et supprimer des parties XML personnalisées au niveau de la présentation, de la diapositive et de la forme. Les parties XML personnalisées sont utiles pour les intégrations qui stockent des informations telles que des identifiants de gestion de documents, l'état du flux de travail, des métadonnées de conformité, des données de liaison de modèle, ou d'autres données d'application structurées à l'intérieur d'une présentation.

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX—les fichiers avec l'extension `.pptx`—sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Office Open XML définit la structure du package et les relations utilisées pour stocker le contenu de la présentation et les données associées.

Une présentation contient plusieurs parties reliées entre elles par des relations. Par exemple, une partie de diapositive contient le contenu d'une seule diapositive et peut avoir des relations explicites avec d'autres parties définies par ISO/IEC 29500.

Les données personnalisées peuvent être stockées sous forme de balises ([TagCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/)) ou de parties XML personnalisées ([CustomXmlPartCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/customxmlpartcollection/)). Les deux sont accessibles via la classe [`CustomData`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/customdata/) .

{{% alert color="primary" %}}
Les balises stockent de simples paires clé‑valeur de chaîne. Les parties XML personnalisées stockent des données XML structurées et peuvent être associées à une présentation, une diapositive ou une forme.
{{% /alert %}}

## **Travailler avec les parties XML personnalisées**

La propriété [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/customdata/custom_xml_parts/) renvoie la collection des parties XML personnalisées associées à un objet de présentation particulier. Par exemple :

- `presentation.custom_data.custom_xml_parts` contient les parties XML personnalisées associées à la présentation elle‑même.
- `slide.custom_data.custom_xml_parts` contient les parties XML personnalisées associées à une diapositive spécifique.
- `shape.custom_data.custom_xml_parts` contient les parties XML personnalisées associées à une forme spécifique.

Utilisez [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/all_custom_xml_parts/) lorsque vous devez examiner toutes les parties XML personnalisées dans la présentation, quel que soit leur emplacement.

### **Ajouter une partie XML personnalisée à une présentation**

Utilisez [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/customxmlpartcollection/add/) pour ajouter des données XML à une collection de parties XML personnalisées. Le XML doit être valide et non vide.

L'exemple suivant ajoute des métadonnées structurées à la collection de données personnalisées au niveau de la présentation :

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add attribue automatiquement un identifiant. Définissez un GUID spécifique uniquement si nécessaire.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

La méthode `add` peut également accepter le XML sous forme de tableau d'octets ou de flux, ce qui est utile lorsque le contenu XML est déjà disponible sous forme binaire.

### **Ajouter une partie XML personnalisée à une diapositive ou à une forme**

Les données XML personnalisées peuvent être associées à une diapositive ou à une forme spécifique plutôt qu'à l'ensemble de la présentation. Cela est utile lorsque les métadonnées décrivent un seul objet, comme une clé de modèle, un identifiant d'enregistrement externe ou des informations de liaison.

L'exemple suivant ajoute une partie XML personnalisée à une diapositive et une autre à une forme :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Le niveau auquel une partie est ajoutée détermine la collection `custom_data.custom_xml_parts` de quel objet contient la relation vers cette partie. Les données au niveau de la présentation conviennent aux métadonnées à l'échelle du document, les données au niveau de la diapositive pour les informations relatives à une diapositive particulière, et les données au niveau de la forme pour les métadonnées liées à une forme individuelle.

### **Lister et auditer toutes les parties XML personnalisées**

Utilisez [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/all_custom_xml_parts/) pour récupérer toutes les parties XML personnalisées d'une présentation. Chaque [`CustomXmlPart`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/customxmlpart/) expose son identifiant, le contenu XML et les schémas d'espaces de noms associés.

L'exemple suivant répertorie toutes les parties XML personnalisées et leurs schémas d'espaces de noms :

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

`[CustomXmlPart.namespace_schemas]` renvoie les schémas XML associés à la partie XML personnalisée. Cette information peut être utile lors de l'audit de présentations contenant du XML produit par des systèmes externes.

### **Lire et mettre à jour le contenu XML et ItemId**

Utilisez [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/customxmlpart/xml_as_string/) pour travailler avec le XML sous forme de chaîne UTF‑8, ou [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/customxmlpart/xml_data/) pour travailler avec les octets XML bruts. Les deux propriétés peuvent être lues et mises à jour.

La propriété [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/customxmlpart/item_id/) contient le GUID qui identifie la partie XML personnalisée dans le document Office Open XML. Elle peut également être modifiée lorsqu'une intégration nécessite un nouvel identifiant.

L'exemple suivant met à jour le contenu XML et l'identifiant :

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Lire le XML actuel en texte.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Mettre à jour le XML en chaîne UTF-8.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data fournit le même contenu XML sous forme d'octets bruts.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Remplacer l'identifiant lorsque l'intégration l'exige.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Lors de l'attribution de `xml_as_string` ou `xml_data`, fournissez un XML valide et non vide. Utilisez l'une ou l'autre représentation selon que l'application travaille principalement avec des chaînes ou des données binaires.

### **Supprimer une partie XML personnalisée**

Aspose.Slides propose plusieurs façons de supprimer les données XML personnalisées :

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/customxmlpart/remove/) supprime la partie XML personnalisée de la présentation.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/customxmlpartcollection/remove/) supprime une partie spécifique d'une collection de parties XML personnalisées.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/customxmlpartcollection/remove_at/) supprime la partie à l'index indiqué de la collection.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/customxmlpartcollection/clear/) supprime toutes les parties d'une collection spécifique.

L'exemple suivant supprime une partie XML personnalisée au niveau de la présentation par référence :

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Si vous avez déjà un `CustomXmlPart` et que vous souhaitez supprimer cette partie de la présentation plutôt que d'adresser une collection particulière, appelez `custom_xml_part.remove()`.

Vous pouvez également supprimer un élément par index :

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Effacer toutes les parties XML personnalisées d'une collection**

Utilisez `clear` lorsque toutes les parties XML personnalisées associées à un objet de présentation particulier doivent être supprimées.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` n'affecte que la collection sélectionnée. Par exemple, effacer la collection d'une diapositive ne vide pas les collections au niveau de la présentation ou de la forme.

Pour supprimer chaque partie XML personnalisée dans la présentation, parcourez `all_custom_xml_parts` et supprimez chaque partie :

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Gérer les parties XML personnalisées liées ou partagées**

Dans une présentation Office Open XML, la même partie XML personnalisée peut être référencée depuis plusieurs objets de présentation. Par exemple, un fichier existant peut contenir des relations à partir de plusieurs diapositives ou formes vers la même partie XML personnalisée sous‑jacent.

Une partie partagée doit être traitée comme un seul objet de données avec plusieurs références :

- Mettre à jour son `xml_as_string`, `xml_data` ou `item_id` modifie la partie XML personnalisée sous‑jacente, de sorte que le changement s'applique partout où cette partie est référencée.
- `item_id` peut être utilisé pour identifier la même partie XML personnalisée lors de l'audit des collections au niveau des objets.
- Supprimer une partie d'une collection `custom_xml_parts` spécifique la retire de cette collection. Utilisez `CustomXmlPart.remove()` lorsque la partie elle‑même doit être supprimée de la présentation.
- Avant de supprimer ou de remplacer une partie partagée, examinez les collections au niveau des objets afin de déterminer si d'autres diapositives ou formes y font encore référence.

Les surcharges `add` créent une nouvelle partie XML personnalisée à partir du contenu XML ; elles n'acceptent pas un `CustomXmlPart` existant. Ainsi, les relations partagées sont le plus souvent rencontrées lors du chargement de présentations qui les contiennent déjà.

L'exemple suivant audite les collections au niveau de la présentation, de la diapositive et de la forme par `item_id` et signale les parties référencées depuis plus d'un emplacement :

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Ce type d'audit est utile avant de modifier ou supprimer des données XML personnalisées dans des présentations créées par des systèmes externes, car la même partie de métadonnées peut participer à plusieurs relations.

## **Obtenir les valeurs des balises**

Dans Slides, une balise correspond à la propriété `DocumentProperties.keywords`. Cet exemple de code montre comment obtenir la valeur d'une balise avec Aspose.Slides pour Python via .NET pour [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) :

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Ajouter des balises aux présentations**

Aspose.Slides vous permet d'ajouter des balises aux présentations. Une balise comprend généralement deux éléments :

- le nom d'une propriété personnalisée, par exemple `MyTag`;
- la valeur de la propriété personnalisée, par exemple `My Tag Value`.

Si vous devez classer les présentations selon une règle ou une propriété spécifique, vous pouvez ajouter des balises à cet effet. Par exemple, si vous souhaitez catégoriser les présentations provenant des pays d'Amérique du Nord, vous pouvez créer une balise « North American » et lui affecter le pays concerné comme valeur.

Cet exemple de code montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) en utilisant Aspose.Slides pour Python via .NET :

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Les balises peuvent également être définies pour une [Slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/) :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Ou pour une [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/) individuelle :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Limites**

Les balises ajoutées via la collection `custom_data.tags` sont stockées uniquement dans le fichier PowerPoint. Elles ne sont **pas** transférées vers la structure de balises du PDF lors de l'exportation de la présentation au format PDF. Par conséquent, un identifiant personnalisé assigné comme balise ne peut pas être récupéré à partir du PDF balisé.

**Solution de contournement** : vous pouvez stocker un identifiant personnalisé dans le **Texte alternatif** de l'objet (par exemple, `shape.alternative_text = "MyId"`). Après l'exportation au PDF, le texte alternatif peut apparaître dans la structure de balises du PDF.

## **FAQ**

**Puis-je supprimer toutes les balises d'une présentation, d'une diapositive ou d'une forme en une seule opération ?**

Oui. La [collection de balises](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/) prend en charge une opération [clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé‑valeur en une fois.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez [remove(name)](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/remove/) sur [TagCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises pour l'analyse ou le filtrage ?**

Utilisez [get_names_of_tags](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/get_names_of_tags/) sur la [collection de balises](https://reference.aspose.com/slides/fr/python-net/aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de balises.

**Comment trouver toutes les parties XML personnalisées, quel que soit leur emplacement ?**

Utilisez [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/all_custom_xml_parts/) pour récupérer toutes les parties XML personnalisées de la présentation.

**Dois-je utiliser `xml_as_string` ou `xml_data` pour mettre à jour une partie XML personnalisée ?**

Utilisez `xml_as_string` lorsque l'application travaille avec du texte XML UTF‑8. Utilisez `xml_data` lorsque le XML est déjà disponible sous forme de tableau d'octets ou lorsque le traitement orienté binaire est plus pratique. Les deux propriétés représentent le même contenu XML de la partie personnalisée.