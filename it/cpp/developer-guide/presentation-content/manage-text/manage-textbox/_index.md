---
title: Gestire le caselle di testo nelle presentazioni usando C++
linktitle: Gestisci la casella di testo
type: docs
weight: 20
url: /it/cpp/manage-textbox/
keywords:
- casella di testo
- frame di testo
- aggiungi testo
- aggiorna testo
- crea casella di testo
- verifica casella di testo
- aggiungi colonna di testo
- aggiungi collegamento ipertestuale
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Aspose.Slides per C++ rende facile creare, modificare e clonare le caselle di testo nei file PowerPoint e OpenDocument, migliorando l'automazione delle tue presentazioni."
---
## **Introduzione**

I testi nelle diapositive si trovano tipicamente in caselle di testo o forme. Pertanto, per aggiungere del testo a una diapositiva, è necessario aggiungere una casella di testo e quindi inserire del testo all’interno della casella stessa. Aspose.Slides per C++ fornisce l’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape) che consente di aggiungere una forma contenente del testo.

{{% alert title="Info" color="info" %}}
Aspose.Slides fornisce anche l’interfaccia [IShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_shape) che permette di aggiungere forme alle diapositive. Tuttavia, non tutte le forme aggiunte tramite l’interfaccia `IShape` possono contenere testo. Le forme aggiunte tramite l’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape) invece possono contenere testo. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Pertanto, quando si lavora con una forma a cui si desidera aggiungere testo, è opportuno verificare e confermare che sia stata convertita tramite l’interfaccia `IAutoShape`. Solo così sarà possibile lavorare con [TextFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.text_frame), che è una proprietà di `IAutoShape`. Vedi la sezione [Update Text](https://docs.aspose.com/slides/it/cpp/manage-textbox/#update-text) in questa pagina. 
{{% /alert %}}

## **Crea una casella di testo su una diapositiva**

Per creare una casella di testo su una diapositiva, segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).  
2. Ottieni un riferimento alla prima diapositiva della presentazione appena creata.  
3. Aggiungi un oggetto [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape) con [ShapeType](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) impostato su `Rectangle` in una posizione specificata sulla diapositiva e ottieni il riferimento per il nuovo oggetto `IAutoShape`.  
4. Aggiungi la proprietà `TextFrame` all’oggetto `IAutoShape` che conterrà del testo. Nell’esempio sottostante, abbiamo aggiunto questo testo: *Aspose TextBox*  
5. Infine, scrivi il file PPTX tramite l’oggetto `Presentation`.  

Questo codice C++—un’implementazione dei passaggi sopra—mostra come aggiungere testo a una diapositiva:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Istanzia la presentazione
auto pres = System::MakeObject<Presentation>();

// Ottiene la prima diapositiva nella presentazione
auto sld = pres->get_Slides()->idx_get(0);

// Aggiunge un AutoShape con tipo impostato a Rettangolo
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Aggiunge TextFrame al rettangolo
ashp->AddTextFrame(u" ");

// Accede al frame di testo
auto txtFrame = ashp->get_TextFrame();

// Crea l'oggetto Paragraph per il frame di testo
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Crea un oggetto Portion per il paragrafo
auto portion = para->get_Portions()->idx_get(0);

// Imposta il testo
portion->set_Text(u"Aspose TextBox");

// Salva la presentazione su disco
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Verifica una forma di casella di testo**

Aspose.Slides fornisce il metodo [get_IsTextBox](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/get_istextbox/) dell’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) per esaminare le forme e identificare le caselle di testo.

![Casella di testo e forma](istextbox.png)

