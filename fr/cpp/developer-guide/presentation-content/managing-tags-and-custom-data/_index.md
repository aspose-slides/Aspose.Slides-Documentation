---
title: Gérer les balises et les données personnalisées dans les présentations avec C++
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/cpp/managing-tags-and-custom-data/
keywords:
- propriétés de document
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
- C++
- Aspose.Slides
description: "Apprenez à gérer les balises et les données XML personnalisées dans les présentations PowerPoint avec Aspose.Slides pour C++, y compris l’ajout, la lecture, la mise à jour, l’audit et la suppression des parties XML personnalisées."
---
## **Vue d'ensemble**

Cet article explique comment Aspose.Slides travaille avec les balises et les données personnalisées dans les présentations PowerPoint. Les données spécifiques à une présentation peuvent être stockées sous forme de balises ou de parties XML personnalisées. Les balises sont de simples paires clé-valeur de chaînes, tandis que les parties XML personnalisées peuvent stocker des métadonnées structurées et des charges XML spécifiques à l'application.

Aspose.Slides fournit des API pour ajouter, lire, mettre à jour, auditer et supprimer des parties XML personnalisées aux niveaux de la présentation, de la diapositive et de la forme. Les parties XML personnalisées sont utiles pour les intégrations qui stockent des informations telles que des identifiants de gestion de documents, l’état du flux de travail, des métadonnées de conformité, des données de liaison de modèle ou d’autres données d’application structurées à l’intérieur d’une présentation.

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX — fichiers avec l’extension `.pptx` — sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Office Open XML définit la structure du package et les relations utilisées pour stocker le contenu de la présentation et les données associées.

Une présentation contient plusieurs parties reliées entre elles par des relations. Par exemple, une partie de diapositive contient le contenu d’une seule diapositive et peut avoir des relations explicites avec d’autres parties définies par ISO/IEC 29500.

Les données personnalisées peuvent être stockées sous forme de balises ([ITagCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itagcollection/)) ou de parties XML personnalisées ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icustomxmlpartcollection/)). Les deux sont accessibles via l’interface [`ICustomData`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icustomdata/) .

{{% alert color="primary" %}}
Les balises stockent de simples paires clé-valeur de chaînes. Les parties XML personnalisées stockent des données XML structurées et peuvent être associées à une présentation, une diapositive ou une forme.
{{% /alert %}}

## **Travailler avec les parties XML personnalisées**

La méthode [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icustomdata/get_customxmlparts/) renvoie la collection de parties XML personnalisées associées à un objet de présentation particulier. Par exemple :

- `presentation->get_CustomData()->get_CustomXmlParts()` contient les parties XML personnalisées associées à la présentation elle-même.
- `slide->get_CustomData()->get_CustomXmlParts()` contient les parties XML personnalisées associées à une diapositive spécifique.
- `shape->get_CustomData()->get_CustomXmlParts()` contient les parties XML personnalisées associées à une forme spécifique.

Utilisez [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_allcustomxmlparts/) lorsque vous devez examiner toutes les parties XML personnalisées de la présentation, quel que soit leur niveau d’association.

### **Ajouter une partie XML personnalisée à une présentation**

Utilisez [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icustomxmlpartcollection/add/) pour ajouter des données XML à une collection de parties XML personnalisées. Le XML doit être valide et non vide.

L’exemple suivant ajoute des métadonnées structurées à la collection de données personnalisées au niveau de la présentation :

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add attribue un identifiant automatiquement. Définissez un GUID spécifique uniquement si nécessaire.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

La méthode `Add` peut également accepter le XML sous forme de tableau d’octets ou de flux, ce qui est utile lorsque le contenu XML est déjà disponible sous forme binaire.

### **Ajouter une partie XML personnalisée à une diapositive ou une forme**

Les données XML personnalisées peuvent être associées à une diapositive ou à une forme spécifique plutôt qu’à l’ensemble de la présentation. Cela est utile lorsque les métadonnées décrivent un seul objet, comme une clé de modèle, un identifiant d’enregistrement externe ou des informations de liaison.

L’exemple suivant ajoute une partie XML personnalisée à une diapositive et une autre à une forme :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

