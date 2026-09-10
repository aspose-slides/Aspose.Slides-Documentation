---
title: Gérer les tags et les données personnalisées dans les présentations avec Python
linktitle: Tags et données personnalisées
type: docs
weight: 300
url: /fr/python-java/managing-tags-and-custom-data/
keywords:
- propriétés du document
- tag
- données personnalisées
- XML personnalisé
- partie XML personnalisée
- métadonnées XML
- ItemId
- ajouter un tag
- paires de valeurs
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment gérer les tags et les données XML personnalisées dans les présentations PowerPoint avec Aspose.Slides pour Python via Java, y compris l’ajout, la lecture, la mise à jour, l’audit et la suppression des parties XML personnalisées."
---
## **Vue d'ensemble**

Cet article explique comment Aspose.Slides gère les tags et les données personnalisées dans les présentations PowerPoint. Les données spécifiques à une présentation peuvent être stockées sous forme de tags ou de parties XML personnalisées. Les tags sont de simples paires clé‑valeur de chaînes, tandis que les parties XML personnalisées peuvent contenir des métadonnées structurées et des charges XML propres à l'application.

Aspose.Slides propose des API pour ajouter, lire, mettre à jour, auditer et supprimer des parties XML personnalisées au niveau de la présentation, de la diapositive et de la forme. Les parties XML personnalisées sont utiles pour les intégrations qui stockent des informations telles que des identifiants de gestion de documents, l’état d’un workflow, des métadonnées de conformité, des données de liaison de modèle ou d’autres données d’application structurées à l’intérieur d’une présentation.

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX — les fichiers portant l’extension `.pptx` — sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Office Open XML définit la structure du package et les relations utilisées pour stocker le contenu de la présentation et les données associées.

Une présentation contient plusieurs parties reliées entre elles par des relations. Par exemple, une partie de diapositive contient le contenu d’une seule diapositive et peut établir des relations explicites avec d’autres parties définies par ISO/IEC 29500.

Les données personnalisées peuvent être stockées sous forme de tags ([TagCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tagcollection/)) ou de parties XML personnalisées ([CustomXmlPartCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpartcollection/)). Les deux sont accessibles via la classe [CustomData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customdata/).

{{% alert color="info" title="Remarque" %}}
Les tags stockent de simples paires clé‑valeur de type chaîne. Les parties XML personnalisées stockent des données XML structurées et peuvent être associées à une présentation, une diapositive ou une forme.
{{% /alert %}}

## **Travailler avec les parties XML personnalisées**

