---
title: Gestire le forme della presentazione in C++
linktitle: Manipolazione forme
type: docs
weight: 40
url: /it/cpp/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma della presentazione
- Forma su diapositiva
- Trova forma
- Clona forma
- Rimuovi forma
- Nascondi forma
- Modifica ordine forme
- Ottieni ID forma interop
- Testo alternativo forma
- Punto di regolazione forma
- Regolazione forma predefinita
- Geometria forma
- Formati layout forma
- Forma come SVG
- Forma in SVG
- Allinea forma
- Ribalta forma
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come identificare, regolare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e ribaltare le forme della presentazione con Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides per C++ rappresenta le forme su una diapositiva come una [IShapeCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/) ordinata. La collezione è sia il luogo in cui trovare e modificare le forme sia la sorgente del loro ordine di sovrapposizione: l'indice `0` è la forma più arretrata, mentre l'ultimo indice è la forma più in avanti.

Questo articolo segue quel modello. Prima spiega come identificare una forma in modo affidabile e modificare i punti di regolazione predefiniti, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali coprono la formattazione a livello di layout, l'esportazione SVG, l'allineamento e le impostazioni di ribaltamento. Ogni esempio è indipendente, così puoi utilizzare solo le operazioni necessarie al tuo flusso di lavoro.

## **Identificare e Trovare le Forme**

Gli indici della collezione sono comodi durante l'elaborazione di un file noto, ma non sono identificatori stabili. Aggiungere, rimuovere o riordinare una forma può cambiarne l'indice. Scegli un identificatore in base a come la presentazione è creata e mantenuta:

- [Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_name/) è utile per modelli controllati dallo sviluppatore ed è facile da ispezionare nel Pannello di selezione di PowerPoint. I nomi possono essere modificati e non sono garantiti univoci, quindi stabilisci una convenzione di denominazione se il codice dipende da essi.
- [AlternativeText](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_alternativetext/) è utile quando una descrizione di accessibilità o un tag fornito dall'autore identifica già la forma. È visibile agli utenti, può essere localizzato o riscritto per l'accessibilità, e non è garantito univoco. Non riutilizzare silenziosamente testo di accessibilità significativo come chiave di database.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_officeinteropshapeid/) è un identificatore di sola lettura che è unico all'interno di una diapositiva e corrisponde all'ID della forma usato dall'interoperabilità di PowerPoint. Usalo quando integri con PowerPoint o quando ti serve un riferimento non ambiguo per tutta la durata della forma. Una forma clonata o ricreata è una forma diversa e riceve un proprio ID.

La proprietà correlata [UniqueId](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_uniqueid/) ha ambito di presentazione, ma è destinata ai componenti aggiuntivi e può essere riassegnata. Non dovrebbe essere trattata come chiave esterna permanente. Se l'identità a lungo termine è essenziale, conserva la mappatura nei dati dell'applicazione e verifica che la forma prevista esista ancora.

L'esempio seguente cerca per `Name` e restituisce l'ID interop a livello di diapositiva. Quando il modello non contiene la forma prevista, il codice segnala quel risultato invece di continuare con l'oggetto errato.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

Quando un'operazione è specifica a un tipo di forma, controlla l'interfaccia prima di usare membri specifici del tipo. Questo esempio aggiorna il testo e il testo alternativo solo se l'oggetto denominato è un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Identificare e Modificare le Regolazioni Predefinite delle Forme**

Le forme di geometria predefinita possono esporre punti di regolazione che controllano caratteristiche come la dimensione dell'angolo, le proporzioni della freccia o gli angoli di arco. Accedi a loro tramite la collezione di sola lettura [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/it/cpp/aspose.slides/igeometryshape/get_adjustments/). La collezione stessa è fornita dalla forma, ma ogni [IAdjustValue](https://reference.aspose.com/slides/it/cpp/aspose.slides/iadjustvalue/) contiene un valore che può essere modificato.

Non fare affidamento solo su un indice di collezione fisso. Scorri le regolazioni e ispeziona la proprietà di sola lettura [IAdjustValue::get_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/iadjustvalue/get_type/), il cui valore [ShapeAdjustmentType](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapeadjustmenttype/) descrive cosa controlla la regolazione. La proprietà di sola lettura [IAdjustValue::get_Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/iadjustvalue/get_name/) fornisce informazioni di identificazione aggiuntive ed è particolarmente utile quando un preset contiene più di una regolazione con lo stesso tipo semantico.

Usa la proprietà valore che corrisponde al significato della regolazione:

| Tipo di regolazione | Scopo | Valore da modificare |
|---|---|---|
| `CornerSize` | Dimensione degli angoli arrotondati | [RawValue](https://reference.aspose.com/slides/it/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Spessore della coda della freccia | `RawValue` |
| `ArrowheadLength` | Lunghezza della punta della freccia | `RawValue` |
| `ArrowheadWidth` | Larghezza della punta della freccia | `RawValue` |
| `StartAngle` | Angolo di inizio di una torta o di un arco | [AngleValue](https://reference.aspose.com/slides/it/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Angolo finale di una torta o di un arco | `AngleValue` |

`Type` e `Name` non possono essere assegnati. `RawValue` è un intero di lettura/scrittura nelle unità geometriche native del preset, mentre `AngleValue` è un angolo di lettura/scrittura in gradi. Il numero, l'ordine, il significato e l'intervallo valido delle regolazioni dipendono dal preset [ShapeType](https://reference.aspose.com/slides/it/cpp/aspose.slides/igeometryshape/get_shapetype/). Un valore valido per un preset può essere non valido o avere un effetto diverso per un altro.

Quando `Type` è `ShapeAdjustmentType::Custom`, l'API non riconosce un significato semantico standard. Ispeziona `Name`, il tipo di preset e il valore esistente, e lascia la regolazione invariata a meno che non si conosca il significato e l'intervallo previsto. Anche per i tipi riconosciuti, verifica se lo stesso tipo compare più volte prima di scegliere un valore. L'articolo [Connector](/slides/it/cpp/connector/) mostra questa situazione con le regolazioni di curvatura dei connettori.

L'esempio completo seguente crea versioni predefinite e modificate di tre forme predefinite. Scorre ogni regolazione, riporta il suo `Name` e `Type`, cambia i valori legati alle dimensioni tramite `RawValue`, cambia gli angoli tramite `AngleValue` e salva il risultato. La colonna sinistra conserva la geometria predefinita; la colonna destra mostra il rettangolo arrotondato, la freccia a quattro vie e la torta regolati.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Aggiunge intestazioni per le colonne delle forme predefinite e regolate.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Controllare il tipo semantico prima di modificare un valore rende il codice esplicito riguardo all'intento ed evita di assumere che un indice di collezione specifico abbia lo stesso significato in forme predefinite diverse.

## **Modificare la Collezione di Forme**

I metodi di aggiunta, clonazione, rimozione e riordino operano immediatamente sulla collezione. Se un'operazione cambia il numero o l'ordine delle forme, non continuare a fare affidamento sugli indici catturati prima di quell'operazione.

### **Clonare una Forma**

[AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addclone/) crea una copia indipendente e la aggiunge alla collezione di destinazione. [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/insertclone/) crea anch'essa una copia ma la posiziona a un indice di ordine Z specificato. Le sovraccariche che accettano coordinate spostano la clonazione senza cambiare le dimensioni; le sovraccariche con larghezza e altezza possono ridimensionarla.

L'esempio crea una diapositiva di destinazione, clona un rettangolo etichettato in primo piano e inserisce un secondo clone in fondo. Le modifiche a ciascun clone non modificano la forma di origine.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La clonazione copia il contenuto e la formattazione della forma, inclusi nome e testo alternativo. Assegna nuovi identificatori logici al clone quando tali valori devono essere univoci. Le risorse usate dalle forme complesse sono gestite dalla presentazione, ma un clone rimane un nuovo elemento della collezione con una nuova identità di forma.

### **Rimuovere Forme**

[Remove](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/remove/) elimina un oggetto forma specifico dalla sua collezione. Quando rimuovi più corrispondenze durante un'iterazione indicizzata, attraversa la collezione dal fondo così che ogni indice rimanente rimanga valido.

Questo esempio rimuove ogni forma con un nome designato. Legge la forma indicizzata corrente, non un elemento fisso della collezione, e non effettua cast inutili.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili rispetto agli indici salvati. Considera anche connettori, animazioni e altre funzionalità della presentazione che potrebbero fare riferimento all'oggetto rimosso; rimuovere una forma visibile può cambiare più che l'aspetto della diapositiva.

### **Nascondere una Forma**

Impostare [Hidden](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/set_hidden/) a `true` mantiene la forma nella collezione ma impedisce che appaia nella presentazione normale. Il suo indice, la formattazione e il contenuto rimangono disponibili al codice, quindi nascondere è appropriato per elementi opzionali che possono essere ripristinati in seguito.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Nascondere non è cancellazione né sicurezza. L'oggetto può ancora essere scoperto e reso visibile da un utente o da codice, e rimane parte del file di presentazione.

### **Modificare l'Ordine Z**

Le forme sovrapposte sono disegnate nell'ordine della collezione. [Reorder](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/reorder/) sposta una forma esistente a un indice di destinazione senza clonarla. L'indice `0` è quello più arretrato; `Count - 1` è quello più avanzato.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il rettangolo viene creato per primo e inizialmente si trova dietro l'ellisse. Spostarlo all'indice finale lo porta in primo piano. Finalizza l'ordine Z dopo aver aggiunto o clonato tutte le forme correlate, perché tali operazioni aggiungono o inseriscono nuovi elementi nella collezione e possono alterare lo stack previsto.

## **Ispezionare le Forme sui Layout**

Le diapositive normali, i layout e i master hanno collezioni di forme separate. Una forma nella collezione di un layout non è lo stesso oggetto di una forma posizionata in modo simile su una diapositiva normale. Ispeziona le forme del layout quando devi comprendere o modificare la formattazione fornita da un layout.

L'esempio seguente legge il [FillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_fillformat/) e il [LineFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_lineformat/) di ogni forma del layout senza presumere che ogni forma sia un `AutoShape`.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Modificare un layout può influire su più diapositive che lo utilizzano. Prima di cambiare una forma di layout, determina se una diapositiva normale eredita l'oggetto o contiene una sovrascrittura locale, e testa ogni diapositiva che usa quel layout.

## **Esportare una Forma in SVG**

[WriteAsSvg](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/writeassvg/) scrive il contenuto renderizzato di una sola forma su uno stream. Il risultato contiene la forma, non l'intero sfondo della diapositiva o le forme vicine.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Mantieni la presentazione aperta durante il rendering. L'output dipende dalla formattazione della forma e da risorse come caratteri e immagini. Se ti serve l'intera composizione, esporta la diapositiva anziché una singola forma. Chi chiama possiede lo stream e deve chiuderlo o rilasciarlo.

## **Allineare le Forme**

Le sovraccariche di [SlideUtil::AlignShapes](https://reference.aspose.com/slides/it/cpp/aspose.slides.util/slideutil/alignshapes/) allineano tutte le forme o gli indici di collezione selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `alignToSlide` a `true` per usare i bordi della diapositiva; impostalo a `false` per allineare le forme selezionate tra loro.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I riferimenti alle forme restituiti vengono convertiti nei loro indici correnti immediatamente prima dell'allineamento.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L'allineamento modifica le posizioni, non l'ordine Z. L'allineamento relativo normalmente richiede almeno due forme, mentre la distribuzione orizzontale o verticale richiede un numero sufficiente di forme per definire la spaziatura. Ricalcola gli indici se modifichi la collezione prima di chiamare il metodo.

## **Ribaltare una Forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapeframe/) memorizza posizione, dimensioni, impostazioni di ribaltamento orizzontale e verticale e rotazione. I valori `FlipH` e `FlipV` usano [NullableBool](https://reference.aspose.com/slides/it/cpp/aspose.slides/nullablebool/): `True` attiva il ribaltamento, `False` lo disattiva, e `NotDefined` conserva lo stato non specificato/predefinito.

La presentazione di input di seguito contiene una forma non ribaltata.

![The shape before flipping](shape_to_be_flipped.png)

L'esempio conserva tutti gli altri valori del frame e sostituisce solo le due impostazioni di ribaltamento. Questo è importante perché assegnare un nuovo [Frame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/set_frame/) sostituisce l'intero frame.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La forma salvata è rispecchiata orizzontalmente e verticalmente mantenendo posizione, dimensioni e rotazione.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usare un indice di collezione come identificatore di una forma?**

Solo per elaborazioni di breve durata quando la collezione non cambierà prima dell'uso dell'indice. Preferisci una convenzione con `Name` o `AlternativeText` per modelli creati, o `OfficeInteropShapeId` per lavori di interop a livello di diapositiva.

**Nascondere una forma la rimuove dall'ordine Z?**

No. Una forma nascosta rimane nella collezione allo stesso indice. Può essere trovata, riordinata, modificata o resa nuovamente visibile.

**Perché una forma clonata è apparsa davanti a un'altra forma?**

`AddClone` aggiunge il clone alla fine della collezione, che corrisponde al fronte dell'ordine Z. Usa `InsertClone` per scegliere l'indice iniziale o `Reorder` dopo aver aggiunto tutte le forme.

**Posso usare un indice fisso per identificare una regolazione di forma predefinita?**

Solo dopo aver convalidato il preset esatto e la disposizione della collezione. Preferisci scorrere `IGeometryShape::get_Adjustments` e verificare `IAdjustValue::get_Type`; usa `IAdjustValue::get_Name` come informazione aggiuntiva quando lo stesso tipo semantico appare più di una volta.