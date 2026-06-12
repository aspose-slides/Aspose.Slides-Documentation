---
title: Crea e Applica Effetti WordArt in Python
linktitle: WordArt
type: docs
weight: 110
url: /it/python-net/wordart/
keywords:
- WordArt
- creare WordArt
- modello WordArt
- effetto WordArt
- effetto ombra
- effetto visualizzazione
- effetto bagliore
- trasformazione WordArt
- effetto 3D
- effetto ombra esterna
- effetto ombra interna
- Python
- Aspose.Slides
description: "Impara a creare e personalizzare gli effetti WordArt in Aspose.Slides per Python via .NET. Questa guida passo passo aiuta gli sviluppatori a migliorare le presentazioni con testo elegante e professionale in Python."
---
## **Panoramica**

Gli effetti WordArt consentono di aggiungere testo stilizzato e visivamente accattivante alle presentazioni PowerPoint. Con Aspose.Slides, gli sviluppatori possono creare, personalizzare e gestire WordArt in modo programmatico proprio come in Microsoft PowerPoint, senza la necessità di avere Office installato. Questo articolo fornisce una panoramica sull'utilizzo di WordArt, includendo come applicare trasformazioni del testo, stili di riempimento, contorni, ombre e altre opzioni di formattazione per rendere il contenuto della presentazione più espressivo e coinvolgente. WordArt consente di trattare il testo come un oggetto grafico. È costituito da effetti o modifiche speciali applicate al testo per renderlo più attraente o evidente.

**WordArt in Microsoft PowerPoint**

Per utilizzare WordArt in Microsoft PowerPoint, è necessario selezionare uno dei modelli WordArt predefiniti. Un modello WordArt è un insieme di effetti che viene applicato a un testo o alla sua forma.

**WordArt in Aspose.Slides**

In Aspose.Slides for Python via .NET 20.10, abbiamo implementato il supporto per WordArt e apportato miglioramenti alla funzionalità nelle versioni successive di Aspose.Slides for Python via .NET.  
Con Aspose.Slides for Python via .NET, è possibile creare facilmente il proprio modello WordArt (un effetto o una combinazione di effetti) in Python e applicarlo ai testi.

## Creare un modello WordArt semplice e applicarlo a un testo

**Utilizzare Aspose.Slides**  

Innanzitutto, creiamo un semplice testo utilizzando questo codice Python:  

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```  
Ora, impostiamo l'altezza del carattere del testo a un valore più grande per rendere l'effetto più evidente tramite questo codice:  

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Utilizzare Microsoft PowerPoint**  

Vai al menu degli effetti WordArt in Microsoft PowerPoint:  

![todo:image_alt_text](image-20200930113926-1.png)  

Dal menu a destra, è possibile scegliere un effetto WordArt predefinito. Dal menu a sinistra, è possibile specificare le impostazioni per un nuovo WordArt.  

Questi sono alcuni dei parametri o opzioni disponibili:  

![todo:image_alt_text](image-20200930114015-3.png)  

**Utilizzare Aspose.Slides**  

Qui, applichiamo il colore del motivo SmallGrid al testo e aggiungiamo un bordo testuale nero di larghezza 1 utilizzando questo codice:  

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```  

Il testo risultante:  

![todo:image_alt_text](image-20200930114108-4.png)

## Applicare altri effetti WordArt

**Utilizzare Microsoft PowerPoint**  

Dall'interfaccia del programma, è possibile applicare questi effetti a un testo, un blocco di testo, una forma o a un elemento simile:  

![todo:image_alt_text](image-20200930114129-5.png)  

Ad esempio, gli effetti Ombra, Riflesso e Bagliore possono essere applicati a un testo; gli effetti Formato 3D e Rotazione 3D possono essere applicati a un blocco di testo; la proprietà Bordi morbidi può essere applicata a un oggetto Forma (ha comunque un effetto anche quando non è impostata alcuna proprietà Formato 3D).

### Applicare effetti Ombra

Qui, intendiamo impostare le proprietà relative solo a un testo. Applichiamo l'effetto ombra a un testo usando questo codice in Python:  

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```  

L'API Aspose.Slides supporta tre tipi di ombre: OuterShadow, InnerShadow e PresetShadow.  

Con PresetShadow, è possibile applicare un'ombra a un testo (usando valori predefiniti).  

**Utilizzare Microsoft PowerPoint**  

In PowerPoint, è possibile utilizzare un tipo di ombra. Ecco un esempio:  

![todo:image_alt_text](image-20200930114225-6.png)  

**Utilizzare Aspose.Slides**  

Aspose.Slides consente effettivamente di applicare due tipi di ombre simultaneamente: InnerShadow e PresetShadow.  

**Note:**  

- Quando OuterShadow e PresetShadow sono usati insieme, viene applicato solo l'effetto OuterShadow.  
- Se OuterShadow e InnerShadow vengono usati simultaneamente, l'effetto risultante o applicato dipende dalla versione di PowerPoint. Ad esempio, in PowerPoint 2013 l'effetto viene raddoppiato. Ma in PowerPoint 2007 viene applicato l'effetto OuterShadow.  

### Applicare la visualizzazione ai testi

Aggiungiamo la visualizzazione al testo tramite questo esempio di codice in Python:  

```py 
    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5 
    portion.portion_format.effect_format.reflection_effect.distance = 4.72 
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0 
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90 
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100 
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT  
```

### Applicare effetto Bagliore ai testi

Applichiamo l'effetto bagliore al testo per farlo brillare o risaltare usando questo codice:  

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```  

Il risultato dell'operazione:  

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}}  
È possibile modificare i parametri per ombra, visualizzazione e bagliore. Le proprietà degli effetti vengono impostate su ciascuna porzione del testo separatamente.  
{{% /alert %}}  

