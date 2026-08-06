---
title: Aspose.Slides pro Python via .NET
second_title: Aspose.Slides pro Python
type: docs
weight: 35
url: /cs/python-net/
is_root: true
keywords:
- Aspose.Slides pro Python
- Automatizace PowerPoint v Pythonu
- Knihovna PPT pro Python
- Export PowerPoint do PDF v Pythonu
- Export PowerPoint do SVG v Pythonu
- Úprava PowerPoint v Pythonu
- PowerPoint v Pythonu bez Microsoft Office
- Správa PPTX v Pythonu
- Náhled snímků v Pythonu
- Přidání audia do snímků v Pythonu
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides pro Python via .NET nabízí komplexní sadu funkcí, včetně správy textu, tvarů, tabulek a animací, přidávání audia a videa do snímků, náhledu snímků a exportu do SVG, PDF a dalších."
---
{{% alert color="primary" %}}

**Vítejte v Aspose.Slides for Python via .NET**

![Logo produktu Aspose.Slides for Python via .NET](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET je robustní knihovna tříd, která umožňuje vašim aplikacím číst a zapisovat prezentace PowerPoint® bez nutnosti Microsoft PowerPoint®.

Jedná se o první a jedinou komponentu, která poskytuje plnohodnotnou správu dokumentů PowerPoint® pro vývojáře v Pythonu.

Aspose.Slides for Python via .NET zahrnuje širokou škálu funkcí, jako je práce s textem, tvary, tabulkami a animacemi; přidávání audia a videa; náhled snímků; a export snímků do formátů jako SVG, PDF a další.

{{% /alert %}}

## Instalace Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

Balíček obsahuje požadované .NET runtime, takže není potřeba nic dalšího instalovat a Microsoft PowerPoint není vyžadován. Python 3.7 nebo novější na Windows, Linuxu nebo macOS.

## Vytvoření PowerPoint prezentace v Pythonu

Tento příklad vytvoří prezentaci, přidá tvar s textem na první snímek a uloží výsledek jak ve formátu PPTX, tak PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

Po spuštění zapíše `presentation.pptx` (asi 34 KB) a `presentation.pdf` (asi 36 KB) do pracovního adresáře.

Bez licence knihovna běží v evaluačním režimu, který přidává vodoznak a omezuje počet snímků. Více viz [Licencování](/slides/cs/python-net/licensing/).

## Zdroje Aspose.Slides for Python via .NET

Prozkoumejte tyto užitečné zdroje:

- [Online dokumentace Aspose.Slides for Python via .NET](/slides/cs/python-net/)
- [Funkce Aspose.Slides for Python via .NET](/slides/cs/python-net/features-overview/)
- [Poznámky k vydání Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/cs/python-net/release-notes/)
- [Produktová stránka Aspose.Slides for Python via .NET](https://products.aspose.com/slides/cs/python-net/)
- [Stáhnout Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/cs/python-net/)
- [Instalace balíčku Aspose.Slides for Python via .NET z PyPi](https://pypi.org/project/aspose.slides/)
- [Průvodce referencí API Aspose.Slides for Python via .NET](https://reference.aspose.com/slides/cs/python-net/)
- [Bezplatné fórum podpory Aspose.Slides for Python via .NET](https://forum.aspose.com/c/slides/cs/11)
- [Placená podpora Aspose.Slides for Python via .NET](https://helpdesk.aspose.com/)

## Často kladené otázky

### Co je Aspose.Slides for Python via .NET?

Aspose.Slides for Python via .NET je výkonná Python knihovna, která vám umožní programově vytvářet, upravovat a konvertovat PowerPoint prezentace (PPT, PPTX, ODP) bez nainstalovaného Microsoft PowerPoint.

### Jaké funkce prezentací Aspose.Slides podporuje?

Knihovna podporuje správu textu, tvarů, tabulek, grafů, animací, hlavních snímků, audia, videa a další. Také umožňuje náhled snímků, vykreslování, tisk a export do formátů jako PDF, SVG, HTML a obrázky.

### Mohu pomocí Aspose.Slides konvertovat prezentace do jiných formátů?

Ano. Aspose.Slides umožňuje konverzi souborů PowerPoint do PDF, SVG, HTML, JPG, PNG, TIFF a dalších formátů s vysokou věrností a výkonem.

### Je pro použití Aspose.Slides vyžadován Microsoft PowerPoint?

Ne. Aspose.Slides je samostatné API a nevyžaduje Microsoft Office ani žádný software třetích stran.

### Jaké platformy Aspose.Slides for Python via .NET podporuje?

Je multiplatformní a funguje v prostředích Windows, Linux a macOS.

### Jak začít s Aspose.Slides for Python?

Můžete jej nainstalovat přes PyPi a prozkoumat [Průvodce vývojáře](/slides/cs/python-net/developer-guide/), abyste začali s příklady, referencemi API a tutoriály.