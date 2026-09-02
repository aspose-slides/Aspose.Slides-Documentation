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
- Wertepaare
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte XML-Daten in PowerPoint-Präsentationen mit Aspose.Slides für C++ verwalten, einschließlich Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML-Teile."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint-Präsentationen arbeitet. Präsentationsspezifische Daten können als Tags oder benutzerdefinierte XML-Teile gespeichert werden. Tags sind einfache Schlüssel‑Wert‑String‑Paare, während benutzerdefinierte XML-Teile strukturierte Metadaten und anwendungsspezifische XML‑Nutzdaten speichern können.

Aspose.Slides stellt APIs zum Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML‑Teile auf Präsentations‑, Folien‑ und Formen‑Ebene bereit. Benutzerdefinierte XML‑Teile sind nützlich für Integrationen, die Informationen wie Dokumentverwaltungs‑Kennungen, Workflow‑Status, Compliance‑Metadaten, Vorlagen‑Bindungsdaten oder andere strukturierte Anwendungsdaten innerhalb einer Präsentation speichern.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien — Dateien mit der Dateierweiterung `.pptx` — werden im PresentationML‑Format gespeichert, das Teil der Office‑Open‑XML‑Spezifikation ist. Office Open XML definiert die Paketstruktur und Beziehungen, die zum Speichern von Präsentationsinhalt und zugehörigen Daten verwendet werden.

Eine Präsentation enthält mehrere Teile, die durch Beziehungen verbunden sind. Zum Beispiel enthält ein Folienteil den Inhalt einer einzelnen Folie und kann explizite Beziehungen zu anderen Teilen haben, die von ISO/IEC 29500 definiert werden.

Benutzerdefinierte Daten können als Tags ([ITagCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/itagcollection/)) oder benutzerdefinierte XML‑Teile ([ICustomXmlPartCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpartcollection/)) gespeichert werden. Beide sind über die Schnittstelle [`ICustomData`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomdata/) verfügbar.

{{% alert color="primary" %}}
Tags speichern einfache Schlüssel‑Wert‑String‑Paare. Benutzerdefinierte XML‑Teile speichern strukturierte XML‑Daten und können einer Präsentation, Folie oder Form zugeordnet werden.
{{% /alert %}}

## **Arbeiten mit benutzerdefinierten XML‑Teilen**

