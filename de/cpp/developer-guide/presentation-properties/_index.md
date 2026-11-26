---
title: Verwalten von Präsentationseigenschaften in C++
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/cpp/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- eingebaute Eigenschaften
- benutzerdefinierte Eigenschaften
- erweiterte Eigenschaften
- Eigenschaften verwalten
- Eigenschaften ändern
- Dokumentmetadaten
- Metadaten bearbeiten
- Korrektursprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Steuern Sie Präsentationseigenschaften in Aspose.Slides für C++ und optimieren Sie Suche, Branding und Arbeitsablauf in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einleitung**

Aspose.Slides für C++ unterstützt **eingebaute** und **benutzerdefinierte** Dokumenteigenschaften. Verwenden Sie diese Eigenschaften, um Präsentations‑Metadaten zu lesen und zu aktualisieren, z. B. den Autor, den Titel und benutzerdefinierte Werte.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über das [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) Interface. Eine Instanz dieses Interfaces wird von [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Note" %}}
Aspose.Slides verwaltet die Anwendungs‑ und Ersteller‑Metadaten beim Speichern von Präsentationen; diese Felder identifizieren die Software, die die Ausgabe erstellt hat.
{{% /alert %}}

## **Präsentationseigenschaften verwalten**

Dokumenteigenschaften speichern beschreibende Informationen zusammen mit dem Präsentationsinhalt. Sie lassen sich in zwei Kategorien einteilen:

- **Eingebaute Eigenschaften** enthalten standardisierte Metadaten, wie Titel, Autor und Dokumentstatistiken.
- **Benutzerdefinierte Eigenschaften** speichern benutzerdefinierte Namens‑/Wert‑Paare.

Aspose.Slides für C++ bietet Zugriff auf beide Kategorien. In PowerPoint wählen Sie **Datei → Info → Eigenschaften → Erweiterte Eigenschaften**, um die Dokumentmetadaten zu prüfen. Der Dialog gruppiert Informationen in Registerkarten wie **Zusammenfassung**, **Statistiken**, **Inhalte** und **Benutzerdefiniert**. Verwenden Sie die Registerkarte **Benutzerdefiniert**, um benutzerdefinierte Eigenschaften zu verwalten.

## **Öffentliche Eigenschaften aus einer verschlüsselten Präsentation lesen**

Ein Öffnungskennwort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wenn eine Präsentation verschlüsselt wird, indem `false` an [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) übergeben wird, bleiben ihre Dokumenteigenschaften öffentlich. Eine Anwendung kann dann `true` an [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) übergeben und die öffentlichen Metadaten lesen, ohne das Öffnungskennwort anzugeben.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) steuert, was Aspose.Slides lädt; es entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Kennwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die gesamte Präsentation geladen.

