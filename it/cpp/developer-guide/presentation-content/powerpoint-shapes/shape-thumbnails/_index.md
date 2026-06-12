---
title: Crea miniature di forme di presentazione in C++
linktitle: Miniature delle forme
type: docs
weight: 70
url: /it/cpp/shape-thumbnails/
keywords:
- miniatura di forma
- immagine della forma
- renderizzare forma
- renderizzazione della forma
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Genera miniature di forma ad alta qualità dalle diapositive PowerPoint con Aspose.Slides per C++ – crea e esporta facilmente le miniature della presentazione."
---
## **Introduzione**

Aspose.Slides viene utilizzato per creare file di presentazione in cui ogni pagina è una diapositiva. Queste diapositive possono essere visualizzate aprendo i file di presentazione con Microsoft PowerPoint. Tuttavia, a volte gli sviluppatori hanno bisogno di visualizzare le immagini delle forme separatamente in un visualizzatore di immagini. In questi casi, Aspose.Slides consente di generare miniature delle forme delle diapositive. Il funzionamento di questa funzionalità è descritto in questo articolo.  
Questo articolo spiega come generare miniature di diapositive in diversi modi:

- Generare una miniatura di una forma all'interno di una diapositiva.  
- Generare una miniatura di una forma per una forma di diapositiva con dimensioni definite dall'utente.  
- Generare una miniatura di una forma nei limiti dell'aspetto della forma.

## **Genera una miniatura della forma da una diapositiva**
Per generare una miniatura della forma da qualsiasi diapositiva usando Aspose.Slides per C++:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottenere il riferimento di qualsiasi diapositiva utilizzando il suo ID o indice.
1. Recuperare l'immagine miniatura della forma della diapositiva di riferimento con scala predefinita.
1. Salvare l'immagine miniatura nel formato immagine desiderato.

L'esempio seguente genera una miniatura della forma.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Genera una miniatura con fattore di scala definito dall'utente**
Per generare la miniatura della forma di qualsiasi forma di diapositiva usando Aspose.Slides per C++:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottenere il riferimento di qualsiasi diapositiva utilizzando il suo ID o indice.
1. Recuperare l'immagine miniatura della diapositiva di riferimento con i limiti della forma.
1. Salvare l'immagine miniatura nel formato immagine desiderato.

L'esempio seguente genera una miniatura con un fattore di scala definito dall'utente.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Scalatura lungo gli assi X e Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Crea una miniatura basata sui limiti dell'aspetto della forma**
Questo metodo per creare miniature di forme consente agli sviluppatori di generare una miniatura nei limiti dell'aspetto della forma. Tiene conto di tutti gli effetti della forma. La miniatura della forma generata è limitata dai bordi della diapositiva. Per generare una miniatura di qualsiasi forma di diapositiva nei limiti del suo aspetto, utilizzare il seguente codice di esempio:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottenere il riferimento di qualsiasi diapositiva utilizzando il suo ID o indice.
1. Recuperare l'immagine miniatura della diapositiva di riferimento con i limiti della forma come aspetto.
1. Salvare l'immagine miniatura nel formato immagine desiderato.

L'esempio seguente crea una miniatura con un fattore di scala definito dall'utente.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Scalatura lungo gli assi X e Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Quali formati immagine possono essere usati quando si salvano le miniature delle forme?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/it/cpp/aspose.slides/imageformat/), e altri. Le forme possono anche essere [esportate come SVG vettoriale](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/writeassvg/) salvando il contenuto della forma come SVG.

**Qual è la differenza tra i limiti Shape e Appearance quando si renderizza una miniatura?**

`Shape` utilizza la geometria della forma; `Appearance` tiene conto degli [effetti visivi](/slides/it/cpp/shape-effect/) (ombreggiature, bagliori, ecc.).

**Cosa succede se una forma è contrassegnata come nascosta? Viene comunque renderizzata come miniatura?**

Una forma nascosta rimane parte del modello e può essere renderizzata; il flag nascosto influisce sulla visualizzazione della presentazione ma non impedisce la generazione dell'immagine della forma.

**Sono supportate le forme di gruppo, i grafici, SmartArt e altri oggetti complessi?**

Sì. Qualsiasi oggetto rappresentato come [Shape](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/) (inclusi [GroupShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chart/), e [SmartArt](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/smartart/)) può essere salvato come miniatura o come SVG.

**I caratteri installati nel sistema influiscono sulla qualità delle miniature per le forme di testo?**

Sì. È necessario [fornire i caratteri richiesti](/slides/it/cpp/custom-font/) (o [configurare le sostituzioni dei caratteri](/slides/it/cpp/font-substitution/)) per evitare fallback indesiderati e riformattazioni del testo.