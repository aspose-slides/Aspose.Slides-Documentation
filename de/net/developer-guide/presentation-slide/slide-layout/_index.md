---
title: Folienlayout in C# anwenden oder ändern
linktitle: Folienlayout
type: docs
weight: 60
url: /de/net/slide-layout/
keywords:
- Folienlayout
- Inhaltslayout
- Platzhalter
- Präsentationsdesign
- Foliendesign
- unbenutztes Layout
- Fußzeilensichtbarkeit
- Titelfolie
- Titel und Inhalt
- Abschnittsüberschrift
- Zwei Inhalte
- Vergleich
- Nur Titel
- Leeres Layout
- Inhalt mit Beschriftung
- Bild mit Beschriftung
- Titel und vertikaler Text
- Vertikaler Titel und Text
- C#
- .NET
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folienlayouts in Aspose.Slides für .NET verwalten und anpassen. Erkunden Sie Layout‑Typen, die Steuerung von Platzhaltern, die Sichtbarkeit von Fußzeilen und die Manipulation von Layouts anhand von Code‑Beispielen in C#."
---

## **Übersicht**

Ein Folienlayout definiert die Anordnung von Platzhalterfeldern und die Formatierung des Inhalts einer Folie. Es steuert, welche Platzhalter verfügbar sind und wo sie erscheinen. Folienlayouts helfen Ihnen, Präsentationen schnell und konsistent zu entwerfen – egal, ob Sie etwas Einfaches oder Komplexeres erstellen. Zu den häufigsten Folienlayouts in PowerPoint gehören:

**Titel‑Folie‑Layout** – Enthält zwei Textplatzhalter: einen für den Titel und einen für den Untertitel.

**Titel‑und‑Inhalt‑Layout** – Verfügt über einen kleineren Titelplatzhalter oben und einen größeren darunter für Hauptinhalt (wie Text, Aufzählungen, Diagramme, Bilder und mehr).

**Leeres Layout** – Enthält keine Platzhalter, sodass Sie die Folie von Grund auf selbst gestalten können.

Folienlayouts sind Teil eines Folienmasters, der die übergeordnete Folie ist, die Layout‑Stile für die Präsentation definiert. Sie können Layout‑Folien über den Folienmaster – nach Typ, Name oder eindeutiger ID – zugreifen und ändern. Alternativ können Sie ein bestimmtes Layout‑Folie‑Element direkt in der Präsentation bearbeiten.

Um mit Folienlayouts in Aspose.Slides für .NET zu arbeiten, können Sie verwenden:

- Eigenschaften wie [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) und [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) in der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)
- Typen wie [ILayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/) und [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

Um mehr über die Arbeit mit Folienmastern zu erfahren, lesen Sie den Artikel [Slide Master](/slides/de/net/slide-master/).

{{% /alert %}}

## **Folienlayouts zu Präsentationen hinzufügen**

Um das Aussehen und die Struktur Ihrer Folien anzupassen, müssen Sie möglicherweise neue Layout‑Folien zu einer Präsentation hinzufügen. Aspose.Slides für .NET ermöglicht es Ihnen, zu prüfen, ob ein bestimmtes Layout bereits existiert, bei Bedarf ein neues hinzuzufügen und es zum Einfügen von Folien zu verwenden, die auf diesem Layout basieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Greifen Sie auf die [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/) zu.
1. Prüfen Sie, ob die gewünschte Layout‑Folie bereits in der Sammlung vorhanden ist. Wenn nicht, fügen Sie das benötigte Layout hinzu.
1. Fügen Sie eine leere Folie basierend auf dem neuen Layout ein.
1. Speichern Sie die Präsentation.

Der folgende C#‑Code demonstriert, wie ein Folienlayout zu einer PowerPoint‑Präsentation hinzugefügt wird:
```cs
// Instanziiert die Presentation-Klasse, die eine PowerPoint-Datei repräsentiert.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Durchläuft die Layout-Foliensortentypen, um eine Layout-Folie auszuwählen.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Eine Situation, in der die Präsentation nicht alle Layout-Typen enthält.
        // Die Präsentationsdatei enthält nur die Layout-Typen Blank und Custom.
        // Allerdings können Layout-Folien mit benutzerdefinierten Typen erkennbare Namen haben,
        // wie "Title", "Title and Content" usw., die für die Auswahl einer Layout-Folie verwendet werden können.
        // Man kann sich auch auf eine Menge von Platzhalter-Shape-Typen verlassen.
        // Zum Beispiel sollte eine Titelfolie nur den Title-Platzhaltertyp haben, usw.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Fügt eine leere Folie mit dem hinzugefügten Layout ein.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Speichert die Präsentation auf dem Datenträger.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Unbenutzte Layout‑Folien entfernen**

Aspose.Slides bietet die Methode [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) aus der Klasse [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) an, um unerwünschte und ungenutzte Layout‑Folien zu löschen.

Der folgende C#‑Code zeigt, wie eine Layout‑Folie aus einer PowerPoint‑Präsentation entfernt wird:
```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Platzhalter zu Folienlayouts hinzufügen**

Aspose.Slides stellt die Eigenschaft [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/placeholdermanager/) bereit, mit der Sie neue Platzhalter zu einer Layout‑Folie hinzufügen können.

Dieser Manager enthält Methoden für die folgenden Platzhalter‑Typen:

| PowerPoint‑Platzhalter              | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/)‑Methode |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Inhalt](content.png)             | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Inhalt (vertikal)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (vertikal)](textV.png)       | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Bild](picture.png)                | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagramm](chart.png)              | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tabelle](table.png)               | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Medien](media.png)                | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online‑Bild](onlineimage.png)    | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Der folgende C#‑Code demonstriert, wie neue Platzhalterformen zum leeren Layout‑Folie‑Element hinzugefügt werden:
```cs
using (var presentation = new Presentation())
{
    // Hole die Blank-Layout-Folie.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Hole den Platzhalter-Manager der Layout-Folie.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Füge verschiedene Platzhalter zur Blank-Layout-Folie hinzu.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Füge eine neue Folie mit dem Blank-Layout hinzu.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Die Platzhalter auf der Layout‑Folie](add_placeholders.png)

## **Fußzeilen‑Sichtbarkeit für ein Layout‑Folie festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text je nach Folienlayout ein- oder ausgeblendet werden. Aspose.Slides für .NET ermöglicht die Steuerung der Sichtbarkeit dieser Fußzeilen‑Platzhalter. Das ist nützlich, wenn bestimmte Layouts Fußzeileninformationen anzeigen sollen, während andere minimal bleiben.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Holen Sie sich eine Layout‑Folie‑Referenz anhand ihres Index.
1. Setzen Sie den Fußzeilen‑Platzhalter der Folie auf sichtbar.
1. Setzen Sie den Folien‑Nummer‑Platzhalter auf sichtbar.
1. Setzen Sie den Datum‑Uhrzeit‑Platzhalter auf sichtbar.
1. Speichern Sie die Präsentation.

Der folgende C#‑Code zeigt, wie die Sichtbarkeit einer Folienfußzeile eingestellt wird:
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```


## **Fußzeilen‑Sichtbarkeit für untergeordnete Folien festlegen**

​In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text auf Master‑Folien‑Ebene gesteuert werden, um Konsistenz über alle Layout‑Folien hinweg sicherzustellen. Aspose.Slides für .NET ermöglicht das Festlegen von Sichtbarkeit und Inhalt dieser Fußzeilen‑Platzhalter auf dem Master‑Folie und das Propagieren dieser Einstellungen zu allen untergeordneten Layout‑Folien. Dieser Ansatz sorgt für einheitliche Fußzeileninformationen in der gesamten Präsentation.​

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf die Master‑Folie anhand ihres Index.
1. Setzen Sie die Fußzeilen‑Platzhalter des Masters und aller untergeordneten Folien auf sichtbar.
1. Setzen Sie die Folien‑Nummer‑Platzhalter des Masters und aller untergeordneten Folien auf sichtbar.
1. Setzen Sie die Datum‑Uhrzeit‑Platzhalter des Masters und aller untergeordneten Folien auf sichtbar.
1. Speichern Sie die Präsentation.

Der folgende C#‑Code demonstriert diesen Vorgang:
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Was ist der Unterschied zwischen einer Master‑Folie und einer Layout‑Folie?**

Eine Master‑Folie definiert das gesamte Design und die Standardformatierung, während Layout‑Folien bestimmte Anordnungen von Platzhaltern für verschiedene Inhaltsarten festlegen.

**Kann ich eine Layout‑Folie von einer Präsentation in eine andere kopieren?**

Ja, Sie können eine Layout‑Folie aus der [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/)‑Sammlung einer Präsentation klonen und mit der Methode `AddClone` in eine andere einfügen.

**Was passiert, wenn ich eine Layout‑Folie lösche, die noch von einer Folie verwendet wird?**

Versuchen Sie, eine Layout‑Folie zu löschen, die von mindestens einer Folie in der Präsentation referenziert wird, wirft Aspose.Slides eine [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception/). Um das zu vermeiden, verwenden Sie [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/), das sicher nur ungenutzte Layout‑Folien entfernt.