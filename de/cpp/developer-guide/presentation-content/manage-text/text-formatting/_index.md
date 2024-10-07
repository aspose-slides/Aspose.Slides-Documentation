---
title: Textformatierung
type: docs
weight: 50
url: /cpp/text-formatting/
keywords:
- Text hervorheben
- regulärer Ausdruck
- Textabsätze ausrichten
- Texttransparenz
- Absatzschriftarten-Eigenschaften
- Schriftfamilie
- Textrrotation
- benutzerdefinierte Winkelrotation
- Textfeld
- Zeilenabstand
- Autofit-Eigenschaft
- Textfeld-Anker
- Texttabulation
- Standard-Textstil
- C++
- Aspose.Slides für .C++
description: "Verwalten und Bearbeiten von Text- und Textfeldeigenschaften in C++"
---

## **Text hervorheben**
Die neue Methode HighlightText wurde zu den Klassen ITextFrame und TextFrame hinzugefügt. Sie ermöglicht es, einen Textteil mit Hintergrundfarbe hervorzuheben, ähnlich wie das Werkzeug Text Highlight Color in PowerPoint 2019.

Der folgende Codeausschnitt zeigt, wie man diese Funktion verwendet:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 

Aspose bietet einen einfachen, [kostenlosen Online PowerPoint-Bearbeitungsdienst](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Text hervorheben mit regulärem Ausdruck**
Die neue Methode HighlightRegex wurde zu den Klassen ITextFrame und TextFrame hinzugefügt. Sie ermöglicht es, einen Textteil mit Hintergrundfarbe unter Verwendung von Regex hervorzuheben, ähnlich wie das Werkzeug Text Highlight Color in PowerPoint 2019.

Der folgende Codeausschnitt zeigt, wie man diese Funktion verwendet:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **Text Hintergrundfarbe festlegen**

Aspose.Slides ermöglicht es Ihnen, die gewünschte Farbe für den Hintergrund eines Textes festzulegen.

Dieser C++-Code zeigt, wie Sie die Hintergrundfarbe für gesamten Text festlegen:

```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Schwarz");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Rot ");

    auto portion3 = System::MakeObject<Portion>(u"Schwarz");
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

Dieser C++-Code zeigt, wie Sie die Hintergrundfarbe nur für einen Teil eines Textes festlegen:

```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Schwarz");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Rot ");

    auto portion3 = System::MakeObject<Portion>(u"Schwarz");
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
        return portion->get_Text().Contains(u"Rot");
	};

	auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    System::SharedPtr<IPortion> redPortion;
	for (auto&& portion : portions)
        if (predicate(portion))
            redPortion = portion;

    redPortion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Rot());

    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```

## **Textabsatz ausrichten**
Die Textformatierung ist eines der Schlüsselelemente beim Erstellen von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für C++ das Hinzufügen von Text zu Folien unterstützt, aber in diesem Thema werden wir sehen, wie wir die Ausrichtung der Textabsätze in einer Folie steuern können. Bitte folgen Sie den folgenden Schritten, um Textabsätze mit Aspose.Slides für C++ auszurichten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden.
3. Greifen Sie auf die Platzhalterformen zu, die in der Folie vorhanden sind, und führen Sie eine Typumwandlung in AutoShape durch.
4. Holen Sie sich den Absatz (der ausgerichtet werden muss) vom TextFrame, das vom AutoShape bereitgestellt wird.
5. Richten Sie den Absatz aus. Ein Absatz kann rechts, links, zentriert oder gerechtfertigt ausgerichtet werden.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Umsetzung der obigen Schritte ist unten angegeben.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **Transparenz für Text festlegen**
Dieser Artikel zeigt, wie Sie die Transparenzeigenschaft für eine beliebige Textebene mit Aspose.Slides festlegen. Um die Transparenz für den Text festzulegen, folgen Sie bitte den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der Presentation-Klasse.
2. Holen Sie sich die Referenz einer Folie.
3. Setzen Sie die Schattenfarbe.
4. Schreiben Sie die Präsentation als PPTX-Datei.

Die Umsetzung der obigen Schritte ist unten angegeben.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **Zeichenabstand für Text festlegen**

Aspose.Slides ermöglicht Ihnen, den Abstand zwischen Buchstaben in einem Textfeld festzulegen. Auf diese Weise können Sie die visuelle Dichte einer Zeile oder eines Textblocks durch Erweitern oder Verdichten des Abstands zwischen den Zeichen anpassen.

Dieser C++-Code zeigt, wie Sie den Abstand für eine Zeile Text erweitern und für eine andere Zeile komprimieren:

```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // erweitern
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // komprimieren

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Schriftarteigenschaften des Absatzes verwalten**

