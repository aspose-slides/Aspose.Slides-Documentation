---
title: Gestisci i campi di testo nelle presentazioni PowerPoint in PHP
linktitle: Campi di testo
type: docs
weight: 52
url: /it/php-java/text-fields/
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
- PHP
- Aspose.Slides
description: "Crea, ispeziona, modifica e rimuovi i campi di testo nelle presentazioni PowerPoint con Aspose.Slides per PHP tramite Java. Conserva la formattazione e verifica i file PPTX e PPT salvati."
---
## **Panoramica**

Un paragrafo di testo è composto da porzioni. Una [Portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/) ordinaria contiene testo letterale; una porzione di campo ha anche un [Field](https://reference.aspose.com/slides/it/php-java/aspose.slides/field/) il cui tipo identifica un valore aggiornato automaticamente, come il numero della diapositiva o la data. Due porzioni possono visualizzare gli stessi caratteri mentre solo una contiene un campo.

Usa [Portion::getField](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#getField) per distinguerle: è `null` per il testo ordinario. [Portion::addField](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#addField) converte una porzione esistente in un campo. Mantieni un’etichetta e il suo valore dinamico in porzioni separate in modo che la conversione del valore non sostituisca anche l’etichetta.

Questa guida tratta i campi all’interno del testo, la loro formattazione e il salvataggio in PPTX e PPT. Per i riquadri di testo e i paragrafi, vedi [Gestisci testo](/slides/it/php-java/manage-text/).

## **Crea un campo numero diapositiva**

L’esempio completo seguente crea una casella di testo contenente un’etichetta letterale `Slide ` seguita da un numero aggiornato automaticamente. Imposta la dimensione, lo spessore e il colore del numero prima di aggiungere il campo, quindi riapre la presentazione salvata e verifica il tipo di campo, il testo e la formattazione. Non è necessario alcun file di input.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

La nuova presentazione inizia con il numero diapositiva 1, quindi il testo è `Slide 1`, e entrambi i controlli stampano `true`. Il numero rimane un campo dopo la riapertura; non è un `1` letterale. Gli indici nella verifica si riferiscono alla forma e alle porzioni create da questo esempio.

## **Scegli un tipo di campo**

[FieldType](https://reference.aspose.com/slides/it/php-java/aspose.slides/fieldtype/) fornisce i seguenti metodi per ottenere valori predefiniti. Passa il valore appropriato a [addField](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#addField).

| Metodo | Scopo |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/it/php-java/aspose.slides/fieldtype/#getSlideNumber) | Il numero corrente della diapositiva. |
| [getDateTime](https://reference.aspose.com/slides/it/php-java/aspose.slides/fieldtype/#getDateTime) | Data/ora nel formato predefinito dell’applicazione di rendering. |
| [getDateTime1](https://reference.aspose.com/slides/it/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/it/php-java/aspose.slides/fieldtype/#getDateTime9) | Formati data o data/ora combinati predefiniti. |
| [getDateTime10](https://reference.aspose.com/slides/it/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/it/php-java/aspose.slides/fieldtype/#getDateTime13) | Formati ora predefiniti, con opzioni per i secondi e orologio a 12 ore. |
| [getHeader](https://reference.aspose.com/slides/it/php-java/aspose.slides/fieldtype/#getHeader) | Un campo intestazione; vedi le limitazioni di segnaposto e formato di seguito. |
| [getFooter](https://reference.aspose.com/slides/it/php-java/aspose.slides/fieldtype/#getFooter) | Un campo piè di pagina. |

Ad esempio, [getDateTime3](https://reference.aspose.com/slides/it/php-java/aspose.slides/fieldtype/#getDateTime3) rappresenta giorno, nome mese completo e anno in inglese. Si tratta di formati campo predefiniti, non di stringhe di formato data PHP arbitrari. La lingua impostata con [setLanguageId](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseportionformat/#setLanguageId) e l’applicazione che elabora la presentazione possono influire sul risultato visualizzato.

## **Crea un campo da una stringa interna**

La sovraccarico stringa di [addField](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#addField) accetta un identificatore di campo interno. Usalo quando devi conservare un identificatore fornito da un’altra applicazione che non ha un valore predefinito. Puoi anche costruire un [FieldType](https://reference.aspose.com/slides/it/php-java/aspose.slides/fieldtype/#FieldType) dall’identificatore. [FieldType::getInternalString](https://reference.aspose.com/slides/it/php-java/aspose.slides/fieldtype/#getInternalString) espone quell’identificatore per l’ispezione.

Questo esempio memorizza un campo specifico dell’applicazione `custom-report-id` con il testo di fallback `Report-042`. L’identificatore non registra alcun calcolo: Aspose.Slides non genera ID report per un tipo sconosciuto. L’applicazione che comprende questo identificatore deve fornire il significato e aggiornare il valore.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Dopo questo round‑trip PPTX, il tipo è `custom-report-id` e il testo è `Report-042`. Passare una stringa come `Y-m-d` nominerebbe un tipo di campo; non configurerebbe un formato data personalizzato. Per una data fissa in un formato arbitrario, usa testo ordinario.

## **Ispeziona, modifica e rimuovi campi data/ora**

Modifica un campo esistente tramite [Field::setType](https://reference.aspose.com/slides/it/php-java/aspose.slides/field/#setType). Verifica che il campo esista prima di accedere al suo tipo. Per interrompere gli aggiornamenti automatici, chiama [Portion::removeField](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#removeField). Questa operazione mantiene la porzione e il suo testo corrente rimuovendo l’associazione al campo. Se ti serve un valore fisso specifico, assegna quel testo dopo aver rimosso il campo.

Per l’impostazione API relativa all’elaborazione dei campi data/ora, vedi [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#setCurrentDateTime). L’esempio seguente utilizza una data di approvazione esplicita quando converte un campo in testo ordinario.

Scarica [sample.pptx](sample.pptx) e posizionalo nella directory di lavoro JavaBridge, oppure passa il suo percorso assoluto al costruttore della presentazione. Contiene due forme di testo nominate, `UpdatedAt` e `ApprovedDate`, ciascuna con un campo data/ora, più etichette di testo ordinario. L’esempio successivo percorre le forme di testo di primo livello nelle diapositive regolari. Cambia i campi data/ora in un formato data lunga e li rende in corsivo, preservando le altre formattazioni. Solo i campi in `ApprovedDate` diventano testo fisso.

Il campione riconosce gli identificatori interni integrati `datetime` e `datetime1` fino a `datetime13`. Gruppi, tabelle, note, layout e master richiedono l’attraversamento dei propri contenitori di testo e sono fuori dallo scopo di questo esempio.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Dopo la riapertura, `UpdatedAt` ha tipo `datetime3` e rimane dinamico. `ApprovedDate` non ha campo e contiene `05 April 2030`. Entrambe le porzioni data sono in corsivo, e la loro dimensione, impostazione grassetto e colore originali restano intatti. Le etichette di testo ordinario sono inalterate. La verifica legge la prima porzione delle due forme note nel campione fornito.

## **Conserva la formattazione del testo**

Lavora con la porzione esistente quando aggiungi, cambi il tipo o rimuovi un campo. Queste operazioni mantengono la formattazione della porzione. Usa [Portion::getPortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#getPortionFormat) per modificare solo le proprietà necessarie, come mostrano gli esempi per colore o corsivo.

Evita di ricostruire un intero riquadro di testo solo per aggiornare un campo: farlo può perdere i confini originali delle porzioni e la loro formattazione individuale. Distinguere inoltre la formattazione impostata esplicitamente da quella ereditata dal paragrafo, dal layout o dal tema. Vedi [Formattazione del testo](/slides/it/php-java/text-formatting/) per opzioni di formattazione più ampie.

## **Campi e segnaposto intestazione/piè di pagina**

Un campo è parte di una porzione di testo. Un segnaposto è una forma con un ruolo nella presentazione, ad esempio un piè di pagina o un numero diapositiva. Aggiungere un campo a una casella di testo ordinaria non trasforma quella forma in un segnaposto.

I gestori di intestazione/piè di pagina controllano il testo segnaposto e la visibilità su diapositive, layout e master, includendo la propagazione alle diapositive dipendenti. Un campo numero in una casella di testo personalizzata può dunque essere utile anche quando non si utilizza il segnaposto numero diapositiva. Al contrario, modificare la visibilità del segnaposto non rimuove un campo da una casella di testo non correlata.

I tipi di intestazione e piè di pagina predefiniti non creano i corrispondenti segnaposti né forniscono il loro contenuto. In particolare, una diapositiva PowerPoint normale non ha un segnaposto intestazione; le intestazioni appartengono alle pagine note e ai fogli di stampa. Non presumere che un campo intestazione o piè di pagina in una forma arbitraria ottenga automaticamente il testo configurato tramite un gestore di segnaposto. Per quel flusso di lavoro, vedi [Intestazioni e piè di pagina della presentazione](/slides/it/php-java/presentation-header-and-footer/).

## **Limitazioni PPTX e PPT**

Verifica sia il tipo di campo sia il testo risultante dopo il salvataggio e la riapertura. Conservare un identificatore non dimostra che un’applicazione possa calcolare o visualizzare il suo valore.

| Formato | Comportamento del campo e limitazioni |
|---|---|
| PPTX | Memorizza gli identificatori di campo interni accanto al testo del campo. Nei controlli di round‑trip, i tipi predefiniti e l’identificatore personalizzato usato sopra sono sopravvissuti al salvataggio e alla riapertura. Il tipo personalizzato sconosciuto ha mantenuto il suo testo di fallback; non ha acquisito logica di calcolo automatico. Un’altra applicazione potrebbe trattare gli identificatori non supportati diversamente. |
| PPT | Utilizza rappresentazioni di campo legacy e ha compatibilità più limitata. Nei controlli di round‑trip, i campi numero diapositiva e data/ora predefiniti sono sopravvissuti al salvataggio e alla riapertura. Un campo personalizzato in una casella di testo ordinaria è stato riaperto con il suo identificatore ma con `*` come testo; un campo intestazione nello stesso contesto ha prodotto anch’esso `*`. Non fare affidamento sul fatto che i campi personalizzati o i contesti di campo non supportati mantengano il loro testo visibile. |

Per un output portabile e fisso, converti i campi non supportati in testo ordinario e assegna esplicitamente il valore desiderato prima del salvataggio. Questo conserva il testo scelto ma interrompe intenzionalmente gli aggiornamenti automatici. Testa anche l’applicazione di destinazione quando il suo ricalcolo dei campi è parte del tuo flusso di lavoro.

## **FAQ**

**Come posso capire se un numero o una data visualizzata è un campo?**

Ispeziona [Portion::getField](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#getField). Un valore non nullo identifica un campo; il solo testo visualizzato non può dirlo.

**La rimozione di un campo elimina il suo testo o la sua formattazione?**

No. [removeField](https://reference.aspose.com/slides/it/php-java/aspose.slides/portion/#removeField) converte la porzione esistente in testo ordinario. Assegna un valore esplicito in seguito se hai bisogno di una data congelata o di un valore di fallback.

**Una stringa interna può definire un nuovo formato data o una formula?**

No. Identifica un tipo di campo. Un identificatore sconosciuto non fornisce un valutatore né un modello di formato data PHP. Usa un tipo predefinito supportato o formatta il valore come testo ordinario.

**Perché controllare nuovamente una presentazione dopo averla salvata?**

Identificatori di campo, testo calcolato e formattazione sono elementi distinti da verificare. La conversione del formato può modificare il risultato visibile anche quando l’identificatore del campo è ancora presente.