---
title: PowerPoint-Absatz in C++ verwalten
type: docs
weight: 40
url: /cpp/manage-paragraph/
keywords: "PowerPoint-Absatz hinzufügen, Absätze verwalten, Absatz-Indentation, Absatz-Eigenschaften, HTML-Text, Absatztext exportieren, PowerPoint-Präsentation, C++, CPP, Aspose.Slides für C++"
description: "Erstellen und Verwalten von Absätzen, Text, Einrückungen und Eigenschaften in PowerPoint-Präsentationen in C++"
---

Aspose.Slides bietet alle Schnittstellen und Klassen, die Sie benötigen, um mit PowerPoint-Texten, Absätzen und Teilen in C++ zu arbeiten.

* Aspose.Slides stellt die [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) Schnittstelle zur Verfügung, um Objekte hinzuzufügen, die einen Absatz darstellen. Ein `ITextFrame`-Objekt kann einen oder mehrere Absätze haben (jeder Absatz wird durch einen Zeilenumbruch erstellt).
* Aspose.Slides stellt die [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) Schnittstelle zur Verfügung, um Objekte hinzuzufügen, die Teile darstellen. Ein `IParagraph`-Objekt kann einen oder mehrere Teile haben (Sammlung von iPortion-Objekten).
* Aspose.Slides bietet die [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) Schnittstelle, um Objekte hinzuzufügen, die Texte und deren Formatierungseigenschaften darstellen.

Ein `IParagraph`-Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften mithilfe seiner zugrunde liegenden `IPortion`-Objekte verwalten.

## **Mehrere Absätze mit mehreren Teilen hinzufügen**

Diese Schritte zeigen Ihnen, wie Sie ein Textfeld mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Teile enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf die entsprechende Folienreferenz zu.
3. Fügen Sie der Folie eine Rechteck-[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Holen Sie sich das mit der [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) verbundene ITextFrame.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) Objekte und fügen Sie sie der `IParagraphs`-Sammlung des [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) hinzu.
6. Erstellen Sie für jeden neuen `IParagraph` drei [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) Objekte (zwei Portion-Objekte für den Standardabsatz) und fügen Sie jedes `IPortion`-Objekt der IPortion-Sammlung jedes `IParagraph` hinzu.
7. Setzen Sie für jeden Teil einen Text.
8. Wenden Sie Ihre bevorzugten Formatierungsmerkmale auf jeden Teil an, indem Sie die von dem `IPortion`-Objekt bereitgestellten Formatierungseigenschaften verwenden.
9. Speichern Sie die geänderte Präsentation.

Dieser C++-Code ist eine Implementierung der Schritte zum Hinzufügen von Absätzen, die Teile enthalten: 

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Laden Sie die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greifen Sie auf die erste Folie zu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Fügen Sie eine AutoShape vom Typ Rechteck hinzu
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Fügen Sie TextFrame zum Rechteck hinzu
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Zugriff auf den ersten Absatz
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Hinzufügen des zweiten Absatzes
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Hinzufügen des dritten Absatzes
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

// Speichern Sie PPTX auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Absatz-Stichpunkte verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Aufgezählte Absätze sind immer einfacher zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf die entsprechende Folienreferenz zu.
3. Fügen Sie der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) des AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) Klasse.
7. Setzen Sie den Aufzählungstyp für den Absatz auf `Symbol` und setzen Sie das Aufzählungszeichen.
8. Setzen Sie den Absatztext.
9. Setzen Sie die Absatz-Einrückung für die Aufzählung.
10. Setzen Sie eine Farbe für die Aufzählung.
11. Setzen Sie eine Höhe für die Aufzählung.
12. Fügen Sie den neuen Absatz der Absatzsammlung des `TextFrame` hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess, der in den Schritten 7 bis 13 angegeben ist.
14. Speichern Sie die Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie einen Absatz-Stichpunkt hinzufügen:

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Laden Sie die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greifen Sie auf die erste Folie zu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Fügen Sie eine AutoShape vom Typ Rechteck hinzu
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Fügen Sie TextFrame zum Rechteck hinzu
ashp->AddTextFrame(u"");

