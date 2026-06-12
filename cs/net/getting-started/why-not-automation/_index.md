---
title: Proč neautomatizovat
type: docs
weight: 40
url: /cs/net/why-not-automation/
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
- .NET
- C#
- Aspose.Slides
description: "Objevte, proč je automatizace Office riziková pro servery a služby, a podívejte se, jak Aspose.Slides nabízí bezpečnější a rychlejší zpracování prezentací pro PowerPoint a OpenDocument."
---
## **Úvod**

Existuje několik důvodů, proč jsou komponenty Aspose lepší alternativou k automatizaci. Mezi klíčové důvody patří:

- Bezpečnost
- Stabilita
- Škálovatelnost/Rychlost
- Cena
- Funkce

Níže je podrobnější vysvětlení každého klíčového bodu.

## **Důležité otázky**

Existují dvě otázky, které u Aspose často slyšíme:

- Vyžadují vaše produkty, aby byl nainstalován Microsoft Office, aby mohly běžet?

Krátká, jednoduchá odpověď je **NE**.

Komponenty Aspose jsou zcela nezávislé a nejsou spojeny s, autorizovány, sponzorovány ani jinak schváleny společností Microsoft Corporation.

- Proč bychom měli používat produkty Aspose místo automatizace Microsoft Office?

Nejprve existuje mnoho [výhod, které získáte při použití Aspose.Slides](/slides/cs/net/product-overview/).

Druhé, Microsoft samotná silně **odrazuje od** používání Office Automation v softwarových řešeních.

## **Bezpečnost**
Následuje přímý citát z článku Microsoft: 

> "Office aplikace nikdy nebyly určeny pro serverové použití, a proto neberou v úvahu bezpečnostní problémy, kterým čelí distribuované komponenty. Office neautentizuje příchozí požadavky a nechrání vás před neúmyslným spouštěním maker nebo před spuštěním dalšího serveru, který by mohl spouštět makra, z vašeho serverového kódu. Neotevírejte soubory nahrané na server od anonymního webu! Na základě posledních nastavení zabezpečení může server spouštět makra v kontextu Administrátora nebo Systému s plnými oprávněními a ohrozit vaši síť! Navíc Office používá mnoho klientských komponent (jako Simple MAPI, WinInet, MSDAIPP), které mohou ukládat informace o autentizaci klienta do cache za účelem urychlení zpracování. Pokud je Office automatizován na serveru, může jedna instance obsluhovat více než jednoho klienta a protože informace o autentizaci byly pro tuto relaci uloženy do cache, je možné, že jeden klient může použít uložené přihlašovací údaje jiného klienta a získat tak neoprávněná přístupová oprávnění napodobováním jiných uživatelů."

Produkty Aspose jsou velmi **bezpečné**. Komponenty Aspose běží ve stejném uživatelském kontextu jako všechny aplikace ASP.NET (pod uživatelem ASPNET). Proto komponenty Aspose **nepředstavují** bezpečnostní riziko. Také nevyužívají kritické systémové prostředky. Navíc když komponenta Aspose otevře dokument, makra se nespouštějí automaticky. Komponenty Aspose byly vytvořeny tak, aby vývojářům umožnily vytvářet, manipulovat a ukládat soubory Office.

{{% alert color="primary" %}} 

Žádná z rizik spojených s balíčkem Microsoft Office se na komponenty Aspose nevztahuje.

{{% /alert %}} 

## **Stabilita**
Tento text je přímý citát z dříve zmíněného článku Microsoft: 

> "Office 2000, Office XP a Office 2003 používají technologii Microsoft Windows Installer (MSI), aby usnadnily instalaci a opravu pro koncového uživatele. MSI zavádí koncept „instalace při prvním použití“, který umožňuje dynamicky instalovat nebo konfigurovat funkce za běhu (pro systém, nebo častěji pro konkrétního uživatele). V serverovém prostředí to zpomaluje výkon a zvyšuje pravděpodobnost, že se objeví dialogové okno žádající uživatele o schválení instalace nebo poskytnutí vhodného instalačního disku. Přestože je to navrženo k zvýšení odolnosti Office jako koncového produktu, implementace MSI v Office je v serverovém prostředí kontraproduktivní. Navíc stabilita Office obecně nemůže být zajištěna, když je provozována na serveru, protože nebyla navržena ani testována pro takové použití. Použití Office jako servisní komponenty na síťovém serveru může snížit stabilitu tohoto stroje a následně celé vaší sítě. Pokud plánujete automatizovat Office na serveru, snažte se izolovat program na dedikovaný počítač, který nemůže ovlivnit kritické funkce a který lze podle potřeby restartovat."

Protože jsou komponenty Aspose zabaleny do jediného DLL souboru, jejich uživatelé nikdy nemusí instalovat další části či součásti, aby fungovaly. Komponenty Aspose jsou využívány pouze .NET aplikacemi a neexistuje žádná část kódu komponenty navržená k čekání na lidskou reakci.

{{% alert color="primary" %}} 

