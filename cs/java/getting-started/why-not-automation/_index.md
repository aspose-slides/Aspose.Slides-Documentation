---
title: Proč ne automatizace
type: docs
weight: 50
url: /cs/java/why-not-automation/
keywords:
- automatizace
- Microsoft Office
- porovnání
- bezpečnost
- stabilita
- škálovatelnost
- funkce
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte, proč je automatizace Office riskantní pro servery a služby, a podívejte se, jak Aspose.Slides nabízí bezpečnější a rychlejší zpracování prezentací pro PowerPoint a OpenDocument."
---
## **Úvod**

Existuje několik důvodů, proč jsou komponenty Aspose lepší alternativou k automatizaci. Některé z hlavních důvodů jsou:

- Bezpečnost
- Stabilita
- Škálovatelnost/Rychlost
- Cena
- Funkce

Níže je podrobnější vysvětlení každého klíčového bodu.

## **Důležité otázky**

Existují dvě otázky, které často slyšíme v Aspose:

- Vyžadují vaše produkty instalaci Microsoft Office, aby mohly běžet?

Krátká, jednoduchá odpověď je **NE**.

Komponenty Aspose jsou zcela nezávislé a nejsou spojeny, autorizovány, sponzorovány ani jinak schváleny společností Microsoft Corporation.

- Proč bychom měli používat produkty Aspose místo Microsoft Office Automation?

Nejprve existuje mnoho [výhod, které získáte při použití Aspose.Slides](/slides/cs/java/product-overview/).

Druhá věc, Microsoft samotný silně **nedoporučuje** používat Office Automation v softwarových řešeních.

## **Bezpečnost**

Následující citace je přímý výňatek z Microsoft článku:

*"Aplikační programy Office nikdy nebyly navrženy pro použití na straně serveru a proto neberou v úvahu bezpečnostní problémy, kterým čelí distribuované komponenty. Office neautentizuje příchozí požadavky a nechrání vás před neúmyslným spuštěním maker nebo spuštěním jiného serveru, který by mohl makra spouštět, z vašeho serverového kódu. Neotevírejte soubory nahrané na server z anonymního webu! Na základě posledních nastavení zabezpečení může server spouštět makra pod kontextem Administrátora nebo Systému s plnými oprávněními a ohrozit vaši síť! Navíc Office používá mnoho komponent na straně klienta (jako Simple MAPI, WinInet, MSDAIPP), které mohou ke zrychlení zpracování kešovat informace o autentizaci klienta. Pokud je Office automatizován na straně serveru, může jedna instance obsluhovat více než jednoho klienta a protože autentizační informace byly pro tuto relaci kešovány, je možné, že jeden klient může použít kešované přihlašovací údaje jiného klienta a tím získat nepovolený přístup tím, že bude impersonovat jiné uživatele."*

Produkty Aspose jsou velmi bezpečné. Komponenty Aspose nepředstavují potenciální riziko pro životně důležité systémové prostředky. Navíc při otevření dokumentu komponentou Aspose se makra automaticky nespouštějí. Komponenty Aspose byly vytvořeny s cílem umožnit vývojářům vytvářet, manipulovat a ukládat soubory Office. Žádná z rizik spojených s balíčkem Microsoft Office není inherentní komponentám Aspose. 

## **Stabilita**
Následující citace je přímý výňatek z Microsoft článku:

*"Office 2000, Office XP a Office 2003 používají technologii Microsoft Windows Installer (MSI), aby usnadnily instalaci a samoopravu pro koncového uživatele. MSI zavádí koncept „instalace při prvním použití“, který umožňuje dynamicky instalovat nebo konfigurovat funkce během běhu (pro systém, nebo častěji pro konkrétního uživatele). V prostředí na straně serveru to jak zpomaluje výkon, tak zvyšuje pravděpodobnost, že se objeví dialogové okno s požadavkem na schválení instalace nebo poskytnutí odpovídajícího instalačního disku. Přestože je to navrženo tak, aby zvyšovalo odolnost Office jako produktu pro koncové uživatele, implementace MSI schopností v Office je v serverovém prostředí kontraproduktivní. Dále nelze obecně zaručit stabilitu Office při spuštění na serveru, protože nebyla navržena ani testována pro tento typ použití. Použití Office jako servisní komponenty na síťovém serveru může snížit stabilitu tohoto stroje a tím i celé vaší sítě. Pokud plánujete automatizovat Office na serveru, pokuste se izolovat program na dedikovaný počítač, který nemůže ovlivnit kritické funkce a který lze potřebně restartovat."*

