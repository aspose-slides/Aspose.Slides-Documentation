---
title: Gestire i paragrafi di testo PowerPoint in C++
linktitle: Gestire paragrafo
type: docs
weight: 40
url: /it/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
  - aggiungere testo
  - aggiungere paragrafo
  - gestire testo
  - gestire paragrafo
  - gestire punto elenco
  - rientro paragrafo
  - rientro sporgente
  - punto elenco paragrafo
  - elenco numerato
  - elenco puntato
  - proprietà paragrafo
  - importare HTML
  - testo in HTML
  - paragrafo in HTML
  - paragrafo in immagine
  - testo in immagine
  - esportare paragrafo
  - PowerPoint
  - OpenDocument
  - presentazione
  - C++
  - Aspose.Slides
description: "Formattazione avanzata dei paragrafi con Aspose.Slides per C++ — ottimizza allineamento, spaziatura e stile nelle presentazioni PPT, PPTX e ODP in C++."
---
## **Introduzione**

Aspose.Slides fornisce tutte le interfacce e le classi necessarie per lavorare con i testi, i paragrafi e le porzioni di PowerPoint in C++.

* Aspose.Slides fornisce l'interfaccia [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) per consentire di aggiungere oggetti che rappresentano un paragrafo. Un oggetto `ITextFame` può contenere uno o più paragrafi (ogni paragrafo viene creato mediante un ritorno a capo).
* Aspose.Slides fornisce l'interfaccia [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/) per consentire di aggiungere oggetti che rappresentano porzioni. Un oggetto `IParagraph` può contenere una o più porzioni (collezione di oggetti iPortions).
* Aspose.Slides fornisce l'interfaccia [IPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/) per consentire di aggiungere oggetti che rappresentano testi e le loro proprietà di formattazione. 

Un oggetto `IParagraph` è in grado di gestire testi con diverse proprietà di formattazione tramite i suoi oggetti `IPortion` sottostanti.

## **Aggiungere più paragrafi contenenti più porzioni**

Questi passaggi mostrano come aggiungere un riquadro di testo contenente 3 paragrafi, ognuno dei quali contiene 3 porzioni:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi un rettangolo [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
4. Ottieni l'ITextFrame associato al [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/).
5. Crea due oggetti [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/) e aggiungili alla collezione `IParagraphs` del [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/).
6. Crea tre oggetti [IPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/) per ciascun nuovo `IParagraph` (due oggetti Portion per il paragrafo predefinito) e aggiungi ogni oggetto `IPortion` alla collezione IPortion di ciascun `IParagraph`.
7. Imposta del testo per ogni porzione.
8. Applica le funzionalità di formattazione preferite a ciascuna porzione utilizzando le proprietà di formattazione esposte dall'oggetto `IPortion`.
9. Salva la presentazione modificata.

Questo codice C++ è un'implementazione dei passaggi per aggiungere paragrafi contenenti porzioni: 

```c++
// Il percorso della directory dei documenti.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Carica la presentazione desiderata
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accedi alla prima diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Aggiungi un AutoShape di tipo Rettangolo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Aggiungi un TextFrame al Rettangolo
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Accedere al primo paragrafo
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Aggiungere il secondo paragrafo
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Aggiungere il terzo paragrafo
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

// Salva il PPTX su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Gestire i punti elenco dei paragrafi**

Le liste puntate ti aiutano a organizzare e presentare le informazioni in modo rapido ed efficiente. I paragrafi puntati sono sempre più facili da leggere e capire.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva selezionata.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) dell'autoshape. 
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo usando la classe [Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraph/).
7. Imposta il `Type` del punto elenco del paragrafo su `Symbol` e imposta il carattere del punto elenco.
8. Imposta il `Text` del paragrafo.
9. Imposta l'`Indent` del paragrafo per il punto elenco.
10. Imposta un colore per il punto elenco.
11. Imposta un'altezza per il punto elenco.
12. Aggiungi il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
13. Aggiungi il secondo paragrafo e ripeti il processo descritto nei passaggi 7‑12.
14. Salva la presentazione.

Questo codice C++ mostra come aggiungere un punto elenco al paragrafo: 

```c++
// Il percorso della directory dei documenti.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Carica la presentazione desiderata
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accedi alla prima diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Aggiungi un AutoShape di tipo Rettangolo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Aggiungi un TextFrame al rettangolo
ashp->AddTextFrame(u"");

// Accesso al TextFrame
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Crea l'oggetto Paragraph per il TextFrame
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Impostazione del testo
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Impostazione dell'indentazione del punto elenco
paragraph->get_ParagraphFormat()->set_Indent (25);

// Impostazione del colore del punto elenco
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
	// Imposta IsBulletHardColor su true per usare il colore del punto elenco personalizzato
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Impostazione dell'altezza del punto elenco
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Aggiunta del paragrafo al TextFrame
txtFrame->get_Paragraphs()->Add(paragraph);

// Creazione del secondo paragrafo
// Crea l'oggetto Paragraph per il TextFrame
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Impostazione del testo
paragraph2->set_Text(u"This is numbered bullet");

// Impostazione del tipo e dello stile del punto elenco del paragrafo
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Impostazione dell'indentazione del punto elenco
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Impostazione del colore del punto elenco
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// Imposta IsBulletHardColor su true per usare un colore del punto elenco personalizzato
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Impostazione dell'altezza del punto elenco
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Aggiunta del paragrafo al TextFrame
txtFrame->get_Paragraphs()->Add(paragraph2);


// Salva il PPTX su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Gestire i punti elenco con immagine**

Le liste puntate ti aiutano a organizzare e presentare le informazioni in modo rapido ed efficiente. I paragrafi con immagine sono facili da leggere e capire.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) dell'autoshape. 
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo usando la classe [Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraph/).
7. Carica l'immagine in [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/).
8. Imposta il tipo di punto elenco su [Picture](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) e imposta l'immagine.
9. Imposta il `Text` del Paragraph.
10. Imposta l'`Indent` del Paragraph per il punto elenco.
11. Imposta un colore per il punto elenco.
12. Imposta un'altezza per il punto elenco.
13. Aggiungi il nuovo paragrafo alla collezione di paragrafi del `TextFrame`.
14. Aggiungi il secondo paragrafo e ripeti il processo basato sui passaggi precedenti.
15. Salva la presentazione modificata.

