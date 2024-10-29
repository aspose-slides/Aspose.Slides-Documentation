---
title: Unterstützung für unterbrechbare Bibliothek
type: docs
weight: 120
url: /de/php-java/support-for-interruptable-library/
---

## **Unterbrechbare Bibliothek**
Jetzt wurden in Aspose.Slides die InterruptionToken-Struktur und die InterruptionTokenSource-Klasse hinzugefügt. Diese Typen unterstützen die Unterbrechung von langlaufenden Aufgaben, wie z.B. Deserialisierung, Serialisierung oder Rendering. InterruptionTokenSource stellt die Quelle des Tokens oder mehrerer Tokens dar, die an **ILoadOptions.InterruptionToken** übergeben werden. Wenn ILoadOptions.InterruptionToken gesetzt ist und diese LoadOptions-Instanz an den Präsentationskonstruktor übergeben wird, wird jede langlaufende Aufgabe, die mit dieser Präsentation verbunden ist, unterbrochen, wenn die Methode InterruptionTokenSource.Interrupt aufgerufen wird.

Der Codeausschnitt unten demonstriert die Unterbrechung der laufenden Aufgabe.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}