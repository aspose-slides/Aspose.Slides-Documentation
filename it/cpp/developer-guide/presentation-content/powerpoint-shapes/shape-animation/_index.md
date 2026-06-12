---
title: Applicare animazioni di forme nelle presentazioni con C++
linktitle: Animazione Forma
type: docs
weight: 60
url: /it/cpp/shape-animation/
keywords:
- forma
- animazione
- effetto
- forma animata
- testo animato
- aggiungi animazione
- ottieni animazione
- estrai animazione
- aggiungi effetto
- ottieni effetto
- estrai effetto
- suono effetto
- applica animazione
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come creare e personalizzare animazioni di forme nelle presentazioni PowerPoint con Aspose.Slides per C++. Fatti notare!"
---
## **Introduzione**

Le animazioni sono effetti visivi che possono essere applicati a testi, immagini, forme o [grafici](/slides/it/cpp/animated-charts/). Danno vita alle presentazioni o ai loro componenti. 

## **Perché usare le animazioni nelle presentazioni?**

Usando le animazioni, è possibile:

* controllare il flusso di informazioni
* evidenziare i punti importanti
* aumentare l'interesse o la partecipazione del pubblico
* rendere il contenuto più facile da leggere, assimilare o elaborare
* attirare l'attenzione dei lettori o spettatori verso le parti importanti di una presentazione

PowerPoint fornisce molte opzioni e strumenti per animazioni ed effetti di animazione nelle categorie **entrata**, **uscita**, **enfasi** e **percorsi di movimento**. 

## **Animazioni in Aspose.Slides**

