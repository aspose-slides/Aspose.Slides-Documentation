---
title: Gestire OLE nelle presentazioni usando C++
linktitle: Gestire OLE
type: docs
weight: 40
url: /it/cpp/manage-ole/
keywords:
- oggetto OLE
- Collegamento e incorporamento di oggetti
- aggiungi OLE
- incorpora OLE
- aggiungi oggetto
- incorpora oggetto
- aggiungi file
- incorpora file
- oggetto collegato
- file collegato
- modifica OLE
- icona OLE
- titolo OLE
- estrai OLE
- estrai oggetto
- estrai file
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in PowerPoint e nei file OpenDocument con Aspose.Slides per C++. Incorpora, aggiorna ed esporta il contenuto OLE senza interruzioni."
---
## **Introduzione**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente di inserire dati e oggetti creati in un'applicazione in un'altra applicazione tramite collegamento o incorporamento. 
{{% /alert %}} 

Considera un grafico creato in MS Excel. Il grafico viene quindi inserito in una diapositiva di PowerPoint. Quel grafico di Excel è considerato un oggetto OLE. 

- Un oggetto OLE può apparire come un'icona. In questo caso, facendo doppio clic sull'icona, il grafico si apre nell'applicazione associata (Excel), oppure ti viene chiesto di selezionare un'applicazione per aprire o modificare l'oggetto. 
- Un oggetto OLE può visualizzare il suo contenuto reale, ad esempio il contenuto di un grafico. In questo caso, il grafico viene attivato in PowerPoint, l'interfaccia del grafico si carica e puoi modificare i dati del grafico all'interno di PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/it/cpp/) consente di inserire OLE Objects nelle diapositive come riquadri di oggetti OLE ([OleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/oleobjectframe/)).

## **Aggiungi riquadri di oggetti OLE alle diapositive**

Supponendo di aver già creato un grafico in Microsoft Excel e di volerlo incorporare in una diapositiva come riquadro di oggetto OLE utilizzando Aspose.Slides for C++, puoi farlo in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Leggi il file Excel come array di byte.
4. Aggiungi il [OleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/oleobjectframe/) alla diapositiva contenente l'array di byte e altre informazioni sull'oggetto OLE.
5. Scrivi la presentazione modificata come file PPTX.

Nell'esempio seguente, abbiamo aggiunto un grafico da un file Excel a una diapositiva come [OleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/oleobjectframe/) usando Aspose.Slides for C++.  
**Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) accetta un'estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e di scegliere l'applicazione appropriata per aprire questo oggetto OLE.

``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepara i dati per l'oggetto OLE.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Aggiungi il riquadro dell'oggetto OLE alla diapositiva.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Aggiungi riquadri di oggetti OLE collegati**

Aspose.Slides for C++ consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/oleobjectframe/) senza incorporare i dati ma solo con un collegamento al file.

Questo codice C++ mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/oleobjectframe/) con un file Excel collegato a una diapositiva:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Aggiungi un riquadro di oggetto OLE con un file Excel collegato.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Accedi ai riquadri di oggetti OLE**

Se un oggetto OLE è già incorporato in una diapositiva, puoi trovarlo o accedervi facilmente in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Ottieni il riferimento della diapositiva usando il suo indice. 
3. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/oleobjectframe/). Nel nostro esempio, abbiamo usato il PPTX precedentemente creato che ha una sola forma nella prima diapositiva. Quindi abbiamo *convertito* quell'oggetto in un [IOleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ioleobjectframe/). Questo era il riquadro di oggetto OLE desiderato da accedere.
4. Una volta che il riquadro dell'oggetto OLE è stato accesso, puoi eseguire qualsiasi operazione su di esso.

Nell'esempio seguente, un riquadro di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i suoi dati file vengono acceduti.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Ottieni i dati del file incorporato.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Ottieni l'estensione del file incorporato.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Accedi alle proprietà del riquadro di oggetto OLE collegato**

Aspose.Slides consente di accedere alle proprietà dei riquadri di oggetti OLE collegati.

