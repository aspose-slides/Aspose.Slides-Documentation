---
title: Verwalten der Präsentationszugänglichkeit auf Android
linktitle: Präsentations‑Zugänglichkeit
type: docs
weight: 30
url: /de/androidjava/presentation-accessibility/
keywords:
- Präsentationszugänglichkeit
- Alternativtext
- Alternativtext‑Titel
- Alternativtext‑Beschreibung
- Als dekorativ markieren
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für Android via Java die automatisierte Überprüfung der Barrierefreiheit von Präsentationen in PPT-, PPTX- und ODP‑Dateien unterstützt – verbessern Sie das Erlebnis für Bildschirmleser und steigern Sie die Konformität."
---
## **Einleitung**

Alternativtext hilft Personen, die unterstützende Technologien verwenden, die Bedeutung von Bildern, Diagrammen und anderen informativen Formen zu verstehen. Dieser Artikel erklärt, wie man Alternative‑Text‑Titel und -Beschreibungen mit Aspose.Slides für Android via Java liest und aktualisiert, wie man Zugänglichkeits‑Beschreibungen von Formnamen unterscheidet, die im Code verwendet werden, und wie man prüft, ob eine Form als dekorativ markiert ist.

Diese Funktionen unterstützen die Barrierefreiheit von Präsentationen, garantieren sie jedoch nicht. Reihenfolge der Inhalte, Farbkontrast, Lesbarkeit des Textes und andere Anforderungen an die Barrierefreiheit müssen ebenfalls überprüft werden.

## **Alternative‑Text‑Titel und -Beschreibungen verwalten**

Verwenden Sie Alternativtext, um die Bedeutung von Bildern, Diagrammen und anderen informativen Formen Personen zu erklären, die sie nicht sehen können. Die folgenden Methoden und Inhalte dienen unterschiedlichen Zwecken:

| Methode oder Inhalt | Zweck |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Ein kurzer Titel für die alternative Beschreibung. |
| [getAlternativeText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | Eine aussagekräftige Beschreibung des Inhalts oder Zwecks der Form im Kontext der Folie. |
| [getName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getName--) | Der Name der Form, den der Code verwenden kann, um eine bestimmte Form in der Präsentation zu finden. |
| Sichtbarer Text | Inhalt, der auf der Folie angezeigt wird, wie der Text einer Form oder der Titel und die Beschriftungen eines Diagramms. Das Aktualisieren des Alternativtexts ändert diesen Inhalt nicht. |

Wenn eine Präsentation als Vorlage wiederverwendet wird, kann Code eine Form anhand des Namens finden, den [getName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getName--) zurückgibt, bevor sie aktualisiert wird. Dieser Name hat einen anderen Zweck als der Alternativtext, der erklärt, was das Visuelle dem Leser vermittelt. Die Suche nach Namen ermöglicht es Autoren, Beschreibungen zu verbessern oder zu übersetzen, ohne zu ändern, wie der Code die Form findet. Namen können bearbeitet werden und sind nicht garantiert eindeutig, prüfen Sie deshalb, dass der Name mit der beabsichtigten Form übereinstimmt; siehe [Identify and Find Shapes](/slides/de/androidjava/shape-manipulations/#identify-and-find-shapes).

Das folgende Beispiel setzt voraus, dass `input.pptx` ein Bild eines Büroeingangs als erste Form auf der ersten Folie enthält. Das Bild sollte nicht als dekorativ markiert sein. Das Beispiel liest und gibt den aktuellen Alternativ‑Text‑Titel und die Beschreibung aus, aktualisiert beide Werte und speichert die Präsentation als `output.pptx`. Passen Sie die Formulierung an das tatsächliche Bild und die von ihm übermittelten Informationen an.

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

Allein das Hinzufügen von Alternativtext garantiert keine Barrierefreiheit der Präsentation oder die Einhaltung von Barrierefreiheitsstandards. Überprüfen Sie die Beschreibungen auf Genauigkeit und Relevanz und prüfen Sie zudem Reihenfolge, Farbkontrast, lesbaren Text und andere Anforderungen an die Barrierefreiheit. Informationsreiche Visualisierungen sollten nicht als dekorativ markiert werden; im nächsten Abschnitt wird gezeigt, wie man [isDecorative](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#isDecorative--) prüft.

## **Als dekorativ markieren**

Der Flag „Als dekorativ markieren“ kennzeichnet rein ornamentale Visualisierungen, sodass Bildschirmleser sie überspringen, was Störgeräusche reduziert und den Fokus auf relevante Inhalte legt. Anwenden auf Hintergründe, Verzierungen und Abstandshalter – niemals auf Diagramme, Symbole oder Bilder, die Informationen vermitteln. Aspose.Slides stellt diesen Flag für Erkennung und Validierung bereit, wodurch automatisierte Barrierefreiheitsprüfungen und Aufräumarbeiten ermöglicht werden.

![Als dekorativ markieren](mark_as_decorative.png)

Der folgende Code‑Beispiel zeigt, wie man feststellt, ob eine Form als dekorativ markiert ist.

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

**Was soll ich in den Alternativ‑Text‑Titel und die Beschreibung eintragen?**

Verwenden Sie einen kurzen Titel, um das Thema zu identifizieren, und eine Beschreibung, um die Informationen zu erklären, die das Visuelle im Kontext der Folie vermittelt. Für ein Diagramm beschreiben Sie den relevanten Trend oder Vergleich, anstatt nur „Diagramm“ zu sagen.

**Sollte ich Alternativtext verwenden, um Formen in einer Vorlage zu finden?**

Bevorzugen Sie das Finden der Form anhand des Namens, den [getName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getName--) zurückgibt, und prüfen Sie, dass es die erwartete Form ist. Alternativtext kann bearbeitet oder übersetzt werden, was Code, der nach einer genauen Beschreibung sucht, brechen kann; siehe [Identify and Find Shapes](/slides/de/androidjava/shape-manipulations/).

**Wann sollte eine Form als dekorativ markiert werden?**

Verwenden Sie den dekorativen Flag für Visualisierungen, die keine Informationen hinzufügen, wie ornamentale Verzierungen. Bilder und Diagramme, die Bedeutungen vermitteln, benötigen stattdessen eine passende Beschreibung.

**Macht das Hinzufügen von Alternativtext eine Präsentation vollständig barrierefrei?**

Nein. Alternativtext deckt nur einen Teil der Barrierefreiheit ab. Außerdem sollten Reihenfolge, Farbkontrast, Textlesbarkeit und weitere relevante Anforderungen überprüft werden; das Setzen dieser Eigenschaften allein stellt keine Konformität sicher.