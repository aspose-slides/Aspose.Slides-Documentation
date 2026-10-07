---
title: Aspose.Slides pro Python přes Java
second_title: Aspose.Slides pro Python
type: docs
weight: 47
url: /cs/python-java/
is_root: true
keywords:
- Aspose.Slides pro Python přes Java
- Knihovna PowerPoint pro Python
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
description: "Začněte zde: nainstalujte Aspose.Slides pro Python přes Java, vytvořte první prezentaci a najděte návody pro běžné úkoly, referenční API a podporu."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java je knihovna pro vytváření, čtení, úpravu a konverzi prezentací PowerPoint a OpenDocument v aplikacích Pythonu, bez Microsoft PowerPoint; spouští engine Aspose.Slides Java ve vašem Python procesu pomocí JPype.

Načítá a ukládá soubory PPT, PPTX, PPS, POT a ODP, včetně variant s makry a šablon, a exportuje do PDF, XPS, HTML, SVG, TIFF, Markdown a obrázků.

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
<li><a href="/slides/cs/python-java/getting-started/">Průvodce začátkem</a></li>
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
<p>PRACOVNÍ PROCESY SLIDES</p>
<ul>
<li><a href="/slides/cs/python-java/powerpoint-charts/">Grafy</a></li>
<li><a href="/slides/cs/python-java/powerpoint-animation/">Animace</a></li>
<li><a href="/slides/cs/python-java/manage-media-files/">Audio a video</a></li>
<li><a href="/slides/cs/python-java/presentation-design/">Návrh snímků</a></li>
<li><a href="/slides/cs/python-java/merge-presentation/">Sloučit prezentace</a></li>
</ul>
<p>PŘÍKLADY</p>
<ul>
<li><a href="/slides/cs/python-java/examples/">Příklady podle prvků snímku</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference a podpora</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">Reference API</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Poznámky k vydání</a></li>
<li><a href="/slides/cs/python-java/known-issues/">Známé problémy</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">Produktová stránka</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Stáhnout</a></li>
</ul>
<p>PODPORA</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Bezplatné fórum podpory</a></li>
<li><a href="https://helpdesk.aspose.com/">Placený helpdesk podpory</a></li>
</ul>
</div>
</div>

------

## **Vaše první prezentace**

Nainstalujte Python a JDK, nastavte `JAVA_HOME` a vytvořte a aktivujte virtuální prostředí, jak je popsáno v [Instalace](/slides/cs/python-java/installation/). Poté nainstalujte JPype a Aspose.Slides z PyPI:

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
    # Získat první snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidat tvar mraku a nastavit jeho text.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Uložit prezentaci jako soubor PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Spusťte jej ve stejném virtuálním prostředí:

```sh
python hello.py
```

Skript uloží *new_presentation.pptx* s jedním snímkem obsahujícím tvar mraku s textem „Hello, Aspose!“. Bez licence obsahuje uložený soubor také vodoznak pro hodnocení — viz [Licencování](/slides/cs/python-java/licensing/). Pro více způsobů, jak vytvořit a naplnit prezentaci, viz [Vytváření prezentací](/slides/cs/python-java/create-presentation/).