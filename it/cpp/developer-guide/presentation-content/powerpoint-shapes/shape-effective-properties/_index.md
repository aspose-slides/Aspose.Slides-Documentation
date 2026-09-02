---
title: Ottenere le proprietà effettive della forma dalle presentazioni in C++
linktitle: Proprietà effettive
type: docs
weight: 50
url: /it/cpp/shape-effective-properties/
keywords:
- proprietà della forma
- proprietà della camera
- struttura di illuminazione
- forma smussata
- riquadro di testo
- stile del testo
- altezza del carattere
- formato di riempimento
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Impara a usare Aspose.Slides per C++ per distinguere la formattazione locale, ereditata e effettiva delle forme in presentazioni PowerPoint."
---
## **Comprendere le proprietà locali, ereditate e effettive**

La formattazione di PowerPoint può provenire da diversi luoghi. Il valore memorizzato direttamente su un oggetto è il suo **valore locale**. Se quel valore non è impostato, PowerPoint esamina le fonti di formattazione genitore, come il valore predefinito di un paragrafo, uno stile di testo, un layout o una diapositiva master, un tema o i valori predefiniti a livello di presentazione. Questi valori sono **valori ereditati**. Il valore che rimane dopo che l'intera gerarchia è stata risolta è il **valore effettivo** — il valore usato per visualizzare l'oggetto.

Ad esempio, una porzione di testo potrebbe non definire la propria altezza del font. Il suo [font height](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseportionformat/) locale è allora `std::numeric_limits<float>::quiet_NaN()`, che significa "non impostato qui". La porzione può ereditare un'altezza dal suo paragrafo, dallo stile di testo predefinito della presentazione o da un'altra fonte applicabile. Chiamando [GetEffective](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportionformat/) sul formato della porzione si ottiene l'altezza finale risolta.

Utilizzare i due tipi di dati di formattazione per scopi diversi:

- Leggere o modificare un oggetto di formato locale, come [IPortionFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportionformat/), quando è necessario controllare dove un valore è definito.
- Leggere un oggetto di dati effettivi, come [IPortionFormatEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportionformateffectivedata/), quando è necessario il risultato finale visualizzato. I dati effettivi sono di sola lettura.

## **Confrontare valori locali, ereditati e effettivi**

Il seguente esempio completo crea una forma e applica altezze del font a livello di presentazione, paragrafo e porzione. Ogni passaggio stampa i valori definiti a quei livelli e il valore effettivo risultante per la stessa porzione di testo. Dimostra inoltre perché i dati effettivi devono essere letti nuovamente dopo le modifiche alla formattazione.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Definisci valori ereditati a due livelli differenti.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Leggi i dati effettivi dopo le modifiche precedenti.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Un valore locale sulla porzione sovrascrive entrambi i valori ereditati.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Modificare un valore ereditato non sovrascrive un valore locale esistente.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Cancella il valore locale. La porzione ora eredita nuovamente dal paragrafo.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Cancella il valore del paragrafo. Il valore predefinito della presentazione fornisce ora il risultato.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La priorità in questo esempio è la formattazione locale della porzione, poi la formattazione del paragrafo, poi il valore predefinito della presentazione. Altri oggetti possono avere catene di eredità diverse, ma il principio è lo stesso: un valore esplicito più specifico vince, e [GetEffective](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportionformat/) restituisce il risultato finale.

## **Ottenere le proprietà di testo effettive**

La formattazione del testo è suddivisa su diversi oggetti:

- ITextFrameFormat::GetEffective risolve le proprietà del riquadro di testo, come i margini, l'ancoraggio, l'autoadattamento e la direzione verticale del testo.
- ITextStyle::GetEffective risolve la formattazione del paragrafo per ogni livello di stile di testo.
- IParagraphFormat::GetEffective risolve le proprietà del paragrafo, come l'allineamento, l'indentazione e i punti elenco.
- IPortionFormat::GetEffective risolve le proprietà dei caratteri, come altezza del font, tipo di carattere, colore, grassetto e corsivo.

