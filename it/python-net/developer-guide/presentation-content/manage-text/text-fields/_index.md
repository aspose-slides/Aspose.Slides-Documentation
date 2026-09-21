---
title: Gestire i campi di testo nelle presentazioni PowerPoint in Python
linktitle: Campi di testo
type: docs
weight: 52
url: /it/python-net/text-fields/
keywords:
- campo di testo
- testo automatico
- numero diapositiva
- data e ora
- intestazione
- piè di pagina
- porzione di testo
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Crea, ispeziona, modifica e rimuovi i campi di testo nelle presentazioni PowerPoint con Aspose.Slides per Python tramite .NET. Preserva la formattazione e verifica i file PPTX e PPT salvati."
---
## **Panoramica**

Un paragrafo di testo è costituito da porzioni. Una [Portion](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/) ordinaria contiene testo letterale; una porzione di campo ha anche un [Field](https://reference.aspose.com/slides/it/python-net/aspose.slides/field/) il cui tipo identifica un valore aggiornato automaticamente, come il numero della diapositiva o la data. Due porzioni possono visualizzare gli stessi caratteri mentre solo una contiene un campo.

Usa [Portion.field](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/field/) per distinguerle: è `None` per il testo ordinario. [Portion.add_field](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/add_field/) converte una porzione esistente in un campo. Mantieni un'etichetta e il suo valore dinamico in porzioni separate in modo che la conversione del valore non sostituisca anche l'etichetta.

Questa guida copre i campi all'interno del testo, la loro formattazione e il salvataggio in PPTX e PPT. Per riquadri di testo e paragrafi, vedi [Manage Text](/slides/it/python-net/manage-text/).

## **Creare un campo numero diapositiva**

L'esempio completo seguente crea una casella di testo contenente un'etichetta letterale `Slide ` seguita da un numero aggiornato automaticamente. Imposta la dimensione, lo spessore e il colore del numero prima di aggiungere il campo, poi riapre la presentazione salvata e verifica il tipo di campo, il testo e la formattazione. Non è necessario alcun file di input.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

La nuova presentazione inizia con il numero diapositiva 1, quindi il testo è `Slide 1`, e entrambi i controlli stampano `True`. Il numero rimane un campo dopo la riapertura; non è un `1` letterale. Gli indici nella verifica si riferiscono alla forma e alle porzioni create da questo esempio.

## **Scegliere un tipo di campo**

[FieldType](https://reference.aspose.com/slides/it/python-net/aspose.slides/fieldtype/) fornisce i seguenti valori predefiniti. Passa il valore appropriato a [add_field](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/add_field/).

| Valore | Scopo |
|---|---|
| [slide_number](https://reference.aspose.com/slides/it/python-net/aspose.slides/fieldtype/slide_number/) | Il numero della diapositiva corrente. |
| [date_time](https://reference.aspose.com/slides/it/python-net/aspose.slides/fieldtype/date_time/) | Data/ora nel formato predefinito dell'applicazione di rendering. |
| [date_time1](https://reference.aspose.com/slides/it/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/it/python-net/aspose.slides/fieldtype/date_time9/) | Formati di data predefiniti o combinazioni data/ora. |
| [date_time10](https://reference.aspose.com/slides/it/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/it/python-net/aspose.slides/fieldtype/date_time13/) | Formati di ora predefiniti, con opzioni per i secondi e un orologio a 12 ore. |
| [header](https://reference.aspose.com/slides/it/python-net/aspose.slides/fieldtype/header/) | Un campo intestazione; vedi le limitazioni di segnaposto e formato di seguito. |
| [footer](https://reference.aspose.com/slides/it/python-net/aspose.slides/fieldtype/footer/) | Un campo piè di pagina. |

Ad esempio, [date_time3](https://reference.aspose.com/slides/it/python-net/aspose.slides/fieldtype/date_time3/) rappresenta giorno, nome completo del mese e anno in inglese. Questi sono formati di campo predefiniti, non stringhe di formato data Python arbitrarie. L'[language_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/language_id/) della porzione e l'applicazione che elabora la presentazione possono influenzare il risultato visualizzato.

## **Creare un campo da una stringa interna**

La sovraccarico a stringa di [add_field](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/add_field/) accetta un identificatore di campo interno. Usalo quando si conserva un identificatore fornito da un'altra applicazione che non ha un valore predefinito. È inoltre possibile costruire un [FieldType](https://reference.aspose.com/slides/it/python-net/aspose.slides/fieldtype/__init__/) dall'identificatore. [FieldType.internal_string](https://reference.aspose.com/slides/it/python-net/aspose.slides/fieldtype/internal_string/) espone quell'identificatore per l'ispezione.

Questo esempio memorizza un campo `custom-report-id` specifico dell'applicazione con il testo di fallback `Report-042`. L'identificatore non registra un calcolo: Aspose.Slides non genera ID report per un tipo sconosciuto. L'applicazione che comprende questo identificatore deve fornire il suo significato e aggiornare il valore.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

Dopo questo round‑trip PPTX, il tipo è `custom-report-id` e il testo è `Report-042`. Passare una stringa come `%Y-%m-%d` denominerebbe un tipo di campo; non configurerebbe un formato data personalizzato. Per una data fissa in un formato arbitrario, usa testo ordinario.

## **Ispezionare, modificare e rimuovere campi data/ora**

Leggi e modifica un campo esistente tramite [Field.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/field/type/). Verifica che il campo esista prima di accedere al suo tipo. Per interrompere gli aggiornamenti automatici, chiama [Portion.remove_field](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/remove_field/). Questo mantiene la porzione e il suo testo corrente rimuovendo l'associazione al campo. Se ti serve un valore fisso specifico, assegna quel testo dopo aver rimosso il campo.

Per l'impostazione API associata all'elaborazione dei campi data/ora, vedi [Presentation.current_date_time](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/current_date_time/). L'esempio seguente utilizza una data di approvazione esplicita quando converte un campo in testo ordinario. Una tupla con i nomi dei mesi in inglese mantiene la data fissa indipendente dalla locale di sistema.

Scarica [sample.pptx](sample.pptx) e posizionalo nella directory di lavoro. Contiene due forme di testo nominate, `UpdatedAt` e `ApprovedDate`, ognuna con un campo data/ora, più etichette di testo ordinario. L'esempio seguente attraversa le forme di testo di primo livello nelle diapositive regolari. Cambia i campi data/ora in un formato data lunga e li rende in corsivo, preservando le altre formattazioni. Solo i campi in `ApprovedDate` diventano testo fisso.

Il campione riconosce gli identificatori interni incorporati `datetime` e `datetime1` fino a `datetime13`. Gruppi, tabelle, note, layout e master richiedono l'attraversamento dei propri contenitori di testo e sono fuori dallo scopo di questo esempio.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

Dopo la riapertura, `UpdatedAt` ha tipo `datetime3` e rimane dinamico. `ApprovedDate` non ha campo e contiene `05 April 2030`. Entrambe le porzioni data sono in corsivo, e la loro dimensione del carattere originale, impostazione di grassetto e colore rimangono intatti. Le etichette di testo ordinario sono invariate. La verifica legge la prima porzione delle due forme conosciute nel campione fornito.

## **Preservare la formattazione del testo**

Lavora con la porzione esistente quando aggiungi un campo, ne cambi il tipo o lo rimuovi. Queste operazioni conservano la formattazione della porzione. Usa [Portion.portion_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/portion_format/) per modificare solo le proprietà necessarie, come fanno gli esempi per il colore o il corsivo.

Evita di ricostruire un intero riquadro di testo solo per aggiornare un campo: ciò può perdere i limiti originali della porzione e la loro formattazione individuale. Distinguere inoltre la formattazione impostata esplicitamente da quella ereditata dal paragrafo, layout o tema. Vedi [Text Formatting](/slides/it/python-net/text-formatting/) per opzioni di formattazione più ampie.

## **Campi e segnaposto intestazione/piè di pagina**

Un campo è parte di una porzione di testo. Un segnaposto è una forma con un ruolo nella presentazione, come un piè di pagina o il numero diapositiva. Aggiungere un campo a una casella di testo ordinaria non trasforma quella forma in un segnaposto.

I gestori di intestazione/piè di pagina controllano il testo del segnaposto e la visibilità su diapositive, layout e master, inclusa la propagazione alle diapositive dipendenti. Un campo numero in una casella di testo personalizzata può quindi essere utile anche quando non si utilizza il segnaposto numero diapositiva. Al contrario, modificare la visibilità del segnaposto non rimuove un campo da una casella di testo non correlata.

I tipi predefiniti di intestazione e piè di pagina non creano i corrispondenti segnaposti né forniscono il loro contenuto. In particolare, una diapositiva PowerPoint standard non ha un segnaposto intestazione; le intestazioni appartengono alle pagine delle note e ai volantini. Non presumere che un campo intestazione o piè di pagina in una forma arbitraria ottenga automaticamente il testo configurato tramite un gestore di segnaposto. Per quel flusso di lavoro, vedi [Presentation Headers and Footers](/slides/it/python-net/presentation-header-and-footer/).

## **Limitazioni PPTX e PPT**

Verifica sia il tipo di campo sia il testo risultante dopo il salvataggio e la riapertura. Conservare un identificatore non dimostra che un'applicazione possa calcolare o visualizzare il suo valore.

| Formato | Comportamento e limitazioni del campo |
|---|---|
| PPTX | Memorizza gli identificatori di campo interni insieme al testo del campo. Nei controlli di round‑trip, i tipi predefiniti e l'identificatore personalizzato usato sopra sono sopravvissuti al salvataggio e alla riapertura. Il tipo personalizzato sconosciuto ha mantenuto il suo testo di fallback; non ha acquisito logica di calcolo automatico. Un'altra applicazione potrebbe gestire gli identificatori non supportati diversamente. |
| PPT | Utilizza rappresentazioni di campo legacy e ha una compatibilità più limitata. Nei controlli di round‑trip, i campi numero diapositiva e data/ora predefiniti sono sopravvissuti al salvataggio e alla riapertura. Un campo personalizzato in una casella di testo di diapositiva ordinaria si è riaperto con il suo identificatore ma con `*` come testo; un campo intestazione nello stesso contesto ha prodotto anch'esso `*`. Non fare affidamento su campi personalizzati o contesti di campo non supportati per mantenere il loro testo visibile. |

Per un output portabile e fisso, converti i campi non supportati in testo ordinario e assegna esplicitamente il valore desiderato prima del salvataggio. Questo preserva il testo scelto ma interrompe intenzionalmente gli aggiornamenti automatici. Verifica anche l'applicazione di destinazione quando il suo ricalcolo dei campi è parte del tuo flusso di lavoro.

## **FAQ**

**Come posso capire se un numero o una data visualizzati sono un campo?**

Ispeziona [Portion.field](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/field/). Un valore diverso da `None` identifica un campo; il solo testo visualizzato non può dirlo.

**La rimozione di un campo elimina il suo testo o la sua formattazione?**

No. [remove_field](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/remove_field/) converte la porzione esistente in testo ordinario. Assegna un valore esplicito successivamente se ti serve una data fissa o un valore di fallback specifico.

**Una stringa interna può definire un nuovo formato data o formula?**

No. Identifica un tipo di campo. Un identificatore sconosciuto non fornisce un valutatore o un modello di formato data Python. Usa un tipo predefinito supportato o formatta il valore tu stesso come testo ordinario.

**Perché controllare nuovamente una presentazione dopo averla salvata?**

Gli identificatori di campo, il testo calcolato e la formattazione sono elementi separati da verificare. La conversione del formato può cambiare il risultato visibile anche quando l'identificatore del campo è ancora presente.