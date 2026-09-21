---
title: Gestire i campi di testo nelle presentazioni PowerPoint in C++
linktitle: Campi di testo
type: docs
weight: 52
url: /it/cpp/text-fields/
keywords:
- campo di testo
- testo automatico
- numero di diapositiva
- data e ora
- intestazione
- piè di pagina
- porzione di testo
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Crea, ispeziona, modifica e rimuovi i campi di testo nelle presentazioni PowerPoint con Aspose.Slides per C++. Conserva la formattazione e verifica i file PPTX e PPT salvati."
---
## **Panoramica**

Un paragrafo di testo è costituito da porzioni. Una [IPortion](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/) ordinaria contiene testo letterale; una porzione di campo contiene anche un [IField](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifield/) il cui tipo identifica un valore aggiornato automaticamente, ad esempio un numero di diapositiva o una data. Due porzioni possono visualizzare gli stessi caratteri mentre solo una contiene un campo.

Usa [IPortion::get_Field](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/get_field/) per distinguerle: restituisce `nullptr` per testo ordinario. [IPortion::AddField](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/addfield/) converte una porzione esistente in un campo. Tieni un’etichetta e il suo valore dinamico in porzioni separate in modo che la conversione del valore non sostituisca anche l’etichetta.

Questa guida tratta i campi all’interno del testo, la loro formattazione e il salvataggio in PPTX e PPT. Per riquadri di testo e paragrafi, vedi [Manage Text](/slides/it/cpp/manage-text/).

## **Crea un campo numero di diapositiva**

L’esempio seguente crea una casella di testo contenente un’etichetta letterale `Slide ` seguita da un numero aggiornato automaticamente. Imposta la dimensione, lo spessore e il colore del numero prima di aggiungere il campo, quindi riapre la presentazione salvata e controlla il tipo di campo, il testo e la formattazione. Non è richiesto alcun file di input.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

La nuova presentazione inizia con il numero di diapositiva 1, quindi il testo previsto è `Slide 1`, e entrambi i controlli dovrebbero stampare `True`. Il numero rimane un campo dopo la riapertura; non è un letterale `1`. Il cast e gli indici nella verifica si riferiscono alla forma e alle porzioni create da questo esempio.

## **Scegli un tipo di campo**

