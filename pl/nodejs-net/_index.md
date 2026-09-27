---
title: Aspose.Slides dla Node.js przez .NET
second_title: Aspose.Slides dla Node.js
type: docs
weight: 47
url: /pl/nodejs-net/
keywords:
- dokumentacja
- przetwarzanie prezentacji
- konwersja prezentacji
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Rozpocznij tutaj: zainstaluj Aspose.Slides for Node.js via .NET, utwórz pierwszą prezentację i znajdź przewodniki dotyczące typowych zadań, licencjonowania, referencji API oraz wsparcia."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET jest biblioteką do tworzenia, odczytywania, edytowania i konwertowania prezentacji PowerPoint oraz OpenDocument w aplikacjach Node.js, bez potrzeby instalacji Microsoft PowerPoint ani automatyzacji Office. Działa ona poprzez pomost edge‑js, więc jej interfejs JavaScript odzwierciedla API .NET, używając nazw członków w stylu camelCase.

Obsługuje ładowanie i zapisywanie plików PPT, PPTX, PPS, POT i ODP, w tym wersje z makrami i szablony, oraz eksport do PDF, XPS, HTML, TIFF, Markdown i obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/pl/nodejs-net/installation/">Instalacja</a></li>
<li><a href="/slides/pl/nodejs-net/create-presentation/">Utwórz pierwszą prezentację</a></li>
<li><a href="/slides/pl/nodejs-net/developer-guide/">Przewodnik dla deweloperów</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/pl/nodejs-net/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/nodejs-net/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Buduj z Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/pl/nodejs-net/open-presentation/">Otwórz i zapisz prezentację</a></li>
<li><a href="/slides/pl/nodejs-net/convert-powerpoint-to-pdf/">Konwertuj do PDF</a></li>
<li><a href="/slides/pl/nodejs-net/convert-slide/">Renderuj slajdy jako obrazy</a></li>
<li><a href="/slides/pl/nodejs-net/manage-text/">Edytuj tekst</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Referencja API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Notatki z wersji</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Pobierz</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Darmowe forum wsparcia</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatna pomoc techniczna</a></li>
</ul>
</div>
</div>

------

## **Twoja pierwsza prezentacja**

Potrzebujesz Node.js 22 lub 24 oraz .NET SDK 8 lub nowszego; Linux wymaga także kilku pakietów systemowych. [Installation](/slides/pl/nodejs-net/installation/) wymienia je oraz platformy, które zostały przetestowane. Utwórz projekt, dodaj nadpisanie, które określa, którą wersję edge‑js ma zainstalować npm, i zainstaluj pakiet:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Jednorazowo na maszynie przywróć pakiety .NET, od których zależy biblioteka. Zapisz plik `deps.csproj` z [Restore the .NET Dependencies](/slides/pl/nodejs-net/installation/#restore-the-net-dependencies) w folderze `deps` wewnątrz folderu projektu, a następnie uruchom:

```sh
dotnet restore deps/deps.csproj
```

Zapisz ten kod jako *hello.js* w folderze projektu:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Nowa prezentacja zawiera jeden pusty slajd.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Pozycja i rozmiar podane są w punktach (1/72 cala): x, y, szerokość, wysokość.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Zwolnij obiekt .NET, który obsługuje prezentację.
    presentation.dispose();
}
```

Uruchom go z folderu projektu:

```sh
node hello.js
```

Skrypt wypisuje `Saved hello.pptx` i zapisuje *hello.pptx* z jednym slajdem zawierającym prostokąt z tekstem. Bez licencji zapisany plik zawiera znak wodny wersji próbnej — zobacz [Licensing](/slides/pl/nodejs-net/licensing/). Aby poznać więcej sposobów tworzenia i wypełniania prezentacji, zobacz [Create a Presentation](/slides/pl/nodejs-net/create-presentation/).