// Zugriff auf das Textfeld
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Erstellen Sie das Paragraph-Objekt für das Textfeld
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Text festlegen
paragraph->set_Text(u"Willkommen bei Aspose.Slides");

// Einrückung für die Aufzählung festlegen
paragraph->get_ParagraphFormat()->set_Indent(25);

// Aufzählungsfarbe festlegen
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// IsBulletHardColor auf true setzen, um die eigene Aufzählungsfarbe zu verwenden
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Höhe der Aufzählung festlegen
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Absatz zum Textfeld hinzufügen
txtFrame->get_Paragraphs()->Add(paragraph);

// Erstellen Sie den zweiten Absatz
// Erstellen Sie das Paragraph-Objekt für das Textfeld
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Text festlegen
paragraph2->set_Text(u"Dies ist ein nummerierter Stichpunkt");

// Typ und Stil des Absatz-Stichpunkts festlegen
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Aufzählungs-Einrückung festlegen
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Aufzählungsfarbe festlegen
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// IsBulletHardColor auf true setzen, um die eigene Aufzählungsfarbe zu verwenden
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Höhe der Aufzählung festlegen
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Absatz zum Textfeld hinzufügen
txtFrame->get_Paragraphs()->Add(paragraph2);


// Speichern Sie PPTX auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Bild-Stichpunkte verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Bildabsätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf die entsprechende Folienreferenz zu.
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) der AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) Klasse.
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungstyp auf [Bild](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) und setzen Sie das Bild.
9. Setzen Sie den Absatztext.
10. Setzen Sie die Absatz-Einrückung für die Aufzählung.
11. Setzen Sie eine Farbe für die Aufzählung.
12. Setzen Sie eine Höhe für die Aufzählung.
13. Fügen Sie den neuen Absatz der Absatzsammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess basierend auf den vorherigen Schritten.
15. Speichern Sie die geänderte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie Bild-Stichpunkte hinzufügen und verwalten:

```c++
// Erstellt eine Presentation-Klasse, die eine PPTX-Datei darstellt
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Zugriff auf die erste Folie
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Instanziiert das Bild für Stichpunkte
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Fügen Sie die AutoShape hinzu und greifen Sie zu
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Greifen Sie auf das Autoshape-Textfeld zu
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Entfernen Sie den Standardabsatz
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Erstellen Sie einen neuen Absatz
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Willkommen bei Aspose.Slides");

// Festlegen des Absatz-Stichpunkts und Bild
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Höhe der Aufzählung festlegen
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Fügen Sie den Absatz dem Textfeld hinzu
paragraphs->Add(paragraph);

// Schreiben Sie die Präsentation als PPTX-Datei
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Schreiben Sie die Präsentation als PPT-Datei
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **Mehrstufige Stichpunkte verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Mehrstufige Stichpunkte sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf die entsprechende Folienreferenz zu.
3. Fügen Sie in der neuen Folie eine [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) der AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz über die [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) Klasse und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatzinstanz über die `Paragraph`-Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatzinstanz über die `Paragraph`-Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatzinstanz über die `Paragraph`-Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze der Absatzsammlung des `TextFrame` hinzu.
11. Speichern Sie die geänderte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie mehrstufige Stichpunkte hinzufügen und verwalten:

```c++
// Erstellt eine Presentation-Klasse, die eine PPTX-Datei darstellt
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Zugriff auf die erste Folie
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Fügen Sie die AutoShape hinzu und greifen Sie zu
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Greifen Sie auf das Textfeld des erstellten AutoShapes zu
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Leeren Sie den Standardabsatz
text->get_Paragraphs()->Clear();

// Fügen Sie den ersten Absatz hinzu
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Inhalt");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Legt die Bullet-Ebene fest
para1Format->set_Depth(0);

// Fügen Sie den zweiten Absatz hinzu
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Zweites Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Legt die Bullet-Ebene fest
para2Format->set_Depth(1);

