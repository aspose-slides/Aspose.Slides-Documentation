---
title: Různé formáty souborů a konverze
type: docs
weight: 50
url: /cs/cpp/different-file-formats-and-conversions/
---
## **Microsoft PowerPoint (PPT)**
### **O PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) je formát souboru prezentačních dokumentů, který může být vytvořen, přečten, upraven a zapsán různými verzemi Microsoft PowerPoint. Jedná se o binární formát pro prezentační dokumenty vyvíjený společností Microsoft.
### **PPT v Aspose.Slides for C++**
Aspose.Slides for C++ dokáže číst soubory PPT vytvořené následujícím softwarem.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

Obdobně soubory PPT vytvořené v Aspose.Slides for C++ mohou být čteny výše uvedeným softwarem.
### **Komplexní podpora pro PPT**
Aspose.Slides for C++ poskytuje podporu téměř všech funkcí souvisejících s formátem souboru PPT. Nepokrývá pouze základní a pokročilé funkce různých verzí Microsoft PowerPoint pro manipulaci s PPT dokumenty, ale také některé funkce, které Microsoft PowerPoint ani nepodporuje. Hlavní výhodou použití knihovny Aspose.Slides for C++ API je snadnost práce s těmito funkcemi.

Kromě základních úkolů souvisejících s vytvářením, čtením a zápisem souborů PPT existuje několik funkcí poskytovaných Aspose.Slides for C++, například:

- Import jiných formátů souborů MS Office jako OLE objekty do PPT dokumentů.
- Export PPT dokumentů do formátů PDF, TIFF, XPS.
- Export snímků v PPT dokumentech do formátu SVG.
- Vykreslení snímku do libovolného formátu obrázku podporovaného C++ Framework.
- Nastavení velikosti snímků v PPT dokumentu.
- Správa animací na tvarech.
- Správa prezentací.
- Formátování textu na snímcích.
- Skenování textu v PPT dokumentech.
- Práce s tabulkami na snímcích.
- Automatické kopírování masterů pomocí funkce klonování.

