---
title: Applicare animazioni di forme nelle presentazioni usando C++
linktitle: Animazione di forma
type: docs
weight: 60
url: /it/cpp/shape-animation/
keywords:
- forma
- animazione
- effetto
- forma animata
- testo animato
- aggiungere animazione
- ottenere animazione
- estrarre animazione
- aggiungere effetto
- ottenere effetto
- estrarre effetto
- suono effetto
- applicare animazione
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come creare e personalizzare le animazioni di forme nelle presentazioni PowerPoint con Aspose.Slides per C++. Distinguersi!"
---
## **Introduzione**

Le animazioni sono effetti visivi che possono essere applicati a testi, immagini, forme o [grafici](/slides/it/cpp/animated-charts/). Danno vita alle presentazioni o ai loro componenti. 

## **Perché utilizzare le animazioni nelle presentazioni?**

Utilizzando le animazioni, puoi 

* controllare il flusso delle informazioni
* enfatizzare i punti importanti
* aumentare l'interesse o la partecipazione del pubblico
* rendere il contenuto più facile da leggere, assimilare o elaborare
* attirare l'attenzione dei lettori o spettatori verso le parti importanti di una presentazione

PowerPoint fornisce molte opzioni e strumenti per animazioni ed effetti di animazione nelle categorie **entrata**, **uscita**, **enfasi** e **percorsi di movimento**. 

## **Animazioni in Aspose.Slides**

* Aspose.Slides fornisce le classi e i tipi necessari per lavorare con le animazioni nello spazio dei nomi [Aspose.Slides.Animation](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.animation).
* Aspose.Slides offre più di **150 effetti di animazione** nell'enumerazione [EffectType](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Questi effetti sono essenzialmente gli stessi (o equivalenti) utilizzati in PowerPoint.

## **Applicare un'animazione a una TextBox**

