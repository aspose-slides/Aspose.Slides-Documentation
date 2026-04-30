---
title: Tags und benutzerdefinierte Daten in Präsentationen mit .NET verwalten
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
description: "Erfahren Sie, wie Sie Tags & benutzerdefinierte Daten in Aspose.Slides für .NET hinzufügen, lesen, aktualisieren und entfernen, mit Beispielen für PowerPoint‑ und OpenDocument‑Präsentationen."
---
## **Überblick**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Er gibt einen kurzen Überblick darüber, wie Daten in PPTX‑Dateien gespeichert werden, weist darauf hin, dass präsentationsspezifische Daten als Tags und benutzerdefinierte XML‑Teile existieren können, und beschreibt Tags als Schlüssel‑Wert‑Zeichenfolgenpaare.

Er zeigt außerdem, wie Tag‑Werte ausgelesen und wie Tags zu einer Präsentation, einer einzelnen Folie oder einer Form hinzugefügt werden können. Zusätzlich behandelt der Artikel gängige Tag‑Verwaltungsaufgaben wie das Löschen aller Tags, das Entfernen eines Tags nach Namen und das Abrufen der Liste von Tag‑Namen.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien – Elemente mit der Endung .pptx – werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Das Office Open XML‑Format definiert die Struktur für Daten, die in Präsentationen enthalten sind. 

Da eine *Folie* eines der Elemente in Präsentationen ist, enthält ein *Folienteil* den Inhalt einer einzelnen Folie. Ein Folienteil darf explizite Beziehungen zu vielen Teilen haben – z. B. zu benutzerdefinierten Tags – die nach ISO/IEC 29500 definiert sind. 

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/de/net/aspose.slides/itagcollection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpartcollection)) existieren. 

{{% alert color="primary" %}} 

Tags sind im Wesentlichen Schlüssel‑Wert‑Paare von Zeichenfolgen. 

{{% /alert %}} 

## **Werte von Tags abrufen**

In Slides entspricht ein Tag der Eigenschaft IDocumentProperties.Keywords. Dieser Beispielcode zeigt, wie Sie den Wert eines Tags mit Aspose.Slides für .NET für [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) erhalten:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- der Name einer benutzerdefinierten Eigenschaft – `MyTag` 
- der Wert der benutzerdefinierten Eigenschaft – `My Tag Value`

Wenn Sie einige Präsentationen nach einer bestimmten Regel oder Eigenschaft klassifizieren müssen, kann das Hinzufügen von Tags zu diesen Präsentationen von Nutzen sein. Beispielsweise können Sie, wenn Sie alle Präsentationen aus nordamerikanischen Ländern zusammenfassen möchten, einen „North American“-Tag erstellen und die entsprechenden Länder (USA, Mexiko und Kanada) als Werte zuweisen. 

Dieser Beispielcode zeigt, wie Sie mit Aspose.Slides für .NET ein Tag zu einer [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) hinzufügen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Tags können auch für [Slide](https://reference.aspose.com/slides/de/net/aspose.slides/slide) festgelegt werden:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Oder für eine einzelne [Shape](https://reference.aspose.com/slides/de/net/aspose.slides/shape):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Einschränkungen**

Tags, die über die `CustomData.Tags`‑Sammlung hinzugefügt werden, werden nur innerhalb der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation in PDF exportiert wird. Folglich kann ein als Tag zugewiesener benutzerdefinierter Bezeichner nicht aus dem getaggten PDF abgerufen werden.

**Umgehungslösung**: Sie können einen benutzerdefinierten Bezeichner im **Alt‑Text** des Objekts speichern (z. B. `shape.AlternativeText = "MyId"`). Nach dem Exportieren nach PDF kann der Alt‑Text in der PDF‑Tag‑Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags einer Präsentation, Folie oder Form in einem Schritt entfernen?**

Ja. Die [Tag‑Sammlung](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag nach seinem Namen, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie die [Remove(name)](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/remove/)‑Operation auf der [TagCollection](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/), um das Tag nach seinem Schlüssel zu entfernen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [GetNamesOfTags](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/getnamesoftags/) auf der [Tag‑Sammlung](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.