Das Beispiel benötigt eine verschlüsselte Präsentation, deren Dokumenteigenschaften öffentlich bleiben. Es prüft den Lademodus über [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/), und liest anschließend eingebaute Eigenschaften über [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

In diesem Modus wird der Folieninhalt nicht geladen. Folien, Folienmaster, Layouts, Formen, Medien und andere Präsentationsobjekte sind nicht verfügbar. Anwendungen sollten stets [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) prüfen, bevor sie eine Operation ausführen, die das vollständige Präsentationsobjektmodell erfordert.

{{% alert color="warning" title="Security" %}}
Öffentliche Metadaten können Autorennamen, Titel, Betreffe, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte offenbaren. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur dann öffentlich, wenn Indexierungs‑, Klassifizierungs‑, Such‑ oder Dokumentenverwaltungssysteme eine spezielle Anforderung haben, ohne Kennwort darauf zuzugreifen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine Präsentation, die durch Übergabe von `true` an [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) geladen wird, zum Lesen öffentlicher Metadaten vorgesehen. Aspose.Slides kann geänderte Eigenschaften dieses reinen Metadaten‑Objekts nicht speichern, weil die öffentlichen Eigenschaften mit den entsprechenden Daten in der verschlüsselten Präsentation konsistent bleiben müssen. Das Aktualisieren erfordert daher das korrekte Öffnungskennwort und einen vollständigen Ladevorgang.

Das Beispiel benötigt eine verschlüsselte PPTX‑Präsentation mit öffentlichen Dokumenteigenschaften und einem bekannten Öffnungskennwort. Es öffnet die vollständige Präsentation mit [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/), aktualisiert öffentliche eingebaute Eigenschaften und speichert das Ergebnis. Anschließend wird mit [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) überprüft, dass die Verschlüsselung erhalten bleibt, und die öffentlichen Metadaten werden ohne Kennwort erneut geöffnet, um die neuen Werte zu prüfen:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Wenn einer Anwendung das Entschlüsseln oder Laden des Präsentationsinhalts nicht gestattet ist, muss sie öffentliche Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf eingebaute Eigenschaften**

Das [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) Interface stellt eingebaute Metadaten über typisierte Getter bereit, darunter [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) und [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). Dieses Beispiel öffnet eine vorhandene Präsentation und gibt deren gespeicherte Metadaten in der Konsole aus. Die Werte hängen von der Eingabepäsentation ab; einige Felder können leer sein.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

### **Revisionnummer und Bearbeitungszeit melden**

Verwenden Sie [GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) und [ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/), um die [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) jeder Datei zu lesen, ohne deren Folien zum Bearbeiten zu laden. Dieses Beispiel gibt für jede PPTX‑Datei im Ordner `presentations` eine Zeile aus. Das Standardformat `c` beinhaltet die Tagesanzahl, wenn die aufgezeichnete Bearbeitungszeit 24 Stunden erreicht.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/timespan.h>

using namespace Aspose::Slides;
using namespace System::IO;

System::Console::WriteLine(u"File | RevisionNumber | TotalEditingTime");
auto paths = Directory::GetFiles(u"presentations", u"*.pptx");
for (const auto& path : paths)
{
    auto info = PresentationFactory::get_Instance()->GetPresentationInfo(path);
    auto properties = info->ReadDocumentProperties();
    auto fileName = Path::GetFileName(path);
    auto editingTime = properties->get_TotalEditingTime().ToString(u"c");
    System::Console::WriteLine(u"{0} | {1} | {2}", fileName, properties->get_RevisionNumber(), editingTime);
}
```

Für eine Präsentation mit 1 Tag, 2 Stunden und 5 Minuten aufgezeichneter Bearbeitungszeit sieht der Bericht wie folgt aus:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[get_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_revisionnumber/) liest einen Metadatenwert, den Anwendungen mit [set_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_revisionnumber/) ändern können. Dieser Wert allein kann nicht ermitteln, wie oft die Präsentation gespeichert wurde, noch die Versionsgeschichte rekonstruieren.

[get_TotalEditingTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_totaleditingtime/) liefert die in der Datei aufgezeichnete Bearbeitungsdauer zurück. Ein Wert von `00:00:00` bedeutet, dass die gespeicherte Dauer null ist. Die Präsentation könnte dennoch bearbeitet worden sein.

## **Eingebaute Eigenschaften ändern**

Um eingebaute Metadaten zu aktualisieren, verwenden Sie die Setter des Objekts, das von [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) zurückgegeben wird. Dieses Beispiel öffnet eine vorhandene Präsentation, ruft [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/) und [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/) auf und speichert die aktualisierte Präsentation mit [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Das gespeicherte PPTX enthält die neuen Metadaten.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Verwalten der Hyperlink-Basis**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) liest die dokumentweite Basis für relative Hyperlinks. Dies ist nützlich, wenn eine Präsentation und ihre verknüpften Dateien an einen anderen Ort verschoben werden. Sie ist von der einzelnen Hyperlink‑Eigenschaft [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) getrennt: Das Ändern der Basis überschreibt nicht die gespeicherten Linkadressen und ändert keine absoluten Ziele.

Das Beispiel benötigt eine Präsentation, die sowohl einen relativen Link, z. B. `target.html`, als auch einen absoluten Link, z. B. `https://example.org/absolute.html`, enthält. Es liest die vorhandene Basis, weist mit [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/) eine neue Basisadresse zu und speichert die Präsentation, um den Wert zu überprüfen, indem sie erneut geöffnet wird. Anschließend wird die Basis mit `u""` geleert und der leere Wert in einer separaten gespeicherten Datei verifiziert. Ersetzen Sie die Beispiel‑Basisadresse durch den Ort Ihrer verknüpften Dateien.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

Die beiden Verifizierungsnachrichten sollten `True` ausgeben. Das Leeren der Basis lässt die einzelnen Hyperlink‑Adressen unverändert.

Ein relativer Link zu `target.pptx` öffnete `old/target.pptx`, als die Basis auf den Ordner `old` zeigte. Nach dem Ändern der Basis auf den Ordner `new`, dem Speichern und erneutem Öffnen der Präsentation öffnete derselbe Link `new/target.pptx`. Ein absoluter Link öffnete weiterhin dieselbe Datei. Testen Sie Ihre relativen Links in PowerPoint vor und nach dem Verschieben der Präsentation oder dem Ändern ihrer Basis.

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Benutzerdefinierte Eigenschaften speichern Metadaten, für die es kein entsprechendes eingebautes Feld gibt. [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) ermöglicht das Zuweisen eines Werts über den Eigenschaftsnamen. Dieses Beispiel erstellt eine Präsentation, fügt zwei Textwerte und einen ganzzahligen Versionswert hinzu und speichert die Präsentation mit [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Das Zuweisen eines Werts zu einem bestehenden Namen ersetzt den Wert dieser Eigenschaft.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Dieses Beispiel öffnet eine Präsentation, die benutzerdefinierte Eigenschaften enthält, und verwendet [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/), um über sie zu iterieren. [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) akzeptiert einen nullbasierten Index und gibt den Namen zurück, der von [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) und [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) verwendet wird. Das Beispiel gibt jeden ursprünglichen Namen und Wert aus, ersetzt jeden Wert durch einen nummerierten String, unabhängig vom ursprünglichen Typ, und speichert die Änderungen. Gibt es keine benutzerdefinierten Eigenschaften, nimmt die Schleife keine Änderungen vor.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **Live‑Beispiel**

Probieren Sie die Online‑App [**Ansicht & Bearbeitung von PowerPoint-Metadaten**](https://products.aspose.app/slides/metadata), um zu sehen, wie man mit Dokumenteigenschaften über die Aspose.Slides‑API arbeitet:

[![Ansicht & Bearbeitung von PowerPoint-Metadaten](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch ihre Werte ändern oder, sofern die jeweilige Eigenschaft dies zulässt, sie auf leer setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr bestehender Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert der Eigenschaft automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die Präsentation vollständig zu laden?**

Ja. Verwenden Sie [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) und anschließend [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Instanz zu erzeugen. Siehe [Erstellen eines leichten Präsentationsinventars](/slides/de/cpp/examine-presentation/) für ein vollständiges Berichtbeispiel und formatbezogene Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne ihr Öffnungskennwort lesen?**

Ja. Die Präsentation muss verschlüsselt worden sein, indem `false` an [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) übergeben wurde, und sie muss geladen werden, indem `true` an [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) übergeben wird.

**Kann ich eine verschlüsselte PPTX‑Datei im Nur‑Dokument‑Eigenschaften‑Modus aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben, daher erfordert das Aktualisieren einer verschlüsselten PPTX‑Datei das Laden der vollständigen Präsentation mit dem korrekten Öffnungskennwort.