Per il prossimo esempio, `text-formatting.pptx` deve contenere almeno una diapositiva e una [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) con un riquadro di testo non vuoto. L'IAutoShape può trovarsi in qualsiasi posizione della raccolta di forme; il codice cerca un oggetto adatto e lo valida prima dell'uso.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Ottenere le proprietà 3D effettive**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/) restituisce un oggetto [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformateffectivedata/) che raggruppa tutte le impostazioni 3D risolte. I suoi dati di [camera](https://reference.aspose.com/slides/it/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapebeveleffectivedata/) e [bottom bevel](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapebeveleffectivedata/) espongono le rispettive impostazioni effettive. Leggere queste impostazioni correlate insieme facilita la comprensione dell'aspetto 3D finale di una forma.

Per questo esempio, `shape-3d.pptx` deve contenere almeno una forma nella prima diapositiva. Applica impostazioni di camera 3D, illuminazione o smussatura a quella forma se desideri che l'output contenga valori diversi da quelli predefiniti.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Ottenere la formattazione della tabella effettiva**

La formattazione della tabella può provenire dallo stile della tabella e da formati applicati all'intera tabella, a una colonna, a una riga o a una singola cella. In caso di conflitti tra riempimenti definiti esplicitamente, la priorità è cella, riga, colonna e infine tutta la tabella. Il formato effettivo di una cella è il formato finale usato per disegnarla.

Per questo esempio, `table-formatting.pptx` deve contenere almeno una tabella nella prima diapositiva. La tabella deve avere almeno una riga e una colonna. Il codice cerca un [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) invece di presumere che la prima forma sia una tabella.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Se ti serve il colore anziché solo il tipo di riempimento, controlla prima il [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifillformateffectivedata/) effettivo, poi leggi la proprietà che si applica a quel tipo — per esempio, [SolidFillColor](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifillformateffectivedata/) per un riempimento solido.

## **Rileggere i dati effettivi dopo le modifiche**

I dati effettivi descrivono la gerarchia di formattazione al momento in cui è risolta. Chiama `GetEffective` di nuovo dopo aver modificato qualsiasi elemento che può partecipare a tale gerarchia, includendo:

- la formattazione locale dell'oggetto;
- i valori predefiniti del paragrafo o del riquadro di testo;
- uno stile di tabella, una tabella, una colonna, una riga o un formato di cella;
- la formattazione del layout o della diapositiva master;
- i dati del tema o i valori predefiniti a livello di presentazione;
- il layout o il master assegnato a una diapositiva.

Non conservare un oggetto di dati effettivi come istantanea permanente. Aspose.Slides può memorizzare nella cache alcuni dati effettivi internamente, e una successiva chiamata a `GetEffective` può aggiornare tali dati. Se devi confrontare valori prima e dopo una modifica, copia i valori scalari di cui hai bisogno — come altezza del font, colore, allineamento o larghezza della smussatura — nelle tue variabili prima di apportare la modifica.

Per modificare un valore, aggiorna l'oggetto di formato locale appropriato e poi chiama `GetEffective` per verificare il risultato. Gli oggetti di dati effettivi sono di sola lettura.

## **FAQ**

**Come posso capire quale livello ha fornito un valore effettivo?**

I dati effettivi contengono il valore finale, non la sua origine. Ispeziona gli oggetti locali applicabili dal livello più specifico verso l'esterno. Per il testo, ciò può includere la porzione, il paragrafo, il riquadro di testo, il layout, il master, il tema e i valori predefiniti della presentazione. Valori non definiti come `std::numeric_limits<float>::quiet_NaN()` o `nullptr` indicano che la ricerca continua a un altro livello.

**Cosa succede quando nessun livello definisce una proprietà?**

Aspose.Slides risolve il valore predefinito appropriato di PowerPoint o della libreria. Tale valore risolto appare nei dati effettivi anche se nessun oggetto locale lo definisce esplicitamente.

**Perché a volte un valore effettivo è uguale al valore locale?**

Il valore locale ha vinto il calcolo di ereditarietà. Questo è previsto quando la proprietà è impostata esplicitamente sull'oggetto e nessuna regola più specifica lo sovrascrive.

**Quando dovrei usare i dati locali invece dei dati effettivi?**

Usa i dati locali per ispezionare o modificare un livello di formattazione specifico. Usa i dati effettivi quando ti serve l'aspetto finale dopo l'ereditarietà, le regole del tema e gli stili applicabili. Il [complete comparison example](#compare-local-inherited-and-effective-values) dimostra entrambi nello stesso flusso di lavoro.