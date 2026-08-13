---
title: Proč ne automatizace
type: docs
weight: 50
url: /cs/cpp/why-not-automation/
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
- C++
- Aspose.Slides
description: "Objevte, proč je automatizace Office riskantní pro servery a služby, a jak Aspose.Slides nabízí bezpečnější a rychlejší zpracování prezentací pro PowerPoint a OpenDocument."
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
- Proč jsou komponenty Aspose mnohem lepší volbou než Microsoft Office Automation?

Existují dvě otázky, které u nás v Aspose slyšíme nejčastěji:

- Vyžadují vaše produkty, aby byl nainstalován Microsoft Office, aby mohly běžet?

Krátká jednoduchá odpověď je **NE**. Aspose a komponenty Aspose jsou zcela nezávislé a nejsou spojeny s Microsoft Corporation, ani nejsou autorizovány, sponzorovány či schváleny společností Microsoft.

- Proč bychom měli používat produkty Aspose místo využívání Microsoft Office Automation?

Nejkratší odpovědí, kterou můžeme poskytnout, je, že existuje mnoho důvodů, přičemž nejdůležitější je, že *Microsoft sám důrazně nedoporučuje Office Automation v softwarových řešeních: [Microsoft Article

## **Bezpečnost**
Následující citát je přímou ukázkou výše zmíněného Microsoft Article :
*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Produkty Aspose jsou velmi bezpečné. Proto komponenty Aspose nepředstavují potenciální riziko pro životně důležité systémové prostředky. Navíc když je dokument otevřen komponentou Aspose, makra se nespouští automaticky. Komponenty Aspose byly vytvořeny s cílem umožnit vývojářům vytvářet, manipulovat a ukládat soubory Office. Žádná z rizik spojených s balíčkem Microsoft Office není inherentní komponentám Aspose.

## **Stabilita**
Následující citát je přímou ukázkou výše zmíněného Microsoft Article :
*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Protože jsou komponenty Aspose zabaleny do jediné DLL, nikdy není potřeba instalovat další součásti, aby fungovaly. Komponenty Aspose jsou využívány pouze v C++ aplikacích a neexistuje žádná část kódu komponenty, která by čekala na lidskou reakci. Komponenty Aspose byly důkladně otestovány a jsou extrémně stabilní. Komponenty Aspose používají [Společnosti](https://about.aspose.com/customers) jako: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** a mnoho dalších.

## **Škálovatelnost/Rychlost**
Následující citát je přímou ukázkou výše zmíněného Microsoft Article :

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Komponenty Aspose jsou vysoce škálovatelné a bleskově rychlé. Office aplikace nebyly navrženy pro současné používání stovkami či tisíci uživatelů. Komponenty Aspose jsou však navrženy právě pro to. Naše komponenty jsou pravým řešením v C++ a fungují bezchybně jak na jediném serveru, který napájí jediné aplikaci, tak na vyváženém Web Formu, který napájí podnikové aplikace.

## **Cena**
Když aplikace používá Microsoft Office Automation, je nutné zakoupit kopii Microsoft Office pro každý počítač, na kterém aplikace běží. Často se stává, že aplikace potřebuje vytvořit nebo upravit soubor Office, ale nevyžaduje, aby uživatel měl nainstalovaný Microsoft Office. Aspose nabízí velmi [Nákladově efektivní](https://purchase.aspose.com/) a royalty free licenci na redistribuci, která umožní nasazení na neomezený počet uživatelů bez starostí o licencování. Při vytváření webových aplikací je důležité vědět, že komponenty Microsoft Office Automation nejsou oceňovány ani licencovány pro serverová řešení; proto neexistuje vhodné licenční řešení pro nasazení webových aplikací, které využívají komponenty Microsoft Office. Aspose také nabízí velmi [Nákladově efektivní](https://purchase.aspose.com/) řešení pro serverové aplikace.

## **Funkce**
Komponenty Aspose poskytují vše, co je potřeba pro správu souborů Office, a ještě mnohem více. Jsou navrženy podle filozofie umožnit vývojářům dosáhnout největších výsledků s co nejmenší námahou. Na rozdíl od Office Automation poskytují komponenty Aspose mnoho výkonných a čas šetřících funkcí. Například [Aspose.Cells](https://products.aspose.com/cells/cpp/) nabízí vývojářům možnost importovat data z **DataTable** nebo **DataView** přímo do Excel souboru. [Aspose.Words](https://products.aspose.com/words/net/) nabízí podobnou funkci, která umožňuje vývojářům naplnit Word (Mail Merge) dokument přímo z libovolného C++ datového objektu. [Každá komponenta](https://products.aspose.com/total/cpp/) v rodině Aspose nabízí vlastní sadu unikátních a výkonných funkcí. Nejlepší částí nákupu komponenty Aspose je přístup k našim vývojovým týmům. Naše vývojové týmy si uvědomují, že pokud vaše společnost potřebuje určitou funkci, je pravděpodobné, že i jiné společnosti ji budou potřebovat. Zatímco není možné přidat každou žádost o funkci, naše týmy se snaží být velmi otevřené a flexibilní při poskytování pomoci. Tento přístup je tím, co pomohlo komponentám Aspose stát se tak výkonnými. Pokud potřebujete další funkce z objektů Office Automation, vaše šance, že budou přidány, jsou velmi, velmi nízké.

## **Závěr**
{{% alert color="info" %}} 

Zatímco tento článek pokryl mnoho klíčových důvodů, proč jsou komponenty Aspose lepší volbou než Office Automation, existuje mnohem více. Článek se zaměřuje především na nejdůležitější body. Všechny různé komponenty Aspose nabízejí bezrizikovou, bez závazků [Verzi pro vyzkoušení](https://downloads.aspose.com/slides/cs/cpp). Doporučujeme využít tuto [Verzi pro vyzkoušení](https://downloads.aspose.com/slides/cs/cpp), abyste lépe viděli, co Aspose může udělat pro vaše aplikace.
{{% /alert %}}