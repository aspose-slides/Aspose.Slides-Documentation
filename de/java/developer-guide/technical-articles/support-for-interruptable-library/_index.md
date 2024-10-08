---
title: Unterstützung für unterbrechbare Bibliothek
type: docs
weight: 120
url: /de/java/support-for-interruptable-library/
---

## **Unterbrechbare Bibliothek**
Jetzt wurden in Aspose.Slides die Struktur InterruptionToken und die Klasse InterruptionTokenSource hinzugefügt. Diese Typen unterstützen die Unterbrechung von langlaufenden Aufgaben, wie z.B. Deserialisierung, Serialisierung oder Rendering. InterruptionTokenSource repräsentiert die Quelle des Tokens oder mehrerer Tokens, die an **ILoadOptions.InterruptionToken** übergeben werden. Wenn ILoadOptions.InterruptionToken gesetzt ist und diese LoadOptions-Instanz an den Konstruktor der Präsentation übergeben wird, wird jede langlaufende Aufgabe, die mit dieser Präsentation zusammenhängt, unterbrochen, wenn die Methode InterruptionTokenSource.Interrupt aufgerufen wird.

Der folgende Codeausschnitt demonstriert die Unterbrechung einer laufenden Aufgabe.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}