Komponenty Aspose byly důkladně testovány a potvrzeny jako velmi stabilní. Komponenty Aspose jsou používány [společnostmi](http://www.aspose.com/Corporate/Aspose/Customerlist.html) jako **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** a mnoha dalšími předními organizacemi v různých odvětvích.

{{% /alert %}} 

## **Škálovatelnost/Rychlost**
Následuje přímý citát z článku Microsoft: 

> "Komponenty na straně serveru musí být vysoce reentratní, víceníťové COM komponenty s minimální zátěží a vysokou propustností pro více klientů. Office aplikace jsou v téměř každém ohledu přesným opakem. Jedná se o nerentratní, na STA založené automatizační servery, které jsou navrženy tak, aby poskytovaly rozmanité, ale náročné funkce pro jednoho klienta. Nabízejí jen omezenou škálovatelnost jako serverové řešení a mají pevně stanovené limity důležitých elementů, jako je paměť, které nelze změnit konfigurací. Navíc používají globální zdroje (jako paměťově mapované soubory, globální doplňky nebo šablony a sdílené automatizační servery), což může omezit počet instancí, které mohou běžet současně, a vést k podmínkám zacyklení, pokud jsou konfigurovány v prostředí s více klienty. Vývojáři, kteří plánují spustit více než jednu instanci jakékoli Office aplikace současně, musí zvážit poolování nebo serializaci přístupu k Office aplikaci, aby se vyhnuli potenciálním deadlockům nebo poškození dat."

Komponenty Aspose jsou neuvěřitelně škálovatelné a bleskově rychlé. Office aplikace nebyly navrženy pro souběžné používání stovkami nebo tisíci uživatelů, ale komponenty Aspose jsou právě pro to vytvořeny. Naše komponenty jsou pravým řešením .NET.

{{% alert color="primary" %}} 

Výkon komponent Aspose je bezchybně na jednom serveru (napájejícím jednu aplikaci) nebo na vyváženém webovém formuláři (napájejícím podnikovou aplikaci).

{{% /alert %}} 

## **Cena**
Když aplikace využívá Microsoft Office Automation, je nutné zakoupit kopii Microsoft Office pro každý počítač, na kterém aplikace běží. Existuje mnoho případů, kdy aplikace potřebuje vytvořit nebo manipulovat s office souborem, ale proces nevyžaduje Microsoft Office.

{{% alert color="primary" %}} 

Aspose poskytuje velmi [nákladově efektivní](https://purchase.aspose.com/) a bezroyaltovou licenci pro redistribuci, která umožňuje nasazení neomezenému počtu uživatelů bez starostí o licencování.

{{% /alert %}} 

Při tvorbě webových aplikací je důležité si uvědomit, že komponenty Microsoft Office Automation nejsou ceněny ani licencovány pro serverová řešení. Proto neexistuje žádné vhodné licenční řešení pro nasazení webových aplikací využívajících komponenty Microsoft Office. Aspose naopak poskytuje velmi [nákladově efektivní](https://purchase.aspose.com/) řešení i pro serverové aplikace.

## **Funkce**
Komponenty Aspose poskytují vše potřebné pro správu Office souborů a ještě mnohem víc. Navrhli jsme je podle naší filozofie pomáhat vývojářům dosáhnout co největších výsledků s co nejmenším úsilím.

{{% alert color="primary" %}} 

Na rozdíl od Office Automation poskytují komponenty Aspose mnoho výkonných a čas šetřících funkcí.

{{% /alert %}} 

Například [Aspose.Cells](https://products.aspose.com/cells/net/) dává vývojářům možnost importovat data z **DataTable** nebo **DataView** přímo do Excel souboru. [Aspose.Words](https://products.aspose.com/words/net/) poskytuje podobnou funkci, která umožňuje vývojářům naplnit Word (tedy Mail Merge) dokument přímo z libovolného .NET datového objektu. [Každá komponenta](https://products.aspose.com/total/net/) v rodině Aspose nabízí svůj vlastní soubor unikátních a výkonných funkcí.

Nejlepší částí zakoupení komponenty Aspose je přístup k našim vývojovým týmům. Například pokud používáte objekty Office Automation a potřebujete určité funkce, šance, že budou tyto funkce přidány, jsou velmi, velmi nízké. S komponentami Aspose je to však jiné.

{{% alert color="primary" %}} 

Naše vývojové týmy chápou, že pokud existuje funkce, kterou vaše společnost potřebuje, existuje dobrá pravděpodobnost, že ji potřebují i jiné firmy. I když víme, že nemůžeme implementovat každou požadovanou funkci, usilujeme o přidání co nejvíce funkcí na základě zpětné vazby od našich zákazníků.

{{% /alert %}} 

Naše týmy jsou vždy otevřené a flexibilní při poskytování pomoci – a to je důvod, proč komponenty Aspose vyrostly a jsou tak výkonné, jaké jsou dnes.

## **Závěr**
{{% alert color="primary" %}} 

Zatímco tento článek pokryl některé klíčové body, proč jsou komponenty Aspose lepší volbou než Office Automation, musíte pochopit, že existuje mnoho, mnoho dalších výhod. Představili jsme jen některé z hlavních výhod.

Kromě toho všechny produkty a komponenty Aspose nabízejí bezrizikovou, bez závazků [Evaluační verzi](https://downloads.aspose.com/slides/cs/net). Doporučujeme využít evaluaci a zjistit, co může Aspose udělat pro vaše aplikace nebo podnik.

{{% /alert %}}