Aspose.Slides per C++ consente di applicare un'animazione al testo in una forma. 

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation/).
2. Ottenere il riferimento a una slide tramite il suo indice.
3. Aggiungere una `rectangle` [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape). 
4. Aggiungere testo a [IAutoShape.TextFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Ottenere la sequenza principale di effetti.
6. Aggiungere un effetto di animazione a [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape). 
7. Impostare la proprietà [TextAnimation.BuildType](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) al valore della [BuildType Enumeration](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Scrivere la presentazione su disco come file PPTX.

Questo codice C++ mostra come applicare l'effetto `Fade` a AutoShape e impostare l'animazione del testo sul valore *Per paragrafi di primo livello*:

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Istanzia una classe Presentation che rappresenta un file di presentazione.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Aggiunge una nuova AutoShape con testo
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Ottiene la sequenza principale della slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Aggiunge l'effetto di animazione Fade alla forma
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Anima il testo della forma per paragrafi di primo livello
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Salva il file PPTX su disco
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

Oltre ad applicare animazioni al testo, è possibile applicare animazioni a un singolo [Paragraph](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_paragraph). Vedi [**Testo animato**](/slides/it/cpp/animated-text/).

{{% /alert %}} 

## **Applicare un'animazione a un PictureFrame**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation/).
2. Ottenere il riferimento a una slide tramite il suo indice.
3. Aggiungere o ottenere un [PictureFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_picture_frame) nella slide. 
4. Ottenere la sequenza principale di effetti.
5. Aggiungere un effetto di animazione al [PictureFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_picture_frame).
6. Scrivere la presentazione su disco come file PPTX.

Questo codice C++ mostra come applicare l'effetto `Fly` a un picture frame:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Istanzia una classe Presentation che rappresenta un file di presentazione.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Carica l'immagine da aggiungere alla raccolta di immagini della presentazione
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Aggiunge un frame immagine alla slide
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Ottiene la sequenza principale della slide.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Aggiunge l'effetto di animazione Fly da sinistra al frame immagine
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Salva il file PPTX su disco
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Applicare un'animazione a una Shape**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation/).
2. Ottenere il riferimento a una slide tramite il suo indice.
3. Aggiungere una `rectangle` [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape). 
4. Aggiungere un `Bevel` [IAutoShape](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_auto_shape) (quando questo oggetto viene cliccato, l'animazione viene eseguita).
5. Creare una sequenza di effetti sulla forma bevel.
6. Creare un `UserPath` personalizzato.
7. Aggiungere comandi per il movimento al `UserPath`.
8. Scrivere la presentazione su disco come file PPTX.

Questo codice C++ mostra come applicare l'effetto `PathFootball` (percorso football) a una forma:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// Il percorso alla directory del documento.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carica la presentazione
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accede alla prima slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accede alla raccolta di forme per la slide selezionata
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Crea l'effetto PathFootball per la forma esistente da zero.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Aggiunge l'effetto di animazione PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Crea una sorta di "pulsante".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Crea una sequenza di effetti per questo pulsante.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Crea un percorso utente personalizzato. Il nostro oggetto verrà spostato solo dopo che il pulsante viene cliccato.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Aggiunge comandi per lo spostamento poiché il percorso creato è vuoto.
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

**Esempio 1: Ottenere gli effetti di animazione applicati a una forma su una slide normale**

In precedenza, hai imparato come aggiungere effetti di animazione a forme nelle presentazioni PowerPoint. Il codice di esempio seguente mostra come ottenere gli effetti applicati alla prima forma sulla prima slide normale della presentazione `AnimExample_out.pptx`.

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Ottiene la sequenza principale di animazione della slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Ottiene la prima forma sulla prima slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Ottiene gli effetti di animazione applicati alla forma.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Esempio 2: Ottenere tutti gli effetti di animazione, inclusi quelli ereditati da segnaposti**

Se una forma su una slide normale ha segnaposti presenti nella slide di layout e/o master, e a questi segnaposti sono stati aggiunti effetti di animazione, allora tutti gli effetti della forma verranno riprodotti durante la presentazione, inclusi quelli ereditati dai segnaposti.

Supponiamo di avere un file di presentazione PowerPoint `sample.pptx` con una slide che contiene solo una forma di piè di pagina con il testo "Made with Aspose.Slides" e a cui è stato applicato l'effetto **Random Bars**.

![Effetto di animazione della forma della slide](slide-shape-animation.png)

Supponiamo inoltre che l'effetto **Split** sia stato applicato al segnaposto del piè di pagina sulla slide di **layout**.

![Effetto di animazione della forma del layout](layout-shape-animation.png)

Infine, l'effetto **Fly In** è stato applicato al segnaposto del piè di pagina sulla slide di **master**.

![Effetto di animazione della forma master](master-shape-animation.png)

Il codice di esempio seguente mostra come utilizzare il metodo `GetBasePlaceholder` dell'interfaccia [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) per accedere ai segnaposti della forma e ottenere gli effetti di animazione applicati alla forma del piè di pagina, inclusi quelli ereditati dai segnaposti situati su slide di layout e master.

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Ottieni gli effetti di animazione della forma sulla slide normale.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Ottieni gli effetti di animazione del segnaposto sulla slide di layout.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Ottieni gli effetti di animazione del segnaposto sulla slide master.
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
Type: 47, subtype: 2              // Fly, Inferiore
Type: 134, subtype: 45            // Split, VerticalIn
Type: 126, subtype: 22            // RandomBars, Orizzontale
```

## **Modificare le proprietà di temporizzazione dell'effetto di animazione**

Aspose.Slides per C++ consente di modificare le proprietà di Timing di un effetto di animazione.

Questo è il pannello di temporizzazione dell'animazione in Microsoft PowerPoint:

![Pannello di temporizzazione dell'animazione](shape-animation.png)

Queste sono le corrispondenze tra il Timing di PowerPoint e le proprietà di [Effect.Timing](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- Il menu a discesa **Start** di PowerPoint corrisponde alla proprietà [Effect.Timing.TriggerType](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- **Duration** di PowerPoint corrisponde alla proprietà [Effect.Timing.Duration](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). La durata di un'animazione (in secondi) è il tempo totale necessario per completare un ciclo. 
- **Delay** di PowerPoint corrisponde alla proprietà [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Ecco come modificare le proprietà di Timing dell'effetto:

1. [Applica](#apply-animation-to-shape) o ottieni l'effetto di animazione.
2. Imposta nuovi valori per le proprietà [Effect.Timing](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) necessarie. 
3. Salva il file PPTX modificato.

Questo codice C++ dimostra l'operazione:

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Istanzia una classe Presentation che rappresenta un file di presentazione.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Ottiene la sequenza principale della slide.
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

Aspose.Slides fornisce queste proprietà per consentire di lavorare con i suoni negli effetti di animazione: 

- [set_Sound()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Aggiungere un suono all'effetto di animazione**

Questo codice C++ mostra come aggiungere un suono all'effetto di animazione e fermarlo quando inizia il successivo effetto:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Aggiunge audio alla raccolta audio della presentazione
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ottiene la sequenza principale della slide.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Ottiene il primo effetto della sequenza principale
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Verifica l'effetto per "No Sound"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Aggiunge il suono per il primo effetto
    firstEffect->set_Sound(effectSound);
}

// Ottiene la prima sequenza interattiva della slide.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Imposta il flag dell'effetto "Stop previous sound"
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Scrive il file PPTX su disco
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Estrarre un suono dall'effetto di animazione**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Ottenere il riferimento a una slide tramite il suo indice. 
3. Ottenere la sequenza principale di effetti. 
4. Estrarre il suono [set_Sound()] incorporato in ogni effetto di animazione. 

Questo codice C++ mostra come estrarre il suono incorporato in un effetto di animazione:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Istanzia una classe Presentation che rappresenta un file di presentazione.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Ottiene la sequenza principale della slide.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Dopo l'animazione**

Aspose.Slides per C++ consente di modificare la proprietà After animation di un effetto di animazione.

Questo è il pannello dell'effetto dopo l'animazione in Microsoft PowerPoint:

![Pannello dell'effetto dopo l'animazione](shape-after-animation.png)

Il menu a discesa **After animation** di PowerPoint corrisponde a queste proprietà: 

- La proprietà [set_AfterAnimationType()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) descrive il tipo di After animation:
  * PowerPoint **More Colors** corrisponde al tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** corrisponde al tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/) (tipo predefinito di after animation);
  * PowerPoint **Hide After Animation** corrisponde al tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** corrisponde al tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/);
- La proprietà [set_AfterAnimationColor()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) definisce un formato di colore After animation. Questa proprietà funziona in congiunzione con il tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/afteranimationtype/). Se cambi il tipo, il colore After animation verrà cancellato.

Questo codice C++ mostra come modificare un effetto After animation:

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Istanzia una classe Presentation che rappresenta un file di presentazione
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ottiene il primo effetto della sequenza principale
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Cambia il tipo di after animation a Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Imposta il colore di after animation
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Scrive il file PPTX su disco
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animare il testo**

Aspose.Slides fornisce queste proprietà per lavorare con il blocco *Animate text* di un effetto di animazione:

- La proprietà [set_AnimateTextType()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) descrive il tipo di animazione del testo dell'effetto. Il testo della forma può essere animato:
  - Tutto in una volta ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/animatetexttype/) tipo)
  - Per parola ([AnimateTextType.ByWord](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/animatetexttype/) tipo)
  - Per lettera ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/animatetexttype/) tipo)
- La proprietà [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) imposta un ritardo tra le parti del testo animate (parole o lettere). Un valore positivo specifica la percentuale della durata dell'effetto. Un valore negativo specifica il ritardo in secondi.

Ecco come è possibile modificare le proprietà Animate text dell'effetto:

1. [Applica](#apply-animation-to-shape) o ottieni l'effetto di animazione.
2. Impostare la proprietà [set_BuildType()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation.itextanimation/set_buildtype/) al valore [BuildType.AsOneObject](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/buildtype/) per disattivare la modalità di animazione *Per paragrafi*.
3. Impostare nuovi valori per le proprietà [set_AnimateTextType()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) e [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/it/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Salva il file PPTX modificato.

Questo codice C++ dimostra l'operazione:

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Istanzia una classe Presentation che rappresenta un file di presentazione.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Ottiene il primo effetto della sequenza principale
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Modifica il tipo di animazione del testo dell'effetto a "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Modifica il tipo di animazione del testo dell'effetto a "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Imposta il ritardo tra le parole al 20% della durata dell'effetto
firstEffect->set_DelayBetweenTextParts(20.0f);

// Scrive il file PPTX su disco
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Come posso assicurarmi che le animazioni vengano conservate quando pubblico la presentazione sul web?

[Esporta in HTML5](/slides/it/cpp/export-to-html5/) e abilita le [opzioni](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/html5options/) responsabili delle animazioni di [forma](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/html5options/set_animateshapes/) e [transizione](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/html5options/set_animatetransitions/). L'HTML semplice non riproduce le animazioni delle slide, mentre l'HTML5 lo fa.

### Come influisce il cambiamento dell'ordine Z (ordine dei livelli) delle forme sull'animazione?

L'ordine Z determina cosa copre cosa, mentre le animazioni controllano il momento e il modo in cui gli oggetti appaiono o scompaiono. Il risultato visivo dipende dalla combinazione di entrambi. (Questo è il comportamento generale di PowerPoint; il modello di effetti e forme di Aspose.Slides segue la stessa logica.)

### Ci sono limitazioni nella conversione delle animazioni in video per alcuni effetti?

In generale, le [animazioni sono supportate](/slides/it/cpp/convert-powerpoint-to-video/), ma casi rari o effetti specifici potrebbero essere renderizzati in modo diverso. Si consiglia di testare con gli effetti effettivi e con la versione della libreria.