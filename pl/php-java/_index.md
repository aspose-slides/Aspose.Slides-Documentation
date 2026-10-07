---
title: Aspose.Slides for PHP via Java
second_title: Aspose.Slides for PHP
type: docs
weight: 45
url: /pl/php-java/
keywords:
- dokumentacja
- przetwarzanie prezentacji
- konwersja prezentacji
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Zacznij tutaj: zainstaluj Aspose.Slides for PHP via Java, utwórz pierwszą prezentację i znajdź poradniki dotyczące typowych zadań, referencję API oraz wsparcie."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java jest biblioteką klas służącą do tworzenia, odczytywania, edytowania i konwertowania prezentacji PowerPoint i OpenDocument w aplikacjach PHP, bez Microsoft PowerPoint ani automatyzacji Office.

Ładuje i zapisuje pliki PPT, PPTX, PPS, POT i ODP, w tym wersje z makrami i szablony, oraz eksportuje do PDF, XPS, HTML, SVG, TIFF, Markdown oraz obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>ROZPOCZĘCIE</p>
<ul>
<li><a href="/slides/pl/php-java/installation/">Instalacja</a></li>
<li><a href="/slides/pl/php-java/create-presentation/">Utwórz swoją pierwszą prezentację</a></li>
<li><a href="/slides/pl/php-java/getting-started/">Poradnik wprowadzający</a></li>
</ul>
<p>EWALUACJA</p>
<ul>
<li><a href="/slides/pl/php-java/supported-file-formats/">Obsługiwane formaty plików</a></li>
<li><a href="/slides/pl/php-java/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/php-java/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tworzenie z Slides</b></p>
<hr>
<p>ZADANIA OGÓLNE</p>
<ul>
<li><a href="/slides/pl/php-java/open-presentation/">Otwórz prezentację</a></li>
<li><a href="/slides/pl/php-java/save-presentation/">Zapisz prezentację</a></li>
<li><a href="/slides/pl/php-java/convert-powerpoint-to-pdf/">Konwertuj do PDF</a></li>
<li><a href="/slides/pl/php-java/convert-slide/">Renderuj slajdy jako obrazy</a></li>
<li><a href="/slides/pl/php-java/manage-text/">Edytuj tekst i kształty</a></li>
</ul>
<p>PRZEBIEGI SLIDE'ÓW</p>
<ul>
<li><a href="/slides/pl/php-java/powerpoint-charts/">Wykresy</a></li>
<li><a href="/slides/pl/php-java/powerpoint-animation/">Animacje</a></li>
<li><a href="/slides/pl/php-java/manage-media-files/">Audio i wideo</a></li>
<li><a href="/slides/pl/php-java/presentation-design/">Projektowanie slajdów</a></li>
<li><a href="/slides/pl/php-java/merge-presentation/">Scalanie prezentacji</a></li>
</ul>
<p>PRZYKŁADY</p>
<ul>
<li><a href="/slides/pl/php-java/examples/">Przykłady według elementów slajdu</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Dokumentacja i wsparcie</b></p>
<hr>
<p>REFERENCJA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">Referencja API</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Informacje o wydaniu</a></li>
<li><a href="/slides/pl/php-java/known-issues/">Znane problemy</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">Strona produktu</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Pobierz</a></li>
</ul>
<p>Wsparcie</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Darmowe forum wsparcia</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatny helpdesk wsparcia</a></li>
</ul>
</div>
</div>

------

## **Twoja pierwsza prezentacja**

Aspose.Slides for PHP via Java działa na Javie w Apache Tomcat, a Twoje skrypty PHP łączą się z nim poprzez PHP/Java Bridge. [Instalacja](/slides/pl/php-java/installation/) konfiguruje PHP 8.3 lub starsze, Java, Tomcat i most, a następnie instaluję pakiet z Packagist w folderze projektu:

```bash
composer require aspose/slides
```

Następnie skopiuj plik JAR pakietu do mostu i zrestartuj Tomcat, tak jak w kroku 4 [Instalacja w systemie Linux](/slides/pl/php-java/installation/#install-on-linux) lub w kroku 6 [Instalacja w systemie Windows](/slides/pl/php-java/installation/#install-on-windows). Z uruchomionym Tomcatem, zapisz ten skrypt jako *hello.php* w folderze projektu i uruchom `php hello.php`:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Skrypt zapisuje *hello.pptx* obok siebie, z jednym slajdem zawierającym pole tekstowe. Bez licencji zapisany plik zawiera znak wodny oceny — zobacz [Licencjonowanie](/slides/pl/php-java/licensing/). Po więcej sposobów tworzenia i wypełniania prezentacji, zobacz [Tworzenie prezentacji](/slides/pl/php-java/create-presentation/).