// Fügen Sie den dritten Absatz hinzu
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Drittes Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Legt die Bullet-Ebene fest
para3Format->set_Depth(2);

// Fügen Sie den vierten Absatz hinzu
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Viertes Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Legt die Bullet-Ebene fest
para4Format->set_Depth(3);

// Fügen Sie Absätze zur Sammlung hinzu
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Schreiben Sie die Präsentation als PPTX-Datei
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **Absatz mit benutzerdefinierter nummerierter Liste verwalten**

Die [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) Schnittstelle bietet die [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) Eigenschaft und andere, mit denen Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung verwalten können.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) zur Folie hinzu.
4. Greifen Sie auf das AutoShape-[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz über die [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) Klasse und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) auf 2.
7. Erstellen Sie die zweite Absatzinstanz über die `Paragraph`-Klasse und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatzinstanz über die `Paragraph`-Klasse und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze der Absatzsammlung des `TextFrame` hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung hinzufügen und verwalten:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Greifen Sie auf das Textfeld des erstellten AutoShapes zu
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Entfernen Sie den Standardexisting Absatz
textFrame->get_Paragraphs()->RemoveAt(0);

// Erste Liste
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"Stichpunkt 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"Stichpunkt 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"Stichpunkt 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```


## **Absatz-Einrückung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Greifen Sie über seinen Index auf die entsprechende Folienreferenz zu.
1. Fügen Sie der Folie eine Rechteck-[AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechtecks-AutoShape ein [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) mit drei Absätzen hinzu.
1. Blenden Sie die Linien des Rechtecks aus.
1. Setzen Sie die Einrückung für jeden [Absatz](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) über deren BulletOffset-Eigenschaft.
1. Schreiben Sie die geänderte Präsentation als PPT-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie eine Absatz-Einrückung festlegen: 

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Laden Sie die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greifen Sie auf die erste Folie zu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Fügen Sie eine AutoShape vom Typ Rechteck hinzu
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Fügen Sie TextFrame zum Rechteck hinzu
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

tf->get_Paragraphs()->Clear();

// Hinzufügen des ersten Absatzes
SharedPtr<Paragraph> superPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion1 = MakeObject<Portion>(u"Folientitel");
superPar->get_Portions()->Add(portion1);

SharedPtr<Portion> superPortion = MakeObject<Portion>();
superPortion->get_PortionFormat()->set_Escapement(30);
superPortion->set_Text(u"TM");
superPar->get_Portions()->Add(superPortion);


// Hinzufügen des ersten Absatzes
SharedPtr<Paragraph> subPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion2 = MakeObject<Portion>(u"a");
subPar->get_Portions()->Add(portion2);

SharedPtr<Portion> subPortion = MakeObject<Portion>();
subPortion->get_PortionFormat()->set_Escapement(-25);
subPortion->set_Text(u"i");
subPar->get_Portions()->Add(subPortion);

// Hinzufügen zum Textfeld
ashp->get_TextFrame()->get_Paragraphs()->Add(superPar);
ashp->get_TextFrame()->get_Paragraphs()->Add(subPar);


// Speichern Sie PPTX auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Hängende Einrückung für Absatz festlegen**

Dieser C++-Code zeigt Ihnen, wie Sie die hängende Einrückung für einen Absatz festlegen:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 250.0f, 550.0f, 150.0f);

System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Beispiel");
System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Hängende Einrückung für Absatz festlegen");
System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Dieser C#-Code zeigt Ihnen, wie Sie die hängende Einrückung für einen Absatz festlegen: ");

para2->get_ParagraphFormat()->set_MarginLeft(10.f);
para3->get_ParagraphFormat()->set_MarginLeft(20.f);

auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Endparagraph-Eigenschaften für Absatz verwalten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz zu der Folie, die den Absatz enthält, über ihre Position.
1. Fügen Sie der Folie eine Rechteck-[AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) mit zwei Absätzen hinzu.
1. Setzen Sie die `FontHeight` und die Schriftart für die Absätze.
1. Setzen Sie die Endeigenschaften für die Absätze.
1. Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie die Endeigenschaften für Absätze in PowerPoint festlegen: 