Präsentationen enthalten normalerweise sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, um entweder bestimmte Abschnitte und Wörter hervorzuheben oder den Unternehmensstil zu entsprechen. Die Textformatierung hilft den Benutzern, das Erscheinungsbild der Präsentationsinhalte zu variieren. Dieser Artikel zeigt, wie man Aspose.Slides für C++ verwendet, um die Schriftarteigenschaften von Textabsätzen auf Folien zu konfigurieren. Um die Schriftarteigenschaften eines Absatzes mit Aspose.Slides für C++ zu verwalten:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Greifen Sie auf die Platzhalterformen in der Folie zu und führen Sie eine Typumwandlung in AutoShape durch.
1. Holen Sie sich den Absatz vom TextFrame, der vom AutoShape bereitgestellt wird.
1. Rechtfertigen Sie den Absatz.
1. Greifen Sie auf den Textanteil eines Absatzes zu.
1. Definieren Sie die Schriftart mit FontData und setzen Sie die Schriftart des Textanteils entsprechend.
   1. Setzen Sie die Schriftart auf fett.
   1. Setzen Sie die Schriftart auf kursiv.
1. Setzen Sie die Schriftfarbe mit dem von den Portionenobjekten bereitgestellten FillFormat.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Die Umsetzung der obigen Schritte ist unten angegeben. Es nimmt eine schlichte Präsentation und formatiert die Schriftarten auf einer der Folien.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}

## **Schriftfamilie des Textes verwalten**
Ein Abschnitt wird verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie mehrere Eigenschaften der Schriftartfamilie mit Aspose.Slides für C++ definiert werden. Um ein Textfeld zu erstellen und die Schriftarteigenschaften des darin enthaltenen Textes festzulegen:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden.
3. Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
4. Entfernen Sie den mit der AutoShape verbundenen Füllstil.
5. Greifen Sie auf das TextFrame der AutoShape zu.
6. Fügen Sie etwas Text zum TextFrame hinzu.
7. Greifen Sie auf das mit dem TextFrame verbundene Portionenobjekt zu.
8. Definieren Sie die Schriftart, die für die Portion verwendet werden soll.
9. Setzen Sie andere Schriftarteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe mit den relevanten Eigenschaften, die von den Portionenobjekten bereitgestellt werden.
10. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Umsetzung der obigen Schritte ist unten angegeben.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **Schriftgröße für Text festlegen**

Aspose.Slides ermöglicht es Ihnen, Ihre bevorzugte Schriftgröße für vorhandenen Text in einem Absatz und andere Texte, die später zu dem Absatz hinzugefügt werden, auszuwählen.

Dieser C++-Code zeigt, wie Sie die Schriftgröße für Texte in einem Absatz festlegen:

```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Holt die erste Form, zum Beispiel.
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // Holt den ersten Absatz, zum Beispiel.
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // Setzt die Standard-Schriftgröße auf 20 pt für alle Textanteile im Absatz.
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

Aspose.Slides für C++ ermöglicht Entwicklern, den Text zu drehen. Der Text kann so eingestellt werden, dass er horizontal, vertikal, vertikal270, WordArtVertikal, OstasiatischeVertikal, MongolischVertikal oder WordArtVertikalRechtsNachLinks erscheint. Um den Text eines TextFrames zu drehen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine Form hinzu.
4. Greifen Sie auf das TextFrame zu.
5. Drehen Sie den Text.
6. Speichern Sie die Datei auf der Festplatte. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}

## **Tabs und EffectiveTabs in der Präsentation**
- Die Eigenschaft EffectiveTabs.ExplicitTabCount (2 in unserem Fall) ist gleich Tabs.Count.
- Die EffectiveTabs-Sammlung umfasst alle Tabs (aus der Tabs-Sammlung und den Standard-Tabs).
- Die Eigenschaft EffectiveTabs.DefaultTabSize (294) zeigt den Abstand zwischen den Standard-Tabs (3 und 4 in unserem Beispiel).
- EffectiveTabs.GetTabByIndex(index) mit index = 0 gibt den ersten expliziten Tab (Position = 731) zurück, index = 1 - den zweiten Tab (Position = 1241). Wenn Sie versuchen, den nächsten Tab mit index = 2 abzurufen, gibt er den ersten Standard-Tab (Position = 1470) zurück usw.
- EffectiveTabs.GetTabAfterPosition(pos) wird verwendet, um die nächste Tabulation nach einem bestimmten Text zu erhalten. Zum Beispiel haben Sie den Text: "Helloworld!". Um diesen Text darzustellen, sollten Sie wissen, wo Sie "world!" zu zeichnen beginnen. Zuerst sollten Sie die Länge von "Hello" in Pixeln berechnen und GetTabAfterPosition mit diesem Wert aufrufen. Sie erhalten die nächste Tab-Position, um "world!" zu zeichnen.

## **Zeilenabstand des Absatzes**

Aspose.Slides bietet Eigenschaften unter `ParagraphFormat`—`SpaceAfter`, `SpaceBefore` und `SpaceWithin`—die es Ihnen ermöglichen, den Zeilenabstand für einen Absatz zu verwalten. Die drei Eigenschaften werden wie folgt verwendet:

* Um den Zeilenabstand für einen Absatz in Prozent anzugeben, verwenden Sie einen positiven Wert. 
* Um den Zeilenabstand für einen Absatz in Punkten anzugeben, verwenden Sie einen negativen Wert.

Zum Beispiel können Sie einen Zeilenabstand von 16pt für einen Absatz anwenden, indem Sie die Eigenschaft `SpaceBefore` auf -16 setzen.

So geben Sie den Zeilenabstand für einen bestimmten Absatz an:

1. Laden Sie eine Präsentation, die eine AutoShape mit einem Text enthält.
2. Holen Sie sich die Referenz einer Folie durch deren Index.
3. Greifen Sie auf das TextFrame zu.
4. Greifen Sie auf den Absatz zu.
5. Setzen Sie die Absatz-Eigenschaften.
6. Speichern Sie die Präsentation.

Dieser C++-Code zeigt, wie Sie den Zeilenabstand für einen Absatz angeben:

```cpp
// Der Pfad zum Dokumentverzeichnis.
System::String dataDir = GetDataPath();