[FieldType](https://reference.aspose.com/slides/it/cpp/aspose.slides/fieldtype/) implementa [IFieldType](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifieldtype/) e fornisce i seguenti valori predefiniti. Passa il valore appropriato a [AddField](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/addfield/).

| Accessor | Scopo |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/it/cpp/aspose.slides/fieldtype/get_slidenumber/) | Il numero di diapositiva corrente. |
| [get_DateTime](https://reference.aspose.com/slides/it/cpp/aspose.slides/fieldtype/get_datetime/) | Data/ora nel formato predefinito dell’applicazione di rendering. |
| [get_DateTime1](https://reference.aspose.com/slides/it/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/it/cpp/aspose.slides/fieldtype/get_datetime9/) | Formati di data predefiniti o combinati data/ora. |
| [get_DateTime10](https://reference.aspose.com/slides/it/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/it/cpp/aspose.slides/fieldtype/get_datetime13/) | Formati di ora predefiniti, con opzioni per i secondi e un orologio a 12 ore. |
| [get_Header](https://reference.aspose.com/slides/it/cpp/aspose.slides/fieldtype/get_header/) | Un campo intestazione; vedere le limitazioni di segnaposto e formato di seguito. |
| [get_Footer](https://reference.aspose.com/slides/it/cpp/aspose.slides/fieldtype/get_footer/) | Un campo piè di pagina. |

Ad esempio, [get_DateTime3](https://reference.aspose.com/slides/it/cpp/aspose.slides/fieldtype/get_datetime3/) fornisce giorno, nome completo del mese e anno in inglese. Si tratta di formati di campo predefiniti, non di stringhe di formattazione data arbitrarie. La lingua della porzione, impostata con [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/set_languageid/), e l’applicazione che elabora la presentazione possono influenzare il risultato visualizzato.

## **Crea un campo da una stringa interna**

La sovraccarico di stringa di [AddField](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/addfield/) accetta un identificatore di campo interno. Usalo quando devi preservare un identificatore fornito da un’altra applicazione che non dispone di un valore predefinito. Puoi anche costruire un [FieldType](https://reference.aspose.com/slides/it/cpp/aspose.slides/fieldtype/fieldtype/) a partire dall’identificatore. [IFieldType::get_InternalString](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifieldtype/get_internalstring/) espone quell’identificatore per l’ispezione.

Questo esempio memorizza un campo specifico dell’applicazione `custom-report-id` con il testo di fallback `Report-042`. Non è richiesto alcun file di input. L’identificatore non registra alcun calcolo: Aspose.Slides non genera ID report per un tipo sconosciuto. L’applicazione che comprende questo identificatore deve fornire il suo significato e aggiornare il valore.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

Dopo questo round‑trip PPTX, il tipo previsto è `custom-report-id` e il testo previsto è `Report-042`. Passare una stringa come `yyyy-MM-dd` nominerebbe un tipo di campo; non configurerebbe un formato data personalizzato. Per una data fissa in un formato arbitrario, usa testo ordinario.

## **Ispeziona, modifica e rimuovi campi data/ora**

Leggi un tipo di campo esistente tramite [IField::get_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifield/get_type/) e modificalo tramite [IField::set_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifield/set_type/). Verifica che il campo esista prima di accedere al suo tipo. Per interrompere gli aggiornamenti automatici, chiama [IPortion::RemoveField](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/removefield/). Questo conserva la porzione e il suo testo corrente rimuovendo l’associazione al campo. Se ti serve un valore fisso specifico, assegna quel testo dopo aver rimosso il campo.

Per l’impostazione API associata all’elaborazione dei campi data/ora, vedi [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/set_currentdatetime/). L’esempio sotto usa una data di approvazione esplicita quando converte un campo in testo ordinario.

Scarica [sample.pptx](sample.pptx) e posizionalo nella directory di lavoro. Contiene due forme di testo con nome, `UpdatedAt` e `ApprovedDate`, ciascuna con un campo data/ora, più etichette di testo ordinario. L’esempio seguente scorre le forme di testo di livello superiore sulle diapositive regolari. Cambia i campi data/ora in un formato data lunga e li rende inclinati, preservando le altre formattazioni. Solo i campi in `ApprovedDate` diventano testo fisso.

Il campione riconosce gli identificatori interni incorporati `datetime` e `datetime1` fino a `datetime13`. Gruppi, tabelle, note, layout e master richiedono l’attraversamento dei propri contenitori di testo e sono fuori dallo scopo di questo esempio.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

Dopo la riapertura, `UpdatedAt` dovrebbe avere tipo `datetime3` e rimanere dinamico. `ApprovedDate` non dovrebbe avere alcun campo e contenere `05 April 2030`. Entrambe le porzioni data sono inclinate e la dimensione originale del carattere, l’impostazione di grassetto e il colore rimangono intatti. Le etichette di testo ordinario non sono cambiate. La verifica legge la prima porzione delle due forme note nel campione fornito.

## **Preserva la formattazione del testo**

Lavora sulla porzione esistente quando aggiungi un campo, ne cambi il tipo o lo rimuovi. Queste operazioni mantengono la formattazione di quella porzione. Usa [IPortion::get_PortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/get_portionformat/) per modificare solo le proprietà necessarie, come mostrano gli esempi per colore o corsivo.

Evita di ricostruire un intero riquadro di testo solo per aggiornare un campo: farlo può perdere i confini originali delle porzioni e la loro formattazione individuale. Distinguere anche la formattazione impostata esplicitamente da quella ereditata dal paragrafo, layout o tema. Vedi [Text Formatting](/slides/it/cpp/text-formatting/) per opzioni di formattazione più ampie.

## **Campi e segnaposti intestazione/piè di pagina**

Un campo è parte di una porzione di testo. Un segnaposto è una forma con un ruolo nella presentazione, come un piè di pagina o un numero di diapositiva. Aggiungere un campo a una casella di testo ordinaria non trasforma quella forma in un segnaposto.

I gestori di intestazione/piè di pagina controllano il testo del segnaposto e la visibilità su diapositive, layout e master, inclusa la propagazione alle diapositive dipendenti. Un campo numerico in una casella di testo personalizzata può quindi essere utile anche quando non si utilizza il segnaposto del numero di diapositiva. Al contrario, cambiare la visibilità del segnaposto non rimuove un campo da una casella di testo non correlata.

I tipi di intestazione e piè di pagina predefiniti non creano i corrispondenti segnaposti né forniscono il loro contenuto. In particolare, una diapositiva PowerPoint normale non ha un segnaposto intestazione; le intestazioni appartengono alle pagine delle note e ai fogli illustrativi. Non supporre che un campo intestazione o piè di pagina in una forma arbitraria ottenga automaticamente il testo configurato tramite un gestore di segnaposto. Per quel flusso di lavoro, vedi [Presentation Headers and Footers](/slides/it/cpp/presentation-header-and-footer/).

## **Limitazioni PPTX e PPT**

Verifica sia il tipo di campo sia il testo risultante dopo il salvataggio e la riapertura. Conservare un identificatore non dimostra che un’applicazione possa calcolare o visualizzare il suo valore.

| Formato | Comportamento del campo e limitazioni |
|---|---|
| PPTX | Memorizza gli identificatori di campo interni accanto al testo del campo. Usa gli esempi sopra per controllare i tipi predefiniti e gli identificatori personalizzati dopo il salvataggio e la riapertura. Un tipo personalizzato sconosciuto non acquisisce una logica di calcolo automatica. Un’altra applicazione può trattare gli identificatori non supportati in modo diverso. |
| PPT | Utilizza rappresentazioni di campo legacy e ha una compatibilità più limitata. I campi numero di diapositiva e data/ora predefiniti hanno rappresentazioni legacy. Campi personalizzati non supportati o campi intestazione in una casella di testo ordinaria possono produrre `*` come loro testo. Non fare affidamento su campi personalizzati o contesti di campo non supportati per mantenere il loro testo visibile. |

Per output portabile e fisso, converti i campi non supportati in testo ordinario e assegna esplicitamente il valore desiderato prima del salvataggio. Questo preserva il testo scelto ma interrompe intenzionalmente gli aggiornamenti automatici. Testa anche l’applicazione di destinazione quando il suo ricalcolo dei campi fa parte del tuo flusso di lavoro.

## **FAQ**

**Come posso capire se un numero o una data visualizzata è un campo?**

Ispeziona [IPortion::get_Field](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/get_field/). Un valore non nullo identifica un campo; il solo testo visualizzato non può dirlo.

**La rimozione di un campo ne rimuove anche il testo o la formattazione?**

No. [RemoveField](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportion/removefield/) converte la porzione esistente in testo ordinario. Assegna un valore esplicito dopo se ti serve una data congelata o un valore di fallback.

**Una stringa interna può definire un nuovo formato data o una formula?**

No. Identifica un tipo di campo. Un identificatore sconosciuto non fornisce un valutatore né un modello di formattazione data. Usa un tipo predefinito supportato o formatta il valore come testo ordinario.

**Perché controllare nuovamente una presentazione dopo averla salvata?**

Gli identificatori di campo, il testo calcolato e la formattazione sono aspetti separati da verificare. La conversione del formato può cambiare il risultato visibile anche quando l’identificatore del campo è ancora presente.