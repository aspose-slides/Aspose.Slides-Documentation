---
title: Anwendung von Schutz auf Präsentationen
type: docs
weight: 60
url: /php-java/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Eine gängige Verwendung von Aspose.Slides ist die Erstellung, Aktualisierung und Speicherung von Microsoft PowerPoint 2007 (PPTX) Präsentationen als Teil eines automatisierten Workflows. Benutzer der Anwendung, die Aspose.Slides auf diese Weise verwendet, erhalten Zugriff auf die Ausgabpräsentationen. Sie vor Änderungen zu schützen, ist ein häufiges Anliegen. Es ist wichtig, dass automatisch generierte Präsentationen ihr ursprüngliches Format und ihren Inhalt beibehalten.

Dieser Artikel erklärt, wie [Präsentationen und Folien aufgebaut sind](/slides/php-java/applying-protection-to-presentation/) und wie Aspose.Slides für PHP über Java [Schutz anwendet](/slides/php-java/applying-protection-to-presentation/), und dann [ihn von](/slides/php-java/applying-protection-to-presentation/) einer Präsentation entfernt. Dieses Feature ist einzigartig für Aspose.Slides und ist zum Zeitpunkt des Schreibens in Microsoft PowerPoint nicht verfügbar. Es bietet Entwicklern eine Möglichkeit, zu steuern, wie die von ihren Anwendungen erstellten Präsentationen verwendet werden.

{{% /alert %}} 
## **Zusammensetzung einer Folie**
Eine PPTX-Folie setzt sich aus einer Anzahl von Komponenten zusammen, wie Autoshapes, Tabellen, OLE-Objekten, gruppierten Formen, Bildrahmen, Videorahmen, Verbindern und den verschiedenen anderen Elementen, die zum Aufbau einer Präsentation verfügbar sind. In Aspose.Slides für PHP über Java wird jedes Element auf einer Folie in ein Shape-Objekt umgewandelt. Mit anderen Worten, jedes Element auf der Folie ist entweder ein Shape-Objekt oder ein Objekt, das von dem Shape-Objekt abgeleitet ist. Die Struktur von PPTX ist komplex, sodass im Gegensatz zu PPT, wo ein generischer Sperrcode für alle Arten von Formen verwendet werden kann, unterschiedliche Arten von Sperren für unterschiedliche Formtypen existieren. Die BaseShapeLock-Klasse ist die generische PPTX-Sperrklasse. Die folgenden Sperrtypen werden in Aspose.Slides für PHP über Java für PPTX unterstützt.

- AutoShapeLock sperrt Autoshapes.
- ConnectorLock sperrt Verbindungsformen.
- GraphicalObjectLock sperrt grafische Objekte.
- GroupshapeLock sperrt Gruppenkörper.
- PictureFrameLock sperrt Bildrahmen.
  Jede Aktion, die auf allen Shape-Objekten in einem Präsentationsobjekt durchgeführt wird, wird auf die gesamte Präsentation angewendet.
## **Anwenden und Entfernen von Schutz**
Schutz zugewiesen确保确保 dass eine Präsentation nicht bearbeitet werden kann. Es ist eine nützliche Technik, um den Inhalt einer Präsentation zu schützen.
## **Anwendung von Schutz auf PPTX Formen**
Aspose.Slides für PHP über Java bietet die Shape-Klasse, um eine Form auf der Folie zu handhaben.

Wie bereits erwähnt, hat jede Formklasse eine zugehörige Form-Sperrklasse zum Schutz. Dieser Artikel konzentriert sich auf die NoSelect-, NoMove- und NoResize-Sperren. Diese Sperren stellen sicher, dass Formen nicht ausgewählt werden können (durch Mausklicks oder andere Auswahlmethoden) und nicht bewegt oder skaliert werden können.

Die folgenden Codebeispiele wenden Schutz auf alle Formtypen in einer Präsentation an.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-ApplyProtection-ApplyProtection.java" >}}
## **Entfernen des Schutzes**
Der mit Aspose.Slides für .NET/Java angewandte Schutz kann nur mit Aspose.Slides für .NET/Java entfernt werden. Um eine Form zu entsperren, setzen Sie den Wert der angewandten Sperre auf falsch. Das folgende Codebeispiel zeigt, wie Sie Formen in einer gesperrten Präsentation entsperren können.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemoveProtection-RemoveProtection.java" >}}




## **Zusammenfassung**
{{% alert color="primary" %}} 

Aspose.Slides bietet eine Vielzahl von Optionen zum Anwenden von Schutz auf Formen in einer Präsentation. Es ist möglich, eine bestimmte Form zu sperren oder durch alle Formen in einer Präsentation zu iterieren und alle zu sperren, um die Präsentation effektiv zu sperren. Nur Aspose.Slides für PHP über Java kann den Schutz von einer Präsentation entfernen, die zuvor geschützt wurde. Entfernen Sie den Schutz, indem Sie den Wert einer Sperre auf falsch setzen.

{{% /alert %}}