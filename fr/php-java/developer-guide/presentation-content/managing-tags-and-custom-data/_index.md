---
title: Gestion des balises et des données personnalisées dans les présentations avec PHP
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/php-java/managing-tags-and-custom-data/
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
- PHP
- Aspose.Slides
description: "Apprenez à gérer les balises et les données XML personnalisées dans les présentations PowerPoint avec Aspose.Slides for PHP via Java, y compris l’ajout, la lecture, la mise à jour, l’audit et la suppression des parties XML personnalisées."
---
## **Vue d'ensemble**

Cet article explique comment Aspose.Slides fonctionne avec les balises et les données personnalisées dans les présentations PowerPoint. Les données spécifiques à une présentation peuvent être stockées sous forme de balises ou de parties XML personnalisées. Les balises sont de simples paires clé‑valeur de chaînes, tandis que les parties XML personnalisées peuvent contenir des métadonnées structurées et des charges XML propres à une application.

Aspose.Slides fournit des API pour ajouter, lire, mettre à jour, auditer et supprimer des parties XML personnalisées au niveau de la présentation, de la diapositive et de la forme. Les parties XML personnalisées sont utiles pour les intégrations qui stockent des informations telles que des identifiants de gestion documentaire, l’état d’un workflow, des métadonnées de conformité, des données de liaison de modèle ou d’autres données d’application structurées à l’intérieur d’une présentation.

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX — fichiers portant l’extension `.pptx` — sont enregistrés au format PresentationML, qui fait partie de la spécification Office Open XML. Office Open XML définit la structure du package et les relations utilisées pour stocker le contenu de la présentation et les données associées.

Une présentation contient plusieurs parties reliées entre elles par des relations. Par exemple, une partie de diapositive contient le contenu d’une seule diapositive et peut avoir des relations explicites avec d’autres parties définies par ISO/IEC 29500.

