---
title: Gestire i segnaposti della presentazione in C++
linktitle: Gestire i segnaposti
type: docs
weight: 10
url: /it/cpp/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- testo di suggerimento
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci senza sforzo i segnaposti in Aspose.Slides per C++: sostituisci il testo, personalizza i suggerimenti e imposta la trasparenza delle immagini in PowerPoint e OpenDocument."
---
## **Panoramica**

Aspose.Slides consente di gestire i segnaposti delle presentazioni in modo programmatico. Questo articolo spiega come trovare i segnaposti nelle diapositive e modificare il loro testo, impostare testi di suggerimento personalizzati per i layout dei segnaposti e regolare la trasparenza di un'immagine utilizzata come sfondo del segnaposto. Include anche una breve FAQ che chiarisce la differenza tra segnaposti di base e forme locali, spiega come le modifiche ai segnaposti possono essere applicate tramite layout o master e indica la gestione dei segnaposti di intestazione e piè di pagina.

## **Modifica del testo in un segnaposto**
Utilizzando [Aspose.Slides for C++](/slides/it/cpp/), è possibile trovare e modificare i segnaposti nelle diapositive delle presentazioni. Aspose.Slides consente di apportare modifiche al testo di un segnaposto.

**Prerequisito**: è necessaria una presentazione che contenga un segnaposto. È possibile creare tale presentazione con l’applicazione standard Microsoft PowerPoint.

Ecco come utilizzare Aspose.Slides per sostituire il testo nel segnaposto di quella presentazione:

1. Istanziare la classe [`Presentation`](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation/) e passare la presentazione come argomento.
2. Ottenere un riferimento alla diapositiva tramite il suo indice.
3. Scorrere le forme per trovare il segnaposto.
4. Eseguire il cast della forma segnaposto a un [`AutoShape`](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.auto_shape/) e modificare il testo usando il [`TextFrame`](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.text_frame/) associato al [`AutoShape`](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.auto_shape/).
5. Salvare la presentazione modificata.

Questo codice C++ mostra come modificare il testo in un segnaposto:

```c++
// Il percorso della directory dei documenti.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Carica la presentazione desiderata
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Accede alla prima diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Accede al primo e al secondo segnaposto nella diapositiva e lo converte in un AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Salva la presentazione su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Imposta il testo di suggerimento in un segnaposto**
I layout standard e predefiniti contengono testi di suggerimento per i segnaposti come ***Fare clic per aggiungere un titolo*** o ***Fare clic per aggiungere un sottotitolo***. Con Aspose.Slides è possibile inserire i propri testi di suggerimento preferiti nei layout dei segnaposti.

Questo codice C++ mostra come impostare il testo di suggerimento in un segnaposto:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Quando non c'è testo, PowerPoint visualizza "Click to add title". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Fa la stessa cosa per il sottotitolo.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Imposta la trasparenza dell'immagine del segnaposto**

Aspose.Slides consente di impostare la trasparenza dell'immagine di sfondo in un segnaposto di testo. Regolando la trasparenza dell'immagine in tale cornice, è possibile far risaltare il testo o l'immagine (a seconda dei colori del testo e dell'immagine).

Questo codice C++ mostra come impostare la trasparenza per lo sfondo di un'immagine (all'interno di una forma):

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **FAQ**

**Che cos'è un segnaposto di base e in che modo differisce da una forma locale su una diapositiva?**

Un segnaposto di base è la forma originale su un layout o master da cui la forma della diapositiva eredita - tipo, posizione e parte della formattazione provengono da esso. Una forma locale è indipendente; se non esiste un segnaposto di base, l'ereditarietà non si applica.

**Come posso aggiornare tutti i titoli o le didascalie in una presentazione senza iterare su ogni diapositiva?**

Modificare il segnaposto corrispondente sul layout o sul master. Le diapositive basate su quei layout/master erediteranno automaticamente la modifica.

**Come gestisco i segnaposti standard di intestazione/piè di pagina - data e ora, numero diapositiva e testo del piè di pagina?**

Utilizzare i gestori HeaderFooter nell'ambito appropriato (diapositive normali, layout, master, note/handout) per attivare o disattivare questi segnaposti e impostarne il contenuto.