Soubor PPT vygenerovaný pomocí Aspose.Slides for C++ a otevřený v Microsoft PowerPoint
## **PresentationML (PPTX, XML)**
### **O PresentationML**
PresentationML je název pro rodinu XML‑založených formátů prezentačních dokumentů. Office OpenXML (OOXML) je XML‑založený formát představený v aplikacích Microsoft Office 2007. Office OpenXML je kontejnerový formát pro několik specializovaných XML‑založených značkovacích jazyků. PresentationML je značkovací jazyk používaný Microsoft Office PowerPoint 2007 k ukládání svých dokumentů.
### **PresentationML v Aspose.Slides for C++**
Dokumenty OOXML PresentationML jsou soubory PPTX, což jsou zabalené XML balíčky podle specifikace [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for C++ rozsáhle podporuje vytváření, čtení, manipulaci a zápis PresentationML dokumentů. Navíc je Aspose.Slides for C++ schopna exportovat PresentationML dokumenty do různých široce používaných formátů, jako jsou PDF, TIFF a XPS. To je možné, protože Aspose.Slides for C++ bylo navrženo tak, aby komplexně zvládalo prezentační dokumenty a PresentationML v podstatě uchovává vnitřní strukturu dokumentů jako zabalený XML balíček.

Dokument PPTX vygenerovaný pomocí Aspose.Slides for C++ a otevřený v Microsoft PowerPoint

Prohlížení dokumentu PPTX vygenerovaného pomocí Aspose.Slides for C++ v aplikaci Zip
### **PresentationML je otevřený, proč použít Aspose.Slides for C++**
Protože PresentationML je založen na XML, je možné vytvářet aplikace pro zpracování a generování PresentationML dokumentů pomocí XML tříd bez spoléhání se na knihovny třetích stran, jako je Aspose.Slides for C++. Existuje však několik výhod použití Aspose.Slides for C++ oproti XML třídám při práci s PresentationML dokumenty.

Specifikace OOXML má několik tisíc stránek. To znamená, že pro řádnou manipulaci s PresentationML dokumenty musíte strávit hodně času a úsilí pochopením formátu těchto dokumentů. Na druhou stranu, když používáte Aspose.Slides for C++, stačí použít příslušné třídy a jejich metody/vlastnosti pro provádění operací, které by se při použití XML tříd jevily jako složité.

Následující funkce jsou nedostupné při práci s PresentationML dokumenty přes XML třídy:

- Export PPT dokumentů do formátů PDF, TIFF, XPS
- Export snímků v PPT dokumentech do formátu SVG
- Vykreslení snímku do libovolného formátu obrázku podporovaného C++ Framework
- Automatické kopírování masterů ze zdrojových prezentací pomocí funkce klonování
- Aplikace ochrany na tvary

Uveďme příklad PresentationML dokumentu s jedním snímkem a jedním textovým polem obsahujícím text „Hello World“. Pro přečtení textu pomocí XML tříd musíte napsat program, který dokáže parsovat tento jednoduchý text z následujícího fragmentu:

``` cpp

 <?xml version="1.0" encoding="UTF-8" standalone="yes"?>

<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">

  <p:cSld>

    <p:spTree>

      <p:nvGrpSpPr>

        <p:cNvPr id="1" name=""/>

        <p:cNvGrpSpPr/>

        <p:nvPr/>

      </p:nvGrpSpPr>

      <p:grpSpPr>

        <a:xfrm>

          <a:off x="0" y="0"/>

          <a:ext cx="0" cy="0"/>

          <a:chOff x="0" y="0"/>

          <a:chExt cx="0" cy="0"/>

        </a:xfrm></p:grpSpPr><p:sp>

          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>

          <p:cNvSpPr txBox="1"/>

            <p:nvPr/>

          </p:nvSpPr>

          <p:spPr>

            <a:xfrm>

              <a:off x="2819400" y="2590800"/>

              <a:ext cx="1297086" cy="369332"/>

            </a:xfrm>

            <a:prstGeom prst="rect">

              <a:avLst/>

            </a:prstGeom>

            <a:noFill/>

          </p:spPr>

          <p:txBody>

            <a:bodyPr wrap="none" rtlCol="0">

              <a:spAutoFit/>

            </a:bodyPr>

            <a:lstStyle/>

            <a:p>

              <a:r>

                <a:rPr lang="en-US"/>

                <a:t>Hello World

                </a:t>

              </a:r>

              <a:endParaRPr lang="en-US"/>

            </a:p>

          </p:txBody>

        </p:sp>

    </p:spTree>

  </p:cSld>

  <p:clrMapOvr>

    <a:masterClrMapping/>

  </p:clrMapOvr>

</p:sld>

```
## **Převod PPT na PPTX**
### **O převodu**
Aspose.Slides nyní také podporuje převod PPT na PPTX.
### **Funkce podporované při převodu**
Aspose.Slides for C++ poskytuje částečnou podporu pro převod prezentací ve formátu PPT na prezentace ve formátu PPTX. Protože byla podpora tohoto převodu právě zavedena v Aspose.Slides for C++, má zatím omezené možnosti a funguje jen pro jednoduché typy prezentací. Hlavní výhodou, kterou knihovna Aspose.Slides for C++ API nabízí při převodu PPT na PPTX, je snadné použití API k dosažení požadovaného cíle. Pokračujte na this[link]() do sekce ukázek kódu pro další podrobnosti. Následující část jasně ukazuje, které funkce jsou podporovány a které nejsou při převodu PPT na PPTX.

### **Podporované funkce**
Během převodu jsou podporovány následující funkce:

- Převod struktury masterů, rozvržení a snímků
- Převod struktury masterů, rozvržení a snímků
- Převod grafů
- Skupinové tvary
- Převod Auto‑tvarů včetně obdélníků a elips. Může se stát, že Auto‑tvarům budou přiřazeny nesprávné hodnoty úprav
- Tvary s vlastním geometrickým tvarem. Někdy nemusí být převedeny
- Textury a výplň obrázky pro Auto‑tvary. Někdy nemusí být převedeny
- Převod zástupných objektů
- Převod textu v textových rámečcích a držácích textu. Avšak odrážky, zarovnání a tabulátory nejsou plně implementovány
### **Nepodporované funkce**
Během převodu nejsou podporovány následující funkce:

- Snímek s poznámkami, protože čtení poznámek není v PPTX implementováno. Pokud PPT obsahuje poznámky, nelze jej zatím uložit jako PPTX* Převod čar a polylin
- Formáty čar a výplní
- Gradientní styly výplně
- OLE rámy, tabulky, video a audio rámy apod.
- Animace a další vlastnosti prezentace jsou vynechány
  Nové nebo chybějící funkce budou doplněny v nadcházejících verzích Aspose.Slides for C++.

Zdrojová PPT prezentace

Převod PPTX prezentace
## **Portable Document Format (PDF)**
### **O PDF**
[Portable Document Format](https://en.wikipedia.org/wiki/PDF) je souborový formát vytvořený společností Adobe Systems pro výměnu dokumentů mezi různými organizacemi. Účelem tohoto formátu je zajistit, aby obsah dokumentů mohl být zobrazen vizuálně nezávisle na platformě, na které je prohlížen.
### **PDF v Aspose.Slides for C++**
Každý prezentační dokument, který lze načíst v Aspose.Slides for C++, může být převeden na PDF dokument, který může odpovídat [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) nebo [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A) podle vašeho výběru. Aspose.Slides for C++ exportuje prezentační dokumenty do PDF tak, že ve většině případů vypadá exportovaný PDF dokument téměř stejně jako původní prezentace. Aspose řešení podporuje následující funkce prezentačních dokumentů při převodu do PDF:

- Obrázky, textová pole a další tvary
- Text a formátování
- Odstavce a formátování
- Hyperlinky
- Záhlaví a zápatí
- Odrážky
- Tabulky

Můžete exportovat prezentační dokumenty přímo do PDF pomocí komponenty Aspose.Slides for C++. To znamená, že k tomuto účelu nepotřebujete žádnou další knihovnu třetí strany ani komponentu Aspose.Pdf. Dále můžete přizpůsobit export prezentace do PDF pomocí různých možností, jak je vysvětleno v [this topic](/slides/cs/cpp/convert-powerpoint-to-pdf/).

Prezentace převedená do PDF pomocí Aspose.Slides for C++
## **XML Parser Specification (XPS)**
### **O XPS**
[XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) je popisovací jazyk pro stránky a formát pevného dokumentu původně vyvinutý společností Microsoft. Stejně jako PDF, XPS je formát pevného rozvržení dokumentu navržený tak, aby zachoval věrnost dokumentu a poskytoval zařízení nezávislý vzhled dokumentu.
### **XPS v Aspose.Slides for C++**
Každý prezentační dokument, který lze načíst v Aspose.Slides for C++, může být převeden do formátu XPS. Aspose.Slides for C++ používá vysoce věrný engine pro rozvržení a vykreslování stránek k vytvoření výstupu ve formátu XPS s pevným rozvržením. Stojí za zmínku, že Aspose.Slides for C++ přímo generuje XPS bez závislosti na třídách Windows Presentation Foundation (WPF), které jsou součástí C++ Framework 3.5, a tak umožňuje vytvářet XPS dokumenty i na počítačích s verzemi C++ Framework staršími než 3.5. O exportu prezentačních dokumentů do XPS pomocí Aspose.Slides for C++ se můžete dozvědět v [this topic](https://docs.aspose.com/slides/cs/cpp/convert-powerpoint-to-xps/).

Prezentace převedená do XPS pomocí Aspose.Slides for C++