Le niveau auquel une partie est ajoutée détermine la collection `get_CustomData()->get_CustomXmlParts()` de quel objet contient la relation vers cette partie. Les données au niveau de la présentation conviennent aux métadonnées couvrant tout le document, les données au niveau de la diapositive pour les informations appartenant à une diapositive particulière, et les données au niveau de la forme pour les métadonnées liées à une forme individuelle.

### **Lister et auditer toutes les parties XML personnalisées**

Utilisez [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_allcustomxmlparts/) pour récupérer toutes les parties XML personnalisées d’une présentation. Chaque [`ICustomXmlPart`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icustomxmlpart/) expose son identifiant, son contenu XML et les schémas d’espace de noms associés.

L’exemple suivant liste toutes les parties XML personnalisées et leurs schémas d’espace de noms :

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

`ICustomXmlPart::get_NamespaceSchemas` renvoie les schémas XML associés à la partie XML personnalisée. Cette information peut être utile lors de l’audit de présentations contenant du XML produit par des systèmes externes.

### **Lire et mettre à jour le contenu XML et ItemId**

Utilisez [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) et `set_XmlAsString` pour travailler avec le XML sous forme de chaîne UTF-8, ou [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icustomxmlpart/get_xmldata/) et `set_XmlData` pour travailler avec les octets XML bruts. Les deux représentations peuvent être lues et mises à jour.

La méthode [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icustomxmlpart/get_itemid/) renvoie le GUID qui identifie la partie XML personnalisée dans le document Office Open XML. L’identifiant peut également être modifié avec `set_ItemId` lorsqu’une intégration nécessite un nouvel identifiant.

L’exemple suivant met à jour le contenu XML et l’identifiant :

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// Lire le XML actuel en texte.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Mettre à jour le XML en tant que chaîne UTF-8.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData fournit le même contenu XML sous forme d'octets bruts.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Remplacer l'identifiant lorsqu'il est requis par l'intégration.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Lors de l’attribution de XML avec `set_XmlAsString` ou `set_XmlData`, fournissez un XML valide et non vide. Utilisez l’une ou l’autre représentation selon que l’application travaille principalement avec des chaînes ou des données binaires.

### **Supprimer une partie XML personnalisée**

Aspose.Slides propose plusieurs façons de supprimer des données XML personnalisées :

- `ICustomXmlPart::Remove` supprime la partie XML personnalisée de la présentation.
- `ICustomXmlPartCollection::Remove` supprime une partie spécifique d’une collection de parties XML personnalisées.
- `ICustomXmlPartCollection::RemoveAt` supprime la partie à l’index spécifié de la collection.
- `ICustomXmlPartCollection::Clear` supprime toutes les parties d’une collection spécifique.

L’exemple suivant supprime une partie XML personnalisée au niveau de la présentation par référence :

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

Si vous avez déjà un `ICustomXmlPart` et souhaitez supprimer cette partie de la présentation plutôt que de cibler une collection particulière, appelez `customXmlPart->Remove()`.

Vous pouvez également supprimer un élément par index :

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Effacer toutes les parties XML personnalisées d’une collection**

