---
title: PowerPoint-Textabsätze in C++ verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählungszeichen verwalten
- Absatzeinzug
- Hängender Einzug
- Absatz‑Aufzählungszeichen
- Nummerierte Liste
- Aufzählungsliste
- Absatzeigenschaften
- HTML importieren
- Text zu HTML
- Absatz zu HTML
- Absatz zu Bild
- Text zu Bild
- Absatz exportieren
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für C++ – optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX‑ und ODP‑Präsentationen in C++."
---
## **Einführung**

Aspose.Slides stellt alle Schnittstellen und Klassen bereit, die Sie benötigen, um in C++ mit PowerPoint‑Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides stellt die [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/)‑Schnittstelle bereit, um Objekte hinzuzufügen, die einen Absatz darstellen. Ein `ITextFame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erzeugt).
* Aspose.Slides stellt die [IParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/)‑Schnittstelle bereit, um Objekte hinzuzufügen, die Portionen darstellen. Ein `IParagraph`‑Objekt kann eine oder mehrere Portionen enthalten (Sammlung von iPortions‑Objekten).
* Aspose.Slides stellt die [IPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/)‑Schnittstelle bereit, um Objekte hinzuzufügen, die Texte und deren Formatierungseigenschaften darstellen. 

Ein `IParagraph`‑Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `IPortion`‑Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Portionen hinzufügen**

Diese Schritte zeigen, wie Sie einen Text‑Frame mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein rechteckiges [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Holen Sie das mit dem [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) verbundene `ITextFrame`.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/)‑Objekte und fügen Sie sie der `IParagraphs`‑Sammlung des [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) hinzu.
6. Erstellen Sie für jedes neue `IParagraph` drei [IPortion](https://reference.aspose.com/slides/de/cpp/aspose.slides/iportion/)‑Objekte (zwei Portion‑Objekte für den Standard‑Absatz) und fügen Sie jedes `IPortion`‑Objekt der IPortion‑Sammlung des jeweiligen `IParagraph` hinzu.
7. Setzen Sie für jede Portion einen Text.
8. Wenden Sie Ihre gewünschten Formatierungsoptionen auf jede Portion über die vom `IPortion`‑Objekt bereitgestellten Eigenschaften an.
9. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code implementiert die Schritte zum Hinzufügen von Absätzen mit Portionen:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Gewünschte Präsentation laden
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Erste Folie öffnen
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// AutoShape vom Typ Rechteck hinzufügen
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// TextFrame zum Rechteck hinzufügen
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Zugriff auf den ersten Absatz
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Zweiten Absatz hinzufügen
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Dritten Absatz hinzufügen
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// PPTX auf Festplatte speichern
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Absatz‑Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Aufgelistete Absätze sind stets leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der ausgewählten Folie ein [autoshape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraph/)‑Klasse.
7. Setzen Sie den Aufzählungs‑`Type` des Absatzes auf `Symbol` und geben Sie das Aufzählungszeichen an.
8. Setzen Sie den Absatz‑`Text`.
9. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
10. Legen Sie eine Farbe für das Aufzählungszeichen fest.
11. Legen Sie eine Höhe für das Aufzählungszeichen fest.
12. Fügen Sie den neuen Absatz der `TextFrame`‑Absatzsammlung hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7 bis 13.
14. Speichern Sie die Präsentation.

Dieser C++‑Code zeigt, wie Sie eine Absatz‑Aufzählung hinzufügen:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Die gewünschte Präsentation laden
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Erste Folie öffnen
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// AutoShape vom Typ Rechteck hinzufügen
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// TextFrame zum Rechteck hinzufügen
ashp->AddTextFrame(u"");

// Zugriff auf den Textframe
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Paragraph-Objekt für Textframe erstellen
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// Text festlegen
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Einzug für Aufzählungszeichen festlegen
paragraph->get_ParagraphFormat()->set_Indent (25);

// Farbe für Aufzählungszeichen festlegen
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// IsBulletHardColor auf true setzen, um eigene Aufzählungszeichenfarbe zu verwenden
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Höhe des Aufzählungszeichens festlegen
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Absatz zum Textframe hinzufügen
txtFrame->get_Paragraphs()->Add(paragraph);

// Zweiten Absatz erstellen
// Paragraph-Objekt für Textframe erstellen
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Text festlegen
paragraph2->set_Text(u"This is numbered bullet");

// Aufzählungszeichen-Typ und -Stil des Absatzes festlegen
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Einzug für Aufzählungszeichen festlegen
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Farbe für Aufzählungszeichen festlegen
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// IsBulletHardColor auf true setzen, um eigene Aufzählungszeichenfarbe zu verwenden
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Höhe des Aufzählungszeichens festlegen
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Absatz zum Textframe hinzufügen
txtFrame->get_Paragraphs()->Add(paragraph2);


// PPTX auf Festplatte speichern
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bild‑Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Bild‑Absätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraph/)‑Klasse.
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungstyp auf [Picture](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) und legen Sie das Bild fest.
9. Setzen Sie den Absatz‑`Text`.
10. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
11. Legen Sie eine Farbe für das Aufzählungszeichen fest.
12. Legen Sie eine Höhe für das Aufzählungszeichen fest.
13. Fügen Sie den neuen Absatz der `TextFrame`‑Absatzsammlung hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den vorherigen Ablauf.
15. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code zeigt, wie Sie Bild‑Aufzählungen hinzufügen und verwalten:

```c++
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Greift auf die erste Folie zu
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Instanziiert das Bild für Aufzählungszeichen
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Fügt ein AutoShape hinzu und greift darauf zu
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Greift auf den TextFrame des AutoShapes zu
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Entfernt den Standard-Absatz
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Erstellt einen neuen Absatz
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Setzt den Aufzählungszeichenstil und das Bild des Absatzes
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Setzt die Höhe des Aufzählungszeichens
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Fügt den Absatz dem TextFrame hinzu
paragraphs->Add(paragraph);

