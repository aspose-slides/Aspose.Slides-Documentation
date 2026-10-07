---
title: Aspose.Slides dla Node.js via .NET
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
description: "Zacznij tutaj: zainstaluj Aspose.Slides dla Node.js via .NET, utwórz pierwszą prezentację i znajdź przewodniki dotyczące typowych zadań, licencjonowania, referencji API oraz wsparcia."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET jest biblioteką do tworzenia, odczytywania, edytowania i konwertowania prezentacji PowerPoint i OpenDocument w aplikacjach Node.js, bez Microsoft PowerPoint ani automatyzacji Office. Uruchamia Aspose.Slides for .NET poprzez most edge-js, więc jego API JavaScript odzwierciedla API .NET, z nazwami członków w formacie camelCase.

Obsługuje ładowanie i zapisywanie plików PPT, PPTX, PPS, POT oraz ODP, w tym wersje z makrami i szablony, oraz eksportuje do PDF, XPS, HTML, TIFF, Markdown i obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>ROZPOCZĘCIE PRACY</p>
<ul>
<li><a href="/slides/pl/nodejs-net/installation/">Instalacja</a></li>
<li><a href="/slides/pl/nodejs-net/create-presentation/">Utwórz swoją pierwszą prezentację</a></li>
<li><a href="/slides/pl/nodejs-net/developer-guide/">Przewodnik dla programistów</a></li>
</ul>
<p>EWALUACJA</p>
<ul>
<li><a href="/slides/pl/nodejs-net/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/nodejs-net/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tworzenie przy użyciu Slides</b></p>
<hr>
<p>ZADANIA PODSTAWOWE</p>
<ul>
<li><a href="/slides/pl/nodejs-net/open-presentation/">Otwórz i zapisz prezentację</a></li>
<li><a href="/slides/pl/nodejs-net/convert-powerpoint-to-pdf/">Konwertuj do PDF</a></li>
<li><a href="/slides/pl/nodejs-net/convert-slide/">Renderuj slajdy jako obrazy</a></li>
<li><a href="/slides/pl/nodejs-net/manage-text/">Edytuj tekst</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencje i wsparcie</b></p>
<hr>
<p>REFERENCJE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Referencja API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Notatki o wydaniu</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">Strona produktu</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Pobierz</a></li>
</ul>
<p>WSPARCIE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Bezpłatne forum wsparcia</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatny helpdesk wsparcia</a></li>
</ul>
</div>
</div>

------

## **Twoja pierwsza prezentacja**

Potrzebujesz Node.js 22 lub 24 oraz .NET SDK 8 lub nowszego; Linux wymaga również kilku pakietów systemowych. [Instalacja](/slides/pl/nodejs-net/installation/) wymienia je oraz platformy, które zostały przetestowane. Utwórz projekt, dodaj nadpisanie, które informuje npm, którą wersję edge-js zainstalować, i zainstaluj pakiet:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Jednorazowo na maszynie przywróć pakiety .NET, od których zależy biblioteka. Zapisz plik `deps.csproj` z [Przywróć zależności .NET](/slides/pl/nodejs-net/installation/#restore-the-net-dependencies) w folderze `deps` wewnątrz folderu projektu, a następnie uruchom:

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

    // Pozycja i rozmiar podawane są w punktach (1/72 cala): x, y, szerokość, wysokość.
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

Skrypt wypisuje `Saved hello.pptx` i zapisuje *hello.pptx* z jednym slajdem zawierającym prostokąt z tekstem. Bez licencji zapisany plik zawiera znak wodny oceny — zobacz [Licencjonowanie](/slides/pl/nodejs-net/licensing/). Aby dowiedzieć się więcej o tworzeniu i wypełnianiu prezentacji, zobacz [Utwórz prezentację](/slides/pl/nodejs-net/create-presentation/).