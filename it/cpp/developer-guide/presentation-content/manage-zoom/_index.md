---
title: Gestire lo Zoom della Presentazione in C++
linktitle: Gestire Zoom
type: docs
weight: 60
url: /it/cpp/manage-zoom/
keywords:
- zoom
- frame zoom
- zoom diapositiva
- zoom sezione
- zoom riepilogo
- aggiungere zoom
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Crea e personalizza lo Zoom con Aspose.Slides per C++ — passa tra le sezioni, aggiungi miniature e transizioni in presentazioni PPT, PPTX e ODP."
---
## **Introduzione**

Gli Zoom in PowerPoint consentono di passare rapidamente a diapositive, sezioni e parti specifiche di una presentazione e di tornare indietro. Durante la presentazione, questa capacità di navigare rapidamente tra i contenuti può rivelarsi molto utile. 

![overview_image](Overview.png)

* Per riassumere un’intera presentazione in un’unica diapositiva, usa uno [Summary Zoom](#Summary-Zoom).
* Per mostrare solo diapositive selezionate, usa uno [Slide Zoom](#Slide-Zoom).
* Per mostrare una sola sezione, usa uno [Section Zoom](#Section-Zoom).

## **Slide Zoom**
Uno slide zoom può rendere la tua presentazione più dinamica, consentendoti di navigare liberamente tra le diapositive in qualsiasi ordine tu scelga senza interrompere il flusso della presentazione. Gli slide zoom sono ideali per presentazioni brevi senza molte sezioni, ma puoi usarli comunque in diversi scenari di presentazione.

Gli slide zoom ti aiutano a approfondire più informazioni mantenendo la sensazione di lavorare su un’unica tela. 

![overview_image](slidezoomsel.png)

Per gli oggetti slide zoom, Aspose.Slides fornisce l’enumerazione [ZoomImageType](https://reference.aspose.com/slides/it/cpp/aspose.slides/zoomimagetype/), l’interfaccia [IZoomFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/izoomframe/) e alcuni metodi dell’interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/).

### **Creare frame di zoom**

Puoi aggiungere un frame di zoom a una diapositiva in questo modo:

1.	Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2.	Crea nuove diapositive a cui intendi collegare i frame di zoom. 
3.	Aggiungi un testo di identificazione e uno sfondo alle diapositive create.
4.	Aggiungi i frame di zoom (contenenti i riferimenti alle diapositive create) alla prima diapositiva.
5.	Salva la presentazione modificata come file PPTX.

Questo codice C++ mostra come creare un frame di zoom su una diapositiva:

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Aggiunge nuove diapositive alla presentazione
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

//Crea uno sfondo per la seconda diapositiva
SetSlideBackground(slide2, Color::get_Cyan());

//Crea una casella di testo per la seconda diapositiva
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Crea uno sfondo per la terza diapositiva
SetSlideBackground(slide3, Color::get_DarkKhaki());

//Crea una casella di testo per la terza diapositiva
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Aggiunge oggetti ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

//Salva la presentazione
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Creare frame di zoom con immagini personalizzate**
Con Aspose.Slides per C++, puoi creare un frame di zoom con un’immagine di anteprima della diapositiva diversa in questo modo: 
1.	Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2.	Crea una nuova diapositiva a cui intendi collegare il frame di zoom. 
3.	Aggiungi un testo di identificazione e uno sfondo alla diapositiva.
4.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) aggiungendo un’immagine alla raccolta Images associata all’oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) che verrà utilizzata per riempire il frame.
5.	Aggiungi i frame di zoom (contenenti il riferimento alla diapositiva creata) alla prima diapositiva.
6.	Salva la presentazione modificata come file PPTX.

Questo codice C++ mostra come creare un frame di zoom con un’immagine diversa:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Aggiunge una nuova diapositiva alla presentazione
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

//Crea uno sfondo per la seconda diapositiva
SetSlideBackground(slide, Color::get_Cyan());

//Crea una casella di testo per la terza diapositiva
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Crea una nuova immagine per l'oggetto zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Aggiunge l'oggetto ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Salva la presentazione
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formattare i frame di zoom**
Nelle sezioni precedenti abbiamo mostrato come creare semplici frame di zoom. Per creare frame di zoom più complessi, è necessario modificare la formattazione di un frame semplice. Esistono diverse opzioni di formattazione che puoi applicare a un frame di zoom. 

Puoi controllare la formattazione di un frame di zoom su una diapositiva in questo modo:

1.	Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2.	Crea nuove diapositive a cui intendi collegare il frame di zoom. 
3.	Aggiungi del testo di identificazione e uno sfondo alle diapositive create.
4.	Aggiungi i frame di zoom (contenenti i riferimenti alle diapositive create) alla prima diapositiva.
5.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) aggiungendo un’immagine alla raccolta Images associata all’oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) che verrà utilizzata per riempire il frame.
6.	Imposta un’immagine personalizzata per il primo oggetto frame di zoom.
7.	Modifica il formato della linea per il secondo oggetto frame di zoom.
8.	Rimuovi lo sfondo dell’immagine del secondo oggetto frame di zoom.
5.	Salva la presentazione modificata come file PPTX.

