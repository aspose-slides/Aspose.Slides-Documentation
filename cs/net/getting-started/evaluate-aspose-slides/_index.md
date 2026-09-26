---
title: Vyhodnocení Aspose.Slides
type: docs
weight: 120
url: /cs/net/evaluate-aspose-slides/
keywords:
- vyhodnocení Aspose.Slides
- vyhodnocení Aspose.Slides
- verze pro vyhodnocení
- plná funkčnost
- vodotisk vyhodnocení
- nákup Aspose.Slides
- omezení
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vyzkoušejte Aspose.Slides pro .NET a prozkoumejte funkce API pro prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) — začněte svou bezplatnou zkušební verzi."
---
## **Vyzkoušení Aspose.Slides**

Můžete si stáhnout Aspose.Slides pro vyzkoušení. Vyhodnocovací balíček je stejný jako zakoupený balíček; po přidání několika řádků kódu pro aplikaci licence se stane licencovaným.

Bez licence poskytuje Aspose.Slides svou plnou funkčnost v režimu vyhodnocení, s dvěma omezeními: přidá textové pole s vodotiskem „Evaluation“ na každý snímek každé prezentace, kterou uloží, a text, který váš kód načítá z prezentace, je oříznut na několik prvních znaků a doplněn upozorněním o omezení vyhodnocení. Text, který váš kód zapisuje, je uložen celý.

![Snímek s vodotiskem vyhodnocení](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Pokud chcete testovat Aspose.Slides bez omezení vyhodnocovací verze, můžete požádat o **30denní dočasnou licenci**. Další informace naleznete v [Jak získat dočasnou licenci?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Instalace vyhodnocovacího balíčku**

```bash
dotnet add package Aspose.Slides.NET
```

Na Linuxu a macOS můžete místo toho použít balíček Aspose.Slides.NET6.CrossPlatform; viz [Instalace](/slides/cs/net/installation/).

## **Aplikace licence**

Toto jsou „několik řádků kódu“, které promění vyhodnocovací balíček na licencovaný. Aplikujte licenci jednou při startu aplikace, před vytvořením jakéhokoli objektu `Presentation` — prezentace vytvořená dříve si ponechá vodotisk vyhodnocení.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` také přijímá `Stream`, což je lepší volba, když je licence dodávána jako vložený prostředek místo souboru na disku. Pokud je cesta špatná nebo licence vypršela, volání vyvolá výjimku, takže selhání se projeví okamžitě při startu místo tichého přepnutí do režimu vyhodnocení.

Po aplikaci licence neobsahují uložené prezentace vodotisk a text se načítá celé.

## **FAQ**

### Mohu testovat více prezentací paralelně napříč různými vlákny v režimu vyhodnocení?

Ano. Můžete zpracovávat různé dokumenty paralelně; neměli byste sdílet stejný objekt prezentace [napříč vlákny](/slides/cs/net/multithreading/). Režim vyhodnocení to neovlivňuje.

### Potřebuji nainstalovat Microsoft PowerPoint pro vyhodnocení knihovny na serveru nebo v CI?

Ne. Aspose.Slides je samostatný engine a nevyžaduje instalaci PowerPointu ani při vyhodnocení, ani v produkci.

### Mohu kompletně testovat konverzi PPT/PPTX do PDF a obrázků v režimu vyhodnocení?

Ano. [Konvertory](/slides/cs/net/convert-presentation/) fungují; výstup bude obsahovat vodotisk.

### Mohu použít dočasnou licenci pro zátěžové testování bez vodotisku?

Ano. 30denní dočasná licence odstraňuje omezení režimu vyhodnocení a umožňuje testování bez vodotisku.