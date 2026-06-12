---
title: "Migliora l'elaborazione delle immagini con l'API Moderna"
linktitle: "API Moderna"
type: docs
weight: 237
url: /it/net/modern-api/
keywords:
- System.Drawing
- API moderna
- disegno
- miniatura di diapositiva
- diapositiva a immagine
- miniatura di forma
- forma a immagine
- miniatura di presentazione
- presentazione a immagini
- aggiungi immagine
- aggiungi immagine
- .NET
- C#
- Aspose.Slides
description: "Modernizza l'elaborazione delle immagini delle diapositive sostituendo le API di imaging obsolete con la Modern API .NET per un'automazione fluida di PowerPoint e OpenDocument."
---
## **Introduzione**

Storicamente, Aspose Slides ha una dipendenza da System.Drawing e ha nell'API pubblica le seguenti classi provenienti da lì:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

A partire dalla versione 24.4, questa API pubblica è dichiarata obsoleta.

Poiché il supporto di System.Drawing nelle versioni .NET6 e successive è stato rimosso per le versioni non Windows ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides ha implementato un approccio a due pacchetti:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - supporto per .NET6+ per Windows, .NETStandard per Windows/Linux/macOS, .NETFramework 2+ (Windows).
  - ha una dipendenza da [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - versione Windows/Linux/macOS senza dipendenze.

La difficoltà di [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) è che implementa la propria versione di System.Drawing nello stesso namespace (per supportare la retrocompatibilità con l'API pubblica). Pertanto, quando Aspose.Slides.NET6.CrossPlatform e System.Drawing dal .NET Framework o dal pacchetto System.Drawing.Common vengono usati contemporaneamente, si verifica un conflitto di nomi a meno che non venga usato un alias.

Per eliminare le dipendenze da System.Drawing nel pacchetto principale Aspose.Slides.NET, abbiamo aggiunto la cosiddetta "Modern API" – cioè l'API da utilizzare al posto di quella deprecata, le cui firme contengono dipendenze dai seguenti tipi di System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) e [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) e [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) sono dichiarati obsoleti e il loro supporto è stato rimosso dall'API pubblica di Slides.

Nelle versioni attuali, considerare l'API pubblica che dipende da System.Drawing come legacy/obsoleta. Utilizzare la Modern API per nuovo codice e quando si migra i flussi di lavoro di elaborazione delle immagini esistenti.

## **API Moderna**

Aggiunte le seguenti classi e enum all'API pubblica:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) - rappresenta l'immagine raster o vettoriale.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/it/net/aspose.slides/imageformat/) - rappresenta il formato file dell'immagine.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/it/net/aspose.slides/images/) - metodi per istanziare e lavorare con l'interfaccia [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/).

Si noti che [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) è disposable (implementa l'interfaccia [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) e il suo utilizzo dovrebbe essere avvolto in un using o eliminato in un altro modo pratico).

Usa `GetImage` per renderizzare una singola diapositiva o forma. Usa `GetImages` per renderizzare diverse diapositive della presentazione. Usa i metodi di [Images](https://reference.aspose.com/slides/it/net/aspose.slides/images/) per caricare le immagini, `AddImage` con [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) per aggiungerle a una presentazione, e `ReplaceImage` con [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) per aggiornare un'immagine esistente della presentazione.

Uno scenario tipico di utilizzo della nuova API può apparire come segue:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // istanzia un'istanza disposable di IImage dal file sul disco.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // crea un'immagine PowerPoint aggiungendo un'istanza di IImage alle immagini della presentazione.
        ppImage = pres.Images.AddImage(image);
    }

    // aggiungi una forma immagine sulla diapositiva #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // ottieni un'istanza di IImage che rappresenta la diapositiva #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // salva l'immagine sul disco.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Sostituire il Codice Obsoleto con la Modern API**

Per facilitare la transizione, l'interfaccia del nuovo [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) ripete le firme separate delle classi [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) e [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). In generale, dovrai semplicemente sostituire la chiamata al metodo vecchio che utilizza System.Drawing con quella nuova.

### **Ottenere una Miniatura della Diapositiva**

API legacy/obsoleta:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

API Moderna:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Ottenere una Miniatura della Forma**

API legacy/obsoleta:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

API Moderna:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Ottenere una Miniatura della Presentazione**

API legacy/obsoleta:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var bitmaps = pres.GetThumbnails(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < bitmaps.Length; index++)
        {
            Bitmap thumbnail = bitmaps[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (Bitmap bitmap in bitmaps)
        {
            bitmap.Dispose();
        }
    }
}
```

API Moderna:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var images = pres.GetImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < images.Length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (IImage image in images)
        {
            image.Dispose();
        }
    }
}
```

### **Aggiungere un'Immagine a una Presentazione**

API legacy/obsoleta:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image image = Image.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

API Moderna:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (IImage image = Aspose.Slides.Images.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

## **Metodi/Proprietà Deprecati e le loro Sostituzioni nella Modern API**

### **Presentazione**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Forma**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/it/net/aspose.slides/shape/getimage#getimage_1) |

### **Diapositiva**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/it/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/it/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/it/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Firma del Metodo/Proprietà | Firma del Metodo di Sostituzione |
|----------------------------|----------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/it/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/it/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/it/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/it/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/it/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Supporto API per Graphics e PrinterSettings**

La classe [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) non è supportata per le versioni cross‑platform di .NET6 e superiori. In Aspose Slides, usa i metodi di rendering di immagini della Modern API invece dell'API che renderizza su [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/it/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/it/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/it/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Inoltre, l'API correlata alla stampa tramite [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) non ha una sostituzione diretta nella Modern API:

[IPresentation](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/print/#print_2)

## **Domande Frequenti**

**Perché è stata rimossa [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)?**

Il supporto per [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) è deprecato nell'API pubblica per unificare il lavoro con il rendering e le immagini, eliminare i legami a dipendenze specifiche della piattaforma e passare a un approccio cross‑platform con [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/). Usa `GetImage` o `GetImages` invece di renderizzare su [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

**Qual è il beneficio pratico di [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) rispetto a [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)?**

[IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) unifica il lavoro con immagini raster e vettoriali, semplifica il salvataggio in vari formati tramite [ImageFormat](https://reference.aspose.com/slides/it/net/aspose.slides/imageformat/), riduce la dipendenza da `System.Drawing` e rende il codice più portabile tra ambienti.

**Il Modern API influenzerà le prestazioni nella generazione delle miniature?**

Il passaggio da `GetThumbnail` a `GetImage` non peggiora gli scenari: i nuovi metodi offrono le stesse capacità di produrre immagini con opzioni e dimensioni, mantenendo il supporto per le opzioni di rendering. Il guadagno o la perdita specifici dipendono dallo scenario, ma funzionalmente le sostituzioni sono equivalenti.