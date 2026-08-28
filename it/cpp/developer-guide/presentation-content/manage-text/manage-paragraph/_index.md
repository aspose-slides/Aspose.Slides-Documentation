---
title: Gestire i paragrafi di testo PowerPoint in C++
linktitle: Gestire il paragrafo
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
  - gestire pallino
  - rientro del paragrafo
  - rientro sporgente
  - pallino del paragrafo
  - elenco numerato
  - elenco puntato
  - proprietà del paragrafo
  - importare HTML
  - testo in HTML
  - paragrafo in HTML
  - paragrafo in immagine
  - testo in immagine
  - esportare paragrafo
  - PowerPoint
  - presentazione
  - C++
  - Aspose.Slides
description: "Scopri come creare e formattare paragrafi, porzioni, pallini, elenchi numerati, rientri, contenuti HTML e immagini di paragrafi con Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides per C++ rappresenta il testo come una gerarchia di fotogrammi di testo, paragrafi e porzioni:

* [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua collezione di paragrafi.
* [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/) rappresenta un singolo paragrafo in un fotogramma di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [IPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/) rappresenta una porzione di testo all'interno di un paragrafo. Ogni porzione può avere il proprio testo e la formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con caratteri, colori, dimensioni e altre formattazioni diverse usando più porzioni.

## **Creare e Formattare i Paragrafi**

### **Creare paragrafi con più porzioni**

I passaggi seguenti creano un fotogramma di testo con tre paragrafi, ciascuno contenente tre porzioni:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva desiderata mediante il suo indice.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedere al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma.
5. Utilizzare il paragrafo predefinito e aggiungere altri due oggetti [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/) al fotogramma di testo.
6. Aggiungere un numero sufficiente di oggetti [IPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/) per consentire a ciascun paragrafo di contenere tre porzioni. Il paragrafo predefinito contiene già una porzione vuota.
7. Impostare il testo di ciascuna porzione.
8. Applicare la formattazione a livello di carattere tramite [IPortion::get_PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/get_portionformat/).
9. Salvare la presentazione modificata.

Questo esempio C++ implementa i passaggi:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Creare elenchi puntati e numerati**

### **Creare un elenco puntato o numerato**

I pallini e la numerazione rendono più facile scansionare gli elementi correlati. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [IBulletFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/).

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva desiderata mediante il suo indice.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva selezionata.
4. Accedere al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma.
5. Rimuovere il paragrafo predefinito dal fotogramma di testo.
6. Creare un [Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraph/) per un pallino simbolico.
7. Impostare [IBulletFormat::set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_type/) su [BulletType::Symbol](https://reference.aspose.com/slides/it/cpp/aspose.slides/bullettype/) e specificare il carattere del pallino.
8. Impostare il testo del paragrafo, il rientro, il colore del pallino e l'altezza del pallino.
9. Aggiungere il paragrafo al fotogramma di testo.
10. Creare un secondo paragrafo e impostare [IBulletFormat::set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_type/) su [BulletType::Numbered](https://reference.aspose.com/slides/it/cpp/aspose.slides/bullettype/).
11. Configurare lo stile del pallino numerato e aggiungere il paragrafo al fotogramma di testo.
12. Salvare la presentazione.

Questo esempio C++ crea un pallino simbolico e un pallino numerato:

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Usare pallini immagine**

I pallini immagine consentono di utilizzare un'immagine personalizzata al posto di un simbolo o di un numero.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedere al riferimento della diapositiva desiderata mediante il suo indice.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) e accedere al suo [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/).
4. Rimuovere il paragrafo predefinito dal fotogramma di testo.
5. Caricare l'immagine del pallino e aggiungerla alla collezione di immagini della presentazione come [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/).
6. Creare un [Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraph/) e impostarne il testo.
7. Impostare [IBulletFormat::set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_type/) su [BulletType::Picture](https://reference.aspose.com/slides/it/cpp/aspose.slides/bullettype/).
8. Assegnare l'immagine tramite [ISlidesPicture::set_Image](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidespicture/set_image/) e impostare l'altezza del pallino.
9. Aggiungere il paragrafo al fotogramma di testo.
10. Salvare la presentazione modificata.

Questo esempio C++ crea un pallino immagine:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **Creare un elenco multinivello**

Impostare [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_depth/) per posizionare i paragrafi a livelli diversi di un elenco. Il livello più alto ha una profondità di `0`.

1. Creare una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e accedere a una diapositiva.
2. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) e cancellare il paragrafo predefinito dal suo fotogramma di testo.
3. Creare quattro paragrafi e configurare i loro simboli di pallino.
4. Impostare i valori di [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_depth/) su `0`, `1`, `2` e `3`.
5. Aggiungere i paragrafi al fotogramma di testo e salvare la presentazione.

Questo esempio C++ crea un elenco puntato a quattro livelli:

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Iniziare gli elementi numerati dell'elenco con valori personalizzati**

Utilizzare [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) per impostare il numero iniziale visualizzato per un paragrafo numerato.

1. Creare una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) a una diapositiva.
2. Cancellare il paragrafo predefinito dal fotogramma di testo della forma.
3. Creare tre paragrafi numerati.
4. Impostare [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) su `2`, `3` e `7` per i rispettivi paragrafi.
5. Aggiungere i paragrafi al fotogramma di testo e salvare la presentazione.

Questo esempio C++ assegna un numero di avvio personalizzato a ciascun paragrafo:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Controllare il layout del paragrafo e le proprietà di fine**

### **Impostare un rientro della prima riga**

Utilizzare [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) per controllare il rientro della prima riga di un paragrafo. Questo metodo sposta solo la prima riga rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima riga verso destra, mentre le righe successive rimangono allineate al corpo del paragrafo.

Usare [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_marginleft/) quando è necessario spostare l'intero paragrafo. Usare [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) quando è necessario spostare solo la prima riga.

L'esempio seguente crea diversi paragrafi e applica differenti valori di [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) per dimostrare come il rientro della prima riga influisca sul layout del paragrafo.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedere alla diapositiva di destinazione.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedere al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma e rimuovere il paragrafo predefinito.
5. Creare diversi paragrafi e impostare valori diversi di [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) per ciascuno.
6. Aggiungere i paragrafi al fotogramma di testo.
7. Salvare la presentazione modificata.

Questo codice mostra come impostare un rientro di paragrafo:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![Rientro della prima riga dei paragrafi](first_line_indent.png)

### **Impostare un rientro sporgente**

Un rientro sporgente è un layout del paragrafo in cui la prima riga inizia a sinistra delle righe successive. In Aspose.Slides, si crea questo effetto con [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/). Impostare il rientro a un valore negativo per spostare la prima riga a sinistra rispetto al corpo del paragrafo.

In pratica, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_marginleft/) definisce la posizione sinistra del corpo del paragrafo, mentre [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) definisce la posizione della prima riga rispetto a quel margine. Per creare un rientro sporgente, impostare un valore positivo di margin-left e un valore negativo di indent.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le linee a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima riga.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedere alla diapositiva di destinazione.
3. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedere al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma e rimuovere il paragrafo predefinito.
5. Creare paragrafi e impostare un valore positivo di [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_marginleft/) per ciascun paragrafo.
6. Impostare un valore negativo di [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) per creare l'effetto di rientro sporgente.
7. Aggiungere i paragrafi al fotogramma di testo.
8. Salvare la presentazione modificata.

Questo codice mostra come impostare un rientro sporgente per un paragrafo:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![Rientro sporgente dei paragrafi](hanging_indent.png)

### **Impostare le proprietà di fine paragrafo**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) controlla la formattazione del segno di fine paragrafo. L'esempio seguente assegna una dimensione di carattere e un carattere latino al segno di fine del secondo paragrafo:

1. Caricare una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e accedere a una diapositiva.
2. Aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) e cancellare il suo paragrafo predefinito.
3. Creare due paragrafi e aggiungere porzioni di testo a ciascuno.
4. Creare un [PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/portionformat/) per il segno di fine del secondo paragrafo.
5. Impostare [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/set_fontheight/) e [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/set_latinfont/).
6. Assegnare il formato con [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) e salvare la presentazione.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Importare ed Esportare il Contenuto dei Paragrafi**

