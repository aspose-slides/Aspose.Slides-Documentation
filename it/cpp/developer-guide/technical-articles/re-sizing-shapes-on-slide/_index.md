---
title: Ridimensionare forme nelle diapositive della presentazione
type: docs
weight: 100
url: /it/cpp/re-sizing-shapes-on-slide/
keywords:
- ridimensionare forma
- cambiare dimensione della forma
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Ridimensiona facilmente le forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per C++—automatizza le regolazioni del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Una delle domande più frequenti dei clienti di Aspose.Slides per C++ è come ridimensionare le forme in modo che, quando le dimensioni della diapositiva cambiano, i dati non vengano tagliati. Questo breve articolo tecnico mostra come farlo.

## **Ridimensiona forme**

Per evitare che le forme si disallineino quando le dimensioni della diapositiva cambiano, aggiorna la posizione e le dimensioni di ciascuna forma affinché si conformino al nuovo layout della diapositiva.

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

// Carica il file di presentazione.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Ottieni le dimensioni originali della diapositiva.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Cambia le dimensioni della diapositiva senza scalare le forme esistenti.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Ottieni le nuove dimensioni della diapositiva.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Ridimensiona e riposiziona le forme su ogni diapositiva.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Scala le dimensioni della forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Scala la posizione della forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
Se una diapositiva contiene una tabella, il codice sopra non funzionerà correttamente. In tal caso, ogni cella della tabella deve essere ridimensionata.
{{% /alert %}} 

Utilizza il seguente codice per ridimensionare le diapositive che contengono tabelle. Per le tabelle, impostare la larghezza o l’altezza è un caso speciale: è necessario regolare le altezze delle righe e le larghezze delle colonne individuali per modificare le dimensioni complessive della tabella.

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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ottieni le dimensioni originali della diapositiva.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Cambia le dimensioni della diapositiva senza scalare le forme esistenti.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Ottieni le nuove dimensioni della diapositiva.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Scala le dimensioni della forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Scala la posizione della forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Scala le dimensioni della forma.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Scala la posizione della forma.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Scala le dimensioni della forma.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Scala la posizione della forma.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

### Perché le forme sono distorte o tagliate dopo aver ridimensionato una diapositiva?

Quando si ridimensiona una diapositiva, le forme mantengono la loro posizione e dimensione originali a meno che la scala non venga modificata esplicitamente. Ciò può provocare il ritaglio del contenuto o il disallineamento delle forme.

### Il codice fornito funziona per tutti i tipi di forma?

L’esempio di base funziona per la maggior parte dei tipi di forma (caselle di testo, immagini, grafici, ecc.). Tuttavia, per le tabelle è necessario gestire righe e colonne separatamente, poiché l’altezza e la larghezza di una tabella sono determinate dalle dimensioni delle singole celle.

### Come ridimensionare le tabelle quando si ridimensiona una diapositiva?

È necessario iterare su tutte le righe e colonne della tabella e ridimensionare la loro altezza e larghezza proporzionalmente, come mostrato nel secondo esempio di codice.

### Questo ridimensionamento funzionerà per le diapositive master e le diapositive layout?

Sì, ma dovresti anche iterare attraverso i [Masters](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_masters/) e le [Layout slides](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_layoutslides/) e applicare la stessa logica di scaling alle loro forme per garantire la coerenza nella presentazione.

### Posso cambiare l'orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?

Sì. Puoi usare [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/it/cpp/aspose.slides/islidesize/set_orientation/) per cambiare l’orientamento. Assicurati di impostare la logica di scaling di conseguenza per preservare il layout.

### Esiste un limite alle dimensioni della diapositiva che posso impostare?

Aspose.Slides supporta dimensioni personalizzate, ma dimensioni molto grandi possono influire sulle prestazioni o sulla compatibilità con alcune versioni di PowerPoint.

### Come posso impedire che le forme con rapporto d'aspetto fisso si distorcano?

Puoi verificare il metodo `get_AspectRatioLocked` della forma prima di eseguire lo scaling. Se è bloccato, regola larghezza o altezza proporzionalmente anziché scalarle singolarmente.