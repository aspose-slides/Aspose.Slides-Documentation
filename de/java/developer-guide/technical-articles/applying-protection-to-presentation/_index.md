---  
title: Schutz auf Präsentation anwenden  
type: docs  
weight: 60  
url: /de/java/applying-protection-to-presentation/  
---  

{{% alert color="primary" %}}  
  
Eine häufige Verwendung von Aspose.Slides besteht darin, Microsoft PowerPoint 2007 (PPTX) Präsentationen im Rahmen eines automatisierten Workflows zu erstellen, zu aktualisieren und zu speichern. Benutzer der Anwendung, die Aspose.Slides auf diese Weise verwenden, erhalten Zugriff auf die ausgegebenen Präsentationen. Sie vor Bearbeitung zu schützen, ist eine gängige Sorge. Es ist wichtig, dass automatisch generierte Präsentationen ihr ursprüngliches Format und ihren Inhalt beibehalten.  

Dieser Artikel erklärt, wie [Präsentationen und Folien aufgebaut sind](/slides/de/java/applying-protection-to-presentation/) und wie Aspose.Slides für Java [Schutz anwenden kann](/slides/de/java/applying-protection-to-presentation/), und dann [ihn von](/slides/de/java/applying-protection-to-presentation/) einer Präsentation [entfernen kann](/slides/de/java/applying-protection-to-presentation/). Dieses Feature ist einzigartig für Aspose.Slides und zum Zeitpunkt des Schreibens nicht in Microsoft PowerPoint verfügbar. Es gibt Entwicklern eine Möglichkeit, zu kontrollieren, wie die von ihren Anwendungen erstellten Präsentationen verwendet werden.  

{{% /alert %}}  
## **Aufbau einer Folie**  
Eine PPTX-Folie besteht aus einer Vielzahl von Komponenten wie Aut Shapes, Tabellen, OLE-Objekten, gruppierten Formen, Bilderrahmen, Video-Frames, Verbindern und anderen verschiedenen Elementen, die zum Aufbau einer Präsentation verfügbar sind. In Aspose.Slides für Java wird jedes Element auf einer Folie in ein Shape-Objekt umgewandelt. Mit anderen Worten, jedes Element auf der Folie ist entweder ein Shape-Objekt oder ein von dem Shape-Objekt abgeleitetes Objekt. Die Struktur von PPTX ist komplex, sodass im Gegensatz zu PPT, wo ein generischer Lock für alle Arten von Formen verwendet werden kann, es unterschiedliche Lock-Arten für verschiedene Formtypen gibt. Die BaseShapeLock-Klasse ist die generische PPTX-Lock-Klasse. Die folgenden Lock-Arten werden in Aspose.Slides für Java für PPTX unterstützt.  

- AutoShapeLock schützt Auto Shapes.  
- ConnectorLock schützt Connector-Formen.  
- GraphicalObjectLock schützt grafische Objekte.  
- GroupshapeLock schützt Gruppenformen.  
- PictureFrameLock schützt Bilderrahmen.  
  Jede Aktion, die auf alle Shape-Objekte in einem Präsentationsobjekt ausgeführt wird, wird auf die gesamte Präsentation angewendet.  
## **Schutz anwenden und entfernen**  
Schutz anzuwenden stellt sicher, dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik zum Schutz des Inhalts einer Präsentation.  
## **Schutz auf PPTX-Formen anwenden**  
Aspose.Slides für Java bietet die Shape-Klasse, um eine Form auf der Folie zu bearbeiten.  

Wie bereits erwähnt, hat jede Shape-Klasse eine zugehörige Shape-Lock-Klasse für den Schutz. Dieser Artikel konzentriert sich auf die NoSelect-, NoMove- und NoResize-Locks. Diese Locks stellen sicher, dass Formen nicht ausgewählt (durch Mausklicks oder andere Auswahlmethoden) und nicht verschoben oder in der Größe geändert werden können.  

Die folgenden Beispielcodes wenden Schutz auf alle Formtypen in einer Präsentation an.  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-ApplyProtection-ApplyProtection.java" >}}  
## **Schutz entfernen**  
Der Schutz, der mit Aspose.Slides für .NET/Java angewendet wurde, kann nur mit Aspose.Slides für .NET/Java entfernt werden. Um eine Form zu entsperren, setzen Sie den Wert des angewendeten Locks auf false. Das folgende Codebeispiel zeigt, wie man Formen in einer gesperrten Präsentation entsperrt.  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemoveProtection-RemoveProtection.java" >}}  

## **Zusammenfassung**  
{{% alert color="primary" %}}  
  
Aspose.Slides bietet eine Reihe von Optionen für den Schutz von Formen in einer Präsentation. Es ist möglich, eine bestimmte Form zu sperren oder durch alle Formen in einer Präsentation zu iterieren und alle zu sperren, um die Präsentation effektiv zu sperren. Nur Aspose.Slides für Java kann den Schutz von einer Präsentation entfernen, die zuvor geschützt wurde. Entfernen Sie den Schutz, indem Sie den Wert eines Locks auf false setzen.  

{{% /alert %}}