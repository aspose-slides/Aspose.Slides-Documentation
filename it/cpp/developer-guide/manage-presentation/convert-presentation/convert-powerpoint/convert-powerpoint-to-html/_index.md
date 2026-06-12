---
title: Converti le presentazioni PowerPoint in HTML in C++
linktitle: PowerPoint in HTML
type: docs
weight: 30
url: /it/cpp/convert-powerpoint-to-html/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in HTML
- presentazione in HTML
- diapositiva in HTML
- PPT in HTML
- PPTX in HTML
- salva PowerPoint come HTML
- salva presentazione come HTML
- salva diapositiva come HTML
- salva PPT come HTML
- salva PPTX come HTML
- esporta PPT in HTML
- esporta PPTX in HTML
- C++
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in HTML in C++. Usa Aspose.Slides per esportare file PPT e PPTX, diapositive selezionate, note, font, immagini, SVG e media."
---
## **Panoramica**

Aspose.Slides per C++ può salvare presentazioni PowerPoint come HTML senza Microsoft PowerPoint. La conversione di base consiste in un singolo caricamento di una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e una chiamata `Save` con [SaveFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveformat/). Utilizza [HtmlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/htmloptions/) quando è necessario controllare il layout esportato, i font, le immagini, le note, i commenti, l’output SVG o le risorse collegate.

Questa guida si concentra su scenari pratici di esportazione HTML:

- Esporta un’intera presentazione o diapositive selezionate.
- Genera HTML a layout fisso, responsive o basato su SVG.
- Includi note del relatore e commenti.
- Controlla la qualità delle immagini e i dati delle aree ritagliate.
- Inserisci i font o salva i file dei font separatamente.
- Scegli come le risorse esterne e i file multimediali vengono scritti e referenziati.

Per impostazione predefinita, l’esportazione HTML produce un documento HTML autosufficiente in cui la maggior parte delle risorse è incorporata. Questo è comodo per condividere un unico file, ma può aumentare la dimensione dell’output. Per la pubblicazione web, considera risorse esterne, DPI immagine più bassi e l’inserimento solo dei font non disponibili in modo affidabile nell’ambiente di destinazione.

## **Convertire una Presentazione in HTML**

