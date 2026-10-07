---
title: Aspose.Slides dla Node.js via Java
second_title: Aspose.Slides dla Node.js
type: docs
weight: 47
url: /pl/nodejs-java/
keywords:
- dokumentacja
- przetwarzanie prezentacji
- konwersja prezentacji
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Zacznij tutaj: zainstaluj Aspose.Slides dla Node.js via Java, utwórz pierwszą prezentację i znajdź przewodniki dotyczące typowych zadań, referencję API oraz wsparcie."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides dla Node.js przez Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java to biblioteka umożliwiająca tworzenie, odczytywanie, edytowanie i konwertowanie prezentacji PowerPoint i OpenDocument w aplikacjach Node.js, bez Microsoft PowerPoint.

Obsługuje ładowanie i zapisywanie plików PPT, PPTX, PPS, POT oraz ODP, w tym wersje z makrami i szablony, oraz eksportuje do PDF, XPS, HTML, SVG, TIFF, Markdown i obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>ROZPOCZĘCIE PRACY</p>
<ul>
<li><a href="/slides/pl/nodejs-java/installation/">Instalacja</a></li>
<li><a href="/slides/pl/nodejs-java/create-presentation/">Utwórz swoją pierwszą prezentację</a></li>
<li><a href="/slides/pl/nodejs-java/getting-started/">Przewodnik dla początkujących</a></li>
</ul>
<p>OCENA</p>
<ul>
<li><a href="/slides/pl/nodejs-java/supported-file-formats/">Obsługiwane formaty plików</a></li>
<li><a href="/slides/pl/nodejs-java/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/nodejs-java/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tworzenie przy użyciu Slides</b></p>
<hr>
<p>WSPÓLNE ZADANIA</p>
<ul>
<li><a href="/slides/pl/nodejs-java/open-presentation/">Otwórz prezentację</a></li>
<li><a href="/slides/pl/nodejs-java/save-presentation/">Zapisz prezentację</a></li>
<li><a href="/slides/pl/nodejs-java/convert-powerpoint-to-pdf/">Konwertuj do PDF</a></li>
<li><a href="/slides/pl/nodejs-java/convert-slide/">Renderuj slajdy jako obrazy</a></li>
<li><a href="/slides/pl/nodejs-java/manage-text/">Edytuj tekst i kształty</a></li>
</ul>
<p>PROCESY PRACY Z SLIDE'AMI</p>
<ul>
<li><a href="/slides/pl/nodejs-java/powerpoint-charts/">Wykresy</a></li>
<li><a href="/slides/pl/nodejs-java/powerpoint-animation/">Animacje</a></li>
<li><a href="/slides/pl/nodejs-java/manage-media-files/">Dźwięk i wideo</a></li>
<li><a href="/slides/pl/nodejs-java/presentation-design/">Projektowanie slajdów</a></li>
<li><a href="/slides/pl/nodejs-java/merge-presentation/">Scalanie prezentacji</a></li>
</ul>
<p>PRZYKŁADY</p>
<ul>
<li><a href="/slides/pl/nodejs-java/examples/">Przykłady według elementu slajdu</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencje i wsparcie</b></p>
<hr>
<p>REFERENCJA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">Dokumentacja API</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">Informacje o wydaniu</a></li>
<li><a href="/slides/pl/nodejs-java/known-issues/">Znane problemy</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-java/">Strona produktu</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">Pobierz</a></li>
</ul>
<p>WSPARCIE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Bezpłatne forum wsparcia</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatna pomoc techniczna</a></li>
</ul>
</div>
</div>

------

## **Twoja pierwsza prezentacja**

Poza Node.js 20 lub nowszym, pakiet wymaga Java Development Kit (JDK), Pythona oraz zestawu narzędzi kompilacji C++, ponieważ npm kompiluje most `java` podczas instalacji. Zobacz [Installation](/slides/pl/nodejs-java/installation/) w celu poznania kroków dla każdego systemu operacyjnego. Następnie utwórz projekt i zainstaluj pakiet z npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Zapisz ten kod jako *hello.js* w folderze projektu:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides działa w maszynie wirtualnej Java, która utrzymuje uruchomiony Node.js, więc zakończ proces jawnie.
process.exit(0);
```

Uruchom go poleceniem `node hello.js`. Skrypt zapisuje *hello.pptx* z jednym slajdem zawierającym pole tekstowe. Bez licencji zapisany plik zawiera znak wodny wersji próbnej — zobacz [Licensing](/slides/pl/nodejs-java/licensing/). Aby poznać więcej sposobów tworzenia i wypełniania prezentacji, zobacz [Create Presentations](/slides/pl/nodejs-java/create-presentation/).