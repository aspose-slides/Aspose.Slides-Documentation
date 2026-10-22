---
title: Personalizza le forme di presentazione in C++
linktitle: Forma personalizzata
type: docs
weight: 20
url: /it/cpp/custom-shape/
keywords:
- forma personalizzata
- aggiungi forma
- crea forma
- modifica forma
- geometria della forma
- percorso geometrico
- punti del percorso
- punti di modifica
- aggiungi punto
- rimuovi punto
- operazione di modifica
- angolo curvo
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Crea e personalizza forme in presentazioni PowerPoint con Aspose.Slides per C++: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme delle presentazioni in Aspose.Slides modificando la geometria delle forme attraverso i punti di modifica e i percorsi geometrici. Mostra come lavorare con [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) e [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) per modificare le forme esistenti, eseguire operazioni di modifica di base del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

Dimostra inoltre come creare forme personalizzate e composite, costruire forme con angoli curvi e determinare se la geometria di una forma è chiusa.

## **Modifica una forma tramite i punti di modifica**

In PowerPoint, è possibile utilizzare **Edit Points** per modificare un quadrato:

* Muovere un angolo verso l'interno o verso l'esterno.
* Regolare la curvatura in un punto.
* Aggiungere nuovi punti.

Modificando i punti è possibile modificare il contorno di una forma o utilizzare una forma esistente come base per una nuova.

## **Suggerimenti per la modifica delle forme**

![overview_image](custom_shape_0.png)

Durante la modifica delle forme di PowerPoint, tenere presente questi concetti:

* Una forma (o il suo percorso) può essere chiusa o aperta.
* Il percorso di una forma è composto da punti di ancoraggio collegati da segmenti.
* Un segmento può essere dritto o curvo. I punti di ancoraggio e le maniglie di controllo determinano la sua forma.
* I punti di ancoraggio esistono come punti angolo, punti dritti o punti lisci:
  * In un punto angolo, i segmenti adiacenti possono incontrarsi con un angolo.
  * In un punto liscio, le due maniglie di controllo sono allineate e a pari distanza dal punto di ancoraggio.
  * In un punto dritto, le due maniglie di controllo sono allineate ma possono trovarsi a distanze diverse dal punto di ancoraggio.
* Spostare i punti di ancoraggio o regolare le loro maniglie modifica il contorno della forma.

