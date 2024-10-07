---
title: Vergleiche Folien
type: docs
weight: 50
url: /cpp/compare-slides/
---

## **Vergleiche Zwei Folien**
Die Equals-Methode wurde zur IBaseSlide-Schnittstelle und zur BaseSlide-Klasse hinzugefügt. Sie gibt true zurück für Folien / Layout-Folien / Master-Folien, die in ihrer Struktur und statischen Inhalte identisch sind.

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und andere Einstellungen usw. übereinstimmen. Bei dem Vergleich werden keine einzigartigen Identifikatoren berücksichtigt, z. B. SlideId und dynamische Inhalte, z. B. der aktuelle Datumswert im Datumsplatzhalter.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}