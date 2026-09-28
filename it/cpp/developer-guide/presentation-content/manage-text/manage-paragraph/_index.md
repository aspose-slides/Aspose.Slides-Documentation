---
title: Gestire i paragrafi di testo PowerPoint in C++
linktitle: Gestisci Paragrafo
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
- gestire punto
- rientro paragrafico
- rientro sospeso
- punto del paragrafo
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
description: "Scopri come creare e formattare paragrafi, porzioni, punti, elenchi numerati, rientri, contenuti HTML e immagini di paragrafi con Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides per C++ rappresenta il testo come una gerarchia di cornici di testo, paragrafi e porzioni:

* [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) rappresenta il contenitore di testo in una forma e fornisce l'accesso alla sua raccolta di paragrafi.
* [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/) rappresenta un paragrafo in una cornice di testo e fornisce l'accesso alle sue porzioni e alla formattazione a livello di paragrafo.
* [IPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/) rappresenta un segmento di testo all'interno di un paragrafo. Ogni porzione può avere il proprio testo e formattazione a livello di carattere.

Un paragrafo può quindi contenere testo con caratteri, colori, dimensioni e altre formattazioni diverse utilizzando più porzioni.

## **Creare e Formattare i Paragrafi**

### **Creare Paragrafi con più Porzioni**

I seguenti passaggi creano una cornice di testo con tre paragrafi, ciascuno contenente tre porzioni:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma.
5. Usa il paragrafo predefinito e aggiungi altri due oggetti [IParagraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/) alla cornice di testo.
6. Aggiungi sufficienti oggetti [IPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/) per ciascun paragrafo in modo che contenga tre porzioni. Il paragrafo predefinito contiene già una porzione vuota.
7. Imposta il testo di ogni porzione.
8. Applica la formattazione a livello di carattere tramite [IPortion::get_PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/get_portionformat/).
9. Salva la presentazione modificata.

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

## **Creare Elenchi Puntati e Numerati**

### **Creare un Elenco Puntato o Numerato**

I punti e la numerazione rendono gli elementi correlati più facili da scorrere. In Aspose.Slides, le impostazioni dell'elenco sono definite tramite [IBulletFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/).

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva selezionata.
4. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma.
5. Rimuovi il paragrafo predefinito dalla cornice di testo.
6. Crea un [Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraph/) per un punto simbolico.
7. Imposta [IBulletFormat::set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_type/) a [BulletType::Symbol](https://reference.aspose.com/slides/it/cpp/aspose.slides/bullettype/) e specifica il carattere del punto.
8. Imposta il testo del paragrafo, il rientro, il colore del punto e l'altezza del punto.
9. Aggiungi il paragrafo alla cornice di testo.
10. Crea un secondo paragrafo e imposta [IBulletFormat::set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_type/) a [BulletType::Numbered](https://reference.aspose.com/slides/it/cpp/aspose.slides/bullettype/).
11. Configura lo stile del punto numerato e aggiungi il paragrafo alla cornice di testo.
12. Salva la presentazione.

Questo esempio C++ crea un punto simbolico e un punto numerato:

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

### **Utilizzare Punti Immagine**

I punti immagine consentono di utilizzare un'immagine personalizzata al posto di un simbolo o di un numero.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi al riferimento della diapositiva pertinente tramite il suo indice.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) e accedi al suo [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/).
4. Rimuovi il paragrafo predefinito dalla cornice di testo.
5. Carica l'immagine del punto e aggiungila alla raccolta di immagini della presentazione come [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/).
6. Crea un [Paragraph](https://reference.aspose.com/slides/it/cpp/aspose.slides/paragraph/) e imposta il suo testo.
7. Imposta [IBulletFormat::set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_type/) a [BulletType::Picture](https://reference.aspose.com/slides/it/cpp/aspose.slides/bullettype/).
8. Assegna l'immagine tramite [ISlidesPicture::set_Image](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidespicture/set_image/) e imposta l'altezza del punto.
9. Aggiungi il paragrafo alla cornice di testo.
10. Salva la presentazione modificata.

Questo esempio C++ crea un punto immagine:

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

### **Creare un Elenco Multilivello**

Imposta [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_depth/) per posizionare i paragrafi a diversi livelli di un elenco. Il livello superiore ha una profondità di `0`.

1. Crea una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) e rimuovi il paragrafo predefinito dalla sua cornice di testo.
3. Crea quattro paragrafi e configura i loro simboli di punto.
4. Imposta i loro valori [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_depth/) a `0`, `1`, `2` e `3`.
5. Aggiungi i paragrafi alla cornice di testo e salva la presentazione.

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

### **Iniziare gli Elementi Numerati dell'Elenco con Valori Personalizzati**

Usa [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) per impostare il numero iniziale visualizzato per un paragrafo numerato.

1. Crea una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) a una diapositiva.
2. Rimuovi il paragrafo predefinito dalla cornice di testo della forma.
3. Crea tre paragrafi numerati.
4. Imposta [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) a `2`, `3` e `7` per i rispettivi paragrafi.
5. Aggiungi i paragrafi alla cornice di testo e salva la presentazione.

Questo esempio C++ assegna un numero iniziale personalizzato a ciascun paragrafo:

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

## **Controllare il Layout del Paragrafo e le Proprietà di Fine**

### **Impostare un Rientro della Prima Linea**

Usa [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) per controllare il rientro della prima linea di un paragrafo. Questo metodo sposta solo la prima linea rispetto al margine sinistro del paragrafo. Un valore positivo sposta la prima linea verso destra, mentre le linee rimanenti rimangono allineate al corpo del paragrafo.

Usa [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_marginleft/) quando devi spostare l'intero paragrafo. Usa [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) quando devi spostare solo la prima linea.

L'esempio seguente crea diversi paragrafi e applica diversi valori [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) per dimostrare come il rientro della prima linea influisce sul layout del paragrafo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma e rimuovi il paragrafo predefinito.
5. Crea diversi paragrafi e imposta valori diversi di [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) per ciascuno.
6. Aggiungi i paragrafi alla cornice di testo.
7. Salva la presentazione modificata.

Questo codice mostra come impostare un rientro del paragrafo:

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

![Il rientro della prima linea dei paragrafi](first_line_indent.png)

### **Impostare un Rientro Sospeso**

Un rientro sospeso è un layout di paragrafo in cui la prima linea inizia a sinistra delle linee rimanenti. In Aspose.Slides, crei questo effetto con [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/). Imposta il rientro a un valore negativo per spostare la prima linea a sinistra rispetto al corpo del paragrafo.

In pratica, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_marginleft/) definisce la posizione sinistra del corpo del paragrafo, e [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) definisce la posizione della prima linea rispetto a quel margine. Per creare un rientro sospeso, imposta un valore positivo per margin-left e un valore negativo per indent.

Questa formattazione è utile per bibliografie, riferimenti, voci di glossario e altri paragrafi in cui le linee a capo devono allinearsi sotto il corpo del paragrafo anziché sotto il primo carattere della prima linea.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi alla diapositiva di destinazione.
3. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) rettangolare alla diapositiva.
4. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma e rimuovi il paragrafo predefinito.
5. Crea paragrafi e imposta un valore positivo di [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_marginleft/) per ciascun paragrafo.
6. Imposta un valore negativo di [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_indent/) per creare l'effetto del rientro sospeso.
7. Aggiungi i paragrafi alla cornice di testo.
8. Salva la presentazione modificata.

