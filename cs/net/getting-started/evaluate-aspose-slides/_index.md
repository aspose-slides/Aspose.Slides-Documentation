---
title: Vyhodnocení Aspose.Slides
type: docs
weight: 75
url: /cs/net/evaluate-aspose-slides/
keywords:
- vyhodnocení Aspose.Slides
- hodnocení Aspose.Slides
- verze pro hodnocení
- plná funkčnost
- hodnoticí vodoznak
- nákup Aspose.Slides
- omezení
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vyzkoušejte Aspose.Slides pro .NET a prozkoumejte funkce API pro prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) - začněte svou bezplatnou zkušební verzi."
---
## **Aspose.Slides – zkušební verze**

Můžete si stáhnout Aspose.Slides k vyhodnocení. Evaluační balíček je stejný jako zakoupený balíček; po přidání několika řádků kódu pro použití licence se stane licencovaným.

Bez licence poskytuje Aspose.Slides svou plnou funkčnost v evaluačním režimu, s dvěma omezeními: přidá vodoznak s textem pro hodnocení na každou snímek každé prezentace, kterou uloží, a text, který váš kód čte z prezentace, je zkrácen na první několik znaků, následováno oznámením o evaluačním omezení. Text, který váš kód zapisuje, je uložen v plném rozsahu.

![Snímek s evaluačním vodoznakem](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Pokud chcete testovat Aspose.Slides bez omezení evaluační verze, můžete požádat o **30denní dočasnou licenci**. Další informace najdete v [Jak získat dočasnou licenci?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Instalace evaluačního balíčku**

```bash
dotnet add package Aspose.Slides.NET
```

Na Linuxu a macOS můžete místo toho použít balíček Aspose.Slides.NET6.CrossPlatform; viz [Instalace](/slides/cs/net/installation/).

## **Použití licence**

Toto jsou „několik řádků kódu“, které přemění evaluační balíček na licencovaný. Licenci použijte jednou při spuštění aplikace, před vytvořením jakéhokoli objektu `Presentation` — prezentace vytvořená dříve si ponechává evaluační vodoznak.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` také přijímá `Stream`, což je lepší možnost, když je licence distribuována jako vložený prostředek místo souboru na disku. Pokud je cesta špatná nebo soubor vypršel, volání vyhodí výjimku, takže selhání se projeví okamžitě při startu místo tichého přepnutí do evaluačního režimu.

Po použití licence uložené prezentace již neobsahují vodoznak a text se čte v plném rozsahu.

## **Často kladené otázky**

### Mohu v evaluačním režimu testovat více prezentací paralelně napříč různými vlákny?

Ano. Můžete zpracovávat různé dokumenty paralelně; neměli byste sdílet stejný objekt prezentace [napříč vlákny](/slides/cs/net/multithreading/). Evaluační režim to neovlivňuje.

### Potřebuji nainstalovat Microsoft PowerPoint k vyhodnocení knihovny na serveru nebo v CI?

Ne. Aspose.Slides je samostatný engine a nevyžaduje instalaci PowerPointu ani pro vyhodnocení, ani pro produkci.

### Mohu v evaluačním režimu plně testovat konverzi PPT/PPTX do PDF a obrázků?

Ano. [Konvertory](/slides/cs/net/convert-presentation/) fungují; výstup bude obsahovat vodoznak.

### Mohu použít dočasnou licenci pro zátěžové testování bez vodoznaku?

Ano. 30denní dočasná licence odstraňuje omezení evaluačního režimu a umožňuje testování bez vodoznaku.