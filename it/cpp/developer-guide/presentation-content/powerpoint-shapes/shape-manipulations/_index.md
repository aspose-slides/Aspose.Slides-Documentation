---
title: Gestisci le forme della presentazione in C++
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/cpp/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma della presentazione
- Forma sulla diapositiva
- Trova forma
- Clona forma
- Rimuovi forma
- Nascondi forma
- Cambia ordine forma
- Ottieni ID forma interop
- Testo alternativo forma
- Formati layout forma
- Forma come SVG
- Forma a SVG
- Allinea forma
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Impara a creare, modificare e ottimizzare le forme in Aspose.Slides per C++ e a realizzare presentazioni PowerPoint ad alte prestazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le forme nelle presentazioni utilizzando Aspose.Slides. Mostra come trovare una forma su una diapositiva, clonarla, rimuoverla, nasconderla, cambiare il suo ordine, ottenere il relativo Interop Shape ID e impostare il testo alternativo per l'identificazione e l'elaborazione successiva.

Copre anche come accedere ai formati di layout per le forme, renderizzare una forma come SVG, allineare le forme su una diapositiva e utilizzare le proprietà di capovolgimento per la riflessione orizzontale e verticale. Inoltre, l'articolo include una breve sezione FAQ su combinazione di forme, ordine di sovrapposizione e blocco delle forme.

## **Trova una forma su una diapositiva**
Questo argomento descriverà una tecnica semplice per facilitare gli sviluppatori nel trovare una forma specifica su una diapositiva senza utilizzare il suo Id interno. È importante sapere che i file di presentazione PowerPoint non hanno alcun modo per identificare le forme su una diapositiva se non tramite un Id interno unico. Sembra difficile per gli sviluppatori trovare una forma usando il suo Id interno unico. Tutte le forme aggiunte alle diapositive hanno qualche Testo Alternativo. Suggeriamo agli sviluppatori di utilizzare il testo alternativo per trovare una forma specifica. È possibile utilizzare MS PowerPoint per definire il testo alternativo per gli oggetti che si prevede di modificare in futuro.

Dopo aver impostato il testo alternativo di qualsiasi forma desiderata, è possibile aprire quella presentazione con Aspose.Slides per C++ e iterare attraverso tutte le forme aggiunte a una diapositiva. Durante ogni iterazione, è possibile verificare il testo alternativo della forma e la forma con il testo alternativo corrispondente sarà quella richiesta. Per dimostrare meglio questa tecnica, abbiamo creato un metodo, [FindShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) che esegue il trucco per trovare una forma specifica in una diapositiva e restituisce semplicemente quella forma.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **Clona una forma**
Per clonare una forma su una diapositiva utilizzando Aspose.Slides per C++:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Ottieni il riferimento di una diapositiva utilizzando il suo indice.
1. Accedi alla raccolta di forme della diapositiva di origine.
1. Aggiungi una nuova diapositiva alla presentazione.
1. Clona le forme dalla raccolta di forme della diapositiva di origine alla nuova diapositiva.
1. Salva la presentazione modificata come file PPTX.

Il codice di esempio sotto aggiunge una forma di gruppo a una diapositiva.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **Rimuovi una forma**
Aspose.Slides per C++ consente agli sviluppatori di rimuovere qualsiasi forma. Per rimuovere la forma da una diapositiva, seguire i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Accedi alla prima diapositiva.
1. Trova la forma con il Testo Alternativo specificato.
1. Rimuovi la forma.
1. Salva il file su disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **Nascondi una forma**
Aspose.Slides per C++ consente agli sviluppatori di nascondere qualsiasi forma. Per nascondere la forma da una diapositiva, seguire i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Accedi alla prima diapositiva.
1. Trova la forma con il Testo Alternativo specificato.
1. Nascondi la forma.
1. Salva il file su disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **Cambia l'ordine delle forme**
Aspose.Slides per C++ consente agli sviluppatori di riordinare le forme. Il riordino della forma specifica quale forma è in primo piano o sullo sfondo. Per riordinare le forme su una diapositiva, seguire i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi una forma.
1. Aggiungi del testo nella casella di testo della forma.
1. Aggiungi un'altra forma con le stesse coordinate.
1. Riordina le forme.
1. Salva il file su disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Ottieni l'ID Interop della forma**
Aspose.Slides per C++ consente agli sviluppatori di ottenere un identificatore unico della forma nell'ambito della diapositiva, in contrasto con la proprietà UniqueId, che consente di ottenere un identificatore unico nell'ambito della presentazione. La proprietà OfficeInteropShapeId è stata aggiunta alle interfacce IShape e alla classe Shape rispettivamente. Il valore restituito dalla proprietà OfficeInteropShapeId corrisponde al valore dell'Id dell'oggetto Microsoft.Office.Interop.PowerPoint.Shape. Di seguito è riportato il codice di esempio.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **Imposta la proprietà AlternativeText**
Aspose.Slides per C++ consente agli sviluppatori di impostare l'AlternativeText di qualsiasi forma. Per impostare l'AlternativeText di una forma, seguire i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi una forma qualsiasi alla diapositiva.
1. Esegui qualche operazione con la forma appena aggiunta.
1. Scorri le forme per trovare una forma.
1. Imposta l'AlternativeText.
1. Salva il file su disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **Accedi ai formati di layout per una forma**
Aspose.Slides per C++ consente agli sviluppatori di accedere ai formati di layout per una forma. Questo articolo dimostra come è possibile accedere alle proprietà **FillFormat** e **LineFormat** per una forma.