Questo codice C++ mostra come aggiungere e gestire i punti elenco con immagine: 

```c++
// Istanzia una classe Presentation che rappresenta un file PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Accede alla prima diapositiva
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Istanzia l'immagine per i punti elenco
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Aggiunge e accede all'AutoShape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accede al TextFrame dell'AutoShape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Rimuove il paragrafo predefinito
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Crea un nuovo paragrafo
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Imposta lo stile del punto elenco del paragrafo e l'immagine
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Imposta l'altezza del punto elenco
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Aggiunge il paragrafo al TextFrame
paragraphs->Add(paragraph);

// Scrive la presentazione in un file PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Scrive la presentazione in un file PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Gestire i punti elenco a più livelli**

Le liste puntate ti aiutano a organizzare e presentare le informazioni in modo rapido ed efficiente. I punti elenco a più livelli sono facili da leggere e capire.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) nella nuova diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) dell'autoshape. 
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraph/) e imposta la profondità a 0.
7. Crea la seconda istanza di paragrafo tramite la classe `Paragraph` e imposta la profondità a 1.
8. Crea la terza istanza di paragrafo tramite la classe `Paragraph` e imposta la profondità a 2.
9. Crea la quarta istanza di paragrafo tramite la classe `Paragraph` e imposta la profondità a 3.
10. Aggiungi i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
11. Salva la presentazione modificata.

Questo codice C++ mostra come aggiungere e gestire i punti elenco a più livelli: 

```c++
// Istanzia una classe Presentation che rappresenta un file PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Accede alla prima diapositiva
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Aggiunge e accede all'AutoShape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accede al TextFrame dell'AutoShape creata
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Cancella il paragrafo predefinito
text->get_Paragraphs()->Clear();

// Aggiunge il primo paragrafo
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Imposta il livello del punto elenco
para1Format->set_Depth(0);

// Aggiunge il secondo paragrafo
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Imposta il livello del punto elenco
para2Format->set_Depth(1);

// Aggiunge il terzo paragrafo
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Imposta il livello del punto elenco
para3Format->set_Depth(2);

// Aggiunge il quarto paragrafo
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Imposta il livello del punto elenco
para4Format->set_Depth(3);

// Aggiunge i paragrafi alla collezione
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Scrive la presentazione in un file PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Gestire un paragrafo con un elenco numerato personalizzato**

L'interfaccia [IBulletFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/) fornisce la proprietà [NumberedBulletStartWith](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) e altre che consentono di gestire paragrafi con numerazione o formattazione personalizzate. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi alla diapositiva contenente il paragrafo.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) dell'autoshape. 
5. Rimuovi il paragrafo predefinito nel `TextFrame`.
6. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraph/) e imposta [NumberedBulletStartWith] a 2.
7. Crea la seconda istanza di paragrafo tramite la classe `Paragraph` e imposta `NumberedBulletStartWith` a 3.
8. Crea la terza istanza di paragrafo tramite la classe `Paragraph` e imposta `NumberedBulletStartWith` a 7.
9. Aggiungi i nuovi paragrafi alla collezione di paragrafi del `TextFrame`.
10. Salva la presentazione modificata.

