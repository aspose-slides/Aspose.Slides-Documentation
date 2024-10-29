---
title: Folie zur Präsentation hinzufügen
type: docs
weight: 10
url: /de/net/add-slide-to-presentation/
keywords: "Folie zur Präsentation hinzufügen, C#, Csharp, .NET, Aspose.Slides"
description: "Folie zur Präsentation in C# oder .NET hinzufügen"
---

## **Folie zur Präsentation hinzufügen**
Bevor wir darüber sprechen, wie Folien zu den Präsentationsdateien hinzugefügt werden, lassen Sie uns einige Fakten über Folien diskutieren. Jede PowerPoint-Präsentationsdatei enthält Master- / Layoutfolie und andere normale Folien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für .NET nicht unterstützt werden. Jede Folie hat eine eindeutige ID und alle normalen Folien sind in einer Reihenfolge angeordnet, die durch den nullbasierten Index angegeben ist. Aspose.Slides für .NET ermöglicht es Entwicklern, leere Folien zu ihrer Präsentation hinzuzufügen. Um eine leere Folie in die Präsentation einzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Klasse, indem Sie eine Referenz zur Slides (Sammlung von Inhaltsfolienobjekten) Eigenschaft setzen, die vom Presentation-Objekt bereitgestellt wird.
- Fügen Sie am Ende der Inhaltsfolien-Sammlung eine leere Folie zur Präsentation hinzu, indem Sie die von ISlideCollection-Objekt bereitgestellten AddEmptySlide-Methoden aufrufen.
- Führen Sie einige Arbeiten mit der neu hinzugefügten leeren Folie durch.
- Schreiben Sie schließlich die Präsentationsdatei mit dem [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}