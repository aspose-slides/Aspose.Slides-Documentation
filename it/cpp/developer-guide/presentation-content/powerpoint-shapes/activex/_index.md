---
title: Gestire i controlli ActiveX nelle presentazioni usando C++
linktitle: ActiveX
type: docs
weight: 80
url: /it/cpp/activex/
keywords:
- ActiveX
- controllo ActiveX
- gestire ActiveX
- aggiungere ActiveX
- modificare ActiveX
- lettore multimediale
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come Aspose.Slides per C++ sfrutta ActiveX per automatizzare e migliorare le presentazioni PowerPoint, offrendo agli sviluppatori un controllo potente sulle diapositive."
---
## **Introduzione**

I controlli ActiveX sono usati nelle presentazioni. Aspose.Slides per C++ consente di gestire i controlli ActiveX, ma la loro gestione è un po' più complicata e diversa dalle normali forme di presentazione. Da Aspose.Slides per C++ 18.1, il componente supporta la gestione dei controlli ActiveX. Al momento, è possibile accedere ai controlli ActiveX già aggiunti nella presentazione e modificarli o eliminarli utilizzando le varie proprietà. Ricorda, i controlli ActiveX non sono forme e non fanno parte della IShapeCollection della presentazione, ma della separata IControlCollection. Questo articolo mostra come lavorare con essi.

## **Modifica un controllo ActiveX**
Per gestire un semplice controllo ActiveX come una casella di testo e un semplice pulsante di comando su una diapositiva:

1. Creare un'istanza della classe Presentation e caricare la presentazione contenente i controlli ActiveX.
1. Ottenere un riferimento alla diapositiva per indice.
1. Accedere ai controlli ActiveX nella diapositiva accedendo a IControlCollection.
1. Accedere al controllo ActiveX TextBox1 utilizzando l'oggetto ControlEx.
1. Modificare le diverse proprietà del controllo ActiveX TextBox1, inclusi testo, carattere, altezza del carattere e posizione del frame.
1. Accedere al secondo controllo chiamato CommandButton1.
1. Modificare la didascalia del pulsante, il carattere e la posizione.
1. Spostare la posizione dei frame dei controlli ActiveX.
1. Scrivere la presentazione modificata in un file PPTX.

Il frammento di codice seguente aggiorna i controlli ActiveX nelle diapositive della presentazione come mostrato di seguito.

```cpp
// Accesso alla presentazione con  controlli ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Accesso alla prima diapositiva nella presentazione
auto slide = presentation->get_Slides()->idx_get(0);

// modifica del testo della TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // modifica dell'immagine sostitutiva. PowerPoint sostituirà questa immagine durante l'attivazione di ActiveX, quindi a volte è OK 
    // lasciare l'immagine invariata.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// modifica della didascalia del pulsante
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // modifica del sostituto
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Spostamento dei frame ActiveX di 100 punti verso il basso
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Salva la presentazione con i controlli ActiveX modificati
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Rimozione dei controlli
slide->get_Controls()->Clear();

// Salvataggio della presentazione con i controlli ActiveX rimossi
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Aggiungi un controllo ActiveX Media Player**
I controlli ActiveX sono usati nelle presentazioni. Aspose.Slides per C++ consente di aggiungere e gestire i controlli ActiveX, ma la loro gestione è un po' più complicata e diversa dalle normali forme di presentazione. Da Aspose.Slides per C++ 18.1, è stato aggiunto il supporto per l'aggiunta del controllo ActiveX Media Player in Aspose.Slides. Ricorda, i controlli ActiveX non sono forme e non fanno parte della IShapeCollection della presentazione, ma della separata IControlExCollection. Questo articolo mostra come lavorare con essi. Per gestire un controllo ActiveX Media Player, eseguire i seguenti passaggi:

1. Creare un'istanza della classe Presentation e caricare la presentazione di esempio con i controlli ActiveX Media Player.
1. Creare un'istanza della classe Presentation di destinazione e generare un'istanza di presentazione vuota.
1. Clonare la diapositiva con il controllo ActiveX Media Player nella presentazione modello nella presentazione di destinazione.
1. Accedere alla diapositiva clonata nella presentazione di destinazione.
1. Accedere ai controlli ActiveX nella diapositiva accedendo a IControlCollection.
1. Accedere al controllo ActiveX Media Player e impostare il percorso del video usando le sue proprietà.
1. Salvare la presentazione in un file PPTX.

```cpp
// Istanzia la classe Presentation che rappresenta un file PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Crea un'istanza di presentazione vuota
auto newPresentation = System::MakeObject<Presentation>();

// Rimuove la diapositiva predefinita
newPresentation->get_Slides()->RemoveAt(0);

// Clona la diapositiva con il controllo ActiveX Media Player
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Accede al controllo ActiveX Media Player e imposta il percorso del video
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Salva la presentazione
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Aspose.Slides conserva i controlli ActiveX durante la lettura e il salvataggio se non possono essere eseguiti nel runtime C++?**

Sì. Aspose.Slides li tratta come parte della presentazione e può leggere/modificare le loro proprietà e i frame; l'esecuzione dei controlli stessi non è necessaria per conservarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE in una presentazione?**

I controlli ActiveX sono controlli gestiti interattivi (pulsanti, caselle di testo, lettore multimediale), mentre [OLE](/slides/it/cpp/manage-ole/) si riferisce a oggetti applicativi incorporati (ad esempio, un foglio di calcolo Excel). Sono memorizzati e gestiti in modo diverso e hanno modelli di proprietà differenti.

**Gli eventi ActiveX e le macro VBA funzionano se il file è stato modificato da Aspose.Slides?**

Aspose.Slides conserva il markup e i metadati esistenti; tuttavia, gli eventi e le macro vengono eseguiti solo all'interno di PowerPoint su Windows quando la sicurezza lo consente. La libreria non esegue VBA.