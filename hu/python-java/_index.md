---
title: Aspose.Slides for Python via Java
second_title: Aspose.Slides for Python
type: docs
weight: 47
url: /hu/python-java/
is_root: true
keywords:
- Aspose.Slides for Python via Java
- Python PowerPoint könyvtár
- PowerPoint prezentációk kezelése Pythonban
- PowerPoint olvasása és írása Pythonban
- PowerPoint diák szerkesztése Pythonban
- PowerPoint exportálása PDF-be Pythonban
- PowerPoint exportálása SVG-be Pythonban
- diák előnézete Pythonban
- hang és videó hozzáadása diákhoz Pythonban
- PowerPoint a Microsoft Office nélkül
- Python
- Java
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for Python via Java-t, hozza létre az első prezentációt, és találja meg a gyakori feladatok útmutatóit, az API-referenciát és a támogatást."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for Python via Java egy könyvtár a PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és átalakításához Python alkalmazásokban, a Microsoft PowerPoint nélkül; a JPype-on keresztül a Python folyamatban futtatja az Aspose.Slides Java motorját.

Betölti és menti a PPT, PPTX, PPS, POT és ODP fájlokat, beleértve a makróval ellátott és sablon változatokat is, és exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kezdés</b></p>
<hr>
<p>ELSŐ LÉPÉSEK</p>
<ul>
<li><a href="/slides/hu/python-java/installation/">Telepítés</a></li>
<li><a href="/slides/hu/python-java/create-presentation/">Az első prezentáció létrehozása</a></li>
<li><a href="/slides/hu/python-java/getting-started/">Első lépések útmutatója</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/python-java/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/python-java/evaluate-aspose-slides/">Próba korlátozások</a></li>
<li><a href="/slides/hu/python-java/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Készítés Slides használatával</b></p>
<hr>
<p>ÁLTALÁNOS FELADATOK</p>
<ul>
<li><a href="/slides/hu/python-java/open-presentation/">Prezentáció megnyitása</a></li>
<li><a href="/slides/hu/python-java/save-presentation/">Prezentáció mentése</a></li>
<li><a href="/slides/hu/python-java/convert-powerpoint-to-pdf/">Átalakítás PDF-be</a></li>
<li><a href="/slides/hu/python-java/convert-slide/">Dia renderelése képként</a></li>
<li><a href="/slides/hu/python-java/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>DIÁK MUNKAFOLYAMOK</p>
<ul>
<li><a href="/slides/hu/python-java/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/python-java/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/python-java/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/python-java/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/python-java/merge-presentation/">Prezentációk egyesítése</a></li>
</ul>
<p>PELTÁK</p>
<ul>
<li><a href="/slides/hu/python-java/examples/">Példák diaelemenként</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia és Támogatás</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="/slides/hu/python-java/known-issues/">Ismert problémák</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">Termékoldal</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatói fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetett támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első prezentációja**

Telepítse a Pythont és egy JDK-t, állítsa be a `JAVA_HOME` változót, és hozza létre és aktiválja a virtuális környezetet a [Installation](/slides/hu/python-java/installation/) útmutatóban leírtak szerint. Ezután telepítse a JPype-ot és az Aspose.Slides-t a PyPI-ról:

```sh
python -m pip install JPype1 aspose-slides-java
```

Kód mentse *hello.py* néven. Elindítja a Java virtuális gépet, egy felhő alakzatot szöveggel ad hozzá az új prezentáció első diájához, és elmenti a prezentációt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Készítsen egy prezentációt egy üres diával.
presentation = Presentation()
try:
    # Lekéri az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Hozzáad egy felhő alakzatot, és beállítja a szövegét.
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

A szkript elmenti a *new_presentation.pptx*-t, amely egy diát tartalmaz, azon egy felhő alakzat a "Hello, Aspose!" szöveggel. Licenc nélkül a mentett fájl értékelési vízjel is tartalmaz — lásd a [Licensing](/slides/hu/python-java/licensing/) oldalt. További módszerekért a prezentáció létrehozására és kitöltésére lásd a [Create Presentations](/slides/hu/python-java/create-presentation/) oldalt.