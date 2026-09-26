---
title: Aspose.Slides dla .NET
second_title: Aspose.Slides dla .NET
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
description: "Zacznij tutaj: zainstaluj Aspose.Slides dla .NET, utwórz pierwszą prezentację i znajdź przewodniki dotyczące typowych zadań, referencję API oraz wsparcie."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET to biblioteka klas służąca do tworzenia, odczytywania, edytowania i konwertowania prezentacji PowerPoint oraz OpenDocument w aplikacjach .NET, bez użycia Microsoft PowerPoint ani automatyzacji Office.

Obsługuje wczytywanie i zapisywanie plików PPT, PPTX, PPS, POT oraz ODP, w tym wersje z makrami i szablonami, a także eksportuje do PDF, XPS, HTML, SVG, TIFF, Markdown oraz obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>ROZPOCZĘCIE</p>
<ul>
<li><a href="/slides/pl/net/installation/">Instalacja</a></li>
<li><a href="/slides/pl/net/create-presentation/">Utwórz swoją pierwszą prezentację</a></li>
<li><a href="/slides/pl/net/getting-started/">Przewodnik po rozpoczęciu</a></li>
</ul>
<p>OCENA</p>
<ul>
<li><a href="/slides/pl/net/supported-file-formats/">Obsługiwane formaty plików</a></li>
<li><a href="/slides/pl/net/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/net/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Buduj przy użyciu Slides</b></p>
<hr>
<p>ZADANIA PODSTAWOWE</p>
<ul>
<li><a href="/slides/pl/net/open-presentation/">Otwórz prezentację</a></li>
<li><a href="/slides/pl/net/save-presentation/">Zapisz prezentację</a></li>
<li><a href="/slides/pl/net/convert-powerpoint-to-pdf/">Konwertuj do PDF</a></li>
<li><a href="/slides/pl/net/convert-slide/">Renderuj slajdy jako obrazy</a></li>
<li><a href="/slides/pl/net/manage-text/">Edytuj tekst i kształty</a></li>
</ul>
<p>PRZEPŁYW PRACY</p>
<ul>
<li><a href="/slides/pl/net/powerpoint-charts/">Wykresy</a></li>
<li><a href="/slides/pl/net/powerpoint-animation/">Animacje</a></li>
<li><a href="/slides/pl/net/manage-media-files/">Audio i wideo</a></li>
<li><a href="/slides/pl/net/presentation-design/">Projektowanie slajdów</a></li>
<li><a href="/slides/pl/net/merge-presentation/">Scalanie prezentacji</a></li>
</ul>
<p>PRZYKŁADY</p>
<ul>
<li><a href="/slides/pl/net/examples/">Przykłady według elementów slajdu</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Przykłady na GitHubie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencje &amp; wsparcie</b></p>
<hr>
<p>REFERENCJA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/pl/net/">Referencja API</a></li>
<li><a href="https://releases.aspose.com/slides/pl/net/release-notes/">Notatki o wydaniu</a></li>
<li><a href="/slides/pl/net/known-issues/">Znane problemy</a></li>
<li><a href="https://releases.aspose.com/slides/pl/net/">Pobierz</a></li>
</ul>
<p>WSPIERANIE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/pl/11">Darmowe forum wsparcia</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatny helpdesk wsparcia</a></li>
</ul>
</div>
</div>

------

## **Twoja pierwsza prezentacja**

Utwórz aplikację konsolową przy użyciu .NET SDK 6 lub nowszego:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Następnie dodaj jeden pakiet odpowiedni dla Twojej platformy:

- W systemie Windows: `dotnet add package Aspose.Slides.NET`
- W systemie Linux i macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — zobacz [Licencjonowanie](/slides/pl/net/licensing/) w celu uzyskania wymagań wstępnych dla Linuxa oraz dla systemów, które potrzebują Aspose.Slides.NET zamiast tego.

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

Program zapisuje *hello.pptx* z jednym slajdem zawierającym pole tekstowe. Bez licencji zapisany plik zawiera znak wodny wersji próbnej — zobacz [Licencjonowanie](/slides/pl/net/licensing/). Aby poznać więcej sposobów tworzenia i wypełniania prezentacji, zobacz [Tworzenie prezentacji](/slides/pl/net/create-presentation/).