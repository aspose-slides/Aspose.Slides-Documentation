---
title: Warum keine Automatisierung
type: docs
weight: 40
url: /de/net/why-not-automation/
keywords:
- Automatisierung
- Microsoft Office
- Vergleich
- Sicherheit
- Stabilität
- Skalierbarkeit
- Funktionen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, warum Office-Automatisierung für Server und Dienste riskant ist, und sehen Sie, wie Aspose.Slides eine sicherere, schnellere Präsentationsverarbeitung für PowerPoint und OpenDocument bietet."
---
## **Einführung**

Es gibt mehrere Gründe, warum Aspose‑Komponenten eine bessere Alternative zur Automatisierung sind. Einige der wichtigsten Gründe sind:

- Sicherheit
- Stabilität
- Skalierbarkeit/Geschwindigkeit
- Preis
- Funktionen

Im Folgenden finden Sie eine detailliertere Erklärung jedes wichtigen Punkts.

## **Wichtige Fragen**

Es gibt zwei Fragen, die wir bei Aspose häufig hören:

- Erfordern Ihre Produkte die Installation von Microsoft Office, um ausgeführt zu werden?

  Die kurze, einfache Antwort ist **NEIN**.

Aspose‑Komponenten sind völlig unabhängig und stehen in keiner Verbindung zu, sind nicht autorisiert von, gesponsert von oder anderweitig von Microsoft Corporation genehmigt.

- Warum sollten wir Aspose‑Produkte anstelle von Microsoft Office Automation verwenden?

  Erstens gibt es viele [Vorteile, die Sie beim Einsatz von Aspose.Slides genießen](/slides/de/net/product-overview/).

  Zweitens rät Microsoft selbst **dringend davon ab**, Office Automation in Softwarelösungen zu verwenden.

## **Sicherheit**
Das Folgende ist ein direktes Zitat aus einem Microsoft‑Artikel:

> "Office‑Anwendungen waren niemals für die serverseitige Nutzung vorgesehen und berücksichtigen daher nicht die Sicherheitsprobleme, die bei verteilten Komponenten auftreten. Office authentifiziert eingehende Anfragen nicht und schützt Sie nicht davor, versehentlich Makros auszuführen oder einen anderen Server zu starten, der Makros ausführen könnte, aus Ihrem serverseitigen Code. Öffnen Sie keine Dateien, die von einem anonymen Web‑Benutzer auf den Server hochgeladen wurden! Je nach den zuletzt festgelegten Sicherheitseinstellungen kann der Server Makros unter einem Administrator‑ oder System‑Kontext mit vollen Rechten ausführen und Ihr Netzwerk gefährden! Darüber hinaus verwendet Office viele clientseitige Komponenten (wie Simple MAPI, WinInet, MSDAIPP), die Client‑Authentifizierungsinformationen zwischenspeichern, um die Verarbeitung zu beschleunigen. Wenn Office serverseitig automatisiert wird, kann eine Instanz mehr als einen Client bedienen, und weil Authentifizierungsinformationen für diese Sitzung zwischengespeichert wurden, ist es möglich, dass ein Client die zwischengespeicherten Anmeldeinformationen eines anderen Clients verwendet und dadurch nicht gewährte Zugriffsrechte erlangt, indem er andere Benutzer impersoniert."

Aspose‑Produkte sind sehr **sicher**. Aspose‑Komponenten laufen im selben Benutzerkontext wie alle ASP.NET‑Anwendungen (unter dem Benutzer **ASPNET**). Daher stellen Aspose‑Komponenten **keine** Sicherheitsrisiko dar. Sie verbrauchen zudem keine kritischen Systemressourcen. Außerdem werden beim Öffnen eines Dokuments durch eine Aspose‑Komponente Makros nicht automatisch ausgeführt. Aspose‑Komponenten wurden entwickelt, um Entwicklern das Erstellen, Manipulieren und Speichern von Office‑Dateien zu ermöglichen.

{{% alert color="info" %}} 
Keines der mit dem Microsoft Office‑Paket verbundenen Risiken gilt für Aspose‑Komponenten.
{{% /alert %}} 

## **Stabilität**
Der folgende Text ist ein direktes Zitat aus dem zuvor genannten Microsoft‑Artikel:

> "Office 2000, Office XP und Office 2003 verwenden die Microsoft Windows Installer‑Technologie (MSI), um Installation und Selbstreparatur für den Endbenutzer zu vereinfachen. MSI führt das Konzept „bei erster Nutzung installieren“ ein, wodurch Funktionen zur Laufzeit dynamisch installiert oder konfiguriert werden können (für das System oder häufiger für einen bestimmten Benutzer). In einer serverseitigen Umgebung verlangsamt dies sowohl die Leistung als auch die Wahrscheinlichkeit, dass ein Dialogfeld erscheint, das den Benutzer zur Genehmigung der Installation oder zur Bereitstellung einer geeigneten Installations‑CD auffordert. Obwohl dies die Resilienz von Office als Endbenutzer‑Produkt erhöhen soll, ist die Implementierung der MSI‑Funktionen von Office in einer serverseitigen Umgebung kontraproduktiv. Darüber hinaus kann die Stabilität von Office im Allgemeinen nicht garantiert werden, wenn es serverseitig ausgeführt wird, da es für diese Art der Nutzung nicht entworfen oder getestet wurde. Die Verwendung von Office als Dienstkomponente auf einem Netzwerk‑Server kann die Stabilität dieses Rechners und damit das gesamte Netzwerk beeinträchtigen. Wenn Sie Office serverseitig automatisieren möchten, versuchen Sie, das Programm auf einen dedizierten Computer zu isolieren, der keine kritischen Funktionen beeinflussen kann und bei Bedarf neu gestartet werden kann."

Da Aspose‑Komponenten in einer einzigen DLL verpackt sind, müssen ihre Benutzer nie zusätzliche Teile oder Komponenten installieren, damit sie funktionieren. Aspose‑Komponenten werden nur von .NET‑Anwendungen verwendet und es gibt keinen Teil des Komponenten‑Codes, der auf eine menschliche Reaktion wartet.