### **Importare testo HTML nei paragrafi**

Utilizzare [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphcollection/addfromhtml/) per convertire il markup HTML in paragrafi e porzioni all'interno di un fotogramma di testo.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedere a una diapositiva e aggiungere una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/).
3. Accedere al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma e cancellare il suo paragrafo predefinito.
4. Leggere il file HTML sorgente.
5. Passare la stringa HTML a [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphcollection/addfromhtml/).
6. Salvare la presentazione modificata.

Questo esempio C++ importa HTML in un fotogramma di testo:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Esportare il testo del paragrafo in HTML**

Utilizzare [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphcollection/exporttohtml/) per esportare un intervallo selezionato di paragrafi come HTML.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e caricare la presentazione desiderata.
2. Accedere alla diapositiva e trovare la [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) che contiene il testo.
3. Accedere al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma.
4. Chiamare [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphcollection/exporttohtml/) con l'indice del paragrafo di partenza e il numero di paragrafi da esportare.
5. Scrivere la stringa HTML restituita in un file.

Questo esempio C++ esporta tutti i paragrafi dalla prima forma di testo:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **Renderizzare un paragrafo come immagine**

[IParagraph::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getimage/) renderizza direttamente un singolo paragrafo e restituisce un [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/). Salvare il risultato in un file o stream con [IImage::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/save/). Non è necessario renderizzare la forma contenente o ritagliare manualmente una bitmap.

