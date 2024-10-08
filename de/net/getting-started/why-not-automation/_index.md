---
title: Warum nicht Automatisierung
type: docs
weight: 40
url: /de/net/why-not-automation/
---

## **Wichtige Fragen**
- Warum sind Aspose-Komponenten eine viel bessere Option als Microsoft Office Automatisierung?

Es gibt zwei Fragen, die wir oft bei Aspose hören:

- Benötigen Ihre Produkte die Installation von Microsoft Office, damit sie ausgeführt werden können?

Die kurze, einfache Antwort—**NEIN**.

Aspose und Aspose-Komponenten sind völlig unabhängig und sind nicht mit Microsoft Corporation verbunden, noch von dieser autorisiert, gesponsert oder in irgendeiner Weise genehmigt.

- Warum sollten wir Aspose-Produkte anstelle von Microsoft Office Automatisierung verwenden?

Einerseits gibt es viele [Vorteile, die Sie genießen, wenn Sie Aspose.Slides verwenden](https://docs.aspose.com/slides/net/product-overview/).

Andererseits rät Microsoft selbst nachdrücklich **von** der Verwendung von Office Automatisierung in Softwarelösungen ab.

## **Übersicht**
Wie bereits erwähnt, gibt es mehrere Gründe, warum Aspose-Komponenten eine bessere Alternative zur Automatisierung sind. Einige der wichtigsten Gründe sind:

- Sicherheit
- Stabilität
- Skalierbarkeit/Geschwindigkeit
- Preis
- Funktionen

Wir haben die Schlüsselpunkte in den folgenden Absätzen erläutert.
## **Sicherheit**
Folgendes ist ein direktes Zitat aus einem Microsoft-Artikel:

> "Office-Anwendungen waren nie für den Einsatz auf Serverseite gedacht und berücksichtigen daher nicht die Sicherheitsprobleme, mit denen verteilte Komponenten konfrontiert sind. Office authentifiziert eingehende Anfragen nicht und schützt Sie nicht davor, versehentlich Makros auszuführen oder einen anderen Server zu starten, der möglicherweise Makros ausführt, aus Ihrem code auf Serverseite. Öffnen Sie keine Dateien, die von einem anonymen Web auf den Server hochgeladen werden! Basierend auf den zuletzt festgelegten Sicherheitseinstellungen kann der Server Makros im Administrator- oder Systemkontext mit vollständigen Berechtigungen ausführen und Ihr Netzwerk gefährden! Darüber hinaus verwendet Office viele clientseitige Komponenten (wie Simple MAPI, WinInet, MSDAIPP), die client-authentifizierungsinformationen zwischenspeichern, um die Verarbeitung zu beschleunigen. Wenn Office serverseitig automatisiert wird, kann eine Instanz mehr als einen Client bedienen, und da die Authentifizierungsinformationen für diese Sitzung zwischengespeichert wurden, ist es möglich, dass ein Client die zwischengespeicherten Anmeldedaten eines anderen Clients verwenden kann und dadurch nicht genehmigten Zugriff auf andere Benutzer erhält."

Aspose-Produkte sind sehr **sicher**. Aspose-Komponenten arbeiten im gleichen Benutzerkontext wie alle ASP.NET-Anwendungen (unter dem ASPNET-Benutzer). Daher stellen Aspose-Komponenten **kein** Sicherheitsrisiko dar. Sie verbrauchen auch keine kritischen Systemressourcen. Darüber hinaus werden Makros nicht automatisch ausgeführt, wenn eine Aspose-Komponente ein Dokument öffnet. Aspose-Komponenten wurden entwickelt, um Entwicklern zu ermöglichen, Office-Dateien zu erstellen, zu manipulieren und zu speichern.

{{% alert color="primary" %}} 

Keiner der mit dem Microsoft Office-Paket verbundenen Risiken gilt für Aspose-Komponenten.

{{% /alert %}} 

## **Stabilität**
Dieser Text ist ein direktes Zitat aus dem zuvor zitierten Microsoft-Artikel:

> "Office 2000, Office XP und Office 2003 verwenden die Microsoft Windows Installer (MSI)-Technologie, um die Installation und Selbstreparatur für einen Endbenutzer zu erleichtern. MSI führt das Konzept "Installieren bei erster Verwendung" ein, das es ermöglicht, Funktionen dynamisch zur Laufzeit (für das System oder häufiger für einen bestimmten Benutzer) zu installieren oder zu konfigurieren. In einer serverseitigen Umgebung verlangsamt dies sowohl die Leistung als auch erhöht die Wahrscheinlichkeit, dass ein Dialogfeld erscheint, das den Benutzer auffordert, die Installation zu genehmigen oder eine geeignete Installationsdiskette bereitzustellen. Obwohl dies darauf ausgelegt ist, die Widerstandsfähigkeit von Office als Endbenutzerprodukt zu erhöhen, ist die Implementierung von MSI-Funktionen in Office kontraproduktiv in einer serverseitigen Umgebung. Darüber hinaus kann die Stabilität von Office im Allgemeinen nicht gewährleistet werden, wenn es serverseitig ausgeführt wird, da es nicht für diesen Typ von Verwendung konzipiert oder getestet wurde. Die Verwendung von Office als Servicemodul auf einem Netzwerkserver kann die Stabilität dieser Maschine und damit Ihr Netzwerk als Ganzes verringern. Wenn Sie planen, Office serverseitig zu automatisieren, versuchen Sie, das Programm auf einem dedizierten Computer zu isolieren, der kritische Funktionen nicht beeinträchtigen kann und nach Bedarf neu gestartet werden kann."

Da Aspose-Komponenten in einer einzigen DLL verpackt sind, müssen ihre Benutzer niemals zusätzliche Teile oder Komponenten installieren, damit sie funktionieren. Aspose-Komponenten werden nur von .NET-Anwendungen genutzt, und für den Komponenten-Code ist kein Teil vorgesehen, der auf eine menschliche Antwort wartet.

{{% alert color="primary" %}} 

Aspose-Komponenten wurden gründlich getestet und als sehr stabil bestätigt. Aspose-Komponenten werden von [Unternehmen](http://www.aspose.com/Corporate/Aspose/Customerlist.html) wie **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** und vielen anderen führenden Organisationen in verschiedenen Branchen und Bereichen eingesetzt.

{{% /alert %}} 

## **Skalierbarkeit/Geschwindigkeit**
Folgendes ist ein direktes Zitat aus einem Microsoft-Artikel:

> "Serverseitige Komponenten müssen hoch reentrant, multithreaded COM-Komponenten mit minimalem Overhead und hoher Durchsatzrate für mehrere Clients sein. Office-Anwendungen sind in fast jeder Hinsicht das genaue Gegenteil. Sie sind nicht-reentrant, STA-basierte Automatisierungsserver, die entwickelt wurden, um vielfältige, aber ressourcenintensive Funktionalitäten für einen einzelnen Client bereitzustellen. Sie bieten wenig Skalierbarkeit als serverseitige Lösung und haben feste Grenzen für wichtige Elemente, wie z.B. Speicher, die nicht durch Konfiguration geändert werden können. Noch wichtiger ist, dass sie globale Ressourcen (wie speichergemappte Dateien, globale Add-Ins oder Vorlagen und gemeinsame Automatisierungsserver) verwenden, was die Anzahl der Instanzen, die gleichzeitig ausgeführt werden können, beschränken kann und zu Race Conditions führen kann, wenn sie in einer Multi-Client-Umgebung konfiguriert sind. Entwickler, die planen, mehr als eine Instanz einer Office-Anwendung gleichzeitig auszuführen, müssen das Pooling oder die serielle Zugriffsverwaltung auf die Office-Anwendung in Betracht ziehen, um potenzielle Deadlocks oder Datenkorruption zu vermeiden."

Aspose-Komponenten sind unglaublich skalierbar und blitzschnell. Office-Anwendungen wurden nicht dafür konzipiert, gleichzeitig von Hunderten oder Tausenden von Benutzern genutzt zu werden, aber Aspose-Komponenten sind genau dafür ausgelegt. Unsere Komponenten sind eine wahre .NET-Lösung.

{{% alert color="primary" %}} 

Die Leistung der Aspose-Komponenten ist fehlerfrei auf einem einzelnen Server (der eine einzelne Anwendung antreibt) oder auf einem Lastenausgleich-Webformular (das eine unternehmensweite Anwendung antreibt).

{{% /alert %}} 

## **Preis**
Wenn eine Anwendung Microsoft Office Automatisierung verwendet, muss für jeden Computer, der die App ausführt, eine Kopie von Microsoft Office gekauft werden. Es gibt viele Situationen, in denen eine Anwendung eine Office-Datei erstellen oder manipulieren muss, der Prozess jedoch Microsoft Office nicht erfordert.

{{% alert color="primary" %}} 

Aspose bietet eine sehr [kostengünstige](https://purchase.aspose.com/) und lizenzfreie Weiterverbreitungslizenz, die bereitgestellt werden kann an eine unbegrenzte Anzahl von Benutzern ohne Lizenzierungsbedenken.

{{% /alert %}} 

Bei der Erstellung webbasierter Anwendungen ist es wichtig zu beachten, dass Microsoft Office Automatisierungs Komponenten weder für serverseitige Lösungen preislich noch lizenziert sind. Daher gibt es keine gute Lizenzierungslösung für die Bereitstellung von Webanwendungen, die Microsoft Office-Komponenten nutzen. Aspose hingegen bietet auch eine sehr [kostengünstige](https://purchase.aspose.com/) Lösung für serverbasierte Anwendungen an.

## **Funktionen**
Aspose-Komponenten bieten alles, was für die Verwaltung von Office-Dateien benötigt wird, und noch viel mehr. Wir haben sie auf der Grundlage unserer Philosophie entwickelt, den Entwicklern zu helfen, die besten Ergebnisse mit dem geringsten Aufwand zu erzielen.

{{% alert color="primary" %}} 

Im Gegensatz zur Office-Automatisierung bieten Aspose-Komponenten viele leistungsstarke und zeitsparende Funktionen.

{{% /alert %}} 

Zum Beispiel ermöglicht [Aspose.Cells](https://products.aspose.com/cells/net/) Entwicklern, Daten direkt aus einer **DataTable** oder **DataView** in eine Excel-Datei zu importieren. [Aspose.Words](https://products.aspose.com/words/net/) bietet eine ähnliche Funktion, die es Entwicklern ermöglicht, ein Word-Dokument (d.h. einen Serienbrief) direkt aus einem beliebigen .NET-Datenobjekt zu befüllen. [Jede Komponente](https://products.aspose.com/total/net/) der Aspose-Familie bietet ihren eigenen Satz einzigartiger und leistungsstarker Funktionen.

Der beste Teil beim Kauf einer Aspose-Komponente ist der Zugang zu unseren Entwicklungsteams. Wenn Sie beispielsweise Office-Automatisierungsobjekte verwenden und bestimmte Funktionen benötigen, ist die Wahrscheinlichkeit, dass diese Funktionen hinzugefügt werden, sehr, sehr gering. Bei Aspose-Komponenten sieht das jedoch anders aus.

{{% alert color="primary" %}} 

Unsere Entwicklungsteams verstehen, dass, wenn es eine Funktion gibt, die Ihr Unternehmen benötigt, eine gute Chance besteht, dass andere Firmen dieselbe Funktion benötigen. Obwohl wir wissen, dass wir nicht jede angeforderte Funktion implementieren können, bemühen wir uns, so viele Funktionen wie möglich auf der Grundlage des Feedbacks unserer Kunden hinzuzufügen.

{{% /alert %}} 

Unsere Teams sind immer offen und flexibel, wenn es um Unterstützung geht – und das ist der Grund, warum Aspose-Komponenten so leistungsstark geworden sind, wie sie jetzt sind.

## **Fazit**
{{% alert color="primary" %}} 

Während dieser Artikel einige der wichtigsten Punkte behandelt hat, warum Aspose-Komponenten eine bessere Wahl als Office Automatisierung sind, müssen Sie verstehen, dass es viele, viele weitere Vorteile gibt. Wir haben nur einige der wichtigsten Vorteile durchgearbeitet.

Darüber hinaus bieten alle Aspose-Produkte und -Komponenten eine risikofreie, unverbindliche [Evaluierungsversion](https://downloads.aspose.com/slides/net). Wir ermutigen Sie, die Evaluierung zu nutzen, um zu sehen, was Aspose für Ihre Anwendungen oder Ihr Unternehmen tun kann.

{{% /alert %}} 