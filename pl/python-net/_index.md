---
title: Aspose.Slides dla Pythona via .NET
second_title: Aspose.Slides dla Pythona
type: docs
weight: 35
url: /pl/python-net/
is_root: true
keywords:
- Aspose.Slides dla Pythona
- automatyzacja PowerPoint w Pythonie
- biblioteka PPT w Pythonie
- eksport PowerPoint do PDF w Pythonie
- eksport PowerPoint do SVG w Pythonie
- edycja PowerPoint w Pythonie
- PowerPoint w Pythonie bez Microsoft Office
- zarządzanie plikami PPTX w Pythonie
- podgląd slajdów w Pythonie
- dodawanie dźwięku do slajdów w Pythonie
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Zacznij tutaj: zainstaluj Aspose.Slides for Python via .NET, utwórz pierwszą prezentację i znajdź przewodniki po typowych zadaniach, referencję API oraz wsparcie."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET to biblioteka Pythona służąca do tworzenia, odczytywania, edytowania i konwertowania prezentacji PowerPoint oraz OpenDocument, bez Microsoft PowerPoint ani Microsoft Office.

Obsługuje wczytywanie i zapisywanie formatów PPT, PPTX, PPS, POT i ODP, w tym wersji z makrami i szablonów, oraz eksportuje do PDF, XPS, HTML, SVG, TIFF, Markdown i obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>ROZPOCZĘCIE</p>
<ul>
<li><a href="/slides/pl/python-net/installation/">Instalacja</a></li>
<li><a href="/slides/pl/python-net/create-presentation/">Utwórz swoją pierwszą prezentację</a></li>
<li><a href="/slides/pl/python-net/getting-started/">Przewodnik po rozpoczęciu pracy</a></li>
</ul>
<p>OCENA</p>
<ul>
<li><a href="/slides/pl/python-net/supported-file-formats/">Obsługiwane formaty plików</a></li>
<li><a href="/slides/pl/python-net/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/python-net/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Buduj przy użyciu Slides</b></p>
<hr>
<p>POWSZECHNE ZADANIA</p>
<ul>
<li><a href="/slides/pl/python-net/open-presentation/">Otwórz prezentację</a></li>
<li><a href="/slides/pl/python-net/save-presentation/">Zapisz prezentację</a></li>
<li><a href="/slides/pl/python-net/convert-powerpoint-to-pdf/">Konwertuj do PDF</a></li>
<li><a href="/slides/pl/python-net/convert-slide/">Renderuj slajdy jako obrazy</a></li>
<li><a href="/slides/pl/python-net/manage-text/">Edytuj tekst i kształty</a></li>
</ul>
<p>PRZEPŁYWY PRACY Z SLIDES</p>
<ul>
<li><a href="/slides/pl/python-net/powerpoint-charts/">Wykresy</a></li>
<li><a href="/slides/pl/python-net/powerpoint-animation/">Animacje</a></li>
<li><a href="/slides/pl/python-net/manage-media-files/">Audio i wideo</a></li>
<li><a href="/slides/pl/python-net/presentation-design/">Projektowanie slajdów</a></li>
<li><a href="/slides/pl/python-net/merge-presentation/">Scalanie prezentacji</a></li>
</ul>
<p>PRZYKŁADY</p>
<ul>
<li><a href="/slides/pl/python-net/examples/">Przykłady według elementów slajdu</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Przykłady na GitHubie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Dokumentacja i wsparcie</b></p>
<hr>
<p>DOKUMENTACJA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">Referencja API</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Informacje o wydaniu</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">Strona produktu</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Pobierz</a></li>
</ul>
<p>WSPIERANIE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Bezpłatne forum wsparcia</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatny helpdesk wsparcia</a></li>
</ul>
</div>
</div>

------

## **Twoja pierwsza prezentacja**

Install the package from PyPI:

```bash
pip install aspose.slides
```

Pakiet zawiera środowisko uruchomieniowe .NET, którego używa, więc nie musisz instalować .NET. Na Linuksie zainstaluj także biblioteki libgdiplus i ICU, a przy korzystaniu z systemowego Pythona w Debianie lub Ubuntu uruchom polecenie w wirtualnym środowisku. macOS wymaga dodatkowych zależności i nie zweryfikowaliśmy instalacji na tej platformie. Zobacz [Instalacja](/slides/pl/python-net/installation/) po komendy, wymagania macOS i obsługiwane wersje Pythona.

Zapisz ten kod jako *hello.py*:

```py
import aspose.slides as slides

# Utwórz obiekt klasy Presentation, który reprezentuje plik prezentacji.
with slides.Presentation() as presentation:
    # Pobierz pierwszy slajd.
    slide = presentation.slides[0]

    # Dodaj auto-kształt typu CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Zapisz prezentację jako plik PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Uruchom go poleceniem `python hello.py`. Skrypt zapisuje *new_presentation.pptx* w bieżącym folderze, z jednym slajdem zawierającym kształt chmury z napisem „Hello, Aspose!”. Bez licencji zapisany plik zawiera znak wodny wersji ewaluacyjnej — zobacz [Licencjonowanie](/slides/pl/python-net/licensing/). Aby dowiedzieć się o innych metodach tworzenia i wypełniania prezentacji, zobacz [Utwórz prezentacje](/slides/pl/python-net/create-presentation/).