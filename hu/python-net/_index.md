---
title: Aspose.Slides Pythonhoz .NET-en keresztül
second_title: Aspose.Slides Pythonhoz
type: docs
weight: 35
url: /hu/python-net/
is_root: true
keywords:
- Aspose.Slides Pythonhoz
- PowerPoint automatizálás Pythonban
- Python PPT könyvtár
- PowerPoint exportálása PDF-be Pythonban
- PowerPoint exportálása SVG-be Pythonban
- PowerPoint szerkesztése Pythonban
- Python PowerPoint Microsoft Office nélkül
- PPTX kezelése Pythonnal
- diák előnézete Pythonban
- Python hang hozzáadása diákhoz
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for Python via .NET-et, hozzon létre egy első prezentációt, és találja meg a gyakori feladatok útmutatóit, az API-referenciát és a támogatást."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides Pythonhoz .NET-en keresztül" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for Python via .NET egy Python könyvtár PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és konvertálásához, a Microsoft PowerPoint vagy Microsoft Office nélkül.

Képes betölteni és menteni a PPT, PPTX, PPS, POT és ODP formátumokat, beleértve a makróval ellátott és sablonváltozatokat is, valamint exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumokba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Első lépések</b></p>
<hr>
<p>Kezdő útmutató</p>
<ul>
<li><a href="/slides/hu/python-net/installation/">Telepítés</a></li>
<li><a href="/slides/hu/python-net/create-presentation/">Az első prezentáció létrehozása</a></li>
<li><a href="/slides/hu/python-net/getting-started/">Első lépések útmutatója</a></li>
</ul>
<p>Értékelés</p>
<ul>
<li><a href="/slides/hu/python-net/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/python-net/evaluate-aspose-slides/">Próba verzió korlátai</a></li>
<li><a href="/slides/hu/python-net/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Felépítés Slides-szel</b></p>
<hr>
<p>Általános feladatok</p>
<ul>
<li><a href="/slides/hu/python-net/open-presentation/">Prezentáció megnyitása</a></li>
<li><a href="/slides/hu/python-net/save-presentation/">Prezentáció mentése</a></li>
<li><a href="/slides/hu/python-net/convert-powerpoint-to-pdf/">Konvertálás PDF-be</a></li>
<li><a href="/slides/hu/python-net/convert-slide/">Diák képként megjelenítése</a></li>
<li><a href="/slides/hu/python-net/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>Slides munkafolyamatok</p>
<ul>
<li><a href="/slides/hu/python-net/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/python-net/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/python-net/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/python-net/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/python-net/merge-presentation/">Prezentációk összefésülése</a></li>
</ul>
<p>Példák</p>
<ul>
<li><a href="/slides/hu/python-net/examples/">Példák diaelemek szerint</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Példák a GitHub-on</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia &amp; Támogatás</b></p>
<hr>
<p>Referencia</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Kiadási jegyzetek</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">Termékoldal</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Letöltés</a></li>
</ul>
<p>Támogatás</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatói fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetős támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első prezentációd**

Telepítsd a csomagot a PyPI-ról:

```bash
pip install aspose.slides
```

A csomag tartalmazza a használt .NET futtatókörnyezetet, ezért nem szükséges a .NET-et telepíteni. Linuxon telepítsd a libgdiplus és az ICU könyvtárakat is, és a Debian vagy Ubuntu rendszer‑Pythonjával egy virtuális környezetben futtasd a parancsot. A macOS-hoz további előfeltételek szükségesek, és a telepítést ott nem ellenőriztük. Lásd a [Telepítés](/slides/hu/python-net/installation/) oldalt a parancsokért, a macOS előfeltételekért és a támogatott Python verziókért.

Mentsd el ezt a kódot *hello.py* néven:

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:
    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adjon hozzá egy CLOUD típusú automatikus alakzatot.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Mentse a prezentációt PPTX fájlként.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Futtasd a `python hello.py` paranccsal. A script a *new_presentation.pptx* fájlt menti az aktuális mappába, egyetlen diát tartalmazva, amely egy felhő alakzatot mutat, és a szöveg: "Hello, Aspose!". Licenc nélkül a mentett fájl értékelő vízjelet tartalmaz – lásd a [Licencelés](/slides/hu/python-net/licensing/) részt. További módokért a prezentációk létrehozására és feltöltésére, lásd a [Prezentációk létrehozása](/slides/hu/python-net/create-presentation/).