* Aspose.Slides fornisce le classi e i tipi necessari per lavorare con le animazioni nello spazio dei nomi [Aspose.Slides.Animation](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.animation).
* Aspose.Slides fornisce oltre **150 effetti di animazione** nello spazio dei nomi [EffectType](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Questi effetti sono sostanzialmente gli stessi (o equivalenti) effetti utilizzati in PowerPoint.

## **Applicare un'animazione a una TextBox**

Aspose.Slides per C++ consente di applicare animazioni al testo in una forma. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un `rectangle` [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape).
4. Aggiungi testo a [IAutoShape.TextFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Ottieni la sequenza principale di effetti.
6. Aggiungi un effetto di animazione a [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape).
7. Imposta la proprietà [TextAnimation.BuildType](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) sul valore dell'[enumerazione BuildType](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Scrivi la presentazione su disco come file PPTX.

Questo codice C++ mostra come applicare l'effetto `Fade` a AutoShape e impostare l'animazione del testo al valore *By 1st Level Paragraphs*:

```c++
// Istanzia una classe Presentation che rappresenta un file di presentazione.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Aggiunge una nuova AutoShape con testo
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Ottiene la sequenza principale della diapositiva.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Aggiunge l'effetto di animazione Fade alla forma
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Anima il testo della forma per paragrafi di primo livello
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Salva il file PPTX su disco
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 
Oltre ad applicare animazioni al testo, è possibile applicare animazioni a un singolo [Paragraph](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_paragraph). Vedi [**Animated Text**](/slides/it/cpp/animated-text/).
{{% /alert %}} 

## **Applicare un'animazione a un PictureFrame**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Aggiungi o ottieni un [PictureFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_picture_frame) sulla diapositiva. 
4. Ottieni la sequenza principale di effetti.
5. Aggiungi un effetto di animazione al [PictureFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_picture_frame).
6. Scrivi la presentazione su disco come file PPTX.

Questo codice C++ mostra come applicare l'effetto `Fly` a un picture frame:

```c++
// Istanzia una classe Presentation che rappresenta un file di presentazione.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Carica l'immagine da aggiungere alla raccolta di immagini della presentazione
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Aggiunge un frame immagine alla diapositiva
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Ottiene la sequenza principale della diapositiva.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Aggiunge l'effetto di animazione Fly da sinistra al frame immagine
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Salva il file PPTX su disco
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Applicare un'animazione a una Shape**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un `rectangle` [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape). 
4. Aggiungi un `Bevel` [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape) (quando questo oggetto viene cliccato, l'animazione viene riprodotta).
5. Crea una sequenza di effetti sulla forma bevel.
6. Crea un `UserPath` personalizzato.
7. Aggiungi comandi per lo spostamento al `UserPath`.
8. Scrivi la presentazione su disco come file PPTX.

Questo codice C++ mostra come applicare l'effetto `PathFootball` (percorso football) a una forma:

```c++
	// Il percorso alla directory dei documenti.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carica la presentazione
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accede alla prima diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accede alla raccolta di forme per la diapositiva selezionata
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Crea l'effetto PathFootball per la forma esistente da zero.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Aggiunge l'effetto di animazione PathFootball
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Crea una sorta di "pulsante".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Crea una sequenza di effetti per questo pulsante.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Crea un percorso utente personalizzato. Il nostro oggetto verrà spostato solo dopo che il pulsante è stato cliccato.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Aggiunge comandi di movimento poiché il percorso creato è vuoto.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // Scrive il file PPTX su disco
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ottenere gli effetti di animazione applicati a una Shape**

Gli esempi seguenti mostrano come utilizzare il metodo `GetEffectsByShape` dell'interfaccia [ISequence](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/isequence/) per ottenere tutti gli effetti di animazione applicati a una forma.

**Esempio 1: Ottenere gli effetti di animazione applicati a una forma su una diapositiva normale**

In precedenza hai imparato come aggiungere effetti di animazione alle forme nelle presentazioni PowerPoint. Il codice di esempio seguente mostra come ottenere gli effetti applicati alla prima forma sulla prima diapositiva normale nella presentazione `AnimExample_out.pptx`.

```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Gets the main animation sequence of the slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on the first slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Gets animation effects applied to the shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Esempio 2: Ottenere tutti gli effetti di animazione, inclusi quelli ereditati dai segnaposto**

Se una forma su una diapositiva normale ha segnaposti che si trovano nella diapositiva layout e/o master, e a questi segnaposti sono stati aggiunti effetti di animazione, tutti gli effetti della forma verranno riprodotti durante la presentazione, inclusi quelli ereditati.

Supponiamo di avere un file PowerPoint `sample.pptx` con una diapositiva contenente solo una forma footer con il testo "Made with Aspose.Slides" e l'effetto **Random Bars** applicato alla forma.

![Effetto di animazione della forma della diapositiva](slide-shape-animation.png)

Supponiamo inoltre che l'effetto **Split** sia applicato al segnaposto footer nella diapositiva **layout**.

![Effetto di animazione della forma layout](layout-shape-animation.png)

Infine, l'effetto **Fly In** è applicato al segnaposto footer nella diapositiva **master**.

![Effetto di animazione della forma master](master-shape-animation.png)

Il codice di esempio seguente mostra come utilizzare il metodo `GetBasePlaceholder` dell'interfaccia [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) per accedere ai segnaposto della forma e ottenere gli effetti di animazione applicati alla forma footer, inclusi quelli ereditati dai segnaposto situati su layout e master.

```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```
```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Get animation effects of the shape on the normal slide.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Vola, Basso
Type: 134, subtype: 45            // Dividi, Entrata verticale
Type: 126, subtype: 22            // Barre casuali, Orizzontale
```

## **Modificare le proprietà di timing dell'effetto di animazione**

Aspose.Slides per C++ consente di modificare le proprietà di Timing di un effetto di animazione.

Questa è il pannello Timing dell'animazione in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Queste sono le corrispondenze tra il Timing di PowerPoint e le proprietà [Effect.Timing](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- Il menu a discesa **Start** del Timing di PowerPoint corrisponde alla proprietà [Effect.Timing.TriggerType](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- **Duration** del Timing di PowerPoint corrisponde alla proprietà [Effect.Timing.Duration](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). La durata di un'animazione (in secondi) è il tempo totale necessario per completare un ciclo. 
- **Delay** del Timing di PowerPoint corrisponde alla proprietà [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Ecco come modificare le proprietà di Timing dell'effetto:

1. [Applica](#apply-animation-to-shape) o ottieni l'effetto di animazione.
2. Imposta i nuovi valori per le proprietà [Effect.Timing](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) necessarie. 
3. Salva il file PPTX modificato.

Questo codice C++ dimostra l'operazione:

```c++
// Istanzia una classe Presentation che rappresenta un file di presentazione.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Ottiene la sequenza principale della diapositiva.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Ottiene il primo effetto della sequenza principale.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Cambia il TriggerType dell'effetto per avviarlo al clic
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Cambia la durata dell'effetto
effect->get_Timing()->set_Duration(3.f);

// Cambia il TriggerDelayTime dell'effetto
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Salva il file PPTX su disco
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Suono dell'effetto di animazione**

Aspose.Slides fornisce queste proprietà per gestire i suoni negli effetti di animazione: 

- [set_Sound()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Aggiungere un suono a un effetto di animazione**

Questo codice C++ mostra come aggiungere un suono a un effetto di animazione e fermarlo quando inizia il prossimo effetto:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Aggiunge audio alla collezione audio della presentazione
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ottiene la sequenza principale della diapositiva.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Ottiene il primo effetto della sequenza principale
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Controlla l'effetto per "Nessun suono"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Aggiunge suono al primo effetto
    firstEffect->set_Sound(effectSound);
}

// Ottiene la prima sequenza interattiva della diapositiva.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Imposta il flag "Interrompi suono precedente" dell'effetto
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Scrive il file PPTX su disco
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Estrarre un suono da un effetto di animazione**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice. 
3. Ottieni la sequenza principale di effetti. 
4. Estrai il metodo [set_Sound()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effect/set_sound/) incorporato in ciascun effetto di animazione. 

Questo codice C++ mostra come estrarre il suono incorporato in un effetto di animazione:

```c++
// Istanzia una classe Presentation che rappresenta un file di presentazione.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Ottiene la sequenza principale della diapositiva.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **After Animation**

Aspose.Slides per C++ consente di modificare la proprietà After animation di un effetto di animazione.

Questo è il pannello dell'effetto di animazione e il menu esteso in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

L'elenco a discesa **After animation** del pannello Effetto di PowerPoint corrisponde a queste proprietà: 

- La proprietà [set_AfterAnimationType()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) che descrive il tipo di After animation:
  * **More Colors** di PowerPoint corrisponde al tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/);
  * **Don't Dim** di PowerPoint corrisponde al tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/) (tipo predefinito);
  * **Hide After Animation** di PowerPoint corrisponde al tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/);
  * **Hide on Next Mouse Click** di PowerPoint corrisponde al tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/);
- La proprietà [set_AfterAnimationColor()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) che definisce il formato colore After animation. Questa proprietà funziona in combinazione con il tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/). Se cambiate il tipo, il colore After animation verrà cancellato.

Questo codice C++ mostra come modificare un effetto After animation:

```c++
// Istanzia una classe Presentation che rappresenta un file di presentazione
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ottiene il primo effetto della sequenza principale
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Cambia il tipo di after animation a Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Imposta il colore di attenuazione after animation
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Scrive il file PPTX su disco
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animare il testo**

Aspose.Slides fornisce queste proprietà per gestire il blocco *Animate text* di un effetto di animazione:

- [set_AnimateTextType()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) che descrive il tipo di animazione del testo dell'effetto. Il testo della forma può essere animato:
  - Tutto in una volta ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/animatetexttype/) type)
  - Per parola ([AnimateTextType.ByWord](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/animatetexttype/) type)
  - Per lettera ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/animatetexttype/) type)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) imposta un ritardo tra le parti di testo animate (parole o lettere). Un valore positivo specifica la percentuale della durata dell'effetto. Un valore negativo specifica il ritardo in secondi.

Ecco come è possibile modificare le proprietà Animate text dell'effetto:

1. [Applica](#apply-animation-to-shape) o ottieni l'effetto di animazione.
2. Imposta la proprietà [set_BuildType()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/itextanimation/set_buildtype/) su [BuildType.AsOneObject](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/buildtype/) per disattivare la modalità di animazione *By Paragraphs*.
3. Imposta nuovi valori per le proprietà [set_AnimateTextType()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) e [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Salva il file PPTX modificato.

Questo codice C++ dimostra l'operazione:

```c++
// Istanzia una classe Presentation che rappresenta un file di presentazione.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ottiene il primo effetto della sequenza principale
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Cambia il tipo di animazione del testo dell'effetto a "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Cambia il tipo di animazione del testo a "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Imposta il ritardo tra le parole al 20% della durata dell'effetto
firstEffect->set_DelayBetweenTextParts(20.0f);

// Scrive il file PPTX su disco
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Come posso garantire che le animazioni siano preservate quando pubblico la presentazione sul web?**

[Esporta in HTML5](/slides/it/cpp/export-to-html5/) e abilita le [opzioni](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/html5options/) responsabili delle animazioni di [shape](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/html5options/set_animateshapes/) e di [transition](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/html5options/set_animatetransitions/). L'HTML semplice non riproduce le animazioni delle diapositive, mentre l'HTML5 lo fa.

**In che modo la modifica dell'ordine Z (ordine dei livelli) delle forme influisce sull'animazione?**

L'ordine di animazione e l'ordine di disegno sono indipendenti: un effetto controlla il timing e il tipo di apparizione/scomparsa, mentre lo [z-order](https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/get_zorderposition/) determina cosa copre cosa. Il risultato visivo è definito dalla loro combinazione. (Questo è il comportamento generale di PowerPoint; il modello effetti‑e‑forme di Aspose.Slides segue la stessa logica.)

**Ci sono limitazioni nella conversione delle animazioni in video per alcuni effetti?**

In generale, le [animazioni sono supportate](/slides/it/cpp/convert-powerpoint-to-video/), ma casi rari o effetti specifici potrebbero essere resa differenti. Si consiglia di testare con gli effetti utilizzati e con la versione della libreria.