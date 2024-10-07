---
title: Warum keine Automatisierung
type: docs
weight: 50
url: /cpp/why-not-automation/
---

## **Wichtige Fragen**
- Warum sind Aspose-Komponenten eine viel bessere Option als Microsoft Office Automation?

Es gibt zwei Fragen, die wir hier bei Aspose am häufigsten hören:

- Benötigen Ihre Produkte, dass Microsoft Office installiert ist, damit sie funktionieren?

Die kurze und einfache Antwort ist **NEIN**. Aspose und Aspose-Komponenten sind vollkommen unabhängig und stehen in keiner Verbindung zu Microsoft Corporation, noch sind sie autorisiert, gesponsert oder anderweitig genehmigt.

- Warum sollten wir Aspose-Produkte anstelle von Microsoft Office Automation verwenden?

Die kürzeste Antwort, die wir geben können, ist, dass es viele Gründe gibt, wobei der wichtigste ist, dass *Microsoft selbst dringend von Office Automation aus Softwarelösungen abrät: [Microsoft-Artikel
## **Überblick**
Wie oben erwähnt, gibt es mehrere Gründe, warum Aspose-Komponenten eine bessere Alternative zur Automatisierung sind. Einige der wichtigsten Gründe sind:

- Sicherheit
- Stabilität
- Skalierbarkeit/Geschwindigkeit
- Preis
- Funktionen

Im Folgenden finden Sie eine genauere Erklärung zu jedem der wichtigsten Punkte. Vergessen Sie auch nicht, den **Zusätzliche Informationen**-Bereich zu besuchen, der einen Link zu unabhängigen Benutzerevaluierungen bietet.
## **Sicherheit**
Folgendes ist ein direktes Zitat aus dem oben genannten Microsoft-Artikel:
*"Office-Anwendungen waren nie für den Einsatz auf Serverseite gedacht und berücksichtigen daher nicht die Sicherheitsprobleme, mit denen verteilte Komponenten konfrontiert sind. Office authentifiziert eingehende Anfragen nicht und schützt Sie nicht davor, unbeabsichtigt Makros auszuführen oder einen anderen Server zu starten, der möglicherweise Makros ausführt, von Ihrem Server-seitigen Code. Öffnen Sie keine Dateien, die von einem anonymen Web auf den Server hochgeladen werden! Basierend auf den zuletzt festgelegten Sicherheitseinstellungen kann der Server Makros im Administrator- oder Systemkontext mit vollem Zugriff ausführen und Ihr Netzwerk gefährden! Darüber hinaus verwendet Office viele Client-seitige Komponenten (wie Simple MAPI, WinInet, MSDAIPP), die Client-Authentifizierungsinformationen zwischenspeichern, um die Verarbeitung zu beschleunigen. Wenn Office serverseitig automatisiert wird, kann eine Instanz mehr als einen Client bedienen und da die Authentifizierungsinformationen für diese Sitzung zwischengespeichert wurden, ist es möglich, dass ein Client die zwischengespeicherten Anmeldeinformationen eines anderen Clients verwenden kann und somit unberechtigten Zugriff erhält, indem er sich als andere Benutzer ausgibt."*

Aspose-Produkte sind sehr sicher. Daher stellen Aspose-Komponenten kein potenzielles Risiko für wichtige Systemressourcen dar. Darüber hinaus werden beim Öffnen eines Dokuments durch eine Aspose-Komponente Makros nicht automatisch ausgeführt. Aspose-Komponenten wurden mit dem Ziel entwickelt, Entwicklern zu ermöglichen, Office-Dateien zu erstellen, zu manipulieren und zu speichern. Keines der Risiken, die mit dem Microsoft Office-Paket verbunden sind, sind inhärent in Aspose-Komponenten.
## **Stabilität**
Folgendes ist ein direktes Zitat aus dem oben genannten Microsoft-Artikel:
*"Office 2000, Office XP und Office 2003 verwenden die Microsoft Windows Installer (MSI)-Technologie, um die Installation und Selbstreparatur für einen Endbenutzer zu erleichtern. MSI führt das Konzept des „Erstmaligen Installierens bei Verwendung“ ein, das es ermöglicht, Funktionen zur Laufzeit dynamisch zu installieren oder zu konfigurieren (für das System oder häufiger für einen bestimmten Benutzer). In einer serverseitigen Umgebung verlangsamt dies sowohl die Leistung als auch erhöht die Wahrscheinlichkeit, dass ein Dialogfeld erscheint, das den Benutzer um die Genehmigung der Installation oder um die Bereitstellung eines entsprechenden Installationsdatenträgers bittet. Obwohl es dafür gedacht ist, die Resilienz von Office als Endbenutzerprodukt zu erhöhen, ist die Implementierung von MSI-Funktionen in Office in einer serverseitigen Umgebung kontraproduktiv. Darüber hinaus kann die Stabilität von Office im Allgemeinen nicht gewährleistet werden, wenn es serverseitig ausgeführt wird, da es nicht für diese Art der Nutzung entwickelt oder getestet wurde. Wenn Sie vorhaben, Office serverseitig zu automatisieren, versuchen Sie, das Programm auf einem dedizierten Computer zu isolieren, der kritische Funktionen nicht beeinträchtigen kann und bei Bedarf neu gestartet werden kann."*

Da Aspose-Komponenten in einer einzigen DLL gebündelt sind, wird es niemals notwendig sein, zusätzliche Teile oder Komponenten zu installieren, damit sie funktionieren. Aspose-Komponenten werden ausschließlich von C++-Anwendungen verwendet und es gibt keinen Teil des Komponentencodes, der dafür ausgelegt ist, auf eine menschliche Antwort zu warten. Aspose-Komponenten wurden ausgiebig getestet und sind äußerst stabil. Aspose-Komponenten werden von [Unternehmen](https://about.aspose.com/customers) verwendet wie: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** und vielen weiteren.
## **Skalierbarkeit/Geschwindigkeit**
Folgendes ist ein direktes Zitat aus dem oben genannten Microsoft-Artikel:


*"Serverseitige Komponenten müssen hochreaktiv, multithreaded COM-Komponenten mit minimalem Overhead und hoher Durchsatz für mehrere Clients sein. Office-Anwendungen sind in fast jeder Hinsicht das genaue Gegenteil. Sie sind nicht reentrant, STA-basierte Automatisierungsserver, die entwickelt wurden, um vielfältige, aber ressourcenintensive Funktionen für einen einzelnen Kunden bereitzustellen. Sie bieten wenig Skalierbarkeit als serverseitige Lösung und haben feste Grenzen für wichtige Elemente, wie z.B. Speicher, die nicht über die Konfiguration geändert werden können. Noch wichtiger ist, dass sie globale Ressourcen (wie speicherabgebildete Dateien, globale Add-Ins oder Vorlagen und gemeinsame Automatisierungsserver) verwenden, die die Anzahl der Instanzen, die gleichzeitig ausgeführt werden können, begrenzen können und zu Rennbedingungen führen, wenn sie in einer Multi-Client-Umgebung konfiguriert sind. Entwickler, die planen, mehr als eine Instanz einer Office-Anwendung gleichzeitig auszuführen, sollten Pooling oder die seriellen Zugriff on der Office-Anwendung in Betracht ziehen, um potenzielle Deadlocks oder Datenkorruption zu vermeiden.”*

Aspose-Komponenten sind hoch skalierbar und blitzschnell. Office-Anwendungen wurden nicht so konzipiert, dass Hunderte oder Tausende von Benutzern sie gleichzeitig nutzen. Aspose-Komponenten hingegen sind genau dafür konzipiert. Unsere Komponenten sind eine echte C++-Lösung und funktionieren einwandfrei, unabhängig davon, ob sie auf einem einzelnen Server, der eine einzige Anwendung betreibt, oder auf einem lastbalancierten Web-Formular, das eine unternehmensweite Anwendung unterstützt.
## **Preis**
Wenn eine Anwendung Microsoft Office Automation verwendet, muss eine Kopie von Microsoft Office für jede Maschine erworben werden, die die Anwendung ausführt. Es gibt viele Fälle, in denen eine Anwendung eine Office-Datei erstellen oder manipulieren muss, aber der Benutzer nicht Microsoft Office benötigt. Aspose bietet eine sehr [kosteneffiziente](https://purchase.aspose.com/) und lizenzfreie Weiterverbreitungs-Lizenz an, die eine Bereitstellung für eine unbegrenzte Anzahl von Benutzern ohne Lizenzierungsprobleme ermöglicht. Bei der Erstellung von webbasierenden Anwendungen ist es wichtig zu wissen, dass Microsoft Office Automation-Komponenten nicht für serverseitige Lösungen preislich oder lizenziell angeboten werden; daher gibt es keine gute Lizenzierungslösung zur Bereitstellung von Webanwendungen, die die Microsoft Office-Komponenten nutzen. Aspose bietet auch eine sehr [kosteneffiziente](https://purchase.aspose.com/) Lösung für serverbasierte Anwendungen an.
## **Funktionen**
Aspose-Komponenten bieten alles, was zur Verwaltung von Office-Dateien erforderlich ist, plus vieles mehr. Sie sind mit der Philosophie konzipiert, Entwicklern zu ermöglichen, die besten Ergebnisse mit dem geringsten Aufwand zu erzielen. Im Gegensatz zu Office Automation bieten Aspose-Komponenten viele leistungsstarke und zeitsparende Funktionen. Zum Beispiel bietet [Aspose.Cells](https://products.aspose.com/cells/cpp/) Entwicklern die Möglichkeit, Daten aus einer **DataTable** oder **DataView** direkt in eine Excel-Datei zu importieren. [Aspose.Words](https://products.aspose.com/words/net/) bietet eine ähnliche Funktion, die es Entwicklern erlaubt, ein Word-Dokument (das ein Serienbrief-Dokument ist) direkt aus jedem C++-Datenobjekt zu befüllen. [Jede Komponente](https://products.aspose.com/total/cpp/) der Aspose-Familie bietet ihre eigenen einzigartigen und leistungsstarken Funktionen. Der beste Teil beim Kauf einer Aspose-Komponente ist der Zugang zu unseren Entwicklungsteams. Unsere Entwicklungsteams sind sich bewusst, dass, wenn es eine Funktion gibt, die Ihr Unternehmen benötigt, sehr wahrscheinlich auch andere Unternehmen sie benötigen werden. Obwohl nicht jede Funktionsanfrage hinzugefügt werden kann, versuchen unsere Teams, sehr offen und flexibel bei der Bereitstellung von Unterstützung zu sein. Diese Denkweise ist es, was dazu beigetragen hat, dass Aspose-Komponenten so leistungsfähig geworden sind. Wenn es zusätzliche Funktionen gibt, die Sie von Office-Automatisierungsobjekten benötigen, sind Ihre Chancen, dass sie hinzugefügt werden, sehr, sehr gering.
## **Fazit**
{{% alert color="primary" %}} 

Während dieser Artikel viele der wichtigsten Punkte behandelt hat, warum Aspose-Komponenten eine bessere Wahl als Office Automation sind, gibt es noch viele, viele mehr. Dieser Artikel behandelt hauptsächlich nur die wichtigsten Punkte. Alle verschiedenen Aspose-Komponenten bieten eine risikofreie, unverbindliche [Evaluierungsversion](https://downloads.aspose.com/slides/cpp) an. Wir ermutigen Sie, diese [Evaluierung](https://downloads.aspose.com/slides/cpp) zu nutzen, um besser zu sehen, was Aspose für Ihre Anwendungen tun kann.