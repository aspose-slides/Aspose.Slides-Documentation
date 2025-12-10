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
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte Daten in Aspose.Slides für C++ hinzufügen, lesen, aktualisieren und entfernen, mit Beispielen für PowerPoint- und OpenDocument-Präsentationen."
---

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien — Elemente mit der Erweiterung .pptx — werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Das Office Open XML‑Format definiert die Struktur der in Präsentationen enthaltenen Daten. 

Da eine *Folie* eines der Elemente in Präsentationen ist, enthält ein *Folienteil* den Inhalt einer einzelnen Folie. Ein Folienteil darf explizite Beziehungen zu vielen Teilen — wie benutzerdefinierten Tags — haben, die von ISO/IEC 29500 definiert sind. 

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_tag_collection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_custom_xml_part_collection)) existieren. 

{{% alert color="primary" %}} 

Tags sind im Wesentlichen Schlüssel‑Wert‑Paare aus Zeichenketten. 

{{% /alert %}} 

## **Werte von Tags abrufen**

In Folien entspricht ein Tag der Eigenschaft IDocumentProperties.Keywords. Dieser Beispielcode zeigt, wie Sie den Wert eines Tags mit Aspose.Slides für C++ für [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation):
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```


## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht es Ihnen, Tags zu Präsentationen hinzuzufügen. Ein Tag besteht typischerweise aus zwei Elementen: 

- der Name einer benutzerdefinierten Eigenschaft - `MyTag` 
- der Wert der benutzerdefinierten Eigenschaft - `My Tag Value`

Wenn Sie einige Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie davon profitieren, Tags zu diesen Präsentationen hinzuzufügen. Beispielsweise, wenn Sie alle Präsentationen aus nordamerikanischen Ländern zusammenfassen möchten, können Sie ein nordamerikanisches Tag erstellen und dann die entsprechenden Länder (USA, Mexiko und Kanada) als Werte zuweisen. 

Dieser Beispielcode zeigt, wie Sie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) mit Aspose.Slides für C++ hinzufügen:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```


Tags können auch für [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) festgelegt werden:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


Oder für ein einzelnes [Shape](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape):
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie löse ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie die [Remove(name)](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/remove/)‑Operation auf [TagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [GetNamesOfTags](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/getnamesoftags/) auf der [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.