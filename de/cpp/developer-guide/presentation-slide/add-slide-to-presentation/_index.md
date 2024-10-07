---
title: Folie zur Präsentation hinzufügen
type: docs
weight: 10
url: /cpp/add-slide-to-presentation/
---

## **Folie zur Präsentation hinzufügen**
Bevor wir darüber sprechen, wie man Folien zu den Präsentationsdateien hinzufügt, lassen Sie uns einige Fakten über die Folien besprechen. Jede PowerPoint-Präsentationsdatei enthält Master-/Layoutfolie und andere Normalfolien. Das bedeutet, dass eine Präsentationsdatei mindestens eine oder mehrere Folien enthält. Es ist wichtig zu wissen, dass Präsentationsdateien ohne Folien von Aspose.Slides für C++ nicht unterstützt werden. Jede Folie hat eine eindeutige ID, und alle Normalfolien sind in einer Reihenfolge angeordnet, die durch den null-basierten Index angegeben wird. Aspose.Slides für C++ ermöglicht es Entwicklern, leere Folien zu ihrer Präsentation hinzuzufügen. Um eine leere Folie in die Präsentation einzufügen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Klasse, indem Sie eine Referenz auf die Slides (Sammlung von Inhalts-Slide-Objekten) Eigenschaft setzen, die vom Präsentationsobjekt bereitgestellt wird.
- Fügen Sie am Ende der Sammlung von Inhaltsfolien eine leere Folie zur Präsentation hinzu, indem Sie die von ISlideCollection-Objekt bereitgestellten AddEmptySlide-Methoden aufrufen.
- Führen Sie einige Arbeiten mit der neu hinzugefügten leeren Folie durch.
- Schreiben Sie schließlich die Präsentationsdatei mit dem [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Objekt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}