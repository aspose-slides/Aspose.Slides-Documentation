---
title: PowerPoint-Text in C++ formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/cpp/text-formatting/
keywords:
- Text hervorheben
- regulärer Ausdruck
- Absatz ausrichten
- Textstil
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schriftarteigenschaften
- Schriftfamilie
- Textrotation
- Rotationswinkel
- Textfeld
- Zeilenabstand
- Autofit-Eigenschaft
- Textfeldverankerung
- Texttabulatoren
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++. Passen Sie Schriftarten, Farben, Ausrichtungen und mehr an."
---

## **Text hervorheben**
Die neue **HighlightText**‑Methode wurde zu den Klassen **ITextFrame** und **TextFrame** hinzugefügt. Sie ermöglicht es, einen Textteil mit Hintergrundfarbe zu markieren, indem ein Textbeispiel verwendet wird, ähnlich dem Werkzeug **Text Highlight Color** in PowerPoint 2019.

Der folgende Code‑Schnipsel zeigt, wie diese Funktion verwendet wird:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 
Aspose bietet einen einfachen, [kostenlosen Online-PowerPoint‑Bearbeitungsservice](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Text mit regulären Ausdrücken hervorheben**
Die neue **HighlightRegex**‑Methode wurde zu den Klassen **ITextFrame** und **TextFrame** hinzugefügt. Sie ermöglicht es, einen Textteil mit Hintergrundfarbe zu markieren, indem ein regulärer Ausdruck verwendet wird, ähnlich dem Werkzeug **Text Highlight Color** in PowerPoint 2019.

Der folgende Code‑Schnipsel zeigt, wie diese Funktion verwendet wird:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **Text‑Hintergrundfarbe festlegen**

Aspose.Slides ermöglicht es, die gewünschte Hintergrundfarbe für Text festzulegen.

Dieser C++‑Code zeigt, wie man die Hintergrundfarbe für den gesamten Text festlegt:
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));
    auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    for (auto&& portion : portions)
    {
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Blue());
    }
    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```


Dieser C++‑Code zeigt, wie man die Hintergrundfarbe nur für einen Teil des Textes festlegt:
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));

	auto predicate = [](System::SharedPtr<IPortion> portion) -> bool {
        return portion->get_Text().Contains(u"Red");
	};

	auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    System::SharedPtr<IPortion> redPortion;
	for (auto&& portion : portions)
        if (predicate(portion))
            redPortion = portion;

    redPortion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Red());

    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```


## **Textabsätze ausrichten**
Die Textformatierung ist ein zentrales Element beim Erstellen von Dokumenten oder Präsentationen. Aspose.Slides für C++ unterstützt das Hinzufügen von Text zu Folien; in diesem Abschnitt zeigen wir, wie man die Ausrichtung von Textabsätzen in einer Folie steuern kann. Bitte folgen Sie den nachstehenden Schritten, um Textabsätze mit Aspose.Slides für C++ auszurichten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Greifen Sie auf die Platzhalter‑Shapes der Folie zu und casten Sie sie zu einem **AutoShape**.  
4. Holen Sie den **Paragraph** (der ausgerichtet werden soll) aus dem **TextFrame**, das vom **AutoShape** bereitgestellt wird.  
5. Richten Sie den **Paragraph** aus. Ein Paragraph kann nach **Right**, **Left**, **Center** oder **Justify** ausgerichtet werden.  
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte finden Sie unten.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **Transparenz für Text festlegen**
Dieser Artikel demonstriert, wie man die Transparenzeigenschaft für beliebige Text‑Shapes mithilfe von Aspose.Slides festlegt. Um die Transparenz für Text festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der **Presentation**‑Klasse.  
2. Holen Sie die Referenz einer Folie.  
3. Setzen Sie die Schattenfarbe.  
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte finden Sie unten.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **Zeichenabstand für Text festlegen**

Aspose.Slides ermöglicht das Festlegen des Abstands zwischen Zeichen in einem Textfeld. Auf diese Weise können Sie die visuelle Dichte einer Zeile oder eines Textblocks durch Vergrößern oder Verkleinern des Zeichenabstands anpassen.

Dieser C++‑Code zeigt, wie man den Abstand für eine Zeile Text erweitert und für eine andere Zeile verkleinert:
```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // erweitern
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // verdichten

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```


## **Text‑Schriftart‑Eigenschaften verwalten**

