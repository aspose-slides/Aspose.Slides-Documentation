---
title: Gestire i segnaposti di presentazione in C++
linktitle: Gestire i segnaposti
type: docs
weight: 10
url: /it/cpp/manage-placeholder/
keywords:
- segnaposto
- segnaposto testo
- segnaposto immagine
- segnaposto grafico
- segnaposto contenuto
- testo di prompt
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Impara a ispezionare e modificare segnaposti di testo, immagine, grafico e contenuto e a comprendere l'ereditarietà dei segnaposti con Aspose.Slides per C++."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un particolare tipo di contenuto in un modello di presentazione. Esempi comuni sono segnaposti per titolo, corpo, immagine, grafico e contenuto generico. A differenza di una forma ordinaria, un segnaposto può ereditare la sua posizione, dimensione, formattazione e altre impostazioni da una diapositiva layout o master.

Aspose.Slides espone le informazioni sui segnaposti attraverso il metodo [IShape::get_Placeholder](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_placeholder/). Il metodo restituisce un oggetto [IPlaceholder](https://reference.aspose.com/slides/it/cpp/aspose.slides/iplaceholder/) o `nullptr` per una forma normale. Utilizza [IPlaceholder::get_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/iplaceholder/get_type/) per determinare cosa il segnaposto è destinato a contenere.

L'interfaccia della forma è ancora importante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto vuoto per testo, immagine, grafico o contenuto è comunemente rappresentato da un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/).
- Un segnaposto immagine popolato può essere rappresentato da un [IPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframe/).
- Un segnaposto grafico popolato può essere rappresentato da un [IChart](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/).
- Un segnaposto di contenuto può contenere diversi tipi di contenuto. Controlla sia [IPlaceholder::get_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/iplaceholder/get_type/) sia l'interfaccia della forma a runtime invece di presumere che ogni segnaposto sia un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/iplaceholder/get_type/) descrive il ruolo di un segnaposto; non garantisce il tipo di forma a runtime. Usa sempre un controllo di tipo prima di accedere a membri specifici di testo, immagine, grafico, tabella o media.
{{% /alert %}}

## **Comprendere l'Ereditarietà dei Segnaposti**

I segnaposti formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposti a livello master.
2. Una diapositiva layout definisce la disposizione usata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposti per quella diapositiva e può ereditare dal suo layout.

Chiama [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/getbaseplaceholder/) per spostarti di un livello verso l'alto in questa gerarchia. Un segnaposto di diapositiva normalmente restituisce il suo segnaposto layout; un segnaposto layout può restituire il suo segnaposto master. Il metodo restituisce `nullptr` quando la forma non ha un segnaposto base.

Il seguente esempio elenca i segnaposti nella prima diapositiva e segnala i loro segnaposti base:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Modificare un segnaposto su una diapositiva normale crea o cambia una sovrascrittura locale per quella diapositiva. Modificare il layout o il master correlato può influenzare tutte le diapositive che ereditano ancora tale impostazione. Una forma locale ordinaria non ha un segnaposto base e non inizia a ereditare solo perché occupa le stesse coordinate.

## **Modificare il Testo in un Segnaposto**

I segnaposti titolo, titolo centrato, sottotitolo, corpo e testo normalmente supportano il testo. Verifica la presenza di un [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) prima di utilizzare il suo metodo [get_TextFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/get_textframe/).

Questo esempio aggiorna il primo segnaposto titolo nella prima diapositiva e salva il risultato:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Questo modello evita il casting di segnaposti immagine, grafico, tabella o media a [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/). Inoltre identifica il segnaposto per scopo anziché fare affidamento su un indice di forma fragile.

## **Impostare il Testo di Prompt su un Layout**

Il testo di prompt è l'istruzione di design-time mostrata in un segnaposto vuoto, ad esempio *Click to add title*. Imposta un testo di prompt personalizzato sul segnaposto layout anziché cercare di raggiungerlo tramite la collezione di forme di una diapositiva normale. Accedi al layout attraverso [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/get_layoutslide/) e itera su [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/it/cpp/aspose.slides/ibaseslide/get_shapes/).

Il seguente esempio modifica i prompt di titolo e sottotitolo sul layout usato dalla prima diapositiva:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

Il testo di prompt non è contenuto normale della diapositiva. È destinato a segnaposti vuoti nelle applicazioni di editing come PowerPoint. Una volta che un utente o un programma fornisce contenuto reale, il prompt non viene più mostrato. Modificare un prompt non sostituisce nemmeno il testo esistente sulle diapositive che usano il layout.

## **Aggiornare un Segnaposto Immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [IPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframe/), sostituisci l'immagine attraverso [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipicturefillformat/get_picture/) e [ISlidesPicture::set_Image](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidespicture/set_image/).
- Se è ancora un segnaposto vuoto, aggiungi un frame immagine alle coordinate del segnaposto con [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addpictureframe/) e rimuovi il segnaposto vuoto.

Il prossimo esempio supporta entrambi i casi e salva la presentazione:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

La sostituzione creata per un segnaposto vuoto è un frame immagine locale, non un nuovo segnaposto, perché [IShape::get_Placeholder](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_placeholder/) è di sola lettura. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se è essenziale conservare la relazione di segnaposto, prepara e popola il segnaposto in PowerPoint prima, quindi aggiorna il [IPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframe/) risultante con Aspose.Slides.

Per trasparenza dell'immagine, ritaglio e altri effetti specifici dell'immagine, consulta [Manage Picture Frames](/slides/it/cpp/picture-frame/). Queste operazioni appartengono al frame immagine o al riempimento immagine, non ai metadati del segnaposto.

## **Lavorare con Segnaposti Grafico e Contenuto**

Un segnaposto grafico popolato può essere rappresentato da un [IChart](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/). Questo esempio trova tale grafico sia per tipo di segnaposto sia per interfaccia a runtime, ne modifica il titolo e salva il file:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Un segnaposto di contenuto generico solitamente ha [PlaceholderType::Object](https://reference.aspose.com/slides/it/cpp/aspose.slides/placeholdertype/). In PowerPoint agisce come avviatore per vari tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo che è stato popolato, ispeziona l'effettiva interfaccia della forma per capire cosa contiene. Layout specializzati possono anche esporre [PlaceholderType::Chart](https://reference.aspose.com/slides/it/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/it/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/it/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/it/cpp/aspose.slides/placeholdertype/), o [PlaceholderType::Diagram](https://reference.aspose.com/slides/it/cpp/aspose.slides/placeholdertype/).

Aspose.Slides non converte un segnaposto vuoto [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) in un [IChart](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/) modificando semplicemente [IPlaceholder::get_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/iplaceholder/get_type/); il tipo è di sola lettura. Per riempire programmaticamente un'area grafico o contenuto vuota, aggiungi l'oggetto richiesto alle coordinate del segnaposto e poi rimuovi il segnaposto vuoto. Il seguente esempio lo fa per un grafico:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

Il grafico aggiunto è un grafico locale ordinario. Occupa l'area del segnaposto ma non eredita dal segnaposto layout. Usa gli articoli dedicati alla [chart management articles](/slides/it/cpp/powerpoint-charts/) quando devi sostituire categorie, serie o dati del workbook.

## **Esempio Completo: Aggiornare Contenuto Testo o Immagine**

Il seguente esempio end-to-end apre un modello, cerca nella prima diapositiva un segnaposto titolo o immagine, verifica i tipi di segnaposto e forma, aggiorna il contenuto appropriato e salva l'output. L'esempio evita deliberatamente di presumere un indice di forma o di castare ogni segnaposto alla stessa interfaccia.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Che cos'è un segnaposto base?**

Un segnaposto base è la forma corrispondente nel layout o nel master da cui un altro segnaposto eredita. Usa [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/getbaseplaceholder/) per recuperarlo. Una forma locale ordinaria restituisce `nullptr` perché non fa parte della gerarchia dei segnaposti.

**Posso cambiare tutti i titoli delle diapositive modificando un segnaposto layout?**

Puoi modificare la formattazione ereditata o il testo di prompt tramite un layout, ma il contenuto reale del titolo è memorizzato sulle diapositive normali. Per sostituire il testo del titolo in tutta la presentazione, itera sulle diapositive e aggiorna ciascun segnaposto titolo.

**Come gestisco i segnaposti data, numero-diapositive, intestazione e piè di pagina?**

Usa i gestori di intestazione e piè di pagina nello scopo appropriato (diapositiva, layout, master, note o dispense). Vedi [Manage Presentation Header and Footer](/slides/it/cpp/presentation-header-and-footer/) per esempi completi.