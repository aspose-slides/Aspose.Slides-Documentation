---
title: Proč ne automatizace
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
description: "Objevte, proč je automatizace Office riskantní pro servery a služby, a zjistěte, jak Aspose.Slides nabízí bezpečnější a rychlejší zpracování prezentací pro PowerPoint a OpenDocument."
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

Existují dva otázky, které často slyšíme v Aspose:

- Vyžadují vaše produkty instalaci Microsoft Office, aby mohly běžet?

Krátká, jednoduchá odpověď je **NE**.

Komponenty Aspose jsou zcela nezávislé a nejsou spojeny, autorizovány, sponzorovány ani schváleny společností Microsoft Corporation.

- Proč bychom měli používat produkty Aspose místo Microsoft Office Automation?

Nejprve existuje mnoho [výhod, které získáte při použití Aspose.Slides](/slides/cs/net/product-overview/).

Druhá věc, Microsoft samotný silně **odrazuje** používání Office Automation ze softwarových řešení.

## **Bezpečnost**
Následující je přímý citát z článku Microsoftu: 

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Produkty Aspose jsou velmi **bezpečné**. Komponenty Aspose běží ve stejném uživatelském kontextu jako všechny aplikace ASP.NET (pod uživatelem ASPNET). Proto komponenty Aspose **nepředstavují** bezpečnostní riziko. Také nespotřebovávají kritické systémové zdroje. Navíc když komponenta Aspose otevře dokument, makra se automaticky nespustí. Komponenty Aspose byly vytvořeny tak, aby vývojářům umožnily vytvářet, manipulovat a ukládat soubory Office. 

{{% alert color="info" %}} 
Žádné z rizik spojených s balíčkem Microsoft Office se na komponenty Aspose nevztahují. 
{{% /alert %}} 

## **Stabilita**
Tento text je přímý citát z dříve zmíněného článku Microsoftu: 

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Protože jsou komponenty Aspose zabaleny do jediné DLL, uživatelé nikdy nemusí instalovat další části, aby fungovaly. Komponenty Aspose jsou využívány pouze aplikacemi .NET a neobsahují žádný kód, který by čekal na lidskou reakci. 

{{% alert color="info" %}} 
Komponenty Aspose byly důkladně testovány a potvrzeny jako vysoce stabilní. Komponenty Aspose používají [společnosti](http://www.aspose.com/Corporate/Aspose/Customerlist.html) jako **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** a mnoho dalších předních organizací v různých odvětvích. 
{{% /alert %}} 

## **Škálovatelnost/Rychlost**
Následující je přímý citát z článku Microsoftu: 

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Komponenty Aspose jsou neuvěřitelně škálovatelné a bleskově rychlé. Aplikace Office nebyly navrženy pro souběžné používání stovkami nebo tisíci uživatelů, zatímco komponenty Aspose jsou právě pro to vytvořeny. Naše komponenty jsou skutečným řešením .NET. 

{{% alert color="info" %}} 
Výkon komponent Aspose je dokonalý na jednom serveru (napájejícím jednu aplikaci) i v prostředí vyváženém zátěží (napájejícím podnikovou aplikaci). 
{{% /alert %}} 

## **Cena**
Když aplikace využívá Microsoft Office Automation, je třeba zakoupit kopii Microsoft Office pro každý stroj, na kterém aplikaci spouštíte. Existuje mnoho případů, kdy aplikace musí vytvořit nebo manipulovat soubor Office, ale proces nevyžaduje Microsoft Office. 

{{% alert color="info" %}} 
Aspose poskytuje velmi [nákladově efektivní](https://purchase.aspose.com/) a bezroyaltovou licenci na redistribuci, která umožňuje nasazení na neomezený počet uživatelů bez licenčních starostí. 
{{% /alert %}} 

Při vytváření webových aplikací je důležité si uvědomit, že komponenty Microsoft Office Automation nejsou cenově ani licenčně určeny pro serverová řešení. Proto neexistuje vhodné licenční řešení pro nasazení webových aplikací využívajících komponenty Microsoft Office. Aspose naopak poskytuje velmi [nákladově efektivní](https://purchase.aspose.com/) řešení také pro serverové aplikace.

## **Funkce**
Komponenty Aspose poskytují vše potřebné pro správu souborů Office a ještě mnohem víc. Navrhli jsme je podle naší filozofie pomoci vývojářům dosáhnout nejvyšších výsledků s co nejmenším úsilím. 

{{% alert color="info" %}} 
Na rozdíl od Office Automation poskytují komponenty Aspose mnoho výkonných a čas šetřících funkcí. 
{{% /alert %}} 

Například [Aspose.Cells](https://products.aspose.com/cells/net/) umožňuje vývojářům importovat data z **DataTable** nebo **DataView** přímo do souboru Excel. [Aspose.Words](https://products.aspose.com/words/net/) nabízí podobnou funkci, která umožňuje naplnit dokument Word (tj. hromadnou korespondenci) přímo z libovolného objektu .NET. [Každá komponenta](https://products.aspose.com/total/net/) v rodině Aspose nabízí svůj vlastní soubor unikátních a výkonných funkcí. 

Největší výhodou nákupu komponenty Aspose je přístup k našim vývojovým týmům. Například pokud používáte objekty Office Automation a potřebujete určité funkce, pravděpodobnost, že budou přidány, je velmi, velmi nízká. S komponentami Aspose je to jiné. 

{{% alert color="info" %}} 
Naše vývojové týmy chápou, že pokud nějaká funkce potřebuje vaše společnost, je pravděpodobné, že ji potřebují i jiné firmy. I když víme, že nemůžeme implementovat každou požadovanou funkci, usilujeme o přidání co největšího počtu funkcí na základě zpětné vazby od našich zákazníků. 
{{% /alert %}} 

Naše týmy jsou vždy otevřené a flexibilní při poskytování pomoci – a to je důvod, proč komponenty Aspose vyrostly do takového výkonu, jaký mají dnes. 

## **Závěr**
{{% alert color="info" %}} 
I když tento článek pokryl některé klíčové body, proč jsou komponenty Aspose lepší volbou než Office Automation, musíte pochopit, že existuje mnoho, mnoho dalších výhod. Uvedli jsme pouze některé z hlavních výhod. 

Navíc všechny produkty a komponenty Aspose nabízejí bezrizikovou, bez závazku [Evaluační verzi](https://downloads.aspose.com/slides/cs/net). Doporučujeme využít tuto evaluaci a zjistit, co může Aspose udělat pro vaše aplikace nebo podnik. 
{{% /alert %}}