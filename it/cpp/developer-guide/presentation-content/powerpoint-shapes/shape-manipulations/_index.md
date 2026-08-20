---
title: Gestire le forme della presentazione in C++
linktitle: Manipolazione forme
type: docs
weight: 40
url: /it/cpp/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma della presentazione
- Forma nella diapositiva
- Trova forma
- Clona forma
- Rimuovi forma
- Nascondi forma
- Cambia ordine della forma
- Ottieni ID della forma interop
- Testo alternativo della forma
- Formati layout della forma
- Forma come SVG
- Converti forma in SVG
- Allinea forma
- Ribalta forma
- PowerPoint
- Presentazione
- C++
- Aspose.Slides
description: "Scopri come identificare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e ribaltare le forme della presentazione con Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides for C++ rappresenta le forme su una diapositiva come una [IShapeCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/) ordinata. La collezione è sia il luogo dove trovare e modificare le forme sia la sorgente del loro ordine di sovrapposizione: l’indice `0` è la forma più sullo sfondo, mentre l’ultimo indice è la forma più in primo piano.

Questo articolo segue quel modello. Prima spiega come identificare una forma in modo affidabile, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali coprono la formattazione a livello di layout, l’esportazione SVG, l’allineamento e le impostazioni di ribaltamento. Ogni esempio è indipendente, così puoi utilizzare solo le operazioni richieste dal tuo flusso di lavoro.

## **Identificare e trovare le forme**

- [Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_name/) è utile per i modelli controllati dallo sviluppatore ed è facile da ispezionare nel Pannello di selezione di PowerPoint. I nomi possono essere modificati e non è garantita l’unicità, quindi stabilisci una convenzione di denominazione se il codice dipende da essi.
- [AlternativeText](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_alternativetext/) è utile quando una descrizione di accessibilità o un tag fornito dall'autore identifica già la forma. È visibile agli utenti, può essere localizzato o riscritto per l'accessibilità e non è garantita l’unicità. Non riutilizzare silenziosamente testi di accessibilità significativi come chiave di database.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_officeinteropshapeid/) è un identificatore di sola lettura che è univoco all’interno di una diapositiva e corrisponde all'ID della forma usato dall'interoperabilità di PowerPoint. Usalo quando integri con PowerPoint o quando hai bisogno di un riferimento inequivocabile durante la vita di una forma. Una forma clonata o ricreata è una forma diversa e riceve un proprio ID.

La proprietà correlata [UniqueId](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_uniqueid/) ha ambito di presentazione, ma è destinata ai componenti aggiuntivi e può essere riassegnata. Non dovrebbe essere considerata una chiave esterna permanente. Se un’identità a lungo termine è essenziale, conserva la mappatura nei dati dell’applicazione e verifica che la forma prevista esista ancora.

L’esempio seguente ricerca per `Name` e restituisce l’ID interop a livello di diapositiva. Quando il modello non contiene la forma prevista, il codice restituisce quel risultato invece di continuare con l’oggetto errato.

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

Quando un’operazione è specifica per un tipo di forma, verifica l’interfaccia prima di usare membri specifici del tipo. Questo esempio aggiorna il testo e il testo alternativo solo se l’oggetto nominato è un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/).

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

## **Modificare la collezione di forme**

I metodi add, clone, remove e reorder operano sulla collezione immediatamente. Se un’operazione modifica il numero o l’ordine delle forme, non continuare a fare affidamento sugli indici catturati prima di quell’operazione.

### **Clonare una forma**

[AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addclone/) crea una copia indipendente e la aggiunge alla collezione di destinazione. [InsertClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/insertclone/) crea anch'essa una copia ma la posiziona a un indice di ordine z specificato. Le versioni che accettano coordinate spostano la copia senza cambiare le dimensioni; le versioni con larghezza e altezza possono ridimensionarla.

L’esempio crea una diapositiva di destinazione, clona un rettangolo con etichetta in primo piano e inserisce un secondo clone sullo sfondo. Le modifiche a ciascun clone non alterano la forma di origine.

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

La clonazione copia il contenuto e la formattazione della forma, inclusi nome e testo alternativo. Assegna nuovi identificatori logici al clone quando tali valori devono essere unici. Le risorse usate da forme complesse sono gestite dalla presentazione, ma un clone rimane un nuovo elemento della collezione con una nuova identità di forma.

### **Rimuovere le forme**

[Remove](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/remove/) elimina un oggetto forma specifico dalla sua collezione. Quando si rimuovono più corrispondenze durante un’iterazione indicizzata, scorrere dall’ultimo verso il primo in modo che ogni indice rimanente rimanga valido.

Questo esempio rimuove ogni forma con un nome designato. Legge la forma indicizzata corrente, non un elemento fisso della collezione, e non effettua cast inutili della forma.

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

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili rispetto agli indici salvati. Considera anche connettori, animazioni e altre funzionalità della presentazione che possono fare riferimento all’oggetto rimosso; rimuovere una forma visibile può modificare più del semplice aspetto della diapositiva.

