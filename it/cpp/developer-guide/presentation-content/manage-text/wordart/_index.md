---
title: Crea e Applica Effetti WordArt in C++
linktitle: WordArt
type: docs
weight: 110
url: /it/cpp/wordart/
keywords:
- WordArt
- crea WordArt
- modello WordArt
- effetto WordArt
- effetto ombra
- effetto visualizzazione
- effetto bagliore
- trasformazione WordArt
- effetto 3D
- effetto ombra esterna
- effetto ombra interna
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Crea e personalizza gli effetti WordArt in Aspose.Slides per C++. Questa guida passo-passo aiuta gli sviluppatori a migliorare le presentazioni con testo professionale in C++."
---
## **Panoramica**

Gli effetti WordArt consentono di aggiungere testo stilizzato e visivamente accattivante alle presentazioni PowerPoint. Con Aspose.Slides, gli sviluppatori possono creare, personalizzare e gestire WordArt programmaticamente proprio come in Microsoft PowerPoint, senza la necessità di avere Office installato. Questo articolo fornisce una panoramica sul lavoro con WordArt, inclusa l’applicazione di trasformazioni del testo, stili di riempimento, contorni, ombre e altre opzioni di formattazione per rendere il contenuto della presentazione più espressivo e coinvolgente. WordArt permette di trattare il testo come un oggetto grafico. Consiste in effetti o modifiche speciali applicate al testo per renderlo più attraente o evidente.

## **Creare un modello WordArt semplice e applicarlo al testo**

**Utilizzando Aspose.Slides** 

Per prima cosa, creiamo un semplice testo con questo codice C++: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Ora impostiamo l’altezza del carattere del testo a un valore più grande per rendere l’effetto più evidente con questo codice:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Utilizzando Microsoft PowerPoint**

Accedi al menu degli effetti WordArt in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Dal pannello a destra puoi scegliere un effetto WordArt predefinito. Dal pannello a sinistra puoi specificare le impostazioni per un nuovo WordArt. 

Questi sono alcuni dei parametri o opzioni disponibili:

![todo:image_alt_text](image-20200930114015-3.png)

**Utilizzando Aspose.Slides**

Qui applichiamo il colore pattern SmallGrid al testo e aggiungiamo un contorno nero di larghezza 1 usando questo codice:

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

Il testo risultante:

![todo:image_alt_text](image-20200930114108-4.png)

## **Applicare altri effetti WordArt**

**Utilizzando Microsoft PowerPoint**

Dall’interfaccia del programma, puoi applicare questi effetti a un testo, blocco di testo, forma o elemento simile:

![todo:image_alt_text](image-20200930114129-5.png)

Ad esempio, gli effetti Ombra, Riflesso e Bagliore possono essere applicati a un testo; gli effetti Formato 3D e Rotazione 3D possono essere applicati a un blocco di testo; la proprietà Bordi morbidi può essere applicata a un oggetto Forma (ha comunque effetto anche quando non è impostato alcun Formato 3D). 

### **Applicare effetti Ombra al testo**

Qui intendiamo impostare le proprietà relative solo al testo. Applichiamo l’effetto ombra al testo con questo codice C++:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

L’API Aspose.Slides supporta tre tipi di ombra: OuterShadow, InnerShadow e PresetShadow. 

Con PresetShadow, puoi applicare un’ombra al testo (usando valori predefiniti). 

**Utilizzando Microsoft PowerPoint**

In PowerPoint è disponibile un solo tipo di ombra. Ecco un esempio:

![todo:image_alt_text](image-20200930114225-6.png)

**Utilizzando Aspose.Slides**

Aspose.Slides consente effettivamente di applicare due tipi di ombra contemporaneamente: InnerShadow e PresetShadow.

**Note:**

- Quando OuterShadow e PresetShadow sono usati insieme, viene applicato solo l’effetto OuterShadow. 
- Se OuterShadow e InnerShadow vengono utilizzati simultaneamente, l’effetto risultante dipende dalla versione di PowerPoint. Per esempio, in PowerPoint 2013 l’effetto viene raddoppiato. In PowerPoint 2007, viene applicato l’effetto OuterShadow. 

### **Applicare effetti Riflesso**

Aggiungiamo un riflesso al testo con questo esempio di codice C++:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### **Applicare effetti Bagliore**

Applichiamo l’effetto bagliore al testo per farlo risplendere o risaltare con questo codice:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Il risultato dell’operazione:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Puoi modificare i parametri per ombra, visualizzazione e bagliore. Le proprietà degli effetti vengono impostate separatamente su ciascuna porzione di testo. 

{{% /alert %}} 

### **Utilizzare le trasformazioni in WordArt**

Usiamo il metodo set_Transform (applicato all’intero blocco di testo) con questo codice:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Il risultato:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sia Microsoft PowerPoint sia Aspose.Slides per C++ forniscono un certo numero di tipi di trasformazione predefiniti. 

{{% /alert %}} 

**Utilizzando PowerPoint**

