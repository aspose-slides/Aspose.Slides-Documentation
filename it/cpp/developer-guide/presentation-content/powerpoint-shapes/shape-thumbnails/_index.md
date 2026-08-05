---
title: Crea miniature di forme di presentazione in C++
linktitle: Miniature di forme
type: docs
weight: 70
url: /it/cpp/shape-thumbnails/
keywords:
- miniatura di forma
- immagine di forma
- renderizzare forma
- rendering di forma
- limiti visivi
- limiti di forma
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Genera miniature di forma di alta qualità da diapositive PowerPoint con Aspose.Slides per C++ – crea e esporta facilmente miniature di presentazioni."
---
## **Introduzione**

Aspose.Slides viene utilizzato per creare file di presentazione in cui ciascuna pagina è una diapositiva. Queste diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Tuttavia, a volte gli sviluppatori potrebbero aver bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In tali casi, Aspose.Slides ti aiuta a generare immagini in miniatura delle forme della diapositiva. Come utilizzare questa funzionalità è descritto in questo articolo.

Questo articolo spiega come generare miniature diapositive in diversi modi:

- Generazione di una miniatura di forma all'interno di una diapositiva.
- Generazione di una miniatura di forma per una forma della diapositiva con dimensioni definite dall'utente.
- Generazione di una miniatura di forma nei limiti dell'aspetto di una forma.

## **Genera una Miniatura di Forma da una Diapositiva**
Per generare una miniatura di forma da qualsiasi diapositiva utilizzando Aspose.Slides per C++:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'immagine in miniatura della forma della diapositiva di riferimento con scala predefinita.
1. Salva l'immagine in miniatura in qualsiasi formato immagine desiderato.

L'esempio seguente genera una miniatura di forma.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Genera una Miniatura con Fattore di Scala Definito dall'Utente**
Per generare la miniatura della forma di qualsiasi forma della diapositiva utilizzando Aspose.Slides per C++:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'immagine in miniatura della diapositiva di riferimento con i limiti della forma.
1. Salva l'immagine in miniatura in qualsiasi formato immagine desiderato.

L'esempio seguente genera una miniatura con fattore di scala definito dall'utente.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Scalatura sugli assi X e Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Crea una Miniatura di Forma Basata sui Limiti dell'Aspetto**
La presente metodo per creare miniature di forme consente agli sviluppatori di generare una miniatura nei limiti dell'aspetto della forma. Tiene conto di tutti gli effetti della forma. La miniatura generata è limitata dai limiti della diapositiva. Per generare una miniatura di qualsiasi forma della diapositiva nei limiti del suo aspetto, utilizzare il seguente codice di esempio:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni il riferimento di qualsiasi diapositiva usando il suo ID o indice.
1. Ottieni l'immagine in miniatura della diapositiva di riferimento con i limiti della forma come aspetto.
1. Salva l'immagine in miniatura in qualsiasi formato immagine desiderato.

L'esempio seguente crea una miniatura con fattore di scala definito dall'utente.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Scalatura sugli assi X e Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Ottieni i Limiti Visivi Reali di una Forma**

Le proprietà del frame di [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) — `IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()` e `IShape::get_Height()` — descrivono il rettangolo memorizzato nel modello della presentazione. Il contenuto effettivamente renderizzato può estendersi oltre quel frame o occupare un rettangolo allineato agli assi diverso. Rotazione, contorni, punte di freccia, layout e overflow del testo, geometria SmartArt generata e altri effetti di rendering possono tutti modificare l'area occupata.

Usa [Shape::GetVisualBounds](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/getvisualbounds/) per calcolare quell'area occupata senza creare un'immagine. Il metodo restituisce un [RectangleF](https://reference.aspose.com/slides/it/cpp/system.drawing/rectanglef/) nelle coordinate della diapositiva. Il rettangolo restituito non è ritagliato alla diapositiva, quindi le sue coordinate possono essere negative quando il contenuto si estende oltre l'origine della diapositiva.

[Shape::GetVisualBounds] non è attualmente dichiarato dall'interfaccia [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/). Pertanto, conserva la forma ottenuta dalla collezione di forme della diapositiva come valore di interfaccia e castala solo quando chiami il metodo.

Il seguente esempio ottiene e confronta i limiti del frame e i limiti visivi:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

Lo stesso [RectangleF](https://reference.aspose.com/slides/it/cpp/system.drawing/rectanglef/) può essere usato per allineare forme vicine al suo bordo `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` o `RectangleF::get_Bottom()`; per riservare spazio sufficiente in un layout generato; o per rilevare contenuti al di fuori di una regione consentita. I limiti visivi sono particolarmente utili per SmartArt, caselle di testo, frecce, immagini, forme ruotate e gruppi di forme, dove il frame memorizzato potrebbe non rappresentare il risultato renderizzato completo.

Usa [Shape::GetVisualBounds] quando ti servono coordinate per layout o convalida e non hai bisogno di una bitmap. Usa [IShape::GetImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/getimage/) quando devi renderizzare la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` dimensiona l'immagine in base ai limiti della forma, includendo le impostazioni di contorno, mentre `ShapeThumbnailBounds::Appearance` la dimensiona in base all'aspetto della forma e limita il risultato ai limiti della diapositiva. Al contrario, [Shape::GetVisualBounds] restituisce solo il rettangolo calcolato e non lo ritaglia alla diapositiva.

## **FAQ**

**Quali formati immagine possono essere usati quando si salvano le miniature delle forme?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/cpp/aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/writeassvg/) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti Shape e Appearance quando si rende una miniatura?**

`Shape` utilizza la geometria della forma; `Appearance` prende in considerazione gli [effetti visivi](/slides/it/cpp/shape-effect/) (ombre, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Viene comunque renderizzata come miniatura?**

Una forma nascosta rimane parte del modello e può essere renderizzata; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell'immagine della forma.

**Le forme di gruppo, i grafici, SmartArt e altri oggetti complessi sono supportati?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chart/), e [SmartArt](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartart/)) può essere salvato come miniatura o come SVG.

**I caratteri installati sul sistema influiscono sulla qualità delle miniature per le forme di testo?**

Sì. Dovresti [fornire i caratteri richiesti](/slides/it/cpp/custom-font/) (o [configurare le sostituzioni di caratteri](/slides/it/cpp/font-substitution/)) per evitare fallback indesiderati e riformattazione del testo.