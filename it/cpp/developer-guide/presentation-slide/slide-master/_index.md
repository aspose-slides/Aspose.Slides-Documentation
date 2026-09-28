---
title: Gestisci i master slide della presentazione in C++
linktitle: Master slide
type: docs
weight: 80
url: /it/cpp/slide-master/
keywords:
- master diapositiva
- slide master
- slide master PPT
- slide master multipli
- confronta slide master
- sfondo
- segnaposto
- clona slide master
- copia slide master
- duplica slide master
- slide master inutilizzato
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci i master slide in Aspose.Slides per C++: accedi, modifica, clona, confronta e rimuovi i master slide in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce impostazioni di design condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un slide master è il modo abituale per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per C++ supporta lo stesso modello. Una presentazione può contenere una o più master slide, e ogni master slide può contenere diverse layout slide. Le diapositive normali di solito non si riferiscono direttamente a un master slide. Invece, una diapositiva normale utilizza una layout slide, e quella layout slide appartiene a un master slide.

La gerarchia è:

1. **Slide master** – definisce il design e il tema condivisi.  
1. **Layout slide** – definisce una disposizione specifica di segnaposti e formattazione a livello di layout.  
1. **Normal slide** – contiene il contenuto effettivo della presentazione e utilizza una layout slide.

![La gerarchia di master slide, layout slide e diapositive normali](slide-master_2.jpg)

