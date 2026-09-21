---
title: Gestire i campi di testo nelle presentazioni PowerPoint in Python tramite Java
linktitle: Campi di testo
type: docs
weight: 52
url: /it/python-java/text-fields/
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
- Java
- Aspose.Slides
description: "Crea, ispeziona, modifica e rimuovi i campi di testo nelle presentazioni PowerPoint con Aspose.Slides per Python tramite Java. Conserva la formattazione e verifica i file PPTX e PPT salvati."
---
## **Panoramica**

Un paragrafo di testo è costituito da porzioni. Una [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/) ordinaria contiene testo letterale; una porzione di campo ha anche un [Field](https://reference.aspose.com/slides/it/python-java/aspose.slides/field/) il cui tipo identifica un valore aggiornato automaticamente, come il numero di diapositiva o la data. Due porzioni possono mostrare gli stessi caratteri mentre solo una contiene un campo.

Usa [Portion.getField](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#getField) per distinguerle: è `None` per il testo ordinario. [Portion.addField](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#addField) converte una porzione esistente in un campo. Mantieni un'etichetta e il suo valore dinamico in porzioni separate così la conversione del valore non sostituisce anche l'etichetta.

Questa guida tratta i campi all'interno del testo, la loro formattazione e il salvataggio in PPTX e PPT. Per i riquadri di testo e i paragrafi, vedi [Manage Text](/slides/it/python-java/manage-text/).

## **Creare un campo Numero diapositiva**

Il seguente esempio completo crea una casella di testo contenente un'etichetta letterale `Slide ` seguita da un numero aggiornato automaticamente. Imposta la dimensione, lo spessore e il colore del numero prima di aggiungere il campo, quindi riapre la presentazione salvata e verifica il tipo di campo, il testo e la formattazione. Non è necessario alcun file di input.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

La nuova presentazione inizia con il numero di diapositiva 1, quindi il testo è `Slide 1`, e entrambe le verifiche stampano `True`. Il numero rimane un campo dopo la riapertura; non è un `1` letterale. Gli indici nella verifica si riferiscono alla forma e alle porzioni create da questo esempio.

## **Scegliere un tipo di campo**

[FieldType](https://reference.aspose.com/slides/it/python-java/aspose.slides/fieldtype/) fornisce i seguenti metodi per ottenere valori predefiniti. Passa il valore appropriato a [addField](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#addField).

| Metodo | Scopo |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/it/python-java/aspose.slides/fieldtype/#getSlideNumber) | Il numero di diapositiva corrente. |
| [getDateTime](https://reference.aspose.com/slides/it/python-java/aspose.slides/fieldtype/#getDateTime) | Data/ora nel formato predefinito dell'applicazione di rendering. |
| [getDateTime1](https://reference.aspose.com/slides/it/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/it/python-java/aspose.slides/fieldtype/#getDateTime9) | Formati di data predefiniti o combinati data/ora. |
| [getDateTime10](https://reference.aspose.com/slides/it/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/it/python-java/aspose.slides/fieldtype/#getDateTime13) | Formati di ora predefiniti, con opzioni per secondi e orologio a 12 ore. |
| [getHeader](https://reference.aspose.com/slides/it/python-java/aspose.slides/fieldtype/#getHeader) | Un campo intestazione; vedi le limitazioni di segnaposto e formato di seguito. |
| [getFooter](https://reference.aspose.com/slides/it/python-java/aspose.slides/fieldtype/#getFooter) | Un campo piè di pagina. |

Ad esempio, [getDateTime3](https://reference.aspose.com/slides/it/python-java/aspose.slides/fieldtype/#getDateTime3) rappresenta giorno, nome completo del mese e anno in inglese. Questi sono formati di campo predefiniti, non stringhe arbitrarie di formattazione data Python. La lingua impostata con [setLanguageId](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setLanguageId) e l'applicazione che elabora la presentazione possono influenzare il risultato visualizzato.

## **Creare un campo da una stringa interna**

La sovraccarico a stringa di [addField](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#addField) accetta un identificatore di campo interno. Usala quando si conserva un identificatore fornito da un'altra applicazione che non ha un valore predefinito. È inoltre possibile costruire un [FieldType](https://reference.aspose.com/slides/it/python-java/aspose.slides/fieldtype/#FieldType) dall'identificatore. [FieldType.getInternalString](https://reference.aspose.com/slides/it/python-java/aspose.slides/fieldtype/#getInternalString) espone quell'identificatore per l'ispezione.

Questo esempio archivia un campo specifico dell'applicazione `custom-report-id` con il testo di fallback `Report-042`. L'identificatore non registra alcun calcolo: Aspose.Slides non genera ID report per un tipo sconosciuto. L'applicazione che comprende questo identificatore deve fornire il suo significato e aggiornare il suo valore.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Dopo questo round‑trip PPTX, il tipo è `custom-report-id` e il testo è `Report-042`. Passare una stringa come `yyyy-MM-dd` denominerebbe un tipo di campo; non configurerebbe un formato data personalizzato. Per una data fissa in un formato arbitrario, usa testo ordinario.

## **Ispezionare, modificare e rimuovere campi data/ora**

Modifica un campo esistente tramite [Field.setType](https://reference.aspose.com/slides/it/python-java/aspose.slides/field/#setType). Verifica che il campo esista prima di accedere al suo tipo. Per interrompere gli aggiornamenti automatici, chiama [Portion.removeField](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#removeField). Questo mantiene la porzione e il suo testo corrente rimuovendo l'associazione al campo. Se hai bisogno di un valore fisso specifico, assegna quel testo dopo aver rimosso il campo.

Per l'impostazione API associata all'elaborazione dei campi data/ora, vedi [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#setCurrentDateTime). L'esempio seguente utilizza una data di approvazione esplicita quando converte un campo in testo ordinario.

Scarica [sample.pptx](sample.pptx) e posizionalo nella directory di lavoro. Contiene due forme di testo nominate, `UpdatedAt` e `ApprovedDate`, ciascuna con un campo data/ora, più etichette di testo ordinario. L'esempio seguente percorre le forme di testo di primo livello sulle diapositive regolari. Cambia i campi data/ora in un formato data lunga e li rende corsivi, preservando le altre formattazioni. Solo i campi in `ApprovedDate` diventano testo fisso.

Il campione riconosce gli identificatori interni incorporati `datetime` e `datetime1` fino a `datetime13`. Gruppi, tabelle, note, layout e master richiedono l'attraversamento dei propri contenitori di testo e sono al di fuori del campo di questo esempio.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Usa i nomi dei mesi in inglese indipendentemente dalla lingua del sistema.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Dopo la riapertura, `UpdatedAt` ha tipo `datetime3` e rimane dinamico. `ApprovedDate` non ha campo e contiene `05 April 2030`. Entrambe le porzioni data sono corsive, e la loro dimensione del carattere originale, impostazione grassetto e colore rimangono intatti. Le etichette di testo ordinario non sono cambiate. La verifica legge la prima porzione delle due forme conosciute nel campione fornito.

## **Preservare la formattazione del testo**

Lavora con la porzione esistente quando aggiungi un campo, ne modifichi il tipo o lo rimuovi. Queste operazioni conservano la formattazione di quella porzione. Usa [Portion.getPortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#getPortionFormat) per modificare solo le proprietà necessarie, come fanno gli esempi per il colore o il corsivo.

Evita di ricostruire un intero riquadro di testo solo per aggiornare un campo: farlo può perdere i confini originali della porzione e la loro formattazione individuale. Inoltre, distinguere la formattazione impostata esplicitamente da quella ereditata dal paragrafo, dal layout o dal tema. Vedi [Text Formatting](/slides/it/python-java/text-formatting/) per opzioni di formattazione più ampie.

## **Campi e segnaposto intestazione/piè di pagina**

Un campo fa parte di una porzione di testo. Un segnaposto è una forma con un ruolo nella presentazione, come un piè di pagina o il numero di diapositiva. Aggiungere un campo a una casella di testo ordinaria non trasforma quella forma in un segnaposto.

I gestori intestazione/piè di pagina controllano il testo del segnaposto e la visibilità su diapositive, layout e master, includendo la propagazione alle diapositive dipendenti. Un campo numero in una casella di testo personalizzata può quindi essere utile anche se non si utilizza il segnaposto numero di diapositiva. Al contrario, modificare la visibilità del segnaposto non rimuove un campo da una casella di testo non correlata.

I tipi predefiniti di intestazione e piè di pagina non creano i corrispondenti segnaposto né forniscono il loro contenuto. In particolare, una diapositiva PowerPoint normale non ha un segnaposto intestazione; le intestazioni appartengono a pagine note e dispense. Non supporre che un campo intestazione o piè di pagina in una forma arbitraria ottenga automaticamente il testo configurato tramite un gestore di segnaposti. Per quel flusso di lavoro, vedi [Presentation Headers and Footers](/slides/it/python-java/presentation-header-and-footer/).

## **Limitazioni PPTX e PPT**

Verifica sia il tipo di campo sia il testo risultante dopo il salvataggio e la riapertura. Conservare un identificatore non dimostra che un'applicazione possa calcolare o visualizzare il suo valore.

| Formato | Comportamento e limitazioni del campo |
|---|---|
| PPTX | Memorizza gli identificatori di campo interni insieme al testo del campo. Nei controlli di round‑trip, i tipi predefiniti e l'identificatore personalizzato usato sopra sono sopravvissuti al salvataggio e alla riapertura. Il tipo personalizzato sconosciuto ha mantenuto il suo testo di fallback; non ha acquisito logica di calcolo automatico. Un'altra applicazione può trattare gli identificatori non supportati in modo diverso. |
| PPT | Utilizza rappresentazioni di campo legacy e ha una compatibilità più limitata. Nei controlli di round‑trip, i campi numero diapositiva e i campi data/ora predefiniti sono sopravvissuti al salvataggio e alla riapertura. Un campo personalizzato in una casella di testo di diapositiva ordinaria è stato riaperto con il suo identificatore ma con `*` come testo; un campo intestazione nello stesso contesto ha prodotto anch'esso `*`. Non fare affidamento su campi personalizzati o contesti di campo non supportati per mantenere il loro testo visibile. |

Per un output portabile e fisso, converte i campi non supportati in testo ordinario e assegna esplicitamente il valore desiderato prima di salvare. Questo preserva il testo scelto ma interrompe intenzionalmente gli aggiornamenti automatici. Testa anche l'applicazione di destinazione quando il suo ricalcolo dei campi è parte del tuo flusso di lavoro.

## **FAQ**

**Come posso capire se un numero o una data visualizzata è un campo?**

Ispeziona [Portion.getField](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#getField). Un valore diverso da `None` identifica un campo; il solo testo visualizzato non può dirlo.

**La rimozione di un campo elimina il suo testo o la sua formattazione?**

No. [removeField](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#removeField) converte la porzione esistente in testo ordinario. Assegna un valore esplicito successivamente se ti serve una data congelata o un valore di fallback specifico.

**Una stringa interna può definire un nuovo formato data o una formula?**

No. Identifica un tipo di campo. Un identificatore sconosciuto non fornisce un valutatore o un modello di formattazione data Python. Usa un tipo predefinito supportato o formatta il valore tu stesso come testo ordinario.

**Perché verificare di nuovo una presentazione dopo averla salvata?**

Gli identificatori di campo, il testo calcolato e la formattazione sono elementi separati da verificare. La conversione del formato può cambiare il risultato visibile anche quando l'identificatore del campo è ancora presente.