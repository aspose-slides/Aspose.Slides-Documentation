---
title: Folie aus Präsentation entfernen
type: docs
weight: 30
url: /de/net/remove-slide-from-presentation/
keywords: "Folie entfernen, Folie löschen, PowerPoint, Präsentation, C#, Csharp, .NET, Aspose.Slides"
description: "Folie aus PowerPoint per Referenz oder Index in C# oder .NET entfernen"
---

Wenn eine Folie (oder ihr Inhalt) überflüssig wird, können Sie sie löschen. Aspose.Slides stellt die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse zur Verfügung, die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) kapselt, welche ein Repository für alle Folien in einer Präsentation ist. Durch Verwendung von Zeigern (Referenz oder Index) für ein bekanntes [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) Objekt können Sie die Folie angeben, die Sie entfernen möchten. 

## **Folie per Referenz entfernen**

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.  
1. Holen Sie sich eine Referenz der Folie, die Sie entfernen möchten, über deren ID oder Index.  
1. Entfernen Sie die referenzierte Folie aus der Präsentation.  
1. Speichern Sie die geänderte Präsentation. 

Dieser C#‑Code zeigt, wie Sie eine Folie über ihre Referenz entfernen:
```c#
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Greift über den Index in der Slides-Collection auf eine Folie zu
    ISlide slide = pres.Slides[0];

    // Entfernt eine Folie über ihre Referenz
    pres.Slides.Remove(slide);

    // Speichert die geänderte Präsentation
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Folie per Index entfernen**

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.  
1. Entfernen Sie die Folie aus der Präsentation über ihre Indexposition.  
1. Speichern Sie die geänderte Präsentation. 

Dieser C#‑Code zeigt, wie Sie eine Folie über ihren Index entfernen:
```c#
 // Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
 using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
 {
 
     // Entfernt eine Folie anhand ihres Indexes
     pres.Slides.RemoveAt(0);
 
     // Speichert die geänderte Präsentation
     pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```


## **Unbenutzte Layout‑Folie entfernen**

Aspose.Slides stellt die Methode [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (aus der Klasse [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) bereit, mit der Sie unerwünschte und nicht verwendete Layout‑Folien löschen können. Dieser C#‑Code zeigt, wie Sie eine Layout‑Folie aus einer PowerPoint‑Präsentation entfernen:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **Unbenutzte Master‑Folie entfernen**

Aspose.Slides stellt die Methode [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (aus der Klasse [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) bereit, mit der Sie unerwünschte und nicht verwendete Master‑Folien löschen können. Dieser C#‑Code zeigt, wie Sie eine Master‑Folie aus einer PowerPoint‑Präsentation entfernen:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Was passiert mit den Folien‑Indizes, nachdem ich eine Folie gelöscht habe?**

Nach dem Löschen reindiziert die [collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) : jede nachfolgende Folie verschiebt sich um eine Position nach links, sodass vorherige Indexzahlen veraltet sind. Wenn Sie eine stabile Referenz benötigen, verwenden Sie die dauerhafte ID jeder Folie anstelle ihres Indexes.

**Unterscheidet sich die ID einer Folie vom Index und ändert sie sich, wenn benachbarte Folien gelöscht werden?**

Ja. Der Index ist die Position der Folie und ändert sich, wenn Folien hinzugefügt oder entfernt werden. Die Folien‑ID ist ein permanenter Bezeichner und ändert sich nicht, wenn andere Folien gelöscht werden.

**Wie wirkt sich das Löschen einer Folie auf Folienabschnitte aus?**

Falls die Folie zu einem Abschnitt gehörte, enthält dieser Abschnitt einfach eine Folie weniger. Die Abschnittsstruktur bleibt erhalten; wenn ein Abschnitt leer wird, können Sie [Abschnitte entfernen oder neu organisieren](/slides/de/net/slide-section/) nach Bedarf.

**Was passiert mit Notizen und Kommentaren, die an einer Folie angehängt sind, wenn sie gelöscht wird?**

[Notes](/slides/de/net/presentation-notes/) und [comments](/slides/de/net/presentation-comments/) sind an diese spezifische Folie gebunden und werden zusammen mit ihr entfernt. Inhalte anderer Folien bleiben unverändert.

**Wie unterscheidet sich das Löschen von Folien vom Aufräumen ungenutzter Layouts/Master?**

Löschen entfernt bestimmte normale Folien aus der Präsentation. Das Aufräumen ungenutzter Layouts/Master entfernt Layout‑ oder Master‑Folien, auf die nichts verweist, wodurch die Dateigröße reduziert wird, ohne den Inhalt der verbleibenden Folien zu ändern. Diese Aktionen ergänzen sich: In der Regel zuerst löschen, anschließend aufräumen.