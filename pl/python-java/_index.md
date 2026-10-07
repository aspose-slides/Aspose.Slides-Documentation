---
title: Aspose.Slides dla Pythona przez Java
second_title: Aspose.Slides dla Pythona
type: docs
weight: 47
url: /pl/python-java/
is_root: true
keywords:
- Aspose.Slides dla Pythona przez Java
- Biblioteka PowerPoint dla Pythona
- zarządzaj prezentacjami PowerPoint w Pythonie
- odczyt i zapis PowerPoint w Pythonie
- edytuj slajdy PowerPoint w Pythonie
- eksportuj PowerPoint do PDF w Pythonie
- eksportuj PowerPoint do SVG w Pythonie
- podgląd slajdów w Pythonie
- dodawaj audio i wideo do slajdów w Pythonie
- PowerPoint bez Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Zacznij tutaj: zainstaluj Aspose.Slides dla Pythona przez Java, utwórz pierwszą prezentację i znajdź poradniki dotyczące typowych zadań, referencję API oraz wsparcie."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides dla Pythona przez Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java jest biblioteką do tworzenia, odczytywania, edytowania i konwertowania prezentacji PowerPoint i OpenDocument w aplikacjach Pythona, bez Microsoft PowerPoint; uruchamia silnik Aspose.Slides Java w procesie Pythona za pomocą JPype.

Obsługuje ładowanie i zapisywanie plików PPT, PPTX, PPS, POT i ODP, w tym wersje z makrami i szablonami, oraz eksportuje do PDF, XPS, HTML, SVG, TIFF, Markdown i obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>ROZPOCZĘCIE</p>
<ul>
<li><a href="/slides/pl/python-java/installation/">Instalacja</a></li>
<li><a href="/slides/pl/python-java/create-presentation/">Utwórz swoją pierwszą prezentację</a></li>
<li><a href="/slides/pl/python-java/getting-started/">Przewodnik po rozpoczęciu</a></li>
</ul>
<p>OCENA</p>
<ul>
<li><a href="/slides/pl/python-java/supported-file-formats/">Obsługiwane formaty plików</a></li>
<li><a href="/slides/pl/python-java/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/python-java/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Tworzenie przy użyciu Slides</b></p>
<hr>
<p>ZADANIA PODSTAWOWE</p>
<ul>
<li><a href="/slides/pl/python-java/open-presentation/">Otwórz prezentację</a></li>
<li><a href="/slides/pl/python-java/save-presentation/">Zapisz prezentację</a></li>
<li><a href="/slides/pl/python-java/convert-powerpoint-to-pdf/">Konwertuj do PDF</a></li>
<li><a href="/slides/pl/python-java/convert-slide/">Renderuj slajdy jako obrazy</a></li>
<li><a href="/slides/pl/python-java/manage-text/">Edytuj tekst i kształty</a></li>
</ul>
<p>PRZEPŁYWY PRACY</p>
<ul>
<li><a href="/slides/pl/python-java/powerpoint-charts/">Wykresy</a></li>
<li><a href="/slides/pl/python-java/powerpoint-animation/">Animacje</a></li>
<li><a href="/slides/pl/python-java/manage-media-files/">Audio i wideo</a></li>
<li><a href="/slides/pl/python-java/presentation-design/">Projektowanie slajdów</a></li>
<li><a href="/slides/pl/python-java/merge-presentation/">Scalanie prezentacji</a></li>
</ul>
<p>PRZYKŁADY</p>
<ul>
<li><a href="/slides/pl/python-java/examples/">Przykłady według elementu slajdu</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Dokumentacja i wsparcie</b></p>
<hr>
<p>REFERENCJA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">Referencja API</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Informacje o wydaniu</a></li>
<li><a href="/slides/pl/python-java/known-issues/">Znane problemy</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">Strona produktu</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Pobierz</a></li>
</ul>
<p>WSPARCIE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Bezpłatny forum wsparcia</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatny helpdesk wsparcia</a></li>
</ul>
</div>
</div>

------

## **Twoja pierwsza prezentacja**

Zainstaluj Pythona i JDK, ustaw `JAVA_HOME` oraz utwórz i aktywuj środowisko wirtualne, jak opisano w [Instalacja](/slides/pl/python-java/installation/). Następnie zainstaluj JPype i Aspose.Slides z PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Zapisz ten kod jako *hello.py*. Uruchamia maszynę wirtualną Java, dodaje kształt chmury z tekstem do pierwszego slajdu nowej prezentacji i zapisuje prezentację:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Utwórz prezentację z jednym pustym slajdem.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj kształt chmury i ustaw jego tekst.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Zapisz prezentację jako plik PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Uruchom go w tym samym środowisku wirtualnym:

```sh
python hello.py
```

Skrypt zapisuje *new_presentation.pptx* z jednym slajdem zawierającym kształt chmury z tekstem „Hello, Aspose!”. Bez licencji zapisany plik zawiera znak wodny oceny — zobacz [Licencjonowanie](/slides/pl/python-java/licensing/). Aby poznać więcej sposobów tworzenia i wypełniania prezentacji, zobacz [Tworzenie prezentacji](/slides/pl/python-java/create-presentation/).