---
title: Incorporare i font nelle presentazioni con C++
linktitle: Incorporamento font
type: docs
weight: 40
url: /it/cpp/embedded-font/
keywords:
- aggiungere font
- incorporare font
- incorporamento del font
- ottenere font incorporato
- aggiungere font incorporato
- rimuovere font incorporato
- comprimere font incorporato
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Incorpora i font TrueType nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per C++, garantendo una resa accurata su tutte le piattaforme."
---
## **Introduzione**

**I font incorporati in PowerPoint** aiutano a garantire che la presentazione mantenga l’aspetto previsto quando viene aperta su qualsiasi sistema o dispositivo. Ciò è particolarmente importante quando si utilizzano caratteri personalizzati, di terze parti o non standard per scopi di branding o creativi. Senza i font incorporati, il testo può essere sostituito, i layout possono rompersi e i caratteri potrebbero apparire come simboli illeggibili o rettangoli, compromettendo il design complessivo.

Aspose.Slides per C++ fornisce un set di potenti API per gestire i font incorporati in modo programmatico. È possibile utilizzare le classi [FontsManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/) e [FontData](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontdata/) per ispezionare, aggiungere o rimuovere i font incorporati nei file della presentazione. Inoltre, la classe [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/) consente di ottimizzare le dimensioni del file comprimendo i dati dei font senza influire sulla qualità o sull’aspetto.

Questi strumenti offrono il controllo totale sull’incorporamento dei font, aiutandoti a mantenere una tipografia coerente su tutte le piattaforme riducendo, quando necessario, le dimensioni del file.

## **Ottenere i font incorporati da una presentazione**

Aspose.Slides per C++ fornisce il metodo `GetEmbeddedFonts` tramite la classe [FontsManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/), che consente di recuperare un elenco di font incorporati in una presentazione PowerPoint. Questo può essere utile per verificare l’uso dei font, assicurare la conformità alle linee guida di branding o verificare che tutti i font necessari siano correttamente inclusi prima di condividere il file.

Il seguente codice C++ mostra come ottenere i font incorporati da un file di presentazione:

```cpp
// Istanziare la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Recupera tutti i font incorporati.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Stampa i nomi dei font incorporati.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Aggiungere font incorporati a una presentazione**

Aspose.Slides per C++ permette di incorporare i font in una presentazione PowerPoint usando il metodo [AddEmbeddedFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/addembeddedfont/), che dispone di due overload per un utilizzo flessibile. È possibile controllare la quantità di caratteri del font da incorporare utilizzando l’enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/embedfontcharacters/), ad esempio scegliendo di incorporare solo i caratteri utilizzati o l’intero set di font. Questa funzionalità è particolarmente utile quando si prepara una presentazione per la condivisione o la distribuzione, garantendo che i font personalizzati o non standard vengano visualizzati correttamente su tutti i sistemi, anche se tali font non sono installati.

Il seguente codice C++ controlla tutti i font usati in una presentazione e incorpora quelli che non sono già incorporati.

```cpp
// Carica un file di presentazione.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Verifica se il font è già incorporato.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Incorpora il font nella presentazione.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Salva la presentazione su disco.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Rimuovere i font incorporati da una presentazione**

Aspose.Slides per C++ offre il metodo `RemoveEmbeddedFont` tramite la classe [FontsManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/), che consente di rimuovere font specifici incorporati in una presentazione PowerPoint. Questo può aiutare a ridurre le dimensioni complessive del file, soprattutto se i font incorporati non sono più utilizzati o necessari. Rimuovere i font inutilizzati può anche migliorare le prestazioni e garantire che la presentazione includa solo le risorse essenziali.

Il seguente codice C++ mostra come rimuovere un font incorporato da una presentazione:

```cpp
auto fontName = u"Calibri";

// Istanziare la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Recupera tutti i font incorporati.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Rimuovi il font incorporato.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Comprimere i font incorporati**

Aspose.Slides per C++ fornisce il metodo `CompressEmbeddedFonts` tramite la classe [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/), consentendo di ridurre le dimensioni complessive di una presentazione ottimizzando i dati dei font incorporati. Questo è particolarmente utile quando la presentazione contiene font grandi o multipli e si desidera mantenere il file leggero per la condivisione, l'archiviazione o l'uso online, senza compromettere la fedeltà visiva del contenuto.

Il seguente codice C++ dimostra come comprimere i font incorporati in una presentazione PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Come posso capire se un font specifico nella presentazione verrà comunque sostituito durante il rendering nonostante l’incorporamento?**

Controlla le [informazioni di sostituzione](/slides/it/cpp/font-substitution/) nel font manager e le [regole di fallback/sostituzione](/slides/it/cpp/fallback-font/): se il font non è disponibile o è limitato, verrà utilizzato un fallback.

**Vale la pena incorporare i font di sistema come Arial/Calibri?**

Di solito no—sono quasi sempre disponibili. Tuttavia, per una portabilità totale in ambienti “leggeri” (Docker, un server Linux senza font preinstallati), incorporare i font di sistema può eliminare il rischio di sostituzioni inattese.