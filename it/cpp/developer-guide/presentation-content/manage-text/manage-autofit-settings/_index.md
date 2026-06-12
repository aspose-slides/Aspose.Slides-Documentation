---
title: "Migliora le tue presentazioni con AutoFit in C++"
linktitle: "Impostazioni Autofit"
type: docs
weight: 30
url: /it/cpp/manage-autofit-settings/
keywords:
- casella di testo
- autoadattamento
- non autoadattamento
- adatta testo
- riduci testo
- avvolgi testo
- ridimensiona forma
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come gestire le impostazioni AutoFit in Aspose.Slides per C++ per ottimizzare la visualizzazione del testo nelle tue presentazioni PowerPoint e OpenDocument e migliorare la leggibilità dei contenuti."
---
## **Introduzione**

Per impostazione predefinita, quando aggiungi una casella di testo, Microsoft PowerPoint utilizza l'impostazione **Resize shape to fix text** per la casella di testo—ridimensiona automaticamente la casella di testo per garantire che il suo contenuto si adatti sempre. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Quando il testo nella casella di testo diventa più lungo o più grande, PowerPoint ingrandisce automaticamente la casella di testo—aumentandone l'altezza—per consentirle di contenere più testo. 
* Quando il testo nella casella di testo diventa più corto o più piccolo, PowerPoint riduce automaticamente la casella di testo—diminuendone l'altezza—per eliminare lo spazio superfluo. 

In PowerPoint, questi sono i 4 parametri o opzioni importanti che controllano il comportamento di autofit per una casella di testo: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ fornisce opzioni simili—alcuni metodi nella classe [TextFrameFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.text_frame_format)—che consentono di controllare il comportamento di autofit per le caselle di testo nelle presentazioni. 

## **Ridimensionare una Forma per Adattare il Testo**

Se vuoi che il testo in una casella si adatti sempre a quella casella dopo aver modificato il testo, devi utilizzare l'opzione **Resize shape to fix text**. Per specificare questa impostazione, imposta la proprietà [AutofitType](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.text_frame_format)) su `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Questo codice C++ mostra come specificare che un testo debba sempre adattarsi alla sua casella in una presentazione PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Se il testo diventa più lungo o più grande, la casella di testo verrà ridimensionata automaticamente (aumentandone l'altezza) per garantire che tutto il testo vi si adatti. Se il testo diventa più corto, avverrà il contrario. 

## **Non Autofit**

Se desideri che una casella di testo o una forma mantenga le sue dimensioni indipendentemente dalle modifiche al testo contenuto, devi utilizzare l'opzione **Do not Autofit**. Per specificare questa impostazione, imposta la proprietà [AutofitType](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.text_frame_format)) su `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Questo codice C++ mostra come specificare che una casella di testo debba sempre mantenere le sue dimensioni in una presentazione PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Quando il testo diventa troppo lungo per la sua casella, trabocca. 

## **Riduci il testo in caso di overflow**

Se un testo diventa troppo lungo per la sua casella, usando l'opzione **Shrink text on overflow**, puoi specificare che la dimensione e la spaziatura del testo debbano essere ridotte per farlo adattare alla casella. Per specificare questa impostazione, imposta la proprietà [AutofitType](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.text_frame_format)) su `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Questo codice C++ mostra come specificare che un testo debba essere ridotto in caso di overflow in una presentazione PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Info" color="info" %}}
Quando viene usata l'opzione **Shrink text on overflow**, l'impostazione viene applicata solo quando il testo diventa troppo lungo per la casella.
{{% /alert %}}

## **Testo a capo**

Se vuoi che il testo in una forma venga avvolto all'interno di quella forma quando il testo supera il bordo della forma (solo in larghezza), devi utilizzare il parametro **Wrap text in shape**. Per specificare questa impostazione, è necessario impostare la proprietà [WrapText](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (della classe [TextFrameFormat](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.text_frame_format)) su `true`. 

Questo codice C++ mostra come utilizzare l'impostazione Wrap Text in una presentazione PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Se imposti la proprietà `WrapText` su `False` per una forma, quando il testo all'interno della forma diventa più lungo della larghezza della forma, il testo si estende oltre i bordi della forma su un'unica riga. 
{{% /alert %}}

## **FAQ**

**Le margini interni del frame di testo influiscono su AutoFit?**

Sì. Il padding (margini interni) riduce l'area utilizzabile per il testo, quindi AutoFit si attiva prima—riducendo il carattere o ridimensionando la forma più rapidamente. Verifica e regola i margini prima di ottimizzare AutoFit.

**Come interagisce AutoFit con interruzioni di riga manuali e morbide?**

Le interruzioni forzate rimangono al loro posto, e AutoFit adatta la dimensione del carattere e la spaziatura intorno a esse. Rimuovere le interruzioni non necessarie riduce spesso l'intensità con cui AutoFit deve rimpicciolire il testo.

**Modificare il font del tema o attivare la sostituzione del font influisce sui risultati di AutoFit?**

Sì. Sostituire con un font con metriche dei glifi diverse cambia la larghezza/altezza del testo, il che può alterare la dimensione finale del carattere e l'avvolgimento delle linee. Dopo qualsiasi modifica o sostituzione del font, ricontrolla le diapositive.