// Speichert die Präsentation als PPTX-Datei
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Speichert die Präsentation als PPT-Datei
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Mehrstufige Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Mehrstufige Aufzählungen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie in der neuen Folie ein [autoshape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraph/)‑Klasse und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze der `TextFrame`‑Absatzsammlung hinzu.
11. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code zeigt, wie Sie mehrstufige Aufzählungen hinzufügen und verwalten:

```c++
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Greift auf die erste Folie zu
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Fügt ein AutoShape hinzu und greift darauf zu
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Greift auf den Textframe des erstellten AutoShapes zu
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Löscht den Standardabsatz
text->get_Paragraphs()->Clear();

// Fügt den ersten Absatz hinzu
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Setzt die Aufzählungsebene
para1Format->set_Depth(0);

// Fügt den zweiten Absatz hinzu
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Setzt die Aufzählungsebene
para2Format->set_Depth(1);

// Fügt den dritten Absatz hinzu
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Setzt die Aufzählungsebene
para3Format->set_Depth(2);

// Fügt den vierten Absatz hinzu
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Setzt die Aufzählungsebene
para4Format->set_Depth(3);

// Fügt die Absätze zur Sammlung hinzu
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Speichert die Präsentation als PPTX-Datei
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Absatz mit benutzerdefinierter nummerierter Liste verwalten**

Die [IBulletFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/)‑Schnittstelle stellt die Eigenschaft [NumberedBulletStartWith](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) und weitere bereit, die Ihnen die Verwaltung von Absätzen mit benutzerdefinierter Nummerierung oder Formatierung ermöglichen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraph/)‑Klasse und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) auf 2.
7. Erstellen Sie die zweite Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze der `TextFrame`‑Absatzsammlung hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code zeigt, wie Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung hinzufügen und verwalten:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Greift auf den Textframe des erstellten AutoShapes zu
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Entfernt den standardmäßig vorhandenen Absatz
textFrame->get_Paragraphs()->RemoveAt(0);

// Erste Liste
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **Einrückung der ersten Zeile für einen Absatz festlegen**

Verwenden Sie die Methode [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/), um die erste‑Zeilen‑Einrückung eines Absatzes zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die restlichen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_marginleft/), wenn Sie den gesamten Absatz verschieben möchten. Verwenden Sie [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/), wenn Sie nur die erste Zeile verschieben wollen.

Das nachfolgende Beispiel erstellt mehrere Absätze und wendet unterschiedliche `Indent`‑Werte an, um zu demonstrieren, wie die erste‑Zeilen‑Einrückung das Layout beeinflusst.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/textframe/) hinzu und entfernen Sie den Standard‑Absatz.
5. Erstellen Sie mehrere Absätze und setzen Sie für sie unterschiedliche [Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/)‑Werte.
6. Fügen Sie die Absätze dem Text‑Frame hinzu.
7. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie Sie eine Absatz‑Einrückung festlegen:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Hängende Einrückung für einen Absatz festlegen**

Eine hängende Einrückung ist ein Absatz‑Layout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Methode [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/). Setzen Sie die Einrückung auf einen negativen Wert, um die erste Zeile nach links zu verschieben.

In der Praxis definiert [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_marginleft/) die linke Position des Absatzkörpers, und [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/) definiert die Position der ersten Zeile relativ zu diesem Rand. Um eine hängende Einrückung zu erzeugen, setzen Sie einen positiven `MarginLeft`‑Wert und einen negativen `Indent`‑Wert.

Diese Formatierung ist nützlich für Bibliografien, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein sollen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/textframe/) hinzu und entfernen Sie den Standard‑Absatz.
5. Erstellen Sie Absätze und setzen Sie für jeden einen positiven [MarginLeft](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_marginleft/)‑Wert.
6. Setzen Sie einen negativen [Indent](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraphformat/set_indent/)‑Wert, um den hängenden Einrückungseffekt zu erzeugen.
7. Fügen Sie die Absätze dem Text‑Frame hinzu.
8. Speichern Sie die geänderte Präsentation.

Dieser Code zeigt, wie Sie eine hängende Einrückung für einen Absatz festlegen:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![The hanging indent of the paragraphs](hanging_indent.png)

## **End‑Absatz‑Lauf‑Eigenschaften verwalten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse.
1. Holen Sie die Referenz der Folie, die den Absatz enthält, über deren Position.
1. Fügen Sie der Folie ein rechteckiges [autoshape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) mit zwei Absätzen hinzu.
1. Setzen Sie für die Absätze `FontHeight` und den Schriftarttyp.
1. Setzen Sie die End‑Eigenschaften für die Absätze.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie die End‑Eigenschaften für Absätze in PowerPoint festlegen:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Die gewünschte Präsentation laden
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Erste Folie öffnen
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// AutoShape vom Typ Rechteck hinzufügen
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// TextFrame zum Rechteck hinzufügen
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Ersten Absatz hinzufügen
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Zweiten Absatz hinzufügen
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// PPTX auf Festplatte speichern
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **HTML‑Text in Absätze importieren**

Aspose.Slides bietet erweiterte Unterstützung für das Importieren von HTML‑Text in Absätze.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) hinzu.
4. Fügen Sie dem `autoshape` ein [ITextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standard‑Absatz im `ITextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem TextReader ein.
7. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraph/)‑Klasse.
8. Fügen Sie den HTML‑Dateiinhalt, der im gelesenen TextReader steht, der [ParagraphCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code implementiert die Schritte zum Importieren von HTML‑Texten in Absätze:

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Gewünschte Präsentation laden
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Erste Folie öffnen
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// AutoShape vom Typ Rechteck hinzufügen
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Standardfüllfarbe zurücksetzen
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// TextFrame zum Rechteck hinzufügen
ashp->AddTextFrame(u" ");

// Zugriff auf den Textframe
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Paragraphs‑Sammlung abrufen
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Alle Absätze im hinzugefügten Textframe löschen
ParaCollection->Clear();

// HTML-Datei mit StreamReader laden
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Text aus HTML‑StreamReader in Textframe hinzufügen
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Paragraph‑Objekt für Textframe erstellen
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Portion‑Objekt für Paragraph erstellen
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Format der Portion abrufen
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Schriftart für die Portion festlegen
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Fett‑Eigenschaft der Schriftart setzen
pf->set_FontBold(NullableBool::True);

// Kursiv‑Eigenschaft der Schriftart setzen
pf->set_FontItalic(NullableBool::True);

// Unterstreichungs‑Eigenschaft der Schriftart setzen
pf->set_FontUnderline(TextUnderlineType::Single);

// Schriftgröße festlegen
pf->set_FontHeight(25);

// Farbe der Schriftart festlegen
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX auf Festplatte speichern
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Absatz‑Text nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (die in Absätzen enthalten sind) nach HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Greifen Sie auf das Shape zu, das den zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/) des Shapes zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie einen Start‑Index für den StreamWriter an und exportieren Sie Ihre gewünschten Absätze.

