---
title: PowerPoint-Textabsätze verwalten in C++
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/cpp/manage-paragraph/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählungszeichen verwalten
- Absatz‑Einzug
- Hängender Einzug
- Absatz‑Aufzählungszeichen
- Nummerierte Liste
- Aufzählungsliste
- Absatz‑Eigenschaften
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
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für C++ – optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX- und ODP‑Präsentationen in C++."
---

Aspose.Slides stellt alle Schnittstellen und Klassen bereit, die Sie benötigen, um in C++ mit PowerPoint‑Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides stellt die [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) Schnittstelle bereit, mit der Sie Objekte hinzufügen können, die einen Absatz darstellen. Ein `ITextFame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Wagenrücklauf erstellt).
* Aspose.Slides stellt die [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) Schnittstelle bereit, mit der Sie Objekte hinzufügen können, die Portionen darstellen. Ein `IParagraph`‑Objekt kann eine oder mehrere Portionen enthalten (Sammlung von iPortions‑Objekten).
* Aspose.Slides stellt die [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) Schnittstelle bereit, mit der Sie Objekte hinzufügen können, die Texte und deren Formatierungseigenschaften darstellen. 

Ein `IParagraph`‑Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `IPortion`‑Objekte verarbeiten.

## **Mehrere Absätze hinzufügen, die mehrere Portionen enthalten**

Diese Schritte zeigen, wie Sie einen Text‑Frame mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein Rechteck‑[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Holen Sie das mit dem [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) verbundene `ITextFrame`.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/)‑Objekte und fügen Sie sie der `IParagraphs`‑Sammlung des [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) hinzu.
6. Erstellen Sie für jedes neue `IParagraph` drei [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/)‑Objekte (zwei Portion‑Objekte für den Standard‑Absatz) und fügen Sie jedes `IPortion`‑Objekt der IPortion‑Sammlung des jeweiligen `IParagraph` hinzu.
7. Setzen Sie für jede Portion einen Text.
8. Wenden Sie die gewünschten Formatierungsoptionen auf jede Portion über die vom `IPortion`‑Objekt bereitgestellten Formatierungseigenschaften an.
9. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code implementiert die Schritte zum Hinzufügen von Absätzen mit Portionen: 
```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Lade die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greife auf die erste Folie zu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Füge ein AutoShape vom Typ Rechteck hinzu
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Füge dem Rechteck ein TextFrame hinzu
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Accessing the first Paragraph
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Adding second Paragraph
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Adding third Paragraph
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

// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Absatz‑Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Aufgezählte Absätze sind immer leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der ausgewählten Folie ein [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)‑Klasse.
7. Setzen Sie den Aufzählungszeichen‑`Type` des Absatzes auf `Symbol` und legen Sie das Aufzählungszeichen‑Zeichen fest.
8. Setzen Sie den Absatz‑`Text`.
9. Setzen Sie den Absatz‑`Indent` für das Aufzählungszeichen.
10. Legen Sie eine Farbe für das Aufzählungszeichen fest.
11. Legen Sie eine Höhe für das Aufzählungszeichen fest.
12. Fügen Sie den neuen Absatz der `TextFrame`‑Absatzsammlung hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang der Schritte 7 bis 13.
14. Speichern Sie die Präsentation.