Per accedere ai tipi di trasformazione predefiniti, vai su: **Formato** -> **EffettoTesto** -> **Trasforma**

**Utilizzando Aspose.Slides**

Per selezionare un tipo di trasformazione, usa l’enumerazione TextShapeType. 

### **Applicare effetti 3D a testo e forme**

Impostiamo un effetto 3D su una forma di testo con questo codice di esempio:

``` cpp 
auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Il testo e la sua forma risultanti:

![todo:image_alt_text](image-20200930114816-9.png)

Applichiamo un effetto 3D al testo con questo codice C++:

``` cpp 
auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Il risultato dell’operazione:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

L’applicazione di effetti 3D a testi o alle loro forme e le interazioni tra gli effetti sono basate su regole specifiche. 

Considera una scena per il testo e la forma che contiene quel testo. L’effetto 3D comprende la rappresentazione dell’oggetto 3D e la scena su cui l’oggetto è posizionato. 

- Quando la scena è impostata sia per la figura sia per il testo, la scena della figura ha priorità più alta—la scena del testo viene ignorata. 
- Quando la figura non ha una propria scena ma ha una rappresentazione 3D, viene usata la scena del testo. 
- Altrimenti—quando la forma originariamente non ha effetto 3D—la forma è piatta e l’effetto 3D viene applicato solo al testo. 

Queste descrizioni sono collegate ai metodi ThreeDFormat.getLightRig() e ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Applicare effetti Outer Shadow alle forme**
Aspose.Slides per C++ fornisce le classi [**IOuterShadow**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.effects.i_outer_shadow) e [**IInnerShadow**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.effects.i_inner_shadow) che consentono di applicare effetti ombra a un testo contenuto in TextFrame. Segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).  
2. Ottieni il riferimento di una diapositiva usando il suo indice.  
3. Aggiungi un AutoShape di tipo Rettangolo alla diapositiva.  
4. Accedi al TextFrame associato all’AutoShape.  
5. Imposta FillType dell’AutoShape su NoFill.  
6. Instanzia la classe OuterShadow.  
7. Imposta BlurRadius dell’ombra.  
8. Imposta Direction dell’ombra.  
9. Imposta Distance dell’ombra.  
10. Imposta RectanglelAlign su TopLeft.  
11. Imposta PresetColor dell’ombra su Black.  
12. Salva la presentazione in formato PPTX.  

Questo codice di esempio in C++—un’implementazione dei passaggi sopra—mostra come applicare l’effetto outer shadow a un testo:

``` cpp
auto pres = System::MakeObject<Presentation>();
// Ottieni il riferimento della diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Aggiungi un AutoShape di tipo Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Aggiungi TextFrame al Rectangle
ashp->AddTextFrame(u"Aspose TextBox");

// Disabilita il riempimento della forma nel caso volessi ottenere l'ombra del testo
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Aggiungi ombra esterna e imposta tutti i parametri necessari
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Salva la presentazione su disco
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **Applicare effetti Inner Shadow alle forme**
Segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).  
2. Ottieni il riferimento della diapositiva.  
3. Aggiungi un AutoShape di tipo Rettangolo.  
4. Abilita InnerShadowEffect.  
5. Imposta tutti i parametri necessari.  
6. Imposta ColorType su Scheme.  
7. Imposta lo Scheme Color.  
8. Salva la presentazione in un file [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Questo codice di esempio (basato sui passaggi precedenti) mostra come aggiungere un connettore tra due forme in C++:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Ottieni il riferimento di una diapositiva
auto slide = presentation->get_Slides()->idx_get(0);

// Aggiungi un AutoShape di tipo Rectangle
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Aggiungi TextFrame al Rectangle
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Abilita InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Imposta tutti i parametri necessari
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Imposta ColorType su Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Imposta il colore Scheme
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Salva la presentazione
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso utilizzare gli effetti WordArt con diversi caratteri o script (ad es. arabo, cinese)?**

Sì, Aspose.Slides supporta Unicode e funziona con tutti i principali caratteri e script. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, anche se la disponibilità del font e il rendering dipendono dai font di sistema.

**Posso applicare gli effetti WordArt agli elementi del master della diapositiva?**

Sì, è possibile applicare gli effetti WordArt a forme nei master slide, inclusi i segnaposto titolo, i piè di pagina o il testo di sfondo. Le modifiche apportate al layout master si rifletteranno su tutte le diapositive associate.

**Gli effetti WordArt influenzano le dimensioni del file della presentazione?**

Leggermente. Effetti come ombre, bagliori e riempimenti sfumati possono aumentare marginalmente la dimensione del file a causa dei metadati di formattazione aggiunti, ma la differenza è solitamente trascurabile.

**Posso visualizzare in anteprima il risultato degli effetti WordArt senza salvare la presentazione?**

Sì, è possibile renderizzare le diapositive contenenti WordArt in immagini (ad es. PNG, JPEG) usando il metodo `GetImage` delle interfacce [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) o [ISlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/). Questo consente di visualizzare l’anteprima in memoria o a schermo prima di salvare o esportare l’intera presentazione.