Per esportare una presentazione in HTML, caricala con [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e salvala con `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Questo esempio scrive un unico file HTML. La chiamata a `Dispose` rilascia i handle dei file e le risorse di rendering dopo l’esportazione.

## **Usare HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/htmloptions/) è la classe di configurazione principale per l’esportazione HTML. Le impostazioni più comuni includono:

- `SlidesLayoutOptions`: aggiunge note, commenti, dispense o altre informazioni di layout.
- `HtmlFormatter`: modifica la struttura del documento HTML o delega la formattazione a un controller.
- `SlideImageFormat`: cambia il modo in cui le diapositive sono rappresentate, ad esempio come SVG.
- `PicturesCompression`: controlla DPI immagine e dimensione dell’output.
- `DeletePicturesCroppedAreas`: mantiene o rimuove i dati delle immagini ritagliate.
- `SvgResponsiveLayout`: fa sì che il contenuto SVG esportato si adatti al contenitore.
- `ShowHiddenSlides`: include le diapositive nascoste quando necessario.

Le sezioni seguenti mostrano le opzioni più comuni separatamente, così da poter combinare solo quelle richieste dal tuo flusso di lavoro.

## **Convertire Diapositive Selezionate in HTML**

Il sovraccarico di `Presentation::Save` che accetta numeri di diapositiva utilizza posizioni basate su indice 1. Il ciclo sotto salva ogni diapositiva in un file HTML separato.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Usa questo modello quando un sito web o un’applicazione necessita di una pagina HTML per diapositiva. Se tutte le diapositive devono avere lo stesso layout, crea un’unica istanza di [HtmlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/htmloptions/) e passala a ciascuna chiamata `Save`.

## **Creare HTML Responsive**

[ResponsiveHtmlController](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/responsivehtmlcontroller/) fornisce un output HTML responsive tramite [HtmlFormatter](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/htmlformatter/). Usalo quando la pagina esportata deve adattarsi meglio alla larghezza del browser.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Per un layout responsive basato su SVG, imposta `SvgResponsiveLayout` su [HtmlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/htmloptions/). Questo è utile quando il contenuto della diapositiva viene esportato come markup SVG scalabile.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Includere Note del Relatore e Commenti**

Usa [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notescommentslayoutingoptions/) tramite `HtmlOptions.SlidesLayoutOptions` per includere note del relatore o commenti. Le note e i commenti sono nascosti per impostazione predefinita, a meno che non ne specifichi le posizioni.

Supponiamo che la presentazione di origine contenga note del relatore:

![Diapositiva con note del relatore in PowerPoint](slide_with_notes.png)

Il codice seguente esporta il contenuto della diapositiva con le note del relatore sotto la diapositiva.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

L’HTML esportato include l’area delle note:

![Output HTML con diapositiva e note del relatore](HTML_with_notes.png)

Per esportare i commenti, imposta `CommentsPosition`, ad esempio su `CommentsPositions::Right` o `CommentsPositions::Bottom`. Se ti servono solo i commenti, ometti `NotesPosition`. Se ti servono sia note sia commenti, imposta entrambe le proprietà.

## **Controllare Qualità Immagine e Aree Ritagliate**

L’esportazione HTML può comprimere le immagini delle diapositive per ridurre la dimensione dell’output. Imposta `PicturesCompression` a un valore di [PicturesCompression](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/picturescompression/) quando hai bisogno di una qualità immagine più alta.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Per impostazione predefinita, le aree ritagliate delle immagini possono essere rimosse dall’output esportato. Mantieni i dati ritagliati solo quando gli utenti devono poterli recuperare o ispezionare. Conservare questi dati può aumentare la dimensione dell’HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Aggiungere CSS**

Per uno stile semplice, passa una stringa CSS a `HtmlFormatter::CreateDocumentFormatter`. Questo modifica il documento HTML circostante mentre Aspose.Slides continua a renderizzare il contenuto della diapositiva.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Per un header documento personalizzato, un file CSS collegato o markup personalizzato attorno a diapositive e forme, implementa [IHtmlFormattingController](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ihtmlformattingcontroller/) e passalo a [HtmlFormatter](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/htmlformatter/) con `CreateCustomFormatter`.

## **Incorporare Font**

Se l’ambiente di destinazione potrebbe non avere installati i font della presentazione, incorpora i font nell’HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/embedallfontshtmlcontroller/). L’incorporamento migliora la fedeltà visiva ma aumenta la dimensione dell’output.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Escludi i font solo quando sei certo che i browser o i sistemi di destinazione li forniscano già. Per i font di brand o meno comuni, l’incorporamento è generalmente più sicuro.

## **Collegare File Font Invece di Incorporarli**

Per ridurre la dimensione del file HTML, puoi scrivere i dati dei font in file WOFF separati e aggiungere regole `@font-face` all’HTML. L’assistente qui sotto estende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/embedallfontshtmlcontroller/) e sovrascrive `WriteFont`.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

In questo esempio, i file dei font vengono salvati in `html-output/fonts`, e l’HTML li riferisce con URL del tipo `fonts/BrandFont-normal-400.woff`. Se il file HTML e i font vengono distribuiti in un’altra posizione, scegli `fontUrlPrefix` in modo che corrisponda al percorso URL distribuito.

## **Salvare Risorse Esterne**

L’HTML autosufficiente è facile da spostare, ma le risorse Base64 incorporate possono rendere il file molto grande. Se la tua applicazione necessita di file immagine esterni, implementa [ILinkEmbedController](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ilinkembedcontroller/) e passalo al costruttore di [HtmlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/htmloptions/).

Quando esternalizzi le risorse, scegli due percorsi in modo consapevole:

- Il percorso di output del file system, dove la tua applicazione scrive immagini, font, audio o video generati.
- Il percorso URL, che è quello usato dal browser dal documento HTML per caricare quei file.

## **Esportare File Multimediali**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/videoplayerhtmlcontroller/) esporta file video e audio e genera HTML che può riprodurli in un browser. Il suo costruttore accetta:

- `path`: la directory in cui saranno scritti i file multimediali generati.
- `fileName`: il nome del file HTML in fase di generazione.
- `baseUri`: il prefisso URI assoluto usato nei collegamenti HTML ai file multimediali.

Se il file HTML è `html-output/presentation.html` e i file multimediali sono salvati in `html-output/media`, `path` deve puntare alla directory media sul disco, mentre `baseUri` deve puntare alla stessa directory dal punto di vista del browser. Per l’anteprima locale, puoi costruire un URI `file:///` dalla directory dei media. Per un’applicazione distribuita, usa l’URL assoluto della directory media pubblicata.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Utilizza directory di output uniche per ogni lavoro di esportazione, specialmente in applicazioni server. Percorsi di output condivisi possono causare la sovrascrittura di file provenienti da conversioni diverse.

## **Prestazioni e Gestione delle Risorse**

La conversione HTML è un’operazione di rendering, quindi tempi di elaborazione e uso di memoria dipendono dal numero di diapositive, dalla risoluzione delle immagini, dai font, dagli effetti, dai grafici e dai media incorporati. Valori DPI più alti per `PicturesCompression`, font incorporati, output SVG e aree ritagliate mantenute possono migliorare la fedeltà ma solitamente aumentano la dimensione dell’output.

Per la conversione batch:

- Disporre tempestivamente di ogni istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
- Utilizzare directory di output separate per lavori distinti.
- Evitare di incorporare font comuni a meno che la fedeltà non lo richieda.
- Ridurre il DPI delle immagini quando l’HTML è destinato a anteprime o miniature.
- Tenere insieme la presentazione di origine, l’HTML generato e le risorse esterne fino a quando i percorsi di distribuzione non sono definitivi.

## **FAQ**

**I collegamenti ipertestuali vengono mantenuti nell’output HTML?**

Sì. I collegamenti ipertestuali della presentazione sono esportati in HTML e rimangono cliccabili quando l’URL di destinazione è valido.

**Posso convertire presentazioni in HTML in parallelo?**

Sì, ma non condividere la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) tra thread. Elabora file diversi con istanze di presentazione separate, stream separati e directory di output distinte. Consulta le [linee guida sul multithreading](/slides/it/cpp/multithreading/) per i dettagli.

