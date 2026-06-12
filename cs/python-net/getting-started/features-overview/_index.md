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
- vykreslování
- tisk
- formátování
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Objevte Aspose.Slides pro Python pomocí .NET: výkonná API pro tvorbu, úpravu, automatizaci a konverzi prezentací PowerPoint a OpenDocument efektivně."
---
## **Podporované platformy**
Platformy, na kterých lze Aspose.Slides pro Python pomocí .NET používat, jsou Windows x64 nebo x86 a široká škála distribucí Linuxu s nainstalovaným Python 3.5 nebo novějším. Existují další požadavky na cílovou platformu Linux:

- runtime knihovny GCC‑6 (nebo novější)
- Závislosti .NET Core Runtime. Instalace samotného .NET Core Runtime NENÍ vyžadována
- Pro Python 3.5‑3.7: Je potřeba verze Python s `pymalloc`. Volba sestavení Pythonu `--with-pymalloc` je ve výchozím nastavení povolena. Obvykle je verze Pythonu s `pymalloc` označena příponou `m` v názvu souboru.
- `libpython` sdílená knihovna Pythonu. Volba sestavení Pythonu `--enable-shared` je ve výchozím nastavení zakázána, některé distribuce Pythonu neobsahují sdílenou knihovnu `libpython`. Pro některé linuxové platformy lze sdílenou knihovnu `libpython` nainstalovat pomocí správce balíčků, například: `sudo apt-get install libpython3.7`. Běžný problém je, že knihovna `libpython` je nainstalována na jiném místě než standardní systémová cesta pro sdílené knihovny. Problém lze vyřešit nastavením alternativních cest ke knihovně při kompilaci Pythonu nebo vytvořením symbolického odkazu na soubor knihovny `libpython` ve standardní systémové cestě pro sdílené knihovny. Typicky má název souboru sdílené knihovny `libpythonX.Ym.so.1.0` pro Python 3.5‑3.7, nebo `libpythonX.Y.so.1.0` pro Python 3.8 a novější (například: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Pokud potřebujete podporu pro další platformy, hledejte produkty „twin brother“ Aspose.Slides pro .NET nebo Aspose.Slides pro Java.

## **Formáty souborů a konverze**
Aspose.Slides pro Python pomocí .NET podporuje většinu formátů dokumentů PowerPoint. Také vám umožňuje exportovat je do populárních formátů, které organizace široce používají a vyměňují mezi sebou. Projděte si tyto podrobnosti:

|**Funkce**|**Popis**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/cs/python-net/ppt-vs-pptx/)|Aspose.Slides pro Python pomocí .NET poskytuje nejrychlejší zpracování tohoto formátu prezentačního dokumentu.|
|[Konverze PPT na PPTX](/slides/cs/python-net/convert-ppt-to-pptx/)|Aspose.Slides pro Python pomocí .NET podporuje konverzi PPT na PPTX.|
|[Portable Document Format (PDF)](/slides/cs/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Můžete exportovat všechny podporované formáty souborů do dokumentů Adobe Portable Document Format (PDF) jedním metodou.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/cs/python-net/convert-powerpoint-to-xps/)|Můžete exportovat všechny podporované formáty souborů do dokumentů XML Parser Specification (XPS) jedním metodou.|
|[Tagged Image File Format (TIFF)](/slides/cs/python-net/convert-powerpoint-to-tiff/)|Můžete exportovat všechny podporované prezentační formáty souborů do Tagged Image File Format (TIFF).|
|[Konverze PPTX na HTML] (https://docs.aspose.com/slides/cs/python-net/convert-powerpoint-to-html/)|Aspose.Slides pro Python pomocí .NET podporuje konverzi PresentationEx do formátu HTML.|

## **Vykreslování a tisk**
Aspose.Slides pro Python pomocí .NET podporuje vysoce věrné vykreslování snímků v prezentačních dokumentech do různých grafických formátů. Projděte si tyto podrobnosti:

|**Funkce**|**Popis**|
| :- | :- |
|.NET Supported Image Formats|S Aspose.Slides pro Python pomocí .NET můžete vykreslovat snímky a obrázky na snímcích do všech .NET podporovaných grafických formátů, jako jsou TIFF, PNG, BMP, JPEG, GIF a metafily.|
|SVG Format|Aspose.Slides pro Python pomocí .NET také poskytuje vestavěné metody, které vám umožní exportovat prezentační snímky do formátu Scalable Vector Graphics (SVG).|
|Presentation Printing|Nejnovější verze Aspose.Slides pro Python pomocí .NET poskytují vestavěné metody tisku s různými možnostmi.|

## **Funkce obsahu**
Aspose.Slides pro Python pomocí .NET vám umožňuje přistupovat, upravovat nebo vytvářet téměř všechny položky nebo obsah prezentačních dokumentů. Projděte si tyto podrobnosti:

|**Funkce**|**Popis**|
| :- | :- |
|Mistrovské snímky|Mistrovské snímky definují rozvržení běžných snímků. Aspose.Slides pro Python pomocí .NET vám umožňuje přistupovat a upravovat mistrovské snímky prezentačních dokumentů.|
|Normální snímky|S Aspose.Slides pro Python pomocí .NET můžete vytvářet nové snímky různých typů; můžete také přistupovat a upravovat existující snímky v prezentacích.|
|Klonování / kopírování snímků|Existují vestavěné metody poskytované Aspose.Slides pro Python pomocí .NET, které vám umožní klonovat nebo kopírovat existující snímky v rámci prezentace. Můžete také použít zkopírované a klonované snímky z jedné prezentace do druhé. Protože snímek dědí rozvržení z mistrovského snímku, vestavěné metody klonování automaticky kopírují mistr při klonování.|
|Správa sekcí snímků|Metody pro organizaci snímků v různých sekcích uvnitř prezentace.|
|Zástupci a textové zástupce|Můžete přistupovat k zástupcům a textovým zástupcům ve snímku. Navíc můžete vytvořit snímek s textovými zástupci od začátku pomocí příslušné metody.|
|Záhlaví a zápatí|Aspose.Slides pro Python pomocí .NET usnadňuje práci se záhlavími/zápatími v snímcích.|
|Poznámky ve snímcích|S Aspose.Slides pro Python pomocí .NET můžete přistupovat a upravovat poznámky přidružené ke snímku a také přidávat nové poznámky.|
|Vyhledání tvaru|Můžete také najít konkrétní tvar ve snímku pomocí alternativního textu přidruženého k tvaru.|
|Pozadí|Aspose.Slides pro Python pomocí .NET vám umožňuje pracovat s pozadími přidruženými k mistrovskému nebo normálnímu snímku v prezentaci.|
|Textová pole|Textová pole lze vytvořit od začátku. Můžete přistupovat k existujícím textovým polím. Můžete také upravovat jejich texty bez ztráty původního formátování textu.|
|Obdélníkové tvary|Můžete vytvářet nebo upravovat obdélníkové tvary s Aspose.Slides pro Python pomocí .NET.|
|Polyliniové tvary|Můžete vytvářet nebo upravovat polyliniové tvary s Aspose.Slides pro Python pomocí .NET.|
|Eliptické tvary|Můžete vytvářet nebo upravovat eliptické tvary s Aspose.Slides pro Python pomocí .NET.|
|Skupinové tvary|Aspose.Slides pro Python pomocí .NET podporuje skupinové tvary.|
|Auto tvary|Aspose.Slides pro Python pomocí .NET podporuje auto tvary.|
|SmartArt|Aspose.Slides pro Python pomocí .NET poskytuje podporu pro SmartArt tvary v MS PowerPoint.|
|Grafy|Aspose.Slides pro Python pomocí .NET poskytuje podporu pro MSO grafy v PowerPoint.|
|Serializace tvarů|Aspose.Slides pro Python pomocí .NET podporuje velké množství tvarů. Když Aspose.Slides pro Python pomocí .NET postrádá podporu pro určitý tvar, můžete použít metodu serializace, pomocí které můžete serializovat tento tvar z existujícího snímku. Tímto způsobem můžete tvar dále používat podle svých požadavků.|
|Rámce obrázků|Můžete spravovat obrázky v rámech obrázků s Aspose.Slides pro Python pomocí .NET.|
|Audio rámečky|Můžete propojit nebo vložit audio soubory v audio rámečcích na snímcích s Aspose.Slides pro Python pomocí .NET.|
|Video rámečky|Můžete pracovat s video soubory ve video rámečcích. Aspose.Slides pro Python pomocí .NET také poskytuje podporu pro propojená a vložená videa.|
|OLE rámec|Můžete spravovat OLE objekty v OLE rámcích s Aspose.Slides pro Python pomocí .NET.|
|Tabulky|Aspose.Slides pro Python pomocí .NET podporuje tabulky ve snímcích.|
|ActiveX Controls|Podpora pro ActiveX ovládací prvky.|
|VBA makra|Podpora pro správu VBA maker v prezentacích.|
|Textový rámec|Můžete přistupovat k textu jakéhokoli tvaru prostřednictvím textového rámce přidruženého k tomuto tvaru.|
|Skenování textu|Můžete skenovat text v prezentaci na úrovni prezentace nebo snímku pomocí vestavěných metod skenování.|
|Animace|Můžete aplikovat animace na tvary.|
|Prezentace|Aspose.Slides pro Python pomocí .NET podporuje prezentace a přechody mezi snímky.|

## **Funkce formátování**
S Aspose.Slides pro Python pomocí .NET můžete formátovat texty a tvary na snímcích v prezentacích. Projděte si tyto podrobnosti:

|**Funkce**|**Popis**|
| :- | :- |
|Formátování textu|<p>V Aspose.Slides pro Python pomocí .NET můžete spravovat texty prostřednictvím textových rámců přidružených k tvarům. Proto můžete formátovat texty pomocí odstavců a částí přidružených k textovým rámcům. Tyto textové prvky lze formátovat pomocí Aspose.Slides pro Python pomocí .NET.</p><p>- Typ písma</p><p>- Velikost písma</p><p>- Barva písma</p><p>- Stíny písma</p><p>- Zarovnání odstavce</p><p>- Odrážky odstavce</p><p>- Orientace odstavce</p>|
|Formátování tvaru|<p>V Aspose.Slides pro Python pomocí .NET je základním prvkem snímku tvar. Tyto prvky tvaru můžete formátovat pomocí Aspose.Slides pro Python pomocí .NET:</p><p>- Pozice</p><p>- Velikost</p><p>- Čára</p><p>- Výplň (včetně vzoru, gradientu, plné barvy)</p><p>- Text</p><p>- Obrázek</p>|

## **FAQ**

**Musím na server/PC nainstalovat Microsoft PowerPoint, aby knihovna fungovala?**

Ne. PowerPoint není vyžadován; Aspose.Slides je samostatný engine pro vytváření, úpravu, konverzi a vykreslování prezentací.

**Jak funguje multithreading? Lze zpracování paralelizovat?**

Je bezpečné zpracovávat různé dokumenty v různých vláknech; stejný [presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) objekt nesmí být používán [více vlákny](/slides/cs/python-net/multithreading/) současně.

**Jsou podporována hesla k souborům a šifrování?**

Ano. [Můžete](/slides/cs/python-net/password-protected-presentation/) otevřít šifrované prezentace, nastavit nebo odebrat heslo pro otevření a zápis a kontrolovat stav ochrany.

**Musím se starat o balíčky fontů v Linux kontejnerech?**

Ano. Doporučuje se nainstalovat běžné balíčky fontů a/nebo explicitně [uvést adresáře fontů](/slides/cs/python-net/custom-font/) ve vaší aplikaci, aby se předešlo neočekávaným substitucím.

**Existují omezení ve zkušební verzi?**

V [evaluation mode](/slides/cs/python-net/licensing/) je do výstupu přidán vodoznak a platí některá omezení; k úplnému testování je k dispozici [30‑denní dočasná licence](https://purchase.aspose.com/temporary-license/).

**Je podporováno importování externích formátů do prezentace (PDF/HTML → PPTX)?**

Ano. Můžete přidat [PDF stránky a HTML obsah](/slides/cs/python-net/import-presentation/) do prezentace, čímž je převodíte na snímky.