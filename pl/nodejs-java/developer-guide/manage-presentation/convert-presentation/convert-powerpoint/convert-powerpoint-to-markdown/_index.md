---
title: Konwertuj prezentacje PowerPoint na Markdown w JavaScript
linktitle: PowerPoint na Markdown
type: docs
weight: 140
url: /pl/nodejs-java/convert-powerpoint-to-markdown/
keywords:
  - konwertuj PowerPoint
  - konwertuj prezentację
  - konwertuj slajd
  - konwertuj PPT
  - konwertuj PPTX
  - PowerPoint do MD
  - prezentacja do MD
  - slajd do MD
  - PPT do MD
  - PPTX do MD
  - zapisz PowerPoint jako Markdown
  - zapisz prezentację jako Markdown
  - zapisz slajd jako Markdown
  - zapisz PPT jako MD
  - zapisz PPTX jako MD
  - eksportuj PPT do MD
  - eksportuj PPTX do MD
  - eksport obrazu Markdown
  - linki do obrazów CDN
  - PowerPoint
  - prezentacja
  - Markdown
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Konwertuj prezentacje PPT i PPTX na Markdown w JavaScript oraz kontroluj, gdzie zapisywane i odwoływane są wyeksportowane obrazy bitmapowe, metafile i SVG."
---
## **Przegląd**

Aspose.Slides dla Node.js poprzez Java może konwertować prezentacje PPT i PPTX na Markdown do dokumentacji, statycznych witryn, migracji treści i przepływów pracy z kontrolą wersji. Możesz wybrać odmianę Markdown, kontrolować sposób renderowania treści slajdów oraz zdecydować, gdzie przechowywane są wyeksportowane obrazy i jak generowany Markdown odwołuje się do nich.

Domyślnie eksport Markdown używa wyjścia wyłącznie tekstowego. Aby wyeksportować treść wizualną, ustaw typ eksportu metodą [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/) na wartość `Sequential` lub `Visual` z wyliczenia [MarkdownExportType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownexporttype/). `Sequential` renderuje elementy slajdu oddzielnie i w kolejności, natomiast `Visual` zachowuje grupowane elementy razem, aby utrzymać ich wizualny związek. Wartość `TextOnly` nie generuje zasobów obrazów, więc wywołania zwrotne zapisywania obrazów nie są wywoływane w tym trybie.

## **Konwertuj prezentację na Markdown**

Załaduj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), a następnie wywołaj metodę [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) z wartością `Md` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Wybierz odmianę Markdown**

Metoda [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/) kontroluje specyfikację Markdown używaną do wyjścia. Wyliczenie [Flavor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/flavor/) zawiera CommonMark, GitHub Flavored Markdown oraz inne obsługiwane warianty.

Poniższy przykład eksportuje prezentację jako CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Eksportuj obrazy używając domyślnego zachowania zapisu lokalnego**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/) zapewnia dwie metody konfigurowania lokalnie zapisywanych obrazów:

- [setBasePath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/) określa katalog podstawowy dla dokumentu Markdown i jego zasobów.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/) określa podkatalog obrazów. Jego domyślna wartość to `Images`.

Poniższy przykład renderuje treść wizualną, zapisuje obrazy do `output/assets` i tworzy względne odwołania do obrazów w dokumencie Markdown:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

To zachowanie służy również jako awaryjne, gdy niestandardowy obsługujący zapis obrazu zwróci `false`.

## **Dostosuj zapisywanie obrazów i odnośniki Markdown**

Użyj metody [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/) aby zarejestrować wywołanie zwrotne dla zasobów bitmap i metafili nie‑SVG emitowanych podczas eksportu Markdown. Jej wywołanie zwrotne `MarkdownImageSavingHandler` otrzymuje obiekt [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/), jego wartość [ImageFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imageformat/) oraz wygenerowany odnośnik Markdown jako jednowymiarową tablicę stringów. Zapisz lub prześlij obraz w podanym formacie i zamień `link[0]` na odnośnik, który ma się pojawić w wyjściu Markdown.

Zasoby emitowane w formacie SVG są obsługiwane osobno. Zarejestruj wywołanie zwrotne metodą [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/). Jej wywołanie zwrotne `MarkdownSvgImageSavingHandler` otrzymuje obiekt `ISvgImage` oraz jednowymiarową tablicę `link`. SVG nie posiada argumentu `ImageFormat`; zamiast tego zapisz lub prześlij jego dane XML metodą `ISvgImage.getSvgData`. W zależności od trybu eksportu i grupowania wizualnego, SVG w prezentacji źródłowej może być rasteryzowane lub łączone z inną treścią; powstały zasób nie‑SVG jest następnie przekazywany do wywołania zwrotnego zapisu obrazu. Zarejestruj oba wywołania zwrotne, gdy każdy wyeksportowany zasób wizualny wymaga własnej obróbki.

W Node.js utwórz implementacje tych interfejsów wywołań zwrotnych za pomocą `java.newProxy`.

