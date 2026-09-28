---
title: Proč ne automatizace
type: docs
weight: 170
url: /cs/net/why-not-automation/
keywords:
- automatizace
- Microsoft Office
- srovnání
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
description: "Objevte, proč je automatizace Office riskantní pro servery a služby, a jak Aspose.Slides poskytuje bezpečnější a rychlejší zpracování prezentací pro PowerPoint a OpenDocument."
---
## **Úvod**

Existuje několik důvodů, proč jsou komponenty Aspose lepší alternativou k automatizaci. Mezi hlavní důvody patří:

- Bezpečnost
- Stabilita
- Škálovatelnost/Rychlost
- Cena
- Funkce

Níže je podrobnější vysvětlení každého klíčového bodu.

## **Důležité otázky**

Existují dvě otázky, které často slyšíme u Aspose:

- Vyžadují vaše produkty instalaci Microsoft Office, aby mohly běžet?

Krátká, jednoduchá odpověď je **NE**.

Komponenty Aspose jsou zcela nezávislé a nejsou spojeny, autorizovány, sponzorovány ani jinak schváleny společností Microsoft Corporation.

- Proč máme používat produkty Aspose místo Microsoft Office Automation?

Nejprve existuje mnoho [výhod, které získáte při používání Aspose.Slides](/slides/cs/net/product-overview/).

Dále Microsoft sám silně **nedoporučuje** používat Office Automation v softwarových řešeních.

## **Bezpečnost**
Následující citát je přímým výpisem z Microsoft článku:

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Produkty Aspose jsou velmi **bezpečné**. Komponenty Aspose běží ve stejném uživatelském kontextu jako všechny ASP.NET aplikace (pod uživatelem ASPNET). Proto komponenty Aspose **nepředstavují** bezpečnostní riziko. Také nespotřebovávají kritické systémové zdroje. Navíc když komponenta Aspose otevře dokument, makra se nespustí automaticky. Komponenty Aspose byly vytvořeny tak, aby vývojářům umožnily vytvářet, upravovat a ukládat soubory Office.

{{% alert color="info" title="Note" %}}

Žádné z rizik spojených s balíčkem Microsoft Office se na komponenty Aspose nevztahují.

{{% /alert %}}

## **Stabilita**
Tento text je přímým citátem z dříve zmíněného Microsoft článku:

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Protože komponenty Aspose jsou zabaleny do jediné DLL, jejich uživatelé nikdy nemusí instalovat další části, aby fungovaly. Komponenty Aspose jsou využívány jen .NET aplikacemi a neexistuje žádná část kódu komponenty, která by čekala na lidskou odpověď.

{{% alert color="info" title="Note" %}}

Komponenty Aspose byly důkladně testovány a potvrzeny jako velmi stabilní. Komponenty Aspose používají [společnosti](https://about.aspose.com/customers/) jako **Bank of America** a mnoho dalších předních organizací v různých odvětvích a oblastech.

{{% /alert %}}

## **Škálovatelnost/Rychlost**
Následující citát je přímým výpisem z Microsoft článku:

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Komponenty Aspose jsou neuvěřitelně škálovatelné a bleskově rychlé. Office aplikace nebyly navrženy pro souběžné používání stovkami nebo tisíci uživatelů, ale komponenty Aspose jsou navrženy právě pro to. Naše komponenty jsou pravým řešením .NET.

{{% alert color="info" title="Note" %}}

Výkon komponent Aspose je bezchybně vysoký na jediném serveru (napájejícím jednu aplikaci) i na vyváženém webovém prostředí (napájejícím enterprise aplikaci).

{{% /alert %}}

## **Cena**
Když aplikace využívá Microsoft Office Automation, je nutné zakoupit kopii Microsoft Office pro každý počítač, na kterém aplikace běží. Existuje mnoho případů, kdy aplikace potřebuje vytvořit nebo upravit soubor Office, ale proces nevyžaduje Microsoft Office.

{{% alert color="info" title="Note" %}}

Aspose poskytuje velmi [nákladově-efektivní](https://purchase.aspose.com/) a royalty-free licenci pro redistribuci, která umožňuje nasazení neomezenému počtu uživatelů bez starostí o licence.

{{% /alert %}}

Při vytváření webových aplikací je důležité mít na paměti, že komponenty Microsoft Office Automation nejsou cenově ani licenčně určeny pro server-side řešení. Proto neexistuje dobré licenční řešení pro nasazení webových aplikací využívajících komponenty Microsoft Office. Aspose naopak nabízí velmi [nákladově-efektivní](https://purchase.aspose.com/) řešení i pro server-side aplikace.

## **Funkce**
Komponenty Aspose poskytují vše, co je potřeba pro správu souborů Office, a mnohem více. Navrhli jsme je podle našeho přesvědčení, že vývojářům pomůžeme dosáhnout co největších výsledků s co nejmenší námahou.

{{% alert color="info" title="Note" %}}

Na rozdíl od Office Automation poskytují komponenty Aspose mnoho výkonných a čas šetřících funkcí.

{{% /alert %}}

Například [Aspose.Cells](https://products.aspose.com/cells/net/) umožňuje vývojářům importovat data z **DataTable** nebo **DataView** přímo do souboru Excel. [Aspose.Words](https://products.aspose.com/words/net/) nabízí podobnou funkci, která umožňuje vývojářům naplnit Word (tj. Hromadnou korespondenci) dokument přímo z libovolného .NET datového objektu. [Každá komponenta](https://products.aspose.com/total/net/) v rodině Aspose nabízí svůj vlastní soubor jedinečných a výkonných funkcí.

Největší výhodou nákupu komponenty Aspose je přístup k našim vývojovým týmům. Například pokud používáte objekty Office Automation a potřebujete určité funkce, šance, že budou přidány, jsou velmi, velmi nízké. S komponentami Aspose je to jinak.

{{% alert color="info" title="Note" %}}

Naše vývojové týmy rozumí tomu, že pokud vaše firma potřebuje funkci, je pravděpodobné, že ji potřebují i další firmy. I když víme, že nemůžeme implementovat každou požadovanou funkci, usilujeme o přidání co největšího počtu funkcí na základě zpětné vazby od našich zákazníků.

{{% /alert %}}

Naše týmy jsou vždy otevřené a flexibilní při poskytování pomoci – a právě proto komponenty Aspose vyrostly do takové síly, jakou jsou dnes.

## **Závěr**
{{% alert color="info" title="Note" %}}

I když tento článek pokrývá některé klíčové body, proč jsou komponenty Aspose lepší volbou než Office Automation, musíte pochopit, že existuje mnohem více výhod. Prošli jsme jen některé z hlavních výhod.

Navíc všechny produkty a komponenty Aspose nabízejí bezrizikovou, bez závazku [Verzi ke zkušebnímu použití](https://releases.aspose.com/slides/net/). Doporučujeme využít zkušební verzi a zjistit, co Aspose může udělat pro vaše aplikace nebo podnikání.

{{% /alert %}}