---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /hu/net/
keywords:
- dokumentáció
- prezentációfeldolgozás
- prezentációkonverzió
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for .NET-et, hozzon létre egy első prezentációt, és találja meg az útmutatókat a gyakori feladatokhoz, az API referenciához és a támogatáshoz."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for .NET egy osztálykönyvtár a PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és konvertálásához .NET alkalmazásokban, a Microsoft PowerPoint vagy Office Automation nélkül.

Betölti és menti a PPT, PPTX, PPS, POT és ODP fájlokat, beleértve a makrókkal rendelkező és sablon változatokat is, és exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Első lépések</b></p>
<hr>
<p>Kezdés</p>
<ul>
<li><a href="/slides/hu/net/installation/">Telepítés</a></li>
<li><a href="/slides/hu/net/create-presentation/">Első prezentáció létrehozása</a></li>
<li><a href="/slides/hu/net/getting-started/">Kezdő útmutató</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/net/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/net/evaluate-aspose-slides/">Próba korlátozások</a></li>
<li><a href="/slides/hu/net/licensing/">Licenc</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Készítés Slides-szel</b></p>
<hr>
<p>ÁLTALÁNOS FELADATOK</p>
<ul>
<li><a href="/slides/hu/net/open-presentation/">Prezentáció megnyitása</a></li>
<li><a href="/slides/hu/net/save-presentation/">Prezentáció mentése</a></li>
<li><a href="/slides/hu/net/convert-powerpoint-to-pdf/">Átalakítás PDF-be</a></li>
<li><a href="/slides/hu/net/convert-slide/">Diaok képként renderelése</a></li>
<li><a href="/slides/hu/net/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>SLIDES FOLYAMATOK</p>
<ul>
<li><a href="/slides/hu/net/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/net/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/net/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/net/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/net/merge-presentation/">Prezentációk egyesítése</a></li>
</ul>
<p>PELDÁK</p>
<ul>
<li><a href="/slides/hu/net/examples/">Példák diaelemekenként</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Példák a GitHub-on</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia és támogatás</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="/slides/hu/net/known-issues/">Ismert problémák</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetett támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első prezentációd**

Hozzon létre egy konzolalkalmazást a .NET SDK 6 vagy újabb verziójával:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Ezután adjon hozzá egy csomagot a platformjához:

- Windows rendszeren: `dotnet add package Aspose.Slides.NET`
- Linux és macOS rendszeren: `dotnet add package Aspose.Slides.NET6.CrossPlatform` – lásd az [Installation](/slides/hu/net/installation/) oldalt a Linux előfeltételekhez, és azokhoz a rendszerekhez, amelyek helyette az Aspose.Slides.NET-et igénylik.

Cserélje le a *Program.cs* tartalmát erre a kódra, és futtassa a `dotnet run` parancsot:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

A program ment egy *hello.pptx* fájlt, amely egy diát tartalmaz szövegdobozzal. Licenc nélkül a mentett fájl egy értékelési vízjelet tartalmaz – lásd a [Licensing](/slides/hu/net/licensing/) oldalt. További módok a prezentáció létrehozására és feltöltésére megtalálhatók a [Create Presentations](/slides/hu/net/create-presentation/) oldalon.