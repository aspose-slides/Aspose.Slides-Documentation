---
title: Gestisci i temi di presentazione in C++
linktitle: Tema della presentazione
type: docs
weight: 10
url: /it/cpp/presentation-theme/
keywords:
- Tema PowerPoint
- Tema della presentazione
- Tema della diapositiva
- Imposta tema
- Cambia tema
- Gestisci tema
- Colore del tema
- Palette aggiuntiva
- Carattere del tema
- Stile del tema
- Effetto del tema
- PowerPoint
- OpenDocument
- Presentazione
- C++
- Aspose.Slides
description: "Gestisci i temi di presentazione in Aspose.Slides per C++ per creare, personalizzare e convertire file PowerPoint con un branding coerente."
---
## **Introduzione**

Un tema di presentazione definisce le proprietà degli elementi di design. Quando selezioni un tema di presentazione, scegli essenzialmente un insieme specifico di elementi visivi e le loro proprietà.

In PowerPoint, un tema comprende colori, [fonts](/slides/it/cpp/powerpoint-fonts/), [background styles](/slides/it/cpp/presentation-background/), ed effetti.

![theme-constituents](theme-constituents.png)

## **Modifica colore del tema**

Un tema di PowerPoint utilizza un insieme specifico di colori per i diversi elementi di una diapositiva. Se i colori non ti piacciono, li cambi applicando nuovi colori al tema. Per consentirti di selezionare un nuovo colore del tema, Aspose.Slides fornisce valori nell'enumerazione [SchemeColor](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Questo codice C++ mostra come modificare il colore accentato per un tema:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Puoi determinare il valore effettivo del colore risultante in questo modo:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Colore [A=255, R=128, G=100, B=162])
```

Per dimostrare ulteriormente l'operazione di modifica del colore, creiamo un altro elemento e gli assegniamo il colore accentato (dall'operazione iniziale). Quindi cambiamo il colore nel tema:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

Il nuovo colore viene applicato automaticamente su entrambi gli elementi.

### **Imposta colore del tema da una palette aggiuntiva**

Quando applichi trasformazioni di luminanza al colore principale del tema(1), si formano i colori dalla palette aggiuntiva(2). Puoi quindi impostare e ottenere tali colori del tema.

![additional-palette-colors](additional-palette-colors.png)

**1**- Colori principali del tema  
**2**- Colori dalla palette aggiuntiva.

Questo codice C++ dimostra un'operazione in cui i colori della palette aggiuntiva vengono ottenuti dal colore principale del tema e poi utilizzati nelle forme:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accento 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accento 4, più chiaro 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accento 4, più chiaro 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accento 4, più chiaro 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accento 4, più scuro 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accento 4, più scuro 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **Mappa `SchemeColor` ai colori `IColorScheme`**

Quando lavori con [SchemeColor](https://reference.aspose.com/slides/it/cpp/aspose.slides/schemecolor/), potresti notare che contiene i seguenti valori di colore del tema:

`Background1`, `Background2`, `Text1` e `Text2`.

Tuttavia, `Presentation::get_MasterTheme()::get_ColorScheme()` restituisce [IColorScheme](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/icolorscheme/), che espone i colori corrispondenti come:

`Dark1`, `Dark2`, `Light1` e `Light2`.

Questa differenza è solo di denominazione. Questi valori si riferiscono alle stesse posizioni di colore del tema e la mappatura è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Non esiste una conversione dinamica tra `Text`/`Background` e `Dark`/`Light`. Sono semplicemente nomi alternativi per gli stessi colori del tema.

Questa differenza di denominazione proviene dalla terminologia di Microsoft Office. Le versioni precedenti di Office usavano `Dark 1`, `Light 1`, `Dark 2` e `Light 2`, mentre le versioni UI più recenti mostrano le stesse posizioni come `Text 1`, `Background 1`, `Text 2` e `Background 2`.

## **Modifica carattere del tema**

Per consentirti di selezionare i caratteri per i temi e altri scopi, Aspose.Slides utilizza questi identificatori speciali (simili a quelli usati in PowerPoint):

* **+mn-lt** - Carattere corpo Latin (Minor Latin Font)
* **+mj-lt** - Carattere intestazione Latin (Major Latin Font)
* **+mn-ea** - Carattere corpo East Asian (Minor East Asian Font)
* **+mj-ea** - Carattere corpo East Asian (Major East Asian Font)

Questo codice C++ mostra come assegnare il carattere Latin a un elemento del tema:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Questo codice C++ mostra come modificare il carattere del tema della presentazione:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

Il carattere in tutte le caselle di testo verrà aggiornato.

{{% alert color="primary" title="TIP" %}} 
Potresti voler vedere [PowerPoint fonts](/slides/it/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Modifica stile di sfondo del tema**

Per impostazione predefinita, l'app PowerPoint fornisce 12 sfondi predefiniti ma solo 3 di questi 12 sfondi vengono salvati in una presentazione tipica.

![todo:image_alt_text](presentation-design_8.png)

Ad esempio, dopo aver salvato una presentazione nell'app PowerPoint, puoi eseguire questo codice C++ per scoprire il numero di sfondi predefiniti nella presentazione:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
Utilizzando la proprietà [BackgroundFillStyles](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) dalla classe [FormatScheme](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.theme.i_format_scheme/), è possibile aggiungere o accedere allo stile di sfondo in un tema PowerPoint. 
{{% /alert %}}

Questo codice C++ mostra come impostare lo sfondo per una presentazione:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Guida agli indici**: 0 è usato per nessuna riempimento. L'indice inizia da 1.

{{% alert color="primary" title="TIP" %}} 
Potresti voler vedere [PowerPoint Background](/slides/it/cpp/presentation-background/).
{{% /alert %}}

## **Modifica effetto del tema**

Un tema PowerPoint di solito contiene 3 valori per ciascun array di stile. Quegli array vengono combinati in questi 3 effetti: sottile, moderato e intenso. Ad esempio, questo è il risultato quando gli effetti vengono applicati a una forma specifica:

![todo:image_alt_text](presentation-design_10.png)

Utilizzando 3 proprietà ([FillStyles](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) dalla classe [FormatScheme](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.theme.i_format_scheme/) è possibile modificare gli elementi in un tema (ancora più flessibilmente rispetto alle opzioni in PowerPoint).

Questo codice C++ mostra come modificare un effetto del tema alterando parti degli elementi:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

Le modifiche risultanti nel colore di riempimento, tipo di riempimento, effetto ombra, ecc:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Posso applicare un tema a una singola diapositiva senza modificare il master?**

Sì. Aspose.Slides supporta le sovrascritture di tema a livello di diapositiva, quindi puoi applicare un tema locale solo a quella diapositiva mantenendo intatto il tema master (tramite il [SlideThemeManager](https://reference.aspose.com/slides/it/cpp/aspose.slides.theme/slidethememanager/)).

**Qual è il modo più sicuro per trasferire un tema da una presentazione all'altra?**

[Clone slides](/slides/it/cpp/clone-slides/) insieme al loro master nella presentazione di destinazione. Questo preserva il master originale, i layout e il tema associato in modo che l'aspetto rimanga coerente.

**Come posso vedere i valori "effettivi" dopo tutta l'ereditarietà e le sovrascritture?**

Utilizza le ["effective" views](/slides/it/cpp/shape-effective-properties/) dell'API per tema/colore/carattere/effetto. Queste restituiscono le proprietà risolte e finali dopo l'applicazione del master più eventuali sovrascritture locali.