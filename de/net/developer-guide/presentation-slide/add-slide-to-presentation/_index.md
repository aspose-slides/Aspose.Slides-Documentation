---
title: Folie zur Präsentation hinzufügen
type: docs
weight: 10
url: /de/net/add-slide-to-presentation/
keywords: "Folie zur Präsentation hinzufügen, C#, Csharp, .NET, Aspose.Slides"
description: "Folie zur Präsentation hinzufügen in C# oder .NET"
---

## **Folie zur Präsentation hinzufügen**
Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten über die Folien diskutieren. Jede PowerPoint‑Präsentationsdatei enthält Master‑/Layout‑Folien und weitere normale Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für .NET nicht unterstützt werden. Jede Folie hat eine eindeutige Id und alle normalen Folien werden in einer durch einen nullbasierten Index festgelegten Reihenfolge angeordnet. Aspose.Slides für .NET ermöglicht Entwicklern, leere Folien zu ihrer Präsentation hinzuzufügen. Um eine leere Folie zur Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection), indem Sie eine Referenz auf die Eigenschaft Slides (Sammlung von Inhalts‑Slide‑Objekten) setzen, die vom Presentation‑Objekt bereitgestellt wird.
- Fügen Sie eine leere Folie zur Präsentation am Ende der Sammlung von Inhalts‑Folien hinzu, indem Sie die von ISlideCollection bereitgestellten AddEmptySlide‑Methoden aufrufen.
- Arbeiten Sie mit der neu hinzugefügten leeren Folie.
- Schreiben Sie schließlich die Präsentationsdatei mithilfe des [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekts.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **FAQ**

**Kann ich eine neue Folie an einer bestimmten Position einfügen, nicht nur am Ende?**

Ja. Die Bibliothek unterstützt Folien‑Sammlungen sowie [insert](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertclone/)-Operationen, sodass Sie eine Folie an dem gewünschten Index einfügen können, anstatt nur am Ende.

**Werden das Thema/ die Stile beibehalten, wenn eine Folie basierend auf einem Layout hinzugefügt wird?**

Ja. Ein Layout übernimmt die Formatierung von seinem Master, und die neue Folie erbt vom ausgewählten Layout und dessen zugehörigem Master.

**Welche Folie ist in einer neuen „leeren“ Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit dem Index null. Dies ist bei der Berechnung von Einfüge‑Indizes zu berücksichtigen.

**Wie wähle ich das „richtige“ Layout für eine neue Folie, wenn der Master viele Optionen hat?**

Wählen Sie im Allgemeinen das [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/), das der erforderlichen Struktur entspricht ([Titel und Inhalt, Zwei Inhalte usw.](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/)). Wenn ein solches Layout fehlt, können Sie es dem Master [zum Master hinzufügen](/slides/de/net/slide-layout/) und dann verwenden.