In Aspose.Slides, un slide master è rappresentato dall’interfaccia [IMasterSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslide/) . Tutti i master slide in una presentazione sono disponibili attraverso la collezione [Presentation::get_Masters](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_masters/) , che implementa [IMasterSlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
Quando la stessa proprietà è definita a più di un livello, prevale il livello più specifico. Per esempio, se un master slide e una layout slide definiscono entrambe uno sfondo, le diapositive basate su quel layout usano lo sfondo del layout. Per ulteriori informazioni sulle layout slide, vedere [Apply or Change Slide Layouts](/slides/it/cpp/slide-layout/).
{{% /alert %}}

## **Accedi ai master slide**

In PowerPoint, puoi aprire la visualizzazione Slide Master da **View** > **Slide Master**.

![Il comando Slide Master nella scheda Visualizza di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, usa la collezione `get_Masters()` per accedere ai master slide:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Puoi anche ottenere il master slide usato da una diapositiva normale attraverso il suo layout:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Cosa contiene un Slide Master**

Un master slide è un oggetto simile a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslide/), quindi espone molte delle stesse proprietà della diapositiva utilizzate da diapositive normali e layout. I membri specifici del master sono elencati nella pagina API [IMasterSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslide/) .

I membri più usati includono:

| Membro | Scopo |
| --- | --- |
| `get_Background()` | Imposta lo sfondo a livello di master. |
| `get_Shapes()` | Memorizza le forme posizionate sul master, come loghi, cornici di immagini e testo condiviso. |
| `get_LayoutSlides()` | Memorizza le layout slide che appartengono al master. |
| `get_ThemeManager()` | Fornisce l'accesso alle API del tema del master. |
| `get_HeaderFooterManager()` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `GetDependingSlides()` | Restituisce le diapositive normali che dipendono dal master attraverso i loro layout. |

## **Aggiungere un'immagine a uno Slide Master**

Quando aggiungi un'immagine a un master slide, essa appare sulle diapositive che usano layout di quel master. Questo è utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

L’esempio seguente aggiunge un logo al primo master slide:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Per ulteriori informazioni sulle cornici di immagini, vedere [Cornice immagine](/slides/it/cpp/picture-frame/).

## **Controllare la visibilità della grafica del master**

Usa [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslide/set_showmastershapes/) per nascondere la grafica ereditata dal master, come loghi o forme decorative, senza eliminarla dal master. Passa `false` a [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/set_showmastershapes/) sulla diapositiva che deve omettere quelle grafiche e `true` su quelle che devono visualizzarle.

L’esempio autonomo seguente crea una banda decorativa blu su un master e due diapositive che usano lo stesso layout vuoto. La banda è visibile sulla prima diapositiva e nascosta sulla seconda. Non è necessario alcun file di presentazione o immagine di input.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L’esempio utilizza il layout **Blank** fornito con una nuova presentazione e rimuove i segnaposti predefiniti della diapositiva iniziale.

### **Scegliere l'ambito dell'impostazione**

Una diapositiva normale utilizza il suo master tramite [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/get_layoutslide/) e [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/ilayoutslide/get_masterslide/). Impostare la proprietà su una singola diapositiva influisce solo su quella diapositiva. Passare `false` a [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/it/cpp/aspose.slides/layoutslide/set_showmastershapes/) nasconde la grafica del master per le diapositive che usano quel layout condiviso, anche se il loro proprio impostazione è `true`. Per nascondere la grafica su una sola diapositiva, modifica la proprietà della diapositiva e lascia invariato il layout condiviso.

L’impostazione non è supportata come controllo di visibilità sul master slide stesso. Sul master restituisce sempre `false`, e assegnare `true` genera `System::NotSupportedException`. Applicala a una diapositiva normale o a un layout invece.

### **Distinguere la grafica dallo sfondo**

| Operazione | Effetto |
| --- | --- |
| Nascondi la grafica del master | Controlla la visibilità delle forme ereditate dal master senza eliminarle o modificare le forme proprie della diapositiva. |
| Modifica il riempimento dello sfondo della diapositiva | Cambia il colore, il gradiente o l’immagine di sfondo. La grafica del master è una forma separata e può rimanere visibile sopra quello sfondo. Vedi [Presentation Background](/slides/it/cpp/presentation-background/). |
| Elimina una forma dal master | Rimuove la forma sorgente condivisa, quindi non è più disponibile per alcuna diapositiva che usa quel master. |

## **Lavorare con i segnaposti**

I segnaposti sono normalmente definiti sulle layout slide. Il master slide fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ogni layout decide quali segnaposti sono disponibili e dove vengono posizionati.

In PowerPoint, i comandi dei segnaposti sono disponibili nella visualizzazione Slide Master.

![Il comando Inserisci segnaposto nella visualizzazione Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavora sul layout slide che appartiene al master:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Puoi anche formattare le forme segnaposto già presenti su un master slide. L’esempio seguente trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Segnaposto del titolo formattato ereditato da diapositive normali](slide-master_8.png)

Per ulteriori opzioni di formattazione dei segnaposti e del testo, vedere [Set Prompt Text in Placeholder](/slides/it/cpp/manage-placeholder/) e [Text Formatting](/slides/it/cpp/text-formatting/).

## **Modificare lo sfondo di uno Slide Master**

Uno sfondo del master è ereditato da layout e diapositive che non lo sovrascrivono. L’esempio seguente imposta un colore di sfondo solido per il primo master slide:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Per argomenti correlati, vedere [Presentation Background](/slides/it/cpp/presentation-background/) e [Presentation Theme](/slides/it/cpp/presentation-theme/).

## **Clonare uno Slide Master in un'altra presentazione**

Usa [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslidecollection/addclone/) per copiare un master slide in un’altra presentazione. Il master copiato può quindi essere usato da layout e diapositive nella presentazione di destinazione.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Se devi clonare diapositive normali insieme al loro master, vedi [Clone Slides](/slides/it/cpp/clone-slides/).

## **Aggiungere più Slide Master**

Una presentazione può contenere più master slide. Questo è utile quando sezioni diverse richiedono branding, struttura di pagina o impostazioni di tema differenti.

![Comandi PowerPoint per inserire e gestire i master slide](slide-master_9.jpg)

L’esempio seguente clona il master predefinito, assegna al clone uno sfondo diverso, crea un layout sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Confrontare gli Slide Master**

I master slide possono essere confrontati con il metodo `Equals` ereditato da [IBaseSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslide/). Il confronto verifica struttura e contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori unici, come ID delle diapositive, né valori dinamici dei segnaposti, come la data corrente.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Per ulteriori informazioni, vedere [Compare Presentation Slides](/slides/it/cpp/compare-slides/).

## **Impostare la visualizzazione Slide Master come visualizzazione predefinita**

Usa il metodo `set_LastView` su [ViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/) per controllare la visualizzazione che PowerPoint apre per prima. L’esempio seguente apre la presentazione in visualizzazione Slide Master:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Per altre impostazioni di visualizzazione, vedere [Save Presentation](/slides/it/cpp/save-presentation/).

## **Rimuovere gli Slide Master inutilizzati**

Le presentazioni a volte contengono master slide che non sono più usati da alcuna diapositiva normale. Rimuovere i master inutilizzati può ridurre le dimensioni del file e semplificare la manutenzione del modello.

Usa [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/it/cpp/aspose.slides/masterslidecollection/removeunused/) per rimuovere i master inutilizzati dalla collezione `get_Masters()`:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Puoi anche usare il metodo a basso codice [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Qual è la differenza tra uno slide master e una layout slide?**

Uno slide master definisce impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una layout slide appartiene a uno slide master e definisce una disposizione specifica di segnaposti. Una diapositiva normale usa una layout slide, quindi eredita sia dal layout sia dal master.

**Una presentazione può contenere diversi slide master?**

Sì. Una presentazione può contenere diversi slide master. Usa più master quando sezioni diverse hanno bisogno di sistemi visivi o branding differenti.

**Devo aggiungere segnaposti a uno slide master o a una layout slide?**

Nella maggior parte dei casi, aggiungi i segnaposti alle layout slide. Metti gli elementi visivi condivisi e la formattazione comune sul master slide, poi posiziona i segnaposti di contenuto sulle layout che le diapositive normali utilizzeranno.

**Posso eliminare uno slide master ancora in uso?**

No. Uno slide master che ha diapositive dipendenti non può essere rimosso in modo sicuro. Sposta prima quelle diapositive su layout di un altro master, oppure usa un metodo di pulizia dei master non utilizzati che rimuove solo i master senza dipendenze.