---
title: Gestire i master diapositive della presentazione in C++
linktitle: Master diapositiva
type: docs
weight: 80
url: /it/cpp/slide-master/
keywords:
- master diapositive
- master diapositiva
- master diapositiva PPT
- master diapositive multipli
- confronta master diapositive
- sfondo
- segnaposto
- clona master diapositiva
- copia master diapositiva
- duplica master diapositiva
- master diapositiva non utilizzata
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci i master diapositive in Aspose.Slides per C++: accedi, modifica, clona, confronta e rimuovi i master diapositive in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **master delle diapositive** definisce impostazioni di design condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un master delle diapositive è il modo consueto per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per C++ supporta lo stesso modello. Una presentazione può contenere una o più master diapositive, e ogni master può contenere diverse diapositive layout. Le diapositive normali non fanno generalmente riferimento direttamente a un master; invece, una diapositiva normale utilizza una diapositiva layout, e quella diapositiva layout appartiene a un master.

La gerarchia è:

1. **Master delle diapositive** – definisce il design condiviso e il tema.  
1. **Diapositiva layout** – definisce una disposizione specifica di segnaposti e formattazione a livello di layout.  
1. **Diapositiva normale** – contiene il contenuto reale della presentazione e utilizza una diapositiva layout.

![La gerarchia di master diapositive, diapositive layout e diapositive normali](slide-master_2.jpg)