### **Nascondere una forma**

Impostare [Hidden](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/set_hidden/) su `true` mantiene la forma nella collezione ma ne impedisce la comparsa nella presentazione normale. Il suo indice, formattazione e contenuto rimangono disponibili al codice, quindi nascondere è appropriato per elementi opzionali che possono essere ripristinati in seguito.

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

Nascondere non è cancellazione né sicurezza. L’oggetto può ancora essere scoperto e resa visibile da un utente o dal codice, e rimane parte del file della presentazione.

### **Modificare l’ordine Z**

Le forme sovrapposte sono disegnate secondo l’ordine della collezione. [Reorder](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/reorder/) sposta una forma esistente a un indice di destinazione senza clonarla. L’indice `0` è lo sfondo; `Count - 1` è il primo piano.

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

Il rettangolo viene creato per primo e inizialmente è dietro l’ellisse. Spostarlo all’indice finale lo porta in primo piano. Finalizza l’ordine Z dopo aver aggiunto o clonato tutte le forme correlate, poiché tali operazioni aggiungono o inseriscono nuovi elementi nella collezione e possono alterare lo stack previsto.

## **Ispezionare le forme nelle diapositive layout**

Le diapositive normali, le diapositive layout e le diapositive master hanno collezioni di forme separate. Una forma in una collezione layout non è lo stesso oggetto di una forma posizionata in modo simile su una diapositiva normale. Ispeziona le forme layout quando devi comprendere o modificare la formattazione fornita da un layout.

L’esempio seguente legge il [FillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_fillformat/) e il [LineFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_lineformat/) di ogni forma layout senza presumere che ogni forma sia un `AutoShape`.

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

Modificare un layout può influenzare più diapositive che lo usano. Prima di cambiare una forma del layout, determina se una diapositiva normale eredita l’oggetto o contiene una sovrascrittura locale, e testa ogni diapositiva che utilizza quel layout.

## **Esportare una forma in SVG**

[WriteAsSvg](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/writeassvg/) scrive il contenuto renderizzato di una forma in uno stream. Il risultato contiene la forma, non l’intero sfondo della diapositiva o le forme vicine.

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

Mantieni aperta la presentazione durante il rendering. L’output dipende dalla formattazione della forma e dalle risorse come font e immagini. Se ti serve l’intera composizione, esporta la diapositiva invece di una singola forma. Il chiamante possiede lo stream e deve chiuderlo o smaltirlo.

## **Allineare le forme**

Le overload di [SlideUtil::AlignShapes](https://reference.aspose.com/slides/it/cpp/aspose.slides.util/slideutil/alignshapes/) allineano tutte le forme o gli indici di collezione selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `alignToSlide` su `true` per usare i bordi della diapositiva; impostalo su `false` per allineare le forme selezionate rispetto a ciascuna altra.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I riferimenti alle forme restituiti sono convertiti nei loro indici correnti immediatamente prima dell’allineamento.

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

L’allineamento cambia le posizioni, non l’ordine Z. L’allineamento relativo richiede normalmente almeno due forme, mentre la distribuzione orizzontale o verticale necessita di un numero sufficiente di forme per definire la spaziatura. Ricalcola gli indici se modifichi la collezione prima di chiamare il metodo.

## **Ribaltare una forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapeframe/) memorizza posizione, dimensione, impostazioni di ribaltamento orizzontale e verticale e rotazione. I suoi valori `FlipH` e `FlipV` usano [NullableBool](https://reference.aspose.com/slides/it/cpp/aspose.slides/nullablebool/): `True` abilita il ribaltamento, `False` lo disabilita, e `NotDefined` conserva lo stato non specificato/predefinito.

La presentazione di input mostrata di seguito contiene una forma non ribaltata.

![La forma prima del ribaltamento](shape_to_be_flipped.png)

L’esempio conserva tutti gli altri valori del frame e sostituisce solo le due impostazioni di ribaltamento. Questo è importante perché assegnare un nuovo [Frame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/set_frame/) sostituisce l’intero frame.

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

La forma salvata è specchiata orizzontalmente e verticalmente mantenendo posizione, dimensione e rotazione.

![La forma dopo il ribaltamento](flipped_shape.png)

## **FAQ**

**Devo usare un indice di collezione come identificatore di una forma?**

Solo per elaborazioni di breve durata quando la collezione non cambierà prima dell'uso dell'indice. Preferisci una convenzione validata di `Name` o `AlternativeText` per i modelli creati, o `OfficeInteropShapeId` per lavori interop a livello di diapositiva.

**Nascondere una forma la rimuove dall’ordine Z?**

No. Una forma nascosta rimane nella collezione allo stesso indice. Può essere trovata, riordinata, modificata o resa nuovamente visibile.

**Perché una forma clonata è apparsa davanti a un'altra forma?**

`AddClone` aggiunge il clone alla fine della collezione, che è il fronte dell’ordine Z. Usa `InsertClone` per scegliere l’indice iniziale o `Reorder` dopo aver aggiunto tutte le forme.