Questo codice C++ mostra come verificare se una forma è stata creata come casella di testo: 

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Nota che se aggiungi semplicemente un’autoshape usando il metodo `AddAutoShape` dell’interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/), il metodo `get_IsTextBox` dell’autoshape restituirà `false`. Tuttavia, dopo aver aggiunto testo all’autoshape usando il metodo `AddTextFrame` o il metodo `set_Text`, il metodo `get_IsTextBox` restituisce `true`.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() restituisce false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() restituisce true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() restituisce false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() restituisce true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() restituisce false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() restituisce false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() restituisce false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() restituisce false
```

## **Trova la forma che possiede un TextFrame**

Nel codice generico di elaborazione del testo, potresti ricevere un [ITextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/) senza sapere a quale oggetto di presentazione appartenga. Usa [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_parentshape/) per tornare alla [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) proprietaria.

Per un TextFrame che appartiene a una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) o a un’altra forma contenente testo, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_parentshape/) restituisce il proprietario e [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframe/get_parentcell/) restituisce `nullptr`. Entrambi i metodi forniscono una navigazione in sola lettura, quindi chiamarli non cambia la proprietà. Controlla sempre il valore restituito per `nullptr` prima di accedere alla forma.

Per un esempio completo che individua i proprietari di forme e celle di tabella, incluse le forme associate a nodi SmartArt, vedi [Search and Replace Text](/slides/it/cpp/search-and-replace-text/).

## **Aggiungi colonne a una casella di testo**

Aspose.Slides fornisce i metodi [set_ColumnCount](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) e [set_ColumnSpacing](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (dell’interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame_format) e della classe [TextFrameFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame_format)) che consentono di aggiungere colonne alle caselle di testo. Puoi specificare il numero di colonne in una casella di testo e impostare la spaziatura in punti tra le colonne. 

Questo codice C++ dimostra l’operazione descritta: 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// Ottiene la prima diapositiva nella presentazione
auto slide = presentation->get_Slides()->idx_get(0);

// Aggiunge un AutoShape con tipo impostato a Rettangolo
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Aggiunge TextFrame al rettangolo
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Ottiene il formato del testo del TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Specifica il numero di colonne nel TextFrame
format->set_ColumnCount(3);

// Specifica la spaziatura tra le colonne
format->set_ColumnSpacing(10);

// Salva la presentazione
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Aggiungi colonne a un TextFrame**
Aspose.Slides per C++ fornisce il metodo [set_ColumnCount](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (dell’interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame_format)) che consente di aggiungere colonne nei TextFrame. Attraverso questo metodo, puoi specificare il numero desiderato di colonne in un TextFrame. 

Questo codice C++ mostra come aggiungere una colonna all’interno di un TextFrame:

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Aggiorna testo**

Aspose.Slides consente di modificare o aggiornare il testo contenuto in una casella di testo o tutti i testi contenuti in una presentazione. 

Questo codice C++ dimostra un’operazione in cui tutti i testi di una presentazione vengono aggiornati o modificati:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //Modifica il testo
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Modifica la formattazione
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Salva la presentazione modificata
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Aggiungi una casella di testo con un collegamento ipertestuale** 

Puoi inserire un collegamento all’interno di una casella di testo. Quando la casella di testo viene cliccata, gli utenti vengono indirizzati al collegamento. 

Per aggiungere una casella di testo contenente un collegamento, segui questi passaggi:

1. Crea un’istanza della classe `Presentation`.  
2. Ottieni un riferimento alla prima diapositiva della presentazione appena creata.  
3. Aggiungi un oggetto `AutoShape` con `ShapeType` impostato su `Rectangle` in una posizione specificata sulla diapositiva e ottieni il riferimento del nuovo oggetto AutoShape.  
4. Aggiungi un `TextFrame` all’oggetto `AutoShape` che contiene *Aspose TextBox* come testo predefinito.  
5. Istanzia la classe `IHyperlinkManager`.  
6. Assegna l’oggetto `IHyperlinkManager` al metodo [set_HyperlinkClick](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) associato alla porzione desiderata del `TextFrame`.  
7. Infine, scrivi il file PPTX tramite l’oggetto `Presentation`. 

Questo codice C++—un’implementazione dei passaggi sopra—mostra come aggiungere una casella di testo con un collegamento ipertestuale a una diapositiva:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Istanzia una classe Presentation che rappresenta un PPTX
auto presentation = System::MakeObject<Presentation>();

// Ottiene la prima diapositiva nella presentazione
auto slide = presentation->get_Slides()->idx_get(0);

// Aggiunge un oggetto AutoShape con tipo impostato a Rettangolo
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Esegue il cast della forma a AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Accede alla proprietà ITextFrame associata all'AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Aggiunge del testo al frame
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Imposta il collegamento ipertestuale per il testo della porzione
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Salva la presentazione PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Qual è la differenza tra una casella di testo e un segnaposto di testo quando si lavora con le diapositive master?**

Un [placeholder](/slides/it/cpp/manage-placeholder/) eredita stile/posizione dal [master](https://reference.aspose.com/slides/it/cpp/aspose.slides/masterslide/) e può essere sovrascritto nei [layout](https://reference.aspose.com/slides/it/cpp/aspose.slides/layoutslide/), mentre una normale casella di testo è un oggetto indipendente su una diapositiva specifica e non cambia quando si cambiano i layout.

**Come posso eseguire una sostituzione di massa del testo nell'intera presentazione senza modificare il testo all'interno di grafici, tabelle e SmartArt?**

Limita l’iterazione alle auto‑forme che possiedono TextFrame ed escludi gli oggetti incorporati ([grafici](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chart/), [tabelle](https://reference.aspose.com/slides/it/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartart/)) attraversando le loro collezioni separatamente o saltando quei tipi di oggetto.