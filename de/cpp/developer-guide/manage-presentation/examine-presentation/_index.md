---
title: Präsentationsinformationen abrufen und aktualisieren in C++
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/cpp/examine-presentation/
keywords:
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteneigenschaften
- Eigenschaften abrufen
- Eigenschaften lesen
- Eigenschaften ändern
- Eigenschaften modifizieren
- Eigenschaften aktualisieren
- PPTX untersuchen
- PPT untersuchen
- ODP untersuchen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mithilfe von C++ für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---

Aspose.Slides für C++ ermöglicht es Ihnen, eine Präsentation zu untersuchen, um deren Eigenschaften zu ermitteln und ihr Verhalten zu verstehen. 

{{% alert title="Info" color="info" %}}
Die Klassen PresentationInfo und DocumentProperties enthalten die Eigenschaften und Methoden, die in den hier gezeigten Vorgängen verwendet werden.
{{% /alert %}} 

## **Prüfen des Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation derzeit befindet.

Sie können das Format einer Präsentation prüfen, ohne die Präsentation zu laden. Siehe diesen C++‑Code:
``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```


## **Präsentationseigenschaften abrufen**

Dieser C++‑Code zeigt, wie Sie Präsentationseigenschaften (Informationen zur Präsentation) abrufen können:
``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```


## **Präsentationseigenschaften aktualisieren**

Aspose.Slides bietet die Methode PresentationInfo::UpdateDocumentProperties, mit der Sie Änderungen an den Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteneigenschaften.

![Originale Dokumenteneigenschaften der PowerPoint‑Präsentation](input_properties.png)

Dieses Codebeispiel zeigt, wie Sie einige Präsentationseigenschaften bearbeiten können:
```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```


Die Ergebnisse der Änderung der Dokumenteneigenschaften werden unten angezeigt.

![Geänderte Dokumenteneigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Weitere Informationen zu einer Präsentation und deren Sicherheitsattributen finden Sie in diesen Links:

- [Überprüfung, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfung, ob eine Präsentation schreibgeschützt (nur lesbar) ist](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfung, ob eine Präsentation passwortgeschützt ist, bevor sie geladen wird](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigung des zum Schutz einer Präsentation verwendeten Passworts](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Wie kann ich prüfen, ob Schriften eingebettet sind und welche das sind?**

Suchen Sie nach eingebetteten Schriftinformationen auf Präsentationsebene und vergleichen Sie diese Einträge anschließend mit dem Satz der tatsächlich im Inhalt verwendeten Schriften, um zu ermitteln, welche Schriften für die Darstellung entscheidend sind.

**Wie kann ich schnell feststellen, ob die Datei verborgene Folien enthält und wie viele?**

Durchlaufen Sie die Folien‑Collection und prüfen Sie das Sichtbarkeits‑Flag jeder Folie.

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet wird und ob sie von den Vorgabewerten abweicht?**

Ja. Vergleichen Sie die aktuelle Foliengröße und -ausrichtung mit den Standard‑Presets; dies hilft, das Verhalten für Druck und Export vorherzusehen.

**Gibt es eine schnelle Methode zu prüfen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle Diagramme, prüfen Sie deren Datenquelle und stellen Sie fest, ob die Daten intern oder verlinkt sind, einschließlich etwaiger defekter Links.

**Wie kann ich „schwere“ Folien einschätzen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objektanzahl und achten Sie auf große Bilder, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie eine grobe Komplexitätsbewertung, um potenzielle Leistungsengpässe zu kennzeichnen.