Questo codice C++ mostra come verificare se un oggetto OLE è collegato e quindi ottenere il percorso del file collegato:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Verifica se l'oggetto OLE è collegato.
    if (oleFrame->get_IsObjectLink())
    {
        // Stampa il percorso completo del file collegato.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Stampa il percorso relativo del file collegato, se presente.
        // Solo le presentazioni PPT possono contenere il percorso relativo.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Modifica i dati dell'oggetto OLE**

{{% alert color="primary" %}} 
In questa sezione, l'esempio di codice qui sotto utilizza [Aspose.Cells for C++](/cells/cpp/). 
{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, puoi accedervi e modificarne i dati in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Ottieni il riferimento della diapositiva tramite il suo indice. 
3. Accedi alla forma [OLEObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/oleobjectframe/). Nel nostro esempio, abbiamo usato il PPTX precedentemente creato che ha una forma nella prima diapositiva. Quindi abbiamo *convertito* quell'oggetto in un [IOleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ioleobjectframe/). Questo era il riquadro di oggetto OLE desiderato da accedere.
4. Una volta che il riquadro dell'oggetto OLE è stato accesso, puoi eseguire qualsiasi operazione su di esso.
5. Crea un oggetto `Workbook` e accedi ai dati OLE.
6. Accedi al `Worksheet` desiderato e modifica i dati.
7. Salva il `Workbook` aggiornato in uno stream.
8. Modifica i dati dell'oggetto OLE dallo stream.

Nell'esempio seguente, un riquadro di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) viene accesso e i suoi dati file vengono modificati per aggiornare i dati del grafico.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Ottieni la prima forma come riquadro di oggetto OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Leggi i dati dell'oggetto OLE come oggetto Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Modifica i dati del workbook.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Cambia i dati dell'oggetto del riquadro OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Incorpora altri tipi di file nelle diapositive**

Oltre ai grafici Excel, Aspose.Slides for C++ consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando un utente fa doppio clic sull'oggetto inserito, questo si apre automaticamente nel programma pertinente, oppure all'utente viene chiesto di selezionare un programma adeguato per aprirlo.

Questo codice C++ mostra come incorporare HTML e ZIP in una diapositiva:

``` cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Imposta i tipi di file per gli oggetti incorporati**

Durante la gestione delle presentazioni, potresti dover sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides for C++ consente di impostare il tipo di file per un oggetto incorporato, permettendo di aggiornare i dati del riquadro OLE o la sua estensione.

Questo codice C++ mostra come impostare il tipo di file per un oggetto OLE incorporato a `zip`:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Cambia il tipo di file in ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Imposta immagini icona e titoli per gli oggetti incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un'anteprima costituita da un'immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l'oggetto OLE. Se desideri utilizzare un'immagine e un testo specifici come elementi nell'anteprima, puoi impostare l'immagine icona e il titolo con Aspose.Slides for C++.

Questo codice C++ mostra come impostare l'immagine icona e il titolo per un oggetto incorporato: 

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Aggiungi un'immagine alle risorse della presentazione.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Imposta un titolo e l'immagine per l'anteprima OLE.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Previeni il ridimensionamento e il riposizionamento del riquadro di oggetto OLE**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva della presentazione, quando apri la presentazione in PowerPoint, potresti visualizzare un messaggio che ti chiede di aggiornare i collegamenti. Cliccando sul pulsante "Update Links" (Aggiorna collegamenti) la dimensione e la posizione del riquadro dell'oggetto OLE potrebbe cambiare perché PowerPoint aggiorna i dati dall'oggetto OLE collegato e rinfresca l'anteprima dell'oggetto. Per impedire a PowerPoint di chiedere l'aggiornamento dei dati dell'oggetto, imposta il metodo `set_UpdateAutomatic` dell'interfaccia [IOleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ioleobjectframe/) su `false`:

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **Estrai i file incorporati**

Aspose.Slides for C++ consente di estrarre i file incorporati in diapositive come oggetti OLE in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) contenente gli oggetti OLE che intendi estrarre.
2. Scorri tutti gli oggetti forma nella presentazione e accedi alle forme [OLEObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/oleobjectframe/).
3. Accedi ai dati dei file incorporati dai riquadri OLE Object e scrivili su disco.

Questo codice C++ mostra come estrarre i file incorporati in una diapositiva come oggetti OLE:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **FAQ**

**Il contenuto OLE verrà renderizzato quando si esportano le diapositive in PDF/immagini?**

Viene renderizzata solo la parte visibile della diapositiva: l'icona/immagine di sostituzione (anteprima). Il contenuto OLE "live" non viene eseguito durante il rendering. Se necessario, imposta un'immagine di anteprima personalizzata per garantire l'aspetto desiderato nel PDF esportato.

**Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides fornisce [blocchi a livello di forma](/slides/it/cpp/applying-protection-to-presentation/). Non si tratta di crittografia, ma impedisce efficacemente modifiche accidentali e spostamenti.

**Perché un oggetto Excel collegato "salta" o cambia dimensione quando apro la presentazione?**

PowerPoint potrebbe aggiornare l'anteprima dell'OLE collegato. Per un aspetto stabile, segui le pratiche della [Soluzione operativa per il ridimensionamento del foglio di lavoro](/slides/it/cpp/working-solution-for-worksheet-resizing/): adatta il riquadro all'intervallo, oppure scala l'intervallo a un riquadro fisso e imposta un'immagine sostitutiva appropriata.

**I percorsi relativi per gli oggetti OLE collegati saranno conservati nel formato PPTX?**

Nel PPTX le informazioni sui "percorsi relativi" non sono disponibili: è presente solo il percorso completo. I percorsi relativi sono presenti nel formato PPT più vecchio. Per la portabilità, è consigliabile utilizzare percorsi assoluti affidabili/URI accessibili o l'incorporamento.