Dieser C++‑Code zeigt, wie Sie PowerPoint‑Absatz‑Texte nach HTML exportieren:

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Gewünschte Präsentation laden
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Zugriff auf die standardmäßige erste Folie der Präsentation
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Gewünschter Index
int index = 0;

// Zugriff auf das hinzugefügte Shape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extrahieren des ersten Absatzes als HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//  System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Schreiben von Absatzdaten nach HTML unter Angabe des Startindex des Absatzes und der Gesamtanzahl zu kopierenden Absätze
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();
```

## **Absatz als Bild speichern**

In diesem Abschnitt zeigen wir zwei Beispiele, die demonstrieren, wie ein Text‑Absatz, dargestellt durch die [IParagraph](https://reference.aspose.com/slides/de/cpp/aspose.slides/iparagraph/)‑Schnittstelle, als Bild gespeichert werden kann. Beide Beispiele umfassen das Abrufen des Bildes eines Shapes, das den Absatz enthält, über die `GetImage`‑Methoden der [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/)‑Schnittstelle, die Berechnung der Begrenzung des Absatzes innerhalb des Shapes und das Exportieren als Bitmap‑Bild. Diese Ansätze ermöglichen das Extrahieren einzelner Text‑Teile aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

Angenommen, wir haben eine Präsentationsdatei namens **sample.pptx** mit einer Folie, wobei das erste Shape ein Textfeld mit drei Absätzen ist.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild des Shapes aus der ersten Folie der Präsentation und berechnen anschließend die Begrenzung des zweiten Absatzes im Text‑Frame des Shapes. Der Absatz wird dann auf ein neues Bitmap‑Bild gezeichnet und im PNG‑Format gespeichert. Diese Methode ist besonders nützlich, wenn ein bestimmter Absatz als separates Bild gespeichert werden soll, wobei die genauen Abmessungen und die Formatierung des Textes erhalten bleiben.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

Das Ergebnis:

![The paragraph image](paragraph_to_image_output.png)

**Beispiel 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatz‑Bild hinzufügen. Das Shape wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch entsteht ein Bild mit höherer Auflösung beim Export des Absatzes. Die Absatz‑Begrenzungen werden anschließend unter Berücksichtigung des Maßstabs berechnet. Skalierung ist besonders hilfreich, wenn ein detaillierteres Bild benötigt wird, beispielsweise für hochwertige Druckmaterialien.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap with scaling.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **FAQ**

**Kann ich das Zeilen‑Umbruch‑Verhalten innerhalb eines Text‑Frames komplett deaktivieren?**

Ja. Verwenden Sie die Umbruch‑Methode des Text‑Frames ([set_WrapText](https://reference.aspose.com/slides/de/cpp/aspose.slides/textframeformat/set_wraptext/)), um den Umbruch auszuschalten, sodass Zeilen nicht an den Rändern des Frames gebrochen werden.

**Wie kann ich die genauen On‑Slide‑Grenzen eines bestimmten Absatzes ermitteln?**

Sie können das Begrenzungsrechteck des Absatzes (und sogar einer einzelnen Portion) abrufen, um dessen genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraphformat/set_alignment/) ist eine Einstellung auf Absatz‑Ebene in [ParagraphFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich eine Rechtschreib‑Sprache nur für einen Teil eines Absatzes festlegen (z. B. ein Wort)?**

Ja. Die Sprache wird auf Portion‑Ebene über ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/de/cpp/aspose.slides/baseportionformat/set_languageid/)) gesetzt, sodass mehrere Sprachen innerhalb eines einzelnen Absatzes coexistieren können.