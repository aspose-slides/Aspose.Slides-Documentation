---
title: Includi font nelle presentazioni usando С++
linktitle: Incorporamento font
type: docs
weight: 40
url: /it/cpp/embedded-font/
keywords:
- aggiungi font
- incorpora font
- incorporamento di font
- ottieni font incorporato
- aggiungi font incorporato
- rimuovi font incorporato
- comprime font incorporato
- PowerPoint
- OpenDocument
- presentazione
- С++
- Aspose.Slides
description: "Incorpora font TrueType nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per С++, garantendo un rendering accurato su tutte le piattaforme."
---
## **Introduzione**

**I font incorporati in PowerPoint** aiutano a garantire che la presentazione mantenga l'aspetto previsto quando viene aperta su qualsiasi sistema o dispositivo. Questo è particolarmente importante quando si utilizzano font personalizzati, di terze parti o non standard per il branding o scopi creativi. Senza font incorporati, il testo può essere sostituito, i layout possono rompersi e i caratteri potrebbero apparire come simboli illeggibili o rettangoli, compromettendo il design complessivo.

Aspose.Slides per C++ fornisce un set di potenti API per gestire i font incorporati programmaticamente. È possibile utilizzare le classi [FontsManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/) e [FontData](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontdata/) per esaminare, aggiungere o rimuovere i font incorporati nei file di presentazione. Inoltre, la classe [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/) consente di ottimizzare le dimensioni del file comprimendo i dati dei font senza influire sulla qualità o sull'aspetto.

Questi strumenti ti offrono il controllo totale sull'incorporamento dei font, aiutandoti a mantenere una tipografia coerente su tutte le piattaforme riducendo le dimensioni del file quando necessario.

## **Ottieni font incorporati da una presentazione**

Aspose.Slides per C++ fornisce il metodo `GetEmbeddedFonts` tramite la classe [FontsManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/), che consente di recuperare un elenco di font incorporati in una presentazione PowerPoint. Questo può essere utile per verificare l'uso dei font, garantire la conformità alle linee guida del brand o accertarsi che tutti i font necessari siano correttamente inclusi prima di condividere il file.

Il seguente codice C++ mostra come ottenere i font incorporati da un file di presentazione:

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Ottieni tutti i font incorporati.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Stampa i nomi dei font incorporati.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Aggiungi font incorporati a una presentazione**

Aspose.Slides per C++ consente di incorporare font in una presentazione PowerPoint usando il metodo [AddEmbeddedFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/addembeddedfont/), che offre due overload per un utilizzo flessibile. È possibile controllare quanta parte del font viene incorporata utilizzando l'enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/embedfontcharacters/), ad esempio scegliendo di incorporare solo i caratteri effettivamente utilizzati o l'intero set di font. Questa funzionalità è particolarmente utile quando si prepara una presentazione per la condivisione o distribuzione, assicurando che i font personalizzati o non standard appaiano correttamente su tutti i sistemi, anche se non installati.

Il seguente codice C++ controlla tutti i font utilizzati in una presentazione e incorpora quelli che non sono già incorporati.

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

## **Rimuovi font incorporati da una presentazione**

Aspose.Slides per C++ fornisce il metodo `RemoveEmbeddedFont` tramite la classe [FontsManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/), che permette di rimuovere font specifici incorporati in una presentazione PowerPoint. Questo può contribuire a ridurre le dimensioni complessive del file, soprattutto se i font incorporati non sono più utilizzati o necessari. La rimozione dei font non usati può anche migliorare le prestazioni e garantire che la presentazione includa solo le risorse essenziali.

Il seguente codice C++ dimostra come rimuovere un font incorporato da una presentazione:

```cpp
auto fontName = u"Calibri";

// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Ottieni tutti i font incorporati.
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

## **Comprimi font incorporati**

Aspose.Slides per C++ fornisce il metodo `CompressEmbeddedFonts` tramite la classe [Compress](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/), consentendo di ridurre le dimensioni complessive di una presentazione ottimizzando i dati dei font incorporati. Questo è particolarmente utile quando la presentazione contiene font di grandi dimensioni o multipli e si desidera mantenere il file leggero per la condivisione, l'archiviazione o l'uso online, senza compromettere la fedeltà visiva del contenuto.

Il seguente codice C++ mostra come comprimere i font incorporati in una presentazione PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Come posso capire se un font specifico nella presentazione verrà comunque sostituito durante il rendering nonostante l'incorporamento?**

Controlla le [informazioni di sostituzione](/slides/it/cpp/font-substitution/) nel gestore dei font e le [regole di fallback/sostituzione](/slides/it/cpp/fallback-font/): se il font non è disponibile o è limitato, verrà usato un fallback.

**Vale la pena incorporare i font "di sistema" come Arial/Calibri?**

Di solito no—sono quasi sempre disponibili. Ma per la piena portabilità in ambienti "leggeri" (Docker, un server Linux senza font preinstallati), incorporare i font di sistema può eliminare il rischio di sostituzioni inattese.