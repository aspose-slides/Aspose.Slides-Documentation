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
description: "Crea e personalizza forme nelle presentazioni PowerPoint con Aspose.Slides per C++: percorsi geometrici, angoli curvi, forme composite."
---
## **Panoramica**

Questo articolo spiega come personalizzare le forme delle presentazioni in Aspose.Slides modificando la geometria della forma tramite punti di modifica e percorsi geometrici. Mostra come utilizzare `GeometryPath` e `IGeometryPath` per modificare forme esistenti, eseguire operazioni di modifica di base del percorso, aggiungere o rimuovere punti e applicare la geometria aggiornata a una forma.

## **Modifica una forma usando i punti di modifica**
Considera un quadrato. In PowerPoint, usando **edit points**, puoi  

* spostare l’angolo del quadrato verso l’interno o l’esterno  
* specificare la curvatura di un angolo o di un punto  
* aggiungere nuovi punti al quadrato  
* manipolare i punti del quadrato, ecc.  

In sostanza, puoi eseguire le operazioni descritte su qualsiasi forma. Usando i punti di modifica, puoi modificare una forma o crearne una nuova a partire da una forma esistente. 

## **Suggerimenti per la modifica delle forme**

![overview_image](custom_shape_0.png)

Prima di iniziare a modificare le forme di PowerPoint tramite i punti di modifica, potresti voler considerare questi aspetti delle forme:

* Una forma (o il suo percorso) può essere chiusa o aperta.  
* Quando una forma è chiusa, non ha un punto di inizio o di fine. Quando una forma è aperta, ha un inizio e una fine.  
* Tutte le forme sono composte da almeno 2 punti di ancoraggio collegati tra loro da linee.  
* Una linea è o dritta o curva. I punti di ancoraggio determinano la natura della linea.  
* I punti di ancoraggio esistono come punti d’angolo, punti dritti o punti lisci:  
  * Un punto d’angolo è un punto in cui 2 linee dritte si uniscono formando un angolo.  
  * Un punto liscio è un punto in cui 2 maniglie esistono su una linea retta e i segmenti della linea si collegano con una curva fluida. In questo caso, tutte le maniglie sono distanziate dal punto di ancoraggio di pari distanza.  
  * Un punto dritto è un punto in cui 2 maniglie esistono su una linea retta e i segmenti della linea si collegano con una curva fluida. In questo caso, le maniglie non devono essere distanziate dal punto di ancoraggio di pari distanza.  
* Spostando o modificando i punti di ancoraggio (che cambiano l’angolo delle linee), è possibile alterare l’aspetto di una forma.  

Per modificare le forme di PowerPoint tramite i punti di modifica, **Aspose.Slides** fornisce la classe [**GeometryPath**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_path) e l’interfaccia [**IGeometryPath**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_geometry_path).  

* Un’istanza di [GeometryPath](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_path) rappresenta il percorso geometrico dell’oggetto [IGeometryShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_geometry_shape).  
* Per recuperare il `GeometryPath` dall’istanza `IGeometryShape`, puoi usare il metodo [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1).  
* Per impostare il `GeometryPath` di una forma, puoi usare questi metodi: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) per *forme solide* e [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) per *forme composite*.  
* Per aggiungere segmenti, puoi usare i metodi sotto [IGeometryPath](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_geometry_path).  
* Usando i metodi [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) e [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7), puoi impostare l’aspetto di un percorso geometrico.  
* Con il metodo [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) puoi recuperare il percorso geometrico di una `GeometryShape` come array di segmenti di percorso.  
* Per accedere ad opzioni aggiuntive di personalizzazione della geometria della forma, puoi convertire [GeometryPath](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_path) in [GraphicsPath](https://reference.aspose.com/slides/it/cpp/class/system.drawing.drawing2_d.graphics_path).  
* Usa i metodi [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) e [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (dalla classe [ShapeUtil](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.util.shape_util)) per convertire [GeometryPath](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_path) in [GraphicsPath](https://reference.aspose.com/slides/it/cpp/class/system.drawing.drawing2_d.graphics_path) e viceversa.  

## **Operazioni di modifica semplici**

Questo codice C++ mostra come  

**Aggiungi una linea** alla fine di un percorso

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Aggiungi una linea** in una posizione specifica su un percorso:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Aggiungi una curva Bezier cubica** alla fine di un percorso:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Aggiungi una curva Bezier cubica** nella posizione specificata su un percorso:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Aggiungi una curva Bezier quadratica** alla fine di un percorso:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Aggiungi una curva Bezier quadratica** nella posizione specificata su un percorso:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Allega un arco dato** a un percorso:

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Chiudi la figura corrente** di un percorso:

``` cpp
void CloseFigure();
```
**Imposta la posizione per il punto successivo**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Rimuovi il segmento di percorso** all’indice indicato:

``` cpp
void RemoveAt(int32_t index);
```

## **Aggiungi punti personalizzati a una forma**
1. Crea un’istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_shape) e imposta il tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Ottieni un’istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_path) dalla forma.  
3. Aggiungi un nuovo punto tra i due punti superiori del percorso.  
4. Aggiungi un nuovo punto tra i due punti inferiori del percorso.  
5. Applica il percorso alla forma.  

Questo codice C++ mostra come aggiungere punti personalizzati a una forma:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Rimuovi punti da una forma**

1. Crea un’istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_shape) e imposta il tipo [ShapeType.Heart](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Ottieni un’istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_path) dalla forma.  
3. Rimuovi il segmento del percorso.  
4. Applica il percorso alla forma.  

