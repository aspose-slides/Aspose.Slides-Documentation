---
title: "Verwalten von Präsentationseigenschaften in C++"
linktitle: "Präsentationseigenschaften"
type: docs
weight: 70
url: /de/cpp/presentation-properties/
keywords:
  - "PowerPoint‑Eigenschaften"
  - "Präsentationseigenschaften"
  - "Dokumenteigenschaften"
  - "Eingebaute Eigenschaften"
  - "Benutzerdefinierte Eigenschaften"
  - "Erweiterte Eigenschaften"
  - "Eigenschaften verwalten"
  - "Eigenschaften ändern"
  - "Dokument‑Metadaten"
  - "Metadaten bearbeiten"
  - "Korrektursprache"
  - "Standardsprache"
  - "PowerPoint"
  - "OpenDocument"
  - "Präsentation"
  - "C++"
  - "Aspose.Slides"
description: "Meistern Sie die Präsentationseigenschaften in Aspose.Slides für C++ und optimieren Sie Suche, Branding und Arbeitsabläufe in Ihren PowerPoint‑ und OpenDocument‑Dateien."
---
## **Einführung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Eingebaute** und **Benutzerdefinierte**. Auf beide Typen kann einfach über die Aspose.Slides‑API zugegriffen und sie verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Eigenschaften von Präsentationsdokumenten über die Schnittstelle [IDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/). Eine Instanz dieser Schnittstelle wird von [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_documentproperties/) zurückgegeben. Die folgenden Beispiele zeigen, wie diese Eigenschaften gelesen, geändert und verwaltet werden können.

{{% alert color="info" title="Note" %}}

Bitte beachten Sie, dass Sie die Felder **Application** und **Producer** nicht setzen können, da „Aspose Ltd.“ und „Aspose.Slides for C++ x.x.x“ in diesen Feldern angezeigt werden.

{{% /alert %}} 

## **Verwalten von Präsentationseigenschaften**

Microsoft PowerPoint bietet eine Funktion, um einige Eigenschaften zu Präsentationsdateien hinzuzufügen. Diese Dokumenteigenschaften ermöglichen das Speichern nützlicher Informationen zusammen mit den Dokumenten (Präsentationsdateien). Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (eingebaute) Eigenschaften
- Benutzerdefinierte (benutzerdefinierte) Eigenschaften

**Eingebaute** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie Dokumenttitel, Autorname, Dokumentstatistiken usw. **Benutzerdefinierte** Eigenschaften werden von den Benutzern als **Name/Wert‑Paare** definiert, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides for C++ können Entwickler die Werte eingebauter Eigenschaften sowie benutzerdefinierter Eigenschaften lesen und ändern. Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Dazu klicken Sie einfach auf das Office‑Symbol und anschließend auf **Prepare | Properties | Advanced Properties** in Microsoft PowerPoint 2007. Nach der Auswahl von **Advanced Properties** erscheint ein Dialog, mit dem Sie die Dokumenteigenschaften der PowerPoint‑Datei verwalten können. Im **Properties Dialog** sehen Sie mehrere Registerkarten wie **General, Summary, Statistics, Contents und Custom**. Alle diese Registerkarten erlauben die Konfiguration verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um benutzerdefinierte Eigenschaften der PowerPoint‑Dateien zu verwalten.

## **Öffentliche Eigenschaften aus einer verschlüsselten Präsentation lesen**

Ein Öffnungs­passwort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wenn eine Präsentation verschlüsselt wird, indem `false` an [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) übergeben wird, bleiben ihre Dokumenteigenschaften öffentlich. Eine Anwendung kann dann `true` an [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) übergeben und die öffentlichen Metadaten lesen, ohne das Öffnungs­passwort anzugeben.

`set_OnlyLoadDocumentProperties` steuert, was Aspose.Slides lädt; es entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Passwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die gesamte Präsentation geladen.

