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
- Eingebaute Eigenschaften
- Benutzerdefinierte Eigenschaften
- Erweiterte Eigenschaften
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
description: "Verwalten Sie Präsentationseigenschaften in Aspose.Slides für C++ und optimieren Sie Suche, Markenbildung und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---

## **Zugriff auf Präsentationseigenschaften**

Wie bereits beschrieben, unterstützt Aspose.Slides für C++ zwei Arten von Dokumenteneigenschaften: **eingebaute** und **benutzerdefinierte** Eigenschaften. Entwickler können beide Arten von Eigenschaften über die Aspose.Slides‑C++‑API abrufen. Aspose.Slides für C++ stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties) bereit, die die Dokumenteneigenschaften einer Präsentationsdatei über die Methode [Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) repräsentiert. Entwickler können die durch das **Presentation**‑Objekt bereitgestellte Methode [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) verwenden, um die Dokumenteneigenschaften von Präsentationsdateien wie unten beschrieben zu erhalten:

{{% alert color="primary" %}} 

Bitte beachten Sie, dass Sie die Felder **Application** und **Producer** nicht setzen können, da Aspose Ltd. und Aspose.Slides für C++ x.x.x in diesen Feldern angezeigt werden.

{{% /alert %}} 

Microsoft PowerPoint bietet die Möglichkeit, einigen Präsentationsdateien Eigenschaften hinzuzufügen. Diese Dokumenteneigenschaften ermöglichen das Speichern nützlicher Informationen zusammen mit den Dokumenten (Präsentationsdateien). Es gibt die folgenden zwei Arten von Dokumenteneigenschaften:

- Systemdefinierte (eingebaute) Eigenschaften  
- Benutzerdefinierte (eigene) Eigenschaften  

**Eingebaute** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie Dokumenttitel, Autorname, Dokumentstatistiken usw. **Benutzerdefinierte** Eigenschaften sind vom Benutzer als **Name/Wert**‑Paare definiert, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für C++ können Entwickler sowohl eingebaute als auch benutzerdefinierte Eigenschaften lesen und ändern. Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteneigenschaften von Präsentationsdateien. Klicken Sie dazu einfach auf das Office‑Symbol und anschließend auf **Prepare | Properties | Advanced Properties** in Microsoft PowerPoint 2007. Nach der Auswahl von **Advanced Properties** erscheint ein Dialog, in dem Sie die Dokumenteneigenschaften der PowerPoint‑Datei verwalten können. Im **Properties Dialog** sehen Sie mehrere Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Alle diese Registerkarten erlauben die Konfiguration verschiedener Informationsarten zu den PowerPoint‑Dateien. Die Registerkarte **Custom** dient zur Verwaltung benutzerdefinierter Eigenschaften der PowerPoint‑Dateien.

## **Zugriff auf eingebaute Eigenschaften**

Die von dem **IDocumentProperties**‑Objekt bereitgestellten Eigenschaften umfassen: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Letztes Druckdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wird zwischen verschiedenen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Eingebaute Eigenschaften ändern**

Das Ändern der eingebauten Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einem gewünschten Property einen Zeichenkettenwert zuweisen und der Wert wird geändert. Im nachfolgenden Beispiel zeigen wir, wie man die eingebauten Dokumenteneigenschaften einer Präsentationsdatei ändern kann.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Aspose.Slides für C++ ermöglicht Entwicklern zudem das Hinzufügen benutzerdefinierter Werte zu den Dokumenteneigenschaften einer Präsentation. Das folgende Beispiel zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation gesetzt werden können.
``` cpp
// Instanziieren der Presentation-Klasse
auto presentation = System::MakeObject<Presentation>();

// Abrufen der Dokumenteigenschaften
auto documentProperties = presentation->get_DocumentProperties();

// Hinzufügen benutzerdefinierter Eigenschaften
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Abrufen des Eigenschaftsnamens an einem bestimmten Index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Entfernen der ausgewählten Eigenschaft
documentProperties->RemoveCustomProperty(getPropertyName);

// Präsentation speichern
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```


## **Benutzerdefinierte Eigenschaften anzeigen und ändern**

Aspose.Slides für C++ erlaubt Entwicklern außerdem das Auslesen und Ändern benutzerdefinierter Eigenschaften. Das nachstehende Beispiel demonstriert, wie Sie alle benutzerdefinierten Eigenschaften einer Präsentation abrufen und ändern können.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Korrektursprache festlegen**

Aspose.Slides stellt die Eigenschaft [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides.baseportionformat/set_languageid/) (exponiert durch die Klasse [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)) bereit, mit der Sie die Korrektursprache für ein PowerPoint‑Dokument festlegen können. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik im PowerPoint geprüft werden.

Der folgende C++‑Code zeigt, wie Sie die Korrektursprache für ein PowerPoint‑Dokument setzen:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```


## **Standardsprache festlegen**

Der folgende C++‑Code zeigt, wie Sie die Standardsprache für eine gesamte PowerPoint‑Präsentation festlegen:
```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Fügt eine neue Rechteckform mit Text hinzu
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Überprüft die Sprache des ersten Abschnitts
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **Live‑Beispiel**

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) aus, um zu sehen, wie Sie mit Dokumenteneigenschaften über die Aspose.Slides‑API arbeiten können:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind integraler Bestandteil einer Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern die jeweilige Eigenschaft es zulässt, auf einen leeren Wert setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft hinzugefügt, wird ihr vorhandener Wert durch den neuen überschrieben. Ein vorheriges Entfernen oder Prüfen der Eigenschaft ist nicht erforderlich, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich Präsentationseigenschaften abrufen, ohne die gesamte Präsentation zu laden?**

Ja. Sie können Präsentationseigenschaften abrufen, ohne die gesamte Präsentation zu laden, indem Sie die Methode `GetPresentationInfo` der Klasse [PresentationFactory](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/) verwenden. Anschließend nutzen Sie die Methode `ReadDocumentProperties` des Interfaces [IPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/), um die Eigenschaften effizient auszulesen, Speicher zu sparen und die Leistung zu verbessern.