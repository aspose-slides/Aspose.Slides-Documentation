---
title: Přehled funkcí
type: docs
weight: 20
url: /cs/python-net/features-overview/
keywords:
- funkce
- podporované platformy
- formát souboru
- konverze
- renderování
- formátování
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Objevte Aspose.Slides for Python via .NET: výkonný API pro vytváření, úpravu, automatizaci a efektivní konverzi prezentací PowerPoint a OpenDocument."
---
## **Podporované platformy**
Platformy Aspose.Slides for Python via .NET lze použít na Windows x64 nebo x86 a na široké škále distribucí Linuxu s nainstalovaným Pythonem 3.5 nebo novějším. Pro cílovou platformu Linux existují další požadavky:
- runtime knihovny GCC-6 (nebo novější)
- Závislosti .NET Core Runtime. Instalace samotného .NET Core Runtime NENÍ vyžadována
- Pro Python 3.5‑3.7: je potřeba build Pythonu s `pymalloc`. Volba buildu Pythonu `--with-pymalloc` je ve výchozím nastavení povolena. Obvykle je build Pythonu s `pymalloc` označen příponou `m` v názvu souboru.
- Sdílená knihovna Pythonu `libpython`. Volba buildu Pythonu `--enable-shared` je ve výchozím nastavení zakázána, některé distribuce Pythonu neobsahují sdílenou knihovnu `libpython`. Pro některé linuxové platformy lze sdílenou knihovnu `libpython` nainstalovat pomocí správce balíčků, například: `sudo apt-get install libpython3.7`. Častý problém je, že knihovna `libpython` je nainstalována na jiném místě než standardní systémová cesta pro sdílené knihovny. Problém lze vyřešit nastavením alternativních cest ke knihovně pomocí volby při sestavování Pythonu, nebo vytvořením symbolického odkazu na soubor knihovny `libpython` v standardním systémovém umístění pro sdílené knihovny. Obvykle se název souboru sdílené knihovny `libpython` jmenuje `libpythonX.Ym.so.1.0` pro Python 3.5‑3.7, nebo `libpythonX.Y.so.1.0` pro Python 3.8 a novější (například: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Pokud potřebujete podporu pro více platforem, podívejte se na „sourozenecké“ produkty Aspose.Slides for .NET nebo Aspose.Slides for Java.


## **Formáty souborů a konverze**
Aspose.Slides for Python via .NET podporuje většinu formátů PowerPoint dokumentů. Umožňuje je také exportovat do populárních formátů, které organizace široce používají a mezi sebou vyměňují. Prohlédněte si podrobnosti:

|**Funkce**|**Popis**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/cs/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET poskytuje nejrychlejší zpracování tohoto formátu prezentačních dokumentů.|
|[Konverze PPT na PPTX](/slides/cs/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET podporuje konverzi PPT na PPTX.|
|[Portable Document Format (PDF)](/slides/cs/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Můžete exportovat všechny podporované formáty souborů do dokumentů Adobe Portable Document Format (PDF) pomocí jediné metody.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/cs/python-net/convert-powerpoint-to-xps/)|Můžete exportovat všechny podporované formáty souborů do dokumentů XML Parser Specification (XPS) pomocí jediné metody.|
|[Tagged Image File Format (TIFF)](/slides/cs/python-net/convert-powerpoint-to-tiff/)|Můžete exportovat všechny podporované formáty prezentačních souborů do Tagged Image File Format (TIFF).|
|[Konverze PPTX do HTML](https://docs.aspose.com/slides/cs/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET podporuje konverzi PresentationEx do formátu HTML.|


## **Renderování prezentací**
Aspose.Slides for Python via .NET podporuje vysoce věrné renderování snímků v prezentačních dokumentech do různých grafických formátů. Prohlédněte si podrobnosti:

|**Funkce**|**Popis**|
| :- | :- |
|Podporované formáty obrázků v .NET|S Aspose.Slides for Python via .NET můžete renderovat snímky prezentace a obrázky na snímcích do všech grafických formátů podporovaných .NET, jako jsou TIFF, PNG, BMP, JPEG, GIF a metafily.|
|Formát SVG|Aspose.Slides for Python via .NET také poskytuje vestavěné metody, které umožňují exportovat snímky prezentace do formátů Scalable Vector Graphics (SVG).|


## **Funkce obsahu**
Aspose.Slides for Python via .NET umožňuje přístup, úpravu nebo vytvoření téměř všech položek či obsahu prezentačních dokumentů. Prohlédněte si podrobnosti:

|**Funkce**|**Popis**|
| :- | :- |
|Hlavní snímky|Hlavní snímky určují rozvržení obyčejných snímků. Aspose.Slides for Python via .NET vám umožňuje přístup a úpravu hlavních snímků prezentačních dokumentů|
|Obyčejné snímky|S Aspose.Slides for Python via .NET můžete vytvářet nové snímky různých typů; také můžete přistupovat k existujícím snímkům v prezentacích a upravovat je|
|Klónování / Kopírování snímků|Aspose.Slides for Python via .NET poskytuje vestavěné metody, které vám umožní klonovat nebo kopírovat existující snímky v rámci prezentace. Také můžete použít zkopírované a klonované snímky z jedné prezentace do druhé. Protože snímek dědí rozvržení z hlavního snímku, vestavěné metody klonování automaticky kopírují hlavní snímek při klonování|
|Správa sekcí snímků|Metody pro uspořádání snímků do různých sekcí v rámci prezentace|
|Zástupci pro umístění a textové zástupce|Můžete přistupovat k zástupcům umístění a textovým zástupcům na snímku. Navíc můžete vytvořit snímek s textovými zástupci od nuly pomocí příslušné metody|
|Záhlaví a zápatí|Aspose.Slides for Python via .NET usnadňuje práci se záhlavími a zápatími na snímcích|
|Poznámky na snímcích|S Aspose.Slides for Python via .NET můžete přistupovat k poznámkám spojeným se snímkem, upravovat je i přidávat nové poznámky|
|Vyhledání tvaru|Můžete také najít konkrétní tvar na snímku pomocí alternativního textu spojeného s tvarem|
|Pozadí|Aspose.Slides for Python via .NET vám umožňuje pracovat s pozadími spojenými s hlavním nebo obyčejným snímkem v prezentaci|
|Textová pole|Textová pole lze vytvořit od nuly. Můžete přistupovat k existujícím textovým polím. Také můžete upravovat jejich texty bez ztráty původního formátování|
|Obdélníkové tvary|S Aspose.Slides for Python via .NET můžete vytvářet nebo upravovat obdélníkové tvary|
|Polyliniové tvary|S Aspose.Slides for Python via .NET můžete vytvářet nebo upravovat polyliniové tvary|
|Eliptické tvary|S Aspose.Slides for Python via .NET můžete vytvářet nebo upravovat eliptické tvary|
|Seskupené tvary|Aspose.Slides for Python via .NET podporuje seskupené tvary|
|Auto tvary|Aspose.Slides for Python via .NET podporuje auto tvary|
|SmartArt|Aspose.Slides for Python via .NET poskytuje podporu pro SmartArt tvary v MS PowerPoint|
|Grafy|Aspose.Slides for Python via .NET poskytuje podporu pro MSO grafy v PowerPointu|
|Serializace tvarů|Aspose.Slides for Python via .NET podporuje velké množství tvarů. Když Aspose.Slides for Python via .NET postrádá podporu pro určitý tvar, můžete použít metodu serializace, pomocí které můžete daný tvar serializovat z existujícího snímku. Tímto způsobem můžete tvar dále využít podle svých potřeb|
|Obrázkové rámy|Můžete spravovat obrázky v obrázkových rámech pomocí Aspose.Slides for Python via .NET|
|Audio rámy|Můžete propojit nebo vložit audio soubory do audio rámců na snímcích pomocí Aspose.Slides for Python via .NET|
|Video rámy|Můžete pracovat se soubory videa ve video rámech. Aspose.Slides for Python via .NET také poskytuje podporu pro propojená a vložená videa|
|OLE rámce|Můžete spravovat OLE objekty v OLE rámcích pomocí Aspose.Slides for Python via .NET|
|Tabulky|Aspose.Slides for Python via .NET podporuje tabulky na snímcích|
|ActiveX ovládací prvky|Podpora pro ActiveX ovládací prvky|
|VBA makra|Podpora pro správu VBA maker v prezentacích|
|Textový rámec|Můžete přistupovat k textu v jakémkoli tvaru prostřednictvím textového rámce spojeného s tímto tvarem|
|Skenování textu|Můžete skenovat text v prezentaci na úrovni celé prezentace nebo jednotlivých snímků pomocí vestavěných skenovacích metod|
|Animace|Můžete aplikovat animace na tvary|
|Promítání snímků|Aspose.Slides for Python via .NET podporuje promítání snímků a přechody mezi snímky|


## **Formátovací funkce**
S Aspose.Slides for Python via .NET můžete formátovat texty a tvary na snímcích v prezentacích. Prohlédněte si podrobnosti:

|**Funkce**|**Popis**|
| :- | :- |
|Formátování textu|<p>V Aspose.Slides for Python via .NET můžete spravovat texty prostřednictvím textových rámců spojených s tvary. Tím můžete formátovat texty pomocí odstavců a částí spojených s textovými rámci. Tyto textové elementy lze formátovat pomocí Aspose.Slides for Python via .NET.</p><p>- Typ písma</p><p>- Velikost písma</p><p>- Barva písma</p><p>- Stíny písma</p><p>- Zarovnání odstavce</p><p>- Odrážky odstavce</p><p>- Orientace odstavce</p>|
|Formátování tvarů|<p>V Aspose.Slides for Python via .NET je základním prvkem snímku tvar. Tyto prvky tvarů můžete formátovat pomocí Aspose.Slides for Python via .NET:</p><p>- Pozice</p><p>- Velikost</p><p>- Čára</p><p>- Výplň (včetně vzoru, gradientu, jedné barvy)</p><p>- Text</p><p>- Obrázek</p>|


## **FAQ**

### Musím nainstalovat Microsoft PowerPoint na server/PC, aby knihovna fungovala?

Ne. PowerPoint není vyžadován; Aspose.Slides je samostatný engine pro vytváření, úpravu, konverzi a renderování prezentací.

### Jak funguje vícevláknové zpracování? Může být zpracování paralelizováno?

Je bezpečné zpracovávat různé dokumenty v různých vláknech; stejný [prezentaci](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) objekt nesmí být používán simultánně více [vlákeny](/slides/cs/python-net/multithreading/).

### Jsou podporována hesla a šifrování souborů?

Ano. [Můžete](/slides/cs/python-net/password-protected-presentation/) otevřít šifrované prezentace, nastavit nebo odstranit otevření a zápisové heslo a zkontrolovat stav ochrany.

### Musím se starat o fontové balíčky v Linuxových kontejnerech?

Ano. Doporučuje se nainstalovat běžné fontové balíčky a/nebo explicitně [specifikovat adresáře s fonty](/slides/cs/python-net/custom-font/) ve vaší aplikaci, aby se předešlo neočekávaným náhradám.

### Existují omezení ve zkušební verzi?

V [zkušebním režimu](/slides/cs/python-net/licensing/) je do výstupu přidáno vodoznak a platí určitá omezení; [30denní dočasná licence](https://purchase.aspose.com/temporary-license/) je k dispozici pro plné testování funkcí.

### Je podporováno importování externích formátů do prezentace (PDF/HTML → PPTX)?

Ano. Můžete přidat [PDF stránky a HTML obsah](/slides/cs/python-net/import-presentation/) do prezentace a převést je na snímky.