Dieser C++‑Code zeigt, wie Sie ein Aufzählungszeichen zu einem Absatz hinzufügen: 
```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Lade die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greife auf die erste Folie zu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Füge ein AutoShape vom Typ Rechteck hinzu
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Füge dem Rechteck ein TextFrame hinzu
ashp->AddTextFrame(u"");

// Greife auf den Textrahmen zu
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Erstelle das Paragraph-Objekt für den Textrahmen
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Text setzen
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Aufzählungseinzug festlegen
paragraph->get_ParagraphFormat()->set_Indent (25);

// Aufzählungsfarbe festlegen
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// IsBulletHardColor auf true setzen, um eigene Aufzählungsfarbe zu verwenden
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Aufzählungshöhe festlegen
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Absatz zum Textrahmen hinzufügen
txtFrame->get_Paragraphs()->Add(paragraph);

// Erstelle zweiten Absatz
// Erstelle das Paragraph-Objekt für den Textrahmen
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Text setzen
paragraph2->set_Text(u"This is numbered bullet");

// Aufzählungstyp und -stil festlegen
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Aufzählungseinzug festlegen
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Aufzählungsfarbe festlegen
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// IsBulletHardColor auf true setzen, um eigene Aufzählungsfarbe zu verwenden
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Aufzählungshöhe festlegen
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Absatz zum Textrahmen hinzufügen
txtFrame->get_Paragraphs()->Add(paragraph2);


// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Bild‑Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Bild‑Absätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)‑Klasse.
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungszeichen‑Typ auf [Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) und legen Sie das Bild fest.
9. Setzen Sie den Absatz‑`Text`.
10. Setzen Sie den Absatz‑`Indent` für das Aufzählungszeichen.
11. Legen Sie eine Farbe für das Aufzählungszeichen fest.
12. Legen Sie eine Höhe für das Aufzählungszeichen fest.
13. Fügen Sie den neuen Absatz der `TextFrame`‑Absatzsammlung hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang anhand der vorherigen Schritte.
15. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code zeigt, wie Sie Bild‑Aufzählungszeichen hinzufügen und verwalten: 
```c++
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Greift auf die erste Folie zu
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Instanziiert das Bild für Aufzählungszeichen
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Fügt eine AutoShape hinzu und greift darauf zu
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Greift auf den TextFrame der AutoShape zu
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Entfert den Standardabsatz
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Erstellt einen neuen Absatz
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Setzt den Aufzählungsstil des Absatzes und das Bild
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Setzt die Aufzählungshöhe
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Fügt den Absatz zum TextFrame hinzu
paragraphs->Add(paragraph);

// Speichert die Präsentation als PPTX-Datei
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Speichert die Präsentation als PPT-Datei
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **Mehrstufige Aufzählungszeichen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Mehrstufige Aufzählungszeichen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie in der neuen Folie ein [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)‑Klasse und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze der `TextFrame`‑Absatzsammlung hinzu.
11. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code zeigt, wie Sie mehrstufige Aufzählungszeichen hinzufügen und verwalten: 
```c++
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Greift auf die erste Folie zu
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Fügt ein AutoShape hinzu und greift darauf zu
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Greift auf den Textrahmen des erstellten AutoShape zu
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

// Fügt Absätze zur Sammlung hinzu
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Speichert die Präsentation als PPTX-Datei
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **Einen Absatz mit einer benutzerdefinierten Nummerierungsliste verwalten**

Die [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/)‑Schnittstelle stellt die Eigenschaft [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) und weitere bereit, mit denen Sie Absätze mit benutzerdefinierten Nummerierungen oder Formatierungen verwalten können. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) des Autoshapes zu. 
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)‑Klasse und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) auf 2.
7. Erstellen Sie die zweite Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatz‑Instanz über die `Paragraph`‑Klasse und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze der `TextFrame`‑Absatzsammlung hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code zeigt, wie Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung hinzufügen und verwalten: 
```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Greift auf den Textrahmen des erstellten AutoShape zu
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Entfernt den standardmäßigen existierenden Absatz
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


## **Absatzeinzug festsetzen**

1. Erstellen Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
1. Greifen Sie über den Index auf die entsprechende Folie zu.
1. Fügen Sie ein Rechteck‑[autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) zur Folie hinzu.
1. Fügen Sie dem Rechteck‑autoshape ein [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) mit drei Absätzen hinzu.
1. Blenden Sie die Rechtecklinien aus.
1. Setzen Sie den Einzug für jeden [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) über dessen `BulletOffset`‑Eigenschaft.
1. Schreiben Sie die geänderte Präsentation als PPT‑Datei.

