---
title: "Migliora l'elaborazione delle immagini con l'API moderna"
linktitle: "API Moderna"
type: docs
weight: 280
url: /it/cpp/modern-api/
keywords:
- System.Drawing
- API moderna
- disegno
- miniatura diapositiva
- diapositiva in immagine
- miniatura forma
- forma in immagine
- miniatura presentazione
- presentazione in immagini
- aggiungi immagine
- aggiungi foto
- C++
- Aspose.Slides
description: "Modernizza l'elaborazione delle immagini delle diapositive sostituendo le API di imaging obsolete con l'API Moderna C++ per un'automazione fluida di PowerPoint e OpenDocument."
---
## **Introduzione**

Attualmente, la libreria Aspose.Slides per C++ ha dipendenze nella sua API pubblica dalle seguenti classi di System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/it/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/it/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/it/cpp/system.drawing/bitmap/)

A partire dalla versione 24.4, questa API pubblica è dichiarata obsoleta.

Per eliminare le dipendenze da System::Drawing nell'API pubblica, abbiamo aggiunto quella che viene chiamata “Modern API”. I metodi con [System::Drawing::Image](https://reference.aspose.com/slides/it/cpp/system.drawing/image/) e [System::Drawing::Bitmap](https://reference.aspose.com/slides/it/cpp/system.drawing/bitmap/) sono dichiarati obsoleti e dovrebbero essere sostituiti con i corrispondenti metodi della Modern API. I metodi con [System::Drawing::Graphics](https://reference.aspose.com/slides/it/cpp/system.drawing/graphics/) sono dichiarati obsoleti e non hanno una sostituzione diretta nella Modern API.

Nelle versioni attuali, considera l'API pubblica che dipende dai tipi System::Drawing come legacy/obsoleta. Usa la Modern API per nuovo codice e quando migri i flussi di lavoro di elaborazione immagini esistenti.

## **API moderna**

Sono state aggiunte le seguenti classi ed enum all'API pubblica:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) - rappresenta l'immagine raster o vettoriale.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/imageformat/) - rappresenta il formato file dell'immagine.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/it/cpp/aspose.slides/images/) - metodi per istanziare e lavorare con l'interfaccia [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/).

Usa `GetImage` per renderizzare una singola diapositiva o forma. Usa `GetImages` per renderizzare più diapositive della presentazione. Usa i metodi di [Images](https://reference.aspose.com/slides/it/cpp/aspose.slides/images/) per caricare immagini, `AddImage` con [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) per aggiungerle a una presentazione, e `ReplaceImage` con [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) per aggiornare un'immagine esistente della presentazione.

Uno scenario tipico di utilizzo della nuova API può apparire come segue:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// istanziare un'istanza di IImage eliminabile dal file su disco.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// creare un'immagine PowerPoint aggiungendo un'istanza di IImage alle immagini della presentazione.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// aggiungere una forma immagine nella diapositiva #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// ottenere un'istanza di IImage che rappresenta la diapositiva #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// salvare l'immagine su disco.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Sostituire il vecchio codice con l'API moderna**

Per facilitare la transizione, l'interfaccia del nuovo [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) ripete le firme separate delle classi [System::Drawing::Image](https://reference.aspose.com/slides/it/cpp/system.drawing/image/) e [System::Drawing::Bitmap](https://reference.aspose.com/slides/it/cpp/system.drawing/bitmap/). In generale, dovrai semplicemente sostituire la chiamata al vecchio metodo che utilizza System::Drawing con quella nuova.

### **Ottenere una miniatura della diapositiva**

API legacy/obsoleta:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

API moderna:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Ottenere una miniatura della forma**

API legacy/obsoleta:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

API moderna:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Ottenere una miniatura della presentazione**

API legacy/obsoleta:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

API moderna:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **Aggiungere un'immagine a una presentazione**

API legacy/obsoleta:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

API moderna:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **Metodi/Proprietà obsoleti e loro sostituzione nell'API moderna**

### **Classe Presentation**
|Firma del metodo|Firma del metodo di sostituzione|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Classe Slide**
|Firma del metodo|Firma del metodo di sostituzione|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **Classe Shape**
|Firma del metodo|Firma del metodo di sostituzione|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **Classe ImageCollection**
|Firma del metodo|Firma del metodo di sostituzione|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **Classe PPImage**
|Firma del metodo|Firma del metodo di sostituzione|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **Classe PatternFormat**
|Firma del metodo|Firma del metodo di sostituzione|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **Classe IPatternFormatEffectiveData**
|Firma del metodo|Firma del metodo di sostituzione|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Supporto API per System::Drawing::Graphics**

I metodi con [System::Drawing::Graphics](https://reference.aspose.com/slides/it/cpp/system.drawing/graphics/) sono dichiarati obsoleti e non hanno una sostituzione diretta nella Modern API.

Usa i metodi di rendering immagini della Modern API invece dell'API che renderizza su [System::Drawing::Graphics](https://reference.aspose.com/slides/it/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**Perché è stata rimossa [System::Drawing::Graphics](https://reference.aspose.com/slides/it/cpp/system.drawing/graphics/)?**

Il supporto a [System::Drawing::Graphics](https://reference.aspose.com/slides/it/cpp/system.drawing/graphics/) è obsoleto nell'API pubblica per uniformare il lavoro di rendering e immagini, eliminare i legami con dipendenze specifiche della piattaforma e passare a un approccio cross‑platform con [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/). Usa `GetImage` o `GetImages` invece di renderizzare su [System::Drawing::Graphics](https://reference.aspose.com/slides/it/cpp/system.drawing/graphics/).

**Qual è il vantaggio pratico di [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) rispetto a [System::Drawing::Image](https://reference.aspose.com/slides/it/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/it/cpp/system.drawing/bitmap/)?**

[IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) unifica la gestione di immagini raster e vettoriali, semplifica il salvataggio in vari formati tramite [ImageFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/imageformat/), riduce la dipendenza da `System::Drawing` e rende il codice più portabile tra ambienti.

**L'API moderna influenzerà le prestazioni nella generazione delle miniature?**

Il passaggio da `GetThumbnail` a `GetImage` non peggiora gli scenari: i nuovi metodi forniscono le stesse capacità per produrre immagini con opzioni e dimensioni, mantenendo il supporto per le opzioni di rendering. Il guadagno o la perdita specifica dipende dallo scenario, ma funzionalmente le sostituzioni sono equivalenti.