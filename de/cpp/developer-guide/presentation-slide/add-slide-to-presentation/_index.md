---
title: Folien zu Präsentationen in C++ hinzufügen
linktitle: Folie hinzufügen
type: docs
weight: 10
url: /de/cpp/add-slide-to-presentation/
keywords:
- Folie hinzufügen
- Folie erstellen
- Leere Folie
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Fügen Sie mit Aspose.Slides für C++ ganz einfach Folien zu Ihren PowerPoint- und OpenDocument-Präsentationen hinzu - nahtlose, effiziente Folieneinfügung in Sekundenschnelle."
---

## **Eine Folie zu einer Präsentation hinzufügen**
Bevor wir über das Hinzufügen von Folien zu Präsentationsdateien sprechen, lassen Sie uns einige Fakten zu den Folien erläutern. Jede PowerPoint‑Präsentationsdatei enthält Master‑/Layout‑Folien und weitere normale Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für C++ nicht unterstützt werden. Jede Folie hat eine eindeutige Id und alle normalen Folien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index festgelegt wird. Aspose.Slides für C++ ermöglicht Entwicklern, leere Folien zu ihrer Präsentation hinzuzufügen. Um eine leere Folie in die Präsentation einzufügen, befolgen Sie bitte die unten aufgeführten Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
- Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)‑Klasse, indem Sie eine Referenz auf die Slides‑Eigenschaft (Sammlung von Inhalt‑Slide‑Objekten) des Presentation‑Objekts setzen.
- Fügen Sie eine leere Folie am Ende der Inhalt‑Slide‑Sammlung hinzu, indem Sie die AddEmptySlide‑Methoden des ISlideCollection‑Objekts aufrufen.
- Arbeiten Sie mit der neu hinzugefügten leeren Folie.
- Schreiben Sie schließlich die Präsentationsdatei mit dem [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Objekt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **FAQ**

**Kann ich eine neue Folie an einer bestimmten Position einfügen, nicht nur am Ende?**

Ja. Die Bibliothek unterstützt Folien‑Sammlungen und [insert](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertclone/)‑Operationen, sodass Sie eine Folie an dem gewünschten Index einfügen können, anstatt nur am Ende.

**Werden die Themen/Styles beim Hinzufügen einer Folie basierend auf einem Layout beibehalten?**

Ja. Ein Layout erbt die Formatierung von seinem Master, und die neue Folie erbt vom ausgewählten Layout und dem zugehörigen Master.

**Welche Folie ist in einer neuen "leeren" Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit Index 0. Dies ist bei der Berechnung von Einfüge‑Indizes zu berücksichtigen.

**Wie wähle ich das "richtige" Layout für eine neue Folie, wenn das Master‑Layout viele Optionen hat?**

Wählen Sie im Allgemeinen das [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/)‑Layout, das der gewünschten Struktur entspricht ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/cpp/aspose.slides/slidelayouttype/)). Wenn ein solches Layout fehlt, können Sie es dem Master [add it to the master](/slides/de/cpp/slide-layout/) hinzufügen und anschließend verwenden.