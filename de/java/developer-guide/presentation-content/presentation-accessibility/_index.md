---
title: Verwalten der Präsentationszugänglichkeit in Java
linktitle: Präsentationszugänglichkeit
type: docs
weight: 30
url: /de/java/presentation-accessibility/
keywords:
- Präsentationszugänglichkeit
- Alternativtext
- Alternativtext-Titel
- Alternativtext-Beschreibung
- Als dekorativ kennzeichnen
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Java die automatisierte Überprüfung der Präsentationszugänglichkeit in PPT-, PPTX- und ODP-Dateien unterstützt – verbessern Sie das Erlebnis für Bildschirmleser und erhöhen Sie die Konformität."
---
## **Einleitung**

Alternativtext hilft Personen, die unterstützende Technologien verwenden, die Bedeutung von Bildern, Diagrammen und anderen informativen Formen zu verstehen. Dieser Artikel erklärt, wie man mit Aspose.Slides für Java Alternativtext‑Titel und -Beschreibungen liest und aktualisiert, Zugänglichkeitsbeschreibungen von in Code verwendeten Formnamen unterscheidet und überprüft, ob eine Form als dekorativ markiert ist.

Diese Funktionen unterstützen die Barrierefreiheit von Präsentationen, garantieren sie jedoch nicht. Reihenfolge des Lesens, Farbkontrast, Textlesbarkeit und weitere Barrierefreiheitsanforderungen müssen ebenfalls überprüft werden.

## **Verwalten von Alternativtext‑Titeln und -Beschreibungen**

Verwenden Sie Alternativtext, um die Bedeutung von Bildern, Diagrammen und anderen informativen Formen Personen zu erklären, die sie nicht sehen können. Die folgenden Methoden und Inhalte dienen unterschiedlichen Zwecken:

| Methode oder Inhalt | Zweck |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Ein kurzer Titel für die alternative Beschreibung. |
| [getAlternativeText](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getAlternativeText--) | Eine sinnvolle Beschreibung des Inhalts oder Zwecks der Form im Kontext der Folie. |
| [getName](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getName--) | Der Name der Form, den Code verwenden kann, um eine bestimmte Form in der Präsentation zu finden. |
| Sichtbarer Text | Auf der Folie angezeigter Inhalt, wie der Text einer Form oder der Titel und die Beschriftungen eines Diagramms. Das Aktualisieren des Alternativtexts ändert diesen Inhalt nicht. |

Wenn eine Präsentation als Vorlage erneut verwendet wird, kann der Code eine Form anhand des von [getName](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getName--) zurückgegebenen Namens finden, bevor sie aktualisiert wird. Dieser Name dient einem anderen Zweck als der Alternativtext, der erklärt, was das visuelle Element dem Leser vermittelt. Die Suche nach dem Namen ermöglicht es Autoren, Beschreibungen zu verbessern oder zu übersetzen, ohne zu ändern, wie der Code die Form findet. Namen können bearbeitet werden und sind nicht garantiert eindeutig, daher sollte überprüft werden, ob der Name der beabsichtigten Form entspricht; siehe [Identify and Find Shapes](/slides/de/java/shape-manipulations/#identify-and-find-shapes).

Das folgende Beispiel benötigt `input.pptx` mit einem Bild eines Büroeingangs als erster Form auf der ersten Folie. Das Bild sollte nicht als dekorativ markiert sein. Das Beispiel liest und gibt den aktuellen Alternativtext‑Titel und die Beschreibung aus, aktualisiert beide Werte und speichert die Präsentation als `output.pptx`. Passen Sie die Formulierung an das tatsächliche Bild und die darin enthaltenen Informationen an.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Hinzufügen von Alternativtext allein garantiert nicht die Barrierefreiheit einer Präsentation oder die Einhaltung von Barrierefreiheitsstandards. Überprüfen Sie die Beschreibungen auf Genauigkeit und Relevanz und prüfen Sie außerdem Reihenfolge des Lesens, Farbkontrast, lesbaren Text und weitere Barrierefreiheitsanforderungen. Informative Grafiken sollten nicht als dekorativ markiert werden; der nächste Abschnitt zeigt, wie man [isDecorative](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#isDecorative--) überprüft.

## **Als dekorativ kennzeichnen**

Die Kennzeichnung als dekorativ markiert rein ornamental gestaltete Visuals, sodass Bildschirmleser sie überspringen, was Rauschen reduziert und den Fokus auf bedeutungsvolle Inhalte legt. Wenden Sie sie auf Hintergründe, Verzierungen und Abstandselemente an – niemals auf Diagramme, Symbole oder Bilder, die Informationen vermitteln. Aspose.Slides stellt dieses Flag zur Erkennung und Validierung bereit, wodurch automatisierte Barrierefreiheitsprüfungen und Bereinigungen ermöglicht werden.

![Als dekorativ kennzeichnen](mark_as_decorative.png)

Das folgende Codebeispiel zeigt, wie man feststellt, ob eine Form als dekorativ markiert ist.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Was soll ich in den Alternativtext‑Titel und die Beschreibung eintragen?**

Verwenden Sie einen kurzen Titel, um das Thema zu identifizieren, und eine Beschreibung, um die vom Visual im Kontext der Folie übermittelten Informationen zu erläutern. Bei einem Diagramm beschreiben Sie den relevanten Trend oder Vergleich, anstatt nur „Diagramm“ zu sagen.

**Soll ich Alternativtext verwenden, um Formen in einer Vorlage zu finden?**

Bevorzugen Sie, die Form anhand des von [getName](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getName--) zurückgegebenen Namens zu finden und zu überprüfen, ob es die erwartete Form ist. Alternativtext kann bearbeitet oder übersetzt werden, was Code, der nach einer genauen Beschreibung sucht, zum Scheitern bringen kann; siehe [Identify and Find Shapes](/slides/de/java/shape-manipulations/).

**Wann sollte eine Form als dekorativ gekennzeichnet werden?**

Verwenden Sie das dekorative Flag für Visuals, die keine Informationen hinzufügen, wie ornamentale Verzierungen. Bilder und Diagramme, die eine Aussage vermitteln, benötigen stattdessen eine passende Beschreibung.

**Macht das Hinzufügen von Alternativtext eine Präsentation vollständig barrierefrei?**

Nein. Alternativtext deckt nur einen Teil der Barrierefreiheit ab. Außerdem sollten Reihenfolge des Lesens, Farbkontrast, Textlesbarkeit und weitere relevante Anforderungen überprüft werden; das Setzen dieser Eigenschaften allein stellt keine Konformität sicher.