Les données personnalisées peuvent être stockées sous forme de balises ([TagCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/)) ou de parties XML personnalisées ([CustomXmlPartCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpartcollection/)). Les deux sont accessibles via la classe [`CustomData`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Les balises stockent de simples paires clé‑valeur de chaînes. Les parties XML personnalisées stockent des données XML structurées et peuvent être associées à une présentation, une diapositive ou une forme.
{{% /alert %}}

## **Travailler avec les parties XML personnalisées**

La méthode [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customdata/#getCustomXmlParts) renvoie la collection des parties XML personnalisées associées à un objet de présentation particulier. Par exemple :

- `$presentation->getCustomData()->getCustomXmlParts()` contient les parties XML personnalisées associées à la présentation elle‑même.
- `$slide->getCustomData()->getCustomXmlParts()` contient les parties XML personnalisées associées à une diapositive spécifique.
- `$shape->getCustomData()->getCustomXmlParts()` contient les parties XML personnalisées associées à une forme spécifique.

Utilisez [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getAllCustomXmlParts) lorsque vous devez inspecter toutes les parties XML personnalisées de la présentation, quelle que soit leur association.

### **Ajouter une partie XML personnalisée à une présentation**

Utilisez [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpartcollection/#add) pour ajouter des données XML à une collection de parties XML personnalisées. Le XML doit être valide et non vide.

L’exemple suivant ajoute des métadonnées structurées à la collection de données personnalisées au niveau de la présentation :

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add attribue automatiquement un identifiant. Définissez un UUID spécifique uniquement si nécessaire.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La méthode `add` peut également accepter le XML sous forme de tableau d’octets ou de flux d’entrée, ce qui est utile lorsque le contenu XML est déjà disponible sous forme binaire.

### **Ajouter une partie XML personnalisée à une diapositive ou à une forme**

Les données XML personnalisées peuvent être associées à une diapositive ou à une forme spécifique plutôt qu’à l’ensemble de la présentation. Ceci est utile lorsque les métadonnées décrivent un seul objet, comme une clé de modèle, un identifiant d’enregistrement externe ou des informations de liaison.

L’exemple suivant ajoute une partie XML personnalisée à une diapositive et une autre à une forme :

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le niveau auquel une partie est ajoutée détermine la collection `getCustomData()->getCustomXmlParts()` de l’objet qui contient la relation vers cette partie. Les données au niveau de la présentation conviennent aux métadonnées globales du document, celles au niveau de la diapositive aux informations propres à une diapositive donnée, et celles au niveau de la forme aux métadonnées liées à une forme individuelle.

### **Lister et auditer toutes les parties XML personnalisées**

Utilisez [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getAllCustomXmlParts) pour récupérer toutes les parties XML personnalisées d’une présentation. Chaque [`CustomXmlPart`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpart/) expose son identifiant, son contenu XML et les schémas d’espace de noms associés.

L’exemple suivant liste toutes les parties XML personnalisées et leurs schémas d’espace de noms :

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) renvoie les schémas XML associés à la partie XML personnalisée. Cette information peut être utile lors de l’audit de présentations contenant du XML généré par des systèmes externes.

### **Lire et mettre à jour le contenu XML et l’ItemId**

Utilisez [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpart/#getXmlAsString) et [`setXmlAsString()`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpart/#setXmlAsString) pour travailler avec le XML sous forme de chaîne UTF‑8, ou [`getXmlData()`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpart/#getXmlData) et [`setXmlData()`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpart/#setXmlData) pour manipuler les octets XML bruts.

La méthode [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpart/#getItemId) renvoie le UUID qui identifie la partie XML personnalisée dans le document Office Open XML. Utilisez [`setItemId()`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpart/#setItemId) lorsqu’une intégration nécessite un nouvel identifiant.

L’exemple suivant met à jour le contenu XML et l’identifiant :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Lire le XML actuel en texte.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Mettre à jour le XML sous forme de chaîne UTF-8.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData fournit le même contenu XML sous forme d’octets bruts.
    $customXmlData = $customXmlPart->getXmlData();

    // Remplacer l’identifiant lorsque l’intégration le nécessite.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Lors de l’appel de `setXmlAsString` ou `setXmlData`, fournissez un XML valide et non vide. Utilisez l’une ou l’autre représentation selon que l’application travaille principalement avec des chaînes ou des données binaires.

### **Supprimer une partie XML personnalisée**

Aspose.Slides offre plusieurs moyens de supprimer des données XML personnalisées :

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpart/#remove) supprime la partie XML personnalisée de la présentation.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpartcollection/#remove) supprime une partie spécifique d’une collection de parties XML personnalisées.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpartcollection/#removeAt) supprime la partie à l’index indiqué de la collection.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpartcollection/#clear) supprime toutes les parties d’une collection donnée.

L’exemple suivant supprime une partie XML personnalisée au niveau de la présentation par référence :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si vous possédez déjà un `CustomXmlPart` et que vous voulez supprimer cette partie de la présentation plutôt que d’adresser une collection particulière, appelez `$customXmlPart->remove()`.

Vous pouvez également supprimer un élément par son index :

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Effacer toutes les parties XML personnalisées d’une collection**

Utilisez `clear` lorsque toutes les parties XML personnalisées associées à un objet de présentation donné doivent être supprimées.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` n’affecte que la collection sélectionnée. Par exemple, vider la collection d’une diapositive ne vide pas les collections au niveau de la présentation ou de la forme.

Pour supprimer chaque partie XML personnalisée de la présentation, parcourez `getAllCustomXmlParts()` et supprimez chaque partie :

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Gérer les parties XML personnalisées liées ou partagées**

Dans une présentation Office Open XML, la même partie XML personnalisée peut être référencée depuis plusieurs objets de la présentation. Par exemple, un fichier existant peut contenir des relations depuis plusieurs diapositives ou formes vers la même partie XML sous‑jacente.

Une partie partagée doit être traitée comme un unique objet de données avec plusieurs références :

- La mettre à jour avec `setXmlAsString`, `setXmlData` ou `setItemId` modifie la partie sous‑jacente, la modification étant alors visible partout où elle est référencée.
- `getItemId()` peut être utilisé pour identifier la même partie XML personnalisée lors de l’audit des collections au niveau des objets.
- Supprimer une partie d’une collection `getCustomXmlParts()` spécifique la retire uniquement de cette collection. Utilisez `CustomXmlPart::remove()` lorsque la partie elle‑même doit être supprimée de la présentation.
- Avant de supprimer ou de remplacer une partie partagée, inspectez les collections au niveau des objets pour déterminer si d’autres diapositives ou formes y font encore référence.

Les surcharges de `add` créent une nouvelle partie XML personnalisée à partir d’un contenu XML ; elles n’acceptent pas un `CustomXmlPart` existant. Ainsi, les relations partagées sont le plus souvent rencontrées lors du chargement de présentations qui les contiennent déjà.

L’exemple suivant audite les collections au niveau de la présentation, de la diapositive et de la forme par `ItemId` et signale les parties référencées depuis plusieurs emplacements :

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Ce type d’audit est utile avant de modifier ou de supprimer des données XML personnalisées dans des présentations générées par des systèmes externes, car la même partie de métadonnées peut participer à plusieurs relations.

## **Obtenir les valeurs des balises**

Dans Slides, une balise correspond à la méthode `DocumentProperties::getKeywords()`. Ce code d’exemple montre comment obtenir la valeur d’une balise avec Aspose.Slides for PHP via Java pour [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Ajouter des balises aux présentations**

Aspose.Slides permet d’ajouter des balises aux présentations. Une balise se compose généralement de deux éléments :

- le nom d’une propriété personnalisée, par exemple `MyTag`;
- la valeur de la propriété personnalisée, par exemple `My Tag Value`.

Si vous devez classer les présentations selon une règle ou une propriété précise, vous pouvez ajouter des balises à cette fin. Par exemple, pour catégoriser les présentations provenant des pays d’Amérique du Nord, créez une balise « North American » et attribuez-y le pays concerné comme valeur.

Ce code d’exemple montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) à l’aide d’Aspose.Slides for PHP via Java :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Des balises peuvent également être définies pour une [Slide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/) :

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Ou pour une [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) individuelle :

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Limitations**

Les balises ajoutées via la collection `getCustomData()->getTags()` sont stockées uniquement dans le fichier PowerPoint. Elles ne sont **pas** transférées vers la structure de balises PDF lorsque la présentation est exportée en PDF. Par conséquent, un identifiant personnalisé attribué sous forme de balise ne peut pas être récupéré dans le PDF balisé.

**Solution de contournement** : vous pouvez stocker un identifiant personnalisé dans le **Texte alternatif** de l’objet (par exemple `$shape->setAlternativeText("MyId")`). Après l’exportation en PDF, le texte alternatif peut apparaître dans la structure de balises du PDF.

## **FAQ**

**Puis‑je supprimer toutes les balises d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [collection de balises](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/) prend en charge l’opération [clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/#clear) qui supprime toutes les paires clé‑valeur d’un coup.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez [remove(name)](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/#remove) sur la [collection de balises](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises à des fins d’analyse ou de filtrage ?**

Utilisez [getNamesOfTags](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/#getNamesOfTags) sur la [collection de balises](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de balises.

**Comment trouver toutes les parties XML personnalisées quel que soit leur emplacement de stockage ?**

Utilisez [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getAllCustomXmlParts) pour récupérer toutes les parties XML personnalisées de la présentation.

**Dois‑je utiliser `getXmlAsString`/`setXmlAsString` ou `getXmlData`/`setXmlData` pour mettre à jour une partie XML personnalisée ?**

Utilisez `getXmlAsString` et `setXmlAsString` lorsque l’application travaille avec du texte XML UTF‑8. Utilisez `getXmlData` et `setXmlData` lorsque le XML est déjà disponible sous forme de tableau d’octets ou lorsque le traitement binaire est plus pratique. Les deux représentations font référence au même contenu XML de la partie personnalisée.