---
title: "Ottieni le proprietà effettive della forma dalle presentazioni in C++"
linktitle: "Proprietà effettive"
type: docs
weight: 50
url: /it/cpp/shape-effective-properties/
keywords:
- "proprietà della forma"
- "proprietà della telecamera"
- "impianto di illuminazione"
- "forma smussata"
- "riquadro di testo"
- "stile di testo"
- "altezza del carattere"
- "formato di riempimento"
- "PowerPoint"
- "presentazione"
- "C++"
- "Aspose.Slides"
description: "Scopri come Aspose.Slides per C++ calcola e applica le proprietà effettive delle forme per una resa precisa di PowerPoint."
---
## **Panoramica**

Questo argomento spiega la differenza tra le proprietà **locali** e **effettive**. I valori locali sono valori impostati direttamente a un determinato livello di formattazione, ad esempio:

1. Proprietà della porzione su una diapositiva.  
1. Stili di testo della forma prototipo su un layout o una diapositiva master, quando la forma del riquadro di testo della porzione ne possiede uno.  
1. Impostazioni di testo globali in una presentazione.  

I valori locali possono essere definiti o omessi a qualsiasi livello. Quando Aspose.Slides ha bisogno della formattazione finale “come renderizzata”, risolve la catena di ereditarietà e restituisce i valori **effettivi**. È possibile ottenerli chiamando il metodo `GetEffective` sull'oggetto di formattazione locale.

L'esempio seguente mostra come ottenere i valori effettivi. Si assume che la prima forma nella prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) con un riquadro di testo e almeno una porzione.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
I dati di formattazione effettiva rappresentano la formattazione calcolata corrente dopo l'applicazione dell'ereditarietà. Nell'implementazione attuale, alcuni oggetti di dati effettivi, come [IPortionFormatEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/iportionformateffectivedata/), possono essere memorizzati nella cache internamente. Richiamare nuovamente `GetEffective` dopo aver modificato la formattazione padre o ereditata può aggiornare i dati memorizzati nella cache, e un oggetto precedentemente ottenuto potrebbe non rappresentare più lo stato precedente. Se è necessario conservare i valori effettivi per un uso successivo, copiare le proprietà richieste, come altezza del carattere, colore di riempimento, stile del carattere o allineamento, nel proprio oggetto dati.
{{% /alert %}}

## **Ottieni le proprietà effettive di una fotocamera**

Aspose.Slides consente di ottenere le proprietà effettive di una fotocamera. L’interfaccia [ICameraEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/icameraeffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà effettive della fotocamera. Un'istanza di [ICameraEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/icameraeffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformateffectivedata/), che fornisce valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/).

Il seguente esempio di codice mostra come ottenere le proprietà effettive per la fotocamera. Si assume che la prima forma nella prima diapositiva abbia una formattazione 3D.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **Ottieni le proprietà effettive di un sistema di illuminazione**

Aspose.Slides consente di ottenere le proprietà effettive di un impianto di illuminazione. L’interfaccia [ILightRigEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilightrigeffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà effettive dell'impianto di illuminazione. Un'istanza di [ILightRigEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilightrigeffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformateffectivedata/), che fornisce valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/).

Il seguente esempio di codice mostra come ottenere le proprietà effettive per l'impianto di illuminazione. Si assume che la prima forma nella prima diapositiva abbia una formattazione 3D.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **Ottieni le proprietà effettive di una forma smussata**

Aspose.Slides consente di ottenere le proprietà effettive di uno smusso di forma. L’interfaccia [IShapeBevelEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapebeveleffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà effettive del rilievo di una forma. Un'istanza di [IShapeBevelEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapebeveleffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformateffectivedata/), che fornisce valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ithreedformat/).

Il seguente esempio di codice mostra come ottenere le proprietà effettive per lo smusso superiore di una forma. Si assume che la prima forma nella prima diapositiva abbia una formattazione 3D.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **Ottieni le proprietà effettive di un riquadro di testo**

Utilizzando Aspose.Slides, è possibile ottenere le proprietà effettive di un riquadro di testo. L’interfaccia [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextframeformateffectivedata/) contiene le proprietà di formattazione effettiva del riquadro di testo.

Il seguente esempio di codice mostra come ottenere le proprietà di formattazione effettiva del riquadro di testo. Si assume che la prima forma nella prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) con un riquadro di testo.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **Ottieni le proprietà effettive di uno stile di testo**

Utilizzando Aspose.Slides, è possibile ottenere le proprietà effettive di uno stile di testo. L’interfaccia [ITextStyleEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/itextstyleeffectivedata/) contiene le proprietà effettive dello stile di testo.

Il seguente esempio di codice mostra come ottenere le proprietà effettive dello stile di testo. Si assume che la prima forma nella prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) con un riquadro di testo.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **Ottieni il valore effettivo dell'altezza del carattere**

