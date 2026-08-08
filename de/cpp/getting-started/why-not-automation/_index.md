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
description: "Entdecken Sie, warum Office-Automatisierung für Server und Dienste riskant ist, und sehen Sie, wie Aspose.Slides eine sicherere, schnellere Präsentationsverarbeitung für PowerPoint und OpenDocument bietet."
---
## **Einleitung**

Es gibt mehrere Gründe, warum Aspose‑Komponenten eine bessere Alternative zur Automatisierung sind. Einige der wichtigsten Gründe sind:

- Sicherheit
- Stabilität
- Skalierbarkeit/Geschwindigkeit
- Preis
- Funktionen

Im Folgenden finden Sie eine ausführlichere Erklärung jedes Schlüsselpunkts.

## **Wichtige Fragen**
- Warum sind Aspose‑Komponenten eine viel bessere Option als Microsoft Office Automation?

Es gibt zwei Fragen, die wir hier bei Aspose am häufigsten hören:

- Erfordern Ihre Produkte, dass Microsoft Office installiert ist, damit sie ausgeführt werden können?
  
  Die kurze, einfache Antwort lautet **NEIN**. Aspose und Aspose‑Komponenten sind völlig unabhängig und stehen in keiner Verbindung zu Microsoft Corporation, noch sind sie von Microsoft autorisiert, gesponsert oder anderweitig genehmigt.

- Warum sollten wir Aspose‑Produkte verwenden, anstatt Microsoft Office Automation zu nutzen?
  
  Die kürzeste Antwort, die wir geben können, ist, dass es viele Gründe gibt, wobei der wichtigste ist, dass *Microsoft selbst dringend davon abrät, Office Automation aus Softwarelösungen zu verwenden: [Microsoft Article

## **Sicherheit**
Das Folgende ist ein direkteres Zitat aus dem oben genannten Microsoft‑Artikel:  

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Aspose‑Produkte sind sehr sicher. Daher stellen Aspose‑Komponenten kein potenzielles Risiko für wichtige Systemressourcen dar. Außerdem werden beim Öffnen eines Dokuments durch eine Aspose‑Komponente Makros nicht automatisch ausgeführt. Aspose‑Komponenten wurden mit dem Ziel entwickelt, Entwicklern das Erstellen, Manipulieren und Speichern von Office‑Dateien zu ermöglichen. Keine der mit dem Microsoft‑Office‑Paket verbundenen Risiken sind bei Aspose‑Komponenten inhärent.

## **Stabilität**
Das Folgende ist ein direkteres Zitat aus dem oben genannten Microsoft‑Artikel:  

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Da Aspose‑Komponenten in einer einzigen DLL verpackt sind, wird niemals ein zusätzlicher Teil oder weitere Komponenten installiert werden müssen, damit sie funktionieren. Aspose‑Komponenten werden ausschließlich von C++‑Anwendungen verwendet und es gibt keinen Teil des Komponenten‑Codes, der auf eine menschliche Antwort wartet. Aspose‑Komponenten wurden gründlich getestet und sind äußerst stabil. Aspose‑Komponenten werden von [Companies](https://about.aspose.com/customers) wie **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** und vielen, vielen anderen eingesetzt.

## **Skalierbarkeit/Geschwindigkeit**
Das Folgende ist ein direkteres Zitat aus dem oben genannten Microsoft‑Artikel:  


*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Aspose‑Komponenten sind hoch skalierbar und blitzschnell. Office‑Anwendungen wurden nicht dafür konzipiert, gleichzeitig von Hunderten oder Tausenden von Benutzern genutzt zu werden. Aspose‑Komponenten hingegen sind genau dafür ausgelegt. Unsere Komponenten sind eine echte C++‑Lösung und arbeiten tadellos, egal ob auf einem einzelnen Server, der eine einzige Anwendung betreibt, oder auf einem Last‑balancierten Web‑Formular, das eine unternehmensweite Anwendung unterstützt.

## **Preis**
Wenn eine Anwendung Microsoft Office Automation verwendet, muss für jede Maschine, auf der die Anwendung läuft, eine Kopie von Microsoft Office erworben werden. Es gibt viele Fälle, in denen eine Anwendung eine Office‑Datei erstellen oder bearbeiten muss, der Benutzer jedoch nicht Microsoft Office besitzen muss. Aspose bietet eine sehr [Cost Effective](https://purchase.aspose.com/) und lizenzgebührenfreie Weitergabelizenz, die die Bereitstellung auf eine unbegrenzte Anzahl von Benutzern ohne Lizenzierungsprobleme ermöglicht. Beim Erstellen webbasierter Anwendungen ist es wichtig zu wissen, dass Microsoft Office Automation‑Komponenten weder preislich noch lizenztechnisch für serverseitige Lösungen vorgesehen sind; daher gibt es keine geeignete Lizenzlösung für die Bereitstellung von Web‑Anwendungen, die Microsoft Office‑Komponenten nutzen. Aspose bietet ebenfalls eine sehr [Cost Effective](https://purchase.aspose.com/) Lösung für serverbasierte Anwendungen.

## **Funktionen**
Aspose‑Komponenten bieten alles, was für die Verwaltung von Office‑Dateien erforderlich ist, und noch viel mehr. Sie wurden nach dem Prinzip entwickelt, Entwicklern zu ermöglichen, die besten Ergebnisse mit möglichst wenig Aufwand zu erzielen. Im Gegensatz zu Office Automation bieten Aspose‑Komponenten viele leistungsstarke und zeitsparende Funktionen. Zum Beispiel ermöglicht [Aspose.Cells](https://products.aspose.com/cells/cpp/) Entwicklern, Daten aus einer **DataTable** oder **DataView** direkt in eine Excel‑Datei zu importieren. [Aspose.Words](https://products.aspose.com/words/net/) bietet eine ähnliche Funktion, mit der Entwickler ein Word‑Dokument (also ein Serienbrief) direkt aus einem beliebigen C++‑Datenobjekt befüllen können. [Every Component](https://products.aspose.com/total/cpp/) in der Aspose‑Familie bietet jeweils eigene, einzigartige und leistungsstarke Funktionen. Der beste Teil beim Kauf einer Aspose‑Komponente ist der Zugriff auf unsere Entwicklungsteams. Unsere Teams wissen, dass ein Feature, das Ihr Unternehmen benötigt, wahrscheinlich auch von anderen Unternehmen benötigt wird. Obwohl nicht jede Funktionsanfrage umgesetzt werden kann, bemühen sich unsere Teams, sehr offen und flexibel zu sein, wenn sie Unterstützung leisten. Diese Einstellung hat Aspose‑Komponenten zu ihrer heutigen Leistungsfähigkeit verholfen. Wenn Sie zusätzliche Features von Office‑Automation‑Objekten benötigen, sind Ihre Chancen, dass diese hinzugefügt werden, sehr, sehr gering.

## **Fazit**
{{% alert color="primary" %}} 

Während dieser Artikel viele der wichtigsten Punkte behandelt hat, warum Aspose‑Komponenten eine bessere Wahl als Office Automation sind, gibt es noch viele, viele weitere. Dieser Artikel konzentriert sich hauptsächlich auf die wichtigsten Punkte. Alle verschiedenen Aspose‑Komponenten bieten eine risikofreie, unverbindliche [Evaluation Version](https://downloads.aspose.com/slides/de/cpp). Wir empfehlen Ihnen, diese [Evaluation](https://downloads.aspose.com/slides/de/cpp) zu nutzen, um besser zu sehen, was Aspose für Ihre Anwendungen leisten kann.

{{% /alert %}}