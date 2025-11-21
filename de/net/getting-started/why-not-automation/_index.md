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
description: "Entdecken Sie, warum Office-Automatisierung für Server und Dienste riskant ist, und sehen Sie, wie Aspose.Slides sicherere und schnellere Präsentationsverarbeitung für PowerPoint und OpenDocument bietet."
---

## **Wichtige Fragen**
- Warum sind Aspose‑Komponenten eine viel bessere Option als Microsoft Office Automation?

Es gibt zwei Fragen, die wir bei Aspose oft hören :

- Erfordern Ihre Produkte, dass Microsoft Office installiert ist, damit sie ausgeführt werden können?

Die kurze, einfache Antwort—**NEIN**. 

Aspose und Aspose‑Komponenten sind völlig unabhängig und stehen in keiner Verbindung zu Microsoft Corporation, noch sind sie von Microsoft autorisiert, gesponsert oder anderweitig genehmigt.

- Warum sollten wir Aspose‑Produkte statt der Nutzung von Microsoft Office Automation verwenden?

Einerseits gibt es viele [Vorteile, die Sie bei der Verwendung von Aspose.Slides genießen](https://docs.aspose.com/slides/net/product-overview/). 

Andererseits rät Microsoft selbst nachdrücklich **vom Einsatz** von Office Automation in Softwarelösungen ab. 

## **Übersicht**
Wie bereits erwähnt, gibt es mehrere Gründe, warum Aspose‑Komponenten eine bessere Alternative zur Automation sind. Einige der wichtigsten Gründe sind:

- Sicherheit
- Stabilität
- Skalierbarkeit/Geschwindigkeit
- Preis
- Funktionen

Wir haben die wichtigsten Gründe in den nachfolgenden Absätzen näher erläutert. 
## **Sicherheit**
Der folgende Abschnitt ist ein direktes Zitat aus einem Microsoft‑Artikel: 

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users".

Aspose‑Produkte sind sehr **sicher**. Aspose‑Komponenten laufen im selben Benutzerkontext wie alle ASP.NET‑Anwendungen (unter dem ASPNET‑Benutzer). Daher stellen Aspose‑Komponenten **keine** Sicherheitsrisiken dar. Sie verbrauchen zudem keine kritischen Systemressourcen. Darüber hinaus werden beim Öffnen eines Dokuments durch eine Aspose‑Komponente Makros nicht automatisch ausgeführt. Aspose‑Komponenten wurden entwickelt, um Entwicklern das Erstellen, Verändern und Speichern von Office‑Dateien zu ermöglichen. 

{{% alert color="primary" %}} 

Keine der mit dem Microsoft‑Office‑Paket verbundenen Risiken gelten für Aspose‑Komponenten. 

{{% /alert %}} 

## **Stabilität**
Dieser Text ist ein direktes Zitat aus dem zuvor erwähnten Microsoft‑Artikel: 

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Da Aspose‑Komponenten in einer einzigen DLL verpackt sind, müssen ihre Benutzer nie zusätzliche Teile oder Komponenten installieren, damit sie funktionieren. Aspose‑Komponenten werden ausschließlich von .NET‑Anwendungen verwendet und es gibt keinen Teil des Komponenten‑Codes, der darauf ausgelegt ist, auf eine menschliche Reaktion zu warten. 

{{% alert color="primary" %}} 

Aspose‑Komponenten wurden gründlich getestet und als sehr stabil bestätigt. Aspose‑Komponenten werden von [Unternehmen](http://www.aspose.com/Corporate/Aspose/Customerlist.html) wie **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** und vielen anderen führenden Organisationen in verschiedenen Branchen und Bereichen eingesetzt. 

{{% /alert %}} 

## **Skalierbarkeit/Geschwindigkeit**
Der folgende Abschnitt ist ein direktes Zitat aus einem Microsoft‑Artikel: 

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Aspose‑Komponenten sind unglaublich skalierbar und blitzschnell. Office‑Anwendungen wurden nicht dafür konzipiert, gleichzeitig von Hunderten oder Tausenden von Benutzern genutzt zu werden, Aspose‑Komponenten hingegen genau dafür. Unsere Komponenten sind eine echte .NET‑Lösung. 

{{% alert color="primary" %}} 

Die Leistung von Aspose‑Komponenten ist sowohl auf einem einzelnen Server (für eine einzelne Anwendung) als auch in einer Last‑balancierten Web‑Umgebung (für eine unternehmensweite Anwendung) einwandfrei. 

{{% /alert %}} 

## **Preis**
Wenn eine Anwendung Microsoft Office Automation nutzt, muss für jede Maschine, auf der die Anwendung läuft, eine Kopie von Microsoft Office erworben werden. Es gibt viele Fälle, in denen eine Anwendung Office‑Dateien erstellen oder bearbeiten muss, aber dafür ist Microsoft Office nicht erforderlich. 

{{% alert color="primary" %}} 

Aspose bietet eine sehr [kostengünstige](https://purchase.aspose.com/) und lizenzgebührenfreie Weiterverbreitungslizenz, die die Bereitstellung für eine unbegrenzte Anzahl von Benutzern ohne Lizenzprobleme ermöglicht. 

{{% /alert %}} 

Beim Erstellen webbasierter Anwendungen ist zu beachten, dass Microsoft Office Automation‑Komponenten weder preislich noch lizenztechnisch für serverseitige Lösungen vorgesehen sind. Daher gibt es keine geeignete Lizenzlösung für die Bereitstellung von Web‑Anwendungen, die Microsoft‑Office‑Komponenten nutzen. Aspose hingegen bietet ebenfalls eine sehr [kostengünstige](https://purchase.aspose.com/) Lösung für serverbasierte Anwendungen. 

## **Funktionen**
Aspose‑Komponenten bieten alles, was zur Verwaltung von Office‑Dateien nötig ist, und noch viel mehr. Wir haben sie nach unserer Philosophie entwickelt, Entwicklern zu ermöglichen, mit möglichst geringem Aufwand bestmögliche Ergebnisse zu erzielen. 

{{% alert color="primary" %}} 

Im Gegensatz zu Office Automation bieten Aspose‑Komponenten viele leistungsstarke und zeitsparende Funktionen. 

{{% /alert %}} 

Zum Beispiel ermöglicht [Aspose.Cells](https://products.aspose.com/cells/net/) Entwicklern, Daten aus einer **DataTable** oder **DataView** direkt in eine Excel‑Datei zu importieren. [Aspose.Words](https://products.aspose.com/words/net/) bietet eine ähnliche Funktion, mit der Entwickler ein Word‑Dokument (also Mail‑Merge) direkt aus einem beliebigen .NET‑Datenobjekt füllen können. [Jede Komponente](https://products.aspose.com/total/net/) der Aspose‑Familie bietet ihre eigenen einzigartigen und leistungsstarken Funktionen. 

Das Beste am Kauf einer Aspose‑Komponente ist der Zugriff auf unsere Entwicklungsteams. Wenn Sie zum Beispiel Office‑Automation‑Objekte verwenden und bestimmte Funktionen benötigen, ist die Wahrscheinlichkeit, dass diese Funktionen hinzugefügt werden, sehr, sehr gering. Bei Aspose‑Komponenten sieht das anders aus. 

{{% alert color="primary" %}} 

Unsere Entwicklungsteams verstehen, dass ein von Ihrem Unternehmen benötigtes Feature wahrscheinlich auch für andere Firmen von Interesse ist. Zwar können wir nicht jedes angeforderte Feature umsetzen, wir bemühen uns jedoch, basierend auf dem Feedback unserer Kunden so viele Funktionen wie möglich hinzuzufügen. 

{{% /alert %}} 

Unsere Teams sind stets offen und flexibel bei der Unterstützung – und das ist der Grund, warum Aspose‑Komponenten zu dem leistungsstarken Werkzeug geworden sind, das sie heute sind. 

## **Fazit**
{{% alert color="primary" %}} 

Während dieser Artikel einige der wichtigsten Punkte behandelte, warum Aspose‑Komponenten eine bessere Wahl als Office Automation sind, müssen Sie verstehen, dass es noch viele, viele weitere Vorteile gibt. Wir haben nur einige der wichtigsten Vorteile genannt. 

Außerdem bieten alle Aspose‑Produkte und -Komponenten eine risikofreie, unverbindliche [Evaluierungs‑Version](https://downloads.aspose.com/slides/net). Wir empfehlen Ihnen, die Evaluierung zu nutzen, um zu sehen, was Aspose für Ihre Anwendungen oder Ihr Unternehmen tun kann. 

{{% /alert %}}