Questo codice C++ mostra come aggiungere e gestire paragrafi con numerazione o formattazione personalizzate: 

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accede al frame di testo dell'autoshape creata
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Rimuove il paragrafo predefinito esistente
textFrame->get_Paragraphs()->RemoveAt(0);

// Prima lista
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

## **Impostare il rientro della prima linea per un paragrafo**

Usa il metodo [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) per controllare il rientro della prima linea di un paragrafo. Questo metodo sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima linea verso destra, mentre le righe rimanenti rimangono allineate al corpo del paragrafo.

Usa [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_marginleft/) quando è necessario spostare l'intero paragrafo. Usa [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) quando è necessario spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica valori di `Indent` diversi per dimostrare come il rientro della prima linea influisce sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframe/) vuoto alla forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori diversi di [Indent] per ciascuno.
6. Aggiungi i paragrafi al TextFrame.
7. Salva la presentazione modificata.

Questo codice mostra come impostare il rientro di un paragrafo: 

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

Il risultato:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Impostare il rientro sporgente per un paragrafo**

Un rientro sporgente è un layout di paragrafo in cui la prima riga inizia a sinistra delle righe successive. In Aspose.Slides, crei questo effetto con il metodo [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/). Imposta il rientro a un valore negativo per spostare la prima riga verso sinistra rispetto al corpo del paragrafo.

In pratica, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_marginleft/) definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) definisce la posizione della prima riga rispetto a quel margine. Per creare un rientro sporgente, imposta un valore positivo per `MarginLeft` e un valore negativo per `Indent`.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi dove le righe a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione.
3. Aggiungi una [AutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/autoshape/) rettangolare alla diapositiva.
4. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframe/) vuoto alla forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e imposta un valore positivo di [MarginLeft] per ciascun paragrafo.
6. Imposta un valore negativo di [Indent] per creare l'effetto di rientro sporgente.
7. Aggiungi i paragrafi al TextFrame.
8. Salva la presentazione modificata.

Questo codice mostra come impostare un rientro sporgente per un paragrafo: 

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

Il risultato:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Gestire le proprietà di fine esecuzione del paragrafo**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni il riferimento alla diapositiva contenente il paragrafo tramite la sua posizione.
1. Aggiungi un [autoshape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) rettangolare alla diapositiva.
1. Aggiungi un [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) con due paragrafi al rettangolo.
1. Imposta `FontHeight` e il tipo di Font per i paragrafi.
1. Imposta le proprietà End per i paragrafi.
1. Scrivi la presentazione modificata come file PPTX.

Questo codice C++ mostra come impostare le proprietà End per i paragrafi in PowerPoint: 

```c++
// Il percorso della directory dei documenti.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Carica la presentazione desiderata
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accedi alla prima diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Aggiungi un AutoShape di tipo Rettangolo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Aggiungi un TextFrame al rettangolo
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Aggiunta del primo paragrafo
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Aggiunta del secondo paragrafo
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Salva il PPTX su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Importare testo HTML nei paragrafi**

Aspose.Slides fornisce un supporto migliorato per l'importazione di testo HTML nei paragrafi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [autoshape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
4. Aggiungi e accedi al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) dell'`autoshape` 
5. Rimuovi il paragrafo predefinito nel `ITextFrame`.
6. Leggi il file HTML sorgente in un TextReader.
7. Crea la prima istanza di paragrafo tramite la classe [Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraph/).
8. Aggiungi il contenuto del file HTML letto dal TextReader al [ParagraphCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraphcollection/) del TextFrame.
9. Salva la presentazione modificata.

Questo codice C++ è un'implementazione dei passaggi per importare testi HTML nei paragrafi: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Il percorso della directory dei documenti.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Carica la presentazione desiderata
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accedi alla prima diapositiva
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Aggiungi un AutoShape di tipo Rettangolo
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//Resetting default fill color
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Aggiungi un TextFrame al rettangolo
ashp->AddTextFrame(u" ");

// Accessing the text frame
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//GetParagraphs collection
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Clearing all paragraphs in added text frame
ParaCollection->Clear();

// Loading the HTML file using stream reader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Adding text from HTML stream reader in text frame
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Create the Paragraph object for text frame
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Create Portion object for paragraph
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Get portion format
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Set the Font for the Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Set Bold property of the Font
pf->set_FontBold(NullableBool::True);

// Set Italic property of the Font
pf->set_FontItalic(NullableBool::True);

// Set Underline property of the Font
pf->set_FontUnderline(TextUnderlineType::Single);

// Set the Height of the Font
pf->set_FontHeight(25);

// Set the color of the Font
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Esportare il testo del paragrafo in HTML**

Aspose.Slides fornisce un supporto migliorato per esportare i testi (contenuti nei paragrafi) in HTML.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e carica la presentazione desiderata.
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Accedi alla forma che contiene il testo da esportare in HTML.
4. Accedi al [TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma.
5. Crea un'istanza di `StreamWriter` e aggiungi il nuovo file HTML.
6. Fornisci un indice di partenza a StreamWriter ed esporta i paragrafi desiderati.

Questo codice C++ mostra come esportare i testi dei paragrafi PowerPoint in HTML: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Il percorso della directory dei documenti.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Carica la presentazione desiderata
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Accede alla prima diapositiva predefinita della presentazione
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Indice desiderato
int index = 0;

// Accesso alla forma aggiunta
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Estrae il primo paragrafo come HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Scrive i dati dei paragrafi in HTML fornendo l'indice iniziale del paragrafo e il numero totale di paragrafi da copiare
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();
```

