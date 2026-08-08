---
title: Proč neautomatizace
type: docs
weight: 50
url: /cs/cpp/why-not-automation/
keywords:
- automatizace
- Microsoft Office
- porovnání
- zabezpečení
- stabilita
- škálovatelnost
- funkce
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Objevte, proč je automatizace Office riskantní pro servery a služby, a zjistěte, jak Aspose.Slides nabízí bezpečnější a rychlejší zpracování prezentací pro PowerPoint a OpenDocument."
---
## **Úvod**

Existuje několik důvodů, proč jsou komponenty Aspose lepší alternativou k automatizaci. Mezi hlavní důvody patří:

- Zabezpečení
- Stabilita
- Škálovatelnost/Rychlost
- Cena
- Funkce

Níže je podrobnější vysvětlení každého klíčového bodu.

## **Důležité otázky**
- Proč jsou komponenty Aspose mnohem lepší volbou než Microsoft Office Automation?

Existují dvě otázky, které zde v Aspose slyšíme nejčastěji :

- Vyžadují vaše produkty, aby byl nainstalován Microsoft Office, aby mohly běžet?

Jednoduchá odpověď je **NE**. Aspose a komponenty Aspose jsou naprosto nezávislé a nejsou spojeny s Microsoft Corporation, ani nejsou odsouhlaseny, sponzorovány nebo jinak schváleny touto společností.

- Proč bychom měli používat produkty Aspose místo využívání Microsoft Office Automation?

Nejkratší odpověď, kterou můžeme podat, je, že existuje mnoho důvodů, přičemž největším je, že *Microsoft sám důrazně nedoporučuje Office Automation v softwarových řešeních: [Microsoft Article*

## **Zabezpečení**
Následující citát je přímou citací výše uvedeného Microsoft Article:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Produkty Aspose jsou velmi bezpečné. Proto komponenty Aspose nepředstavují potenciální riziko pro kritické systémové zdroje. Navíc při otevření dokumentu komponentou Aspose se makra automaticky nespouští. Komponenty Aspose byly vytvořeny s cílem umožnit vývojářům vytvářet, upravovat a ukládat soubory Office. Žádné z rizik spojených s balíčkem Microsoft Office nepatří mezi inherentní rizika komponent Aspose.

## **Stabilita**
Následující citát je přímou citací výše uvedeného Microsoft Article:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Protože komponenty Aspose jsou baleny do jediné knihovny DLL, nikdy nebudete muset instalovat žádné další části, aby fungovaly. Komponenty Aspose jsou používány pouze v C++ aplikacích a neexistuje žádná část kódu, která by čekala na lidskou odezvu. Komponenty Aspose byly důkladně otestovány a jsou extrémně stabilní. Komponenty Aspose využívají [Companies](https://about.aspose.com/customers) jako **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** a mnoho dalších.

## **Škálovatelnost/Rychlost**
Následující citát je přímou citací výše uvedeného Microsoft Article:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Komponenty Aspose jsou vysoce škálovatelné a extrémně rychlé. Office aplikace nebyly navrženy pro souběžné použití stovkami či tisíci uživatelů. Naopak komponenty Aspose jsou k tomu vytvořeny. Naše komponenty jsou skutečným C++ řešením a fungují bezchybně jak na jediném serveru, tak i v prostředí load‑balanced Web Form pro podnikové aplikace.

## **Cena**
Když aplikace využívá Microsoft Office Automation, je třeba zakoupit kopii Microsoft Office pro každý počítač, na kterém aplikace běží. Často se však stává, že aplikace potřebuje vytvářet nebo upravovat soubor Office, aniž by uživatel potřeboval mít Microsoft Office nainstalovaný. Aspose nabízí velmi [Cost Effective](https://purchase.aspose.com/) a royalty‑free licenční model, který umožňuje nasazení na neomezený počet uživatelů bez licenčních starostí. Při tvorbě webových aplikací je důležité vědět, že komponenty Microsoft Office Automation nejsou cenově ani licenčně určeny pro serverová řešení; neexistuje tedy vhodná licenční cesta pro nasazení webových aplikací využívajících komponenty Microsoft Office. Aspose poskytuje velmi [Cost Effective](https://purchase.aspose.com/) řešení i pro serverové aplikace.

## **Funkce**
Komponenty Aspose poskytují vše potřebné pro správu souborů Office a mnohem více. Jsou navrženy tak, aby vývojářům umožnily dosáhnout co největších výsledků při co nejmenším úsilí. Na rozdíl od Office Automation nabízejí komponenty Aspose mnoho výkonných a čas šetřících funkcí. Například [Aspose.Cells](https://products.aspose.com/cells/cpp/) umožňuje vývojářům importovat data z **DataTable** nebo **DataView** přímo do Excel souboru. [Aspose.Words](https://products.aspose.com/words/net/) nabízí podobnou funkci, která umožňuje naplnit Word (Mail Merge) dokument přímo z libovolného C++ datového objektu. [Every Component](https://products.aspose.com/total/cpp/) v rodině Aspose poskytuje vlastní sadu unikátních a výkonných funkcí. Největší výhodou při nákupu komponenty Aspose je přístup k našim vývojářským týmům. Naše týmy si uvědomují, že pokud vaše společnost potřebuje určitou funkci, pravděpodobně ji budou potřebovat i další firmy. I když ne každou žádost o funkci lze implementovat, naše týmy se snaží být otevřené a flexibilní při poskytování pomoci. Tento přístup pomohl komponentám Aspose stát se tak výkonnými, jaké jsou. Pokud potřebujete dodatečné funkce, které nabízí objekty Office Automation, šance, že budou do Aspose přidány, jsou velmi, velmi nízké.

## **Závěr**
{{% alert color="primary" %}} 

I když tento článek pokrývá mnoho klíčových bodů, proč jsou komponenty Aspose lepší volbou než Office Automation, existuje mnohem více. Tento článek se zaměřuje pouze na nejdůležitější body. Všechny různé komponenty Aspose nabízejí bezrizikovou, nevyžadující závazek [Evaluation Version](https://downloads.aspose.com/slides/cs/cpp). Doporučujeme využít tuto [Evaluation](https://downloads.aspose.com/slides/cs/cpp) a lépe tak poznat, co Aspose dokáže pro vaše aplikace. 
{{% /alert %}}