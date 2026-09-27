---
title: Vyhodnocení Aspose.Slides
type: docs
weight: 110
url: /cs/cpp/evaluate-aspose-slides/
keywords:
- vyhodnocení Aspose.Slides
- vyhodnocení Aspose.Slides
- evaluační verze
- plná funkčnost
- evaluační vodoznak
- nákup Aspose.Slides
- omezení
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Vyhodnoťte Aspose.Slides pro C++ a prozkoumejte funkce API pro prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) — začněte svou bezplatnou zkušební verzí."
---
## **Aspose.Slides Evaluace**

Můžete si stáhnout Aspose.Slides k vyzkoušení. Vyhodnocovací balíček je stejný jako zakoupený balíček; získá licenci po přidání několika řádků kódu pro aplikaci licence, jak je ukázáno v [Licencování](/slides/cs/cpp/licensing/).

Bez licence poskytuje Aspose.Slides svou plnou funkčnost v evaluačním režimu, ale s dvěma omezeními:

* Přidá jeden evaluační vodoznakový textový rámeček doprostřed každého snímku každé prezentace, kterou uloží. Otevření prezentace nepřidá vodoznak, ale vodoznak uložený dříve je načten jako tvar na snímku. Takže pokud otevřete prezentaci uloženou v evaluačním režimu a uložíte ji znovu, každý snímek bude mít dva vodoznaky.
* Text, který váš kód načte z prezentace, je zkrácen na několik prvních znaků, následovaný upozorněním na omezení evaluační verze. Toto se týká každého snímku i textu, který váš kód právě nastavil. Text, který váš kód zapíše, je uložen celý.

{{% alert color="info" title="Note" %}}

Pokud chcete testovat Aspose.Slides bez omezení evaluační verze, můžete také požádat o 30denní dočasnou licenci. Viz [How to get a Temporary License?](https://purchase.aspose.com/temporary-license)

{{% /alert %}}

## **Často kladené otázky**

### Můžu testovat více prezentací paralelně napříč různými vlákny v evaluačním režimu?

Ano. Můžete zpracovávat různé dokumenty paralelně; neměli byste sdílet stejný objekt prezentace [napříč vlákny](/slides/cs/cpp/multithreading/). Evaluační režim to neovlivní.

### Musím mít nainstalovaný Microsoft PowerPoint k vyzkoušení knihovny na serveru nebo v CI?

Ne. Aspose.Slides je samostatný engine a nevyžaduje instalaci PowerPointu ani pro vyhodnocení, ani pro produkci.

### Můžu plně testovat konverzi PPT/PPTX do PDF a obrázků v evaluačním režimu?

Ano. [konvertory](/slides/cs/cpp/convert-presentation/) fungují; výstup bude obsahovat vodoznak.

### Můžu použít dočasnou licenci pro zatěžovací testy bez vodoznaku?

Ano. 30denní dočasná licence odstraňuje omezení evaluačního režimu a umožňuje testování bez vodoznaku.