```c++
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Laden Sie die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greifen Sie auf die erste Folie zu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Fügen Sie eine AutoShape vom Typ Rechteck hinzu
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Fügen Sie TextFrame zum Rechteck hinzu
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Hinzufügen des ersten Absatzes
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Beispielformat");

para1->get_Portions()->Add(port01);

// Hinzufügen des zweiten Absatzes
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Beispielformat 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Speichern Sie PPTX auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **HTML-Text in Absätze importieren**

Aspose.Slides bietet erweiterte Unterstützung für den Import von HTML-Text in Absätze.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf die entsprechende Folienreferenz zu.
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) hinzu.
4. Fügen Sie das AutoShape-[ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standardabsatz im `ITextFrame`.
6. Lesen Sie die Quell-HTML-Datei in einem TextReader ein.
7. Erstellen Sie die erste Absatzinstanz über die [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) Klasse.
8. Fügen Sie den Inhalt der HTML-Datei, die im gelesenen TextReader enthalten ist, der ParagraphCollection des TextFrames hinzu.
9. Speichern Sie die geänderte Präsentation.

Dieser C++-Code ist eine Implementierung der Schritte zum Importieren von HTML-Text in Absätze: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Laden Sie die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Greifen Sie auf die erste Folie zu
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Fügen Sie eine AutoShape vom Typ Rechteck hinzu
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Setzen Sie die Standardfüllfarbe zurück
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Fügen Sie dem Rechteck TextFrame hinzu
ashp->AddTextFrame(u" ");

// Zugriff auf das Textfeld
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Holen Sie sich die Paragraphs-Sammlung
SharedPtr<Aspose::Slides::IParagraphCollection> ParaCollection = txtFrame->get_Paragraphs();

// Löschen Sie alle Absätze im hinzugefügten Textfeld
ParaCollection->Clear();

// Laden Sie die HTML-Datei mit Hilfe des StreamReaders
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Fügen Sie den Text aus dem HTML-StreamReader in das Textfeld ein
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Erstellen Sie das Absatzobjekt für das Textfeld
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Erstellen Sie ein Portion-Objekt für den Absatz
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Holen Sie sich das Portion-Format
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Legen Sie die Schriftart für die Portion fest
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Festlegen der Fettschrift-Eigenschaft der Schriftart
pf->set_FontBold(NullableBool::True);

// Festlegen der Kursivschrift-Eigenschaft der Schriftart
pf->set_FontItalic(NullableBool::True);

// Festlegen der Unterstreichungseigenschaft der Schriftart
pf->set_FontUnderline(TextUnderlineType::Single);

// Festlegen der Schriftgröße
pf->set_FontHeight(25);

// Festlegen der Schriftfarbe
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Speichern Sie PPTX auf der Festplatte
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```


## **Text von Absätzen nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für den Export von Texten (die in Absätzen enthalten sind) nach HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie über seinen Index auf die entsprechende Folienreferenz zu.
3. Greifen Sie auf die Form zu, die den Text enthält, der nach HTML exportiert wird.
4. Greifen Sie auf das Form-[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML-Datei hinzu.
6. Geben Sie einen Startindex für den StreamWriter an und exportieren Sie Ihre bevorzugten Absätze.

Dieser C++-Code zeigt Ihnen, wie Sie Paragraph-Texts von PowerPoint nach HTML exportieren: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Der Pfad zum Dokumentenverzeichnis.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Laden Sie die gewünschte Präsentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Zugriff auf die standardmäßige erste Folie der Präsentation
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Gewünschter Index
int index = 0;

// Zugriff auf die hinzugefügte Form
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extrahieren Sie den ersten Absatz als HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Schreiben von Absatzdaten in HTML, indem der Startindex des Absatzes und die Anzahl der zu kopierenden Absätze angegeben werden
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```