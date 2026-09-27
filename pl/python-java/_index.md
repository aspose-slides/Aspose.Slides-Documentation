---
title: Aspose.Slides dla Pythona przez Java
second_title: Aspose.Slides dla Pythona
type: docs
weight: 47
url: /pl/python-java/
is_root: true
keywords:
- Aspose.Slides dla Pythona przez Java
- Biblioteka Python do PowerPoint
- zarządzanie prezentacjami PowerPoint w Pythonie
- odczyt i zapis PowerPoint w Pythonie
- edytowanie slajdów PowerPoint w Pythonie
- eksportowanie PowerPoint do PDF w Pythonie
- eksportowanie PowerPoint do SVG w Pythonie
- podgląd slajdów w Pythonie
- dodawanie dźwięku i wideo do slajdów w Pythonie
- PowerPoint bez Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Rozpocznij tutaj: zainstaluj Aspose.Slides dla Pythona przez Java, utwórz pierwszą prezentację i znajdź przewodniki dotyczące typowych zadań, referencję API oraz wsparcie."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java to biblioteka do tworzenia, odczytywania, edytowania i konwertowania prezentacji PowerPoint i OpenDocument w aplikacjach Pythona, bez Microsoft PowerPoint; uruchamia silnik Aspose.Slides Java w procesie Pythona przy użyciu JPype.

Obsługuje ładowanie i zapisywanie plików PPT, PPTX, PPS, POT i ODP, w tym wariantów z makrami i szablonów, oraz eksportuje do PDF, XPS, HTML, SVG, TIFF, Markdown i obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>ROZPOCZĘCIE</p>
<ul>
<li><a href="/slides/pl/python-java/installation/">Installation</a></li>
<li><a href="/slides/pl/python-java/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/pl/python-java/getting-started/">Getting started guide</a></li>
</ul>
<p>EWALUACJA</p>
<ul>
<li><a href="/slides/pl/python-java/supported-file-formats/">Supported file formats</a></li>
<li><a href="/slides/pl/python-java/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/pl/python-java/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Buduj ze Slides</b></p>
<hr>
<p>POTRZEBNE ZADANIA</p>
<ul>
<li><a href="/slides/pl/python-java/open-presentation/">Open a presentation</a></li>
<li><a href="/slides/pl/python-java/save-presentation/">Save a presentation</a></li>
<li><a href="/slides/pl/python-java/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/pl/python-java/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/pl/python-java/manage-text/">Edit text and shapes</a></li>
</ul>
<p>PRZEPŁYWY SLIDES</p>
<ul>
<li><a href="/slides/pl/python-java/powerpoint-charts/">Charts</a></li>
<li><a href="/slides/pl/python-java/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/pl/python-java/manage-media-files/">Audio and video</a></li>
<li><a href="/slides/pl/python-java/presentation-design/">Slide design</a></li>
<li><a href="/slides/pl/python-java/merge-presentation/">Merge presentations</a></li>
</ul>
<p>PRZYKŁADY</p>
<ul>
<li><a href="/slides/pl/python-java/examples/">Examples by slide element</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencje &amp; Wsparcie</b></p>
<hr>
<p>REFERENCJA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Release notes</a></li>
<li><a href="/slides/pl/python-java/known-issues/">Known issues</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Download</a></li>
</ul>
<p>WSPARCIE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Free support forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Paid support helpdesk</a></li>
</ul>
</div>
</div>

------

## **Twoja pierwsza prezentacja**

Zainstaluj Pythona i JDK, ustaw `JAVA_HOME` oraz utwórz i aktywuj środowisko wirtualne zgodnie z instrukcją w [Installation](/slides/pl/python-java/installation/). Następnie zainstaluj JPype i Aspose.Slides z PyPI:

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

Skrypt zapisuje *new_presentation.pptx* z jednym slajdem zawierającym kształt chmury z tekstem „Hello, Aspose!”. Bez licencji zapisany plik zawiera znak wodny oceny — zobacz [Licensing](/slides/pl/python-java/licensing/). Aby dowiedzieć się więcej o sposobach tworzenia i wypełniania prezentacji, zobacz [Create Presentations](/slides/pl/python-java/create-presentation/).