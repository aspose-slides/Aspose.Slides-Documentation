---
title: Präsentationsfolien in C++ vergleichen
linktitle: Folien vergleichen
type: docs
weight: 50
url: /de/cpp/compare-slides/
keywords:
- Folien vergleichen
- Folienvergleich
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Vergleichen Sie PowerPoint- und OpenDocument-Präsentationen programmgesteuert mit Aspose.Slides für C++. Identifizieren Sie Folienunterschiede im Code schnell."
---

## **Zwei Folien vergleichen**
Die Equals‑Methode wurde zum IBaseSlide‑Interface und zur BaseSlide‑Klasse hinzugefügt. Sie gibt **true** zurück für Folien / Layout‑Folien / Master‑Folien, die durch ihre Struktur und statischen Inhalt identisch sind.

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und andere Einstellungen usw. übereinstimmen. Der Vergleich berücksichtigt keine eindeutigen Bezeichnerwerte, z. B. SlideId, und keinen dynamischen Inhalt, z. B. den aktuellen Datumswert im Date Placeholder.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **FAQ**

**Wirkt sich die Tatsache, dass eine Folie ausgeblendet ist, auf den Vergleich der Folien selbst aus?**

[Hidden status](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_hidden/) ist eine Präsentations-/Wiedergabe‑Ebene‑Eigenschaft, nicht visueller Inhalt. Die Gleichheit zweier bestimmter Folien wird durch ihre Struktur und statischen Inhalt bestimmt; die bloße Tatsache, dass eine Folie ausgeblendet ist, macht die Folien nicht unterschiedlich.

**Werden Hyperlinks und ihre Parameter berücksichtigt?**

Ja. Links sind Teil des statischen Inhalts einer Folie. Wenn die URL oder die Hyperlink‑Aktion abweicht, wird dies in der Regel als Unterschied im statischen Inhalt angesehen.

**Wenn ein Diagramm auf eine externe Excel‑Datei verweist, werden die Inhalte dieser Datei berücksichtigt?**

Nein. Der Vergleich erfolgt basierend auf den Folien selbst. Externe Datenquellen werden im Allgemeinen nicht zum Vergleichzeitpunkt gelesen; es wird nur das berücksichtigt, was in der Struktur und dem statischen Zustand der Folie vorhanden ist.