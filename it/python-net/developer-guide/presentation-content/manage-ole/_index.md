---
title: Gestire OLE nelle presentazioni usando Python
linktitle: Gestire OLE
type: docs
weight: 40
url: /it/python-net/manage-ole/
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
- Python
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in PowerPoint e nei file OpenDocument con Aspose.Slides per Python via .NET. Incorpora, aggiorna ed esporta i contenuti OLE senza problemi."
---
## **Introduzione**

{{% alert color="info" title="Note" %}}

**OLE (Object Linking & Embedding)** è una tecnologia Microsoft che consente di collegare o incorporare dati e oggetti creati in un'applicazione in un'altra.

{{% /alert %}}

Ad esempio, un grafico creato in Microsoft Excel e inserito in una diapositiva PowerPoint è un oggetto OLE.

- Un oggetto OLE può apparire come un'icona. Facendo doppio clic sull'icona si apre l'oggetto nell'applicazione associata (ad es., Excel) oppure viene chiesto di scegliere un'app per aprirlo o modificarlo.
- Un oggetto OLE può visualizzare il proprio contenuto (ad esempio, un grafico). In questo caso, PowerPoint attiva l'oggetto incorporato, carica l'interfaccia del grafico e consente di modificare i dati del grafico direttamente in PowerPoint.

Aspose.Slides per Python consente di inserire oggetti OLE nelle diapositive come frame di oggetti OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Aggiungere oggetti OLE alle diapositive**

Se hai già creato un grafico in Microsoft Excel e desideri incorporarlo in una diapositiva come frame di oggetto OLE utilizzando Aspose.Slides per Python, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva mediante il suo indice.
1. Leggi il file Excel in un array di byte.
1. Aggiungi un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) alla diapositiva, fornendo l'array di byte e gli altri dettagli dell'oggetto OLE.
1. Salva la presentazione modificata come file PPTX.

Nell'esempio sottostante, un grafico proveniente da un file Excel viene incorporato in una diapositiva come [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Nota:** Il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) accetta l'estensione del file dell'oggetto incorporabile come secondo parametro. PowerPoint utilizza questa estensione per identificare il tipo di file e selezionare l'applicazione appropriata per aprire l'oggetto OLE.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Prepara i dati per l'oggetto OLE.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Aggiungi un frame di oggetto OLE alla diapositiva.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Aggiungere oggetti OLE collegati**

Aspose.Slides per Python consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) che collega a un file invece di incorporarne i dati.

Il seguente esempio Python mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) collegato a un file Excel su una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aggiungi un frame di oggetto OLE con un file Excel collegato.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedere agli oggetti OLE**

Se un oggetto OLE è già incorporato in una diapositiva, è possibile accedervi come segue:

1. Carica la presentazione che contiene l'oggetto OLE incorporato creando un'istanza della classe Presentation.
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Accedi alla forma OleObjectFrame.
1. Una volta ottenuto il frame dell'oggetto OLE, esegui le operazioni necessarie su di esso.

L'esempio sotto accede al frame dell'oggetto OLE — un grafico Excel incorporato — e ne recupera i dati del file. In questo esempio, utilizziamo un PPTX che contiene una singola forma nella prima diapositiva.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Ottieni i dati del file incorporato.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Ottieni l'estensione del file incorporato.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Accedere alle proprietà dell'oggetto OLE collegato**

Aspose.Slides consente di accedere alle proprietà di un frame di oggetto OLE collegato.

Il seguente esempio Python verifica se un oggetto OLE è collegato e, in tal caso, recupera il percorso del file collegato:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Verifica se l'oggetto OLE è collegato.
        if ole_frame.is_object_link:
            # Stampa il percorso completo del file collegato.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Stampa il percorso relativo del file collegato, se presente.
            # Solo le presentazioni .ppt possono contenere un percorso relativo.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Modificare i dati dell'oggetto OLE**

{{% alert color="info" title="Note" %}}

In questa sezione, l'esempio di codice sotto utilizza [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/).

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, è possibile accedervi e modificarne i dati come segue:

1. Carica la presentazione creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Ottieni la diapositiva target tramite il suo indice.
1. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. Una volta ottenuto il frame dell'oggetto OLE, esegui le operazioni richieste su di esso.
1. Crea un oggetto `Workbook` e leggi i dati OLE.
1. Apri il `Worksheet` desiderato e modifica i dati.
1. Salva il `Workbook` aggiornato in uno stream.
1. Sostituisci i dati dell'oggetto OLE utilizzando quello stream.