Dieser C++‑Code zeigt, wie Sie einen Absatzeinzug festlegen: 
```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Lade die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greife auf die erste Folie zu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Füge ein AutoShape vom Typ Rechteck hinzu
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Füge dem Rechteck ein TextFrame hinzu
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

tf->get_Paragraphs()->Clear();

// Füge den ersten Absatz hinzu
SharedPtr<Paragraph> superPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion1 = MakeObject<Portion>(u"SlideTitle");
superPar->get_Portions()->Add(portion1);

SharedPtr<Portion> superPortion = MakeObject<Portion>();
superPortion->get_PortionFormat()->set_Escapement(30);
superPortion->set_Text(u"TM");
superPar->get_Portions()->Add(superPortion);


// Füge den ersten Absatz hinzu
SharedPtr<Paragraph> subPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion2 = MakeObject<Portion>(u"a");
subPar->get_Portions()->Add(portion2);

SharedPtr<Portion> subPortion = MakeObject<Portion>();
subPortion->get_PortionFormat()->set_Escapement(-25);
subPortion->set_Text(u"i");
subPar->get_Portions()->Add(subPortion);

// Zum Textframe hinzufügen
ashp->get_TextFrame()->get_Paragraphs()->Add(superPar);
ashp->get_TextFrame()->get_Paragraphs()->Add(subPar);


// Speichere PPTX auf Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Hängenden Einzug für einen Absatz festlegen**

Dieser C++‑Code zeigt, wie Sie den hängenden Einzug für einen Absatz festlegen:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 250.0f, 550.0f, 150.0f);

System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Example");
System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Set Hanging Indent for Paragraph");
System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"This C# code shows you how to set the hanging indent for a paragraph: ");

para2->get_ParagraphFormat()->set_MarginLeft(10.f);
para3->get_ParagraphFormat()->set_MarginLeft(20.f);

auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **End‑Absatz‑Lauf‑Eigenschaften verwalten**

1. Erstellen Sie eine Instanz von [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
1. Holen Sie die Referenz zur Folie, die den Absatz enthält, über deren Position.
1. Fügen Sie der Folie ein Rechteck‑[autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) mit zwei Absätzen hinzu.
1. Setzen Sie `FontHeight` und Schriftart für die Absätze.
1. Setzen Sie die End‑Eigenschaften für die Absätze.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie die End‑Eigenschaften für Absätze in PowerPoint festlegen: 
```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Lade die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greife auf die erste Folie zu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Füge ein AutoShape vom Typ Rechteck hinzu
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Füge dem Rechteck ein TextFrame hinzu
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Füge den ersten Absatz hinzu
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Füge den zweiten Absatz hinzu
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Speichere PPTX auf Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **HTML‑Text in Absätze importieren**

Aspose.Slides bietet erweiterte Unterstützung für das Importieren von HTML‑Text in Absätze.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Fügen Sie dem `autoshape` ein [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standard‑Absatz im `ITextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem `TextReader`.
7. Erstellen Sie die erste Absatz‑Instanz über die [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)‑Klasse.
8. Fügen Sie den HTML‑Dateiinhalt aus dem gelesenen `TextReader` zur [ParagraphCollection](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die geänderte Präsentation.

Dieser C++‑Code implementiert die Schritte zum Importieren von HTML‑Texten in Absätze: 
```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Laden Sie die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greift auf die erste Folie zu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Fügt ein AutoShape vom Typ Rechteck hinzu
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//Zurücksetzen der Standardfüllfarbe
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Fügt dem Rechteck ein TextFrame hinzu
ashp->AddTextFrame(u" ");

// Zugriff auf den Textframe
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//GetParagraphs Sammlung
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Löschen aller Absätze im hinzugefügten Textframe
ParaCollection->Clear();

// Laden der HTML-Datei mit StreamReader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Hinzufügen von Text aus dem HTML-StreamReader zum Textframe
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Erstelle das Paragraph-Objekt für den Textframe
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Erstelle Portion-Objekt für den Absatz
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Portion-Format abrufen
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Setze die Schriftart für die Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Setze die Fettdruck-Eigenschaft der Schriftart
pf->set_FontBold(NullableBool::True);

// Setze die Kursiv-Eigenschaft der Schriftart
pf->set_FontItalic(NullableBool::True);

// Setze die Unterstreichungs-Eigenschaft der Schriftart
pf->set_FontUnderline(TextUnderlineType::Single);

// Setze die Höhe der Schriftart
pf->set_FontHeight(25);

// Setze die Farbe der Schriftart
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Speichere PPTX auf Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Absatz‑Text nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (in Absätzen enthalten) nach HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die entsprechende Folie zu.
3. Greifen Sie auf die Form zu, die den zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) der Form zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie einen Start‑Index für den `StreamWriter` an und exportieren Sie die gewünschten Absätze.