Utilizzando Aspose.Slides, è possibile ottenere l'altezza effettiva del carattere. Il codice seguente dimostra come l'altezza effettiva del carattere di una porzione cambi dopo che sono stati impostati valori locali di altezza del carattere a diversi livelli della struttura della presentazione.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ottieni il formato di riempimento effettivo per una tabella**

Utilizzando Aspose.Slides, è possibile ottenere la formattazione di riempimento effettiva per le diverse parti di una tabella. L’interfaccia [IFillFormatEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifillformateffectivedata/) contiene le proprietà di formattazione di riempimento effettive. La formattazione delle celle ha priorità più alta rispetto alla formattazione delle righe, la formattazione delle righe ha priorità più alta rispetto a quella delle colonne, e la formattazione delle colonne ha priorità più alta rispetto alla formattazione dell'intera tabella.

Di conseguenza, le proprietà di [ICellFormatEffectiveData](https://reference.aspose.com/slides/it/cpp/aspose.slides/icellformateffectivedata/) vengono utilizzate per disegnare la cella della tabella. Il seguente esempio di codice mostra come ottenere la formattazione di riempimento effettiva per le diverse parti della tabella. Si assume che la prima forma nella prima diapositiva sia una [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **FAQ**

**`GetEffective` restituisce un'istantanea?**

Non sempre. I dati effettivi rappresentano la formattazione calcolata dopo l'applicazione dell'ereditarietà, ma alcuni oggetti di dati effettivi possono essere memorizzati nella cache internamente. Una chiamata successiva a `GetEffective` può ricalcolare la formattazione e aggiornare i dati nella cache, quindi un oggetto ottenuto in precedenza non dovrebbe essere considerato un'istantanea stabile.

**Quando dovrei leggere nuovamente le proprietà effettive?**

Richiama `GetEffective` nuovamente dopo aver modificato la formattazione locale, gli stili padre, la formattazione del layout, la formattazione master o le impostazioni predefinite a livello di presentazione. La successiva chiamata rivaluta la gerarchia di formattazione e restituisce il risultato effettivo corrente.

**Modificare o rimuovere una diapositiva di layout/master influisce sulle proprietà effettive già recuperate?**

Sì, ma la modifica si riflette alla successiva chiamata `GetEffective`. Se una fonte di formattazione padre viene modificata o rimossa, i dati effettivi ottenuti in precedenza possono diventare obsoleti. Una volta chiamato nuovamente `GetEffective`, Aspose.Slides rivaluta l'albero di formattazione e i font, i colori, le dimensioni o altri valori risultanti possono cambiare.

**Posso modificare i valori tramite gli oggetti di dati effettivi?**

No. Gli oggetti di dati effettivi espongono i valori calcolati. Apporta le modifiche agli oggetti di formattazione locale e poi ottieni nuovamente i valori effettivi.

**Cosa succede se una proprietà non è impostata a livello di forma, né nel layout/master, né nelle impostazioni globali?**

Il valore effettivo è determinato dal meccanismo predefinito, che include le impostazioni predefinite di PowerPoint e Aspose.Slides. Quel valore risolto diventa parte dei dati effettivi correnti.

**Dal valore di font effettivo, posso capire a quale livello è stato fornito la dimensione o il tipo di carattere?**

Non direttamente. I dati effettivi restituiscono il valore finale. Per individuare la fonte, verifica i valori locali nella porzione, nel paragrafo, nel riquadro di testo e negli stili di testo a livello di layout, master e presentazione per vedere dove appare la prima definizione esplicita.

**Perché i valori effettivi a volte sembrano identici a quelli locali?**

Perché il valore locale è risultato finale (non è stata necessaria alcuna ereditarietà di livello superiore). In tali casi, il valore effettivo corrisponde a quello locale.

**Quando dovrei usare le proprietà effettive e quando dovrei lavorare solo con quelle locali?**

Utilizza i dati effettivi quando hai bisogno del risultato “come renderizzato” dopo che tutta l'ereditarietà è stata applicata, ad esempio per allineare colori, rientri o dimensioni. Se devi conservare tali valori indipendentemente dalle modifiche di formattazione successive, copia le proprietà necessarie nel tuo oggetto. Se devi modificare la formattazione a un livello specifico, modifica le proprietà locali e poi, se necessario, leggi nuovamente i dati effettivi per verificare il risultato.