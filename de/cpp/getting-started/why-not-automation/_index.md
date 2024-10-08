---
title: Warum keine Automatisierung
type: docs
weight: 50
url: /de/cpp/why-not-automation/
---

## **Wichtige Fragen**
- Warum sind Aspose-Komponenten eine viel bessere Option als Microsoft Office Automation?

Es gibt zwei Fragen, die wir hier bei Aspose am häufigsten hören:

- Erfordern Ihre Produkte, dass Microsoft Office installiert ist, damit sie funktionieren?

Die kurze, einfache Antwort ist **NEIN**. Aspose und Aspose-Komponenten sind vollkommen unabhängig und stehen in keiner Verbindung zu Microsoft Corporation, noch sind sie autorisiert, gesponsert oder anders genehmigt von Microsoft Corporation.

- Warum sollten wir Aspose-Produkte verwenden, anstatt Microsoft Office Automation zu nutzen?

Die kürzeste Antwort, die wir geben können, ist, dass es viele Gründe gibt, wobei der wichtigste ist, dass *Microsoft selbst ausdrücklich von Office Automation in Softwarelösungen abrät: [Microsoft Artikel](https://www.microsoft.com).*

## **Übersicht**
Wie oben stated, gibt es mehrere Gründe, warum Aspose-Komponenten eine bessere Alternative zur Automatisierung sind. Einige der wichtigsten Gründe sind:

- Sicherheit
- Stabilität
- Skalierbarkeit/Geschwindigkeit
- Preis
- Funktionen

Im Folgenden finden Sie eine bessere Erläuterung zu jedem der wichtigsten Punkte. Besuchen Sie auch den **Zusätzliche Informationen**-Bereich, der Links zu unabhängigen Benutzerevaluierungen bietet.

## **Sicherheit**
Folgendes ist ein direktes Zitat aus dem oben genannten Microsoft Artikel:  
*"Office-Anwendungen waren nie für den Server-Einsatz gedacht und berücksichtigen daher nicht die Sicherheitsprobleme, mit denen verteilte Komponenten konfrontiert sind. Office authentifiziert keine eingehenden Anfragen und schützt Sie nicht vor unbeabsichtigtem Ausführen von Makros oder dem Starten eines anderen Servers, der möglicherweise Makros ausführt, von Ihrem serverseitigen Code. Öffnen Sie keine Dateien, die von einem anonymen Web auf den Server hochgeladen werden! Basierend auf den zuletzt festgelegten Sicherheitseinstellungen kann der Server Makros mit Administrator- oder Systemkontext mit vollen Rechten ausführen und Ihr Netzwerk gefährden! Darüber hinaus verwendet Office viele clientseitige Komponenten (wie Simple MAPI, WinInet, MSDAIPP), die Informationen zur Clientauthentifizierung zwischenspeichern, um die Verarbeitung zu beschleunigen. Wenn Office serverseitig automatisiert wird, kann eine Instanz mehr als einen Client bedienen, und da die Authentifizierungsinformationen für diese Sitzung zwischengespeichert wurden, ist es möglich, dass ein Client die zwischengespeicherten Anmeldeinformationen eines anderen Clients verwendet und dadurch unberechtigten Zugriff durch Imitation anderer Benutzer erhält."*

Aspose-Produkte sind sehr sicher. Daher stellen Aspose-Komponenten kein potenzielles Risiko für wichtige Systemressourcen dar. Darüber hinaus werden bei der Öffnung eines Dokuments durch eine Aspose-Komponente keine Makros automatisch ausgeführt. Aspose-Komponenten wurden mit dem Ziel entwickelt, Entwicklern zu ermöglichen, Office-Dateien zu erstellen, zu bearbeiten und zu speichern. Keines der Risiken, die mit dem Microsoft Office-Paket verbunden sind, sind inherent in Aspose-Komponenten.

## **Stabilität**
Folgendes ist ein direktes Zitat aus dem oben genannten Microsoft Artikel:  
*"Office 2000, Office XP und Office 2003 verwenden die Microsoft Windows Installer (MSI)-Technologie, um die Installation und Selbstreparatur für Endbenutzer zu erleichtern. MSI führt das Konzept „Installieren bei erster Verwendung“ ein, das es ermöglicht, Funktionen zur Laufzeit dynamisch zu installieren oder zu konfigurieren (für das System oder häufiger für einen bestimmten Benutzer). In einer serverseitigen Umgebung verlangsamt dies sowohl die Leistung als auch erhöht die Wahrscheinlichkeit, dass ein Dialogfeld erscheint, das den Benutzer auffordert, die Installation zu genehmigen oder eine geeignete Installationsdiskette bereitzustellen. Obwohl es darauf ausgelegt ist, die Resilienz von Office als Endbenutzerprodukt zu erhöhen, ist die Implementierung der MSI-Funktionen in Office kontraproduktiv in einer serverseitigen Umgebung. Darüber hinaus kann die Stabilität von Office im Allgemeinen nicht gewährleistet werden, wenn es serverseitig ausgeführt wird, da es nicht für diese Art der Verwendung entworfen oder getestet wurde. Wenn Sie planen, Office serverseitig zu automatisieren, versuchen Sie, das Programm auf einem dedizierten Computer zu isolieren, der kritische Funktionen nicht beeinflussen kann und bei Bedarf neu gestartet werden kann."*

Da Aspose-Komponenten in einer einzigen DLL verpackt sind, wird es nie notwendig sein, zusätzliche Teile oder Stücke zu installieren, damit sie funktionieren. Aspose-Komponenten werden nur von C++-Anwendungen verwendet, und es gibt keinen Teil des Komponenten-Codes, der darauf ausgelegt ist, auf eine menschliche Antwort zu warten. Aspose-Komponenten wurden umfangreich getestet und sind äußerst stabil. Aspose-Komponenten werden von **[Unternehmen](https://about.aspose.com/customers)** wie **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** und vielen weiteren verwendet.

## **Skalierbarkeit/Geschwindigkeit**
Folgendes ist ein direktes Zitat aus dem oben genannten Microsoft Artikel:  
*"Serverseitige Komponenten müssen hoch reentrante, multithreaded COM-Komponenten mit minimalem Overhead und hoher Durchsatzrate für mehrere Clients sein. Office-Anwendungen sind in fast allen Aspekten das genaue Gegenteil. Sie sind nicht reentrant, STA-basierte Automatisierungsserver, die darauf ausgelegt sind, vielfältige, aber ressourcenintensive Funktionalität für einen einzelnen Client bereitzustellen. Sie bieten wenig Skalierbarkeit als serverseitige Lösung und haben feste Grenzen für wichtige Elemente wie Speicher, die nicht durch Konfiguration geändert werden können. Noch wichtiger ist, dass sie globale Ressourcen (wie speicherabgebildete Dateien, globale Add-Ins oder Vorlagen und gemeinsame Automatisierungsserver) verwenden, die die Anzahl der Instanzen, die gleichzeitig ausgeführt werden können, limitieren können und zu Wettlaufbedingungen führen können, wenn sie in einer Multi-Client-Umgebung konfiguriert sind. Entwickler, die planen, mehr als eine Instanz einer Office-Anwendung gleichzeitig auszuführen, müssen Pooling oder die serielle Zugriffssteuerung zur Vermeidung potenzieller Deadlocks oder Datenbeschädigungen berücksichtigen."*

Aspose-Komponenten sind hoch skalierbar und blitzschnell. Office-Anwendungen wurden nicht für die gleichzeitige Nutzung durch Hunderte und Tausende von Benutzern entwickelt. Aspose-Komponenten hingegen sind genau dafür ausgelegt. Unsere Komponenten sind eine wahre C++-Lösung und funktionieren einwandfrei, egal ob auf einem einzelnen Server, der eine einzelne Anwendung antreibt oder auf einem Lastenausgleichs-Webformular, das eine unternehmensweite Anwendung unterstützt.

## **Preis**
Wenn eine Anwendung Microsoft Office Automation nutzt, muss für jeden Computer, der die Anwendung ausführt, eine Kopie von Microsoft Office erworben werden. Es gibt viele Fälle, in denen eine Anwendung eine Office-Datei erstellen oder bearbeiten muss, der Benutzer jedoch Microsoft Office nicht benötigt. Aspose bietet eine sehr **[kosteneffektive](https://purchase.aspose.com/)** und lizenzfreie Wiederverteilungslizenz an, die die Bereitstellung an eine unbegrenzte Anzahl von Benutzern ohne Lizenzsorgen ermöglicht. Bei der Erstellung webbasierter Anwendungen ist es wichtig zu wissen, dass Microsoft Office Automation-Komponenten nicht für serverseitige Lösungen preislich oder lizenziert sind; daher gibt es keine gute Lizenzlösung für die Bereitstellung von Webanwendungen, die die Microsoft Office-Komponenten nutzen. Aspose bietet ebenfalls eine sehr **[kosteneffektive](https://purchase.aspose.com/)** Lösung für serverbasierte Anwendungen an.

## **Funktionen**
Aspose-Komponenten bieten alles, was zum Verwalten von Office-Dateien erforderlich ist, plus noch viel mehr. Sie sind mit der Philosophie entwickelt, Entwicklern zu ermöglichen, die besten Ergebnisse mit dem geringsten Aufwand zu erzielen. Im Gegensatz zur Office-Automatisierung bieten Aspose-Komponenten viele leistungsstarke und zeitsparende Funktionen. Beispielsweise bietet **[Aspose.Cells](https://products.aspose.com/cells/cpp/)** Entwicklern die Möglichkeit, Daten aus einer **DataTable** oder **DataView** direkt in eine Excel-Datei zu importieren. **[Aspose.Words](https://products.aspose.com/words/net/)** bietet eine ähnliche Funktion, die es Entwicklern ermöglicht, ein Word-Dokument (das ist Mail Merge) direkt aus einem beliebigen C++-Datenobjekt zu befüllen. **[Jede Komponente](https://products.aspose.com/total/cpp/)** in der Aspose-Familie bietet ihre eigenen einzigartigen und leistungsstarken Funktionen. Der beste Teil des Kaufs einer Aspose-Komponente ist der Zugang zu unseren Entwicklungsteams. Unsere Entwicklungsteams erkennen, dass, wenn Ihre Firma eine Funktion benötigt, wahrscheinlich auch andere Firmen dies benötigen. Während nicht jede Funktionsanforderung hinzugefügt werden kann, versuchen unsere Teams, sehr aufgeschlossen und flexibel bei der Bereitstellung von Unterstützung zu sein. Diese Denkweise hat dazu beigetragen, dass Aspose-Komponenten so leistungsstark geworden sind, wie sie sind. Wenn es zusätzliche Funktionen gibt, die Sie von Office-Automatisierungsobjekten benötigen, sind Ihre Chancen, dass sie hinzugefügt werden, sehr, sehr gering.

## **Fazit**
{{% alert color="primary" %}} 

Obwohl dieser Artikel viele der Schlüsselpunkte behandelt hat, warum Aspose-Komponenten eine bessere Wahl als Office Automation sind, gibt es noch viele, viele mehr. Dieser Artikel befasst sich hauptsächlich nur mit den wichtigsten Punkten. Alle verschiedenen Aspose-Komponenten bieten eine risikofreie, unverbindliche **[Bewertungsversion](https://downloads.aspose.com/slides/cpp)** an. Wir ermutigen Sie, diese **[Bewertung](https://downloads.aspose.com/slides/cpp)** zu nutzen, um besser zu sehen, was Aspose für Ihre Anwendungen tun kann.