Questo codice C++ mostra come rimuovere punti da una forma:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Crea una forma personalizzata**

1. Calcola i punti per la forma.  
2. Crea un’istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_path).  
3. Riempie il percorso con i punti.  
4. Crea un’istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_shape).  
5. Applica il percorso alla forma.  

Questo codice C++ mostra come creare una forma personalizzata:

``` cpp
SharedPtr<List<PointF>> points = System::MakeObject<List<PointF>>();

float R = 100.0f, r = 50.0f;
int32_t step = 72;

for (int32_t angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math::PI / 180.f);
    double x = outerRadius * Math::Cos(radians);
    double y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + step / 2) / 180.0;
    x = innerRadiusr * Math::Cos(radians);
    y = innerRadiusr * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

SharedPtr<GeometryPath> starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (int32_t i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, R * 2, R * 2));

shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)


## **Crea una forma composita personalizzata**

1. Crea un’istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_shape).  
2. Crea una prima istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_path).  
3. Crea una seconda istanza della classe [GeometryPath](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_path).  
4. Applica i percorsi alla forma.  

Questo codice C++ mostra come creare una forma composita personalizzata:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath0 = System::MakeObject<GeometryPath>();
geometryPath0->MoveTo(0.0f, 0.0f);
geometryPath0->LineTo(shape->get_Width(), 0.0f);
geometryPath0->LineTo(shape->get_Width(), shape->get_Height() / 3);
geometryPath0->LineTo(0.0f, shape->get_Height() / 3);
geometryPath0->CloseFigure();

SharedPtr<IGeometryPath> geometryPath1 = System::MakeObject<GeometryPath>();
geometryPath1->MoveTo(0.0f, shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height());
geometryPath1->LineTo(0.0f, shape->get_Height());
geometryPath1->CloseFigure();

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ geometryPath0, geometryPath1 }));
```
![example4_image](custom_shape_4.png)

## **Crea una forma personalizzata con angoli curvi**

Questo codice C++ mostra come creare una forma personalizzata con angoli curvi (verso l’interno);

```cpp
float shapeX = 20.f;
float shapeY = 20.f;
float shapeWidth = 300.f;
float shapeHeight = 200.f;

float leftTopSize = 50.f;
float rightTopSize = 20.f;
float rightBottomSize = 40.f;
float leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();

auto childShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto geometryPath = System::MakeObject<GeometryPath>();

PointF point1(leftTopSize, 0.0f);
PointF point2(shapeWidth - rightTopSize, 0.0f);
PointF point3(shapeWidth, shapeHeight - rightBottomSize);
PointF point4(leftBottomSize, shapeHeight);
PointF point5(0.0f, leftTopSize);

geometryPath->MoveTo(point1);
geometryPath->LineTo(point2);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(point3);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(point4);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(point5);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);

geometryPath->CloseFigure();

childShape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Scopri se la geometria di una forma è chiusa**

Una forma chiusa è definita come quella i cui lati si collegano tutti, formando un unico contorno senza interruzioni. Tale forma può essere una figura geometrica semplice o un contorno personalizzato complesso. L’esempio di codice seguente mostra come verificare se la geometria di una forma è chiusa:

```cpp
bool IsGeometryClosed(SharedPtr<IGeometryShape> geometryShape)
{
    bool isClosed = false;

    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto dataLength = geometryPath->get_PathData()->get_Length();
        if (dataLength == 0)
            continue;

        auto lastSegment = geometryPath->get_PathData()[dataLength - 1];
        isClosed = lastSegment->get_PathCommand() == PathCommandType::Close;

        if (!isClosed)
            return false;
    }

    return isClosed;
}
```

## **Converti GeometryPath in GraphicsPath** 

1. Crea un’istanza della classe [GeometryShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_shape).  
2. Crea un’istanza della classe [GraphicsPath](https://reference.aspose.com/slides/it/cpp/class/system.drawing.drawing2_d.graphics_path) del namespace [System.Drawing.Drawing2D](https://reference.aspose.com/slides/it/cpp/namespace/system.drawing.drawing2_d).  
3. Converti l’istanza di [GraphicsPath](https://reference.aspose.com/slides/it/cpp/class/system.drawing.drawing2_d.graphics_path) nell’istanza di [GeometryPath](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.geometry_path) usando [ShapeUtil](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.util.shape_util).  
4. Applica i percorsi alla forma.  

Questo codice C++—un’implementazione dei passaggi sopra—dimostra il processo di conversione da **GeometryPath** a **GraphicsPath**:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Text in shape", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Cosa accadrà al riempimento e al contorno dopo aver sostituito la geometria?**  

Lo stile rimane associato alla forma; cambia solo il contorno. Il riempimento e il contorno vengono applicati automaticamente alla nuova geometria.

**Come ruoto correttamente una forma personalizzata insieme alla sua geometria?**  

Usa la proprietà di [rotation](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/set_rotation/) della forma; la geometria ruota con la forma perché è vincolata al sistema di coordinate della forma stessa.

**Posso convertire una forma personalizzata in un'immagine per "bloccare" il risultato?**  

Sì. Esporta l’[slide](/slides/it/cpp/convert-powerpoint-to-png/) o la [shape](/slides/it/cpp/create-shape-thumbnails/) desiderata in un formato raster; questo semplifica ulteriori lavori con geometrie complesse.