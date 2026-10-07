---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /pl/net/
keywords:
- dokumentacja
- przetwarzanie prezentacji
- konwersja prezentacji
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Zacznij tutaj: zainstaluj Aspose.Slides for .NET, utwórz pierwszą prezentację i znajdź przewodniki dotyczące typowych zadań, wdrażania oraz referencji API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET to biblioteka klas umożliwiająca tworzenie, odczytywanie, edytowanie i konwertowanie prezentacji PowerPoint oraz OpenDocument w aplikacjach .NET, bez Microsoft PowerPoint ani automatyzacji Office.

Ładuje i zapisuje pliki PPT, PPTX, PPS, POT oraz ODP, w tym warianty z makrami i szablony, oraz eksportuje do PDF, XPS, HTML, SVG, TIFF, Markdown i obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>ROZPOCZĘCIE</p>
<ul>
<li><a href="/slides/pl/net/installation/">Instalacja</a></li>
<li><a href="/slides/pl/net/create-presentation/">Utwórz pierwszą prezentację</a></li>
<li><a href="/slides/pl/net/system-requirements/">Wymagania systemowe</a></li>
<li><a href="/slides/pl/net/getting-started/">Przewodnik wprowadzający</a></li>
</ul>
<p>EWALUACJA</p>
<ul>
<li><a href="/slides/pl/net/supported-file-formats/">Obsługiwane formaty plików</a></li>
<li><a href="/slides/pl/net/features-overview/">Przegląd funkcji</a></li>
<li><a href="/slides/pl/net/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/net/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Buduj z Slides</b></p>
<hr>
<p>CZĘSTE ZADANIA</p>
<ul>
<li><a href="/slides/pl/net/open-presentation/">Otwórz prezentację</a></li>
<li><a href="/slides/pl/net/save-presentation/">Zapisz prezentację</a></li>
<li><a href="/slides/pl/net/convert-powerpoint-to-pdf/">Konwertuj do PDF</a></li>
<li><a href="/slides/pl/net/convert-slide/">Renderuj slajdy jako obrazy</a></li>
<li><a href="/slides/pl/net/manage-text/">Edytuj tekst i kształty</a></li>
</ul>
<p>PRZEPŁYWY PRACY SLIDES</p>
<ul>
<li><a href="/slides/pl/net/powerpoint-charts/">Wykresy</a></li>
<li><a href="/slides/pl/net/powerpoint-animation/">Animacje</a></li>
<li><a href="/slides/pl/net/manage-media-files/">Audio i wideo</a></li>
<li><a href="/slides/pl/net/presentation-design/">Projektowanie slajdów</a></li>
<li><a href="/slides/pl/net/merge-presentation/">Łączenie prezentacji</a></li>
</ul>
<p>PRZYKŁADY</p>
<ul>
<li><a href="/slides/pl/net/examples/">Przykłady według elementu slajdu</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Przykłady na GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Wdrożenie i wsparcie</b></p>
<hr>
<p>WDROŻENIE</p>
<ul>
<li><a href="/slides/pl/net/net6/">Wieloplatformowe (.NET 6+)</a></li>
<li><a href="/slides/pl/net/how-to-run-aspose-slides-in-docker/">Uruchom w Dockerze</a></li>
<li><a href="/slides/pl/net/deploy-fonts/">Czcionki</a></li>
<li><a href="/slides/pl/net/security/">Bezpieczeństwo</a></li>
</ul>
<p>REFERENCJA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Referencja API</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Notatki o wersji</a></li>
<li><a href="/slides/pl/net/known-issues/">Znane problemy</a></li>
<li><a href="/slides/pl/net/api-limitations/">Ograniczenia metadanych wyjściowych</a></li>
<li><a href="https://products.aspose.com/slides/net/">Strona produktu</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Pobierz</a></li>
</ul>
<p>WSPARCIE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum wsparcia darmowego</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatny helpdesk wsparcia</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Twoja pierwsza prezentacja**

Utwórz aplikację konsolową przy użyciu .NET SDK 6 lub nowszego:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Następnie dodaj jeden pakiet dla swojej platformy:

- w systemie Windows: `dotnet add package Aspose.Slides.NET`
- w systemie Linux i macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — zobacz [Instalacja](/slides/pl/net/installation/) dla wymagań wstępnych Linux oraz dla systemów, które potrzebują Aspose.Slides.NET zamiast tego.

Zastąp zawartość pliku *Program.cs* tym kodem i uruchom `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Program zapisuje *hello.pptx* z jednym slajdem zawierającym pole tekstowe. Bez licencji, zapisany plik zawiera znak wodny wersji próbnej — zobacz [Licencjonowanie](/slides/pl/net/licensing/). Aby dowiedzieć się więcej o sposobach tworzenia i wypełniania prezentacji, zobacz [Tworzenie prezentacji](/slides/pl/net/create-presentation/).