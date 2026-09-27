---
title: "Aspose.Slides Pythonhoz Java-n keresztül"
second_title: "Aspose.Slides Pythonhoz"
type: docs
weight: 47
url: /hu/python-java/
is_root: true
keywords:
- "Aspose.Slides Pythonhoz Java-n keresztül"
- "Python PowerPoint könyvtár"
- "PowerPoint prezentációk kezelése Pythonban"
- "PowerPoint olvasása és írása Pythonban"
- "PowerPoint diák szerkesztése Pythonban"
- "PowerPoint exportálása PDF-be Pythonban"
- "PowerPoint exportálása SVG-be Pythonban"
- "Diák előnézete Pythonban"
- "Hang és videó hozzáadása diákhoz Pythonban"
- "PowerPoint Microsoft Office nélkül"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Kezdje itt: telepítse az Aspose.Slides for Python via Java könyvtárat, hozza létre az első prezentációt, és keresse meg az útmutatókat a gyakori feladatokhoz, az API referenciához és a támogatáshoz."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for Python via Java egy könyvtár PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és konvertálásához Python alkalmazásokban, a Microsoft PowerPoint nélkül; a Java Aspose.Slides motorját futtatja a Python folyamatban a JPype segítségével.

Támogatja a PPT, PPTX, PPS, POT és ODP fájlok betöltését és mentését, beleértve a makrókkal ellátott és sablonváltozatokat is, valamint exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumokba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kezdő lépések</b></p>
<hr>
<p>ELKEZDÉS</p>
<ul>
<li><a href="/slides/hu/python-java/installation/">Telepítés</a></li>
<li><a href="/slides/hu/python-java/create-presentation/">Készítsd el az első prezentációdat</a></li>
<li><a href="/slides/hu/python-java/getting-started/">Kezdő útmutató</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/python-java/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/python-java/evaluate-aspose-slides/">Próba korlátozások</a></li>
<li><a href="/slides/hu/python-java/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Készítés a Slides-szel</b></p>
<hr>
<p>ÁLTALÁNOS FELADATOK</p>
<ul>
<li><a href="/slides/hu/python-java/open-presentation/">Prezentáció megnyitása</a></li>
<li><a href="/slides/hu/python-java/save-presentation/">Prezentáció mentése</a></li>
<li><a href="/slides/hu/python-java/convert-powerpoint-to-pdf/">Konvertálás PDF-be</a></li>
<li><a href="/slides/hu/python-java/convert-slide/">Dia renderelése képeként</a></li>
<li><a href="/slides/hu/python-java/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>SLIDES MUNKAFOLYAMOK</p>
<ul>
<li><a href="/slides/hu/python-java/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/python-java/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/python-java/manage-media-files/">Audio és videó</a></li>
<li><a href="/slides/hu/python-java/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/python-java/merge-presentation/">Prezentációk egyesítése</a></li>
</ul>
<p>PELDÁK</p>
<ul>
<li><a href="/slides/hu/python-java/examples/">Példák diaelemek szerint</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenciák és támogatás</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">API referenciák</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="/slides/hu/python-java/known-issues/">Ismert hibák</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatói fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetős támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első prezentációd**

Telepítsd a Python-t és egy JDK-t, állítsd be a `JAVA_HOME` környezeti változót, majd hozd létre és aktiváld a virtuális környezetet a [Installation](/slides/hu/python-java/installation/) útmutató szerint. Ezután telepítsd a JPype-ot és az Aspose.Slides-et a PyPI-ról:

```sh
python -m pip install JPype1 aspose-slides-java
```

Mentse el ezt a kódot *hello.py* néven. Elindítja a Java Virtual Machine-et, felvesz egy felhő alakzatot szöveggel az új prezentáció első diájára, és menti a prezentációt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Készítsen egy prezentációt egy üres diával.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy felhő alakzatot és állítsa be a szövegét.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Mentse a prezentációt PPTX fájlként.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Futtassa ugyanabban a virtuális környezetben:

```sh
python hello.py
```

A szkript *new_presentation.pptx*-t ment egy diával, amely egy felhő alakzatot tartalmaz a "Hello, Aspose!" szöveggel. Licenc nélkül a mentett fájl értékelő vízjelet is tartalmaz — lásd a [Licensing](/slides/hu/python-java/licensing/) oldalt. További módok a prezentációk létrehozására és kitöltésére a [Create Presentations](/slides/hu/python-java/create-presentation/) oldalon találhatók.