Komponenty Aspose byly důkladně testovány a jsou mimořádně stabilní. Komponenty Aspose používají [společnosti](https://about.aspose.com/customers) jako **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** a mnoho dalších. 

## **Škálovatelnost/Rychlost**
Následující citace je přímý výňatek z Microsoft článku:

*"Komponenty na straně serveru musí být vysoce reentrance, vícevláknové COM komponenty s minimálním režijním zatížením a vysokou propustností pro více klientů. Aplikační programy Office jsou ve všech ohledech přesným opakem. Jsou nereentrantní, na bázi STA, servery Automation, které jsou navrženy tak, aby poskytovaly rozmanitou, ale náročnou funkčnost pro jediného klienta. Nabízejí jen malou škálovatelnost jako serverové řešení a mají pevná omezení důležitých prvků, jako je paměť, kterou nelze změnit konfigurací. Důležitější je, že používají globální zdroje (jako paměťově mapované soubory, globální doplňky nebo šablony a sdílené servery Automation), což může omezit počet instancí, které mohou běžet souběžně, a vést k závodním podmínkám, pokud jsou nakonfigurovány v prostředí s více klienty. Vývojáři, kteří plánují spouštět více než jednu instanci jakékoliv aplikace Office současně, by měli zvážit ***Pooling*** nebo ***Serializing Access*** k aplikaci Office, aby se vyhnuli potenciálním ***Deadlocks*** nebo ***Data Corruption***.* 

Komponenty Aspose jsou vysoce škálovatelné a bleskově rychlé. Aplikační programy Office nebyly navrženy pro současné používání stovkami nebo tisíci uživatelů. Komponenty Aspose jsou však navrženy právě pro to. Naše komponenty fungují bezchybně jak na jediném serveru, napájejí jedinou aplikaci, tak i v rovnovážně zatíženém webovém formuláři napájejícím podnikové aplikace.

## **Cena**
Při použití Microsoft Office Automation je nutné zakoupit kopii Microsoft Office pro každý počítač, na kterém aplikace běží. Často se však stává, že aplikace potřebuje vytvořit nebo upravit soubor Office, aniž by uživatel musel mít Microsoft Office nainstalován. Aspose nabízí velmi [nákladově efektivní](https://purchase.aspose.com/) a bezroyalty redistribuční licenci, která umožní nasazení neomezenému počtu uživatelů bez starostí o licencování.

Při tvorbě webových aplikací je důležité vědět, že komponenty Microsoft Office Automation nejsou cenově ani licenčně určeny pro serverová řešení; neexistuje tedy vhodné licenční řešení pro nasazení webových aplikací využívajících komponenty Microsoft Office. Aspose také nabízí velmi nákladově efektivní řešení pro serverové aplikace.

## **Funkce**
Komponenty Aspose poskytují vše potřebné pro správu souborů Office a ještě mnohem víc. Jsou navrženy s filosofií umožnit vývojářům dosáhnout největších výsledků s co nejmenším úsilím. Na rozdíl od Office Automation poskytují komponenty Aspose mnoho výkonných a čas šetřících funkcí. Například [Aspose.Cells](https://products.aspose.com/cells/java/) nabízí vývojářům možnost importovat data z **DataTable** nebo **DataView** přímo do Excel souboru. [Aspose.Words](https://products.aspose.com/words/java/) nabízí podobnou funkci, která umožňuje naplnit Word (tedy Mail Merge) dokument. [Každá komponenta](https://products.aspose.com/total/java/) v rodině Aspose nabízí svůj vlastní soubor jedinečných a výkonných funkcí.

Největší výhodou zakoupení komponenty Aspose (nebo sad komponent jako [Aspose.Total](https://products.aspose.com/total/java/)) je přístup k našim vývojovým týmům. Naše vývojové týmy si uvědomují, že pokud vaše společnost potřebuje určitou funkci, pravděpodobně ji potřebují i další společnosti. Ačkoliv ne každá žádost o funkci může být přidána, naše týmy se snaží být otevřené a flexibilní při poskytování pomoci. Toto myšlení pomohlo komponentám Aspose stát se tak výkonnými, jaké jsou. Pokud potřebujete další funkce z objektů Office Automation, šance, že budou přidány, jsou velmi, velmi nízké. 

## **Závěr**
{{% alert color="info" %}} 

Ačkoliv tento článek pokrývá mnoho klíčových bodů, proč jsou komponenty Aspose lepší volbou než Office Automation, existuje mnohem více. Tento článek se zaměřuje pouze na nejdůležitější body. Všechny různé komponenty Aspose nabízejí bezrizikovou, bez závazku [Evaluační verzi](https://downloads.aspose.com/slides/cs/java). Doporučujeme využít tuto evaluační verzi, abyste lépe viděli, co Aspose může udělat pro vaše aplikace. 

{{% /alert %}}