[IParagraph::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getimage/) può restituire `nullptr` se il paragrafo non si trova nella collezione genitore, non ha limiti di rendering validi o non può essere renderizzato. Verificare il risultato prima di salvarlo e rilasciare l'immagine restituita dopo l'uso.

#### **Renderizzare un paragrafo alla scala predefinita**

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, dove la prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

L'esempio seguente renderizza il secondo paragrafo in una forma di testo normale alla scala predefinita e salva l'immagine restituita in formato PNG.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

Il risultato:

![Immagine del paragrafo](paragraph_to_image_output.png)

#### **Renderizzare un paragrafo in una cella di tabella con scaling**

Utilizzare la sovraccarica di [IParagraph::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getimage/) che accetta i parametri `float scaleX` e `float scaleY` per impostare i fattori di scala orizzontale e verticale. L'esempio seguente crea una tabella, renderizza il paragrafo nella sua prima cella con il doppio della larghezza e altezza predefinite, e salva il risultato come immagine PNG.

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

Un fattore di scala `1` mantiene quell'asse alla dimensione pixel predefinita. Per esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono circa il doppio delle dimensioni predefinite, risultando in quattro volte più pixel. Fattori più grandi producono generalmente testo più nitido per lo zoom o output ad alta risoluzione, ma aumentano anche l'uso di memoria e la dimensione del file. Fattori inferiori a `1` producono immagini più piccole con minori dettagli. Utilizzare fattori uguali per preservare le proporzioni del paragrafo; fattori orizzontali e verticali differenti allungano l'output indipendentemente.

Renderizzare un'intera forma con [IShape::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/getimage/) resta utile quando l'output deve includere il riempimento, il bordo o altri contesti visivi della forma. Per un'immagine solo del paragrafo, usare [IParagraph::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Posso disabilitare completamente l'andamento del testo all'interno di un fotogramma di testo?**

Sì. Usare [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/set_wraptext/) per disabilitare l'andamento in modo che le linee non vengano interrotte ai bordi del fotogramma.

**Come posso ottenere i limiti esatti sullo slide di un paragrafo specifico?**

Usare [IParagraph::GetRect](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getrect/) per recuperare il rettangolo di delimitazione del paragrafo. [IPortion::GetRect](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/getrect/) fornisce i limiti di una singola porzione.

**Dove è controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_alignment/) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare la lingua di correzione per parte di un paragrafo?**

Sì. Usare [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/set_languageid/) per le singole porzioni, così un paragrafo può contenere testo in più lingue.