Questo codice mostra come impostare un rientro sospeso per un paragrafo:

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

![Il rientro sospeso dei paragrafi](hanging_indent.png)

### **Impostare le Proprietà di Esecuzione del Paragrafo di Fine**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) controlla la formattazione del segno di fine paragrafo. Il seguente esempio assegna una dimensione del carattere e un font latino al segno di fine del secondo paragrafo:

1. Carica una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e accedi a una diapositiva.
2. Aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) e rimuovi il suo paragrafo predefinito.
3. Crea due paragrafi e aggiungi porzioni di testo a ciascuno.
4. Crea un [PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/portionformat/) per il segno di fine del secondo paragrafo.
5. Imposta [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/set_fontheight/) e [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/set_latinfont/).
6. Assegna il formato con [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) e salva la presentazione.

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

## **Contare le Linee Renderizzate**

Per le regole di paragrafo che influenzano il ritorno a capo automatico e la punteggiatura alla fine delle linee, vedi [Control Line Breaking](/slides/it/cpp/text-formatting/#control-line-breaking) e [Control Hanging Punctuation](/slides/it/cpp/text-formatting/#control-hanging-punctuation).

Usa [IParagraph::GetLinesCount](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getlinescount/) per contare le linee occupate da un paragrafo dopo il layout del testo, includendo il ritorno a capo automatico. Ciò è utile quando si verifica la lunghezza del testo e il layout nei modelli di presentazione.

Un paragrafo è un elemento in [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_paragraphs/) e può occupare diverse linee renderizzate. Un'interruzione di riga esplicita all'interno di un paragrafo forza una nuova linea senza creare un altro paragrafo. Il ritorno a capo automatico crea linee in base alla larghezza disponibile senza inserire interruzioni di riga esplicite nel testo. Pertanto, contare i paragrafi o i caratteri di interruzione di riga non fornisce il conteggio delle linee renderizzate.

Il seguente esempio crea una forma di testo, conta le sue linee, restringe la forma e poi sostituisce il testo con una stringa più corta. Il ritorno a capo è abilitato e l'autofit è disabilitato in modo che la larghezza della forma controlli il ritorno a capo senza ridurre automaticamente il testo o ridimensionare la forma. Le dimensioni della forma sono in punti. Infine, l'esempio aggiunge un altro paragrafo e somma i conteggi delle linee all'interno della cornice di testo.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

Con questo testo e queste dimensioni, restringere la forma aumenta il conteggio delle linee, mentre sostituire il testo con la stringa corta lo riduce. I conteggi esatti possono variare in base alla disponibilità e sostituzione dei caratteri, dimensione del font, margini, rientro, ritorno a capo e impostazioni di autofit. Usa i font e le impostazioni di layout previste per l'ambiente di destinazione quando controlli un modello.

Il solo conteggio delle linee non determina se il testo trabocca dal contenitore. Anche l'altezza disponibile, le altezze delle linee, la spaziatura dei paragrafi e delle linee, e il comportamento dell'autofit sono importanti; anche una singola linea può superare la larghezza disponibile quando il ritorno a capo è disabilitato.

## **Importare ed Esportare il Contenuto dei Paragrafi**

### **Importare Testo HTML nei Paragrafi**

Usa [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphcollection/addfromhtml/) per convertire il markup HTML in paragrafi e porzioni in una cornice di testo.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Accedi a una diapositiva e aggiungi una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/).
3. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma e rimuovi il suo paragrafo predefinito.
4. Leggi il file HTML di origine.
5. Passa la stringa HTML a [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphcollection/addfromhtml/).
6. Salva la presentazione modificata.

