---
title: Verwalten von Tags und benutzerdefinierten Daten in Präsentationen mit C++
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/cpp/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- benutzerdefiniertes XML
- benutzerdefinierter XML-Teil
- XML-Metadaten
- ItemId
- Tag hinzufügen
- Paarwerte
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte XML-Daten in PowerPoint-Präsentationen mit Aspose.Slides für C++ verwalten, einschließlich Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML-Teile."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint-Präsentationen arbeitet. Präsentationsspezifische Daten können als Tags oder als benutzerdefinierte XML‑Teile gespeichert werden. Tags sind einfache Schlüssel‑Wert‑Zeichenketten, während benutzerdefinierte XML‑Teile strukturierte Metadaten und anwendungsspezifische XML‑Payloads enthalten können.

Aspose.Slides stellt APIs zum Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML‑Teile auf Präsentations‑, Folien‑ und Formebene bereit. Benutzerdefinierte XML‑Teile sind nützlich für Integrationen, die Informationen wie Dokument‑Management‑Kennungen, Workflow‑Zustände, Compliance‑Metadaten, Vorlagen‑Bindungsdaten oder andere strukturierte Anwendungsdaten innerhalb einer Präsentation speichern.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien – Dateien mit der Erweiterung `.pptx` – werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Office Open XML definiert die Paketstruktur und die Beziehungen, die zum Speichern von Präsentationsinhalt und zugehörigen Daten verwendet werden.

Eine Präsentation besteht aus mehreren Teilen, die durch Beziehungen verbunden sind. Beispielsweise enthält ein Folienteil den Inhalt einer einzelnen Folie und kann explizite Beziehungen zu anderen Teilen haben, wie in ISO/IEC 29500 definiert.

Benutzerdefinierte Daten können als Tags ([ITagCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/itagcollection/)) oder als benutzerdefinierte XML‑Teile ([ICustomXmlPartCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpartcollection/)) gespeichert werden. Beide sind über das [`ICustomData`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomdata/)‑Interface verfügbar.

{{% alert color="info" %}}

Tags speichern einfache Zeichenketten‑Schlüssel‑Wert‑Paare. Benutzerdefinierte XML‑Teile speichern strukturierte XML‑Daten und können einer Präsentation, Folie oder Form zugeordnet werden.

{{% /alert %}}

## **Arbeiten mit benutzerdefinierten XML‑Teilen**

Die Methode [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomdata/get_customxmlparts/) liefert die Sammlung der benutzerdefinierten XML‑Teile, die einem bestimmten Präsentationsobjekt zugeordnet sind. Beispiel:

