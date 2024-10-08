---
title: Tags und benutzerdefinierte Daten verwalten
type: docs
weight: 300
url: /de/cpp/managing-tags-and-custom-data

---

## Datenspeicher in Präsentationsdateien

PPTX-Dateien—Elemente mit der .pptx-Erweiterung—werden im Präsentations-ML-Format gespeichert, das Teil der Office Open XML-Spezifikation ist. Das Office Open XML-Format definiert die Struktur für Daten, die in Präsentationen enthalten sind. 

Mit einem *Folien* als eines der Elemente in Präsentationen enthält ein *Folienpart* den Inhalt einer einzelnen Folie. Ein Folienpart darf explizite Beziehungen zu vielen Teilen haben—wie Benutzerdefinierte Tags—die durch ISO/IEC 29500 definiert sind. 

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_tag_collection)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_custom_xml_part_collection)) existieren. 

{{% alert color="primary" %}} 

Tags sind im Wesentlichen Schlüssel-Wert-Paarwerte. 

{{% /alert %}} 

## Abrufen der Werte für Tags

In Folien entspricht ein Tag der IDocumentProperties.Keywords-Eigenschaft. Dieser Beispielcode zeigt Ihnen, wie Sie den Wert eines Tags mit Aspose.Slides für C++ für [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) abrufen:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## Hinzufügen von Tags zu Präsentationen

Aspose.Slides ermöglicht es Ihnen, Tags zu Präsentationen hinzuzufügen. Ein Tag besteht typischerweise aus zwei Elementen: 

- dem Namen einer benutzerdefinierten Eigenschaft - `MyTag` 
- dem Wert der benutzerdefinierten Eigenschaft - `My Tag Value`

Wenn Sie einige Präsentationen basierend auf einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie davon profitieren, Tags zu diesen Präsentationen hinzuzufügen. Wenn Sie beispielsweise alle Präsentationen aus nordamerikanischen Ländern kategorisieren oder zusammenfassen möchten, können Sie ein nordamerikanisches Tag erstellen und dann die relevanten Länder (die USA, Mexiko und Kanada) als Werte zuweisen. 

Dieser Beispielcode zeigt Ihnen, wie Sie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) mit Aspose.Slides für C++ hinzufügen:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Tags können auch für [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) gesetzt werden:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Oder für jede einzelne [Shape](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```