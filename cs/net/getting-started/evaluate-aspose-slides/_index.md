---
title: Vyzkoušet Aspose.Slides
type: docs
weight: 120
url: /cs/net/evaluate-aspose-slides/
keywords:
- vyzkoušet Aspose.Slides
- Vyhodnocení Aspose.Slides
- evaluační verze
- plná funkcionalita
- evaluační vodoznak
- zakoupit Aspose.Slides
- omezení
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vyzkoušejte Aspose.Slides pro .NET a prozkoumejte funkce API pro prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) - začněte bezplatnou zkušební verzí."
---
## **Aspose.Slides – zkušební verze**

Aspose.Slides si můžete snadno stáhnout k vyzkoušení. Zkušební balíček je stejný jako zakoupený balíček. Zkušební verze se jednoduše změní na licencovanou poté, co přidáte několik řádků kódu pro aplikaci licence.

Zkušební verze Aspose.Slides (bez určené licence) poskytuje plnou funkčnost produktu, ale při otevření a uložení vloží vodoznak záměru na horní část dokumentu. Také jste omezeni na jeden snímek při extrahování textu z prezentačních snímků.

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 
Pokud chcete testovat Aspose.Slides bez omezení zkušební verze, můžete požádat o **30denní dočasnou licenci**. Další informace naleznete v článku [Jak získat dočasnou licenci?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Instalace zkušebního balíčku**

```bash
dotnet add package Aspose.Slides.NET
```

## **Aplikace licence**

Toto jsou „několik řádků kódu“, které promění zkušební balíček na licencovaný. Aplikujte licenci jednou při spuštění aplikace, před vytvořením jakéhokoli objektu `Presentation` — prezentace vytvořená dříve si ponechá zkušební vodoznak.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` také přijímá `Stream`, což je lepší varianta, pokud je licence dodávána jako vložený prostředek místo souboru na disku. Pokud je cesta špatná nebo soubor vypršel, volání vyhodí výjimku, takže selhání se projeví okamžitě při spuštění místo tichého přepnutí do zkušebního režimu.

Po aplikaci licence zmizí vodoznak a omezení na jeden snímek při extrahování textu se zruší.

## **Často kladené otázky**

### Mohu testovat více prezentací paralelně napříč různými vlákny v zkušebním režimu?

Ano. Můžete zpracovávat různé dokumenty paralelně; neměli byste sdílet stejný objekt prezentace [napříč vlákny](/slides/cs/net/multithreading/). Zkušební režim to neovlivňuje.

### Musím pro vyhodnocení knihovny na serveru nebo v CI nainstalovat Microsoft PowerPoint?

Ne. Aspose.Slides je samostatný engine a nevyžaduje instalaci PowerPointu ani pro vyhodnocení, ani pro produkci.

### Mohu v zkušebním režimu kompletně testovat převod PPT/PPTX na PDF a obrázky?

Ano. [Konvertory](/slides/cs/net/convert-presentation/) fungují; výstup bude obsahovat vodoznak.

### Mohu použít dočasnou licenci pro zátěžové testování bez vodoznaku?

Ano. 30denní dočasná licence odstraňuje omezení zkušebního režimu a umožňuje testování bez vodoznaku.