Die Methode [`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomdata/get_customxmlparts/) gibt die Sammlung benutzerdefinierter XML‑Teile zurück, die mit einem bestimmten Präsentationsobjekt verknüpft sind. Beispiel:

- `presentation->get_CustomData()->get_CustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die mit der Präsentation selbst verknüpft sind.
- `slide->get_CustomData()->get_CustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die mit einer bestimmten Folie verknüpft sind.
- `shape->get_CustomData()->get_CustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die mit einer bestimmten Form verknüpft sind.

Verwenden Sie [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_allcustomxmlparts/), wenn Sie alle benutzerdefinierten XML‑Teile in der Präsentation prüfen müssen, unabhängig davon, wo sie verknüpft sind.

### **Ein benutzerdefiniertes XML‑Teil zu einer Präsentation hinzufügen**

Verwenden Sie [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpartcollection/add/), um XML‑Daten zu einer benutzerdefinierten XML‑Teil‑Sammlung hinzuzufügen. Das XML muss gültig und nicht leer sein.

Das folgende Beispiel fügt strukturierte Metadaten zur Präsentations‑Ebene der benutzerdefinierten Datensammlung hinzu:

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

// Add weist automatisch eine Kennung zu. Setzen Sie nur bei Bedarf eine bestimmte GUID.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

Die Methode `Add` kann XML auch als Byte‑Array oder Stream akzeptieren, was nützlich ist, wenn XML‑Inhalt bereits in binärer Form vorliegt.

### **Ein benutzerdefiniertes XML‑Teil zu einer Folie oder Form hinzufügen**

Benutzerdefinierte XML‑Daten können einem bestimmten Folien‑ oder Formobjekt zugeordnet werden, anstatt der gesamten Präsentation. Dies ist nützlich, wenn Metadaten nur ein Objekt beschreiben, z. B. einen Vorlagenschlüssel, eine externe Datensatz‑Kennung oder Bindungsinformationen.

Das folgende Beispiel fügt einer Folie einen benutzerdefinierten XML‑Teil und einer Form einen weiteren hinzu:

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

Die Ebene, auf der ein Teil hinzugefügt wird, bestimmt, welche Sammlung `get_CustomData()->get_CustomXmlParts()` des Objekts die Beziehung zu diesem Teil enthält. Präsentations‑Ebene‑Daten eignen sich für dokumentweite Metadaten, Folien‑Ebene‑Daten für Informationen, die zu einer bestimmten Folie gehören, und Form‑Ebene‑Daten für Metadaten, die an einer einzelnen Form hängen.

### **Alle benutzerdefinierten XML‑Teile auflisten und prüfen**

Verwenden Sie [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_allcustomxmlparts/), um alle benutzerdefinierten XML‑Teile aus einer Präsentation abzurufen. Jeder [`ICustomXmlPart`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpart/) stellt seine Kennung, den XML‑Inhalt und zugehörige Namespace‑Schemata bereit.

Das folgende Beispiel listet alle benutzerdefinierten XML‑Teile und ihre Namespace‑Schemata auf:

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

`[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/)` gibt die XML‑Schemata zurück, die dem benutzerdefinierten XML‑Teil zugeordnet sind. Diese Information kann beim Prüfen von Präsentationen nützlich sein, die XML von externen Systemen enthalten.

### **XML‑Inhalt und ItemId lesen und aktualisieren**

Verwenden Sie [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) und `set_XmlAsString`, um mit XML als UTF‑8‑String zu arbeiten, oder [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpart/get_xmldata/) und `set_XmlData`, um mit den rohen XML‑Bytes zu arbeiten. Beide Darstellungen können gelesen und aktualisiert werden.

Die Methode [`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpart/get_itemid/) gibt die GUID zurück, die den benutzerdefinierten XML‑Teil im Office‑Open‑XML‑Dokument identifiziert. Die Kennung kann bei Bedarf mit `set_ItemId` geändert werden, wenn eine Integration eine neue Kennung erfordert.

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

// Aktualisiere das XML als UTF-8-String.
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData liefert den gleichen XML-Inhalt als Rohbytes.
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// Ersetze die Kennung, wenn sie von der Integration benötigt wird.
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

Beim Zuweisen von XML mit `set_XmlAsString` oder `set_XmlData` muss gültiges, nicht leeres XML bereitgestellt werden. Verwenden Sie die eine oder andere Darstellung, je nachdem, ob die Anwendung hauptsächlich mit Zeichenketten oder Byte‑Daten arbeitet.

### **Einen benutzerdefinierten XML‑Teil entfernen**

Aspose.Slides bietet mehrere Möglichkeiten, benutzerdefinierte XML‑Daten zu entfernen:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpart/remove/) entfernt den benutzerdefinierten XML‑Teil aus der Präsentation.
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpartcollection/remove/) entfernt einen bestimmten Teil aus einer benutzerdefinierten XML‑Teil‑Sammlung.
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpartcollection/removeat/) entfernt den Teil an einem angegebenen Sammlungs‑Index.
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpartcollection/clear/) entfernt alle Teile aus einer bestimmten Sammlung.

Das folgende Beispiel entfernt einen benutzerdefinierten XML‑Teil auf Präsentationsebene per Referenz:

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

Wenn Sie bereits ein `ICustomXmlPart` besitzen und diesen Teil aus der Präsentation entfernen möchten, anstatt eine bestimmte Sammlung anzusprechen, rufen Sie `customXmlPart->Remove()` auf.

Sie können ein Element auch nach Index entfernen:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **Alle benutzerdefinierten XML‑Teile aus einer Sammlung löschen**

Verwenden Sie `Clear`, wenn alle mit einem bestimmten Präsentationsobjekt verknüpften benutzerdefinierten XML‑Teile entfernt werden sollen.

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

`Clear` wirkt nur auf die ausgewählte Sammlung. Beispielsweise löscht das Leeren der Folien‑Sammlung nicht die Sammlungen auf Präsentations‑ oder Form‑Ebene.

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

### **Verknüpfte oder gemeinsam genutzte benutzerdefinierte XML‑Teile behandeln**

In einer Office‑Open‑XML‑Präsentation kann derselbe benutzerdefinierte XML‑Teil von mehr als einem Präsentationsobjekt referenziert werden. Beispielsweise kann eine vorhandene Datei Beziehungen von mehreren Folien oder Formen zu demselben zugrunde liegenden benutzerdefinierten XML‑Teil enthalten.

Ein gemeinsam genutzter Teil sollte als ein Datenobjekt mit mehreren Referenzen behandelt werden:

- Das Aktualisieren mit `set_XmlAsString`, `set_XmlData` oder `set_ItemId` ändert den zugrunde liegenden benutzerdefinierten XML‑Teil, sodass die Änderung überall dort wirksam ist, wo dieser Teil referenziert wird.
- `get_ItemId()` kann verwendet werden, um denselben benutzerdefinierten XML‑Teil bei der Prüfung von Sammlungen auf Objektebene zu identifizieren.
- Das Entfernen eines Teils aus einer bestimmten `get_CustomXmlParts()`‑Sammlung entfernt ihn aus dieser Sammlung. Verwenden Sie `ICustomXmlPart::Remove()`, wenn der Teil selbst aus der Präsentation entfernt werden soll.
- Vor dem Löschen oder Ersetzen eines gemeinsam genutzten Teils sollten Sie die Sammlungen auf Objektebene prüfen, um festzustellen, ob andere Folien oder Formen ihn noch referenzieren.

Die `Add`‑Überladungen erzeugen einen neuen benutzerdefinierten XML‑Teil aus XML‑Inhalt; sie akzeptieren keinen bestehenden `ICustomXmlPart`. Daher treten gemeinsam genutzte Beziehungen am häufigsten beim Laden von Präsentationen auf, die bereits solche Teile enthalten.

Das folgende Beispiel prüft die Sammlungen auf Präsentations‑, Folien‑ und Form‑Ebene nach `ItemId` und berichtet über Teile, die von mehr als einem Ort referenziert werden:

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

Diese Art von Prüfung ist nützlich, bevor benutzerdefinierte XML‑Daten in von externen Systemen erstellten Präsentationen geändert oder gelöscht werden, da derselbe Metadaten‑Teil an mehr als einer Beziehung beteiligt sein kann.

## **Werte von Tags abrufen**

In Slides entspricht ein Tag der Eigenschaft `IDocumentProperties::get_Keywords`. Dieser Beispielcode zeigt, wie man einen Tag‑Wert mit Aspose.Slides für C++ für [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) abruft:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- den Namen einer benutzerdefinierten Eigenschaft, z. B. `MyTag`;
- den Wert der benutzerdefinierten Eigenschaft, z. B. `My Tag Value`.

Wenn Sie Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie dafür Tags hinzufügen. Beispielsweise können Sie, wenn Sie Präsentationen aus nordamerikanischen Ländern kategorisieren möchten, ein „North American“-Tag erstellen und das entsprechende Land als Wert zuweisen.

Dieser Beispielcode zeigt, wie man mit Aspose.Slides für C++ einem [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) ein Tag hinzufügt:

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

Tags, die über die Sammlung `get_CustomData()->get_Tags()` hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation nach PDF exportiert wird. Folglich kann ein als Tag zugewiesener benutzerdefinierter Identifikator nicht aus dem getaggten PDF abgerufen werden.

**Workaround**: Sie können einen benutzerdefinierten Identifikator im **Alt‑Text** des Objekts speichern (z. B. `shape->set_AlternativeText(u\"MyId\")`). Nach dem Export nach PDF kann der Alt‑Text in der PDF‑Tag‑Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [Tag‑Collection](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/) unterstützt eine [Clear](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie [Remove(name)](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/remove/) auf der [TagCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die komplette Liste der Tag‑Namen für Analysen oder Filterung abrufen?**

Verwenden Sie [GetNamesOfTags](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/getnamesoftags/) auf der [Tag‑Collection](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.

**Wie finde ich alle benutzerdefinierten XML‑Teile, unabhängig davon, wo sie gespeichert sind?**

Verwenden Sie [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_allcustomxmlparts/), um alle benutzerdefinierten XML‑Teile in der Präsentation abzurufen.

**Soll ich `get_XmlAsString`/`set_XmlAsString` oder `get_XmlData`/`set_XmlData` verwenden, um einen benutzerdefinierten XML‑Teil zu aktualisieren?**

Verwenden Sie `get_XmlAsString` und `set_XmlAsString`, wenn die Anwendung mit UTF‑8‑XML‑Text arbeitet. Verwenden Sie `get_XmlData` und `set_XmlData`, wenn das XML bereits als Byte‑Array vorliegt oder eine binärorientierte Verarbeitung praktischer ist. Beide Darstellungen beziehen sich auf den XML‑Inhalt desselben benutzerdefinierten XML‑Teils.