Präsentationen enthalten üblicherweise Text und Bilder. Der Text kann auf verschiedene Weise formatiert werden, etwa zur Hervorhebung bestimmter Abschnitte oder zur Einhaltung von Unternehmensrichtlinien. Die Textformatierung hilft Benutzern, das Aussehen von Präsentationsinhalten zu variieren. Dieser Artikel zeigt, wie man mit Aspose.Slides für C++ die Schriftarteigenschaften von Absätzen auf Folien konfiguriert.

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2. Holen Sie die Referenz einer Folie über deren Index.  
3. Greifen Sie auf die Platzhalter‑Shapes der Folie zu und casten Sie sie zu **AutoShape**.  
4. Holen Sie den **Paragraph** aus dem **TextFrame**, das vom **AutoShape** bereitgestellt wird.  
5. Richten Sie den Paragraph aus.  
6. Greifen Sie auf das **Portion**‑Objekt des Paragraphs zu.  
7. Definieren Sie die Schriftart über **FontData** und setzen Sie die **Font**‑Eigenschaft des **Portion**‑Objekts entsprechend.  
   1. Setzen Sie die Schriftart auf **Bold**.  
   2. Setzen Sie die Schriftart auf **Italic**.  
8. Setzen Sie die Schriftfarbe über das **FillFormat**, das vom **Portion**‑Objekt bereitgestellt wird.  
9. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte finden Sie unten. Sie nimmt eine schlichte Präsentation und formatiert die Schriftarten einer Folie.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}

## **Schriftfamilie von Text verwalten**
Ein **Portion** wird verwendet, um Text mit ähnlichem Formatstil in einem Paragraphen zu halten. Dieser Artikel zeigt, wie man mit Aspose.Slides für C++ ein Textfeld mit Text erstellt und dabei eine bestimmte Schriftart sowie weitere Eigenschaften der Schriftfamilie definiert.

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2. Holen Sie die Referenz einer Folie über deren Index.  
3. Fügen Sie der Folie ein **AutoShape** vom Typ **Rectangle** hinzu.  
4. Entfernen Sie den Füllstil, der dem **AutoShape** zugeordnet ist.  
5. Greifen Sie auf das **TextFrame** des **AutoShape** zu.  
6. Fügen Sie dem **TextFrame** Text hinzu.  
7. Greifen Sie auf das **Portion**‑Objekt im **TextFrame** zu.  
8. Definieren Sie die Schriftart, die für das **Portion** verwendet werden soll.  
9. Setzen Sie weitere Schriftarteigenschaften wie **Bold**, **Italic**, **Underline**, **Color** und **Height** über die entsprechenden Eigenschaften des **Portion**‑Objekts.  
10. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte finden Sie unten.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **Schriftgröße für Text festlegen**

Aspose.Slides ermöglicht es, die gewünschte Schriftgröße für bestehenden Text in einem Paragraphen sowie für später hinzugefügten Text festzulegen.