Nell'esempio sotto, un frame di oggetto OLE (un grafico Excel incorporato) viene accesso e i suoi dati di file vengono modificati per aggiornare il grafico. L'esempio utilizza un PPTX creato in precedenza che contiene una singola forma nella prima diapositiva.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Leggi i dati dell'oggetto OLE come oggetto Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Modifica i dati del workbook.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Cambia i dati dell'oggetto OLE frame.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Incorporare file nelle diapositive**

Oltre ai grafici Excel, Aspose.Slides per Python consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando un utente fa doppio clic su un oggetto inserito, questo si apre automaticamente nell'applicazione associata, oppure viene chiesto di scegliere un programma appropriato.

Questo codice Python mostra come incorporare file HTML e ZIP in una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare i tipi di file per gli oggetti incorporati**

Quando si lavora con le presentazioni, potrebbe essere necessario sostituire vecchi oggetti OLE con nuovi o scambiare un oggetto OLE non supportato con uno supportato. Aspose.Slides per Python consente di impostare il tipo di file di un oggetto incorporato, permettendo di aggiornare i dati del frame OLE o la sua estensione di file.

Questo codice Python mostra come impostare il tipo di file dell'oggetto OLE incorporato su `zip`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Cambia il tipo di file in ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare le immagini icona e i titoli per gli oggetti incorporati**

Dopo aver incorporato un oggetto OLE, un'anteprima basata su icona viene aggiunta automaticamente. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l'oggetto OLE. Se vuoi utilizzare un'immagine e un testo specifici nell'anteprima, puoi impostare l'immagine icona e il titolo utilizzando Aspose.Slides per Python.

Questo codice Python mostra come impostare l'immagine icona e il titolo per un oggetto incorporato:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Aggiungi un'immagine alle risorse della presentazione.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Imposta un titolo e l'immagine per l'anteprima OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Impedire il ridimensionamento e il riposizionamento dei frame di oggetti OLE**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva, PowerPoint potrebbe chiederti di aggiornare i collegamenti quando apri la presentazione. Selezionare Aggiorna collegamenti può modificare le dimensioni e la posizione del frame dell'oggetto OLE perché PowerPoint aggiorna l'anteprima con i dati dell'oggetto collegato. Per impedire a PowerPoint di chiederti di aggiornare i dati dell'oggetto, imposta la proprietà `update_automatic` della classe [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) su `False`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Estrarre file incorporati**

Aspose.Slides per Python consente di estrarre i file incorporati nelle diapositive come oggetti OLE come segue:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) che contiene gli oggetti OLE da estrarre.
1. Itera attraverso tutte le forme nella presentazione e individua le forme OLEObjectFrame.
1. Recupera i dati del file incorporato da ogni [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) e scrivili su disco.

Il seguente codice Python mostra come estrarre file incorporati in una diapositiva come oggetti OLE:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**Il contenuto OLE verrà renderizzato durante l'esportazione delle diapositive in PDF/immagini?**

Viene renderizzata solo la parte visibile della diapositiva: l'icona/immagine sostitutiva (anteprima). Il contenuto OLE "live" non viene eseguito durante il rendering. Se necessario, imposta un'immagine di anteprima personalizzata per garantire l'aspetto desiderato nel PDF esportato.

Per preservare anche il file incorporato come allegato PDF, imposta [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) su `True`. Questa opzione è disabilitata per impostazione predefinita. Per un esempio e istruzioni su come verificare l'allegato, vedi [Preserve Embedded OLE Files as PDF Attachments](/slides/it/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides fornisce [blocchi a livello di forma](/slides/it/python-net/applying-protection-to-presentation/). Non si tratta di crittografia, ma impedisce efficacemente modifiche accidentali e spostamenti.

**Perché un oggetto Excel collegato "salta" o cambia dimensione quando apro la presentazione?**

PowerPoint potrebbe aggiornare l'anteprima dell'OLE collegato. Per un aspetto stabile, segui le pratiche della [Working Solution for Worksheet Resizing](/slides/it/python-net/working-solution-for-worksheet-resizing/) — adatta il frame all'intervallo o scala l'intervallo a un frame fisso e imposta un'immagine sostitutiva appropriata.

**I percorsi relativi per gli oggetti OLE collegati saranno conservati nel formato PPTX?**

Nel PPTX le informazioni sul "percorso relativo" non sono disponibili — solo il percorso completo. I percorsi relativi si trovano nel formato PPT più vecchio. Per la portabilità, è preferibile utilizzare percorsi assoluti affidabili/URI accessibili o l'incorporamento.