Questo esempio C++ importa HTML in una cornice di testo:

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

### **Esportare il Testo del Paragrafo in HTML**

Usa [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphcollection/exporttohtml/) per esportare un intervallo selezionato di paragrafi come HTML.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e carica la presentazione desiderata.
2. Accedi alla diapositiva e trova la [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) che contiene il testo.
3. Accedi al [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) della forma.
4. Chiama [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphcollection/exporttohtml/) con l'indice del paragrafo iniziale e il numero di paragrafi da esportare.
5. Scrivi la stringa HTML restituita in un file.

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

### **Renderizzare un Paragrafo Come Immagine**

[IParagraph::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getimage/) renderizza direttamente un singolo paragrafo e restituisce un [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/). Salva il risultato in un file o stream con [IImage::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/save/). Non è necessario renderizzare la forma contenente o ritagliare manualmente una bitmap.

[IParagraph::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getimage/) può restituire `nullptr` se il paragrafo non è trovato nella sua collezione padre, non ha limiti di rendering validi o non può essere renderizzato. Controlla il risultato prima di salvarlo e rilascia l'immagine restituita dopo l'uso.

#### **Renderizzare un Paragrafo alla Scala Predefinita**

Supponiamo di avere un file di presentazione chiamato sample.pptx con una diapositiva, dove la prima forma è una casella di testo contenente tre paragrafi.

![La casella di testo con tre paragrafi](paragraph_to_image_input.png)

Il seguente esempio renderizza il secondo paragrafo in una forma di testo regolare alla scala predefinita e salva l'immagine restituita in formato PNG.

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

![L'immagine del paragrafo](paragraph_to_image_output.png)

#### **Renderizzare un Paragrafo in una Cella di Tabella con Scaling**

Usa il sovraccarico di [IParagraph::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getimage/) che accetta i parametri `float scaleX` e `float scaleY` per impostare i fattori di scala orizzontale e verticale. Il seguente esempio crea una tabella, renderizza il paragrafo nella sua prima cella a una larghezza e altezza doppie rispetto alla scala predefinita, e salva il risultato come immagine PNG.

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

Un fattore di scala di `1` mantiene quell'asse alla sua dimensione di pixel predefinita. Per esempio, `2` per entrambi i fattori produce un'immagine la cui larghezza e altezza sono approssimativamente il doppio delle dimensioni predefinite, risultando in quattro volte più pixel. Fattori più grandi producono generalmente testo più nitido per ingrandimenti o output ad alta risoluzione, ma aumentano anche l'uso di memoria e le dimensioni del file. Fattori inferiori a `1` producono immagini più piccole con meno dettagli. Usa fattori uguali per preservare il rapporto d'aspetto del paragrafo; fattori orizzontali e verticali diversi allungano l'output indipendentemente.

Renderizzare un'intera forma con [IShape::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/getimage/) è utile quando l'output deve includere il riempimento, il bordo o altro contesto visivo della forma. Per un'immagine solo di paragrafo, usa [IParagraph::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Posso disabilitare completamente il ritorno a capo all'interno di una cornice di testo?**

Sì. Usa [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformat/set_wraptext/) per disabilitare il wrapping così le linee non si interrompono ai bordi della cornice di testo.

**Come posso ottenere i limiti esatti sulla diapositiva di un paragrafo specifico?**

Usa [IParagraph::GetRect](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraph/getrect/) per recuperare il rettangolo di delimitazione del paragrafo. [IPortion::GetRect](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/getrect/) fornisce i limiti di una singola porzione.

**Dove è controllato l'allineamento del paragrafo (sinistra, destra, centro o giustificato)?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/it/cpp/aspose.slides/iparagraphformat/set_alignment/) è un'impostazione a livello di paragrafo e si applica all'intero paragrafo indipendentemente dalla formattazione delle singole porzioni.

**Posso impostare la lingua di correzione per una parte di un paragrafo?**

Sì. Usa [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/set_languageid/) per le singole porzioni, così un paragrafo può contenere testo in più lingue.