Questo codice C++ mostra come modificare la formattazione di un frame di zoom su una diapositiva: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Aggiunge nuove diapositive alla presentazione
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

//Crea uno sfondo per la seconda diapositiva
SetSlideBackground(slide2, Color::get_Cyan());

//Crea una casella di testo per la seconda diapositiva
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Crea uno sfondo per la terza diapositiva
SetSlideBackground(slide3, Color::get_DarkKhaki());

//Crea una casella di testo per la terza diapositiva
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Aggiunge oggetti ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

//Crea una nuova immagine per l'oggetto zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
//Imposta un'immagine personalizzata per l'oggetto zoomFrame1
zoomFrame1->set_Image(image);

//Imposta un formato di frame zoom per l'oggetto zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

//Impostazione per non mostrare lo sfondo per l'oggetto zoomFrame2
zoomFrame2->set_ShowBackground(false);

//Salva la presentazione
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Section Zoom**

Uno section zoom è un collegamento a una sezione della tua presentazione. Puoi usare gli section zoom per tornare a sezioni che desideri enfatizzare o per evidenziare come determinate parti della presentazione siano collegate tra loro. 

![overview_image](seczoomsel.png)

Per gli oggetti section zoom, Aspose.Slides fornisce l’interfaccia [ISectionZoomFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/isectionzoomframe/) e alcuni metodi dell’interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/).

### **Creare frame di section zoom**

Puoi aggiungere un frame di section zoom a una diapositiva in questo modo:

1.	Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2.	Crea una nuova diapositiva. 
3.	Aggiungi uno sfondo di identificazione alla diapositiva creata.
4.	Crea una nuova sezione a cui intendi collegare il frame di zoom. 
5.	Aggiungi un frame di section zoom (contenente i riferimenti alla sezione creata) alla prima diapositiva.
6.	Salva la presentazione modificata come file PPTX.

Questo codice C++ mostra come creare un frame di zoom su una diapositiva:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Aggiunge una nuova diapositiva alla presentazione
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Aggiunge una nuova sezione alla presentazione
pres->get_Sections()->AddSection(u"Section 1", slide);

// Aggiunge un oggetto SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Salva la presentazione
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Creare frame di section zoom con immagini personalizzate**

Usando Aspose.Slides per C++, puoi creare un frame di section zoom con un’immagine di anteprima della diapositiva diversa in questo modo: 

1.	Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2.	Crea una nuova diapositiva.
3.	Aggiungi uno sfondo di identificazione alla diapositiva creata.
4.	Crea una nuova sezione a cui intendi collegare il frame di zoom. 
5.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) aggiungendo un’immagine alla raccolta Images associata all’oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) che verrà utilizzata per riempire il frame.
5.	Aggiungi un frame di section zoom (contenente un riferimento alla sezione creata) alla prima diapositiva.
6.	Salva la presentazione modificata come file PPTX.

