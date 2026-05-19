---
title: Verwalten von Tags und benutzerdefinierten Daten in Präsentationen mit C++
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/cpp/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- Tag hinzufügen
- Paarwerte
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags & benutzerdefinierte Daten in Aspose.Slides für C++ hinzufügen, lesen, aktualisieren und entfernen, mit Beispielen für PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Er gibt einen kurzen Überblick darüber, wie Daten in PPTX‑Dateien gespeichert werden, weist darauf hin, dass präsentationsspezifische Daten als Tags und benutzerdefinierte XML‑Teile existieren können, und beschreibt Tags als Schlüssel‑Wert‑Zeichenkettenpaare.

Er zeigt außerdem, wie Tag‑Werte ausgelesen und wie Tags zu einer Präsentation, einer einzelnen Folie oder einer Form hinzugefügt werden können. Darüber hinaus behandelt der Artikel gängige Tag‑Verwaltungsaufgaben wie das Löschen aller Tags, das Entfernen eines Tags nach Namen und das Abrufen der Liste von Tag‑Namen.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien — Dateien mit der Endung .pptx — werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Das Office Open XML‑Format definiert die Struktur für Daten in Präsentationen.

Da eine *Folie* eines der Elemente in Präsentationen ist, enthält ein *Folienteil* den Inhalt einer einzelnen Folie. Ein Folienteil darf explizite Beziehungen zu vielen Teilen haben — wie benutzerdefinierten Tags — die nach ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/itagcollection/)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/icustomxmlpartcollection/)) existieren.

{{% alert color="primary" %}} 
Tags sind im Wesentlichen Schlüssel‑Wert‑Zeichenkettenpaare. 
{{% /alert %}} 

## **Werte von Tags abrufen**

In Slides entspricht ein Tag der Eigenschaft IDocumentProperties.Keywords. Dieser Beispielcode zeigt, wie Sie den Wert eines Tags mit Aspose.Slides für C++ für [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) abrufen:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- dem Namen einer benutzerdefinierten Eigenschaft — `MyTag`
- dem Wert der benutzerdefinierten Eigenschaft — `My Tag Value`

Wenn Sie Präsentationen nach einer bestimmten Regel oder Eigenschaft klassifizieren möchten, können Sie von Tags profitieren. Beispielsweise können Sie alle Präsentationen aus nordamerikanischen Ländern mit einem Tag „North American“ versehen und die jeweiligen Länder (USA, Mexiko und Kanada) als Werte zuweisen.

Dieser Beispielcode zeigt, wie Sie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) mit Aspose.Slides für C++ hinzufügen:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Tags können auch für [Slide](https://reference.aspose.com/slides/de/cpp/aspose.slides/slide/) gesetzt werden:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Oder für jede einzelne [Shape](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Einschränkungen**

Tags, die über die benutzerdefinierte Datentag‑Sammlung mit `get_CustomData()->get_Tags()` hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation als PDF exportiert wird. Daher kann ein als Tag zugewiesener benutzerdefinierter Bezeichner nicht aus dem getaggten PDF abgerufen werden.

**Umgehungslösung**: Sie können einen benutzerdefinierten Bezeichner im **Alt‑Text** des Objekts speichern (z. B. `shape->set_AlternativeText(u"MyId")`). Nach dem Exportieren nach PDF kann der Alt‑Text in der PDF‑Tag‑Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Schritt entfernen?**

Ja. Die [Tag‑Sammlung](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag nach seinem Namen, ohne die gesamte Sammlung zu iterieren?**

Verwenden Sie die [Remove(name)](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/remove/)‑Methode der [TagCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu entfernen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [GetNamesOfTags](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/getnamesoftags/) auf der [Tag‑Sammlung](https://reference.aspose.com/slides/de/cpp/aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.