// Erstellen Sie eine Instanz der Presentation-Klasse
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// Erhalten Sie die Referenz einer Folie durch ihren Index
auto sld = presentation->get_Slides()->idx_get(0);

// Greifen Sie auf das TextFrame zu
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// Greifen Sie auf den Absatz zu
auto para = tf1->get_Paragraphs()->idx_get(0);

// Setzen Sie die Eigenschaften des Absatzes
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// Präsentation speichern
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```

## **AutofitType-Eigenschaft des Textfeldes festlegen**
In diesem Thema werden wir die verschiedenen Formatierungseigenschaften des Textfeldes untersuchen. Dieser Artikel behandelt, wie man die AutofitType-Eigenschaft des Textfeldes, den Anker des Textes und die Rotation des Textes in der Präsentation festlegt. Aspose.Slides für C++ ermöglicht es Entwicklern, die AutofitType-Eigenschaft eines Textfeldes festzulegen. AutofitType kann auf Normal oder Shape gesetzt werden. Wenn auf Normal festgelegt, bleibt die Form gleich, während der Text angepasst wird, ohne dass sich die Form selbst ändert. Wenn AutofitType auf Shape gesetzt wird, wird die Form so modifiziert, dass nur der erforderliche Text darin enthalten ist. Um die AutofitType-Eigenschaft eines Textfelds festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der Presentation-Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine Form hinzu.
4. Greifen Sie auf das TextFrame zu.
5. Setzen Sie den AutofitType des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}

## **Anker des Textfeldes festlegen**
Aspose.Slides für C++ ermöglicht Entwicklern, den Anker für jedes Textfeld festzulegen. Der TextAnchorType gibt an, wo der Text in der Form platziert ist. Der TextAnchorType kann auf Oben, Zentrum, Unten, Justifiziert oder Verteilung gesetzt werden. Um den Anker eines Textfeldes festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine Form hinzu.
4. Greifen Sie auf das TextFrame zu.
5. Setzen Sie den TextAnchorType des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}

## **Benutzerdefinierten Rotationswinkel für das Textfeld festlegen**
Aspose.Slides für C++ unterstützt nun das Festlegen eines benutzerdefinierten Rotationswinkels für das Textfeld. In diesem Thema werden wir mit einem Beispiel sehen, wie Sie die RotationAngle-Eigenschaft in Aspose.Slides festlegen. Die neue Eigenschaft RotationAngle wurde zu den Schnittstellen IChartTextBlockFormat und ITextFrameFormat hinzugefügt und ermöglicht das Festlegen des benutzerdefinierten Rotationswinkels für das Textfeld. Um die RotationAngle-Eigenschaft festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der Presentation-Klasse.
2. Fügen Sie ein Diagramm auf der Folie hinzu.
3. Setzen Sie die RotationAngle-Eigenschaft.
4. Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel legen wir die RotationAngle-Eigenschaft fest.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **Korrektursprach festlegen**

Aspose.Slides bietet die [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) Eigenschaft (die von der [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) Klasse bereitgestellt wird), um Ihnen das Festlegen der Korrektursprach für ein PowerPoint-Dokument zu ermöglichen. Die Korrektursprach ist die Sprache, für die die Rechtschreibung und Grammatik in PowerPoint überprüft werden.

Dieser C++-Code zeigt, wie Sie die Korrektursprach für ein PowerPoint festlegen:

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
// setze die ID einer Korrektursprach

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Standardsprache festlegen**

Dieser C++-Code zeigt, wie Sie die Standardsprache für eine gesamte PowerPoint-Präsentation festlegen:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Fügt eine neue Rechteckform mit Text hinzu
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"Neuer Text");

// Überprüft die Sprache des ersten Anteils
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Standard-Textstil festlegen**

Wenn Sie denselben Standard-Textstil auf alle Textelemente einer Präsentation gleichzeitig anwenden möchten, können Sie die Methode `get_DefaultTextStyle` aus der [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) Schnittstelle verwenden und die bevorzugte Formatierung festlegen. Das folgende Codebeispiel zeigt, wie man die Standard-Schriftart (14 pt) für den Text auf allen Folien in einer neuen Präsentation festlegt.

```c++
auto presentation = MakeObject<Presentation>();

// Holen Sie sich das obere Absatzformat.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```