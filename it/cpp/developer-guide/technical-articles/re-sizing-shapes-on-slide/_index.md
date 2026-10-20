---
title: Ridimensionare forme su diapositive di presentazione in C++
type: docs
weight: 130
url: /it/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/ridimensionamento-forme-su-diapositive/
  - /it/cpp/re-sizing-shapes-on-slide/
keywords:
  - ridimensionare forma
  - cambiare dimensione forma
  - PowerPoint
  - OpenDocument
  - presentazione
  - C++
  - Aspose.Slides
description: "Ridimensiona facilmente forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per C++—automatizza la regolazione del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Quando cambi le dimensioni di una diapositiva, potresti dover anche ridimensionare e riposizionare le sue forme per adattarle alle nuove dimensioni. Questo articolo mostra come ridimensionare manualmente le forme e come gestire le tabelle su diapositive, master e layout.

## **Ridimensionare forme**

Per conservare la posizione e le dimensioni relative di ogni forma, moltiplica le sue coordinate orizzontali e la larghezza per il rapporto tra la larghezza della nuova diapositiva e quella originale. Applica il corrispondente rapporto di altezza alle sue coordinate verticali e all'altezza.

Il primo esempio carica una presentazione le cui diapositive non contengono tabelle, cambia la dimensione della diapositiva in A4 e salva il risultato. Usa [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) con [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) in modo che il ciclo successivo controlli la scalatura. I rapporti sono adimensionali; le posizioni e le dimensioni delle forme sono misurate in punti. Rapporti diversi di larghezza e altezza possono deformare le forme, e modificare le dimensioni di una forma non scala le dimensioni del carattere.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Le tabelle richiedono una gestione separata: scala le larghezze delle colonne e le altezze delle righe invece di assegnare la larghezza e l'altezza complessive della tabella. Le altezze delle righe possono rimanere maggiori di quanto richiesto se il contenuto della cella richiede più spazio.
{{% /alert %}}

Il secondo esempio supporta le tabelle e processa le forme su master e layout oltre che su diapositive individuali prima di salvare la presentazione ridimensionata. Il suo helper gestisce ogni [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) scalando [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) e [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/). Quindi scala la posizione della tabella senza scalare separatamente le sue dimensioni complessive.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calcola fattori di scala orizzontali e verticali indipendenti.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // Le dimensioni della tabella sono controllate dalle larghezze delle colonne e dalle altezze delle righe.
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// Ridimensiona le forme definite su master e layout così come sulle diapositive individuali.
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Domande frequenti**

**Perché le forme risultano distorte o tagliate dopo aver ridimensionato una diapositiva?**

Se cambi le dimensioni della diapositiva senza scalare le forme, queste mantengono le loro posizioni e dimensioni originali e possono estendersi oltre la diapositiva. Scalare larghezza e altezza con rapporti diversi può anche deformare le forme.

**Il codice fornito funziona per tutti i tipi di forma?**

Il primo esempio modifica direttamente i confini delle forme ed è destinato a diapositive senza tabelle. Il secondo esempio gestisce le tabelle separatamente. Controlla il layout risultante, in particolare testo e tabelle, perché questi esempi non scalano le dimensioni del carattere e il contenuto delle tabelle può limitare le altezze delle righe.

**Come ridimensionare le tabelle durante il ridimensionamento di una diapositiva?**

Scala le larghezze delle colonne usando il rapporto di larghezza e le altezze minime delle righe usando il rapporto di altezza, quindi scala la posizione della tabella, come mostrato nel secondo esempio.

**Il ridimensionamento funziona per le diapositive master e le diapositive di layout?**

Sì. Il secondo esempio itera attraverso [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) e le [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) di ogni master e applica la stessa logica di ridimensionamento alle loro forme.

**Posso cambiare l'orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?**

Sì. Imposta [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) dopo aver cambiato le dimensioni della diapositiva e prima di leggere le dimensioni target, così i fattori di scala riflettono l'orientamento finale.

**Esiste un limite alle dimensioni della diapositiva che posso impostare?**

Puoi specificare dimensioni personalizzate della diapositiva con [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/). Le dimensioni supportate dipendono anche dal formato della presentazione e dall'applicazione usata per aprire il file.

**Come posso evitare che le forme con rapporto d'aspetto fisso vengano distorte?**

Usa lo stesso fattore di scala per larghezza e altezza. Per adattare il layout originale alle nuove dimensioni della diapositiva, utilizza il più piccolo dei due rapporti (larghezza o altezza) per entrambe le dimensioni e le posizioni. Questo preserva le proporzioni ma può lasciare spazio inutilizzato lungo un bordo.