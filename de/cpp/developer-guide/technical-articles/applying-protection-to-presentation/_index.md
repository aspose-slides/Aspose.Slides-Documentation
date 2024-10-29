---
title: Anwendung von Schutz auf Präsentationen
type: docs
weight: 10
url: /de/cpp/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Eine häufige Verwendung von Aspose.Slides besteht darin, Microsoft PowerPoint 2007 (PPTX) Präsentationen im Rahmen eines automatisierten Workflows zu erstellen, zu aktualisieren und zu speichern. Benutzer der Anwendung, die Aspose.Slides auf diese Weise verwenden, haben Zugriff auf die Ausgabpräsentationen. Sie vor Bearbeitung zu schützen, ist ein häufiges Anliegen. Es ist wichtig, dass automatisch generierte Präsentationen ihr ursprüngliches Format und ihren Inhalt beibehalten.

Dieser Artikel erklärt, wie [Präsentationen und Folien aufgebaut sind](/slides/de/cpp/applying-protection-to-presentation/) und wie Aspose.Slides für C++ [Schutz anwendet](/slides/de/cpp/applying-protection-to-presentation/), und dann [ihn von](/slides/de/cpp/applying-protection-to-presentation/) einer Präsentation entfernt. Diese Funktion ist einzigartig für Aspose.Slides und ist zum Zeitpunkt des Schreibens nicht in Microsoft PowerPoint verfügbar. Sie bietet Entwicklern eine Möglichkeit, zu steuern, wie die Präsentationen, die ihre Anwendungen erstellen, verwendet werden.

{{% /alert %}} 
## **Zusammensetzung einer Folie**
Eine PPTX-Folie besteht aus einer Reihe von Komponenten wie Autoformen, Tabellen, OLE-Objekten, gruppierten Formen, Bilderrahmen, Videorahmen, Verbindern und verschiedenen anderen Elementen, die zur Erstellung einer Präsentation verfügbar sind.

In Aspose.Slides für C++ wird jedes Element auf einer Folie in ein Shape-Objekt umgewandelt. Mit anderen Worten, jedes Element auf der Folie ist entweder ein Shape-Objekt oder ein Objekt, das vom Shape-Objekt abgeleitet ist.

Die Struktur von PPTX ist komplex, sodass im Gegensatz zu PPT, wo ein generischer Lock für alle Formen verwendet werden kann, es verschiedene Arten von Locks für verschiedene Formtypen gibt. Die BaseShapeLock-Klasse ist die generische PPTX-Sperrklasse. Die folgenden Arten von Locks werden in Aspose.Slides für C++ für PPTX unterstützt.

- AutoShapeLock sperrt Autoformen.
- ConnectorLock sperrt Verbindungselemente.
- GraphicalObjectLock sperrt grafische Objekte.
- GroupshapeLock sperrt Gruppenformen.
- PictureFrameLock sperrt Bilderrahmen.

Jede Aktion, die auf allen Shape-Objekten in einem Präsentationsobjekt durchgeführt wird, wird auf die gesamte Präsentation angewendet.
## **Anwenden und Entfernen von Schutz**
Das Anwenden von Schutz stellt sicher, dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik, um den Inhalt einer Präsentation zu schützen.
### **Anwenden von Schutz auf PPTX-Formen**
Aspose.Slides für C++ bietet die Shape-Klasse zur Verwaltung einer Form auf der Folie.

Wie bereits erwähnt, hat jede Shape-Klasse eine zugeordnete Shape-Lock-Klasse zum Schutz. Dieser Artikel konzentriert sich auf die Locks NoSelect, NoMove und NoResize. Diese Locks stellen sicher, dass Formen nicht ausgewählt (durch Mausklicks oder andere Auswahlmethoden) und nicht verschoben oder in der Größe geändert werden können.

Die nachfolgenden Codebeispiele wenden Schutz auf alle Formen in einer Präsentation an.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ApplyProtection-ApplyProtection.cpp" >}}

### **Entfernen von Schutz**
Der mit Aspose.Slides für C++ angewendete Schutz kann nur mit Aspose.Slides für C++ entfernt werden. Um eine Form zu entsperren, setzen Sie den Wert des angewendeten Locks auf false. Das folgende Codebeispiel zeigt, wie man Formen in einer gesperrten Präsentation entsperrt.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-RemoveProtection-RemoveProtection.cpp" >}}
## **Zusammenfassung**
{{% alert color="primary" %}} 

Aspose.Slides bietet eine Reihe von Optionen zum Anwenden von Schutz auf Formen in einer Präsentation. Es ist möglich, eine bestimmte Form zu sperren oder durch alle Formen in einer Präsentation zu iterieren und alle zu sperren, um die Präsentation effektiv zu sperren.

Nur Aspose.Slides für C++ kann den Schutz von einer zuvor geschützten Präsentation entfernen. Entfernen Sie den Schutz, indem Sie den Wert eines Locks auf false setzen.

{{% /alert %}} 
### **Verwandte Artikel**
- Die [ShapeEx](http://docs.aspose.com/display/slidesnet/ShapeEx+Class) Klasse.
- Die [BaseShapeLockEx](http://docs.aspose.com/display/slidesnet/BaseShapeLockEx+Class) Klasse.