### Utilizzare le trasformazioni in WordArt

Utilizziamo la proprietà Transform (intrinseca a tutto il blocco di testo) con questo codice:  
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```  

Il risultato:  

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}}  
Sia Microsoft PowerPoint sia Aspose.Slides for Python via .NET offrono un certo numero di tipologie di trasformazione predefinite.  
{{% /alert %}}  

**Utilizzare PowerPoint**  

Per accedere alle tipologie di trasformazione predefinite, navigare tramite: **Formato** -> **EffettoTesto** -> **Trasforma**  

**Utilizzare Aspose.Slides**  

Per selezionare una tipologia di trasformazione, utilizzare l'enumerazione TextShapeType.  

### Applicare effetti 3D a testi e forme

Impostiamo un effetto 3D a una forma testuale usando questo codice di esempio:  

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```  

Il testo risultante e la sua forma:  

![todo:image_alt_text](image-20200930114816-9.png)  

Applichiamo un effetto 3D al testo con questo codice Python:  

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```  

Il risultato dell'operazione:  

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}}  
L'applicazione di effetti 3D a testi o alle loro forme e le interazioni tra gli effetti si basano su determinate regole.  

Considera una scena per un testo e la forma che contiene quel testo. L'effetto 3D contiene la rappresentazione dell'oggetto 3D e la scena su cui l'oggetto è stato posizionato.  

- Quando la scena è impostata sia per la figura sia per il testo, la scena della figura ha la priorità più alta — la scena del testo viene ignorata.  
- Quando la figura non ha una sua scena ma possiede una rappresentazione 3D, viene utilizzata la scena del testo.  
- Altrimenti — quando la forma originariamente non ha alcun effetto 3D — la forma è piatta e l'effetto 3D viene applicato solo al testo.  

Le descrizioni sono collegate alle proprietà [ThreeDFormat.LightRig](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/) e [ThreeDFormat.Camera](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/).  
{{% /alert %}}  

## **Applicare effetti Ombra Esterna ai testi**
Aspose.Slides for Python via .NET fornisce le classi [**IOuterShadow**](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/ioutershadow/) e [**IInnerShadow**](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/iinnershadow/) che consentono di applicare effetti ombra a un testo contenuto in TextFrame. Segui questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).  
2. Ottenere il riferimento di una diapositiva utilizzando il suo indice.  
3. Aggiungere un AutoShape di tipo Rettangolo alla diapositiva.  
4. Accedere al TextFrame associato all'AutoShape.  
5. Impostare il FillType dell'AutoShape su NoFill.  
6. Istantiare la classe OuterShadow  
7. Impostare il BlurRadius dell'ombra.  
8. Impostare la Direction dell'ombra  
9. Impostare la Distance dell'ombra.  
10. Impostare il RectanglelAlign su TopLeft.  
11. Impostare il PresetColor dell'ombra su Black.  
12. Salvare la presentazione come file PPTX.  

Questo esempio di codice in Python—un'implementazione dei passaggi sopra—mostra come applicare l'effetto ombra esterna a un testo:  

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Ottieni il riferimento della diapositiva
    sld = pres.slides[0]

    # Aggiungi un AutoShape di tipo Rettangolo
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Aggiungi TextFrame al Rettangolo
    ashp.add_text_frame("Aspose TextBox")

    # Disabilita il riempimento della forma nel caso si voglia ottenere l'ombra del testo
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Aggiungi ombra esterna e imposta tutti i parametri necessari
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Scrivi la presentazione su disco
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Applicare effetto Ombra Interna alle forme**
Segui questi passaggi:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).  
2. Ottenere un riferimento della diapositiva.  
3. Aggiungere un AutoShape di tipo Rettangolo.  
4. Abilitare InnerShadowEffect.  
5. Impostare tutti i parametri necessari.  
6. Impostare il ColorType su Scheme.  
7. Impostare il colore Scheme.  
8. Salvare la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Questo esempio di codice (basato sui passaggi precedenti) mostra come aggiungere un connettore tra due forme in Python:  

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Ottieni il riferimento di una diapositiva
    slide = presentation.slides[0]

    # Aggiungi un AutoShape di tipo Rettangolo
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Aggiungi TextFrame al Rettangolo
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Abilita inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Imposta tutti i parametri necessari
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Imposta ColorType come Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Imposta il colore Scheme
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Salva la presentazione
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso usare gli effetti WordArt con diversi font o script (ad es., arabo, cinese)?**  
Sì, Aspose.Slides supporta Unicode e funziona con tutti i principali font e script. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, sebbene la disponibilità dei font e il rendering possano dipendere dai font di sistema.

**Posso applicare gli effetti WordArt agli elementi del master della diapositiva?**  
Sì, è possibile applicare gli effetti WordArt alle forme nei master delle diapositive, inclusi segnaposto titoli, piè di pagina o testo di sfondo. Le modifiche apportate al layout master verranno riflesse su tutte le diapositive associate.

**Gli effetti WordArt influiscono sulla dimensione del file della presentazione?**  
Leggermente. Effetti come ombre, bagliori e riempimenti sfumati possono aumentare marginalmente la dimensione del file a causa dei metadati di formattazione aggiunti, ma la differenza è solitamente trascurabile.

**Posso visualizzare in anteprima il risultato degli effetti WordArt senza salvare la presentazione?**  
Sì, è possibile renderizzare le diapositive contenenti WordArt in immagini (ad es., PNG, JPEG) utilizzando il metodo `get_image` dalle classi [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) o [Slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/). Questo consente di visualizzare in anteprima il risultato in memoria o sullo schermo prima di salvare o esportare l'intera presentazione.