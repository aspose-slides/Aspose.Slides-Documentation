---
title: Gestire i campi di testo nelle presentazioni PowerPoint in Java
linktitle: Campi di testo
type: docs
weight: 52
url: /it/java/text-fields/
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
- Java
- Aspose.Slides
description: "Crea, ispeziona, modifica e rimuovi i campi di testo nelle presentazioni PowerPoint con Aspose.Slides per Java. Conserva la formattazione e verifica i file PPTX e PPT salvati."
---
## **Panoramica**

Un paragrafo di testo è costituito da porzioni. Una [IPortion](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/) ordinaria contiene testo letterale; una porzione di campo ha anche un [IField](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifield/) il cui tipo identifica un valore aggiornato automaticamente, come il numero della diapositiva o la data. Due porzioni possono visualizzare gli stessi caratteri mentre solo una contiene un campo.

Usa [IPortion.getField](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/#getField--) per distinguerle: è `null` per il testo ordinario. [IPortion.addField](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) converte una porzione esistente in un campo. Mantieni un’etichetta e il suo valore dinamico in porzioni separate in modo che la conversione del valore non sostituisca anche l’etichetta.

Questa guida copre i campi all'interno del testo, la loro formattazione e il salvataggio in PPTX e PPT. Per riquadri di testo e paragrafi, vedere [Manage Text](/slides/it/java/manage-text/).

## **Crea un campo numero diapositiva**

Il seguente esempio completo crea una casella di testo contenente un'etichetta letterale `Slide ` seguita da un numero aggiornato automaticamente. Imposta la dimensione, lo spessore e il colore del numero prima di aggiungere il campo, quindi riapre la presentazione salvata e verifica il tipo di campo, il testo e la formattazione. Non è necessario alcun file di input.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

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

La nuova presentazione inizia con il numero diapositiva 1, quindi il testo è `Slide 1`, e entrambe le verifiche stampano `true`. Il numero rimane un campo dopo la riapertura; non è un `1` letterale. I cast e gli indici nella verifica si riferiscono alla forma e alle porzioni create da questo esempio.

## **Scegli un tipo di campo**

[FieldType](https://reference.aspose.com/slides/it/java/com.aspose.slides/fieldtype/) implementa [IFieldType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifieldtype/) e fornisce i seguenti metodi per ottenere valori predefiniti. Passa il valore appropriato a [addField](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/it/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Il numero attuale della diapositiva. |
| [getDateTime](https://reference.aspose.com/slides/it/java/com.aspose.slides/fieldtype/#getDateTime--) | Data/ora nel formato predefinito dell'applicazione di rendering. |
| [getDateTime1](https://reference.aspose.com/slides/it/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/it/java/com.aspose.slides/fieldtype/#getDateTime9--) | Formati di data predefiniti o combinati data/ora. |
| [getDateTime10](https://reference.aspose.com/slides/it/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/it/java/com.aspose.slides/fieldtype/#getDateTime13--) | Formati di ora predefiniti, con opzioni per i secondi e un orologio a 12 ore. |
| [getHeader](https://reference.aspose.com/slides/it/java/com.aspose.slides/fieldtype/#getHeader--) | Un campo intestazione; vedere le limitazioni di segnaposto e formato di seguito. |
| [getFooter](https://reference.aspose.com/slides/it/java/com.aspose.slides/fieldtype/#getFooter--) | Un campo piè di pagina. |

Ad esempio, [getDateTime3](https://reference.aspose.com/slides/it/java/com.aspose.slides/fieldtype/#getDateTime3--) rappresenta il giorno, il nome completo del mese e l'anno in inglese. Questi sono formati di campo predefiniti, non stringhe di formato data Java arbitrarie. La lingua impostata con [setLanguageId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) e l'applicazione che elabora la presentazione possono influenzare il risultato visualizzato.

## **Crea un campo da una stringa interna**

La sovraccarico di stringa di [addField](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/#addField-java.lang.String-) accetta un identificatore di campo interno. Usala quando si deve conservare un identificatore fornito da un'altra applicazione che non ha un valore predefinito. È inoltre possibile costruire un [FieldType](https://reference.aspose.com/slides/it/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) dall'identificatore. [IFieldType.getInternalString](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifieldtype/#getInternalString--) espone quell'identificatore per l'ispezione.

Questo esempio memorizza un campo specifico dell'applicazione `custom-report-id` con il testo di riserva `Report-042`. L'identificatore non registra alcun calcolo: Aspose.Slides non genera ID report per un tipo sconosciuto. L'applicazione che interpreta questo identificatore deve fornire il suo significato e aggiornare il suo valore.

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

Dopo questo round‑trip PPTX, il tipo è `custom-report-id` e il testo è `Report-042`. Passare una stringa come `yyyy-MM-dd` denominerebbe un tipo di campo; non configurerebbe un formato data personalizzato. Per una data fissa in un formato arbitrario, usa testo ordinario.

## **Ispeziona, modifica e rimuovi campi data/ora**

Modifica un campo esistente tramite [IField.setType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Verifica che il campo esista prima di accedere al suo tipo. Per interrompere gli aggiornamenti automatici, chiama [IPortion.removeField](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/#removeField--). Questo conserva la porzione e il suo testo corrente rimuovendo l'associazione al campo. Se ti serve un valore fisso specifico, assegna quel testo dopo aver rimosso il campo.

Per l'impostazione API associata all'elaborazione dei campi data/ora, vedere [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). L'esempio seguente utilizza una data di approvazione esplicita quando si converte un campo in testo ordinario.

Scarica [sample.pptx](sample.pptx) e posizionalo nella directory di lavoro. Contiene due forme di testo nominate, `UpdatedAt` e `ApprovedDate`, ciascuna con un campo data/ora, più etichette di testo ordinario. Il seguente esempio percorre le forme di testo di primo livello su diapositive regolari. Cambia i campi data/ora in un formato data estesa e li rende italici, conservando le altre formattazioni. Solo i campi in `ApprovedDate` diventano testo fisso.

Il campione riconosce gli identificatori interni integrati `datetime` e `datetime1` fino a `datetime13`. Gruppi, tabelle, note, layout e master richiedono l'attraversamento dei propri contenitori di testo e sono al di fuori dello scopo di questo esempio.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

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
                        String fixedDate = approvalDate.format(dateFormat);
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

Dopo la riapertura, `UpdatedAt` ha tipo `datetime3` e rimane dinamico. `ApprovedDate` non ha campo e contiene `05 April 2030`. Entrambe le porzioni data sono italiche, e la loro dimensione del carattere originale, l'impostazione grassetto e il colore rimangono intatti. Le etichette di testo ordinario non sono cambiate. La verifica legge la prima porzione delle due forme note nel campione fornito.

## **Preserva la formattazione del testo**

Lavora con la porzione esistente quando aggiungi un campo, ne cambi il tipo o lo rimuovi. Queste operazioni conservano la formattazione di quella porzione. Usa [IPortion.getPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/#getPortionFormat--) per modificare solo le proprietà necessarie, come fanno gli esempi per colore o italico.

Evita di ricostruire un intero riquadro di testo solo per aggiornare un campo: farlo può perdere i confini originali delle porzioni e la loro formattazione individuale. Inoltre, distingui la formattazione impostata esplicitamente da quella ereditata dal paragrafo, dal layout o dal tema. Vedi [Text Formatting](/slides/it/java/text-formatting/) per opzioni di formattazione più ampie.

## **Campi e segnaposto intestazione/piè di pagina**

Un campo è parte di una porzione di testo. Un segnaposto è una forma con un ruolo nella presentazione, come un piè di pagina o il numero della diapositiva. Aggiungere un campo a una casella di testo ordinaria non trasforma quella forma in un segnaposto.

I gestori di intestazione/piè di pagina controllano il testo del segnaposto e la visibilità su diapositive, layout e master, includendo la propagazione alle diapositive dipendenti. Un campo numero in una casella di testo personalizzata può quindi essere utile anche se non utilizzi il segnaposto numero diapositiva. Al contrario, modificare la visibilità del segnaposto non rimuove un campo da una casella di testo non correlata.

I tipi predefiniti di intestazione e piè di pagina non creano i corrispondenti segnaposti né forniscono il loro contenuto. In particolare, una diapositiva PowerPoint normale non ha un segnaposto intestazione; le intestazioni appartengono alle pagine delle note e ai volanti. Non supporre che un campo intestazione o piè di pagina in una forma arbitraria ottenga automaticamente il testo configurato tramite un gestore di segnaposti. Per quel flusso di lavoro, vedere [Presentation Headers and Footers](/slides/it/java/presentation-header-and-footer/).

## **Limitazioni PPTX e PPT**

Verifica sia il tipo di campo sia il testo risultante dopo il salvataggio e la riapertura. Conservare un identificatore non prova che un'applicazione possa calcolare o visualizzare il suo valore.

| Formato | Comportamento del campo e limitazioni |
|---|---|
| PPTX | Memorizza gli identificatori di campo interni accanto al testo del campo. Nei controlli round‑trip, i tipi predefiniti e l'identificatore personalizzato usato sopra sono sopravvissuti al salvataggio e alla riapertura. Il tipo personalizzato sconosciuto ha mantenuto il suo testo di riserva; non ha acquisito logica di calcolo automatico. Un'altra applicazione potrebbe gestire gli identificatori non supportati diversamente. |
| PPT | Utilizza rappresentazioni di campo legacy e ha una compatibilità più limitata. Nei controlli round‑trip, i campi numero diapositiva e i campi data/ora predefiniti sono sopravvissuti al salvataggio e alla riapertura. Un campo personalizzato in una casella di testo di diapositiva ordinaria si è riaperto con il suo identificatore ma con `*` come testo; anche un campo intestazione nello stesso contesto ha prodotto `*`. Non fare affidamento su campi personalizzati o contesti di campo non supportati per mantenere il testo visibile. |

Per un output portabile e fisso, converte i campi non supportati in testo ordinario e assegna esplicitamente il valore desiderato prima del salvataggio. Questo preserva il testo scelto ma interrompe intenzionalmente gli aggiornamenti automatici. Testa anche l'applicazione target quando il suo ricalcolo dei campi è parte del tuo flusso di lavoro.

## **FAQ**

**Come posso capire se un numero o una data visualizzati sono un campo?**

Ispeziona [IPortion.getField](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/#getField--). Un valore diverso da `null` identifica un campo; il solo testo visualizzato non può dirlo.

**La rimozione di un campo elimina il suo testo o la sua formattazione?**

No. [removeField](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportion/#removeField--) converte la porzione esistente in testo ordinario. Assegna un valore esplicito successivamente se ti serve una data congelata o un valore di riserva specifico.

**Una stringa interna può definire un nuovo formato data o formula?**

No. Identifica un tipo di campo. Un identificatore sconosciuto non fornisce un valutatore né un modello di formato data Java. Usa un tipo predefinito supportato o formatta il valore come testo ordinario.

**Perché verificare nuovamente una presentazione dopo averla salvata?**

Gli identificatori di campo, il testo calcolato e la formattazione sono elementi separati da verificare. La conversione del formato può modificare il risultato visibile anche se l'identificatore di campo è ancora presente.