Utilisez `Clear` lorsque toutes les parties XML personnalisées associées à un objet de présentation particulier doivent être supprimées.

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` n’affecte que la collection sélectionnée. Par exemple, vider la collection d’une diapositive ne vide pas les collections au niveau de la présentation ou de la forme.

Pour supprimer chaque partie XML personnalisée de la présentation, parcourez `get_AllCustomXmlParts()` et supprimez chaque partie :

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **Gérer les parties XML personnalisées liées ou partagées**

Dans une présentation Office Open XML, la même partie XML personnalisée peut être référencée depuis plusieurs objets de présentation. Par exemple, un fichier existant peut contenir des relations depuis plusieurs diapositives ou formes vers la même partie XML personnalisée sous-jacente.

Une partie partagée doit être considérée comme un seul objet de données avec plusieurs références :

- La mettre à jour avec `set_XmlAsString`, `set_XmlData` ou `set_ItemId` modifie la partie XML personnalisée sous-jacente, de sorte que la modification s’applique partout où cette partie est référencée.
- `get_ItemId()` peut être utilisé pour identifier la même partie XML personnalisée lors de l’audit des collections au niveau des objets.
- Supprimer une partie d’une collection spécifique `get_CustomXmlParts()` la retire de cette collection. Utilisez `ICustomXmlPart::Remove()` lorsque la partie elle‑même doit être supprimée de la présentation.
- Avant de supprimer ou de remplacer une partie partagée, inspectez les collections au niveau des objets pour déterminer si d’autres diapositives ou formes la référencent encore.

Les surcharges de `Add` créent une nouvelle partie XML personnalisée à partir du contenu XML ; elles n’acceptent pas un `ICustomXmlPart` existant. Ainsi, les relations partagées sont le plus souvent rencontrées lors du chargement de présentations qui les contiennent déjà.

L’exemple suivant audite les collections au niveau de la présentation, de la diapositive et de la forme par `ItemId` et signale les parties référencées depuis plus d’un endroit :

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

Ce type d’audit est utile avant de modifier ou de supprimer des données XML personnalisées dans des présentations créées par des systèmes externes, car la même partie de métadonnées peut participer à plusieurs relations.

## **Obtenir les valeurs des balises**

Dans Slides, une balise correspond à la propriété `IDocumentProperties::get_Keywords`. Ce code d’exemple montre comment obtenir la valeur d’une balise avec Aspose.Slides pour C++ pour [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) :

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Ajouter des balises aux présentations**

Aspose.Slides vous permet d’ajouter des balises aux présentations. Une balise se compose généralement de deux éléments :

- le nom d’une propriété personnalisée, par exemple, `MyTag`;
- la valeur de la propriété personnalisée, par exemple, `My Tag Value`.

Si vous devez classifier les présentations en fonction d’une règle ou d’une propriété spécifique, vous pouvez ajouter des balises à cet effet. Par exemple, si vous souhaitez catégoriser les présentations provenant des pays d’Amérique du Nord, vous pouvez créer une balise « North American » et attribuer le pays correspondant comme valeur.

Ce code d’exemple montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) en utilisant Aspose.Slides pour C++ :

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Les balises peuvent également être définies pour une [Slide](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slide/) :

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Ou pour une [Shape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/shape/) individuelle :

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Limitations**

Les balises ajoutées via la collection `get_CustomData()->get_Tags()` sont stockées uniquement dans le fichier PowerPoint. Elles ne sont **pas** transférées vers la structure de balises PDF lorsque la présentation est exportée en PDF. Par conséquent, un identifiant personnalisé assigné comme balise ne peut pas être récupéré à partir du PDF balisé.

**Solution de contournement** : vous pouvez stocker un identifiant personnalisé dans le **Texte alternatif** de l’objet (par exemple, `shape->set_AlternativeText(u"MyId")`). Après l’exportation en PDF, le texte alternatif peut apparaître dans la structure de balises du PDF.

## **FAQ**

**Puis‑je supprimer toutes les balises d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [tag collection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/tagcollection/) prend en charge une opération [Clear](https://reference.aspose.com/slides/fr/cpp/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé‑valeur d’un coup.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez [Remove(name)](https://reference.aspose.com/slides/fr/cpp/aspose.slides/tagcollection/remove/) sur [TagCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises pour l’analyse ou le filtrage ?**

Utilisez [GetNamesOfTags](https://reference.aspose.com/slides/fr/cpp/aspose.slides/tagcollection/getnamesoftags/) sur la [tag collection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de balises.

**Comment trouver toutes les parties XML personnalisées, quel que soit leur emplacement ?**

Utilisez [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_allcustomxmlparts/) pour récupérer toutes les parties XML personnalisées de la présentation.

**Dois‑je utiliser `get_XmlAsString`/`set_XmlAsString` ou `get_XmlData`/`set_XmlData` pour mettre à jour une partie XML personnalisée ?**

Utilisez `get_XmlAsString` et `set_XmlAsString` lorsque l’application travaille avec du texte XML UTF‑8. Utilisez `get_XmlData` et `set_XmlData` lorsque le XML est déjà disponible sous forme de tableau d’octets ou lorsque le traitement binaire est plus pratique. Les deux représentations se réfèrent au même contenu XML de la partie XML personnalisée.