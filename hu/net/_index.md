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
description: "Kezdje itt: telepítse az Aspose.Slides for .NET-et, hozza létre az első prezentációt, és találja meg a gyakori feladatok, a telepítés és az API referencia útmutatóit."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for .NET egy osztálykönyvtár a PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és konvertálásához .NET alkalmazásokban, a Microsoft PowerPoint vagy Office automatizáció nélkül.

Betölti és menti a PPT, PPTX, PPS, POT és ODP fájlokat, beleértve a makróval ellátott és sablon változatokat is, valamint exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumokba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Első lépések</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/hu/net/installation/">Telepítés</a></li>
<li><a href="/slides/hu/net/create-presentation/">Az első prezentáció létrehozása</a></li>
<li><a href="/slides/hu/net/system-requirements/">Rendszerkövetelmények</a></li>
<li><a href="/slides/hu/net/getting-started/">Gyorsindító útmutató</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/hu/net/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/net/features-overview/">Funkciók áttekintése</a></li>
<li><a href="/slides/hu/net/evaluate-aspose-slides/">Próba korlátozások</a></li>
<li><a href="/slides/hu/net/licensing/">Licenc</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Fejlesztés Slides segítségével</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/hu/net/open-presentation/">Prezentáció megnyitása</a></li>
<li><a href="/slides/hu/net/save-presentation/">Prezentáció mentése</a></li>
<li><a href="/slides/hu/net/convert-powerpoint-to-pdf/">Konvertálás PDF-be</a></li>
<li><a href="/slides/hu/net/convert-slide/">Diák renderelése képként</a></li>
<li><a href="/slides/hu/net/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/hu/net/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/net/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/net/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/net/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/net/merge-presentation/">Prezentációk egyesítése</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/hu/net/examples/">Példák diaelemenként</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Példák a GitHub-on</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Telepítés és támogatás</b></p>
<hr>
<p>DEPLOY</p>
<ul>
<li><a href="/slides/hu/net/net6/">Keresztplatformos (.NET 6+)</a></li>
<li><a href="/slides/hu/net/how-to-run-aspose-slides-in-docker/">Futtatás Dockerben</a></li>
<li><a href="/slides/hu/net/deploy-fonts/">Betűkészletek</a></li>
<li><a href="/slides/hu/net/security/">Biztonság</a></li>
</ul>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="/slides/hu/net/known-issues/">Ismert problémák</a></li>
<li><a href="/slides/hu/net/api-limitations/">Kimeneti metaadat korlátozások</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Letöltés</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetett támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Az első prezentációja**

Hozzon létre egy konzolalkalmazást a .NET SDK 6 vagy újabb használatával:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Ezután adjon hozzá egy csomagot a platformjához:

- Windows rendszeren: `dotnet add package Aspose.Slides.NET`
- Linuxon és macOS-en: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — lásd a [Installation](/slides/hu/net/installation/) szakaszt a Linux előfeltételhez és azokhoz a rendszerekhez, amelyek helyette az Aspose.Slides.NET-et igénylik.

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

A program elmenti a *hello.pptx*-t egy szövegdobozos diával. Licenc nélkül a mentett fájl értékelő vízjelet tartalmaz — lásd a [Licenc](/slides/hu/net/licensing/) szakaszt. További módokért a prezentáció létrehozására és feltöltésére, lásd a [Create Presentations](/slides/hu/net/create-presentation/) szakaszt.