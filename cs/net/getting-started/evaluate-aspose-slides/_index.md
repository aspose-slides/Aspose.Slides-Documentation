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
description: "Vyhodnoťte Aspose.Slides pro .NET a prozkoumejte funkce API pro prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) — začněte svou bezplatnou zkušební verzi."
---
## **Aspose.Slides Vyhodnocení**

Aspose.Slides můžete snadno stáhnout k vyhodnocení. Vyhodnocovací balíček je stejný jako zakoupený balíček. Vyhodnocovací verze se jednoduše stane licencovanou poté, co přidáte několik řádků kódu pro použití licence.

Vyhodnocovací verze Aspose.Slides (bez uvedené licence) poskytuje plnou funkčnost produktu, ale při otevření a uložení vloží vodotisk pro vyhodnocení v horní části dokumentu. Při extrahování textu z prezentačních snímků jste také omezeni na jeden snímek.

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="primary" %}} 
Pokud chcete testovat Aspose.Slides bez omezení vyhodnocovací verze, můžete požádat o **30denní dočasnou licenci**. Další informace najdete v [Jak získat dočasnou licenci?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Instalace vyhodnocovacího balíčku**

```bash
dotnet add package Aspose.Slides.NET
```

## **Použití licence**

Toto jsou „několik řádků kódu“, které přemění vyhodnocovací balíček na licencovanou verzi. Licenci použijte jednou při spuštění aplikace, před vytvořením jakéhokoli objektu `Presentation` — prezentace vytvořená dříve si zachová vyhodnocovací vodotisk.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` také přijímá `Stream`, což je lepší možnost, když je licence distribuována jako vložený prostředek místo souboru na disku. Pokud je cesta špatná nebo soubor vypršel, volání vyhodí výjimku, takže selhání se projeví okamžitě při spuštění místo tichého přechodu do režimu vyhodnocení.

Po použití licence vodotisk zmizí a omezení na jeden snímek při extrakci textu je odstraněno.

## **Často kladené otázky**

### Mohu testovat více prezentací paralelně napříč různými vlákny v režimu vyhodnocení?

Ano. Můžete zpracovávat různé dokumenty paralelně; neměli byste sdílet stejný objekt prezentace [napříč vlákny](/slides/cs/net/multithreading/). Režim vyhodnocení to neovlivňuje.

### Potřebuji nainstalovat Microsoft PowerPoint pro vyhodnocení knihovny na serveru nebo v CI?

Ne. Aspose.Slides je samostatný engine a nevyžaduje instalaci PowerPointu ani pro vyhodnocení, ani pro produkci.

### Mohu plně otestovat konverzi PPT/PPTX do PDF a obrázků v režimu vyhodnocení?

Ano. [Konvertory](/slides/cs/net/convert-presentation/) fungují; výstup bude obsahovat vodotisk.

### Mohu použít dočasnou licenci pro zatěžovací testy bez vodotisku?

Ano. 30denní dočasná licence odstraňuje omezení režimu vyhodnocení a umožňuje testování bez vodotisku.