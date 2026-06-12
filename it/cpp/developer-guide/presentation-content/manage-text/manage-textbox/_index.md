---
title: Gestire le caselle di testo nelle presentazioni usando C++
linktitle: Gestire la casella di testo
type: docs
weight: 20
url: /it/cpp/manage-textbox/
keywords:
- casella di testo
- riquadro di testo
- aggiungere testo
- aggiornare testo
- creare casella di testo
- verificare casella di testo
- aggiungere colonna di testo
- aggiungere collegamento ipertestuale
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Aspose.Slides per C++ semplifica la creazione, modifica e clonazione delle caselle di testo nei file PowerPoint e OpenDocument, migliorando l'automazione delle tue presentazioni."
---
## **Introduzione**

I testi nelle diapositive si trovano tipicamente in caselle di testo o in forme. Per aggiungere quindi un testo a una diapositiva, è necessario aggiungere una casella di testo e quindi inserire del testo all’interno della casella. Aspose.Slides per C++ fornisce l’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape) che consente di aggiungere una forma contenente del testo.

{{% alert title="Info" color="info" %}}

Aspose.Slides fornisce anche l’interfaccia [IShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_shape) che permette di aggiungere forme alle diapositive. Tuttavia, non tutte le forme aggiunte tramite l’interfaccia `IShape` possono contenere testo. Le forme aggiunte tramite l’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape) invece possono contenere testo. 

{{% /alert %}}

{{% alert title="Nota" color="warning" %}} 

Pertanto, quando si lavora con una forma a cui si desidera aggiungere testo, è opportuno verificare e confermare che sia stata convertita tramite l’interfaccia `IAutoShape`. Solo in tal caso sarà possibile utilizzare [TextFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.text_frame), proprietà di `IAutoShape`. Vedi la sezione [Update Text](https://docs.aspose.com/slides/it/cpp/manage-textbox/#update-text) in questa pagina. 

{{% /alert %}}

## **Creare una casella di testo su una diapositiva**

Per creare una casella di testo su una diapositiva, segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation). 
2. Ottieni un riferimento alla prima diapositiva della presentazione appena creata. 
3. Aggiungi un oggetto [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape) con `ShapeType` impostato su `Rectangle` nella posizione desiderata sulla diapositiva e ottieni il riferimento all’oggetto `IAutoShape` appena aggiunto. 
4. Aggiungi la proprietà `TextFrame` all’oggetto `IAutoShape` che conterrà del testo. Nell’esempio seguente, abbiamo inserito questo testo: *Aspose TextBox*
5. Infine, scrivi il file PPTX tramite l’oggetto `Presentation`. 

Il codice C++—un’implementazione dei passaggi sopra descritti—mostra come aggiungere testo a una diapositiva:

```cpp
// Istanzia la presentazione
auto pres = System::MakeObject<Presentation>();

// Ottiene la prima diapositiva nella presentazione
auto sld = pres->get_Slides()->idx_get(0);

// Aggiunge un AutoShape con il tipo impostato su Rettangolo
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Aggiunge TextFrame al rettangolo
ashp->AddTextFrame(u" ");

// Accede al text frame
auto txtFrame = ashp->get_TextFrame();

// Crea l'oggetto Paragraph per il text frame
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Crea un oggetto Portion per il paragrafo
auto portion = para->get_Portions()->idx_get(0);

// Imposta il testo
portion->set_Text(u"Aspose TextBox");

// Salva la presentazione su disco
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Verificare la presenza di una forma casella di testo**

Aspose.Slides fornisce il metodo [get_IsTextBox](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/get_istextbox/) dell’interfaccia [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) per esaminare le forme e identificare le caselle di testo.

![Casella di testo e forma](istextbox.png)

Questo codice C++ mostra come verificare se una forma è stata creata come casella di testo: 

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
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

Nota che se aggiungi semplicemente un auto‑shape utilizzando il metodo `AddAutoShape` dell’interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/), il metodo `get_IsTextBox` dell’auto‑shape restituirà `false`. Tuttavia, dopo aver aggiunto testo all’auto‑shape con il metodo `AddTextFrame` o con il metodo `set_Text`, il metodo `get_IsTextBox` restituirà `true`.

```cpp
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