In Aspose.Slides, un master diapositive è rappresentato dall’interfaccia [IMasterSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslide/) . Tutti i master diapositive in una presentazione sono disponibili tramite la collezione [Presentation::get_Masters](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_masters/) , che implementa [IMasterSlideCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
Quando la stessa proprietà è definita a più di un livello, prevale il livello più specifico. Ad esempio, se un master diapositive e una diapositiva layout definiscono entrambi uno sfondo, le diapositive basate su quel layout utilizzano lo sfondo del layout. Per ulteriori informazioni sulle diapositive layout, vedere [Applica o modifica layout diapositive](/slides/it/cpp/slide-layout/) .
{{% /alert %}}

## **Accedi ai master diapositive**

In PowerPoint, è possibile aprire la visualizzazione **Master delle diapositive** da **Visualizza** > **Master delle diapositive**.

![Il comando Master delle diapositive nella scheda Visualizza di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, usa la collezione `get_Masters()` per accedere ai master diapositive:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Puoi anche ottenere il master diapositive usato da una diapositiva normale tramite il suo layout:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Cosa contiene un master diapositive**

Un master diapositive è un oggetto simile a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslide/), quindi espone molte delle stesse proprietà delle diapositive usate da diapositive normali e layout. I membri specifici del master sono elencati nella pagina API di [IMasterSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslide/) .

I membri del master diapositive più comunemente usati includono:

| Membro | Scopo |
| --- | --- |
| `get_Background()` | Imposta lo sfondo della diapositiva a livello di master. |
| `get_Shapes()` | Contiene le forme posizionate sul master, come loghi, cornici di immagini e testo condiviso. |
| `get_LayoutSlides()` | Contiene le diapositive layout che appartengono al master. |
| `get_ThemeManager()` | Fornisce l’accesso alle API del tema del master. |
| `get_HeaderFooterManager()` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `GetDependingSlides()` | Restituisce le diapositive normali che dipendono dal master tramite i loro layout. |

## **Aggiungi un'immagine a un master diapositive**

Quando aggiungi un’immagine a un master diapositive, essa appare sulle diapositive che utilizzano i layout di quel master. È utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

L’esempio seguente aggiunge un logo al primo master diapositive:

```cpp
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

Per ulteriori informazioni sulle cornici di immagini, vedere [Cornice immagine](/slides/it/cpp/picture-frame/) .

## **Lavora con i segnaposti**

I segnaposti sono normalmente definiti sulle diapositive layout. Il master diapositive fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ogni layout decide quali segnaposti sono disponibili e dove sono posizionati.

In PowerPoint, i comandi dei segnaposti sono disponibili nella visualizzazione **Master delle diapositive**.

![Il comando Inserisci segnaposto nella visualizzazione Master delle diapositive di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavora con la diapositiva layout che appartiene al master:

```cpp
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

Puoi anche formattare le forme segnaposto già presenti su un master diapositive. L’esempio seguente trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

```cpp
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

![Segnaposto titolo formattato ereditato dalle diapositive normali](slide-master_8.png)

Per ulteriori opzioni di formattazione di segnaposti e testo, vedere [Imposta testo prompt nel segnaposto](/slides/it/cpp/manage-placeholder/) e [Formattazione del testo](/slides/it/cpp/text-formatting/) .

## **Modifica lo sfondo di un master diapositive**

Uno sfondo master è ereditato da layout e diapositive che non lo sovrascrivono. L’esempio seguente imposta un colore di sfondo solido per il primo master diapositive:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Per argomenti correlati, vedere [Sfondo presentazione](/slides/it/cpp/presentation-background/) e [Tema presentazione](/slides/it/cpp/presentation-theme/) .

## **Clona un master diapositive in un'altra presentazione**

Usa [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/it/cpp/aspose.slides/imasterslidecollection/addclone/) per copiare un master diapositive in un’altra presentazione. Il master copiato può quindi essere usato da layout e diapositive nella presentazione di destinazione.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Se hai bisogno di clonare diapositive normali insieme al loro master, vedere [Clona diapositive](/slides/it/cpp/clone-slides/) .

## **Aggiungi più master diapositive**

Una presentazione può contenere più master diapositive. È utile quando sezioni diverse richiedono branding, struttura di pagina o impostazioni del tema differenti.

![Comandi PowerPoint per inserire e gestire master diapositive](slide-master_9.jpg)

L’esempio seguente clona il master predefinito, assegna al clone uno sfondo diverso, crea un layout sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

```cpp
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

## **Confronta i master diapositive**

I master diapositive possono essere confrontati con il metodo `Equals` ereditato da [IBaseSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslide/) . Il confronto verifica struttura e contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori unici, come gli ID delle diapositive, né i valori dinamici dei segnaposti, come la data corrente.

```cpp
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

Per ulteriori informazioni, vedere [Confronta diapositive presentazione](/slides/it/cpp/compare-slides/) .

## **Imposta la visualizzazione Master diapositive come visualizzazione predefinita**

Usa il metodo `set_LastView` su [ViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/) per controllare la visualizzazione che PowerPoint apre per prima. L’esempio seguente apre la presentazione nella visualizzazione **Master delle diapositive**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Per altre impostazioni di visualizzazione, vedere [Salva presentazione](/slides/it/cpp/save-presentation/) .

## **Rimuovi master diapositive non utilizzati**

Le presentazioni a volte contengono master diapositive che non sono più usati da alcuna diapositiva normale. Rimuovere i master inutilizzati può ridurre la dimensione del file e semplificare la manutenzione del modello.

Usa [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/it/cpp/aspose.slides/masterslidecollection/removeunused/) per rimuovere i master non utilizzati dalla collezione `get_Masters()` :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Puoi anche usare il metodo low‑code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Qual è la differenza tra un master diapositive e una diapositiva layout?**  
Un master diapositive definisce impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una diapositiva layout appartiene a un master e definisce una disposizione specifica di segnaposti. Una diapositiva normale usa una diapositiva layout, ereditando sia dal layout sia dal master.

**Una presentazione può contenere più master diapositive?**  
Sì. Una presentazione può contenere più master diapositive. Usa master multipli quando sezioni diverse necessitano di sistemi visivi o branding differenti.

**Devo aggiungere i segnaposti a un master diapositive o a una diapositiva layout?**  
Nella maggior parte dei casi, aggiungi i segnaposti alle diapositive layout. Metti gli elementi visivi condivisi e la formattazione comune sul master diapositive, quindi inserisci i segnaposti di contenuto sui layout che le diapositive normali utilizzeranno.

**Posso eliminare un master diapositive che è ancora in uso?**  
No. Un master diapositive che ha diapositive dipendenti non può essere rimosso in modo sicuro. Sposta prima quelle diapositive su layout di un altro master, oppure usa una procedura di pulizia che rimuove solo i master non utilizzati.