Per modificare le forme di PowerPoint tramite i punti di modifica, **Aspose.Slides** fornisce la classe [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) e l'interfaccia [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Un'istanza di [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) rappresenta un percorso geometrico dell'oggetto [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Per recuperare il [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) dall'istanza [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), è possibile utilizzare il metodo [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Per impostare il [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) per una forma, è possibile utilizzare questi metodi: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) per forme con un singolo percorso e [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) per forme con percorsi multipli.
* Per aggiungere segmenti, è possibile utilizzare i metodi sotto [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* Utilizzando i metodi [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) e [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/), è possibile impostare l'aspetto di un percorso geometrico.
* Utilizzando il metodo [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/), è possibile recuperare il percorso geometrico di un [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) come un array di segmenti di percorso.

## **Operazioni di modifica semplici**

Utilizzare i seguenti metodi per modificare un percorso geometrico. Le sovraccariche che accettano un indice inseriscono un segmento in quella posizione basata su zero nell'array dei segmenti del percorso.

| Operazione | Metodo |
| --- | --- |
| Aggiungere o inserire una linea retta. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Aggiungere o inserire una curva cubica Bézier con due punti di controllo e un punto finale. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Aggiungere o inserire una curva quadratica Bézier con un punto di controllo e un punto finale. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Aggiungere un arco ellittico con le dimensioni e gli angoli specificati in gradi. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Chiudere la figura corrente collegando il suo punto finale al punto di partenza. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Impostare il punto di partenza di una figura. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Rimuovere un segmento in un indice basato su zero. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Aggiungere punti personalizzati a una forma**

Questo esempio inserisce due punti in una forma rettangolare utilizzando [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) e applica il percorso modificato con [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Le coordinate sono locali alla forma: entrambi i nuovi punti si trovano al suo centro, a 100 punti dalla sinistra e 50 punti dall'alto. Gli indici dei segmenti 1 e 4 li posizionano sui bordi superiore e inferiore, tirando questi bordi verso l'interno.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Rimuovere punti da una forma**

Questo esempio modifica il contorno di una forma a cuore rimuovendo il segmento all'indice basato su zero 2 con [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Applicare il percorso modificato con [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) aggiorna il contorno della forma.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Creare una forma personalizzata**

Questo esempio costruisce una stella a cinque punte con [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Raggi esterni e interni alternati di 100 e 50 punti definiscono le punte e le rientranze; un passo di 72 gradi distribuisce uniformemente le cinque punte. Il percorso è chiuso con [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) e applicato a una forma rettangolare usando [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), sostituendo il suo contorno.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **Creare una forma personalizzata composita**

Questo esempio definisce due oggetti [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) chiusi per il terzo superiore e inferiore di una forma. Applicare entrambi i percorsi con [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) crea una singola forma composita con uno spazio attraverso il suo terzo centrale.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(0.0f, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **Creare una forma personalizzata con angoli curvi**

Questo esempio combina segmenti dritti con [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) per creare una forma con angoli curvi verso l'interno. Ogni dimensione dell'angolo imposta la larghezza e l'altezza dell'arco in punti, e la sweep di -90 gradi disegna un quarto di ellisse in senso antiorario. Il percorso completato è applicato con [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), e la presentazione viene salvata in formato PPTX.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Scoprire se la geometria di una forma è chiusa**

L'utilità seguente verifica se ogni percorso geometrico non vuoto termina con un segmento di chiusura. Legge [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) e confronta il comando del segmento finale [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) con [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Restituisce false quando non ci sono percorsi non vuoti. Questo controlla il comando finale di ciascun percorso; non ispeziona ogni sottofigura all'interno di un percorso. L'esempio stampa `True` per un rettangolo.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **Estrarre e ispezionare gli elementi della forma**

Utilizzare [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) per ispezionare una forma esistente come elementi contenenti punti di percorso e tipi di punto. Convertire ogni [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) restituito in [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) per leggere gli array restituiti da [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) e [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Questa rappresentazione è utile per l'analisi del contorno o per passare la geometria a strumenti di disegno personalizzati.

L'esempio apre una presentazione, trova la prima forma geometrica direttamente nella prima diapositiva e stampa i suoi segmenti di percorso. Utilizzare una presentazione contenente una forma con segmenti dritti e curvi per vedere entrambi i tipi di output. Non ricerca all'interno dei gruppi.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // Mantieni il tipo di segmento, escludendo i flag.
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // Consuma entrambi i punti di controllo e il punto finale.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Gli array corrispondono per indice: `points[i]` è un punto e `types[i]` ne descrive il ruolo. Il tipo `0` avvia una figura, e il tipo `1` disegna una linea dal punto precedente al punto corrente. Un segmento Bézier cubico inizia dal punto finale precedente e utilizza tre voci consecutive di tipo `3`: due punti di controllo seguiti dal nuovo punto finale. Il ciclo consuma queste tre voci insieme e verifica il punto finale per la chiusura.

I tipi di punto contengono anche flag. Mascherare con `0x07` per identificare il tipo di segmento, e testare `0x80` separatamente per rilevare un sotto-percorso chiuso. Ad esempio, `129` (`0x81`) indica un punto finale di linea che chiude un sotto-percorso, e `131` (`0x83`) indica un punto finale Bézier che ne chiude uno. Confrontare il valore grezzo solo con `1` o `3` ometterebbe questi casi. Altri flag, come dash (`0x10`) e marker (`0x20`), non modificano il tipo base del segmento.

**Coordinate e trasformazioni.** I punti sono misurati in punti (1/72 di pollice), con X che aumenta verso destra e Y che aumenta verso il basso. Per una forma non raggruppata, le coordinate estratte includono già la posizione restituita da [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) e [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) e riflettono la sua larghezza e altezza attuali. Ad esempio, un rettangolo non ruotato a `(100, 200)` con dimensioni `120 × 80` ha i limiti del contorno `(100, 200)`–`(220, 280)`. Non aggiungere nuovamente la posizione della forma. Sottrarre il suo X e Y per ottenere coordinate relative al suo frame non ruotato.

I punti estratti non applicano la rotazione impostata tramite [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) o le capovolgimenti orizzontali e verticali. Per riprodurre il contorno visualizzato, applicare tali trasformazioni attorno al centro della forma. Per le forme raggruppate, considerare anche la mappatura delle coordinate del gruppo e le trasformazioni; non presumere che i punti estratti siano le coordinate finali renderizzate della diapositiva o applicare una traduzione o scala due volte se già riflessa nel frame del figlio.

**Ispezione vs modifica.** Gli array estratti descrivono il contorno; modificarli non aggiorna la forma originale. Scegliere questo approccio quando la tua analisi o il codice di disegno necessita di array di punto/tipo. Usa [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) quando hai bisogno di comandi geometrici nel sistema di coordinate locale della forma o vuoi modificare la sua geometria. Applica i percorsi modificati tramite [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) o [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Convertire GeometryPath in GraphicsPath**

L'attuale API pubblica di Aspose.Slides per C++ non espone conversioni tra percorsi geometrici e percorsi grafici. Per ispezionare un contorno, utilizzare gli elementi della forma come descritto sopra. Per modificare una forma, utilizzare i percorsi geometrici e applicare i percorsi aggiornati alla forma.

## **FAQ**

**Cosa accadrà al riempimento e al contorno dopo aver sostituito la geometria?**

Lo stile rimane sulla forma; solo il contorno cambia. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**

Utilizzare il metodo [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) della forma; la geometria ruota con la forma perché è legata al proprio sistema di coordinate.

**Posso convertire una forma personalizzata in un'immagine per "bloccare" il risultato?**

Sì. Esportare l'area della [diapositiva](/slides/it/cpp/convert-powerpoint-to-png/) richiesta o la [forma](/slides/it/cpp/shape-thumbnails/) stessa in un formato raster; questo semplifica il lavoro successivo con geometrie complesse.