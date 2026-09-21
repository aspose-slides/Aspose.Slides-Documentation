---
title: Gestire i campi di testo nelle presentazioni PowerPoint in .NET
linktitle: Campi di testo
type: docs
weight: 52
url: /it/net/text-fields/
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
- C#
- Aspose.Slides
description: "Crea, ispeziona, modifica e rimuovi i campi di testo nelle presentazioni PowerPoint con Aspose.Slides per .NET. Preserva la formattazione e verifica i file PPTX e PPT salvati."
---
## **Panoramica**

Un paragrafo di testo è composto da porzioni. Una [IPortion](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/) ordinaria contiene testo letterale; una porzione di campo contiene anche un [IField](https://reference.aspose.com/slides/it/net/aspose.slides/ifield/) il cui tipo identifica un valore aggiornato automaticamente, come il numero della diapositiva o la data. Due porzioni possono visualizzare gli stessi caratteri mentre solo una contiene un campo.

Usa [IPortion.Field](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/field/) per distinguerle: è `null` per il testo ordinario. [IPortion.AddField](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/addfield/) converte una porzione esistente in un campo. Mantieni un'etichetta e il suo valore dinamico in porzioni separate in modo che la conversione del valore non sostituisca anche l'etichetta.

Questa guida tratta i campi all'interno del testo, la loro formattazione e il salvataggio in PPTX e PPT. Per fotogallery di testo e paragrafi, vedi [Manage Text](/slides/it/net/manage-text/).

## **Creare un campo numero diapositiva**

L'esempio completo seguente crea una casella di testo contenente un'etichetta letterale `Slide ` seguita da un numero aggiornato automaticamente. Imposta la dimensione, lo spessore e il colore del numero prima di aggiungere il campo, quindi riapre la presentazione salvata e controlla il tipo del campo, il testo e la formattazione. Non è necessario alcun file di input.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

La nuova presentazione inizia con il numero diapositiva 1, quindi il testo è `Slide 1`, e entrambe le verifiche stampano `True`. Il numero rimane un campo dopo la riapertura; non è un letterale `1`. I cast e gli indici nella verifica si riferiscono alla forma e alle porzioni create da questo esempio.

## **Scegliere un tipo di campo**

[FieldType](https://reference.aspose.com/slides/it/net/aspose.slides/fieldtype/) implementa [IFieldType](https://reference.aspose.com/slides/it/net/aspose.slides/ifieldtype/) e fornisce i seguenti valori predefiniti. Passa il valore appropriato a [AddField](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/addfield/).

| Valore | Scopo |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/it/net/aspose.slides/fieldtype/slidenumber/) | Il numero corrente della diapositiva. |
| [DateTime](https://reference.aspose.com/slides/it/net/aspose.slides/fieldtype/datetime/) | Data/ora nel formato predefinito dell'applicazione di rendering. |
| [DateTime1](https://reference.aspose.com/slides/it/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/it/net/aspose.slides/fieldtype/datetime9/) | Formati di data predefiniti o combinazioni data/ora. |
| [DateTime10](https://reference.aspose.com/slides/it/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/it/net/aspose.slides/fieldtype/datetime13/) | Formati di ora predefiniti, con opzioni per i secondi e orologio a 12 ore. |
| [Header](https://reference.aspose.com/slides/it/net/aspose.slides/fieldtype/header/) | Un campo intestazione; vedi le limitazioni di segnaposto e formato sotto. |
| [Footer](https://reference.aspose.com/slides/it/net/aspose.slides/fieldtype/footer/) | Un campo piè di pagina. |

Ad esempio, [DateTime3](https://reference.aspose.com/slides/it/net/aspose.slides/fieldtype/datetime3/) rappresenta giorno, nome completo del mese e anno in inglese. Si tratta di formati di campo predefiniti, non di stringhe di formato data .NET arbitrarie. L'[LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseportionformat/languageid/) della porzione e l'applicazione che elabora la presentazione possono influire sul risultato visualizzato.

## **Creare un campo da una stringa interna**

La sovraccarico di stringa di [AddField](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/addfield/) accetta un identificatore di campo interno. Usalo quando devi conservare un identificatore fornito da un'altra applicazione che non ha un valore predefinito. Puoi anche costruire un [FieldType](https://reference.aspose.com/slides/it/net/aspose.slides/fieldtype/fieldtype/) dall'identificatore. [IFieldType.InternalString](https://reference.aspose.com/slides/it/net/aspose.slides/ifieldtype/internalstring/) espone quell'identificatore per l'ispezione.

Questo esempio memorizza un campo `custom-report-id` specifico dell'applicazione con il testo di fallback `Report-042`. L'identificatore non registra un calcolo: Aspose.Slides non genera ID report per un tipo sconosciuto. L'applicazione che interpreta questo identificatore deve fornire il significato e aggiornare il valore.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Dopo questo round‑trip PPTX, il tipo è `custom-report-id` e il testo è `Report-042`. Passare una stringa come `yyyy-MM-dd` nome un tipo di campo; non configurerebbe un formato data personalizzato. Per una data fissa in un formato arbitrario, usa testo ordinario.

## **Ispezionare, modificare e rimuovere campi data/ora**

Leggi e modifica un campo esistente tramite [IField.Type](https://reference.aspose.com/slides/it/net/aspose.slides/ifield/type/). Verifica che il campo esista prima di accedere al suo tipo. Per fermare gli aggiornamenti automatici, chiama [IPortion.RemoveField](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/removefield/). Questo mantiene la porzione e il suo testo corrente, rimuovendo l'associazione al campo. Se ti serve un valore fisso specifico, assegna quel testo dopo aver rimosso il campo.

Per le impostazioni API associate all'elaborazione dei campi data/ora, vedi [Presentation.CurrentDateTime](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/currentdatetime/). L'esempio sotto utilizza una data di approvazione esplicita quando converte un campo in testo ordinario.

Scarica [sample.pptx](sample.pptx) e posizionalo nella directory di lavoro. Contiene due forme di testo nominate, `UpdatedAt` e `ApprovedDate`, ognuna con un campo data/ora, più etichette di testo ordinarie. L'esempio seguente scorre le forme di testo di primo livello sulle diapositive regolari. Cambia i campi data/ora in un formato data lunga e li rende italic, preservando la loro altra formattazione. Solo i campi in `ApprovedDate` diventano testo fisso.

Il campione riconosce gli identificatori interni incorporati `datetime` e `datetime1` fino a `datetime13`. Gruppi, tabelle, note, layout e master richiedono l'attraversamento dei propri contenitori di testo e sono fuori dallo scopo di questo esempio.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

Dopo la riapertura, `UpdatedAt` ha tipo `datetime3` e rimane dinamico. `ApprovedDate` non ha campo e contiene `05 April 2030`. Entrambe le porzioni data sono italic, e la loro dimensione carattere originale, impostazione grassetto e colore rimangono intatti. Le etichette di testo ordinarie sono invariate. La verifica legge la prima porzione delle due forme note nel campione fornito.

## **Preservare la formattazione del testo**

Lavora con la porzione esistente quando aggiungi un campo, ne cambi il tipo o lo rimuovi. Queste operazioni mantengono la formattazione di quella porzione. Usa [IPortion.PortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/portionformat/) per modificare solo le proprietà necessarie, come negli esempi per colore o italico.

Evita di ricostruire un intero fotogramma di testo solo per aggiornare un campo: questo può far perdere i confini originali delle porzioni e la loro formattazione individuale. Distinguere inoltre la formattazione impostata esplicitamente da quella ereditata dal paragrafo, layout o tema. Vedi [Text Formatting](/slides/it/net/text-formatting/) per opzioni di formattazione più ampie.

## **Campi e segnaposto intestazione/piè di pagina**

Un campo è parte di una porzione di testo. Un segnaposto è una forma con un ruolo nella presentazione, come un piè di pagina o numero diapositiva. Aggiungere un campo a una casella di testo ordinaria non trasforma quella forma in un segnaposto.

I gestori di intestazione/piè di pagina controllano il testo del segnaposto e la visibilità su diapositive, layout e master, inclusa la propagazione a diapositive dipendenti. Un campo numero in una casella di testo personalizzata può quindi essere utile anche quando non usi il segnaposto numero diapositiva. Al contrario, modificare la visibilità del segnaposto non rimuove un campo da una casella di testo non correlata.

I tipi di intestazione e piè di pagina predefiniti non creano i corrispondenti segnaposti né forniscono il loro contenuto. In particolare, una diapositiva PowerPoint normale non ha un segnaposto intestazione; le intestazioni appartengono a pagine note e a dispense. Non presumere che un campo intestazione o piè di pagina in una forma arbitraria otterrà automaticamente il testo configurato tramite un gestore di segnaposti. Per quel flusso di lavoro, vedi [Presentation Headers and Footers](/slides/it/net/presentation-header-and-footer/).

## **Limitazioni PPTX e PPT**

Verifica sia il tipo di campo sia il testo risultante dopo il salvataggio e la riapertura. Conservare un identificatore non dimostra che un'applicazione possa calcolare o visualizzare il suo valore.

| Formato | Comportamento del campo e limitazioni |
|---|---|
| PPTX | Memorizza gli identificatori di campo interni accanto al testo del campo. Nei controlli round‑trip, i tipi predefiniti e l'identificatore personalizzato usato sopra sono sopravvissuti al salvataggio e alla riapertura. Il tipo personalizzato sconosciuto ha mantenuto il suo testo di fallback; non ha acquisito logica di calcolo automatico. Un'altra applicazione potrebbe trattare gli identificatori non supportati in modo differente. |
| PPT | Usa rappresentazioni legacy dei campi e ha compatibilità più limitata. Nei controlli round‑trip, i campi numero diapositiva e data/ora predefiniti sono sopravvissuti al salvataggio e alla riapertura. Un campo personalizzato in una casella di testo ordinaria è stato riaperto con il suo identificatore ma con `*` come testo; un campo intestazione nello stesso contesto ha prodotto anch'esso `*`. Non fare affidamento su campi personalizzati o contesti di campo non supportati che mantengono il loro testo visibile. |

Per un output portabile e fisso, converti i campi non supportati in testo ordinario e assegna esplicitamente il valore desiderato prima del salvataggio. Questo conserva il testo scelto ma interrompe intenzionalmente gli aggiornamenti automatici. Testa anche l'applicazione di destinazione quando il suo ricalcolo dei campi fa parte del tuo flusso di lavoro.

## **FAQ**

**Come posso capire se un numero o una data visualizzata è un campo?**

Ispeziona [IPortion.Field](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/field/). Un valore non nullo identifica un campo; il solo testo visualizzato non può dirlo.

**La rimozione di un campo rimuove anche il suo testo o la sua formattazione?**

No. [RemoveField](https://reference.aspose.com/slides/it/net/aspose.slides/iportion/removefield/) converte la porzione esistente in testo ordinario. Assegna un valore esplicito in seguito se ti serve una data fissa o un valore di fallback.

**Una stringa interna può definire un nuovo formato data o una formula?**

No. Identifica un tipo di campo. Un identificatore sconosciuto non fornisce un valutatore o un pattern di formato data .NET. Usa un tipo predefinito supportato o formatta il valore come testo ordinario.

**Perché controllare nuovamente una presentazione dopo averla salvata?**

Gli identificatori di campo, il testo calcolato e la formattazione sono cose separate da verificare. La conversione di formato può cambiare il risultato visibile anche quando l'identificatore del campo è ancora presente.