Dieser C++‑Code zeigt, wie man die Schriftgröße für Texte in einem Paragraphen festlegt:
```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Holt das erste Shape, zum Beispiel.
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // Holt den ersten Absatz, zum Beispiel.
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // Setzt die Standardschriftgröße auf 20 pt für alle Textanteile im Absatz.
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // Setzt die Schriftgröße auf 20 pt für aktuelle Textanteile im Absatz.
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Textrotation festlegen**

Aspose.Slides für C++ erlaubt Entwicklern, Text zu drehen. Der Text kann als **Horizontal**, **Vertical**, **Vertical270**, **WordArtVertical**, **EastAsianVertical**, **MongolianVertical** oder **WordArtVerticalRightToLeft** dargestellt werden. Um den Text eines beliebigen **TextFrame** zu drehen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie der Folie ein beliebiges **Shape** hinzu.  
4. Greifen Sie auf das **TextFrame** zu.  
5. Drehen Sie den Text.  
6. Speichern Sie die Datei auf dem Datenträger.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}

## **Tabs und effektive Tabs in einer Präsentation**
- Die Eigenschaft **EffectiveTabs.ExplicitTabCount** (2 in unserem Beispiel) entspricht **Tabs.Count**.  
- Die Sammlung **EffectiveTabs** enthält alle Tabs (aus der **Tabs**‑Sammlung und den Standards).  
- Die Eigenschaft **EffectiveTabs.DefaultTabSize** (294) gibt den Abstand zwischen den Standard‑Tabs an (3 und 4 in unserem Beispiel).  
- **EffectiveTabs.GetTabByIndex(index)** mit **index = 0** liefert den ersten expliziten Tab (Position = 731), **index = 1** den zweiten Tab (Position = 1241). Bei **index = 2** wird der erste Standard‑Tab (Position = 1470) zurückgegeben usw.  
- **EffectiveTabs.GetTabAfterPosition(pos)** wird verwendet, um die nächste Tab‑Position nach einem Text zu ermitteln. Beispiel: Sie haben den Text „Helloworld!“. Um diesen Text zu rendern, müssen Sie wissen, wo Sie mit dem Zeichnen von „world!“ beginnen. Zuerst berechnen Sie die Länge von „Hello“ in Pixeln und rufen **GetTabAfterPosition** mit diesem Wert auf. Sie erhalten die nächste Tab‑Position, um „world!“ zu zeichnen.

## **Zeilenabstand eines Absatzes**

Aspose.Slides stellt Eigenschaften unter `ParagraphFormat` – `SpaceAfter`, `SpaceBefore` und `SpaceWithin` – bereit, mit denen Sie den Zeilenabstand eines Absatzes verwalten können. Die drei Eigenschaften werden wie folgt verwendet:

* Um den Zeilenabstand prozentual anzugeben, verwenden Sie einen positiven Wert.  
* Um den Zeilenabstand in Punkten anzugeben, verwenden Sie einen negativen Wert.

Beispiel: Sie können einen Zeilenabstand von 16 pt für einen Absatz festlegen, indem Sie die Eigenschaft **SpaceBefore** auf **-16** setzen.

So legen Sie den Zeilenabstand für einen bestimmten Absatz fest:

1. Laden Sie eine Präsentation, die ein **AutoShape** mit Text enthält.  
2. Holen Sie die Referenz einer Folie über deren Index.  
3. Greifen Sie auf das **TextFrame** zu.  
4. Greifen Sie auf den **Paragraph** zu.  
5. Setzen Sie die Paragraph‑Eigenschaften.  
6. Speichern Sie die Präsentation.

Dieser C++‑Code zeigt, wie man den Zeilenabstand für einen Paragraphen festlegt:
``` cpp
// Der Pfad zum Dokumentenverzeichnis.
System::String dataDir = GetDataPath();

// Erstelle eine Instanz der Presentation-Klasse
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// Erhalte die Referenz einer Folie über ihren Index
auto sld = presentation->get_Slides()->idx_get(0);

// Greife auf das TextFrame zu
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// Greife auf den Absatz zu
auto para = tf1->get_Paragraphs()->idx_get(0);

