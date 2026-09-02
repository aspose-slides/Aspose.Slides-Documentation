---
title: Verwalten von Präsentationseigenschaften in C++
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/cpp/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteneigenschaften
- integrierte Eigenschaften
- benutzerdefinierte Eigenschaften
- erweiterte Eigenschaften
- Eigenschaften verwalten
- Eigenschaften ändern
- Dokument-Metadaten
- Metadaten bearbeiten
- Korrektursprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Meistern Sie die Präsentationseigenschaften in Aspose.Slides für C++ und optimieren Sie Suche, Branding und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einführung**

Aspose.Slides unterstützt zwei Arten von Dokumenteneigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können einfach über die Aspose.Slides API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Präsentations‑Dokumenteneigenschaften über die [IDocumentProperties](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_document_properties)‑Schnittstelle. Eine Instanz dieser Schnittstelle wird von der [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_documentproperties/)‑Methode zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Note" %}}
Bitte beachten Sie, dass Sie keine Werte für die Felder **Application** und **Producer** festlegen können, da Aspose Ltd. und Aspose.Slides für C++ x.x.x in diesen Feldern angezeigt werden.
{{% /alert %}} 

## **Präsentationseigenschaften verwalten**

Microsoft PowerPoint bietet eine Funktion, um einigen Eigenschaften zu den Präsentationsdateien hinzuzufügen. Diese Dokumenteneigenschaften ermöglichen das Speichern nützlicher Informationen zusammen mit den Dokumenten (Präsentationsdateien). Es gibt zwei Arten von Dokumenteneigenschaften als folgt

- Systemdefinierte (Built-in) Eigenschaften
- Benutzerdefinierte (Custom) Eigenschaften

**Built-in**‑Eigenschaften enthalten allgemeine Informationen über das Dokument wie Dokumenttitel, Autorname, Dokumentstatistiken usw. **Custom**‑Eigenschaften sind solche, die von den Benutzern als **Name/Wert**‑Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für C++ können Entwickler die Werte von Built-in‑ und Custom‑Eigenschaften zugreifen und ändern. Microsoft PowerPoint 2007 ermöglicht das Verwalten der Dokumenteneigenschaften von Präsentationsdateien. Dazu klicken Sie einfach auf das Office‑Symbol und anschließend auf den Menüpunkt **Prepare | Properties | Advanced Properties** in Microsoft PowerPoint 2007. Nachdem Sie den Menüpunkt **Advanced Properties** gewählt haben, erscheint ein Dialog, in dem Sie die Dokumenteneigenschaften der PowerPoint‑Datei verwalten können. Im **Properties Dialog** sehen Sie mehrere Registerkarten wie **General, Summary, Statistics, Contents und Custom**. All diese Registerkarten ermöglichen die Konfiguration verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** dient zur Verwaltung benutzerdefinierter Eigenschaften der PowerPoint‑Dateien.

## **Zugriff auf Built-in‑Eigenschaften**

Diese vom Objekt **IDocumentProperties** bereitgestellten Eigenschaften umfassen: **Creator (Author)**, **Description**, **KeyWords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wird zwischen verschiedenen Erstellern geteilt?), **PresentationFormat**, **Subject** und **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Built-in‑Eigenschaften ändern**

Das Ändern der Built-in‑Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einem gewünschten Feld einen Zeichenkettenwert zuweisen und der Eigenschaftswert wird geändert. Im nachstehenden Beispiel wird gezeigt, wie die Built-in‑Dokumenteneigenschaften einer Präsentationsdatei geändert werden können.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Aspose.Slides für C++ ermöglicht es Entwicklern auch, benutzerdefinierte Werte für die Dokumenteneigenschaften einer Präsentation hinzuzufügen. Das folgende Beispiel zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation festgelegt werden.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanziieren der Presentation-Klasse
auto presentation = System::MakeObject<Presentation>();

// Abrufen der Dokumenteneigenschaften
auto documentProperties = presentation->get_DocumentProperties();

// Hinzufügen benutzerdefinierter Eigenschaften
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Abrufen des Eigenschaftsnamens an einem bestimmten Index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Entfernen der ausgewählten Eigenschaft
documentProperties->RemoveCustomProperty(getPropertyName);

// Speichern der Präsentation
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Zugriff auf und Ändern von benutzerdefinierten Eigenschaften**

Aspose.Slides für C++ ermöglicht es Entwicklern außerdem, auf die Werte benutzerdefinierter Eigenschaften zuzugreifen. Das nachstehende Beispiel zeigt, wie Sie alle diese benutzerdefinierten Eigenschaften einer Präsentation lesen und ändern können.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Korrektursprache festlegen**

Aspose.Slides stellt die [LanguageId](https://reference.aspose.com/slides/de/cpp/aspose.slides/baseportionformat/set_languageid/)‑Eigenschaft (exponiert durch die [PortionFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/portionformat/)‑Klasse) bereit, um die Korrektursprache für ein PowerPoint‑Dokument festzulegen. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint überprüft werden.

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
// setze die Id einer Korrektursprache

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Standardsprache festlegen**

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

// Überprüft die Sprache der ersten Portion
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live‑Beispiel**

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata) aus, um zu sehen, wie Sie über die Aspose.Slides API mit Dokumenteneigenschaften arbeiten:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine Built-in‑Eigenschaft aus einer Präsentation entfernen?**

Built-in‑Eigenschaften sind integraler Bestandteil einer Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern die jeweilige Eigenschaft dies zulässt, auf leer setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr vorhandener Wert durch den neuen überschrieben. Ein vorheriges Entfernen oder Prüfen der Eigenschaft ist nicht nötig, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**

Ja. Verwenden Sie [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) und anschließend [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Instanz zu erzeugen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/cpp/examine-presentation/) für ein vollständiges Reporting‑Beispiel und format‑spezifische Einschränkungen.