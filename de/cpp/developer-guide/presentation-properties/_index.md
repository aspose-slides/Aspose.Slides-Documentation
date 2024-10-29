---
title: Präsentationseigenschaften
type: docs
weight: 70
url: /de/cpp/presentation-properties/
---


## **Zugriff auf Präsentationseigenschaften**
Wie bereits beschrieben, unterstützt Aspose.Slides für C++ zwei Arten von Dokumenteigenschaften, nämlich **Integrierte** und **Benutzerdefinierte** Eigenschaften. Entwickler können beide Arten von Eigenschaften mit der Aspose.Slides für C++ API abrufen. Aspose.Slides für C++ bietet eine Klasse [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties), die die mit einer Präsentationsdatei verknüpften Dokumenteigenschaften über die Methode [Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) darstellt. Entwickler können die Methode [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) verwenden, die vom **Presentation**-Objekt bereitgestellt wird, um die Dokumenteigenschaften der Präsentationsdateien wie unten beschrieben abzurufen:

{{% alert color="primary" %}} 

Bitte beachten Sie, dass Sie die Werte für die Felder **Anwendung** und **Hersteller** nicht festlegen können, da dort Aspose Ltd. und Aspose.Slides für C++ x.x.x angezeigt werden.

{{% /alert %}} 


Microsoft PowerPoint bietet eine Funktion zum Hinzufügen einiger Eigenschaften zu den Präsentationsdateien. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (Integrierte) Eigenschaften
- Benutzerdefinierte (Eigene) Eigenschaften

**Integrierte** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie Dokumenttitel, Name des Autors, Dokumentstatistiken usw. **Benutzerdefinierte** Eigenschaften sind solche, die von den Benutzern als **Name/Wert**-Paare definiert sind, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für C++ können Entwickler die Werte von integrierten Eigenschaften sowie benutzerdefinierten Eigenschaften abrufen und ändern. Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften der Präsentationsdateien. Sie müssen lediglich auf das Office-Symbol klicken und dann den Menüpunkt **Vorbereiten | Eigenschaften | Erweiterte Eigenschaften** von Microsoft PowerPoint 2007 auswählen. Nachdem Sie den Menüpunkt **Erweiterte Eigenschaften** ausgewählt haben, erscheint ein Dialogfeld, das Ihnen ermöglicht, die Dokumenteigenschaften der PowerPoint-Datei zu verwalten. Im **Eigenschaften-Dialog** können Sie sehen, dass es viele Registerkarten gibt, wie **Allgemein, Zusammenfassung, Statistiken, Inhalt und Benutzerdefiniert**. Alle diese Registerkarten ermöglichen die Konfiguration verschiedener Arten von Informationen, die mit den PowerPoint-Dateien verbunden sind. Die Registerkarte **Benutzerdefiniert** wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint-Dateien zu verwalten.


## **Zugriff auf integrierte Eigenschaften**
Diese Eigenschaften, wie sie vom **IDocumentProperties**-Objekt bereitgestellt werden, umfassen: **Ersteller (Autor)**, **Beschreibung**, **Schlüsselwörter**, **Erstellt** (Erstellungsdatum), **Änderung** (Änderungsdatum), **Druckdatum** (Letzter Druckdatum), **Zuletzt geändert von**, **Schlüsselwörter**, **SharedDoc** (Ist es zwischen verschiedenen Produzenten geteilt?), **Präsentationsformat**, **Betreff** und **Titel**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}
## **Modifizieren integrierter Eigenschaften**
Die Modifizierung der integrierten Eigenschaften von Präsentationsdateien ist ebenso einfach wie deren Zugriff. Sie können einfach einem gewünschten Eigenschaften einen Stringwert zuweisen, und der Eigenschaftswert wird geändert. Im folgenden Beispiel haben wir demonstriert, wie wir die integrierten Dokumenteigenschaften der Präsentationsdatei ändern können.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**
Aspose.Slides für C++ ermöglicht es Entwicklern auch, benutzerdefinierte Werte für die Dokumenteigenschaften der Präsentation hinzuzufügen. Ein Beispiel wird unten angegeben, das zeigt, wie man die benutzerdefinierten Eigenschaften für eine Präsentation festlegt.

``` cpp
// Instanziieren der Präsentationsklasse
auto presentation = System::MakeObject<Presentation>();

// Abrufen der Dokumenteigenschaften
auto documentProperties = presentation->get_DocumentProperties();

// Hinzufügen von benutzerdefinierten Eigenschaften
documentProperties->idx_set(u"Neue Benutzerdefiniert", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"Mein Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Benutzerdefiniert", ObjectExt::Box<int32_t>(124));

// Abrufen des Eigenschaftsnamen an einem bestimmten Index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Entfernen der ausgewählten Eigenschaft
documentProperties->RemoveCustomProperty(getPropertyName);

// Speichern der Präsentation
presentation->Save(u"BenutzerdefinierteDokumenteigenschaften_out.pptx", SaveFormat::Pptx);
```

## **Zugriff auf und Modifizieren von benutzerdefinierten Präsentationseigenschaften**
Aspose.Slides für C++ ermöglicht es Entwicklern auch, die Werte der benutzerdefinierten Eigenschaften abzurufen. Ein Beispiel wird unten angegeben, das zeigt, wie Sie auf all diese benutzerdefinierten Eigenschaften für eine Präsentation zugreifen und sie ändern können.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}


## **Überprüfen, ob die Präsentation geändert oder erstellt wurde**
Aspose.Slides für C++ bietet eine Funktion, um zu überprüfen, ob eine Präsentation geändert oder erstellt wurde. Ein Beispiel wird unten angegeben, das zeigt, wie man überprüfen kann, ob die Präsentation erstellt oder geändert wurde.

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"props.pptx");

auto props = info->ReadDocumentProperties();

String app = props->get_NameOfApplication();
String ver = props->get_AppVersion();
```

## **Proofing-Sprache festlegen**

Aspose.Slides bietet die [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) Eigenschaft (bereitgestellt durch die [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) Klasse), um Ihnen zu ermöglichen, die Proofing-Sprache für ein PowerPoint-Dokument festzulegen. Die Proofing-Sprache ist die Sprache, für die die Rechtschreibung und Grammatik in PowerPoint überprüft werden.

Dieser C++-Code zeigt, wie Sie die Proofing-Sprache für ein PowerPoint festlegen:

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
// setze die ID einer Proofing-Sprache

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Standard-Sprache festlegen**

Dieser C++-Code zeigt, wie Sie die Standardsprache für eine gesamte PowerPoint-Präsentation festlegen:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Fügt eine neue rechteckige Form mit Text hinzu
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"Neuer Text");

// Überprüft die Sprache des ersten Portions
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```