## **Aggiungere colonne a una casella di testo**

Aspose.Slides fornisce i metodi [set_ColumnCount](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) e [set_ColumnSpacing](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (dall’interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame_format) e dalla classe [TextFrameFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame_format)) che consentono di aggiungere colonne alle caselle di testo. È possibile specificare il numero di colonne in una casella di testo e impostare la spaziatura, in punti, tra le colonne. 

Il codice C++ seguente dimostra l’operazione descritta: 

```cpp
auto presentation = System::MakeObject<Presentation>();
// Ottiene la prima diapositiva nella presentazione
auto slide = presentation->get_Slides()->idx_get(0);

// Aggiunge un AutoShape con tipo impostato su Rettangolo
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

## **Aggiungere colonne a un Text Frame**

Aspose.Slides per C++ fornisce il metodo [set_ColumnCount](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (dall’interfaccia [ITextFrameFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_text_frame_format)) che consente di aggiungere colonne nei text frame. Attraverso questo metodo è possibile specificare il numero di colonne desiderato in un text frame. 

Questo codice C++ mostra come aggiungere una colonna all’interno di un text frame:

```cpp
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

## **Aggiornare il testo**

Aspose.Slides consente di modificare o aggiornare il testo contenuto in una casella di testo o tutti i testi presenti in una presentazione. 

Il codice C++ dimostra un’operazione in cui tutti i testi di una presentazione vengono aggiornati o modificati:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
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

## **Aggiungere una casella di testo con collegamento ipertestuale** 

È possibile inserire un collegamento all’interno di una casella di testo. Quando la casella di testo viene cliccata, gli utenti vengono indirizzati al collegamento. 

 Per aggiungere una casella di testo contenente un collegamento, segui questi passaggi:

1. Crea un’istanza della classe `Presentation`. 
2. Ottieni un riferimento alla prima diapositiva della presentazione appena creata. 
3. Aggiungi un oggetto `AutoShape` con `ShapeType` impostato su `Rectangle` nella posizione desiderata sulla diapositiva e ottieni il riferimento all’oggetto AutoShape appena aggiunto.
4. Aggiungi un `TextFrame` all’oggetto `AutoShape` contenente *Aspose TextBox* come testo predefinito. 
5. Istanzia la classe `IHyperlinkManager`. 
6. Assegna l’oggetto `IHyperlinkManager` al metodo [set_HyperlinkClick](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) associato alla porzione desiderata del `TextFrame`. 
7. Infine, scrivi il file PPTX tramite l’oggetto `Presentation`. 

Il codice C++—un’implementazione dei passaggi sopra descritti—mostra come aggiungere una casella di testo con collegamento ipertestuale a una diapositiva:

```cpp
// Istanzia una classe Presentation che rappresenta un PPTX
auto presentation = System::MakeObject<Presentation>();

// Ottiene la prima diapositiva nella presentazione
auto slide = presentation->get_Slides()->idx_get(0);

// Aggiunge un oggetto AutoShape con tipo impostato su Rettangolo
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Esegue il cast della forma a AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Accede alla proprietà ITextFrame associata all'AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Aggiunge del testo al riquadro
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Imposta il collegamento ipertestuale per il testo della porzione
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Salva la presentazione PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Qual è la differenza tra una casella di testo e un segnaposto di testo quando si lavora con le diapositive master?**

Un [placeholder](/slides/it/cpp/manage-placeholder/) eredita stile/posizione dal [master](https://reference.aspose.com/slides/it/cpp/aspose.slides/masterslide/) e può essere sovrascritto nei [layout](https://reference.aspose.com/slides/it/cpp/aspose.slides/layoutslide/), mentre una casella di testo normale è un oggetto indipendente su una diapositiva specifica e non cambia quando si passa a un altro layout.

**Come posso eseguire una sostituzione massiva di testo nella presentazione senza modificare il testo all’interno di grafici, tabelle e SmartArt?**

Limita l’iterazione alle auto‑shape che possiedono text frame ed escludi gli oggetti incorporati ([grafici](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chart/), [tabelle](https://reference.aspose.com/slides/it/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartart/)) attraversando le loro collezioni separatamente o saltando quei tipi di oggetto.