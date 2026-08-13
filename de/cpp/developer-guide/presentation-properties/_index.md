---
title: Verwalten von Präsentationseigenschaften in C++
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/cpp/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- eingebaute Eigenschaften
- benutzerdefinierte Eigenschaften
- erweiterte Eigenschaften
- Eigenschaften verwalten
- Eigenschaften ändern
- Dokumentmetadaten
- Metadaten bearbeiten
- Korrektursprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie Präsentationseigenschaften in Aspose.Slides für C++ und optimieren Sie Suche, Markenbildung und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einleitung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können problemlos über die Aspose.Slides API abgerufen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit den Präsentationsdokumenteigenschaften über das [IDocumentProperties](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_document_properties)-Interface. Eine Instanz dieses Interfaces wird von der Methode [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_documentproperties/) zurückgegeben. Die folgenden Beispiele zeigen, wie diese Eigenschaften gelesen, geändert und verwaltet werden können.

{{% alert color="info" %}} 
Bitte beachten Sie, dass Sie keine Werte für die Felder **Application** und **Producer** festlegen können, da Aspose Ltd. und Aspose.Slides für C++ x.x.x in diesen Feldern angezeigt werden.
{{% /alert %}} 

## **Verwalten von Präsentationseigenschaften**

Microsoft PowerPoint bietet eine Funktion, um einige Eigenschaften zu den Präsentationsdateien hinzuzufügen. Diese Dokumenteigenschaften ermöglichen das Speichern nützlicher Informationen zusammen mit den Dokumenten (Präsentationsdateien). Es gibt zwei Arten von Dokumenteigenschaften wie folgt

- Systemdefinierte (Built-in) Eigenschaften
- Benutzerdefinierte (Custom) Eigenschaften

**Built-in**‑Eigenschaften enthalten allgemeine Informationen über das Dokument, wie Dokumenttitel, Namen des Autors, Dokumentstatistiken usw. **Custom**‑Eigenschaften sind solche, die von Benutzern als **Name/Value**‑Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für C++ können Entwickler sowohl die Werte integrierter Eigenschaften als auch benutzerdefinierter Eigenschaften abrufen und ändern. Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Dafür müssen Sie lediglich das Office‑Symbol anklicken und anschließend den Menüpunkt **Prepare | Properties | Advanced Properties** in Microsoft PowerPoint 2007 auswählen. Nachdem Sie den Menüpunkt **Advanced Properties** gewählt haben, erscheint ein Dialog, der die Verwaltung der Dokumenteigenschaften der PowerPoint‑Datei ermöglicht. Im **Properties Dialog** sehen Sie mehrere Registerkarten wie **General, Summary, Statistics, Contents und Custom**. All diese Registerkarten erlauben das Konfigurieren verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um benutzerdefinierte Eigenschaften der PowerPoint‑Dateien zu verwalten.

## **Zugriff auf Built-in‑Eigenschaften**

Diese Eigenschaften, die vom **IDocumentProperties**‑Objekt bereitgestellt werden, umfassen: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **Keywords**, **SharedDoc** (Ist zwischen verschiedenen Produzenten freigegeben?), **PresentationFormat**, **Subject** und **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Built-in‑Eigenschaften ändern**

Das Ändern der integrierten Eigenschaften von Präsentationsdateien ist genauso einfach wie deren Zugriff. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen und der Eigenschaftswert wird geändert. Im nachfolgenden Beispiel haben wir gezeigt, wie wir die integrierten Dokumenteigenschaften der Präsentationsdatei ändern können.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Aspose.Slides für C++ ermöglicht Entwicklern zudem das Hinzufügen benutzerdefinierter Werte für die Dokumenteigenschaften einer Präsentation. Ein Beispiel wird unten gezeigt, das demonstriert, wie benutzerdefinierte Eigenschaften für eine Präsentation festgelegt werden.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanziiere die Presentation-Klasse
auto presentation = System::MakeObject<Presentation>();

// Abrufen der Dokumenteigenschaften
auto documentProperties = presentation->get_DocumentProperties();

// Hinzufügen benutzerdefinierter Eigenschaften
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Abrufen des Eigenschaftsnames an einem bestimmten Index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Entfernen der ausgewählten Eigenschaft
documentProperties->RemoveCustomProperty(getPropertyName);

// Speichern der Präsentation
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Zugriff auf benutzerdefinierte Eigenschaften und deren Änderung**

Aspose.Slides für C++ ermöglicht Entwicklern außerdem den Zugriff auf die Werte benutzerdefinierter Eigenschaften. Ein Beispiel wird unten gezeigt, wie Sie alle diese benutzerdefinierten Eigenschaften einer Präsentation abrufen und ändern können.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Korrektursprache festlegen**

Aspose.Slides stellt die Eigenschaft [LanguageId](https://reference.aspose.com/slides/de/cpp/aspose.slides/baseportionformat/set_languageid/) (bereitgestellt von der Klasse [PortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/portionformat/)) zur Verfügung, um die Korrektursprache für ein PowerPoint‑Dokument festzulegen. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

Dieser C++‑Code zeigt, wie die Korrektursprache für ein PowerPoint festgelegt wird:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// setzt die ID einer Korrektursprache

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Standard‑Sprache festlegen**

Dieser C++‑Code zeigt, wie die Standardsprache für eine gesamte PowerPoint‑Präsentation festgelegt wird:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Fügt eine neue Rechteckform mit Text hinzu
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Prüft die Sprache der ersten Portion
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live‑Beispiel**

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata) aus, um zu sehen, wie Sie mit Dokumenteigenschaften über die Aspose.Slides‑API arbeiten können:

[![Ansicht & Bearbeiten von PowerPoint‑Metadaten](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## ***FAQ**

### Wie kann ich eine integrierte Eigenschaft aus einer Präsentation entfernen?

Integrierte Eigenschaften sind ein wesentlicher Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch ihre Werte ändern oder, sofern die jeweilige Eigenschaft dies zulässt, auf leer setzen.

### Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?

Wenn Sie eine benutzerdefinierte Eigenschaft hinzufügen, die bereits existiert, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert der Eigenschaft automatisch aktualisiert.

### Kann ich Präsentationseigenschaften abrufen, ohne die Präsentation vollständig zu laden?

Ja, Sie können Präsentationseigenschaften abrufen, ohne die Präsentation vollständig zu laden, indem Sie die Methode `GetPresentationInfo` der Klasse [PresentationFactory](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentationfactory/) verwenden. Anschließend nutzen Sie die Methode `ReadDocumentProperties` des Interfaces [IPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/), um die Eigenschaften effizient zu lesen, Speicher zu sparen und die Leistung zu verbessern.