**Un oggetto Presentation è thread‑safe?**

No. Una singola istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) deve essere caricata, modificata, salvata e smaltita su un unico thread. Per lavori paralleli, crea un’istanza indipendente per ogni thread o processo.

**Perché il file HTML generato è grande?**

L’esportazione predefinita può incorporare risorse direttamente nell’HTML. Font incorporati, immagini ad alta DPI, media, contenuto SVG e aree di immagine ritagliate mantenute aumentano la dimensione. Usa risorse esterne, escludi i font comuni dall’incorporamento e abbassa `PicturesCompression` quando un output più piccolo è più importante della massima fedeltà.

**Perché una dimensione del font PowerPoint come 24 pt appare come 17.999819 pt in HTML?**

Ciò può accadere perché PowerPoint e HTML usano modelli DPI diversi. PowerPoint memorizza le dimensioni del testo in punti tipografici basati su 72 DPI, mentre il layout HTML si basa su pixel CSS in un modello a 96 DPI. Quando Aspose.Slides esporta una presentazione in HTML, la dimensione del font viene tradotta tra questi sistemi e la conversione può introdurre piccole differenze di arrotondamento.

Questi valori non indicano un reale cambiamento visivo della dimensione del font. Sono solo un effetto matematico secondario della conversione delle metriche testuali tra PowerPoint e HTML.

**Come devo scegliere baseUri per l’esportazione dei media?**

Scegli `baseUri` dal punto di vista del browser e passalo come URI assoluto. Per l’anteprima locale, puoi ottenerlo dalla directory di output con `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. Per la distribuzione, usa l’URL assoluto della directory media pubblicata. Il `path` del file system e il `baseUri` del browser non devono essere la stessa stringa, ma devono descrivere la stessa posizione delle risorse.

**Posso includere diapositive nascoste?**

Sì. Imposta `ShowHiddenSlides` su `true` su [HtmlOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/htmloptions/) quando le diapositive nascoste devono essere esportate.