Das folgende Beispiel prüft den Lademodus über [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) und liest dann eingebaute Eigenschaften über [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

In diesem Modus werden Folieninhalte nicht geladen. Folien, Folienmaster, Layouts, Formen, Medien und andere Präsentationsobjekte stehen nicht zur Verfügung. Anwendungen sollten stets `get_IsOnlyDocumentPropertiesLoaded` prüfen, bevor sie Vorgänge ausführen, die das komplette Präsentationsobjektmodell erfordern.

{{% alert color="warning" title="Warning" %}}
Öffentliche Metadaten können Autorennamen, Titel, Betreff, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte preisgeben. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur öffentlich, wenn Indexierungs‑, Klassifizierungs‑, Such‑ oder Dokument‑Management‑Systeme einen spezifischen Zugriff ohne Passwort benötigen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Bei einer verschlüsselten PPTX‑Datei ist eine Präsentation, die nach Aufruf von `set_OnlyLoadDocumentProperties(true)` geladen wurde, nur zum Lesen öffentlicher Metadaten gedacht. Aspose.Slides kann geänderte Eigenschaften aus diesem reinen Metadaten‑Objekt nicht speichern, da die öffentlichen Eigenschaften mit den entsprechenden Daten in der verschlüsselten Präsentation konsistent bleiben müssen. Ein Update erfordert daher das korrekte Öffnungs­passwort und ein vollständiges Laden.

Das folgende Beispiel öffnet die Präsentation mit [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/), aktualisiert öffentliche eingebaute Eigenschaften und speichert das Ergebnis. Anschließend wird mit [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) geprüft, ob die Verschlüsselung erhalten bleibt, und die öffentlichen Metadaten werden ohne Passwort erneut geöffnet, um die neuen Werte zu prüfen:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Ist einer Anwendung das Entschlüsseln oder Laden des Präsentationsinhalts nicht gestattet, muss sie die öffentlichen Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf eingebaute Eigenschaften**

Diese über das **IDocumentProperties**‑Objekt verfügbaren Eigenschaften umfassen: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Letztes Druckdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Ist zwischen verschiedenen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Eingebaute Eigenschaften ändern**

Das Ändern eingebauter Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen, und der Eigenschaftswert wird geändert. Im nachfolgenden Beispiel wird gezeigt, wie die eingebauten Dokumenteigenschaften einer Präsentationsdatei geändert werden können.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Aspose.Slides for C++ ermöglicht Entwicklern ebenfalls das Hinzufügen benutzerdefinierter Werte für Dokumenteigenschaften einer Präsentation. Das folgende Beispiel zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation festgelegt werden.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanziieren Sie die Presentation-Klasse
auto presentation = System::MakeObject<Presentation>();

// Abrufen der Dokumenteigenschaften
auto documentProperties = presentation->get_DocumentProperties();

// Hinzufügen benutzerdefinierter Eigenschaften
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Abrufen des Eigenschaftsnamens an einem bestimmten Index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Entfernen der ausgewählten Eigenschaft
documentProperties->RemoveCustomProperty(getPropertyName);

// Speichern der Präsentation
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides for C++ ermöglicht Entwicklern außerdem den Zugriff auf die Werte benutzerdefinierter Eigenschaften. Das nachstehende Beispiel zeigt, wie Sie alle benutzerdefinierten Eigenschaften einer Präsentation lesen und ändern können.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Korrektursprache festlegen**

Aspose.Slides stellt die Eigenschaft [LanguageId](https://reference.aspose.com/slides/de/cpp/aspose.slides/baseportionformat/set_languageid/) (bereitgestellt von der Klasse [PortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/portionformat/)) zur Verfügung, mit der Sie die Korrektursprache für ein PowerPoint‑Dokument festlegen können. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

Dieser C++‑Code zeigt, wie die Korrektursprache für ein PowerPoint‑Dokument festgelegt wird:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Standardsprache festlegen**

Dieser C++‑Code zeigt, wie die Standardsprache für eine gesamte PowerPoint‑Präsentation festgelegt wird:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Fügt eine neue Rechteckform mit Text hinzu
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Überprüft die Sprache der ersten Portion
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live‑Beispiel**

Probieren Sie die Online‑App **Aspose.Slides Metadata**[https://products.aspose.app/slides/de/metadata] aus, um zu sehen, wie Sie über die Aspose.Slides‑API mit Dokumenteigenschaften arbeiten:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch ihre Werte ändern oder sie, sofern die jeweilige Eigenschaft dies zulässt, auf einen leeren Wert setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft hinzugefügt, wird ihr bestehender Wert durch den neuen überschrieben. Ein vorheriges Entfernen oder Prüfen der Eigenschaft ist nicht nötig, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**

Ja. Verwenden Sie [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) und anschließend [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/), um gespeicherte Dokument‑Metadaten zu lesen, ohne ein [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Objekt zu erstellen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/cpp/examine-presentation/) für ein vollständiges Bericht‑Beispiel und format‑spezifische Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne ihr Öffnungs­passwort lesen?**

Ja. Die Präsentation muss mit `false` an `set_EncryptDocumentProperties` verschlüsselt worden sein und muss mit `true` an `set_OnlyLoadDocumentProperties` geladen werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Modus „nur Dokumenteigenschaften“ aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben; daher erfordert das Aktualisieren einer verschlüsselten PPTX‑Datei das vollständige Laden der Präsentation mit dem korrekten Öffnungs­passwort.