Questo codice C++ mostra come creare un frame di zoom con un’immagine diversa:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Aggiunge nuova diapositiva alla presentazione
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Aggiunge una nuova sezione alla presentazione
pres->get_Sections()->AddSection(u"Section 1", slide);

// Crea una nuova immagine per l'oggetto zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Aggiunge oggetto SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Salva la presentazione
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formattare i frame di section zoom**

Per creare frame di section zoom più complessi, è necessario modificare la formattazione di un frame semplice. Esistono diverse opzioni di formattazione che puoi applicare a un frame di section zoom. 

Puoi controllare la formattazione di un frame di section zoom su una diapositiva in questo modo:

1.	Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2.	Crea una nuova diapositiva.
3.	Aggiungi uno sfondo di identificazione alla diapositiva creata.
4.	Crea una nuova sezione a cui intendi collegare il frame di zoom. 
5.	Aggiungi un frame di section zoom (contenente i riferimenti alla sezione creata) alla prima diapositiva.
6.	Modifica la dimensione e la posizione dell’oggetto di section zoom creato.
7.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) aggiungendo un’immagine alla raccolta Images associata all’oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) che verrà utilizzata per riempire il frame.
8.	Imposta un’immagine personalizzata per l’oggetto frame di section zoom creato.
9.	Imposta la capacità di *ritornare alla diapositiva originale dalla sezione collegata*. 
10.	Rimuovi lo sfondo dell’immagine dell’oggetto frame di section zoom.
11.	Modifica il formato della linea per il secondo frame di zoom.
12.	Modifica la durata della transizione.
13.	Salva la presentazione modificata come file PPTX.

Questo codice C++ mostra come modificare la formattazione di un frame di section zoom:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Aggiunge nuova diapositiva alla presentazione
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Aggiunge una nuova sezione alla presentazione
pres->get_Sections()->AddSection(u"Section 1", slide);

// Aggiunge oggetto SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Formattazione per SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// Salva la presentazione
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Summary Zoom**

Uno summary zoom è simile a una pagina di destinazione in cui tutte le parti della presentazione sono visualizzate contemporaneamente. Quando presenti, puoi usare lo zoom per passare da una parte all’altra della presentazione in qualsiasi ordine desideri. Puoi essere creativo, saltare in avanti o tornare su parti della presentazione senza interrompere il flusso. 

![overview_image](sumzoomsel.png)

Per gli oggetti summary zoom, Aspose.Slides fornisce le interfacce [ISummaryZoomFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isummaryzoomsection/) e [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isummaryzoomsectioncollection/) e alcuni metodi dell’interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/).

### **Creare Summary Zoom**

Puoi aggiungere un frame di summary zoom a una diapositiva in questo modo:

1.	Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2.	Crea nuove diapositive con sfondo di identificazione e nuove sezioni per le diapositive create.
3.	Aggiungi il frame di summary zoom alla prima diapositiva.
4.	Salva la presentazione modificata come file PPTX.

Questo codice C++ mostra come creare un frame di summary zoom su una diapositiva:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Aggiunge una nuova diapositiva alla presentazione
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Aggiunge una nuova sezione alla presentazione
pres->get_Sections()->AddSection(u"Section 1", slide);

// Aggiunge una nuova diapositiva alla presentazione
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Aggiunge una nuova sezione alla presentazione
pres->get_Sections()->AddSection(u"Section 2", slide);

// Aggiunge una nuova diapositiva alla presentazione
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Aggiunge una nuova sezione alla presentazione
pres->get_Sections()->AddSection(u"Section 3", slide);

// Aggiunge una nuova diapositiva alla presentazione
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Aggiunge una nuova sezione alla presentazione
pres->get_Sections()->AddSection(u"Section 4", slide);

// Aggiunge un oggetto SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Salva la presentazione
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Aggiungere e rimuovere una sezione di Summary Zoom**

Tutte le sezioni in un frame di summary zoom sono rappresentate da oggetti [ISummaryZoomSection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isummaryzoomsection/), memorizzati nell’oggetto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isummaryzoomsectioncollection/). Puoi aggiungere o rimuovere un oggetto sezione di summary zoom tramite l’interfaccia [ISummaryZoomSectionCollection] in questo modo:

