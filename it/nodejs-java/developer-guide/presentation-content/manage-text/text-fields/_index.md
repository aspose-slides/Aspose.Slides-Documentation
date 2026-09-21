---
title: Gestisci campi di testo nelle presentazioni PowerPoint in JavaScript
linktitle: Campi di testo
type: docs
weight: 52
url: /it/nodejs-java/text-fields/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea, ispeziona, modifica e rimuovi i campi di testo nelle presentazioni PowerPoint con Aspose.Slides per Node.js via Java. Conserva la formattazione e verifica i file PPTX e PPT salvati."
---
## **Panoramica**

Un paragrafo di testo è costituito da porzioni. Una [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) ordinaria contiene testo letterale; una porzione di campo ha anche un [Field](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/field/) il cui tipo identifica un valore aggiornato automaticamente, ad esempio il numero della diapositiva o la data. Due porzioni possono visualizzare gli stessi caratteri mentre solo una contiene un campo.

Usa [Portion.getField](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/#getField) per distinguerle: è `null` per il testo ordinario. [Portion.addField](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/#addField) converte una porzione esistente in un campo. Mantieni un’etichetta e il suo valore dinamico in porzioni separate in modo che la conversione del valore non sostituisca anche l’etichetta.

Questa guida tratta i campi all’interno del testo, la loro formattazione e il salvataggio in PPTX e PPT. Per i riquadri di testo e i paragrafi, vedi [Manage Text](/slides/it/nodejs-java/manage-text/).

## **Crea un campo numero diapositiva**

Il seguente esempio completo crea una casella di testo contenente un’etichetta letterale `Slide ` seguita da un numero aggiornato automaticamente. Imposta la dimensione, il peso e il colore del numero prima di aggiungere il campo, quindi riapre la presentazione salvata e verifica il tipo di campo, il testo e la formattazione. Non è necessario alcun file di input.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

La nuova presentazione inizia con il numero diapositiva 1, quindi il testo è `Slide 1` e entrambe le verifiche stampano `true`. Il numero rimane un campo dopo la riapertura; non è un `1` letterale. Gli indici nella verifica si riferiscono alla forma e alle porzioni create da questo esempio.

## **Scegli un tipo di campo**

[FieldType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fieldtype/) fornisce i seguenti metodi per ottenere valori predefiniti. Passa il valore appropriato a [addField](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/#addField).

| Metodo | Scopo |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Il numero corrente della diapositiva. |
| [getDateTime](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Data/ora nel formato predefinito dell’applicazione di rendering. |
| [getDateTime1](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Formati di data predefiniti o combinazioni data/ora. |
| [getDateTime10](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Formati di ora predefiniti, con opzioni per i secondi e un orologio a 12 ore. |
| [getHeader](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fieldtype/#getHeader) | Un campo intestazione; vedi le limitazioni di segnaposto e formato di seguito. |
| [getFooter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fieldtype/#getFooter) | Un campo piè di pagina. |

Ad esempio, [getDateTime3](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fieldtype/#getDateTime3) rappresenta giorno, nome completo del mese e anno in inglese. Questi sono formati di campo predefiniti, non stringhe di formato data arbitrario. La lingua impostata con [setLanguageId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) e l’applicazione che elabora la presentazione possono influire sul risultato visualizzato.

## **Crea un campo da una stringa interna**

La sovraccarico di stringa di [addField](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/#addField) accetta un identificatore di campo interno. Usalo quando devi conservare un identificatore fornito da un’altra applicazione che non ha un valore predefinito. Puoi anche costruire un [FieldType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fieldtype/) dall’identificatore. [FieldType.getInternalString](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fieldtype/#getInternalString) espone quell’identificatore per l’ispezione.

Questo esempio memorizza un campo specifico dell’applicazione `custom-report-id` con il testo di fallback `Report-042`. L’identificatore non registra un calcolo: Aspose.Slides non genera ID report per un tipo sconosciuto. L’applicazione che comprende questo identificatore deve fornire il suo significato e aggiornare il valore.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Dopo questo round‑trip PPTX, il tipo è `custom-report-id` e il testo è `Report-042`. Passare una stringa come `yyyy-MM-dd` denominerà un tipo di campo; non configurerà un formato data personalizzato. Per una data fissa in un formato arbitrario, usa il testo ordinario.

## **Ispeziona, modifica e rimuovi i campi data/ora**

Modifica un campo esistente attraverso [Field.setType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/field/#setType). Verifica che il campo esista prima di accedere al suo tipo. Per interrompere gli aggiornamenti automatici, chiama [Portion.removeField](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/#removeField). Questo mantiene la porzione e il suo testo corrente rimuovendo l’associazione al campo. Se ti serve un valore fisso specifico, assegna quel testo dopo aver rimosso il campo.

Per l’impostazione API associata all’elaborazione dei campi data/ora, vedi [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). L’esempio sottostante utilizza una data di approvazione esplicita quando converte un campo in testo ordinario.

Scarica [sample.pptx](sample.pptx) e posizionalo nella directory di lavoro. Contiene due forme di testo denominati, `UpdatedAt` e `ApprovedDate`, ognuna con un campo data/ora, più etichette di testo ordinario. L’esempio seguente percorre le forme di testo di primo livello nelle diapositive regolari. Cambia i campi data/ora in un formato data lunga e li rende italici, preservando le altre formattazioni. Solo i campi in `ApprovedDate` diventano testo fisso.

La data di approvazione è 5 aprile 2030; gli indici dei mesi JavaScript partono da zero, quindi aprile è `3`. UTC è usato sia per la costruzione sia per la formattazione per mantenere la data indipendente dal fuso orario locale.

Il campione riconosce gli identificatori interni incorporati `datetime` e `datetime1` attraverso `datetime13`. Gruppi, tabelle, note, layout e master richiedono l’attraversamento dei propri contenitori di testo e sono fuori dallo scopo di questo esempio.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Dopo la riapertura, `UpdatedAt` ha tipo `datetime3` e rimane dinamico. `ApprovedDate` non ha campo e contiene `05 April 2030`. Entrambe le porzioni data sono italiche, e la loro dimensione carattere originale, impostazione grassetto e colore rimangono intatti. Le etichette di testo ordinario non sono state modificate. La verifica legge la prima porzione delle due forme conosciute nel campione fornito.

## **Mantieni la formattazione del testo**

Lavora con la porzione esistente quando aggiungi un campo, ne cambi il tipo o lo rimuovi. Queste operazioni conservano la formattazione di quella porzione. Usa [Portion.getPortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/#getPortionFormat) per modificare solo le proprietà necessarie, come negli esempi per colore o corsivo.

Evita di ricostruire un intero riquadro di testo solo per aggiornare un campo: farlo può perdere i confini originali delle porzioni e la loro formattazione individuale. Distinguere inoltre la formattazione impostata esplicitamente da quella ereditata dal paragrafo, layout o tema. Vedi [Text Formatting](/slides/it/nodejs-java/text-formatting/) per opzioni di formattazione più ampie.

## **Campi e segnaposti intestazione/piè di pagina**

Un campo è parte di una porzione di testo. Un segnaposto è una forma con un ruolo nella presentazione, come piè di pagina o numero diapositiva. Aggiungere un campo a una casella di testo ordinaria non trasforma quella forma in un segnaposto.

I gestori di intestazione/piè di pagina controllano il testo e la visibilità dei segnaposti su diapositive, layout e master, inclusa la propagazione alle diapositive dipendenti. Un campo numero in una casella di testo personalizzata può quindi essere utile anche quando non si utilizza il segnaposto numero diapositiva. Al contrario, modificare la visibilità del segnaposto non rimuove un campo da una casella di testo non correlata.

I tipi predefiniti di intestazione e piè di pagina non creano i corrispondenti segnaposti né forniscono il loro contenuto. In particolare, una diapositiva PowerPoint normale non ha un segnaposto intestazione; le intestazioni appartengono alle pagine di note e ai dispense. Non presumere che un campo intestazione o piè di pagina in una forma arbitraria ottenga automaticamente il testo configurato tramite un gestore di segnaposto. Per quel flusso di lavoro, vedi [Presentation Headers and Footers](/slides/it/nodejs-java/presentation-header-and-footer/).

## **Limitazioni PPTX e PPT**

Verifica sia il tipo di campo sia il testo risultante dopo il salvataggio e la riapertura. Conservare un identificatore non dimostra che un’applicazione possa calcolare o visualizzare il suo valore.

| Formato | Comportamento del campo e limitazioni |
|---|---|
| PPTX | Memorizza gli identificatori di campo interni accanto al testo del campo. Nei controlli di round‑trip, i tipi predefiniti e l’identificatore personalizzato usato sopra sono sopravvissuti al salvataggio e alla riapertura. Il tipo personalizzato sconosciuto ha mantenuto il suo testo di fallback; non ha acquisito una logica di calcolo automatica. Un’altra applicazione potrebbe trattare gli identificatori non supportati in modo diverso. |
| PPT | Utilizza rappresentazioni di campo legacy e ha una compatibilità più limitata. Nei controlli di round‑trip, i campi numero diapositiva e i campi data/ora predefiniti sono sopravvissuti al salvataggio e alla riapertura. Un campo personalizzato in una casella di testo ordinaria si è riaperto con il suo identificatore ma con `*` come testo; un campo intestazione nello stesso contesto ha prodotto anch’esso `*`. Non fare affidamento su campi personalizzati o contesti di campo non supportati per mantenere il testo visibile. |

Per un output portabile e fisso, converti i campi non supportati in testo ordinario e assegna esplicitamente il valore desiderato prima del salvataggio. Questo conserva il testo scelto ma interrompe intenzionalmente gli aggiornamenti automatici. Testa anche l’applicazione di destinazione quando il suo ricalcolo dei campi è parte del tuo flusso di lavoro.

## **FAQ**

**Come posso capire se un numero o una data visualizzata è un campo?**  
Ispeziona [Portion.getField](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/#getField). Un valore non nullo identifica un campo; il solo testo visualizzato non può dirlo.

**La rimozione di un campo elimina il suo testo o la sua formattazione?**  
No. [removeField](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/#removeField) converte la porzione esistente in testo ordinario. Assegna un valore esplicito in seguito se ti serve una data fissa o un valore di fallback.

**Una stringa interna può definire un nuovo formato data o formula?**  
No. Identifica un tipo di campo. Un identificatore sconosciuto non fornisce un valutatore né un modello di formato data. Usa un tipo predefinito supportato o formatta il valore come testo ordinario.

**Perché verificare nuovamente una presentazione dopo averla salvata?**  
Gli identificatori di campo, il testo calcolato e la formattazione sono aspetti distinti da verificare. La conversione del formato può cambiare il risultato visibile anche se l’identificatore di campo è ancora presente.