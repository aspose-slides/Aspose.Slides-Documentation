---
title: Formattare le forme PowerPoint in C++
linktitle: Formattazione forme
type: docs
weight: 20
url: /it/cpp/shape-formatting/
keywords:
- formattare forma
- formattare linea
- effetto schizzo
- linea schizzo della forma
- formattare stile di giunzione
- riempimento gradiente
- riempimento a motivo
- riempimento immagine
- riempimento con texture
- riempimento a colore solido
- trasparenza forma
- ruotare forma
- effetto smusso 3D
- effetto rotazione 3D
- ripristinare formattazione
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come formattare le forme PowerPoint in C++ usando Aspose.Slides—imposta stili di riempimento, linea ed effetto per file PPT, PPTX e ODP con precisione e pieno controllo."
---
## **Introduzione**

In PowerPoint, è possibile aggiungere forme alle diapositive. Poiché le forme sono composte da linee, è possibile formattarle modificando o applicando effetti ai loro contorni. Inoltre, è possibile formattare le forme specificando impostazioni che controllano come vengono riempiti i loro interni.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ fornisce interfacce e metodi che consentono di formattare le forme utilizzando le stesse opzioni disponibili in PowerPoint.

## **Formattare le linee**

Utilizzando Aspose.Slides, è possibile specificare uno stile di linea personalizzato per una forma. I passaggi seguenti illustrano la procedura:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta lo [stile di linea](https://reference.aspose.com/slides/it/cpp/aspose.slides/linestyle/) della forma.
1. Imposta la larghezza della linea.
1. Imposta lo [stile di tratteggio](https://reference.aspose.com/slides/it/cpp/aspose.slides/linedashstyle/) della linea.
1. Imposta il colore della linea per la forma.
1. Salva la presentazione modificata come file PPTX.

Il codice seguente dimostra come formattare un `AutoShape` rettangolare:

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Ottieni la prima diapositiva.
auto slide = presentation->get_Slide(0);

// Aggiungi una forma automatica di tipo Rettangolo.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Imposta il colore di riempimento per la forma rettangolare.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Applica la formattazione alle linee del rettangolo.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Imposta il colore per la linea del rettangolo.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Salva il file PPTX su disco.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The formatted lines in the presentation](formatted-lines.png)

## **Applicare effetti schizzo alle linee delle forme**

Un effetto schizzo rende la linea di una forma simile a disegnata a mano. Usa [IShape::get_LineFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_lineformat/) per accedere alle impostazioni della linea, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilineformat/get_sketchformat/) per accedere alle impostazioni dello schizzo e [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/it/cpp/aspose.slides/isketchformat/set_sketchtype/) per selezionare un valore dall'enumerazione [LineSketchType](https://reference.aspose.com/slides/it/cpp/aspose.slides/linesketchtype/).

Il codice C++ seguente mostra come applicare un effetto [LineSketchType::Curved](https://reference.aspose.com/slides/it/cpp/aspose.slides/linesketchtype/) , leggere il valore assegnato esplicitamente e rimuovere l'effetto con [LineSketchType::None](https://reference.aspose.com/slides/it/cpp/aspose.slides/linesketchtype/):

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Il valore restituito da [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/it/cpp/aspose.slides/isketchformat/get_sketchtype/) rappresenta l'impostazione assegnata direttamente alla forma. Se la formattazione della linea può essere ereditata da un tema, da una diapositiva master o da una diapositiva layout, usa [ILineFormat::GetEffective](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilineformat/geteffective/), accedi a [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) e leggi [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/it/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Il valore effettivo riflette la formattazione effettivamente applicata dopo la risoluzione dell'ereditarietà:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **Formattare gli stili di giunzione**

Ecco le tre opzioni di tipo di giunzione:

* Arrotondato
* Smusso
* Bisel

Per impostazione predefinita, quando PowerPoint unisce due linee a un angolo (ad esempio all'angolo di una forma), utilizza l'impostazione **Arrotondato**. Tuttavia, se stai disegnando una forma con angoli acuti, potresti preferire l'opzione **Smusso**.

![The join style in the presentation](join-style-powerpoint.png)

Il codice C++ seguito dimostra come tre rettangoli (come mostrato nell'immagine sopra) sono stati creati utilizzando le impostazioni di tipo di giunzione Miter, Bevel e Arrotondato:

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Ottieni la prima diapositiva.
auto slide = presentation->get_Slide(0);

// Aggiungi tre forme automatiche di tipo Rettangolo.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Imposta il colore di riempimento per ciascuna forma rettangolare.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Imposta lo spessore della linea.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Imposta il colore per la linea di ciascun rettangolo.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Imposta lo stile di giunzione.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Aggiungi testo a ciascun rettangolo.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Salva il file PPTX su disco.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Riempimento gradiente**

In PowerPoint, il Riempimento gradiente è un'opzione di formattazione che consente di applicare una gradazione continua di colori a una forma. Ad esempio, è possibile applicare due o più colori in modo che uno sfumi gradualmente nell'altro.

Ecco come applicare un riempimento gradiente a una forma usando Aspose.Slides:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/) della forma su `Gradient`.
1. Aggiungi i due colori preferiti con posizioni definite usando i metodi `Add` della collezione di gradient stop esposta dall'interfaccia [IGradientFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/igradientformat/).
1. Salva la presentazione modificata come file PPTX.

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Ottieni la prima diapositiva.
auto slide = presentation->get_Slide(0);

// Aggiungi una forma automatica di tipo Ellisse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Applica formattazione a gradiente all'ellisse.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Imposta la direzione del gradiente.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Aggiungi due fermate di gradiente.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Salva il file PPTX su disco.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The ellipse with gradient fill](gradient-fill.png)

## **Riempimento a motivo**

In PowerPoint, il Riempimento a motivo è un'opzione di formattazione che consente di applicare un disegno bicolore — come punti, strisce, tratteggi incrociati o scacchi — a una forma. È possibile scegliere colori personalizzati per il primo piano e lo sfondo del motivo.

Aspose.Slides fornisce oltre 45 stili di motivo predefiniti che è possibile applicare alle forme per migliorare l'aspetto visivo delle presentazioni. Anche dopo aver selezionato un motivo predefinito, è ancora possibile specificare i colori esatti da utilizzare.

Ecco come applicare un riempimento a motivo a una forma usando Aspose.Slides:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/) della forma su `Pattern`.
1. Scegli uno stile di motivo tra le opzioni predefinite.
1. Imposta il [Background Color](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipatternformat/get_backcolor/) del motivo.
1. Imposta il [Foreground Color](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipatternformat/get_forecolor/) del motivo.
1. Salva la presentazione modificata come file PPTX.

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Ottieni la prima diapositiva.
auto slide = presentation->get_Slide(0);

// Aggiungi una forma automatica di tipo Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Imposta il tipo di riempimento su Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Imposta lo stile del motivo.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Imposta i colori di sfondo e primo piano del motivo.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Salva il file PPTX su disco.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The rectangle with pattern fill](pattern-fill.png)

## **Riempimento immagine**

In PowerPoint, il Riempimento immagine è un'opzione di formattazione che consente di inserire un'immagine all'interno di una forma — utilizzando efficacemente l'immagine come sfondo della forma.

Ecco come utilizzare Aspose.Slides per applicare un riempimento immagine a una forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/) della forma su `Picture`.
1. Imposta la modalità di riempimento immagine su `Tile` (o un'altra modalità preferita).
1. Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) dall'immagine che desideri utilizzare.
1. Passa l'immagine al metodo `ISlidesPicture.set_Image`.
1. Salva la presentazione modificata come file PPTX.

![The lotus picture](lotus.png)

Il codice C++ seguente dimostra come riempire una forma con l'immagine:

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Ottieni la prima diapositiva.
auto slide = presentation->get_Slide(0);

// Aggiungi una forma automatica di tipo Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Imposta il tipo di riempimento su Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Imposta la modalità di riempimento immagine.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Carica un'immagine e aggiungila alle risorse della presentazione.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Imposta l'immagine.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Salva il file PPTX su disco.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The shape with picture fill](picture-fill.png)

### **Immagine a mosaico come texture**

Se desideri impostare un'immagine a mosaico come texture e personalizzare il comportamento del mosaico, puoi utilizzare i seguenti metodi dell'interfaccia [IPictureFillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/) e della classe [PictureFillFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Imposta la modalità di riempimento immagine — `Tile` o `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Specifica l'allineamento delle tessere all'interno della forma.
- [set_TileFlip](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Controlla se la tessera è capovolta orizzontalmente, verticalmente o in entrambi i sensi.
- [set_TileOffsetX](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Imposta lo spostamento orizzontale della tessera (in punti) dall'origine della forma.
- [set_TileOffsetY](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Imposta lo spostamento verticale della tessera (in punti) dall'origine della forma.
- [set_TileScaleX](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Definisce la scala orizzontale della tessera in percentuale.
- [set_TileScaleY](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Definisce la scala verticale della tessera in percentuale.

Il campione di codice seguente mostra come aggiungere una forma rettangolare con un riempimento immagine a mosaico e configurare le opzioni di tessera:

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Ottieni la prima diapositiva.
auto firstSlide = presentation->get_Slide(0);

// Aggiungi una forma automatica rettangolare.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Imposta il tipo di riempimento della forma su Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Carica l'immagine e aggiungila alle risorse della presentazione.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Assegna l'immagine alla forma.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Configura la modalità di riempimento immagine e le proprietà di tiling.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Salva il file PPTX su disco.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The tile options](tile-options.png)

## **Riempimento a colore solido**

In PowerPoint, il Riempimento a colore solido è un'opzione di formattazione che riempie una forma con un unico colore uniforme. Questo colore di sfondo semplice è applicato senza gradienti, texture o motivi.

Per applicare un riempimento a colore solido a una forma usando Aspose.Slides, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/) della forma su `Solid`.
1. Assegna alla forma il colore di riempimento desiderato.
1. Salva la presentazione modificata come file PPTX.

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Ottieni la prima diapositiva.
auto slide = presentation->get_Slide(0);

// Aggiungi una forma automatica di tipo Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Imposta il tipo di riempimento su Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Imposta il colore di riempimento.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Salva il file PPTX su disco.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The shape with solid color fill](solid-color-fill.png)

## **Impostare la trasparenza**

In PowerPoint, quando si applica un riempimento a colore solido, gradiente, immagine o texture a delle forme, è possibile impostare anche un livello di trasparenza per controllare l'opacità del riempimento. Un valore di trasparenza più alto rende la forma più trasparente, consentendo allo sfondo o agli oggetti sottostanti di essere parzialmente visibili.

Aspose.Slides consente di impostare il livello di trasparenza regolando il valore alfa del colore usato per il riempimento. Ecco come fare:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta il [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/) su `Solid`.
1. Usa `Color` per definire un colore con trasparenza (il componente `alpha` controlla la trasparenza).
1. Salva la presentazione.

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Ottieni la prima diapositiva.
auto slide = presentation->get_Slide(0);

// Aggiungi una forma automatica rettangolare solida.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Aggiungi una forma automatica rettangolare trasparente sopra la forma solida.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Salva il file PPTX su disco.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The transparent shape](shape-transparency.png)

## **Ruotare le forme**

Aspose.Slides consente di ruotare le forme nelle presentazioni PowerPoint. Questo può essere utile quando si posizionano elementi visivi con specifici requisiti di allineamento o design.

Per ruotare una forma su una diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
1. Imposta la proprietà di rotazione della forma sull'angolo desiderato.
1. Salva la presentazione.

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Ottieni la prima diapositiva.
auto slide = presentation->get_Slide(0);

// Aggiungi una forma automatica di tipo Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Ruota la forma di 5 gradi.
shape->set_Rotation(5);

// Salva il file PPTX su disco.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The shape rotation](shape-rotation.png)

## **Aggiungere effetti di smusso 3D**

Aspose.Slides consente di applicare effetti di smusso 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/threedformat/).

Per aggiungere effetti di smusso 3D a una forma, segui questi passaggi:

1. Instanzia la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
1. Configura il [ThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/threedformat/) della forma per definire le impostazioni di smusso.
1. Salva la presentazione.

```cpp
// Crea un'istanza della classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Aggiungi una forma alla diapositiva.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Imposta le proprietà ThreeDFormat della forma.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Salva la presentazione come file PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The 3D bevel effect](3D-bevel-effect.png)

## **Aggiungere effetti di rotazione 3D**

Aspose.Slides consente di applicare effetti di rotazione 3D alle forme configurando le loro proprietà [ThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/threedformat/).

Per applicare una rotazione 3D a una forma:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) alla diapositiva.
1. Usa [set_CameraType](https://reference.aspose.com/slides/it/cpp/aspose.slides/icamera/set_cameratype/) e [set_LightType](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilightrig/set_lighttype/) per definire la rotazione 3D.
1. Salva la presentazione.

```cpp
// Crea un'istanza della classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Salva la presentazione come file PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![The 3D rotation effect](3D-rotation-effect.png)

## **Ripristinare la formattazione**

Il codice C++ seguente mostra come ripristinare la formattazione di una diapositiva e riportare la posizione, le dimensioni e la formattazione di tutte le forme con segnaposti sul [LayoutSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/layoutslide/) alle loro impostazioni predefinite:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Reimposta ogni forma nella diapositiva che ha un segnaposto nel layout.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**La formattazione delle forme influisce sulla dimensione finale del file della presentazione?**

Solo minimamente. Le immagini e i media incorporati occupano la maggior parte dello spazio del file, mentre i parametri delle forme come colori, effetti e gradienti sono memorizzati come metadati e aggiungono praticamente nessuna dimensione extra.

**Come posso rilevare le forme su una diapositiva che condividono una formattazione identica così da poterle raggruppare?**

Confronta le proprietà di formattazione chiave di ciascuna forma — impostazioni di riempimento, linea ed effetti. Se tutti i valori corrispondenti coincidono, considera i loro stili come identici e raggruppa logicamente quelle forme, semplificando la gestione successiva degli stili.

**Posso salvare un set di stili di forme personalizzati in un file separato per riutilizzarlo in altre presentazioni?**

Sì. Conserva le forme di esempio con gli stili desiderati in un set diapositive modello o in un file modello .POTX. Quando crei una nuova presentazione, apri il modello, clona le forme stilizzate di cui hai bisogno e riapplica la loro formattazione dove necessario.