1.	Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2.	Crea nuove diapositive con sfondo di identificazione e nuove sezioni per le diapositive create.
3.	Aggiungi un frame di summary zoom alla prima diapositiva.
4.	Aggiungi una nuova diapositiva e una sezione alla presentazione.
5.	Aggiungi la sezione creata al frame di summary zoom.
6.	Rimuovi la prima sezione dal frame di summary zoom.
7.	Salva la presentazione modificata come file PPTX.

Questo codice C++ mostra come aggiungere e rimuovere sezioni in un frame di summary zoom:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Aggiunge una nuova diapositiva alla presentazione
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Aggiunge una nuova sezione alla presentazione
pres->get_Sections()->AddSection(u"Section 1", slide);

//Aggiunge una nuova diapositiva alla presentazione
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Aggiunge una nuova sezione alla presentazione
pres->get_Sections()->AddSection(u"Section 2", slide);

// Aggiunge oggetto SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Aggiunge una nuova diapositiva alla presentazione
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Aggiunge una nuova sezione alla presentazione
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Aggiunge una sezione allo Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Rimuove la sezione dallo Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Salva la presentazione
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formattare le sezioni di Summary Zoom**

Per creare oggetti di sezione di summary zoom più complessi, è necessario modificare la formattazione di un frame semplice. Esistono diverse opzioni di formattazione che puoi applicare a un oggetto sezione di summary zoom. 

Puoi controllare la formattazione di un oggetto sezione di summary zoom in un frame di summary zoom in questo modo:

1.	Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2.	Crea nuove diapositive con sfondo di identificazione e nuove sezioni per le diapositive create.
3.	Aggiungi un frame di summary zoom alla prima diapositiva.
4.	Ottieni un oggetto sezione di summary zoom dal `ISummaryZoomSectionCollection` per il primo oggetto.
7.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) aggiungendo un’immagine alla raccolta images associata all’oggetto [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) che verrà usata per riempire il frame.
8.	Imposta un’immagine personalizzata per l’oggetto frame di sezione di summary zoom creato.
9.	Imposta la capacità di *ritornare alla diapositiva originale dalla sezione collegata*. 
11.	Modifica il formato della linea per il secondo frame di zoom.
12.	Modifica la durata della transizione.
13.	Salva la presentazione modificata come file PPTX.

Questo codice C++ mostra come modificare la formattazione di un oggetto sezione di summary zoom:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Aggiunge una nuova diapositiva alla presentazione
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Aggiunge una nuova sezione alla presentazione
pres->get_Sections()->AddSection(u"Section 1", slide);

//Aggiunge una nuova diapositiva alla presentazione
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Aggiunge una nuova sezione alla presentazione
pres->get_Sections()->AddSection(u"Section 2", slide);

// Aggiunge un oggetto SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Ottiene il primo oggetto SummaryZoomSection
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Formattazione per l'oggetto SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Salva la presentazione
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso controllare il ritorno alla diapositiva “genitore” dopo aver mostrato il contenuto di destinazione?**

Sì. Il [Zoom frame](https://reference.aspose.com/slides/it/cpp/aspose.slides/zoomframe/) o il [section](https://reference.aspose.com/slides/it/cpp/aspose.slides/sectionzoomframe/) dispone di un metodo `set_ReturnToParent` che riporta gli spettatori alla diapositiva di origine dopo aver visitato il contenuto di destinazione.

**Posso regolare la “velocità” o la durata della transizione Zoom?**

Sì. Lo Zoom supporta l’impostazione di una durata di transizione così da poter controllare quanto tempo impiega l’animazione di salto.

**Ci sono limiti al numero di oggetti Zoom che una presentazione può contenere?**

Non esiste un limite API rigido documentato. I limiti pratici dipendono dalla complessità complessiva della presentazione e dalle prestazioni del visualizzatore. Puoi aggiungere molti frame di Zoom, ma considera la dimensione del file e i tempi di rendering.