// Setze Eigenschaften des Absatzes
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// Präsentation speichern
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```


## **AutofitType‑Eigenschaft eines Textfelds festlegen**

In diesem Abschnitt untersuchen wir die verschiedenen Formatierungseigenschaften von TextFrames. Dieser Artikel erklärt, wie man die **AutofitType**‑Eigenschaft, die Verankerung und die Drehung von Text in einer Präsentation festlegt. Aspose.Slides für C++ erlaubt das Setzen der **AutofitType**‑Eigenschaft jedes TextFrames. **AutofitType** kann auf **Normal** oder **Shape** gesetzt werden. Bei **Normal** bleibt die Form unverändert, während der Text angepasst wird; bei **Shape** wird die Form so geändert, dass nur der benötigte Text hineinpasst.

1. Erstellen Sie eine Instanz der **Presentation**‑Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie der Folie ein beliebiges Shape hinzu.  
4. Greifen Sie auf das **TextFrame** zu.  
5. Setzen Sie die **AutofitType** des **TextFrame**.  
6. Speichern Sie die Datei auf dem Datenträger.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}

## **Verankerung eines Textfelds festlegen**

Aspose.Slides für C++ erlaubt das Setzen der Verankerung jedes **TextFrame**. **TextAnchorType** bestimmt, wo der Text innerhalb der Form platziert wird. **TextAnchorType** kann auf **Top**, **Center**, **Bottom**, **Justified** oder **Distributed** gesetzt werden.

1. Erstellen Sie eine Instanz der `Presentation`‑Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie der Folie ein beliebiges Shape hinzu.  
4. Greifen Sie auf das **TextFrame** zu.  
5. Setzen Sie **TextAnchorType** des **TextFrame**.  
6. Speichern Sie die Datei auf dem Datenträger.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}

## **Benutzerdefinierten Rotationswinkel für ein Textfeld festlegen**

Aspose.Slides für C++ unterstützt nun das Setzen eines benutzerdefinierten Rotationswinkels für TextFrames. In diesem Abschnitt wird anhand eines Beispiels gezeigt, wie die **RotationAngle**‑Eigenschaft in Aspose.Slides gesetzt wird. Die neue Eigenschaft **RotationAngle** wurde zu den Schnittstellen **IChartTextBlockFormat** und **ITextFrameFormat** hinzugefügt und erlaubt das Festlegen eines benutzerdefinierten Rotationswinkels für TextFrames.

1. Erstellen Sie eine Instanz der **Presentation**‑Klasse.  
2. Fügen Sie der Folie ein Diagramm hinzu.  
3. Setzen Sie die **RotationAngle**‑Eigenschaft.  
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Im folgenden Beispiel setzen wir die **RotationAngle**‑Eigenschaft:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **Korrektursprache festlegen**

Aspose.Slides stellt die Eigenschaft **LanguageId** (exponiert von der Klasse **PortionFormat**) bereit, um die Korrektursprache für ein PowerPoint‑Dokument festzulegen. Die Korrektursprache bestimmt, für welche Sprache Rechtschreibung und Grammatik im PowerPoint geprüft werden.

Dieser C++‑Code zeigt, wie man die Korrektursprache für ein PowerPoint festlegt:
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


## **Standard‑Sprache festlegen**

Dieser C++‑Code zeigt, wie man die Standardsprache für eine gesamte PowerPoint‑Präsentation festlegt:
```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Fügt eine neue Rechteckform mit Text hinzu
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Überprüft die Sprache des ersten Textanteils
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **Standard‑Textstil festlegen**

Wenn Sie dieselbe Standard‑Textformatierung für alle Textelemente einer Präsentation gleichzeitig anwenden möchten, können Sie die Methode **get_DefaultTextStyle** des Interfaces **IPresentation** verwenden und die gewünschte Formatierung festlegen. Das folgende Beispiel zeigt, wie man die Standardschriftart **Bold** (14 pt) für den Text auf allen Folien einer neuen Präsentation setzt.
```c++
auto presentation = MakeObject<Presentation>();

// Hole das Absatzformat der obersten Ebene.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Text mit dem All‑Caps‑Effekt extrahieren**

In PowerPoint sorgt die Schriftarteigenschaft **All Caps** dafür, dass Text in Großbuchstaben angezeigt wird, obwohl er ursprünglich klein geschrieben wurde. Beim Auslesen eines solchen Textabschnitts mit Aspose.Slides liefert die Bibliothek den Text exakt so, wie er eingegeben wurde. Um dies zu berücksichtigen, prüfen Sie **TextCapType** – wenn es **All** ist, konvertieren Sie die zurückgegebene Zeichenkette einfach in Großbuchstaben, sodass Ihre Ausgabe dem entspricht, was der Benutzer auf der Folie sieht.

Angenommen, wir haben die folgende Textbox auf der ersten Folie der Datei **sample2.pptx**.

![The All Caps effect](all_caps_effect.png)

Der folgende Code zeigt, wie man den Text mit dem **All Caps**‑Effekt extrahiert:
```cpp
auto presentation = MakeObject<Presentation>(u"sample2.pptx");
auto autoShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```


Ausgabe:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Wie kann man Text in einer Tabelle auf einer Folie ändern?**

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie das Objekt **ITable**. Sie können durch alle Zellen der Tabelle iterieren und den Text jeder Zelle ändern, indem Sie deren TextFrame und Paragraph‑Format‑Eigenschaften innerhalb jeder Zelle zugreifen.

**Wie kann man einen Farbverlauf auf Text in einer PowerPoint‑Folien anwenden?**

Um einen Farbverlauf auf Text anzuwenden, verwenden Sie die Methode **get_FillFormat** in **PortionFormat**. Setzen Sie das Fill‑Format auf **Gradient** und definieren Sie die Start‑ und Endfarben des Verlaufs sowie weitere Eigenschaften wie Richtung und Transparenz, um den gewünschten Verlaufseffekt auf den Text zu erzielen.