## **Salvare un paragrafo come immagine**

In questa sezione esploreremo due esempi che dimostrano come salvare un paragrafo di testo, rappresentato dall'interfaccia [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/), come immagine. Entrambi gli esempi includono l'ottenimento dell'immagine di una forma contenente il paragrafo usando i metodi `GetImage` dell'interfaccia [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/), il calcolo dei limiti del paragrafo all'interno della forma e l'esportazione come immagine bitmap. questi approcci consentono di estrarre parti specifiche del testo dalle presentazioni PowerPoint e salvarle come immagini separate, utile per vari scenari.

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, in cui la prima forma è una casella di testo contenente tre paragrafi.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Esempio 1**

In questo esempio, otteniamo il secondo paragrafo come immagine. Per fare ciò, estraiamo l'immagine della forma dalla prima diapositiva della presentazione e quindi calcoliamo i limiti del secondo paragrafo nel text frame della forma. Il paragrafo viene quindi ridisegnato su una nuova immagine bitmap, salvata in formato PNG. Questo metodo è particolarmente utile quando è necessario salvare un paragrafo specifico come immagine separata mantenendo le dimensioni e la formattazione esatte del testo.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Salva la forma in memoria come bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Crea un bitmap della forma dalla memoria.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calcola i confini del secondo paragrafo.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calcola le dimensioni dell'immagine di output (dimensione minima - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepara un bitmap per il paragrafo.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Ridisegna il paragrafo dal bitmap della forma al bitmap del paragrafo.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

Il risultato:

![The paragraph image](paragraph_to_image_output.png)

**Esempio 2**

In questo esempio, estendiamo l'approccio precedente aggiungendo fattori di scala all'immagine del paragrafo. La forma viene estratta dalla presentazione e salvata come immagine con un fattore di scala pari a `2`. Questo consente una risoluzione più alta durante l'esportazione del paragrafo. I limiti del paragrafo vengono quindi calcolati tenendo conto della scala. La scalatura può essere particolarmente utile quando è necessaria un'immagine più dettagliata, ad esempio per l'uso in materiali stampati di alta qualità.

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

**Posso disabilitare completamente l'andamento a capo all'interno di un TextFrame?**

Sì. Usa il metodo di avvolgimento del TextFrame ([set_WrapText](https://reference.aspose.com/slides/it/cpp/aspose.slides/textframeformat/set_wraptext/)) per disattivare l'andamento a capo in modo che le linee non si interrompano ai bordi del frame.

**Come posso ottenere i limiti esatti sullo slide di un paragrafo specifico?**

Puoi recuperare il rettangolo di delimitazione del paragrafo (e anche di una singola porzione) per conoscere la sua posizione e dimensione precise sullo slide.

**Dove viene controllato l'allineamento del paragrafo (sinistra/destra/centrato/giustificato)?**

[Alignment](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraphformat/set_alignment/) è un'impostazione a livello di paragrafo in [ParagraphFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraphformat/); si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare una lingua di controllo ortografico solo per una parte di un paragrafo (ad esempio una parola)?**

Sì. La lingua viene impostata a livello di porzione usando ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseportionformat/set_languageid/)), quindi più lingue possono coesistere all'interno di un unico paragrafo.