---
title: Tags und benutzerdefinierte Daten in Präsentationen in .NET verwalten
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/net/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- Tag hinzufügen
- Paarwerte
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte Daten in Aspose.Slides für .NET hinzufügen, lesen, aktualisieren und entfernen, mit Beispielen für PowerPoint- und OpenDocument-Präsentationen."
---

## **Datenablage in Präsentationsdateien**

PPTX‑Dateien — Dateien mit der Endung .pptx — werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Das Office Open XML‑Format definiert die Struktur der in Präsentationen enthaltenen Daten. 

Da eine *Folie* eines der Elemente in Präsentationen ist, enthält ein *Folienteil* den Inhalt einer einzelnen Folie. Ein Folienteil darf explizite Beziehungen zu vielen Teilen haben — wie z. B. benutzerdefinierten Tags — wie in ISO/IEC 29500 definiert. 

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)) vorliegen. 

{{% alert color="primary" %}} 
Tags sind im Wesentlichen Schlüssel‑Wert‑Paare als Zeichenketten. 
{{% /alert %}} 

## **Abrufen der Werte für Tags**

In Folien entspricht ein Tag der Eigenschaft IDocumentProperties.Keywords. Dieser Beispielcode zeigt, wie Sie den Wert eines Tags mit Aspose.Slides für .NET für [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) abrufen:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```


## **Hinzufügen von Tags zu Präsentationen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen: 

- der Name einer benutzerdefinierten Eigenschaft - `MyTag` 
- der Wert der benutzerdefinierten Eigenschaft - `My Tag Value`

Wenn Sie einige Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, kann das Hinzufügen von Tags zu diesen Präsentationen hilfreich sein. Zum Beispiel können Sie, wenn Sie alle Präsentationen aus nordamerikanischen Ländern zusammenfassen möchten, einen Tag „North American“ erstellen und dann die jeweiligen Länder (USA, Mexiko und Kanada) als Werte zuweisen. 

Dieser Beispielcode zeigt, wie Sie mit Aspose.Slides für .NET einem [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) einen Tag hinzufügen:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```


Tags können auch für [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) gesetzt werden:
```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```


Oder für ein einzelnes [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape):
```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```


## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder einem Shape in einem Vorgang entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie die [Remove(name)](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/remove/)‑Operation auf der [TagCollection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterung abrufen?**

Verwenden Sie [GetNamesOfTags](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/getnamesoftags/) auf der [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.