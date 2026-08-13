---
title: Warum nicht automatisieren
type: docs
weight: 50
url: /de/cpp/why-not-automation/
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
- C++
- Aspose.Slides
description: "Entdecken Sie, warum Office Automation für Server und Dienste riskant ist, und sehen Sie, wie Aspose.Slides sicherere und schnellere Präsentationsverarbeitung für PowerPoint und OpenDocument bietet."
---
## **Einführung**

Es gibt mehrere Gründe, warum Aspose‑Komponenten eine bessere Alternative zur Automatisierung darstellen. Zu den wichtigsten zählen:

- Sicherheit
- Stabilität
- Skalierbarkeit/Geschwindigkeit
- Preis
- Funktionen

Im Folgenden finden Sie eine detailliertere Erläuterung jedes einzelnen Punktes.

## **Wichtige Fragen**
- Warum sind Aspose‑Komponenten eine deutlich bessere Option als Microsoft Office Automation?

Es gibt zwei Fragen, die wir bei Aspose am häufigsten hören:

- Müssen Ihre Produkte Microsoft Office installiert haben, damit sie ausgeführt werden können?

Die kurze, einfache Antwort lautet **NEIN**. Aspose‑ und Aspose‑Komponenten sind völlig unabhängig und stehen in keiner Verbindung zu Microsoft Corporation, noch sind sie von Microsoft autorisiert, gesponsert oder anderweitig genehmigt.

- Warum sollten wir Aspose‑Produkte verwenden, anstatt Microsoft Office Automation zu nutzen?

