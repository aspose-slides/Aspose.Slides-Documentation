---
title: Gestire elenchi puntati e numerati nelle presentazioni in C++
linktitle: Gestire gli elenchi
type: docs
weight: 70
url: /it/cpp/manage-lists/
keywords:
- punto
- elenco puntato
- elenco numerato
- punto simbolo
- punto immagine
- punto personalizzato
- elenco a più livelli
- creare punto
- aggiungere punto
- aggiungere elenco
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come creare e formattare elenchi puntati, con immagine, a più livelli e numerati nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides per C++ consente di creare e formattare elenchi puntati e numerati in presentazioni PowerPoint e OpenDocument. Un elemento di elenco è un paragrafo le cui impostazioni del punto elenco sono controllate tramite il formato del paragrafo.

Utilizza il metodo [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/get_paragraphformat/) per accedere alle impostazioni dell'elenco a livello di paragrafo. Il punto di ingresso principale è [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/get_bullet/), che restituisce un oggetto [IBulletFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/). Con questo oggetto, è possibile impostare il tipo di punto elenco, il simbolo, l'immagine, il colore, la dimensione, lo stile di numerazione e il numero di partenza.

Questo articolo mostra come:
- creare un elenco puntato con un simbolo personalizzato
- creare un punto elenco con immagine
- creare un elenco a più livelli impostando la profondità del paragrafo
- creare un elenco numerato
- esaminare e modificare la formattazione dell'elenco in una presentazione esistente

## **Creare un elenco puntato**

Per creare un elenco puntato, aggiungi oggetti [Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraph/) a un [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) e imposta [IBulletFormat::set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_type/) su [BulletType::Symbol](https://reference.aspose.com/slides/it/cpp/aspose.slides/bullettype/). Puoi quindi impostare [IBulletFormat::set_Char](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/get_color/) e [IBulletFormat::set_Height](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_height/) per controllare l'aspetto del punto elenco.

Il seguente codice C++ dimostra come creare un elenco puntato in una diapositiva:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![I punti elenco a simbolo](symbol_bullets.png)

## **Creare un elenco numerato**

Usa gli elenchi numerati quando l'ordine degli elementi è importante. Imposta [IBulletFormat::set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_type/) su [BulletType::Numbered](https://reference.aspose.com/slides/it/cpp/aspose.slides/bullettype/). Puoi anche scegliere un formato di numerazione con [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) o impostare [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) quando l'elenco deve iniziare da un valore diverso da 1.

Il seguente codice C++ mostra come creare un elenco numerato in una diapositiva:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![I punti elenco numerati](numbered_bullets.png)

## **Creare un punto elenco con immagine**

Aspose.Slides consente di sostituire un simbolo di punto elenco standard con un'immagine. I punti elenco con immagine funzionano meglio con immagini semplici che rimangono leggibili a dimensioni ridotte, come icone o piccoli file PNG trasparenti.

{{% alert color="info" %}}
Idealmente, se prevedi di sostituire il simbolo di punto elenco standard con un'immagine, è meglio scegliere una grafica semplice con sfondo trasparente. Tali immagini funzionano bene come simboli di punto elenco personalizzati.

Tieni presente che l'immagine verrà ridimensionata a una dimensione molto piccola. Per questo motivo, consigliamo vivamente di selezionare un'immagine che rimanga chiara ed efficace dal punto di vista visivo quando viene usata come punto elenco in un elenco.
{{% /alert %}}

Per creare un punto elenco con immagine, aggiungi un'immagine a [IPresentation::get_Images](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_images/) e assegna l'oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) restituito a [IBulletFormat::get_Picture](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/get_picture/). Imposta [IBulletFormat::set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_type/) su [BulletType::Picture](https://reference.aspose.com/slides/it/cpp/aspose.slides/bullettype/) prima di assegnare l'immagine.

Supponiamo di avere un "image.png":

![Un'immagine per i punti elenco](picture_for_bullets.png)

Il seguente codice C++ mostra come creare punti elenco con immagine in una diapositiva:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![I punti elenco con immagine](picture_bullets.png)

## **Creare un elenco a più livelli**

Usa [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_depth/) per posizionare gli elementi dell'elenco su livelli diversi. Il livello 0 è il livello superiore, il livello 1 è nidificato al di sotto, e così via.

Il seguente codice C++ mostra come creare un elenco puntato a più livelli:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![L'elenco a più livelli](multilevel_list.png)

## **Modificare un elenco esistente**

Per modificare la formattazione di un elenco in una presentazione esistente, accedi al paragrafo di destinazione e aggiorna le sue impostazioni [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/get_bullet/). Le stesse proprietà usate per creare gli elenchi possono essere utilizzate per ispezionare o modificare gli elenchi caricati da un file PPT, PPTX o ODP.

Il seguente codice C++ modifica il primo paragrafo in una cornice di testo per utilizzare uno stile di elenco numerato:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

### È possibile esportare gli elenchi puntati e numerati in PDF o immagini?

Sì. Aspose.Slides conserva la formattazione degli elenchi quando il formato di destinazione supporta la disposizione del testo e le funzionalità di puntatura corrispondenti.

### Posso modificare gli elenchi in presentazioni esistenti?

Sì. Carica la presentazione, accedi al paragrafo di destinazione, esamina o aggiorna le sue impostazioni [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/get_bullet/), e salva la presentazione.

### Gli elenchi possono contenere testo non latino?

Sì. Il testo degli elementi dell'elenco può contenere caratteri Unicode, quindi è possibile creare elenchi in presentazioni multilingue. Assicurati che i caratteri utilizzati nella presentazione supportino i caratteri di cui hai bisogno.