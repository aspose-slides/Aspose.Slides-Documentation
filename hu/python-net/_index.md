---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /hu/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- PowerPoint automatizálás Pythonban
- Python PPT könyvtár
- PowerPoint exportálása PDF-be Pythonban
- PowerPoint exportálása SVG-be Pythonban
- PowerPoint szerkesztése Pythonban
- Python PowerPoint Microsoft Office nélkül
- PPTX kezelése Pythonban
- Dia előnézet Pythonban
- Python hang hozzáadása diákhoz
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for Python via .NET-et, hozzon létre egy első prezentációt, és találja meg az útmutatókat a gyakori feladatokhoz, az API referenciához és a támogatáshoz."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for Python via .NET egy Python könyvtár a PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és konvertálásához, a Microsoft PowerPoint vagy Microsoft Office nélkül.

Támogatja a PPT, PPTX, PPS, POT és ODP fájlok betöltését és mentését, beleértve a makrókat tartalmazó és sablonváltozatokat, valamint exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumokba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Első lépések</b></p>
<hr>
<p>Kezdés</p>
<ul>
<li><a href="/slides/hu/python-net/installation/">Telepítés</a></li>
<li><a href="/slides/hu/python-net/create-presentation/">Első prezentáció létrehozása</a></li>
<li><a href="/slides/hu/python-net/getting-started/">Kezdő útmutató</a></li>
</ul>
<p>Értékelés</p>
<ul>
<li><a href="/slides/hu/python-net/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/python-net/evaluate-aspose-slides/">Próba korlátok</a></li>
<li><a href="/slides/hu/python-net/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides használata</b></p>
<hr>
<p>Általános feladatok</p>
<ul>
<li><a href="/slides/hu/python-net/open-presentation/">Prezentáció megnyitása</a></li>
<li><a href="/slides/hu/python-net/save-presentation/">Prezentáció mentése</a></li>
<li><a href="/slides/hu/python-net/convert-powerpoint-to-pdf/">Átalakítás PDF-be</a></li>
<li><a href="/slides/hu/python-net/convert-slide/">Dia renderelése képekként</a></li>
<li><a href="/slides/hu/python-net/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>Slides munkafolyamatok</p>
<ul>
<li><a href="/slides/hu/python-net/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/python-net/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/python-net/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/python-net/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/python-net/merge-presentation/">Prezentációk egyesítése</a></li>
</ul>
<p>Példák</p>
<ul>
<li><a href="/slides/hu/python-net/examples/">Példák diaelemek szerint</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Példák a GitHub-on</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia és támogatás</b></p>
<hr>
<p>Referencia</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Letöltés</a></li>
</ul>
<p>Támogatás</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetett támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első prezentációd**

Telepítsd a csomagot a PyPI-ról:

```bash
pip install aspose.slides
```

A csomag tartalmazza a használt .NET futtatókörnyezetet, így nem kell telepítened a .NET-et. Linux alatt telepítsd a libgdiplus és az ICU könyvtárakat is, és a Debian vagy Ubuntu rendszermag Pythonjával egy virtuális környezetben futtasd a parancsot. macOS-nek további előfeltételei vannak, és a telepítést ott még nem ellenőriztük. Lásd a [Telepítés](/slides/hu/python-net/installation/) oldalt a parancsokért, a macOS előfeltételekért és a támogatott Python verziókért.

Mentsd el ezt a kódot *hello.py*-ként:

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

Futtasd a `python hello.py` paranccsal. A script elmenti a *new_presentation.pptx*-t az aktuális mappába, egyetlen diával, amely felhő alakzatot tartalmaz és a "Hello, Aspose!" szöveget jeleníti meg. Licenc nélkül a mentett fájl értékelő vízjelet kap — lásd a [Licenc](/slides/hu/python-net/licensing/). További módokért a prezentáció létrehozására és feltöltésére, lásd a [Prezentációk létrehozása](/slides/hu/python-net/create-presentation/).