- `presentation->get_CustomData()->get_CustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die der Präsentation selbst zugeordnet sind.
- `slide->get_CustomData()->get_CustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die einer bestimmten Folie zugeordnet sind.
- `shape->get_CustomData()->get_CustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die einer bestimmten Form zugeordnet sind.

Verwenden Sie [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_allcustomxmlparts/), wenn Sie alle benutzerdefinierten XML‑Teile in der Präsentation untersuchen möchten, unabhängig davon, wo sie zugeordnet sind.

### **Einen benutzerdefinierten XML‑Teil zu einer Präsentation hinzufügen**

Verwenden Sie [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpartcollection/add/), um XML‑Daten zu einer Sammlung benutzerdefinierter XML‑Teile hinzuzufügen. Das XML muss gültig und nicht leer sein.

Das folgende Beispiel fügt strukturierte Metadaten zur Präsentationsebene‑Sammlung hinzu:

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

// Fügt automatisch eine Kennung zu. Setzen Sie eine spezifische GUID nur bei Bedarf.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Die `Add`‑Methode kann XML auch als Byte‑Array oder Stream übernehmen, was nützlich ist, wenn XML‑Inhalt bereits in binärer Form vorliegt.

### **Einen benutzerdefinierten XML‑Teil zu einer Folie oder Form hinzufügen**

Benutzerdefinierte XML‑Daten können einer bestimmten Folie oder Form zugeordnet werden, anstatt der gesamten Präsentation. Das ist praktisch, wenn Metadaten nur ein Objekt beschreiben, z. B. einen Vorlagenschlüssel, eine externe Datensatz‑Kennung oder Bindungsinformationen.

Das folgende Beispiel fügt einen benutzerdefinierten XML‑Teil zu einer Folie und einen weiteren zu einer Form hinzu:

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

Die Ebene, auf der ein Teil hinzugefügt wird, bestimmt, welche `get_CustomData()->get_CustomXmlParts()`‑Sammlung die Beziehung zu diesem Teil enthält. Präsentationsebene‑Daten eignen sich für dokumentweite Metadaten, Folienebene‑Daten für Informationen, die zu einer bestimmten Folie gehören, und Formebene‑Daten für Metadaten, die an einer einzelnen Form hängen.

### **Alle benutzerdefinierten XML‑Teile auflisten und prüfen**

Verwenden Sie [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_allcustomxmlparts/), um alle benutzerdefinierten XML‑Teile aus einer Präsentation abzurufen. Jeder [`ICustomXmlPart`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpart/) stellt seine Kennung, den XML‑Inhalt und die zugehörigen Namespace‑Schemas bereit.

Das folgende Beispiel listet alle benutzerdefinierten XML‑Teile und ihre Namespace‑Schemas auf:

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

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) liefert die XML‑Schemas, die dem benutzerdefinierten XML‑Teil zugeordnet sind. Diese Information kann beim Prüfen von Präsentationen nützlich sein, die XML von externen Systemen enthalten.

### **XML‑Inhalt und ItemId lesen und aktualisieren**

Verwenden Sie [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) und `set_XmlAsString`, um mit XML als UTF‑8‑Zeichenkette zu arbeiten, oder [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpart/get_xmldata/) und `set_XmlData`, um mit den rohen XML‑Bytes zu arbeiten. Beide Darstellungen können gelesen und aktualisiert werden.

Die Methode [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpart/get_itemid/) gibt die GUID zurück, die den benutzerdefinierten XML‑Teil im Office Open XML‑Dokument eindeutig identifiziert. Die Kennung kann mit `set_ItemId` ebenfalls geändert werden, wenn eine Integration eine neue Kennung erfordert.

Das folgende Beispiel aktualisiert den XML‑Inhalt und die Kennung:

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

// Lese das aktuelle XML als Text.
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// Aktualisiere das XML als UTF-8-Zeichenkette.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData liefert denselben XML-Inhalt als Rohbytes.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Ersetze die Kennung, wenn die Integration es erfordert.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Beim Zuweisen von XML mit `set_XmlAsString` oder `set_XmlData` muss gültiges, nicht leeres XML angegeben werden. Verwenden Sie die eine oder andere Darstellung, je nachdem, ob die Anwendung primär mit Zeichenketten oder Binärdaten arbeitet.

### **Einen benutzerdefinierten XML‑Teil entfernen**

Aspose.Slides bietet mehrere Möglichkeiten, benutzerdefinierte XML‑Daten zu entfernen:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpart/remove/) entfernt den benutzerdefinierten XML‑Teil aus der Präsentation.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpartcollection/remove/) entfernt einen bestimmten Teil aus einer Sammlung benutzerdefinierter XML‑Teile.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpartcollection/removeat/) entfernt den Teil an einem angegebenen Sammlungs‑Index.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpartcollection/clear/) entfernt alle Teile aus einer bestimmten Sammlung.

Das folgende Beispiel entfernt einen Präsentationsebene‑XML‑Teil per Referenz:

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

Wenn Sie bereits ein `ICustomXmlPart` besitzen und diesen Teil aus der Präsentation entfernen möchten, rufen Sie `customXmlPart->Remove()` auf.

Ein Teil kann auch per Index entfernt werden:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Alle benutzerdefinierten XML‑Teile einer Sammlung leeren**

Verwenden Sie `Clear`, wenn alle benutzerdefinierten XML‑Teile, die einem bestimmten Präsentationsobjekt zugeordnet sind, entfernt werden sollen.

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

`Clear` wirkt nur auf die ausgewählte Sammlung. Das Leeren der Sammlung einer Folie entfernt beispielsweise nicht die Sammlungen auf Präsentations‑ oder Formebene.

Um jeden benutzerdefinierten XML‑Teil in der Präsentation zu entfernen, iterieren Sie über `get_AllCustomXmlParts()` und entfernen jeden Teil:

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

### **Verknüpfte oder gemeinsam genutzte benutzerdefinierte XML‑Teile handhaben**

In einer Office Open XML‑Präsentation kann derselbe benutzerdefinierte XML‑Teil von mehr als einem Präsentationsobjekt referenziert werden. Beispielsweise kann eine vorhandene Datei Beziehungen von mehreren Folien oder Formen zum gleichen zugrunde liegenden XML‑Teil enthalten.

Ein gemeinsam genutzter Teil sollte als ein Datenobjekt mit mehreren Verweisen behandelt werden:

- Die Aktualisierung mit `set_XmlAsString`, `set_XmlData` oder `set_ItemId` ändert den zugrunde liegenden XML‑Teil, sodass die Änderung überall wirksam wird, wo der Teil referenziert wird.
- `get_ItemId()` kann verwendet werden, um denselben benutzerdefinierten XML‑Teil beim Prüfen von Objekt‑Sammlungen zu identifizieren.
- Das Entfernen eines Teils aus einer bestimmten `get_CustomXmlParts()`‑Sammlung entfernt ihn nur aus dieser Sammlung. Verwenden Sie `ICustomXmlPart::Remove()`, wenn der Teil selbst aus der Präsentation entfernt werden soll.
- Vor dem Löschen oder Ersetzen eines gemeinsam genutzten Teils sollten Sie die Objekt‑Sammlungen prüfen, um festzustellen, ob weitere Folien oder Formen noch darauf verweisen.

Die `Add`‑Überladungen erstellen einen neuen benutzerdefinierten XML‑Teil aus XML‑Inhalt; sie akzeptieren keinen bereits bestehenden `ICustomXmlPart`. Daher treten gemeinsam genutzte Beziehungen am häufigsten beim Laden von Präsentationen auf, die sie bereits enthalten.

Das folgende Beispiel prüft Präsentations‑, Folien‑ und Formebene‑Sammlungen nach `ItemId` und meldet Teile, die von mehr als einem Ort referenziert werden:

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

Eine solche Prüfung ist vor Änderungen oder dem Entfernen benutzerdefinierter XML‑Daten in von externen Systemen erstellten Präsentationen sinnvoll, da derselbe Metadaten‑Teil an mehreren Beziehungen beteiligt sein kann.

## **Tag‑Werte abrufen**

In Slides entspricht ein Tag der Eigenschaft `IDocumentProperties::get_Keywords`. Dieses Beispiel zeigt, wie man mit Aspose.Slides für C++ den Wert eines Tags einer [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) erhält:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- dem Namen einer benutzerdefinierten Eigenschaft, z. B. `MyTag`;
- dem Wert der benutzerdefinierten Eigenschaft, z. B. `My Tag Value`.

Wenn Sie Präsentationen nach einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie dafür Tags hinzufügen. Beispiel: Möchten Sie Präsentationen aus nordamerikanischen Ländern kategorisieren, können Sie einen Tag „NorthAmerica“ erstellen und das jeweilige Land als Wert zuweisen.

Das folgende Beispiel zeigt, wie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) mit Aspose.Slides für C++ hinzugefügt wird:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

Tags können auch für eine [Slide](https://reference.aspose.com/slides/de/cpp/aspose.slides/slide/) gesetzt werden:

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

Oder für eine einzelne [Shape](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/):

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

### **Einschränkungen**

Tags, die über die Sammlung `get_CustomData()->get_Tags()` hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation als PDF exportiert wird. Somit kann ein als Tag gespeicherter benutzerdefinierter Bezeichner nicht aus dem getaggten PDF ausgelesen werden.

**Umgehungslösung**: Sie können einen benutzerdefinierten Bezeichner im **Alternativ‑Text** des Objekts speichern (z. B. `shape->set_AlternativeText(u"MyId")`). Nach dem Export nach PDF kann der Alternativ‑Text in der PDF‑Tag‑Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [Tag‑Sammlung](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/) unterstützt die Operation [Clear](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/clear/), die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu iterieren?**

Verwenden Sie [Remove(name)](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/remove/) auf der [TagCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [GetNamesOfTags](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/getnamesoftags/) auf der [Tag‑Sammlung](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.

**Wie finde ich alle benutzerdefinierten XML‑Teile, unabhängig davon, wo sie gespeichert sind?**

Verwenden Sie [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_allcustomxmlparts/), um alle benutzerdefinierten XML‑Teile in der Präsentation abzurufen.

**Soll ich `get_XmlAsString`/`set_XmlAsString` oder `get_XmlData`/`set_XmlData` zum Aktualisieren eines benutzerdefinierten XML‑Teils verwenden?**

Verwenden Sie `get_XmlAsString` und `set_XmlAsString`, wenn die Anwendung mit UTF‑8‑XML‑Text arbeitet. Verwenden Sie `get_XmlData` und `set_XmlData`, wenn das XML bereits als Byte‑Array vorliegt oder eine binäre Verarbeitung vorzuziehen ist. Beide Darstellungen beziehen sich auf den XML‑Inhalt desselben benutzerdefinierten XML‑Teils.