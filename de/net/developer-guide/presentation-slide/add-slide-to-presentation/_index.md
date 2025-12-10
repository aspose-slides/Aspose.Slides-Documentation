---
title: Folien zu Präsentationen in .NET hinzufügen
linktitle: Folie hinzufügen
type: docs
weight: 10
url: /de/net/add-slide-to-presentation/
keywords:
- Folie hinzufügen
- Folie erstellen
- leere Folie
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Fügen Sie Ihren PowerPoint- und OpenDocument-Präsentationen ganz einfach Folien hinzu mit Aspose.Slides für .NET – nahtloses, effizientes Einfügen von Folien in Sekundenschnelle."
---

## **Eine Folie zu einer Präsentation hinzufügen**
Bevor wir über das Hinzufügen von Folien zu den Präsentationsdateien sprechen, lassen Sie uns einige Fakten zu den Folien erläutern. Jede PowerPoint‑Präsentationsdatei enthält Master‑/Layout‑Folien und weitere Normal‑Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine Folie enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für .NET nicht unterstützt werden. Jede Folie hat eine eindeutige Id und alle Normal‑Folien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index angegeben wird. Aspose.Slides für .NET ermöglicht es Entwicklern, leere Folien zu ihrer Präsentation hinzuzufügen. Um eine leere Folie in die Präsentation einzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
- Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Klasse, indem Sie eine Referenz auf die Slides‑Eigenschaft (Sammlung von Inhalts‑Slide‑Objekten) des Presentation‑Objekts setzen.
- Fügen Sie mit der AddEmptySlide‑Methode, die vom ISlideCollection‑Objekt bereitgestellt wird, eine leere Folie am Ende der Inhalts‑Slide‑Sammlung hinzu.
- Arbeiten Sie mit der neu hinzugefügten leeren Folie.
- Schreiben Sie schließlich die Präsentationsdatei mithilfe des [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Objekts.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **FAQ**

**Kann ich eine neue Folie an einer bestimmten Position einfügen und nicht nur am Ende?**

Ja. Die Bibliothek unterstützt Folien‑Sammlungen und die [insert](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertclone/)-Operationen, sodass Sie eine Folie am gewünschten Index einfügen können, anstatt nur am Ende.

**Werden das Thema bzw. die Stile beibehalten, wenn ich eine Folie basierend auf einem Layout hinzufüge?**

Ja. Ein Layout erbt die Formatierung von seinem Master, und die neue Folie erbt vom ausgewählten Layout und dessen zugehörigem Master.

**Welche Folie ist in einer neuen „leeren“ Präsentation vorhanden, bevor Folien hinzugefügt werden?**

Eine neu erstellte Präsentation enthält bereits eine leere Folie mit Index 0. Das ist wichtig zu berücksichtigen, wenn Einfüge‑Indizes berechnet werden.

**Wie wähle ich das „richtige“ Layout für eine neue Folie, wenn der Master viele Optionen hat?**

Wählen Sie im Allgemeinen das [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/), das der gewünschten Struktur entspricht ([Titel und Inhalt, Zwei Inhalte usw.](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/)). Wenn ein solches Layout fehlt, können Sie es dem Master [add it to the master](/slides/de/net/slide-layout/) hinzufügen und anschließend verwenden.