Wartość zwracana przez obsługującego określa, kto przetwarza obraz:
- Zwróć `true` po tym, jak obsługujący zapisał, przesłał, przekształcił lub w inny sposób przetworzył obraz i przypisał prawidłową wartość do `link[0]`. Aspose.Slides zapisuje tę wartość w dokumencie Markdown i nie wykonuje domyślnego zapisu lokalnego.
- Zwróć `false`, aby pozwolić Aspose.Slides zapisać obraz lokalnie i wygenerować odnośnik zgodnie z wartościami ustawionymi przez [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/) i [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Ważne" %}}
Obsługujący, który zwróci `true`, przejmuje odpowiedzialność za obraz. Jeśli zwróci `true` bez przypisania prawidłowego, niepustego odnośnika, eksport zakończy się niepowodzeniem z `InvalidOperationException`.
{{% /alert %}}

### **Zapisz obrazy w katalogu CDN i użyj zewnętrznych adresów URL**

Poniższy przykład traktuje `cdn-origin/presentations/quarterly-report` jako zamontowany lub zsynchronizowany katalog źródłowy CDN. Każdy obsługujący wyodrębnia wygenerowaną nazwę pliku, zapisuje obraz w tym niestandardowym katalogu i zamienia wygenerowany lokalny odnośnik na publiczny URL CDN. Sam przykład nie wykonuje żadnego przesyłania sieciowego: adres URL staje się ważny dopiero po zamontowaniu katalogu jako źródła CDN lub po opublikowaniu jego plików w CDN. W przypadku przechowywania obiektowego zastąp zapis do systemu plików operacją uploadu z SDK magazynu i przypisz `link[0]` dopiero po pomyślnym przesłaniu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Obsługujący obrazy bitmapowe celowo zwraca `false` dla obrazów mniejszych niż 128 × 128 pikseli, więc Aspose.Slides zapisuje te obrazy w `output/fallback-images` przy użyciu domyślnego zachowania. Większe zasoby bitmap i metafili, a także zasoby SVG, są obsługiwane przez własny kod. Na przykład wygenerowany lokalny odnośnik taki jak `fallback-images/image1.png` staje się `https://cdn.example.com/presentations/quarterly-report/image1.png`. Obsługujący używają ścieżek systemu operacyjnego wyłącznie przy zapisie plików; odnośniki zapisywane w Markdown używają ukośników (`/`) i znaków URL‑escaped w nazwach plików. Stosuj tę samą zasadę przy budowaniu względnych odnośników: używaj `/`, a nie separatora katalogów specyficznego dla platformy.

## **FAQ**

**Czy jeden obsługujący może przetwarzać zarówno obrazy rastrowe, jak i obrazy SVG?**

Odp.: Nie. Użyj [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/) dla emitowanych zasobów bitmap i metafili oraz [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/) dla zasobów emitowanych jako SVG. Pierwsza metoda dostarcza obiekt [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/) oraz wartość [ImageFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imageformat/); druga dostarcza obiekt `ISvgImage`, którego dane SVG można odczytać metodą `ISvgImage.getSvgData`. Źródłowy SVG, który zostanie rasteryzowany podczas eksportu, jest przetwarzany przez wywołanie zwrotne zapisu obrazu.

**Co się dzieje, gdy obsługujący zapisywanie obrazu zwróci `false`?**

Odp.: Aspose.Slides korzysta z domyślnego zachowania zapisu lokalnego. Lokalizacja obrazu i wygenerowany odnośnik są kontrolowane przez wartości ustawione za pomocą [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/) i [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markdownsaveoptions/).

**Czy obsługujący może podać URL bez zapisywania obrazu lokalnie?**

Odp.: Tak. Obsługujący może przesłać obraz do magazynu obiektowego lub przekazać go do innej usługi, przypisać powstały URL do `link[0]` i zwrócić `true`. Obsługujący musi samodzielnie zakończyć przetwarzanie; zwrócenie `true` zapobiega domyślnemu zapisowi lokalnemu.

**Dlaczego eksport Markdown zgłasza `InvalidOperationException` z obsługującego?**

Odp.: Ten wyjątek występuje, gdy obsługujący zwróci `true`, ale nie dostarczy prawidłowego odnośnika. Przypisz względną ścieżkę lub zewnętrzny URL, który ma być zapisany w Markdown, przed zwróceniem `true`.

**Jakiego separatora ścieżek powinny używać odnośniki do obrazów?**

Odp.: Używaj ukośników (`/`) w odnośnikach Markdown i URL‑ach. `path.join` stosuj wyłącznie do ścieżek systemu plików, a odnośnik Markdown twórz lub normalizuj oddzielnie.

**Czy hiperłącza są zachowywane podczas eksportu Markdown?**

Odp.: Tak. Tekstowe [hiperłącza](/slides/pl/nodejs-java/manage-hyperlinks/) są zachowywane jako standardowe odnośniki Markdown. Przejścia [slajdów](/slides/pl/nodejs-java/slide-transition/) i [animacje](/slides/pl/nodejs-java/powerpoint-animation/) nie są konwertowane.

**Czy prezentacje mogą być konwertowane na Markdown równolegle?**

Odp.: Możesz przetwarzać różne pliki prezentacji równocześnie, ale nie współdzielić tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) pomiędzy wątkami. Postępuj zgodnie z [wskazówkami dotyczącymi wielowątkowości](/slides/pl/nodejs-java/multithreading/) i używaj osobnej instancji dla każdego pliku.