Die kürzeste Antwort ist, dass es viele Gründe gibt, wobei der wichtigste ist, dass *Microsoft selbst dringend davon abrät, Office‑Automation aus Softwarelösungen zu verwenden: [Microsoft‑Artikel](https://example.com)*

## **Sicherheit**
Im Folgenden ein Zitat aus dem oben genannten Microsoft‑Artikel:  
*"Office‑Anwendungen waren niemals für den serverseitigen Einsatz gedacht und berücksichtigen daher nicht die Sicherheitsprobleme, denen verteilte Komponenten ausgesetzt sind. Office authentifiziert eingehende Anfragen nicht und schützt Sie nicht davor, versehentlich Makros auszuführen oder einen anderen Server zu starten, der Makros ausführen könnte, aus Ihrem serverseitigen Code heraus. Öffnen Sie keine Dateien, die anonym auf den Server hochgeladen wurden! Je nach zuletzt gesetzten Sicherheitseinstellungen kann der Server Makros unter einem Administrator‑ oder Systemkontext mit vollen Rechten ausführen und Ihr Netzwerk kompromittieren! Darüber hinaus verwendet Office viele clientseitige Komponenten (wie Simple MAPI, WinInet, MSDAIPP), die Authentifizierungsinformationen zwischenspeichern, um die Verarbeitung zu beschleunigen. Wird Office serverseitig automatisiert, kann eine Instanz mehr als einen Client bedienen, und weil die Authentifizierungsinformationen für diese Sitzung zwischengespeichert wurden, ist es möglich, dass ein Client die zwischengespeicherten Anmeldeinformationen eines anderen Clients verwendet und dadurch nicht gewährte Zugriffsrechte erlangt, indem er andere Benutzer impersoniert."*

Aspose‑Produkte sind sehr sicher. Daher stellen Aspose‑Komponenten kein potenzielles Risiko für wichtige Systemressourcen dar. Außerdem werden beim Öffnen eines Dokuments durch eine Aspose‑Komponente Makros nicht automatisch ausgeführt. Aspose‑Komponenten wurden entwickelt, um Entwicklern das Erstellen, Manipulieren und Speichern von Office‑Dateien zu ermöglichen. Keine der Risiken, die mit dem Microsoft‑Office‑Paket verbunden sind, sind in Aspose‑Komponenten inhärent.

## **Stabilität**
Im Folgenden ein Zitat aus dem oben genannten Microsoft‑Artikel:  
*"Office 2000, Office XP und Office 2003 verwenden die Microsoft Windows Installer (MSI)‑Technologie, um Installation und Selbstreparatur für Endbenutzer zu vereinfachen. MSI führt das Konzept „install on first use“ ein, bei dem Features zur Laufzeit (für das System oder häufiger für einen bestimmten Benutzer) dynamisch installiert oder konfiguriert werden können. In einer serverseitigen Umgebung verlangsamt dies sowohl die Leistung als auch die Wahrscheinlichkeit, dass ein Dialogfeld erscheint, das den Benutzer zur Genehmigung der Installation oder zur Angabe eines Installations‑Disks auffordert. Obwohl MSI die Resilienz von Office für Endbenutzer erhöhen soll, ist die Implementation von MSI‑Funktionen in einer serverseitigen Umgebung kontraproduktiv. Darüber hinaus kann die Stabilität von Office im Allgemeinen nicht garantiert werden, wenn es serverseitig ausgeführt wird, da es nicht für diesen Zweck entwickelt oder getestet wurde. Die Verwendung von Office als Service‑Komponente auf einem Netzwerk‑Server kann die Stabilität dieses Rechners und damit Ihres gesamten Netzwerks mindern. Wenn Sie Office serverseitig automatisieren wollen, versuchen Sie, das Programm auf einen dedizierten Rechner zu isolieren, der keine kritischen Funktionen beeinträchtigen kann und bei Bedarf neu gestartet werden kann."*

Da Aspose‑Komponenten in einer einzigen DLL verpackt sind, ist nie die Installation zusätzlicher Teile erforderlich. Aspose‑Komponenten werden ausschließlich von C++‑Anwendungen genutzt und enthalten keinen Code, der auf eine menschliche Reaktion wartet. Aspose‑Komponenten wurden gründlich getestet und sind äußerst stabil. Aspose‑Komponenten werden von [Unternehmen](https://about.aspose.com/customers) wie **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** und vielen weiteren eingesetzt.

## **Skalierbarkeit/Geschwindigkeit**
Im Folgenden ein Zitat aus dem oben genannten Microsoft‑Artikel:

*"Serverseitige Komponenten müssen hochgradig reentrante, multithreaded COM‑Komponenten mit minimalem Overhead und hohem Durchsatz für mehrere Clients sein. Office‑Anwendungen sind fast in allem das genaue Gegenteil. Sie sind nicht‑reentrante, STA‑basierte Automatisierungs‑Server, die dafür ausgelegt sind, vielfältige, aber ressourcenintensive Funktionalität für einen einzelnen Client bereitzustellen. Sie bieten nur geringe Skalierbarkeit als serverseitige Lösung und haben feste Grenzen für wichtige Elemente wie Speicher, die nicht konfigurierbar sind. Noch wichtiger ist, dass sie globale Ressourcen (wie memory‑mapped Files, globale Add‑Ins oder Vorlagen und geteilte Automatisierungs‑Server) nutzen, was die gleichzeitig laufende Instanzenanzahl begrenzen und zu Race‑Conditions führen kann, wenn sie in einer Multi‑Client‑Umgebung konfiguriert werden. Entwickler, die planen, mehr als eine Instanz einer Office‑Anwendung gleichzeitig zu betreiben, müssen Pooling oder Serializing Access to the Office Application in Betracht ziehen, um potenzielle Deadlocks oder Datenkorruption zu vermeiden."*

Aspose‑Komponenten sind hoch skalierbar und blitzschnell. Office‑Anwendungen wurden nicht dafür entwickelt, gleichzeitig von Hunderten oder Tausenden von Benutzern genutzt zu werden. Aspose‑Komponenten hingegen sind genau dafür konzipiert. Unsere Komponenten sind eine echte C++‑Lösung und funktionieren einwandfrei, egal ob auf einem einzelnen Server, der eine einzelne Anwendung antreibt, oder in einer load‑balanced Web‑Form, die eine unternehmensweite Anwendung bedient.

## **Preis**
Wenn eine Anwendung Microsoft Office Automation verwendet, muss für jede Maschine, auf der die Anwendung läuft, eine Kopie von Microsoft Office erworben werden. Oft muss eine Anwendung Office‑Dateien erstellen oder manipulieren, ohne dass der Benutzer Microsoft Office besitzt. Aspose bietet eine sehr [kostengünstige](https://purchase.aspose.com/) und lizenzfreie Weiterverteilungs‑Lizenz, die den Einsatz für eine unbegrenzte Anzahl von Benutzern ohne Lizenzsorgen ermöglicht. Beim Erstellen webbasierter Anwendungen ist zu beachten, dass Microsoft Office Automation‑Komponenten weder preislich noch lizenztechnisch für serverseitige Lösungen vorgesehen sind; es gibt also keine passende Lizenzlösung für die Bereitstellung von Web‑Anwendungen, die Microsoft Office‑Komponenten nutzen. Aspose bietet ebenfalls eine sehr [kostengünstige](https://purchase.aspose.com/) Lösung für serverbasierte Anwendungen.

## **Funktionen**
Aspose‑Komponenten bieten alles, was zur Verwaltung von Office‑Dateien nötig ist – und noch viel mehr. Sie wurden mit der Philosophie entwickelt, Entwicklern zu ermöglichen, die bestmöglichen Ergebnisse mit möglichst geringem Aufwand zu erzielen. Im Gegensatz zu Office Automation stellen Aspose‑Komponenten zahlreiche leistungsstarke und zeitsparende Funktionen bereit. Beispielsweise ermöglicht [Aspose.Cells](https://products.aspose.com/cells/cpp/) Entwicklern, Daten aus einer **DataTable** oder **DataView** direkt in eine Excel‑Datei zu importieren. [Aspose.Words](https://products.aspose.com/words/net/) bietet eine ähnliche Funktion, mit der Entwickler ein Word‑Dokument (Mail‑Merge) direkt aus einem beliebigen C++‑Datenobjekt befüllen können. [Jede Komponente](https://products.aspose.com/total/cpp/) der Aspose‑Familie bietet ihr eigenes Set an einzigartigen und leistungsstarken Funktionen. Das Beste am Kauf einer Aspose‑Komponente ist der Zugriff auf unsere Entwicklungsteams. Unsere Teams wissen, dass ein Feature, das Ihr Unternehmen benötigt, höchstwahrscheinlich auch für andere Unternehmen interessant ist. Zwar kann nicht jedes Feature‑Anliegen umgesetzt werden, doch unsere Teams sind sehr offen und flexibel, wenn es um Unterstützung geht. Diese Einstellung hat Aspose‑Komponenten zu der Kraft verholfen, die sie heute besitzen. Wenn Sie zusätzliche Funktionen von Office‑Automation‑Objekten benötigen, sind die Chancen, dass sie hinzugefügt werden, äußerst gering.

## **Fazit**
{{% alert color="info" %}} 

Während dieser Artikel viele der wichtigsten Gründe behandelt, warum Aspose‑Komponenten eine bessere Wahl als Office Automation sind, gibt es noch viel mehr. Dieser Artikel konzentriert sich vor allem auf die zentralen Punkte. Alle verschiedenen Aspose‑Komponenten bieten eine risikofreie, unverbindliche [Evaluierungs‑Version](https://downloads.aspose.com/slides/de/cpp). Wir empfehlen Ihnen, diese [Evaluierung](https://downloads.aspose.com/slides/de/cpp) zu nutzen, um besser zu erkennen, was Aspose für Ihre Anwendungen tun kann.
{{% /alert %}}