---
title: Aspose.Slides pro Python via .NET
second_title: Aspose.Slides pro Python
type: docs
weight: 35
url: /cs/python-net/
is_root: true
keywords:
- Aspose.Slides pro Python
- Automatizace PowerPointu v Pythonu
- Knihovna PPT pro Python
- Export PowerPointu do PDF v Pythonu
- Export PowerPointu do SVG v Pythonu
- Úprava PowerPointu v Pythonu
- PowerPoint v Pythonu bez Microsoft Office
- Správa PPTX v Pythonu
- Náhled snímků v Pythonu
- Přidání audia do snímků v Pythonu
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Začněte zde: nainstalujte Aspose.Slides pro Python via .NET, vytvořte první prezentaci a najděte návody pro běžné úkoly, referenční API a podporu."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET je knihovna Python pro vytváření, čtení, úpravu a konverzi prezentací PowerPoint a OpenDocument, bez Microsoft PowerPointu nebo Microsoft Office.

Načítá a ukládá soubory PPT, PPTX, PPS, POT a ODP, včetně variant s makry a šablon, a exportuje do PDF, XPS, HTML, SVG, TIFF, Markdownu a obrázků.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Začínáme</b></p>
<hr>
<p>ZAČÁTEK</p>
<ul>
<li><a href="/slides/cs/python-net/installation/">Instalace</a></li>
<li><a href="/slides/cs/python-net/create-presentation/">Vytvořte svou první prezentaci</a></li>
<li><a href="/slides/cs/python-net/getting-started/">Průvodce pro začátečníky</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/cs/python-net/supported-file-formats/">Podporované formáty souborů</a></li>
<li><a href="/slides/cs/python-net/evaluate-aspose-slides/">Omezení zkušební verze</a></li>
<li><a href="/slides/cs/python-net/licensing/">Licencování</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Vytvářejte pomocí Slides</b></p>
<hr>
<p>OBECNÉ ÚKOLY</p>
<ul>
<li><a href="/slides/cs/python-net/open-presentation/">Otevřít prezentaci</a></li>
<li><a href="/slides/cs/python-net/save-presentation/">Uložit prezentaci</a></li>
<li><a href="/slides/cs/python-net/convert-powerpoint-to-pdf/">Převést do PDF</a></li>
<li><a href="/slides/cs/python-net/convert-slide/">Vykreslit snímky jako obrázky</a></li>
<li><a href="/slides/cs/python-net/manage-text/">Upravit text a tvary</a></li>
</ul>
<p>PRACOVNÍ POSTUPY SLIDES</p>
<ul>
<li><a href="/slides/cs/python-net/powerpoint-charts/">Grafy</a></li>
<li><a href="/slides/cs/python-net/powerpoint-animation/">Animace</a></li>
<li><a href="/slides/cs/python-net/manage-media-files/">Audio a video</a></li>
<li><a href="/slides/cs/python-net/presentation-design/">Design snímků</a></li>
<li><a href="/slides/cs/python-net/merge-presentation/">Sloučit prezentace</a></li>
</ul>
<p>PŘÍKLADY</p>
<ul>
<li><a href="/slides/cs/python-net/examples/">Příklady podle prvků snímku</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Příklady na GitHubu</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; podpora</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cs/python-net/">Reference API</a></li>
<li><a href="https://releases.aspose.com/slides/cs/python-net/release-notes/">Poznámky k vydání</a></li>
<li><a href="https://releases.aspose.com/slides/cs/python-net/">Stáhnout</a></li>
</ul>
<p>PODPOŘA</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/cs/11">Bezplatné fórum podpory</a></li>
<li><a href="https://helpdesk.aspose.com/">Placená podpora helpdesk</a></li>
</ul>
</div>
</div>

------

## **Vaše první prezentace**

Nainstalujte balíček z PyPI:

```bash
pip install aspose.slides
```

Balíček obsahuje .NET runtime, který používá, takže nemusíte instalovat .NET. Na Linuxu také nainstalujte knihovny libgdiplus a ICU a s systémovým Pythonem v Debianu nebo Ubuntu spusťte příkaz ve virtuálním prostředí. macOS má další předpoklady a instalaci jsme tam neověřovali. Viz [Instalace](/slides/cs/python-net/installation/) pro příkazy, předpoklady pro macOS a podporované verze Pythonu.

Uložte tento kód jako *hello.py*:

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:
    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte automatický tvar typu CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Spusťte jej pomocí `python hello.py`. Skript uloží *new_presentation.pptx* do aktuální složky, s jedním snímkem obsahujícím tvar mraku s textem “Hello, Aspose!”. Bez licence obsahuje uložený soubor vodoznak z hodnocení — viz [Licencování](/slides/cs/python-net/licensing/). Pro více způsobů, jak vytvořit a naplnit prezentaci, viz [Vytvoření prezentací](/slides/cs/python-net/create-presentation/).