Di seguito è riportato il codice di esempio.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Renderizza una forma come SVG**
Ora Aspose.Slides per C++ supporta il rendering di una forma come SVG. Il metodo WriteAsSvg (e le sue overload) è stato aggiunto alla classe Shape e all'interfaccia IShape. Questo metodo permette di salvare il contenuto della forma in un file SVG. Il frammento di codice seguente mostra come esportare la forma di una diapositiva in un file SVG.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Allineamento delle forme**
Aspose.Slides consente di allineare le forme sia rispetto ai margini della diapositiva sia rispetto le une alle altre. A tal fine, è stato aggiunto un metodo sovraccaricato [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab). L'enumerazione [ShapesAlignmentType](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) definisce le possibili opzioni di allineamento.

**Esempio 1**

Il codice sorgente qui sotto allinea le forme con gli indici 1, 2 e 4 lungo il bordo superiore della diapositiva.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Esempio 2**

L'esempio qui sotto mostra come allineare l'intera raccolta di forme rispetto alla forma più bassa della raccolta.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **Proprietà di capovolgimento**

In Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapeframe/) fornisce il controllo sul ribaltamento orizzontale e verticale delle forme tramite le sue proprietà `flipH` e `flipV`. Entrambe le proprietà sono di tipo [NullableBool](https://reference.aspose.com/slides/it/cpp/aspose.slides/nullablebool/), consentendo valori `True` per indicare un ribaltamento, `False` per nessun ribaltamento, o `NotDefined` per utilizzare il comportamento predefinito. Questi valori sono accessibili dal [Frame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_frame/) di una forma.

Per modificare le impostazioni di ribaltamento, viene costruita una nuova istanza di [ShapeFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapeframe/) con la posizione e le dimensioni correnti della forma, i valori desiderati per `flipH` e `flipV` e l'angolo di rotazione. Assegnando questa istanza al [Frame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_frame/) della forma e salvando la presentazione, vengono applicate le trasformazioni di mirror e registrate nel file di output.

Supponiamo di avere un file sample.pptx in cui la prima diapositiva contiene una singola forma con impostazioni di ribaltamento predefinite, come mostrato di seguito.

![La forma da capovolgere](shape_to_be_flipped.png)

Il seguente esempio di codice recupera le proprietà di ribaltamento correnti della forma e la ribalta sia orizzontalmente sia verticalmente.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Recupera la proprietà di ribaltamento orizzontale della forma.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Recupera la proprietà di ribaltamento verticale della forma.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Capovolgi orizzontalmente.
auto flipV = NullableBool::True; // Capovolgi orizzontalmente.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il risultato:

![La forma capovolta](flipped_shape.png)

## **FAQ**

**Posso combinare le forme (unione/intersezione/sottrazione) su una diapositiva come in un editor desktop?**

Non esiste un'API integrata per operazioni booleane. È possibile approssimarla creando manualmente il contorno desiderato—ad esempio, calcolando la geometria risultante (tramite [GeometryPath](https://reference.aspose.com/slides/it/cpp/aspose.slides/geometrypath/)) e creando una nuova forma con quel contorno, rimuovendo opzionalmente le originali.

**Come posso controllare l'ordine di sovrapposizione (z-order) in modo che una forma rimanga sempre “in cima”?**

Modifica l'ordine di inserimento/spostamento all'interno della collezione di [shapes](https://reference.aspose.com/slides/it/cpp/aspose.slides/baseslide/get_shapes/) della diapositiva. Per risultati prevedibili, finalizza lo z-order dopo tutte le altre modifiche alla diapositiva.

**Posso “bloccare” una forma per impedire agli utenti di modificarla in PowerPoint?**

Sì. Imposta i flag di protezione a livello di forma (ad esempio, blocca selezione, spostamento, ridimensionamento, modifiche al testo). Se necessario, applica restrizioni analoghe al master o al layout. Nota che si tratta di protezione a livello UI, non di una funzione di sicurezza; per una protezione più forte, combinala con restrizioni a livello di file come [raccomandazioni di sola lettura o password](/slides/it/cpp/password-protected-presentation/).