La méthode [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customdata/#getCustomXmlParts) renvoie la collection de parties XML personnalisées associées à un objet de présentation particulier. Par exemple :

- La collection [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customdata/#getCustomXmlParts) de la présentation contient les parties XML personnalisées associées à la présentation elle‑même.
- La collection [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customdata/#getCustomXmlParts) de la diapositive contient les parties XML personnalisées associées à une diapositive spécifique.
- La collection [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customdata/#getCustomXmlParts) de la forme contient les parties XML personnalisées associées à une forme spécifique.

Utilisez [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getAllCustomXmlParts) lorsque vous devez examiner toutes les parties XML personnalisées de la présentation, quel que soit leur niveau d’association.

### **Ajouter une partie XML personnalisée à une présentation**

Utilisez [CustomXmlPartCollection.add](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpartcollection/#add) pour ajouter des données XML à une collection de parties XML personnalisées. Le XML doit être valide et non vide.

L’exemple suivant ajoute des métadonnées structurées à la collection de données personnalisées au niveau de la présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # ajoute attribue un identifiant automatiquement. Définissez un UUID spécifique uniquement si nécessaire.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La méthode [add](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpartcollection/#add) peut également accepter le XML sous forme de tableau d’octets ou de flux d’entrée, ce qui est utile lorsque le contenu XML est déjà disponible en format binaire.

### **Ajouter une partie XML personnalisée à une diapositive ou une forme**

Les données XML personnalisées peuvent être associées à une diapositive ou une forme spécifique plutôt qu’à l’ensemble de la présentation. Cela est utile lorsqu’une métadonnée décrit un seul objet, comme une clé de modèle, un identifiant d’enregistrement externe ou des informations de liaison.

L’exemple suivant ajoute une partie XML personnalisée à une diapositive et une autre à une forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le niveau auquel une partie est ajoutée détermine la collection [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customdata/#getCustomXmlParts) qui contient la relation vers cette partie. Les données au niveau de la présentation conviennent aux métadonnées globales du document, les données au niveau de la diapositive aux informations propres à une diapositive donnée, et les données au niveau de la forme aux métadonnées rattachées à une forme individuelle.

### **Lister et auditer toutes les parties XML personnalisées**

Utilisez [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getAllCustomXmlParts) pour récupérer toutes les parties XML personnalisées d’une présentation. Chaque [CustomXmlPart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/) expose son identifiant, son contenu XML et les schémas d’espace de noms associés.

L’exemple suivant liste toutes les parties XML personnalisées ainsi que leurs schémas d’espace de noms :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) renvoie les schémas XML associés à la partie XML personnalisée. Cette information peut être utile lors de l’audit de présentations contenant du XML produit par des systèmes externes.

### **Lire et mettre à jour le contenu XML et l’ItemId**

Utilisez [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#getXmlAsString) et [setXmlAsString](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#setXmlAsString) pour travailler avec le XML sous forme de chaîne UTF‑8, ou [getXmlData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#getXmlData) et [setXmlData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#setXmlData) pour travailler avec les octets XML bruts.

La méthode [CustomXmlPart.getItemId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#getItemId) renvoie le UUID qui identifie la partie XML personnalisée dans le document Office Open XML. Utilisez [setItemId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#setItemId) lorsqu’une intégration nécessite un nouvel identifiant.

L’exemple suivant met à jour le contenu XML et l’identifiant :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Lire le XML actuel en texte.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Mettre à jour le XML en tant que chaîne UTF-8.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData fournit le même contenu XML sous forme d'octets bruts.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Remplacez l'identifiant lorsqu'il est requis par l'intégration.
        item_id = UUID.randomRandom()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

Lors de l’appel à [setXmlAsString](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#setXmlAsString) ou [setXmlData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#setXmlData), fournissez un XML valide et non vide. Utilisez l’une ou l’autre représentation selon que l’application travaille principalement avec des chaînes ou des données binaires.

### **Supprimer une partie XML personnalisée**

Aspose.Slides offre plusieurs façons de supprimer des données XML personnalisées :

- [CustomXmlPart.remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#remove) supprime la partie XML personnalisée de la présentation.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpartcollection/#remove) supprime une partie spécifique d’une collection de parties XML personnalisées.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpartcollection/#removeAt) supprime la partie à l’index indiqué de la collection.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpartcollection/#clear) supprime toutes les parties d’une collection donnée.

L’exemple suivant supprime une partie XML personnalisée au niveau de la présentation en se basant sur une référence :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Si vous disposez déjà d’un [CustomXmlPart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/) et que vous souhaitez le retirer de la présentation plutôt que d’adresser une collection particulière, appelez [CustomXmlPart.remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#remove).

Vous pouvez également supprimer un élément par son index :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Effacer toutes les parties XML personnalisées d’une collection**

Utilisez [clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpartcollection/#clear) lorsque toutes les parties XML personnalisées associées à un objet de présentation donné doivent être supprimées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpartcollection/#clear) n’affecte que la collection sélectionnée. Par exemple, vider la collection d’une diapositive ne vide pas les collections au niveau de la présentation ou de la forme.

Pour supprimer chaque partie XML personnalisée de la présentation, parcourez [getAllCustomXmlParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getAllCustomXmlParts) et supprimez chaque partie :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Gérer les parties XML personnalisées liées ou partagées**

Dans une présentation Office Open XML, la même partie XML personnalisée peut être référencée depuis plusieurs objets de présentation. Par exemple, un fichier existant peut contenir des relations provenant de plusieurs diapositives ou formes vers la même partie XML sous‑jacente.

Une partie partagée doit être traitée comme un seul objet de données avec plusieurs références :

- La mettre à jour avec [setXmlAsString](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#setXmlData) ou [setItemId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#setItemId) modifie la partie XML sous‑jacente, de sorte que la modification s’applique partout où la partie est référencée.
- [getItemId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#getItemId) peut être utilisé pour identifier la même partie XML lors de l’audit des collections au niveau des objets.
- Supprimer une partie d’une collection spécifique via [getCustomXmlParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customdata/#getCustomXmlParts) ne la retire que de cette collection. Utilisez [CustomXmlPart.remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#remove) lorsque la partie elle‑même doit être supprimée de la présentation.
- Avant de supprimer ou de remplacer une partie partagée, examinez les collections au niveau des objets pour déterminer si d’autres diapositives ou formes y font encore référence.

Les surcharges de [add](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpartcollection/#add) créent une nouvelle partie XML personnalisée à partir du contenu XML ; elles n’acceptent pas un [CustomXmlPart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/) existant. Ainsi, les relations partagées sont le plus souvent rencontrées lors du chargement de présentations qui les contiennent déjà.

L’exemple suivant audite les collections au niveau de la présentation, de la diapositive et de la forme par `ItemId` et signale les parties référencées depuis plusieurs emplacements :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Ce type d’audit est utile avant de modifier ou de supprimer des données XML personnalisées dans des présentations créées par des systèmes externes, car la même partie de métadonnées peut participer à plusieurs relations.

## **Obtenir les valeurs des tags**

Dans les diapositives, un tag correspond à la méthode [DocumentProperties.getKeywords](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getKeywords). Cet exemple de code montre comment obtenir la valeur d’un tag avec Aspose.Slides for Python via Java pour [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Ajouter des tags aux présentations**

Aspose.Slides vous permet d’ajouter des tags aux présentations. Un tag se compose généralement de deux éléments :

- le nom d’une propriété personnalisée, par exemple `MyTag`;
- la valeur de la propriété personnalisée, par exemple `My Tag Value`.

Si vous devez classer des présentations selon une règle ou une propriété spécifique, vous pouvez ajouter des tags à cet effet. Par exemple, pour catégoriser les présentations provenant des pays d’Amérique du Nord, créez un tag « North American » et affectez le pays concerné comme valeur.

Cet exemple de code montre comment ajouter un tag à une [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) à l’aide d’Aspose.Slides for Python via Java :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

Des tags peuvent également être définis pour une [Slide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Ou pour une [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) individuelle :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Limitations**

Les tags ajoutés via la collection [CustomData.getTags](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customdata/#getTags) sont stockés uniquement dans le fichier PowerPoint. Ils ne sont **pas** transférés vers la structure de tags PDF lors de l’exportation de la présentation en PDF. Par conséquent, un identifiant personnalisé assigné comme tag ne peut pas être récupéré depuis le PDF taggé.

**Solution de contournement** : vous pouvez stocker un identifiant personnalisé dans le **Texte alternatif** de l’objet (par exemple, [Shape.setAlternativeText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#setAlternativeText) avec la valeur `"MyId"`). Après l’exportation en PDF, le texte alternatif peut apparaître dans la structure de tags du PDF.

## **FAQ**

**Puis‑je supprimer tous les tags d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [tag collection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tagcollection/) prend en charge l’opération [clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tagcollection/#clear) qui supprime toutes les paires clé‑valeur d’un coup.

**Comment supprimer un seul tag par son nom sans parcourir toute la collection ?**

Utilisez [remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tagcollection/#remove) sur la [tag collection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tagcollection/) pour supprimer le tag par sa clé.

**Comment obtenir la liste complète des noms de tags pour des analyses ou un filtrage ?**

Utilisez [getNamesOfTags](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tagcollection/#getNamesOfTags) sur la [tag collection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de tags.

**Comment trouver toutes les parties XML personnalisées, quel que soit leur lieu de stockage ?**

Utilisez [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getAllCustomXmlParts) pour récupérer toutes les parties XML personnalisées de la présentation.

**Dois‑je utiliser [getXmlAsString](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#setXmlAsString) ou [getXmlData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#setXmlData) pour mettre à jour une partie XML personnalisée ?**

Utilisez [getXmlAsString](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#getXmlAsString) et [setXmlAsString](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#setXmlAsString) lorsque l’application travaille avec du texte XML UTF‑8. Utilisez [getXmlData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#getXmlData) et [setXmlData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/customxmlpart/#setXmlData) lorsque le XML est déjà disponible sous forme de tableau d’octets ou lorsque le traitement binaire est plus pratique. Les deux représentations font référence au même contenu XML de la partie XML personnalisée.