Dieser C++‑Code zeigt, wie Sie Absatz‑Texte aus PowerPoint nach HTML exportieren: 
```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Laden Sie die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Greifen Sie auf die standardmäßige erste Folie der Präsentation zu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Gewünschter Index
int index = 0;

// Zugriff auf die hinzugefügte Form
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extrahieren des ersten Absatzes als HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//  System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Schreiben von Absatzdaten nach HTML, indem der Startindex des Absatzes und die Gesamtzahl der zu kopierenden Absätze angegeben werden
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```


## **Einen Absatz als Bild speichern**

In diesem Abschnitt zeigen wir zwei Beispiele, die demonstrieren, wie ein Text‑Absatz, dargestellt durch die [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/)‑Schnittstelle, als Bild gespeichert werden kann. Beide Beispiele umfassen das Abrufen des Bildes einer Form, die den Absatz enthält, über die `GetImage`‑Methoden der [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)‑Schnittstelle, das Berechnen der Begrenzungsrechtecke des Absatzes innerhalb der Form und das Exportieren als Bitmap‑Bild. Diese Ansätze ermöglichen das Extrahieren bestimmter Textteile aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

Angenommen, wir haben eine Präsentationsdatei namens **sample.pptx** mit einer Folie, wobei die erste Form ein Textfeld mit drei Absätzen ist.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Hierzu extrahieren wir das Bild der Form aus der ersten Folie der Präsentation und berechnen anschließend die Begrenzungsrechtecke des zweiten Absatzes im Text‑Frame der Form. Der Absatz wird dann auf ein neues Bitmap‑Bild rediziert, das im PNG‑Format gespeichert wird. Diese Methode ist besonders nützlich, wenn ein bestimmter Absatz als separates Bild gespeichert werden soll, während die genauen Abmessungen und Formatierungen des Textes erhalten bleiben.
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

![Das Absatz‑Bild](paragraph_to_image_output.png)

**Beispiel 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatz‑Bild hinzufügen. Die Form wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch entsteht eine höher aufgelöste Ausgabe beim Exportieren des Absatzes. Die Absatz‑Grenzen werden dann unter Berücksichtigung der Skalierung berechnet. Skalierung kann besonders hilfreich sein, wenn ein detaillierteres Bild benötigt wird, etwa für den Einsatz in hochwertigem Druckmaterial.
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

**Kann ich das Zeilenumbruch‑Verhalten innerhalb eines Text‑Frames komplett deaktivieren?**

Ja. Verwenden Sie die Umbruch‑Methode des Text‑Frames ([set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/)), um das Umbrechen auszuschalten, sodass Zeilen nicht an den Rändern des Frames umbrechen.

**Wie kann ich die genauen On‑Slide‑Grenzen eines bestimmten Absatzes ermitteln?**

Sie können das Begrenzungsrechteck des Absatzes (und sogar eines einzelnen Portions) abrufen, um seine präzise Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_alignment/) ist eine Absatz‑Ebene‑Einstellung in [ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich eine Rechtschreib‑Sprache nur für einen Teil eines Absatzes (z. B. ein Wort) festlegen?**

Ja. Die Sprache wird auf Portion‑Ebene über ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/)) festgelegt, sodass mehrere Sprachen innerhalb eines einzelnen Absatzes coexistieren können.