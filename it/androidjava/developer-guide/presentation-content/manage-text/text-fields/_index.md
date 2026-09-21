---
title: Gestire i campi di testo nelle presentazioni PowerPoint su Android
linktitle: Campi di testo
type: docs
weight: 52
url: /it/androidjava/text-fields/
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
- Android
- Java
- Aspose.Slides
description: "Crea, ispeziona, modifica e rimuovi i campi di testo nelle presentazioni PowerPoint con Aspose.Slides per Android via Java. Conserva la formattazione e verifica i file PPTX e PPT salvati."
---
## **Panoramica**

Un paragrafo di testo è costituito da porzioni. Una [IPortion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/) contiene testo letterale; una porzione di campo contiene anche un [IField](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifield/) il cui tipo identifica un valore aggiornato automaticamente, come il numero della diapositiva o la data. Due porzioni possono visualizzare gli stessi caratteri mentre solo una contiene un campo.

Utilizza [IPortion.getField](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/#getField--) per distinguerle: è `null` per il testo ordinario. [IPortion.addField](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) converte una porzione esistente in un campo. Mantieni un'etichetta e il suo valore dinamico in porzioni separate in modo che la conversione del valore non sostituisca anche l'etichetta.

Questa guida tratta i campi all'interno del testo, la loro formattazione e il salvataggio in PPTX e PPT. Per riquadri di testo e paragrafi, vedi [Manage Text](/slides/it/androidjava/manage-text/).

## **Crea un campo Numero diapositiva**

L'esempio completo seguente crea una casella di testo contenente un'etichetta letterale `Slide ` seguita da un numero aggiornato automaticamente. Imposta la dimensione, lo spessore e il colore del numero prima di aggiungere il campo, quindi riapre la presentazione salvata e verifica il tipo di campo, il testo e la formattazione. Non è necessario alcun file di input.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

La nuova presentazione inizia con il numero diapositiva 1, quindi il testo è `Slide 1`, e entrambe le verifiche stampano `true`. Il numero rimane un campo dopo la riapertura; non è un letterale `1`. I cast e gli indici nella verifica si riferiscono alla forma e alle porzioni create da questo esempio.

## **Scegli un tipo di campo**

[FieldType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fieldtype/) implementa [IFieldType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifieldtype/) e fornisce i seguenti metodi per ottenere valori predefiniti. Passa il valore appropriato a [addField](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Metodo | Scopo |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | Il numero corrente della diapositiva. |
| [getDateTime](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | Data/ora nel formato predefinito dell'applicazione di rendering. |
| [getDateTime1](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | Formati di data predefiniti o formati combinati data/ora. |
| [getDateTime10](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | Formati di ora predefiniti, con opzioni per i secondi e un orologio a 12 ore. |
| [getHeader](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fieldtype/#getHeader--) | Un campo intestazione; vedere le limitazioni di segnaposto e formato di seguito. |
| [getFooter](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fieldtype/#getFooter--) | Un campo piè di pagina. |

Ad esempio, [getDateTime3](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) rappresenta giorno, nome completo del mese e anno in inglese. Questi sono formati di campo predefiniti, non stringhe di formato data Java arbitrarie. La lingua impostata con [setLanguageId](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) e l'applicazione che elabora la presentazione possono influenzare il risultato visualizzato.

## **Crea un campo da una stringa interna**

La sovraccarico di stringa di [addField](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) accetta un identificatore di campo interno. Usalo quando devi preservare un identificatore fornito da un'altra applicazione che non ha un valore predefinito. Puoi anche costruire un [FieldType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) dall'identificatore. [IFieldType.getInternalString](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) espone quell'identificatore per l'ispezione.

Questo esempio memorizza un campo `custom-report-id` specifico dell'applicazione con il testo di ripiego `Report-042`. L'identificatore non registra alcun calcolo: Aspose.Slides non genera ID report per un tipo sconosciuto. L'applicazione che interpreta questo identificatore deve fornire il suo significato e aggiornare il suo valore.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Dopo questo round‑trip PPTX, il tipo è `custom-report-id` e il testo è `Report-042`. Passare una stringa come `yyyy-MM-dd` definirebbe un tipo di campo; non configurerebbe un formato data personalizzato. Per una data fissa in un formato arbitrario, usa testo ordinario.

## **Ispeziona, modifica e rimuovi campi data/ora**

Cambia un campo esistente tramite [IField.setType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Verifica che il campo esista prima di accedere al suo tipo. Per interrompere gli aggiornamenti automatici, chiama [IPortion.removeField](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/#removeField--). Questo mantiene la porzione e il suo testo corrente rimuovendo l'associazione al campo. Se ti serve un valore fisso specifico, assegna quel testo dopo aver rimosso il campo.

Per l'impostazione API associata all'elaborazione dei campi data/ora, vedi [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). L'esempio seguente utilizza una data di approvazione esplicita quando converte un campo in testo ordinario.

Scarica [sample.pptx](sample.pptx) e posizionalo nella directory di lavoro. Contiene due forme di testo nominate, `UpdatedAt` e `ApprovedDate`, ciascuna con un campo data/ora, più etichette di testo ordinario. L'esempio seguente percorre le forme di testo di livello superiore sulle diapositive normali. Cambia i campi data/ora in un formato data lunga e li rende in corsivo, mantenendo la loro altra formattazione. Solo i campi in `ApprovedDate` diventano testo fisso.

Il campione riconosce gli identificatori interni incorporati `datetime` e `datetime1` fino a `datetime13`. Gruppi, tabelle, note, layout e master richiedono l'attraversamento dei propri contenitori di testo e sono al di fuori dello scopo di questo esempio.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Dopo la riapertura, `UpdatedAt` ha tipo `datetime3` e rimane dinamico. `ApprovedDate` non ha alcun campo e contiene `05 April 2030`. Entrambe le porzioni data sono in corsivo, e la loro dimensione di carattere originale, impostazione grassetto e colore rimangono intatti. Le etichette di testo ordinario sono invariate. La verifica legge la prima porzione delle due forme conosciute nel campione fornito.

## **Preserva la formattazione del testo**

Lavora con la porzione esistente quando aggiungi un campo, cambi il suo tipo o lo rimuovi. Queste operazioni conservano la formattazione di quella porzione. Usa [IPortion.getPortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/#getPortionFormat--) per modificare solo le proprietà necessarie, come mostrano gli esempi per il colore o il corsivo.

Evita di ricostruire un intero riquadro di testo solo per aggiornare un campo: farlo può far perdere i confini originali delle porzioni e la loro formattazione individuale. Distinguere inoltre la formattazione impostata esplicitamente da quella ereditata dal paragrafo, layout o tema. Vedi [Text Formatting](/slides/it/androidjava/text-formatting/) per opzioni di formattazione più ampie.

## **Campi e segnaposti intestazione/piè di pagina**

Un campo è parte di una porzione di testo. Un segnaposto è una forma con un ruolo nella presentazione, come un piè di pagina o un numero diapositiva. Aggiungere un campo a una casella di testo ordinaria non trasforma quella forma in un segnaposto.

I gestori di intestazione/piè di pagina controllano il testo e la visibilità dei segnaposti su diapositive, layout e master, includendo la propagazione alle diapositive dipendenti. Un campo numero in una casella di testo personalizzata può quindi essere utile anche se non utilizzi il segnaposto numero diapositiva. Al contrario, modificare la visibilità del segnaposto non rimuove un campo da una casella di testo non correlata.

I tipi predefiniti di intestazione e piè di pagina non creano i corrispondenti segnaposti né forniscono il loro contenuto. In particolare, una diapositiva PowerPoint normale non ha un segnaposto intestazione; le intestazioni appartengono alle pagine di note e agli opuscoli. Non presumere che un campo intestazione o piè di pagina in una forma arbitraria ottenga automaticamente il testo configurato tramite un gestore di segnaposti. Per quel flusso di lavoro, vedi [Presentation Headers and Footers](/slides/it/androidjava/presentation-header-and-footer/).

## **Limitazioni PPTX e PPT**

Verifica sia il tipo di campo sia il testo risultante dopo aver salvato e riaperto. Conservare un identificatore non dimostra che un'applicazione possa calcolare o visualizzare il suo valore.

| Formato | Comportamento del campo e limitazioni |
|---|---|
| PPTX | Memorizza gli identificatori di campo interni insieme al testo del campo. Nei controlli di round‑trip, i tipi predefiniti e l'identificatore personalizzato usato sopra hanno sopportato il salvataggio e la riapertura. Il tipo personalizzato sconosciuto ha mantenuto il suo testo di ripiego; non ha acquisito una logica di calcolo automatico. Un'altra applicazione potrebbe trattare diversamente gli identificatori non supportati. |
| PPT | Utilizza rappresentazioni di campo legacy e ha una compatibilità più limitata. Nei controlli di round‑trip, i campi numero diapositiva e i campi data/ora predefiniti hanno sopportato il salvataggio e la riapertura. Un campo personalizzato in una casella di testo diapositiva ordinaria è stato riaperto con il suo identificatore ma con `*` come testo; un campo intestazione nello stesso contesto ha prodotto anche `*`. Non fare affidamento sul fatto che i campi personalizzati o i contesti di campo non supportati mantengano il loro testo visibile. |

Per un output portabile e fisso, converti i campi non supportati in testo ordinario e assegna esplicitamente il valore desiderato prima di salvare. Questo preserva il testo scelto ma interrompe intenzionalmente gli aggiornamenti automatici. Testa anche l'applicazione di destinazione quando il suo proprio ricalcolo dei campi fa parte del tuo flusso di lavoro.

## **FAQ**

**Come posso capire se un numero o una data visualizzati sono un campo?**

Ispeziona [IPortion.getField](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/#getField--). Un valore non nullo identifica un campo; il solo testo visualizzato non può dirlo.

**Rimuovere un campo rimuove anche il suo testo o la sua formattazione?**

No. [removeField](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportion/#removeField--) converte la porzione esistente in testo ordinario. Assegna un valore esplicito successivamente se ti serve una data fissa o un valore di ripiego particolare.

**Una stringa interna può definire un nuovo formato data o una formula?**

No. Identifica un tipo di campo. Un identificatore sconosciuto non fornisce un valutatore o un modello di formato data Java. Usa un tipo predefinito supportato o formatta un valore tu stesso come testo ordinario.

**Perché verificare nuovamente una presentazione dopo averla salvata?**

Gli identificatori di campo, il testo calcolato e la formattazione sono elementi separati da verificare. La conversione del formato può modificare il risultato visibile anche se l'identificatore di campo è ancora presente.