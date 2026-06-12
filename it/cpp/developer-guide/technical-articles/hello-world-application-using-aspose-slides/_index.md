---
title: Applicazione Hello World usando Aspose.Slides per C++
type: docs
weight: 80
url: /it/cpp/hello-world-application-using-aspose-slides/
keywords:
- ciao mondo
- applicazione
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Crea la tua prima app C++ con Aspose.Slides, un semplice esempio Hello World che ti prepara ad automatizzare le presentazioni PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo mostra come creare una semplice presentazione PowerPoint **Hello World** utilizzando Aspose.Slides. L'esempio dimostra come creare una nuova presentazione, accedere alla prima diapositiva, aggiungere un'AutoShape rettangolare in una posizione specificata, inserire un riquadro di testo contenente il testo **Hello World**, e regolare la formattazione della forma e del testo.

Spiega inoltre come rendere visibile il testo cambiandone il colore in nero, nascondere il bordo della forma impostando il colore della linea su bianco, rimuovere il riempimento della forma e salvare la presentazione come file PPTX.

## **Passaggi per creare un'applicazione Hello World**

Segui i passaggi seguenti per creare un'applicazione **Hello World** utilizzando l'API Aspose.Slides per C++:

- Crea un'istanza della classe Presentation
- Ottieni il riferimento della prima diapositiva nella presentazione, creata al momento dell'istanziazione di Presentation.
- Aggiungi un'AutoShape con ShapeType impostato a Rectangle nella posizione specificata della diapositiva.
- Aggiungi un TextFrame all'AutoShape contenente Hello World come testo predefinito
- Cambia il colore del testo in nero, poiché è bianco per impostazione predefinita e non è visibile sulla diapositiva con sfondo bianco
- Modifica il colore della linea della forma in bianco per nascondere il bordo della forma
- Rimuovi il formato di riempimento predefinito della forma
- Infine, scrivi la presentazione nel formato di file desiderato utilizzando l'oggetto Presentation

L'implementazione dei passaggi sopra indicati è mostrata di seguito in un esempio.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // ottieni la prima diapositiva
    auto slide = pres->get_Slides()->idx_get(0);

    // aggiungi un'AutoShape di tipo rettangolo
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // aggiungi TextFrame al rettangolo
    shape->AddTextFrame(u"Hello World");

    // cambia il colore del testo in nero (che è bianco per impostazione predefinita)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // cambia il colore della linea del rettangolo in bianco
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // rimuovi qualsiasi formattazione di riempimento nella forma
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // salva la presentazione su disco
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```