---
title: Aspose.Slides pro Python via Java
second_title: Aspose.Slides pro Python
type: docs
weight: 47
url: /cs/python-java/
is_root: true
keywords:
- Aspose.Slides pro Python via Java
- Knihovna Python pro PowerPoint
- spravovat PowerPoint prezentace v Pythonu
- číst a zapisovat PowerPoint v Pythonu
- upravit PowerPoint snímky v Pythonu
- exportovat PowerPoint do PDF v Pythonu
- exportovat PowerPoint do SVG v Pythonu
- náhled snímků v Pythonu
- přidat audio a video do snímků v Pythonu
- PowerPoint bez Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Začněte zde: nainstalujte Aspose.Slides pro Python via Java, vytvořte první prezentaci a najděte průvodce pro běžné úkoly, referenční API a podporu."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java je knihovna pro vytváření, čtení, úpravu a převod prezentací PowerPoint a OpenDocument v aplikacích Python, bez Microsoft PowerPoint; spouští Java engine Aspose.Slides ve vašem Python procesu prostřednictvím JPype.

Načítá a ukládá soubory PPT, PPTX, PPS, POT a ODP, včetně variant s makry a šablon, a exportuje do PDF, XPS, HTML, SVG, TIFF, Markdownu a obrázků.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Začínáme</b></p>
<hr>
<p>ZAČÁTEK</p>
<ul>
<li><a href="/slides/cs/python-java/installation/">Instalace</a></li>
<li><a href="/slides/cs/python-java/create-presentation/">Vytvořte svou první prezentaci</a></li>
<li><a href="/slides/cs/python-java/getting-started/">Průvodce pro začátečníky</a></li>
</ul>
<p>HODNOCENÍ</p>
<ul>
<li><a href="/slides/cs/python-java/supported-file-formats/">Podporované formáty souborů</a></li>
<li><a href="/slides/cs/python-java/evaluate-aspose-slides/">Omezení zkušební verze</a></li>
<li><a href="/slides/cs/python-java/licensing/">Licencování</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Vytvářejte pomocí Slides</b></p>
<hr>
<p>OBECNÉ ÚKOLY</p>
<ul>
<li><a href="/slides/cs/python-java/open-presentation/">Otevřít prezentaci</a></li>
<li><a href="/slides/cs/python-java/save-presentation/">Uložit prezentaci</a></li>
<li><a href="/slides/cs/python-java/convert-powerpoint-to-pdf/">Převést do PDF</a></li>
<li><a href="/slides/cs/python-java/convert-slide/">Vykreslit snímky jako obrázky</a></li>
<li><a href="/slides/cs/python-java/manage-text/">Upravit text a tvary</a></li>
</ul>
<p>PRACOVNÍ PROCESY</p>
<ul>
<li><a href="/slides/cs/python-java/powerpoint-charts/">Grafy</a></li>
<li><a href="/slides/cs/python-java/powerpoint-animation/">Animace</a></li>
<li><a href="/slides/cs/python-java/manage-media-files/">Audio a video</a></li>
<li><a href="/slides/cs/python-java/presentation-design/">Design snímků</a></li>
<li><a href="/slides/cs/python-java/merge-presentation/">Sloučit prezentace</a></li>
</ul>
<p>PŘÍKLADY</p>
<ul>
<li><a href="/slides/cs/python-java/examples/">Příklady podle prvku snímku</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Podpora</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cs/python-java/">Reference API</a></li>
<li><a href="https://releases.aspose.com/slides/cs/python-java/release-notes/">Poznámky k vydání</a></li>
<li><a href="/slides/cs/python-java/known-issues/">Známé problémy</a></li>
<li><a href="https://releases.aspose.com/slides/cs/python-java/">Stáhnout</a></li>
</ul>
<p>PODPOUŽKA</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/cs/11">Bezplatné fórum podpory</a></li>
<li><a href="https://helpdesk.aspose.com/">Placená podpora</a></li>
</ul>
</div>
</div>

------

## **Vaše první prezentace**

Nainstalujte Python a JDK, nastavte `JAVA_HOME` a vytvořte a aktivujte virtuální prostředí podle popisu v [Instalace](/slides/cs/python-java/installation/). Poté nainstalujte JPype a Aspose.Slides z PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Uložte tento kód jako *hello.py*. Spustí Java Virtual Machine, přidá tvar mraku s textem na první snímek nové prezentace a uloží prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Vytvořte prezentaci s jedním prázdným snímkem.
presentation = Presentation()
try:
    # Získejte první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte tvar mraku a nastavte jeho text.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Uložte prezentaci jako soubor PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Spusťte jej ve stejném virtuálním prostředí:

```sh
python hello.py
```

Skript uloží *new_presentation.pptx* s jedním snímkem obsahujícím tvar mraku s textem „Hello, Aspose!“. Bez licence má uložený soubor také vodoznak z hodnocení — viz [Licencování](/slides/cs/python-java/licensing/). Další způsoby, jak vytvořit a vyplnit prezentaci, najdete v [Vytvořit prezentace](/slides/cs/python-java/create-presentation/).