{{% alert color="info" %}} 
Aspose‑Komponenten wurden gründlich getestet und als sehr stabil bestätigt. Aspose‑Komponenten werden von [Unternehmen](http://www.aspose.com/Corporate/Aspose/Customerlist.html) wie **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** und vielen anderen führenden Organisationen in verschiedenen Branchen eingesetzt.
{{% /alert %}} 

## **Skalierbarkeit/Geschwindigkeit**
Das Folgende ist ein direktes Zitat aus einem Microsoft‑Artikel:

> "Serverseitige Komponenten müssen hochgradig wiederbetretbar, mehrthreadig und COM‑basiert sein, mit minimalem Overhead und hohem Durchsatz für mehrere Clients. Office‑Anwendungen sind in fast allen Aspekten das genaue Gegenteil. Sie sind nicht‑wiederbetretbare, STA‑basierte Automatisierungs‑Server, die dafür konzipiert sind, vielfältige, aber ressourcenintensive Funktionalität für einen einzelnen Client bereitzustellen. Sie bieten kaum Skalierbarkeit als serverseitige Lösung und haben feste Grenzen für wichtige Elemente wie Speicher, die nicht durch Konfiguration geändert werden können. Noch wichtiger ist, dass sie globale Ressourcen (wie speicher‑gemappte Dateien, globale Add‑Ins oder Vorlagen und gemeinsam genutzte Automatisierungs‑Server) verwenden, was die Anzahl gleichzeitig laufender Instanzen begrenzen und zu Race‑Conditions führen kann, wenn sie in einer Multi‑Client‑Umgebung konfiguriert werden. Entwickler, die planen, mehr als eine Instanz einer Office‑Anwendung gleichzeitig zu betreiben, müssen Pooling oder Serializing Access zur Office‑Anwendung in Betracht ziehen, um potenzielle Deadlocks oder Datenkorruption zu vermeiden."

Aspose‑Komponenten sind unglaublich skalierbar und blitzschnell. Office‑Anwendungen wurden nicht dafür konzipiert, gleichzeitig von Hunderten oder Tausenden von Benutzern genutzt zu werden, Aspose‑Komponenten hingegen genau dafür entwickelt. Unsere Komponenten sind eine echte .NET‑Lösung.

{{% alert color="info" %}} 
Die Leistung von Aspose‑Komponenten ist makellos auf einem einzelnen Server (für eine einzelne Anwendung) oder in einem lastverteilten Web‑Formular (für eine unternehmensweite Anwendung).
{{% /alert %}} 

## **Preis**
Wenn eine Anwendung Microsoft Office Automation verwendet, muss für jede Maschine, auf der die Anwendung läuft, eine Kopie von Microsoft Office erworben werden. Es gibt zahlreiche Szenarien, in denen eine Anwendung Office‑Dateien erstellen oder manipulieren muss, doch dafür ist Microsoft Office nicht erforderlich.

{{% alert color="info" %}} 
Aspose bietet eine sehr [kosteneffiziente](https://purchase.aspose.com/) und lizenzgebührenfreie Weiterverbreitungslizenz, die die Bereitstellung für eine unbegrenzte Anzahl von Benutzern ohne Lizenzsorgen ermöglicht.
{{% /alert %}} 

Bei der Erstellung webbasierter Anwendungen ist zu beachten, dass Microsoft Office Automation‑Komponenten weder preislich noch lizenztechnisch für serverseitige Lösungen ausgelegt sind. Daher gibt es keine geeignete Lizenzierung für die Bereitstellung von Web‑Anwendungen, die Microsoft‑Office‑Komponenten nutzen. Aspose hingegen bietet ebenfalls eine sehr [kosteneffiziente](https://purchase.aspose.com/) Lösung für serverbasierte Anwendungen.

## **Funktionen**
Aspose‑Komponenten bieten alles, was für die Verwaltung von Office‑Dateien erforderlich ist, und noch viel mehr. Sie wurden nach unserer Philosophie entwickelt, Entwicklern zu ermöglichen, mit minimalem Aufwand die bestmöglichen Ergebnisse zu erzielen.

{{% alert color="info" %}} 
Im Gegensatz zu Office Automation bieten Aspose‑Komponenten viele leistungsstarke und zeitsparende Funktionen.
{{% /alert %}} 

Zum Beispiel ermöglicht [Aspose.Cells](https://products.aspose.com/cells/net/) Entwicklern, Daten aus einer **DataTable** oder **DataView** direkt in eine Excel‑Datei zu importieren. [Aspose.Words](https://products.aspose.com/words/net/) bietet eine ähnliche Funktion, mit der Entwickler ein Word‑Dokument (also ein Seriendruckdokument) direkt aus jedem .NET‑Datenobjekt befüllen können. [Jede Komponente](https://products.aspose.com/total/net/) der Aspose‑Familie stellt ihren eigenen Satz einzigartiger und leistungsstarker Features bereit.

Der größte Vorteil beim Kauf einer Aspose‑Komponente ist der Zugriff auf unsere Entwicklungsteams. Wenn Sie beispielsweise Office‑Automation‑Objekte verwenden und bestimmte Funktionen benötigen, ist die Wahrscheinlichkeit, dass diese Funktionen hinzugefügt werden, sehr, sehr gering. Bei Aspose‑Komponenten ist das anders.

{{% alert color="info" %}} 
Unsere Entwicklungsteams verstehen, dass ein Feature, das Ihr Unternehmen benötigt, wahrscheinlich auch von anderen Unternehmen benötigt wird. Zwar können wir nicht jedes gewünschte Feature umsetzen, aber wir bemühen uns, basierend auf dem Feedback unserer Kunden möglichst viele Funktionen hinzuzufügen.
{{% /alert %}} 

Unsere Teams sind stets offen und flexibel bei der Unterstützung – und das ist der Grund, warum Aspose‑Komponenten so leistungsfähig geworden sind.

## **Fazit**
{{% alert color="info" %}} 
Während dieser Artikel einige der wichtigsten Punkte beschrieben hat, warum Aspose‑Komponenten eine bessere Wahl als Office Automation sind, gibt es noch viele, viele weitere Vorteile. Wir haben nur einige der wichtigsten Vorteile aufgeführt.

Zudem bieten alle Aspose‑Produkte und -Komponenten eine risikofreie, unverbindliche [Evaluierungsversion](https://downloads.aspose.com/slides/de/net). Wir empfehlen Ihnen, die Evaluation zu nutzen, um zu sehen, was Aspose für Ihre Anwendungen oder Ihr Unternehmen leisten kann.
{{% /alert %}}